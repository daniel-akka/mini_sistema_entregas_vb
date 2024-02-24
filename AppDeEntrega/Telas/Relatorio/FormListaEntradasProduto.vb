Imports Microsoft.Reporting.WinForms
Public Class FormListaEntradasProduto

    Public _ListaEntradaProdutos As New List(Of EntradaDeProdutos)
    Public _FiltroFornecedor As String = ""
    Public _FiltroDtInicial As String = ""
    Public _FiltroDtFinal As String = ""
    Public _FiltroCidade As String = ""
    Public _FiltroDescricao As String = ""
    Public _TotalReceber As String = ""

    Private Sub FormListaEntradasProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregaLista()
        Me.rpvListaEntradaProdutos.RefreshReport()
    End Sub

    Sub CarregaLista()

        Me.rpvListaEntradaProdutos.LocalReport.DataSources.Clear()

        'Set Paramentros
        Dim mFiltroFornecedor As New ReportParameter("rpFornecedor", _FiltroFornecedor)
        Dim mFiltroDtInicial As New ReportParameter("rpDataInicial", _FiltroDtInicial)
        Dim mFiltroDtFinal As New ReportParameter("rpDataFinal", _FiltroDtFinal)
        Dim mFiltroCidade As New ReportParameter("rpCidade", _FiltroCidade)
        Dim mFiltroDescricao As New ReportParameter("rpDescricao", _FiltroDescricao)
        Dim mFiltroTotalEntrada As New ReportParameter("rpTotalEntrada", _TotalReceber)
        Me.rpvListaEntradaProdutos.LocalReport.SetParameters(mFiltroFornecedor)
        Me.rpvListaEntradaProdutos.LocalReport.SetParameters(mFiltroDtInicial)
        Me.rpvListaEntradaProdutos.LocalReport.SetParameters(mFiltroDtFinal)
        Me.rpvListaEntradaProdutos.LocalReport.SetParameters(mFiltroCidade)
        Me.rpvListaEntradaProdutos.LocalReport.SetParameters(mFiltroDescricao)
        Me.rpvListaEntradaProdutos.LocalReport.SetParameters(mFiltroTotalEntrada)

        Me.rpvListaEntradaProdutos.LocalReport.ReportEmbeddedResource = MdlConfiguracoes.appNome & ".RelatorioListaEntradaProdutos.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("DSEntradaProdutos", _ListaEntradaProdutos)
        Me.rpvListaEntradaProdutos.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaEntradaProdutos
        Me.rpvListaEntradaProdutos.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rpvListaEntradaProdutos.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

    End Sub

End Class