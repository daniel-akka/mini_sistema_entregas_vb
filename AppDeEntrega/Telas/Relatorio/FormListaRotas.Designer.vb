<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaRotas
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
        Me.rpvListaRotas = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.RotaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.RotaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvListaRotas
        '
        Me.rpvListaRotas.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DSListaRotas"
        ReportDataSource1.Value = Me.RotaBindingSource
        Me.rpvListaRotas.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvListaRotas.LocalReport.ReportEmbeddedResource = "AppDeEntrega.RelatorioListaRotas.rdlc"
        Me.rpvListaRotas.Location = New System.Drawing.Point(0, 0)
        Me.rpvListaRotas.Name = "rpvListaRotas"
        Me.rpvListaRotas.Size = New System.Drawing.Size(701, 507)
        Me.rpvListaRotas.TabIndex = 0
        '
        'RotaBindingSource
        '
        Me.RotaBindingSource.DataSource = GetType(AppDeEntrega.Rota)
        '
        'FormListaRotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 507)
        Me.Controls.Add(Me.rpvListaRotas)
        Me.MinimizeBox = False
        Me.Name = "FormListaRotas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Rotas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RotaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvListaRotas As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents RotaBindingSource As System.Windows.Forms.BindingSource
End Class
