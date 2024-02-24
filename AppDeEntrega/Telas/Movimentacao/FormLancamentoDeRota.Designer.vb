<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLancamentoDeRota
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.txtValorPorKM = New System.Windows.Forms.TextBox()
        Me.txtKMRodado = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalComissao = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboFornecedorRota = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.tbpRota = New System.Windows.Forms.TabPage()
        Me.txtDescricaoRota = New System.Windows.Forms.ComboBox()
        Me.dataDaRota = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CboPesquisaFornecedor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.txtIdRota = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSomaKmRotas = New System.Windows.Forms.TextBox()
        Me.txtSomaTotaisRota = New System.Windows.Forms.TextBox()
        Me.txtQuantidadeRegistros = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtgRotas = New System.Windows.Forms.DataGridView()
        Me.idUsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDataRota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colKmRodado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalComissao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFornecedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcRota = New System.Windows.Forms.TabControl()
        Me.dtpFim = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbpRota.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgRotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcRota.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalvar
        '
        Me.btnSalvar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSalvar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalvar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSalvar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnSalvar.Image = Global.AppDeEntrega.My.Resources.Resources.Save
        Me.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalvar.Location = New System.Drawing.Point(691, 83)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(109, 34)
        Me.btnSalvar.TabIndex = 220
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.UseVisualStyleBackColor = False
        '
        'txtValorPorKM
        '
        Me.txtValorPorKM.Location = New System.Drawing.Point(18, 91)
        Me.txtValorPorKM.Name = "txtValorPorKM"
        Me.txtValorPorKM.Size = New System.Drawing.Size(115, 26)
        Me.txtValorPorKM.TabIndex = 150
        Me.txtValorPorKM.Text = "0,00"
        Me.txtValorPorKM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtKMRodado
        '
        Me.txtKMRodado.Location = New System.Drawing.Point(185, 88)
        Me.txtKMRodado.Name = "txtKMRodado"
        Me.txtKMRodado.Size = New System.Drawing.Size(101, 26)
        Me.txtKMRodado.TabIndex = 160
        Me.txtKMRodado.Text = "1"
        Me.txtKMRodado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(181, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 19)
        Me.Label8.TabIndex = 561
        Me.Label8.Text = "KM Rodado:"
        '
        'txtTotalComissao
        '
        Me.txtTotalComissao.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalComissao.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalComissao.Location = New System.Drawing.Point(360, 88)
        Me.txtTotalComissao.Name = "txtTotalComissao"
        Me.txtTotalComissao.ReadOnly = True
        Me.txtTotalComissao.Size = New System.Drawing.Size(131, 26)
        Me.txtTotalComissao.TabIndex = 180
        Me.txtTotalComissao.Text = "0,00"
        Me.txtTotalComissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(356, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 19)
        Me.Label6.TabIndex = 559
        Me.Label6.Text = "Total R$:"
        '
        'cboFornecedorRota
        '
        Me.cboFornecedorRota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFornecedorRota.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboFornecedorRota.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFornecedorRota.FormattingEnabled = True
        Me.cboFornecedorRota.Location = New System.Drawing.Point(534, 27)
        Me.cboFornecedorRota.Name = "cboFornecedorRota"
        Me.cboFornecedorRota.Size = New System.Drawing.Size(266, 27)
        Me.cboFornecedorRota.TabIndex = 140
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 69)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 19)
        Me.Label13.TabIndex = 557
        Me.Label13.Text = "Valor. Por KM:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(530, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 19)
        Me.Label3.TabIndex = 557
        Me.Label3.Text = "Fornecedor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(181, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Descrição:"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnBuscar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnBuscar.Image = Global.AppDeEntrega.My.Resources.Resources.Search
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(680, 63)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(149, 30)
        Me.btnBuscar.TabIndex = 585
        Me.btnBuscar.Text = "Consultar [ F5 ]"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'tbpRota
        '
        Me.tbpRota.Controls.Add(Me.txtDescricaoRota)
        Me.tbpRota.Controls.Add(Me.dataDaRota)
        Me.tbpRota.Controls.Add(Me.Label7)
        Me.tbpRota.Controls.Add(Me.txtValorPorKM)
        Me.tbpRota.Controls.Add(Me.txtKMRodado)
        Me.tbpRota.Controls.Add(Me.btnSalvar)
        Me.tbpRota.Controls.Add(Me.Label8)
        Me.tbpRota.Controls.Add(Me.txtTotalComissao)
        Me.tbpRota.Controls.Add(Me.Label6)
        Me.tbpRota.Controls.Add(Me.cboFornecedorRota)
        Me.tbpRota.Controls.Add(Me.Label13)
        Me.tbpRota.Controls.Add(Me.Label3)
        Me.tbpRota.Controls.Add(Me.Label2)
        Me.tbpRota.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbpRota.Location = New System.Drawing.Point(4, 28)
        Me.tbpRota.Name = "tbpRota"
        Me.tbpRota.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpRota.Size = New System.Drawing.Size(817, 124)
        Me.tbpRota.TabIndex = 0
        Me.tbpRota.Text = "Dados da Rota:"
        Me.tbpRota.UseVisualStyleBackColor = True
        '
        'txtDescricaoRota
        '
        Me.txtDescricaoRota.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDescricaoRota.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtDescricaoRota.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescricaoRota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txtDescricaoRota.Font = New System.Drawing.Font("Cambria", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescricaoRota.FormattingEnabled = True
        Me.txtDescricaoRota.Location = New System.Drawing.Point(185, 29)
        Me.txtDescricaoRota.Name = "txtDescricaoRota"
        Me.txtDescricaoRota.Size = New System.Drawing.Size(306, 23)
        Me.txtDescricaoRota.TabIndex = 590
        '
        'dataDaRota
        '
        Me.dataDaRota.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataDaRota.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataDaRota.Location = New System.Drawing.Point(18, 28)
        Me.dataDaRota.Name = "dataDaRota"
        Me.dataDaRota.Size = New System.Drawing.Size(132, 26)
        Me.dataDaRota.TabIndex = 110
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 19)
        Me.Label7.TabIndex = 589
        Me.Label7.Text = "Data da Rota:"
        '
        'CboPesquisaFornecedor
        '
        Me.CboPesquisaFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPesquisaFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CboPesquisaFornecedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPesquisaFornecedor.FormattingEnabled = True
        Me.CboPesquisaFornecedor.Location = New System.Drawing.Point(340, 65)
        Me.CboPesquisaFornecedor.Name = "CboPesquisaFornecedor"
        Me.CboPesquisaFornecedor.Size = New System.Drawing.Size(289, 28)
        Me.CboPesquisaFornecedor.TabIndex = 581
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(336, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 19)
        Me.Label4.TabIndex = 582
        Me.Label4.Text = "Fornecedor:"
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
        Me.btnImprimir.Location = New System.Drawing.Point(710, 264)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(136, 29)
        Me.btnImprimir.TabIndex = 580
        Me.btnImprimir.Text = "&Imprimir F11"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'txtIdRota
        '
        Me.txtIdRota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdRota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdRota.Location = New System.Drawing.Point(786, 12)
        Me.txtIdRota.MaxLength = 3
        Me.txtIdRota.Name = "txtIdRota"
        Me.txtIdRota.ReadOnly = True
        Me.txtIdRota.Size = New System.Drawing.Size(60, 21)
        Me.txtIdRota.TabIndex = 579
        Me.txtIdRota.Text = "0"
        Me.txtIdRota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIdRota.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(255, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(346, 25)
        Me.Label1.TabIndex = 576
        Me.Label1.Text = ":: LANÇAMENTO DE ROTAS ::"
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
        Me.btn_excluir.Location = New System.Drawing.Point(605, 264)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(91, 29)
        Me.btn_excluir.TabIndex = 575
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excluir.UseVisualStyleBackColor = False
        '
        'btn_alterar
        '
        Me.btn_alterar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_alterar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_alterar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_alterar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_alterar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_alterar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_alterar.Image = Global.AppDeEntrega.My.Resources.Resources.editar
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_alterar.Location = New System.Drawing.Point(500, 264)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(91, 29)
        Me.btn_alterar.TabIndex = 574
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtSomaKmRotas)
        Me.GroupBox1.Controls.Add(Me.txtSomaTotaisRota)
        Me.GroupBox1.Controls.Add(Me.txtQuantidadeRegistros)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 295)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(822, 35)
        Me.GroupBox1.TabIndex = 578
        Me.GroupBox1.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(221, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 14)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Tot. Km Rodados:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(427, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 14)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Total R$:"
        '
        'txtSomaKmRotas
        '
        Me.txtSomaKmRotas.BackColor = System.Drawing.SystemColors.Info
        Me.txtSomaKmRotas.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSomaKmRotas.Location = New System.Drawing.Point(331, 9)
        Me.txtSomaKmRotas.Name = "txtSomaKmRotas"
        Me.txtSomaKmRotas.ReadOnly = True
        Me.txtSomaKmRotas.Size = New System.Drawing.Size(78, 22)
        Me.txtSomaKmRotas.TabIndex = 2
        Me.txtSomaKmRotas.Text = "0,00"
        Me.txtSomaKmRotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSomaTotaisRota
        '
        Me.txtSomaTotaisRota.BackColor = System.Drawing.SystemColors.Info
        Me.txtSomaTotaisRota.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSomaTotaisRota.Location = New System.Drawing.Point(489, 9)
        Me.txtSomaTotaisRota.Name = "txtSomaTotaisRota"
        Me.txtSomaTotaisRota.ReadOnly = True
        Me.txtSomaTotaisRota.Size = New System.Drawing.Size(78, 22)
        Me.txtSomaTotaisRota.TabIndex = 2
        Me.txtSomaTotaisRota.Text = "0,00"
        Me.txtSomaTotaisRota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantidadeRegistros
        '
        Me.txtQuantidadeRegistros.BackColor = System.Drawing.SystemColors.Info
        Me.txtQuantidadeRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQuantidadeRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantidadeRegistros.ForeColor = System.Drawing.Color.Red
        Me.txtQuantidadeRegistros.Location = New System.Drawing.Point(720, 12)
        Me.txtQuantidadeRegistros.MaxLength = 4
        Me.txtQuantidadeRegistros.Name = "txtQuantidadeRegistros"
        Me.txtQuantidadeRegistros.ReadOnly = True
        Me.txtQuantidadeRegistros.Size = New System.Drawing.Size(85, 17)
        Me.txtQuantidadeRegistros.TabIndex = 1
        Me.txtQuantidadeRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(653, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Registros:"
        '
        'dtgRotas
        '
        Me.dtgRotas.AllowUserToAddRows = False
        Me.dtgRotas.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgRotas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgRotas.BackgroundColor = System.Drawing.Color.Gray
        Me.dtgRotas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgRotas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgRotas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgRotas.ColumnHeadersHeight = 26
        Me.dtgRotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgRotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idUsu, Me.colDataRota, Me.colDescricao, Me.colKmRodado, Me.colTotalComissao, Me.colFornecedor})
        Me.dtgRotas.Location = New System.Drawing.Point(24, 333)
        Me.dtgRotas.Name = "dtgRotas"
        Me.dtgRotas.ReadOnly = True
        Me.dtgRotas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtgRotas.RowHeadersWidth = 20
        Me.dtgRotas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgRotas.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgRotas.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dtgRotas.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgRotas.Size = New System.Drawing.Size(822, 168)
        Me.dtgRotas.TabIndex = 572
        '
        'idUsu
        '
        Me.idUsu.HeaderText = "Id"
        Me.idUsu.MaxInputLength = 13
        Me.idUsu.Name = "idUsu"
        Me.idUsu.ReadOnly = True
        Me.idUsu.Visible = False
        '
        'colDataRota
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.colDataRota.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDataRota.HeaderText = "Data da Rota"
        Me.colDataRota.MaxInputLength = 150
        Me.colDataRota.Name = "colDataRota"
        Me.colDataRota.ReadOnly = True
        Me.colDataRota.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colDataRota.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colDataRota.Width = 130
        '
        'colDescricao
        '
        Me.colDescricao.HeaderText = "Descrição da Rota"
        Me.colDescricao.Name = "colDescricao"
        Me.colDescricao.ReadOnly = True
        Me.colDescricao.Width = 250
        '
        'colKmRodado
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colKmRodado.DefaultCellStyle = DataGridViewCellStyle4
        Me.colKmRodado.HeaderText = "KM Rodado"
        Me.colKmRodado.Name = "colKmRodado"
        Me.colKmRodado.ReadOnly = True
        Me.colKmRodado.Width = 90
        '
        'colTotalComissao
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.colTotalComissao.DefaultCellStyle = DataGridViewCellStyle5
        Me.colTotalComissao.HeaderText = "Total R$"
        Me.colTotalComissao.Name = "colTotalComissao"
        Me.colTotalComissao.ReadOnly = True
        Me.colTotalComissao.Width = 110
        '
        'colFornecedor
        '
        Me.colFornecedor.HeaderText = "Fornecedor"
        Me.colFornecedor.Name = "colFornecedor"
        Me.colFornecedor.ReadOnly = True
        Me.colFornecedor.Width = 200
        '
        'tbcRota
        '
        Me.tbcRota.Controls.Add(Me.tbpRota)
        Me.tbcRota.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcRota.Location = New System.Drawing.Point(25, 103)
        Me.tbcRota.Name = "tbcRota"
        Me.tbcRota.SelectedIndex = 0
        Me.tbcRota.Size = New System.Drawing.Size(825, 156)
        Me.tbcRota.TabIndex = 100
        '
        'dtpFim
        '
        Me.dtpFim.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFim.Location = New System.Drawing.Point(189, 67)
        Me.dtpFim.Name = "dtpFim"
        Me.dtpFim.Size = New System.Drawing.Size(126, 25)
        Me.dtpFim.TabIndex = 588
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 19)
        Me.Label5.TabIndex = 586
        Me.Label5.Text = "Período:"
        '
        'dtpInicio
        '
        Me.dtpInicio.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(31, 67)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(125, 25)
        Me.dtpInicio.TabIndex = 589
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Cambria", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(162, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 23)
        Me.Label9.TabIndex = 587
        Me.Label9.Text = "A"
        '
        'FormLancamentoDeRota
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppDeEntrega.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(869, 510)
        Me.Controls.Add(Me.dtpFim)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpInicio)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.CboPesquisaFornecedor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.txtIdRota)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.btn_alterar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtgRotas)
        Me.Controls.Add(Me.tbcRota)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormLancamentoDeRota"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lançamento de Rota"
        Me.tbpRota.ResumeLayout(False)
        Me.tbpRota.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtgRotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcRota.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents txtValorPorKM As System.Windows.Forms.TextBox
    Friend WithEvents txtKMRodado As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalComissao As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboFornecedorRota As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents tbpRota As System.Windows.Forms.TabPage
    Friend WithEvents CboPesquisaFornecedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents txtIdRota As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtQuantidadeRegistros As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtgRotas As System.Windows.Forms.DataGridView
    Friend WithEvents tbcRota As System.Windows.Forms.TabControl
    Friend WithEvents dataDaRota As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFim As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDescricaoRota As System.Windows.Forms.ComboBox
    Friend WithEvents idUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDataRota As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colKmRodado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalComissao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFornecedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSomaKmRotas As System.Windows.Forms.TextBox
    Friend WithEvents txtSomaTotaisRota As System.Windows.Forms.TextBox
End Class
