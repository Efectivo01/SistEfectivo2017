<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpNota
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.crReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crReporte
        '
        Me.crReporte.ActiveViewIndex = -1
        Me.crReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crReporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.crReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crReporte.Location = New System.Drawing.Point(0, 0)
        Me.crReporte.Name = "crReporte"
        Me.crReporte.ShowCopyButton = False
        Me.crReporte.ShowExportButton = False
        Me.crReporte.ShowGotoPageButton = False
        Me.crReporte.ShowGroupTreeButton = False
        Me.crReporte.ShowLogo = False
        Me.crReporte.ShowPageNavigateButtons = False
        Me.crReporte.ShowParameterPanelButton = False
        Me.crReporte.ShowRefreshButton = False
        Me.crReporte.ShowTextSearchButton = False
        Me.crReporte.ShowZoomButton = False
        Me.crReporte.Size = New System.Drawing.Size(650, 521)
        Me.crReporte.TabIndex = 0
        Me.crReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frmImpNota
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 521)
        Me.Controls.Add(Me.crReporte)
        Me.Name = "frmImpNota"
        Me.Text = "Impresion Nota"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents crReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
