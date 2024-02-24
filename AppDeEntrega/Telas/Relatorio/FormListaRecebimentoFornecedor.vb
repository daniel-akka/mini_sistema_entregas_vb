Imports Microsoft.Reporting.WinForms
Public Class FormListaRecebimentoFornecedor

    Public _ListaRecebimentoFornecedor As New List(Of PagamentoComissaoFornecedor)
    Public _FiltroFornecedor As String = ""
    Public _FiltroDtInicial As String = ""
    Public _FiltroDtFinal As String = ""
    Public _FiltroObservacao As String = ""
    Dim _somaValor As Double = 0

    Private Sub FormListaRecebimentoFornecedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaLista()
        Me.rpvListaRecebimentoFornecedor.RefreshReport()
    End Sub

    Sub CarregaLista()

        Me.rpvListaRecebimentoFornecedor.LocalReport.DataSources.Clear()
        SomaValores()

        'Set Paramentros
        Dim mFiltroFornecedor As New ReportParameter("rpFornecedor", _FiltroFornecedor)
        Dim mFiltroDtInicial As New ReportParameter("rpDataInicial", _FiltroDtInicial)
        Dim mFiltroDtFinal As New ReportParameter("rpDataFinal", _FiltroDtFinal)
        Dim mFiltroObservacao As New ReportParameter("rpObservacao", _FiltroObservacao)
        Dim mSoma As New ReportParameter("rpSomaValores", _somaValor.ToString("#,##0.00"))
        Me.rpvListaRecebimentoFornecedor.LocalReport.SetParameters(mFiltroFornecedor)
        Me.rpvListaRecebimentoFornecedor.LocalReport.SetParameters(mFiltroDtInicial)
        Me.rpvListaRecebimentoFornecedor.LocalReport.SetParameters(mFiltroDtFinal)
        Me.rpvListaRecebimentoFornecedor.LocalReport.SetParameters(mFiltroObservacao)
        Me.rpvListaRecebimentoFornecedor.LocalReport.SetParameters(mSoma)

        Me.rpvListaRecebimentoFornecedor.LocalReport.ReportEmbeddedResource = MdlConfiguracoes.appNome & ".RelatorioListaRecebimentoFornecedor.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("DSRecebimentoComissaoFornecedor", _ListaRecebimentoFornecedor)
        Me.rpvListaRecebimentoFornecedor.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaRecebimentoFornecedor
        Me.rpvListaRecebimentoFornecedor.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rpvListaRecebimentoFornecedor.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

    End Sub

    Sub SomaValores()
        _somaValor = 0
        _somaValor = _ListaRecebimentoFornecedor.Sum(Function(l As PagamentoComissaoFornecedor) l.ValorPago)
    End Sub

End Class