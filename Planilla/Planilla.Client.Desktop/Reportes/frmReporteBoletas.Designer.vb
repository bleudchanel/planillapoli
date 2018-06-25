<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReporteBoletas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dsBoletas = New Planilla.Client.Desktop.dsBoletas()
        Me.dtBoletasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dsBoletas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtBoletasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.dtBoletasBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Planilla.Client.Desktop.Boletas.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(897, 634)
        Me.ReportViewer1.TabIndex = 0
        '
        'dsBoletas
        '
        Me.dsBoletas.DataSetName = "dsBoletas"
        Me.dsBoletas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtBoletasBindingSource
        '
        Me.dtBoletasBindingSource.DataMember = "dtBoletas"
        Me.dtBoletasBindingSource.DataSource = Me.dsBoletas
        '
        'frmReporteBoletas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 634)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmReporteBoletas"
        Me.Text = "frmReporteBoletas"
        CType(Me.dsBoletas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtBoletasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtBoletasBindingSource As BindingSource
    Friend WithEvents dsBoletas As dsBoletas
End Class
