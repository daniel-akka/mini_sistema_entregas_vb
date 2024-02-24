Imports Npgsql
Public Class PagamentoComissaoDAO


    Public Sub incPagamentoComissao(ByVal vPagComissao As PagamentoComissao, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO pagamento_comissao(id, data_pagamento, entregador_id, entregador_nome, valor_pago, observacao, fornecedor_id, fornecedor_nome) "
        sql += "VALUES (DEFAULT, @data_pagamento, @entregador_id, @entregador_nome, @valor_pago, @observacao, @fornecedor_id, @fornecedor_nome) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@data_pagamento", vPagComissao.DataPagamento)
        comm.Parameters.Add("@entregador_id", vPagComissao.EntregadorID)
        comm.Parameters.Add("@entregador_nome", vPagComissao.EntregadorNome)
        comm.Parameters.Add("@valor_pago", vPagComissao.ValorPago)
        comm.Parameters.Add("@observacao", vPagComissao.Observacao)
        comm.Parameters.Add("@fornecedor_id", vPagComissao.FornecedorID)
        comm.Parameters.Add("@fornecedor_nome", vPagComissao.FornecedorNome)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altPagamentoComissao(ByVal vPagComissao As PagamentoComissao, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        '(id, , , , , 
        sql = "UPDATE pagamento_comissao SET data_pagamento = @data_pagamento, entregador_id = @entregador_id, entregador_nome = @entregador_nome, "
        sql += "valor_pago = @valor_pago, observacao = @observacao "
        sql += "WHERE id = @id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentross
        comm.Parameters.Add("@id", vPagComissao.Id)
        comm.Parameters.Add("@data_pagamento", vPagComissao.DataPagamento)
        comm.Parameters.Add("@entregador_id", vPagComissao.EntregadorID)
        comm.Parameters.Add("@entregador_nome", vPagComissao.EntregadorNome)
        comm.Parameters.Add("@valor_pago", vPagComissao.ValorPago)
        comm.Parameters.Add("@observacao", vPagComissao.Observacao)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Function PagamentoComissaoConsulta(ByRef vPagComissao As PagamentoComissao, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""PagamentoComissaoDAO:TrazPagamentoComissao"":: " & ex.Message)
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

    Public Sub CopiaListaPagamentoComissaoDeOutraLISTA(ByRef NovaListaPagamentoComissao As List(Of PagamentoComissao), ByVal ListaDePagamentoComissaos As List(Of PagamentoComissao))

        Dim PagamentoComissao As New PagamentoComissao
        NovaListaPagamentoComissao.Clear()
        For Each lc As PagamentoComissao In ListaDePagamentoComissaos

            PagamentoComissao.ZeraValores()
            PagamentoComissao.SetaPagamentoComissao(lc)
            NovaListaPagamentoComissao.Add(New PagamentoComissao(PagamentoComissao))
        Next

    End Sub

    Public Function TrazPagamentoComissaoPorID(ByRef vPagComissao As PagamentoComissao, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""PagamentoComissaoDAO:TrazPagamentoComissao"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT id, data_pagamento, entregador_id, entregador_nome, valor_pago, observacao, fornecedor_id, fornecedor_nome " '7
        consulta += "FROM pagamento_comissao WHERE id = " & vPagComissao.Id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vPagComissao

                .Id = dr(0)
                .DataPagamento = dr(1)
                .EntregadorID = dr(2)
                .EntregadorNome = dr(3)
                .ValorPago = dr(4)
                .Observacao = dr(5).ToString
                .FornecedorID = dr(6)
                .FornecedorNome = dr(7).ToString
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub TrazPagamentoComissaoDaListaPorID(ByRef vPagComissao As PagamentoComissao, ByVal ListPagamentoComissaoes As List(Of PagamentoComissao))


        For Each p As PagamentoComissao In ListPagamentoComissaoes
            If p.Id.Equals(vPagComissao.Id) Then

                vPagComissao.SetaPagamentoComissao(p)
                Exit For
            End If

        Next

    End Sub

    Public Sub TrazListPagamentoComissaosBD(ByRef vListaDePagamentoComissaos As List(Of PagamentoComissao), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vPagComissao As New PagamentoComissao


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""PagamentoComissaoDAO:TrazListPagamentoComissaoes"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, data_pagamento, entregador_id, entregador_nome, valor_pago, observacao, fornecedor_id, fornecedor_nome " '5
        consulta += "FROM pagamento_comissao "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        vListaDePagamentoComissaos.Clear()
        While dr.Read

            With vPagComissao

                .Id = dr(0)
                .DataPagamento = dr(1)
                .EntregadorID = dr(2)
                .EntregadorNome = dr(3)
                .ValorPago = dr(4)
                .Observacao = dr(5).ToString
                .FornecedorID = dr(6)
                .FornecedorNome = dr(7).ToString
            End With

            vListaDePagamentoComissaos.Add(New PagamentoComissao(vPagComissao))
            vPagComissao.ZeraValores()
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub TrazListPagamentoComissaosBD_WHERE(ByRef vListaDePagamentoComissaos As List(Of PagamentoComissao), ByVal strConection As String, _
                               Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vPagComissao As New PagamentoComissao


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""PagamentoComissaoDAO:TrazListPagamentoComissaoes"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, data_pagamento, entregador_id, entregador_nome, valor_pago, observacao, fornecedor_id, fornecedor_nome " '5
        consulta += "FROM pagamento_comissao "
        If Not condicao.Equals("") Then
            consulta += condicao
        End If

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        vListaDePagamentoComissaos.Clear()
        While dr.Read

            With vPagComissao

                .Id = dr(0)
                .DataPagamento = dr(1)
                .EntregadorID = dr(2)
                .EntregadorNome = dr(3)
                .ValorPago = dr(4)
                .Observacao = dr(5).ToString
                .FornecedorID = dr(6)
                .FornecedorNome = dr(7).ToString
            End With

            vListaDePagamentoComissaos.Add(New PagamentoComissao(vPagComissao))
            vPagComissao.zeraValores()
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delPagamentoComissao(ByVal vPagComissao As PagamentoComissao, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM pagamento_comissao WHERE id = @id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vPagComissao.Id)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Function TrazIdUltimaPagamentoComissao(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction) As Int64


        Dim dr As NpgsqlDataReader
        Dim com As New NpgsqlCommand
        Dim consulta As String = ""
        Dim mId As Integer = 0

        Try
            consulta = "SELECT MAX(id) FROM pagamento_comissao"
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
