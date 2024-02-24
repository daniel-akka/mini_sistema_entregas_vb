Imports Npgsql
Public Class FormRecebimentoFornecedor

    'Objetos para Pesquisa:
    Private _PagamentoComissao As New PagamentoComissaoFornecedor
    Private _PagamentoComissaoDAO As New PagamentoComissaoFornecedorDAO
    Private _ListaComissoes As New List(Of PagamentoComissaoFornecedor)
    Private _ListaComissoesRelatorio As New List(Of PagamentoComissaoFornecedor)
    Private _ListaSaidasEntregues As New List(Of SaidaDeProdutos)
    Private _SaidaProdutoDAO As New SaidaDeProdutosDAO
    Private _ListaFornecedores As New List(Of Fornecedor)


    'Objetos:
    Private _Fornecedor As New Fornecedor
    Private _FornecedorPesquisa As New Fornecedor
    Private _FornecedorSaidaEntregue As New Fornecedor
    Private _FornecedorDAO As New FornecedorDAO

    Private Sub FormPagamentoComissao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializaCamposFormulario()
        ExecutaF5()

    End Sub

    Private Sub FormPagamentoComissao_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                ExecutaF5()
            Case Keys.F11
                executaF11()
        End Select
    End Sub

    Sub InicializaCamposFormulario()

        _FornecedorDAO.PreencheCboFornecedoresRelatorio(cboFornecedorPesquisa, MdlConexaoBD.conectionPadrao)
        _FornecedorDAO.PreencheCboFornecedoresSoNomeBD(CboFornecedor, MdlConexaoBD.conectionPadrao)
        _FornecedorDAO.PreencheCboFornecedoresRelatorio(cboFornecedorPesquisaENTREGUES, MdlConexaoBD.conectionPadrao)
        _FornecedorDAO.TrazListFornecedoresBD(_ListaFornecedores, MdlConexaoBD.conectionPadrao)

        If cboFornecedorPesquisa.Items.Count = 1 Then
            cboFornecedorPesquisa.SelectedIndex = 0
        ElseIf cboFornecedorPesquisa.Items.Count = 2 Then
            cboFornecedorPesquisa.SelectedIndex = 1
        End If

        If cboFornecedorPesquisaENTREGUES.Items.Count = 2 Then
            cboFornecedorPesquisaENTREGUES.SelectedIndex = 1
        Else
            cboFornecedorPesquisaENTREGUES.SelectedIndex = 0
        End If

        If CboFornecedor.Items.Count = 1 Then CboFornecedor.SelectedIndex = 0


    End Sub

    Sub ExecutaF5()

        dtgComissaoPagas.Rows.Clear()
        _ListaComissoes.Clear()
        Dim condicao As String = ""

        condicao = "WHERE (data_pagamento BETWEEN '" & dtpInicioPago.Text & "' AND '" & dtpFimPago.Text & "') "

        If _FornecedorPesquisa.Id > 0 Then
            condicao += "AND fornecedor_id = " & _FornecedorPesquisa.Id & " "
        End If

        If Trim(txtObservacaoPesquisa.Text).Length > 0 Then
            condicao += "AND observacao LIKE '" & txtObservacaoPesquisa.Text & "%' "
        End If


        _PagamentoComissaoDAO.TrazListPagamentoComissaoFornecedorsBD_WHERE(_ListaComissoes, MdlConexaoBD.conectionPadrao, condicao)



        If _ListaComissoes.Count < 1 Then Return
        For Each p As PagamentoComissaoFornecedor In _ListaComissoes
            dtgComissaoPagas.Rows.Add(p.Id, p.DataPagamento.ToShortDateString, p.FornecedorNome, p.ValorPago.ToString("#,##0.00"), p.Observacao)
        Next

        txtQtdeRegistrosComissoes.Text = _ListaComissoes.Count
        txtSomaComissoes.Text = _ListaComissoes.Sum(Function(c As PagamentoComissaoFornecedor) c.ValorPago).ToString("#,##0.00")
    End Sub



    Private Sub CboFornecedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFornecedor.SelectedIndexChanged

        _Fornecedor.ZeraValores()
        If CboFornecedor.SelectedIndex > -1 Then
            _Fornecedor.Nome = CboFornecedor.SelectedItem.ToString
            _FornecedorDAO.TrazFornecedorPorNome(_Fornecedor, MdlConexaoBD.conectionPadrao)
        End If
    End Sub

    Private Sub cboEntregadorPagoPesquisa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFornecedorPesquisa.SelectedIndexChanged

        _FornecedorPesquisa.ZeraValores()
        If cboFornecedorPesquisa.SelectedIndex > 0 Then
            _FornecedorPesquisa.Nome = cboFornecedorPesquisa.SelectedItem.ToString
            _FornecedorDAO.TrazFornecedorPorNome(_FornecedorPesquisa, MdlConexaoBD.conectionPadrao)
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
            _PagamentoComissaoDAO.TrazPagamentoComissaoFornecedorPorID(_PagamentoComissao, MdlConexaoBD.conectionPadrao)

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
                    _PagamentoComissaoDAO.delPagamentoComissaoFornecedor(_PagamentoComissao, conection, transacao)
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

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

        If ValidaRecebimento() Then

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
            _PagamentoComissaoDAO.incPagamentoComissaoFornecedor(_PagamentoComissao, conection, transacao)
            transacao.Commit() : conection.ClearPool() : conection.Close()
            MsgBox("Recebimento Registrado Com Sucesso!", MsgBoxStyle.Exclamation, Application.ProductName)
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

            .DataPagamento = dataRecebimento.Value
            .FornecedorID = _Fornecedor.Id
            .FornecedorNome = _Fornecedor.Nome
            .ValorPago = CDbl(txtValorComissao.Text)
            .Observacao = txtObservacao.Text
        End With
    End Sub

    Sub LimpaCamposFormulario()
        txtObservacao.Text = ""
        txtValorComissao.Text = "0,00"
    End Sub

    Function ValidaRecebimento() As Boolean

        If _Fornecedor.Id < 1 Then
            MsgBox("Informe um Fornecedor!", MsgBoxStyle.Exclamation, Application.ProductName)
            CboFornecedor.Focus()
            CboFornecedor.DroppedDown = True
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

    Private Sub txtTotalComissao_Leave(sender As Object, e As EventArgs) Handles txtValorComissao.Leave

        If IsNumeric(txtValorComissao.Text) Then
            txtValorComissao.Text = CDbl(txtValorComissao.Text).ToString("#,##0.00")
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
        _PagamentoComissaoDAO.CopiaListaPagamentoComissaoFornecedorDeOutraLISTA(_ListaComissoesRelatorio, _ListaComissoes)
        
        If _ListaComissoesRelatorio.Count > 0 Then

            Dim mformRelatorio As New FormListaRecebimentoFornecedor
            mformRelatorio._FiltroFornecedor = _Fornecedor.Nome
            mformRelatorio._FiltroObservacao = txtObservacaoPesquisa.Text
            mformRelatorio._FiltroDtInicial = dtpInicioPago.Text
            mformRelatorio._FiltroDtFinal = dtpFimPago.Text
            mformRelatorio._ListaRecebimentoFornecedor = _ListaComissoesRelatorio
            mformRelatorio.ShowDialog()
            mformRelatorio = Nothing
        Else
            MsgBox("Não foi Encotrados Registros! Pressione F5 e Depois tente novamente", MsgBoxStyle.Exclamation, Application.ProductName)
        End If


    End Sub

    Private Sub tbpComissPaga_Click(sender As Object, e As EventArgs) Handles tbpComissPaga.Click

    End Sub

    Private Sub btnPesquisaEntregues_Click(sender As Object, e As EventArgs) Handles btnPesquisaEntregues.Click
        PesquisaProdutosEntregues()
    End Sub

    Sub PesquisaProdutosEntregues()

        dtgSaidaENTREGUE.Rows.Clear()
        _ListaSaidasEntregues.Clear()
        txtQuantidadeEntregue.Text = "0"
        txtSomaComissFornecedorENTREGUES.Text = "0,00"

        If dtpInicialENTREGA.Text.Equals("") Then Return

        Dim condicao As String = ""

        condicao = "WHERE (data_saida BETWEEN '" & dtpInicialENTREGA.Text & "' AND '" & dtpFinalENTREGA.Text & "') "

        If _FornecedorSaidaEntregue.Id > 0 Then
            condicao += "AND fornecedor_id = " & _FornecedorSaidaEntregue.Id & " "
        End If

        condicao += "AND finalizado = true"


        _SaidaProdutoDAO.TrazListSaidasBD_Condicao(_ListaSaidasEntregues, MdlConexaoBD.conectionPadrao, condicao)


        txtQuantidadeEntregue.Text = _ListaSaidasEntregues.Count
        If _ListaSaidasEntregues.Count < 1 Then Return

        Dim somaComissaoFornecedor As Double = 0
        Dim vValor As Double = 0
        Dim vFornecedor As New Fornecedor
        For Each p As SaidaDeProdutos In _ListaSaidasEntregues

            vValor = _ListaFornecedores.Where(Function(f As Fornecedor) f.Id = p.FornecedorID).Sum(Function(f1 As Fornecedor) f1.ComissaoFornecedor)
            somaComissaoFornecedor += (p.Quantidade * vValor)

            dtgSaidaENTREGUE.Rows.Add(p.Id, p.DataSaida.ToShortDateString, p.ProdutoDescricao, p.Quantidade.ToString("0.00"), p.FornecedorNome)
        Next
        txtSomaComissFornecedorENTREGUES.Text = somaComissaoFornecedor.ToString("#,##0.00")
    End Sub

    Private Sub cboFornecedorPesquisaENTREGUES_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFornecedorPesquisaENTREGUES.SelectedIndexChanged

        _FornecedorSaidaEntregue.ZeraValores()
        If cboFornecedorPesquisaENTREGUES.SelectedIndex > 0 Then
            _FornecedorSaidaEntregue.Nome = cboFornecedorPesquisaENTREGUES.SelectedItem.ToString
            _FornecedorDAO.TrazFornecedorPorNome(_FornecedorSaidaEntregue, MdlConexaoBD.conectionPadrao)
        End If
    End Sub
End Class