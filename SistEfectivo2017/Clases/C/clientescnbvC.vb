Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class clientescnbvC
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet = Nothing
    Dim sql, where, strSet, str As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim dr As SqlDataReader = Nothing
    Dim abc As Integer = Nothing
    Dim lst As List(Of clientescnbvM)
    Dim dt As DataTable
    Dim disposed As Boolean = False
    Dim rs As SqlDataReader

    Public clientescnbvC()

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

    Private Sub CargarVariablesLstDt()
        da = New SqlDataAdapter
        lst = New List(Of clientescnbvM)
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
#End Region

    Public Function Aclientecnbv(ByVal data As clientescnbvM) As Integer
        CargarVariables()

        sql = "INSERT INTO clientescnbv(ID,Iniciales,Nombre,ApellidoPaterno,ApellidoMaterno,PaisNace,EstadoNace,CiudadResidencia," &
    "PaisResidencia,EstadoResidencia,Direccion,Calle,No_Interior,No_Exterior,EntreCalles, Colonia,Referencias, Municipio, Estado, Telfijo," &
    "Telcelular, Identificacion, email, CP, Rfc, Fecnac, Sexo, Nacionalidad, Empresa, CURP, actividadcomercial,identifica1,identifica2,app," &
    "Tarjeta,num_usu,nom_usu,fechar,horar,Nosucursal,nacionalizado,vencimiento_id,TarjetaActiva,limite,riesgo,fiel,firma)VALUES('" & data.ID & "'," &
    "'" & data.Iniciales & "','" & data.Nombre & "','" & data.ApellidoPaterno & "','" & data.ApellidoMaterno & "','" & data.PaisNace & "'," &
    "'" & data.EstadoNace & "','" & data.CiudadResidencia & "'," &
    "'" & data.PaisResidencia & "','" & data.EstadoResidencia & "','" & data.Direccion & "','" & data.Calle & "','" & data.No_Interior & "'," &
    "'" & data.No_Exterior & "','" & data.EntreCalles & "', '" & data.Colonia & "','" & data.Referencias & "', '" & data.Municipio & "'," &
    "'" & data.Estado & "', '" & data.Telfijo & "'," &
    "'" & data.Telcelular & "', '" & data.Identificacion & "', '" & data.email & "', '" & data.CP & "', '" & data.Rfc & "', '" & data.Fecnac & "', " &
    "" & CInt(data.Sexo) & ", '" & data.Nacionalidad & "', '" & data.Empresa & "', '" & data.CURP & "', '" & data.actividadcomercial & "'," &
    "'" & data.identifica1 & "','" & data.identifica2 & "'," & CInt(data.app) & ",'" & data.Tarjeta & "','" & data.num_usu & "','" & data.nom_usu & "'," &
    "'" & data.fechar & "','" & data.horar & "','" & data.Nosucursal & "','" & data.nacionalizado & "','" & data.VencID & "',0,2,'" & data.riesgo & "','" & data.fiel & "','" & data.firma & "')"

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Aclientecnbv2(ByVal data As clientescnbvM) As Integer
        CargarVariables()
        sql = "INSERT INTO clientescnbv(ID,Iniciales,Nombre,ApellidoPaterno,ApellidoMaterno,PaisNace,EstadoNace,CiudadResidencia," &
    "PaisResidencia,EstadoResidencia,Direccion,Calle,No_Interior,No_Exterior,EntreCalles, Colonia,Referencias, Municipio, Estado, Telfijo," &
    "Telcelular, Identificacion, email, CP, Rfc, Fecnac, Sexo, Nacionalidad, Empresa, CURP, actividadcomercial,identifica1,identifica2,app," &
    "Tarjeta,num_usu,nom_usu,fechar,horar)VALUES(0,'" & data.Iniciales & "','" & data.Nombre & "','" & data.ApellidoPaterno & "','" &
    data.ApellidoMaterno & "','" & data.PaisNace & "','" & data.EstadoNace & "','" & data.CiudadResidencia & "'," &
    "'" & data.PaisResidencia & "','" & data.EstadoResidencia & "','" & data.Direccion & "','" & data.Calle & "','" & data.No_Interior &
    "','" & data.No_Exterior & "','" & data.EntreCalles & "', '" & data.Colonia & "','" & data.Referencias & "', '" & data.Municipio &
    "', '" & data.Estado & "', '" & data.Telfijo & "'," & "'" & data.Telcelular & "', '" & data.Identificacion & "', '" &
    data.email & "', '" & data.CP & "','" & data.Rfc & "', '" & data.Fecnac.ToString("dd/MM/yyyy") & "', " & data.Sexo & ", '" & data.Nacionalidad &
    "', '" & data.Empresa & "', '" & data.CURP & "', '" & data.actividadcomercial & "'," &
    "'" & data.identifica1 & "','" & data.identifica2 & "'," & data.app & ",'" & data.Tarjeta & "','" &
    data.num_usu & "','" & data.nom_usu & "','" & data.fechar.ToString("dd/MM/yyyy") & "','" & data.horar & "')"

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Eclientecnbv(ByVal data As clientescnbvM) As Integer
        CargarVariables()
        sql = "DELETE FROM clientescnbv WHERE cliente=@cliente"
        cmd.Parameters.Add("@cliente", SqlDbType.Int)
        cmd.Parameters("@cliente").Value = data.cliente
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Mclientecnbv(ByVal data As clientescnbvM, ByVal oclientescnbvM As clientescnbvM) As Integer
        CargarVariables()
        sql = "update clientescnbv set "
        If data.Iniciales <> oclientescnbvM.Iniciales And data.Iniciales <> Nothing Then
            strSet += "Iniciales=@Iniciales,"
            cmd.Parameters.AddWithValue("@Iniciales", SqlDbType.NVarChar).Value = data.Iniciales
        End If
        If data.Nombre <> oclientescnbvM.Nombre And data.Nombre <> Nothing Then
            strSet += "Nombre=@Nombre,"
            cmd.Parameters.AddWithValue("@Nombre", SqlDbType.NVarChar).Value = data.Nombre
        End If
        If data.ApellidoPaterno <> oclientescnbvM.ApellidoPaterno Then
            strSet += "ApellidoPaterno=@ApellidoPaterno,"
            cmd.Parameters.AddWithValue("@ApellidoPaterno", SqlDbType.NVarChar).Value = data.ApellidoPaterno
            If data.ApellidoPaterno = Nothing Then
                MessageBox.Show("HA DEJADO VACÍO EL APELLIDO PATERNO")
            End If
        End If
        If data.ApellidoMaterno <> oclientescnbvM.ApellidoMaterno Then
            strSet += "ApellidoMaterno=@ApellidoMaterno,"
            cmd.Parameters.AddWithValue("@ApellidoMaterno", SqlDbType.NVarChar).Value = data.ApellidoMaterno
            If data.ApellidoMaterno = Nothing Then
                MessageBox.Show("HA DEJADO VACÍO EL APELLIDO MATERNO")
            End If
        End If
        If data.PaisNace <> oclientescnbvM.PaisNace And data.PaisNace <> Nothing Then
            strSet += "PaisNace=@PaisNace,"
            cmd.Parameters.AddWithValue("@PaisNace", SqlDbType.NVarChar).Value = data.PaisNace
        End If
        If data.EstadoNace <> oclientescnbvM.EstadoNace And data.EstadoNace <> Nothing Then
            strSet += "EstadoNace=@EstadoNace,"
            cmd.Parameters.AddWithValue("@EstadoNace", SqlDbType.NVarChar).Value = data.EstadoNace
        End If
        If data.CiudadResidencia <> oclientescnbvM.CiudadResidencia And data.CiudadResidencia <> Nothing Then
            strSet += "CiudadResidencia=@CiudadResidencia,"
            cmd.Parameters.AddWithValue("@CiudadResidencia", SqlDbType.NVarChar).Value = data.CiudadResidencia
        End If
        If data.PaisResidencia <> oclientescnbvM.PaisResidencia And data.PaisResidencia <> Nothing Then
            strSet += "PaisResidencia=@PaisResidencia,"
            cmd.Parameters.AddWithValue("@PaisResidencia", SqlDbType.NVarChar).Value = data.PaisResidencia
        End If
        If data.EstadoResidencia <> oclientescnbvM.EstadoResidencia And data.EstadoResidencia <> Nothing Then
            strSet += "EstadoResidencia=@EstadoResidencia,"
            cmd.Parameters.AddWithValue("@EstadoResidencia", SqlDbType.NVarChar).Value = data.EstadoResidencia
        End If
        If data.Direccion <> oclientescnbvM.Direccion And data.Direccion <> Nothing Then
            strSet += "Direccion=@Direccion,"
            cmd.Parameters.AddWithValue("@Direccion", SqlDbType.NVarChar).Value = data.Direccion
        End If
        If data.Calle <> oclientescnbvM.Calle And data.Calle <> Nothing Then
            strSet += "Calle=@Calle,"
            cmd.Parameters.AddWithValue("@Calle", SqlDbType.NVarChar).Value = data.Calle
        End If
        If data.No_Interior <> oclientescnbvM.No_Interior And data.No_Interior <> Nothing Then
            strSet += "No_Interior=@No_Interior,"
            cmd.Parameters.AddWithValue("@No_Interior", SqlDbType.NVarChar).Value = data.No_Interior
        End If
        If data.No_Exterior <> oclientescnbvM.No_Exterior And data.No_Exterior <> Nothing Then
            strSet += "No_Exterior=@No_Exterior,"
            cmd.Parameters.AddWithValue("@No_Exterior", SqlDbType.NVarChar).Value = data.No_Exterior
        End If
        If data.EntreCalles <> oclientescnbvM.EntreCalles And data.EntreCalles <> Nothing Then
            strSet += "EntreCalles=@EntreCalles,"
            cmd.Parameters.AddWithValue("@EntreCalles", SqlDbType.NVarChar).Value = data.EntreCalles
        End If
        If data.Colonia <> oclientescnbvM.Colonia And data.Colonia <> Nothing Then
            strSet += "Colonia=@Colonia,"
            cmd.Parameters.AddWithValue("@Colonia", SqlDbType.NVarChar).Value = data.Colonia
        End If
        If data.Referencias <> oclientescnbvM.Referencias And data.Referencias <> Nothing Then
            strSet += "Referencias=@Referencias,"
            cmd.Parameters.AddWithValue("@Referencias", SqlDbType.NVarChar).Value = data.Referencias
        End If
        If data.Municipio <> oclientescnbvM.Municipio And data.Municipio <> Nothing Then
            strSet += "Municipio=@Municipio,"
            cmd.Parameters.AddWithValue("@Municipio", SqlDbType.NVarChar).Value = data.Municipio
        End If
        If data.Estado <> oclientescnbvM.Estado And data.Estado <> Nothing Then
            strSet += "Estado=@Estado,"
            cmd.Parameters.AddWithValue("@Estado", SqlDbType.NVarChar).Value = data.Estado
        End If
        If data.Telfijo <> oclientescnbvM.Telfijo And data.Telfijo <> Nothing Then
            strSet += "Telfijo=@Telfijo,"
            cmd.Parameters.AddWithValue("@Telfijo", SqlDbType.NVarChar).Value = data.Telfijo
        End If
        If data.Telcelular <> oclientescnbvM.Telcelular And data.Telcelular <> Nothing Then
            strSet += "Telcelular=@Telcelular,"
            cmd.Parameters.AddWithValue("@Telcelular", SqlDbType.NVarChar).Value = data.Telcelular
        End If
        If data.Identificacion <> oclientescnbvM.Identificacion And data.Identificacion <> Nothing Then
            strSet += "Identificacion=@Identificacion,"
            cmd.Parameters.AddWithValue("@Identificacion", SqlDbType.NVarChar).Value = data.Identificacion
        End If
        If data.email <> oclientescnbvM.email And data.email <> Nothing Then
            strSet += "email=@email,"
            cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = data.email
        End If
        If data.CP <> oclientescnbvM.CP And data.CP <> Nothing Then
            strSet += "CP=@CP,"
            cmd.Parameters.AddWithValue("@CP", SqlDbType.NVarChar).Value = data.CP
        End If
        If data.Rfc <> oclientescnbvM.Rfc And data.Rfc <> Nothing Then
            strSet += "Rfc=@Rfc,"
            cmd.Parameters.AddWithValue("@Rfc", SqlDbType.NVarChar).Value = data.Rfc
        End If
        If data.Fecnac <> oclientescnbvM.Fecnac And data.Fecnac <> Nothing Then
            strSet += "Fecnac=@Fecnac,"
            cmd.Parameters.AddWithValue("@Fecnac", SqlDbType.SmallDateTime).Value = data.Fecnac
        End If
        If data.Sexo <> oclientescnbvM.Sexo And data.Sexo >= 0 Then
            strSet += "Sexo=@Sexo,"
            cmd.Parameters.AddWithValue("@Sexo", SqlDbType.NVarChar).Value = data.Sexo
        End If
        If data.Nacionalidad <> oclientescnbvM.Nacionalidad And data.Nacionalidad <> Nothing Then
            strSet += "Nacionalidad=@Nacionalidad,"
            cmd.Parameters.AddWithValue("@Nacionalidad", SqlDbType.NVarChar).Value = data.Nacionalidad
        End If
        If data.Empresa <> oclientescnbvM.Empresa And data.Empresa <> Nothing Then
            strSet += "Empresa=@Empresa,"
            cmd.Parameters.AddWithValue("@Empresa", SqlDbType.NVarChar).Value = data.Empresa
        End If
        If data.CURP <> oclientescnbvM.CURP And data.CURP <> Nothing Then
            strSet += "CURP=@CURP,"
            cmd.Parameters.AddWithValue("@CURP", SqlDbType.NVarChar).Value = data.CURP
        End If
        If data.fiel <> oclientescnbvM.fiel And data.fiel <> Nothing Then
            strSet += "fiel=@fiel,"
            cmd.Parameters.AddWithValue("@fiel", SqlDbType.NVarChar).Value = data.fiel
        End If
        If data.actividadcomercial <> oclientescnbvM.actividadcomercial And data.actividadcomercial <> Nothing Then
            strSet += "actividadcomercial=@actividadcomercial,"
            cmd.Parameters.AddWithValue("@actividadcomercial", SqlDbType.NVarChar).Value = data.actividadcomercial
        End If
        If data.identifica1 <> oclientescnbvM.identifica1 And data.identifica1 <> Nothing Then
            strSet += "identifica1=@identifica1,"
            cmd.Parameters.AddWithValue("@identifica1", SqlDbType.NVarChar).Value = data.identifica1
        End If
        If data.identifica2 <> oclientescnbvM.identifica2 And data.identifica2 <> Nothing Then
            strSet += "identifica2=@identifica2,"
            cmd.Parameters.AddWithValue("@identifica2", SqlDbType.NVarChar).Value = data.identifica2
        End If
        If data.firma <> oclientescnbvM.firma And data.firma <> Nothing Then
            strSet += "firma=@firma,"
            cmd.Parameters.AddWithValue("@firma", SqlDbType.NVarChar).Value = data.firma
        End If
        If data.app <> oclientescnbvM.app And data.app <> Nothing Or (data.app < oclientescnbvM.app Or data.app > oclientescnbvM.app) Then
            strSet += "app=@app,"
            cmd.Parameters.AddWithValue("@app", SqlDbType.SmallInt).Value = data.app
        End If
        If data.Tarjeta <> oclientescnbvM.Tarjeta And data.Tarjeta <> Nothing Or (data.Tarjeta = "") Then
            strSet += "Tarjeta=@Tarjeta,"
            cmd.Parameters.AddWithValue("@Tarjeta", SqlDbType.NVarChar).Value = data.Tarjeta
        End If
        If data.nacionalizado <> oclientescnbvM.nacionalizado And data.nacionalizado <> Nothing Then
            strSet += "nacionalizado=@nacionalizado,"
            cmd.Parameters.AddWithValue("@nacionalizado", SqlDbType.NVarChar).Value = data.nacionalizado
        End If

        strSet += "vencimiento_id=@Vencimiento,"
        cmd.Parameters.AddWithValue("@Vencimiento", SqlDbType.SmallDateTime).Value = data.VencID

        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If
        strSet += " where cliente=@cliente2"
        cmd.Parameters.AddWithValue("@cliente2", SqlDbType.Int).Value = oclientescnbvM.cliente
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Mimagen(ByVal cliente As Integer, ByVal A As String, ByVal B As String) As Integer
        CargarVariables()
        sql = "update clientescnbv set "
        If A IsNot Nothing Or A <> "" Then
            strSet += "identifica1=@identifica1,"
            cmd.Parameters.Add("@identifica1", SqlDbType.NVarChar).Value = A
        End If

        If B IsNot Nothing Or B <> "" Then
            strSet += "identifica2=@identifica2,"
            cmd.Parameters.AddWithValue("@identifica2", SqlDbType.NVarChar).Value = B
        End If
        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += " where id=@cliente;"
        cmd.Parameters.AddWithValue("@cliente", SqlDbType.Int).Value = cliente
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Mifirma(ByVal cliente As Integer, ByVal A As String) As Integer
        CargarVariables()
        sql = "update clientescnbv set "
        If A IsNot Nothing Or A <> "" Then
            strSet += "firma=@firma,"
            cmd.Parameters.AddWithValue("@firma", SqlDbType.NVarChar).Value = A
        End If

        If A IsNot Nothing Or A <> "" Then
            strSet += "fechaFirma=GETDATE()+180,"
        End If

        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += " where cliente=@cliente;"
        cmd.Parameters.AddWithValue("@cliente", SqlDbType.Int).Value = cliente
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function MiDocumet(ByVal cliente As Integer, ByVal A As String, ByVal B As String, ByVal VencID As Date) As Integer
        CargarVariables()
        sql = "update clientescnbv set "
        If B = "CD" And (A IsNot Nothing Or A <> "") Then
            strSet += "comprobante=@identifica1, vigencia_compro=@vigencia"
            cmd.Parameters.AddWithValue("@identifica1", SqlDbType.NVarChar).Value = A
            cmd.Parameters.AddWithValue("@vigencia", SqlDbType.SmallDateTime).Value = Format(VencID, "mm/dd/yyyy")
        ElseIf B = "C1" And (A IsNot Nothing Or A <> "") Then
            strSet += "cuestionario1=@identifica1, vigencia_cuest1=@vigencia"
            cmd.Parameters.AddWithValue("@identifica1", SqlDbType.NVarChar).Value = A
            cmd.Parameters.AddWithValue("@vigencia", SqlDbType.SmallDateTime).Value = Format(VencID, "mm/dd/yyyy")
        ElseIf B = "C2" And (A IsNot Nothing Or A <> "") Then
            strSet += "cuestionario2=@identifica1, vigencia_cuest2=@vigencia"
            cmd.Parameters.AddWithValue("@identifica1", SqlDbType.NVarChar).Value = A
            cmd.Parameters.AddWithValue("@vigencia", SqlDbType.SmallDateTime).Value = Format(VencID, "mm/dd/yyyy")
        End If

        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += " where cliente=@cliente;"
        cmd.Parameters.AddWithValue("@cliente", SqlDbType.Int).Value = cliente
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Private Sub maswhere(ByVal data As clientescnbvM, ByVal a As String, ByVal b As String, ByVal likeoigual As Boolean)
        Dim operador As String = ""
        Select Case likeoigual
            Case True
                operador = " like "
            Case False
                operador = "="
        End Select
        If data.cliente > 0 Then
            where = where & "cliente=@cliente and"
            cmd.Parameters.AddWithValue("@cliente", SqlDbType.Int).Value = data.cliente
        End If
        If Not data.Nombre Is Nothing Then
            where = where & " Nombre" & operador & " '" & b & "'+@Nombre+'" & a & "' and"
            cmd.Parameters.AddWithValue("@Nombre", SqlDbType.NVarChar).Value = data.Nombre

        End If
        If Not data.ApellidoPaterno Is Nothing Then
            where = where & " ApellidoPaterno" & operador & " '" & b & "'+@ApellidoPaterno+'" & a & "' and"
            cmd.Parameters.AddWithValue("@ApellidoPaterno", SqlDbType.NVarChar).Value = data.ApellidoPaterno
        End If
        where = where & " ISNULL(PPE,0)=0 and"
        If where.Trim.Length > 0 Then
            where = " WHERE " & where.Remove(where.Length - 3, 3)
        End If
        where += " order by ApellidoPaterno,Nombre;"
    End Sub

    Private Sub maswhereBCS(ByVal data As clientescnbvM, ByVal a As String, ByVal b As String, ByVal likeoigual As Boolean)
        Dim operador As String = ""
        Select Case likeoigual
            Case True
                operador = " like "
            Case False
                operador = "="
        End Select
        If data.cliente > 0 Then
            where = where & "cliente=@cliente and"
            cmd.Parameters.AddWithValue("@cliente", SqlDbType.Int).Value = data.cliente
        End If
        If Not data.Nombre Is Nothing Then
            where = where & " Nombre" & operador & " '" & b & "'+@Nombre+'" & a & "' and"
            cmd.Parameters.AddWithValue("@Nombre", SqlDbType.NVarChar).Value = data.Nombre

        End If
        If Not data.ApellidoPaterno Is Nothing Then
            where = where & " ApellidoPaterno" & operador & " '" & b & "'+@ApellidoPaterno+'" & a & "' and"
            cmd.Parameters.AddWithValue("@ApellidoPaterno", SqlDbType.NVarChar).Value = data.ApellidoPaterno
        End If

        If where.Trim.Length > 0 Then
            where = " WHERE " & where.Remove(where.Length - 3, 3)
        End If
        where += " order by ApellidoPaterno,Nombre;"
    End Sub

    Public Function Sclientecnbv(ByVal data As clientescnbvM) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, "", "", False)
        sql = "SELECT * FROM clientescnbv "
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Selecciona4(ByVal id As Integer) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   cliente, "
        sql = sql & "   Nombre, "
        sql = sql & "   ApellidoPaterno, "
        sql = sql & "   ApellidoMaterno, "
        sql = sql & "   identifica1, "
        sql = sql & "   identifica2, "
        sql = sql & "   vencimiento_id, "
        sql = sql & "   Tarjeta, "
        sql = sql & "   comprobante, "
        sql = sql & "   riesgo, "
        sql = sql & "   vigencia_compro, "
        sql = sql & "   vigencia_cuest1, "
        sql = sql & "   vigencia_cuest2, "
        sql = sql & "   vigencia_format4, "
        sql = sql & "   vigencia_format5, "
        sql = sql & "   CURP, "
        sql = sql & "   Rfc, "
        sql = sql & "   email, "
        sql = sql & "   firma, "
        sql = sql & "   Telfijo, "
        sql = sql & "   Telcelular, "
        sql = sql & "   documentoCURP, "
        sql = sql & "   documentoRFC, "
        sql = sql & "   nacionalizado, "
        sql = sql & "   PaisNace, "
        sql = sql & "   PaisResidencia, "
        sql = sql & "   EstadoResidencia, "
        sql = sql & "   actividadcomercial, "
        sql = sql & "   Calle, "
        sql = sql & "   Fecha_Envio_P "
        sql = sql & "FROM "
        sql = sql & "   clientescnbv "
        sql = sql & "where "
        sql = sql & "   cliente = " & id
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Sclientecnbv2(ByVal data As clientescnbvM) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, "", "", False)
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   cliente, "
        sql = sql & "   ApellidoPaterno, "
        sql = sql & "   ApellidoMaterno, "
        sql = sql & "   Nombre, "
        sql = sql & "   Direccion, "
        sql = sql & "   ('C '+ Calle +' No '+ No_exterior +' '+ EntreCalles + ' '+ Colonia) as Direccion, "
        sql = sql & "   Municipio, "
        sql = sql & "   Estado, "
        sql = sql & "   Identificacion "
        sql = sql & "FROM "
        sql = sql & "   clientescnbv "
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Fclientecnbv(ByVal data As clientescnbvM, ByVal a As String, ByVal b As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, a, b, True)
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   cliente, "
        sql = sql & "   ApellidoPaterno, "
        sql = sql & "   ApellidoMaterno, "
        sql = sql & "   Nombre, "
        sql = sql & "   Direccion, "
        sql = sql & "   ('C '+ Calle +' No '+ No_exterior +' '+ EntreCalles + ' '+ Colonia) as Direccion, "
        sql = sql & "   Colonia, "
        sql = sql & "   Municipio, "
        sql = sql & "   Estado, "
        sql = sql & "   Identificacion "
        sql = sql & "FROM "
        sql = sql & "   clientescnbv "
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function FclientecnbvOno(ByVal data As clientescnbvM, ByVal a As String, ByVal b As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, a, b, True)
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   cliente, "
        sql = sql & "   ApellidoPaterno, "
        sql = sql & "   ApellidoMaterno, "
        sql = sql & "   Nombre, "
        sql = sql & "   Direccion, "
        sql = sql & "   ('C '+ Calle +' No '+ No_exterior +' '+ EntreCalles + ' '+ Colonia) as Direccion, "
        sql = sql & "   Colonia, "
        sql = sql & "   Municipio, "
        sql = sql & "   Estado, "
        sql = sql & "   Identificacion, "
        sql = sql & "   identifica1, "
        sql = sql & "   identifica2, "
        sql = sql & "   PPE "
        sql = sql & "FROM "
        sql = sql & "   clientescnbv "
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function FclientecnbvBCS(ByVal data As clientescnbvM, ByVal a As String, ByVal b As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhereBCS(data, a, b, True)
        sql = "SELECT cliente,ApellidoPaterno,ApellidoMaterno,Nombre," &
            "Direccion,('C '+ Calle +' No '+ No_exterior +' '+ EntreCalles + ' '+ Colonia) as Direccion,Colonia, Municipio, Estado," &
            "Identificacion, identifica1, identifica2, PPE FROM clientescnbv " &
            "union all " &
            "SELECT Num as cliente,ApellidoPaterno,ApellidoMaterno,Nombres as Nombre, " &
            "'' as Direccion,'' as Direccion " &
            ",'' as Colonia, '' as Municipio, '' as Estado," &
            "'' as Identificacion, '' as identifica1, '' as identifica2, '1' as PPE " &
            "FROM PersonasPoliticasE " &
            "union all " &
            "SELECT Num as cliente,ApellidoPaterno,ApellidoMaterno,Nombres as Nombre, " &
            "'' as Direccion,'' as Direccion " &
            ",'' as Colonia, '' as Municipio, '' as Estado," &
            "'' as Identificacion, '' as identifica1, '' as identifica2, '1' as PPE " &
            "FROM PersonasPoliticasEEx " &
            "union all " &
            "SELECT id as cliente,ApellidoPaterno,ApellidoMaterno,Nombre, " &
            "'' as Direccion,'' as Direccion " &
            ",'' as Colonia, '' as Municipio, '' as Estado, " &
            "'' as Identificacion, '' as identifica1, '' as identifica2, '1' as PPE  " &
            "FROM OFAC " &
            "union all " &
            "SELECT Num as cliente,ApellidoPaterno,ApellidoMaterno,Nombres, " &
            "'' as Direccion,'' as Direccion " &
            ",'' as Colonia, '' as Municipio, '' as Estado, " &
            "'' as Identificacion, '' as identifica1, '' as identifica2, '1' as PPE  " &
            "FROM PersonasBloqueadasFisicas"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Uclientecnbv() As Integer
        CargarVariables()
        sql = "SELECT MAX(cliente)+1 FROM clientescnbv"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function Uclientecnbv2() As Integer
        CargarVariables()
        sql = "SELECT MAX(cliente) FROM clientescnbv"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function chequeopais(ByVal pais As String) As Integer
        CargarVariables()
        sql = "SELECT COUNT(*) FROM paises WHERE pais = '" & pais & "'"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function chequeoEstado(ByVal estado As String) As Integer
        CargarVariables()
        sql = "SELECT COUNT(*) FROM estados WHERE estado = '" & estado & "'"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function chequeoActividad(ByVal actividad As String) As Integer
        CargarVariables()
        sql = "SELECT COUNT(*) FROM actividades WHERE nombre = '" & actividad & "'"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function clientecnbvTarjeta(ByVal TarjetaCli As String) As Integer
        CargarVariables()
        sql = "SELECT ISNULL(MAX(cliente),0) as cliente FROM clientescnbv where Tarjeta = '" & TarjetaCli & "'"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

#Region "comentar"



#End Region

#Region "ParaAntiguoPruebas"
    Public Function S1clientescnbv(ByVal oclientescnbvM As clientescnbvM) As clientescnbvM
        CargarVariables()
        maswhere(oclientescnbvM, "", "", False)
        sql = "SELECT * FROM clientescnbv "
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            oclientescnbvM.cliente = dr.GetInt32(0)
            If Not dr.IsDBNull(1) Then
                oclientescnbvM.ID = dr.GetInt32(1)
            End If

            If Not dr.IsDBNull(2) Then
                oclientescnbvM.Iniciales = dr.GetString(2)
            End If
            If Not dr.IsDBNull(3) Then
                oclientescnbvM.Nombre = dr.GetString(3)
            End If

            If Not dr.IsDBNull(4) Then
                oclientescnbvM.ApellidoPaterno = dr.GetString(4)
            End If

            If Not dr.IsDBNull(5) Then
                oclientescnbvM.ApellidoMaterno = dr.GetString(5)
            End If

            If Not dr.IsDBNull(6) Then
                oclientescnbvM.PaisNace = dr.GetString(6)
            End If

            If Not dr.IsDBNull(7) Then
                oclientescnbvM.EstadoNace = dr.GetString(7)
            End If

            If Not dr.IsDBNull(8) Then
                oclientescnbvM.CiudadResidencia = dr.GetString(8)
            End If

            If Not dr.IsDBNull(9) Then
                oclientescnbvM.PaisResidencia = dr.GetString(9)
            End If

            If Not dr.IsDBNull(10) Then
                oclientescnbvM.EstadoResidencia = dr.GetString(10)
            End If

            If Not dr.IsDBNull(11) Then
                oclientescnbvM.Direccion = dr.GetString(11)
            End If

            If Not dr.IsDBNull(12) Then
                oclientescnbvM.Calle = dr.GetString(12)
            End If

            If Not dr.IsDBNull(13) Then
                oclientescnbvM.No_Interior = dr.GetString(13)
            End If

            If Not dr.IsDBNull(14) Then
                oclientescnbvM.No_Exterior = dr.GetString(14)
            End If

            If Not dr.IsDBNull(15) Then
                oclientescnbvM.EntreCalles = dr.GetString(15)
            End If

            If Not dr.IsDBNull(16) Then
                oclientescnbvM.Colonia = dr.GetString(16)
            End If

            If Not dr.IsDBNull(17) Then
                oclientescnbvM.Referencias = dr.GetString(17)
            End If

            If Not dr.IsDBNull(18) Then
                oclientescnbvM.Municipio = dr.GetString(18)
            End If
            If Not dr.IsDBNull(19) Then
                oclientescnbvM.Estado = dr.GetString(19)
            End If
            If Not dr.IsDBNull(20) Then
                oclientescnbvM.Telfijo = dr.GetString(20)
            End If

            If Not dr.IsDBNull(21) Then
                oclientescnbvM.Telcelular = dr.GetString(21)
            End If

            If Not dr.IsDBNull(22) Then
                oclientescnbvM.Identificacion = dr.GetString(22)
            End If

            If Not dr.IsDBNull(23) Then
                oclientescnbvM.email = dr.GetString(23)
            End If

            If Not dr.IsDBNull(24) Then
                oclientescnbvM.CP = dr.GetString(24)
            End If

            If Not dr.IsDBNull(25) Then
                oclientescnbvM.Rfc = dr.GetString(25)
            End If

            If Not dr.IsDBNull(26) Then
                oclientescnbvM.Fecnac = dr.GetDateTime(26)
            End If

            If Not dr.IsDBNull(27) Then
                oclientescnbvM.Sexo = dr.GetInt16(27)
            End If

            If Not dr.IsDBNull(28) Then
                oclientescnbvM.Nacionalidad = dr.GetString(28)
            End If

            If Not dr.IsDBNull(29) Then
                oclientescnbvM.Empresa = dr.GetString(29)
            End If

            If Not dr.IsDBNull(30) Then
                oclientescnbvM.CURP = dr.GetString(30)
            End If

            If Not dr.IsDBNull(31) Then
                oclientescnbvM.actividadcomercial = dr.GetString(31)
            End If

            If Not dr.IsDBNull(32) Then
                oclientescnbvM.identifica1 = dr.GetString(32)
            End If

            If Not dr.IsDBNull(33) Then
                oclientescnbvM.identifica2 = dr.GetString(33)
            End If

            If Not dr.IsDBNull(34) Then
                oclientescnbvM.app = dr.GetInt16(34)
            End If

            If Not dr.IsDBNull(35) Then
                oclientescnbvM.Tarjeta = dr.GetString(35)
            End If

            If Not dr.IsDBNull(41) Then
                oclientescnbvM.nacionalizado = dr.GetString(41)
            End If

            If Not dr.IsDBNull(43) Then
                oclientescnbvM.VencID = dr.GetDateTime(43)
            Else
                oclientescnbvM.VencID = "31/12/" & Date.Now.Year
            End If

            If Not dr.IsDBNull(51) Then
                oclientescnbvM.Autorizado = dr.GetInt16(51)
            End If

            If Not dr.IsDBNull(57) Then
                oclientescnbvM.riesgo = dr.GetString(57)
            End If

            If Not dr.IsDBNull(58) Then
                oclientescnbvM.fiel = dr.GetString(58)
            End If

            If Not dr.IsDBNull(65) Then
                oclientescnbvM.firma = dr.GetString(65)
            End If

            If Not dr.IsDBNull(68) Then
                'MsgBox(Format(dr.GetDateTime(68), "dd/MM/yyyy"), vbInformation)
                oclientescnbvM.fechaenvp = Format(dr.GetDateTime(68), "dd/MM/yyyy")
            End If

            Exit While
        End While
        dr.Close()
        LiberarVariables()
        Return oclientescnbvM
    End Function
#End Region

    Public Function Filtrar(ByVal data As clientescnbvM, ByVal a As String, ByVal b As String) As DataTable
        CargarVariables()
        CargarVariablesLstDt()
        maswhere(data, a, b, True)
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   cliente, "
        sql = sql & "   ApellidoPaterno, "
        sql = sql & "   ApellidoMaterno, "
        sql = sql & "   Nombre, "
        sql = sql & "   Direccion, "
        sql = sql & "   ('C '+Calle +' No '+ No_exterior +' X '+ EntreCalles +' Int:'+ No_Interior +' Col. '+ Colonia) as Direccion, "
        sql = sql & "   Municipio, "
        sql = sql & "   Estado, "
        sql = sql & "   Identificacion, "
        sql = sql & "   vencimiento_id, "
        sql = sql & "   Tarjeta, "
        sql = sql & "   Fecha_Envio_P "
        sql = sql & "FROM "
        sql = sql & "   clientescnbv "
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function UInformclientecnbv(ByVal cliente As Integer) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = ""
        sql = sql & "select * "
        sql = sql & "from "
        sql = sql & "   remisioM "
        sql = sql & "where "
        sql = sql & "   cliente=" & cliente & " and "
        sql = sql & "   fecha=(select MAX(fecha) from remisioM where cliente=" & cliente & ")"
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return ds
    End Function

    Public Function Imagen(ByVal cliente As Integer) As DataTable
        CargarVariables()
        CargarVariablesLstDt()
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   cliente, "
        sql = sql & "   identifica1, "
        sql = sql & "   identifica2 "
        sql = sql & "FROM "
        sql = sql & "   clientescnbv "
        sql = sql & "where "
        sql = sql & "   cliente=" & cliente & ";"
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function RptClientesDia(ByVal fecha1 As Date, ByVal fecha2 As String, ByVal Nosucursal As String) As DataSet
        Dim oLstClientes As LstClientes = New LstClientes()
        CargarVariables()
        da = New SqlDataAdapter
        sql = ""
        sql = sql & "SELECT "
        sql = sql & "   cliente, "
        sql = sql & "   Nombre, "
        sql = sql & "   ISNULL(ApellidoPaterno,'SIN') as ApellidoPaterno, "
        sql = sql & "   ISNULL(ApellidoMaterno,'SIN') as ApellidoMaterno, "
        sql = sql & "   ISNULL(Identificacion,'SIN') as Identificacion, "
        sql = sql & "   ISNULL(Direccion,'SIN') as Direccion, "
        sql = sql & "   Calle, "
        sql = sql & "   No_exterior, "
        sql = sql & "   EntreCalles, "
        sql = sql & "   Colonia, "
        sql = sql & "   Nosucursal, "
        sql = sql & "   nom_usu, "
        sql = sql & "   fechar, "
        sql = sql & "   horar "
        sql = sql & "FROM "
        sql = sql & "   clientescnbv "
        sql = sql & "where "
        sql = sql & "   Nosucursal='" & Nosucursal & "' "
        Select Case fecha2 Is Nothing
            Case False
                sql += "and fechar between '" & fecha1.ToString("dd/MM/yyyy") & "' and '" & fecha2 & "';"
            Case True
                sql += "and fechar='" & fecha1.ToString("dd/MM/yyyy") & "';"
        End Select

        cmd = New SqlCommand(sql, con.EstablecerConexion())
        da.SelectCommand = cmd
        da.Fill(oLstClientes, "clientescnbv")

        LiberarVariables()
        Return oLstClientes
    End Function

    Public Function RptClientesDia2(ByVal fecha1 As Date, ByVal fecha2 As String, ByVal Nosucursal As String) As Integer
        CargarVariables()
        sql = "SELECT COUNT(cliente) as cliente FROM clientescnbv " &
            "where Nosucursal='" & Nosucursal & "' "
        Select Case fecha2 Is Nothing
            Case False
                sql += "and fechar between '" & fecha1.ToString("dd/MM/yyyy") & "' and '" & fecha2 & "';"
            Case True
                sql += "and fechar='" & fecha1.ToString("dd/MM/yyyy") & "';"
        End Select
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function ValidaRepetido(ByVal ApellidoPaterno As String, ByVal Nombre As String, ByVal NOMBRE2 As String, ByVal ApellidoMaterno As String) As DataSet
        CargarVariables()
        CargarVariablesLstDt()

        sql = "SELECT cliente,ApellidoPaterno,ApellidoMaterno,Nombre, 'CLIENTE EXISTENTES' as Mensaje from clientescnbv where "
        sql += "ApellidoPaterno = '" & ApellidoPaterno & "' and "
        sql += "ApellidoMaterno = '" & ApellidoMaterno & "' and "
        sql += " Nombre = '" & Nombre & "'"

        sql += " UNION SELECT Num,ApellidoPaterno,ApellidoMaterno,Nombres, 'PERSONAS POLITICAMENTE EXPUESTAS' as Mensaje from PersonasPoliticasE where "
        sql += "ApellidoPaterno = '" & ApellidoPaterno & "' and "
        sql += "ApellidoMaterno = '" & ApellidoMaterno & "' and "
        sql += " Nombres = '" & Nombre & "'"

        sql += " UNION SELECT Num,ApellidoPaterno,ApellidoMaterno,Nombres, 'PERSONAS POLITICAMENTE EXPUESTAS EXTRANJERA' as Mensaje from PersonasPoliticasEEx where "
        sql += "ApellidoPaterno = '" & ApellidoPaterno & "' and "
        sql += "ApellidoMaterno = '" & ApellidoMaterno & "' and "
        sql += " Nombres = '" & Nombre & "'"

        sql += " UNION SELECT id,ApellidoPaterno,ApellidoMaterno,Nombre, 'LISTADO OFAC' as Mensaje from OFAC where "
        sql += "ApellidoPaterno = '" & ApellidoPaterno & "' and "
        sql += "ApellidoMaterno = '" & ApellidoMaterno & "' and "
        sql += " Nombre = '" & Nombre & "'"

        sql += " UNION SELECT Num,ApellidoPaterno,ApellidoMaterno,Nombres, 'PERSONAS BLOQUEADAS FISICAS' as Mensaje from PersonasBloqueadasFisicas where "
        sql += "ApellidoPaterno = '" & ApellidoPaterno & "' and "
        sql += "ApellidoMaterno = '" & ApellidoMaterno & "' and "
        sql += " Nombres = '" & Nombre & "'"

        AccesoDatos()
        RecopilarDatos()
        'RecopilarDatosDt()
        LiberarVariables()
        Return ds
    End Function

    Public Function clientesDuplicados1() As DataSet
        Dim orptDuplicados As rptDuplicados = New rptDuplicados()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT distinct(apellidoPaterno) as ApellidoPaterno,nombre,ApellidoMaterno, count(*) AS REPETIDO " &
        "FROM clientescnbv GROUP BY apellidoPaterno,nombre,ApellidoMaterno HAVING count(*) > 1"
        sql = "DECLARE  @Apellido varchar(80),@Nombre varchar(80),@ApellidoM varchar(80), " &
        "	@cliente int,@clientes varchar(200), @cli varchar(50);  " &
        " " &
        "CREATE TABLE #TempCliente (Cliente int) " &
        " " &
        "DECLARE vendor_cursor CURSOR FOR   " &
        "SELECT distinct(apellidoPaterno) as ApellidoPaterno,nombre,ApellidoMaterno " &
        "FROM clientescnbv WHERE ISNULL(PPE,0) <> 1 GROUP BY apellidoPaterno,nombre,ApellidoMaterno HAVING count(*) > 1 ;  " &
        " " &
        "OPEN vendor_cursor  " &
        " " &
        "FETCH NEXT FROM vendor_cursor   " &
        "INTO @Apellido,@Nombre,@ApellidoM " &
        " " &
        "WHILE @@FETCH_STATUS = 0  " &
        "BEGIN " &
        " " &
        "DECLARE product_cursor CURSOR FOR   " &
        "SELECT cliente " &
        "FROM clientescnbv " &
        "WHERE ApellidoPaterno = @Apellido and ApellidoMaterno = @ApellidoM and Nombre = @Nombre " &
        " " &
        "OPEN product_cursor  " &
        "FETCH NEXT FROM product_cursor " &
        "INTO @cli  " &
        " " &
        "WHILE @@FETCH_STATUS = 0  " &
        "BEGIN " &
        " " &
        "INSERT INTO #TempCliente VALUES (@cli) " &
        " " &
        "FETCH NEXT FROM product_cursor " &
        "INTO @cli  " &
                        "End " &
        " " &
        "CLOSE product_cursor  " &
        "DEALLOCATE product_cursor  " &
        " " &
        "FETCH NEXT FROM vendor_cursor   " &
        "INTO @Apellido,@Nombre,@ApellidoM    " &
                            "End " &
        "CLOSE vendor_cursor;  " &
        "DEALLOCATE vendor_cursor; " &
        " " &
        "select cliente as No, ApellidoPaterno as ApePaterno, ApellidoMaterno as ApeMaterno, Nombre as Nombres " &
        "from clientescnbv where cliente in (select Cliente from #TempCliente) order by Nombre, cliente " &
        " " &
        "drop TABLE #TempCliente "
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(orptDuplicados, "clientes")
        LiberarVariables()
        Return orptDuplicados
    End Function


    Public Function clientesDuplicados2(ByVal nombre As String, ByVal apeP As String, ByVal apeM As String) As DataTable
        CargarVariables()
        CargarVariablesLstDt()
        sql = "select * from clientescnbv where ApellidoPaterno='" & apeP & "' and nombre='" & nombre & "' and apellidoMaterno='" & apeM & "'"

        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function S1PersonasMorales(ByVal oPersonasMoralespM As PersonasMoralespM, ByVal cliente As Integer) As PersonasMoralespM
        CargarVariables()
        'maswhere(oclientescnbvM, "", "", False)
        sql = "SELECT c.cliente, p.* FROM clientescnbv c INNER JOIN personasmoralesp p ON p.Num = c.ID WHERE c.cliente = " & cliente
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            oPersonasMoralespM.cliente = dr.GetInt32(0)
            If Not dr.IsDBNull(1) Then
                oPersonasMoralespM.Num = dr.GetInt32(1)
            End If

            If Not dr.IsDBNull(2) Then
                oPersonasMoralespM.RazonSocial = dr.GetString(2)
            End If
            If Not dr.IsDBNull(3) Then
                oPersonasMoralespM.Giro = dr.GetString(3)
            End If

            If Not dr.IsDBNull(4) Then
                oPersonasMoralespM.Nacionalidad = dr.GetString(4)
            End If

            If Not dr.IsDBNull(5) Then
                oPersonasMoralespM.RFC = dr.GetString(5)
            End If

            If Not dr.IsDBNull(6) Then
                oPersonasMoralespM.NoFiel = dr.GetString(6)
            End If

            If Not dr.IsDBNull(7) Then
                oPersonasMoralespM.Calle = dr.GetString(7)
            End If

            If Not dr.IsDBNull(8) Then
                oPersonasMoralespM.NoExt = dr.GetString(8)
            End If

            If Not dr.IsDBNull(9) Then
                oPersonasMoralespM.NoInt = dr.GetString(9)
            End If

            If Not dr.IsDBNull(10) Then
                oPersonasMoralespM.Colonia = dr.GetString(10)
            End If

            If Not dr.IsDBNull(11) Then
                oPersonasMoralespM.CP = dr.GetString(11)
            End If

            If Not dr.IsDBNull(12) Then
                oPersonasMoralespM.Ciudad = dr.GetString(12)
            End If

            If Not dr.IsDBNull(13) Then
                oPersonasMoralespM.Estado = dr.GetString(13)
            End If

            If Not dr.IsDBNull(14) Then
                oPersonasMoralespM.NoTelefono = dr.GetString(14)
            End If

            If Not dr.IsDBNull(15) Then
                oPersonasMoralespM.CorreoE = dr.GetString(15)
            End If

            If Not dr.IsDBNull(16) Then
                oPersonasMoralespM.FechaConstitucion = dr.GetString(16)
            End If

            If Not dr.IsDBNull(17) Then
                oPersonasMoralespM.DirectorGeneral = dr.GetString(17)
            End If

            If Not dr.IsDBNull(18) Then
                oPersonasMoralespM.RepresentanteL = dr.GetString(18)
            End If

            Exit While
        End While
        dr.Close()
        LiberarVariables()
        Return oPersonasMoralespM
    End Function

    Public Function Email_Valido(ByRef Email As String) As Boolean
        'Dim MiCaracter As String
        'Dim CaracterAnterior As String = ""
        'Dim YaTuvoArroba As Boolean

        'Email = LCase(Trim(Email))
        'Email_Valido = False
        'YaTuvoArroba = False

        'If InStr(1, Email, "@") = 0 Then Exit Function 'que tenga arroba

        'For i = 1 To Len(Email)
        '    MiCaracter = Mid(Email, i, 1)
        '    If (Not (MiCaracter Like "[_.a-z]")) And (Not (MiCaracter Like "[@0-9]")) And (Not (MiCaracter Like "[_-.@]")) = 0 Then Exit Function 'que solo permita a-z A-Z 0-9 .@-
        '    If i = 1 Then If InStr(1, ".@", MiCaracter) > 0 Then Exit Function 'que no empiece con .@
        '    If i = Len(Email) Then If InStr(1, ".@-_", MiCaracter) > 0 Then Exit Function 'que no termine con .@-
        '    If MiCaracter = "@" And YaTuvoArroba Then Exit Function ' que solo tenga una @
        '    If InStr(1, ".@", CaracterAnterior) > 0 Then If InStr(1, ".@", MiCaracter) Then Exit Function 'que despues de la @ 0. no haya otra @ o punto

        '    If MiCaracter = "@" Then YaTuvoArroba = True
        '    CaracterAnterior = MiCaracter
        'Next

        'If Not Email.Contains(".com") And Not Email.Contains(".net") And Not Email.Contains(".mx") And Not Email.Contains(".es") And Not Email.Contains(".org") Then Exit Function

        Email_Valido = Regex.IsMatch(Email,
               "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$")

        'Email_Valido = True
    End Function

    Public Function clientesRelaciones(ByVal cliente As String) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "select "
        sql = sql & "   ISNULL(pm.cliente, ISNULL(dp.cliente,ISNULL(pr.cliente,ISNULL(pr2.cliente,ISNULL(pr2.cliente,ISNULL(o.id,0)))))) as AP "
        sql = sql & "from "
        sql = sql & "   clientescnbv c "
        sql = sql & "   left outer join PersonasMoralesRelacion pm on pm.cliente = c.cliente "
        sql = sql & "   left outer join dependenciasPublicRelacion dp on dp.cliente = c.cliente "
        sql = sql & "   left outer join propietariosRealesR pr on pr.cliente = c.cliente "
        sql = sql & "   left outer join propietariosReales pr2 on pr2.cliente = c.cliente "
        sql = sql & "   left outer join OFAC o on o.nombre = c.Nombre and "
        sql = sql & "   o.ApellidoMaterno = c.ApellidoMaterno and o.ApellidoPaterno = c.ApellidoPaterno "
        sql = sql & "where "
        sql = sql & "   c.cliente = '" & cliente & "'"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function Get_EMail(ByVal Cliente As Integer) As String
        CargarVariables()
        sql = ""
        sql = sql & "select "
        sql = sql & "   email "
        sql = sql & "from "
        sql = sql & "   clientescnbv "
        sql = sql & "where "
        sql = sql & "   cliente = '" & Cliente & "'"
        AccesoDatos()
        str = cmd.ExecuteScalar().ToString()
        LiberarVariables()
        Return str
    End Function

    Public Function Actualiza_Proveedor(ByVal cliente As Integer) As Integer
        CargarVariables()
        sql = "update clientescnbv set EsProveedor = 1 Where cliente = " & cliente
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Buscar_Proveedor(ByVal cliente As Integer) As Single
        Dim Incentivo As Single
        CargarVariables()
        sql = ""
        sql = sql & "Select Incentivo From Proveedor Where Cliente = " & cliente
        AccesoDatos()
        rs = cmd.ExecuteReader()
        Incentivo = 0
        While rs.Read
            Incentivo = Format(rs(0), "0.0000")
        End While
        rs.Close()
        LiberarVariables()
        Return Incentivo
    End Function

    Public Function Grabar_Nota_Cargo(ByVal cliente As Integer, ByVal Fecha As Date, ByVal Importe As Decimal, ByVal Folio_Factura As String, ByVal Sucursal As String, ByVal letra As String) As Integer
        Dim FolioNota, Retorno As Integer
        FolioNota = Get_Folio(Sucursal)
        CargarVariables()
        sql = ""
        sql = sql & "INSERT INTO Nota_Incentivo VALUES(" & FolioNota & ", " & cliente & ", '" & Format(Fecha, "dd/MM/yyyy") & "', "
        sql = sql & Importe & ", '" & Folio_Factura & "', '" & Sucursal & "', 1, '" & letra & "')"


        AccesoDatos()
        Retorno = EjecutarABC()
        LiberarVariables()
        Return FolioNota
    End Function

    Public Function Get_Folio(ByVal Sucursal As String) As Integer
        Dim Folio, Ret As Integer
        CargarVariables()
        sql = ""
        sql = sql & "Select Folio From Folio_Sucursal Where Tabla = 'NOTA_INCENTIVO' AND Sucursal = '" & Sucursal & "'"
        AccesoDatos()
        rs = cmd.ExecuteReader()
        Folio = 0
        While rs.Read
            Folio = rs(0)
        End While
        rs.Close()
        sql = ""
        sql = sql & "UPDATE Folio_Sucursal SET Folio = Folio + 1 WHERE Tabla = 'NOTA_INCENTIVO' AND Sucursal = '" & Sucursal & "'"
        AccesoDatos()
        Ret = EjecutarABC()
        LiberarVariables()
        Return Folio

    End Function

    Public Function Buscar_Nombre(ByVal Cliente As Integer) As String
        CargarVariables()
        sql = ""
        sql = sql & "Select "
        sql = sql & "   Nombre + ' ' + ApellidoPaterno + ' ' + ApellidoMaterno as Nombre "
        sql = sql & "From "
        sql = sql & "   clientescnbv "
        sql = sql & "Where "
        sql = sql & "   cliente = '" & Cliente & "'"
        AccesoDatos()
        str = cmd.ExecuteScalar().ToString()
        LiberarVariables()
        Return str
    End Function

    Public Function Buscar_Municipio(ByVal Municipio As String) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "Select "
        sql = sql & "   COUNT(ciudad) as Total "
        sql = sql & "From "
        sql = sql & "   MunicipioIncentivo "
        sql = sql & "Where "
        sql = sql & "   ciudad = '" & Municipio & "'"
        AccesoDatos()
        str = cmd.ExecuteScalar().ToString()
        LiberarVariables()
        Return str
    End Function

    Public Function Municipio_Cliente(ByVal cliente As Integer) As String
        CargarVariables()
        sql = ""
        sql = sql & "Select "
        sql = sql & "   Municipio "
        sql = sql & "From "
        sql = sql & "   clientescnbv "
        sql = sql & "Where "
        sql = sql & "   cliente = '" & cliente & "'"
        AccesoDatos()
        str = cmd.ExecuteScalar().ToString()
        LiberarVariables()
        Return str
    End Function

    Public Function Buscar_Cliente_Incentivo(ByVal Cliente As Integer) As Integer
        CargarVariables()
        sql = ""
        sql = sql & "Select "
        sql = sql & "   COUNT(*) as Total "
        sql = sql & "From "
        sql = sql & "   Clientes_Incentivo "
        sql = sql & "Where "
        sql = sql & "   cliente = " & Cliente
        AccesoDatos()
        str = cmd.ExecuteScalar().ToString()
        LiberarVariables()
        Return str
    End Function
End Class
