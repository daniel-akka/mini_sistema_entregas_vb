Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql

Public Class FormCadEntregador

    Dim _entregador As New Entregador
    Dim _entregadorDao As New EntregadorDAO
    Dim _funcoes As New ClFuncoes

    Dim tipoOperacao As String = "I"

    Private Sub FormCadEntregador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExecutaF5()
    End Sub

    Private Sub FormCadEntregador_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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


        If IsNumeric(txtEntregadorID.Text) Then _entregador.Id = CInt(txtEntregadorID.Text)
        _entregador.Nome = Trim(txtEntregadorNome.Text)
        _entregador.Comissao = CDbl(txtEntregadorComissao.Text)
        If _entregadorDao.ValidaEntregador(_entregador, tipoOperacao) = False Then Return

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
                _entregadorDao.incEntregador(_entregador, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _entregadorDao.altEntregador(_entregador, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Entregador Salvo com Sucesso!", MsgBoxStyle.Exclamation, Application.CompanyName)
            _entregadorDao.TrazListEntregadores_BD(MdlConexaoBD.ListaEntregadores, MdlConexaoBD.conectionPadrao)
            txtEntregadorNome.Text = "" : txtEntregadorID.Text = "" : txtEntregadorComissao.Text = "0,00"
            _entregador.ZeraValores()
            ExecutaF5()
            tipoOperacao = "I"
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub ExecutaF5()
        _entregadorDao.PreencheCboEntregadoresBD(CboEntregadores, MdlConexaoBD.conectionPadrao)
        '_entregadorDao.PreencheCboEntregadoresLista(CboEntregadores, ListaEntregadores)
    End Sub

    Sub ExecuteDel()
        'If MdlConexaoBD.sincronizado Then
        '    MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
        '    Return
        'End If

        If CboEntregadores.SelectedIndex < 0 Then MsgBox("Selecione um Entregador para Excluir!", MsgBoxStyle.Exclamation, Application.ProductName) : Return
        If MessageBox.Show("Deseja Realmente Deletar o Entregador -> """ & CboEntregadores.SelectedItem & """ ?", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


            _entregador.Nome = CboEntregadores.SelectedItem
            _entregadorDao.TrazEntregadorPorNome(_entregador, MdlConexaoBD.conectionPadrao)


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
                _entregadorDao.delEntregador(_entregador, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                MsgBox("Entregador Deletado com Sucesso!", MsgBoxStyle.Exclamation, Application.CompanyName)
                _entregadorDao.TrazListEntregadores_BD(MdlConexaoBD.ListaEntregadores, MdlConexaoBD.conectionPadrao)
                txtEntregadorNome.Text = ""
                txtEntregadorComissao.Text = "0,00"
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

        If CboEntregadores.SelectedIndex < 0 Then MsgBox("Selecione um Entregador para Alterar!", MsgBoxStyle.Exclamation, Application.CompanyName) : Return
        _entregador.Nome = CboEntregadores.SelectedItem
        _entregadorDao.TrazEntregadorPorNome(_entregador, MdlConexaoBD.conectionPadrao)

        tipoOperacao = "A"
        txtEntregadorID.Text = _entregador.Id
        txtEntregadorNome.Text = _entregador.Nome
        txtEntregadorComissao.Text = _entregador.Comissao.ToString("0.00")
        txtEntregadorNome.Focus()

    End Sub

    Private Sub txtComissao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEntregadorComissao.KeyPress
        'permite só numeros virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtComissao_Leave(sender As Object, e As EventArgs) Handles txtEntregadorComissao.Leave


        If IsNumeric(txtEntregadorComissao.Text) Then

            txtEntregadorComissao.Text = CDbl(txtEntregadorComissao.Text).ToString("0.00")
        Else
            txtEntregadorComissao.Text = "0,00"
        End If


    End Sub

    Private Sub FormCadEntregador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

End Class