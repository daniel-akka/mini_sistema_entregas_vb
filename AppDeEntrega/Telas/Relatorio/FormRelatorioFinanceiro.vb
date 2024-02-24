Imports Npgsql
Public Class FormRelatorioFinanceiro

    Private _FluxoFinanceiro As New RelatorioFluxoFinanceiro
    Private _Relatorio As New List(Of RelatorioFluxoFinanceiro)
    Private _FluxoFinanceiroDAO As New FluxoFinanceiroDAO

    Dim _SomaEntradas As Double = 0
    Dim _SomaSaidas As Double = 0
    Dim _SaldoFinal As Double = 0

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ExecutaF5()
    End Sub

    Sub ExecutaF5()

        dtgRelatorioFinanceiro.Rows.Clear()
        _Relatorio.Clear()
        If Trim(dtpDataFinal.Text).Equals("") Then Return

        _FluxoFinanceiroDAO.criarRelatorioFluxoFinanceiro_PorData(_Relatorio, dtpDataInicial.Text, dtpDataFinal.Text, MdlConexaoBD.conectionPadrao)

        zeraValores()
        If _Relatorio.Count < 1 Then Return
        For Each r As RelatorioFluxoFinanceiro In _Relatorio


            If r.Texto3.Equals("") AndAlso (r.Valor1 = 0) Then
                dtgRelatorioFinanceiro.Rows.Add(r.Texto2, "", "", "")
                Continue For
            End If

            dtgRelatorioFinanceiro.Rows.Add(r.Texto2, r.Texto3, r.Texto4, r.Valor1.ToString("#,##0.00"))
            Select Case r.Texto1
                Case "E"
                    _SomaEntradas += r.Valor1
                Case "S", "D"
                    _SomaSaidas += r.Valor1
            End Select

        Next

        _SaldoFinal = (_SomaEntradas - _SomaSaidas)
        txtSaldoFinal.Text = _SaldoFinal.ToString("#,##0.00")
        txtTotalEntradas.Text = _SomaEntradas.ToString("#,##0.00")
        txtTotalSaídas.Text = _SomaSaidas.ToString("#,##0.00")

    End Sub

    Sub zeraValores()
        txtTotalEntradas.Text = "0,00"
        txtTotalSaídas.Text = "0,00"
        txtSaldoFinal.Text = "0,00"
        _SomaEntradas = 0
        _SomaSaidas = 0
        _SaldoFinal = 0
    End Sub

    Private Sub FormRelatorioFinanceiro_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                ExecutaF5()
            Case Keys.F11
                ExecutaF11()
        End Select
    End Sub

    Sub ExecutaF11()

        If _Relatorio.Count > 0 Then

            Dim mformRelatorio As New ImpressaoRelatorioFinanceiro
            mformRelatorio._FiltroDtInicial = dtpDataInicial.Text
            mformRelatorio._FiltroDtFinal = dtpDataFinal.Text
            mformRelatorio._RealtorioFinaceiro = _Relatorio
            mformRelatorio.ShowDialog()
            mformRelatorio = Nothing
        Else
            MsgBox("Não foi Encotrados Registros! Pressione F5 e Depois tente novamente")
        End If

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ExecutaF11()
    End Sub
End Class