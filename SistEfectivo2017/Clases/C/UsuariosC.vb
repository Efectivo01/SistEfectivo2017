Imports System.Data.SqlClient

Public Class UsuariosC
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet = Nothing
    Dim sql, where, strSet As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim dr As SqlDataReader = Nothing
    Dim abc As Integer = Nothing
    Dim lst As List(Of UsuariosM)
    Dim dt As DataTable
    Dim disposed As Boolean = False
    Dim ValorBool As Boolean = False
    Dim abc2 As Double = Nothing
    Dim ValorDevuelto As String

    Public UsuariosC()

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

    Private Sub CargarVariablesLst()
        da = New SqlDataAdapter
        lst = New List(Of UsuariosM)
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
        'Try

        'Catch ex As Exception
        '    MessageBox.Show("Error del sistema, informele a alguien de soporte")
        'End Try
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
        lst = Nothing
        dt = Nothing
    End Sub

    Public Function Alta(ByVal data As UsuariosM) As Integer
        CargarVariables()
        sql = "INSERT INTO Usuarios(num,nombre,usuario,contrasenia,activo) values(" &
            "@num,@usuario,@contrasenia,1)"
        cmd.Parameters.Add("@num", SqlDbType.Int).Value = data.num
        cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = data.nombre
        cmd.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = data.usuario
        cmd.Parameters.Add("@contrasenia", SqlDbType.NVarChar).Value = data.contrasenia
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Baja(ByVal data As UsuariosM) As Integer
        CargarVariables()
        sql = "DELETE FROM Usuarios WHERE num=@num"
        cmd.Parameters.Add("@num", SqlDbType.Int)
        cmd.Parameters("@ID").Value = data.num
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Cambio(ByVal data As UsuariosM, ByVal oUsuariosM As UsuariosM) As Integer
        CargarVariables()
        sql = "update Usuarios set "

        If data.nombre <> oUsuariosM.nombre And data.nombre <> Nothing Then
            strSet += "nombre=@nombre,"
            cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = data.nombre
        End If

        If data.usuario <> oUsuariosM.usuario And data.usuario <> Nothing Then
            strSet += " usuario=@usuario,"
            cmd.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = data.usuario
        End If

        If data.contrasenia <> oUsuariosM.contrasenia And data.contrasenia <> Nothing Then
            strSet += " contrasenia=@contrasenia,"
            cmd.Parameters.Add("@contrasenia", SqlDbType.NVarChar).Value = data.contrasenia
        End If

        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
            strSet += " where num=@num"
        End If

        cmd.Parameters.Add("@num", SqlDbType.Int).Value = oUsuariosM.num
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Modificar(ByVal oUsuariosM As UsuariosM) As Integer
        CargarVariables()
        sql = "update Usuarios set nombre=@nombre, usuario=@usuario, contrasenia=@contrasenia where num=@num"
        cmd.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = oUsuariosM.usuario
        cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = oUsuariosM.nombre
        cmd.Parameters.Add("@contrasenia", SqlDbType.NVarChar).Value = oUsuariosM.contrasenia
        cmd.Parameters.Add("@num", SqlDbType.Int).Value = oUsuariosM.num
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Limites(ByVal cliente As Integer, ByVal tipo As Integer) As Double
        CargarVariables()
        sql = "select l.MontoMaximo from clientescnbv c " & _
        "inner join limites l on l.limite = c.limite and l.tipoDivisa = " & tipo & " " & _
        "where cliente = " & cliente
        AccesoDatos()
        Dim execute As String = cmd.ExecuteScalar().ToString()
        If IsNumeric(execute) Then
            abc2 = Convert.ToDouble(execute)
        End If
        LiberarVariables()
        Return abc2
    End Function

    Public Function LimitesAcumulado(ByVal cliente As Integer, ByVal tipo As Integer) As Double
        CargarVariables()
        sql = "select l.AcumuladoMaximo from clientescnbv c " & _
        "inner join limites l on l.limite = c.limite and l.tipoDivisa = " & tipo & " " & _
        "where cliente = " & cliente
        AccesoDatos()
        Dim execute As String = cmd.ExecuteScalar().ToString()
        If IsNumeric(execute) Then
            abc2 = Convert.ToDouble(execute)
        End If
        LiberarVariables()
        Return abc2
    End Function

    Public Function AltaPermisos(ByVal pant As Integer, ByVal permiso As Integer, ByVal NumUser As Integer) As Integer
        CargarVariables()
        sql = "INSERT INTO permisos(num,pantalla,permitido) values(" &
            "@num,@pantalla,@permitido)"
        cmd.Parameters.Add("@num", SqlDbType.Int).Value = NumUser
        cmd.Parameters.Add("@pantalla", SqlDbType.Int).Value = pant
        cmd.Parameters.Add("@permitido", SqlDbType.Int).Value = permiso
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function ModPermisos(ByVal pant As Integer, ByVal permiso As Integer, ByVal NumUser As Integer) As Integer
        CargarVariables()
        sql = "UPDATE permisos SET permitido=@permitido WHERE num=@num AND pantalla=@pantalla"
        cmd.Parameters.Add("@num", SqlDbType.Int).Value = NumUser
        cmd.Parameters.Add("@pantalla", SqlDbType.Int).Value = pant
        cmd.Parameters.Add("@permitido", SqlDbType.Int).Value = permiso
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Private Sub maswhere(ByVal data As UsuariosM, ByVal a As String, ByVal b As String, ByVal likeoigual As Boolean)
        Dim operador As String = ""
        Select Case likeoigual
            Case True
                operador = " like "
            Case False
                operador = "="
        End Select

        If data.num > 0 Then
            where = where & " num=@num and"
            cmd.Parameters.Add("@num", SqlDbType.Int).Value = data.num
        End If

        If Not data.nombre Is Nothing Then
            where = where & " nombre" & operador & " '" & b & "'+@nombre+'" & a & "' and"
            cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = data.nombre
        End If

        If Not data.nombre Is Nothing Then
            where = where & " usuario" & operador & " '" & b & "'+@usuario+'" & a & "' and"
            cmd.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = data.usuario
        End If

        If Not data.nombre Is Nothing Then
            where = where & " contrasenia" & operador & " '" & b & "'+@contrasenia+'" & a & "' and"
            cmd.Parameters.Add("@contrasenia", SqlDbType.NVarChar).Value = data.contrasenia
        End If

        If where.Trim.Length > 0 Then
            where = " WHERE " & where.Remove(where.Length - 3, 3)
        End If
    End Sub

    Public Function EligeTodo(ByVal data As UsuariosM) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, "", "", False)
        sql = "SELECT * FROM Usuarios "
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function EligeTodosMenor(ByVal data As UsuariosM) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, "", "", False)
        sql = "SELECT num,nombre,usuario,contrasenia from Usuarios"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function FiltraDs(ByVal data As UsuariosM, ByVal a As String, ByVal b As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, a, b, True)
        sql = "SELECT num,nombre,usuario,contrasenia from Usuarios"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function SiguienteIdNum() As Integer
        CargarVariables()
        sql = "SELECT MAX(num)+1 FROM Usuarios"
        AccesoDatos()
        Dim execute As String = cmd.ExecuteScalar().ToString()
        If IsNumeric(execute) Then 'If execute IsNot Nothing Or execute <> "NULL" Or execute <> "" Then
            abc = Convert.ToInt32(execute)
        End If
        LiberarVariables()
        Return abc
    End Function

    Public Function Listado(ByVal oUsuariosM As UsuariosM) As List(Of UsuariosM)
        CargarVariables()
        sql = "Select * from Usuarios"
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            oUsuariosM = New UsuariosM()
            oUsuariosM.num = dr.GetInt32(0)
            oUsuariosM.nombre = dr.GetString(1)
            oUsuariosM.contrasenia = dr.GetString(2)
            oUsuariosM.usuario = dr.GetString(3)
            lst.Add(oUsuariosM)
            oUsuariosM = Nothing
        End While
        dr.Close()
        LiberarVariables()
        Return lst
    End Function

#Region "Clientes V1"
    Public Function Elige1(ByVal oUsuariosM As UsuariosM) As UsuariosM
        CargarVariables()
        maswhere(oUsuariosM, "", "", False)
        sql = "SELECT * FROM Usuarios "
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            If Not IsDBNull(0) Then
                oUsuariosM.num = dr.GetInt32(0)
            End If

            If Not dr.IsDBNull(1) Then
                oUsuariosM.nombre = dr.GetString(1)
            End If

            If Not dr.IsDBNull(3) Then
                oUsuariosM.usuario = dr.GetString(2)
            End If

            If Not dr.IsDBNull(2) Then
                oUsuariosM.contrasenia = dr.GetString(3)
            End If
            Exit While
        End While
        dr.Close()
        LiberarVariables()
        Return oUsuariosM
    End Function
#End Region

    Public Function FiltraDt(ByVal data As UsuariosM, ByVal a As String, ByVal b As String) As DataTable
        CargarVariables()
        CargarVariablesDt()
        maswhere(data, a, b, True)
        sql = "SELECT * FROM Usuarios "
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function NombresDt() As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT num,nombre FROM Usuarios "
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function ValidaUsuario(ByVal user As String, ByVal pass As String) As DataTable
        CargarVariables()
        CargarVariablesDt()
        'sql = "SELECT * FROM Usuarios where usuario=@usuario and contrasenia=@contrasenia and activo=1"
        sql = "SELECT u.num, u.nombre, u.usuario, pe.permitido, pa.nombre as ventana " & _
        "FROM Usuarios u inner join Permisos pe on pe.num = u.num and pe.permitido = 1 " & _
        "inner join Pantallas pa on pa.pantalla = pe.pantalla and pa.nombre = 'CAJA' " & _
        "where u.usuario=@usuario and u.contrasenia=@contrasenia and u.activo=1"
        cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = user
        cmd.Parameters.Add("@contrasenia", SqlDbType.VarChar).Value = pass
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function ValidaPermisoC(ByVal user As String, ByVal pass As String) As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT u.num, u.nombre as usuario, u.usuario, pe.permitido, pe.nombre " & _
        "FROM Usuarios u inner join Permisos_Det pe on pe.num = u.num and pe.permitido = 1 " & _
        "inner join Pantallas pa on pa.pantalla = pe.pantalla and pa.nombre = 'CAJA' " & _
        "where u.usuario=@usuario and u.contrasenia=@contrasenia and u.activo=1"
        cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = user
        cmd.Parameters.Add("@contrasenia", SqlDbType.VarChar).Value = pass
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function DatosUsuario(ByVal NumUser As String) As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT u.num, u.nombre, u.usuario, u.contrasenia, pe.permitido, pa.nombre as ventana " & _
        "FROM Usuarios u inner join Permisos pe on pe.num = u.num and pe.permitido = 1 " & _
        "inner join Pantallas pa on pa.pantalla = pe.pantalla " & _
        "where u.num=@num and u.activo=1"
        cmd.Parameters.Add("@num", SqlDbType.VarChar).Value = NumUser
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function Pantallas() As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT pantalla, nombre FROM Pantallas "
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function AplicaCupon(id As Integer, Folio As Integer) As Boolean
        CargarVariables()
        sql = "SELECT Activo FROM cupones Where id = " & id & " AND Folio = " & Folio
        AccesoDatos()
        dr = cmd.ExecuteReader()
        ValorBool = False
        While dr.Read
            ValorBool = dr(0)
        End While
        LiberarVariables()
        Return ValorBool
    End Function

    Public Function ActualizaCupon(id As Integer, Folio As Integer, Nota As Integer, Sucursal As String) As Boolean
        Try
            CargarVariables()
            sql = ""
            sql = sql & "UPDATE cupones SET "
            sql = sql & "Nota = " & Nota & ", "
            sql = sql & "Sucursal = '" & Sucursal & "', "
            sql = sql & "Fecha = '" & Format(Date.Now, "dd/MM/yyyy") & "', "
            sql = sql & "Hora = '" & Format(Date.Now, "HH:mm") & "', "
            sql = sql & "Activo = 1 "
            sql = sql & "Where id = " & id & " AND Folio = " & Folio
            AccesoDatos()
            cmd.ExecuteNonQuery()
            LiberarVariables()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function VerificarCupon(ByVal id As Integer, ByVal Folio As Integer) As Double
        Dim MontoMin As Double
        CargarVariables()
        sql = "SELECT MontoMin FROM cupones Where id = " & id & " AND Folio = " & Folio
        AccesoDatos()
        dr = cmd.ExecuteReader()
        MontoMin = 0
        While dr.Read
            MontoMin = dr(0)
        End While
        LiberarVariables()
        Return MontoMin
    End Function
End Class
