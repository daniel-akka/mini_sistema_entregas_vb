<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaDespesasMensal
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ClDespesaMensalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rpvListaDespesasMensal = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.ClDespesaMensalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ClDespesaMensalBindingSource
        '
        Me.ClDespesaMensalBindingSource.DataSource = GetType(AppDeEntrega.ClDespesaMensal)
        '
        'rpvListaDespesasMensal
        '
        Me.rpvListaDespesasMensal.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DespesaMensalImpressaoDS"
        ReportDataSource1.Value = Me.ClDespesaMensalBindingSource
        Me.rpvListaDespesasMensal.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvListaDespesasMensal.LocalReport.ReportEmbeddedResource = "AppDeEntrega.RelatorioListaDespesasMensal.rdlc"
        Me.rpvListaDespesasMensal.Location = New System.Drawing.Point(0, 0)
        Me.rpvListaDespesasMensal.Name = "rpvListaDespesasMensal"
        Me.rpvListaDespesasMensal.Size = New System.Drawing.Size(701, 507)
        Me.rpvListaDespesasMensal.TabIndex = 0
        '
        'FormListaDespesasMensal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 507)
        Me.Controls.Add(Me.rpvListaDespesasMensal)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormListaDespesasMensal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Despesas Mensal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClDespesaMensalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvListaDespesasMensal As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClDespesaMensalBindingSource As System.Windows.Forms.BindingSource
End Class
