Imports System.Data.SqlClient

Public Class localidadesC
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet = Nothing
    Dim sql, where, strSet As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim dr As SqlDataReader = Nothing
    Dim abc As Integer = Nothing
    Dim lst As List(Of localidadesM)
    Dim dt As DataTable
    Dim disposed As Boolean = False

    Public localidadesC()

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

#Region "Variables conexión"
    Private Sub CargarVariables()
        con = New ConexionSQLS
        cmd = New SqlCommand
        sql = ""
        where = ""
        strSet = ""
        abc = 0
    End Sub

    Private Sub CargarVariablesDS()
        ds = New DataSet
        da = New SqlDataAdapter
    End Sub

    Private Sub CargarVariablesDt()
        da = New SqlDataAdapter
        lst = New List(Of localidadesM)
        dt = New DataTable
    End Sub

    Private Sub AccesoDatos()
        cmd.Connection = con.EstablecerConexion()
        con.AbrirConexion()
        cmd.CommandText = sql & where & strSet
    End Sub

    Private Function EjecutarABC() As Integer
        If cmd.ExecuteNonQuery() <= 0 Then
            Return 0
        End If
        Return 1
    End Function

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
        lst = Nothing
        dt = Nothing
    End Sub
#End Region

    'maswhere es para cuando se necesite filtrar 
    Private Sub maswhere(ByVal data As localidadesM, ByVal a As String, ByVal b As String, ByVal likeoigual As Boolean)
        Dim operador As String = ""
        Select Case likeoigual
            Case True
                operador = " like "
            Case False
                operador = "="
        End Select

        If data.localidad > 0 Then
            where = where & "localidad" & operador & "'" & a & "@localidad" & b & "' and"
            cmd.Parameters.Add("@localidad", SqlDbType.NVarChar).Value = data.estadopais
        End If

        If Not data.nombre Is Nothing Then
            where = where & " nombre" & operador & "'" & a & "@nombre" & b & "' and"
            cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = data.nombre
        End If

        If Not data.estadopais Is Nothing Then
            where = where & " estadopais" & operador & "'" & a & "@estadopais" & b & "' and"
            cmd.Parameters.Add("@estadopais", SqlDbType.NVarChar).Value = data.estadopais
        End If
        If where.Trim.Length > 0 Then
            where = " WHERE " & where.Remove(where.Length - 3, 3)
        End If
        'where += " order by ApellidoPaterno,Nombre"
    End Sub

    Public Function Sestado() As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT distinct estadopais FROM localidades order by estadopais asc"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function EstadosCNBV(Optional ByVal valor As String = "") As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT distinct estado as estadopais FROM estados"
        If valor <> "" Then
            sql = sql & " WHERE idpais = '" & valor & "'"
        End If
        sql = sql & " order by estado asc"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function ciudadesCNBV(Optional ByVal valor As String = "") As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT distinct ciudad FROM ciudades"
        If valor <> "" Then
            sql = sql & " WHERE clave = '" & valor & "'"
        End If
        sql = sql & " order by ciudad asc"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function coloniaCNBV(Optional ByVal valor As String = "") As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT CodigoPostal, Colonia FROM CodigosPostales"
        If valor <> "" Then
            sql = sql & " WHERE Estado = '" & valor & "'"
        End If
        sql = sql & " order by Estado, Municipio"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function S1localidades(ByVal data As localidadesM) As localidadesM
        CargarVariables()
        maswhere(data, "", "", False)
        sql = " SELECT * FROM localidades"
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            data.localidad = dr.GetString(0)
            data.nombre = dr.GetString(1)
            data.estadopais = dr.GetString(2)
            Exit While
        End While
        LiberarVariables()
        Return data
    End Function
End Class
