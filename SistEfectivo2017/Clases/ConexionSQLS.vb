Imports System.Data
Imports System.Data.SqlClient

Public Class ConexionSQLS
    Dim file As System.IO.StreamReader
    Dim cs As String = ""

    Public con As SqlConnection

    Public Function EstablecerConexion() As SqlConnection
        Try
            file = New System.IO.StreamReader("servidor.txt")
            cs = file.ReadLine
            file.Close()
            con = New SqlConnection(cs)
        Catch exc As Exception
            MessageBox.Show("Error en la cadena de conexion")
        End Try

        Return con
    End Function

    Public Sub AbrirConexion()
        Try
            con.Open()
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con el servidor")
            Application.Exit()
        End Try
    End Sub

    Public Sub CerrarConexion()
        con.Close()
    End Sub
End Class
