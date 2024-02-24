Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql

Public Class FormCadProduto

    Private _produto As New Produto
    Private _produtoDAO As New ProdutoDAO
    Private _fornecedor As New Fornecedor
    Private _fornecedorPesquisa As New Fornecedor
    Private _fornecedorDAO As New FornecedorDAO
    Private _valorAdicional As New ValorAdicional
    Private _valorAdicionalDAO As New ValorAdicionalDAO
    Private _ListaProdutos As New List(Of Produto)
    Private _ListaProdutosRelatorio As New List(Of Produto)


    Dim tipoOperacao As String = "I"
    Dim _funcoes As New ClFuncoes

    Private Sub FormCadProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InicializaCamposFormulario()
        zeraCamposProdutoFormulario()
        zeraCamposPesquisa()
        _produtoDAO.TrazListProdutosBD(MdlConexaoBD.ListaProdutos, MdlConexaoBD.conectionPadrao)
        ExecutaF5()

    End Sub

    Sub InicializaCamposFormulario()

        _fornecedorDAO.PreencheCboFornecedoresPesquisa(CboPesquisaFornecedor, MdlConexaoBD.conectionPadrao)
        _fornecedorDAO.PreencheCboFornecedoresSoNomeBD(cboProdutoFornecedor, MdlConexaoBD.conectionPadrao)
        _valorAdicionalDAO.PreencheCboValorAdicionalPesquisaBD(CboValoresAdicionais, MdlConexaoBD.conectionPadrao)

    End Sub

    Sub zeraCamposProdutoFormulario()

        txtIdProd.Text = "0"
        txtProdutoDescricao.Text = ""
        txtProdutoEstoque.Text = "0"
        txtValorAdicional.Text = "0.00"
        txtValorComissaoFornecedor.Text = "0,00"
        cboProdutoFornecedor.SelectedIndex = -1
        CboValoresAdicionais.SelectedIndex = 0
        mskDataEntrada.Text = ""
        mskDataSaida.Text = ""
        mskDataEntrega.Text = ""

    End Sub

    Sub zeraCamposPesquisa()
        txtPesquisaDescricao.Text = ""
        If CboPesquisaFornecedor.Items.Count > 1 Then CboPesquisaFornecedor.SelectedIndex = 0
    End Sub

    Private Sub FormCadProduto_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F3
                ExecutaF3()
            Case Keys.F5
                ExecutaF5()
        End Select

    End Sub

    Sub ExecutaF5()

        dtgProdutos.Rows.Clear()
        _ListaProdutos.Clear()
        If _fornecedorPesquisa.Id > 0 Then

            If txtPesquisaDescricao.Text.Length > 0 Then
                _ListaProdutos = MdlConexaoBD.ListaProdutos.FindAll(Function(p As Produto) p.Descricao.StartsWith(Me.txtPesquisaDescricao.Text) And _
                                                                    (p.FornecedorID = _fornecedor.Id))
            Else
                _ListaProdutos = MdlConexaoBD.ListaProdutos.FindAll(Function(p As Produto) (p.FornecedorID = _fornecedor.Id))
            End If


        Else

            If txtPesquisaDescricao.Text.Length > 0 Then
                _ListaProdutos = MdlConexaoBD.ListaProdutos.FindAll(Function(p As Produto) p.Descricao.StartsWith(Me.txtPesquisaDescricao.Text))
            Else
                _produtoDAO.CopiaListaProdutoDeOutraLISTA(_ListaProdutos, MdlConexaoBD.ListaProdutos)
            End If
        End If



        If _ListaProdutos.Count < 1 Then Return
        For Each p As Produto In _ListaProdutos
            dtgProdutos.Rows.Add(p.Id, p.Descricao, p.FornecedorNome, p.FornecedorComissao.ToString("0.00"), p.Estoque.ToString("0.00"), p.AdicionalValor.ToString("0.00"))
        Next

    End Sub

    Private Sub FormCadProduto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CboPesquisaFornecedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPesquisaFornecedor.SelectedIndexChanged

        _fornecedorPesquisa.ZeraValores()
        If CboPesquisaFornecedor.SelectedIndex > 0 Then
            _fornecedorPesquisa.Nome = CboPesquisaFornecedor.SelectedItem.ToString
            _fornecedorDAO.TrazFornecedorPorNome(_fornecedorPesquisa, MdlConexaoBD.conectionPadrao)
        End If
    End Sub

    Private Sub cboProdutoFornecedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProdutoFornecedor.SelectedIndexChanged

        _fornecedor.ZeraValores()
        txtValorComissaoFornecedor.Text = "0.00"
        If cboProdutoFornecedor.SelectedIndex >= 0 Then

            _fornecedor.Nome = cboProdutoFornecedor.SelectedItem.ToString
            _fornecedorDAO.TrazFornecedorPorNome(_fornecedor, MdlConexaoBD.conectionPadrao)
            txtValorComissaoFornecedor.Text = _fornecedor.ComissaoFornecedor.ToString("0.00")
        End If
    End Sub

    Private Sub CboValoresAdicionais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboValoresAdicionais.SelectedIndexChanged

        _valorAdicional.ZeraValores()
        txtValorAdicional.Text = "0.00"
        If CboValoresAdicionais.SelectedIndex > 0 Then
            _valorAdicional.Descricao = CboValoresAdicionais.SelectedItem.ToString
            _valorAdicionalDAO.TrazValorAdicionalPorNome(_valorAdicional, MdlConexaoBD.conectionPadrao)
            txtValorAdicional.Text = _valorAdicional.Valor.ToString("0.00")
        End If
    End Sub

    Function validaProduto() As Boolean

        If Trim(txtProdutoDescricao.Text).Equals("") Then
            MsgBox("Informe uma Descricao para o Produto!", MsgBoxStyle.Exclamation, Application.ProductName)
            txtProdutoDescricao.Focus()
            Return False
        End If

        If (cboProdutoFornecedor.SelectedIndex < 0) Then
            MsgBox("Informe um Fornecedor para o Produto!", MsgBoxStyle.Exclamation, Application.ProductName)
            cboProdutoFornecedor.Focus()
            cboProdutoFornecedor.DroppedDown = True
            Return False
        End If

        If (CDbl(txtValorComissaoFornecedor.Text) <= 0) Then

            MsgBox("Produto dever ter um Valor De Comissão!", MsgBoxStyle.Exclamation, Application.ProductName)
            txtValorComissaoFornecedor.Focus()
            Return False
        End If

        Return True
    End Function

    Sub preencheValoresDoProduto()

        tipoOperacao = "I"
        If _produto.Id > 0 Then tipoOperacao = "A"
        With _produto

            .Descricao = txtProdutoDescricao.Text
            .FornecedorID = _fornecedor.Id
            .FornecedorNome = _fornecedor.Nome
            .FornecedorComissao = CDbl(txtValorComissaoFornecedor.Text)
            .FornecedorComissaoEntregador = _fornecedor.ComissaoEntregador
            .AdicionalID = 0
            .AdicionalDescricao = ""
            .AdicionalValor = CDbl(txtValorAdicional.Text)
            If (_valorAdicional.Id > 0) Then
                .AdicionalID = _valorAdicional.Id
                .AdicionalDescricao = _valorAdicional.Descricao
            End If
            .Estoque = CDbl(txtProdutoEstoque.Text)
        End With
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        If validaProduto() = False Then Return
        preencheValoresDoProduto()
        If _produtoDAO.ValidaProduto(_produto, tipoOperacao) = False Then Return


        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If tipoOperacao.Equals("I") Then
                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _produtoDAO.incProduto(_produto, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _produtoDAO.altProduto(_produto, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Produto Salvo com Sucesso!", MsgBoxStyle.Exclamation, Application.CompanyName)
            _produtoDAO.TrazListProdutosBD(MdlConexaoBD.ListaProdutos, MdlConexaoBD.conectionPadrao)
            zeraCamposProdutoFormulario()
            zeraCamposPesquisa()
            ExecutaF5()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try
    End Sub


    Sub preencheCamposDoFormulario()

        With Me

            .txtIdProd.Text = _produto.Id
            .txtProdutoDescricao.Text = _produto.Descricao
            .txtProdutoEstoque.Text = _produto.Estoque
            .mskDataEntrada.Text = ""
            .mskDataSaida.Text = ""
            .mskDataEntrega.Text = ""
            If _funcoes.validaData(_produto.DataEntrada) Then .mskDataEntrada.Text = _produto.DataEntrada.ToShortDateString
            If _funcoes.validaData(_produto.DataSaida) Then .mskDataSaida.Text = _produto.DataSaida.ToShortDateString
            If _funcoes.validaData(_produto.DataEntrega) Then .mskDataEntrega.Text = _produto.DataEntrega.ToShortDateString
            .cboProdutoFornecedor.SelectedIndex = _funcoes.trazIndexCboTextoTodo(_produto.FornecedorNome, .cboProdutoFornecedor)
            .txtValorComissaoFornecedor.Text = _produto.FornecedorComissao.ToString("0.00")
            .CboValoresAdicionais.SelectedIndex = _funcoes.trazIndexCboTextoTodo(_produto.AdicionalDescricao, .CboValoresAdicionais)
            .txtValorAdicional.Text = _produto.AdicionalValor.ToString("0.00")
        End With
    End Sub


    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click

        ExecutaF3()
    End Sub

    Sub ExecutaF3()

        zeraCamposProdutoFormulario()
        If Me.dtgProdutos.RowCount > 0 Then

            If Not Me.dtgProdutos.CurrentRow.IsNewRow Then

                _produto.Id = CInt(Me.dtgProdutos.CurrentRow.Cells(0).Value)
                _produtoDAO.TrazProdutoProID(_produto, MdlConexaoBD.conectionPadrao)
                preencheCamposDoFormulario()
            Else
                MsgBox("Selecione Um Produto na Tabela abaixo para Alterar", MsgBoxStyle.Exclamation, Application.ProductName)
            End If

        Else
            MsgBox("Nenhum Um Produto para Alterar! Verifique os Filtros de Pesquisa", MsgBoxStyle.Exclamation, Application.ProductName)
        End If

    End Sub

    Private Sub dtgProdutos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgProdutos.RowsAdded
        txtQuantidadeRegistros.Text = _ListaProdutos.Count
    End Sub

    Private Sub dtgProdutos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dtgProdutos.RowsRemoved
        txtQuantidadeRegistros.Text = _ListaProdutos.Count
    End Sub


    Private Sub txtValorComissaoFornecedor_Leave(sender As Object, e As EventArgs) Handles txtValorComissaoFornecedor.Leave

        If IsNumeric(txtValorComissaoFornecedor.Text) Then

            txtValorComissaoFornecedor.Text = CDbl(txtValorComissaoFornecedor.Text).ToString("0.00")
        Else
            txtValorComissaoFornecedor.Text = "0,00"
        End If
    End Sub

    Private Sub txtValorAdicional_Leave(sender As Object, e As EventArgs) Handles txtValorAdicional.Leave

        If IsNumeric(txtValorAdicional.Text) Then

            txtValorAdicional.Text = CDbl(txtValorAdicional.Text).ToString("0.00")
        Else
            txtValorAdicional.Text = "0,00"
        End If
    End Sub

    Private Sub txtProdutoEstoque_Leave(sender As Object, e As EventArgs) Handles txtProdutoEstoque.Leave

        If IsNumeric(txtValorAdicional.Text) Then
            txtValorAdicional.Text = "0"
        End If
    End Sub

    Sub ExecuteDel()
        'If MdlConexaoBD.sincronizado Then
        '    MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
        '    Return
        'End If

        zeraCamposProdutoFormulario()
        If Me.dtgProdutos.RowCount > 0 Then

            If Not Me.dtgProdutos.CurrentRow.IsNewRow Then

                _produto.Id = CInt(Me.dtgProdutos.CurrentRow.Cells(0).Value)
                _produtoDAO.TrazProdutoProID(_produto, MdlConexaoBD.conectionPadrao)
                If MessageBox.Show("Deseja Realmente Deletar esse Produto -> """ & _produto.Descricao & """ ?", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


                    Dim transacao As NpgsqlTransaction
                    Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

                    Try

                        Try
                            conection.Open()
                        Catch ex As Exception
                            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
                            Return
                        End Try

                        transacao = conection.BeginTransaction
                        _produtoDAO.delProduto(_produto, conection, transacao)
                        transacao.Commit() : conection.ClearPool() : conection.Close()
                        MsgBox("Produto Deletado com Sucesso!", MsgBoxStyle.Exclamation, Application.CompanyName)
                        _produtoDAO.TrazListProdutosBD(MdlConexaoBD.ListaProdutos, MdlConexaoBD.conectionPadrao)
                        ExecutaF5()

                    Catch ex As Exception
                        MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                        Try
                            transacao.Rollback()

                        Catch ex1 As Exception
                        End Try

                    Finally
                        transacao = Nothing : conection = Nothing
                        _produto.ZeraValores()
                    End Try

                Else
                    _produto.ZeraValores()
                End If
            Else
                MsgBox("Selecione Um Produto na Tabela abaixo para Excluir", MsgBoxStyle.Exclamation, Application.ProductName)
            End If

        Else
            MsgBox("Nenhum Um Produto para Exckuir! Verifique os Filtros de Pesquisa", MsgBoxStyle.Exclamation, Application.ProductName)
        End If


    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        ExecuteDel()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ExecutaF5()
    End Sub
End Class