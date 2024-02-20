Imports System.Data.SqlClient

Public Class ReportesUnicosC
    Implements IDisposable
    Dim con As ConexionSQLS
    Dim ds As DataSet
    Dim sql, where, strSet As String
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim dr As SqlDataReader
    Dim abc As Integer
    Dim dt As DataTable
    Dim disposed As Boolean = False

    Public ReportesUnicosC()

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
#End Region

    Public Function RptGlobalDivisas(ByVal fecha1 As Date, ByVal fecha2 As Date, ByVal Nosucursal As String) As DataSet
        Dim oRptGlobalDivisasDs As RptGlobalDivisasDs = New RptGlobalDivisasDs()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT * FROM divisas ORDER BY tipo,valor;"
        'sql = "SELECT DISTINCT(DIV.codigo), DIV.divisa,DIV.valor,DIV.tipo,DIV.cpromedio FROM DIVISAS AS DIV INNER JOIN REMISIOD AS RD " & _
        '    "ON DIV.CODIGO=RD.PRODUCTO AND NOSUCURSAL='" & Nosucursal & "' and RD.fecha between '" & fecha1.ToString("dd/MM/yyyy") & "' " & _
        '    "and '" & fecha2.ToString("dd/MM/yyyy") & "' ORDER BY DIV.tipo,DIV.valor;"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oRptGlobalDivisasDs, "divisas")

        sql = "SELECT rD.folio_factura, rD.producto, rD.cantidads - ISNULL(rD2.cantidads,0) as cantidads, rD.p_unitario, rD.stotal - ISNULL(rD2.stotal,0) as stotal, " &
            "rD.descuento, rD.capacidad, rD.unidad, rD.descripcion_larga, rD.Nosucursal, rD.fecha, rD.operacion FROM remisioD as rD " &
            "left outer join remisioCA_Det rD2 on rD2.folio_factura = rD.folio_factura and rD2.Nosucursal = rD.Nosucursal " &
            "where rD.Nosucursal='" & Nosucursal & "' and rD.fecha between '" & fecha1.ToString("dd/MM/yyyy") & "' and '" & fecha2.ToString("dd/MM/yyyy") & "';"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oRptGlobalDivisasDs, "remisioD")

        sql = "SELECT * FROM remisioM as rM where Nosucursal='" & Nosucursal & "' and fecha between '" & fecha1.ToString("dd/MM/yyyy") & "' and '" & fecha2.ToString("dd/MM/yyyy") & "';"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oRptGlobalDivisasDs, "remisioM")
        LiberarVariables()
        Return oRptGlobalDivisasDs
    End Function

    Public Function RptGlobalDivisas2(ByVal fecha1 As Date, ByVal fecha2 As Date, ByVal Nosucursal As String) As DataSet
        Dim oRptGlobalDivisasDs As RptGlobalDivisasDs2 = New RptGlobalDivisasDs2()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "select t.divisa, t.tipo, SUM(case when t.observaciones = 'COMPRA' then t.cantidads else 0 end) as cantidads, " &
        "CASE WHEN SUM(case when t.observaciones = 'COMPRA' then t.stotal else 0 end)> 0 THEN ROUND(SUM(case when t.observaciones = 'COMPRA' then t.stotal else 0 end)/SUM(case when t.observaciones = 'COMPRA' then t.cantidads else 0 end),2) ELSE 0 END as precio_pro, " &
        "SUM(case when t.observaciones = 'COMPRA' then t.stotal else 0 end) as stotal, " &
        "SUM(case when t.observaciones = 'COMPRA' then t.billete else 0 end) as billete, " &
        "SUM(case when t.observaciones = 'VENTA' then t.cantidads else 0 end) as cantidadsV, " &
        "CASE WHEN SUM(case when t.observaciones = 'VENTA' then t.stotal else 0 end) > 0 THEN ROUND(SUM(case when t.observaciones = 'VENTA' then t.stotal else 0 end) / SUM(case when t.observaciones = 'VENTA' then t.cantidads else 0 end),2) ELSE 0 END as precio_proV, " &
        "SUM(case when t.observaciones = 'VENTA' then t.stotal else 0 end) as stotalV, " &
        "SUM(case when t.observaciones = 'VENTA' then t.billete else 0 end) as billeteV, " &
        "t.fechaI, t.fechaF, t.nombre, SUM(case when t.observaciones = 'COMPRA' then 1 else 0 end) as compra, " &
        "SUM(case when t.observaciones = 'VENTA' then 1 else 0 end) as venta from  ( " &
        "SELECT d.divisa, d.tipo, rM.observaciones, SUM(rD.cantidads - ISNULL(rD2.cantidads,0)) as cantidads, " &
        "ROUND(SUM(rD.p_unitario) /COUNT(rD.p_unitario),2) as precio_pro, SUM(rD.stotal - ISNULL(rD2.stotal,0)) as stotal " &
        ", SUM(rD.cantidads - ISNULL(rD2.cantidads,0)) / MAX(d.valor) as billete, '" & fecha1.ToString("dd/MM/yyyy") & "' as fechaI, '" & fecha2.ToString("dd/MM/yyyy") & "' as fechaF, s.nombre " &
        "FROM remisioM as rM inner join remisioD as rD ON rD.folio_factura = rM.folio_factura and rD.Nosucursal = rM.Nosucursal " &
        "left outer join remisioCA_Det rD2 on rD2.folio_factura = rD.folio_factura and rD2.Nosucursal = rD.Nosucursal " &
        "inner join divisas as d ON d.codigo = rD.producto inner join Sucursales as s ON s.id = rM.Nosucursal " &
        "where rM.Nosucursal='" & Nosucursal & "' and rM.fecha between '" & fecha1.ToString("dd/MM/yyyy") & "' and '" & fecha2.ToString("dd/MM/yyyy") & "' " &
        "group by d.divisa, d.tipo, rM.observaciones, s.nombre ) t " &
        "group  by t.divisa, t.tipo, t.fechaI, t.fechaF, t.nombre order by t.tipo, t.divisa"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oRptGlobalDivisasDs, "remisioD")

        LiberarVariables()
        Return oRptGlobalDivisasDs
    End Function

    Public Function RptNota1(ByVal filtro1 As String, ByVal filtro2 As String) As DataSet
        Dim oNotacv As Nota1 = New Nota1()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "select cl.* from clientescnbv as cl inner join remisioM as rM " &
        "on cl.cliente=rM.cliente and rM.folio_factura='" & filtro1 & "' and rM.Nosucursal='" & filtro2 & "';"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oNotacv, "clientescnbv")
        'MessageBox.Show(oNotacv.Tables("clientescnbv").Rows(0)(3).ToString)

        sql = "SELECT * FROM remisioM where folio_factura='" & filtro1 & "' and Nosucursal='" & filtro2 & "';"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "remisioM")

        'sql = "SELECT * FROM remisioD where folio_factura='" & filtro1 & "' and Nosucursal='" & filtro2 & "';"
        sql = "SELECT * FROM remisioD as rD inner join remisioM as rM on " &
        "rD.folio_factura=rM.folio_factura and rM.folio_factura='" & filtro1 & "' " &
        "and rD.fecha=rM.fecha and rM.fecha=(select max(fecha) from remisioM where folio_factura='" & filtro1 & "')" &
        " order by Convert(int,REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(producto, 'D', ''),'C',''),'E',''),'L',''), 'Y', ''), 'A', ''), 'J', ''), 'F', '')) asc;"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "remisioD")

        LiberarVariables()
        Return oNotacv
    End Function

    Public Function RptNota2(ByVal filtro1 As String, ByVal filtro2 As String) As DataSet
        Dim oNotacv As Nota1 = New Nota1()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "select cl.* from clientescnbv as cl inner join remisioM as rM " &
        "on cl.cliente=rM.cliente and rM.folio_factura='" & filtro1 & "' and rM.Nosucursal='" & filtro2 & "';"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oNotacv, "clientescnbv")
        'MessageBox.Show(oNotacv.Tables("clientescnbv").Rows(0)(3).ToString)

        sql = "SELECT * FROM remisioM where folio_factura='" & filtro1 & "' and Nosucursal='" & filtro2 & "';"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "remisioM")

        sql = "SELECT * FROM remisioD as rD inner join remisioM as rM on (rD.folio_factura=rM.folio_factura and " &
            " rD.nosucursal=rM.nosucursal) " &
            " and rM.folio_factura='" & filtro1 &
        "' and rD.fecha=rM.fecha and rM.Nosucursal='" & filtro2 & "'" &
            "order by Convert(int,REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(producto, 'D', ''),'C',''),'E',''),'L',''), 'Y', ''), 'A', ''), 'J', ''), 'F', '')) asc"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "remisioD")

        sql = "SELECT * FROM Sucursales where id='" & filtro2 & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Sucursales")

        sql = ""
        sql = sql & "sp_Select_Cupon " & filtro1 & ", '" & filtro2 & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Cupon")

        LiberarVariables()
        Return oNotacv
    End Function

    Public Function ImprimeNota1(ByVal filtro As String, ByVal filtro2 As String, ByVal filtro3 As String) As DataSet
        Dim oNotacv As Nota1 = New Nota1()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT * FROM clientescnbv where cliente=" & Convert.ToInt32(filtro) & ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oNotacv, "clientescnbv")
        sql = "SELECT * FROM remisioM where cliente=" & Convert.ToInt32(filtro) & " and folio_factura='" & filtro2 & "'"
        If filtro3 IsNot Nothing Then
            sql += " and Nosucursal='" & filtro3 & "'"
        End If
        sql += ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "remisioM")

        sql = "SELECT * FROM remisioD where folio_factura='" & filtro2 & "'"
        If filtro3 IsNot Nothing Then
            sql += " and Nosucursal='" & filtro3 & "'"
        End If
        sql += " order by Convert(int,REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(producto, 'D', ''),'C',''),'E',''),'L',''), 'Y', ''), 'A', ''), 'J', ''), 'F', '')) asc;"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "remisioD")

        sql = ""
        sql = sql & "sp_Select_Cupon " & filtro2 & ", '" & filtro3 & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Cupon")

        LiberarVariables()
        Return oNotacv
    End Function

    Public Function ImprimeNota2(ByVal filtro As String, ByVal filtro2 As String, ByVal filtro3 As String) As DataSet
        Dim oNotacv As Nota1 = New Nota1()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT * FROM clientescnbv where cliente=" & Convert.ToInt32(filtro) & ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oNotacv, "clientescnbv")
        sql = "SELECT * FROM remisioM where cliente=" & Convert.ToInt32(filtro) & " and folio_factura='" & filtro2 & "' " &
            "and fecha='" & Date.Now.ToString("dd/MM/yyyy") & "'"
        If filtro3 IsNot Nothing Then
            sql += " and Nosucursal='" & filtro3 & "'"
        End If
        sql += ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "remisioM")

        sql = "SELECT * FROM remisioD where folio_factura='" & filtro2 & "' and fecha='" & Date.Now.ToString("dd/MM/yyyy") & "'"
        If filtro3 IsNot Nothing Then
            sql += " and Nosucursal='" & filtro3 & "'"
        End If
        sql += " order by Convert(int,REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(producto, 'D', ''),'C',''),'E',''),'L',''), 'Y', ''), 'A', ''), 'J', ''), 'F', '')) asc;"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "remisioD")

        sql = "SELECT * FROM Sucursales where id='" & filtro3 & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Sucursales")

        sql = ""
        sql = sql & "sp_Select_Cupon " & filtro2 & ", '" & filtro3 & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Cupon")

        LiberarVariables()
        Return oNotacv
    End Function

    Public Function ImprimeNotaCambio(ByVal filtro As String, ByVal filtro2 As String, ByVal filtro3 As String) As DataSet
        Dim oNotacv As Nota1 = New Nota1()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT * FROM clientescnbv where cliente=" & Convert.ToInt32(filtro) & ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oNotacv, "clientescnbv")
        sql = "SELECT * FROM remisioM where cliente=" & Convert.ToInt32(filtro) & " and folio_factura='" & filtro2 & "' " &
            "and fecha='" & Date.Now.ToString("dd/MM/yyyy") & "'"
        If filtro3 IsNot Nothing Then
            sql += " and Nosucursal='" & filtro3 & "'"
        End If
        sql += ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "remisioM")

        sql = "SELECT folio_factura,producto,cantidads,p_unitario,stotal,0 as descuento,capacidad,unidad,descripcion_larga,Nosucursal,fecha,'C' as operacion  " &
            "FROM remisioCA_Ent where folio_factura='" & filtro2 & "' and fecha='" & Date.Now.ToString("dd/MM/yyyy") & "'"
        If filtro3 IsNot Nothing Then
            sql += " and Nosucursal='" & filtro3 & "'"
        End If
        'sql += " order by Convert(int,REPLACE(REPLACE(REPLACE(REPLACE(producto, 'D', ''),'C',''),'E',''),'L','')) asc;"
        sql += " UNION ALL SELECT folio_factura, producto, -(cantidads),p_unitario, -(stotal), 0 as descuento, capacidad,unidad,descripcion_larga,Nosucursal, " &
            "fecha,'CA' as operacion FROM remisioCA_Det where folio_factura='" & filtro2 & "' and fecha='" & Date.Now.ToString("dd/MM/yyyy") & "'"
        If filtro3 IsNot Nothing Then
            sql += " and Nosucursal='" & filtro3 & "'"
        End If
        'sql += " order by Convert(int,REPLACE(REPLACE(REPLACE(REPLACE(producto, 'D', ''),'C',''),'E',''),'L','')) asc;"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "remisioD")

        sql = "SELECT * FROM Sucursales where id='" & filtro3 & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Sucursales")

        LiberarVariables()
        Return oNotacv
    End Function

    Public Function ImprimeNotaPuntos(ByVal filtro As String, ByVal filtro2 As String, ByVal filtro3 As String) As DataSet
        Dim oNotacv As NotaCredito1 = New NotaCredito1()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT * FROM clientescnbv where cliente=" & Convert.ToInt32(filtro) & ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oNotacv, "clientescnbv")

        sql = "SELECT tarjeta, dolares, fecha, cliente, estatus, total, letra as letras, Nosucursal, folio_NC, puntos " &
            "FROM Nota_Credito where cliente=" & Convert.ToInt32(filtro) & " and folio_NC='" & filtro2 & "' "

        If filtro3 IsNot Nothing Then
            sql += " and Nosucursal='" & filtro3 & "'"
        End If
        sql += ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Nota_Credito")

        sql = "SELECT folio_NC,producto,cantidad,p_unitario,total,descripcion_larga,Nosucursal  " &
            "FROM Nota_Credito_Det where folio_NC='" & filtro2 & "' "
        If filtro3 IsNot Nothing Then
            sql += " and Nosucursal='" & filtro3 & "'"
        End If
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Nota_Credito_Det")

        sql = "SELECT id,nombre,folio_NC,direccion,colonia,CP,Estado,Municipio,Pais,letra_NC AS letra, 'NCA' as letra2 FROM Sucursales where id='" & filtro3 & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Sucursales")

        LiberarVariables()
        Return oNotacv
    End Function

    Public Function ImprimeNotaPuntosVenta(ByVal filtro As String, ByVal filtro2 As String, ByVal filtro3 As String) As DataSet
        Dim oNotacv As NotaCredito1 = New NotaCredito1()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT * FROM clientescnbv where cliente=" & Convert.ToInt32(filtro) & ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oNotacv, "clientescnbv")

        sql = "SELECT tarjeta, dolares, fecha, cliente, estatus, 0 AS total, 'CEROS PESOS CON 00/100 M.N.' as letras, Nosucursal, folio_NC, puntos, folio_factura " &
            "FROM Nota_Credito where cliente=" & Convert.ToInt32(filtro) & " and folio_NC='" & filtro2 & "' " &
            "and fecha='" & Date.Now.ToString("dd/MM/yyyy") & "'"
        If filtro3 IsNot Nothing Then
            sql += " and Nosucursal='" & filtro3 & "'"
        End If
        sql += ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Nota_Credito")

        sql = "SELECT folio_NC,producto,cantidad,0 AS p_unitario,0 AS total,descripcion_larga,Nosucursal  " &
            "FROM Nota_Credito_Det where folio_NC='" & filtro2 & "' "
        If filtro3 IsNot Nothing Then
            sql += " and Nosucursal='" & filtro3 & "'"
        End If
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Nota_Credito_Det")

        sql = "SELECT id,nombre,folio_remision,direccion,colonia,CP,Estado,Municipio,Pais,letra AS letra, 'NCA' as letra2 FROM Sucursales where id='" & filtro3 & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Sucursales")

        LiberarVariables()
        Return oNotacv
    End Function

    Public Function ImprimeNotaPuntosVenta2(ByVal filtro2 As String, ByVal filtro3 As String, ByVal filtro4 As String) As DataSet
        Dim oNotacv As NotaCredito1 = New NotaCredito1()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT c.* FROM clientescnbv c INNER JOIN Nota_Credito n ON n.cliente = c.cliente " &
            "AND n.folio_factura = '" & filtro2 & "' AND n.nosucursal = '" & filtro3 & "';"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oNotacv, "clientescnbv")

        sql = "SELECT tarjeta, dolares, fecha, cliente, estatus, 0 AS total, 'CEROS PESOS CON 00/100 M.N.' as letras, Nosucursal, folio_NC, puntos, folio_factura " &
            "FROM Nota_Credito where folio_factura ='" & filtro2 & "' " &
            "and nosucursal ='" & filtro3 & "'"
        If filtro3 IsNot Nothing Then
            sql += " and Nosucursal='" & filtro3 & "'"
        End If
        sql += ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Nota_Credito")

        sql = "SELECT folio_NC,producto,cantidad,0 AS p_unitario,0 AS total,descripcion_larga,Nosucursal  " &
            "FROM Nota_Credito_Det where folio_NC='" & filtro4 & "' "
        If filtro3 IsNot Nothing Then
            sql += " and Nosucursal='" & filtro3 & "'"
        End If
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Nota_Credito_Det")

        sql = "SELECT id,nombre,folio_remision,direccion,colonia,CP,Estado,Municipio,Pais,letra AS letra, 'NCA' as letra2 FROM Sucursales where id='" & filtro3 & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Sucursales")

        LiberarVariables()
        Return oNotacv
    End Function

    Public Function ImprimeNotaCambio2(ByVal filtro1 As String, ByVal filtro2 As String) As DataSet
        Dim oNotacv As Nota1 = New Nota1()
        CargarVariables()
        da = New SqlDataAdapter
        'sql = "SELECT * FROM clientescnbv where cliente=" & Convert.ToInt32(filtro) & ";"
        sql = "select cl.* from clientescnbv as cl inner join remisioM as rM " &
        "on cl.cliente=rM.cliente and rM.folio_factura='" & filtro1 & "' and rM.Nosucursal='" & filtro2 & "';"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oNotacv, "clientescnbv")

        'sql = "SELECT * FROM remisioM where cliente=" & Convert.ToInt32(filtro) & " and folio_factura='" & filtro2 & "' " & _
        '    "and fecha='" & Date.Now.ToString("dd/MM/yyyy") & "'"
        sql = "SELECT * FROM remisioM where folio_factura='" & filtro1 & "' and Nosucursal='" & filtro2 & "';"
        'If filtro3 IsNot Nothing Then
        '    sql += " and Nosucursal='" & filtro3 & "'"
        'End If
        'sql += ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "remisioM")

        sql = "SELECT folio_factura,producto,cantidads,p_unitario,stotal,0 as descuento,capacidad,unidad,descripcion_larga,Nosucursal,fecha,'C' as operacion  " &
            "FROM remisioCA_Ent where folio_factura='" & filtro1 & "' and Nosucursal='" & filtro2 & "'"
        'If filtro3 IsNot Nothing Then
        '    sql += " and Nosucursal='" & filtro2 & "'"
        'End If
        'sql += " order by Convert(int,REPLACE(REPLACE(REPLACE(REPLACE(producto, 'D', ''),'C',''),'E',''),'L','')) asc;"
        sql += " UNION ALL SELECT folio_factura, producto, -(cantidads),p_unitario, -(stotal), 0 as descuento, capacidad,unidad,descripcion_larga,Nosucursal, " &
            "fecha,'CA' as operacion FROM remisioCA_Det where folio_factura='" & filtro1 & "' and Nosucursal='" & filtro2 & "'"
        'If filtro3 IsNot Nothing Then
        '    sql += " and Nosucursal='" & filtro2 & "'"
        'End If
        'sql += " order by Convert(int,REPLACE(REPLACE(REPLACE(REPLACE(producto, 'D', ''),'C',''),'E',''),'L','')) asc;"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "remisioD")

        sql = "SELECT * FROM Sucursales where id='" & filtro2 & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Sucursales")

        LiberarVariables()
        Return oNotacv
    End Function

    Public Function ImprimeNota22(ByVal filtro As String, ByVal filtro2 As String, ByVal filtro3 As String) As DataSet
        Dim oNotacv As Nota1 = New Nota1()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT * FROM clientescnbv where cliente=" & Convert.ToInt32(filtro) & ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oNotacv, "clientescnbv")
        'sql = "SELECT * FROM remisioM where cliente=" & Convert.ToInt32(filtro) & " and folio_factura='" & filtro2 & "'"
        sql = "select * from remisioM where folio_factura not like '%A%' AND cliente=" & Convert.ToInt32(filtro) & " and " &
            "fecha=(select max(fecha) from remisioM where cliente=" & Convert.ToInt32(filtro) & ") AND folio_factura='" & filtro2 & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "remisioM")

        'sql = "SELECT * FROM remisioD where folio_factura='" & filtro2 & "'"
        sql = "SELECT rD.* FROM remisioD as rD INNER JOIN remisioM as rM on rM.folio_factura=rD.folio_factura " &
        "and rM.fecha=rD.fecha and rM.Nosucursal=rD.Nosucursal AND rM.folio_factura not like '%A%' and rM.cliente=" & Convert.ToInt32(filtro) & " " &
        "and rM.fecha=(select max(fecha) from remisioM where cliente=" & Convert.ToInt32(filtro) & ") " &
        "AND rM.folio_factura='" & filtro2 & "'"
        sql += " order by Convert(int,REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(producto, 'D', ''),'C',''),'E',''),'L',''), 'Y', ''), 'A', ''), 'J', ''), 'F', '')) asc;"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "remisioD")

        sql = "SELECT * FROM Sucursales where id='" & filtro3 & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv, "Sucursales")

        LiberarVariables()
        Return oNotacv
    End Function

    Public Function ImprimeNota3(ByVal filtro As String, ByVal filtro2 As String, ByVal filtro3 As String) As DataSet
        Dim oNotacv2 As Nota1 = New Nota1()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT * FROM clientescnbv where cliente=" & Convert.ToInt32(filtro) & ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oNotacv2, "clientescnbv")
        sql = "SELECT * FROM remisioM where cliente=" & Convert.ToInt32(filtro) & " and folio_factura='" & filtro2 & "'"
        sql += ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv2, "remisioM")

        sql = "SELECT * FROM remisioD where folio_factura='" & filtro2 & "'"
        sql += " order by Convert(int,REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(producto, 'D', ''),'C',''),'E',''),'L',''), 'Y', ''), 'A', ''), 'J', ''), 'F', '')) asc;"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv2, "remisioD")

        sql = "SELECT * FROM Sucursales where id='" & filtro3 & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotacv2, "Sucursales")

        LiberarVariables()
        Return oNotacv2
    End Function

    Public Function folio_rpt(ByVal nosucursal As String, ByVal fecha1 As Date, ByVal fecha2 As Date) As DataSet
        Dim oFolios_notas As Folios_notas = New Folios_notas
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT folio_factura,total,observaciones FROM remisiom where folio_factura not like'%A%' and nosucursal='" & nosucursal & "' and " &
            "fecha between '" & fecha1.ToString("dd/MM/yyyy") & "' and '" & fecha2.ToString("dd/MM/yyyy") & "' " &
            " order by convert(int,folio_factura) asc"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oFolios_notas, "notas")
        LiberarVariables()
        Return oFolios_notas
    End Function

    Public Function ReporteTraspaso_Det(ByVal nosucursal As String, ByVal fecha1 As Date, ByVal fecha2 As Date)
        Dim oTraspasosDet As Traspaso = New Traspaso
        CargarVariables()
        da = New SqlDataAdapter

        If nosucursal = "" Then
            sql = "SELECT td.folio_factura, td.producto, td.cantidads, td.p_unitario, td.cantidads*td.p_unitario as stotal " &
            ", td.cantidads/d.valor AS descuento, td.capacidad, tdi.Nombre as unidad, td.descripcion_larga " &
            ", td.fecha, td.Nosucursal " &
            "from transferD td " &
            "inner join transferM tm on tm.folio_factura = td.folio_factura and tm.Nosucursal = td.Nosucursal " &
            "inner join divisas d on d.codigo = td.producto " &
            "inner join tipodivisas tdi on tdi.tipo = d.tipo and tdi.nosucursal = td.Nosucursal " &
            "where td.fecha between '" & fecha1.ToString("dd/MM/yyyy") & "' and '" & fecha2.ToString("dd/MM/yyyy") & "' " &
            " order by convert(int,td.folio_factura) asc"
            cmd = New SqlCommand(sql, con.EstablecerConexion())
            con.AbrirConexion()
            da.SelectCommand = cmd
            da.Fill(oTraspasosDet, "transferD")

            sql = "SELECT * " &
            "from transferM " &
            "where fecha between '" & fecha1.ToString("dd/MM/yyyy") & "' and '" & fecha2.ToString("dd/MM/yyyy") & "' " &
            "AND observaciones = 'SALIDA' order by convert(int,folio_factura) asc"
            cmd = New SqlCommand(sql, con.EstablecerConexion())
            da.SelectCommand = cmd
            da.Fill(oTraspasosDet, "transferM")
        Else
            sql = "SELECT td.folio_factura, td.producto, td.cantidads, td.p_unitario, td.cantidads*td.p_unitario as stotal " &
                    ", td.cantidads/d.valor AS descuento, td.capacidad, tdi.Nombre as unidad, td.descripcion_larga " &
                    ", td.fecha, td.Nosucursal " &
                    "from transferD td " &
                    "inner join transferM tm on tm.folio_factura = td.folio_factura and tm.Nosucursal = td.Nosucursal " &
                    "inner join divisas d on d.codigo = td.producto " &
                    "inner join tipodivisas tdi on tdi.tipo = d.tipo and tdi.nosucursal = td.Nosucursal " &
                    "where td.Nosucursal = '" & nosucursal & "' and " &
                    "td.fecha between '" & fecha1.ToString("dd/MM/yyyy") & "' and '" & fecha2.ToString("dd/MM/yyyy") & "' " &
                    " order by convert(int,td.folio_factura) asc"
            cmd = New SqlCommand(sql, con.EstablecerConexion())
            con.AbrirConexion()
            da.SelectCommand = cmd
            da.Fill(oTraspasosDet, "transferD")

            sql = "SELECT * " &
            "from transferM " &
            "where Nosucursal = '" & nosucursal & "' and " &
            "fecha between '" & fecha1.ToString("dd/MM/yyyy") & "' and '" & fecha2.ToString("dd/MM/yyyy") & "' " &
            " order by convert(int,folio_factura) asc"
            cmd = New SqlCommand(sql, con.EstablecerConexion())
            da.SelectCommand = cmd
            da.Fill(oTraspasosDet, "transferM")
        End If

        LiberarVariables()
        Return oTraspasosDet
    End Function

    Public Function ReporteFraccionar(ByVal nosucursal As String, ByVal fecha1 As Date, ByVal fecha2 As Date)
        Dim oTraspasosDet As Fraccionar = New Fraccionar
        CargarVariables()
        da = New SqlDataAdapter

        sql = "select 'DOLARES USD' as divisa, rCD.producto, rCD.cantidads/d.valor as cantidads, rC.folio_fraccion, rCD.operacion " &
                ", rC.Nosucursal from remisioCA rC " &
                "inner join remisioCA_Det rCD on rCD.Nosucursal = rC.Nosucursal and rCD.folio_fraccion = rC.folio_fraccion and rCD.operacion = rC.operacion " &
                "Inner join divisas d on d.codigo = rCD.producto " &
                "where rC.Nosucursal = '" & nosucursal & "' and " &
                "rC.fecha between '" & fecha1.ToString("dd/MM/yyyy") & "' and '" & fecha2.ToString("dd/MM/yyyy") & "' " &
                " and rC.folio_factura = '0' order by rC.folio_fraccion, rCD.operacion asc"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oTraspasosDet, "Fraccionar")

        LiberarVariables()
        Return oTraspasosDet
    End Function

    Public Function ImprimeNotaCargo(ByVal Cliente As String, ByVal folio As String, ByVal sucursal As String) As DataSet
        Dim oNotaCar As NotaIncentivo = New NotaIncentivo
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT * FROM clientescnbv where cliente=" & Convert.ToInt32(Cliente) & ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oNotaCar, "clientescnbv")

        sql = "SELECT Folio, Cliente, Fecha, Importe, Folio_Factura, Nosucursal, letra " &
            "FROM Nota_Incentivo where cliente=" & Convert.ToInt32(Cliente) & " and folio ='" & folio & "' "

        If sucursal IsNot Nothing Then
            sql += " and Nosucursal='" & sucursal & "'"
        End If
        sql += ";"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotaCar, "NotaIncentivo")

        sql = "SELECT id,nombre,folio_NC,direccion,colonia,CP,Estado,Municipio,Pais,letra_NCar AS letra, 'NCA' as letra2 FROM Sucursales where id='" & sucursal & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oNotaCar, "Sucursales")

        LiberarVariables()
        Return oNotaCar
    End Function
End Class

