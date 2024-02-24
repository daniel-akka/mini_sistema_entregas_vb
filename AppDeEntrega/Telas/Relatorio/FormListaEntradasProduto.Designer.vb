<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaEntradasProduto
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
        Me.rpvListaEntradaProdutos = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.EntradaDeProdutosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.EntradaDeProdutosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvListaEntradaProdutos
        '
        Me.rpvListaEntradaProdutos.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DSEntradaProdutos"
        ReportDataSource1.Value = Me.EntradaDeProdutosBindingSource
        Me.rpvListaEntradaProdutos.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvListaEntradaProdutos.LocalReport.ReportEmbeddedResource = "AppDeEntrega.RelatorioListaEntradaProdutos.rdlc"
        Me.rpvListaEntradaProdutos.Location = New System.Drawing.Point(0, 0)
        Me.rpvListaEntradaProdutos.Name = "rpvListaEntradaProdutos"
        Me.rpvListaEntradaProdutos.Size = New System.Drawing.Size(613, 411)
        Me.rpvListaEntradaProdutos.TabIndex = 0
        '
        'EntradaDeProdutosBindingSource
        '
        Me.EntradaDeProdutosBindingSource.DataSource = GetType(AppDeEntrega.EntradaDeProdutos)
        '
        'FormListaEntradasProduto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 411)
        Me.Controls.Add(Me.rpvListaEntradaProdutos)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FormListaEntradasProduto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Entrada de Produtos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.EntradaDeProdutosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvListaEntradaProdutos As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents EntradaDeProdutosBindingSource As System.Windows.Forms.BindingSource
End Class
