<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMensajePts
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
        Me.BtnImprmir = New System.Windows.Forms.Button()
        Me.TxtFolioNC = New System.Windows.Forms.TextBox()
        Me.BtnCuenta = New System.Windows.Forms.Button()
        Me.LblPrecioV = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnCanjear = New System.Windows.Forms.Button()
        Me.TxtDolares = New System.Windows.Forms.TextBox()
        Me.TxtPesos = New System.Windows.Forms.TextBox()
        Me.TxtPuntos = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnCuentaTic = New System.Windows.Forms.Button()
        Me.LblPesos = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LbPesos2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LbPesos3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnImprmir
        '
        Me.BtnImprmir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprmir.Location = New System.Drawing.Point(407, 258)
        Me.BtnImprmir.Name = "BtnImprmir"
        Me.BtnImprmir.Size = New System.Drawing.Size(88, 39)
        Me.BtnImprmir.TabIndex = 39
        Me.BtnImprmir.Text = "Imprimir Nota Credito"
        Me.BtnImprmir.UseVisualStyleBackColor = True
        '
        'TxtFolioNC
        '
        Me.TxtFolioNC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolioNC.Location = New System.Drawing.Point(408, 226)
        Me.TxtFolioNC.Name = "TxtFolioNC"
        Me.TxtFolioNC.Size = New System.Drawing.Size(88, 26)
        Me.TxtFolioNC.TabIndex = 38
        '
        'BtnCuenta
        '
        Me.BtnCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCuenta.Location = New System.Drawing.Point(404, 48)
        Me.BtnCuenta.Name = "BtnCuenta"
        Me.BtnCuenta.Size = New System.Drawing.Size(89, 36)
        Me.BtnCuenta.TabIndex = 34
        Me.BtnCuenta.Text = "Generar Estado de Cuenta"
        Me.BtnCuenta.UseVisualStyleBackColor = True
        '
        'LblPrecioV
        '
        Me.LblPrecioV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblPrecioV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrecioV.Location = New System.Drawing.Point(279, 109)
        Me.LblPrecioV.Name = "LblPrecioV"
        Me.LblPrecioV.Size = New System.Drawing.Size(86, 23)
        Me.LblPrecioV.TabIndex = 33
        Me.LblPrecioV.Text = "Precio"
        Me.LblPrecioV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(279, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 23)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Precio Venta"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(263, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 23)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "1 Puntos =  0.05 Pesos"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(263, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 23)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "1 Dolar = 1 Puntos"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(263, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 23)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Informacion:"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Location = New System.Drawing.Point(163, 258)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(94, 36)
        Me.BtnCancelar.TabIndex = 28
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnCanjear
        '
        Me.BtnCanjear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCanjear.Location = New System.Drawing.Point(31, 259)
        Me.BtnCanjear.Name = "BtnCanjear"
        Me.BtnCanjear.Size = New System.Drawing.Size(94, 34)
        Me.BtnCanjear.TabIndex = 27
        Me.BtnCanjear.Text = "Canjear"
        Me.BtnCanjear.UseVisualStyleBackColor = True
        '
        'TxtDolares
        '
        Me.TxtDolares.Enabled = False
        Me.TxtDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDolares.Location = New System.Drawing.Point(157, 170)
        Me.TxtDolares.Name = "TxtDolares"
        Me.TxtDolares.Size = New System.Drawing.Size(100, 26)
        Me.TxtDolares.TabIndex = 26
        '
        'TxtPesos
        '
        Me.TxtPesos.Enabled = False
        Me.TxtPesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPesos.Location = New System.Drawing.Point(157, 102)
        Me.TxtPesos.Name = "TxtPesos"
        Me.TxtPesos.Size = New System.Drawing.Size(100, 26)
        Me.TxtPesos.TabIndex = 25
        '
        'TxtPuntos
        '
        Me.TxtPuntos.Enabled = False
        Me.TxtPuntos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPuntos.Location = New System.Drawing.Point(157, 60)
        Me.TxtPuntos.Name = "TxtPuntos"
        Me.TxtPuntos.Size = New System.Drawing.Size(100, 26)
        Me.TxtPuntos.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(357, 20)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "¿Deseas Canjear Los Puntos de la Tarjeta?"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(68, 171)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 20)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Dolares:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(81, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 20)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Pesos:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(81, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 20)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Puntos:"
        '
        'BtnCuentaTic
        '
        Me.BtnCuentaTic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCuentaTic.Location = New System.Drawing.Point(403, 9)
        Me.BtnCuentaTic.Name = "BtnCuentaTic"
        Me.BtnCuentaTic.Size = New System.Drawing.Size(89, 36)
        Me.BtnCuentaTic.TabIndex = 40
        Me.BtnCuentaTic.Text = "Estado de Cuenta Ticket"
        Me.BtnCuentaTic.UseVisualStyleBackColor = True
        '
        'LblPesos
        '
        Me.LblPesos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblPesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesos.Location = New System.Drawing.Point(279, 164)
        Me.LblPesos.Name = "LblPesos"
        Me.LblPesos.Size = New System.Drawing.Size(86, 23)
        Me.LblPesos.TabIndex = 42
        Me.LblPesos.Text = "Pesos"
        Me.LblPesos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(283, 151)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 13)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Valor 1 Punto"
        '
        'LbPesos2
        '
        Me.LbPesos2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbPesos2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbPesos2.Location = New System.Drawing.Point(403, 109)
        Me.LbPesos2.Name = "LbPesos2"
        Me.LbPesos2.Size = New System.Drawing.Size(86, 23)
        Me.LbPesos2.TabIndex = 44
        Me.LbPesos2.Text = "Pesos"
        Me.LbPesos2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(406, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 15)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Valor 1 Punto"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(266, 135)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(131, 16)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Puntos menores a 5000"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(389, 85)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(131, 12)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Puntos iguales a 5000"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(387, 133)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(131, 10)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "Puntos extra mayor a 5000"
        '
        'LbPesos3
        '
        Me.LbPesos3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbPesos3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbPesos3.Location = New System.Drawing.Point(401, 164)
        Me.LbPesos3.Name = "LbPesos3"
        Me.LbPesos3.Size = New System.Drawing.Size(86, 23)
        Me.LbPesos3.TabIndex = 48
        Me.LbPesos3.Text = "Pesos"
        Me.LbPesos3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(402, 143)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 15)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Valor 1 Punto"
        '
        'FrmMensajePts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 311)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.LbPesos3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.LbPesos2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LblPesos)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.BtnCuentaTic)
        Me.Controls.Add(Me.BtnImprmir)
        Me.Controls.Add(Me.TxtFolioNC)
        Me.Controls.Add(Me.BtnCuenta)
        Me.Controls.Add(Me.LblPrecioV)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnCanjear)
        Me.Controls.Add(Me.TxtDolares)
        Me.Controls.Add(Me.TxtPesos)
        Me.Controls.Add(Me.TxtPuntos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmMensajePts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Puntos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnImprmir As System.Windows.Forms.Button
    Friend WithEvents TxtFolioNC As System.Windows.Forms.TextBox
    Friend WithEvents BtnCuenta As System.Windows.Forms.Button
    Friend WithEvents LblPrecioV As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnCanjear As System.Windows.Forms.Button
    Friend WithEvents TxtDolares As System.Windows.Forms.TextBox
    Friend WithEvents TxtPesos As System.Windows.Forms.TextBox
    Friend WithEvents TxtPuntos As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnCuentaTic As System.Windows.Forms.Button
    Friend WithEvents LblPesos As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LbPesos2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents LbPesos3 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
