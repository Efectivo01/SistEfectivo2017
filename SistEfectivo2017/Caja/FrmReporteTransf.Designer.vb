<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporteTransf
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
        Me.crvRptTrans = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvRptTrans
        '
        Me.crvRptTrans.ActiveViewIndex = -1
        Me.crvRptTrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvRptTrans.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvRptTrans.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvRptTrans.Location = New System.Drawing.Point(0, 0)
        Me.crvRptTrans.Name = "crvRptTrans"
        Me.crvRptTrans.Size = New System.Drawing.Size(629, 565)
        Me.crvRptTrans.TabIndex = 0
        Me.crvRptTrans.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'FrmReporteTransf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 565)
        Me.Controls.Add(Me.crvRptTrans)
        Me.Name = "FrmReporteTransf"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmReporteTransf"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvRptTrans As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
