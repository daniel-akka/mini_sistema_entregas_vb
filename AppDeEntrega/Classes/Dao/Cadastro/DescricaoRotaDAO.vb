Imports Npgsql
Public Class DescricaoRotaDAO

    Public Sub PreencheCboDescricaoRotasBD(ByRef cboBairro As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""BairroDAO:PreencheCboBairros"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT descricao FROM descricao_rota "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboBairro.Items.Clear()
        If dr.HasRows = True Then
            cboBairro.AutoCompleteCustomSource.Clear()
            cboBairro.Items.Clear()
            cboBairro.Refresh()
            While dr.Read

                cboBairro.AutoCompleteCustomSource.Add(dr(0).ToString)
                cboBairro.Items.Add(dr(0).ToString)
            End While

            cboBairro.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub incDescricaoRota(ByVal descricaoRota As DescricaoRota, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO descricao_rota(id, descricao)"
        sql += "VALUES (DEFAULT, @descricao)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@descricao", descricaoRota.descricao)
        Try
            comm.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        comm = Nothing : sql = Nothing
    End Sub

    Public Sub incDescricaoRota(ByVal descricaoRota As DescricaoRota, ByVal conexao As String)

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(conexao)
        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        Try
            conection.Open()
            sql = "INSERT INTO descricao_rota(id, descricao)"
            sql += "VALUES (DEFAULT, @descricao)"

            comm.Transaction = transacao
            comm = New NpgsqlCommand(sql, conection)
            ' Prepara Paramentros
            comm.Parameters.Add("@descricao", descricaoRota.descricao)
            

        Catch ex As Exception
            ' MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.ProductName)
            transacao.Rollback()
            Return
        Finally
            If conection.State = ConnectionState.Open Then conection.Close()
            transacao = Nothing : conection = Nothing

        End Try

        


        comm = Nothing : sql = Nothing

    End Sub
End Class
