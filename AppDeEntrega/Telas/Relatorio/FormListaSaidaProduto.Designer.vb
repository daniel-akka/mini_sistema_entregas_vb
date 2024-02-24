<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaSaidaProduto
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
        Me.rpvListaSaidaProduto = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SaidaDeProdutosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.SaidaDeProdutosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvListaSaidaProduto
        '
        Me.rpvListaSaidaProduto.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DSSaidaProdutos"
        ReportDataSource1.Value = Me.SaidaDeProdutosBindingSource
        Me.rpvListaSaidaProduto.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvListaSaidaProduto.LocalReport.ReportEmbeddedResource = "AppDeEntrega.RelatorioListaSaidaProduto.rdlc"
        Me.rpvListaSaidaProduto.Location = New System.Drawing.Point(0, 0)
        Me.rpvListaSaidaProduto.Name = "rpvListaSaidaProduto"
        Me.rpvListaSaidaProduto.Size = New System.Drawing.Size(667, 413)
        Me.rpvListaSaidaProduto.TabIndex = 0
        '
        'SaidaDeProdutosBindingSource
        '
        Me.SaidaDeProdutosBindingSource.DataSource = GetType(AppDeEntrega.SaidaDeProdutos)
        '
        'FormListaSaidaProduto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 413)
        Me.Controls.Add(Me.rpvListaSaidaProduto)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FormListaSaidaProduto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Saídas de Produtos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SaidaDeProdutosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvListaSaidaProduto As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents SaidaDeProdutosBindingSource As System.Windows.Forms.BindingSource
End Class
