Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql

Public Class FormSaidaDeProdutos

    'Objetos para Pesquisa:
    Private _produtoPesquisa As New Produto
    Private _fornecedorPesquisa As New Fornecedor
    Private _cidadePesquisa As New Cidade
    Private _listaSaidasProdutoRelatorio As New List(Of SaidaDeProdutos)
    Private _listaSaidasProduto As New List(Of SaidaDeProdutos)
    Private _entregadorPesquisa As New Entregador
    Private _entrada As New EntradaDeProdutos


    'Objetos para Cadastro:
    Private _produto As New Produto
    Private _fornecedor As New Fornecedor
    Private _SaidaProduto As New SaidaDeProdutos
    Private _cidade As New Cidade
    Private _entregador As New Entregador
    Private _fornecedorVerificacao As New Fornecedor
    Private _produtoVerificacao As New Produto

    'Objetos pra Vizualizar Saida:
    Private _SaidaProdutoVIEW As New SaidaDeProdutos

    'Objetos para controle:
    Private _produtoDAO As New ProdutoDAO
    Private _fornecedorDAO As New FornecedorDAO
    Private _cidadeDAO As New CidadeDAO
    Private _SaidaDAO As New SaidaDeProdutosDAO
    Private _entregadorDAO As New EntregadorDAO
    Private _EntradaDAO As New EntradaDeProdutosDAO
    Dim _OperacaoProduto As String = "I"
    Dim _funcoes As New ClFuncoes


    'Objetos para Manutenção:
    Private _entregadorManutencao As New Entregador
    Private _fornecedorManutencao As New Fornecedor
    Private _cidadeManutencao As New Cidade
    Private _ListaSaidaManutencao As New List(Of SaidaDeProdutos)
    Private _SaidaManutencao As New SaidaDeProdutos

    Private Sub btnCadSaida_Click(sender As Object, e As EventArgs) Handles btnCadSaida.Click
        tbcSaida.SelectTab(1)
        AtualizaGridTabelaSaida()
    End Sub

    Private Sub FormSaidaDeProdutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializaCamposFormulario()
        ExecutaF5()
    End Sub

    Private Sub FormSaidaDeProdutos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                ExecutaF2()
            Case Keys.F5
                ExecutaF5()
        End Select
    End Sub

    Sub InicializaCamposFormulario()

        _fornecedorDAO.PreencheCboFornecedoresPesquisa(Me.CboFornecedorPesquisa, MdlConexaoBD.conectionPadrao)
        _fornecedorDAO.PreencheCboFornecedoresSoNomeBD(Me.cboFornecedorSaida, MdlConexaoBD.conectionPadrao)
        _cidadeDAO.PreencheCboCidadesPesquisaBD(Me.cboCidadesPesquisa, MdlConexaoBD.conectionPadrao)
        _cidadeDAO.PreencheCboCidadesBD(Me.CboCidadeSaida, MdlConexaoBD.conectionPadrao)
        _entregadorDAO.PreencheCboEntregadoresRelatorio(CboEntregadorPesquisa, MdlConexaoBD.conectionPadrao)
        _entregadorDAO.PreencheCboEntregadoresBD(cboEntregadorSaida, MdlConexaoBD.conectionPadrao)

        If CboFornecedorPesquisa.Items.Count = 1 Then
            CboFornecedorPesquisa.SelectedIndex = 0
        ElseIf CboFornecedorPesquisa.Items.Count = 2 Then
            CboFornecedorPesquisa.SelectedIndex = 1
        End If

        If cboCidadesPesquisa.Items.Count = 1 Then
            cboCidadesPesquisa.SelectedIndex = 0
        ElseIf cboCidadesPesquisa.Items.Count = 2 Then
            cboCidadesPesquisa.SelectedIndex = 1
        End If

        If CboEntregadorPesquisa.Items.Count = 1 Then
            CboEntregadorPesquisa.SelectedIndex = 0
        ElseIf CboEntregadorPesquisa.Items.Count = 2 Then
            CboEntregadorPesquisa.SelectedIndex = 1
        End If

        If cboFornecedorSaida.Items.Count = 1 Then cboFornecedorSaida.SelectedIndex = 0
        If CboCidadeSaida.Items.Count = 1 Then CboCidadeSaida.SelectedIndex = 0
        If cboEntregadorSaida.Items.Count = 1 Then cboEntregadorSaida.SelectedIndex = 0


        'Tela Manutenção:
        _fornecedorDAO.PreencheCboFornecedoresPesquisa(Me.cboFornecedorManutencao, MdlConexaoBD.conectionPadrao)
        _cidadeDAO.PreencheCboCidadesPesquisaBD(Me.cboCidadeManutencao, MdlConexaoBD.conectionPadrao)
        _entregadorDAO.PreencheCboEntregadoresRelatorio(cboEntregadorManutencao, MdlConexaoBD.conectionPadrao)


        If cboFornecedorManutencao.Items.Count = 1 Then
            cboFornecedorManutencao.SelectedIndex = 0
        ElseIf cboFornecedorManutencao.Items.Count = 2 Then
            cboFornecedorManutencao.SelectedIndex = 1
        End If

        If cboCidadeManutencao.Items.Count = 1 Then
            cboCidadeManutencao.SelectedIndex = 0
        ElseIf cboCidadeManutencao.Items.Count = 2 Then
            cboCidadeManutencao.SelectedIndex = 1
        End If

        If cboEntregadorManutencao.Items.Count = 1 Then
            cboEntregadorManutencao.SelectedIndex = 0
        ElseIf cboEntregadorManutencao.Items.Count = 2 Then
            cboEntregadorManutencao.SelectedIndex = 1
        End If

    End Sub

    Sub ExecutaF2()

        tbcSaida.SelectTab(1)
        If cboFornecedorSaida.Items.Count > 1 Then

            cboFornecedorSaida.Focus()
            cboFornecedorSaida.DroppedDown = True
        Else

            If CboCidadeSaida.Items.Count > 1 Then

                CboCidadeSaida.Focus()
                CboCidadeSaida.DroppedDown = True

            Else

                If cboEntregadorSaida.Items.Count > 1 Then

                    cboEntregadorSaida.Focus()
                    cboEntregadorSaida.DroppedDown = True
                Else
                    txtDescricaoProdutoSaida.Focus()
                End If

            End If
        End If

        AtualizaGridTabelaSaida()

    End Sub

    Sub ExecutaF5()

        dtgSaidaRelacao.Rows.Clear()
        _listaSaidasProdutoRelatorio.Clear()
        Dim condicao As String = ""

        If rdbDataSaida.Checked Then
            condicao = "WHERE (data_saida BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "') "
        ElseIf rdbDataDevolucao.Checked Then
            condicao = "WHERE (data_devolucao BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "') "
        ElseIf rdbDataEntrega.Checked Then
            condicao = "WHERE (data_entrega BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "') "
        End If


        If txtDescricaoProdutoSaida.Text.Length > 0 Then
            condicao += "AND produto_descricao LIKE '%" & txtPesquisaDescricaoProduto.Text & "%' "
        End If

        If _fornecedorPesquisa.Id > 0 Then
            condicao += "AND fornecedor_id = " & _fornecedorPesquisa.Id & " "
        End If

        If _cidadePesquisa.Id > 0 Then
            condicao += "AND cidade_id = " & _cidadePesquisa.Id & " "
        End If

       
        _SaidaDAO.TrazListSaidasBD_Condicao(_listaSaidasProdutoRelatorio, MdlConexaoBD.conectionPadrao, condicao)


        txtQuantidadeRegistros.Text = _listaSaidasProdutoRelatorio.Count
        If _listaSaidasProdutoRelatorio.Count < 1 Then Return
        For Each p As SaidaDeProdutos In _listaSaidasProdutoRelatorio
            dtgSaidaRelacao.Rows.Add(p.Id, p.DataSaida.ToShortDateString, p.EntregadorNome, p.ProdutoDescricao, p.Quantidade.ToString("0.00"), p.FornecedorNome)
        Next


    End Sub

    Sub AtualizaGridTabelaSaida()

        If dataSaida.Text.Equals("") Then
            Return
        End If
        dtgSaida.Rows.Clear()
        _listaSaidasProduto.Clear()
        Dim condicao As String = ""
        condicao = "WHERE data_Saida BETWEEN '" & dataSaida.Text & "' AND '" & dataSaida.Text & "' "
        condicao += "AND finalizado = false "

        _SaidaDAO.TrazListSaidasBD_Condicao(_listaSaidasProduto, MdlConexaoBD.conectionPadrao, condicao)

        If _listaSaidasProduto.Count < 1 Then Return
        For Each p As SaidaDeProdutos In _listaSaidasProduto
            dtgSaida.Rows.Add(p.Id, p.DataSaida.ToShortDateString, p.EntregadorNome, p.ProdutoDescricao, p.Quantidade.ToString("0.00"), p.FornecedorNome)
        Next
        txtQuantidadeRegistrosSaida.Text = dtgSaida.Rows.Count
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ExecutaF5()
    End Sub

    Private Sub CboPesquisaFornecedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFornecedorPesquisa.SelectedIndexChanged

        _fornecedorPesquisa.ZeraValores()
        If CboFornecedorPesquisa.SelectedIndex > 0 Then
            _fornecedorPesquisa.Nome = CboFornecedorPesquisa.SelectedItem.ToString
            _fornecedorDAO.TrazFornecedorPorNome(_fornecedorPesquisa, MdlConexaoBD.conectionPadrao)
        End If

    End Sub

    Private Sub cboCidadesPesquisa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCidadesPesquisa.SelectedIndexChanged

        _cidadePesquisa.ZeraValores()
        If cboCidadesPesquisa.SelectedIndex > 0 Then
            _cidadePesquisa.Nome = cboCidadesPesquisa.SelectedItem.ToString
            _cidadeDAO.TrazCidadePorNomeBD(_cidadePesquisa, MdlConexaoBD.conectionPadrao)
        End If
    End Sub

    Private Sub CboEntregadorPesquisa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboEntregadorPesquisa.SelectedIndexChanged

        _entregadorPesquisa.ZeraValores()
        If CboEntregadorPesquisa.SelectedIndex > 0 Then
            _entregadorPesquisa.Nome = CboEntregadorPesquisa.SelectedItem.ToString
            _entregadorDAO.TrazEntregadorPorNome(_entregadorPesquisa, MdlConexaoBD.conectionPadrao)
        End If
    End Sub

    Private Sub dtgSaida_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgSaida.RowsAdded
        txtQuantidadeRegistros.Text = dtgSaida.Rows.Count
    End Sub

    Private Sub dtgSaida_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dtgSaida.RowsRemoved
        txtQuantidadeRegistros.Text = dtgSaida.Rows.Count
    End Sub

    Function validaSaida() As Boolean

        If MdlConfiguracoes.Configuracoes.validaIniciaisProduto(Me.txtDescricaoProdutoSaida.Text) = False Then
            MsgBox("Código de Barras " & Me.txtDescricaoProdutoSaida.Text & " Inválido!", MsgBoxStyle.Exclamation, Application.ProductName)
            Me.txtDescricaoProdutoSaida.Focus()
            Me.txtDescricaoProdutoSaida.SelectAll()
            Return False
        End If

        If _fornecedor.Id = 0 Then
            MsgBox("Informe um Fornecedor Para Adicionar", MsgBoxStyle.Exclamation, Application.ProductName)
            cboFornecedorSaida.Focus()
            cboFornecedorSaida.DroppedDown = True
            Return False
        End If

        If _cidade.Id = 0 Then
            MsgBox("Informe uma Cidade Para Adicionar", MsgBoxStyle.Exclamation, Application.ProductName)
            CboCidadeSaida.Focus()
            CboCidadeSaida.DroppedDown = True
            Return False
        End If

        If _entregador.Id = 0 Then

            MsgBox("Informe um Entregador Para Adicionar", MsgBoxStyle.Exclamation, Application.ProductName)
            CboCidadeSaida.Focus()
            CboCidadeSaida.DroppedDown = True
            Return False
        End If

        If Not IsNumeric(txtQuantidadeSaida.Text) Then
            MsgBox("Informe uma Quantidade Para Adicionar", MsgBoxStyle.Exclamation, Application.ProductName)
            txtQuantidadeSaida.Focus()
            Return False
        End If

        If Trim(txtDescricaoProdutoSaida.Text).Length < 1 Then
            txtDescricaoProdutoSaida.Focus()
            Return False
        Else

            
            'valida se foi dado entrada antes:
            _entrada.ZeraValores()
            _entrada.DescricaoProduto = Me.txtDescricaoProdutoSaida.Text
            _EntradaDAO.TrazEntradaPorDescricaoProduto(_entrada, MdlConexaoBD.conectionPadrao)
            If _entrada.Id < 1 Then


                _OperacaoProduto = "A"
                _produto.ZeraValores()
                _produto.SetaProduto(_produtoDAO.TrazProdutoPorDescricao(Me.txtDescricaoProdutoSaida.Text, MdlConexaoBD.conectionPadrao))
                If _produto.Id < 1 Then

                    If MessageBox.Show("Produto Não Foi Dado Entrada! Deseja Incluir a Entrada Na Data de Hoje para Contiuar?", Application.ProductName, MessageBoxButtons.YesNo) _
                        = Windows.Forms.DialogResult.Yes Then

                        _OperacaoProduto = "I"
                        preencheValoresEntrada()
                        _EntradaDAO.salvaEntradaProduto(_entrada, _OperacaoProduto)
                        _entrada.ZeraValores()
                        _produto.ZeraValores()
                        _produto.SetaProduto(_produtoDAO.TrazProdutoPorDescricao(Me.txtDescricaoProdutoSaida.Text, MdlConexaoBD.conectionPadrao))
                    Else
                        txtDescricaoProdutoSaida.Focus()
                        txtDescricaoProdutoSaida.SelectAll()
                        Return False
                    End If
                    
                End If


                'Valida se foi dado saída:
                _SaidaProduto.ZeraValores()
                _SaidaProduto.ProdutoDescricao = Me.txtDescricaoProdutoSaida.Text
                _SaidaDAO.TrazSaidaPorDescricaoProduto(_SaidaProduto, MdlConexaoBD.conectionPadrao)
                If _SaidaProduto.Id > 0 Then


                    MsgBox("Esse Produto já foi adicionado na Data: " & _SaidaProduto.DataSaida.ToShortDateString, MsgBoxStyle.Exclamation, Application.ProductName)
                    txtDescricaoProdutoSaida.Focus()
                    txtDescricaoProdutoSaida.SelectAll()
                    Return False
                End If



            End If


        End If


        Return True
    End Function

    Sub preencheValoresEntrada()

        _entrada.ZeraValores()
        With _entrada

            .DescricaoProduto = Me.txtDescricaoProdutoSaida.Text
            .FornecedorID = _fornecedor.Id
            .FornecedorNome = _fornecedor.Nome
            .CidadeID = _cidade.Id
            .CidadeNome = _cidade.Nome
            .Quantidade = CDbl(Me.txtQuantidadeSaida.Text)
            .DataEntrada = dataSaida.Value
            .ProdutoId = _produto.Id
        End With
    End Sub

    Sub preencheValoresSaida()

        _SaidaProduto.ZeraValores()
        With _SaidaProduto

            .ProdutoDescricao = Me.txtDescricaoProdutoSaida.Text
            .FornecedorID = _fornecedor.Id
            .FornecedorNome = _fornecedor.Nome
            .CidadeID = _cidade.Id
            .CidadeNome = _cidade.Nome
            .EntregadorID = _entregador.Id
            .EntregadorNome = _entregador.Nome
            .Comissao = CDbl(txtComissaoSaida.Text)
            .Quantidade = CDbl(Me.txtQuantidadeSaida.Text)
            .DataSaida = dataSaida.Value
            .ProdutoID = _produto.Id
        End With
    End Sub

    Sub zeraCamposSaida()

        _produto.ZeraValores()
        _SaidaProduto.ZeraValores()

        Me.txtDescricaoProdutoSaida.Text = ""
        Me.txtComissaoSaida.Text = "0,00"
        Me.txtDescricaoProdutoSaida.Focus()
    End Sub

    Private Sub txtDescricaoProdutoSaida_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescricaoProdutoSaida.KeyDown

        If e.KeyCode = Keys.Enter Then

            _produto.SetaProduto(_produtoDAO.TrazProdutoPorDescricao(txtDescricaoProdutoSaida.Text, MdlConexaoBD.conectionPadrao))
            If ajustaComissao2() Then
                salvaSaidaProdutos()
            End If

        End If
    End Sub

    Sub ajustaComissao()

        Select Case MdlConfiguracoes.Configuracoes.TipoPagamentoComissao

            Case "E"

                If _entregador.Id < 1 Then

                    _entregador.ZeraValores()
                    If cboEntregadorSaida.SelectedIndex > -1 Then

                        _entregador.Nome = cboEntregadorSaida.SelectedItem.ToString
                        _entregadorDAO.TrazEntregadorPorNome(_entregador, MdlConexaoBD.conectionPadrao)
                    End If
                End If

                txtComissaoSaida.Text = _entregador.Comissao.ToString("0.00")
            Case "F"


                If Me.txtDescricaoProdutoSaida.Text.Equals("") = False Then

                    _produtoVerificacao.SetaProduto(_produtoDAO.TrazProdutoPorDescricao(Me.txtDescricaoProdutoSaida.Text, MdlConexaoBD.conectionPadrao))
                    If _produtoVerificacao.Id < 1 Then
                        MsgBox("Produto não encontrado!", MsgBoxStyle.Exclamation, Application.ProductName)
                        txtComissaoSaida.Text = "0,00"
                        Return
                    End If
                    _fornecedorVerificacao.Id = _produtoVerificacao.FornecedorID
                    _fornecedorDAO.TrazFornecedorPorID(_fornecedorVerificacao, MdlConexaoBD.conectionPadrao)

                    If _fornecedor.Id < 1 Then

                        _fornecedor.SetaFornecedor(_fornecedorVerificacao)
                    Else

                        If _fornecedor.Id <> _fornecedorVerificacao.Id Then

                            MsgBox("Fornecedor do Produto é Diferente do Informado! Na Entrada Está:: " & _fornecedorVerificacao.Nome & ". Será mudado para o da Entrada!", MsgBoxStyle.Exclamation, Application.ProductName)
                            cboFornecedorSaida.SelectedIndex = _funcoes.trazIndexCboTextoTodo(_fornecedorVerificacao.Nome, cboFornecedorSaida)
                        End If
                    End If
                End If
                

                txtComissaoSaida.Text = _fornecedor.ComissaoEntregador.ToString("0.00")
            Case "P"

                txtComissaoSaida.Text = _produto.FornecedorComissaoEntregador.ToString("0.00")
            Case Else

        End Select
    End Sub

    Function ajustaComissao2() As Boolean

        Select Case MdlConfiguracoes.Configuracoes.TipoPagamentoComissao

            Case "E"

                If _entregador.Id < 1 Then

                    _entregador.ZeraValores()
                    If cboEntregadorSaida.SelectedIndex > -1 Then

                        _entregador.Nome = cboEntregadorSaida.SelectedItem.ToString
                        _entregadorDAO.TrazEntregadorPorNome(_entregador, MdlConexaoBD.conectionPadrao)
                    End If
                End If

                txtComissaoSaida.Text = _entregador.Comissao.ToString("0.00")
            Case "F"


                If Me.txtDescricaoProdutoSaida.Text.Equals("") = False Then

                    _produtoVerificacao.SetaProduto(_produtoDAO.TrazProdutoPorDescricao(Me.txtDescricaoProdutoSaida.Text, MdlConexaoBD.conectionPadrao))
                    If _produtoVerificacao.Id < 1 Then
                        MsgBox("Produto não encontrado!", MsgBoxStyle.Exclamation, Application.ProductName)
                        txtComissaoSaida.Text = "0,00"
                        Return False
                    End If
                    _fornecedorVerificacao.Id = _produtoVerificacao.FornecedorID
                    _fornecedorDAO.TrazFornecedorPorID(_fornecedorVerificacao, MdlConexaoBD.conectionPadrao)

                    If _fornecedor.Id < 1 Then

                        _fornecedor.SetaFornecedor(_fornecedorVerificacao)
                    Else

                        If _fornecedor.Id <> _fornecedorVerificacao.Id Then

                            If MessageBox.Show("Fornecedor do Produto é Diferente do Informado! Na Entrada Está:: " & _
                                               _fornecedorVerificacao.Nome & ". Será mudado para o da Entrada!", _
                                               Application.ProductName, MessageBoxButtons.YesNo, _
                                               MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then

                                Return False
                            End If
                            cboFornecedorSaida.SelectedIndex = _funcoes.trazIndexCboTextoTodo(_fornecedorVerificacao.Nome, cboFornecedorSaida)
                        End If
                    End If
                End If


                txtComissaoSaida.Text = _fornecedor.ComissaoEntregador.ToString("0.00")
            Case "P"

                txtComissaoSaida.Text = _produto.FornecedorComissaoEntregador.ToString("0.00")
            Case Else


        End Select

        Return True
    End Function

    Private Sub cboFornecedorSaida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFornecedorSaida.SelectedIndexChanged

        _fornecedor.ZeraValores()
        If cboFornecedorSaida.SelectedIndex > -1 Then

            _fornecedor.Nome = cboFornecedorSaida.SelectedItem.ToString
            _fornecedorDAO.TrazFornecedorPorNome(_fornecedor, MdlConexaoBD.conectionPadrao)

        End If

        ajustaComissao()
    End Sub

    Private Sub cboEntregadorSaida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntregadorSaida.SelectedIndexChanged

        _entregador.ZeraValores()
        If cboEntregadorSaida.SelectedIndex > -1 Then

            _entregador.Nome = cboEntregadorSaida.SelectedItem.ToString
            _entregadorDAO.TrazEntregadorPorNome(_entregador, MdlConexaoBD.conectionPadrao)
        End If

        ajustaComissao()
    End Sub

    Private Sub CboCidadeSaida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboCidadeSaida.SelectedIndexChanged

        _cidade.ZeraValores()
        If CboCidadeSaida.SelectedIndex > -1 Then

            _cidade.Nome = CboCidadeSaida.SelectedItem.ToString
            _cidadeDAO.TrazCidadePorNomeBD(_cidade, MdlConexaoBD.conectionPadrao)
        End If
    End Sub

    Sub salvaSaidaProdutos()

        If validaSaida() = False Then Return
        preencheValoresSaida()

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try

            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Critical, Application.ProductName)
                Return
            End Try

            transacao = conection.BeginTransaction
            _SaidaDAO.incSaidaDeProdutos(_SaidaProduto, conection, transacao)
            transacao.Commit() : conection.ClearPool() : conection.Close()
            zeraCamposSaida()
            ExecutaF5()
            AtualizaGridTabelaSaida()
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

    Private Sub txtComissaoSaida_Leave(sender As Object, e As EventArgs) Handles txtComissaoSaida.Leave

        If IsNumeric(txtComissaoSaida.Text) Then

            txtComissaoSaida.Text = CDbl(txtComissaoSaida.Text).ToString("0.00")
        Else
            txtComissaoSaida.Text = "0.00"
        End If
    End Sub

    Private Sub dtgSaida_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgSaida.CellContentDoubleClick

        If dtgSaida.CurrentRow.IsNewRow = False Then

            _SaidaProduto.Id = CInt(dtgSaida.CurrentRow.Cells(0).Value)
            _SaidaDAO.TrazSaidaDeProdutoPorID(_SaidaProduto, MdlConexaoBD.conectionPadrao)

            If MessageBox.Show("Deseja Realmente Deletar essa Saída?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


                Dim transacao As NpgsqlTransaction
                Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

                Try

                    Try
                        conection.Open()
                    Catch ex As Exception
                        MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Critical, Application.ProductName)
                        Return
                    End Try

                    transacao = conection.BeginTransaction
                    _SaidaDAO.delSaidaDeProduto(_SaidaProduto, conection, transacao)
                    transacao.Commit() : conection.ClearPool() : conection.Close()
                    AtualizaGridTabelaSaida()
                    ExecutaF5()
                Catch ex As Exception
                    MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                    Try
                        transacao.Rollback()

                    Catch ex1 As Exception
                    End Try

                Finally
                    transacao = Nothing : conection = Nothing
                End Try

            End If

        End If

    End Sub

    Private Sub btnManutencaoSaida_Click(sender As Object, e As EventArgs) Handles btnManutencaoSaida.Click

        tbcSaida.SelectTab(2)

    End Sub


#Region "Manutencao das Saídas  "

    Sub AtualizaConsultaMANUTENCAO()

        atualizaConsultaManutencaoProdutoSaidos()
        atualizaConsultaManutencaoProdutosEntreges()
        atualizaConsultaManutencaoProdutosDevolvidos()

    End Sub

    Sub atualizaConsultaManutencaoProdutoSaidos()

        dtgManutencaoSaidas.Rows.Clear()
        _ListaSaidaManutencao.Clear()
        Dim condicao As String = ""
        condicao = "WHERE data_Saida BETWEEN '" & DataInicioSaidaManutencao.Text & "' AND '" & DataFinalSaidaManutencao.Text & "' "


        condicao += "AND finalizado = false AND devolvido = false "

        _SaidaDAO.TrazListSaidasBD_Condicao(_ListaSaidaManutencao, MdlConexaoBD.conectionPadrao, condicao)

        If _ListaSaidaManutencao.Count < 1 Then Return
        For Each p As SaidaDeProdutos In _ListaSaidaManutencao
            dtgManutencaoSaidas.Rows.Add(p.Id, p.DataSaida.ToShortDateString, p.EntregadorNome, p.ProdutoDescricao, p.Quantidade.ToString("0.00"), p.FornecedorNome)
        Next

    End Sub

    Sub atualizaConsultaManutencaoProdutosEntreges()

        dtgProdutosEntreges.Rows.Clear()
        _ListaSaidaManutencao.Clear()
        Dim condicao As String = ""
        condicao = "WHERE data_Saida BETWEEN '" & DataInicioSaidaManutencao.Text & "' AND '" & DataFinalSaidaManutencao.Text & "' "
        condicao += "AND finalizado = true "

        _SaidaDAO.TrazListSaidasBD_Condicao(_ListaSaidaManutencao, MdlConexaoBD.conectionPadrao, condicao)

        If _ListaSaidaManutencao.Count < 1 Then Return
        For Each p As SaidaDeProdutos In _ListaSaidaManutencao
            dtgProdutosEntreges.Rows.Add(p.Id, p.DataSaida.ToShortDateString, p.ProdutoDescricao)
        Next

    End Sub

    Sub atualizaConsultaManutencaoProdutosDevolvidos()

        dtgProdutoDevolvido.Rows.Clear()
        _ListaSaidaManutencao.Clear()
        Dim condicao As String = ""
        condicao = "WHERE data_Saida BETWEEN '" & DataInicioSaidaManutencao.Text & "' AND '" & DataFinalSaidaManutencao.Text & "' "
        condicao += "AND devolvido = true "

        _SaidaDAO.TrazListSaidasBD_Condicao(_ListaSaidaManutencao, MdlConexaoBD.conectionPadrao, condicao)

        If _ListaSaidaManutencao.Count < 1 Then Return
        For Each p As SaidaDeProdutos In _ListaSaidaManutencao
            dtgProdutoDevolvido.Rows.Add(p.Id, p.DataSaida.ToShortDateString, p.ProdutoDescricao)
        Next
    End Sub

    Private Sub dtgProdutosEntreges_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgProdutosEntreges.RowsAdded
        txtQuantidadeEntrege.Text = dtgProdutosEntreges.Rows.Count
    End Sub

    Private Sub dtgProdutosEntreges_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dtgProdutosEntreges.RowsRemoved
        txtQuantidadeEntrege.Text = dtgProdutosEntreges.Rows.Count
    End Sub

    Private Sub dtgProdutoDevolvido_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgProdutoDevolvido.RowsAdded
        txtQuantidadeDevolvido.Text = dtgProdutoDevolvido.Rows.Count
    End Sub

    Private Sub dtgProdutoDevolvido_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dtgProdutoDevolvido.RowsRemoved
        txtQuantidadeDevolvido.Text = dtgProdutoDevolvido.Rows.Count
    End Sub

    Private Sub DtGridManutencaoSaidas_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgManutencaoSaidas.RowsAdded
        txtQuantidadeSaidaManutencao.Text = dtgManutencaoSaidas.Rows.Count
    End Sub

    Private Sub DtGridManutencaoSaidas_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dtgManutencaoSaidas.RowsRemoved
        txtQuantidadeSaidaManutencao.Text = dtgManutencaoSaidas.Rows.Count
    End Sub

    Private Sub btnEntregarTodosManuntencao_Click(sender As Object, e As EventArgs) Handles btnEntregarTodosManuntencao.Click

        UpdateTODAsSaidas()

    End Sub

    Function montaCONSULTA_Manutecao() As String

        Dim vWHERE As String = ""
        vWHERE = "WHERE (data_Saida BETWEEN '" & DataInicioSaidaManutencao.Text & "' AND '" & DataFinalSaidaManutencao.Text & "') "

        If _fornecedorManutencao.Id > 0 Then
            vWHERE += "AND (fornecedor_id = " & _fornecedorManutencao.Id & ") "
        End If

        If _entregadorManutencao.Id > 0 Then
            vWHERE += "AND (entregador_id = " & _entregadorManutencao.Id & ") "
        End If

        If _cidadeManutencao.Id > 0 Then
            vWHERE += "AND (cidade_id = " & _cidadeManutencao.Id & ") "
        End If

        Return vWHERE
    End Function

    Sub UpdateTODAsSaidas()


        Dim vWHERE As String = ""
        vWHERE = montaCONSULTA_Manutecao()
        vWHERE += "AND finalizado = false AND devolvido = false "

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
            _SaidaDAO.altSaidaDeProdutosParaENTREGE_WHERE(Me.DataDaEntrega.Value, vWHERE, conection, transacao)
            transacao.Commit() : conection.ClearPool() : conection.Close()
            MsgBox("Saídas Atualizadas com Sucesso!", MsgBoxStyle.Exclamation, Application.ProductName)
            AtualizaConsultaMANUTENCAO()
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

    Private Sub cboFornecedorManutencao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFornecedorManutencao.SelectedIndexChanged

        _fornecedorManutencao.ZeraValores()
        If cboFornecedorManutencao.SelectedIndex > 0 Then
            _fornecedorManutencao.Nome = cboFornecedorManutencao.SelectedItem.ToString
            _fornecedorDAO.TrazFornecedorPorNome(_fornecedorManutencao, MdlConexaoBD.conectionPadrao)
        End If
    End Sub

    Private Sub cboEntregadorManutencao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntregadorManutencao.SelectedIndexChanged

        _entregadorManutencao.ZeraValores()
        If cboEntregadorManutencao.SelectedIndex > 0 Then
            _entregadorManutencao.Nome = cboEntregadorManutencao.SelectedItem.ToString
            _entregadorDAO.TrazEntregadorPorNome(_entregadorManutencao, MdlConexaoBD.conectionPadrao)
        End If
    End Sub

    Private Sub cboCidadeManutencao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCidadeManutencao.SelectedIndexChanged

        _cidadeManutencao.ZeraValores()
        If cboCidadeManutencao.SelectedIndex > 0 Then
            _cidadeManutencao.Nome = cboCidadeManutencao.SelectedItem.ToString
            _cidadeDAO.TrazCidadePorNomeBD(_cidadeManutencao, MdlConexaoBD.conectionPadrao)
        End If
    End Sub

    Private Sub btnAtualizaConsultaManutencao_Click(sender As Object, e As EventArgs) Handles btnAtualizaConsultaManutencao.Click
        AtualizaConsultaMANUTENCAO()
    End Sub

    Sub DesfazEntrega()

        If dtgProdutosEntreges.Rows.Count < 1 Then Return
        If dtgProdutosEntreges.CurrentRow.IsNewRow = False Then

            _SaidaManutencao.Id = CInt(dtgProdutosEntreges.CurrentRow.Cells(0).Value)
            _SaidaDAO.TrazSaidaDeProdutoPorID(_SaidaManutencao, MdlConexaoBD.conectionPadrao)

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
                _SaidaDAO.altSaidaDeProdutosDesfazENTREGA(_SaidaManutencao, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                atualizaConsultaManutencaoProdutosEntreges()
                atualizaConsultaManutencaoProdutoSaidos()
            Catch ex As Exception
                MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                Try
                    transacao.Rollback()

                Catch ex1 As Exception
                End Try

            Finally
                transacao = Nothing : conection = Nothing
            End Try

        End If

    End Sub

    Sub DesfazDevolucao()

        If dtgProdutoDevolvido.CurrentRow.IsNewRow = False Then

            _SaidaManutencao.Id = CInt(dtgProdutoDevolvido.CurrentRow.Cells(0).Value)
            _SaidaDAO.TrazSaidaDeProdutoPorID(_SaidaManutencao, MdlConexaoBD.conectionPadrao)


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
                _SaidaDAO.altSaidaDeProdutosDesfazDEVOLVIDO(_SaidaManutencao, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                atualizaConsultaManutencaoProdutosDevolvidos()
                atualizaConsultaManutencaoProdutoSaidos()

            Catch ex As Exception
                MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                Try
                    transacao.Rollback()

                Catch ex1 As Exception
                End Try

            Finally
                transacao = Nothing : conection = Nothing
            End Try

        End If

    End Sub

    Private Sub btnDesfazerEntrega_Click(sender As Object, e As EventArgs) Handles btnDesfazerEntrega.Click

        DesfazEntrega()

    End Sub

    Private Sub txtProdutoParaDevolver_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProdutoParaDevolver.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter, Keys.Tab
                _SaidaManutencao.ProdutoDescricao = txtProdutoParaDevolver.Text
                _SaidaDAO.TrazSaidaPorDescricaoProduto(_SaidaManutencao, MdlConexaoBD.conectionPadrao)
                DevolveSaidaProduto(_SaidaManutencao)
                txtProdutoParaDevolver.Text = ""

        End Select
    End Sub

    Sub DevolveSaidaProduto(vSaida As SaidaDeProdutos)

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
            vSaida.DataDevolucao = Date.Now
            _SaidaDAO.altSaidaDeProdutosParaDEVOLVIDO(vSaida, conection, transacao)
            transacao.Commit() : conection.ClearPool() : conection.Close()
            AtualizaConsultaMANUTENCAO()
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

#End Region


    Private Sub DataSaidaManutencao_ValueChanged(sender As Object, e As EventArgs) Handles DataInicioSaidaManutencao.ValueChanged, DataFinalSaidaManutencao.ValueChanged
        AtualizaConsultaMANUTENCAO()
    End Sub

    Private Sub dtgProdutoDevolvido_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgProdutoDevolvido.CellClick

        If e.ColumnIndex = 3 Then

            DesfazDevolucao()
        End If
    End Sub

    Private Sub tbcSaida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcSaida.SelectedIndexChanged

        Select Case tbcSaida.SelectedIndex
            Case 2
                AtualizaConsultaMANUTENCAO()
        End Select
        
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        executaF11()
    End Sub

    Sub executaF11()

        '_listaSaidasProdutoRelatorio.Clear()
        '_SaidaDAO.CopiaListaEntradaDeOutraLISTA(_listaSaidasProdutoRelatorio, _listaSaidasProduto)

        If _listaSaidasProdutoRelatorio.Count > 0 Then

            Dim mformRelatorio As New FormListaSaidaProduto
            mformRelatorio._FiltroFornecedor = _fornecedorPesquisa.Nome
            mformRelatorio._FiltroDescricao = txtPesquisaDescricaoProduto.Text
            mformRelatorio._FiltroDtInicial = dtpInicio.Text
            mformRelatorio._FiltroDtFinal = dtpFim.Text
            mformRelatorio._FiltroEntregador = _entregadorPesquisa.Nome
            mformRelatorio._FiltroCidade = _cidadePesquisa.Nome
            mformRelatorio._TipoDatas = "Saídas:"
            If rdbDataEntrega.Checked Then mformRelatorio._TipoDatas = "Entregas:"
            If rdbDataDevolucao.Checked Then mformRelatorio._TipoDatas = "Devoluções:"
            mformRelatorio._ListaSaidaProdutos = _listaSaidasProdutoRelatorio
            mformRelatorio.ShowDialog()
            mformRelatorio = Nothing
        Else
            MsgBox("Não foi Encotrados Registros! Pressione F5 e Depois tente novamente", MsgBoxStyle.Exclamation, Application.ProductName)
        End If


    End Sub

End Class