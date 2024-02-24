<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCadProduto
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
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtgProdutos = New System.Windows.Forms.DataGridView()
        Me.idUsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescricaoProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgFornecedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgComissaoForn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgEstoque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgValorAdicional = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.txtIdProd = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtQuantidadeRegistros = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPesquisaDescricao = New System.Windows.Forms.TextBox()
        Me.CboPesquisaFornecedor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtValorComissaoFornecedor = New System.Windows.Forms.TextBox()
        Me.mskDataEntrega = New System.Windows.Forms.MaskedTextBox()
        Me.mskDataSaida = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.mskDataEntrada = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtProdutoEstoque = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtValorAdicional = New System.Windows.Forms.TextBox()
        Me.CboValoresAdicionais = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProdutoDescricao = New System.Windows.Forms.TextBox()
        Me.cboProdutoFornecedor = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        CType(Me.dtgProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgProdutos
        '
        Me.dtgProdutos.AllowUserToAddRows = False
        Me.dtgProdutos.AllowUserToResizeColumns = False
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgProdutos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle16
        Me.dtgProdutos.BackgroundColor = System.Drawing.Color.Gray
        Me.dtgProdutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgProdutos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dtgProdutos.ColumnHeadersHeight = 26
        Me.dtgProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idUsu, Me.DescricaoProd, Me.dtgFornecedor, Me.dtgComissaoForn, Me.dtgEstoque, Me.dtgValorAdicional})
        Me.dtgProdutos.Location = New System.Drawing.Point(26, 333)
        Me.dtgProdutos.Name = "dtgProdutos"
        Me.dtgProdutos.ReadOnly = True
        Me.dtgProdutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtgProdutos.RowHeadersWidth = 20
        Me.dtgProdutos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgProdutos.RowsDefaultCellStyle = DataGridViewCellStyle20
        Me.dtgProdutos.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dtgProdutos.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgProdutos.Size = New System.Drawing.Size(858, 168)
        Me.dtgProdutos.TabIndex = 126
        '
        'idUsu
        '
        Me.idUsu.HeaderText = "Id"
        Me.idUsu.MaxInputLength = 13
        Me.idUsu.Name = "idUsu"
        Me.idUsu.ReadOnly = True
        Me.idUsu.Visible = False
        '
        'DescricaoProd
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.DescricaoProd.DefaultCellStyle = DataGridViewCellStyle18
        Me.DescricaoProd.HeaderText = "Descrição"
        Me.DescricaoProd.MaxInputLength = 2
        Me.DescricaoProd.Name = "DescricaoProd"
        Me.DescricaoProd.ReadOnly = True
        Me.DescricaoProd.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DescricaoProd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DescricaoProd.Width = 300
        '
        'dtgFornecedor
        '
        Me.dtgFornecedor.HeaderText = "Fornecedor"
        Me.dtgFornecedor.Name = "dtgFornecedor"
        Me.dtgFornecedor.ReadOnly = True
        Me.dtgFornecedor.Width = 240
        '
        'dtgComissaoForn
        '
        Me.dtgComissaoForn.HeaderText = "Comissao do Fornecedor"
        Me.dtgComissaoForn.Name = "dtgComissaoForn"
        Me.dtgComissaoForn.ReadOnly = True
        Me.dtgComissaoForn.Width = 90
        '
        'dtgEstoque
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgEstoque.DefaultCellStyle = DataGridViewCellStyle19
        Me.dtgEstoque.HeaderText = "Estoque"
        Me.dtgEstoque.Name = "dtgEstoque"
        Me.dtgEstoque.ReadOnly = True
        Me.dtgEstoque.Width = 85
        '
        'dtgValorAdicional
        '
        Me.dtgValorAdicional.HeaderText = "Adicional"
        Me.dtgValorAdicional.Name = "dtgValorAdicional"
        Me.dtgValorAdicional.ReadOnly = True
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
        Me.btnImprimir.Location = New System.Drawing.Point(744, 264)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(136, 29)
        Me.btnImprimir.TabIndex = 555
        Me.btnImprimir.Text = "&Imprimir F11"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'txtIdProd
        '
        Me.txtIdProd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdProd.Location = New System.Drawing.Point(832, 12)
        Me.txtIdProd.MaxLength = 3
        Me.txtIdProd.Name = "txtIdProd"
        Me.txtIdProd.ReadOnly = True
        Me.txtIdProd.Size = New System.Drawing.Size(48, 21)
        Me.txtIdProd.TabIndex = 554
        Me.txtIdProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIdProd.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(285, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(305, 23)
        Me.Label1.TabIndex = 551
        Me.Label1.Text = ":: CADASTRO DE PRODUTOS ::"
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
        Me.btn_excluir.Location = New System.Drawing.Point(639, 264)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(91, 29)
        Me.btn_excluir.TabIndex = 550
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
        Me.btn_alterar.Location = New System.Drawing.Point(534, 264)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(91, 29)
        Me.btn_alterar.TabIndex = 549
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(200, 19)
        Me.Label7.TabIndex = 552
        Me.Label7.Text = "Descrição para Pesquisar:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtQuantidadeRegistros)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 295)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(858, 35)
        Me.GroupBox1.TabIndex = 553
        Me.GroupBox1.TabStop = False
        '
        'txtQuantidadeRegistros
        '
        Me.txtQuantidadeRegistros.BackColor = System.Drawing.SystemColors.Info
        Me.txtQuantidadeRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQuantidadeRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantidadeRegistros.ForeColor = System.Drawing.Color.Red
        Me.txtQuantidadeRegistros.Location = New System.Drawing.Point(765, 12)
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
        Me.Label10.Location = New System.Drawing.Point(698, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Registros:"
        '
        'txtPesquisaDescricao
        '
        Me.txtPesquisaDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPesquisaDescricao.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPesquisaDescricao.Location = New System.Drawing.Point(31, 68)
        Me.txtPesquisaDescricao.MaxLength = 60
        Me.txtPesquisaDescricao.Name = "txtPesquisaDescricao"
        Me.txtPesquisaDescricao.Size = New System.Drawing.Size(343, 27)
        Me.txtPesquisaDescricao.TabIndex = 548
        '
        'CboPesquisaFornecedor
        '
        Me.CboPesquisaFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPesquisaFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CboPesquisaFornecedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPesquisaFornecedor.FormattingEnabled = True
        Me.CboPesquisaFornecedor.Location = New System.Drawing.Point(391, 68)
        Me.CboPesquisaFornecedor.Name = "CboPesquisaFornecedor"
        Me.CboPesquisaFornecedor.Size = New System.Drawing.Size(274, 28)
        Me.CboPesquisaFornecedor.TabIndex = 556
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(387, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 19)
        Me.Label4.TabIndex = 557
        Me.Label4.Text = "Fornecedor:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(27, 103)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(857, 156)
        Me.TabControl1.TabIndex = 558
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtValorComissaoFornecedor)
        Me.TabPage1.Controls.Add(Me.mskDataEntrega)
        Me.TabPage1.Controls.Add(Me.mskDataSaida)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.mskDataEntrada)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.txtProdutoEstoque)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtValorAdicional)
        Me.TabPage1.Controls.Add(Me.CboValoresAdicionais)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtProdutoDescricao)
        Me.TabPage1.Controls.Add(Me.cboProdutoFornecedor)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(849, 124)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Dados do Produto:"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtValorComissaoFornecedor
        '
        Me.txtValorComissaoFornecedor.Location = New System.Drawing.Point(628, 30)
        Me.txtValorComissaoFornecedor.Name = "txtValorComissaoFornecedor"
        Me.txtValorComissaoFornecedor.Size = New System.Drawing.Size(115, 26)
        Me.txtValorComissaoFornecedor.TabIndex = 4
        Me.txtValorComissaoFornecedor.Text = "0,00"
        Me.txtValorComissaoFornecedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskDataEntrega
        '
        Me.mskDataEntrega.BackColor = System.Drawing.SystemColors.Info
        Me.mskDataEntrega.ForeColor = System.Drawing.Color.ForestGreen
        Me.mskDataEntrega.Location = New System.Drawing.Point(738, 91)
        Me.mskDataEntrega.Mask = "00/00/0000"
        Me.mskDataEntrega.Name = "mskDataEntrega"
        Me.mskDataEntrega.ReadOnly = True
        Me.mskDataEntrega.Size = New System.Drawing.Size(105, 26)
        Me.mskDataEntrega.TabIndex = 15
        Me.mskDataEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mskDataEntrega.ValidatingType = GetType(Date)
        '
        'mskDataSaida
        '
        Me.mskDataSaida.BackColor = System.Drawing.SystemColors.Info
        Me.mskDataSaida.ForeColor = System.Drawing.Color.Red
        Me.mskDataSaida.Location = New System.Drawing.Point(594, 91)
        Me.mskDataSaida.Mask = "00/00/0000"
        Me.mskDataSaida.Name = "mskDataSaida"
        Me.mskDataSaida.ReadOnly = True
        Me.mskDataSaida.Size = New System.Drawing.Size(105, 26)
        Me.mskDataSaida.TabIndex = 13
        Me.mskDataSaida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mskDataSaida.ValidatingType = GetType(Date)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(734, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 19)
        Me.Label12.TabIndex = 561
        Me.Label12.Text = "Dt. Entrega:"
        '
        'mskDataEntrada
        '
        Me.mskDataEntrada.BackColor = System.Drawing.SystemColors.Info
        Me.mskDataEntrada.Location = New System.Drawing.Point(454, 91)
        Me.mskDataEntrada.Mask = "00/00/0000"
        Me.mskDataEntrada.Name = "mskDataEntrada"
        Me.mskDataEntrada.ReadOnly = True
        Me.mskDataEntrada.Size = New System.Drawing.Size(105, 26)
        Me.mskDataEntrada.TabIndex = 11
        Me.mskDataEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mskDataEntrada.ValidatingType = GetType(Date)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(590, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 19)
        Me.Label11.TabIndex = 561
        Me.Label11.Text = "Dt. Saída:"
        '
        'txtProdutoEstoque
        '
        Me.txtProdutoEstoque.Location = New System.Drawing.Point(361, 92)
        Me.txtProdutoEstoque.Name = "txtProdutoEstoque"
        Me.txtProdutoEstoque.Size = New System.Drawing.Size(64, 26)
        Me.txtProdutoEstoque.TabIndex = 9
        Me.txtProdutoEstoque.Text = "1"
        Me.txtProdutoEstoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(450, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 19)
        Me.Label9.TabIndex = 561
        Me.Label9.Text = "Dt. Entrada:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(356, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 19)
        Me.Label8.TabIndex = 561
        Me.Label8.Text = "Estoque:"
        '
        'txtValorAdicional
        '
        Me.txtValorAdicional.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorAdicional.Location = New System.Drawing.Point(236, 91)
        Me.txtValorAdicional.Name = "txtValorAdicional"
        Me.txtValorAdicional.Size = New System.Drawing.Size(89, 26)
        Me.txtValorAdicional.TabIndex = 7
        Me.txtValorAdicional.Text = "0,00"
        Me.txtValorAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CboValoresAdicionais
        '
        Me.CboValoresAdicionais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboValoresAdicionais.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CboValoresAdicionais.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboValoresAdicionais.FormattingEnabled = True
        Me.CboValoresAdicionais.Location = New System.Drawing.Point(19, 89)
        Me.CboValoresAdicionais.Name = "CboValoresAdicionais"
        Me.CboValoresAdicionais.Size = New System.Drawing.Size(201, 27)
        Me.CboValoresAdicionais.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(232, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 19)
        Me.Label6.TabIndex = 559
        Me.Label6.Text = "Valor Adic.:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 19)
        Me.Label5.TabIndex = 559
        Me.Label5.Text = "Adicional:"
        '
        'txtProdutoDescricao
        '
        Me.txtProdutoDescricao.Location = New System.Drawing.Point(19, 30)
        Me.txtProdutoDescricao.Name = "txtProdutoDescricao"
        Me.txtProdutoDescricao.Size = New System.Drawing.Size(306, 26)
        Me.txtProdutoDescricao.TabIndex = 1
        '
        'cboProdutoFornecedor
        '
        Me.cboProdutoFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProdutoFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboProdutoFornecedor.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProdutoFornecedor.FormattingEnabled = True
        Me.cboProdutoFornecedor.Location = New System.Drawing.Point(360, 28)
        Me.cboProdutoFornecedor.Name = "cboProdutoFornecedor"
        Me.cboProdutoFornecedor.Size = New System.Drawing.Size(227, 27)
        Me.cboProdutoFornecedor.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(624, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(150, 19)
        Me.Label13.TabIndex = 557
        Me.Label13.Text = "Comiss. Fornecedor:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(356, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 19)
        Me.Label3.TabIndex = 557
        Me.Label3.Text = "Fornecedor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Descrição:"
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
        Me.btnSalvar.Location = New System.Drawing.Point(785, 97)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(95, 30)
        Me.btnSalvar.TabIndex = 570
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.UseVisualStyleBackColor = False
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
        Me.btnBuscar.Location = New System.Drawing.Point(679, 67)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(60, 30)
        Me.btnBuscar.TabIndex = 571
        Me.btnBuscar.Text = "F5"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'FormCadProduto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppDeEntrega.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(906, 510)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.CboPesquisaFornecedor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.txtIdProd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.btn_alterar)
        Me.Controls.Add(Me.txtPesquisaDescricao)
        Me.Controls.Add(Me.dtgProdutos)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCadProduto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Produto"
        CType(Me.dtgProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgProdutos As System.Windows.Forms.DataGridView
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents txtIdProd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtQuantidadeRegistros As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPesquisaDescricao As System.Windows.Forms.TextBox
    Friend WithEvents CboPesquisaFornecedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtProdutoDescricao As System.Windows.Forms.TextBox
    Friend WithEvents cboProdutoFornecedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboValoresAdicionais As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtValorAdicional As System.Windows.Forms.TextBox
    Friend WithEvents mskDataEntrega As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskDataSaida As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents mskDataEntrada As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtProdutoEstoque As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents idUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescricaoProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgFornecedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgComissaoForn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgEstoque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgValorAdicional As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtValorComissaoFornecedor As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents btnBuscar As System.Windows.Forms.Button
End Class
