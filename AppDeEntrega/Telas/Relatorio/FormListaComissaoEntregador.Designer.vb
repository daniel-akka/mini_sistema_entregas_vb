<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaComissaoEntregador
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
        Me.rpvListaComissoesEntregador = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.PagamentoComissaoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.PagamentoComissaoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvListaComissoesEntregador
        '
        Me.rpvListaComissoesEntregador.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DSComissoesEntregador"
        ReportDataSource1.Value = Me.PagamentoComissaoBindingSource
        Me.rpvListaComissoesEntregador.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvListaComissoesEntregador.LocalReport.ReportEmbeddedResource = "AppDeEntrega.RelatorioListaComissoesEntregador.rdlc"
        Me.rpvListaComissoesEntregador.Location = New System.Drawing.Point(0, 0)
        Me.rpvListaComissoesEntregador.Name = "rpvListaComissoesEntregador"
        Me.rpvListaComissoesEntregador.Size = New System.Drawing.Size(701, 507)
        Me.rpvListaComissoesEntregador.TabIndex = 0
        '
        'PagamentoComissaoBindingSource
        '
        Me.PagamentoComissaoBindingSource.DataSource = GetType(AppDeEntrega.PagamentoComissao)
        '
        'FormListaComissaoEntregador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 507)
        Me.Controls.Add(Me.rpvListaComissoesEntregador)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FormListaComissaoEntregador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Comissões Por Entregador"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PagamentoComissaoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvListaComissoesEntregador As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PagamentoComissaoBindingSource As System.Windows.Forms.BindingSource
End Class
