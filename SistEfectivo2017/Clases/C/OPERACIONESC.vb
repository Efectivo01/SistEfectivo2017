'Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class OPERACIONESC
    Implements IDisposable
    'Dim con As ConexionAccess2000
    Dim con As ConexionSQLS = Nothing
    Dim sql, strSet, where As String
    'Dim cmd As OleDbCommand
    'Dim da As OleDbDataAdapter
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim abc As Double
    Dim dt As DataTable
    Dim disposed As Boolean = False
    Dim execute As String

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
            LiberarDt()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub
#End Region

#Region "Variables de conexión"
    Private Sub CargarVariables()
        'con = New ConexionAccess2000
        'cmd = New OleDbCommand
        con = New ConexionSQLS
        cmd = New SqlCommand
        sql = ""
        where = ""
        strSet = ""
        abc = 0
        execute = ""
    End Sub

    Private Sub Modelo()

    End Sub

    Private Sub CargarVariablesDt()
        'da = New OleDbDataAdapter
        da = New SqlDataAdapter
        dt = New DataTable
    End Sub


    Private Sub AccesoDatos()
        cmd.Connection = con.EstablecerConexion()
        con.AbrirConexion()
        cmd.CommandText = sql & strSet & where
    End Sub

    Private Sub AccesoDatos2()
        cmd.Connection = con.EstablecerConexion()
        con.AbrirConexion()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = sql & strSet & where
    End Sub

    Private Function EjecutarABC() As Integer
        If cmd.ExecuteNonQuery() <= 0 Then
            Return 0
        End If
        Return 1
    End Function

    Private Sub VerificarValor()
        execute = ""
        execute = cmd.ExecuteScalar().ToString()
        If execute Is Nothing Or execute = "NULL" Or execute = "" Then
            abc = 0
        Else
            abc = Convert.ToDouble(execute)

        End If
    End Sub

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
        where = Nothing
        strSet = Nothing
    End Sub

    Public Sub LiberarDt()
        da = Nothing
        dt = Nothing
    End Sub

#End Region

    Public Function SCausas() As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT * FROM OPERACIONES"
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function SCausasCmb(ByVal Num As Integer) As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT descripcion as CAUSA FROM causales where Num =" & Num
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function
End Class
