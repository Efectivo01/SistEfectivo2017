Imports System.Data.SqlClient
Public Class CPuntos
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet = Nothing
    Dim sql, where, strSet As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim dr As SqlDataReader = Nothing
    Dim abc As Integer = Nothing
    Dim FechaEnv As String
    Dim lst As List(Of CPuntosDet)
    Dim dt As DataTable
    Dim disposed As Boolean = False

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

    Private Sub CargarVariablesLstDt()
        da = New SqlDataAdapter
        lst = New List(Of CPuntosDet)
        dt = New DataTable
    End Sub

    Private Sub AccesoDatos()
        cmd.Connection = con.EstablecerConexion()
        con.AbrirConexion()
        cmd.CommandText = sql & strSet & where
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

    Public Function GuardarPtsDet(ByVal data As CPuntosDet) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "INSERT INTO "
        sql = sql & "   Puntos_Det("
        sql = sql & "   Tarjeta, "
        sql = sql & "   Puntos, "
        sql = sql & "   Fecha, "
        sql = sql & "   Cliente, "
        sql = sql & "   Folio_Factura, "
        sql = sql & "   Nosucursal) "
        sql = sql & "VALUES("
        sql = sql & "   '" & data.tarjeta & "', " & data.puntos & ",'" & data.fecha.ToString("dd/MM/yyyy") & "', " &
            data.cliente & ", '" & data.folio & "', '" & data.NoSuc & "')"

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function GuardarPts(ByVal data As CPuntosDet) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "INSERT INTO "
        sql = sql & "   Puntos("
        sql = sql & "   Tarjeta, "
        sql = sql & "   Puntos, "
        sql = sql & "   Fecha, "
        sql = sql & "   CLiente) "
        'sql = sql & "   Fecha_Alta)"
        sql = sql & "VALUES("
        sql = sql & "   '" & data.tarjeta & "', "
        sql = sql & data.puntos & ", "
        sql = sql & "   '" & data.fecha.ToString("dd/MM/yyyy") & "', "
        sql = sql & data.cliente & ")"
        'sql = sql & "   '" & data.fecha.ToString("dd/MM/yyyy") & "')"

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function UpdatePts(ByVal data As CPuntosDet) As Integer
        CargarVariables()
        sql = "UPDATE Puntos SET Puntos = 0, Fecha = '" & data.fecha.ToString("dd/MM/yyyy") & "' WHERE Tarjeta = '" & data.tarjeta & "'"

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function InsertarEncPts(ByVal data As CPuntosDet) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "INSERT INTO Puntos VALUES('" & data.tarjeta & "', 0, '" & data.fecha.ToString("dd/MM/yyyy") & "', "
        sql = sql & data.cliente & ", '" & data.fecha.ToString("dd/MM/yyyy") & "')"

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function UpdatePtsCanjeados(ByVal puntos As Double, ByVal tarjeta As String) As Integer
        CargarVariables()
        sql = "UPDATE Puntos SET Puntos = puntos -" & puntos & " WHERE Tarjeta = '" & tarjeta & "'"

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function ChecarDiasPts(ByVal Tarjeta As String) As Integer
        CargarVariables()
        sql = "SELECT ISNULL(SUM(DATEDIFF(DD,Fecha,GETDATE())),0) AS dias FROM Puntos WHERE Tarjeta = '" & Tarjeta & "'"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function PuntosTotalesTar(ByVal Tarjeta As String) As Integer
        CargarVariables()
        sql = "SELECT Puntos FROM Puntos WHERE Tarjeta = '" & Tarjeta & "'"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar())
        LiberarVariables()
        Return abc
    End Function

    Public Function ChecarPuntos(ByVal Tarjeta As String) As Integer
        CargarVariables()
        sql = "SELECT ISNULL(COUNT(Puntos),0) as Puntos FROM Puntos WHERE Tarjeta = '" & Tarjeta & "'"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function ChecarEnvioTar(ByVal Cliente As String) As String
        CargarVariables()
        sql = "Select Fecha_Envio From clientescnbv Where cliente = '" & Cliente & "'"
        AccesoDatos()
        FechaEnv = cmd.ExecuteScalar().ToString()
        LiberarVariables()
        Return FechaEnv
    End Function

    Public Function ChecarEnvioTarP(ByVal Cliente As String) As String
        CargarVariables()
        sql = "Select Fecha_Envio_P From clientescnbv Where cliente = '" & Cliente & "'"
        AccesoDatos()
        FechaEnv = cmd.ExecuteScalar().ToString()
        LiberarVariables()
        Return FechaEnv
    End Function
    Public Function ChecarPuntos2(ByVal Tarjeta As String) As Double
        CargarVariables()
        sql = "SELECT ISNULL(SUM(Puntos),0) as Puntos FROM Puntos WHERE Tarjeta = '" & Tarjeta & "'"
        AccesoDatos()
        abc = Convert.ToDouble(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function ExisteEncPuntos(ByVal Tarjeta As String) As Double
        CargarVariables()
        sql = "SELECT COUNT(*) as Total FROM Puntos WHERE Tarjeta = '" & Tarjeta & "'"
        AccesoDatos()
        abc = Convert.ToDouble(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function Consulta2Compras(ByVal Cliente As Integer) As Integer
        CargarVariables()
        sql = "select COUNT(*) from Puntos_Det where cliente = " & Cliente & ""
        AccesoDatos()
        abc = Convert.ToDouble(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function ConsultaComprasPts(ByVal Cliente As Integer, ByVal Fecha As Date, ByVal nosuc As String) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "select "
        sql = sql & "   SUM(p) "
        sql = sql & "from "
        sql = sql & "   ( select COUNT(*) as p "
        sql = sql & "   from "
        sql = sql & "       Puntos_Det "
        sql = sql & "   where "
        sql = sql & "       Cliente = " & Cliente & " And "
        sql = sql & "       Fecha = '" & Fecha.ToString("dd/MM/yyyy") & "' and "
        sql = sql & "       Nosucursal = '" & nosuc & "' "
        sql = sql & "   union "
        sql = sql & "   select "
        sql = sql & "       COUNT(*) "
        sql = sql & "   from "
        sql = sql & "       remisioM "
        sql = sql & "   where "
        sql = sql & "       cliente = " & Cliente & " and "
        sql = sql & "       Fecha = '" & Fecha.ToString("dd/MM/yyyy") & "' and "
        sql = sql & "       Nosucursal = '" & nosuc & "' and "
        sql = sql & "       observaciones = 'VENTA' ) t"
        AccesoDatos()
        abc = Convert.ToDouble(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function ConsultaActTar(ByVal Cliente As Integer) As Integer
        CargarVariables()
        sql = "select ISNUll(max(TarjetaActiva),0) AS TarjetaActiva from clientescnbv where cliente = " & Cliente & ""
        AccesoDatos()
        abc = Convert.ToDouble(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function ActivarTarjeta(ByVal tarjetaC As String) As Integer
        CargarVariables()
        sql = "UPDATE clientescnbv SET TarjetaActiva = 1 WHERE Tarjeta = " & tarjetaC & ""

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function CambioTarjeta(ByVal ClienteC As Integer, ByVal tarjetaC As String) As Integer
        CargarVariables()
        sql = "UPDATE Puntos SET Tarjeta = '" & tarjetaC & "' WHERE cliente = " & ClienteC & ""

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function CambioTarjetaD(ByVal ClienteC As Integer, ByVal tarjetaC As String) As Integer
        CargarVariables()
        sql = "UPDATE Puntos_Det SET Tarjeta = '" & tarjetaC & "' WHERE cliente = " & ClienteC & ""

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function CambioTarjetaC(ByVal ClienteC As Integer, ByVal tarjetaC As String) As Integer
        CargarVariables()
        sql = "UPDATE clientescnbv SET Tarjeta = '" & tarjetaC & "' WHERE cliente = " & ClienteC & ""

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function ActivarDesacTarj(ByVal ClienteC As Integer, ByVal tarj As Integer) As Integer
        CargarVariables()
        sql = "UPDATE clientescnbv SET TarjetaActiva = " & tarj & " WHERE cliente = " & ClienteC & ""

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function ReporteEstadoCuenta(ByVal cliente As Integer, ByVal No_sucursal As String) As DataSet
        Dim oMovimientoDeCajaDS As EstadoCuenta = New EstadoCuenta()
        CargarVariables()
        da = New SqlDataAdapter

        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   c.cliente, "
        sql = sql & "   c.Nombre + ' ' + c.ApellidoPaterno + ' ' + c.ApellidoMaterno AS nombre, "
        sql = sql & "   p.Tarjeta, "
        sql = sql & "   p.Puntos, "
        sql = sql & "   t.Venta, "
        sql = sql & "   Case "
        sql = sql & "       when p.Puntos >= pr.MaximoPts then ROUND(p.Puntos*pr.valorPtsMax,2) "
        sql = sql & "       else ROUND(p.Puntos*pr.valorPtsMax,2) "
        sql = sql & "   end AS Dolares, "
        sql = sql & "   Case "
        sql = sql & "       when p.Puntos >= pr.MaximoPts then FLOOR((ROUND(5000*pr.valorPtsMax,2)+ROUND((p.Puntos-5000)*pr.valorPts,2)) / t.Venta) "
        sql = sql & "       else FLOOR(ROUND(p.Puntos*pr.valorPts,2) / t.Venta) "
        sql = sql & "   end as entrega, "
        sql = sql & "   getdate() as Fecha "
        sql = sql & "FROM "
        sql = sql & "   Puntos p "
        sql = sql & "   INNER JOIN clientescnbv c ON c.cliente = p.Cliente "
        sql = sql & "   INNER JOIN tipodivisas t ON t.nosucursal = '" & No_sucursal & "' AND tipo = 1 "
        sql = sql & "   INNER JOIN promociones pr on pr.id = 1 "
        sql = sql & "WHERE "
        sql = sql & "   p.Cliente = " & cliente
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oMovimientoDeCajaDS, "cuenta")

        LiberarVariables()
        Return oMovimientoDeCajaDS
    End Function

    Public Function ReportePuntos(ByVal NoSucP As String, ByVal FechaP As Date) As DataSet
        Dim oMovimientoDeCajaDS As RptPuntos = New RptPuntos()
        CargarVariables()
        da = New SqlDataAdapter

        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   n.folio_NC, "
        sql = sql & "   n.folio_factura as cliente, "
        sql = sql & "   c.Nombre + ' ' + c.ApellidoPaterno + ' ' + c.ApellidoMaterno AS nombre, "
        sql = sql & "   n.puntos, n.dolares, "
        sql = sql & "   max(nd.p_unitario) as precio, "
        sql = sql & "   n.total, "
        sql = sql & "   n.fecha "
        sql = sql & "FROM "
        sql = sql & "   Nota_Credito n "
        sql = sql & "   INNER JOIN Nota_Credito_Det nd ON nd.folio_NC = n.folio_NC "
        sql = sql & "   INNER JOIN clientescnbv c ON c.cliente = n.cliente "
        sql = sql & "WHERE "
        sql = sql & "   n.fecha = '" & FechaP.ToString("dd/MM/yyyy") & "' AND "
        sql = sql & "   n.nosucursal = '" & NoSucP & "' "
        sql = sql & "GROUP BY "
        sql = sql & "   n.folio_NC, "
        sql = sql & "   n.folio_factura, "
        sql = sql & "   c.Nombre + ' ' + c.ApellidoPaterno + ' ' + c.ApellidoMaterno, "
        sql = sql & "   n.puntos, "
        sql = sql & "   n.dolares, "
        sql = sql & "   n.total, "
        sql = sql & "   n.fecha "
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oMovimientoDeCajaDS, "Puntos")

        LiberarVariables()
        Return oMovimientoDeCajaDS
    End Function

    Public Function Promociones(ByVal CompraVenta As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "select * from promociones where activo = 1 AND Operacion = '" & CompraVenta & "'"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function ChecarTarjeta(ByVal Tarjeta As String) As Integer
        CargarVariables()
        sql = "SELECT COUNT(*) FROM clientescnbv WHERE Tarjeta = '" & Tarjeta & "'"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function RptMonto_Incentivo(ByVal fecha1 As Date, ByVal fecha2 As Date, ByVal suc As String) As DataSet
        Dim oReporteMontoDs As RepMIncentivo = New RepMIncentivo()
        CargarVariables()
        da = New SqlDataAdapter
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   Nota_Incentivo.Folio, "
        sql = sql & "   Nota_Incentivo.Cliente, "
        sql = sql & "   clientescnbv.Nombre + ' ' + clientescnbv.ApellidoPaterno + ' ' + clientescnbv.ApellidoMaterno as Nombre, "
        sql = sql & "   Nota_Incentivo.Folio_Factura, "
        sql = sql & "   Nota_Incentivo.Importe, "
        sql = sql & "   Nota_Incentivo.Fecha, "
        sql = sql & "   Sucursales.nombre as Sucursal "
        sql = sql & "FROM "
        sql = sql & "   Nota_Incentivo INNER JOIN clientescnbv ON Nota_Incentivo.Cliente = clientescnbv.cliente "
        sql = sql & "   INNER JOIN Sucursales ON Nota_Incentivo.nosucursal = Sucursales.id "
        sql = sql & "WHERE "
        sql = sql & "   Fecha Between '" & fecha1.ToString("dd/MM/yyyy") & "' AND '" & fecha2.ToString("dd/MM/yyyy") & "' "
        If suc <> "99" Then
            sql = sql & "   AND Nota_Incentivo.nosucursal = '" & suc & "'"
        End If

        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oReporteMontoDs, "Monto_Incentivo")
        Return oReporteMontoDs
    End Function
End Class
