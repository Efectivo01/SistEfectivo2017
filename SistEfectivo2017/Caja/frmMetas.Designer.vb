<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMetas
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
        Me.txtEstMesC = New System.Windows.Forms.TextBox()
        Me.txtMetaC = New System.Windows.Forms.TextBox()
        Me.txtAcumuladoC = New System.Windows.Forms.TextBox()
        Me.txtVariacionC = New System.Windows.Forms.TextBox()
        Me.txtMetaDiariaC = New System.Windows.Forms.TextBox()
        Me.txtMetaDiariaV = New System.Windows.Forms.TextBox()
        Me.txtVariacionV = New System.Windows.Forms.TextBox()
        Me.txtAcumuladoV = New System.Windows.Forms.TextBox()
        Me.txtMetaV = New System.Windows.Forms.TextBox()
        Me.txtEstMesV = New System.Windows.Forms.TextBox()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape5 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.cmdRefrescar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compras:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Ventas:"
        '
        'txtEstMesC
        '
        Me.txtEstMesC.BackColor = System.Drawing.Color.White
        Me.txtEstMesC.Location = New System.Drawing.Point(116, 59)
        Me.txtEstMesC.Name = "txtEstMesC"
        Me.txtEstMesC.ReadOnly = True
        Me.txtEstMesC.Size = New System.Drawing.Size(109, 26)
        Me.txtEstMesC.TabIndex = 2
        Me.txtEstMesC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMetaC
        '
        Me.txtMetaC.BackColor = System.Drawing.Color.White
        Me.txtMetaC.Location = New System.Drawing.Point(248, 59)
        Me.txtMetaC.Name = "txtMetaC"
        Me.txtMetaC.ReadOnly = True
        Me.txtMetaC.Size = New System.Drawing.Size(109, 26)
        Me.txtMetaC.TabIndex = 3
        Me.txtMetaC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAcumuladoC
        '
        Me.txtAcumuladoC.BackColor = System.Drawing.Color.White
        Me.txtAcumuladoC.Location = New System.Drawing.Point(377, 59)
        Me.txtAcumuladoC.Name = "txtAcumuladoC"
        Me.txtAcumuladoC.ReadOnly = True
        Me.txtAcumuladoC.Size = New System.Drawing.Size(109, 26)
        Me.txtAcumuladoC.TabIndex = 4
        Me.txtAcumuladoC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVariacionC
        '
        Me.txtVariacionC.BackColor = System.Drawing.Color.White
        Me.txtVariacionC.Location = New System.Drawing.Point(508, 59)
        Me.txtVariacionC.Name = "txtVariacionC"
        Me.txtVariacionC.ReadOnly = True
        Me.txtVariacionC.Size = New System.Drawing.Size(109, 26)
        Me.txtVariacionC.TabIndex = 5
        Me.txtVariacionC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMetaDiariaC
        '
        Me.txtMetaDiariaC.BackColor = System.Drawing.Color.White
        Me.txtMetaDiariaC.Location = New System.Drawing.Point(635, 59)
        Me.txtMetaDiariaC.Name = "txtMetaDiariaC"
        Me.txtMetaDiariaC.ReadOnly = True
        Me.txtMetaDiariaC.Size = New System.Drawing.Size(109, 26)
        Me.txtMetaDiariaC.TabIndex = 6
        Me.txtMetaDiariaC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMetaDiariaV
        '
        Me.txtMetaDiariaV.BackColor = System.Drawing.Color.White
        Me.txtMetaDiariaV.Location = New System.Drawing.Point(635, 138)
        Me.txtMetaDiariaV.Name = "txtMetaDiariaV"
        Me.txtMetaDiariaV.ReadOnly = True
        Me.txtMetaDiariaV.Size = New System.Drawing.Size(109, 26)
        Me.txtMetaDiariaV.TabIndex = 11
        Me.txtMetaDiariaV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVariacionV
        '
        Me.txtVariacionV.BackColor = System.Drawing.Color.White
        Me.txtVariacionV.Location = New System.Drawing.Point(508, 138)
        Me.txtVariacionV.Name = "txtVariacionV"
        Me.txtVariacionV.ReadOnly = True
        Me.txtVariacionV.Size = New System.Drawing.Size(109, 26)
        Me.txtVariacionV.TabIndex = 10
        Me.txtVariacionV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAcumuladoV
        '
        Me.txtAcumuladoV.BackColor = System.Drawing.Color.White
        Me.txtAcumuladoV.Location = New System.Drawing.Point(377, 138)
        Me.txtAcumuladoV.Name = "txtAcumuladoV"
        Me.txtAcumuladoV.ReadOnly = True
        Me.txtAcumuladoV.Size = New System.Drawing.Size(109, 26)
        Me.txtAcumuladoV.TabIndex = 9
        Me.txtAcumuladoV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMetaV
        '
        Me.txtMetaV.BackColor = System.Drawing.Color.White
        Me.txtMetaV.Location = New System.Drawing.Point(248, 138)
        Me.txtMetaV.Name = "txtMetaV"
        Me.txtMetaV.ReadOnly = True
        Me.txtMetaV.Size = New System.Drawing.Size(109, 26)
        Me.txtMetaV.TabIndex = 8
        Me.txtMetaV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEstMesV
        '
        Me.txtEstMesV.BackColor = System.Drawing.Color.White
        Me.txtEstMesV.Location = New System.Drawing.Point(116, 138)
        Me.txtEstMesV.Name = "txtEstMesV"
        Me.txtEstMesV.ReadOnly = True
        Me.txtEstMesV.Size = New System.Drawing.Size(109, 26)
        Me.txtEstMesV.TabIndex = 7
        Me.txtEstMesV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdCerrar
        '
        Me.cmdCerrar.BackColor = System.Drawing.Color.Red
        Me.cmdCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.ForeColor = System.Drawing.Color.White
        Me.cmdCerrar.Location = New System.Drawing.Point(614, 200)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(155, 57)
        Me.cmdCerrar.TabIndex = 12
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(112, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 47)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Estimado" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Mes"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(244, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 47)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "META"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(373, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 47)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Acumulado"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(504, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 47)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Variación"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(631, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 47)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Meta" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Diaria"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape5, Me.LineShape4, Me.LineShape3, Me.LineShape2, Me.LineShape1, Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(782, 263)
        Me.ShapeContainer1.TabIndex = 18
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape5
        '
        Me.LineShape5.Name = "LineShape5"
        Me.LineShape5.X1 = 366
        Me.LineShape5.X2 = 366
        Me.LineShape5.Y1 = 7
        Me.LineShape5.Y2 = 191
        '
        'LineShape4
        '
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 21
        Me.LineShape4.X2 = 768
        Me.LineShape4.Y1 = 109
        Me.LineShape4.Y2 = 109
        '
        'LineShape3
        '
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 626
        Me.LineShape3.X2 = 626
        Me.LineShape3.Y1 = 7
        Me.LineShape3.Y2 = 191
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 497
        Me.LineShape2.X2 = 497
        Me.LineShape2.Y1 = 7
        Me.LineShape2.Y2 = 191
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 240
        Me.LineShape1.X2 = 240
        Me.LineShape1.Y1 = 7
        Me.LineShape1.Y2 = 191
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Location = New System.Drawing.Point(21, 7)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(747, 184)
        '
        'cmdRefrescar
        '
        Me.cmdRefrescar.BackColor = System.Drawing.Color.Green
        Me.cmdRefrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefrescar.ForeColor = System.Drawing.Color.White
        Me.cmdRefrescar.Location = New System.Drawing.Point(12, 200)
        Me.cmdRefrescar.Name = "cmdRefrescar"
        Me.cmdRefrescar.Size = New System.Drawing.Size(155, 57)
        Me.cmdRefrescar.TabIndex = 19
        Me.cmdRefrescar.Text = "Refrescar"
        Me.cmdRefrescar.UseVisualStyleBackColor = False
        '
        'frmMetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 263)
        Me.Controls.Add(Me.cmdRefrescar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.txtMetaDiariaV)
        Me.Controls.Add(Me.txtVariacionV)
        Me.Controls.Add(Me.txtAcumuladoV)
        Me.Controls.Add(Me.txtMetaV)
        Me.Controls.Add(Me.txtEstMesV)
        Me.Controls.Add(Me.txtMetaDiariaC)
        Me.Controls.Add(Me.txtVariacionC)
        Me.Controls.Add(Me.txtAcumuladoC)
        Me.Controls.Add(Me.txtMetaC)
        Me.Controls.Add(Me.txtEstMesC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmMetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Metas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEstMesC As TextBox
    Friend WithEvents txtMetaC As TextBox
    Friend WithEvents txtAcumuladoC As TextBox
    Friend WithEvents txtVariacionC As TextBox
    Friend WithEvents txtMetaDiariaC As TextBox
    Friend WithEvents txtMetaDiariaV As TextBox
    Friend WithEvents txtVariacionV As TextBox
    Friend WithEvents txtAcumuladoV As TextBox
    Friend WithEvents txtMetaV As TextBox
    Friend WithEvents txtEstMesV As TextBox
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmdRefrescar As Button
    Private WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Private WithEvents LineShape4 As PowerPacks.LineShape
    Private WithEvents LineShape3 As PowerPacks.LineShape
    Private WithEvents LineShape2 As PowerPacks.LineShape
    Private WithEvents LineShape1 As PowerPacks.LineShape
    Private WithEvents RectangleShape1 As PowerPacks.RectangleShape
    Private WithEvents LineShape5 As PowerPacks.LineShape
End Class
