Imports System.Data.SqlClient

Public Class remisioMC
    Implements IDisposable
    Dim con As ConexionSQLS
    Dim ds As DataSet
    Dim sql, where, strSet As String
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim dr As SqlDataReader
    Dim abc As Integer
    Dim fch As String
    Dim dt As DataTable
    Dim disposed As Boolean = False
    Dim execute As String

#Region "Dispose"
    Public Sub Close()
        Dispose()
    End Sub

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Overloads Sub Dispose(disposing As Boolean)
        If disposed = False Then
            If disposing Then
                ' Free other state (managed objects).
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
        If cmd Is Nothing Then
            cmd = New SqlCommand
        End If
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

    Public Function AremisioM(ByVal data As remisioMM) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "insert into remisioM("
        sql = sql & "   folio_factura, "
        sql = sql & "   fecha, "
        sql = sql & "   tipo, "
        sql = sql & "   cliente, "
        sql = sql & "   vendedor, "
        sql = sql & "   condiciones, "
        sql = sql & "   estatus, "
        sql = sql & "   stotal, "
        sql = sql & "   iva, "
        sql = sql & "   total, "
        sql = sql & "   observaciones, "
        sql = sql & "   moneda, "
        sql = sql & "   letras, "
        sql = sql & "   cajero, "
        sql = sql & "   ncorte, "
        sql = sql & "   hora, "
        sql = sql & "   Nosucursal, "
        sql = sql & "   precio_especial, "
        sql = sql & "   cambio) "
        sql = sql & "values("
        sql = sql & "   @folio_factura, "
        sql = sql & "   @fecha, "
        sql = sql & "   @tipo, "
        sql = sql & "   @cliente, "
        sql = sql & "   @vendedor, "
        sql = sql & "   @condiciones, "
        sql = sql & "   @estatus, "
        sql = sql & "   @stotal, "
        sql = sql & "   @iva, "
        sql = sql & "   @total, "
        sql = sql & "   @observaciones, "
        sql = sql & "   @moneda, "
        sql = sql & "   @letras, "
        sql = sql & "   @cajero, "
        sql = sql & "   @ncorte, "
        sql = sql & "   @hora, "
        sql = sql & "   @Nosucursal, "
        sql = sql & "   @precio_especial, "
        sql = sql & "   @cambio)"
        cmd.Parameters.Add("@folio_factura", SqlDbType.NVarChar).Value = data.folio_factura
        cmd.Parameters.Add("@fecha", SqlDbType.SmallDateTime).Value = data.fecha.ToString("dd/MM/yyyy")
        cmd.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = data.tipo
        cmd.Parameters.Add("@cliente", SqlDbType.Int).Value = data.cliente
        cmd.Parameters.Add("@vendedor", SqlDbType.Int).Value = data.vendedor
        cmd.Parameters.Add("@condiciones", SqlDbType.NVarChar).Value = data.condiciones
        cmd.Parameters.Add("@estatus", SqlDbType.NVarChar).Value = data.estatus
        cmd.Parameters.Add("@stotal", SqlDbType.Float).Value = data.stotal
        cmd.Parameters.Add("@iva", SqlDbType.Float).Value = data.iva
        cmd.Parameters.Add("@total", SqlDbType.Float).Value = data.total
        cmd.Parameters.Add("@observaciones", SqlDbType.NVarChar).Value = data.observaciones
        cmd.Parameters.Add("@moneda", SqlDbType.Int).Value = data.moneda
        cmd.Parameters.Add("@letras", SqlDbType.NVarChar).Value = data.letras
        cmd.Parameters.Add("@cajero", SqlDbType.Int).Value = data.cajero
        cmd.Parameters.Add("@ncorte", SqlDbType.Int).Value = data.ncorte
        cmd.Parameters.Add("@hora", SqlDbType.SmallDateTime).Value = data.hora
        cmd.Parameters.Add("@Nosucursal", SqlDbType.NVarChar).Value = data.Nosucursal
        cmd.Parameters.Add("@precio_especial", SqlDbType.NVarChar).Value = data.precio_especial
        cmd.Parameters.Add("@cambio", SqlDbType.NVarChar).Value = data.cambio
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function InsertAutorizacion(ByVal cliente As String, ByVal fecha As String, ByVal folio As String, ByVal suc As String, ByVal cant As String, ByVal oper As String, ByVal tipo As String, ByVal precio As String) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "insert into clientesRiesgoLimite("
        sql = sql & "   cliente, "
        sql = sql & "   fecha, "
        sql = sql & "   folio, "
        sql = sql & "   sucursal, "
        sql = sql & "   cantidad, "
        sql = sql & "   tipo, "
        sql = sql & "   operacion, "
        sql = sql & "   p_unitario) "
        sql = sql & "values("
        sql = sql & cliente & ", "
        sql = sql & "   '" & fecha & "', "
        sql = sql & "   '" & folio & "', "
        sql = sql & "   '" & suc & "', "
        sql = sql & cant & ", "
        sql = sql & tipo & "', "
        sql = sql & "   '" & oper & "', "
        sql = sql & precio & ")"
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function EliminarAutorizacion(ByVal cliente As String, ByVal folio As String, ByVal suc As String) As Integer
        CargarVariables()
        sql = "Delete  FROM clientesRiesgoLimite WHERE cliente = '" & cliente & "' and folio='" & folio & "' and sucursal='" & suc & "'"
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function AremisioCA(ByVal data As remisioMM) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "insert into remisioCA("
        sql = sql & "   folio_factura, "
        sql = sql & "   fecha, "
        sql = sql & "   tipo, "
        sql = sql & "   cliente, "
        sql = sql & "   vendedor, "
        sql = sql & "   condiciones, "
        sql = sql & "   estatus, "
        sql = sql & "   stotal, "
        sql = sql & "   iva, "
        sql = sql & "   total, "
        sql = sql & "   observaciones, "
        sql = sql & "   letras, "
        sql = sql & "   cajero, "
        sql = sql & "   ncorte, "
        sql = sql & "   hora, "
        sql = sql & "   Nosucursal) "
        sql = sql & "values("
        sql = sql & "   @folio_factura, "
        sql = sql & "   @fecha, "
        sql = sql & "   @tipo, "
        sql = sql & "   @cliente, "
        sql = sql & "   @vendedor, "
        sql = sql & "   @condiciones, "
        sql = sql & "   @estatus, "
        sql = sql & "   @stotal, "
        sql = sql & "   @iva, "
        sql = sql & "   @total, "
        sql = sql & "   @observaciones, "
        sql = sql & "   @letras, "
        sql = sql & "   @cajero, "
        sql = sql & "   @ncorte, "
        sql = sql & "   @hora, "
        sql = sql & "   @Nosucursal)"
        cmd.Parameters.Add("@folio_factura", SqlDbType.NVarChar).Value = data.folio_factura
        cmd.Parameters.Add("@fecha", SqlDbType.SmallDateTime).Value = data.fecha
        cmd.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = data.tipo
        cmd.Parameters.Add("@cliente", SqlDbType.Int).Value = data.cliente
        cmd.Parameters.Add("@vendedor", SqlDbType.Int).Value = data.vendedor
        cmd.Parameters.Add("@condiciones", SqlDbType.NVarChar).Value = data.condiciones
        cmd.Parameters.Add("@estatus", SqlDbType.NVarChar).Value = data.estatus
        cmd.Parameters.Add("@stotal", SqlDbType.Float).Value = data.stotal
        cmd.Parameters.Add("@iva", SqlDbType.Float).Value = data.iva
        cmd.Parameters.Add("@total", SqlDbType.Float).Value = data.total
        cmd.Parameters.Add("@observaciones", SqlDbType.NVarChar).Value = data.observaciones
        cmd.Parameters.Add("@letras", SqlDbType.NVarChar).Value = data.letras
        cmd.Parameters.Add("@cajero", SqlDbType.Int).Value = data.cajero
        cmd.Parameters.Add("@ncorte", SqlDbType.Int).Value = data.ncorte
        cmd.Parameters.Add("@hora", SqlDbType.SmallDateTime).Value = data.hora
        cmd.Parameters.Add("@Nosucursal", SqlDbType.NVarChar).Value = data.Nosucursal
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function AremisioNC(ByVal data As puntosNC) As Integer
        'CargarVariables()
        sql = ""
        sql = sql & "insert into Nota_Credito("
        sql = sql & "   cliente, "
        sql = sql & "   tarjeta, "
        sql = sql & "   puntos, "
        sql = sql & "   dolares, "
        sql = sql & "   fecha, "
        sql = sql & "   estatus, "
        sql = sql & "   letra, "
        sql = sql & "   total, "
        sql = sql & "   folio_NC, "
        sql = sql & "   nosucursal, "
        sql = sql & "   folio_factura) "
        sql = sql & "values("
        sql = sql & "   @cliente, "
        sql = sql & "   @tarjeta, "
        sql = sql & "   @puntos, "
        sql = sql & "   @dolares, "
        sql = sql & "   @fecha, "
        sql = sql & "   @estatus, "
        sql = sql & "   @letra, "
        sql = sql & "   @total, "
        sql = sql & "   @folio_NC, "
        sql = sql & "   @nosucursal, "
        sql = sql & "   @folio_factura)"
        'cmd.Parameters.Add("@cliente", SqlDbType.Int).Value = data.cliente
        'cmd.Parameters.Add("@tarjeta", SqlDbType.NVarChar).Value = data.tarjeta
        'cmd.Parameters.Add("@puntos", SqlDbType.Float).Value = data.puntos
        'cmd.Parameters.Add("@dolares", SqlDbType.Int).Value = data.dolares
        'cmd.Parameters.Add("@fecha", SqlDbType.SmallDateTime).Value = data.fecha
        'cmd.Parameters.Add("@estatus", SqlDbType.NVarChar).Value = data.estatus
        'cmd.Parameters.Add("@letra", SqlDbType.NVarChar).Value = data.letra
        'cmd.Parameters.Add("@total", SqlDbType.Float).Value = data.total
        'cmd.Parameters.Add("@folio_NC", SqlDbType.NVarChar).Value = data.folio_NC
        'cmd.Parameters.Add("@Nosucursal", SqlDbType.NVarChar).Value = data.nosucursal
        'cmd.Parameters.Add("@folio_factura", SqlDbType.NVarChar).Value = data.folio_factura

        'AccesoDatos()
        'abc = EjecutarABC()
        'LiberarVariables()
        Return 0
    End Function

    Public Function EremisioM(ByVal data As remisioMM) As Integer
        CargarVariables()
        sql = "DELETE FROM remisioM WHERE folio_pedido=@folio_pedido"
        cmd.Parameters.Add("@folio_pedido", SqlDbType.VarChar).Value = data.folio_pedido
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function MremisioM(ByVal data As remisioMM, ByVal oremisioMM As remisioMM) As Integer
        CargarVariables()
        sql = "update remisioM set "
        If data.folio_pedido <> oremisioMM.folio_pedido And data.folio_pedido <> Nothing Then
            strSet += "folio_pedido=@folio_factura ,"
            cmd.Parameters.Add("@folio_pedido", SqlDbType.NVarChar).Value = data.folio_pedido
        End If

        If data.folio_factura <> oremisioMM.folio_factura And data.folio_factura <> Nothing Then
            strSet += "folio_factura=@folio_factura ,"
            cmd.Parameters.Add("@folio_factura", SqlDbType.NVarChar).Value = data.folio_factura
        End If

        If data.fecha <> oremisioMM.fecha And data.fecha <> Nothing Then
            strSet += "fecha=@fecha ,"
            cmd.Parameters.Add("@fecha", SqlDbType.SmallDateTime).Value = data.fecha
        End If

        If data.tipo <> oremisioMM.tipo And data.tipo <> Nothing Then
            strSet += "tipo=@tipo ,"
            cmd.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = data.tipo
        End If

        If data.cliente <> oremisioMM.cliente And data.cliente <> Nothing Then
            strSet += "cliente=@cliente ,"
            cmd.Parameters.Add("@cliente", SqlDbType.Int).Value = data.cliente
        End If

        If data.vendedor <> oremisioMM.vendedor And data.vendedor <> Nothing Then
            strSet += "vendedor=@vendedor ,"
            cmd.Parameters.Add("@vendedor", SqlDbType.Int).Value = data.vendedor
        End If

        If data.consignar_dir <> oremisioMM.consignar_dir And data.consignar_dir <> Nothing Then
            strSet += "consignar_dir=@consignar_dir ,"
            cmd.Parameters.Add("@consignar_dir", SqlDbType.NVarChar).Value = data.consignar_dir
        End If

        If data.consignar_col <> oremisioMM.consignar_col And data.consignar_col <> Nothing Then
            strSet += "consignar_col=@consignar_col ,"
            cmd.Parameters.Add("@consignar_col", SqlDbType.NVarChar).Value = data.consignar_col
        End If

        If data.consignar_est <> oremisioMM.consignar_est And data.consignar_est <> Nothing Then
            strSet += "consignar_est=@consignar_est ,"
            cmd.Parameters.Add("@consignar_est", SqlDbType.NVarChar).Value = data.consignar_est
        End If

        If data.consignar_pais <> oremisioMM.consignar_pais And data.consignar_pais <> Nothing Then
            strSet += "consignar_pais=@consignar_pais ,"
            cmd.Parameters.Add("@consignar_pais", SqlDbType.NVarChar).Value = data.consignar_pais
        End If

        If data.sucursal_postal <> oremisioMM.sucursal_postal And data.sucursal_postal <> Nothing Then
            strSet += "sucursal_postal=@sucursal_postal ,"
            cmd.Parameters.Add("@sucursal_postal", SqlDbType.NVarChar).Value = data.sucursal_postal
        End If

        If data.condiciones <> oremisioMM.condiciones And data.condiciones <> Nothing Then
            strSet += "condiciones=@condiciones ,"
            cmd.Parameters.Add("@condiciones", SqlDbType.NVarChar).Value = data.condiciones
        End If

        If data.estatus <> oremisioMM.estatus And data.estatus <> Nothing Then
            strSet += "estatus=@estatus ,"
            cmd.Parameters.Add("@estatus", SqlDbType.NVarChar).Value = data.estatus
        End If

        If data.stotal <> oremisioMM.stotal And data.stotal <> Nothing Then
            strSet += "stotal=@stotal ,"
            cmd.Parameters.Add("@stotal", SqlDbType.Float).Value = data.stotal
        End If

        If data.iva <> oremisioMM.iva And data.iva <> Nothing Then
            strSet += "iva=@iva ,"
            cmd.Parameters.Add("@iva", SqlDbType.Float).Value = data.iva
        End If

        If data.total <> oremisioMM.total And data.total <> Nothing Then
            strSet += "total=@total ,"
            cmd.Parameters.Add("@total", SqlDbType.Float).Value = data.total
        End If

        If data.saldo <> oremisioMM.saldo And data.saldo <> Nothing Then
            strSet += "saldo=@saldo ,"
            cmd.Parameters.Add("@saldo", SqlDbType.Float).Value = data.saldo
        End If

        If data.fecha_cobro <> oremisioMM.fecha_cobro And data.fecha_cobro <> Nothing Then
            strSet += "fecha_cobro=@fecha_cobro ,"
            cmd.Parameters.Add("@fecha_cobro", SqlDbType.SmallDateTime).Value = data.fecha_cobro
        End If

        If data.observaciones <> oremisioMM.observaciones And data.observaciones <> Nothing Then
            strSet += "observaciones=@observaciones ,"
            cmd.Parameters.Add("@observaciones", SqlDbType.NVarChar).Value = data.observaciones
        End If

        If data.descuento <> oremisioMM.descuento And data.descuento <> Nothing Then
            strSet += "descuento=@descuento ,"
            cmd.Parameters.Add("@descuento", SqlDbType.Float).Value = data.descuento
        End If

        If data.moneda <> oremisioMM.moneda And data.moneda <> Nothing Then
            strSet += "moneda=@moneda ,"
            cmd.Parameters.Add("@moneda", SqlDbType.Int).Value = data.moneda
        End If

        If data.tipo_cambio <> oremisioMM.tipo_cambio And data.tipo_cambio <> Nothing Then
            strSet += "tipo_cambio=@tipo_cambio ,"
            cmd.Parameters.Add("@tipo_cambio", SqlDbType.Float).Value = data.tipo_cambio
        End If

        If data.letras <> oremisioMM.letras And data.letras <> Nothing Then
            strSet += "letras=@letras ,"
            cmd.Parameters.Add("@letras", SqlDbType.NVarChar).Value = data.letras
        End If

        If data.cajero <> oremisioMM.cajero And data.cajero <> Nothing Then
            strSet += "cajero=@cajero ,"
            cmd.Parameters.Add("@cajero", SqlDbType.Int).Value = data.cajero
        End If

        If data.procesado <> oremisioMM.procesado And data.procesado <> Nothing Then
            strSet += "procesado=@procesado ,"
            cmd.Parameters.Add("@procesado", SqlDbType.NVarChar).Value = data.procesado
        End If

        If data.ncorte <> oremisioMM.ncorte And data.ncorte <> Nothing Then
            strSet += "ncorte=@ncorte ,"
            cmd.Parameters.Add("@ncorte", SqlDbType.Int).Value = data.ncorte
        End If

        If data.hora <> oremisioMM.hora And data.hora <> Nothing Then
            strSet += "hora=@hora ,"
            cmd.Parameters.Add("@hora", SqlDbType.SmallDateTime).Value = data.hora
        End If

        If data.Nosucursal <> oremisioMM.Nosucursal And data.Nosucursal <> Nothing Then
            strSet += "Nosucursal=@Nosucursal ,"
            cmd.Parameters.Add("@Nosucursal", SqlDbType.NVarChar).Value = data.hora
        End If

        If data.precio_especial <> oremisioMM.precio_especial And data.precio_especial <> Nothing Then
            strSet += "precio_especial=@precio_especial ,"
            cmd.Parameters.Add("@precio_especial", SqlDbType.NVarChar).Value = data.precio_especial
        End If

        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += " where folio_factura=@folio_factura2"
        cmd.Parameters.Add("@folio_factura2", SqlDbType.NVarChar).Value = oremisioMM.folio_factura
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Private Sub maswhere(ByVal data As remisioMM, ByVal a As String, ByVal b As String, ByVal likeoigual As Boolean)
        Dim operador As String = ""
        Select Case likeoigual
            Case True
                operador = " like "
            Case False
                operador = "="
        End Select

        If data.folio_factura IsNot Nothing Then
            where = where & "folio_factura" & operador & "'" & a & "'+@folio_factura+'" & b & "' and"
            cmd.Parameters.Add("@folio_factura", SqlDbType.NVarChar).Value = data.folio_factura
        End If

        If data.fecha <> Nothing Then
            where = where & " fecha" & operador & "'" & a & "'+@fecha+'" & b & "' and"
            cmd.Parameters.Add("@fecha", SqlDbType.SmallDateTime).Value = data.fecha
        End If

        If data.Nosucursal <> Nothing Then
            where = where & " Nosucursal=@Nosucursal and"
            cmd.Parameters.Add("@Nosucursal", SqlDbType.VarChar).Value = data.Nosucursal
        End If

        If where.Trim.Length > 0 Then
            where = " WHERE " & where.Remove(where.Length - 3, 3)
        End If
        'where += " order by ApellidoPaterno,Nombre"
    End Sub

    Public Function S1remisioM(ByVal data As remisioMM) As remisioMM
        CargarVariables()
        maswhere(data, "", "", False)
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   folio_factura, "
        sql = sql & "   fecha, "
        sql = sql & "   tipo, "
        sql = sql & "   cliente, "
        sql = sql & "   vendedor, "
        sql = sql & "   condiciones, "
        sql = sql & "   estatus, "
        sql = sql & "   stotal, "
        sql = sql & "   iva, "
        sql = sql & "   total, "
        sql = sql & "   observaciones, "
        sql = sql & "   letras, "
        sql = sql & "   cajero, "
        sql = sql & "   ncorte, "
        sql = sql & "   hora, "
        sql = sql & "   Nosucursal, "
        sql = sql & "   precio_especial "
        sql = sql & "FROM "
        sql = sql & "   remisioM "
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            data.folio_factura = dr.GetString(0)
            data.fecha = dr.GetDateTime(1)
            data.tipo = dr.GetString(2)
            data.cliente = dr.GetInt32(3)
            data.vendedor = dr.GetInt32(4)
            data.condiciones = dr.GetString(5)
            data.estatus = dr.GetString(6)
            data.stotal = dr.GetDouble(7)
            data.iva = dr.GetDouble(8)
            data.total = dr.GetDouble(9)
            data.observaciones = dr.GetString(10)
            data.letras = dr.GetString(11)
            data.cajero = dr.GetInt32(12)
            data.ncorte = dr.GetInt32(13)
            data.hora = dr.GetDateTime(14)
            data.Nosucursal = dr.GetString(15)
            data.precio_especial = dr.GetString(16)
            Exit While
        End While
        LiberarVariables()
        Return data
    End Function

    Public Function UFolioRemision(ByVal NoSucursal As String) As Integer
        CargarVariables()
        'sql = "SELECT folio_remision +1 FROM [control];"
        sql = "SELECT folio_remision +1 FROM Sucursales where id='" & NoSucursal & "';"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function UltFolioVentaNC(ByVal NoSucursal As String, ByVal cliente As String, ByVal fecha As Date) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "select "
        sql = sql & "   ISNULL(MAX(folio_factura),0) as folio "
        sql = sql & "from "
        sql = sql & "   remisioM "
        sql = sql & "where "
        sql = sql & "   fecha = '" & fecha.ToString("dd/MM/yyyy") & "' and "
        sql = sql & "   observaciones = 'VENTA' and "
        sql = sql & "   cliente = '" & cliente & "' and "
        sql = sql & "   Nosucursal ='" & NoSucursal & "';"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function MFolioRemision(ByVal NoSucursal As String) As Integer
        CargarVariables()
        'sql = "update [control] set folio_remision=folio_remision+1;"
        sql = "update Sucursales set folio_remision=folio_remision+1 where id='" & NoSucursal & "';"
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function UFolioNC(ByVal NoSucursal As String) As Integer
        CargarVariables()
        'sql = "SELECT folio_remision +1 FROM [control];"
        sql = "SELECT folio_NC +1 FROM Sucursales where id='" & NoSucursal & "';"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function MFolioNC(ByVal NoSucursal As String) As Integer
        CargarVariables()
        'sql = "update [control] set folio_remision=folio_remision+1;"
        sql = "update Sucursales set folio_NC=folio_NC+1 where id='" & NoSucursal & "';"
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function UNoCorte() As Integer
        CargarVariables()
        sql = "SELECT folio_corte +1 FROM [control];"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function SNombreApellido(ByVal ID As Integer) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT cliente,Nombre,ApellidoPaterno FROM clientescnbv where cliente=" & ID
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function UInformclientecnbv(ByVal cliente As Integer) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = ""
        sql = sql & "select "
        sql = sql & "   top 2 "
        sql = sql & "   folio_factura, "
        sql = sql & "   fecha, "
        sql = sql & "   observaciones, "
        sql = sql & "   total, "
        sql = sql & "   Nosucursal "
        sql = sql & "from "
        sql = sql & "   remisioM "
        sql = sql & "where "
        sql = sql & "   cliente=" & cliente & " and "
        sql = sql & "   fecha=(select MAX(fecha) from remisioM where cliente=" & cliente & ") "
        sql = sql & "order by "
        sql = sql & "   folio_factura desc"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function tolesx() As Double
        CargarVariables()
        sql = "select sum(total) from remisioM where cliente='1229' and fecha='2016/02/10'"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function fechatransfer(ByVal Nosucursal As String, ByVal fecha As Date) As DateTime
        CargarVariables()
        sql = "select top 1 hora from transferM where Nosucursal='" & Nosucursal & "' and fecha ='" & fecha & "' order by fecha,hora desc;"
        AccesoDatos()
        fch = cmd.ExecuteScalar().ToString()
        LiberarVariables()
        If fch = "" Or fch = "NULL" Or fch Is Nothing Then
            Return "1900/01/01"
        End If
        Return fch
    End Function


    Public Function countransfer(ByVal Nosucursal As String, ByVal fecha As Date) As Integer
        CargarVariables()
        'sql = "SELECT folio_remision +1 FROM [control];"
        sql = "select Count(hora) as cn from transferM where Nosucursal='" & Nosucursal & "' and fecha ='" & fecha.ToString("dd/MM/yyyy") & "'"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function ValidaRemision(ByVal folio As Integer, ByVal nosucursal As String, ByVal fecha As Date) As Double
        CargarVariables()
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   count(folio_factura) "
        sql = sql & "FROM "
        sql = sql & "   remisioM "
        sql = sql & "WHERE "
        sql = sql & "   folio_factura not like '%A%' and "
        sql = sql & "   folio_factura = '" & folio & "' and "
        sql = sql & "   nosucursal= '" & nosucursal & "'"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function ReporteTrasferencia(ByVal folioFact As String, ByVal sucursal As String) As DataSet
        Dim oMovimientoDeCajaDS As RepTraspasos = New RepTraspasos()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT 1 AS tipo, td.folio_factura, tm.letras, tm.observaciones, td.cantidads/d.valor as Cantidad " & _
        ", td.cantidads*td.p_unitario as Costo, td.cantidads, d.valor, tdi.Nombre, td.p_unitario, td.producto, td.fecha " & _
        "FROM transferD td " & _
        "INNER JOIN transferM tm ON tm.folio_factura = td.folio_factura and tm.Nosucursal = td.Nosucursal " & _
        "INNER JOIN divisas d ON d.codigo = td.producto " & _
        "INNER JOIN tipodivisas tdi ON tdi.tipo = d.tipo AND tdi.nosucursal = td.Nosucursal " & _
        "WHERE td.Nosucursal = '" & sucursal & "' AND td.folio_factura ='" & folioFact & "'" & _
        "union SELECT 2 AS tipo, td.folio_factura, tm.letras, tm.observaciones, td.cantidads/d.valor as Cantidad " & _
        ", td.cantidads*td.p_unitario as Costo, td.cantidads, d.valor, tdi.Nombre, td.p_unitario, td.producto, td.fecha " & _
        "FROM transferD td " & _
        "INNER JOIN transferM tm ON tm.folio_factura = td.folio_factura and tm.Nosucursal = td.Nosucursal " & _
        "INNER JOIN divisas d ON d.codigo = td.producto " & _
        "INNER JOIN tipodivisas tdi ON tdi.tipo = d.tipo AND tdi.nosucursal = td.Nosucursal " & _
        "WHERE td.Nosucursal = '" & sucursal & "' AND td.folio_factura ='" & folioFact & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oMovimientoDeCajaDS, "ReporteTras")

        LiberarVariables()
        Return oMovimientoDeCajaDS
    End Function

    Public Function ChequeAutorizacion(ByVal cliente As String, ByVal NoSucursal As String, ByVal folio As String) As Integer
        CargarVariables()
        sql = "select COUNT(*) as aut from clientesRiesgoLimite " & _
        "where cliente = '" & cliente & "' and sucursal = '" & NoSucursal & "' and contrasenia <> '' and folio='" & folio & "'"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function
End Class
