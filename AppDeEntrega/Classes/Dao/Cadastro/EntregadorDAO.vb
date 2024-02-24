Imports Npgsql
Public Class EntregadorDAO

    Public Sub incEntregador(ByVal vEntregador As Entregador, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO entregador(id, nome, comissao) "
        sql += "VALUES (DEFAULT, @nome, @comissao)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@nome", vEntregador.Nome)
        comm.Parameters.Add("@comissao", vEntregador.Comissao)
        comm.ExecuteNonQuery()

        TrazListEntregadores_BD(MdlConexaoBD.ListaEntregadores, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altEntregador(ByVal vEntregador As Entregador, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE Entregador SET nome = @nome, comissao = @comissao WHERE id = @id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vEntregador.Id)
        comm.Parameters.Add("@nome", vEntregador.Nome)
        comm.Parameters.Add("@comissao", vEntregador.Comissao)
        comm.ExecuteNonQuery()

        TrazListEntregadores_BD(MdlConexaoBD.ListaEntregadores, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaEntregador(ByVal vEntregador As Entregador, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(vEntregador.Nome).Equals("") Then MsgBox("Informe um NOME para o Entregador!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT nome FROM entregador WHERE nome = '" & vEntregador.Nome & "'"
        Else
            consulta = "SELECT nome FROM entregador WHERE id <> " & vEntregador.Id & " AND nome = '" & vEntregador.Nome & "'"
        End If
        If EntregadorConsulta(vEntregador, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O Entregador """ & vEntregador.Nome & """ já existe em outro CADASTRO !") : Return False
        End If

        Return True
    End Function

    Public Sub TrazListEntregadores_BD(ByRef vEntregadores As List(Of Entregador), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EntregadorDAO:TrazListEntregadores"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, nome, comissao FROM entregador "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        vEntregadores.Clear()
        While dr.Read

            vEntregadores.Add(New Entregador(dr(0), dr(1).ToString, dr(2)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazEntregador(ByRef vEntregador As Entregador, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EntregadorDAO:TrazEntregador"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT id, nome, comissao FROM entregador WHERE id = " & vEntregador.Id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            vEntregador.Id = dr(0)
            vEntregador.Nome = dr(1).ToString
            vEntregador.Comissao = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazEntregadorPorNome(ByRef vEntregador As Entregador, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EntregadorDAO:TrazEntregadorNome"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT id, nome, comissao FROM entregador WHERE nome = '" & vEntregador.Nome & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            vEntregador.Id = dr(0)
            vEntregador.Nome = dr(1).ToString
            vEntregador.Comissao = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazEntregadorNomeDaLista(ByRef vEntregador As Entregador) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As Entregador In MdlConexaoBD.ListaEntregadores

            If a.Nome.Equals(vEntregador.Nome) Then

                With vEntregador

                    .Id = a.Id
                    .Nome = a.Nome
                    .Comissao = a.Comissao
                End With
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazEntregadorNomeDaLista(ByRef vEntregador As Entregador, ByVal ListaEntregadores As List(Of Entregador)) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As Entregador In ListaEntregadores

            If a.Nome.Equals(vEntregador.Nome) Then

                With vEntregador

                    .Id = a.Id
                    .Nome = a.Nome
                    .Comissao = a.Comissao
                End With
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Sub PreencheCboEntregadoresBD(ByRef cboEntregador As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EntregadorDAO:PreencheCboEntregadores"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT nome, id FROM entregador "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY nome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboEntregador.Items.Clear()
        If dr.HasRows = True Then
            cboEntregador.AutoCompleteCustomSource.Clear()
            cboEntregador.Items.Clear()
            cboEntregador.Refresh()
            While dr.Read

                cboEntregador.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboEntregador.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboEntregador.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboEntregadoresPesquisaBD(ByRef cboEntregador As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EntregadorDAO:PreencheCboEntregadores"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT nome, id FROM entregador "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY nome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboEntregador.Items.Clear()
        If dr.HasRows = True Then
            cboEntregador.AutoCompleteCustomSource.Clear()
            cboEntregador.Items.Clear()
            cboEntregador.Refresh()
            cboEntregador.AutoCompleteCustomSource.Add("<< TODOS >>")
            cboEntregador.Items.Add("<< TODOS >>")

            While dr.Read

                cboEntregador.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboEntregador.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboEntregador.SelectedIndex = -1
            If cboEntregador.Items.Count > 1 Then cboEntregador.SelectedIndex = 0
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboEntregadoresLista(ByRef cboEntregador As ComboBox, ByVal listEntregadores As List(Of Entregador))

        If listEntregadores.Count > 0 Then

            cboEntregador.AutoCompleteCustomSource.Clear()
            cboEntregador.Items.Clear()
            cboEntregador.Refresh()

            For Each a As Entregador In listEntregadores

                cboEntregador.AutoCompleteCustomSource.Add(a.Nome) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboEntregador.Items.Add(a.Nome) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
        End If

    End Sub

    Public Sub PreencheCboEntregadoresListaPesquisa(ByRef cboEntregador As ComboBox, ByVal listEntregadores As List(Of Entregador))

        If listEntregadores.Count > 0 Then

            cboEntregador.AutoCompleteCustomSource.Clear()
            cboEntregador.Items.Clear()
            cboEntregador.Refresh()
            cboEntregador.AutoCompleteCustomSource.Add("<< TODOS >>")
            cboEntregador.Items.Add("<< TODOS >>")
            For Each a As Entregador In listEntregadores

                cboEntregador.AutoCompleteCustomSource.Add(a.Nome) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboEntregador.Items.Add(a.Nome) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
            cboEntregador.SelectedIndex = 0
        End If

    End Sub

    Public Sub PreencheCboEntregadoresRelatorio(ByRef cboEntregador As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EntregadorDAO:PreencheCboEntregadores"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT nome, id FROM entregador "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY nome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboEntregador.Items.Clear()
        If dr.HasRows = True Then
            cboEntregador.AutoCompleteCustomSource.Clear()
            cboEntregador.Items.Clear()
            cboEntregador.Refresh()
            cboEntregador.AutoCompleteCustomSource.Add("< TODOS >")
            cboEntregador.Items.Add("< TODOS >")

            While dr.Read

                cboEntregador.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboEntregador.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboEntregador.SelectedIndex = 0
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delEntregador(ByVal vEntregador As Entregador, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM entregador WHERE id = @id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vEntregador.Id)

        comm.ExecuteNonQuery()

        TrazListEntregadores_BD(MdlConexaoBD.ListaEntregadores, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function EntregadorConsulta(ByRef vEntregador As Entregador, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EntregadorDAO:EntregadorConsulta"":: " & ex.Message)
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
