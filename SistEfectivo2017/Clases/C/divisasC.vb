Imports System.Data.SqlClient

Public Class divisasC
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet = Nothing
    Dim sql, where, strSet As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim dr As SqlDataReader = Nothing
    Dim abc As Integer = Nothing
    Dim lst As List(Of divisasM)
    Dim dt As DataTable
    Dim disposed As Boolean = False

    Public actividadesC()

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
        lst = New List(Of divisasM)
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

    Public Sub LiberarLstDt()
        da = Nothing
        lst = Nothing
        dt = Nothing
    End Sub

    Public Function Adivisas(ByVal data As divisasM) As Integer
        CargarVariables()
        cmd.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = data.codigo
        cmd.Parameters.Add("@divisa", SqlDbType.NVarChar).Value = data.divisa
        cmd.Parameters.Add("@valor", SqlDbType.Float).Value = data.valor
        cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = data.tipo
        cmd.Parameters.Add("@cpromedio", SqlDbType.Float).Value = data.cpromedio
        sql = "INSERT INTO divisas(codigo,divisa,valor,tipo,cpromedio)VALUES(@codigo,@divisa,@valor,@tipo,@cpromedio)"
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Edivisas(ByVal data As divisasM) As Integer
        CargarVariables()
        sql = "DELETE FROM divisasM WHERE tipo=@tipo"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        cmd.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = data.tipo
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Mdivisas(ByVal data As divisasM, ByVal odivisasM As divisasM) As Integer
        CargarVariables()
        sql = "update divisas set "
        If data.codigo <> odivisasM.codigo And data.codigo <> Nothing Then
            strSet += "codigo=@codigo ,"
            cmd.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = data.codigo
        End If

        If data.divisa <> odivisasM.divisa And data.divisa <> Nothing Then
            strSet += "divisa=@divisa ,"
            cmd.Parameters.Add("@divisa", SqlDbType.NVarChar).Value = data.divisa
        End If

        If data.valor <> odivisasM.valor And data.valor <> Nothing Then
            strSet += "valor=@valor ,"
            cmd.Parameters.Add("@valor", SqlDbType.Float).Value = data.valor
        End If

        If data.tipo <> odivisasM.tipo And data.tipo <> Nothing Then
            strSet += "Venta=@Venta ,"
            cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = data.tipo
        End If

        If data.cpromedio <> odivisasM.cpromedio And data.cpromedio <> Nothing Then
            strSet += "cpromedio=@cpromedio ,"
            cmd.Parameters.Add("@cpromedio", SqlDbType.Float).Value = data.cpromedio
        End If

        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += "where codigo=@codigo2"
        cmd.Parameters.Add("@codigo2", SqlDbType.NVarChar).Value = odivisasM.codigo
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Sdivisas(ByVal data As divisasM) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT * FROM divisas"

        If data.tipo <> Nothing Then
            where = where + "tipo=@tipo and"
            cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = data.tipo
        End If

        If data.codigo <> Nothing Then
            where = where + "codigo=@codigo and"
            cmd.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = data.codigo
        End If

        If where.Trim().Length > 0 Then
            where = " where " & where.Remove(where.Length - 3, 3)
        End If
        where += " order by tipo,valor;"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Sdivisas2() As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT * FROM divisas order by tipo,valor;"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function TiposDivisas() As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "Select tipo, Nombre FROM tipodivisas Where nosucursal = '01' order by tipo"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds

    End Function

    Public Function SdivisasyTipo(ByVal data As divisasM, ByVal no As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        'sql = "select divisas.*,tipodivisas" & no & ".Nombre,tipodivisas" & no & ".Compra,tipodivisas" & no & ".Venta from divisas,tipodivisas" & no & ""
        sql = "select divisas.*,tipodivisas.Nombre,tipodivisas.Compra,tipodivisas.Venta from divisas,tipodivisas "
        If data.tipo <> Nothing Then
            where = where + "divisas.tipo=@tipo and"
            cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = data.tipo
        End If

        If data.codigo <> Nothing Then
            where = where + "divisas.codigo=@codigo and"
            cmd.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = data.codigo
        End If

        If where.Trim().Length > 0 Then
            'where = " where tipodivisas" & no & ".tipo=divisas.tipo and" & where.Remove(where.Length - 3, 3)
            where = " where  tipodivisas.nosucursal='" & no & "' and tipodivisas.tipo=divisas.tipo and" & where.Remove(where.Length - 3, 3)
        End If
        where += " order by divisas.tipo,divisas.valor;"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Fdivisas(ByVal data As divisasM, ByVal a As String, ByVal b As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT * FROM divisas"
        If Not data.codigo Is Nothing Then
            where = where & " where codigo like '" & b & "@codigo" & a & "'"
            cmd.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = data.codigo
        End If
        where += " order by tipo,valor;"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Slstdivisas(ByVal data As divisasM) As List(Of divisasM)
        CargarVariables()
        sql = "Select * from divisas order by tipo,valor;"
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            data = New divisasM()
            data.codigo = dr.GetString(0)
            data.divisa = dr.GetString(1)
            data.valor = dr.GetDouble(2)
            data.tipo = dr.GetInt32(3)
            data.cpromedio = dr.GetDouble(4)
            lst.Add(data)
        End While
        LiberarVariables()
        Return lst
    End Function

    Public Function S1divisas(ByVal data As divisasM) As divisasM
        CargarVariables()
        sql = " SELECT * FROM divisas "
        If Not data.codigo Is Nothing Then
            sql = sql & " where codigo='" & "@codigo" & "'"
            cmd.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = data.codigo
        End If
        where += " order by tipo,valor;"
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            data.codigo = dr.GetString(0)
            data.divisa = dr.GetString(1)
            data.valor = dr.GetDouble(2)
            data.tipo = dr.GetInt32(3)
            data.cpromedio = dr.GetDouble(4)
            Exit While
        End While
        LiberarVariables()
        Return data
    End Function

    Public Function RptTipado() As DataSet
        Dim oReporteDivisasDs As ReporteDivisasDs = New ReporteDivisasDs()
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT * FROM divisas "
        AccesoDatos()
        da.SelectCommand = cmd
        da.Fill(oReporteDivisasDs, "divisas")
        Return oReporteDivisasDs
    End Function

    Public Function Mcpromedio(ByVal codigo As String, ByVal cpromedio As Double) As Integer
        CargarVariables()
        cmd.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = codigo
        cmd.Parameters.Add("@cpromedio", SqlDbType.Decimal).Value = cpromedio
        sql = "update divisas set cpromedio=@cpromedio "
        strSet += "where codigo=@codigo"
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

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
End Class
