Imports Npgsql
Public Class CidadeDAO

    Public Sub incCidade(ByVal cidade As Cidade, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO cidade(id, nome, distancia_km) "
        sql += "VALUES (DEFAULT, @nome, @distancia_km)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@nome", cidade.Nome)
        comm.Parameters.Add("@distancia_km", cidade.DistanciaKM)
        comm.ExecuteNonQuery()

        TrazListCidadesDoBD(MdlConexaoBD.ListaCidades, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altCidade(ByVal cidade As Cidade, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE cidade SET nome = @nome, distancia_km = @distancia_km WHERE id = @id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", cidade.Id)
        comm.Parameters.Add("@nome", cidade.Nome)
        comm.Parameters.Add("@distancia_km", cidade.DistanciaKM)
        comm.ExecuteNonQuery()

        TrazListCidadesDoBD(MdlConexaoBD.ListaCidades, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaCidade(ByVal cidade As Cidade, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(cidade.Nome).Equals("") Then MsgBox("Informe um NOME para a Cidade!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT nome FROM cidade WHERE nome = '" & cidade.Nome & "'"
        Else
            consulta = "SELECT nome FROM cidade WHERE id <> " & cidade.Id & " AND nome = '" & cidade.Nome & "'"
        End If
        If cidadeConsulta(cidade, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("A Cidade """ & cidade.Nome & """ já existe em outro CADASTRO !") : Return False
        End If

        Return True
    End Function

    Public Sub TrazListCidadesDoBD(ByRef cidade As List(Of Cidade), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""CidadeDAO:TrazListCidadesBD"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, nome, distancia_km FROM cidade "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cidade.Clear()
        While dr.Read

            cidade.Add(New Cidade(dr(0), dr(1).ToString, dr(2)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazCidadeID(ByRef cidade As Cidade, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""CidadeDAO:TrazCidadeID"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT id, nome, distancia_km FROM cidade WHERE id = " & cidade.Id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            cidade.Id = dr(0)
            cidade.Nome = dr(1).ToString
            cidade.DistanciaKM = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazCidadePorNomeBD(ByRef cidade As Cidade, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""CidadeDAO:TrazCidadeNome"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT id, nome, distancia_km FROM cidade WHERE nome = '" & cidade.Nome & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            cidade.Id = dr(0)
            cidade.Nome = dr(1).ToString
            cidade.DistanciaKM = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazCidadePorNomeDaLista(ByRef cidade As Cidade) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As Cidade In MdlConexaoBD.ListaCidades

            If a.Nome.Equals(cidade.Nome) Then

                With cidade

                    .Id = a.Id
                    .Nome = a.Nome
                    .DistanciaKM = a.DistanciaKM
                End With
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazCidadeNomeDaLista(ByRef cidade As Cidade, ByVal Listacidades As List(Of Cidade)) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As Cidade In Listacidades

            If a.Nome.Equals(cidade.Nome) Then

                With cidade

                    .Id = a.Id
                    .Nome = a.Nome
                    .DistanciaKM = a.DistanciaKM
                End With
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Sub PreencheCboCidadesBD(ByRef cbocidade As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""CidadeDAO:PreencheCboCidades"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT nome, id FROM cidade "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY nome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cbocidade.Items.Clear()
        If dr.HasRows = True Then
            cbocidade.AutoCompleteCustomSource.Clear()
            cbocidade.Items.Clear()
            cbocidade.Refresh()
            While dr.Read

                cbocidade.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cbocidade.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cbocidade.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboCidadesPesquisaBD(ByRef cbocidade As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""CidadeDAO:PreencheCboCidades"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT nome, id FROM cidade "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY nome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cbocidade.Items.Clear()
        If dr.HasRows = True Then
            cbocidade.AutoCompleteCustomSource.Clear()
            cbocidade.Items.Clear()
            cbocidade.Refresh()
            cbocidade.AutoCompleteCustomSource.Add("<< TODOS >>")
            cbocidade.Items.Add("<< TODOS >>")

            While dr.Read

                cbocidade.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cbocidade.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cbocidade.SelectedIndex = -1
            If cbocidade.Items.Count > 1 Then cbocidade.SelectedIndex = 0
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboCidadesLista(ByRef cbocidade As ComboBox, ByVal listcidades As List(Of Cidade))

        If listcidades.Count > 0 Then

            cbocidade.AutoCompleteCustomSource.Clear()
            cbocidade.Items.Clear()
            cbocidade.Refresh()

            For Each a As Cidade In listcidades

                cbocidade.AutoCompleteCustomSource.Add(a.Nome) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cbocidade.Items.Add(a.Nome) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
        End If

    End Sub

    Public Sub PreencheCboCidadesListaPesquisa(ByRef cbocidade As ComboBox, ByVal listcidades As List(Of Cidade))

        If listcidades.Count > 0 Then

            cbocidade.AutoCompleteCustomSource.Clear()
            cbocidade.Items.Clear()
            cbocidade.Refresh()
            cbocidade.AutoCompleteCustomSource.Add("<< TODOS >>")
            cbocidade.Items.Add("<< TODOS >>")
            For Each a As Cidade In listcidades

                cbocidade.AutoCompleteCustomSource.Add(a.Nome) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cbocidade.Items.Add(a.Nome) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
            cbocidade.SelectedIndex = 0
        End If

    End Sub

    Public Sub PreencheCboCidadesRelatorio(ByRef cbocidade As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""CidadeDAO:PreencheCboCidades"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT nome, id FROM cidade "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY nome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cbocidade.Items.Clear()
        If dr.HasRows = True Then
            cbocidade.AutoCompleteCustomSource.Clear()
            cbocidade.Items.Clear()
            cbocidade.Refresh()
            cbocidade.AutoCompleteCustomSource.Add("< TODOS >")
            cbocidade.Items.Add("< TODOS >")

            While dr.Read

                cbocidade.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cbocidade.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cbocidade.SelectedIndex = -1
            If cbocidade.Items.Count > 1 Then cbocidade.SelectedIndex = 0
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delCidade(ByVal cidade As Cidade, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM cidade WHERE id = @id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", cidade.Id)

        comm.ExecuteNonQuery()

        TrazListCidadesDoBD(MdlConexaoBD.ListaCidades, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function cidadeConsulta(ByRef cidade As Cidade, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""CidadeDAO:CidadeConsulta"":: " & ex.Message)
            Return False
        End Try

        consulta = Query
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader
        If dr.HasRows Then
            Return True
        Else
            Return False
        End If

        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

End Class
