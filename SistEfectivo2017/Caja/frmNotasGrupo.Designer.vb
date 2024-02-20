<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotasGrupo
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
        Me.cmdGenerar = New System.Windows.Forms.Button()
        Me.lvClientes = New System.Windows.Forms.ListView()
        Me.Cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Importe = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdGenerar
        '
        Me.cmdGenerar.Location = New System.Drawing.Point(592, 433)
        Me.cmdGenerar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdGenerar.Name = "cmdGenerar"
        Me.cmdGenerar.Size = New System.Drawing.Size(168, 48)
        Me.cmdGenerar.TabIndex = 1
        Me.cmdGenerar.Text = "Generar"
        Me.cmdGenerar.UseVisualStyleBackColor = True
        '
        'lvClientes
        '
        Me.lvClientes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Cliente, Me.Nombre, Me.Importe})
        Me.lvClientes.HideSelection = False
        Me.lvClientes.Location = New System.Drawing.Point(47, 85)
        Me.lvClientes.Name = "lvClientes"
        Me.lvClientes.Size = New System.Drawing.Size(713, 340)
        Me.lvClientes.TabIndex = 2
        Me.lvClientes.UseCompatibleStateImageBehavior = False
        Me.lvClientes.View = System.Windows.Forms.View.Details
        '
        'Cliente
        '
        Me.Cliente.Text = "Cliente"
        Me.Cliente.Width = 100
        '
        'Nombre
        '
        Me.Nombre.Text = "Nombre"
        Me.Nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Nombre.Width = 400
        '
        'Importe
        '
        Me.Importe.Text = "Importe"
        Me.Importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Importe.Width = 150
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(112, 20)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(98, 26)
        Me.txtCliente.TabIndex = 0
        '
        'lbNombre
        '
        Me.lbNombre.Location = New System.Drawing.Point(214, 23)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(561, 24)
        Me.lbNombre.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Importe:"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(112, 53)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(137, 26)
        Me.txtCantidad.TabIndex = 1
        '
        'frmNotasGrupo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 488)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbNombre)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvClientes)
        Me.Controls.Add(Me.cmdGenerar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmNotasGrupo"
        Me.Text = "Notas en Grupo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdGenerar As Button
    Friend WithEvents lvClientes As ListView
    Friend WithEvents Cliente As ColumnHeader
    Friend WithEvents Nombre As ColumnHeader
    Friend WithEvents Importe As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents lbNombre As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCantidad As TextBox
End Class
