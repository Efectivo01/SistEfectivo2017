<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGenerarTarjeta
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbTarjeta = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdGenerar = New System.Windows.Forms.Button()
        Me.pbCBP = New System.Windows.Forms.PictureBox()
        Me.lbApellidos = New System.Windows.Forms.Label()
        Me.cmdGenerarSMS = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        CType(Me.pbCBP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CLIENTE:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(111, 40)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(137, 26)
        Me.txtCliente.TabIndex = 1
        '
        'lbNombre
        '
        Me.lbNombre.Location = New System.Drawing.Point(264, 43)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(436, 21)
        Me.lbNombre.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "EMAIL:"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(111, 137)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(514, 26)
        Me.txtEmail.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "TARJETA:"
        '
        'lbTarjeta
        '
        Me.lbTarjeta.Location = New System.Drawing.Point(111, 176)
        Me.lbTarjeta.Name = "lbTarjeta"
        Me.lbTarjeta.Size = New System.Drawing.Size(137, 19)
        Me.lbTarjeta.TabIndex = 6
        '
        'cmdCancelar
        '
        Me.cmdCancelar.BackColor = System.Drawing.Color.Red
        Me.cmdCancelar.Location = New System.Drawing.Point(359, 199)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(104, 32)
        Me.cmdCancelar.TabIndex = 7
        Me.cmdCancelar.Text = "CANCELAR"
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'cmdGenerar
        '
        Me.cmdGenerar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdGenerar.Location = New System.Drawing.Point(469, 199)
        Me.cmdGenerar.Name = "cmdGenerar"
        Me.cmdGenerar.Size = New System.Drawing.Size(104, 54)
        Me.cmdGenerar.TabIndex = 8
        Me.cmdGenerar.Text = "GENERAR EMAIL"
        Me.cmdGenerar.UseVisualStyleBackColor = False
        '
        'pbCBP
        '
        Me.pbCBP.Location = New System.Drawing.Point(25, 209)
        Me.pbCBP.Name = "pbCBP"
        Me.pbCBP.Size = New System.Drawing.Size(83, 47)
        Me.pbCBP.TabIndex = 9
        Me.pbCBP.TabStop = False
        Me.pbCBP.Visible = False
        '
        'lbApellidos
        '
        Me.lbApellidos.Location = New System.Drawing.Point(264, 73)
        Me.lbApellidos.Name = "lbApellidos"
        Me.lbApellidos.Size = New System.Drawing.Size(436, 21)
        Me.lbApellidos.TabIndex = 10
        '
        'cmdGenerarSMS
        '
        Me.cmdGenerarSMS.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdGenerarSMS.Location = New System.Drawing.Point(579, 199)
        Me.cmdGenerarSMS.Name = "cmdGenerarSMS"
        Me.cmdGenerarSMS.Size = New System.Drawing.Size(104, 54)
        Me.cmdGenerarSMS.TabIndex = 11
        Me.cmdGenerarSMS.Text = "GENERAR SMS"
        Me.cmdGenerarSMS.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 20)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "CELULAR:"
        '
        'txtCelular
        '
        Me.txtCelular.Location = New System.Drawing.Point(111, 103)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCelular.ReadOnly = True
        Me.txtCelular.Size = New System.Drawing.Size(195, 26)
        Me.txtCelular.TabIndex = 13
        '
        'frmGenerarTarjeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 265)
        Me.Controls.Add(Me.txtCelular)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdGenerarSMS)
        Me.Controls.Add(Me.lbApellidos)
        Me.Controls.Add(Me.pbCBP)
        Me.Controls.Add(Me.cmdGenerar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.lbTarjeta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbNombre)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmGenerarTarjeta"
        Me.Text = "Generar Tarjeta"
        CType(Me.pbCBP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents lbNombre As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lbTarjeta As Label
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdGenerar As Button
    Friend WithEvents pbCBP As PictureBox
    Friend WithEvents lbApellidos As Label
    Friend WithEvents cmdGenerarSMS As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCelular As TextBox
End Class
