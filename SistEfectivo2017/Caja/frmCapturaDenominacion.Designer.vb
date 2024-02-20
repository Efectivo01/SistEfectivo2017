<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapturaDenominacion
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtD1 = New System.Windows.Forms.TextBox()
        Me.txtD5 = New System.Windows.Forms.TextBox()
        Me.txtD10 = New System.Windows.Forms.TextBox()
        Me.txtD20 = New System.Windows.Forms.TextBox()
        Me.txtD50 = New System.Windows.Forms.TextBox()
        Me.txtD100 = New System.Windows.Forms.TextBox()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "D1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(162, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "D5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(264, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "D10"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(362, 10)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "D20"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(462, 10)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "D50"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(564, 10)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "D100"
        '
        'txtD1
        '
        Me.txtD1.Location = New System.Drawing.Point(20, 39)
        Me.txtD1.Name = "txtD1"
        Me.txtD1.Size = New System.Drawing.Size(98, 26)
        Me.txtD1.TabIndex = 6
        '
        'txtD5
        '
        Me.txtD5.Location = New System.Drawing.Point(124, 39)
        Me.txtD5.Name = "txtD5"
        Me.txtD5.Size = New System.Drawing.Size(98, 26)
        Me.txtD5.TabIndex = 7
        '
        'txtD10
        '
        Me.txtD10.Location = New System.Drawing.Point(228, 39)
        Me.txtD10.Name = "txtD10"
        Me.txtD10.Size = New System.Drawing.Size(98, 26)
        Me.txtD10.TabIndex = 8
        '
        'txtD20
        '
        Me.txtD20.Location = New System.Drawing.Point(332, 39)
        Me.txtD20.Name = "txtD20"
        Me.txtD20.Size = New System.Drawing.Size(98, 26)
        Me.txtD20.TabIndex = 9
        '
        'txtD50
        '
        Me.txtD50.Location = New System.Drawing.Point(436, 39)
        Me.txtD50.Name = "txtD50"
        Me.txtD50.Size = New System.Drawing.Size(98, 26)
        Me.txtD50.TabIndex = 10
        '
        'txtD100
        '
        Me.txtD100.Location = New System.Drawing.Point(540, 39)
        Me.txtD100.Name = "txtD100"
        Me.txtD100.Size = New System.Drawing.Size(98, 26)
        Me.txtD100.TabIndex = 11
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(529, 88)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(109, 32)
        Me.cmdAceptar.TabIndex = 12
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmCapturaDenominacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 131)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.txtD100)
        Me.Controls.Add(Me.txtD50)
        Me.Controls.Add(Me.txtD20)
        Me.Controls.Add(Me.txtD10)
        Me.Controls.Add(Me.txtD5)
        Me.Controls.Add(Me.txtD1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaDenominacion"
        Me.Text = "Captura Denominacion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtD1 As TextBox
    Friend WithEvents txtD5 As TextBox
    Friend WithEvents txtD10 As TextBox
    Friend WithEvents txtD20 As TextBox
    Friend WithEvents txtD50 As TextBox
    Friend WithEvents txtD100 As TextBox
    Friend WithEvents cmdAceptar As Button
End Class
