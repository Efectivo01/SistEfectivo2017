Imports System.Data.SqlClient

Public Class remisioDC
    Implements IDisposable
    Dim con As ConexionSQLS
    Dim ds As DataSet
    Dim sql, where, strSet As String
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim dr As SqlDataReader
    Dim abc As Double
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
        execute = cmd.ExecuteScalar().ToString()
        If execute Is Nothing Or execute = "NULL" Or execute = "" Then
            abc = 0
        Else
            abc = Convert.ToDouble(execute)
        End If
    End Sub

    Private Function RecopilarDatos() As DataSet
        da.SelectCommand = cmd
        da.Fill(ds, "remisioD")
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

    Public Function AremisioD(ByVal data As remisioDM) As Integer
        CargarVariables()
        sql = "INSERT INTO remisioD(folio_factura,producto,cantidads," &
            "p_unitario,stotal,descuento,capacidad,unidad,descripcion_larga,Nosucursal,fecha,operacion)" &
            "VALUES(@folio_factura,@producto,@cantidads,@p_unitario," &
            "@stotal,@descuento,@capacidad,@unidad,@descripcion_larga,@Nosucursal,@fecha,@operacion)"
        cmd.Parameters.Add("@folio_factura", SqlDbType.NVarChar).Value = data.folio_factura
        cmd.Parameters.Add("@producto", SqlDbType.NVarChar).Value = data.producto
        cmd.Parameters.Add("@cantidads", SqlDbType.Real).Value = data.cantidads
        cmd.Parameters.Add("@p_unitario", SqlDbType.Float).Value = data.p_unitario
        cmd.Parameters.Add("@stotal", SqlDbType.Float).Value = data.stotal
        cmd.Parameters.Add("@descuento", SqlDbType.Int).Value = data.descuento
        cmd.Parameters.Add("@capacidad", SqlDbType.NVarChar).Value = data.capacidad
        cmd.Parameters.Add("@unidad", SqlDbType.NVarChar).Value = data.unidad
        cmd.Parameters.Add("@descripcion_larga", SqlDbType.NText).Value = data.descripcion_larga
        cmd.Parameters.Add("@Nosucursal", SqlDbType.NVarChar).Value = data.Nosucursal
        cmd.Parameters.Add("@fecha", SqlDbType.SmallDateTime).Value = data.fecha
        cmd.Parameters.Add("@operacion", SqlDbType.NVarChar).Value = data.operacion
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function AremisioCA_DET(ByVal data As remisioDM) As Integer
        CargarVariables()
        sql = "INSERT INTO remisioCA_Det(folio_factura,producto,cantidads," &
            "p_unitario,stotal,capacidad,unidad,descripcion_larga,Nosucursal,fecha,operacion)" &
            "VALUES(@folio_factura,@producto,@cantidads,@p_unitario," &
            "@stotal,@capacidad,@unidad,@descripcion_larga,@Nosucursal,@fecha,@operacion)"
        cmd.Parameters.Add("@folio_factura", SqlDbType.NVarChar).Value = data.folio_factura
        cmd.Parameters.Add("@producto", SqlDbType.NVarChar).Value = data.producto
        cmd.Parameters.Add("@cantidads", SqlDbType.Real).Value = data.cantidads
        cmd.Parameters.Add("@p_unitario", SqlDbType.Float).Value = data.p_unitario
        cmd.Parameters.Add("@stotal", SqlDbType.Float).Value = data.stotal
        cmd.Parameters.Add("@capacidad", SqlDbType.NVarChar).Value = data.capacidad
        cmd.Parameters.Add("@unidad", SqlDbType.NVarChar).Value = data.unidad
        cmd.Parameters.Add("@descripcion_larga", SqlDbType.NText).Value = data.descripcion_larga
        cmd.Parameters.Add("@Nosucursal", SqlDbType.NVarChar).Value = data.Nosucursal
        cmd.Parameters.Add("@fecha", SqlDbType.SmallDateTime).Value = data.fecha
        cmd.Parameters.Add("@operacion", SqlDbType.NVarChar).Value = data.operacion
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function AremisioNC_DET(ByVal data As puntosNC_Det) As Integer
        CargarVariables()
        sql = "INSERT INTO Nota_Credito_Det(folio_NC,producto,cantidad," &
            "p_unitario,total,descripcion_larga,Nosucursal)" &
            "VALUES(@folio_NC,@producto,@cantidad,@p_unitario," &
            "@total,@descripcion_larga,@Nosucursal)"
        cmd.Parameters.Add("@folio_NC", SqlDbType.NVarChar).Value = data.folio_NC
        cmd.Parameters.Add("@producto", SqlDbType.NVarChar).Value = data.producto
        cmd.Parameters.Add("@cantidad", SqlDbType.Real).Value = data.cantidads
        cmd.Parameters.Add("@p_unitario", SqlDbType.Float).Value = data.p_unitario
        cmd.Parameters.Add("@total", SqlDbType.Float).Value = data.stotal
        cmd.Parameters.Add("@descripcion_larga", SqlDbType.NText).Value = data.descripcion_larga
        cmd.Parameters.Add("@Nosucursal", SqlDbType.NVarChar).Value = data.Nosucursal
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function AremisioCA_ENT(ByVal data As remisioDM) As Integer
        CargarVariables()
        sql = "INSERT INTO remisioCA_Ent(folio_factura,producto,cantidads," &
            "p_unitario,stotal,capacidad,unidad,descripcion_larga,Nosucursal,fecha,operacion)" &
            "VALUES(@folio_factura,@producto,@cantidads,@p_unitario," &
            "@stotal,@capacidad,@unidad,@descripcion_larga,@Nosucursal,@fecha,@operacion)"
        cmd.Parameters.Add("@folio_factura", SqlDbType.NVarChar).Value = data.folio_factura
        cmd.Parameters.Add("@producto", SqlDbType.NVarChar).Value = data.producto
        cmd.Parameters.Add("@cantidads", SqlDbType.Real).Value = data.cantidads
        cmd.Parameters.Add("@p_unitario", SqlDbType.Float).Value = data.p_unitario
        cmd.Parameters.Add("@stotal", SqlDbType.Float).Value = data.stotal
        cmd.Parameters.Add("@capacidad", SqlDbType.NVarChar).Value = data.capacidad
        cmd.Parameters.Add("@unidad", SqlDbType.NVarChar).Value = data.unidad
        cmd.Parameters.Add("@descripcion_larga", SqlDbType.NText).Value = data.descripcion_larga
        cmd.Parameters.Add("@Nosucursal", SqlDbType.NVarChar).Value = data.Nosucursal
        cmd.Parameters.Add("@fecha", SqlDbType.SmallDateTime).Value = data.fecha
        cmd.Parameters.Add("@operacion", SqlDbType.NVarChar).Value = data.operacion
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function EremisioD(ByVal data As remisioDM) As Integer
        CargarVariables()
        sql = "DELETE FROM remisioD WHERE folio_factura=@folio_factura"
        cmd.Parameters.Add("@folio_factura", SqlDbType.NVarChar).Value = data.folio_factura
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function MremisioD(ByVal data As remisioDM, ByVal oremisioDM As remisioDM) As Integer
        CargarVariables()
        sql = "update remisioD set "
        If data.folio_factura <> oremisioDM.folio_factura And data.folio_factura <> Nothing Then
            strSet += "folio_factura=@folio_factura,"
            cmd.Parameters.Add("@folio_factura", SqlDbType.NVarChar).Value = data.folio_factura
        End If

        If data.producto <> oremisioDM.producto And data.producto <> Nothing Then
            strSet += "producto=@producto,"
            cmd.Parameters.Add("@producto", SqlDbType.NVarChar).Value = data.producto
        End If

        If data.cantidads <> oremisioDM.cantidads And data.cantidads <> Nothing Then
            strSet += "cantidads=@cantidads,"
            cmd.Parameters.Add("@cantidads", SqlDbType.Real).Value = data.cantidads
        End If

        If data.p_unitario <> oremisioDM.p_unitario And data.p_unitario <> Nothing Then
            strSet += "p_unitario=@p_unitario,"
            cmd.Parameters.Add("@p_unitario", SqlDbType.Float).Value = data.p_unitario
        End If

        If data.stotal <> oremisioDM.stotal And data.stotal <> Nothing Then
            strSet += "stotal=@stotal,"
            cmd.Parameters.Add("@stotal", SqlDbType.Float).Value = data.stotal
        End If

        If data.descuento <> oremisioDM.descuento And data.descuento <> Nothing Then
            strSet += "descuento=@descuento,"
            cmd.Parameters.Add("@descuento", SqlDbType.Int).Value = data.descuento
        End If

        If data.capacidad <> oremisioDM.capacidad And data.capacidad <> Nothing Then
            strSet += "capacidad=@capacidad,"
            cmd.Parameters.Add("@capacidad", SqlDbType.NVarChar).Value = data.capacidad
        End If

        If data.unidad <> oremisioDM.unidad And data.unidad <> Nothing Then
            strSet += "localidad=@localidad,"
            cmd.Parameters.Add("@unidad", SqlDbType.NVarChar).Value = data.unidad
        End If

        If data.descripcion_larga <> oremisioDM.descripcion_larga And data.descripcion_larga <> Nothing Then
            strSet += "descripcion_larga=@descripcion_larga,"
            cmd.Parameters.Add("@descripcion_larga", SqlDbType.NText).Value = data.descripcion_larga
        End If

        If data.Nosucursal <> oremisioDM.Nosucursal And data.Nosucursal <> Nothing Then
            strSet += "Nosucursal=@Nosucursal,"
            cmd.Parameters.Add("@Nosucursal", SqlDbType.NVarChar).Value = data.Nosucursal
        End If


        If data.fecha <> oremisioDM.fecha And data.fecha <> Nothing Then
            strSet += "fecha=@fecha,"
            cmd.Parameters.Add("@fecha", SqlDbType.SmallDateTime).Value = data.fecha
        End If

        If data.operacion <> oremisioDM.operacion And data.operacion <> Nothing Then
            strSet += "operacion=@operacion,"
            cmd.Parameters.Add("@operacion", SqlDbType.NVarChar).Value = data.operacion
        End If

        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += " where folio_factura=@folio_factura2"
        cmd.Parameters.Add("@folio_factura2", SqlDbType.NVarChar).Value = oremisioDM.folio_factura
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Private Sub maswhere(ByVal data As remisioDM, ByVal a As String, ByVal b As String, ByVal likeoigual As Boolean)
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

        If Not data.producto Is Nothing Then
            where = where & " producto" & operador & "'" & a & "'+@producto+'" & b & "' and"
            cmd.Parameters.Add("@producto", SqlDbType.NVarChar).Value = data.producto
        End If

        If data.Nosucursal IsNot Nothing Then
            where = where & "Nosucursal=@Nosucursal" And ""
            cmd.Parameters.Add("@Nosucursal", SqlDbType.NVarChar).Value = data.Nosucursal
        End If

        If where.Trim.Length > 0 Then
            where = " WHERE " & where.Remove(where.Length - 3, 3)
        End If
        'where += " order by ApellidoPaterno,Nombre"
    End Sub

    Public Function SremisioD(ByVal data As remisioDM) As DataSet 'puede quitarse
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, "", "", False)
        sql = "SELECT * FROM remisioD"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function S1remisioD(ByVal data As remisioDM) As remisioDM
        CargarVariables()
        maswhere(data, "", "", False)
        sql = " SELECT * FROM remisioD"
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            data.folio_factura = dr.GetString(0)
            data.producto = dr.GetString(1)
            data.cantidads = dr.GetDouble(2)
            data.p_unitario = dr.GetDouble(3)
            data.stotal = dr.GetDouble(4)
            data.descuento = dr.GetInt32(5)
            data.capacidad = dr.GetString(6)
            data.unidad = dr.GetString(7)
            data.descripcion_larga = dr.GetString(8)
            data.Nosucursal = dr.GetString(9)
            data.fecha = dr.GetDateTime(10)
            data.operacion = dr.GetString(11)
            Exit While
        End While
        LiberarVariables()
        Return data
    End Function

    Public Function CantDivisasC1(ByVal codigo As String, ByVal fechaI As DateTime, ByVal fechaF As DateTime, ByVal Nosucursal As String) As Integer
        CargarVariables()
        'primero la cantidad de divisas x divisa que se tiene "COMPRA"
        sql = "select sum(rD.cantidads) as unidades from remisioD as rD inner join remisioM as rM on rD.folio_factura = rM.folio_factura and rM.Nosucursal=rD.Nosucursal " &
        " inner join divisas as d on rD.producto=d.codigo where rD.producto ='" & codigo & "' and rM.observaciones ='COMPRA' and rM.estatus='1'" &
        " and rD.fecha=rM.fecha and rM.fecha <'" & fechaF.ToString("dd/MM/yyyy") & "' and rD.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function TotDivisasC2(ByVal codigo As String, ByVal fechaI As DateTime, ByVal fechaF As DateTime, ByVal Nosucursal As String) As Double
        CargarVariables()
        'la suma de los totales de divisas x divisa que se tiene "COMPRA"
        sql = "select sum(rD.stotal) as gtotal from remisioD as rD inner join remisioM as rM on rD.folio_factura = rM.folio_factura and rM.Nosucursal=rD.Nosucursal " &
        " inner join divisas as d on rD.producto=d.codigo where rD.producto ='" & codigo & "' and rM.observaciones ='COMPRA' " &
         " and rD.fecha=rM.fecha and rM.fecha <'" & fechaF.ToString("dd/MM/yyyy") & "' and rD.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function CantDivisasC3(ByVal codigo As String, ByVal fechaI As DateTime, ByVal fechaF As DateTime, ByVal Nosucursal As String) As Integer 'cantidades de compra de hoy
        CargarVariables()
        'la suma de los totales de divisas x divisa que se tiene "COMPRA"
        sql = "select sum(rD.cantidads/d.valor) as canent from remisioD as rD inner join remisioM as rM on rM.folio_factura = rD.folio_factura and rM.Nosucursal=rD.Nosucursal " &
        " inner join divisas as d on rD.producto=d.codigo where rM.observaciones ='COMPRA' and rD.producto ='" & codigo & "' " &
        "and rD.fecha=rM.fecha and rM.fecha <'" & fechaF.ToString("dd/MM/yyyy") & "' and rD.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function CantDivisasV4(ByVal codigo As String, ByVal fechaI As DateTime, ByVal fechaF As DateTime, ByVal Nosucursal As String) As Integer 'cantidades de venta de hoy
        CargarVariables()
        'la suma de los totales de divisas x divisa que se tiene "COMPRA"
        sql = "select sum(rD.cantidads/d.valor) as cansal from remisioD as rD inner join remisioM as rM on rD.folio_factura = rM.folio_factura and rM.Nosucursal=rD.Nosucursal " &
        " inner join divisas as d on rD.producto=d.codigo where rM.observaciones ='VENTA' and rD.producto ='" & codigo & "' " &
        "and rD.fecha=rM.fecha and rM.fecha <'" & fechaF.ToString("dd/MM/yyyy") & "' and rD.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function CantDivisasC6(ByVal codigo As String, ByVal fecha As DateTime, ByVal Nosucursal As String) As Integer
        CargarVariables()
        'la suma de los totales de divisas x divisa que se tiene "COMPRA"
        sql = "select sum(rD.cantidads/d.valor) as canent from remisioD as rD inner join remisioM as rM on rM.folio_factura = rD.folio_factura and rM.Nosucursal=rD.Nosucursal " &
        " inner join divisas as d on rD.producto=d.codigo where rM.observaciones ='COMPRA' and rD.producto ='" & codigo & "' " &
        "and rD.fecha=rM.fecha and rM.fecha ='" & fecha.ToString("dd/MM/yyyy") & "' and rD.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function CantDivisasV7(ByVal codigo As String, ByVal fecha As DateTime, ByVal Nosucursal As String) As Integer
        CargarVariables()
        'la suma de los totales de divisas x divisa que se tiene "COMPRA"
        sql = "select sum(rD.cantidads/d.valor) as cansal from remisioD as rD inner join remisioM as rM on rD.folio_factura = rM.folio_factura and rM.Nosucursal=rD.Nosucursal " &
        " inner join divisas as d on rD.producto=d.codigo where rM.observaciones ='VENTA' and rD.producto ='" & codigo & "' " &
        "and rD.fecha=rM.fecha and rM.fecha ='" & fecha.ToString("dd/MM/yyyy") & "' and rD.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Sub EliminaInventarioV8()
        CargarVariables()
        sql = "truncate table tinventario"
        AccesoDatos()
        cmd.ExecuteNonQuery()
        LiberarVariables()
    End Sub

    Public Function Rp1DivisasCantEnt(ByVal codigo As String, ByVal fechaI As DateTime, ByVal fechaF As DateTime, ByVal Nosucursal As String) As Integer
        CargarVariables()
        sql = "select sum(rD.cantidads) as unidades from remisioD as rD inner join remisioM as rM on rD.folio_factura = rM.folio_factura and rM.Nosucursal=rD.Nosucursal " &
        " inner join divisas as d on rD.producto=d.codigo where rD.producto ='" & codigo & "' and rM.observaciones ='COMPRA' and rM.estatus='1'" &
        " and rD.fecha=rM.fecha and rM.fecha < '" & fechaF.ToString("dd/MM/yyyy") & "' and rD.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function Rp2DivisasCantSal(ByVal codigo As String, ByVal fechaI As DateTime, ByVal fechaF As DateTime, ByVal Nosucursal As String) As Integer
        CargarVariables()
        sql = "select sum(rD.cantidads) as cansal from remisioD as rD inner join remisioM as rM on " & _
        "rD.folio_factura = rM.folio_factura where rM.observaciones ='VENTA' and rD.producto ='" & codigo & "'" & _
        " and rD.fecha=rM.fecha and rM.fecha <'" & fechaF.ToString("dd/MM/yyyy") & "' and rD.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function Rp3CostoPromedio1(ByVal codigo As String, ByVal no As String) As Double
        CargarVariables()
        sql = "select dt.Compra from divisas as d inner join tipodivisas" & no & " as dt on " & _
        "d.tipo = dt.tipo where d.codigo ='" & codigo & "'"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function Rp4DivisasCantEntrada(ByVal codigo As String, ByVal fechaI As DateTime, ByVal fechaF As DateTime, ByVal Nosucursal As String) As Integer
        CargarVariables()
        sql = "select sum(rD.cantidads) as cansal from remisioD as rD inner join remisioM as rM on " & _
        "rD.folio_factura = rM.folio_factura where rM.observaciones ='VENTA' and rD.producto ='" & codigo & "'" & _
        " and rD.fecha=rM.fecha and rM.fecha <'" & fechaF.ToString("dd/MM/yyyy") & "' and rD.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function Rp5DivisasCantSalidas(ByVal codigo As String, ByVal fechaI As DateTime, ByVal fechaF As DateTime, ByVal Nosucursal As String) As Integer
        CargarVariables()
        sql = "select sum(rD.cantidads) as cansal from remisioD as rD inner join remisioM as rM on " & _
        "rD.folio_factura = rM.folio_factura where rM.observaciones ='VENTA' and rD.producto ='" & codigo & "'" & _
        " and rD.fecha=rM.fecha and rM.fecha ='" & fechaF.ToString("dd/MM/yyyy") & "' and rD.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function CantidadxCliente(ByVal fecha1 As Date, ByVal Nocliente As Integer, ByVal tipdivisa As Integer, ByVal no As String) As Double
        CargarVariables()
        sql = "select SUM(rD.cantidads) as Cantidad from remisioD as rD inner join remisioM as rM on rD.folio_factura=rM.folio_factura " &
"inner join divisas as dv on rD.producto=dv.codigo inner join tipodivisas as td on td.tipo=dv.tipo and td.nosucursal='" & no & "'" &
"and rD.fecha=rM.fecha and rM.fecha='" & fecha1.ToString("dd/MM/yyyy") & "' and rM.cliente=" & Nocliente & " and td.tipo=" & tipdivisa & ";"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function CantidadxCliente2(ByVal fecha1 As Date, ByVal Nocliente As Integer, ByVal no As String) As Double
        CargarVariables()
        sql = "select SUM(rD.cantidads) as Cantidad from remisioD as rD inner join remisioM as rM on rD.folio_factura=rM.folio_factura " &
"inner join divisas as dv on rD.producto=dv.codigo inner join tipodivisas as td on td.tipo=dv.tipo and td.nosucursal='" & no & "'" &
"and rD.fecha=rM.fecha and rM.fecha='" & fecha1.ToString("dd/MM/yyyy") & "' and rM.cliente=" & Nocliente & " ;"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function CantidadxCliente3(ByVal fecha1 As Date, ByVal Nocliente As Integer, ByVal no As String) As Double
        CargarVariables()
        sql = "select SUM(rD.stotal) as Cantidad from remisioD as rD inner join remisioM as rM on rD.folio_factura=rM.folio_factura " &
"inner join divisas as dv on rD.producto=dv.codigo inner join tipodivisas as td on td.tipo=dv.tipo and td.nosucursal='" & no & "'" &
"and rD.fecha=rM.fecha and rM.fecha='" & fecha1.ToString("dd/MM/yyyy") & "' and rM.cliente=" & Nocliente & " ;"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function
End Class
