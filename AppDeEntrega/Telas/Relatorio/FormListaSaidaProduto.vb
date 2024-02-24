Imports Microsoft.Reporting.WinForms
Public Class FormListaSaidaProduto

    Public _ListaSaidaProdutos As New List(Of SaidaDeProdutos)
    Public _FiltroFornecedor As String = ""
    Public _FiltroDtInicial As String = ""
    Public _FiltroDtFinal As String = ""
    Public _TipoDatas As String = ""
    Public _FiltroCidade As String = ""
    Public _FiltroEntregador As String = ""
    Public _FiltroDescricao As String = ""

    Private Sub FormListaSaidaProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregaLista()
        Me.rpvListaSaidaProduto.RefreshReport()
    End Sub

    Sub CarregaLista()

        Me.rpvListaSaidaProduto.LocalReport.DataSources.Clear()

        'Set Paramentros
        Dim mFiltroFornecedor As New ReportParameter("rpFornecedor", _FiltroFornecedor)
        Dim mFiltroDtInicial As New ReportParameter("rpDataInicial", _FiltroDtInicial)
        Dim mFiltroDtFinal As New ReportParameter("rpDataFinal", _FiltroDtFinal)
        Dim mFiltroEntregador As New ReportParameter("rpEntregador", _FiltroEntregador)
        Dim mFiltroCidade As New ReportParameter("rpCidade", _FiltroCidade)
        Dim mFiltroDescricao As New ReportParameter("rpDescricao", _FiltroDescricao)
        Dim mFiltroTipoData As New ReportParameter("rpTipoData", _TipoDatas)
        Me.rpvListaSaidaProduto.LocalReport.SetParameters(mFiltroFornecedor)
        Me.rpvListaSaidaProduto.LocalReport.SetParameters(mFiltroDtInicial)
        Me.rpvListaSaidaProduto.LocalReport.SetParameters(mFiltroDtFinal)
        Me.rpvListaSaidaProduto.LocalReport.SetParameters(mFiltroEntregador)
        Me.rpvListaSaidaProduto.LocalReport.SetParameters(mFiltroCidade)
        Me.rpvListaSaidaProduto.LocalReport.SetParameters(mFiltroDescricao)
        Me.rpvListaSaidaProduto.LocalReport.SetParameters(mFiltroTipoData)

        Me.rpvListaSaidaProduto.LocalReport.ReportEmbeddedResource = MdlConfiguracoes.appNome & ".RelatorioListaSaidaProduto.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("DSSaidaProdutos", _ListaSaidaProdutos)
        Me.rpvListaSaidaProduto.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaSaidaProdutos
        Me.rpvListaSaidaProduto.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rpvListaSaidaProduto.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

    End Sub

End Class