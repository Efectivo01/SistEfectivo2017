Imports System.Data.SqlClient

Public Class frmAutCambioCel
    Dim conn As New ConexionSQLS
    Dim comm As SqlCommand
    Dim rs As SqlDataReader
    Dim SQL As String
    Public Encontrado As Boolean

    Private Sub frmAutCambioCel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsuario.Focus()
        Encontrado = False
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Aceptar()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Encontrado = False
        Me.Close()
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Aceptar()
        End If
    End Sub

    Sub Aceptar()
        If txtUsuario.Text.ToUpper <> "RICARDOCF" And txtUsuario.Text.ToUpper <> "MANOLOFM" And txtUsuario.Text.ToUpper <> "BETOCF" Then
            MsgBox("No esta autorizado a hacer cambios al Numero Celular", vbInformation)
            Exit Sub
        Else
            SQL = ""
            SQL = SQL & "Select "
            SQL = SQL & "   nombre "
            SQL = SQL & "From "
            SQL = SQL & "   Usuarios "
            SQL = SQL & "Where "
            SQL = SQL & "   usuario = '" & txtUsuario.Text.Trim & "' AND "
            SQL = SQL & "   contrasenia = '" & txtPassword.Text.Trim & "'"

            conn.EstablecerConexion()
            conn.AbrirConexion()

            comm = New SqlCommand(SQL, conn.con)
            rs = comm.ExecuteReader

            If rs.HasRows Then
                Encontrado = True
            Else
                Encontrado = False
            End If
            rs.Close()
            conn.CerrarConexion()
        End If
        Me.Close()
    End Sub
End Class