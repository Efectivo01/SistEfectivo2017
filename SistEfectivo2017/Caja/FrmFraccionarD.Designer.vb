<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFraccionarD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFraccionarD))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.vbtnd1 = New VIBlend.WinForms.Controls.vButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtmonto2 = New VIBlend.WinForms.Controls.vTextBox()
        Me.txtmonto1 = New VIBlend.WinForms.Controls.vTextBox()
        Me.lblm2 = New System.Windows.Forms.Label()
        Me.lblm1 = New System.Windows.Forms.Label()
        Me.DTExistencia = New System.Windows.Forms.DataGridView()
        Me.BtnCancelar = New VIBlend.WinForms.Controls.vButton()
        Me.BtnProcesar = New VIBlend.WinForms.Controls.vButton()
        Me.DGEntrega = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn14 = New System.Windows.Forms.Button()
        Me.btn11 = New VIBlend.WinForms.Controls.vButton()
        Me.btn0 = New VIBlend.WinForms.Controls.vButton()
        Me.btn1 = New VIBlend.WinForms.Controls.vButton()
        Me.btn2 = New VIBlend.WinForms.Controls.vButton()
        Me.btn3 = New VIBlend.WinForms.Controls.vButton()
        Me.btn10 = New VIBlend.WinForms.Controls.vButton()
        Me.btn4 = New VIBlend.WinForms.Controls.vButton()
        Me.btn5 = New VIBlend.WinForms.Controls.vButton()
        Me.btn6 = New VIBlend.WinForms.Controls.vButton()
        Me.btn7 = New VIBlend.WinForms.Controls.vButton()
        Me.btn8 = New VIBlend.WinForms.Controls.vButton()
        Me.btn9 = New VIBlend.WinForms.Controls.vButton()
        Me.btnb7 = New VIBlend.WinForms.Controls.vButton()
        Me.BtnGuardar = New VIBlend.WinForms.Controls.vButton()
        Me.btnb6 = New VIBlend.WinForms.Controls.vButton()
        Me.btnb5 = New VIBlend.WinForms.Controls.vButton()
        Me.btnb4 = New VIBlend.WinForms.Controls.vButton()
        Me.btnb3 = New VIBlend.WinForms.Controls.vButton()
        Me.btnb2 = New VIBlend.WinForms.Controls.vButton()
        Me.btn13 = New VIBlend.WinForms.Controls.vButton()
        Me.btn12 = New VIBlend.WinForms.Controls.vButton()
        Me.btnb1 = New VIBlend.WinForms.Controls.vButton()
        Me.dgvCoV = New System.Windows.Forms.DataGridView()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.DTExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGEntrega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCoV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'vbtnd1
        '
        Me.vbtnd1.AllowAnimations = True
        Me.vbtnd1.BackColor = System.Drawing.Color.Transparent
        Me.vbtnd1.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.vbtnd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.vbtnd1.Image = CType(resources.GetObject("vbtnd1.Image"), System.Drawing.Image)
        Me.vbtnd1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.vbtnd1.Location = New System.Drawing.Point(779, 51)
        Me.vbtnd1.Name = "vbtnd1"
        Me.vbtnd1.RoundedCornersMask = CType(15, Byte)
        Me.vbtnd1.Size = New System.Drawing.Size(105, 74)
        Me.vbtnd1.TabIndex = 74
        Me.vbtnd1.Text = "BORRAR OPERACIÓN"
        Me.vbtnd1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.vbtnd1.TextWrap = True
        Me.vbtnd1.UseThemeTextColor = False
        Me.vbtnd1.UseVisualStyleBackColor = False
        Me.vbtnd1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(27, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(473, 40)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Ingresa los Datos de los Billetes a Entregar"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(26, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(486, 28)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Ingresa el Datos del Billete a Fraccionar"
        '
        'txtmonto2
        '
        Me.txtmonto2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtmonto2.BoundsOffset = New System.Drawing.Size(1, 1)
        Me.txtmonto2.ControlBorderColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.txtmonto2.DefaultText = ""
        Me.txtmonto2.DefaultTextFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonto2.Enabled = False
        Me.txtmonto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonto2.Location = New System.Drawing.Point(617, 13)
        Me.txtmonto2.MaxLength = 32767
        Me.txtmonto2.Name = "txtmonto2"
        Me.txtmonto2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtmonto2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtmonto2.SelectionLength = 0
        Me.txtmonto2.SelectionStart = 0
        Me.txtmonto2.Size = New System.Drawing.Size(267, 30)
        Me.txtmonto2.TabIndex = 71
        Me.txtmonto2.Text = "0"
        Me.txtmonto2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtmonto2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'txtmonto1
        '
        Me.txtmonto1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtmonto1.BoundsOffset = New System.Drawing.Size(1, 1)
        Me.txtmonto1.ControlBorderColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.txtmonto1.DefaultText = ""
        Me.txtmonto1.DefaultTextFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonto1.Enabled = False
        Me.txtmonto1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonto1.Location = New System.Drawing.Point(150, 13)
        Me.txtmonto1.MaxLength = 32767
        Me.txtmonto1.Name = "txtmonto1"
        Me.txtmonto1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtmonto1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtmonto1.SelectionLength = 0
        Me.txtmonto1.SelectionStart = 0
        Me.txtmonto1.Size = New System.Drawing.Size(264, 30)
        Me.txtmonto1.TabIndex = 70
        Me.txtmonto1.Text = "0"
        Me.txtmonto1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtmonto1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblm2
        '
        Me.lblm2.BackColor = System.Drawing.Color.Transparent
        Me.lblm2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblm2.Location = New System.Drawing.Point(480, 9)
        Me.lblm2.Name = "lblm2"
        Me.lblm2.Size = New System.Drawing.Size(112, 40)
        Me.lblm2.TabIndex = 68
        Me.lblm2.Text = "TOTAL DE LA OPERACIÓN"
        '
        'lblm1
        '
        Me.lblm1.BackColor = System.Drawing.Color.Transparent
        Me.lblm1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblm1.Location = New System.Drawing.Point(12, 9)
        Me.lblm1.Name = "lblm1"
        Me.lblm1.Size = New System.Drawing.Size(132, 40)
        Me.lblm1.TabIndex = 69
        Me.lblm1.Text = "MONTO DE LA OPERACIÓN"
        '
        'DTExistencia
        '
        Me.DTExistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTExistencia.Location = New System.Drawing.Point(820, 138)
        Me.DTExistencia.Name = "DTExistencia"
        Me.DTExistencia.Size = New System.Drawing.Size(171, 281)
        Me.DTExistencia.TabIndex = 103
        '
        'BtnCancelar
        '
        Me.BtnCancelar.AllowAnimations = True
        Me.BtnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancelar.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.HoverEffectsEnabled = True
        Me.BtnCancelar.Location = New System.Drawing.Point(547, 429)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.RoundedCornersMask = CType(15, Byte)
        Me.BtnCancelar.Size = New System.Drawing.Size(97, 54)
        Me.BtnCancelar.TabIndex = 102
        Me.BtnCancelar.Tag = "XC"
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCancelar.UseVisualStyleBackColor = False
        Me.BtnCancelar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.ORANGEFRESH
        '
        'BtnProcesar
        '
        Me.BtnProcesar.AllowAnimations = True
        Me.BtnProcesar.BackColor = System.Drawing.Color.Transparent
        Me.BtnProcesar.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.BtnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProcesar.HoverEffectsEnabled = True
        Me.BtnProcesar.Location = New System.Drawing.Point(356, 429)
        Me.BtnProcesar.Name = "BtnProcesar"
        Me.BtnProcesar.RoundedCornersMask = CType(15, Byte)
        Me.BtnProcesar.Size = New System.Drawing.Size(97, 54)
        Me.BtnProcesar.TabIndex = 101
        Me.BtnProcesar.Tag = "XC"
        Me.BtnProcesar.Text = "Procesar"
        Me.BtnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnProcesar.UseVisualStyleBackColor = False
        Me.BtnProcesar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.ORANGEFRESH
        '
        'DGEntrega
        '
        Me.DGEntrega.AllowUserToAddRows = False
        Me.DGEntrega.AllowUserToDeleteRows = False
        Me.DGEntrega.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DGEntrega.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGEntrega.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGEntrega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEntrega.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGEntrega.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGEntrega.Location = New System.Drawing.Point(469, 133)
        Me.DGEntrega.Name = "DGEntrega"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGEntrega.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGEntrega.RowTemplate.Height = 34
        Me.DGEntrega.Size = New System.Drawing.Size(345, 286)
        Me.DGEntrega.TabIndex = 100
        Me.DGEntrega.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre y descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Importe $M.N"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Precio"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'btn14
        '
        Me.btn14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn14.ForeColor = System.Drawing.Color.Olive
        Me.btn14.Location = New System.Drawing.Point(12, 134)
        Me.btn14.Name = "btn14"
        Me.btn14.Size = New System.Drawing.Size(100, 60)
        Me.btn14.TabIndex = 77
        Me.btn14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn14.UseVisualStyleBackColor = True
        '
        'btn11
        '
        Me.btn11.AllowAnimations = True
        Me.btn11.BackColor = System.Drawing.Color.Transparent
        Me.btn11.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btn11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn11.Location = New System.Drawing.Point(278, 316)
        Me.btn11.Name = "btn11"
        Me.btn11.RoundedCornersMask = CType(15, Byte)
        Me.btn11.Size = New System.Drawing.Size(88, 54)
        Me.btn11.TabIndex = 91
        Me.btn11.Text = "Enter"
        Me.btn11.UseVisualStyleBackColor = False
        Me.btn11.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.EXPRESSIONDARK
        '
        'btn0
        '
        Me.btn0.AllowAnimations = True
        Me.btn0.BackColor = System.Drawing.Color.Transparent
        Me.btn0.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btn0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(211, 316)
        Me.btn0.Name = "btn0"
        Me.btn0.RoundedCornersMask = CType(15, Byte)
        Me.btn0.Size = New System.Drawing.Size(60, 54)
        Me.btn0.TabIndex = 90
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        Me.btn0.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.EXPRESSIONDARK
        '
        'btn1
        '
        Me.btn1.AllowAnimations = True
        Me.btn1.BackColor = System.Drawing.Color.Transparent
        Me.btn1.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(145, 316)
        Me.btn1.Name = "btn1"
        Me.btn1.RoundedCornersMask = CType(15, Byte)
        Me.btn1.Size = New System.Drawing.Size(60, 54)
        Me.btn1.TabIndex = 89
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        Me.btn1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.EXPRESSIONDARK
        '
        'btn2
        '
        Me.btn2.AllowAnimations = True
        Me.btn2.BackColor = System.Drawing.Color.Transparent
        Me.btn2.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btn2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(79, 316)
        Me.btn2.Name = "btn2"
        Me.btn2.RoundedCornersMask = CType(15, Byte)
        Me.btn2.Size = New System.Drawing.Size(60, 54)
        Me.btn2.TabIndex = 88
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        Me.btn2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.EXPRESSIONDARK
        '
        'btn3
        '
        Me.btn3.AllowAnimations = True
        Me.btn3.BackColor = System.Drawing.Color.Transparent
        Me.btn3.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btn3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(13, 316)
        Me.btn3.Name = "btn3"
        Me.btn3.RoundedCornersMask = CType(15, Byte)
        Me.btn3.Size = New System.Drawing.Size(60, 54)
        Me.btn3.TabIndex = 87
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        Me.btn3.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.EXPRESSIONDARK
        '
        'btn10
        '
        Me.btn10.AllowAnimations = True
        Me.btn10.BackColor = System.Drawing.Color.Transparent
        Me.btn10.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btn10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn10.Location = New System.Drawing.Point(409, 256)
        Me.btn10.Name = "btn10"
        Me.btn10.RoundedCornersMask = CType(15, Byte)
        Me.btn10.Size = New System.Drawing.Size(60, 54)
        Me.btn10.TabIndex = 86
        Me.btn10.UseVisualStyleBackColor = False
        Me.btn10.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.EXPRESSIONDARK
        '
        'btn4
        '
        Me.btn4.AllowAnimations = True
        Me.btn4.BackColor = System.Drawing.Color.Transparent
        Me.btn4.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btn4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(343, 256)
        Me.btn4.Name = "btn4"
        Me.btn4.RoundedCornersMask = CType(15, Byte)
        Me.btn4.Size = New System.Drawing.Size(60, 54)
        Me.btn4.TabIndex = 85
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        Me.btn4.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.EXPRESSIONDARK
        '
        'btn5
        '
        Me.btn5.AllowAnimations = True
        Me.btn5.BackColor = System.Drawing.Color.Transparent
        Me.btn5.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btn5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(278, 256)
        Me.btn5.Name = "btn5"
        Me.btn5.RoundedCornersMask = CType(15, Byte)
        Me.btn5.Size = New System.Drawing.Size(60, 54)
        Me.btn5.TabIndex = 84
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        Me.btn5.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.EXPRESSIONDARK
        '
        'btn6
        '
        Me.btn6.AllowAnimations = True
        Me.btn6.BackColor = System.Drawing.Color.Transparent
        Me.btn6.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btn6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(212, 256)
        Me.btn6.Name = "btn6"
        Me.btn6.RoundedCornersMask = CType(15, Byte)
        Me.btn6.Size = New System.Drawing.Size(60, 54)
        Me.btn6.TabIndex = 83
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        Me.btn6.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.EXPRESSIONDARK
        '
        'btn7
        '
        Me.btn7.AllowAnimations = True
        Me.btn7.BackColor = System.Drawing.Color.Transparent
        Me.btn7.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btn7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(146, 256)
        Me.btn7.Name = "btn7"
        Me.btn7.RoundedCornersMask = CType(15, Byte)
        Me.btn7.Size = New System.Drawing.Size(60, 54)
        Me.btn7.TabIndex = 82
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        Me.btn7.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.EXPRESSIONDARK
        '
        'btn8
        '
        Me.btn8.AllowAnimations = True
        Me.btn8.BackColor = System.Drawing.Color.Transparent
        Me.btn8.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btn8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(79, 256)
        Me.btn8.Name = "btn8"
        Me.btn8.RoundedCornersMask = CType(15, Byte)
        Me.btn8.Size = New System.Drawing.Size(60, 54)
        Me.btn8.TabIndex = 81
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        Me.btn8.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.EXPRESSIONDARK
        '
        'btn9
        '
        Me.btn9.AllowAnimations = True
        Me.btn9.BackColor = System.Drawing.Color.Transparent
        Me.btn9.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btn9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(13, 256)
        Me.btn9.Name = "btn9"
        Me.btn9.RoundedCornersMask = CType(15, Byte)
        Me.btn9.Size = New System.Drawing.Size(60, 54)
        Me.btn9.TabIndex = 80
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        Me.btn9.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.EXPRESSIONDARK
        '
        'btnb7
        '
        Me.btnb7.AllowAnimations = True
        Me.btnb7.BackColor = System.Drawing.Color.Transparent
        Me.btnb7.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btnb7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnb7.Location = New System.Drawing.Point(409, 196)
        Me.btnb7.Name = "btnb7"
        Me.btnb7.RoundedCornersMask = CType(15, Byte)
        Me.btnb7.Size = New System.Drawing.Size(60, 54)
        Me.btnb7.TabIndex = 99
        Me.btnb7.UseVisualStyleBackColor = False
        Me.btnb7.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'BtnGuardar
        '
        Me.BtnGuardar.AllowAnimations = True
        Me.BtnGuardar.BackColor = System.Drawing.Color.Transparent
        Me.BtnGuardar.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.BtnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.HoverEffectsEnabled = True
        Me.BtnGuardar.Location = New System.Drawing.Point(372, 316)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.RoundedCornersMask = CType(15, Byte)
        Me.BtnGuardar.Size = New System.Drawing.Size(97, 54)
        Me.BtnGuardar.TabIndex = 92
        Me.BtnGuardar.Tag = "XC"
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGuardar.UseVisualStyleBackColor = False
        Me.BtnGuardar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.ORANGEFRESH
        '
        'btnb6
        '
        Me.btnb6.AllowAnimations = True
        Me.btnb6.BackColor = System.Drawing.Color.Transparent
        Me.btnb6.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btnb6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnb6.Location = New System.Drawing.Point(343, 196)
        Me.btnb6.Name = "btnb6"
        Me.btnb6.RoundedCornersMask = CType(15, Byte)
        Me.btnb6.Size = New System.Drawing.Size(60, 54)
        Me.btnb6.TabIndex = 98
        Me.btnb6.Text = "D100"
        Me.btnb6.UseVisualStyleBackColor = False
        Me.btnb6.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'btnb5
        '
        Me.btnb5.AllowAnimations = True
        Me.btnb5.BackColor = System.Drawing.Color.Transparent
        Me.btnb5.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btnb5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnb5.Location = New System.Drawing.Point(277, 196)
        Me.btnb5.Name = "btnb5"
        Me.btnb5.RoundedCornersMask = CType(15, Byte)
        Me.btnb5.Size = New System.Drawing.Size(60, 54)
        Me.btnb5.TabIndex = 97
        Me.btnb5.Text = "D50"
        Me.btnb5.UseVisualStyleBackColor = False
        Me.btnb5.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'btnb4
        '
        Me.btnb4.AllowAnimations = True
        Me.btnb4.BackColor = System.Drawing.Color.Transparent
        Me.btnb4.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btnb4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnb4.Location = New System.Drawing.Point(211, 196)
        Me.btnb4.Name = "btnb4"
        Me.btnb4.RoundedCornersMask = CType(15, Byte)
        Me.btnb4.Size = New System.Drawing.Size(60, 54)
        Me.btnb4.TabIndex = 96
        Me.btnb4.Text = "D20"
        Me.btnb4.UseVisualStyleBackColor = False
        Me.btnb4.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'btnb3
        '
        Me.btnb3.AllowAnimations = True
        Me.btnb3.BackColor = System.Drawing.Color.Transparent
        Me.btnb3.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btnb3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnb3.Location = New System.Drawing.Point(145, 196)
        Me.btnb3.Name = "btnb3"
        Me.btnb3.RoundedCornersMask = CType(15, Byte)
        Me.btnb3.Size = New System.Drawing.Size(60, 54)
        Me.btnb3.TabIndex = 95
        Me.btnb3.Text = "D10"
        Me.btnb3.UseVisualStyleBackColor = False
        Me.btnb3.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'btnb2
        '
        Me.btnb2.AllowAnimations = True
        Me.btnb2.BackColor = System.Drawing.Color.Transparent
        Me.btnb2.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btnb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnb2.Location = New System.Drawing.Point(79, 196)
        Me.btnb2.Name = "btnb2"
        Me.btnb2.RoundedCornersMask = CType(15, Byte)
        Me.btnb2.Size = New System.Drawing.Size(60, 54)
        Me.btnb2.TabIndex = 94
        Me.btnb2.Text = "D5"
        Me.btnb2.UseVisualStyleBackColor = False
        Me.btnb2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'btn13
        '
        Me.btn13.AllowAnimations = True
        Me.btn13.BackColor = System.Drawing.Color.Transparent
        Me.btn13.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btn13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn13.Location = New System.Drawing.Point(114, 136)
        Me.btn13.Name = "btn13"
        Me.btn13.RoundedCornersMask = CType(15, Byte)
        Me.btn13.Size = New System.Drawing.Size(138, 54)
        Me.btn13.TabIndex = 78
        Me.btn13.UseVisualStyleBackColor = False
        Me.btn13.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER
        '
        'btn12
        '
        Me.btn12.AllowAnimations = True
        Me.btn12.BackColor = System.Drawing.Color.Transparent
        Me.btn12.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btn12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn12.Location = New System.Drawing.Point(253, 136)
        Me.btn12.Name = "btn12"
        Me.btn12.RoundedCornersMask = CType(15, Byte)
        Me.btn12.Size = New System.Drawing.Size(216, 54)
        Me.btn12.TabIndex = 79
        Me.btn12.Text = "0"
        Me.btn12.UseVisualStyleBackColor = False
        Me.btn12.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER
        '
        'btnb1
        '
        Me.btnb1.AllowAnimations = True
        Me.btnb1.BackColor = System.Drawing.Color.Transparent
        Me.btnb1.FocusColor = System.Drawing.Color.WhiteSmoke
        Me.btnb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnb1.Location = New System.Drawing.Point(13, 196)
        Me.btnb1.Name = "btnb1"
        Me.btnb1.RoundedCornersMask = CType(15, Byte)
        Me.btnb1.Size = New System.Drawing.Size(60, 54)
        Me.btnb1.TabIndex = 93
        Me.btnb1.Text = "D1"
        Me.btnb1.UseVisualStyleBackColor = False
        Me.btnb1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'dgvCoV
        '
        Me.dgvCoV.AllowUserToAddRows = False
        Me.dgvCoV.AllowUserToDeleteRows = False
        Me.dgvCoV.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCoV.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCoV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCoV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCoV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.Nombre, Me.Cantidad, Me.Importe, Me.Precio})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCoV.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCoV.Location = New System.Drawing.Point(469, 134)
        Me.dgvCoV.Name = "dgvCoV"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCoV.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvCoV.RowTemplate.Height = 34
        Me.dgvCoV.Size = New System.Drawing.Size(345, 286)
        Me.dgvCoV.TabIndex = 75
        '
        'codigo
        '
        Me.codigo.HeaderText = "codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.Visible = False
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre y descripción"
        Me.Nombre.Name = "Nombre"
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'Importe
        '
        Me.Importe.HeaderText = "Importe $M.N"
        Me.Importe.Name = "Importe"
        '
        'Precio
        '
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Silver
        Me.PictureBox1.Location = New System.Drawing.Point(12, 134)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(461, 286)
        Me.PictureBox1.TabIndex = 76
        Me.PictureBox1.TabStop = False
        '
        'FrmFraccionarD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(993, 499)
        Me.ControlBox = False
        Me.Controls.Add(Me.DTExistencia)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnProcesar)
        Me.Controls.Add(Me.DGEntrega)
        Me.Controls.Add(Me.btn14)
        Me.Controls.Add(Me.btn11)
        Me.Controls.Add(Me.btn0)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn3)
        Me.Controls.Add(Me.btn10)
        Me.Controls.Add(Me.btn4)
        Me.Controls.Add(Me.btn5)
        Me.Controls.Add(Me.btn6)
        Me.Controls.Add(Me.btn7)
        Me.Controls.Add(Me.btn8)
        Me.Controls.Add(Me.btn9)
        Me.Controls.Add(Me.btnb7)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnb6)
        Me.Controls.Add(Me.btnb5)
        Me.Controls.Add(Me.btnb4)
        Me.Controls.Add(Me.btnb3)
        Me.Controls.Add(Me.btnb2)
        Me.Controls.Add(Me.btn13)
        Me.Controls.Add(Me.btn12)
        Me.Controls.Add(Me.btnb1)
        Me.Controls.Add(Me.dgvCoV)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.vbtnd1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtmonto2)
        Me.Controls.Add(Me.txtmonto1)
        Me.Controls.Add(Me.lblm2)
        Me.Controls.Add(Me.lblm1)
        Me.Name = "FrmFraccionarD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fraccionar"
        CType(Me.DTExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGEntrega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCoV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents vbtnd1 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtmonto2 As VIBlend.WinForms.Controls.vTextBox
    Friend WithEvents txtmonto1 As VIBlend.WinForms.Controls.vTextBox
    Friend WithEvents lblm2 As System.Windows.Forms.Label
    Friend WithEvents lblm1 As System.Windows.Forms.Label
    Friend WithEvents DTExistencia As System.Windows.Forms.DataGridView
    Friend WithEvents BtnCancelar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents BtnProcesar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents DGEntrega As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn14 As System.Windows.Forms.Button
    Friend WithEvents btn11 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btn0 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btn1 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btn2 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btn3 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btn10 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btn4 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btn5 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btn6 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btn7 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btn8 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btn9 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnb7 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents BtnGuardar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnb6 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnb5 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnb4 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnb3 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnb2 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btn13 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btn12 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnb1 As VIBlend.WinForms.Controls.vButton
    Friend WithEvents dgvCoV As System.Windows.Forms.DataGridView
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
