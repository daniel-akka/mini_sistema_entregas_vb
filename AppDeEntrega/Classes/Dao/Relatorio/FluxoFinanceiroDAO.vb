Imports Npgsql
Public Class FluxoFinanceiroDAO

    Public Sub criarRelatorioFluxoFinanceiro_PorData(ByRef vListaRelatorio As List(Of RelatorioFluxoFinanceiro), ByVal vDataInicial As String, _
                                                     ByVal vDataFinal As String, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vRelatorio As New RelatorioFluxoFinanceiro
        Dim vSomaEntradas As Double = 0
        Dim vSomaSaidas As Double = 0
        Dim vSomaDespesas As Double = 0

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FluxoFinanceiroDAO:criarRelatorioFluxoFinanceiro_WHERE"":: " & ex.Message)
            Return
        End Try

        vListaRelatorio.Clear()

        '1) Monta primeiro Relatório das Entradas:
        vRelatorio.zeraValores()
        consulta = "SELECT data_pagamento, fornecedor_nome, observacao, valor_pago FROM comissao_fornecedor "
        consulta += "WHERE data_pagamento BETWEEN '" & vDataInicial & "' AND '" & vDataFinal & "'"

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        If dr.HasRows Then
            vRelatorio.Texto2 = "ENTRADA - Recebimento Fornecedor:"
            vListaRelatorio.Add(New RelatorioFluxoFinanceiro(vRelatorio))
            vRelatorio.zeraValores()
        End If

        While dr.Read

            With vRelatorio

                .Texto1 = "E"
                If IsDate(dr(0)) Then .Texto2 = CDate(dr(0)).ToShortDateString
                .Texto3 = dr(1).ToString
                .Texto4 = dr(2).ToString
                .Valor1 = dr(3)
                .Texto5 = .Valor1.ToString("#,##0.00")
            End With

            vListaRelatorio.Add(New RelatorioFluxoFinanceiro(vRelatorio))
            vSomaEntradas += vRelatorio.Valor1
            vRelatorio.zeraValores()
        End While
        dr.Close()
        If vSomaEntradas > 0 Then
            vRelatorio.zeraValores()
            vRelatorio.Texto2 = "TOTAL:"
            vRelatorio.Texto5 = vSomaEntradas.ToString("#,##0.00")
            vRelatorio.Valor1 = vSomaEntradas
            vListaRelatorio.Add(New RelatorioFluxoFinanceiro(vRelatorio))
        End If


        '2) Monta Relatório das Saídas:
        vRelatorio.zeraValores()
        consulta = "SELECT data_pagamento, entregador_nome, observacao, valor_pago FROM pagamento_comissao "
        consulta += "WHERE data_pagamento BETWEEN '" & vDataInicial & "' AND '" & vDataFinal & "'"

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        If dr.HasRows Then


            vRelatorio.Texto2 = "SAÍDA - Pagamento Entregador:"
            vListaRelatorio.Add(New RelatorioFluxoFinanceiro(vRelatorio))
            vRelatorio.zeraValores()
        End If

        While dr.Read

            With vRelatorio

                .Texto1 = "S"
                If IsDate(dr(0)) Then .Texto2 = CDate(dr(0)).ToShortDateString
                .Texto3 = dr(1).ToString
                .Texto4 = dr(2).ToString
                .Valor1 = dr(3)
                .Texto5 = .Valor1.ToString("#,##0.00")
            End With

            vListaRelatorio.Add(New RelatorioFluxoFinanceiro(vRelatorio))
            vSomaSaidas += vRelatorio.Valor1
            vRelatorio.zeraValores()
        End While
        dr.Close()
        If vSomaSaidas > 0 Then
            vRelatorio.zeraValores()
            vRelatorio.Texto2 = "TOTAL:"
            vRelatorio.Texto5 = vSomaSaidas.ToString("#,##0.00")
            vRelatorio.Valor1 = vSomaSaidas
            vListaRelatorio.Add(New RelatorioFluxoFinanceiro(vRelatorio))
        End If


        '3) Monta Relatório das Saídas - Despesas:
        vRelatorio.zeraValores()
        consulta = "SELECT dm_data_despesa, dm_gpdescricao, dm_sgpdescricao, dm_valor "
        consulta += "FROM despesa_mensal "
        consulta += "WHERE dm_data_despesa BETWEEN '" & vDataInicial & "' AND '" & vDataFinal & "'"

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        If dr.HasRows Then

            vRelatorio.Texto2 = "SAÍDA - Despesas:"
            vListaRelatorio.Add(New RelatorioFluxoFinanceiro(vRelatorio))
            vRelatorio.zeraValores()
        End If
        While dr.Read

            With vRelatorio

                .Texto1 = "D"
                If IsDate(dr(0)) Then .Texto2 = CDate(dr(0)).ToShortDateString
                .Texto3 = dr(1).ToString
                .Texto4 = dr(2).ToString
                .Valor1 = dr(3)
                .Texto5 = .Valor1.ToString("#,##0.00")
            End With

            vListaRelatorio.Add(New RelatorioFluxoFinanceiro(vRelatorio))
            vSomaDespesas += vRelatorio.Valor1
            vRelatorio.zeraValores()
        End While
        dr.Close()
        If vSomaDespesas > 0 Then
            vRelatorio.zeraValores()
            vRelatorio.Texto2 = "TOTAL:"
            vRelatorio.Texto5 = vSomaDespesas.ToString("#,##0.00")
            vRelatorio.Valor1 = vSomaDespesas
            vListaRelatorio.Add(New RelatorioFluxoFinanceiro(vRelatorio))
        End If


        If (vSomaSaidas > 0) Or (vSomaDespesas > 0) Then
            vRelatorio.zeraValores()
            vRelatorio.Texto2 = "TOTAL SAIDAS + DESPESAS:"
            vRelatorio.Texto5 = (vSomaSaidas + vSomaDespesas).ToString("#,##0.00")
            vRelatorio.Valor1 = vSomaSaidas + vSomaDespesas
            vListaRelatorio.Add(New RelatorioFluxoFinanceiro(vRelatorio))
        End If


        If (vSomaEntradas > 0) Or (vSomaSaidas > 0) Or (vSomaDespesas > 0) Then

            vRelatorio.zeraValores()
            vListaRelatorio.Add(New RelatorioFluxoFinanceiro(vRelatorio))
            vListaRelatorio.Add(New RelatorioFluxoFinanceiro(vRelatorio))
            vRelatorio.Texto2 = "SALDO FINAL:"
            vRelatorio.Texto5 = (vSomaEntradas - (vSomaDespesas + vSomaSaidas)).ToString("#,##0.00")
            vRelatorio.Valor1 = vSomaEntradas - (vSomaDespesas + vSomaSaidas)
            vListaRelatorio.Add(New RelatorioFluxoFinanceiro(vRelatorio))

        End If
        

        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

End Class
