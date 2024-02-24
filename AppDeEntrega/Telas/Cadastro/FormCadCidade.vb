Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql
Public Class FormCadCidade

    Dim _Cidade As New Cidade
    Dim _CidadeDAO As New CidadeDAO
    Dim _funcoes As New ClFuncoes

    Dim _tipoOperacao As String = "I"

    Private Sub FormCadCidade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExecutaF5()
    End Sub

    Private Sub FormCadCidade_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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


        If IsNumeric(txtCidadeID.Text) Then _Cidade.Id = CInt(txtCidadeID.Text)
        _Cidade.Nome = Trim(txtCidadeNome.Text)
        _Cidade.DistanciaKM = CDbl(txtDistanciaKM.Text)
        If _CidadeDAO.ValidaCidade(_Cidade, _tipoOperacao) = False Then Return

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If _tipoOperacao.Equals("I") Then
                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _CidadeDAO.incCidade(_Cidade, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _CidadeDAO.altCidade(_Cidade, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Cidade Gravada com Sucesso!", MsgBoxStyle.Exclamation, Application.ProductName)
            _CidadeDAO.TrazListCidadesDoBD(MdlConexaoBD.ListaCidades, MdlConexaoBD.conectionPadrao)
            txtCidadeNome.Text = "" : txtCidadeID.Text = "" : txtDistanciaKM.Text = "0"
            _Cidade.ZeraValores()
            ExecutaF5()
            _tipoOperacao = "I"
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub ExecutaF5()
        _CidadeDAO.PreencheCboCidadesBD(CboCidades, MdlConexaoBD.conectionPadrao)
    End Sub

    Sub ExecuteDel()

        If CboCidades.SelectedIndex < 0 Then MsgBox("Selecione uma Cidade para Excluir!", MsgBoxStyle.Exclamation, Application.ProductName) : Return
        If MessageBox.Show("Deseja Realmente Deletar a Cidade -> """ & CboCidades.SelectedItem & """ ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


            _Cidade.Nome = CboCidades.SelectedItem
            _CidadeDAO.TrazCidadePorNomeBD(_Cidade, MdlConexaoBD.conectionPadrao)


            Dim transacao As NpgsqlTransaction
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try

                Try
                    conection.Open()
                Catch ex As Exception
                    MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.ProductName)
                    Return
                End Try

                transacao = conection.BeginTransaction
                _CidadeDAO.delCidade(_Cidade, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                MsgBox("Cidade Deletada com Sucesso!", MsgBoxStyle.Exclamation, Application.ProductName)
                _CidadeDAO.TrazListCidadesDoBD(MdlConexaoBD.ListaCidades, MdlConexaoBD.conectionPadrao)
                ExecutaF5()
                _tipoOperacao = "I"
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
        If CboCidades.SelectedIndex < 0 Then MsgBox("Selecione uma Cidade para Alterar!", MsgBoxStyle.Exclamation, Application.ProductName) : Return
        _Cidade.Nome = CboCidades.SelectedItem
        _CidadeDAO.TrazCidadePorNomeBD(_Cidade, MdlConexaoBD.conectionPadrao)

        _tipoOperacao = "A"
        txtCidadeID.Text = _Cidade.Id
        txtCidadeNome.Text = _Cidade.Nome
        txtDistanciaKM.Text = _Cidade.DistanciaKM.ToString("0.00")
        txtCidadeNome.Focus()

    End Sub

    Private Sub txtDistanciaKM_Leave(sender As Object, e As EventArgs) Handles txtDistanciaKM.Leave

        If IsNumeric(txtDistanciaKM.Text) Then

            txtDistanciaKM.Text = CDbl(txtDistanciaKM.Text).ToString("0.00")
        Else
            txtDistanciaKM.Text = "0,00"
        End If
    End Sub
End Class