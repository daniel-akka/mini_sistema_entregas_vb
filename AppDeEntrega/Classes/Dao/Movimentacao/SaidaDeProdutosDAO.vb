Imports Npgsql
Public Class SaidaDeProdutosDAO

    Public Sub incSaidaDeProdutos(ByVal vSaidaDeProdutos As SaidaDeProdutos, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""
        comm.Transaction = transacao

        sql = "INSERT INTO saida_produto(id, data_saida, entregador_id, entregador_nome, cidade_id, cidade_nome, "
        sql += "produto_id, produto_descricao, quantidade, fornecedor_id, fornecedor_nome, comisao, "
        sql += "descricao_rota, finalizado, devolvido, data_devolucao, data_entrega) VALUES (DEFAULT, @data_saida, "
        sql += "@entregador_id, @entregador_nome, @cidade_id, @cidade_nome, @produto_id, "
        sql += "@produto_descricao, @quantidade, @fornecedor_id, @fornecedor_nome, @comisao, "
        sql += "@descricao_rota, @finalizado, @devolvido, @data_devolucao, @data_entrega)"

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@data_saida", vSaidaDeProdutos.DataSaida)
        comm.Parameters.Add("@entregador_id", vSaidaDeProdutos.EntregadorID)
        comm.Parameters.Add("@entregador_nome", vSaidaDeProdutos.EntregadorNome)
        comm.Parameters.Add("@cidade_id", vSaidaDeProdutos.CidadeID)
        comm.Parameters.Add("@cidade_nome", vSaidaDeProdutos.CidadeNome)
        comm.Parameters.Add("@produto_id", vSaidaDeProdutos.ProdutoID)
        comm.Parameters.Add("@produto_descricao", vSaidaDeProdutos.ProdutoDescricao)
        comm.Parameters.Add("@quantidade", vSaidaDeProdutos.Quantidade)
        comm.Parameters.Add("@fornecedor_id", vSaidaDeProdutos.FornecedorID)
        comm.Parameters.Add("@fornecedor_nome", vSaidaDeProdutos.FornecedorNome)
        comm.Parameters.Add("@comisao", vSaidaDeProdutos.Comissao)
        comm.Parameters.Add("@descricao_rota", vSaidaDeProdutos.DescricaoRota)
        comm.Parameters.Add("@finalizado", vSaidaDeProdutos.Finalizado)
        comm.Parameters.Add("@devolvido", vSaidaDeProdutos.Devolvido)
        comm.Parameters.Add("@data_devolucao", System.DBNull.Value)
        comm.Parameters.Add("@data_entrega", System.DBNull.Value)
        

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altSaidaDeProdutos(ByVal vSaidaDeProdutos As SaidaDeProdutos, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""
        comm.Transaction = transacao

        sql = "UPDATE saida_produto SET data = @data_saida, entregador_id = @entregador_id, entregador_nome = @entregador_nome, "
        sql += "cidade_id = @cidade_id, cidade_nome = @cidade_nome, produto_id = @produto_id, produto_descricao = @produto_descricao, "
        sql += "quantidade = @quantidade, fornecedor_id = @fornecedor_id, fornecedor_nome = @fornecedor_nome, comisao = @comisao, "
        sql += "descricao_rota = @descricao_rota, finalizado = @finalizado, devolvido = @devolvido, data_devolucao = @data_devolucao "
        sql += "data_entrega = @data_entrega WHERE id = @id"

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vSaidaDeProdutos.Id)
        comm.Parameters.Add("@data_saida", vSaidaDeProdutos.DataSaida)
        comm.Parameters.Add("@entregador_id", vSaidaDeProdutos.EntregadorID)
        comm.Parameters.Add("@entregador_nome", vSaidaDeProdutos.EntregadorNome)
        comm.Parameters.Add("@cidade_id", vSaidaDeProdutos.CidadeID)
        comm.Parameters.Add("@cidade_nome", vSaidaDeProdutos.CidadeNome)
        comm.Parameters.Add("@produto_id", vSaidaDeProdutos.ProdutoID)
        comm.Parameters.Add("@produto_descricao", vSaidaDeProdutos.ProdutoDescricao)
        comm.Parameters.Add("@quantidade", vSaidaDeProdutos.Quantidade)
        comm.Parameters.Add("@fornecedor_id", vSaidaDeProdutos.FornecedorID)
        comm.Parameters.Add("@fornecedor_nome", vSaidaDeProdutos.FornecedorNome)
        comm.Parameters.Add("@comisao", vSaidaDeProdutos.Comissao)
        comm.Parameters.Add("@descricao_rota", vSaidaDeProdutos.DescricaoRota)
        comm.Parameters.Add("@finalizado", vSaidaDeProdutos.Finalizado)
        comm.Parameters.Add("@devolvido", vSaidaDeProdutos.Devolvido)

        If IsNothing(vSaidaDeProdutos.DataDevolucao) Then
            comm.Parameters.Add("@data_devolucao", System.DBNull.Value)
        Else
            comm.Parameters.Add("@data_devolucao", vSaidaDeProdutos.DataDevolucao)
        End If

        If IsNothing(vSaidaDeProdutos.DataEntrega) Then
            comm.Parameters.Add("@data_entrega", System.DBNull.Value)
        Else
            comm.Parameters.Add("@data_entrega", vSaidaDeProdutos.DataEntrega)
        End If

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Function TrazSaidaDeProdutoPorID(ByRef vSaidaDeProdutos As SaidaDeProdutos, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ProdutoDAO:TrazProduto"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT id, data_saida, entregador_id, entregador_nome, cidade_id, cidade_nome, " '5
        consulta += "produto_id, produto_descricao, quantidade, fornecedor_id, fornecedor_nome, comisao, " '11
        consulta += "descricao_rota, finalizado, devolvido, data_devolucao, data_entrega " '16
        consulta += "FROM saida_produto WHERE id = " & vSaidaDeProdutos.Id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vSaidaDeProdutos

                .Id = dr(0)
                .DataSaida = dr(1)
                .EntregadorID = dr(2)
                .EntregadorNome = dr(3).ToString
                .CidadeID = dr(4)
                .CidadeNome = dr(5).ToString
                .ProdutoID = dr(6)
                .ProdutoDescricao = dr(7).ToString
                .Quantidade = dr(8)
                .FornecedorID = dr(9)
                .FornecedorNome = dr(10)
                .Comissao = dr(11)
                .DescricaoRota = dr(12).ToString
                .Finalizado = dr(13)
                .Devolvido = dr(14)
                If IsDate(dr(15)) Then .DataDevolucao = dr(15)
                If IsDate(dr(16)) Then .DataEntrega = dr(16)

            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub TrazListTodasSaidasBD(ByRef vSaidasProd As List(Of SaidaDeProdutos), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vSaida As New SaidaDeProdutos


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""SaidaDeProdutoDAO:TrazListEntradasProduto"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, data_saida, entregador_id, entregador_nome, cidade_id, cidade_nome, " '5
        consulta += "produto_id, produto_descricao, quantidade, fornecedor_id, fornecedor_nome, comisao, " '11
        consulta += "descricao_rota, finalizado, devolvido, data_devolucao, data_entrega " '16
        consulta += "FROM saida_produto "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        vSaidasProd.Clear()
        While dr.Read

            With vSaida

                .Id = dr(0)
                .DataSaida = dr(1)
                .EntregadorID = dr(2)
                .EntregadorNome = dr(3).ToString
                .CidadeID = dr(4)
                .CidadeNome = dr(5).ToString
                .ProdutoID = dr(6)
                .ProdutoDescricao = dr(7).ToString
                .Quantidade = dr(8)
                .FornecedorID = dr(9)
                .FornecedorNome = dr(10)
                .Comissao = dr(11)
                .DescricaoRota = dr(12).ToString
                .Finalizado = dr(13)
                .Devolvido = dr(14)
                If IsDate(dr(15)) Then .DataDevolucao = dr(15)
                If IsDate(dr(16)) Then .DataEntrega = dr(16)

            End With

            vSaidasProd.Add(New SaidaDeProdutos(vSaida))
            vSaida.ZeraValores()
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub TrazSaidaPorDescricaoProduto(ByRef vSaidaProduto As SaidaDeProdutos, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""SaidaDeProdutoDAO:TrazListEntradasProduto"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, data_saida, entregador_id, entregador_nome, cidade_id, cidade_nome, " '5
        consulta += "produto_id, produto_descricao, quantidade, fornecedor_id, fornecedor_nome, comisao, " '11
        consulta += "descricao_rota, finalizado, devolvido, data_devolucao, data_entrega " '16
        consulta += "FROM saida_produto WHERE produto_descricao LIKE '" & vSaidaProduto.ProdutoDescricao & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vSaidaProduto

                .Id = dr(0)
                .DataSaida = dr(1)
                .EntregadorID = dr(2)
                .EntregadorNome = dr(3).ToString
                .CidadeID = dr(4)
                .CidadeNome = dr(5).ToString
                .ProdutoID = dr(6)
                .ProdutoDescricao = dr(7).ToString
                .Quantidade = dr(8)
                .FornecedorID = dr(9)
                .FornecedorNome = dr(10)
                .Comissao = dr(11)
                .DescricaoRota = dr(12).ToString
                .Finalizado = dr(13)
                .Devolvido = dr(14)
                If IsDate(dr(15)) Then .DataDevolucao = dr(15)
                If IsDate(dr(16)) Then .DataEntrega = dr(16)

            End With
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub TrazListSaidasBD_Condicao(ByRef vSaidasProd As List(Of SaidaDeProdutos), ByVal strConection As String,
                                           Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vSaida As New SaidaDeProdutos


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""SaidaDeProdutoDAO:TrazListEntradasProduto"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, data_saida, entregador_id, entregador_nome, cidade_id, cidade_nome, " '5
        consulta += "produto_id, produto_descricao, quantidade, fornecedor_id, fornecedor_nome, comisao, " '11
        consulta += "descricao_rota, finalizado, devolvido, data_devolucao, data_entrega " '16
        consulta += "FROM saida_produto "
        If Not condicao.Equals("") Then
            consulta += condicao
        End If
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        vSaidasProd.Clear()
        While dr.Read

            With vSaida

                .Id = dr(0)
                .DataSaida = dr(1)
                .EntregadorID = dr(2)
                .EntregadorNome = dr(3).ToString
                .CidadeID = dr(4)
                .CidadeNome = dr(5).ToString
                .ProdutoID = dr(6)
                .ProdutoDescricao = dr(7).ToString
                .Quantidade = dr(8)
                .FornecedorID = dr(9)
                .FornecedorNome = dr(10)
                .Comissao = dr(11)
                .DescricaoRota = dr(12).ToString
                .Finalizado = dr(13)
                .Devolvido = dr(14)
                If IsDate(dr(15)) Then .DataDevolucao = dr(15)
                If IsDate(dr(16)) Then .DataEntrega = dr(16)

            End With

            vSaidasProd.Add(New SaidaDeProdutos(vSaida))
            vSaida.ZeraValores()
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delSaidaDeProduto(ByVal vSaidaDeProdutos As SaidaDeProdutos, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM saida_produto WHERE id = @id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vSaidaDeProdutos.Id)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub CopiaListaEntradaDeOutraLISTA(ByRef NovaListaEntrada As List(Of SaidaDeProdutos), ByVal ListaDeEntrada As List(Of SaidaDeProdutos))

        Dim entrada As New SaidaDeProdutos
        NovaListaEntrada.Clear()
        For Each lc As SaidaDeProdutos In ListaDeEntrada

            entrada.SetaValores(lc)
            NovaListaEntrada.Add(New SaidaDeProdutos(entrada))
        Next

    End Sub

    Public Sub altSaidaDeProdutosParaENTREGE(ByVal vSaidaDeProdutos As SaidaDeProdutos, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""
        comm.Transaction = transacao

        sql = "UPDATE saida_produto SET data_entrega = @data_entrega, finalizado = @finalizado, devolvido = @devolvido, "
        sql += "data_devolucao = @data_devolucao WHERE id = @id"

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vSaidaDeProdutos.Id)
        comm.Parameters.Add("@data_entrega", vSaidaDeProdutos.DataEntrega)
        comm.Parameters.Add("@finalizado", True)
        comm.Parameters.Add("@devolvido", False)
        comm.Parameters.Add("@data_devolucao", System.DBNull.Value)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altSaidaDeProdutosParaENTREGE_WHERE(ByVal vDataEntregas As Date, ByVal vWHERE As String, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""
        comm.Transaction = transacao

        sql = "UPDATE saida_produto SET data_entrega = @data_entrega, finalizado = @finalizado, devolvido = @devolvido, "
        sql += "data_devolucao = @data_devolucao "
        sql += vWHERE

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@data_entrega", vDataEntregas)
        comm.Parameters.Add("@finalizado", True)
        comm.Parameters.Add("@devolvido", False)
        comm.Parameters.Add("@data_devolucao", System.DBNull.Value)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altSaidaDeProdutosParaDEVOLVIDO(ByVal vSaidaDeProdutos As SaidaDeProdutos, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""
        comm.Transaction = transacao

        sql = "UPDATE saida_produto SET data_entrega = @data_entrega, finalizado = @finalizado, devolvido = @devolvido, "
        sql += "data_devolucao = @data_devolucao WHERE id = @id"

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vSaidaDeProdutos.Id)
        comm.Parameters.Add("@data_entrega", System.DBNull.Value)
        comm.Parameters.Add("@finalizado", False)
        comm.Parameters.Add("@devolvido", True)
        comm.Parameters.Add("@data_devolucao", vSaidaDeProdutos.DataDevolucao)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altSaidaDeProdutosDesfazEntrega_DEVOLVIDO(ByVal vSaidaDeProdutos As SaidaDeProdutos, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""
        comm.Transaction = transacao

        sql = "UPDATE saida_produto SET data_entrega = @data_entrega, finalizado = @finalizado, devolvido = @devolvido, "
        sql += "data_devolucao = @data_devolucao WHERE id = @id"

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vSaidaDeProdutos.Id)
        comm.Parameters.Add("@data_entrega", System.DBNull.Value)
        comm.Parameters.Add("@finalizado", False)
        comm.Parameters.Add("@devolvido", False)
        comm.Parameters.Add("@data_devolucao", System.DBNull.Value)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altSaidaDeProdutosDesfazENTREGA(ByVal vSaidaDeProdutos As SaidaDeProdutos, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""
        comm.Transaction = transacao

        sql = "UPDATE saida_produto SET data_entrega = @data_entrega, finalizado = @finalizado "
        sql += "WHERE id = @id"

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vSaidaDeProdutos.Id)
        comm.Parameters.Add("@data_entrega", System.DBNull.Value)
        comm.Parameters.Add("@finalizado", False)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altSaidaDeProdutosDesfazDEVOLVIDO(ByVal vSaidaDeProdutos As SaidaDeProdutos, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""
        comm.Transaction = transacao

        sql = "UPDATE saida_produto SET devolvido = @devolvido, "
        sql += "data_devolucao = @data_devolucao WHERE id = @id"

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vSaidaDeProdutos.Id)
        comm.Parameters.Add("@devolvido", False)
        comm.Parameters.Add("@data_devolucao", System.DBNull.Value)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

End Class
