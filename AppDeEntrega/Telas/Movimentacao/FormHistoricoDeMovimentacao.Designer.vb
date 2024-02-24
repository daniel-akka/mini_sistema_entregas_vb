<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHistoricoDeMovimentacao
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtgSaidaRelacao = New System.Windows.Forms.DataGridView()
        Me.dtg1_colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg1_colDataEntrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg1_entregador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg1_colProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg1_colquantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg1_colFornecedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CboEntregadorPesquisa = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dtpFim = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPesquisaDescricaoProduto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dtgSaidaRelacao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgSaidaRelacao
        '
        Me.dtgSaidaRelacao.AllowUserToAddRows = False
        Me.dtgSaidaRelacao.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgSaidaRelacao.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgSaidaRelacao.BackgroundColor = System.Drawing.Color.Gray
        Me.dtgSaidaRelacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgSaidaRelacao.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgSaidaRelacao.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgSaidaRelacao.ColumnHeadersHeight = 26
        Me.dtgSaidaRelacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgSaidaRelacao.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dtg1_colID, Me.dtg1_colDataEntrada, Me.dtg1_entregador, Me.dtg1_colProduto, Me.dtg1_colquantidade, Me.dtg1_colFornecedor})
        Me.dtgSaidaRelacao.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtgSaidaRelacao.Location = New System.Drawing.Point(0, 267)
        Me.dtgSaidaRelacao.Name = "dtgSaidaRelacao"
        Me.dtgSaidaRelacao.ReadOnly = True
        Me.dtgSaidaRelacao.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtgSaidaRelacao.RowHeadersWidth = 20
        Me.dtgSaidaRelacao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgSaidaRelacao.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dtgSaidaRelacao.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dtgSaidaRelacao.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgSaidaRelacao.Size = New System.Drawing.Size(870, 168)
        Me.dtgSaidaRelacao.TabIndex = 595
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dtg1_colDataEntrada.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtg1_colDataEntrada.HeaderText = "Data Saída"
        Me.dtg1_colDataEntrada.Name = "dtg1_colDataEntrada"
        Me.dtg1_colDataEntrada.ReadOnly = True
        Me.dtg1_colDataEntrada.Width = 130
        '
        'dtg1_entregador
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dtg1_entregador.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtg1_entregador.HeaderText = "Entregador"
        Me.dtg1_entregador.Name = "dtg1_entregador"
        Me.dtg1_entregador.ReadOnly = True
        Me.dtg1_entregador.Width = 170
        '
        'dtg1_colProduto
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtg1_colProduto.DefaultCellStyle = DataGridViewCellStyle5
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
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtg1_colquantidade.DefaultCellStyle = DataGridViewCellStyle6
        Me.dtg1_colquantidade.HeaderText = "Quantidade"
        Me.dtg1_colquantidade.Name = "dtg1_colquantidade"
        Me.dtg1_colquantidade.ReadOnly = True
        Me.dtg1_colquantidade.Width = 95
        '
        'dtg1_colFornecedor
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dtg1_colFornecedor.DefaultCellStyle = DataGridViewCellStyle7
        Me.dtg1_colFornecedor.HeaderText = "Fornecedor"
        Me.dtg1_colFornecedor.Name = "dtg1_colFornecedor"
        Me.dtg1_colFornecedor.ReadOnly = True
        Me.dtg1_colFornecedor.Width = 200
        '
        'CboEntregadorPesquisa
        '
        Me.CboEntregadorPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEntregadorPesquisa.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CboEntregadorPesquisa.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEntregadorPesquisa.FormattingEnabled = True
        Me.CboEntregadorPesquisa.Location = New System.Drawing.Point(453, 88)
        Me.CboEntregadorPesquisa.Name = "CboEntregadorPesquisa"
        Me.CboEntregadorPesquisa.Size = New System.Drawing.Size(253, 25)
        Me.CboEntregadorPesquisa.TabIndex = 599
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(449, 66)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 19)
        Me.Label16.TabIndex = 600
        Me.Label16.Text = "Entregador:"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.dtpFim)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.dtpInicio)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(17, 125)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(395, 60)
        Me.GroupBox4.TabIndex = 598
        Me.GroupBox4.TabStop = False
        '
        'dtpFim
        '
        Me.dtpFim.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFim.Location = New System.Drawing.Point(250, 22)
        Me.dtpFim.Name = "dtpFim"
        Me.dtpFim.Size = New System.Drawing.Size(126, 25)
        Me.dtpFim.TabIndex = 579
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 19)
        Me.Label2.TabIndex = 577
        Me.Label2.Text = "Período:"
        '
        'dtpInicio
        '
        Me.dtpInicio.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(92, 22)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(126, 25)
        Me.dtpInicio.TabIndex = 580
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(225, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 19)
        Me.Label3.TabIndex = 578
        Me.Label3.Text = "A"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(272, 19)
        Me.Label7.TabIndex = 597
        Me.Label7.Text = "Descrição do Produto para Pesquisar:"
        '
        'txtPesquisaDescricaoProduto
        '
        Me.txtPesquisaDescricaoProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPesquisaDescricaoProduto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPesquisaDescricaoProduto.Location = New System.Drawing.Point(17, 86)
        Me.txtPesquisaDescricaoProduto.MaxLength = 60
        Me.txtPesquisaDescricaoProduto.Name = "txtPesquisaDescricaoProduto"
        Me.txtPesquisaDescricaoProduto.Size = New System.Drawing.Size(395, 27)
        Me.txtPesquisaDescricaoProduto.TabIndex = 596
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Cambria", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(207, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(381, 23)
        Me.Label1.TabIndex = 577
        Me.Label1.Text = "Histórico de Movimentação dos Produtos"
        '
        'FormHistoricoDeMovimentacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppDeEntrega.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(870, 435)
        Me.Controls.Add(Me.dtgSaidaRelacao)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CboEntregadorPesquisa)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPesquisaDescricaoProduto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormHistoricoDeMovimentacao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Histórico de Movimentacao"
        CType(Me.dtgSaidaRelacao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgSaidaRelacao As System.Windows.Forms.DataGridView
    Friend WithEvents dtg1_colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg1_colDataEntrada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg1_entregador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg1_colProduto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg1_colquantidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg1_colFornecedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CboEntregadorPesquisa As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFim As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPesquisaDescricaoProduto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
