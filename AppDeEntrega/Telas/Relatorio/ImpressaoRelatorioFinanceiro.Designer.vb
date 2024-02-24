<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpressaoRelatorioFinanceiro
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
        Me.rpvRelatorioFinanceiro = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.RelatorioFluxoFinanceiroBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.RelatorioFluxoFinanceiroBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvRelatorioFinanceiro
        '
        Me.rpvRelatorioFinanceiro.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DSRelatorioFinanceiro"
        ReportDataSource1.Value = Me.RelatorioFluxoFinanceiroBindingSource
        Me.rpvRelatorioFinanceiro.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvRelatorioFinanceiro.LocalReport.ReportEmbeddedResource = "AppDeEntrega.RelatorioFinanceiro.rdlc"
        Me.rpvRelatorioFinanceiro.Location = New System.Drawing.Point(0, 0)
        Me.rpvRelatorioFinanceiro.Name = "rpvRelatorioFinanceiro"
        Me.rpvRelatorioFinanceiro.Size = New System.Drawing.Size(569, 383)
        Me.rpvRelatorioFinanceiro.TabIndex = 0
        '
        'RelatorioFluxoFinanceiroBindingSource
        '
        Me.RelatorioFluxoFinanceiroBindingSource.DataSource = GetType(AppDeEntrega.RelatorioFluxoFinanceiro)
        '
        'ImpressaoRelatorioFinanceiro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 383)
        Me.Controls.Add(Me.rpvRelatorioFinanceiro)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "ImpressaoRelatorioFinanceiro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatório Financeiro Por Período"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RelatorioFluxoFinanceiroBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvRelatorioFinanceiro As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents RelatorioFluxoFinanceiroBindingSource As System.Windows.Forms.BindingSource
End Class
