Imports System.Data.SqlClient

Public Class concepto_gastosC
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim sql As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim dt As DataTable
    Dim disposed As Boolean = False

    Public concepto_gastosC()

#Region "Sección Dispose"
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Overloads Sub Dispose(disposing As Boolean)
        If disposed = False Then
            If disposing Then
                ' Free other state (managed objects).
                LiberarDt()
                disposed = True
            End If
            ' Free your own state (unmanaged objects).
            ' Set large fields to null.
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub
#End Region

#Region "Variables conexión"
    Private Sub CargarVariables()
        con = New ConexionSQLS
        cmd = New SqlCommand
        sql = ""
    End Sub

    Private Sub CargarVariablesDt()
        da = New SqlDataAdapter
        dt = New DataTable
    End Sub

    Private Sub AccesoDatos()
        cmd.Connection = con.EstablecerConexion()
        con.AbrirConexion()
        cmd.CommandText = sql
    End Sub

    Private Function EjecutarABC() As Integer
        If cmd.ExecuteNonQuery() <= 0 Then
            Return 0
        End If
        Return 1
    End Function

    Private Sub RecopilarDatosDt()
        da.SelectCommand = cmd
        da.Fill(dt)
    End Sub

    Private Sub LiberarVariables()
        cmd.Connection.Close()
        con.CerrarConexion()
        con = Nothing
        cmd = Nothing
        sql = Nothing
    End Sub

    Public Sub LiberarDt()
        da = Nothing
        dt = Nothing
    End Sub
#End Region

    Public Function BuscarTodo() As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT * from concepto_gastos;"
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function GastosDetalle(ByVal concepto As String) As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT * from concepto_gastos_det where concepto = " & concepto & ";"
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function
End Class
