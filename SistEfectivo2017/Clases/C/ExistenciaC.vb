Imports System.Data.SqlClient

Public Class ExistenciaC
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet = Nothing
    Dim sql, where, strSet As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim dr As SqlDataReader = Nothing
    Dim abc As Double = Nothing
    Dim dt As DataTable
    Dim disposed As Boolean = False
    Dim executar As String

    'Public ExistenciaC()
#Region "Sección Dispose"
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
        If disposed = False Then
            If disposing Then
                ' Free other state (managed objects).
                LiberarDS()
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
        where = ""
        strSet = ""
        executar = ""
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
        cmd.Connection.CreateCommand()
        cmd.CommandText = sql & strSet & where
    End Sub

    Private Function EjecutarABC() As Integer
        If cmd.ExecuteNonQuery() <= 0 Then
            Return 0
        End If
        Return 1
    End Function

    Private Sub EjecutarCantidades()
        If cmd Is Nothing Then
            cmd = New SqlCommand
        End If
        executar = cmd.ExecuteScalar().ToString()
        If executar Is Nothing Or executar = "NULL" Or executar = "" Then
            abc = 0
        Else
            abc = Convert.ToDouble(executar)
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

#Region "primero"
    Public Function countdivisas(ByVal Nosucursal As String, ByVal fecha As Date) As Integer
        CargarVariables()
        sql = "select COUNT(fecha)from Existencia where nosucursal='" & Nosucursal & "' and fecha ='" & fecha.ToString("dd/MM/yyyy") & "'"
        AccesoDatos()
        'abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        EjecutarCantidades()
        LiberarVariables()
        Return abc
    End Function

    Public Function existenciasf(ByVal Nosucursal As String, ByVal fecha As Date, ByVal divisa As String) As Integer
        CargarVariables()
        sql = "select top 1 ([sf]) from Existencia where nosucursal='" & Nosucursal & "' " &
            "and fecha <'" & fecha.ToString("dd/MM/yyyy") & "' " &
            " and divisa='" & divisa & "' order by fecha desc"
        AccesoDatos()

        EjecutarCantidades()
        LiberarVariables()
        Return abc
    End Function

    Public Function insertaDivisas(ByVal data As ExistenciaM) As Integer
        CargarVariables()
        sql = "INSERT INTO Existencia(fecha,nosucursal,divisa,si,en,sal,sf,te,ts,ce,cs,precio,tipo)VALUES" &
            "(@fecha,@nosucursal,@divisa,@si,@en,@sal,@sf,@te,@ts,@ce,@cs,@precio,@tipo)"
        cmd.Parameters.AddWithValue("@fecha", SqlDbType.Date).Value = data.fecha
        cmd.Parameters.AddWithValue("@nosucursal", SqlDbType.NVarChar).Value = data.nosucursal
        cmd.Parameters.AddWithValue("@divisa", SqlDbType.NVarChar).Value = data.divisa
        cmd.Parameters.AddWithValue("@si", SqlDbType.Int).Value = data.si
        cmd.Parameters.AddWithValue("@en", SqlDbType.Int).Value = data.en
        cmd.Parameters.AddWithValue("@sal", SqlDbType.Int).Value = data.sal
        cmd.Parameters.AddWithValue("@sf", SqlDbType.Int).Value = data.sf
        cmd.Parameters.AddWithValue("@te", SqlDbType.Int).Value = data.te
        cmd.Parameters.AddWithValue("@ts", SqlDbType.Int).Value = data.ts
        cmd.Parameters.AddWithValue("@ce", SqlDbType.Int).Value = data.ce
        cmd.Parameters.AddWithValue("@cs", SqlDbType.Int).Value = data.cs
        cmd.Parameters.AddWithValue("@precio", SqlDbType.Float).Value = data.precio
        cmd.Parameters.AddWithValue("@tipo", SqlDbType.Int).Value = data.tipo
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function EliminaDivisas(ByVal Nosucursal As String, ByVal fecha As Date) As Integer
        CargarVariables()
        sql = "DELETE FROM Existencia WHERE fecha='" & fecha & "' and nosucursal='" & Nosucursal & "'"
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

#End Region

#Region "segundos"
    Public Function Modifica2(ByVal data As ExistenciaM) As Integer
        CargarVariables()
        sql = "update Existencia set "

        If data.si <> Nothing Then
            strSet += "si=@si ,"
            cmd.Parameters.Add("@si", SqlDbType.Int).Value = data.si
        End If

        If data.en <> Nothing Then
            strSet += "en=en + @en ,"
            cmd.Parameters.Add("@en", SqlDbType.Int).Value = data.en

            If data.sf <> Nothing Then
                strSet += "sf=(si + en + te + ce + @sf) - (sal + ts + cs + pts) ,"
                cmd.Parameters.Add("@sf", SqlDbType.Int).Value = data.sf
            End If
        End If

        If data.sal <> Nothing Then
            strSet += "sal=sal + @sal ,"
            cmd.Parameters.Add("@sal", SqlDbType.Int).Value = data.sal

            If data.sf <> Nothing Then
                strSet += "sf=(si + en + te + ce) - (sal + ts + cs + pts + @sf) ,"
                cmd.Parameters.Add("@sf", SqlDbType.Int).Value = data.sf
            End If
        End If

        If data.te <> Nothing Then
            strSet += "te=te + @te ,"
            cmd.Parameters.Add("@te", SqlDbType.Int).Value = data.te

            If data.sf <> Nothing Then
                strSet += "sf=(si + en + te + ce + @sf) - (sal + ts + cs + pts) ,"
                cmd.Parameters.Add("@sf", SqlDbType.Int).Value = data.sf
            End If
        End If

        If data.ts <> Nothing Then
            strSet += "ts=ts + @ts ,"
            cmd.Parameters.Add("@ts", SqlDbType.Int).Value = data.ts

            If data.sf <> Nothing Then
                strSet += "sf=(si + en + te + ce) - (sal + ts + cs + pts + @sf) ,"
                cmd.Parameters.Add("@sf", SqlDbType.Int).Value = data.sf
            End If
        End If

        If data.ce <> Nothing Then
            strSet += "ce=ce + @ce ,"
            cmd.Parameters.Add("@ce", SqlDbType.Int).Value = data.ce

            If data.sf <> Nothing Then
                strSet += "sf=(si + en + te + ce + @sf) - (sal + ts + cs + pts) ,"
                cmd.Parameters.Add("@sf", SqlDbType.Int).Value = data.sf
            End If
        End If

        If data.cs <> Nothing Then
            strSet += "cs=cs + @cs ,"
            cmd.Parameters.Add("@cs", SqlDbType.Int).Value = data.cs

            If data.sf <> Nothing Then
                strSet += "sf=(si + en + te + ce) - (sal + ts + cs + pts + @sf) ,"
                cmd.Parameters.Add("@sf", SqlDbType.Int).Value = data.sf
            End If
        End If

        If data.precio <> Nothing Then
            strSet += "precio=@precio ,"
            cmd.Parameters.Add("@precio", SqlDbType.Float).Value = data.precio
        End If

        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += "where fecha=@fecha and nosucursal=@nosucursal and divisa=@divisa"
        cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = data.fecha
        cmd.Parameters.Add("@nosucursal", SqlDbType.NVarChar).Value = data.nosucursal
        cmd.Parameters.Add("@divisa", SqlDbType.NVarChar).Value = data.divisa
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc

    End Function

    Public Function ExistenciaHoy(ByVal fecha As Date, ByVal nosucursal As String) As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT * FROM Existencia where fecha='" & fecha.ToString("dd/MM/yyyy") & "' and nosucursal='" & nosucursal & "'"
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function ExistenciaDivisa(ByVal fecha As Date, ByVal nosucursal As String, ByVal tipo As Integer) As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = ""
        sql = sql & "SELECT SUM(Existencia.sf * divisas.valor) as Sf "
        sql = sql & "From Existencia INNER JOIN divisas ON Existencia.divisa = divisas.codigo "
        sql = sql & "where fecha='" & fecha.ToString("dd/MM/yyyy") & "' and nosucursal='" & nosucursal & "' and Existencia.tipo = " & tipo
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function RptTipado(ByVal fecha As Date, ByVal suc As String) As DataSet
        Dim oReporteExistenciaDs As ExistenciaDivDS = New ExistenciaDivDS()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT * FROM Existencia where fecha='" & fecha.ToString("dd/MM/yyyy") & "' and " &
            "nosucursal='" & suc & "';"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oReporteExistenciaDs, "Existencia")

        sql = "SELECT * FROM divisas order by divisa;"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oReporteExistenciaDs, "divisas")
        Return oReporteExistenciaDs
    End Function
#End Region

    Public Function ActualizaPrecio(ByVal nosucursal As String, ByVal fecha As Date, ByVal tipo As Integer, ByVal precio As Double) As Integer
        CargarVariables()
        sql = "update Existencia set precio=" & precio & " where fecha='" & fecha.ToString("dd/MM/yyyy") & "' " & _
            "and nosucursal='" & nosucursal & "' and tipo=" & tipo
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
        Return 0
    End Function

    Public Function Sucursales() As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT id FROM Sucursales order by id"
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function
End Class
