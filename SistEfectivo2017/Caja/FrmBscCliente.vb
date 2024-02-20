Imports System.Drawing

Public Class FrmBscCliente
    Dim oclientescnbvM As New clientescnbvM
    Dim oclientescnbvC As New clientescnbvC
    Dim dt As DataTable
    Dim source1 As New BindingSource()
    Public clave As String = ""

    Private Sub FrmBscCliente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oclientescnbvC.Dispose()
        dt.Dispose()
        source1.Dispose()
    End Sub

    Private Sub FrmBscCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        Me.Height = Screen.PrimaryScreen.WorkingArea.Height / 1.1
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)
        dgvClientes.Width = Me.Width / 1.1
        dgvClientes.Height = (Me.Height - GroupBox1.Height * 1.7)
        Buscar1("", "")
        dgvClientes.EnableHeadersVisualStyles = False
        dgvClientes.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
    End Sub

    Private Sub Buscar1(ByVal f1 As String, ByVal f2 As String)
        dt = oclientescnbvC.Fclientecnbv(oclientescnbvM, f1, f2).Tables(0)
        source1.DataSource = dt
        dgvClientes.DataSource = source1
        'comentar la lina de abajo ("cliente") para mostrar la columna ID
        dgvClientes.Columns("ApellidoPaterno").Width = 200
        dgvClientes.Columns("ApellidoMaterno").Width = 200
        dgvClientes.Columns("Nombre").Width = 200
        dgvClientes.Columns("Direccion").Width = 200
        dgvClientes.Columns("Direccion1").Width = 200
        dgvClientes.Columns("Colonia").Width = 200
        dgvClientes.Columns("Municipio").Width = 200
        dgvClientes.Columns("Estado").Width = 200
        dgvClientes.Columns("Identificacion").Width = 200
        DesabilitaOrdenarcion()
    End Sub

    Private Sub DesabilitaOrdenarcion()
        Dim x As DataGridViewColumn
        For Each x In Me.dgvClientes.Columns
            x.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        dgvClientes.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 14, FontStyle.Bold)
    End Sub

    Private Sub Buscar2()
        dt = oclientescnbvC.Sclientecnbv2(oclientescnbvM).Tables(0)
        dgvClientes.DataSource = dt
        dgvClientes.Columns("cliente").Visible = False
    End Sub

    Private Sub dgvClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellDoubleClick
        clave = dgvClientes.CurrentRow.Cells("cliente").Value.ToString()
        Close()
    End Sub

    Private Sub VButton2_Click(sender As Object, e As EventArgs) Handles VButton2.Click
        Close()
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(Keys.Tab) Or e.KeyChar = ChrW(Keys.Enter) Then
            If Not txtApellidoP.Text.Trim() = "" Then
                txtApellidoP.Text = txtApellidoP.Text.Trim()
                oclientescnbvM.ApellidoPaterno = txtApellidoP.Text.Trim()
            End If
            If Not txtNombre.Text.Trim() = "" Then
                txtNombre.Text = txtNombre.Text.Trim()
                oclientescnbvM.Nombre = txtNombre.Text.Trim()
            End If
            'Buscar1("%", "")
            If txtNombre.Text = "" Then
                txtNombre.Focus()
            End If
        End If
    End Sub

    Private Sub VButton1_Click(sender As Object, e As EventArgs) Handles VButton1.Click
        LimpiarControles()
        oclientescnbvM.Nombre = Nothing
        oclientescnbvM.ApellidoPaterno = Nothing
        Buscar1("", "")
        txtApellidoP.Focus()
    End Sub

    Private Sub LimpiarControles()
        txtApellidoP.Text = ""
        txtNombre.Text = ""
        txtApellidoM.Text = ""
        dgvClientes.DataSource = Nothing
        dgvClientes.Refresh()
        source1.DataSource = Nothing
    End Sub

    Private Sub Aplicar_Filtro()
        If source1 Is Nothing Then
            txtApellidoP.BackColor = Color.Olive
            txtNombre.BackColor = Color.Olive
            Exit Sub
        End If

        Try
            Dim filtro As String = String.Empty
            If txtNombre.Text <> "" Then
                filtro += "[Nombre] like '%" & txtNombre.Text.Trim & "%' and"
            End If
            If txtApellidoP.Text <> "" Then
                filtro += "[ApellidoPaterno] like '%" & txtApellidoP.Text.Trim & "%' and"
            End If
            If txtApellidoM.Text <> "" Then
                filtro += "[ApellidoMaterno] like '%" & txtApellidoM.Text.Trim & "%' and"
            End If

            If filtro.Trim().Length > 1 Then
                filtro = filtro.Remove(filtro.Length - 3, 3)
            End If

            source1.Filter = filtro
            If source1.Count = 0 Then
                txtApellidoP.BackColor = Color.Lime
                txtNombre.BackColor = Color.Lime
            Else
                txtApellidoP.BackColor = Color.White
                txtNombre.BackColor = Color.White
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        Aplicar_Filtro()
    End Sub

    Private Sub txtApellidoP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellidoP.KeyPress
        If e.KeyChar = ChrW(Keys.Tab) Or e.KeyChar = ChrW(Keys.Enter) Then
            txtApellidoP.Focus()
        End If
    End Sub

    Private Sub txtApellidoP_TextChanged(sender As Object, e As EventArgs) Handles txtApellidoP.TextChanged
        Aplicar_Filtro()
    End Sub

    Private Sub dgvClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvClientes.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            clave = dgvClientes.CurrentRow.Cells("cliente").Value.ToString()
            Close()
        End If
    End Sub

    Private Sub btnImg_Click(sender As Object, e As EventArgs) Handles btnImg.Click
        Me.Cursor = Cursors.WaitCursor
        Dim dtc As DataTable
        Dim ruta As String = "D:\IDENTIFICACIONES\"
        Dim A, B As String
        Dim clienteNo As Integer
        For x As Integer = 0 To dgvClientes.RowCount - 1
            A = ""
            B = ""
            clienteNo = Convert.ToInt32(dgvClientes.Rows(x).Cells("cliente").Value)
            dtc = oclientescnbvC.Imagen(Convert.ToInt32(dgvClientes.Rows(x).Cells("cliente").Value))
            If System.IO.File.Exists(ruta & dtc.Rows(0)("cliente").ToString & "A.jpg") Then
                A = ruta & dtc.Rows(0)("cliente").ToString & "A.jpg"

            End If
            If System.IO.File.Exists(ruta & dtc.Rows(0)("cliente").ToString & "B.jpg") Then
                B = ruta & dtc.Rows(0)("cliente").ToString & "B.jpg"
            End If
            oclientescnbvC.Mimagen(clienteNo, A, B)
        Next
        Me.Cursor = Cursors.Default
        MessageBox.Show("completado")
    End Sub

    Private Sub btnImagen2_Click(sender As Object, e As EventArgs) Handles btnImagen2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim carpeta As String = "D:\IDENTIFICACIONES\localizadas\"
        Dim Aa As String = "A"
        Dim Bb As String = "B"
        Dim extension As String = ""
        Dim Files As String(), File As String
        Files = IO.Directory.GetFiles(carpeta, "*.JPG")
        Dim no As String = ""
        Dim notemp As String = ""
        Dim a, b As String
        For Each File In Files
            a = ""
            b = ""
            no = File.Remove(File.Length - 5, 5)
            extension = File.Replace(carpeta, "")
            extension = extension.Substring(extension.Length - 4, 4)
            If System.IO.File.Exists(no & Aa & extension) Or System.IO.File.Exists(no & Aa.ToLower & extension) Then
                a = no & Aa & extension
            End If
            If System.IO.File.Exists(no & Bb & extension) Or System.IO.File.Exists(no & Bb.ToLower & extension) Then
                b = no & Bb & extension
            End If
            If no = notemp Then
                Continue For
            Else
                oclientescnbvC.Mimagen(Convert.ToInt32(no.Replace(carpeta, "")), a.Replace("localizadas\", ""), b.Replace("localizadas\", ""))
                notemp = no
            End If
        Next
        Me.Cursor = Cursors.Default
        MessageBox.Show("COMPLETADO")
    End Sub

    Private Sub txtApellidoM_TextChanged(sender As Object, e As EventArgs) Handles txtApellidoM.TextChanged
        Aplicar_Filtro()
    End Sub

    Private Sub dgvClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellContentClick

    End Sub
End Class