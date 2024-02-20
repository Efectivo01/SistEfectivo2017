Imports System.Drawing

Public Class FrmBsOnonimos
    Dim oclientescnbvM, oclientescnbvM2 As New clientescnbvM
    Dim oclientescnbvC As New clientescnbvC
    Dim dt As DataTable
    Dim source1 As New BindingSource()
    Public clave As String = ""
    Public ApellidoPat As String
    Public ApellidoMat As String
    Public Nombre As String
    Dim Imagen1 As Bitmap
    Dim Imagen2 As Bitmap
    Dim identif1 As String
    Dim identif2 As String
    Public homonimo As Boolean = False
    Public PPE As Boolean = False
    Public MensajeRojo, MensajeGral As String

    Private Sub VButton2_Click(sender As Object, e As EventArgs) Handles VButton2.Click
        If dgvClientes.Rows(dgvClientes.CurrentRow.Index).Cells(12).Value.ToString = "1" Then
            PPE = True
        End If
        homonimo = False
        Me.Close()
    End Sub

    Private Sub FrmBsOnonimos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oclientescnbvC.Dispose()
        dt.Dispose()
        source1.Dispose()
    End Sub

    Private Sub FrmBsOnonimos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        'Me.Height = Screen.PrimaryScreen.WorkingArea.Height / 1.1
        'Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)
        'dgvClientes.Width = Me.Width / 1.1
        'dgvClientes.Height = (Me.Height - GroupBox1.Height * 1.7)
        Buscar1("", "")
        'dgvClientes.EnableHeadersVisualStyles = False
        'dgvClientes.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        'dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        txtApellidoP.Text = ApellidoPat
        txtApellidoM.Text = ApellidoMat
        txtNombre.Text = Nombre
        lbRojo.Text = MensajeRojo
        lbMensaje.Text = MensajeGral
        Aplicar_Filtro()
        For i As Integer = 0 To dgvClientes.Rows.Count - 1
            If dgvClientes.Rows(i).Cells(12).Value.ToString() = "1" Then
                dgvClientes.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Sub Buscar1(ByVal f1 As String, ByVal f2 As String)
        dt = oclientescnbvC.FclientecnbvBCS(oclientescnbvM, f1, f2).Tables(0)
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
        dgvClientes.Columns("identifica1").Width = 200
        dgvClientes.Columns("identifica2").Width = 200
        dgvClientes.Columns("PPE").Width = 200
        DesabilitaOrdenarcion()

    End Sub

    Private Sub DesabilitaOrdenarcion()
        Dim x As DataGridViewColumn
        For Each x In Me.dgvClientes.Columns
            x.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        dgvClientes.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 14, FontStyle.Bold)
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

    Private Sub dgvClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellClick

    End Sub

    Private Sub dgvClientes_Click(sender As Object, e As EventArgs) Handles dgvClientes.Click
        'Dim identif1 As String
        'Dim identif2 As String
        identif1 = dgvClientes.Rows(dgvClientes.CurrentRow.Index).Cells(10).Value.ToString
        identif2 = dgvClientes.Rows(dgvClientes.CurrentRow.Index).Cells(11).Value.ToString

        Dim fs As System.IO.FileStream
        If System.IO.File.Exists(identif1) Then
            fs = New System.IO.FileStream(identif1, IO.FileMode.Open, IO.FileAccess.Read)
            Imagen1 = System.Drawing.Image.FromStream(fs)
            pkb5.Image = Imagen1
            pkb5.SizeMode = PictureBoxSizeMode.StretchImage
            fs.Close()
        Else
            LimpiarImagen1()
        End If

        If System.IO.File.Exists(identif2) Then
            fs = New System.IO.FileStream(identif2, IO.FileMode.Open, IO.FileAccess.Read)
            Imagen2 = System.Drawing.Image.FromStream(fs)
            pkb6.Image = Imagen2
            pkb6.SizeMode = PictureBoxSizeMode.StretchImage
            fs.Close()
        Else
            LimpiarImagen2()
        End If
    End Sub

    Private Sub LimpiarImagen1()
        If Not pkb5.Image Is Nothing Then
            pkb5.Image.Dispose()
            pkb5.Image = Nothing
        End If
        pkb5.Refresh()
    End Sub

    Private Sub LimpiarImagen2()
        If Not pkb6.Image Is Nothing Then
            pkb6.Image.Dispose()
            pkb6.Image = Nothing
        End If
        pkb6.Refresh()
    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        Dim form As New FrmIdentificacion
        If oclientescnbvM2 IsNot Nothing Then
            If oclientescnbvM2.identifica1 Is Nothing Or oclientescnbvM2.identifica1 = "" Then
                oclientescnbvM2.identifica1 = identif1
            End If
            If oclientescnbvM2.identifica2 Is Nothing Or oclientescnbvM2.identifica2 = "" Then
                oclientescnbvM2.identifica2 = identif2
            End If
        End If

        form.oclientescnbvM = oclientescnbvM2
        form.ShowDialog()
    End Sub

    Private Sub txtApellidoP_TextChanged(sender As Object, e As EventArgs) Handles txtApellidoP.TextChanged
        Aplicar_Filtro()
        For i As Integer = 0 To dgvClientes.Rows.Count - 1
            If dgvClientes.Rows(i).Cells(12).Value.ToString() = "1" Then
                dgvClientes.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Sub txtApellidoM_TextChanged(sender As Object, e As EventArgs) Handles txtApellidoM.TextChanged
        Aplicar_Filtro()
        For i As Integer = 0 To dgvClientes.Rows.Count - 1
            If dgvClientes.Rows(i).Cells(12).Value.ToString() = "1" Then
                dgvClientes.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        Aplicar_Filtro()
        For i As Integer = 0 To dgvClientes.Rows.Count - 1
            If dgvClientes.Rows(i).Cells(12).Value.ToString() = "1" Then
                dgvClientes.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        homonimo = True
        Me.Close()
    End Sub
End Class