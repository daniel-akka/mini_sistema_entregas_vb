Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql

Public Class FormCadValorAdicional

    Dim _valorAdicional As New ValorAdicional
    Dim _valorAdicionalDao As New ValorAdicionalDAO
    Dim _funcoes As New ClFuncoes

    Dim tipoOperacao As String = "I"

    Private Sub FormCadValorAdicional_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExecutaF5()
    End Sub

    Private Sub FormCadValorAdicional_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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


        If IsNumeric(txtValorAdicionalID.Text) Then _valorAdicional.Id = CInt(txtValorAdicionalID.Text)
        _valorAdicional.Descricao = Trim(txtValorAdicionalDescricao.Text)
        _valorAdicional.Valor = CDbl(txtValorAdicionalValor.Text)
        If _valorAdicionalDao.ValidaValorAdicional(_valorAdicional, tipoOperacao) = False Then Return

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
                _valorAdicionalDao.incValorAdicional(_valorAdicional, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _valorAdicionalDao.altValorAdicional(_valorAdicional, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Valor Adicional Salvo com Sucesso!", MsgBoxStyle.Exclamation, Application.CompanyName)
            _valorAdicionalDao.TrazListValorAdicionalDoBD(MdlConexaoBD.ListaValorAdicional, MdlConexaoBD.conectionPadrao)
            txtValorAdicionalDescricao.Text = "" : txtValorAdicionalID.Text = "" : txtValorAdicionalValor.Text = "0,00"
            _valorAdicional.ZeraValores()
            ExecutaF5()
            tipoOperacao = "I"
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub ExecutaF5()
        _valorAdicionalDao.PreencheCboValorAdicionalBD(CboValoresAdicionais, MdlConexaoBD.conectionPadrao)
        '_valorAdicionalDao.PreencheCboValor AdicionalesLista(CboValor Adicionales, ListaValor Adicionales)
    End Sub

    Sub ExecuteDel()
        'If MdlConexaoBD.sincronizado Then
        '    MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
        '    Return
        'End If

        If CboValoresAdicionais.SelectedIndex < 0 Then MsgBox("Selecione um Valor Adicional para Excluir!") : Return
        If MessageBox.Show("Deseja Realmente Deletar o Valor Adicional -> """ & CboValoresAdicionais.SelectedItem & """ ?", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


            _valorAdicional.Descricao = CboValoresAdicionais.SelectedItem
            _valorAdicionalDao.TrazValorAdicionalPorNome(_valorAdicional, MdlConexaoBD.conectionPadrao)


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
                _valorAdicionalDao.delValorAdicional(_valorAdicional, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                MsgBox("Valor Adicional Deletado com Sucesso!", MsgBoxStyle.Exclamation, Application.CompanyName)
                _valorAdicionalDao.TrazListValorAdicionalDoBD(MdlConexaoBD.ListaValorAdicional, MdlConexaoBD.conectionPadrao)
                txtValorAdicionalDescricao.Text = ""
                txtValorAdicionalValor.Text = "0,00"
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

        If CboValoresAdicionais.SelectedIndex < 0 Then MsgBox("Selecione um Valor Adicional para Alterar!", MsgBoxStyle.Exclamation, Application.CompanyName) : Return
        _valorAdicional.Descricao = CboValoresAdicionais.SelectedItem
        _valorAdicionalDao.TrazValorAdicionalPorNome(_valorAdicional, MdlConexaoBD.conectionPadrao)

        tipoOperacao = "A"
        txtValorAdicionalID.Text = _valorAdicional.Id
        txtValorAdicionalDescricao.Text = _valorAdicional.Descricao
        txtValorAdicionalValor.Text = _valorAdicional.Valor.ToString("0.00")
        txtValorAdicionalDescricao.Focus()

    End Sub

    Private Sub txtComissao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValorAdicionalValor.KeyPress
        'permite só numeros virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtComissao_Leave(sender As Object, e As EventArgs) Handles txtValorAdicionalValor.Leave


        If IsNumeric(txtValorAdicionalValor.Text) Then

            txtValorAdicionalValor.Text = CDbl(txtValorAdicionalValor.Text).ToString("0.00")
        Else
            txtValorAdicionalValor.Text = "0,00"
        End If


    End Sub

    Private Sub FormCadValorAdicional_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

End Class