Imports System.Data.SqlClient

Public Class paisesC
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet = Nothing
    Dim sql, where, strSet As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim dr As SqlDataReader = Nothing
    Dim abc As Integer = Nothing
    Dim dt As DataTable
    Dim disposed As Boolean = False

    Public paisesC()

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
        dt = Nothing
    End Sub

    Public Function Spaises(ByVal data As paisesM) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = " SELECT * FROM paises"
        If data.pais IsNot Nothing Then
            where = where + " where pais=@pais"
            cmd.Parameters.Add("@pais", SqlDbType.NVarChar).Value = data.pais
        End If
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Fpaises(ByVal data As paisesM, ByVal a As String, ByVal b As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = " SELECT * FROM paises"
        If Not data.pais Is Nothing Then
            where = where & " where pais like '" & b & "@pais" & a & "'"
            cmd.Parameters.Add("@pais", SqlDbType.NVarChar).Value = data.pais
        End If
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Spaises(Optional ByVal nacionalidad As Integer = 0) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = " SELECT distinct pais FROM paises"
        If nacionalidad > 0 Then sql = sql & " WHERE nacionalidad=" & nacionalidad
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function S1paises(ByVal data As paisesM) As paisesM
        CargarVariables()
        sql = " SELECT * FROM paises"
        If Not data.pais Is Nothing Then
            sql = sql & " where pais=@pais"
            cmd.Parameters.Add("@pais", SqlDbType.NVarChar).Value = data.pais
        End If
        AccesoDatos()
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        While dr.Read()
            data = New paisesM()
            data.pais = dr.GetString(0)
            Exit While
        End While
        LiberarVariables()
        Return data
    End Function

    Public Function P_Bloqueados() As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = " SELECT * FROM paises_bloqueados"
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function


End Class
