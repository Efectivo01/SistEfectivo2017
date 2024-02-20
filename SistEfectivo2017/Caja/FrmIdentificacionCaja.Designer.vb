<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIdentificacionCaja
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnNo = New System.Windows.Forms.Button()
        Me.BtnSi = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAncho2 = New System.Windows.Forms.Button()
        Me.btnAlto2 = New System.Windows.Forms.Button()
        Me.btnReinicio = New System.Windows.Forms.Button()
        Me.btnAncho = New System.Windows.Forms.Button()
        Me.btnAlto = New System.Windows.Forms.Button()
        Me.pkb6 = New System.Windows.Forms.PictureBox()
        Me.pkb5 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.pkb6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pkb5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnNo)
        Me.Panel1.Controls.Add(Me.BtnSi)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnAncho2)
        Me.Panel1.Controls.Add(Me.btnAlto2)
        Me.Panel1.Controls.Add(Me.btnReinicio)
        Me.Panel1.Controls.Add(Me.btnAncho)
        Me.Panel1.Controls.Add(Me.btnAlto)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 287)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1013, 39)
        Me.Panel1.TabIndex = 63
        '
        'BtnNo
        '
        Me.BtnNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.BtnNo.Location = New System.Drawing.Point(923, 2)
        Me.BtnNo.Name = "BtnNo"
        Me.BtnNo.Size = New System.Drawing.Size(85, 35)
        Me.BtnNo.TabIndex = 69
        Me.BtnNo.Text = "No"
        Me.BtnNo.UseVisualStyleBackColor = True
        '
        'BtnSi
        '
        Me.BtnSi.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.BtnSi.Location = New System.Drawing.Point(814, 2)
        Me.BtnSi.Name = "BtnSi"
        Me.BtnSi.Size = New System.Drawing.Size(85, 35)
        Me.BtnSi.TabIndex = 68
        Me.BtnSi.Text = "Si"
        Me.BtnSi.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(583, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 15)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "¿Es la Identificación del Cliente?"
        '
        'btnAncho2
        '
        Me.btnAncho2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btnAncho2.Location = New System.Drawing.Point(460, 2)
        Me.btnAncho2.Name = "btnAncho2"
        Me.btnAncho2.Size = New System.Drawing.Size(85, 35)
        Me.btnAncho2.TabIndex = 63
        Me.btnAncho2.Text = "-Ancho"
        Me.btnAncho2.UseVisualStyleBackColor = True
        '
        'btnAlto2
        '
        Me.btnAlto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btnAlto2.Location = New System.Drawing.Point(379, 2)
        Me.btnAlto2.Name = "btnAlto2"
        Me.btnAlto2.Size = New System.Drawing.Size(75, 35)
        Me.btnAlto2.TabIndex = 62
        Me.btnAlto2.Text = "-Alto"
        Me.btnAlto2.UseVisualStyleBackColor = True
        '
        'btnReinicio
        '
        Me.btnReinicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btnReinicio.Location = New System.Drawing.Point(287, 3)
        Me.btnReinicio.Name = "btnReinicio"
        Me.btnReinicio.Size = New System.Drawing.Size(86, 35)
        Me.btnReinicio.TabIndex = 60
        Me.btnReinicio.Text = "Reiniciar"
        Me.btnReinicio.UseVisualStyleBackColor = True
        '
        'btnAncho
        '
        Me.btnAncho.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btnAncho.Location = New System.Drawing.Point(195, 3)
        Me.btnAncho.Name = "btnAncho"
        Me.btnAncho.Size = New System.Drawing.Size(85, 35)
        Me.btnAncho.TabIndex = 58
        Me.btnAncho.Text = "+Ancho"
        Me.btnAncho.UseVisualStyleBackColor = True
        '
        'btnAlto
        '
        Me.btnAlto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btnAlto.Location = New System.Drawing.Point(114, 3)
        Me.btnAlto.Name = "btnAlto"
        Me.btnAlto.Size = New System.Drawing.Size(75, 35)
        Me.btnAlto.TabIndex = 57
        Me.btnAlto.Text = "+Alto"
        Me.btnAlto.UseVisualStyleBackColor = True
        '
        'pkb6
        '
        Me.pkb6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pkb6.Location = New System.Drawing.Point(507, -2)
        Me.pkb6.Name = "pkb6"
        Me.pkb6.Size = New System.Drawing.Size(507, 284)
        Me.pkb6.TabIndex = 62
        Me.pkb6.TabStop = False
        '
        'pkb5
        '
        Me.pkb5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pkb5.Location = New System.Drawing.Point(0, -2)
        Me.pkb5.Name = "pkb5"
        Me.pkb5.Size = New System.Drawing.Size(507, 284)
        Me.pkb5.TabIndex = 61
        Me.pkb5.TabStop = False
        '
        'FrmIdentificacionCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 326)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pkb6)
        Me.Controls.Add(Me.pkb5)
        Me.Name = "FrmIdentificacionCaja"
        Me.Text = "FrmIdentificacionCaja"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pkb6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pkb5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnNo As System.Windows.Forms.Button
    Friend WithEvents BtnSi As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAncho2 As System.Windows.Forms.Button
    Friend WithEvents btnAlto2 As System.Windows.Forms.Button
    Friend WithEvents btnReinicio As System.Windows.Forms.Button
    Friend WithEvents btnAncho As System.Windows.Forms.Button
    Friend WithEvents btnAlto As System.Windows.Forms.Button
    Friend WithEvents pkb6 As System.Windows.Forms.PictureBox
    Friend WithEvents pkb5 As System.Windows.Forms.PictureBox
End Class
