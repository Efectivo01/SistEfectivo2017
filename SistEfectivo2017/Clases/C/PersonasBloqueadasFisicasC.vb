Imports System.Data.SqlClient

Public Class PersonasBloqueadasFisicasC
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

#Region "ABC o ABM completos"
    Public Function Insert(ByVal data As PersonasBloqueadasFisicasM) As Integer
        CargarVariables()
        sql = "insert into PersonasBloqueadasFisicas(Nombres,ApellidoPaterno,ApellidoMaterno,FechaN,Alias,Relacion)" & _
        "values (@Nombres,@ApellidoPaterno,@ApellidoMaterno,@FechaN,@Alias,@Relacion)"
        'cmd.Parameters.Add("@Num", SqlDbType.Int).Value = data.Num
        cmd.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = data.Nombres
        cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar).Value = data.ApellidoPaterno
        cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar).Value = data.ApellidoMaterno
        cmd.Parameters.Add("@FechaN", SqlDbType.VarChar).Value = data.FechaN
        cmd.Parameters.Add("@Alias", SqlDbType.VarChar).Value = data.Alias_
        cmd.Parameters.Add("@Relacion", SqlDbType.Int).Value = data.Relacion

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Delete(ByVal data As PersonasBloqueadasFisicasM) As Integer
        CargarVariables()
        sql = "DELETE FROM PersonasBloqueadasFisicas WHERE Num=@Num"
        cmd.Parameters.Add("@Num", SqlDbType.Int).Value = data.Num
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Update(ByVal data As PersonasBloqueadasFisicasM, ByVal obj As PersonasBloqueadasFisicasM) As Integer
        'data es el objeto originas y obj es en el que se modificaron datos
        CargarVariables()
        sql = "update PersonasBloqueadasFisicas set "
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

        If data.Alias_ <> obj.Alias_ And data.Alias_ <> Nothing Then
            strSet += "Alias=@Alias ,"
            cmd.Parameters.Add("@Alias", SqlDbType.NVarChar).Value = data.Alias_
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

    Private Sub maswhere(ByVal data As PersonasBloqueadasFisicasM, ByVal a As String, ByVal b As String, ByVal likeoigual As Boolean)
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

        If data.Alias_ <> Nothing Then
            where = where & " Alias_=@Alias_ and"
            cmd.Parameters.Add("@Alias_", SqlDbType.VarChar).Value = data.Alias_
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
    Public Function Select1(ByVal data As PersonasBloqueadasFisicasM) As PersonasBloqueadasFisicasM
        CargarVariables()
        maswhere(data, "", "", False)
        sql = " SELECT * FROM PersonasBloqueadasFisicas "
        AccesoDatos()
        dr = cmd.ExecuteReader()
        If dr.HasRows = True Then
            While dr.Read()
                data.Num = dr.GetInt32(0)
                data.Nombres = dr.GetString(1)
                data.ApellidoPaterno = dr.GetString(2)
                data.ApellidoMaterno = dr.GetString(3)
                data.FechaN = dr.GetString(4)
                data.Alias_ = dr.GetString(5)
                data.Relacion = dr.GetInt32(6)
                Exit While
            End While
        End If

        LiberarVariables()
        Return data
    End Function

    Public Function Max() As Integer
        CargarVariables()
        sql = "SELECT MAX(Num) FROM PersonasBloqueadasFisicas"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function Maxy1() As Integer
        CargarVariables()
        sql = "SELECT MAX(Num) +1 FROM PersonasBloqueadasFisicas"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function
#End Region

#Region "Simples ABCS"
    Public Function Modifica(ByVal Num As Integer) As Integer
        CargarVariables()
        sql = "update PersonasBloqueadasFisicas set campo=valor where Num=" & Num
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Aliass(ByVal Num As Integer) As String
        CargarVariables()
        sql = "select Alias from PersonasBloqueadasFisicas where Num=" & Num
        AccesoDatos()
        'abc = EjecutarABC()
        execute = cmd.ExecuteScalar().ToString()
        LiberarVariables()
        Return execute
    End Function
#End Region

#Region "FILTRO"
    Public Function FILTRAR_ALL(ByVal data As PersonasBloqueadasFisicasM, ByVal a As String, ByVal b As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, a, b, True)
        sql = "SELECT Num,(Nombres + ' '+ ApellidoPaterno + ' '+ ApellidoMaterno) as NomCompleto,FechaN,Alias FROM PersonasBloqueadasFisicas "
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    'Public Function FILTRAR_ListaInterna() As DataSet
    '    CargarVariables()
    '    CargarVariablesDS()
    '    sql = "SELECT Nombre, ApellidoPaterno+' '+ ApellidoMaterno as Apellido FROM listaInterna "
    '    AccesoDatos()
    '    RecopilarDatos()
    '    LiberarVariables()
    '    Return ds
    'End Function

    Public Function FILTRAR_ListaInterna(ByVal nombrecompleto As String) As Integer
        CargarVariables()
        'sql = "SELECT folio_remision +1 FROM [control];"
        sql = "SELECT Count(*) as Lst FROM listaInterna where Nombre + ' ' + apellidoPaterno + ' ' + apellidoMaterno like '" & nombrecompleto & "';"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function Valida_Existencia(ByVal data As PersonasBloqueadasFisicasM, ByVal a As String, ByVal b As String) As DataTable
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, a, b, True)
        sql = "SELECT Num,(Nombres + ' '+ ApellidoPaterno + ' '+ ApellidoMaterno) as NomCompleto,FechaN,Alias " & _
            "FROM PersonasBloqueadasFisicas "
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function
#End Region
End Class
