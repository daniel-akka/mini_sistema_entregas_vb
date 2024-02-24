Imports Npgsql
Public Class FormCadEmpresa

    Private _empresa As New Empresa
    Private _empresaDAO As New EmpresaDAO

    Private Sub FormCadEmpresa_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        PreencheValoresEmpresa()
        If _empresaDAO.ValidaEmpresa(_empresa) = False Then
            Return
        End If

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
            connection = Nothing : Return
        End Try

        Dim transacao As NpgsqlTransaction = connection.BeginTransaction

        _empresaDAO.altEmpresa(_empresa, connection, transacao)

        transacao.Commit()
        connection.Close()
        MsgBox("Empresa Salva Com Sucesso!", MsgBoxStyle.Exclamation, Application.ProductName)
        Me.Close()

    End Sub

    Private Sub FormCadEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _empresa.SetaEmpresa(_empresaDAO.TrazEmpresa(MdlConexaoBD.conectionPadrao))
        txtEmpresaID.Text = _empresa.Id
        txtEmpresaNome.Text = _empresa.Nome
    End Sub

    Sub PreencheValoresEmpresa()

        With _empresa
            .Id = CInt(txtEmpresaID.Text)
            .Nome = txtEmpresaNome.Text
        End With
    End Sub

End Class