Imports System.Data.SQLite

Public Class ConexionSQLite
    Dim cs As String = "Data Source=auxMeritrade.sqlite"
    Dim con As SQLiteConnection

    Public Function EstablecerConexion() As SQLiteConnection
        con = New SQLiteConnection(cs)
        Return con
    End Function

    Public Sub AbrirConexion()
        Try
            con.Open()
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con el servidor")
        End Try
    End Sub

    Public Sub CerrarConexion()
        con.Close()
    End Sub
End Class
