Imports Microsoft.Reporting.WinForms
Public Class FormListaComissaoEntregador

    Public _ListaComissaoEntregador As New List(Of PagamentoComissao)
    Public _FiltroEntregador As String = ""
    Public _FiltroDtInicial As String = ""
    Public _FiltroDtFinal As String = ""
    Public _FiltroObservacao As String = ""
    Public _FiltroFornecedor As String = ""
    Dim _somaValor As Double = 0

    Private Sub FormListaComissaoEntregador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaLista()
        Me.rpvListaComissoesEntregador.RefreshReport()
    End Sub

    Sub CarregaLista()

        Me.rpvListaComissoesEntregador.LocalReport.DataSources.Clear()
        SomaValores()

        'Set Paramentros
        Dim mFiltroEntregador As New ReportParameter("rpEntregador", _FiltroEntregador)
        Dim mFiltroDtInicial As New ReportParameter("rpDataInicial", _FiltroDtInicial)
        Dim mFiltroDtFinal As New ReportParameter("rpDataFinal", _FiltroDtFinal)
        Dim mFiltroObservacao As New ReportParameter("rpObservacao", _FiltroObservacao)
        Dim mFiltroFornecedor As New ReportParameter("rpFornecedor", _FiltroFornecedor)
        Dim mSoma As New ReportParameter("rpSomaValores", _somaValor.ToString("#,##0.00"))
        Me.rpvListaComissoesEntregador.LocalReport.SetParameters(mFiltroEntregador)
        Me.rpvListaComissoesEntregador.LocalReport.SetParameters(mFiltroDtInicial)
        Me.rpvListaComissoesEntregador.LocalReport.SetParameters(mFiltroDtFinal)
        Me.rpvListaComissoesEntregador.LocalReport.SetParameters(mFiltroObservacao)
        Me.rpvListaComissoesEntregador.LocalReport.SetParameters(mFiltroFornecedor)
        Me.rpvListaComissoesEntregador.LocalReport.SetParameters(mSoma)

        Me.rpvListaComissoesEntregador.LocalReport.ReportEmbeddedResource = MdlConfiguracoes.appNome & ".RelatorioListaComissoesEntregador.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("DSComissoesEntregador", _ListaComissaoEntregador)
        Me.rpvListaComissoesEntregador.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaComissaoEntregador
        Me.rpvListaComissoesEntregador.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rpvListaComissoesEntregador.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

    End Sub

    Sub SomaValores()
        _somaValor = 0
        _somaValor = _ListaComissaoEntregador.Sum(Function(l As PagamentoComissao) l.ValorPago)
    End Sub

End Class