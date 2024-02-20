Imports System.Data.SqlClient
Public Class transferDC
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet = Nothing
    Dim sql, where, strSet As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim dr As SqlDataReader = Nothing
    Dim abc As Integer = Nothing
    Dim abc2 As String = ""
    Dim dt As DataTable
    Dim disposed As Boolean = False

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

    Public Function AtransferD(ByVal data As transferDM) As Integer
        CargarVariables()
        sql = "INSERT INTO transferD(folio_factura,producto,cantidads,p_unitario," &
            "stotal,descuento,capacidad,unidad,descripcion_larga,Nosucursal)" &
            "VALUES(@folio_factura,@producto,@cantidads,@p_unitario,@stotal," &
            "@descuento,@capacidad,@unidad,@descripcion_larga,@Nosucursal)"
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

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function EtransferD(ByVal data As transferDM) As Integer
        CargarVariables()
        sql = "DELETE FROM transferD WHERE folio_factura=@folio_factura"
        cmd.Parameters.Add("@folio_factura", SqlDbType.NVarChar).Value = data.folio_factura
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function TransferenciaOrigen(ByVal no As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   td.folio_orig, "
        sql = sql & "   SUM(t.cantidads*t.p_unitario) AS importe, "
        sql = sql & "   td.folio_dest, "
        sql = sql & "   td.nosucursal_dest, "
        sql = sql & "   transferM.hora "
        sql = sql & "FROM "
        sql = sql & "   TransferDet td "
        sql = sql & "   INNER JOIN transferD t ON t.folio_factura = td.folio_orig And "
        sql = sql & "   t.Nosucursal = td.nosucursal_orig "
        sql = sql & "   INNER Join transferM ON td.folio_orig = transferM.folio_factura "
        sql = sql & "   And td.nosucursal_orig = transferM.Nosucursal "
        sql = sql & "WHERE "
        sql = sql & "   td.firma_orig Is null And "
        sql = sql & "   td.nosucursal_orig = '" & no & "' "
        sql = sql & "GROUP BY "
        sql = sql & "   td.folio_orig, "
        sql = sql & "   td.folio_dest, "
        sql = sql & "   td.nosucursal_dest, "
        sql = sql & "   transferM.hora"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function TransferenciaDestino(ByVal no As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = ""
        sql = sql & "select "
        sql = sql & "   td.folio_dest, "
        sql = sql & "   SUM(t.cantidads*t.p_unitario) as importe, "
        sql = sql & "   td.nosucursal_orig, "
        sql = sql & "   transferM.hora "
        sql = sql & "from "
        sql = sql & "   TransferDet td "
        sql = sql & "   inner join transferD t on t.folio_factura = td.folio_dest And "
        sql = sql & "   t.Nosucursal = td.nosucursal_dest "
        sql = sql & "   INNER Join transferM ON td.folio_dest = transferM.folio_factura "
        sql = sql & "   And td.nosucursal_dest = transferM.Nosucursal "
        sql = sql & "where "
        sql = sql & "   td.firma_dest Is null And "
        sql = sql & "   td.nosucursal_dest = '" & no & "' "
        sql = sql & "group by "
        sql = sql & "   td.folio_dest, "
        sql = sql & "   td.nosucursal_orig, "
        sql = sql & "   transferM.hora "
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function TransferenciaDinero(ByVal no As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT td.folio_orig, SUM(t.cantidads*t.p_unitario) AS importe  FROM TransferDet td " &
        "INNER JOIN transferD t ON t.folio_factura = td.folio_orig And t.Nosucursal = td.nosucursal_orig " &
        "WHERE td.estatus = 3 And td.nosucursal_orig = '" & no & "' GROUP BY td.folio_orig"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function TransferenciaRegistro(ByVal no As String, ByVal folio As Integer) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = ""
        sql = sql & "select "
        sql = sql & "   te.divisa, "
        sql = sql & "   te.producto, "
        sql = sql & "   te.ts, "
        sql = sql & "   te.precio, "
        sql = sql & "   td.cantidads, "
        sql = sql & "   te.precio * td.cantidads as importe "
        sql = sql & "from "
        sql = sql & "   TranferE te "
        sql = sql & "   inner join transferD td on td.folio_factura = te.folio And "
        sql = sql & "   td.Nosucursal = te.Nosucursal And td.producto = te.producto "
        sql = sql & "where "
        sql = sql & "   te.folio = " & folio & " And "
        sql = sql & "   te.Nosucursal = '" & no & "' "
        sql = sql & "order by "
        sql = sql & "   te.divisa, "
        sql = sql & "   case te.divisa "
        sql = sql & "       when 'CANADIENSES' then convert(int,substring(te.producto,3,5)) "
        sql = sql & "       when 'DAUSTRALIANO' then convert(int, substring(te.producto,3,5)) "
        sql = sql & "       when 'YEN JAPONES' then convert(int, substring(te.producto,3,5)) "
        sql = sql & "   else convert(int,substring(te.producto,2,4)) end "
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function TransferenciaRegistro2(ByVal no As String, ByVal folio As Integer) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = ""
        sql = sql & "select "
        sql = sql & "   te.divisa, "
        sql = sql & "   te.producto, "
        sql = sql & "   te.te, "
        sql = sql & "   te.precio, "
        sql = sql & "   td.cantidads, "
        sql = sql & "   te.precio*td.cantidads as importe "
        sql = sql & "from "
        sql = sql & "   TranferE te "
        sql = sql & "   inner join transferD td on td.folio_factura = te.folio And "
        sql = sql & "   td.Nosucursal = te.Nosucursal And td.producto = te.producto "
        sql = sql & "where "
        sql = sql & "   te.folio = " & folio & " And "
        sql = sql & "   te.Nosucursal = '" & no & "' "
        sql = sql & "order by "
        sql = sql & "   te.divisa, "
        sql = sql & "   case te.divisa "
        sql = sql & "       when 'CANADIENSES' then convert(int,substring(te.producto,3,5)) "
        sql = sql & "       when 'DAUSTRALIANO' then convert(int, substring(te.producto,3,5)) "
        sql = sql & "       when 'YEN JAPONES' then convert(int, substring(te.producto,3,5)) "
        sql = sql & "   else "
        sql = sql & "       convert(int,substring(te.producto,2,4)) "
        sql = sql & "   end "
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function TransferenciaExistencias(ByVal no As String, ByVal folio As Integer, ByVal Tipo As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        If Tipo = "SALIDA" Then
            sql = ""
            sql = sql & "select "
            sql = sql & "   te.fecha, "
            sql = sql & "   te.producto, "
            sql = sql & "   te.ts, "
            sql = sql & "   te.precio, "
            sql = sql & "   td.cantidads, "
            sql = sql & "   te.precio*td.cantidads as importe, "
            sql = sql & "   case when "
            sql = sql & "       te.divisa = 'DOLARES' then 1 "
            sql = sql & "   else "
            sql = sql & "       case when te.divisa = 'EUROS' then 2 "
            sql = sql & "   else "
            sql = sql & "       case when te.divisa = 'CANADIENSES' then 3 "
            sql = sql & "   else "
            sql = sql & "       case when te.divisa = 'LIBRAS' then 4 "
            sql = sql & "   else "
            sql = sql & "       case when te.divisa = 'YUAN' then 5 "
            sql = sql & "   else "
            sql = sql & "       case when te.divisa = 'AUSTRALIA' then 6 "
            sql = sql & "   else "
            sql = sql & "       case when te.divisa = 'FRANCO' then 7 "
            sql = sql & "   else "
            sql = sql & "       case when te.divisa = 'YEN JAPONES' then 8 "
            sql = sql & "   else 0 "
            sql = sql & "   end end end end end end end end as tipo "
            sql = sql & "from TranferE te "
            sql = sql & "   inner join transferD td on td.folio_factura = te.folio And "
            sql = sql & "   td.Nosucursal = te.Nosucursal And td.producto = te.producto "
            sql = sql & "where "
            sql = sql & "   te.folio = " & folio & " And "
            sql = sql & "   te.Nosucursal = '" & no & "' "
            sql = sql & "order by "
            sql = sql & "   te.divisa"
        ElseIf Tipo = "ENTRADA" Then
            sql = ""
            sql = sql & "select "
            sql = sql & "   te.fecha, "
            sql = sql & "   te.producto, "
            sql = sql & "   te.te, "
            sql = sql & "   te.precio, "
            sql = sql & "   td.cantidads, "
            sql = sql & "   te.precio*td.cantidads as importe, "
            sql = sql & "   case when "
            sql = sql & "       te.divisa = 'DOLARES' then 1 "
            sql = sql & "   else "
            sql = sql & "       case when te.divisa = 'EUROS' then 2 "
            sql = sql & "   else "
            sql = sql & "       case when te.divisa = 'CANADIENSES' then 3 "
            sql = sql & "   else "
            sql = sql & "       case when te.divisa = 'LIBRAS' then 4 "
            sql = sql & "   else "
            sql = sql & "       case when te.divisa = 'YUAN' then 5 "
            sql = sql & "   else "
            sql = sql & "       case when te.divisa = 'AUSTRALIA' then 6 "
            sql = sql & "   else "
            sql = sql & "       case when te.divisa = 'FRANCO' then 7 "
            sql = sql & "   else "
            sql = sql & "       case when te.divisa = 'YEN JAPONES' then 8 "
            sql = sql & "   else 0 "
            sql = sql & "   end end end end end end end end as tipo "
            sql = sql & "from "
            sql = sql & "   TranferE te "
            sql = sql & "   inner join transferD td on td.folio_factura = te.folio And "
            sql = sql & "   td.Nosucursal = te.Nosucursal And td.producto = te.producto "
            sql = sql & "where "
            sql = sql & "   te.folio = " & folio & " And "
            sql = sql & "   te.Nosucursal = '" & no & "' "
            sql = sql & "order by "
            sql = sql & "   te.divisa"
        End If
        
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function UpdateTranfer(ByVal folio As Integer, ByVal estatus As Integer, ByVal suc As String, ByVal usu As String, ByVal fecha As DateTime, ByVal contrasenia As String) As Integer
        CargarVariables()
        If estatus = 1 Then
            sql = "update TransferDet set estatus = 2, fecha_orig = '" & fecha & "', " & _
                "firma_orig = '" & contrasenia & "', usu_orig = '" & usu & "' where folio_orig = " & folio & " and nosucursal_orig = '" & suc & "'"
        ElseIf estatus = 2 Then
            sql = "update TransferDet set estatus = 4, fecha_dest = '" & fecha.ToString("dd/MM/yyyy") & "', " & _
                "firma_dest = '" & contrasenia & "', usu_dest = '" & usu & "' where folio_dest = " & folio & " and nosucursal_dest = '" & suc & "'"
        ElseIf estatus = 3 Then
            sql = "update TransferDet set estatus = 4, fecha_efec = '" & fecha.ToString("dd/MM/yyyy") & "', " & _
                "firma_efec = '" & contrasenia & "', usu_efec = '" & usu & "' where folio_orig = " & folio & " and nosucursal_orig = '" & suc & "'"
        End If

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function ValidarContrasena(ByVal contrasena As String) As Integer
        CargarVariables()
        sql = "SELECT count(*) FROM Usuarios where contrasenia = '" & contrasena & "'"
        AccesoDatos()
        Dim execute As String = cmd.ExecuteScalar().ToString()
        If IsNumeric(execute) Then 'If execute IsNot Nothing Or execute <> "NULL" Or execute <> "" Then
            abc = Convert.ToInt32(execute)
        End If
        LiberarVariables()
        Return abc
    End Function

    Public Function SucursalesDestOrig(ByVal Sucursal As String) As String
        CargarVariables()
        sql = "SELECT nombre FROM Sucursales where id = '" & Sucursal & "'"
        AccesoDatos()
        Dim execute As String = cmd.ExecuteScalar().ToString()
        'If IsNumeric(execute) Then 'If execute IsNot Nothing Or execute <> "NULL" Or execute <> "" Then
        abc2 = execute
        'End If
        LiberarVariables()
        Return abc2
    End Function

    Public Function MtransferD(ByVal data As transferDM, ByVal otransferD As transferDM) As Integer
        CargarVariables()
        sql = "update transferD set "
        If data.folio_factura <> otransferD.folio_factura And data.folio_factura <> Nothing Then
            strSet += "folio_factura=@folio_factura,"
            cmd.Parameters.Add("@folio_factura", SqlDbType.NVarChar).Value = data.folio_factura
        End If

        If data.producto <> otransferD.producto And data.producto <> Nothing Then
            strSet += "producto=@producto,"
            cmd.Parameters.Add("@producto", SqlDbType.NVarChar).Value = data.producto
        End If

        If data.cantidads <> otransferD.cantidads And data.cantidads <> Nothing Then
            strSet += "cantidads=@cantidads,"
            cmd.Parameters.Add("@cantidads", SqlDbType.Real).Value = data.cantidads
        End If

        If data.p_unitario <> otransferD.p_unitario And data.p_unitario <> Nothing Then
            strSet += "p_unitario=@p_unitario,"
            cmd.Parameters.Add("@p_unitario", SqlDbType.Float).Value = data.p_unitario
        End If

        If data.stotal <> otransferD.stotal And data.stotal <> Nothing Then
            strSet += "stotal=@stotal,"
            cmd.Parameters.Add("@stotal", SqlDbType.Float).Value = data.stotal
        End If

        If data.descuento <> otransferD.descuento And data.descuento <> Nothing Then
            strSet += "descuento=@descuento,"
            cmd.Parameters.Add("@descuento", SqlDbType.Int).Value = data.descuento
        End If

        If data.capacidad <> otransferD.capacidad And data.capacidad <> Nothing Then
            strSet += "capacidad=@capacidad,"
            cmd.Parameters.Add("@capacidad", SqlDbType.NVarChar).Value = data.capacidad
        End If

        If data.unidad <> otransferD.unidad And data.unidad <> Nothing Then
            strSet += "localidad=@localidad,"
            cmd.Parameters.Add("@unidad", SqlDbType.NVarChar).Value = data.unidad
        End If

        If data.descripcion_larga <> otransferD.descripcion_larga And data.descripcion_larga <> Nothing Then
            strSet += "descripcion_larga=@descripcion_larga,"
            cmd.Parameters.Add("@descripcion_larga", SqlDbType.NText).Value = data.descripcion_larga
        End If

        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += " where folio_factura=@folio_factura2"
        cmd.Parameters.Add("@folio_factura2", SqlDbType.NVarChar).Value = otransferD.folio_factura
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Private Sub maswhere(ByVal data As transferDM, ByVal a As String, ByVal b As String, ByVal likeoigual As Boolean)
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

        If Not data.Nosucursal Is Nothing Then
            where = where & " Nosucursal" & operador & "'" & a & "'+@Nosucursal+'" & b & "' and"
            cmd.Parameters.Add("@Nosucursal", SqlDbType.NVarChar).Value = data.Nosucursal
        End If

        If where.Trim.Length > 0 Then
            where = " WHERE " & where.Remove(where.Length - 3, 3)
        End If
    End Sub

#Region "Inventario"

    Public Function StransferD2(ByVal fechaI As DateTime, ByVal fechaF As DateTime, ByVal Nosucursal As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT * FROM transferD where fecha between '" & fechaI.ToString("dd/MM/yyyy") & "' and '" & fechaF.ToString("dd/MM/yyyy") & "'" &
            "and Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function CantDivisasC1(ByVal codigo As String, ByVal fechaI As DateTime, ByVal fechaF As DateTime, ByVal Nosucursal As String) As Integer
        CargarVariables()
        'primero la cantidad de divisas x divisa que se tiene "COMPRA"
        sql = "select sum(cantidads) as canent from transferD as tD inner join transferM as tM on " & _
        "tD.folio_factura = tM.folio_factura where tM.observaciones ='ENTRADA' and tD.producto ='" & codigo & "'" & _
        " and tD.fecha=tM.fecha and tM.fecha <" & fechaF & "' and tD.Nosucursal='" & Nosucursal & "';"
        '"and fecha between '" & fechaI.ToString("dd/MM/yyyy") & "' and '" & fechaF.ToString("dd/MM/yyyy") & "'"

        AccesoDatos()
        Dim execute As String
        execute = cmd.ExecuteScalar().ToString()
        If execute Is Nothing Or execute = "NULL" Or execute = "" Then
            abc = 0
        Else
            abc = CInt(execute)
        End If
        LiberarVariables()
        Return abc
    End Function

    Public Function TotDivisasC2(ByVal codigo As String, ByVal fechaI As DateTime, ByVal fechaF As DateTime, ByVal Nosucursal As String) As Double
        CargarVariables()
        'la suma de los totales de divisas x divisa que se tiene "COMPRA"
        sql = "select sum(tD.cantidads/d.valor) as canent from transferD as tD inner join transferM as tM on " &
"tD.folio_factura = tM.folio_factura and tM.Nosucursal=tD.Nosucursal inner join divisas as d on tD.producto=d.codigo " &
" where tM.observaciones ='ENTRADA' and tD.producto ='" & codigo & "' and tD.fecha=tM.fecha and tM.fecha < '" & fechaF.ToString("dd/MM/yyyy") & "'" &
          "and tD.Nosucursal='" & Nosucursal & "';"
        '"and fecha between '" & fechaI.ToString("dd/MM/yyyy") & "' and '" & fechaF.ToString("dd/MM/yyyy") & "'"
        AccesoDatos()
        Dim execute As String
        execute = cmd.ExecuteScalar().ToString()
        If execute Is Nothing Or execute = "NULL" Or execute = "" Then
            abc = 0
        Else
            abc = CInt(execute)
        End If
        LiberarVariables()
        Return abc
    End Function

    Public Function CantDivisasC3(ByVal codigo As String, ByVal fechaI As DateTime, ByVal fechaF As DateTime, ByVal Nosucursal As String) As Integer 'cantidades de compra de hoy
        CargarVariables()
        'la suma de los totales de divisas x divisa que se tiene "COMPRA"
        sql = "select sum(tD.cantidads/d.valor) as canent from transferD as tD inner join transferM as tM on " &
"tD.folio_factura = tM.folio_factura and tM.Nosucursal=tD.Nosucursal inner join divisas as d on tD.producto=d.codigo" &
" where tM.observaciones ='ENTRADA' and tD.producto ='" & codigo & "' and tD.fecha=tM.fecha and tM.fecha <'" & fechaF.ToString("dd/MM/yyyy") & "'" &
          "and tD.Nosucursal='" & Nosucursal & "';"
        '"and fecha between '" & fechaI.ToString("dd/MM/yyyy") & "' and '" & fechaF.ToString("dd/MM/yyyy") & "'"
        AccesoDatos()
        Dim execute As String
        execute = cmd.ExecuteScalar().ToString()
        If execute Is Nothing Or execute = "NULL" Or execute = "" Then
            abc = 0
        Else
            abc = CInt(execute)
        End If
        LiberarVariables()
        Return abc
    End Function

    Public Function CantDivisasV4(ByVal codigo As String, ByVal fechaI As DateTime, ByVal fechaF As DateTime, ByVal Nosucursal As String) As Integer 'cantidades de venta de hoy
        CargarVariables()
        'la suma de los totales de divisas x divisa que se tiene "COMPRA"
        sql = "select sum(tD.cantidads/d.valor) as cansal from transferD as tD inner join transferM as tM on " &
"tD.folio_factura = tM.folio_factura and tM.Nosucursal=tD.Nosucursal inner join divisas as d on tD.producto=d.codigo " &
" where tM.observaciones ='SALIDA' and tD.producto ='" & codigo & "' and tD.fecha=tM.fecha and  tM.fecha <'" & fechaF.ToString("dd/MM/yyyy") & "'" &
          "and tD.Nosucursal='" & Nosucursal & "';"
        '"and fecha between '" & fechaI.ToString("dd/MM/yyyy") & "' and '" & fechaF.ToString("dd/MM/yyyy") & "'"
        AccesoDatos()
        Dim execute As String
        execute = cmd.ExecuteScalar().ToString()
        If execute Is Nothing Or execute = "NULL" Or execute = "" Then
            abc = 0
        Else
            abc = CInt(execute)
        End If
        LiberarVariables()
        Return abc
    End Function

    Public Function TipoDivisa5(ByVal tipo As Integer, ByVal no As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "select * from tipodivisas" & no & " where tipo =" & tipo
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function CantDivisasC6(ByVal codigo As String, ByVal fecha As DateTime, ByVal Nosucursal As String) As Integer
        CargarVariables()
        'la suma de los totales de divisas x divisa que se tiene "COMPRA"
        sql = "select sum(tD.cantidads/d.valor) as canent from transferD as tD inner join transferM as tM on " &
"tD.folio_factura = tM.folio_factura and tM.Nosucursal=tD.Nosucursal inner join divisas as d on tD.producto=d.codigo" &
" where tM.observaciones ='ENTRADA' and tD.producto ='" & codigo & "' and tD.fecha=tM.fecha and tM.fecha ='" & fecha.ToString("dd/MM/yyyy") & "'" &
          "and tD.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        Dim execute As String
        execute = cmd.ExecuteScalar().ToString()
        If execute Is Nothing Or execute = "NULL" Or execute = "" Then
            abc = 0
        Else
            abc = CInt(execute)
        End If
        LiberarVariables()
        Return abc
    End Function

    Public Function CantDivisasV7(ByVal codigo As String, ByVal fecha As DateTime, ByVal Nosucursal As String) As Integer
        CargarVariables()
        'la suma de los totales de divisas x divisa que se tiene "COMPRA"
        sql = "select sum(tD.cantidads/d.valor) as cansal from transferD as tD inner join transferM as tM on " &
"tD.folio_factura = tM.folio_factura and tM.Nosucursal=tD.Nosucursal inner join divisas as d on tD.producto=d.codigo " &
" where tM.observaciones ='SALIDA' and tD.producto ='" & codigo & "' and tD.fecha=tM.fecha and tM.fecha ='" & fecha.ToString("dd/MM/yyyy") & "'" &
          "and tD.Nosucursal='" & Nosucursal & "';"
        AccesoDatos()
        Dim execute As String
        execute = cmd.ExecuteScalar().ToString()
        If execute Is Nothing Or execute = "NULL" Or execute = "" Then
            abc = 0
        Else
            abc = CInt(execute)
        End If
        LiberarVariables()
        Return abc
    End Function

#End Region

    Public Function S1transferD(ByVal otransferD As transferDM) As transferDM
        CargarVariables()
        maswhere(otransferD, "", "", False)
        sql = " SELECT * FROM remisioD"
        AccesoDatos()
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        While dr.Read()
            otransferD.folio_factura = dr.GetString(0)
            otransferD.producto = dr.GetString(1)
            otransferD.cantidads = dr.GetDouble(2)
            otransferD.p_unitario = dr.GetDouble(3)
            otransferD.stotal = dr.GetDouble(4)
            otransferD.descuento = dr.GetInt32(5)
            otransferD.capacidad = dr.GetString(6)
            otransferD.unidad = dr.GetString(7)
            otransferD.descripcion_larga = dr.GetString(8)
            otransferD.Nosucursal = dr.GetString(9)
            Exit While
        End While
        LiberarVariables()
        Return otransferD
    End Function

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

End Class
