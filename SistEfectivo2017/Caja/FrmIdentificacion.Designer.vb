<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIdentificacion
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
        Me.pkb6 = New System.Windows.Forms.PictureBox()
        Me.pkb5 = New System.Windows.Forms.PictureBox()
        Me.btnCopia = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAncho2 = New System.Windows.Forms.Button()
        Me.btnAlto2 = New System.Windows.Forms.Button()
        Me.btnReinicio = New System.Windows.Forms.Button()
        Me.btnAncho = New System.Windows.Forms.Button()
        Me.btnAlto = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.pkb6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pkb5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pkb6
        '
        Me.pkb6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pkb6.Location = New System.Drawing.Point(507, -1)
        Me.pkb6.Name = "pkb6"
        Me.pkb6.Size = New System.Drawing.Size(507, 284)
        Me.pkb6.TabIndex = 59
        Me.pkb6.TabStop = False
        '
        'pkb5
        '
        Me.pkb5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pkb5.Location = New System.Drawing.Point(0, -1)
        Me.pkb5.Name = "pkb5"
        Me.pkb5.Size = New System.Drawing.Size(507, 284)
        Me.pkb5.TabIndex = 58
        Me.pkb5.TabStop = False
        '
        'btnCopia
        '
        Me.btnCopia.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btnCopia.Location = New System.Drawing.Point(292, 3)
        Me.btnCopia.Name = "btnCopia"
        Me.btnCopia.Size = New System.Drawing.Size(75, 35)
        Me.btnCopia.TabIndex = 67
        Me.btnCopia.Text = "Copiar"
        Me.btnCopia.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Button2.Location = New System.Drawing.Point(210, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 35)
        Me.Button2.TabIndex = 66
        Me.Button2.Text = "LadoB"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Button1.Location = New System.Drawing.Point(104, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 35)
        Me.Button1.TabIndex = 65
        Me.Button1.Text = "LadoA"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btnSalir.Location = New System.Drawing.Point(899, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(85, 35)
        Me.btnSalir.TabIndex = 64
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnAncho2
        '
        Me.btnAncho2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btnAncho2.Location = New System.Drawing.Point(807, 2)
        Me.btnAncho2.Name = "btnAncho2"
        Me.btnAncho2.Size = New System.Drawing.Size(85, 35)
        Me.btnAncho2.TabIndex = 63
        Me.btnAncho2.Text = "-Ancho"
        Me.btnAncho2.UseVisualStyleBackColor = True
        '
        'btnAlto2
        '
        Me.btnAlto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btnAlto2.Location = New System.Drawing.Point(726, 2)
        Me.btnAlto2.Name = "btnAlto2"
        Me.btnAlto2.Size = New System.Drawing.Size(75, 35)
        Me.btnAlto2.TabIndex = 62
        Me.btnAlto2.Text = "-Alto"
        Me.btnAlto2.UseVisualStyleBackColor = True
        '
        'btnReinicio
        '
        Me.btnReinicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btnReinicio.Location = New System.Drawing.Point(634, 3)
        Me.btnReinicio.Name = "btnReinicio"
        Me.btnReinicio.Size = New System.Drawing.Size(86, 35)
        Me.btnReinicio.TabIndex = 60
        Me.btnReinicio.Text = "Reiniciar"
        Me.btnReinicio.UseVisualStyleBackColor = True
        '
        'btnAncho
        '
        Me.btnAncho.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btnAncho.Location = New System.Drawing.Point(542, 3)
        Me.btnAncho.Name = "btnAncho"
        Me.btnAncho.Size = New System.Drawing.Size(85, 35)
        Me.btnAncho.TabIndex = 58
        Me.btnAncho.Text = "+Ancho"
        Me.btnAncho.UseVisualStyleBackColor = True
        '
        'btnAlto
        '
        Me.btnAlto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btnAlto.Location = New System.Drawing.Point(461, 3)
        Me.btnAlto.Name = "btnAlto"
        Me.btnAlto.Size = New System.Drawing.Size(75, 35)
        Me.btnAlto.TabIndex = 57
        Me.btnAlto.Text = "+Alto"
        Me.btnAlto.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCopia)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.btnAncho2)
        Me.Panel1.Controls.Add(Me.btnAlto2)
        Me.Panel1.Controls.Add(Me.btnReinicio)
        Me.Panel1.Controls.Add(Me.btnAncho)
        Me.Panel1.Controls.Add(Me.btnAlto)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 285)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1016, 39)
        Me.Panel1.TabIndex = 60
        '
        'FrmIdentificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 324)
        Me.Controls.Add(Me.pkb6)
        Me.Controls.Add(Me.pkb5)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmIdentificacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmIdentificacion"
        CType(Me.pkb6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pkb5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pkb6 As System.Windows.Forms.PictureBox
    Friend WithEvents pkb5 As System.Windows.Forms.PictureBox
    Friend WithEvents btnCopia As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnAncho2 As System.Windows.Forms.Button
    Friend WithEvents btnAlto2 As System.Windows.Forms.Button
    Friend WithEvents btnReinicio As System.Windows.Forms.Button
    Friend WithEvents btnAncho As System.Windows.Forms.Button
    Friend WithEvents btnAlto As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
