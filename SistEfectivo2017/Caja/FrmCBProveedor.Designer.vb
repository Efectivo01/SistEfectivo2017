<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCBProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCBProveedor))
        Me.cmdGenerar = New System.Windows.Forms.Button()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.pbCBP = New System.Windows.Forms.PictureBox()
        Me.lbNombre = New System.Windows.Forms.Label()
        CType(Me.pbCBP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdGenerar
        '
        Me.cmdGenerar.Location = New System.Drawing.Point(233, 3)
        Me.cmdGenerar.Name = "cmdGenerar"
        Me.cmdGenerar.Size = New System.Drawing.Size(89, 29)
        Me.cmdGenerar.TabIndex = 0
        Me.cmdGenerar.Text = "GENERAR"
        Me.cmdGenerar.UseVisualStyleBackColor = True
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(12, 12)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(68, 20)
        Me.txtCodigo.TabIndex = 2
        '
        'pbCBP
        '
        Me.pbCBP.Image = CType(resources.GetObject("pbCBP.Image"), System.Drawing.Image)
        Me.pbCBP.Location = New System.Drawing.Point(12, 53)
        Me.pbCBP.Name = "pbCBP"
        Me.pbCBP.Size = New System.Drawing.Size(310, 224)
        Me.pbCBP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbCBP.TabIndex = 3
        Me.pbCBP.TabStop = False
        '
        'lbNombre
        '
        Me.lbNombre.Location = New System.Drawing.Point(13, 37)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(304, 13)
        Me.lbNombre.TabIndex = 4
        '
        'FrmCBProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 284)
        Me.Controls.Add(Me.lbNombre)
        Me.Controls.Add(Me.pbCBP)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.cmdGenerar)
        Me.Name = "FrmCBProveedor"
        Me.Text = "Codigo Barras Proveedor"
        CType(Me.pbCBP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdGenerar As System.Windows.Forms.Button
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents pbCBP As System.Windows.Forms.PictureBox
    Friend WithEvents lbNombre As Label
End Class
