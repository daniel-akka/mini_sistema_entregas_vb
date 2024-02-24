Imports Microsoft.Reporting.WinForms
Public Class ImpressaoRelatorioFinanceiro

    Public _RealtorioFinaceiro As New List(Of RelatorioFluxoFinanceiro)
    Public _FiltroDtInicial As String = ""
    Public _FiltroDtFinal As String = ""

    Private Sub ImpressaoRelatorioFinanceiro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregaLista()
        Me.rpvRelatorioFinanceiro.RefreshReport()
    End Sub

    Sub CarregaLista()

        Me.rpvRelatorioFinanceiro.LocalReport.DataSources.Clear()

        'Set Paramentros
        Dim mFiltroDtInicial As New ReportParameter("rpDataInicial", _FiltroDtInicial)
        Dim mFiltroDtFinal As New ReportParameter("rpDataFinal", _FiltroDtFinal)
        Me.rpvRelatorioFinanceiro.LocalReport.SetParameters(mFiltroDtInicial)
        Me.rpvRelatorioFinanceiro.LocalReport.SetParameters(mFiltroDtFinal)

        Me.rpvRelatorioFinanceiro.LocalReport.ReportEmbeddedResource = MdlConfiguracoes.appNome & ".RelatorioFinanceiro.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("DSRelatorioFinanceiro", _RealtorioFinaceiro)
        Me.rpvRelatorioFinanceiro.LocalReport.DataSources.Add(ds)
        ds.Value = _RealtorioFinaceiro
        Me.rpvRelatorioFinanceiro.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rpvRelatorioFinanceiro.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

    End Sub

End Class