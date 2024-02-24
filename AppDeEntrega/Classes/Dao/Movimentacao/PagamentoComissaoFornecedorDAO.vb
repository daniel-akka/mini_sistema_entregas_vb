Imports Npgsql
Public Class PagamentoComissaoFornecedorDAO

    Public Sub incPagamentoComissaoFornecedor(ByVal vPagComissao As PagamentoComissaoFornecedor, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO comissao_fornecedor(id, data_pagamento, fornecedor_id, fornecedor_nome, valor_pago, observacao) "
        sql += "VALUES (DEFAULT, @data_pagamento, @fornecedor_id, @fornecedor_nome, @valor_pago, @observacao) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@data_pagamento", vPagComissao.DataPagamento)
        comm.Parameters.Add("@fornecedor_id", vPagComissao.FornecedorID)
        comm.Parameters.Add("@fornecedor_nome", vPagComissao.FornecedorNome)
        comm.Parameters.Add("@valor_pago", vPagComissao.ValorPago)
        comm.Parameters.Add("@observacao", vPagComissao.Observacao)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altPagamentoComissaoFornecedor(ByVal vPagComissao As PagamentoComissaoFornecedor, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        '(id, , , , , 
        sql = "UPDATE comissao_fornecedor SET data_pagamento = @data_pagamento, fornecedor_id = @fornecedor_id, fornecedor_nome = @fornecedor_nome, "
        sql += "valor_pago = @valor_pago, observacao = @observacao "
        sql += "WHERE id = @id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentross
        comm.Parameters.Add("@id", vPagComissao.Id)
        comm.Parameters.Add("@data_pagamento", vPagComissao.DataPagamento)
        comm.Parameters.Add("@fornecedor_id", vPagComissao.FornecedorID)
        comm.Parameters.Add("@fornecedor_nome", vPagComissao.FornecedorNome)
        comm.Parameters.Add("@valor_pago", vPagComissao.ValorPago)
        comm.Parameters.Add("@observacao", vPagComissao.Observacao)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Function PagamentoComissaoFornecedorConsulta(ByRef vPagComissao As PagamentoComissaoFornecedor, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""PagamentoComissaoFornecedorDAO:TrazPagamentoComissaoFornecedor"":: " & ex.Message)
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

    Public Sub CopiaListaPagamentoComissaoFornecedorDeOutraLISTA(ByRef NovaLista As List(Of PagamentoComissaoFornecedor), ByVal ListaAnterior As List(Of PagamentoComissaoFornecedor))

        Dim PagamentoComissaoFornecedor As New PagamentoComissaoFornecedor
        NovaLista.Clear()
        For Each lc As PagamentoComissaoFornecedor In ListaAnterior

            PagamentoComissaoFornecedor.ZeraValores()
            PagamentoComissaoFornecedor.SetaPagamentoComissaoFornecedor(lc)
            NovaLista.Add(New PagamentoComissaoFornecedor(PagamentoComissaoFornecedor))
        Next

    End Sub

    Public Function TrazPagamentoComissaoFornecedorPorID(ByRef vPagComissao As PagamentoComissaoFornecedor, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""PagamentoComissaoFornecedorDAO:TrazPagamentoComissaoFornecedor"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT id, data_pagamento, fornecedor_id, fornecedor_nome, valor_pago, observacao " '5
        consulta += "FROM comissao_fornecedor WHERE id = " & vPagComissao.Id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vPagComissao

                .Id = dr(0)
                .DataPagamento = dr(1)
                .FornecedorID = dr(2)
                .FornecedorNome = dr(3)
                .ValorPago = dr(4)
                .Observacao = dr(5).ToString
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub TrazPagamentoComissaoFornecedorDaListaPorID(ByRef vPagComissao As PagamentoComissaoFornecedor, ByVal ListPagamentoComissaoFornecedores As List(Of PagamentoComissaoFornecedor))


        For Each p As PagamentoComissaoFornecedor In ListPagamentoComissaoFornecedores
            If p.Id.Equals(vPagComissao.Id) Then

                vPagComissao.SetaPagamentoComissaoFornecedor(p)
                Exit For
            End If

        Next

    End Sub

    Public Sub TrazListPagamentoComissaoFornecedorsBD(ByRef vListaDePagamentoComissaoFornecedors As List(Of PagamentoComissaoFornecedor), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vPagComissao As New PagamentoComissaoFornecedor


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""PagamentoComissaoFornecedorDAO:TrazListPagamentoComissaoFornecedores"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, data_pagamento, fornecedor_id, fornecedor_nome, valor_pago, observacao " '5
        consulta += "FROM comissao_fornecedor "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        vListaDePagamentoComissaoFornecedors.Clear()
        While dr.Read

            With vPagComissao

                .Id = dr(0)
                .DataPagamento = dr(1)
                .FornecedorID = dr(2)
                .FornecedorNome = dr(3)
                .ValorPago = dr(4)
                .Observacao = dr(5).ToString
            End With

            vListaDePagamentoComissaoFornecedors.Add(New PagamentoComissaoFornecedor(vPagComissao))
            vPagComissao.ZeraValores()
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub TrazListPagamentoComissaoFornecedorsBD_WHERE(ByRef vListaDePagamentoComissaoFornecedors As List(Of PagamentoComissaoFornecedor), ByVal strConection As String, _
                               Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vPagComissao As New PagamentoComissaoFornecedor


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""PagamentoComissaoFornecedorDAO:TrazListPagamentoComissaoFornecedores"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, data_pagamento, fornecedor_id, fornecedor_nome, valor_pago, observacao " '5
        consulta += "FROM comissao_fornecedor "
        If Not condicao.Equals("") Then
            consulta += condicao
        End If

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        vListaDePagamentoComissaoFornecedors.Clear()
        While dr.Read

            With vPagComissao

                .Id = dr(0)
                .DataPagamento = dr(1)
                .FornecedorID = dr(2)
                .FornecedorNome = dr(3)
                .ValorPago = dr(4)
                .Observacao = dr(5).ToString
            End With

            vListaDePagamentoComissaoFornecedors.Add(New PagamentoComissaoFornecedor(vPagComissao))
            vPagComissao.zeraValores()
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delPagamentoComissaoFornecedor(ByVal vPagComissao As PagamentoComissaoFornecedor, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM comissao_fornecedor WHERE id = @id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vPagComissao.Id)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Function TrazIdUltimaPagamentoComissaoFornecedor(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction) As Int64


        Dim dr As NpgsqlDataReader
        Dim com As New NpgsqlCommand
        Dim consulta As String = ""
        Dim mId As Integer = 0

        Try
            consulta = "SELECT MAX(id) FROM comissao_fornecedor"
            com.Transaction = transacao
            com = New NpgsqlCommand(consulta, conexao)
            dr = com.ExecuteReader

            While dr.Read
                mId = dr(0)
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox("ERRO ao Trazer ID Ultimo Pagamento:: " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            com = Nothing : dr = Nothing : consulta = Nothing
        End Try


        Return mId
    End Function

End Class
