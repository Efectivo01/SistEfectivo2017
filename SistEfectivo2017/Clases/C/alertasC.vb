'Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class alertasC
    Implements IDisposable
    'Dim con As ConexionAccess2000
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet
    Dim sql, strSet, where As String
    'Dim cmd As OleDbCommand
    'Dim da As OleDbDataAdapter
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    'Dim dr As OleDbDataReader
    Dim dr As SqlDataReader
    Dim abc As Double
    Dim dt As DataTable
    Dim disposed As Boolean = False
    Dim execute As String
    'Dim oalertasM As New alertasM

#Region "Sección Dispose"
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Overloads Sub Dispose(disposing As Boolean)
        If disposed = False Then
            If disposing Then
                ' Free other state (managed objects).
                LiberarDS()
                LiberarDt()
                disposed = True
            End If
            ' Free your own state (unmanaged objects).
            ' Set large fields to null.
            LiberarDS()
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

    Private Sub CargarVariablesDS()
        ds = New DataSet
        'da = New OleDbDataAdapter
        da = New SqlDataAdapter
    End Sub

    Private Sub CargarVariablesDt()
        ' da = New OleDbDataAdapter
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

    Private Function RecopilarDatos() As DataSet
        da.SelectCommand = cmd
        da.Fill(ds)
        Return ds
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
        where = Nothing
        strSet = Nothing
        dr = Nothing
    End Sub

    Public Sub LiberarDS()
        da = Nothing
        ds = Nothing
    End Sub

    Public Sub LiberarDt()
        da = Nothing
        dt = Nothing
    End Sub

#End Region

    Public Function Alta(ByVal data As alertasM) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "INSERT INTO "
        sql = sql & "alertas("
        sql = sql & "Nosucursal, "
        sql = sql & "Fecha, "
        sql = sql & "Hora, "
        sql = sql & "Empleado, "
        sql = sql & "Motivo, "
        sql = sql & "Operacion, "
        sql = sql & "Monto, "
        sql = sql & "Divisa, "
        sql = sql & "Observaciones, "
        sql = sql & "usuario) "
        sql = sql & "VALUES("
        sql = sql & "'" & data.Sucursal & "', "
        sql = sql & "'" & data.Fecha & "', "
        sql = sql & "'" & Format(data.Hora, "dd/MM/yyyy HH:mm:ss") & "', "
        sql = sql & "'" & data.Empleado & "', "
        sql = sql & "'" & data.Motivo & "', "
        sql = sql & "'" & data.Operacion & "', "
        sql = sql & data.Monto & ", "
        sql = sql & data.Divisa & ", "
        sql = sql & "'" & data.Observaciones & "', "
        sql = sql & "'" & data.Usuario & "')"
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Correo(ByVal Email As String) As Integer
        CargarVariables()
        sql = "" & Email
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Baja(ByVal data As alertasM) As Integer
        CargarVariables()
        sql = "DELETE FROM alertas WHERE Id=?"
        cmd.Parameters.AddWithValue("Id", data.Fecha)
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

#Region "Filtro"
    Private Sub maswhere(ByVal data As alertasM, ByVal a As String, ByVal b As String, ByVal likeoigual As Boolean)
        Dim operador As String = ""
        Select Case likeoigual
            Case True
                operador = " Like "
            Case False
                operador = "="
        End Select

        If data.Id <> Nothing Then
            where = where & " Id=? And"
            cmd.Parameters.AddWithValue("Fecha", data.Fecha)
        End If

        If data.Fecha <> Nothing Then
            where = where & " Fecha" & operador & " '" & b & "'+?+'" & a & "' and"
            cmd.Parameters.AddWithValue("Fecha", data.Fecha)
        End If

        If where.Trim.Length > 0 Then
            where = " WHERE " & where.Remove(where.Length - 3, 3)
        End If
        'where += " order by codigo"
    End Sub
#End Region

    Public Function STodo() As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT * FROM alertas"
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function
End Class
