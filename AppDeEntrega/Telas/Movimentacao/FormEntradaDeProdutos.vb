Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql
Public Class FormEntradaDeProdutos

    'Objetos para Pesquisa:
    Private _produtoPesquisa As New Produto
    Private _fornecedorPesquisa As New Fornecedor
    Private _cidadePesquisa As New Cidade
    Private _listaEntradasProdutoRelatorio As New List(Of EntradaDeProdutos)
    Private _listaEntradasProduto As New List(Of EntradaDeProdutos)


    'Objetos para Cadastro:
    Private _produto As New Produto
    Private _fornecedor As New Fornecedor
    Private _entradaProduto As New EntradaDeProdutos
    Private _cidade As New Cidade

    'Objetos pra Vizualizar Entrada:
    Private _entradaProdutoVIEW As New EntradaDeProdutos

    'Objetos para controle:
    Private _produtoDAO As New ProdutoDAO
    Private _fornecedorDAO As New FornecedorDAO
    Private _cidadeDAO As New CidadeDAO
    Private _entradaDAO As New EntradaDeProdutosDAO
    Dim _OperacaoProduto As String = "I"

    Private Sub btnCadEntrada_Click(sender As Object, e As EventArgs) Handles btnCadEntrada.Click
        ExecutaF2()
    End Sub

    Private Sub FormEntradaDeProdutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If MdlConfiguracoes.Configuracoes.TipoPagamentoComissao.Equals("E") Then
            lblTotalEntrada.Visible = False
            txtSomaTotaisEntrada.Visible = False
        End If
        InicializaCamposFormulario()
        ExecutaF5()
        AtualizaGridTabelaEntrada()
    End Sub

    Private Sub FormEntradaDeProdutos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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

        _fornecedorDAO.PreencheCboFornecedoresPesquisa(Me.CboPesquisaFornecedor, MdlConexaoBD.conectionPadrao)
        _fornecedorDAO.PreencheCboFornecedoresSoNomeBD(Me.cboFornecedorEntrada, MdlConexaoBD.conectionPadrao)
        _cidadeDAO.PreencheCboCidadesPesquisaBD(Me.cboCidadesPesquisa, MdlConexaoBD.conectionPadrao)
        _cidadeDAO.PreencheCboCidadesBD(Me.CboCidadeEntrada, MdlConexaoBD.conectionPadrao)

        If CboPesquisaFornecedor.Items.Count = 1 Then
            CboPesquisaFornecedor.SelectedIndex = 0
        ElseIf CboPesquisaFornecedor.Items.Count = 2 Then
            CboPesquisaFornecedor.SelectedIndex = 1
        End If

        If cboCidadesPesquisa.Items.Count = 1 Then
            cboCidadesPesquisa.SelectedIndex = 0
        ElseIf cboCidadesPesquisa.Items.Count = 2 Then
            cboCidadesPesquisa.SelectedIndex = 1
        End If

        If cboFornecedorEntrada.Items.Count = 1 Then cboFornecedorEntrada.SelectedIndex = 0
        If CboCidadeEntrada.Items.Count = 1 Then CboCidadeEntrada.SelectedIndex = 0

    End Sub

    Sub ExecutaF2()
        tbcEntrada.SelectTab(1)
        If cboFornecedorEntrada.Items.Count > 1 Then

            cboFornecedorEntrada.Focus()
            cboFornecedorEntrada.DroppedDown = True
        Else

            If CboCidadeEntrada.Items.Count > 1 Then

                CboCidadeEntrada.Focus()
                CboCidadeEntrada.DroppedDown = True

            Else
                txtDescricaoProdutoEntrada.Focus()
            End If
        End If

        AtualizaGridTabelaEntrada()
    End Sub

    Sub ExecutaF5()

        dtgEntradaRelacao.Rows.Clear()
        _listaEntradasProdutoRelatorio.Clear()
        Dim condicao As String = ""
        condicao = "WHERE (data_entrada BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "') "

        If txtDescricaoProdutoEntrada.Text.Length > 0 Then
            condicao += "AND descricao_produto LIKE '%" & txtPesquisaDescricaoProduto.Text & "%' "
        End If

        If _fornecedorPesquisa.Id > 0 Then
            condicao += "AND fornecedor_id = " & _fornecedorPesquisa.Id & " "
        End If

        If _cidadePesquisa.Id > 0 Then
            condicao += "AND cidade_id = " & _cidadePesquisa.Id & " "
        End If

        _entradaDAO.TrazListEntradasBD_Condicao(_listaEntradasProdutoRelatorio, MdlConexaoBD.conectionPadrao, condicao)


        txtQuantidadeRegistros.Text = _listaEntradasProdutoRelatorio.Count
        txtSomaTotaisEntrada.Text = "0,00"
        If _listaEntradasProdutoRelatorio.Count < 1 Then Return
        For Each p As EntradaDeProdutos In _listaEntradasProdutoRelatorio
            dtgEntradaRelacao.Rows.Add(p.Id, p.DescricaoProduto, p.DataEntrada.ToShortDateString, p.FornecedorNome, p.Quantidade.ToString("0.00"), puxaValorEntrada(p))
        Next

        If Not MdlConfiguracoes.Configuracoes.TipoPagamentoComissao.Equals("E") Then
            txtSomaTotaisEntrada.Text = SomaValoresPecasEntrada().ToString("0.00")
        End If
    End Sub

    Function puxaValorEntrada(ventrada As EntradaDeProdutos) As Double
        Dim vValor As Double = 0


        Select Case MdlConfiguracoes.Configuracoes.TipoPagamentoComissao

            Case "p"
                Dim mProd As New Produto
                mProd.SetaProduto(MdlConexaoBD.ListaProdutos.Find(Function(p As Produto) p.Id = ventrada.ProdutoId))
                vValor = (mProd.FornecedorComissao + mProd.AdicionalValor)
            Case "F"
                Dim mForn As New Fornecedor
                mForn.SetaFornecedor(MdlConexaoBD.ListaFornecedores.Find(Function(f As Fornecedor) f.Id = ventrada.FornecedorID))
                vValor = mForn.ComissaoEntregador
        End Select

        Return vValor
    End Function

    Sub AtualizaGridTabelaEntrada()

        dtgEntrada.Rows.Clear()
        _listaEntradasProduto.Clear()
        If dataEntrada.Text.Equals("") Then Return
        Dim condicao As String = ""
        condicao = "WHERE data_entrada BETWEEN '" & dataEntrada.Text & "' AND '" & dataEntrada.Text & "' "

        _entradaDAO.TrazListEntradasBD_Condicao(_listaEntradasProduto, MdlConexaoBD.conectionPadrao, condicao)

        txtRegistrosEntrada.Text = _listaEntradasProduto.Count
        If _listaEntradasProduto.Count < 1 Then Return
        For Each p As EntradaDeProdutos In _listaEntradasProduto
            dtgEntrada.Rows.Add(p.Id, p.DescricaoProduto, p.DataEntrada.ToShortDateString, p.FornecedorNome, p.Quantidade.ToString("0.00"))
        Next

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ExecutaF5()
    End Sub

    Private Sub CboPesquisaFornecedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPesquisaFornecedor.SelectedIndexChanged

        _fornecedorPesquisa.ZeraValores()
        If CboPesquisaFornecedor.SelectedIndex > 0 Then
            _fornecedorPesquisa.Nome = CboPesquisaFornecedor.SelectedItem.ToString
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

    Private Sub dtgEntrada_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgEntrada.RowsAdded
        txtQuantidadeRegistros.Text = dtgEntrada.Rows.Count
    End Sub

    Private Sub dtgEntrada_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dtgEntrada.RowsRemoved
        txtQuantidadeRegistros.Text = dtgEntrada.Rows.Count
    End Sub

    Function validaEntrada() As Boolean

        If MdlConfiguracoes.Configuracoes.validaIniciaisProduto(Me.txtDescricaoProdutoEntrada.Text) = False Then
            MsgBox("Código de Barras " & Me.txtDescricaoProdutoEntrada.Text & " Inválido!", MsgBoxStyle.Exclamation, Application.ProductName)
            Me.txtDescricaoProdutoEntrada.Focus()
            Me.txtDescricaoProdutoEntrada.SelectAll()
            Return False
        End If

        If _fornecedor.Id = 0 Then
            MsgBox("Informe um Fornecedor Para Adicionar", MsgBoxStyle.Exclamation, Application.ProductName)
            cboFornecedorEntrada.Focus()
            cboFornecedorEntrada.DroppedDown = True
            Return False
        End If

        If _cidade.Id = 0 Then
            MsgBox("Informe uma Cidade Para Adicionar", MsgBoxStyle.Exclamation, Application.ProductName)
            CboCidadeEntrada.Focus()
            CboCidadeEntrada.DroppedDown = True
            Return False
        End If

        If Not IsNumeric(txtQuantidadeEntrada.Text) Then
            MsgBox("Informe uma Quantidade Para Adicionar", MsgBoxStyle.Exclamation, Application.ProductName)
            txtQuantidadeEntrada.Focus()
            Return False
        End If

        If Trim(txtDescricaoProdutoEntrada.Text).Length < 1 Then
            txtDescricaoProdutoEntrada.Focus()
            Return False
        Else

            _OperacaoProduto = "I"
            _produto.ZeraValores()
            _produto.SetaProduto(_produtoDAO.TrazProdutoPorDescricao(Me.txtDescricaoProdutoEntrada.Text, MdlConexaoBD.conectionPadrao))
            If _produto.Id > 0 Then

                _OperacaoProduto = "A"
                _entradaProduto.ZeraValores()
                _entradaProduto.DescricaoProduto = _produto.Descricao
                _entradaProduto.ProdutoId = _produto.Id
                _entradaDAO.TrazEntradaPorDescricaoProduto(_entradaProduto, MdlConexaoBD.conectionPadrao)

                If _entradaProduto.Id > 0 Then

                    MsgBox("Esse Produto já foi adicionado na Data: " & _entradaProduto.DataEntrada.ToShortDateString, MsgBoxStyle.Exclamation, Application.ProductName)
                    txtDescricaoProdutoEntrada.Focus()
                    txtDescricaoProdutoEntrada.SelectAll()
                    Return False
                End If

            End If
        End If


        Return True
    End Function

    Sub preencheValoresEntrada()

        _entradaProduto.ZeraValores()
        With _entradaProduto

            .DescricaoProduto = Me.txtDescricaoProdutoEntrada.Text
            .FornecedorID = _fornecedor.Id
            .FornecedorNome = _fornecedor.Nome
            .CidadeID = _cidade.Id
            .CidadeNome = _cidade.Nome
            .Quantidade = CDbl(Me.txtQuantidadeEntrada.Text)
            .DataEntrada = dataEntrada.Value
            .ProdutoId = _produto.Id
        End With
    End Sub

    Sub zeraCamposEntrada()

        _produto.ZeraValores()
        _entradaProduto.ZeraValores()

        Me.txtDescricaoProdutoEntrada.Text = ""
        Me.txtDescricaoProdutoEntrada.Focus()
    End Sub

    Private Sub txtDescricaoProdutoEntrada_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescricaoProdutoEntrada.KeyDown

        If e.KeyCode = Keys.Enter Then

            salvaEntradaProdutos()
            zeraCamposEntrada()
        End If
    End Sub

    Private Sub cboFornecedorEntrada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFornecedorEntrada.SelectedIndexChanged

        _fornecedor.ZeraValores()
        If cboFornecedorEntrada.SelectedIndex > -1 Then

            _fornecedor.Nome = cboFornecedorEntrada.SelectedItem.ToString
            _fornecedorDAO.TrazFornecedorPorNome(_fornecedor, MdlConexaoBD.conectionPadrao)
        End If
    End Sub

    Sub salvaEntradaProdutos()


        If validaEntrada() = False Then Return
        preencheValoresEntrada()

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
            _entradaDAO.incEntradaDeProdutos(_entradaProduto, _OperacaoProduto, conection, transacao)
            transacao.Commit() : conection.ClearPool() : conection.Close()
            AtualizaGridTabelaEntrada()
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

    End Sub

    Private Sub CboCidadeEntrada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboCidadeEntrada.SelectedIndexChanged

        _cidade.ZeraValores()
        If CboCidadeEntrada.SelectedIndex > -1 Then

            _cidade.Nome = CboCidadeEntrada.SelectedItem.ToString
            _cidadeDAO.TrazCidadePorNomeBD(_cidade, MdlConexaoBD.conectionPadrao)
        End If
    End Sub

    Private Sub dtgEntrada_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgEntrada.CellContentDoubleClick

        If dtgEntrada.CurrentRow.IsNewRow = False Then

            _entradaProduto.Id = CInt(dtgEntrada.CurrentRow.Cells(0).Value)
            _entradaDAO.TrazEntradaPorID(_entradaProduto, MdlConexaoBD.conectionPadrao)

            If MessageBox.Show("Deseja Realmente Deletar essa Entrada?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
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
                    _entradaDAO.delEntradaProduto(_entradaProduto, conection, transacao)
                    transacao.Commit() : conection.ClearPool() : conection.Close()
                    AtualizaGridTabelaEntrada()
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

    Private Sub dataEntrada_ValueChanged(sender As Object, e As EventArgs) Handles dataEntrada.ValueChanged
        AtualizaGridTabelaEntrada()
    End Sub

    Function SomaValoresPecasEntrada() As Double
        Dim vSoma As Double = 0.0

        For Each row As DataGridViewRow In dtgEntradaRelacao.Rows

            If Not row.IsNewRow Then
                vSoma += row.Cells(5).Value
            End If
        Next

        Return vSoma
    End Function

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        executaF11()
    End Sub

    Sub executaF11()

        
        If _listaEntradasProdutoRelatorio.Count > 0 Then

            Dim mformRelatorio As New FormListaEntradasProduto
            mformRelatorio._FiltroFornecedor = _fornecedorPesquisa.Nome
            mformRelatorio._FiltroDescricao = txtPesquisaDescricaoProduto.Text
            mformRelatorio._FiltroDtInicial = dtpInicio.Text
            mformRelatorio._FiltroDtFinal = dtpFim.Text
            mformRelatorio._FiltroCidade = _cidadePesquisa.Nome
            mformRelatorio._TotalReceber = txtSomaTotaisEntrada.Text
            mformRelatorio._ListaEntradaProdutos = _listaEntradasProdutoRelatorio
            mformRelatorio.ShowDialog()
            mformRelatorio = Nothing
        Else
            MsgBox("Não foi Encotrados Registros! Pressione F5 e Depois tente novamente", MsgBoxStyle.Exclamation, Application.ProductName)
        End If


    End Sub

End Class