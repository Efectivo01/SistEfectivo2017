Imports System.Data.SqlClient

Public Class PersonasPoliticasEC
    Implements IDisposable
#Region "variables"
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
#End Region

#Region "Dispose"
    Public Sub Close()
        Dispose()
    End Sub

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
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

#Region "Ejecutar consulta"
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
        cmd.CommandText = sql & strSet & where & " ;"
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

#Region "ABC o ABM completos"
    Public Function Insert(ByVal data As PersonasPoliticasEM) As Integer
        CargarVariables()
        sql = "insert into PersonasPoliticasE(Nombres,ApellidoPaterno,ApellidoMaterno,Periodo,CargoOcupado,Relacion)" & _
        "values (@Nombres,@ApellidoPaterno,@ApellidoMaterno,@Periodo,@CargoOcupado,@Relacion)"
        'cmd.Parameters.Add("@Num", SqlDbType.Int).Value = data.Num
        cmd.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = data.Nombres
        cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar).Value = data.ApellidoPaterno
        cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar).Value = data.ApellidoMaterno
        cmd.Parameters.Add("@Periodo", SqlDbType.VarChar).Value = data.Periodo
        cmd.Parameters.Add("@CargoOcupado", SqlDbType.VarChar).Value = data.CargoOcupado
        cmd.Parameters.Add("@Relacion", SqlDbType.Int).Value = data.Relacion

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Delete(ByVal data As PersonasPoliticasEM) As Integer
        CargarVariables()
        sql = "DELETE FROM PersonasPoliticasE WHERE Num=@Num"
        cmd.Parameters.Add("@Num", SqlDbType.Int).Value = data.Num
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Update(ByVal data As PersonasPoliticasEM, ByVal obj As PersonasPoliticasEM) As Integer
        'data es el objeto originas y obj es en el que se modificaron datos
        CargarVariables()
        sql = "update PersonasPoliticasE set "
        If data.Nombres <> obj.Nombres And data.Nombres <> Nothing Then
            strSet += "Nombres=@Nombres ,"
            cmd.Parameters.Add("@Nombres", SqlDbType.NVarChar).Value = data.Nombres
        End If

        If data.ApellidoPaterno <> obj.ApellidoPaterno And data.ApellidoPaterno <> Nothing Then
            strSet += "ApellidoPaterno=@ApellidoPaterno ,"
            cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.NVarChar).Value = data.ApellidoPaterno
        End If

        If data.ApellidoMaterno <> obj.ApellidoMaterno And data.ApellidoMaterno <> Nothing Then
            strSet += "ApellidoMaterno=@ApellidoMaterno ,"
            cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.NVarChar).Value = data.ApellidoMaterno
        End If

        If data.Periodo <> obj.Periodo And data.Periodo <> Nothing Then
            strSet += "Periodo=@Periodo ,"
            cmd.Parameters.Add("@Periodo", SqlDbType.NVarChar).Value = data.Periodo
        End If

        If data.CargoOcupado <> obj.CargoOcupado And data.CargoOcupado <> Nothing Then
            strSet += "CargoOcupado=@CargoOcupado ,"
            cmd.Parameters.Add("@CargoOcupado", SqlDbType.NVarChar).Value = data.CargoOcupado
        End If

        If data.Relacion <> obj.Relacion And data.Relacion <> Nothing Then
            strSet += "Relacion=@Relacion ,"
            cmd.Parameters.Add("@Relacion", SqlDbType.Int).Value = data.Relacion
        End If


        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += " where Num=@Num"
        cmd.Parameters.Add("@Num", SqlDbType.Int).Value = obj.Num
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

#End Region

#Region "Parte Where del select"

    Private Sub maswhere(ByVal data As PersonasPoliticasEM, ByVal a As String, ByVal b As String, ByVal likeoigual As Boolean)
        Dim operador As String = ""
        Select Case likeoigual
            Case True
                operador = " like "
            Case False
                operador = "="
        End Select

        If data.Num > 0 Then
            where = where & "Num" & operador & "'" & a & "'+@Num+'" & b & "' and"
            cmd.Parameters.Add("@Num", SqlDbType.Int).Value = data.Num
        End If

        If data.Nombres <> Nothing Then
            where = where & " Nombres" & operador & "'" & a & "'+@Nombres+'" & b & "' and"
            cmd.Parameters.Add("@Nombres", SqlDbType.NVarChar).Value = data.Nombres
        End If

        If data.ApellidoPaterno <> Nothing Then
            where = where & " ApellidoPaterno=@ApellidoPaterno and"
            cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar).Value = data.ApellidoPaterno
        End If

        If data.CargoOcupado <> Nothing Then
            where = where & " CargoOcupado_=@CargoOcupado_ and"
            cmd.Parameters.Add("@CargoOcupado_", SqlDbType.VarChar).Value = data.CargoOcupado
        End If

        If data.Relacion > 0 Then
            where = where & " Relacion=@Relacion and"
            cmd.Parameters.Add("@Relacion", SqlDbType.Int).Value = data.Relacion
        End If


        If where.Trim.Length > 0 Then
            where = " WHERE " & where.Remove(where.Length - 3, 3)
        End If
        'where += " order by ApellidoPaterno,Nombre"
    End Sub
#End Region

#Region "selects"
    Public Function Select1(ByVal data As PersonasPoliticasEM) As PersonasPoliticasEM
        CargarVariables()
        maswhere(data, "", "", False)
        sql = " SELECT * FROM PersonasPoliticasE "
        AccesoDatos()
        dr = cmd.ExecuteReader()
        If dr.HasRows = True Then
            While dr.Read()
                data.Num = dr.GetInt32(0)
                data.Nombres = dr.GetString(1)
                data.ApellidoPaterno = dr.GetString(2)
                data.ApellidoMaterno = dr.GetString(3)
                data.Periodo = dr.GetString(4)
                data.CargoOcupado = dr.GetString(5)
                data.Relacion = dr.GetInt32(6)
                Exit While
            End While
        End If

        LiberarVariables()
        Return data
    End Function

    Public Function Max() As Integer
        CargarVariables()
        sql = "SELECT MAX(Num) FROM PersonasPoliticasE"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function Maxy1() As Integer
        CargarVariables()
        sql = "SELECT MAX(Num) +1 FROM PersonasPoliticasE"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function
#End Region

#Region "Simples ABCS"
    Public Function Modifica(ByVal Num As Integer) As Integer
        CargarVariables()
        sql = "update PersonasPoliticasE set campo=valor where Num=" & Num
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function CargoOcupados(ByVal Num As Integer) As String
        CargarVariables()
        sql = "select CargoOcupado from PersonasPoliticasE where Num=" & Num
        AccesoDatos()
        'abc = EjecutarABC()
        execute = cmd.ExecuteScalar().ToString()
        LiberarVariables()
        Return execute
    End Function
#End Region

#Region "FILTRO"
    Public Function FILTRAR_ALL(ByVal data As PersonasPoliticasEM, ByVal a As String, ByVal b As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        'maswhere(data, a, b, True)
        'sql = "SELECT Num,Nombres+' '+ApellidoPaterno+' '+ApellidoMaterno as NomCompleto,Periodo,CargoOcupado FROM PersonasPoliticasE"
        'sql = "select cliente,Nombre+' '+ApellidoPaterno+' '+ApellidoMaterno as NomCompleto, '' as Periodo, '' as CargoOcupado from clientescnbv where PPE = 1"
        'sql = "select cliente,Nombre+' '+ApellidoPaterno+' '+ApellidoMaterno as NomCompleto, '' as Periodo, '' as CargoOcupado, Nombre, ApellidoPaterno from clientescnbv where PPE = 1"
        sql = "SELECT Num as cliente, Nombres+' '+ApellidoPaterno+' '+ApellidoMaterno AS NomCompleto " & _
        ", '' as Periodo, '' as CargoOcupado, Nombres as Nombre, ApellidoPaterno FROM PersonasPoliticasE " & _
        "UNION " & _
        "SELECT Num as cliente, Nombres+' '+ApellidoPaterno+' '+ApellidoMaterno AS NomCompleto " & _
        ", '' as Periodo, '' as CargoOcupado, Nombres as Nombre, ApellidoPaterno FROM PersonasPoliticasEEx " & _
        "UNION " & _
        "SELECT id as cliente, Nombre+' '+ApellidoPaterno+' '+ApellidoMaterno AS NomCompleto " & _
        ", '' as Periodo, '' as CargoOcupado, Nombre, ApellidoPaterno FROM OFAC"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function PersonaPE(ByVal nombre As String, ByVal AP As String, ByVal AM As String) As Integer
        CargarVariables()
        sql = "select COUNT(*) from PersonasPoliticasE where Nombres ='" & nombre & "' and ApellidoPaterno ='" & AP & "' " &
        "and ApellidoMaterno ='" & AM & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function PersonaPEEx(ByVal nombre As String, ByVal AP As String, ByVal AM As String) As Integer
        CargarVariables()
        sql = "select COUNT(*) from PersonasPoliticasEEx where Nombres ='" & nombre & "' and ApellidoPaterno ='" & AP & "' " &
        "and ApellidoMaterno ='" & AM & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function PersonaBF(ByVal nombre As String, ByVal AP As String, ByVal AM As String) As Integer
        CargarVariables()
        sql = "select COUNT(*) from PersonasBloqueadasFisicas where Nombres ='" & nombre & "' and ApellidoPaterno ='" & AP & "' " &
        "and ApellidoMaterno ='" & AM & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function ListaInt(ByVal nombre As String, ByVal AP As String, ByVal AM As String) As Integer
        CargarVariables()
        sql = "select COUNT(*) from listaInterna where Nombre ='" & nombre & "' and ApellidoPaterno ='" & AP & "' " &
        "and ApellidoMaterno ='" & AM & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function ListaPersonasBloqueadas(ByVal nombre As String) As Integer
        CargarVariables()
        sql = "select COUNT(*) from ListaPersonasBloqueadas where Nombre = '" & nombre & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function ListaPersonas69B(ByVal nombre As String, ByVal Tipo As String) As Integer
        CargarVariables()
        If Tipo = "MO" Then
            sql = "select COUNT(*) from Listado69BMoral where Nombre = '" & nombre & "';"
        Else
            sql = "select COUNT(*) from Listado69BFisica where Nombre = '" & nombre & "';"
        End If
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function ListaReportados(ByVal nombre As String, ByVal AP As String, AM As String) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   COUNT(*) "
        sql = sql & "FROM "
        sql = sql & "   ClientesReportados "
        sql = sql & "   INNER JOIN clientescnbv ON ClientesReportados.Cliente = clientescnbv.cliente "
        sql = sql & "where "
        sql = sql & "   Nombre = '" & nombre & "' and "
        sql = sql & "   ApellidoPaterno = '" & AP & "' and "
        sql = sql & "   ApellidoMaterno = '" & AM & "'"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc

    End Function
    Public Function ListaOFAC(ByVal nombre As String, ByVal AP As String, ByVal AM As String) As Integer
        CargarVariables()
        sql = "select COUNT(*) from OFAC where Nombre ='" & nombre & "' and ApellidoPaterno ='" & AP & "' " &
        "and ApellidoMaterno ='" & AM & "';"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function
#End Region
End Class
