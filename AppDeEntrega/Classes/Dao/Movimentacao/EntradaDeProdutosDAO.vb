Imports Npgsql
Public Class EntradaDeProdutosDAO

    Private _produto As New Produto
    Private _produtoDAO As New ProdutoDAO
    Private _fornecedor As New Fornecedor
    Private _fornecedorDAO As New FornecedorDAO

    Sub salvaEntradaProduto(vEntrada As EntradaDeProdutos, operacao As String)


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
            incEntradaDeProdutos(vEntrada, operacao, conection, transacao)
            transacao.Commit() : conection.ClearPool() : conection.Close()
        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try

        Finally
            transacao = Nothing : conection = Nothing
        End Try

    End Sub

    Public Sub incEntradaDeProdutos(ByVal vEntradaDeProdutos As EntradaDeProdutos, operacaoProduto As String, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""
        comm.Transaction = transacao

        '1 :
        _fornecedor.Id = vEntradaDeProdutos.FornecedorID
        If _fornecedorDAO.TrazFornecedorPorID(_fornecedor, MdlConexaoBD.conectionPadrao) = False Then
            MsgBox("Informe um Fornecedor para Incluir a Entrada Desse Produto")
            Return
        End If
        '2 Inclue Produto Primeiro:
        If operacaoProduto.Equals("A") Then

            _produto.Id = vEntradaDeProdutos.ProdutoId
            _produtoDAO.TrazProdutoProID(_produto, MdlConexaoBD.conectionPadrao)
        End If

        With _produto

            .Descricao = vEntradaDeProdutos.DescricaoProduto
            .DataEntrada = vEntradaDeProdutos.DataEntrada
            .Estoque = vEntradaDeProdutos.Quantidade
            .FornecedorID = vEntradaDeProdutos.FornecedorID
            .FornecedorNome = vEntradaDeProdutos.FornecedorNome
            .FornecedorComissao = _fornecedor.ComissaoFornecedor
            .FornecedorComissaoEntregador = _fornecedor.ComissaoEntregador
        End With

        If _produtoDAO.ValidaProduto(_produto, operacaoProduto) = False Then
            Throw New System.Exception("Erro ao Validade o Produto para INSERT")
        End If

        If operacaoProduto.Equals("I") Then

            _produtoDAO.incProduto(_produto, conexao, transacao)
            vEntradaDeProdutos.ProdutoId = _produtoDAO.TrazIdUltimoProduto(conexao, transacao)
        Else 'Alteracao

            _produtoDAO.altProduto(_produto, conexao, transacao)
        End If

        '3 Inclui Entrada:
        sql = "INSERT INTO entrada_produto(id, descricao_produto, data_entrada, quantidade, fornecedor_id, "
        sql += "fornecedor_nome, cidade_id, cidade_nome, produto_id) VALUES (DEFAULT, @descricao_produto, @data_entrada, @quantidade, @fornecedor_id, "
        sql += "@fornecedor_nome, @cidade_id, @cidade_nome, @produto_id)"

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@descricao_produto", vEntradaDeProdutos.DescricaoProduto)
        comm.Parameters.Add("@data_entrada", vEntradaDeProdutos.DataEntrada)
        comm.Parameters.Add("@quantidade", vEntradaDeProdutos.Quantidade)
        comm.Parameters.Add("@fornecedor_id", vEntradaDeProdutos.FornecedorID)
        comm.Parameters.Add("@fornecedor_nome", vEntradaDeProdutos.FornecedorNome)
        comm.Parameters.Add("@cidade_id", vEntradaDeProdutos.CidadeID)
        comm.Parameters.Add("@cidade_nome", vEntradaDeProdutos.CidadeNome)
        comm.Parameters.Add("@produto_id", vEntradaDeProdutos.ProdutoId)
        comm.ExecuteNonQuery()

        'TrazListEntradaDeProdutossDoBD(MdlConexaoBD.ListaEntradaDeProdutoss, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function TrazEntradaProdutoProID(ByRef vEntradaDeProdutos As EntradaDeProdutos, ByVal strConection As String) As Boolean

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

        consulta = "SELECT id, descricao_produto, data_entrada, quantidade, fornecedor_id, " '4
        consulta += "fornecedor_nome, produto_id, cidade_id, cidade_nome " '8
        consulta += "FROM entrada_produto WHERE id = " & vEntradaDeProdutos.Id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vEntradaDeProdutos

                .Id = dr(0)
                .DescricaoProduto = dr(1).ToString
                .DataEntrada = dr(2)
                .Quantidade = dr(3)
                .FornecedorID = dr(4)
                .FornecedorNome = dr(5).ToString
                .ProdutoId = dr(6)
                .CidadeID = dr(7)
                .CidadeNome = dr(8).ToString
                
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub TrazListTodasEntradasBD(ByRef vEntradasProd As List(Of EntradaDeProdutos), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vEntrada As New EntradaDeProdutos


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EntradaProdutoDAO:TrazListEntradasProduto"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, descricao_produto, data_entrada, quantidade, fornecedor_id, " '4
        consulta += "fornecedor_nome, produto_id, cidade_id, cidade_nome " '8
        consulta += "FROM entrada_produto "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        vEntradasProd.Clear()
        While dr.Read

            With vEntrada

                .Id = dr(0)
                .DescricaoProduto = dr(1).ToString
                .DataEntrada = dr(2)
                .Quantidade = dr(3)
                .FornecedorID = dr(4)
                .FornecedorNome = dr(5).ToString
                .ProdutoId = dr(6)
                .CidadeID = dr(7)
                .CidadeNome = dr(8).ToString

            End With

            vEntradasProd.Add(New EntradaDeProdutos(vEntrada))
            vEntrada.ZeraValores()
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub TrazEntradaPorID(ByRef vEntradaProd As EntradaDeProdutos, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EntradaProdutoDAO:TrazListEntradasProduto"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, descricao_produto, data_entrada, quantidade, fornecedor_id, " '4
        consulta += "fornecedor_nome, produto_id, cidade_id, cidade_nome " '8
        consulta += "FROM entrada_produto WHERE id = " & vEntradaProd.Id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vEntradaProd

                .Id = dr(0)
                .DescricaoProduto = dr(1).ToString
                .DataEntrada = dr(2)
                .Quantidade = dr(3)
                .FornecedorID = dr(4)
                .FornecedorNome = dr(5).ToString
                .ProdutoId = dr(6)
                .CidadeID = dr(7)
                .CidadeNome = dr(8).ToString

            End With
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub TrazEntradaPorDescricaoProduto(ByRef vEntradaProd As EntradaDeProdutos, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EntradaProdutoDAO:TrazListEntradasProduto"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, descricao_produto, data_entrada, quantidade, fornecedor_id, " '4
        consulta += "fornecedor_nome, produto_id, cidade_id, cidade_nome " '8
        consulta += "FROM entrada_produto WHERE descricao_produto LIKE '" & vEntradaProd.DescricaoProduto & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vEntradaProd

                .Id = dr(0)
                .DescricaoProduto = dr(1).ToString
                .DataEntrada = dr(2)
                .Quantidade = dr(3)
                .FornecedorID = dr(4)
                .FornecedorNome = dr(5).ToString
                .ProdutoId = dr(6)
                .CidadeID = dr(7)
                .CidadeNome = dr(8).ToString

            End With
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub TrazListEntradasBD_Condicao(ByRef vEntradasProd As List(Of EntradaDeProdutos), ByVal strConection As String,
                                           Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vEntrada As New EntradaDeProdutos


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EntradaProdutoDAO:TrazListEntradasProduto"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, descricao_produto, data_entrada, quantidade, fornecedor_id, " '4
        consulta += "fornecedor_nome, produto_id, cidade_id, cidade_nome " '8
        consulta += "FROM entrada_produto "
        If Not condicao.Equals("") Then
            consulta += condicao
        End If
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        vEntradasProd.Clear()
        While dr.Read

            With vEntrada

                .Id = dr(0)
                .DescricaoProduto = dr(1).ToString
                .DataEntrada = dr(2)
                .Quantidade = dr(3)
                .FornecedorID = dr(4)
                .FornecedorNome = dr(5).ToString
                .ProdutoId = dr(6)
                .CidadeID = dr(7)
                .CidadeNome = dr(8).ToString

            End With

            vEntradasProd.Add(New EntradaDeProdutos(vEntrada))
            vEntrada.ZeraValores()
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delEntradaProduto(ByVal vEntradaDeProdutos As EntradaDeProdutos, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM entrada_produto WHERE id = @id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vEntradaDeProdutos.Id)

        comm.ExecuteNonQuery()

        'ALTERA PRODUTO:
        Dim produtoDAO As New ProdutoDAO
        Dim produto As New Produto
        produto.SetaProduto(produtoDAO.TrazProdutoPorDescricao(vEntradaDeProdutos.DescricaoProduto, MdlConexaoBD.conectionPadrao))
        produto.DataEntrada = Nothing
        produtoDAO.altProduto(produto, conexao, transacao)

        'DELETA O PRODUTO TAMBEM:
        

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub CopiaListaEntradaDeOutraLISTA(ByRef NovaListaEntrada As List(Of EntradaDeProdutos), ByVal ListaDeEntrada As List(Of EntradaDeProdutos))

        Dim entrada As New EntradaDeProdutos
        NovaListaEntrada.Clear()
        For Each lc As EntradaDeProdutos In ListaDeEntrada

            entrada.SetaValores(lc)
            NovaListaEntrada.Add(New EntradaDeProdutos(entrada))
        Next

    End Sub


End Class
