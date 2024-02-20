<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAlerta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAlerta))
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.rtxObservaciones = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rbd4 = New System.Windows.Forms.RadioButton()
        Me.rbd3 = New System.Windows.Forms.RadioButton()
        Me.rbd2 = New System.Windows.Forms.RadioButton()
        Me.rbd1 = New System.Windows.Forms.RadioButton()
        Me.txtmonto = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbd8 = New System.Windows.Forms.RadioButton()
        Me.rbd7 = New System.Windows.Forms.RadioButton()
        Me.rbd6 = New System.Windows.Forms.RadioButton()
        Me.rbd5 = New System.Windows.Forms.RadioButton()
        Me.rbV = New System.Windows.Forms.RadioButton()
        Me.cmbcausales = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtoperacion = New System.Windows.Forms.TextBox()
        Me.txtdivisa = New System.Windows.Forms.TextBox()
        Me.txtsucursal = New System.Windows.Forms.TextBox()
        Me.txtempleado = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chTentativa = New System.Windows.Forms.CheckBox()
        Me.rbTen24 = New System.Windows.Forms.RadioButton()
        Me.rbC = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson
        Me.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Crimson
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Location = New System.Drawing.Point(467, 466)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 78)
        Me.btnSalir.TabIndex = 53
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnAlta
        '
        Me.btnAlta.BackColor = System.Drawing.Color.Green
        Me.btnAlta.BackgroundImage = CType(resources.GetObject("btnAlta.BackgroundImage"), System.Drawing.Image)
        Me.btnAlta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlta.Location = New System.Drawing.Point(279, 466)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(75, 78)
        Me.btnAlta.TabIndex = 51
        Me.btnAlta.UseVisualStyleBackColor = False
        '
        'rtxObservaciones
        '
        Me.rtxObservaciones.Location = New System.Drawing.Point(116, 371)
        Me.rtxObservaciones.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rtxObservaciones.Name = "rtxObservaciones"
        Me.rtxObservaciones.Size = New System.Drawing.Size(426, 87)
        Me.rtxObservaciones.TabIndex = 46
        Me.rtxObservaciones.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(13, 374)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "DESCRIPCION:"
        '
        'rbd4
        '
        Me.rbd4.AutoSize = True
        Me.rbd4.Location = New System.Drawing.Point(165, 53)
        Me.rbd4.Name = "rbd4"
        Me.rbd4.Size = New System.Drawing.Size(63, 17)
        Me.rbd4.TabIndex = 2
        Me.rbd4.TabStop = True
        Me.rbd4.Text = "LIBRAS"
        Me.rbd4.UseVisualStyleBackColor = True
        '
        'rbd3
        '
        Me.rbd3.AutoSize = True
        Me.rbd3.Location = New System.Drawing.Point(3, 53)
        Me.rbd3.Name = "rbd3"
        Me.rbd3.Size = New System.Drawing.Size(101, 17)
        Me.rbd3.TabIndex = 1
        Me.rbd3.TabStop = True
        Me.rbd3.Text = "CANADIENSES"
        Me.rbd3.UseVisualStyleBackColor = True
        '
        'rbd2
        '
        Me.rbd2.AutoSize = True
        Me.rbd2.Location = New System.Drawing.Point(165, 14)
        Me.rbd2.Name = "rbd2"
        Me.rbd2.Size = New System.Drawing.Size(63, 17)
        Me.rbd2.TabIndex = 0
        Me.rbd2.TabStop = True
        Me.rbd2.Text = "EUROS"
        Me.rbd2.UseVisualStyleBackColor = True
        '
        'rbd1
        '
        Me.rbd1.AutoSize = True
        Me.rbd1.Location = New System.Drawing.Point(3, 14)
        Me.rbd1.Name = "rbd1"
        Me.rbd1.Size = New System.Drawing.Size(87, 17)
        Me.rbd1.TabIndex = 0
        Me.rbd1.TabStop = True
        Me.rbd1.Text = "DOLAR USA"
        Me.rbd1.UseVisualStyleBackColor = True
        '
        'txtmonto
        '
        Me.txtmonto.Location = New System.Drawing.Point(275, 243)
        Me.txtmonto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtmonto.Name = "txtmonto"
        Me.txtmonto.Size = New System.Drawing.Size(267, 20)
        Me.txtmonto.TabIndex = 35
        Me.txtmonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rbd8)
        Me.GroupBox1.Controls.Add(Me.rbd7)
        Me.GroupBox1.Controls.Add(Me.rbd6)
        Me.GroupBox1.Controls.Add(Me.rbd5)
        Me.GroupBox1.Controls.Add(Me.rbd4)
        Me.GroupBox1.Controls.Add(Me.rbd3)
        Me.GroupBox1.Controls.Add(Me.rbd2)
        Me.GroupBox1.Controls.Add(Me.rbd1)
        Me.GroupBox1.Location = New System.Drawing.Point(275, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(267, 164)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        '
        'rbd8
        '
        Me.rbd8.AutoSize = True
        Me.rbd8.Location = New System.Drawing.Point(165, 134)
        Me.rbd8.Name = "rbd8"
        Me.rbd8.Size = New System.Drawing.Size(74, 30)
        Me.rbd8.TabIndex = 6
        Me.rbd8.TabStop = True
        Me.rbd8.Text = "YEN" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "JAPONES"
        Me.rbd8.UseVisualStyleBackColor = True
        '
        'rbd7
        '
        Me.rbd7.AutoSize = True
        Me.rbd7.Location = New System.Drawing.Point(3, 134)
        Me.rbd7.Name = "rbd7"
        Me.rbd7.Size = New System.Drawing.Size(105, 17)
        Me.rbd7.TabIndex = 5
        Me.rbd7.TabStop = True
        Me.rbd7.Text = "FRANCO SUIZO"
        Me.rbd7.UseVisualStyleBackColor = True
        '
        'rbd6
        '
        Me.rbd6.AutoSize = True
        Me.rbd6.Location = New System.Drawing.Point(165, 95)
        Me.rbd6.Name = "rbd6"
        Me.rbd6.Size = New System.Drawing.Size(101, 30)
        Me.rbd6.TabIndex = 3
        Me.rbd6.TabStop = True
        Me.rbd6.Text = "DOLAR " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AUSTRALIANO"
        Me.rbd6.UseVisualStyleBackColor = True
        '
        'rbd5
        '
        Me.rbd5.AutoSize = True
        Me.rbd5.Location = New System.Drawing.Point(3, 95)
        Me.rbd5.Name = "rbd5"
        Me.rbd5.Size = New System.Drawing.Size(92, 17)
        Me.rbd5.TabIndex = 4
        Me.rbd5.TabStop = True
        Me.rbd5.Text = "YUAN CHINO"
        Me.rbd5.UseVisualStyleBackColor = True
        '
        'rbV
        '
        Me.rbV.AutoSize = True
        Me.rbV.Location = New System.Drawing.Point(106, 18)
        Me.rbV.Name = "rbV"
        Me.rbV.Size = New System.Drawing.Size(158, 17)
        Me.rbV.TabIndex = 1
        Me.rbV.TabStop = True
        Me.rbV.Text = "INTERNO PREOCUPANTE"
        Me.rbV.UseVisualStyleBackColor = True
        '
        'cmbcausales
        '
        Me.cmbcausales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcausales.FormattingEnabled = True
        Me.cmbcausales.Location = New System.Drawing.Point(116, 337)
        Me.cmbcausales.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbcausales.Name = "cmbcausales"
        Me.cmbcausales.Size = New System.Drawing.Size(426, 24)
        Me.cmbcausales.TabIndex = 43
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(13, 288)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "OPERACIÓN:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(13, 248)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(174, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "MONTO MONEDA EXTRANJERA:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(13, 85)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "DIVISA:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(13, 42)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "SUCURSAL:"
        '
        'txtoperacion
        '
        Me.txtoperacion.Location = New System.Drawing.Point(138, 282)
        Me.txtoperacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtoperacion.Name = "txtoperacion"
        Me.txtoperacion.Size = New System.Drawing.Size(74, 20)
        Me.txtoperacion.TabIndex = 36
        Me.txtoperacion.Visible = False
        '
        'txtdivisa
        '
        Me.txtdivisa.Location = New System.Drawing.Point(137, 82)
        Me.txtdivisa.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtdivisa.Name = "txtdivisa"
        Me.txtdivisa.Size = New System.Drawing.Size(50, 20)
        Me.txtdivisa.TabIndex = 34
        Me.txtdivisa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtdivisa.Visible = False
        '
        'txtsucursal
        '
        Me.txtsucursal.Enabled = False
        Me.txtsucursal.Location = New System.Drawing.Point(275, 39)
        Me.txtsucursal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtsucursal.Name = "txtsucursal"
        Me.txtsucursal.Size = New System.Drawing.Size(267, 20)
        Me.txtsucursal.TabIndex = 37
        Me.txtsucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtempleado
        '
        Me.txtempleado.Enabled = False
        Me.txtempleado.Location = New System.Drawing.Point(275, 9)
        Me.txtempleado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtempleado.Name = "txtempleado"
        Me.txtempleado.Size = New System.Drawing.Size(267, 20)
        Me.txtempleado.TabIndex = 33
        Me.txtempleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.chTentativa)
        Me.GroupBox2.Controls.Add(Me.rbTen24)
        Me.GroupBox2.Controls.Add(Me.rbV)
        Me.GroupBox2.Controls.Add(Me.rbC)
        Me.GroupBox2.Location = New System.Drawing.Point(275, 264)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(267, 66)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        '
        'chTentativa
        '
        Me.chTentativa.AutoSize = True
        Me.chTentativa.Enabled = False
        Me.chTentativa.Location = New System.Drawing.Point(106, 41)
        Me.chTentativa.Name = "chTentativa"
        Me.chTentativa.Size = New System.Drawing.Size(86, 17)
        Me.chTentativa.TabIndex = 3
        Me.chTentativa.Text = "TENTATIVA"
        Me.chTentativa.UseVisualStyleBackColor = True
        '
        'rbTen24
        '
        Me.rbTen24.AutoSize = True
        Me.rbTen24.Location = New System.Drawing.Point(14, 41)
        Me.rbTen24.Name = "rbTen24"
        Me.rbTen24.Size = New System.Drawing.Size(78, 17)
        Me.rbTen24.TabIndex = 2
        Me.rbTen24.TabStop = True
        Me.rbTen24.Text = "24 HORAS"
        Me.rbTen24.UseVisualStyleBackColor = True
        '
        'rbC
        '
        Me.rbC.AutoSize = True
        Me.rbC.Location = New System.Drawing.Point(14, 18)
        Me.rbC.Name = "rbC"
        Me.rbC.Size = New System.Drawing.Size(72, 17)
        Me.rbC.TabIndex = 0
        Me.rbC.TabStop = True
        Me.rbC.Text = "INUSUAL"
        Me.rbC.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(13, 342)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "CAUSALES:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "EMPLEADO:"
        '
        'FrmAlerta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(572, 547)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAlta)
        Me.Controls.Add(Me.rtxObservaciones)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtmonto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbcausales)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtoperacion)
        Me.Controls.Add(Me.txtdivisa)
        Me.Controls.Add(Me.txtsucursal)
        Me.Controls.Add(Me.txtempleado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmAlerta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alerta"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents rtxObservaciones As System.Windows.Forms.RichTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rbd4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbd3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbd2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbd1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtmonto As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbV As System.Windows.Forms.RadioButton
    Friend WithEvents cmbcausales As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtoperacion As System.Windows.Forms.TextBox
    Friend WithEvents txtdivisa As System.Windows.Forms.TextBox
    Friend WithEvents txtsucursal As System.Windows.Forms.TextBox
    Friend WithEvents txtempleado As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbC As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbTen24 As RadioButton
    Friend WithEvents chTentativa As CheckBox
    Friend WithEvents rbd8 As RadioButton
    Friend WithEvents rbd7 As RadioButton
    Friend WithEvents rbd6 As RadioButton
    Friend WithEvents rbd5 As RadioButton
End Class
