<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaRecebimentoFornecedor
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
        Me.rpvListaRecebimentoFornecedor = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.PagamentoComissaoFornecedorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.PagamentoComissaoFornecedorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvListaRecebimentoFornecedor
        '
        Me.rpvListaRecebimentoFornecedor.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DSRecebimentoComissaoFornecedor"
        ReportDataSource1.Value = Me.PagamentoComissaoFornecedorBindingSource
        Me.rpvListaRecebimentoFornecedor.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvListaRecebimentoFornecedor.LocalReport.ReportEmbeddedResource = "AppDeEntrega.RelatorioListaRecebimentoFornecedor.rdlc"
        Me.rpvListaRecebimentoFornecedor.Location = New System.Drawing.Point(0, 0)
        Me.rpvListaRecebimentoFornecedor.Name = "rpvListaRecebimentoFornecedor"
        Me.rpvListaRecebimentoFornecedor.Size = New System.Drawing.Size(701, 507)
        Me.rpvListaRecebimentoFornecedor.TabIndex = 0
        '
        'PagamentoComissaoFornecedorBindingSource
        '
        Me.PagamentoComissaoFornecedorBindingSource.DataSource = GetType(AppDeEntrega.PagamentoComissaoFornecedor)
        '
        'FormListaRecebimentoFornecedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 507)
        Me.Controls.Add(Me.rpvListaRecebimentoFornecedor)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FormListaRecebimentoFornecedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recebimentos do Fornecedor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PagamentoComissaoFornecedorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvListaRecebimentoFornecedor As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PagamentoComissaoFornecedorBindingSource As System.Windows.Forms.BindingSource
End Class
