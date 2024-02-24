Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql

Public Class FormCadFornecedor

    Dim _fornecedor As New Fornecedor
    Dim _fornecedorDao As New FornecedorDAO
    Dim _funcoes As New ClFuncoes

    Dim tipoOperacao As String = "I"

    Private Sub FormCadFornecedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExecutaF5()
    End Sub

    Private Sub FormCadFornecedor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F3
                ExecutaF3()
            Case Keys.F5
                ExecutaF5()
            Case Keys.Delete
                ExecuteDel()
        End Select

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click


        If IsNumeric(txtFornecedorID.Text) Then _fornecedor.Id = CInt(txtFornecedorID.Text)
        _fornecedor.Nome = Trim(txtFornecedorNome.Text)
        _fornecedor.ComissaoFornecedor = CDbl(txtComissaoFornecedor.Text)
        _fornecedor.ComissaoEntregador = CDbl(txtComissaoEntregador.Text)
        _fornecedor.ValorKM = CDbl(txtValorKM.Text)
        If _fornecedorDao.ValidaFornecedor(_fornecedor, tipoOperacao) = False Then Return

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If tipoOperacao.Equals("I") Then
                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _fornecedorDao.incFornecedor(_fornecedor, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _fornecedorDao.altFornecedor(_fornecedor, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Fornecedor Salvo com Sucesso!", MsgBoxStyle.Exclamation, Application.CompanyName)

            _fornecedorDao.TrazListFornecedoresBD(MdlConexaoBD.ListaFornecedores, MdlConexaoBD.conectionPadrao)
            _fornecedor.ZeraValores()

            txtFornecedorNome.Text = "" : txtFornecedorID.Text = ""
            txtComissaoFornecedor.Text = "0,00"
            txtComissaoEntregador.Text = "0,00"
            txtValorKM.Text = "0.00"
            ExecutaF5()
            tipoOperacao = "I"

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub ExecutaF5()
        _fornecedorDao.PreencheCboFornecedoresSoNomeBD(CboFornecedores, MdlConexaoBD.conectionPadrao)
        '_fornecedorDao.PreencheCboFornecedoresLista(CboFornecedores, ListaFornecedores)
    End Sub

    Sub ExecuteDel()
        'If MdlConexaoBD.sincronizado Then
        '    MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
        '    Return
        'End If

        If CboFornecedores.SelectedIndex < 0 Then MsgBox("Selecione um Fornecedor para Excluir!", MsgBoxStyle.Exclamation, Application.ProductName) : Return
        If MessageBox.Show("Deseja Realmente Deletar o Fornecedor -> """ & CboFornecedores.SelectedItem & """ ?", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


            _fornecedor.Nome = CboFornecedores.SelectedItem
            _fornecedorDao.TrazFornecedorPorNome(_fornecedor, MdlConexaoBD.conectionPadrao)


            Dim transacao As NpgsqlTransaction
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try

                Try
                    conection.Open()
                Catch ex As Exception
                    MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
                    Return
                End Try

                transacao = conection.BeginTransaction
                _fornecedorDao.delFornecedor(_fornecedor, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                MsgBox("Fornecedor Deletado com Sucesso!", MsgBoxStyle.Exclamation, Application.CompanyName)
                _fornecedorDao.TrazListFornecedoresBD(MdlConexaoBD.ListaFornecedores, MdlConexaoBD.conectionPadrao)
                txtFornecedorNome.Text = ""
                txtComissaoFornecedor.Text = "0,00"
                txtComissaoEntregador.Text = "0,00"
                ExecutaF5()
                tipoOperacao = "I"
            Catch ex As Exception
                MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                Try
                    transacao.Rollback()

                Catch ex1 As Exception
                End Try

            Finally
                transacao = Nothing : conection = Nothing
            End Try



        End If

    End Sub

    Sub ExecutaF3()
        'If MdlConexaoBD.sincronizado Then
        '    MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
        '    Return
        'End If

        If CboFornecedores.SelectedIndex < 0 Then
            MsgBox("Selecione um Fornecedor para Alterar!", MsgBoxStyle.Exclamation, Application.CompanyName)
            CboFornecedores.DroppedDown = True
            Return
        End If

        _fornecedor.Nome = CboFornecedores.SelectedItem
        _fornecedorDao.TrazFornecedorPorNome(_fornecedor, MdlConexaoBD.conectionPadrao)

        tipoOperacao = "A"
        txtFornecedorID.Text = _fornecedor.Id
        txtFornecedorNome.Text = _fornecedor.Nome
        txtComissaoFornecedor.Text = _fornecedor.ComissaoFornecedor.ToString("0.00")
        txtComissaoEntregador.Text = _fornecedor.ComissaoEntregador.ToString("0.00")
        txtValorKM.Text = _fornecedor.ValorKM.ToString("0.00")
        txtFornecedorNome.Focus()

    End Sub

    Private Sub txtComissao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComissaoFornecedor.KeyPress
        'permite só numeros virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtComissao_Leave(sender As Object, e As EventArgs) Handles txtComissaoFornecedor.Leave


        If IsNumeric(txtComissaoFornecedor.Text) Then

            txtComissaoFornecedor.Text = CDbl(txtComissaoFornecedor.Text).ToString("0.00")
        Else
            txtComissaoFornecedor.Text = "0,00"
        End If


    End Sub

    Private Sub FormCadFornecedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtComissaoEntregador_Leave(sender As Object, e As EventArgs) Handles txtComissaoEntregador.Leave

        If IsNumeric(txtComissaoEntregador.Text) Then

            txtComissaoEntregador.Text = CDbl(txtComissaoEntregador.Text).ToString("0.00")
        Else
            txtComissaoEntregador.Text = "0,00"
        End If

    End Sub

    Private Sub txtValorKM_Leave(sender As Object, e As EventArgs) Handles txtValorKM.Leave

        If IsNumeric(txtValorKM.Text) Then

            txtValorKM.Text = CDbl(txtValorKM.Text).ToString("0.00")
        Else
            txtValorKM.Text = "0,00"
        End If

    End Sub
End Class