<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRecebimentoFornecedor
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
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle52 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle50 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle51 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtIdRota = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbcPagComissao = New System.Windows.Forms.TabControl()
        Me.tbpComissPaga = New System.Windows.Forms.TabPage()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.dataRecebimento = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.txtValorComissao = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CboFornecedor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtObservacaoPesquisa = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.cboFornecedorPesquisa = New System.Windows.Forms.ComboBox()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.dtpFimPago = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnConsultaPagos = New System.Windows.Forms.Button()
        Me.dtpInicioPago = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbpProdutosEntregues = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSomaComissoes = New System.Windows.Forms.TextBox()
        Me.txtQtdeRegistrosComissoes = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtgComissaoPagas = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDataPagamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEntregador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValorPagamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colObservacaoPagos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtQuantidadeEntregue = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtgSaidaENTREGUE = New System.Windows.Forms.DataGridView()
        Me.dtg1_colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg1_colDataEntrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg1_colProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg1_colquantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg1_colFornecedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboFornecedorPesquisaENTREGUES = New System.Windows.Forms.ComboBox()
        Me.dtpFinalENTREGA = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpInicialENTREGA = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnPesquisaEntregues = New System.Windows.Forms.Button()
        Me.txtSomaComissFornecedorENTREGUES = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbcPagComissao.SuspendLayout()
        Me.tbpComissPaga.SuspendLayout()
        Me.tbpProdutosEntregues.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtgComissaoPagas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgSaidaENTREGUE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtIdRota
        '
        Me.txtIdRota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdRota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdRota.Location = New System.Drawing.Point(701, 18)
        Me.txtIdRota.MaxLength = 3
        Me.txtIdRota.Name = "txtIdRota"
        Me.txtIdRota.ReadOnly = True
        Me.txtIdRota.Size = New System.Drawing.Size(60, 21)
        Me.txtIdRota.TabIndex = 599
        Me.txtIdRota.Text = "0"
        Me.txtIdRota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIdRota.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(185, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(410, 23)
        Me.Label1.TabIndex = 598
        Me.Label1.Text = ":: RECEBIMENTO DOS FORNECEDORES ::"
        '
        'tbcPagComissao
        '
        Me.tbcPagComissao.Controls.Add(Me.tbpComissPaga)
        Me.tbcPagComissao.Controls.Add(Me.tbpProdutosEntregues)
        Me.tbcPagComissao.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcPagComissao.Location = New System.Drawing.Point(18, 156)
        Me.tbcPagComissao.Name = "tbcPagComissao"
        Me.tbcPagComissao.SelectedIndex = 0
        Me.tbcPagComissao.Size = New System.Drawing.Size(760, 383)
        Me.tbcPagComissao.TabIndex = 597
        '
        'tbpComissPaga
        '
        Me.tbpComissPaga.Controls.Add(Me.GroupBox2)
        Me.tbpComissPaga.Controls.Add(Me.dtgComissaoPagas)
        Me.tbpComissPaga.Controls.Add(Me.txtObservacao)
        Me.tbpComissPaga.Controls.Add(Me.dataRecebimento)
        Me.tbpComissPaga.Controls.Add(Me.Label3)
        Me.tbpComissPaga.Controls.Add(Me.btnConfirmar)
        Me.tbpComissPaga.Controls.Add(Me.txtValorComissao)
        Me.tbpComissPaga.Controls.Add(Me.Label2)
        Me.tbpComissPaga.Controls.Add(Me.Label15)
        Me.tbpComissPaga.Controls.Add(Me.Label6)
        Me.tbpComissPaga.Controls.Add(Me.CboFornecedor)
        Me.tbpComissPaga.Controls.Add(Me.Label4)
        Me.tbpComissPaga.Location = New System.Drawing.Point(4, 28)
        Me.tbpComissPaga.Name = "tbpComissPaga"
        Me.tbpComissPaga.Size = New System.Drawing.Size(752, 351)
        Me.tbpComissPaga.TabIndex = 1
        Me.tbpComissPaga.Text = "Recebimento"
        Me.tbpComissPaga.UseVisualStyleBackColor = True
        '
        'txtObservacao
        '
        Me.txtObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacao.Location = New System.Drawing.Point(113, 101)
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(331, 26)
        Me.txtObservacao.TabIndex = 623
        '
        'dataRecebimento
        '
        Me.dataRecebimento.Font = New System.Drawing.Font("Cambria", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataRecebimento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataRecebimento.Location = New System.Drawing.Point(17, 56)
        Me.dataRecebimento.Name = "dataRecebimento"
        Me.dataRecebimento.Size = New System.Drawing.Size(138, 28)
        Me.dataRecebimento.TabIndex = 620
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label3.Location = New System.Drawing.Point(13, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(473, 19)
        Me.Label3.TabIndex = 621
        Me.Label3.Text = "Dados do Pagamento:                                                              " & _
    "              "
        '
        'btnConfirmar
        '
        Me.btnConfirmar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirmar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnConfirmar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnConfirmar.Image = Global.AppDeEntrega.My.Resources.Resources.ok_16x16
        Me.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirmar.Location = New System.Drawing.Point(621, 50)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(118, 34)
        Me.btnConfirmar.TabIndex = 615
        Me.btnConfirmar.Text = "&Confirmar"
        Me.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfirmar.UseVisualStyleBackColor = False
        '
        'txtValorComissao
        '
        Me.txtValorComissao.BackColor = System.Drawing.SystemColors.Info
        Me.txtValorComissao.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorComissao.Location = New System.Drawing.Point(488, 57)
        Me.txtValorComissao.Name = "txtValorComissao"
        Me.txtValorComissao.Size = New System.Drawing.Size(103, 25)
        Me.txtValorComissao.TabIndex = 614
        Me.txtValorComissao.Text = "0,00"
        Me.txtValorComissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 19)
        Me.Label2.TabIndex = 622
        Me.Label2.Text = "Data Recebimento:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 19)
        Me.Label15.TabIndex = 616
        Me.Label15.Text = "Observação:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(484, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 19)
        Me.Label6.TabIndex = 617
        Me.Label6.Text = "Total R$:"
        '
        'CboFornecedor
        '
        Me.CboFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CboFornecedor.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboFornecedor.FormattingEnabled = True
        Me.CboFornecedor.Location = New System.Drawing.Point(191, 59)
        Me.CboFornecedor.Name = "CboFornecedor"
        Me.CboFornecedor.Size = New System.Drawing.Size(253, 25)
        Me.CboFornecedor.TabIndex = 619
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(187, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 19)
        Me.Label4.TabIndex = 618
        Me.Label4.Text = "Fornecedor:"
        '
        'txtObservacaoPesquisa
        '
        Me.txtObservacaoPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacaoPesquisa.Location = New System.Drawing.Point(138, 125)
        Me.txtObservacaoPesquisa.Name = "txtObservacaoPesquisa"
        Me.txtObservacaoPesquisa.Size = New System.Drawing.Size(305, 20)
        Me.txtObservacaoPesquisa.TabIndex = 631
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(35, 124)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(94, 19)
        Me.Label17.TabIndex = 630
        Me.Label17.Text = "Observação:"
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnImprimir.Image = Global.AppDeEntrega.My.Resources.Resources.Imprime
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(631, 116)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(130, 29)
        Me.btnImprimir.TabIndex = 622
        Me.btnImprimir.Text = "&Imprimir F11"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'cboFornecedorPesquisa
        '
        Me.cboFornecedorPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFornecedorPesquisa.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboFornecedorPesquisa.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFornecedorPesquisa.FormattingEnabled = True
        Me.cboFornecedorPesquisa.Location = New System.Drawing.Point(342, 79)
        Me.cboFornecedorPesquisa.Name = "cboFornecedorPesquisa"
        Me.cboFornecedorPesquisa.Size = New System.Drawing.Size(253, 25)
        Me.cboFornecedorPesquisa.TabIndex = 629
        '
        'btn_excluir
        '
        Me.btn_excluir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_excluir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_excluir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_excluir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_excluir.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_excluir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_excluir.Image = Global.AppDeEntrega.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_excluir.Location = New System.Drawing.Point(465, 116)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(130, 29)
        Me.btn_excluir.TabIndex = 621
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excluir.UseVisualStyleBackColor = False
        '
        'dtpFimPago
        '
        Me.dtpFimPago.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFimPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFimPago.Location = New System.Drawing.Point(192, 79)
        Me.dtpFimPago.Name = "dtpFimPago"
        Me.dtpFimPago.Size = New System.Drawing.Size(126, 25)
        Me.dtpFimPago.TabIndex = 627
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(35, 55)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 19)
        Me.Label12.TabIndex = 625
        Me.Label12.Text = "Período:"
        '
        'btnConsultaPagos
        '
        Me.btnConsultaPagos.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnConsultaPagos.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnConsultaPagos.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnConsultaPagos.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnConsultaPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultaPagos.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnConsultaPagos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnConsultaPagos.Image = Global.AppDeEntrega.My.Resources.Resources.Search
        Me.btnConsultaPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultaPagos.Location = New System.Drawing.Point(631, 73)
        Me.btnConsultaPagos.Name = "btnConsultaPagos"
        Me.btnConsultaPagos.Size = New System.Drawing.Size(130, 30)
        Me.btnConsultaPagos.TabIndex = 624
        Me.btnConsultaPagos.Text = "Consultar F5"
        Me.btnConsultaPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultaPagos.UseVisualStyleBackColor = False
        '
        'dtpInicioPago
        '
        Me.dtpInicioPago.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInicioPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicioPago.Location = New System.Drawing.Point(39, 79)
        Me.dtpInicioPago.Name = "dtpInicioPago"
        Me.dtpInicioPago.Size = New System.Drawing.Size(125, 25)
        Me.dtpInicioPago.TabIndex = 628
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Cambria", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(167, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(23, 23)
        Me.Label13.TabIndex = 626
        Me.Label13.Text = "A"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(338, 55)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 19)
        Me.Label14.TabIndex = 623
        Me.Label14.Text = "Fornecedor:"
        '
        'tbpProdutosEntregues
        '
        Me.tbpProdutosEntregues.Controls.Add(Me.btnPesquisaEntregues)
        Me.tbpProdutosEntregues.Controls.Add(Me.cboFornecedorPesquisaENTREGUES)
        Me.tbpProdutosEntregues.Controls.Add(Me.dtpFinalENTREGA)
        Me.tbpProdutosEntregues.Controls.Add(Me.Label5)
        Me.tbpProdutosEntregues.Controls.Add(Me.dtpInicialENTREGA)
        Me.tbpProdutosEntregues.Controls.Add(Me.Label9)
        Me.tbpProdutosEntregues.Controls.Add(Me.Label11)
        Me.tbpProdutosEntregues.Controls.Add(Me.GroupBox1)
        Me.tbpProdutosEntregues.Controls.Add(Me.dtgSaidaENTREGUE)
        Me.tbpProdutosEntregues.Location = New System.Drawing.Point(4, 28)
        Me.tbpProdutosEntregues.Name = "tbpProdutosEntregues"
        Me.tbpProdutosEntregues.Size = New System.Drawing.Size(752, 351)
        Me.tbpProdutosEntregues.TabIndex = 2
        Me.tbpProdutosEntregues.Text = "Produtos Entregues"
        Me.tbpProdutosEntregues.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtSomaComissoes)
        Me.GroupBox2.Controls.Add(Me.txtQtdeRegistrosComissoes)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 148)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(752, 39)
        Me.GroupBox2.TabIndex = 637
        Me.GroupBox2.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(369, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 14)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Total R$:"
        '
        'txtSomaComissoes
        '
        Me.txtSomaComissoes.BackColor = System.Drawing.SystemColors.Info
        Me.txtSomaComissoes.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSomaComissoes.Location = New System.Drawing.Point(431, 12)
        Me.txtSomaComissoes.Name = "txtSomaComissoes"
        Me.txtSomaComissoes.ReadOnly = True
        Me.txtSomaComissoes.Size = New System.Drawing.Size(78, 22)
        Me.txtSomaComissoes.TabIndex = 2
        Me.txtSomaComissoes.Text = "0,00"
        Me.txtSomaComissoes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQtdeRegistrosComissoes
        '
        Me.txtQtdeRegistrosComissoes.BackColor = System.Drawing.SystemColors.Info
        Me.txtQtdeRegistrosComissoes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQtdeRegistrosComissoes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtdeRegistrosComissoes.ForeColor = System.Drawing.Color.Red
        Me.txtQtdeRegistrosComissoes.Location = New System.Drawing.Point(651, 14)
        Me.txtQtdeRegistrosComissoes.MaxLength = 4
        Me.txtQtdeRegistrosComissoes.Name = "txtQtdeRegistrosComissoes"
        Me.txtQtdeRegistrosComissoes.ReadOnly = True
        Me.txtQtdeRegistrosComissoes.Size = New System.Drawing.Size(85, 17)
        Me.txtQtdeRegistrosComissoes.TabIndex = 1
        Me.txtQtdeRegistrosComissoes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(584, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Registros:"
        '
        'dtgComissaoPagas
        '
        Me.dtgComissaoPagas.AllowUserToAddRows = False
        Me.dtgComissaoPagas.AllowUserToResizeColumns = False
        DataGridViewCellStyle47.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle47.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgComissaoPagas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle47
        Me.dtgComissaoPagas.BackgroundColor = System.Drawing.Color.Gray
        Me.dtgComissaoPagas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgComissaoPagas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle48.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgComissaoPagas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle48
        Me.dtgComissaoPagas.ColumnHeadersHeight = 26
        Me.dtgComissaoPagas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgComissaoPagas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.colDataPagamento, Me.colEntregador, Me.colValorPagamento, Me.colObservacaoPagos})
        Me.dtgComissaoPagas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtgComissaoPagas.Location = New System.Drawing.Point(0, 187)
        Me.dtgComissaoPagas.Name = "dtgComissaoPagas"
        Me.dtgComissaoPagas.ReadOnly = True
        Me.dtgComissaoPagas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtgComissaoPagas.RowHeadersWidth = 20
        Me.dtgComissaoPagas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle52.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgComissaoPagas.RowsDefaultCellStyle = DataGridViewCellStyle52
        Me.dtgComissaoPagas.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dtgComissaoPagas.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgComissaoPagas.Size = New System.Drawing.Size(752, 164)
        Me.dtgComissaoPagas.TabIndex = 638
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.MaxInputLength = 13
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'colDataPagamento
        '
        DataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colDataPagamento.DefaultCellStyle = DataGridViewCellStyle49
        Me.colDataPagamento.HeaderText = "Data Pagamento"
        Me.colDataPagamento.Name = "colDataPagamento"
        Me.colDataPagamento.ReadOnly = True
        Me.colDataPagamento.Width = 150
        '
        'colEntregador
        '
        DataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle50.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.colEntregador.DefaultCellStyle = DataGridViewCellStyle50
        Me.colEntregador.HeaderText = "Fornecedor"
        Me.colEntregador.MaxInputLength = 2
        Me.colEntregador.Name = "colEntregador"
        Me.colEntregador.ReadOnly = True
        Me.colEntregador.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colEntregador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colEntregador.Width = 220
        '
        'colValorPagamento
        '
        DataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colValorPagamento.DefaultCellStyle = DataGridViewCellStyle51
        Me.colValorPagamento.HeaderText = "Valor R$"
        Me.colValorPagamento.Name = "colValorPagamento"
        Me.colValorPagamento.ReadOnly = True
        Me.colValorPagamento.Width = 110
        '
        'colObservacaoPagos
        '
        Me.colObservacaoPagos.HeaderText = "Observação:"
        Me.colObservacaoPagos.Name = "colObservacaoPagos"
        Me.colObservacaoPagos.ReadOnly = True
        Me.colObservacaoPagos.Width = 230
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtSomaComissFornecedorENTREGUES)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtQuantidadeEntregue)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 141)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(752, 42)
        Me.GroupBox1.TabIndex = 555
        Me.GroupBox1.TabStop = False
        '
        'txtQuantidadeEntregue
        '
        Me.txtQuantidadeEntregue.BackColor = System.Drawing.SystemColors.Info
        Me.txtQuantidadeEntregue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQuantidadeEntregue.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantidadeEntregue.ForeColor = System.Drawing.Color.Red
        Me.txtQuantidadeEntregue.Location = New System.Drawing.Point(654, 16)
        Me.txtQuantidadeEntregue.MaxLength = 4
        Me.txtQuantidadeEntregue.Name = "txtQuantidadeEntregue"
        Me.txtQuantidadeEntregue.ReadOnly = True
        Me.txtQuantidadeEntregue.Size = New System.Drawing.Size(85, 17)
        Me.txtQuantidadeEntregue.TabIndex = 1
        Me.txtQuantidadeEntregue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(587, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Registros:"
        '
        'dtgSaidaENTREGUE
        '
        Me.dtgSaidaENTREGUE.AllowUserToAddRows = False
        Me.dtgSaidaENTREGUE.AllowUserToResizeColumns = False
        DataGridViewCellStyle40.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle40.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgSaidaENTREGUE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle40
        Me.dtgSaidaENTREGUE.BackgroundColor = System.Drawing.Color.Gray
        Me.dtgSaidaENTREGUE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgSaidaENTREGUE.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle41.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle41.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgSaidaENTREGUE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle41
        Me.dtgSaidaENTREGUE.ColumnHeadersHeight = 26
        Me.dtgSaidaENTREGUE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgSaidaENTREGUE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dtg1_colID, Me.dtg1_colDataEntrada, Me.dtg1_colProduto, Me.dtg1_colquantidade, Me.dtg1_colFornecedor})
        Me.dtgSaidaENTREGUE.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtgSaidaENTREGUE.Location = New System.Drawing.Point(0, 183)
        Me.dtgSaidaENTREGUE.Name = "dtgSaidaENTREGUE"
        Me.dtgSaidaENTREGUE.ReadOnly = True
        Me.dtgSaidaENTREGUE.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtgSaidaENTREGUE.RowHeadersWidth = 20
        Me.dtgSaidaENTREGUE.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle46.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgSaidaENTREGUE.RowsDefaultCellStyle = DataGridViewCellStyle46
        Me.dtgSaidaENTREGUE.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dtgSaidaENTREGUE.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgSaidaENTREGUE.Size = New System.Drawing.Size(752, 168)
        Me.dtgSaidaENTREGUE.TabIndex = 556
        '
        'dtg1_colID
        '
        Me.dtg1_colID.HeaderText = "Id"
        Me.dtg1_colID.MaxInputLength = 13
        Me.dtg1_colID.Name = "dtg1_colID"
        Me.dtg1_colID.ReadOnly = True
        Me.dtg1_colID.Visible = False
        '
        'dtg1_colDataEntrada
        '
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dtg1_colDataEntrada.DefaultCellStyle = DataGridViewCellStyle42
        Me.dtg1_colDataEntrada.HeaderText = "Data Saída"
        Me.dtg1_colDataEntrada.Name = "dtg1_colDataEntrada"
        Me.dtg1_colDataEntrada.ReadOnly = True
        Me.dtg1_colDataEntrada.Width = 130
        '
        'dtg1_colProduto
        '
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle43.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtg1_colProduto.DefaultCellStyle = DataGridViewCellStyle43
        Me.dtg1_colProduto.HeaderText = "Produto"
        Me.dtg1_colProduto.MaxInputLength = 2
        Me.dtg1_colProduto.Name = "dtg1_colProduto"
        Me.dtg1_colProduto.ReadOnly = True
        Me.dtg1_colProduto.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg1_colProduto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dtg1_colProduto.Width = 240
        '
        'dtg1_colquantidade
        '
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle44.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtg1_colquantidade.DefaultCellStyle = DataGridViewCellStyle44
        Me.dtg1_colquantidade.HeaderText = "Quantidade"
        Me.dtg1_colquantidade.Name = "dtg1_colquantidade"
        Me.dtg1_colquantidade.ReadOnly = True
        Me.dtg1_colquantidade.Width = 110
        '
        'dtg1_colFornecedor
        '
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dtg1_colFornecedor.DefaultCellStyle = DataGridViewCellStyle45
        Me.dtg1_colFornecedor.HeaderText = "Fornecedor"
        Me.dtg1_colFornecedor.Name = "dtg1_colFornecedor"
        Me.dtg1_colFornecedor.ReadOnly = True
        Me.dtg1_colFornecedor.Width = 230
        '
        'cboFornecedorPesquisaENTREGUES
        '
        Me.cboFornecedorPesquisaENTREGUES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFornecedorPesquisaENTREGUES.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboFornecedorPesquisaENTREGUES.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFornecedorPesquisaENTREGUES.FormattingEnabled = True
        Me.cboFornecedorPesquisaENTREGUES.Location = New System.Drawing.Point(320, 54)
        Me.cboFornecedorPesquisaENTREGUES.Name = "cboFornecedorPesquisaENTREGUES"
        Me.cboFornecedorPesquisaENTREGUES.Size = New System.Drawing.Size(253, 25)
        Me.cboFornecedorPesquisaENTREGUES.TabIndex = 635
        '
        'dtpFinalENTREGA
        '
        Me.dtpFinalENTREGA.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFinalENTREGA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinalENTREGA.Location = New System.Drawing.Point(170, 54)
        Me.dtpFinalENTREGA.Name = "dtpFinalENTREGA"
        Me.dtpFinalENTREGA.Size = New System.Drawing.Size(126, 25)
        Me.dtpFinalENTREGA.TabIndex = 633
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 19)
        Me.Label5.TabIndex = 631
        Me.Label5.Text = "Período:"
        '
        'dtpInicialENTREGA
        '
        Me.dtpInicialENTREGA.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInicialENTREGA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicialENTREGA.Location = New System.Drawing.Point(17, 54)
        Me.dtpInicialENTREGA.Name = "dtpInicialENTREGA"
        Me.dtpInicialENTREGA.Size = New System.Drawing.Size(125, 25)
        Me.dtpInicialENTREGA.TabIndex = 634
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Cambria", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(145, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 23)
        Me.Label9.TabIndex = 632
        Me.Label9.Text = "A"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(316, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 19)
        Me.Label11.TabIndex = 630
        Me.Label11.Text = "Fornecedor:"
        '
        'btnPesquisaEntregues
        '
        Me.btnPesquisaEntregues.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPesquisaEntregues.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnPesquisaEntregues.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnPesquisaEntregues.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnPesquisaEntregues.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPesquisaEntregues.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnPesquisaEntregues.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnPesquisaEntregues.Image = Global.AppDeEntrega.My.Resources.Resources.Search
        Me.btnPesquisaEntregues.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPesquisaEntregues.Location = New System.Drawing.Point(609, 48)
        Me.btnPesquisaEntregues.Name = "btnPesquisaEntregues"
        Me.btnPesquisaEntregues.Size = New System.Drawing.Size(130, 30)
        Me.btnPesquisaEntregues.TabIndex = 636
        Me.btnPesquisaEntregues.Text = "Consultar"
        Me.btnPesquisaEntregues.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPesquisaEntregues.UseVisualStyleBackColor = False
        '
        'txtSomaComissFornecedorENTREGUES
        '
        Me.txtSomaComissFornecedorENTREGUES.BackColor = System.Drawing.SystemColors.Info
        Me.txtSomaComissFornecedorENTREGUES.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSomaComissFornecedorENTREGUES.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSomaComissFornecedorENTREGUES.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtSomaComissFornecedorENTREGUES.Location = New System.Drawing.Point(488, 19)
        Me.txtSomaComissFornecedorENTREGUES.MaxLength = 4
        Me.txtSomaComissFornecedorENTREGUES.Name = "txtSomaComissFornecedorENTREGUES"
        Me.txtSomaComissFornecedorENTREGUES.ReadOnly = True
        Me.txtSomaComissFornecedorENTREGUES.Size = New System.Drawing.Size(85, 17)
        Me.txtSomaComissFornecedorENTREGUES.TabIndex = 3
        Me.txtSomaComissFornecedorENTREGUES.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(360, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(122, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Comiss. Fornecedor:"
        '
        'FormRecebimentoFornecedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppDeEntrega.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(796, 551)
        Me.Controls.Add(Me.txtObservacaoPesquisa)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.cboFornecedorPesquisa)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.dtpFimPago)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnConsultaPagos)
        Me.Controls.Add(Me.dtpInicioPago)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtIdRota)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbcPagComissao)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormRecebimentoFornecedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recebimentos do Fornecedor"
        Me.tbcPagComissao.ResumeLayout(False)
        Me.tbpComissPaga.ResumeLayout(False)
        Me.tbpComissPaga.PerformLayout()
        Me.tbpProdutosEntregues.ResumeLayout(False)
        Me.tbpProdutosEntregues.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtgComissaoPagas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtgSaidaENTREGUE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIdRota As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbcPagComissao As System.Windows.Forms.TabControl
    Friend WithEvents tbpComissPaga As System.Windows.Forms.TabPage
    Friend WithEvents txtObservacao As System.Windows.Forms.TextBox
    Friend WithEvents dataRecebimento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents btnConfirmar As System.Windows.Forms.Button
    Friend WithEvents txtValorComissao As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CboFornecedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtObservacaoPesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents cboFornecedorPesquisa As System.Windows.Forms.ComboBox
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents dtpFimPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents btnConsultaPagos As System.Windows.Forms.Button
    Friend WithEvents dtpInicioPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbpProdutosEntregues As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSomaComissoes As System.Windows.Forms.TextBox
    Friend WithEvents txtQtdeRegistrosComissoes As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtgComissaoPagas As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDataPagamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEntregador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValorPagamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObservacaoPagos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtQuantidadeEntregue As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtgSaidaENTREGUE As System.Windows.Forms.DataGridView
    Friend WithEvents dtg1_colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg1_colDataEntrada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg1_colProduto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg1_colquantidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg1_colFornecedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents btnPesquisaEntregues As System.Windows.Forms.Button
    Friend WithEvents cboFornecedorPesquisaENTREGUES As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFinalENTREGA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpInicialENTREGA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSomaComissFornecedorENTREGUES As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
