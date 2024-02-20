<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransferencias
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTransferencias))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvCoV = New System.Windows.Forms.DataGridView()
        Me.transferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.folio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvCoV2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.destino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.horad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvCoV4 = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtTransfer = New System.Windows.Forms.TextBox()
        Me.TxtImporteT = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.BtnConfirmar = New System.Windows.Forms.Button()
        Me.TxtImporteD = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtImporteE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtImporteC = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtImporteL = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtFolioDest = New System.Windows.Forms.TextBox()
        Me.TxtNoSucDest = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtMontoL = New System.Windows.Forms.TextBox()
        Me.TxtMontoC = New System.Windows.Forms.TextBox()
        Me.TxtMontoE = New System.Windows.Forms.TextBox()
        Me.TxtMontoD = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtCantL = New System.Windows.Forms.TextBox()
        Me.TxtCantC = New System.Windows.Forms.TextBox()
        Me.TxtCantE = New System.Windows.Forms.TextBox()
        Me.TxtCantD = New System.Windows.Forms.TextBox()
        Me.TxtTotalC = New System.Windows.Forms.TextBox()
        Me.TxtTotalM = New System.Windows.Forms.TextBox()
        Me.TxtTotalI = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BtnTraspasosDet = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblDestino = New System.Windows.Forms.Label()
        Me.TxtCantYe = New System.Windows.Forms.TextBox()
        Me.TxtCantF = New System.Windows.Forms.TextBox()
        Me.TxtCantDA = New System.Windows.Forms.TextBox()
        Me.TxtCantYu = New System.Windows.Forms.TextBox()
        Me.TxtMontoYe = New System.Windows.Forms.TextBox()
        Me.TxtMontoF = New System.Windows.Forms.TextBox()
        Me.TxtMontoDA = New System.Windows.Forms.TextBox()
        Me.TxtMontoYu = New System.Windows.Forms.TextBox()
        Me.txtImporteYe = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtImporteF = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtImporteDA = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtImporteYu = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.divisa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DivisaFoto = New System.Windows.Forms.DataGridViewImageColumn()
        Me.producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCoV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCoV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCoV4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dgvCoV)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(370, 218)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transferencias a Enviar"
        '
        'dgvCoV
        '
        Me.dgvCoV.AllowUserToAddRows = False
        Me.dgvCoV.AllowUserToDeleteRows = False
        Me.dgvCoV.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCoV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCoV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCoV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.transferencia, Me.Importe, Me.folio, Me.sucursal, Me.hora})
        Me.dgvCoV.Location = New System.Drawing.Point(19, 25)
        Me.dgvCoV.Name = "dgvCoV"
        Me.dgvCoV.ReadOnly = True
        Me.dgvCoV.RowHeadersVisible = False
        Me.dgvCoV.RowTemplate.Height = 34
        Me.dgvCoV.Size = New System.Drawing.Size(337, 177)
        Me.dgvCoV.TabIndex = 108
        '
        'transferencia
        '
        Me.transferencia.HeaderText = "# Transferencia"
        Me.transferencia.Name = "transferencia"
        Me.transferencia.ReadOnly = True
        Me.transferencia.Width = 130
        '
        'Importe
        '
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        '
        'folio
        '
        Me.folio.HeaderText = "folio"
        Me.folio.Name = "folio"
        Me.folio.ReadOnly = True
        Me.folio.Visible = False
        '
        'sucursal
        '
        Me.sucursal.HeaderText = "sucursal"
        Me.sucursal.Name = "sucursal"
        Me.sucursal.ReadOnly = True
        Me.sucursal.Visible = False
        '
        'hora
        '
        DataGridViewCellStyle1.Format = "t"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.hora.DefaultCellStyle = DataGridViewCellStyle1
        Me.hora.HeaderText = "Hora"
        Me.hora.Name = "hora"
        Me.hora.ReadOnly = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dgvCoV2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(384, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(383, 218)
        Me.GroupBox2.TabIndex = 109
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Transferencias a Recibir"
        '
        'dgvCoV2
        '
        Me.dgvCoV2.AllowUserToAddRows = False
        Me.dgvCoV2.AllowUserToDeleteRows = False
        Me.dgvCoV2.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCoV2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCoV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCoV2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.destino, Me.horad})
        Me.dgvCoV2.Location = New System.Drawing.Point(19, 25)
        Me.dgvCoV2.Name = "dgvCoV2"
        Me.dgvCoV2.ReadOnly = True
        Me.dgvCoV2.RowHeadersVisible = False
        Me.dgvCoV2.RowTemplate.Height = 34
        Me.dgvCoV2.Size = New System.Drawing.Size(348, 177)
        Me.dgvCoV2.TabIndex = 108
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "# Transferencia"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 130
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Importe"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'destino
        '
        Me.destino.HeaderText = "destino"
        Me.destino.Name = "destino"
        Me.destino.ReadOnly = True
        Me.destino.Visible = False
        '
        'horad
        '
        DataGridViewCellStyle2.Format = "t"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.horad.DefaultCellStyle = DataGridViewCellStyle2
        Me.horad.HeaderText = "Hora"
        Me.horad.Name = "horad"
        Me.horad.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 239)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 20)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "# Transferencia:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(310, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 20)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "Importe Total:"
        '
        'dgvCoV4
        '
        Me.dgvCoV4.AllowUserToAddRows = False
        Me.dgvCoV4.AllowUserToDeleteRows = False
        Me.dgvCoV4.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCoV4.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCoV4.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCoV4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCoV4.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.divisa, Me.DivisaFoto, Me.producto, Me.Cantidad, Me.Monto, Me.Precio, Me.DataGridViewTextBoxColumn5})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCoV4.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCoV4.Location = New System.Drawing.Point(4, 268)
        Me.dgvCoV4.Name = "dgvCoV4"
        Me.dgvCoV4.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCoV4.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCoV4.RowHeadersVisible = False
        Me.dgvCoV4.RowTemplate.Height = 50
        Me.dgvCoV4.Size = New System.Drawing.Size(747, 331)
        Me.dgvCoV4.TabIndex = 113
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(731, 576)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 20)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Contraseña:"
        '
        'TxtTransfer
        '
        Me.TxtTransfer.Enabled = False
        Me.TxtTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTransfer.Location = New System.Drawing.Point(146, 236)
        Me.TxtTransfer.Name = "TxtTransfer"
        Me.TxtTransfer.Size = New System.Drawing.Size(100, 26)
        Me.TxtTransfer.TabIndex = 115
        '
        'TxtImporteT
        '
        Me.TxtImporteT.Enabled = False
        Me.TxtImporteT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImporteT.Location = New System.Drawing.Point(423, 236)
        Me.TxtImporteT.Name = "TxtImporteT"
        Me.TxtImporteT.Size = New System.Drawing.Size(100, 26)
        Me.TxtImporteT.TabIndex = 116
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(833, 573)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox3.Size = New System.Drawing.Size(100, 26)
        Me.TextBox3.TabIndex = 117
        '
        'BtnConfirmar
        '
        Me.BtnConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfirmar.Location = New System.Drawing.Point(968, 573)
        Me.BtnConfirmar.Name = "BtnConfirmar"
        Me.BtnConfirmar.Size = New System.Drawing.Size(115, 33)
        Me.BtnConfirmar.TabIndex = 118
        Me.BtnConfirmar.Text = "Confirmar"
        Me.BtnConfirmar.UseVisualStyleBackColor = True
        '
        'TxtImporteD
        '
        Me.TxtImporteD.Enabled = False
        Me.TxtImporteD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImporteD.Location = New System.Drawing.Point(872, 37)
        Me.TxtImporteD.Name = "TxtImporteD"
        Me.TxtImporteD.Size = New System.Drawing.Size(98, 24)
        Me.TxtImporteD.TabIndex = 123
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(775, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 18)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "Dolares:"
        '
        'TxtImporteE
        '
        Me.TxtImporteE.Enabled = False
        Me.TxtImporteE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImporteE.Location = New System.Drawing.Point(872, 78)
        Me.TxtImporteE.Name = "TxtImporteE"
        Me.TxtImporteE.Size = New System.Drawing.Size(98, 24)
        Me.TxtImporteE.TabIndex = 125
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(775, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 18)
        Me.Label6.TabIndex = 124
        Me.Label6.Text = "Euros:"
        '
        'TxtImporteC
        '
        Me.TxtImporteC.Enabled = False
        Me.TxtImporteC.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImporteC.Location = New System.Drawing.Point(872, 119)
        Me.TxtImporteC.Name = "TxtImporteC"
        Me.TxtImporteC.Size = New System.Drawing.Size(98, 24)
        Me.TxtImporteC.TabIndex = 127
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(775, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 18)
        Me.Label7.TabIndex = 126
        Me.Label7.Text = "Canadienses:"
        '
        'TxtImporteL
        '
        Me.TxtImporteL.Enabled = False
        Me.TxtImporteL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImporteL.Location = New System.Drawing.Point(872, 160)
        Me.TxtImporteL.Name = "TxtImporteL"
        Me.TxtImporteL.Size = New System.Drawing.Size(98, 24)
        Me.TxtImporteL.TabIndex = 129
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(775, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 18)
        Me.Label8.TabIndex = 128
        Me.Label8.Text = "Libras:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(868, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 18)
        Me.Label9.TabIndex = 130
        Me.Label9.Text = "Importe $M.N:"
        '
        'TxtFolioDest
        '
        Me.TxtFolioDest.Enabled = False
        Me.TxtFolioDest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolioDest.Location = New System.Drawing.Point(529, 236)
        Me.TxtFolioDest.Name = "TxtFolioDest"
        Me.TxtFolioDest.Size = New System.Drawing.Size(100, 26)
        Me.TxtFolioDest.TabIndex = 132
        Me.TxtFolioDest.Visible = False
        '
        'TxtNoSucDest
        '
        Me.TxtNoSucDest.Enabled = False
        Me.TxtNoSucDest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoSucDest.Location = New System.Drawing.Point(633, 236)
        Me.TxtNoSucDest.Name = "TxtNoSucDest"
        Me.TxtNoSucDest.Size = New System.Drawing.Size(78, 26)
        Me.TxtNoSucDest.TabIndex = 133
        Me.TxtNoSucDest.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1000, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 18)
        Me.Label4.TabIndex = 138
        Me.Label4.Text = "Monto"
        '
        'TxtMontoL
        '
        Me.TxtMontoL.Enabled = False
        Me.TxtMontoL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoL.Location = New System.Drawing.Point(976, 160)
        Me.TxtMontoL.Name = "TxtMontoL"
        Me.TxtMontoL.Size = New System.Drawing.Size(98, 24)
        Me.TxtMontoL.TabIndex = 137
        '
        'TxtMontoC
        '
        Me.TxtMontoC.Enabled = False
        Me.TxtMontoC.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoC.Location = New System.Drawing.Point(976, 119)
        Me.TxtMontoC.Name = "TxtMontoC"
        Me.TxtMontoC.Size = New System.Drawing.Size(98, 24)
        Me.TxtMontoC.TabIndex = 136
        '
        'TxtMontoE
        '
        Me.TxtMontoE.Enabled = False
        Me.TxtMontoE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoE.Location = New System.Drawing.Point(976, 78)
        Me.TxtMontoE.Name = "TxtMontoE"
        Me.TxtMontoE.Size = New System.Drawing.Size(98, 24)
        Me.TxtMontoE.TabIndex = 135
        '
        'TxtMontoD
        '
        Me.TxtMontoD.Enabled = False
        Me.TxtMontoD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoD.Location = New System.Drawing.Point(976, 37)
        Me.TxtMontoD.Name = "TxtMontoD"
        Me.TxtMontoD.Size = New System.Drawing.Size(98, 24)
        Me.TxtMontoD.TabIndex = 134
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1091, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 18)
        Me.Label10.TabIndex = 143
        Me.Label10.Text = "Cant."
        '
        'TxtCantL
        '
        Me.TxtCantL.Enabled = False
        Me.TxtCantL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantL.Location = New System.Drawing.Point(1080, 160)
        Me.TxtCantL.Name = "TxtCantL"
        Me.TxtCantL.Size = New System.Drawing.Size(63, 24)
        Me.TxtCantL.TabIndex = 142
        '
        'TxtCantC
        '
        Me.TxtCantC.Enabled = False
        Me.TxtCantC.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantC.Location = New System.Drawing.Point(1080, 119)
        Me.TxtCantC.Name = "TxtCantC"
        Me.TxtCantC.Size = New System.Drawing.Size(63, 24)
        Me.TxtCantC.TabIndex = 141
        '
        'TxtCantE
        '
        Me.TxtCantE.Enabled = False
        Me.TxtCantE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantE.Location = New System.Drawing.Point(1080, 78)
        Me.TxtCantE.Name = "TxtCantE"
        Me.TxtCantE.Size = New System.Drawing.Size(63, 24)
        Me.TxtCantE.TabIndex = 140
        '
        'TxtCantD
        '
        Me.TxtCantD.Enabled = False
        Me.TxtCantD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantD.Location = New System.Drawing.Point(1080, 37)
        Me.TxtCantD.Name = "TxtCantD"
        Me.TxtCantD.Size = New System.Drawing.Size(63, 24)
        Me.TxtCantD.TabIndex = 139
        '
        'TxtTotalC
        '
        Me.TxtTotalC.Enabled = False
        Me.TxtTotalC.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalC.Location = New System.Drawing.Point(1080, 370)
        Me.TxtTotalC.Name = "TxtTotalC"
        Me.TxtTotalC.Size = New System.Drawing.Size(63, 24)
        Me.TxtTotalC.TabIndex = 147
        '
        'TxtTotalM
        '
        Me.TxtTotalM.Enabled = False
        Me.TxtTotalM.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalM.Location = New System.Drawing.Point(976, 370)
        Me.TxtTotalM.Name = "TxtTotalM"
        Me.TxtTotalM.Size = New System.Drawing.Size(98, 24)
        Me.TxtTotalM.TabIndex = 146
        '
        'TxtTotalI
        '
        Me.TxtTotalI.Enabled = False
        Me.TxtTotalI.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalI.Location = New System.Drawing.Point(872, 370)
        Me.TxtTotalI.Name = "TxtTotalI"
        Me.TxtTotalI.Size = New System.Drawing.Size(98, 24)
        Me.TxtTotalI.TabIndex = 145
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(775, 373)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 18)
        Me.Label11.TabIndex = 144
        Me.Label11.Text = "Total:"
        '
        'BtnTraspasosDet
        '
        Me.BtnTraspasosDet.BackColor = System.Drawing.Color.Goldenrod
        Me.BtnTraspasosDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnTraspasosDet.Location = New System.Drawing.Point(968, 503)
        Me.BtnTraspasosDet.Name = "BtnTraspasosDet"
        Me.BtnTraspasosDet.Size = New System.Drawing.Size(111, 48)
        Me.BtnTraspasosDet.TabIndex = 148
        Me.BtnTraspasosDet.Text = "Reporte de Traspasos"
        Me.BtnTraspasosDet.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(775, 428)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 18)
        Me.Label12.TabIndex = 149
        Me.Label12.Text = "Destino:"
        '
        'LblDestino
        '
        Me.LblDestino.AutoSize = True
        Me.LblDestino.BackColor = System.Drawing.Color.Transparent
        Me.LblDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDestino.Location = New System.Drawing.Point(869, 428)
        Me.LblDestino.Name = "LblDestino"
        Me.LblDestino.Size = New System.Drawing.Size(104, 18)
        Me.LblDestino.TabIndex = 150
        Me.LblDestino.Text = "____________"
        '
        'TxtCantYe
        '
        Me.TxtCantYe.Enabled = False
        Me.TxtCantYe.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantYe.Location = New System.Drawing.Point(1080, 325)
        Me.TxtCantYe.Name = "TxtCantYe"
        Me.TxtCantYe.Size = New System.Drawing.Size(63, 24)
        Me.TxtCantYe.TabIndex = 166
        '
        'TxtCantF
        '
        Me.TxtCantF.Enabled = False
        Me.TxtCantF.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantF.Location = New System.Drawing.Point(1080, 284)
        Me.TxtCantF.Name = "TxtCantF"
        Me.TxtCantF.Size = New System.Drawing.Size(63, 24)
        Me.TxtCantF.TabIndex = 165
        '
        'TxtCantDA
        '
        Me.TxtCantDA.Enabled = False
        Me.TxtCantDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantDA.Location = New System.Drawing.Point(1080, 243)
        Me.TxtCantDA.Name = "TxtCantDA"
        Me.TxtCantDA.Size = New System.Drawing.Size(63, 24)
        Me.TxtCantDA.TabIndex = 164
        '
        'TxtCantYu
        '
        Me.TxtCantYu.Enabled = False
        Me.TxtCantYu.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantYu.Location = New System.Drawing.Point(1080, 202)
        Me.TxtCantYu.Name = "TxtCantYu"
        Me.TxtCantYu.Size = New System.Drawing.Size(63, 24)
        Me.TxtCantYu.TabIndex = 163
        '
        'TxtMontoYe
        '
        Me.TxtMontoYe.Enabled = False
        Me.TxtMontoYe.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoYe.Location = New System.Drawing.Point(976, 325)
        Me.TxtMontoYe.Name = "TxtMontoYe"
        Me.TxtMontoYe.Size = New System.Drawing.Size(98, 24)
        Me.TxtMontoYe.TabIndex = 162
        '
        'TxtMontoF
        '
        Me.TxtMontoF.Enabled = False
        Me.TxtMontoF.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoF.Location = New System.Drawing.Point(976, 284)
        Me.TxtMontoF.Name = "TxtMontoF"
        Me.TxtMontoF.Size = New System.Drawing.Size(98, 24)
        Me.TxtMontoF.TabIndex = 161
        '
        'TxtMontoDA
        '
        Me.TxtMontoDA.Enabled = False
        Me.TxtMontoDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoDA.Location = New System.Drawing.Point(976, 243)
        Me.TxtMontoDA.Name = "TxtMontoDA"
        Me.TxtMontoDA.Size = New System.Drawing.Size(98, 24)
        Me.TxtMontoDA.TabIndex = 160
        '
        'TxtMontoYu
        '
        Me.TxtMontoYu.Enabled = False
        Me.TxtMontoYu.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoYu.Location = New System.Drawing.Point(976, 202)
        Me.TxtMontoYu.Name = "TxtMontoYu"
        Me.TxtMontoYu.Size = New System.Drawing.Size(98, 24)
        Me.TxtMontoYu.TabIndex = 159
        '
        'txtImporteYe
        '
        Me.txtImporteYe.Enabled = False
        Me.txtImporteYe.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteYe.Location = New System.Drawing.Point(872, 325)
        Me.txtImporteYe.Name = "txtImporteYe"
        Me.txtImporteYe.Size = New System.Drawing.Size(98, 24)
        Me.txtImporteYe.TabIndex = 158
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(775, 328)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 18)
        Me.Label13.TabIndex = 157
        Me.Label13.Text = "Yen Japones:"
        '
        'txtImporteF
        '
        Me.txtImporteF.Enabled = False
        Me.txtImporteF.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteF.Location = New System.Drawing.Point(872, 284)
        Me.txtImporteF.Name = "txtImporteF"
        Me.txtImporteF.Size = New System.Drawing.Size(98, 24)
        Me.txtImporteF.TabIndex = 156
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(775, 287)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 18)
        Me.Label14.TabIndex = 155
        Me.Label14.Text = "Franco:"
        '
        'txtImporteDA
        '
        Me.txtImporteDA.Enabled = False
        Me.txtImporteDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteDA.Location = New System.Drawing.Point(872, 243)
        Me.txtImporteDA.Name = "txtImporteDA"
        Me.txtImporteDA.Size = New System.Drawing.Size(98, 24)
        Me.txtImporteDA.TabIndex = 154
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(775, 246)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 18)
        Me.Label15.TabIndex = 153
        Me.Label15.Text = "Australiano:"
        '
        'txtImporteYu
        '
        Me.txtImporteYu.Enabled = False
        Me.txtImporteYu.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteYu.Location = New System.Drawing.Point(872, 202)
        Me.txtImporteYu.Name = "txtImporteYu"
        Me.txtImporteYu.Size = New System.Drawing.Size(98, 24)
        Me.txtImporteYu.TabIndex = 152
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(775, 205)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 18)
        Me.Label16.TabIndex = 151
        Me.Label16.Text = "Yuan:"
        '
        'divisa
        '
        Me.divisa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.divisa.HeaderText = "Divisa"
        Me.divisa.Name = "divisa"
        Me.divisa.ReadOnly = True
        Me.divisa.Width = 130
        '
        'DivisaFoto
        '
        Me.DivisaFoto.HeaderText = "Divisa_foto"
        Me.DivisaFoto.Name = "DivisaFoto"
        Me.DivisaFoto.ReadOnly = True
        Me.DivisaFoto.Width = 150
        '
        'producto
        '
        Me.producto.HeaderText = "Producto"
        Me.producto.Name = "producto"
        Me.producto.ReadOnly = True
        '
        'Cantidad
        '
        Me.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Width = 85
        '
        'Monto
        '
        Me.Monto.HeaderText = "Monto"
        Me.Monto.Name = "Monto"
        Me.Monto.ReadOnly = True
        '
        'Precio
        '
        Me.Precio.HeaderText = "P.Unitario"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Importe $M.N"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 140
        '
        'FrmTransferencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1151, 611)
        Me.Controls.Add(Me.TxtCantYe)
        Me.Controls.Add(Me.TxtCantF)
        Me.Controls.Add(Me.TxtCantDA)
        Me.Controls.Add(Me.TxtCantYu)
        Me.Controls.Add(Me.TxtMontoYe)
        Me.Controls.Add(Me.TxtMontoF)
        Me.Controls.Add(Me.TxtMontoDA)
        Me.Controls.Add(Me.TxtMontoYu)
        Me.Controls.Add(Me.txtImporteYe)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtImporteF)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtImporteDA)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtImporteYu)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.LblDestino)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.BtnTraspasosDet)
        Me.Controls.Add(Me.TxtTotalC)
        Me.Controls.Add(Me.TxtTotalM)
        Me.Controls.Add(Me.TxtTotalI)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtCantL)
        Me.Controls.Add(Me.TxtCantC)
        Me.Controls.Add(Me.TxtCantE)
        Me.Controls.Add(Me.TxtCantD)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtMontoL)
        Me.Controls.Add(Me.TxtMontoC)
        Me.Controls.Add(Me.TxtMontoE)
        Me.Controls.Add(Me.TxtMontoD)
        Me.Controls.Add(Me.TxtNoSucDest)
        Me.Controls.Add(Me.TxtFolioDest)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtImporteL)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtImporteC)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtImporteE)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtImporteD)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnConfirmar)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TxtImporteT)
        Me.Controls.Add(Me.TxtTransfer)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvCoV4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MinimizeBox = False
        Me.Name = "FrmTransferencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transferencias"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvCoV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvCoV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCoV4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCoV As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCoV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvCoV4 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtTransfer As System.Windows.Forms.TextBox
    Friend WithEvents TxtImporteT As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents BtnConfirmar As System.Windows.Forms.Button
    Friend WithEvents TxtImporteD As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtImporteE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtImporteC As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtImporteL As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtFolioDest As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoSucDest As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtMontoL As System.Windows.Forms.TextBox
    Friend WithEvents TxtMontoC As System.Windows.Forms.TextBox
    Friend WithEvents TxtMontoE As System.Windows.Forms.TextBox
    Friend WithEvents TxtMontoD As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtCantL As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantC As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantE As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantD As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotalC As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotalM As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotalI As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BtnTraspasosDet As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents LblDestino As System.Windows.Forms.Label
    Friend WithEvents transferencia As DataGridViewTextBoxColumn
    Friend WithEvents Importe As DataGridViewTextBoxColumn
    Friend WithEvents folio As DataGridViewTextBoxColumn
    Friend WithEvents sucursal As DataGridViewTextBoxColumn
    Friend WithEvents hora As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents destino As DataGridViewTextBoxColumn
    Friend WithEvents horad As DataGridViewTextBoxColumn
    Friend WithEvents TxtCantYe As TextBox
    Friend WithEvents TxtCantF As TextBox
    Friend WithEvents TxtCantDA As TextBox
    Friend WithEvents TxtCantYu As TextBox
    Friend WithEvents TxtMontoYe As TextBox
    Friend WithEvents TxtMontoF As TextBox
    Friend WithEvents TxtMontoDA As TextBox
    Friend WithEvents TxtMontoYu As TextBox
    Friend WithEvents txtImporteYe As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtImporteF As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtImporteDA As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtImporteYu As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents divisa As DataGridViewTextBoxColumn
    Friend WithEvents DivisaFoto As DataGridViewImageColumn
    Friend WithEvents producto As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents Monto As DataGridViewTextBoxColumn
    Friend WithEvents Precio As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
End Class
