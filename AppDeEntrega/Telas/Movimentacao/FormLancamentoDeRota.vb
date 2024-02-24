Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql
Public Class FormLancamentoDeRota

    'Objetos:
    Private _Rota As New Rota
    Private _Fornecedor As New Fornecedor
    Private _FornecedorPesquisa As New Fornecedor
    Private _ListaRotas As New List(Of Rota)
    Private _ListaRotasRelatorio As New List(Of Rota)
    Private _DescricaoRotaDAO As New DescricaoRotaDAO
    Private _DescricaoRota As New DescricaoRota

    'Persistencia:
    Private _RotaDAO As New RotaDAO
    Private _FornecedorDAO As New FornecedorDAO


    'Controle:
    Dim _Operacao As String = "I"
    Dim _funcao As New ClFuncoes

    Private Sub FormLancamentoDeRota_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InicializaCamposFormulario()
        limpaCamposFormularioRota()
        ExecutaF5()
        txtDescricaoRota.Focus()
    End Sub

    Sub ExecutaF5()

        dtgRotas.Rows.Clear()
        _ListaRotas.Clear()
        Dim condicao As String = ""
        condicao = "WHERE (data_rota BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "') "

        If _FornecedorPesquisa.Id > 0 Then
            condicao += "AND fornecedor_id = " & _FornecedorPesquisa.Id & " "
        End If


        _RotaDAO.TrazListRotasBD_WHERE(_ListaRotas, MdlConexaoBD.conectionPadrao, condicao)

        If _ListaRotas.Count < 1 Then Return
        For Each p As Rota In _ListaRotas
            dtgRotas.Rows.Add(p.Id, p.DataRota.ToShortDateString, p.Descricao, p.QuantidadeKM.ToString("0.00"), p.TotalComissao.ToString("0.00"), p.FornecedorNome)
        Next

        txtQuantidadeRegistros.Text = dtgRotas.Rows.Count
        txtSomaKmRotas.Text = SomaValoresKmRodadoRotas.ToString("0.00")
        txtSomaTotaisRota.Text = SomaValoresTotalRotas.ToString("0.00")
    End Sub

    Sub InicializaCamposFormulario()

        _FornecedorDAO.PreencheCboFornecedoresPesquisa(Me.CboPesquisaFornecedor, MdlConexaoBD.conectionPadrao)
        _FornecedorDAO.PreencheCboFornecedoresSoNomeBD(Me.cboFornecedorRota, MdlConexaoBD.conectionPadrao)
        _DescricaoRotaDAO.PreencheCboDescricaoRotasBD(Me.txtDescricaoRota, MdlConexaoBD.conectionPadrao)

        If CboPesquisaFornecedor.Items.Count = 1 Then
            CboPesquisaFornecedor.SelectedIndex = 0
        ElseIf CboPesquisaFornecedor.Items.Count = 2 Then
            CboPesquisaFornecedor.SelectedIndex = 1
        End If

        cboFornecedorRota.SelectedIndex = -1

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ExecutaF5()
    End Sub

    Private Sub FormLancamentoDeRota_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                ExecutaF5()

            Case Keys.F11
                executaF11()
        End Select
    End Sub

    Sub limpaCamposFormularioRota()

        txtIdRota.Text = "0"
        txtDescricaoRota.Text = ""
        cboFornecedorRota.SelectedIndex = -1
        txtValorPorKM.Text = "0,00"
        txtKMRodado.Text = "0,00"
        txtTotalComissao.Text = "0,00"
        txtDescricaoRota.Focus()

    End Sub

    Private Sub cboFornecedorRota_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFornecedorRota.SelectedIndexChanged

        _Fornecedor.ZeraValores()
        If cboFornecedorRota.SelectedIndex > -1 Then

            _Fornecedor.Nome = cboFornecedorRota.SelectedItem.ToString
            _FornecedorDAO.TrazFornecedorPorNome(_Fornecedor, MdlConexaoBD.conectionPadrao)
            txtValorPorKM.Text = _Fornecedor.ValorKM.ToString("0.00")
        End If
    End Sub

    Private Sub CboPesquisaFornecedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPesquisaFornecedor.SelectedIndexChanged

        _FornecedorPesquisa.ZeraValores()
        If CboPesquisaFornecedor.SelectedIndex > 0 Then

            _FornecedorPesquisa.Nome = CboPesquisaFornecedor.SelectedItem.ToString
            _FornecedorDAO.TrazFornecedorPorNome(_FornecedorPesquisa, MdlConexaoBD.conectionPadrao)
        End If
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        SalvandoROTA()
    End Sub

    Sub SalvandoROTA()

        If validaRota() = False Then
            Return
        End If

        PreencheValoresRota()

        _Operacao = "I"
        If CInt(txtIdRota.Text) > 0 Then _Operacao = "A"

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
            _DescricaoRota.descricao = txtDescricaoRota.Text
            _DescricaoRotaDAO.incDescricaoRota(_DescricaoRota, MdlConexaoBD.conectionPadrao)

            If _Operacao.Equals("I") Then
                _RotaDAO.incRota(_Rota, conection, transacao)
            Else
                _RotaDAO.altRota(_Rota, conection, transacao)
            End If
            MsgBox("Rota foi Salva com Sucesso!", MsgBoxStyle.Exclamation, Application.ProductName)
            limpaCamposFormularioRota()
            transacao.Commit() : conection.ClearPool() : conection.Close()
            ExecutaF5()
            txtDescricaoRota.Focus()
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

    Function validaRota() As Boolean

        If Trim(txtDescricaoRota.Text.Equals("")) Then
            MsgBox("Informe uma Descrição para a Rota!", MsgBoxStyle.Exclamation, Application.ProductName)
            txtDescricaoRota.Focus()
            txtDescricaoRota.SelectAll()
            Return False
        End If

        If cboFornecedorRota.SelectedIndex < 0 Then

            MsgBox("Informe um Fornecedor para a Rota!", MsgBoxStyle.Exclamation, Application.ProductName)
            cboFornecedorRota.Focus()
            cboFornecedorRota.DroppedDown = True
            Return False
        End If

        If CDbl(txtValorPorKM.Text) <= 0 Then

            MsgBox("Informe uma Comissão por KM Rodado!", MsgBoxStyle.Exclamation, Application.ProductName)
            txtValorPorKM.Focus()
            txtValorPorKM.SelectAll()
            Return False
        End If

        If CDbl(txtKMRodado.Text) <= 0 Then

            MsgBox("Informe a Quantidade de Quilômetros KM Rodado!", MsgBoxStyle.Exclamation, Application.ProductName)
            txtKMRodado.Focus()
            txtKMRodado.SelectAll()
            Return False
        End If

        Return True
    End Function

    Private Sub txtComissaoPorKM_Leave(sender As Object, e As EventArgs) Handles txtValorPorKM.Leave

        If IsNumeric(txtValorPorKM.Text) Then

            txtValorPorKM.Text = CDbl(txtValorPorKM.Text).ToString("0.00")
            If (CDbl(txtValorPorKM.Text) > 0) And (CDbl(txtKMRodado.Text) > 0) Then

                txtTotalComissao.Text = (CDbl(txtKMRodado.Text) * CDbl(txtValorPorKM.Text)).ToString("0.00")
            End If
        Else
            txtValorPorKM.Text = "0,00"
        End If
    End Sub

    Private Sub txtKMRodado_Leave(sender As Object, e As EventArgs) Handles txtKMRodado.Leave

        If IsNumeric(txtKMRodado.Text) Then

            txtKMRodado.Text = CDbl(txtKMRodado.Text).ToString("0.00")
            If (CDbl(txtValorPorKM.Text) > 0) And (CDbl(txtKMRodado.Text) > 0) Then

                txtTotalComissao.Text = (CDbl(txtKMRodado.Text) * CDbl(txtValorPorKM.Text)).ToString("0.00")
            End If
        Else
            txtKMRodado.Text = "0,00"
        End If
    End Sub

    Sub PreencheValoresRota()

        With _Rota

            .Id = CInt(txtIdRota.Text)
            .Descricao = txtDescricaoRota.Text
            .DataRota = dataDaRota.Value
            .FornecedorId = _Fornecedor.Id
            .FornecedorNome = _Fornecedor.Nome
            .QuantidadeKM = CDbl(txtKMRodado.Text)
            .TotalComissao = CDbl(txtTotalComissao.Text)
            .ValorKM = CDbl(txtValorPorKM.Text)
        End With
    End Sub

    Sub PreencheCamposRotasFormulario()

        With Me

            .txtIdRota.Text = _Rota.Id
            .dataDaRota.Value = _Rota.DataRota
            .txtDescricaoRota.Text = _Rota.Descricao
            .cboFornecedorRota.SelectedIndex = _funcao.trazIndexCboTextoTodo(_Rota.FornecedorNome, .cboFornecedorRota)
            .txtValorPorKM.Text = _Rota.ValorKM.ToString("0.00")
            .txtKMRodado.Text = _Rota.QuantidadeKM.ToString("0.00")
            .txtTotalComissao.Text = _Rota.TotalComissao.ToString("0.00")
        End With
    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click

        If Not dtgRotas.CurrentRow.IsNewRow Then

            _Rota.Id = dtgRotas.CurrentRow.Cells(0).Value
            _RotaDAO.TrazRotaPorID(_Rota, MdlConexaoBD.conectionPadrao)
            PreencheCamposRotasFormulario()
            txtDescricaoRota.Focus()
        Else
            MsgBox("Selecione um Registro para Alterar!", MsgBoxStyle.Exclamation, Application.ProductName)
        End If
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click

        If Not dtgRotas.CurrentRow.IsNewRow Then

            _Rota.Id = dtgRotas.CurrentRow.Cells(0).Value
            _RotaDAO.TrazRotaPorID(_Rota, MdlConexaoBD.conectionPadrao)
            DeleteRota()
        Else
            MsgBox("Selecione um Registro para Excluir!", MsgBoxStyle.Exclamation, Application.ProductName)
        End If
    End Sub

    Sub DeleteRota()

        If MessageBox.Show("Deseja Realmente Deletar essa Rota?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
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
                _RotaDAO.delRota(_Rota, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                MsgBox("Rota Deletada com Sucesso!", MsgBoxStyle.Exclamation, Application.ProductName)
                limpaCamposFormularioRota()
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
    End Sub

    Private Sub txtValorPorKM_Click(sender As Object, e As EventArgs) Handles txtValorPorKM.GotFocus
        txtValorPorKM.SelectAll()
    End Sub

    Private Sub txtKMRodado_Click(sender As Object, e As EventArgs) Handles txtKMRodado.GotFocus
        txtKMRodado.SelectAll()
    End Sub

    Private Sub FormLancamentoDeRota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Function SomaValoresTotalRotas() As Double
        Dim vSoma As Double = 0.0

        For Each row As DataGridViewRow In dtgRotas.Rows

            If Not row.IsNewRow Then
                vSoma += row.Cells(4).Value
            End If
        Next

        Return vSoma
    End Function

    Function SomaValoresKmRodadoRotas() As Double
        Dim vSoma As Double = 0.0

        For Each row As DataGridViewRow In dtgRotas.Rows

            If Not row.IsNewRow Then
                vSoma += row.Cells(3).Value
            End If
        Next

        Return vSoma
    End Function

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        executaF11()
    End Sub

    Sub executaF11()

        _ListaRotasRelatorio.Clear()
        _RotaDAO.CopiaListaRotaDeOutraLISTA(_ListaRotasRelatorio, _ListaRotas)

        If _ListaRotasRelatorio.Count > 0 Then

            Dim mformRelatorio As New FormListaRotas
            mformRelatorio._FiltroFornecedor = _Fornecedor.Nome
            mformRelatorio._FiltroDtInicial = dtpInicio.Text
            mformRelatorio._FiltroDtFinal = dtpFim.Text
            mformRelatorio._ListaRotas = _ListaRotasRelatorio
            mformRelatorio.ShowDialog()
            mformRelatorio = Nothing
        Else
            MsgBox("Não foi Encotrados Registros! Pressione F5 e Depois tente novamente", MsgBoxStyle.Exclamation, Application.ProductName)
        End If


    End Sub

End Class