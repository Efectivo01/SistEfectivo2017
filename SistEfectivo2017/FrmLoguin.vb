Public Class FrmLoguin
    Dim oUsuariosM As UsuariosM
    Dim oUsuariosC As UsuariosC
    Dim dt1, dt2, dt3 As DataTable
    Dim oSucursalesM As SucursalesM
    Dim oSucursalesC As SucursalesC

    Public NOsucursal As String = ""
    Public entrar As Boolean = False
    Public usuario As String = ""
    Public NoCaj As Integer
    Public NomSuc As String
    Public UsuLog As String
    Dim RutaDesktop As String
    Dim file As System.IO.StreamReader
    Public CompraC, VentaC, DolaresC, EurosC, CanadiensesC, LibrasC As Boolean

    Private Sub FrmLoguin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        oUsuariosM = New UsuariosM
        oUsuariosC = New UsuariosC
        oSucursalesC = New SucursalesC
        oSucursalesM = New SucursalesM
        file = New System.IO.StreamReader("sucursal.txt")
        lblSucursal.Text = file.ReadLine()
        NOsucursal = lblSucursal.Text
        file.Close()
        oSucursalesM.id = NOsucursal
        oSucursalesC.Elige1(oSucursalesM)
        lblSucursal.Text = oSucursalesC.SucursalE1(oSucursalesM.id)
        NomSuc = lblSucursal.Text
        vtxtUser.Select()
        vtxtUser.Focus()
    End Sub

    Private Sub vbtnSalir_Click(sender As Object, e As EventArgs) Handles vbtnSalir.Click
        entrar = False
        Me.Close()
    End Sub

    Private Sub NombresUsuarios()
        dt2 = oUsuariosC.NombresDt()
        oUsuariosC.LiberarDt()
    End Sub

    Private Sub vbtnAceptar_Click(sender As Object, e As EventArgs) Handles vbtnAceptar.Click
        Try
            dt1 = oUsuariosC.ValidaUsuario(vtxtUser.Text.Trim, vtxtPass.Text.Trim)
            If dt1.Rows.Count >= 1 Then
                usuario = dt1.Rows(0)("nombre").ToString
                NoCaj = dt1.Rows(0)("num").ToString
                UsuLog = dt1.Rows(0)("usuario").ToString
                entrar = True
                Close()
            Else
                MsgBox("Usuario Incorrecto, Prueba de Nuevo su Usuario y Contraseña")
                vtxtUser.Focus()
                vtxtUser.SelectAll()
            End If
        Catch ex As Exception
            MsgBox("Ocurrio un error: " & vbCrLf & "Error: " & ex.Message, MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub

    Private Sub vtxtUser_KeyPress(sender As Object, e As KeyPressEventArgs) Handles vtxtUser.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If vtxtUser.Text.Trim.Length > 2 And vtxtPass.Text.Trim.Length > 2 Then
                vbtnAceptar.PerformClick()
            End If
        End If
    End Sub

    Private Sub vtxtPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles vtxtPass.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If vtxtUser.Text.Trim.Length > 2 And vtxtPass.Text.Trim.Length > 2 Then
                vbtnAceptar.PerformClick()
            End If
        End If
    End Sub
End Class