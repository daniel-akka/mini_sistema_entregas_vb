Imports Microsoft.Reporting.WinForms
Public Class FormListaRotas

    Public _ListaRotas As New List(Of Rota)
    Public _FiltroFornecedor As String = ""
    Public _FiltroDtInicial As String = ""
    Public _FiltroDtFinal As String = ""

    Private Sub FormListaRotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregaLista()
        Me.rpvListaRotas.RefreshReport()
    End Sub

    Sub CarregaLista()

        Me.rpvListaRotas.LocalReport.DataSources.Clear()

        'Set Paramentros
        Dim mFiltroFornecedor As New ReportParameter("rpFornecedor", _FiltroFornecedor)
        Dim mFiltroDtInicial As New ReportParameter("rpDataInicial", _FiltroDtInicial)
        Dim mFiltroDtFinal As New ReportParameter("rpDataFinal", _FiltroDtFinal)
        Me.rpvListaRotas.LocalReport.SetParameters(mFiltroFornecedor)
        Me.rpvListaRotas.LocalReport.SetParameters(mFiltroDtInicial)
        Me.rpvListaRotas.LocalReport.SetParameters(mFiltroDtFinal)

        Me.rpvListaRotas.LocalReport.ReportEmbeddedResource = MdlConfiguracoes.appNome & ".RelatorioListaRotas.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("DSListaRotas", _ListaRotas)
        Me.rpvListaRotas.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaRotas
        Me.rpvListaRotas.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rpvListaRotas.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

    End Sub

End Class