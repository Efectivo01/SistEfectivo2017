<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVerificacionAut
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.vbtnVerificacion = New VIBlend.WinForms.Controls.vButton()
        Me.vBtnCancelar = New VIBlend.WinForms.Controls.vButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(462, 51)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ESPERANDO AUTORIZACIÓN. HACER UN CLIC EN EL BOTÓN DE VERIFICAR"
        '
        'vbtnVerificacion
        '
        Me.vbtnVerificacion.AllowAnimations = True
        Me.vbtnVerificacion.BackColor = System.Drawing.Color.Transparent
        Me.vbtnVerificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vbtnVerificacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.vbtnVerificacion.Location = New System.Drawing.Point(104, 98)
        Me.vbtnVerificacion.Name = "vbtnVerificacion"
        Me.vbtnVerificacion.RoundedCornersMask = CType(15, Byte)
        Me.vbtnVerificacion.Size = New System.Drawing.Size(111, 44)
        Me.vbtnVerificacion.TabIndex = 103
        Me.vbtnVerificacion.Text = "VERIFICAR"
        Me.vbtnVerificacion.TextWrap = True
        Me.vbtnVerificacion.UseThemeTextColor = False
        Me.vbtnVerificacion.UseVisualStyleBackColor = False
        Me.vbtnVerificacion.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
        '
        'vBtnCancelar
        '
        Me.vBtnCancelar.AllowAnimations = True
        Me.vBtnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.vBtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vBtnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.vBtnCancelar.Location = New System.Drawing.Point(310, 98)
        Me.vBtnCancelar.Name = "vBtnCancelar"
        Me.vBtnCancelar.RoundedCornersMask = CType(15, Byte)
        Me.vBtnCancelar.Size = New System.Drawing.Size(111, 44)
        Me.vBtnCancelar.TabIndex = 104
        Me.vBtnCancelar.Text = "CANCELAR"
        Me.vBtnCancelar.TextWrap = True
        Me.vBtnCancelar.UseThemeTextColor = False
        Me.vBtnCancelar.UseVisualStyleBackColor = False
        Me.vBtnCancelar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
        '
        'FrmVerificacionAut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 175)
        Me.ControlBox = False
        Me.Controls.Add(Me.vBtnCancelar)
        Me.Controls.Add(Me.vbtnVerificacion)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmVerificacionAut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cliente de ALTO riesgo"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents vbtnVerificacion As VIBlend.WinForms.Controls.vButton
    Friend WithEvents vBtnCancelar As VIBlend.WinForms.Controls.vButton
End Class
