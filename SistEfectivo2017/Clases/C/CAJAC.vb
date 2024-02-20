Imports System.Data.SqlClient

Public Class CAJAC
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet = Nothing
    Dim sql, where, strSet As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim dr As SqlDataReader = Nothing
    Dim abc As Double = Nothing
    Dim lst As List(Of CAJAM)
    Dim dt As DataTable
    Dim disposed As Boolean = False
    Dim execute As String

    Public CAJAC()

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

    Private Sub CargarLst()
        da = New SqlDataAdapter
        lst = New List(Of CAJAM)
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
        da.Fill(ds, "CAJA")
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

    Private Sub VerificarValor()
        execute = ""
        execute = cmd.ExecuteScalar().ToString()
        If execute Is Nothing Or execute = "NULL" Or execute = "" Then
            abc = 0
        Else
            abc = Convert.ToDouble(execute)
        End If
    End Sub
#End Region

    Public Function Alta(ByVal data As CAJAM) As Integer
        CargarVariables()
        sql = "INSERT INTO CAJA(Fecha,movimiento,tipo,Referencia,BC,Folio,TOTAL,valor,Nosucursal)VALUES " &
            "(@Fecha,@movimiento,@tipo,@Referencia,@BC,@Folio,@TOTAL,@valor,@Nosucursal)"
        cmd.Parameters.AddWithValue("@Fecha", SqlDbType.SmallDateTime).Value = data.Fecha
        cmd.Parameters.AddWithValue("@movimiento", SqlDbType.NVarChar).Value = data.movimiento
        cmd.Parameters.AddWithValue("@tipo", SqlDbType.NVarChar).Value = data.tipo
        cmd.Parameters.AddWithValue("@Referencia", SqlDbType.NVarChar).Value = data.Referencia
        cmd.Parameters.AddWithValue("@BC", SqlDbType.NVarChar).Value = data.BC
        cmd.Parameters.AddWithValue("@Folio", SqlDbType.Int).Value = data.Folio
        cmd.Parameters.AddWithValue("@TOTAL", SqlDbType.Float).Value = data.TOTAL
        cmd.Parameters.AddWithValue("@valor", SqlDbType.Float).Value = data.valor
        cmd.Parameters.AddWithValue("@Nosucursal", SqlDbType.NVarChar).Value = data.sucursal
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Baja(ByVal data As CAJAM) As Integer
        CargarVariables()
        sql = "DELETE FROM CAJA WHERE movimiento=@movimiento"
        cmd.Parameters.AddWithValue("@movimiento", SqlDbType.VarChar).Value = data.movimiento
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Cambio(ByVal data As CAJAM, ByVal oCAJAM As CAJAM) As Integer
        CargarVariables()
        sql = "update CAJA set "

        If data.movimiento <> oCAJAM.movimiento And data.movimiento <> Nothing Then
            strSet += "movimiento=@movimiento ,"
            cmd.Parameters.AddWithValue("@movimiento", SqlDbType.VarChar).Value = data.movimiento
        End If
        If data.tipo <> oCAJAM.tipo And data.tipo <> Nothing Then
            strSet += "tipo=@tipo ,"
            cmd.Parameters.AddWithValue("@tipo", SqlDbType.VarChar).Value = data.tipo
        End If
        If data.Referencia <> oCAJAM.Referencia And data.Referencia <> Nothing Then
            strSet += "Referencia=@Referencia ,"
            cmd.Parameters.AddWithValue("@Referencia", SqlDbType.VarChar).Value = data.Referencia
        End If
        If data.BC <> oCAJAM.BC And data.BC <> Nothing Then
            strSet += "BC=@BC ,"
            cmd.Parameters.AddWithValue("@BC", SqlDbType.VarChar).Value = data.BC
        End If

        If data.Folio <> oCAJAM.Folio And data.Folio <> Nothing Then
            strSet += "Folio=@Folio ,"
            cmd.Parameters.AddWithValue("@Folio", SqlDbType.Int).Value = data.Folio
        End If
        If data.TOTAL <> oCAJAM.TOTAL And data.TOTAL <> Nothing Then
            strSet += "TOTAL=@TOTAL ,"
            cmd.Parameters.AddWithValue("@TOTAL", SqlDbType.Float).Value = data.TOTAL
        End If
        If data.valor <> oCAJAM.valor And data.valor <> Nothing Then
            strSet += "valor=@valor ,"
            cmd.Parameters.AddWithValue("@valor", SqlDbType.Float).Value = data.valor
        End If

        If data.valor <> oCAJAM.valor And data.valor <> Nothing Then
            strSet += "Nosucursal=@Nosucursal ,"
            cmd.Parameters.AddWithValue("@Nosucursal", SqlDbType.NVarChar).Value = data.sucursal
        End If

        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If
        strSet += "where movimiento=@movimiento2 "
        cmd.Parameters.AddWithValue("@movimiento2", SqlDbType.VarChar).Value = oCAJAM.movimiento
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function MovimientoB(ByVal data As BovedaM) As Integer
        CargarVariables()
        sql = "INSERT INTO movimiento_boveda(movimiento,total,descripcion,usuario,fecha,Nosucursal)VALUES " &
            "(@movimiento,@total,@descripcion,@usuario,@fecha,@Nosucursal)"
        cmd.Parameters.AddWithValue("@movimiento", SqlDbType.NVarChar).Value = data.movimiento
        cmd.Parameters.AddWithValue("@total", SqlDbType.Float).Value = data.TOTAL
        cmd.Parameters.AddWithValue("@descripcion", SqlDbType.NVarChar).Value = data.descripcion
        cmd.Parameters.AddWithValue("@usuario", SqlDbType.NVarChar).Value = data.usuario
        cmd.Parameters.AddWithValue("@fecha", SqlDbType.SmallDateTime).Value = data.Fecha
        cmd.Parameters.AddWithValue("@Nosucursal", SqlDbType.NVarChar).Value = data.sucursal
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Private Sub maswhere(ByVal data As CAJAM, ByVal a As String, ByVal b As String, ByVal likeoigual As Boolean)
        Dim operador As String = ""
        Select Case likeoigual
            Case True
                operador = " like "
            Case False
                operador = "="
        End Select

        If data.Fecha <> Nothing Then
            where = where & " Fecha=@Fecha and"
            cmd.Parameters.AddWithValue("@Fecha", SqlDbType.SmallDateTime).Value = data.Fecha
        End If

        If Not data.movimiento Is Nothing Then
            where = where & " movimiento=@movimiento and"
            cmd.Parameters.AddWithValue("@movimiento", SqlDbType.VarChar).Value = data.movimiento
        End If

        If Not data.tipo Is Nothing Then
            where = where & " tipo=@tipo and"
            cmd.Parameters.AddWithValue("@tipo", SqlDbType.VarChar).Value = data.tipo
        End If

        If where.Trim.Length > 0 Then
            where = " WHERE " & where.Remove(where.Length - 3, 3)
        End If
    End Sub

    Public Function SeleccionaDS(ByVal data As CAJAM) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, "", "", False)
        sql = " SELECT * FROM CAJA"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Filtra(ByVal data As CAJAM, ByVal a As String, ByVal b As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, a, b, True)
        sql = " SELECT * FROM CAJA"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Lista(ByVal data As CAJAM) As List(Of CAJAM)
        CargarVariables()
        sql = "Select * from CAJA"
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            data = New CAJAM()
            data.Fecha = dr.GetDateTime(0)
            data.movimiento = dr.GetString(1)
            data.tipo = dr.GetString(2)
            data.Referencia = dr.GetString(3)
            data.BC = dr.GetString(4)
            data.Folio = dr.GetInt32(5)
            data.TOTAL = dr.GetDouble(6)
            data.valor = dr.GetDouble(7)
            data.sucursal = dr.GetString(8)
            lst.Add(data)
        End While
        cmd.Connection.Close()
        Return lst
    End Function

    Public Function Selecciona(ByVal data As CAJAM) As CAJAM
        CargarVariables()
        maswhere(data, "", "", False)
        sql = " SELECT * FROM CAJA "
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            data.Fecha = dr.GetDateTime(0)
            data.movimiento = dr.GetString(1)
            data.tipo = dr.GetString(2)
            data.Referencia = dr.GetString(3)
            data.BC = dr.GetString(4)
            data.Folio = dr.GetInt32(5)
            data.TOTAL = dr.GetDouble(6)
            data.valor = dr.GetDouble(7)
            data.sucursal = dr.GetString(8)
            Exit While
        End While
        cmd.Connection.Close()
        Return data
    End Function

    Public Function Filtrar(ByVal fecha As Date, ByVal Nosucursal As String) As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   sum(total) as totales "
        sql = sql & "FROM "
        sql = sql & "   CAJA "
        sql = sql & "WHERE "
        sql = sql & "   fecha ='" & fecha.ToString("dd/MM/yyyy") & "' and "
        sql = sql & "   movimiento ='17' and "
        sql = sql & "   Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function CompraDivisa(ByVal codigo As String, ByVal fecha1 As Date, ByVal fecha2 As String, ByVal No_sucursal As String) As Double
        Dim condiciones As String = ""

        Select Case fecha2 Is Nothing
            Case True
                condiciones += " and rD.fecha=rM.fecha and rM.fecha ='" & fecha1.ToString("dd/MM/yyyy") & "'"
            Case False
                condiciones += " and rD.fecha=rM.fecha and rM.fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "'"
        End Select

        Select Case codigo.Length
            Case 1
                condiciones += " and rD.producto like '" & codigo & "%' and not SUBSTRING(rD.producto, 2, 1) between 'A' and 'Z'"
            Case 2
                condiciones += " and rD.producto like '" & codigo & "%'"
        End Select

        CargarVariables()

        sql = ""
        sql = sql & "select "
        sql = sql & "   SUM(rD.stotal) as compra "
        sql = sql & "from "
        sql = sql & "   remisioD as rD inner join remisioM as rM on rD.folio_factura="
        sql = sql & "   rM.folio_factura and rM.Nosucursal=rD.Nosucursal "
        sql = sql & "where "
        sql = sql & "   rM.observaciones='COMPRA' AND "
        sql = sql & "   rM.tipo='DIVISAS' and "
        sql = sql & "   rM.Nosucursal='" & No_sucursal & "'" & condiciones
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function VentaDivisa(ByVal codigo As String, ByVal fecha1 As Date, ByVal fecha2 As String, ByVal No_sucursal As String) As Double
        Dim condiciones As String = ""

        Select Case fecha2 Is Nothing
            Case True
                condiciones += " and rD.fecha=rM.fecha and rM.fecha ='" & fecha1.ToString("dd/MM/yyyy") & "'"
            Case False
                condiciones += " and rD.fecha=rM.fecha and rM.fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "'"
        End Select

        Select Case codigo.Length
            Case 1
                condiciones += " and rD.producto like '" & codigo & "%' and not SUBSTRING(rD.producto, 2, 1) between 'A' and 'Z'"
            Case 2
                condiciones += " and rD.producto like '" & codigo & "%'"
        End Select

        CargarVariables()
        sql = ""
        sql = sql & "select "
        sql = sql & "   SUM(rD.stotal) as venta "
        sql = sql & "from "
        sql = sql & "   remisioD as rD inner join remisioM as rM on rD.folio_factura="
        sql = sql & "   rM.folio_factura and rM.Nosucursal=rD.Nosucursal "
        sql = sql & "where "
        sql = sql & "   rM.observaciones='VENTA' AND "
        sql = sql & "   rM.tipo='DIVISAS' and "
        sql = sql & "   rM.Nosucursal='" & No_sucursal & "'" & condiciones & ";"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    'este
    Public Function TransferenciaEntrada(ByVal codigo As String, ByVal fecha1 As Date, ByVal fecha2 As String, ByVal Nosucursal As String) As Double
        Dim condiciones As String = ""

        Select Case fecha2 Is Nothing
            Case True
                condiciones += " and tD.fecha=tM.fecha and tM.fecha ='" & fecha1.ToString("dd/MM/yyyy") & "'"
            Case False
                condiciones += " and tD.fecha=tM.fecha and tM.fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "'"
        End Select

        Select Case codigo.Length
            Case 1
                condiciones += " and tD.producto like '" & codigo & "%' and not SUBSTRING(tD.producto, 2, 1) between 'A' and 'Z'"
            Case 2
                condiciones += " and tD.producto like '" & codigo & "%'"
        End Select
        CargarVariables()
        sql = ""
        sql = sql & "select "
        sql = sql & "   SUM(tD.cantidads*tD.p_unitario) as Entrada "
        sql = sql & "from "
        sql = sql & "   transferD as tD inner join transferM as tM on tD.folio_factura="
        sql = sql & "   tM.folio_factura and tM.Nosucursal=tD.Nosucursal "
        sql = sql & "where "
        sql = sql & "   tM.observaciones='ENTRADA' AND "
        sql = sql & "   tM.tipo='DIVISAS'" & condiciones & " and "
        sql = sql & "   tM.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    'este
    Public Function TransferenciaSalida(ByVal codigo As String, ByVal fecha1 As Date, ByVal fecha2 As String, ByVal Nosucursal As String) As Double
        Dim condiciones As String = ""

        Select Case fecha2 Is Nothing
            Case True
                condiciones += " and tD.fecha=tM.fecha and tM.fecha ='" & fecha1.ToString("dd/MM/yyyy") & "'"
            Case False
                condiciones += " and tD.fecha=tM.fecha and tM.fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "'"
        End Select

        Select Case codigo.Length
            Case 1
                condiciones += " and tD.producto like '" & codigo & "%' and not SUBSTRING(tD.producto, 2, 1) between 'A' and 'Z'"
            Case 2
                condiciones += " and tD.producto like '" & codigo & "%'"
        End Select
        CargarVariables()
        sql = ""
        sql = sql & "select "
        sql = sql & "   SUM(tD.cantidads*tD.p_unitario) as Salida "
        sql = sql & "from "
        sql = sql & "   transferD as tD inner join transferM as tM on tD.folio_factura="
        sql = sql & "   tM.folio_factura and tM.Nosucursal=tD.Nosucursal "
        sql = sql & "where "
        sql = sql & "   tM.observaciones='SALIDA' AND "
        sql = sql & "   tM.tipo='DIVISAS'" & condiciones & " and "
        sql = sql & "   tM.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function BuscaTodasLasDivisas() As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "select distinct SUBSTRING(d.codigo, 1, 1) as CODIGO,tipo from divisas as d where ISNUMERIC(SUBSTRING(d.codigo, 3, 1))>=0 and not SUBSTRING(codigo, 2, 1) between 'A' and 'Z'"
        AccesoDatos()
        dt.TableName = "DIVISAS"
        RecopilarDatosDt()
        sql = "select distinct(SUBSTRING(codigo, 1, 2)) as CODIGO,tipo from divisas where SUBSTRING(codigo, 2, 1) between 'A' and 'Z'"
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function TraspasoAbobeda(ByVal fecha1 As Date, ByVal fecha2 As String, ByVal Nosucursal As String) As Double
        Dim condiciones As String = ""
        Select Case fecha2 Is Nothing
            Case True
                condiciones += " and fecha='" & fecha1.ToString("dd/MM/yyyy") & "'"
            Case False
                condiciones += " and fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "'"
        End Select
        CargarVariables()
        sql = "select SUM(TOTAL) as A from CAJA where movimiento='12' and tipo='S'" & condiciones & " and Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function TraspasoDebobeda(ByVal fecha1 As Date, ByVal fecha2 As String, ByVal Nosucursal As String) As Double
        Dim condiciones As String = ""
        Select Case fecha2 Is Nothing
            Case True
                condiciones += " and fecha='" & fecha1.ToString("dd/MM/yyyy") & "'"
            Case False
                condiciones += " and fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "'"
        End Select
        CargarVariables()
        sql = "select SUM(TOTAL) as DE from CAJA where movimiento='1' and tipo='E'" & condiciones & " and Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function BuscaTodosLosGastos() As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "select * from concepto_gastos"
        AccesoDatos()
        dt.TableName = "concepto_gastos"
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function Gastos(ByVal codigo As String, ByVal fecha1 As Date, ByVal fecha2 As String, ByVal Nosucursal As String) As Double
        Dim condiciones As String = ""
        Select Case fecha2 Is Nothing
            Case True
                condiciones += " and fecha='" & fecha1.ToString("dd/MM/yyyy") & "'"
            Case False
                condiciones += " and fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "'"
        End Select
        CargarVariables()
        sql = "select SUM(total) from gastos where concepto='" & codigo & "'" & condiciones & " and Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function CompraDivisa2(ByVal fecha1 As Date, ByVal fecha2 As String, ByVal operador As String, ByVal movimiento As Integer, ByVal No_sucursal As String) As Double
        Dim condiciones As String = ""
        'opcines 17 y 10 ; 10 es cancela venta y 17 es compra
        Select Case fecha2 Is Nothing
            Case True
                condiciones += " and c.fecha " & operador & "'" & fecha1.ToString("dd/MM/yyyy") & "'"
            Case False
                condiciones += " and c.fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "'"
        End Select

        CargarVariables()
        sql = "SELECT SUM(TOTAL) as compras FROM CAJA as c WHERE c.movimiento ='" & movimiento & "' and c.Nosucursal='" & No_sucursal & "'" & condiciones & ";"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function VentaDivisa2(ByVal fecha1 As Date, ByVal fecha2 As String, ByVal operador As String, ByVal movimiento As Integer, ByVal No_sucursal As String) As Double
        Dim condiciones As String = ""
        'opcines 17 y 10 ; 10 es cancela venta y 17 es compra
        Select Case fecha2 Is Nothing
            Case True
                condiciones += " and c.fecha " & operador & "'" & fecha1.ToString("dd/MM/yyyy") & "'"
            Case False
                condiciones += " and c.fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "'"
        End Select

        CargarVariables()
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   SUM(TOTAL) as ventas "
        sql = sql & "FROM "
        sql = sql & "   CAJA as c "
        sql = sql & "WHERE "
        sql = sql & "   c.movimiento ='" & movimiento & "' and "
        sql = sql & "   c.Nosucursal='" & No_sucursal & "'" & condiciones & ";"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    'este
    Public Function TransferenciaEntrada2(ByVal fecha1 As Date, ByVal fecha2 As String, ByVal Nosucursal As String) As Double
        Dim condiciones As String = ""

        Select Case fecha2 Is Nothing
            Case True
                condiciones += " and tD.fecha=tM.fecha and tM.fecha ='" & fecha1.ToString("dd/MM/yyyy") & "'"
            Case False
                condiciones += " and tD.fecha=tM.fecha and tM.fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "'"
        End Select
        CargarVariables()
        sql = ""
        sql = sql & "select "
        sql = sql & "   ISNULL(SUM(tD.cantidads*tD.p_unitario),0) as tranasanteE1 "
        sql = sql & "from "
        sql = sql & "   transferD as tD inner join transferM as tM on "
        sql = sql & "   tD.folio_factura=tM.folio_factura and tM.Nosucursal=tD.Nosucursal "
        sql = sql & "where "
        sql = sql & "   tM.observaciones = 'ENTRADA'" & condiciones & " and "
        sql = sql & "   tD.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    'este
    Public Function TransferenciaSalida2(ByVal fecha1 As Date, ByVal fecha2 As String, ByVal Nosucursal As String) As Double
        Dim condiciones As String = ""

        Select Case fecha2 Is Nothing
            Case True
                condiciones += " and tD.fecha=tM.fecha and tM.fecha ='" & fecha1.ToString("dd/MM/yyyy") & "'"
            Case False
                condiciones += " and tD.fecha=tM.fecha and tM.fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "'"
        End Select

        CargarVariables()
        sql = ""
        sql = sql & "select "
        sql = sql & "   ISNULL(SUM(tD.cantidads*tD.p_unitario),0) as tranasanteS1 "
        sql = sql & "from "
        sql = sql & "   transferD as tD inner join transferM as tM on "
        sql = sql & "   tD.folio_factura=tM.folio_factura and tM.Nosucursal=tD.Nosucursal "
        sql = sql & "where "
        sql = sql & "   tM.observaciones = 'SALIDA'" & condiciones & " and "
        sql = sql & "   tD.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function TraspasosBobedaGastos(ByVal fecha1 As Date, ByVal fecha2 As String, ByVal movimiento As Integer, ByVal BC As String, ByVal No_sucursal As String) As Double
        Dim condiciones As String = ""
        Select Case fecha2 Is Nothing
            Case True
                condiciones += " and fecha='" & fecha1.ToString("dd/MM/yyyy") & "'"
            Case False
                condiciones += " and fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "'"
        End Select
        CargarVariables()
        sql = "select ISNULL(SUM(TOTAL),0) as A from CAJA where movimiento='" & movimiento & "' and Nosucursal='" & No_sucursal & "'" & condiciones & " and BC='" & BC & "'"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function GastosSabado(ByVal fecha1 As Date, ByVal fecha2 As String, ByVal No_sucursal As String) As Double
        Dim condiciones As String = ""
        Select Case fecha2 Is Nothing
            Case True
                condiciones += " and fecha='" & fecha1.ToString("dd/MM/yyyy") & "'"
            Case False
                condiciones += " and fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "'"
        End Select
        CargarVariables()
        sql = "select SUM(total) as A from gasots where Nosucursal='" & No_sucursal & "'" & condiciones
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function VentasAl(ByVal fecha1 As Date, ByVal fecha2 As String, ByVal caso As Integer, ByVal No_sucursal As String) As Double
        CargarVariables()
        Select Case caso
            Case 1
                sql = ""
                sql = sql & "select "
                sql = sql & "   ISNULL(SUM(rD.stotal),0) as totventasdia "
                sql = sql & "from "
                sql = sql & "   remisioD as rD inner join remisioM as rM on "
                sql = sql & "   rD.folio_factura=rM.folio_factura and rM.Nosucursal=rD.Nosucursal "
                sql = sql & "   inner join CAJA as c on rM.folio_factura= c.Folio and "
                sql = sql & "   c.Nosucursal=rM.Nosucursal and "
                sql = sql & "   c.Fecha ='" & fecha1.ToString("dd/MM/yyyy") & "'" & " and rM.Nosucursal='" & No_sucursal & "'"
                sql = sql & "   and c.movimiento = '11' and rM.estatus<>'C' and rM.folio_factura not like '%A%' ;"
            Case 2
                sql = ""
                sql = sql & "select "
                sql = sql & "   ISNULL(SUM(rD.stotal),0) as totventames "
                sql = sql & "from "
                sql = sql & "   remisioD as rD inner join remisioM as rM on "
                sql = sql & "   rD.folio_factura=rM.folio_factura and rM.Nosucursal=rD.Nosucursal "
                sql = sql & "   inner join CAJA as c on rM.folio_factura= c.Folio and "
                sql = sql & "   c.Nosucursal=rM.Nosucursal and "
                sql = sql & "   c.Fecha between '" & fecha2 & "' and "
                sql = sql & "   '" & fecha1.ToString("dd/MM/yyyy") & "' and "
                sql = sql & "   rM.Nosucursal='" & No_sucursal & "'"
                sql = sql & "   and c.movimiento = '11' and "
                sql = sql & "   rM.estatus<>'C' and "
                sql = sql & "   rM.folio_factura not like '%A%' ;"
        End Select
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function ComprasAl(ByVal fecha1 As Date, ByVal fecha2 As String, ByVal caso As Integer, ByVal No_sucursal As String) As Double
        CargarVariables()
        Select Case caso
            Case 1
                sql = ""
                sql = sql & "select "
                sql = sql & "   ISNULL(SUM(rD.stotal),0) as totcompradia "
                sql = sql & "from "
                sql = sql & "   remisioD as rD inner join remisioM as rM on "
                sql = sql & "   rD.folio_factura=rM.folio_factura and rM.Nosucursal=rD.Nosucursal "
                sql = sql & "   inner join CAJA as c on rM.folio_factura= c.Folio and "
                sql = sql & "   c.Nosucursal=rM.Nosucursal and "
                sql = sql & "   c.Fecha ='" & fecha1.ToString("dd/MM/yyyy") & "' and "
                sql = sql & "   rM.Nosucursal='" & No_sucursal & "'" & " and "
                sql = sql & "   c.movimiento = '17'"
                sql = sql & "   and rM.estatus<>'C' and "
                sql = sql & "   rM.folio_factura not like '%A%' ;"
            Case 2
                sql = ""
                sql = sql & "select "
                sql = sql & "   ISNULL(SUM(rD.stotal),0) as totcomprames "
                sql = sql & "from "
                sql = sql & "   remisioD as rD inner join remisioM as rM on "
                sql = sql & "   rD.folio_factura=rM.folio_factura and "
                sql = sql & "   rM.Nosucursal=rD.Nosucursal inner join "
                sql = sql & "   CAJA as c on rM.folio_factura= c.Folio and "
                sql = sql & "   c.Nosucursal=rM.Nosucursal and "
                sql = sql & "   c.Fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "' and "
                sql = sql & "   rM.Nosucursal='" & No_sucursal & "'"
                sql = sql & "   and c.movimiento = '17' and "
                sql = sql & "   rM.estatus<>'C' and "
                sql = sql & "   rM.folio_factura not like '%A%' ;"
        End Select
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function GastosAyer(ByVal fecha1 As Date, ByVal operador As String, ByVal movimiento As Integer, ByVal No_sucursal As String) As Double
        'opcines 17 y 10 ; 10 es cancela venta y 17 es compra
        CargarVariables()
        sql = "SELECT SUM(TOTAL) as ventas FROM gastos as c WHERE and c.Nosucursal='" & No_sucursal & "' and c.fecha ='" & fecha1.ToString("dd/MM/yyyy") & "'"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function ValidaCaja(ByVal folio As Integer, ByVal nosucursal As String, ByVal fecha As Date) As Double
        CargarVariables()
        sql = "SELECT count(Folio)  FROM CAJA WHERE Folio =" & folio & "" & _
         " and Nosucursal='" & nosucursal & "'" ' and fecha ='" & fecha.ToString("dd/MM/yyyy") & "'"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function Incentivos(ByVal fecha As Date, ByVal Nosucursal As String) As Double
        CargarVariables()
        sql = ""
        sql = sql & "select "
        sql = sql & "   ISNULL(SUM(Importe),0) as Total "
        sql = sql & "from "
        sql = sql & "   Nota_Incentivo "
        sql = sql & "where "
        sql = sql & "   fecha = '" & fecha.ToString("dd/MM/yyyy") & "' AND "
        sql = sql & "   Nosucursal = '" & Nosucursal & "' "

        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function IncentivosMes(ByVal fechaFin As Date, ByVal FechaIni As Date, ByVal Nosucursal As String) As Double
        CargarVariables()
        sql = ""
        sql = sql & "select "
        sql = sql & "   ISNULL(SUM(Importe),0) as Total "
        sql = sql & "from "
        sql = sql & "   Nota_Incentivo "
        sql = sql & "where "
        sql = sql & "   fecha Between '" & FechaIni.ToString("dd/MM/yyyy") & "' AND "
        sql = sql & "   '" & fechaFin.ToString("dd/MM/yyyy") & "' AND "
        sql = sql & "   Nosucursal = '" & Nosucursal & "' "

        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function


    Public Function IncentivosM(ByVal fecha As Date, ByVal Nosucursal As String) As Double
        CargarVariables()
        sql = ""
        sql = sql & "select "
        sql = sql & "   ISNULL(SUM(Importe),0) as Total "
        sql = sql & "from "
        sql = sql & "   Nota_Incentivo "
        sql = sql & "where "
        sql = sql & "   MONTH(fecha) = '" & fecha.Month & "' AND YEAR(Fecha) = '" & fecha.Year & "' AND "
        sql = sql & "   Nosucursal = '" & Nosucursal & "' "

        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function Buscar_Proveedor(ByVal Proveedor As Integer) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "Select COUNT(Cliente) as Total from Proveedor Where Cliente = " & Proveedor

        AccesoDatos()
        'abc = EjecutarABC()
        VerificarValor()
        LiberarVariables()

        Return abc

    End Function

    Public Function Cupones(ByVal fecha As Date, ByVal Nosucursal As String) As Double
        CargarVariables()
        sql = ""
        sql = sql & "select "
        sql = sql & "   ISNULL(SUM(Importe),0) as Total "
        sql = sql & "from "
        sql = sql & "   Cupones "
        sql = sql & "where "
        sql = sql & "   fecha = '" & fecha.ToString("dd/MM/yyyy") & "' AND "
        sql = sql & "   sucursal = '" & Nosucursal & "' "

        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function CuponesM(ByVal fecha As Date, ByVal Nosucursal As String) As Double
        CargarVariables()
        sql = ""
        sql = sql & "select "
        sql = sql & "   ISNULL(SUM(Importe),0) as Total "
        sql = sql & "from "
        sql = sql & "   Cupones "
        sql = sql & "where "
        sql = sql & "   MONTH(fecha) = '" & fecha.Month & "' AND YEAR(Fecha) = '" & fecha.Year & "' AND "
        sql = sql & "   sucursal = '" & Nosucursal & "' "

        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function CuponesMes(ByVal fechaFin As Date, ByVal FechaIni As Date, ByVal Nosucursal As String) As Double
        CargarVariables()

        sql = ""
        sql = sql & "select "
        sql = sql & "   ISNULL(SUM(Importe),0) as Total "
        sql = sql & "from "
        sql = sql & "   Cupones "
        sql = sql & "where "
        sql = sql & "   fecha Between '" & FechaIni.ToString("dd/MM/yyyy") & "' AND "
        sql = sql & "   '" & fechaFin.ToString("dd/MM/yyyy") & "' AND "
        sql = sql & "   sucursal = '" & Nosucursal & "' "

        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function
#Region "dispose"
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

End Class
