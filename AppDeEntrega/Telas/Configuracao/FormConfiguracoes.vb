Public Class FormConfiguracoes

    Private _configuracoes As New Configuracoes
    Private _configuracoesDAO As New ConfiguracaoDAO

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        With _configuracoes

            If rdbFornecedor.Checked Then .TipoPagamentoComissao = "F"
            If rdbEntregador.Checked Then .TipoPagamentoComissao = "E"
            If rdbProduto.Checked Then .TipoPagamentoComissao = "P"
        End With

        _configuracoes.IniciaisDosProdutosTEXT = Me.txtIniciaisProdutos.Text

        _configuracoesDAO.altConfiguracoes(_configuracoes, MdlConexaoBD.conectionPadrao)
        MsgBox("Configurações Salvas com Sucesso!")
        Me.Close()
    End Sub

    Private Sub FormConfiguracoes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _configuracoesDAO.TrazConfiguracoes(_configuracoes, MdlConexaoBD.conectionPadrao)
        preencheCamposFormulario()
    End Sub

    Private Sub FormConfiguracoes_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Sub preencheCamposFormulario()

        Select Case _configuracoes.TipoPagamentoComissao
            Case "F"
                rdbFornecedor.Checked = True
            Case "E"
                rdbEntregador.Checked = True
            Case "P"
                rdbProduto.Checked = True
        End Select

        'Preenche Iniciais:
        txtIniciaisProdutos.Text = _configuracoes.IniciaisDosProdutosTEXT

    End Sub
End Class