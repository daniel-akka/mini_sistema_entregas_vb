Imports Npgsql
Public Class FornecedorDAO


    Dim _funcoes As New ClFuncoes

    Public Sub incFornecedor(ByVal vFornecedor As Fornecedor, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO fornecedor(id, nome, comissao_fornecedor, comissao_entregador, valor_km)"
        sql += "VALUES (DEFAULT, @nome, @comissao_fornecedor, @comissao_entregador, @valor_km)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@nome", vFornecedor.Nome)
        comm.Parameters.Add("@comissao_fornecedor", vFornecedor.ComissaoFornecedor)
        comm.Parameters.Add("@comissao_entregador", vFornecedor.ComissaoEntregador)
        comm.Parameters.Add("@valor_km", vFornecedor.ValorKM)

        comm.ExecuteNonQuery()

        TrazListFornecedoresBD(MdlConexaoBD.ListaFornecedores, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altFornecedor(ByVal vFornecedor As Fornecedor, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE fornecedor SET nome = @nome, comissao_fornecedor = @comissao_fornecedor, comissao_entregador = @comissao_entregador, "
        sql += "valor_km = @valor_km WHERE id = @id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vFornecedor.Id)
        comm.Parameters.Add("@nome", vFornecedor.Nome)
        comm.Parameters.Add("@comissao_fornecedor", vFornecedor.ComissaoFornecedor)
        comm.Parameters.Add("@comissao_entregador", vFornecedor.ComissaoEntregador)
        comm.Parameters.Add("@valor_km", vFornecedor.ValorKM)

        comm.ExecuteNonQuery()

        TrazListFornecedoresBD(MdlConexaoBD.ListaFornecedores, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaFornecedor(ByVal vFornecedor As Fornecedor, Optional ByVal Operacao As String = "I") As Boolean
        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT id FROM fornecedor WHERE id = " & vFornecedor.Id
        Else
            consulta = "SELECT id FROM fornecedor WHERE id <> " & vFornecedor.Id & " AND nome = '" & vFornecedor.Nome & "'"
        End If
        If FornecedorConsulta(vFornecedor, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O Fornecedor """ & vFornecedor.Nome & """ já existe em outro Cadastro !") : Return False
        End If

        Return True
    End Function

    Public Function FornecedorConsulta(ByRef vFornecedor As Fornecedor, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FornecedorDAO:TrazFornecedor"":: " & ex.Message)
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

    Public Function TrazFornecedorPorID(ByRef vFornecedor As Fornecedor, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FornecedorDAO:TrazFornecedor"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT id, nome, comissao_fornecedor, comissao_entregador, valor_km "
        consulta += "FROM fornecedor WHERE id = " & vFornecedor.Id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vFornecedor

                .Id = dr(0)
                .Nome = dr(1).ToString
                .ComissaoFornecedor = dr(2)
                .ComissaoEntregador = dr(3)
                .ValorKM = dr(4)
            End With
            

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazFornecedorPorNome(ByRef vFornecedor As Fornecedor, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FornecedorDAO:TrazFornecedorPorNome"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT id, nome, comissao_fornecedor, comissao_entregador, valor_km "
        consulta += "FROM fornecedor WHERE nome like '" & vFornecedor.Nome & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vFornecedor

                .Id = dr(0)
                .Nome = dr(1).ToString
                .ComissaoFornecedor = dr(2)
                .ComissaoEntregador = dr(3)
                .ValorKM = dr(4)
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub TrazFornecedorDaListaPorID(ByRef vFornecedor As Fornecedor, ByVal ListFornecedores As List(Of Fornecedor))


        For Each p As Fornecedor In ListFornecedores
            If p.Id.Equals(vFornecedor.Id) Then

                With vFornecedor

                    .Id = p.Id
                    .Nome = p.Nome
                    .ComissaoFornecedor = p.ComissaoFornecedor
                    .ComissaoEntregador = p.ComissaoEntregador
                    .ValorKM = p.ValorKM
                End With
                Exit For
            End If

        Next

    End Sub

    Public Sub TrazListFornecedoresBD(ByRef vFornecedores As List(Of Fornecedor), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FornecedorDAO:TrazListFornecedores"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, nome, comissao_fornecedor, comissao_entregador, valor_km FROM fornecedor "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        vFornecedores.Clear()
        While dr.Read

            vFornecedores.Add(New Fornecedor(dr(0), dr(1).ToString, dr(2), dr(3), dr(4)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboFornecedoresBD(ByRef cboFornecedor As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FornecedorDAO:PreencheCboFornecedores"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT nome, id FROM fornecedor "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY nome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboFornecedor.Items.Clear()
        If dr.HasRows = True Then
            cboFornecedor.AutoCompleteCustomSource.Clear()
            cboFornecedor.Items.Clear()
            cboFornecedor.Refresh()
            While dr.Read

                cboFornecedor.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
                cboFornecedor.Items.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
            End While

            cboFornecedor.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboFornecedoresSoNomeBD(ByRef cboFornecedor As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FornecedorDAO:PreencheCboFornecedores"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT nome, id FROM fornecedor "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY nome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboFornecedor.Items.Clear()
        If dr.HasRows = True Then
            cboFornecedor.AutoCompleteCustomSource.Clear()
            cboFornecedor.Items.Clear()
            cboFornecedor.Refresh()
            While dr.Read

                cboFornecedor.AutoCompleteCustomSource.Add(dr(0).ToString)
                cboFornecedor.Items.Add(dr(0).ToString)
            End While

            cboFornecedor.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboFornecedoresLista(ByRef cboFornecedor As ComboBox, ByVal listFornecedores As List(Of Fornecedor))



        If listFornecedores.Count > 0 Then

            cboFornecedor.AutoCompleteCustomSource.Clear()
            cboFornecedor.Items.Clear()
            cboFornecedor.Refresh()

            For Each p As Fornecedor In listFornecedores
                cboFornecedor.AutoCompleteCustomSource.Add(p.Nome & " - " & p.Id.ToString.PadLeft(5, " "))
                cboFornecedor.Items.Add(p.Nome & " - " & p.Id.ToString.PadLeft(5, " "))
            Next
        End If

    End Sub

    Public Sub PreencheCboFornecedoresRelatorio(ByRef cboFornecedor As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FornecedorDAO:PreencheCboFornecedoresRelatorio"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT nome, id FROM fornecedor "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY nome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboFornecedor.Items.Clear()
        If dr.HasRows = True Then
            cboFornecedor.AutoCompleteCustomSource.Clear()
            cboFornecedor.Items.Clear()
            cboFornecedor.Refresh()
            cboFornecedor.AutoCompleteCustomSource.Add("< TODOS >")
            cboFornecedor.Items.Add("< TODOS >")
            While dr.Read

                cboFornecedor.AutoCompleteCustomSource.Add(dr(0).ToString)
                cboFornecedor.Items.Add(dr(0).ToString)
            End While

            cboFornecedor.SelectedIndex = 0
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboFornecedoresPesquisa(ByRef cboFornecedor As ComboBox, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FornecedorDAO:PreencheCboFornecedoresConsulta"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT nome, id FROM fornecedor ORDER BY nome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboFornecedor.Items.Clear()
        If dr.HasRows = True Then
            cboFornecedor.AutoCompleteCustomSource.Clear()
            cboFornecedor.Items.Clear()
            cboFornecedor.Refresh()
            cboFornecedor.AutoCompleteCustomSource.Add("< TODOS >")
            cboFornecedor.Items.Add("< TODOS >")
            While dr.Read

                cboFornecedor.AutoCompleteCustomSource.Add(dr(0).ToString)
                cboFornecedor.Items.Add(dr(0).ToString)
            End While

            cboFornecedor.AutoCompleteMode = AutoCompleteMode.None
            cboFornecedor.AutoCompleteSource = AutoCompleteSource.ListItems
            cboFornecedor.Refresh()
            cboFornecedor.SelectedIndex = -1

        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delFornecedor(ByVal vFornecedor As Fornecedor, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM fornecedor WHERE id = @id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vFornecedor.Id)

        comm.ExecuteNonQuery()

        TrazListFornecedoresBD(MdlConexaoBD.ListaFornecedores, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub


End Class
