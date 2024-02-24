Imports Npgsql
Public Class ProdutoDAO

    Dim _funcoes As New ClFuncoes

    Public Sub incProduto(ByVal vProduto As Produto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO produto(id, descricao, fornecedor_id, fornecedor_nome, fornecedor_comissao, "
        sql += "fornecedor_comissao_entregador, adicional_id, adicional_descricao, "
        sql += "adicional_valor, data_entrada, data_saida, data_entrega, estoque) "
        sql += "VALUES (DEFAULT, @descricao, @fornecedor_id, @fornecedor_nome, @fornecedor_comissao, "
        sql += "@fornecedor_comissao_entregador, @adicional_id, @adicional_descricao, "
        sql += "@adicional_valor, @data_entrada, @data_saida, @data_entrega, @estoque)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@descricao", vProduto.Descricao)
        comm.Parameters.Add("@fornecedor_id", vProduto.FornecedorID)
        comm.Parameters.Add("@fornecedor_nome", vProduto.FornecedorNome)
        comm.Parameters.Add("@fornecedor_comissao", vProduto.FornecedorComissao)
        comm.Parameters.Add("@fornecedor_comissao_entregador", vProduto.FornecedorComissaoEntregador)
        comm.Parameters.Add("@adicional_id", vProduto.AdicionalID)
        comm.Parameters.Add("@adicional_descricao", vProduto.AdicionalDescricao)
        comm.Parameters.Add("@adicional_valor", vProduto.AdicionalValor)

        If IsDate(vProduto.DataEntrada) Then
            comm.Parameters.Add("@data_entrada", vProduto.DataEntrada.ToShortDateString)
        Else
            comm.Parameters.Add("@data_entrada", System.DBNull.Value)
        End If

        If IsDate(vProduto.DataSaida) Then
            comm.Parameters.Add("@data_saida", vProduto.DataSaida.ToShortDateString)
        Else
            comm.Parameters.Add("@data_saida", System.DBNull.Value)
        End If

        If IsDate(vProduto.DataEntrega) Then
            comm.Parameters.Add("@data_entrega", vProduto.DataEntrega.ToShortDateString)
        Else
            comm.Parameters.Add("@data_entrega", System.DBNull.Value)
        End If

        comm.Parameters.Add("@estoque", vProduto.Estoque)

        comm.ExecuteNonQuery()

        TrazListProdutosBD(MdlConexaoBD.ListaProdutos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altProduto(ByVal vProduto As Produto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE produto SET descricao = @descricao, fornecedor_id = @fornecedor_id, fornecedor_nome = @fornecedor_nome, "
        sql += "fornecedor_comissao = @fornecedor_comissao, fornecedor_comissao_entregador = @fornecedor_comissao_entregador, "
        sql += "adicional_id = @adicional_id, adicional_descricao = @adicional_descricao, adicional_valor = @adicional_valor, "
        sql += "data_entrada = @data_entrada, data_saida = @data_saida, data_entrega = @data_entrega, estoque = @estoque "
        sql += "WHERE id = @id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentross
        comm.Parameters.Add("@id", vProduto.Id)
        comm.Parameters.Add("@descricao", vProduto.Descricao)
        comm.Parameters.Add("@fornecedor_id", vProduto.FornecedorID)
        comm.Parameters.Add("@fornecedor_nome", vProduto.FornecedorNome)
        comm.Parameters.Add("@fornecedor_comissao", vProduto.FornecedorComissao)
        comm.Parameters.Add("@fornecedor_comissao_entregador", vProduto.FornecedorComissaoEntregador)
        comm.Parameters.Add("@adicional_id", vProduto.AdicionalID)
        comm.Parameters.Add("@adicional_descricao", vProduto.AdicionalDescricao)
        comm.Parameters.Add("@adicional_valor", vProduto.AdicionalValor)
        
        If IsDate(vProduto.DataEntrada) Then
            comm.Parameters.Add("@data_entrada", vProduto.DataEntrada.ToShortDateString)
        Else
            comm.Parameters.Add("@data_entrada", System.DBNull.Value)
        End If

        If IsDate(vProduto.DataSaida) Then
            comm.Parameters.Add("@data_saida", vProduto.DataSaida.ToShortDateString)
        Else
            comm.Parameters.Add("@data_saida", System.DBNull.Value)
        End If

        If IsDate(vProduto.DataEntrega) Then
            comm.Parameters.Add("@data_entrega", vProduto.DataEntrega.ToShortDateString)
        Else
            comm.Parameters.Add("@data_entrega", System.DBNull.Value)
        End If

        comm.Parameters.Add("@estoque", vProduto.Estoque)

        comm.ExecuteNonQuery()

        TrazListProdutosBD(MdlConexaoBD.ListaProdutos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaProduto(ByVal vProduto As Produto, Optional ByVal Operacao As String = "I") As Boolean
        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT id FROM produto WHERE descricao = '" & vProduto.Descricao & "'"
        Else
            consulta = "SELECT id FROM produto WHERE id <> " & vProduto.Id & " AND descricao = '" & vProduto.Descricao & "'"
        End If
        If ProdutoConsulta(vProduto, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O Produto """ & vProduto.Descricao & """ já existe em outro Cadastro !") : Return False
        End If

        Return True
    End Function

    Public Function ProdutoConsulta(ByRef vProduto As Produto, ByVal Query As String, ByVal strConection As String) As Boolean

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

    Public Sub CopiaListaProdutoDeOutraLISTA(ByRef NovaListaProduto As List(Of Produto), ByVal ListaDeProdutos As List(Of Produto))

        Dim produto As New Produto
        NovaListaProduto.Clear()
        For Each lc As Produto In ListaDeProdutos

            produto.ZeraValores()
            produto.SetaProduto(lc)
            NovaListaProduto.Add(New Produto(produto))
        Next

    End Sub

    Public Function TrazProdutoProID(ByRef vProduto As Produto, ByVal strConection As String) As Boolean

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

        consulta = "SELECT id, descricao, fornecedor_id, fornecedor_nome, fornecedor_comissao, " '4
        consulta += "fornecedor_comissao_entregador, adicional_id, adicional_descricao, " '7
        consulta += "adicional_valor, data_entrada, data_saida, data_entrega, estoque " '12
        consulta += "FROM produto WHERE id = " & vProduto.Id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vProduto

                .Id = dr(0)
                .Descricao = dr(1).ToString
                .FornecedorID = dr(2)
                .FornecedorNome = dr(3).ToString
                .FornecedorComissao = dr(4)
                .FornecedorComissaoEntregador = dr(5)
                .AdicionalID = dr(6)
                .AdicionalDescricao = dr(7).ToString
                .AdicionalValor = dr(8)
                .DataEntrada = Nothing
                .DataSaida = Nothing
                .DataEntrega = Nothing
                If IsDate(dr(9)) Then .DataEntrada = dr(9)
                If IsDate(dr(10)) Then .DataSaida = dr(10)
                If IsDate(dr(11)) Then .DataEntrega = dr(11)
                .Estoque = dr(12)
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazProdutoPorDescricao(vDescricao As String, ByVal strConection As String) As Produto

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim novoProduto As New Produto

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ProdutoDAO:TrazProduto"":: " & ex.Message)
            Return novoProduto
        End Try

        consulta = "SELECT id, descricao, fornecedor_id, fornecedor_nome, fornecedor_comissao, " '4
        consulta += "fornecedor_comissao_entregador, adicional_id, adicional_descricao, " '7
        consulta += "adicional_valor, data_entrada, data_saida, data_entrega, estoque " '12
        consulta += "FROM produto WHERE descricao LIKE '" & vDescricao & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With novoProduto

                .Id = dr(0)
                .Descricao = dr(1).ToString
                .FornecedorID = dr(2)
                .FornecedorNome = dr(3).ToString
                .FornecedorComissao = dr(4)
                .FornecedorComissaoEntregador = dr(5)
                .AdicionalID = dr(6)
                .AdicionalDescricao = dr(7).ToString
                .AdicionalValor = dr(8)
                If IsDate(dr(9)) Then .DataEntrada = dr(9)
                If IsDate(dr(10)) Then .DataSaida = dr(10)
                If IsDate(dr(11)) Then .DataEntrega = dr(11)
                .Estoque = dr(12)
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return novoProduto
    End Function

    Public Sub TrazProdutoDaListaPorID(ByRef vProduto As Produto, ByVal ListProdutoes As List(Of Produto))


        For Each p As Produto In ListProdutoes
            If p.Id.Equals(vProduto.Id) Then

                vProduto.SetaProduto(p)
                Exit For
            End If

        Next

    End Sub

    Public Sub TrazListProdutosBD(ByRef vProdutos As List(Of Produto), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vProd As New Produto


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ProdutoDAO:TrazListProdutoes"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, descricao, fornecedor_id, fornecedor_nome, fornecedor_comissao, " '4
        consulta += "fornecedor_comissao_entregador, adicional_id, adicional_descricao, " '7
        consulta += "adicional_valor, data_entrada, data_saida, data_entrega, estoque " '12
        consulta += "FROM produto"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        vProdutos.Clear()
        While dr.Read

            With vProd

                .Id = dr(0)
                .Descricao = dr(1).ToString
                .FornecedorID = dr(2)
                .FornecedorNome = dr(3).ToString
                .FornecedorComissao = dr(4)
                .FornecedorComissaoEntregador = dr(5)
                .AdicionalID = dr(6)
                .AdicionalDescricao = dr(7).ToString
                .AdicionalValor = dr(8)
                If IsDate(dr(9)) Then .DataEntrada = dr(9)
                If IsDate(dr(10)) Then .DataSaida = dr(10)
                If IsDate(dr(11)) Then .DataEntrega = dr(11)
                .Estoque = dr(12)
            End With

            vProdutos.Add(New Produto(vProd))
            vProd.ZeraValores()
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboProdutosBD(ByRef cboProduto As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ProdutoDAO:PreencheCboProdutoes"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT descricao, id FROM produto "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboProduto.Items.Clear()
        If dr.HasRows = True Then
            cboProduto.AutoCompleteCustomSource.Clear()
            cboProduto.Items.Clear()
            cboProduto.Refresh()
            While dr.Read

                cboProduto.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
                cboProduto.Items.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
            End While

            cboProduto.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboProdutosLista(ByRef cboProduto As ComboBox, ByVal listProdutoes As List(Of Produto))



        If listProdutoes.Count > 0 Then

            cboProduto.AutoCompleteCustomSource.Clear()
            cboProduto.Items.Clear()
            cboProduto.Refresh()

            For Each p As Produto In listProdutoes
                cboProduto.AutoCompleteCustomSource.Add(p.Descricao & " - " & p.Id.ToString.PadLeft(5, " "))
                cboProduto.Items.Add(p.Descricao & " - " & p.Id.ToString.PadLeft(5, " "))
            Next
        End If

    End Sub

    Public Sub PreencheCboProdutosRelatorio(ByRef cboProduto As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ProdutoDAO:PreencheCboProdutosRelatorio"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT descricao, id FROM produto "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboProduto.Items.Clear()
        If dr.HasRows = True Then
            cboProduto.AutoCompleteCustomSource.Clear()
            cboProduto.Items.Clear()
            cboProduto.Refresh()
            cboProduto.AutoCompleteCustomSource.Add("< TODOS >")
            cboProduto.Items.Add("< TODOS >")
            While dr.Read

                cboProduto.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
                cboProduto.Items.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
            End While

            cboProduto.SelectedIndex = 0
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboProdutosConsulta(ByRef cboCliente As ComboBox, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ProdutoDAO:PreencheCboProdutosConsulta"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT descricao, id FROM produto ORDER BY descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboCliente.Items.Clear()
        If dr.HasRows = True Then
            cboCliente.AutoCompleteCustomSource.Clear()
            cboCliente.Items.Clear()
            cboCliente.Refresh()
            While dr.Read

                cboCliente.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
                cboCliente.Items.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
            End While

            cboCliente.AutoCompleteMode = AutoCompleteMode.Suggest
            cboCliente.AutoCompleteSource = AutoCompleteSource.ListItems
            cboCliente.Refresh()
            cboCliente.SelectedIndex = -1

        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delProduto(ByVal vProduto As Produto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM produto WHERE id = @id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vProduto.Id)

        comm.ExecuteNonQuery()

        TrazListProdutosBD(MdlConexaoBD.ListaProdutos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function TrazIdUltimoProduto(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction) As Int64


        Dim dr As NpgsqlDataReader
        Dim com As New NpgsqlCommand
        Dim consulta As String = ""
        Dim mId As Integer = 0

        Try
            consulta = "SELECT MAX(id) FROM produto"
            com.Transaction = transacao
            com = New NpgsqlCommand(consulta, conexao)
            dr = com.ExecuteReader

            While dr.Read
                mId = dr(0)
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox("ERRO ao Trazer ID Ultima Venda Seviço - VendaServicoDAO:: " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            com = Nothing : dr = Nothing : consulta = Nothing
        End Try


        Return mId
    End Function



End Class
