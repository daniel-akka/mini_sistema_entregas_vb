Imports Npgsql
Public Class FormPagamentoComissao

    'Objetos para Pesquisa:
    Private _PagamentoComissao As New PagamentoComissao
    Private _PagamentoComissaoDAO As New PagamentoComissaoDAO
    Private _ListaComissoes As New List(Of PagamentoComissao)
    Private _ListaComissoesRelatorio As New List(Of PagamentoComissao)

    'Objetos:
    Private _Entregador As New Entregador
    Private _EntregadorPesquisa As New Entregador
    Private _Fornecedor As New Fornecedor
    Private _FornecedorPesquisa As New Fornecedor
    Private _FornecedorDAO As New FornecedorDAO
    Private _EntregadorDAO As New EntregadorDAO
    Private _SaidaProdutoDAO As New SaidaDeProdutosDAO
    Private _listaSaidasProduto As New List(Of SaidaDeProdutos)

    Dim _mudouFornecedor As Boolean = False

    Private Sub FormPagamentoComissao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializaCamposFormulario()
        ExecutaF5()
    End Sub

    Private Sub FormPagamentoComissao_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                ExecutaF2()
            Case Keys.F5
                ExecutaF5()
            Case Keys.F11
                executaF11()
        End Select
    End Sub

    Sub InicializaCamposFormulario()

        _EntregadorDAO.PreencheCboEntregadoresRelatorio(cboEntregadorPagoPesquisa, MdlConexaoBD.conectionPadrao)
        _EntregadorDAO.PreencheCboEntregadoresBD(CboEntregadorPAgo, MdlConexaoBD.conectionPadrao)
        _FornecedorDAO.PreencheCboFornecedoresPesquisa(Me.CboFornecedorPesquisa, MdlConexaoBD.conectionPadrao)
        _FornecedorDAO.PreencheCboFornecedoresPesquisa(Me.cboFornecedor, MdlConexaoBD.conectionPadrao)
        _FornecedorDAO.PreencheCboFornecedoresPesquisa(Me.cboFornecedorPesquisaPRINCIPAL, MdlConexaoBD.conectionPadrao)

        If cboEntregadorPagoPesquisa.Items.Count = 1 Then
            cboEntregadorPagoPesquisa.SelectedIndex = 0
        ElseIf cboEntregadorPagoPesquisa.Items.Count = 2 Then
            cboEntregadorPagoPesquisa.SelectedIndex = 1
        End If

        If CboFornecedorPesquisa.Items.Count = 2 Then
            CboFornecedorPesquisa.SelectedIndex = 1
        ElseIf CboFornecedorPesquisa.Items.Count > 0 Then
            CboFornecedorPesquisa.SelectedIndex = 0
        End If

        If cboFornecedorPesquisaPRINCIPAL.Items.Count = 2 Then
            cboFornecedorPesquisaPRINCIPAL.SelectedIndex = 1
        ElseIf cboFornecedorPesquisaPRINCIPAL.Items.Count > 0 Then
            cboFornecedorPesquisaPRINCIPAL.SelectedIndex = 0
        End If

        If CboEntregadorPAgo.Items.Count = 1 Then CboEntregadorPAgo.SelectedIndex = 0

    End Sub

    Sub ExecutaF5()

        dtgComissaoPagas.Rows.Clear()
        _ListaComissoes.Clear()
        Dim condicao As String = ""

        condicao = "WHERE (data_pagamento BETWEEN '" & dtpInicioPago.Text & "' AND '" & dtpFimPago.Text & "') "
       
        If Trim(txtObservacaoPesquisa.Text).Length > 0 Then
            condicao += "AND observacao LIKE '%" & txtObservacaoPesquisa.Text & "%' "
        End If

        If _EntregadorPesquisa.Id > 0 Then
            condicao += "AND entregador_id = " & _EntregadorPesquisa.Id & " "
        End If

        If _FornecedorPesquisa.Id > 0 Then
            condicao += "AND fornecedor_id = " & _FornecedorPesquisa.Id & " "
        End If


        _PagamentoComissaoDAO.TrazListPagamentoComissaosBD_WHERE(_ListaComissoes, MdlConexaoBD.conectionPadrao, condicao)


        txtQtdeRegistrosComissoes.Text = _ListaComissoes.Count
        txtSomaComissoes.Text = _ListaComissoes.Sum(Function(c As PagamentoComissao) c.ValorPago).ToString("0.00")

        If _ListaComissoes.Count < 1 Then Return
        For Each p As PagamentoComissao In _ListaComissoes
            dtgComissaoPagas.Rows.Add(p.Id, p.DataPagamento.ToShortDateString, p.EntregadorNome, p.ValorPago.ToString("0.00"), p.Observacao)
        Next

        
    End Sub

    Sub AtualizaGridTabelaSaidaENTREGUES()

        dtgEntregues.Rows.Clear()
        _listaSaidasProduto.Clear()
        txtQuantidadeEntregas.Text = "0"
        txtSomaTotalEntreges.Text = "0,00"
        Dim condicao As String = ""
        condicao = "WHERE data_Saida BETWEEN '" & dtpInicioEntrege.Text & "' AND '" & dtpFimEntrege.Text & "' "
        If _Fornecedor.Id > 0 Then
            condicao += "AND fornecedor_id = " & _Fornecedor.Id & " "
        End If
        condicao += "AND finalizado = true "

        _SaidaProdutoDAO.TrazListSaidasBD_Condicao(_listaSaidasProduto, MdlConexaoBD.conectionPadrao, condicao)



        If _listaSaidasProduto.Count < 1 Then Return
        For Each p As SaidaDeProdutos In _listaSaidasProduto
            dtgEntregues.Rows.Add(p.Id, p.DataSaida.ToShortDateString, p.EntregadorNome, p.ProdutoDescricao, p.Quantidade.ToString("0.00"), p.FornecedorNome)
        Next

        txtQuantidadeEntregas.Text = _listaSaidasProduto.Count
        txtSomaTotalEntreges.Text = _listaSaidasProduto.Sum(Function(s As SaidaDeProdutos) s.Comissao).ToString("0.00")
    End Sub

    Private Sub CboEntregadorPAgo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboEntregadorPAgo.SelectedIndexChanged

        _Entregador.ZeraValores()
        If CboEntregadorPAgo.SelectedIndex > -1 Then
            _Entregador.Nome = CboEntregadorPAgo.SelectedItem.ToString
            _EntregadorDAO.TrazEntregadorPorNome(_Entregador, MdlConexaoBD.conectionPadrao)
        End If
    End Sub

    Private Sub cboEntregadorPagoPesquisa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntregadorPagoPesquisa.SelectedIndexChanged

        _EntregadorPesquisa.ZeraValores()
        If cboEntregadorPagoPesquisa.SelectedIndex > 0 Then
            _EntregadorPesquisa.Nome = cboEntregadorPagoPesquisa.SelectedItem.ToString
            _EntregadorDAO.TrazEntregadorPorNome(_EntregadorPesquisa, MdlConexaoBD.conectionPadrao)
        End If
    End Sub

    Private Sub btnConsultaPagos_Click(sender As Object, e As EventArgs) Handles btnConsultaPagos.Click
        ExecutaF5()
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        ExecutaDel()
    End Sub

    Sub ExecutaDel()

        _PagamentoComissao.ZeraValores()
        If dtgComissaoPagas.RowCount < 1 Then Return
        If dtgComissaoPagas.CurrentRow.IsNewRow = False Then

            _PagamentoComissao.Id = CInt(dtgComissaoPagas.CurrentRow.Cells(0).Value)
            _PagamentoComissaoDAO.TrazPagamentoComissaoPorID(_PagamentoComissao, MdlConexaoBD.conectionPadrao)

            If MessageBox.Show("Deseja Realmente Deletar esse Lançamento?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


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
                    _PagamentoComissaoDAO.delPagamentoComissao(_PagamentoComissao, conection, transacao)
                    transacao.Commit() : conection.ClearPool() : conection.Close()
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

    Private Sub btnBuscarEntreges_Click(sender As Object, e As EventArgs) Handles btnBuscarEntreges.Click
        AtualizaGridTabelaSaidaENTREGUES()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

        If ValidaPagamento() Then

            PreencheValoresPagamento()
            SalvaComissao()
        End If
    End Sub

    Sub SalvaComissao()

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
            _PagamentoComissaoDAO.incPagamentoComissao(_PagamentoComissao, conection, transacao)
            transacao.Commit() : conection.ClearPool() : conection.Close()
            MsgBox("Comissão Registrada Com Sucesso!", MsgBoxStyle.Exclamation, Application.ProductName)
            LimpaCamposFormulario()
            ExecutaF5()
            tbcPagComissao.SelectTab(0)
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

    Sub PreencheValoresPagamento()

        With _PagamentoComissao

            .DataPagamento = dataPagamento.Value
            .EntregadorID = _Entregador.Id
            .EntregadorNome = _Entregador.Nome
            .ValorPago = CDbl(txtValorComissao.Text)
            .Observacao = txtObservacao.Text
            .FornecedorID = _Fornecedor.Id
            .FornecedorNome = _Fornecedor.Nome
        End With
    End Sub

    Sub LimpaCamposFormulario()
        txtObservacao.Text = ""
        txtValorComissao.Text = "0,00"
    End Sub

    Function ValidaPagamento() As Boolean

        If _Entregador.Id < 1 Then
            MsgBox("Informe um Entregador!", MsgBoxStyle.Exclamation, Application.ProductName)
            CboEntregadorPAgo.Focus()
            CboEntregadorPAgo.DroppedDown = True
            Return False
        End If

        If CDbl(txtValorComissao.Text) <= 0 Then
            MsgBox("Informe um Valor Maior que Zero pra Comissão!", MsgBoxStyle.Exclamation, Application.ProductName)
            txtValorComissao.Focus()
            txtValorComissao.SelectAll()
            Return False
        End If

        Return True
    End Function

    Private Sub btnPagarComissao_Click(sender As Object, e As EventArgs) Handles btnPagarComissao.Click

        ExecutaF2()
    End Sub

    Sub ExecutaF2()
        tbcPagComissao.SelectTab(1)

        If CboEntregadorPAgo.Items.Count = 1 Then
            txtValorComissao.Focus()
            txtValorComissao.SelectAll()
        ElseIf CboEntregadorPAgo.Items.Count > 1 Then
            CboEntregadorPAgo.Focus()
            CboEntregadorPAgo.DroppedDown = True
        End If
    End Sub

    Private Sub txtTotalComissao_Leave(sender As Object, e As EventArgs) Handles txtValorComissao.Leave

        If IsNumeric(txtValorComissao.Text) Then
            txtValorComissao.Text = CDbl(txtValorComissao.Text).ToString("0.00")
        Else
            txtValorComissao.Text = "0,00"
        End If
    End Sub

    Private Sub FormPagamentoComissao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        executaF11()
    End Sub

    Sub executaF11()

        _ListaComissoesRelatorio.Clear()
        _PagamentoComissaoDAO.CopiaListaPagamentoComissaoDeOutraLISTA(_ListaComissoesRelatorio, _ListaComissoes)

        If _ListaComissoesRelatorio.Count > 0 Then

            Dim mformRelatorio As New FormListaComissaoEntregador
            mformRelatorio._FiltroEntregador = _Entregador.Nome
            mformRelatorio._FiltroObservacao = txtObservacaoPesquisa.Text
            mformRelatorio._FiltroDtInicial = dtpInicioPago.Text
            mformRelatorio._FiltroDtFinal = dtpFimPago.Text
            mformRelatorio._FiltroFornecedor = _FornecedorPesquisa.Nome
            mformRelatorio._ListaComissaoEntregador = _ListaComissoesRelatorio
            mformRelatorio.ShowDialog()
            mformRelatorio = Nothing
        Else
            MsgBox("Não foi Encotrados Registros! Pressione F5 e Depois tente novamente", MsgBoxStyle.Exclamation, Application.ProductName)
        End If


    End Sub

    Private Sub CboFornecedorPesquisa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFornecedorPesquisa.SelectedIndexChanged

        _Fornecedor.ZeraValores()
        If CboFornecedorPesquisa.SelectedIndex > 0 Then
            _Fornecedor.Nome = CboFornecedorPesquisa.SelectedItem.ToString
            _FornecedorDAO.TrazFornecedorPorNome(_Fornecedor, MdlConexaoBD.conectionPadrao)
            If CboFornecedorPesquisa.SelectedIndex <> cboFornecedor.SelectedIndex Then
                cboFornecedor.SelectedIndex = CboFornecedorPesquisa.SelectedIndex
            End If
        Else
            If CboFornecedorPesquisa.SelectedIndex <> cboFornecedor.SelectedIndex Then
                cboFornecedor.SelectedIndex = CboFornecedorPesquisa.SelectedIndex
            End If
        End If

    End Sub

    Private Sub cboFornecedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFornecedor.SelectedIndexChanged

        _mudouFornecedor = False
        If CboFornecedorPesquisa.SelectedIndex <> cboFornecedor.SelectedIndex Then
            _mudouFornecedor = True
            CboFornecedorPesquisa.SelectedIndex = cboFornecedor.SelectedIndex
        End If
    End Sub

    Private Sub cboFornecedorPesquisaPRINCIPAL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFornecedorPesquisaPRINCIPAL.SelectedIndexChanged

        _FornecedorPesquisa.ZeraValores()
        If cboFornecedorPesquisaPRINCIPAL.SelectedIndex > 0 Then
            _FornecedorPesquisa.Nome = cboFornecedorPesquisaPRINCIPAL.SelectedItem.ToString
            _FornecedorDAO.TrazFornecedorPorNome(_FornecedorPesquisa, MdlConexaoBD.conectionPadrao)
        End If
        ExecutaF5()
    End Sub
End Class