<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMostrarReporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMostrarReporte))
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnTraspasosDet = New System.Windows.Forms.Button()
        Me.Btn8 = New System.Windows.Forms.Button()
        Me.Btn7 = New System.Windows.Forms.Button()
        Me.Btn6 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.btnNota = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.dtpFecha2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.cmdRepIncentivo = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv.Location = New System.Drawing.Point(0, 0)
        Me.crv.Name = "crv"
        Me.crv.Size = New System.Drawing.Size(792, 733)
        Me.crv.TabIndex = 2
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Green
        Me.Panel1.Controls.Add(Me.cmdRepIncentivo)
        Me.Panel1.Controls.Add(Me.BtnTraspasosDet)
        Me.Panel1.Controls.Add(Me.Btn8)
        Me.Panel1.Controls.Add(Me.Btn7)
        Me.Panel1.Controls.Add(Me.Btn6)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.txtFolio)
        Me.Panel1.Controls.Add(Me.btnNota)
        Me.Panel1.Controls.Add(Me.btn5)
        Me.Panel1.Controls.Add(Me.dtpFecha2)
        Me.Panel1.Controls.Add(Me.dtpFecha)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.btn4)
        Me.Panel1.Controls.Add(Me.btn3)
        Me.Panel1.Controls.Add(Me.btn2)
        Me.Panel1.Controls.Add(Me.btn1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(792, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(115, 733)
        Me.Panel1.TabIndex = 3
        '
        'BtnTraspasosDet
        '
        Me.BtnTraspasosDet.BackColor = System.Drawing.Color.Goldenrod
        Me.BtnTraspasosDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnTraspasosDet.Location = New System.Drawing.Point(4, 410)
        Me.BtnTraspasosDet.Name = "BtnTraspasosDet"
        Me.BtnTraspasosDet.Size = New System.Drawing.Size(111, 48)
        Me.BtnTraspasosDet.TabIndex = 25
        Me.BtnTraspasosDet.Text = "Transferencias"
        Me.BtnTraspasosDet.UseVisualStyleBackColor = False
        '
        'Btn8
        '
        Me.Btn8.BackColor = System.Drawing.Color.Goldenrod
        Me.Btn8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Btn8.Location = New System.Drawing.Point(2, 464)
        Me.Btn8.Name = "Btn8"
        Me.Btn8.Size = New System.Drawing.Size(111, 46)
        Me.Btn8.TabIndex = 9
        Me.Btn8.Text = "Clientes y Folios"
        Me.Btn8.UseVisualStyleBackColor = False
        '
        'Btn7
        '
        Me.Btn7.BackColor = System.Drawing.Color.Goldenrod
        Me.Btn7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Btn7.Location = New System.Drawing.Point(4, 351)
        Me.Btn7.Name = "Btn7"
        Me.Btn7.Size = New System.Drawing.Size(111, 50)
        Me.Btn7.TabIndex = 8
        Me.Btn7.Text = "Reporte de Gastos"
        Me.Btn7.UseVisualStyleBackColor = False
        '
        'Btn6
        '
        Me.Btn6.BackColor = System.Drawing.Color.Goldenrod
        Me.Btn6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Btn6.Location = New System.Drawing.Point(2, 249)
        Me.Btn6.Name = "Btn6"
        Me.Btn6.Size = New System.Drawing.Size(111, 45)
        Me.Btn6.TabIndex = 7
        Me.Btn6.Text = "Incentivo Cliente"
        Me.Btn6.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Location = New System.Drawing.Point(4, 658)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(107, 5)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'txtFolio
        '
        Me.txtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.txtFolio.Location = New System.Drawing.Point(4, 667)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(107, 24)
        Me.txtFolio.TabIndex = 6
        Me.txtFolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnNota
        '
        Me.btnNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnNota.Location = New System.Drawing.Point(2, 695)
        Me.btnNota.Name = "btnNota"
        Me.btnNota.Size = New System.Drawing.Size(111, 50)
        Me.btnNota.TabIndex = 5
        Me.btnNota.Text = "Imprimir Nota"
        Me.btnNota.UseVisualStyleBackColor = True
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.Goldenrod
        Me.btn5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btn5.Location = New System.Drawing.Point(2, 546)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(111, 47)
        Me.btn5.TabIndex = 4
        Me.btn5.Text = "Global de divisas"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'dtpFecha2
        '
        Me.dtpFecha2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha2.Location = New System.Drawing.Point(2, 516)
        Me.dtpFecha2.Name = "dtpFecha2"
        Me.dtpFecha2.Size = New System.Drawing.Size(111, 24)
        Me.dtpFecha2.TabIndex = 3
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(2, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(111, 24)
        Me.dtpFecha.TabIndex = 2
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.OrangeRed
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(2, 599)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(111, 54)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.Text = "Atrás"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.Goldenrod
        Me.btn4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btn4.Location = New System.Drawing.Point(2, 193)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(111, 50)
        Me.btn4.TabIndex = 0
        Me.btn4.Text = "Inventario Divisas"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.Goldenrod
        Me.btn3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btn3.Location = New System.Drawing.Point(2, 140)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(111, 47)
        Me.btn3.TabIndex = 0
        Me.btn3.Text = "Reporte de Caja"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.Goldenrod
        Me.btn2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btn2.Location = New System.Drawing.Point(2, 85)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(111, 49)
        Me.btn2.TabIndex = 0
        Me.btn2.Text = "Ventas"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.Goldenrod
        Me.btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(2, 29)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(111, 50)
        Me.btn1.TabIndex = 0
        Me.btn1.Text = "Compras"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'cmdRepIncentivo
        '
        Me.cmdRepIncentivo.BackColor = System.Drawing.Color.Goldenrod
        Me.cmdRepIncentivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdRepIncentivo.Location = New System.Drawing.Point(2, 300)
        Me.cmdRepIncentivo.Name = "cmdRepIncentivo"
        Me.cmdRepIncentivo.Size = New System.Drawing.Size(111, 45)
        Me.cmdRepIncentivo.TabIndex = 26
        Me.cmdRepIncentivo.Text = "Incentivo Proveedor"
        Me.cmdRepIncentivo.UseVisualStyleBackColor = False
        '
        'FrmMostrarReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 733)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmMostrarReporte"
        Me.Text = "FrmMostrarReporte"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Btn6 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents btnNota As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents dtpFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents Btn7 As System.Windows.Forms.Button
    Friend WithEvents Btn8 As System.Windows.Forms.Button
    Friend WithEvents BtnTraspasosDet As System.Windows.Forms.Button
    Private WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdRepIncentivo As Button
End Class
