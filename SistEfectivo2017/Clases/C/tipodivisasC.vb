Imports System.Data.SqlClient

Public Class tipodivisasC
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet = Nothing
    Dim sql, where, strSet, execute As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim dr As SqlDataReader = Nothing
    Dim abc As Double
    Dim lst As List(Of tipodivisasM)
    Dim dt As DataTable
    Dim disposed As Boolean = False

    Public actividadesC()

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
        execute = ""
        abc = 0
    End Sub

    Private Sub CargarVariablesDS()
        ds = New DataSet
        da = New SqlDataAdapter
    End Sub

    Private Sub CargarVariablesDt()
        da = New SqlDataAdapter
        lst = New List(Of tipodivisasM)
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

    Public Function Atipodivisas(ByVal data As tipodivisasM, ByVal no As String) As Integer
        CargarVariables()
        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = data.Nombre
        cmd.Parameters.Add("@Compra", SqlDbType.Float).Value = data.Compra
        cmd.Parameters.Add("@Venta", SqlDbType.Real).Value = data.Venta
        sql = "INSERT INTO tipodivisas" & no & "(Nombre,Compra,Venta)VALUES(@Nombre,@Compra,@Venta)"
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Etipodivisas(ByVal data As tipodivisasM, ByVal no As String) As Integer
        CargarVariables()
        sql = "DELETE FROM tipodivisas" & no & " WHERE tipo=@tipo"
        cmd.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = data.tipo
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Mtipodivisas(ByVal data As tipodivisasM, ByVal otipodivisasM As tipodivisasM, ByVal no As String) As Integer
        CargarVariables()
        sql = "UPDATE tipodivisas" & no & " SET "
        If data.Nombre <> otipodivisasM.Nombre And data.Nombre <> Nothing Then
            strSet += "Nombre=@Nombre ,"
            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = data.Nombre
        End If

        If data.Compra <> otipodivisasM.Compra And data.Compra <> Nothing Then
            strSet += "Compra=@Compra ,"
            cmd.Parameters.Add("@Compra", SqlDbType.Float).Value = data.Compra
        End If

        If data.Venta <> otipodivisasM.Venta And data.Venta <> Nothing Then
            strSet += "Venta=@Venta ,"
            cmd.Parameters.Add("@Venta", SqlDbType.Real).Value = data.Venta
        End If
        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += "WHERE tipo=@tipo2"
        cmd.Parameters.Add("@tipo2", SqlDbType.NVarChar).Value = otipodivisasM.tipo
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Mtipodivisas2(ByVal data As tipodivisasM, ByVal no As String) As Integer
        CargarVariables()
        sql = "UPDATE tipodivisas SET "
        If data.Nombre <> Nothing Then
            strSet += "Nombre=@Nombre ,"
            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = data.Nombre
        End If

        If data.Compra <> Nothing Then
            strSet += "Compra=@Compra ,"
            cmd.Parameters.Add("@Compra", SqlDbType.Float).Value = data.Compra
        End If

        If data.Venta <> Nothing Then
            strSet += "Venta=@Venta ,"
            cmd.Parameters.Add("@Venta", SqlDbType.Real).Value = data.Venta
        End If
        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += "WHERE tipo=@tipo AND nosucursal=@nosucursal"
        cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = data.tipo
        cmd.Parameters.Add("@nosucursal", SqlDbType.VarChar).Value = data.nosucursal
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Stipodivisas(ByVal data As tipodivisasM, ByVal no As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT * FROM tipodivisas "
        sql += "WHERE nosucursal= @nosucursal"
        cmd.Parameters.Add("@nosucursal", SqlDbType.VarChar).Value = data.nosucursal
        If data.tipo <> Nothing Then
            sql = sql + " and tipo=@tipo"
            cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = data.tipo
        End If
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Stipodivisas2(ByVal no As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT * FROM tipodivisas WHERE nosucursal='" & no & "' ORDER BY tipo"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Transferencias(ByVal no As String) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   SUM(F) "
        sql = sql & "FROM "
        sql = sql & "   (SELECT count(folio_orig) as F "
        sql = sql & "   FROM TransferDet "
        sql = sql & "   WHERE "
        sql = sql & "       firma_orig is null AND nosucursal_orig = '" & no & "' "
        sql = sql & "UNION "
        sql = sql & "SELECT "
        sql = sql & "   count(folio_dest) "
        sql = sql & "FROM "
        sql = sql & "   TransferDet "
        sql = sql & "WHERE "
        sql = sql & "   firma_dest is null AND nosucursal_dest = '" & no & "' ) t"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function Ftipodivisas(ByVal data As tipodivisasM, ByVal a As String, ByVal b As String, ByVal no As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = " SELECT * FROM tipodivisas" & no & ""
        If Not data.Nombre Is Nothing Then
            sql = sql & " WHERE Nombre like '" & b & "@Nombre" & a & "'"
            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = data.Nombre
        End If
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Slsttipodivisas(ByVal data As tipodivisasM, ByVal no As String) As List(Of tipodivisasM)
        CargarVariables()
        sql = "Select * From tipodivisas" & no & ""
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            data = New tipodivisasM()
            data.tipo = dr.GetInt32(0)
            data.Nombre = dr.GetString(1)
            data.Compra = dr.GetDouble(2)
            data.Venta = dr.GetDouble(3)
            lst.Add(data)
        End While
        dr.Close()
        LiberarVariables()
        Return lst
    End Function

    Public Function S1tipodivisas(ByVal data As tipodivisasM, ByVal no As String) As tipodivisasM
        CargarVariables()
        sql = " SELECT * FROM tipodivisas" & no & " "
        If Not data.Nombre Is Nothing Then
            sql = sql & " WHERE Nombre='" & "@Nombre" & "'"
            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = data.Nombre
        End If
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            data.tipo = dr.GetInt32(0)
            data.Nombre = dr.GetString(1)
            data.Compra = dr.GetDouble(2)
            data.Venta = dr.GetDouble(3)
            Exit While
        End While
        dr.Close()
        LiberarVariables()
        Return data
    End Function

    Public Function PrecioDivisa(ByVal Nosucursal As String, ByVal tipo As Integer) As Double
        CargarVariables()
        sql = "SELECT Compra FROM tipodivisas WHERE tipo=" & tipo & " AND nosucursal='" & Nosucursal & "'"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function
End Class
