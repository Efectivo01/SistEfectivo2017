<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLoguin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLoguin))
        Me.lblSucursal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pkb4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.vtxtPass = New VIBlend.WinForms.Controls.vTextBox()
        Me.vbtnSalir = New VIBlend.WinForms.Controls.vButton()
        Me.vbtnAceptar = New VIBlend.WinForms.Controls.vButton()
        Me.vlblPass = New VIBlend.WinForms.Controls.vLabel()
        Me.vlblUser = New VIBlend.WinForms.Controls.vLabel()
        Me.vtxtUser = New VIBlend.WinForms.Controls.vTextBox()
        CType(Me.pkb4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSucursal
        '
        Me.lblSucursal.BackColor = System.Drawing.Color.Green
        Me.lblSucursal.Font = New System.Drawing.Font("Modern No. 20", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSucursal.ForeColor = System.Drawing.Color.Gold
        Me.lblSucursal.Location = New System.Drawing.Point(404, 81)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(123, 37)
        Me.lblSucursal.TabIndex = 79
        Me.lblSucursal.Text = "Sucursal"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Font = New System.Drawing.Font("Modern No. 20", 23.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gold
        Me.Label1.Location = New System.Drawing.Point(14, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(525, 32)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Centro Cambiario Meritrade S.A. de C.V."
        '
        'pkb4
        '
        Me.pkb4.BackColor = System.Drawing.Color.Green
        Me.pkb4.BackgroundImage = CType(resources.GetObject("pkb4.BackgroundImage"), System.Drawing.Image)
        Me.pkb4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pkb4.Location = New System.Drawing.Point(0, 40)
        Me.pkb4.Name = "pkb4"
        Me.pkb4.Size = New System.Drawing.Size(46, 31)
        Me.pkb4.TabIndex = 77
        Me.pkb4.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(404, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(123, 54)
        Me.PictureBox1.TabIndex = 75
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(540, 62)
        Me.PictureBox2.TabIndex = 76
        Me.PictureBox2.TabStop = False
        '
        'vtxtPass
        '
        Me.vtxtPass.BackColor = System.Drawing.Color.White
        Me.vtxtPass.BoundsOffset = New System.Drawing.Size(1, 1)
        Me.vtxtPass.ControlBorderColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.vtxtPass.DefaultText = ""
        Me.vtxtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.vtxtPass.Location = New System.Drawing.Point(226, 127)
        Me.vtxtPass.MaxLength = 32767
        Me.vtxtPass.Name = "vtxtPass"
        Me.vtxtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.vtxtPass.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vtxtPass.SelectionLength = 0
        Me.vtxtPass.SelectionStart = 0
        Me.vtxtPass.Size = New System.Drawing.Size(145, 29)
        Me.vtxtPass.TabIndex = 83
        Me.vtxtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.vtxtPass.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'vbtnSalir
        '
        Me.vbtnSalir.AllowAnimations = True
        Me.vbtnSalir.BackColor = System.Drawing.Color.Transparent
        Me.vbtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.vbtnSalir.Location = New System.Drawing.Point(279, 196)
        Me.vbtnSalir.Name = "vbtnSalir"
        Me.vbtnSalir.RoundedCornersMask = CType(15, Byte)
        Me.vbtnSalir.Size = New System.Drawing.Size(100, 30)
        Me.vbtnSalir.TabIndex = 85
        Me.vbtnSalir.Text = "Salir"
        Me.vbtnSalir.UseVisualStyleBackColor = False
        Me.vbtnSalir.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO
        '
        'vbtnAceptar
        '
        Me.vbtnAceptar.AllowAnimations = True
        Me.vbtnAceptar.BackColor = System.Drawing.Color.Transparent
        Me.vbtnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.vbtnAceptar.Location = New System.Drawing.Point(154, 196)
        Me.vbtnAceptar.Name = "vbtnAceptar"
        Me.vbtnAceptar.RoundedCornersMask = CType(15, Byte)
        Me.vbtnAceptar.Size = New System.Drawing.Size(100, 30)
        Me.vbtnAceptar.TabIndex = 84
        Me.vbtnAceptar.Text = "Aceptar"
        Me.vbtnAceptar.UseVisualStyleBackColor = False
        Me.vbtnAceptar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO
        '
        'vlblPass
        '
        Me.vlblPass.BackColor = System.Drawing.Color.Transparent
        Me.vlblPass.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly
        Me.vlblPass.Ellipsis = False
        Me.vlblPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vlblPass.ImageAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.vlblPass.Location = New System.Drawing.Point(120, 133)
        Me.vlblPass.Multiline = True
        Me.vlblPass.Name = "vlblPass"
        Me.vlblPass.Size = New System.Drawing.Size(97, 25)
        Me.vlblPass.TabIndex = 80
        Me.vlblPass.Text = "Contraseña"
        Me.vlblPass.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.vlblPass.UseMnemonics = True
        Me.vlblPass.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'vlblUser
        '
        Me.vlblUser.BackColor = System.Drawing.Color.Transparent
        Me.vlblUser.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly
        Me.vlblUser.Ellipsis = True
        Me.vlblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vlblUser.ImageAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.vlblUser.Location = New System.Drawing.Point(120, 93)
        Me.vlblUser.Multiline = True
        Me.vlblUser.Name = "vlblUser"
        Me.vlblUser.Size = New System.Drawing.Size(80, 25)
        Me.vlblUser.TabIndex = 81
        Me.vlblUser.Text = "Usuario"
        Me.vlblUser.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.vlblUser.UseMnemonics = True
        Me.vlblUser.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.ORANGEFRESH
        '
        'vtxtUser
        '
        Me.vtxtUser.BackColor = System.Drawing.Color.White
        Me.vtxtUser.BoundsOffset = New System.Drawing.Size(1, 1)
        Me.vtxtUser.ControlBorderColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.vtxtUser.DefaultText = ""
        Me.vtxtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.vtxtUser.Location = New System.Drawing.Point(226, 93)
        Me.vtxtUser.MaxLength = 32767
        Me.vtxtUser.Name = "vtxtUser"
        Me.vtxtUser.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.vtxtUser.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vtxtUser.SelectionLength = 0
        Me.vtxtUser.SelectionStart = 0
        Me.vtxtUser.Size = New System.Drawing.Size(145, 29)
        Me.vtxtUser.TabIndex = 82
        Me.vtxtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.vtxtUser.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'FrmLoguin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 259)
        Me.ControlBox = False
        Me.Controls.Add(Me.vtxtPass)
        Me.Controls.Add(Me.vbtnSalir)
        Me.Controls.Add(Me.vbtnAceptar)
        Me.Controls.Add(Me.vlblPass)
        Me.Controls.Add(Me.vlblUser)
        Me.Controls.Add(Me.vtxtUser)
        Me.Controls.Add(Me.lblSucursal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pkb4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Name = "FrmLoguin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loguin"
        CType(Me.pkb4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pkb4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents vtxtPass As VIBlend.WinForms.Controls.vTextBox
    Friend WithEvents vbtnSalir As VIBlend.WinForms.Controls.vButton
    Friend WithEvents vbtnAceptar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents vlblPass As VIBlend.WinForms.Controls.vLabel
    Friend WithEvents vlblUser As VIBlend.WinForms.Controls.vLabel
    Friend WithEvents vtxtUser As VIBlend.WinForms.Controls.vTextBox
End Class
