<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRelatorioFinanceiro
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDataInicial = New System.Windows.Forms.DateTimePicker()
        Me.dtpDataFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTotalEntradas = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSaldoFinal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalSaídas = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtgRelatorioFinanceiro = New System.Windows.Forms.DataGridView()
        Me.dtgRelCol1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg1_entregador_forn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg1_colObservacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg1_colvalor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgRelatorioFinanceiro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 19)
        Me.Label2.TabIndex = 581
        Me.Label2.Text = "Período:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(245, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 19)
        Me.Label3.TabIndex = 582
        Me.Label3.Text = "A"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 19)
        Me.Label1.TabIndex = 581
        Me.Label1.Text = "Filtros:                          "
        '
        'dtpDataInicial
        '
        Me.dtpDataInicial.Font = New System.Drawing.Font("Cambria", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataInicial.Location = New System.Drawing.Point(107, 70)
        Me.dtpDataInicial.Name = "dtpDataInicial"
        Me.dtpDataInicial.Size = New System.Drawing.Size(132, 25)
        Me.dtpDataInicial.TabIndex = 583
        '
        'dtpDataFinal
        '
        Me.dtpDataFinal.Font = New System.Drawing.Font("Cambria", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataFinal.Location = New System.Drawing.Point(270, 69)
        Me.dtpDataFinal.Name = "dtpDataFinal"
        Me.dtpDataFinal.Size = New System.Drawing.Size(132, 25)
        Me.dtpDataFinal.TabIndex = 583
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Cambria", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(197, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(269, 23)
        Me.Label4.TabIndex = 581
        Me.Label4.Text = ":: RELATÓRIO FINANCEIRO ::"
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
        Me.btnBuscar.Location = New System.Drawing.Point(560, 61)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(135, 34)
        Me.btnBuscar.TabIndex = 584
        Me.btnBuscar.Text = "Consultar F5"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtTotalEntradas)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtSaldoFinal)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtTotalSaídas)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 156)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(718, 49)
        Me.GroupBox1.TabIndex = 585
        Me.GroupBox1.TabStop = False
        '
        'txtTotalEntradas
        '
        Me.txtTotalEntradas.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalEntradas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalEntradas.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtTotalEntradas.Location = New System.Drawing.Point(249, 16)
        Me.txtTotalEntradas.MaxLength = 4
        Me.txtTotalEntradas.Name = "txtTotalEntradas"
        Me.txtTotalEntradas.ReadOnly = True
        Me.txtTotalEntradas.Size = New System.Drawing.Size(85, 24)
        Me.txtTotalEntradas.TabIndex = 1
        Me.txtTotalEntradas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(182, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Entradas:"
        '
        'txtSaldoFinal
        '
        Me.txtSaldoFinal.BackColor = System.Drawing.SystemColors.Info
        Me.txtSaldoFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoFinal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtSaldoFinal.Location = New System.Drawing.Point(610, 14)
        Me.txtSaldoFinal.MaxLength = 4
        Me.txtSaldoFinal.Name = "txtSaldoFinal"
        Me.txtSaldoFinal.ReadOnly = True
        Me.txtSaldoFinal.Size = New System.Drawing.Size(85, 24)
        Me.txtSaldoFinal.TabIndex = 1
        Me.txtSaldoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(530, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Saldo Final:"
        '
        'txtTotalSaídas
        '
        Me.txtTotalSaídas.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalSaídas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSaídas.ForeColor = System.Drawing.Color.Red
        Me.txtTotalSaídas.Location = New System.Drawing.Point(421, 16)
        Me.txtTotalSaídas.MaxLength = 4
        Me.txtTotalSaídas.Name = "txtTotalSaídas"
        Me.txtTotalSaídas.ReadOnly = True
        Me.txtTotalSaídas.Size = New System.Drawing.Size(85, 24)
        Me.txtTotalSaídas.TabIndex = 1
        Me.txtTotalSaídas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(354, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Saídas:"
        '
        'dtgRelatorioFinanceiro
        '
        Me.dtgRelatorioFinanceiro.AllowUserToAddRows = False
        Me.dtgRelatorioFinanceiro.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgRelatorioFinanceiro.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgRelatorioFinanceiro.BackgroundColor = System.Drawing.Color.Gray
        Me.dtgRelatorioFinanceiro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgRelatorioFinanceiro.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgRelatorioFinanceiro.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgRelatorioFinanceiro.ColumnHeadersHeight = 26
        Me.dtgRelatorioFinanceiro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgRelatorioFinanceiro.ColumnHeadersVisible = False
        Me.dtgRelatorioFinanceiro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dtgRelCol1, Me.dtg1_entregador_forn, Me.dtg1_colObservacao, Me.dtg1_colvalor})
        Me.dtgRelatorioFinanceiro.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtgRelatorioFinanceiro.Location = New System.Drawing.Point(0, 205)
        Me.dtgRelatorioFinanceiro.Name = "dtgRelatorioFinanceiro"
        Me.dtgRelatorioFinanceiro.ReadOnly = True
        Me.dtgRelatorioFinanceiro.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtgRelatorioFinanceiro.RowHeadersVisible = False
        Me.dtgRelatorioFinanceiro.RowHeadersWidth = 20
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgRelatorioFinanceiro.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dtgRelatorioFinanceiro.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgRelatorioFinanceiro.Size = New System.Drawing.Size(718, 210)
        Me.dtgRelatorioFinanceiro.TabIndex = 586
        '
        'dtgRelCol1
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dtgRelCol1.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgRelCol1.HeaderText = "Relatório/Data"
        Me.dtgRelCol1.Name = "dtgRelCol1"
        Me.dtgRelCol1.ReadOnly = True
        Me.dtgRelCol1.Width = 200
        '
        'dtg1_entregador_forn
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dtg1_entregador_forn.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtg1_entregador_forn.HeaderText = "Fornecedor/Entregador"
        Me.dtg1_entregador_forn.Name = "dtg1_entregador_forn"
        Me.dtg1_entregador_forn.ReadOnly = True
        Me.dtg1_entregador_forn.Width = 200
        '
        'dtg1_colObservacao
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtg1_colObservacao.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtg1_colObservacao.HeaderText = "Observação"
        Me.dtg1_colObservacao.MaxInputLength = 2
        Me.dtg1_colObservacao.Name = "dtg1_colObservacao"
        Me.dtg1_colObservacao.ReadOnly = True
        Me.dtg1_colObservacao.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg1_colObservacao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dtg1_colObservacao.Width = 200
        '
        'dtg1_colvalor
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtg1_colvalor.DefaultCellStyle = DataGridViewCellStyle6
        Me.dtg1_colvalor.HeaderText = "Valor R$"
        Me.dtg1_colvalor.Name = "dtg1_colvalor"
        Me.dtg1_colvalor.ReadOnly = True
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
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(560, 101)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(135, 46)
        Me.btnImprimir.TabIndex = 587
        Me.btnImprimir.Text = "&Imprimir F11"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'FormRelatorioFinanceiro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppDeEntrega.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(718, 415)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtgRelatorioFinanceiro)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.dtpDataFinal)
        Me.Controls.Add(Me.dtpDataInicial)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRelatorioFinanceiro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatório Financeiro"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtgRelatorioFinanceiro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDataInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDataFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalEntradas As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSaídas As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtgRelatorioFinanceiro As System.Windows.Forms.DataGridView
    Friend WithEvents dtgRelCol1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg1_entregador_forn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg1_colObservacao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg1_colvalor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
End Class
