<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBsOnonimos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBsOnonimos))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtApellidoM = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtApellidoP = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VButton2 = New VIBlend.WinForms.Controls.vButton()
        Me.dgvClientes = New System.Windows.Forms.DataGridView()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.pkb5 = New System.Windows.Forms.PictureBox()
        Me.pkb6 = New System.Windows.Forms.PictureBox()
        Me.BtnAceptar = New VIBlend.WinForms.Controls.vButton()
        Me.lbRojo = New System.Windows.Forms.Label()
        Me.lbMensaje = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pkb5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pkb6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Snow
        Me.GroupBox1.Controls.Add(Me.txtApellidoM)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.txtApellidoP)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(737, 107)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Hay Alguna Persona con Apellidos y Nombres Iguales"
        '
        'txtApellidoM
        '
        Me.txtApellidoM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellidoM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.txtApellidoM.Location = New System.Drawing.Point(430, 29)
        Me.txtApellidoM.Name = "txtApellidoM"
        Me.txtApellidoM.Size = New System.Drawing.Size(159, 22)
        Me.txtApellidoM.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(321, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "APELLIDO M:"
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.txtNombre.Location = New System.Drawing.Point(109, 62)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(205, 22)
        Me.txtNombre.TabIndex = 3
        '
        'txtApellidoP
        '
        Me.txtApellidoP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellidoP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.txtApellidoP.Location = New System.Drawing.Point(109, 29)
        Me.txtApellidoP.Name = "txtApellidoP"
        Me.txtApellidoP.Size = New System.Drawing.Size(205, 22)
        Me.txtApellidoP.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "APELLIDO P:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NOMBRE(S):"
        '
        'VButton2
        '
        Me.VButton2.AllowAnimations = True
        Me.VButton2.BackColor = System.Drawing.Color.Transparent
        Me.VButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VButton2.Image = CType(resources.GetObject("VButton2.Image"), System.Drawing.Image)
        Me.VButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.VButton2.Location = New System.Drawing.Point(521, 442)
        Me.VButton2.Name = "VButton2"
        Me.VButton2.RoundedCornersMask = CType(15, Byte)
        Me.VButton2.Size = New System.Drawing.Size(193, 36)
        Me.VButton2.TabIndex = 8
        Me.VButton2.Text = "Persona Registrada"
        Me.VButton2.UseVisualStyleBackColor = True
        Me.VButton2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO
        '
        'dgvClientes
        '
        Me.dgvClientes.AllowUserToAddRows = False
        Me.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClientes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Green
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvClientes.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvClientes.Location = New System.Drawing.Point(15, 129)
        Me.dgvClientes.Name = "dgvClientes"
        Me.dgvClientes.RowTemplate.Height = 32
        Me.dgvClientes.Size = New System.Drawing.Size(737, 303)
        Me.dgvClientes.TabIndex = 4
        '
        'btnVer
        '
        Me.btnVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnVer.Image = CType(resources.GetObject("btnVer.Image"), System.Drawing.Image)
        Me.btnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVer.Location = New System.Drawing.Point(822, 346)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(84, 36)
        Me.btnVer.TabIndex = 111
        Me.btnVer.Text = "Ver"
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'pkb5
        '
        Me.pkb5.BackColor = System.Drawing.Color.White
        Me.pkb5.Location = New System.Drawing.Point(761, 14)
        Me.pkb5.Name = "pkb5"
        Me.pkb5.Size = New System.Drawing.Size(209, 161)
        Me.pkb5.TabIndex = 112
        Me.pkb5.TabStop = False
        '
        'pkb6
        '
        Me.pkb6.BackColor = System.Drawing.Color.White
        Me.pkb6.Location = New System.Drawing.Point(761, 179)
        Me.pkb6.Name = "pkb6"
        Me.pkb6.Size = New System.Drawing.Size(209, 161)
        Me.pkb6.TabIndex = 113
        Me.pkb6.TabStop = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.AllowAnimations = True
        Me.BtnAceptar.BackColor = System.Drawing.Color.Transparent
        Me.BtnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAceptar.Location = New System.Drawing.Point(289, 442)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.RoundedCornersMask = CType(15, Byte)
        Me.BtnAceptar.Size = New System.Drawing.Size(135, 36)
        Me.BtnAceptar.TabIndex = 114
        Me.BtnAceptar.Text = "Aceptar Homonimo"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        Me.BtnAceptar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO
        '
        'lbRojo
        '
        Me.lbRojo.BackColor = System.Drawing.Color.Red
        Me.lbRojo.Font = New System.Drawing.Font("Century", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRojo.Location = New System.Drawing.Point(761, 384)
        Me.lbRojo.Name = "lbRojo"
        Me.lbRojo.Size = New System.Drawing.Size(209, 53)
        Me.lbRojo.TabIndex = 115
        Me.lbRojo.Text = "MARCADOS POR EL COLOR ROJO SON PERSONAS POLITICAMENTE EXPUESTAS"
        '
        'lbMensaje
        '
        Me.lbMensaje.BackColor = System.Drawing.SystemColors.Control
        Me.lbMensaje.Font = New System.Drawing.Font("Century", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMensaje.Location = New System.Drawing.Point(720, 435)
        Me.lbMensaje.Name = "lbMensaje"
        Me.lbMensaje.Size = New System.Drawing.Size(266, 49)
        Me.lbMensaje.TabIndex = 116
        Me.lbMensaje.Text = "Si es una Persona Politicamente Espuesta lo Seleccionas en el Grid y Precionas el" &
    " Boton de Persona Registrada."
        '
        'FrmBsOnonimos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 493)
        Me.Controls.Add(Me.lbMensaje)
        Me.Controls.Add(Me.lbRojo)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.btnVer)
        Me.Controls.Add(Me.VButton2)
        Me.Controls.Add(Me.pkb5)
        Me.Controls.Add(Me.pkb6)
        Me.Controls.Add(Me.dgvClientes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmBsOnonimos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmBsOnonimos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pkb5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pkb6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtApellidoM As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents VButton2 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtApellidoP As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvClientes As System.Windows.Forms.DataGridView
    Friend WithEvents btnVer As System.Windows.Forms.Button
    Friend WithEvents pkb5 As System.Windows.Forms.PictureBox
    Friend WithEvents pkb6 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnAceptar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents lbRojo As System.Windows.Forms.Label
    Friend WithEvents lbMensaje As System.Windows.Forms.Label
End Class
