Imports System.Data.SqlClient

Public Class FrmPersonasMConsulta
    Dim dtbTabla As New System.Data.DataTable
    Private cmd, cmd2 As New SqlCommand
    Private lector As SqlDataReader
    Dim dtrFila As DataRow
    Public tipoInf As String
    Public clave As String = ""

    Private Sub FrmPersonasMConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox1.Text = "Busqueda de Personas Morales"
        Label2.Text = "RAZON SOCIAL:"
        dgvClientes.AllowUserToAddRows = False

        dtbTabla.Columns.Add("Cliente")
        dtbTabla.Columns.Add("Razon Social")
        dtbTabla.Columns.Add("RFC")
        dtbTabla.Columns.Add("Giro Mercantil")
        dtbTabla.Columns.Add("Nacionalidad")
        dtbTabla.Columns.Add("Dirección")


        CargarGrid()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CargarGrid()
        Dim Busqueda As String = ""
        Conexion()
        cone.Open()
        If TxtRazonSocial.Text <> "" Then
            Busqueda = " WHERE p.razonsocial like '%" & TxtRazonSocial.Text & "%'"
        End If
        dtbTabla.Clear()

        Dim consulta As String = "select p.*, c.cliente from PersonasMoralesp p inner join clientescnbv c on c.ID = p.Num " & Busqueda
        cmd = New SqlCommand(consulta, cone)
        lector = cmd.ExecuteReader()
        While lector.Read
            dtrFila = dtbTabla.NewRow()
            dtrFila("Cliente") = lector("cliente")
            dtrFila("Razon Social") = lector("razonsocial")
            dtrFila("RFC") = lector("RFC")
            dtrFila("Giro Mercantil") = lector("giro")
            dtrFila("Nacionalidad") = lector("nacionalidad")
            If lector("calle") <> "" Then
                dtrFila("Dirección") = "Calle " & lector("calle") & " No.Externo " & lector("NoExt") & " No. Interno " & lector("NoInt")
            Else
                dtrFila("Dirección") = lector("calle")
            End If
            dtbTabla.Rows.Add(dtrFila)
        End While

        dgvClientes.DataSource = dtbTabla

        With dgvClientes
            .Columns(0).Width = 90
            .Columns(1).Width = 250
            .Columns(2).Width = 250
            .Columns(3).Width = 250
            .Columns(4).Width = 350
        End With
        cone.Close()
    End Sub

    Private Sub TxtRazonSocial_TextChanged(sender As Object, e As EventArgs) Handles TxtRazonSocial.TextChanged
        CargarGrid()
    End Sub

    Private Sub dgvClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellContentClick

    End Sub

    Private Sub dgvClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellDoubleClick
        clave = dgvClientes.CurrentRow.Cells("Cliente").Value.ToString()
        Close()
    End Sub
End Class