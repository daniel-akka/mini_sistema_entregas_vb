<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuS = New System.Windows.Forms.MenuStrip()
        Me.CadastrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMCadEntregador = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMCadProduto = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMCadFornecedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMCadValorAdicional = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMCadCidade = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMCadEmpresa = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMMovimentacao = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMMovEntrada = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMMovSaida = New System.Windows.Forms.ToolStripMenuItem()
        Me.LancamentoDeRotaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMMovOutraDespesa = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuDespesasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmMovGrupoDesp = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmMovSubGrupoDesp = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMMovPagComissao = New System.Windows.Forms.ToolStripMenuItem()
        Me.REcebimentoDoFornecedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMRelatVendaServico = New System.Windows.Forms.ToolStripMenuItem()
        Me.RelatórioDeFluxoDeCaixaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMConfiguracao = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMSincroniza = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsp_atalhos = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.painelPrincipal = New System.Windows.Forms.Panel()
        Me.txt_hora = New System.Windows.Forms.TextBox()
        Me.HistoricoDeMovimentacaoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuS.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.painelPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuS
        '
        Me.MenuS.BackColor = System.Drawing.SystemColors.Info
        Me.MenuS.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.MenuS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastrosToolStripMenuItem, Me.TSMMovimentacao, Me.TSMRelatVendaServico, Me.TSMConfiguracao, Me.TSMSincroniza})
        Me.MenuS.Location = New System.Drawing.Point(0, 0)
        Me.MenuS.Name = "MenuS"
        Me.MenuS.Size = New System.Drawing.Size(956, 33)
        Me.MenuS.TabIndex = 25
        Me.MenuS.Text = "Menu"
        '
        'CadastrosToolStripMenuItem
        '
        Me.CadastrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMCadEntregador, Me.TSMCadProduto, Me.TSMCadFornecedor, Me.TSMCadValorAdicional, Me.TSMCadCidade, Me.ToolStripSeparator1, Me.TSMCadEmpresa})
        Me.CadastrosToolStripMenuItem.Name = "CadastrosToolStripMenuItem"
        Me.CadastrosToolStripMenuItem.Size = New System.Drawing.Size(103, 29)
        Me.CadastrosToolStripMenuItem.Text = "Cadastros"
        '
        'TSMCadEntregador
        '
        Me.TSMCadEntregador.Name = "TSMCadEntregador"
        Me.TSMCadEntregador.Size = New System.Drawing.Size(202, 30)
        Me.TSMCadEntregador.Text = "&Entregador"
        '
        'TSMCadProduto
        '
        Me.TSMCadProduto.Name = "TSMCadProduto"
        Me.TSMCadProduto.Size = New System.Drawing.Size(202, 30)
        Me.TSMCadProduto.Text = "&Produtos"
        '
        'TSMCadFornecedor
        '
        Me.TSMCadFornecedor.Name = "TSMCadFornecedor"
        Me.TSMCadFornecedor.Size = New System.Drawing.Size(202, 30)
        Me.TSMCadFornecedor.Text = "&Fornecedores"
        '
        'TSMCadValorAdicional
        '
        Me.TSMCadValorAdicional.Name = "TSMCadValorAdicional"
        Me.TSMCadValorAdicional.Size = New System.Drawing.Size(202, 30)
        Me.TSMCadValorAdicional.Text = "&Valor Adicional"
        '
        'TSMCadCidade
        '
        Me.TSMCadCidade.Name = "TSMCadCidade"
        Me.TSMCadCidade.Size = New System.Drawing.Size(202, 30)
        Me.TSMCadCidade.Text = "&Cidades"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(199, 6)
        '
        'TSMCadEmpresa
        '
        Me.TSMCadEmpresa.Name = "TSMCadEmpresa"
        Me.TSMCadEmpresa.Size = New System.Drawing.Size(202, 30)
        Me.TSMCadEmpresa.Text = "&Empresa"
        '
        'TSMMovimentacao
        '
        Me.TSMMovimentacao.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMMovEntrada, Me.TSMMovSaida, Me.LancamentoDeRotaToolStripMenuItem, Me.TSMMovOutraDespesa, Me.TSMMovPagComissao, Me.REcebimentoDoFornecedorToolStripMenuItem, Me.HistoricoDeMovimentacaoToolStripMenuItem})
        Me.TSMMovimentacao.Name = "TSMMovimentacao"
        Me.TSMMovimentacao.Size = New System.Drawing.Size(142, 29)
        Me.TSMMovimentacao.Text = "Movimentação"
        '
        'TSMMovEntrada
        '
        Me.TSMMovEntrada.Name = "TSMMovEntrada"
        Me.TSMMovEntrada.Size = New System.Drawing.Size(309, 30)
        Me.TSMMovEntrada.Text = "&Entrada de Produtos"
        '
        'TSMMovSaida
        '
        Me.TSMMovSaida.Name = "TSMMovSaida"
        Me.TSMMovSaida.Size = New System.Drawing.Size(309, 30)
        Me.TSMMovSaida.Text = "&Saida de Produtos"
        '
        'LancamentoDeRotaToolStripMenuItem
        '
        Me.LancamentoDeRotaToolStripMenuItem.Name = "LancamentoDeRotaToolStripMenuItem"
        Me.LancamentoDeRotaToolStripMenuItem.Size = New System.Drawing.Size(309, 30)
        Me.LancamentoDeRotaToolStripMenuItem.Text = "&Lancamento de Rota"
        '
        'TSMMovOutraDespesa
        '
        Me.TSMMovOutraDespesa.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuDespesasToolStripMenuItem, Me.TsmMovGrupoDesp, Me.TsmMovSubGrupoDesp})
        Me.TSMMovOutraDespesa.Name = "TSMMovOutraDespesa"
        Me.TSMMovOutraDespesa.Size = New System.Drawing.Size(309, 30)
        Me.TSMMovOutraDespesa.Text = "&Outras Despesas"
        '
        'MenuDespesasToolStripMenuItem
        '
        Me.MenuDespesasToolStripMenuItem.Name = "MenuDespesasToolStripMenuItem"
        Me.MenuDespesasToolStripMenuItem.Size = New System.Drawing.Size(279, 30)
        Me.MenuDespesasToolStripMenuItem.Text = "&Menu Despesa Mensal"
        '
        'TsmMovGrupoDesp
        '
        Me.TsmMovGrupoDesp.Name = "TsmMovGrupoDesp"
        Me.TsmMovGrupoDesp.Size = New System.Drawing.Size(279, 30)
        Me.TsmMovGrupoDesp.Text = "&Grupo de Despesas"
        '
        'TsmMovSubGrupoDesp
        '
        Me.TsmMovSubGrupoDesp.Name = "TsmMovSubGrupoDesp"
        Me.TsmMovSubGrupoDesp.Size = New System.Drawing.Size(279, 30)
        Me.TsmMovSubGrupoDesp.Text = "&Sub. Grupo de Despesas"
        '
        'TSMMovPagComissao
        '
        Me.TSMMovPagComissao.Name = "TSMMovPagComissao"
        Me.TSMMovPagComissao.Size = New System.Drawing.Size(309, 30)
        Me.TSMMovPagComissao.Text = "&Pagamento de Comissão"
        '
        'REcebimentoDoFornecedorToolStripMenuItem
        '
        Me.REcebimentoDoFornecedorToolStripMenuItem.Name = "REcebimentoDoFornecedorToolStripMenuItem"
        Me.REcebimentoDoFornecedorToolStripMenuItem.Size = New System.Drawing.Size(309, 30)
        Me.REcebimentoDoFornecedorToolStripMenuItem.Text = "&Recebimento do Fornecedor"
        '
        'TSMRelatVendaServico
        '
        Me.TSMRelatVendaServico.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RelatórioDeFluxoDeCaixaToolStripMenuItem})
        Me.TSMRelatVendaServico.Name = "TSMRelatVendaServico"
        Me.TSMRelatVendaServico.Size = New System.Drawing.Size(102, 29)
        Me.TSMRelatVendaServico.Text = "Relatórios"
        '
        'RelatórioDeFluxoDeCaixaToolStripMenuItem
        '
        Me.RelatórioDeFluxoDeCaixaToolStripMenuItem.Name = "RelatórioDeFluxoDeCaixaToolStripMenuItem"
        Me.RelatórioDeFluxoDeCaixaToolStripMenuItem.Size = New System.Drawing.Size(239, 30)
        Me.RelatórioDeFluxoDeCaixaToolStripMenuItem.Text = "&Relatório Financeiro"
        '
        'TSMConfiguracao
        '
        Me.TSMConfiguracao.Name = "TSMConfiguracao"
        Me.TSMConfiguracao.Size = New System.Drawing.Size(138, 29)
        Me.TSMConfiguracao.Text = "Configurações"
        '
        'TSMSincroniza
        '
        Me.TSMSincroniza.Name = "TSMSincroniza"
        Me.TSMSincroniza.Size = New System.Drawing.Size(131, 29)
        Me.TSMSincroniza.Text = "&Fazer Backup!"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsp_atalhos, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel7})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 339)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(956, 30)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 26
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsp_atalhos
        '
        Me.tsp_atalhos.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsp_atalhos.ForeColor = System.Drawing.Color.DarkBlue
        Me.tsp_atalhos.Margin = New System.Windows.Forms.Padding(0, 3, -7, 2)
        Me.tsp_atalhos.Name = "tsp_atalhos"
        Me.tsp_atalhos.Size = New System.Drawing.Size(54, 25)
        Me.tsp_atalhos.Text = "[ F1 ]"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(191, 25)
        Me.ToolStripStatusLabel4.Text = "- Entrada de Produtos"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.DarkBlue
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(0, 3, -7, 2)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(54, 25)
        Me.ToolStripStatusLabel1.Text = "[ F2 ]"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(170, 25)
        Me.ToolStripStatusLabel2.Text = "- Saída de Produtos"
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel5.ForeColor = System.Drawing.Color.DarkBlue
        Me.ToolStripStatusLabel5.Margin = New System.Windows.Forms.Padding(0, 3, -7, 2)
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(54, 25)
        Me.ToolStripStatusLabel5.Text = "[ F3 ]"
        Me.ToolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(191, 25)
        Me.ToolStripStatusLabel6.Text = "- Lançamento de Rota"
        Me.ToolStripStatusLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.Color.DarkBlue
        Me.ToolStripStatusLabel3.Margin = New System.Windows.Forms.Padding(0, 3, -7, 2)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(54, 25)
        Me.ToolStripStatusLabel3.Text = "[ F6 ]"
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(191, 25)
        Me.ToolStripStatusLabel7.Text = "- Relatório Financeiro"
        Me.ToolStripStatusLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer
        '
        Me.Timer.Enabled = True
        '
        'painelPrincipal
        '
        Me.painelPrincipal.BackgroundImage = Global.AppDeEntrega.My.Resources.Resources.backgroundTelas
        Me.painelPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.painelPrincipal.Controls.Add(Me.txt_hora)
        Me.painelPrincipal.Location = New System.Drawing.Point(0, 30)
        Me.painelPrincipal.Name = "painelPrincipal"
        Me.painelPrincipal.Size = New System.Drawing.Size(956, 306)
        Me.painelPrincipal.TabIndex = 22
        '
        'txt_hora
        '
        Me.txt_hora.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.txt_hora.Enabled = False
        Me.txt_hora.Font = New System.Drawing.Font("Times New Roman", 35.0!, System.Drawing.FontStyle.Bold)
        Me.txt_hora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.txt_hora.Location = New System.Drawing.Point(778, 233)
        Me.txt_hora.MaxLength = 20
        Me.txt_hora.Name = "txt_hora"
        Me.txt_hora.ReadOnly = True
        Me.txt_hora.Size = New System.Drawing.Size(149, 61)
        Me.txt_hora.TabIndex = 25
        Me.txt_hora.Text = "12:00"
        Me.txt_hora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'HistoricoDeMovimentacaoToolStripMenuItem
        '
        Me.HistoricoDeMovimentacaoToolStripMenuItem.Name = "HistoricoDeMovimentacaoToolStripMenuItem"
        Me.HistoricoDeMovimentacaoToolStripMenuItem.Size = New System.Drawing.Size(309, 30)
        Me.HistoricoDeMovimentacaoToolStripMenuItem.Text = "&Historico de Movimentacao"
        '
        'FormPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 369)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.painelPrincipal)
        Me.Controls.Add(Me.MenuS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Formulário Principal"
        Me.MenuS.ResumeLayout(False)
        Me.MenuS.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.painelPrincipal.ResumeLayout(False)
        Me.painelPrincipal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuS As System.Windows.Forms.MenuStrip
    Friend WithEvents CadastrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMCadEntregador As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMCadProduto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMCadFornecedor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMCadValorAdicional As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMCadCidade As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSMCadEmpresa As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMMovimentacao As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMMovEntrada As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMMovSaida As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMMovOutraDespesa As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuDespesasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TsmMovGrupoDesp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TsmMovSubGrupoDesp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMMovPagComissao As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMRelatVendaServico As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMConfiguracao As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMSincroniza As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents painelPrincipal As System.Windows.Forms.Panel
    Friend WithEvents txt_hora As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsp_atalhos As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents REcebimentoDoFornecedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents LancamentoDeRotaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RelatórioDeFluxoDeCaixaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistoricoDeMovimentacaoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
