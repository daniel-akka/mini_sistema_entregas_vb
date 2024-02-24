Imports System.GC
Imports System.Threading
Imports System.ComponentModel

Public Class FormPrincipal

    Dim _threadsTrazObjetos As Thread

    Private Sub TSMCadEmpresa_Click(sender As Object, e As EventArgs) Handles TSMCadEmpresa.Click

        Dim formulario As New FormCadEmpresa
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Private Sub FormPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Thread Tempo Excedido:
        _threadsTrazObjetos = New Threading.Thread(AddressOf CarregaObjetos)
        _threadsTrazObjetos.Start()
        _threadsTrazObjetos.IsBackground = True

    End Sub

    Sub CarregaObjetos()

        Dim _empresaDAO As New EmpresaDAO
        Dim _produtoDAO As New ProdutoDAO
        Dim _entregadorDAO As New EntregadorDAO
        Dim _fornecedorDAO As New FornecedorDAO
        Dim _GrupoDAO As New ClGrupoDespMensalDAO
        Dim _SubGrupoDAO As New ClSubGrupoDespMensalDAO
        Dim _DespesaMensalDAO As New ClDespesaMensalDAO
        Dim _CondiguracaoDAO As New ConfiguracaoDAO

        MdlConexaoBD.empresaPadrao.SetaEmpresa(_empresaDAO.TrazEmpresa(MdlConexaoBD.conectionPadrao))
        _entregadorDAO.TrazListEntregadores_BD(MdlConexaoBD.ListaEntregadores, MdlConexaoBD.conectionPadrao)
        _fornecedorDAO.TrazListFornecedoresBD(MdlConexaoBD.ListaFornecedores, MdlConexaoBD.conectionPadrao)
        _produtoDAO.TrazListProdutosBD(MdlConexaoBD.ListaProdutos, MdlConexaoBD.conectionPadrao)
        _DespesaMensalDAO.TrazListDespesaMensalDoBanco(MdlConexaoBD.ListaDespesaMensal, MdlConexaoBD.conectionPadrao)
        _GrupoDAO.TrazListGrupoDespMensalDoBANCO(MdlConexaoBD.ListaGrupoDespMensal, MdlConexaoBD.conectionPadrao)
        _SubGrupoDAO.TrazListaSubGrupoDespMensalDoBANCO(MdlConexaoBD.ListaSubGrupoDespMensal, MdlConexaoBD.conectionPadrao)
        _CondiguracaoDAO.TrazConfiguracoes(MdlConfiguracoes.Configuracoes, MdlConexaoBD.conectionPadrao)

    End Sub

    Private Sub FormPrincipal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F1

                ExecutaF1()
            Case Keys.F2
                ExecutaF2()

            Case Keys.F3
                ExecutaF3()

            Case Keys.F6
                ExecutaF6()

        End Select
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        txt_hora.Text = Mid(TimeString, 1, 5)
    End Sub

    Private Sub TSMCadCidade_Click(sender As Object, e As EventArgs) Handles TSMCadCidade.Click

        Dim formulario As New FormCadCidade
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Private Sub TSMCadEntregador_Click(sender As Object, e As EventArgs) Handles TSMCadEntregador.Click

        Dim formulario As New FormCadEntregador
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Private Sub TSMCadValorAdicional_Click(sender As Object, e As EventArgs) Handles TSMCadValorAdicional.Click

        Dim formulario As New FormCadValorAdicional
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Private Sub TSMCadFornecedor_Click(sender As Object, e As EventArgs) Handles TSMCadFornecedor.Click

        Dim formulario As New FormCadFornecedor
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Private Sub TSMCadProduto_Click(sender As Object, e As EventArgs) Handles TSMCadProduto.Click

        Dim formulario As New FormCadProduto
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Private Sub TSMMovEntrada_Click(sender As Object, e As EventArgs) Handles TSMMovEntrada.Click

        ExecutaF1()
    End Sub

    Private Sub TSMMovSaida_Click(sender As Object, e As EventArgs) Handles TSMMovSaida.Click

        ExecutaF2()
    End Sub

    Sub ExecutaF1()

        Dim formulario As New FormEntradaDeProdutos
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Sub ExecutaF2()

        Dim formulario As New FormSaidaDeProdutos
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Sub ExecutaF3()

        Dim formulario As New FormLancamentoDeRota
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Sub ExecutaF6()

        Dim formulario As New FormRelatorioFinanceiro
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Private Sub LancamentoDeRotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LancamentoDeRotaToolStripMenuItem.Click
        ExecutaF3()
    End Sub

    Private Sub TsmMovGrupoDesp_Click(sender As Object, e As EventArgs) Handles TsmMovGrupoDesp.Click

        Dim formulario As New FrmCadGrupoDespMensal
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Private Sub MenuDespesasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuDespesasToolStripMenuItem.Click

        Dim formulario As New FrmMenuDespesaMensal
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Private Sub TsmMovSubGrupoDesp_Click(sender As Object, e As EventArgs) Handles TsmMovSubGrupoDesp.Click

        Dim formulario As New FrmCadSubGrupoDespMensal
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Private Sub TSMMovPagComissao_Click(sender As Object, e As EventArgs) Handles TSMMovPagComissao.Click

        Dim formulario As New FormPagamentoComissao
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Private Sub REcebimentoDoFornecedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REcebimentoDoFornecedorToolStripMenuItem.Click

        Dim formulario As New FormRecebimentoFornecedor
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Private Sub RelatórioDeFluxoDeCaixaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RelatórioDeFluxoDeCaixaToolStripMenuItem.Click

        Dim formulario As New FormRelatorioFinanceiro
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Private Sub TSMConfiguracao_Click(sender As Object, e As EventArgs) Handles TSMConfiguracao.Click


        Dim formulario As New FormConfiguracoes
        formulario.ShowDialog()
        formulario = Nothing
    End Sub

    Private Sub TSMSincroniza_Click(sender As Object, e As EventArgs) Handles TSMSincroniza.Click

        Dim Backup As New Backup
        Backup.fazerBackup()
    End Sub

    Private Sub FormPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim Backup As New Backup
        Backup.fazerBackupBackGround()
        ''System.Threading.Thread.Sleep(2000)

    End Sub
End Class
