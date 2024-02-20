Imports System.Data.SqlClient

Public Class movimientosC
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet = Nothing
    Dim sql As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim abc As Integer = Nothing
    Dim dt As DataTable
    Dim disposed As Boolean = False

    Public actividadesC()

#Region "Variables con Acceso a bd"
    Private Sub CargarVariables()
        con = New ConexionSQLS
        cmd = New SqlCommand
        sql = ""
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
        cmd.CommandText = sql
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
    End Sub

    Public Sub LiberarDS()
        da = Nothing
        ds = Nothing
    End Sub

    Public Sub LiberarLstDt()
        da = Nothing
        dt = Nothing
    End Sub
#End Region

    Public Function BuscarTodoDS() As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT * FROM movimientos"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function BuscarTodoDT(ByVal mvt As String) As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT * FROM movimientos where "
        If mvt <> "" Then
            sql += "movimiento='" & mvt & "';"
        End If
        AccesoDatos()
        dt.TableName = "movimientos"
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function ReporteMovimientos(ByVal mvt As String, ByVal No_sucursal As String, ByVal fecha As Date) As DataSet
        Dim oMovimientoDeCajaDS As MovCaja = New MovCaja()
        CargarVariables()
        da = New SqlDataAdapter
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   remisioM.folio_factura as Folio, "
        sql = sql & "   CAJA.Referencia as Cliente, "
        sql = sql & "   tipodivisas.Nombre as Divisa, "
        sql = sql & "   SUM(remisioD.cantidads) as Cantidad, "
        sql = sql & "   remisioD.p_unitario as Precio_Unit, "
        sql = sql & "   SUM(remisioD.stotal) as TotalMN "
        sql = sql & "FROM "
        sql = sql & "   remisioD INNER JOIN "
        sql = sql & "   remisioM ON remisioD.folio_factura = remisioM.folio_factura AND "
        sql = sql & "   remisioD.Nosucursal = remisioM.Nosucursal AND remisioD.fecha = remisioM.fecha INNER JOIN "
        sql = sql & "   CAJA ON remisioM.Nosucursal = CAJA.Nosucursal AND remisioM.folio_factura = CAJA.Folio "
        sql = sql & "   INNER JOIN tipodivisas ON remisioM.moneda = tipodivisas.tipo AND tipodivisas.nosucursal = '01'"
        sql = sql & "WHERE "
        sql = sql & "   remisioM.fecha = '" & fecha & "' AND "
        sql = sql & "   remisioM.Nosucursal = '" & No_sucursal & "' AND "
        sql = sql & "   remisioM.observaciones = '" & mvt & "' "
        sql = sql & "GROUP BY "
        sql = sql & "   remisioM.folio_factura, "
        sql = sql & "   CAJA.Referencia, "
        sql = sql & "   tipodivisas.Nombre, "
        sql = sql & "   remisioD.p_unitario"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oMovimientoDeCajaDS, "Caja")

        LiberarVariables()
        Return oMovimientoDeCajaDS
    End Function

    Public Function ReporteGatos(ByVal No_sucursal As String, ByVal fecha As Date) As DataSet
        Dim oMovimientoDeGastosDS As Gastos = New Gastos()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "select cg.nombre as concepto, cgd.nombre as concepto_det, g.total, g.referencia, g.factura, g.usuario, g.fecha " & _
        ", s.nombre from gastos g inner join concepto_gastos cg on cg.concepto = g.concepto " & _
        "left outer join concepto_gastos_det cgd on cgd.concepto_det = g.concepto_det and cgd.concepto = g.concepto " & _
        "inner join Sucursales s on s.id = g.Nosucursal " & _
        "where g.Nosucursal = '" & No_sucursal & "' and g.fecha = '" & fecha.ToString("dd/MM/yyyy") & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oMovimientoDeGastosDS, "Gastos")

        LiberarVariables()
        Return oMovimientoDeGastosDS
    End Function

#Region "Dispose"
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Overloads Sub Dispose(disposing As Boolean)
        If disposed = False Then
            If disposing Then
                ' Free other state (managed objects).
                LiberarDS()
                LiberarLstDt()
                disposed = True
            End If
            ' Free your own state (unmanaged objects).
            ' Set large fields to null.
            LiberarDS()
            LiberarLstDt()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub
#End Region
End Class
