Imports System.Data.SqlClient

Public Class caja_diario2C
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet
    Dim sql, strSet, where As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim dr As SqlDataReader = Nothing
    Dim abc As Double
    Dim lst As List(Of caja_diarioM)
    Dim dt As DataTable
    Dim disposed As Boolean = False
    Dim execute As String
    Public No As String

    Public caja_diarioC()

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
#End Region

#Region "Variables de conexión"
    Private Sub CargarVariables()
        con = New ConexionSQLS
        cmd = New SqlCommand
        sql = ""
        where = ""
        strSet = ""
        abc = 0
        execute = ""
    End Sub

    Private Sub CargarVariablesDS()
        ds = New DataSet
        da = New SqlDataAdapter
    End Sub

    Private Sub CargarVariablesDt()
        da = New SqlDataAdapter
        dt = New DataTable
    End Sub

    Private Sub CargarVarialbesLst()
        lst = New List(Of caja_diarioM)
    End Sub

    Private Sub AccesoDatos()
        cmd.Connection = con.EstablecerConexion()
        con.AbrirConexion()
        cmd.CommandText = sql & strSet & where
    End Sub

    Private Sub AccesoDatos2()
        cmd.Connection = con.EstablecerConexion()
        con.AbrirConexion()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = sql & strSet & where
    End Sub

    Private Function EjecutarABC() As Double
        If cmd.ExecuteNonQuery() <= 0 Then
            Return 0
        End If
        Return 1
    End Function

    Private Sub VerificarValor()
        execute = ""
        If cmd.ExecuteScalar().ToString() <> vbNull Then
            execute = cmd.ExecuteScalar().ToString()
        End If
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

    Public Sub LiberarLstDt()
        da = Nothing
        lst = Nothing
        dt = Nothing
    End Sub

#End Region

#Region "Prueba inserción fecha y valor negativo"
    Public Function Insertar_fecha(ByVal data As caja_diarioM) As Integer
        CargarVariables()
        sql = "insert into caja_diario(saldoi,fecha) values(?,?) ;"
        cmd.Parameters.AddWithValue("@saldoi", SqlDbType.Real).Value = data.saldoi
        cmd.Parameters.AddWithValue("@fecha", SqlDbType.VarChar).Value = data.fecha
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function
#End Region


    Public Function Acaja_diario(ByVal data As caja_diarioM) As Integer
        CargarVariables()
        sql = "INSERT INTO repCajaDia(fecha,Nosucursal,saldoInicial,saldoFinal,compraDivisas,ventaDivisas," &
            "gastos,transEnt,transSal,ventaDolares,ventaEuros,ventaDcan,ventaLibras,ventaMonedas," &
            "transDolaresI,transEurosI,transDcanI,transLibrasI,traspasoBovedaI,compraDolares,compraEuros," &
            "compraDcan,compraLibras,compraMonedas,transDolaresE,transEurosE,transDcanE,transLibrasE," &
            "traspasoBovedaE,gastosOperacion,gastosPersonal,gastosImpCouta,gastosOtros,saldoInicialM," &
            "saldoFinalM,compraDivisasM,ventaDivisasM,gastosM,transEntM,transSalM,ventaDolaresM," &
            "ventaEurosM,ventaDcanM,ventaLibrasM,ventaMonedasM,transDolaresIM,transEurosIM,transDcanIM," &
            "transLibrasIM,traspasoBovedaIM,compraDolaresM,compraEurosM,compraDcanM,compraLibrasM," &
            "compraMonedasM,transDolaresEM,transEurosEM,transDcanEM,transLibrasEM,traspasoBovedaEM," &
            "gastosOperacionM,gastosPersonalM,gastosImpCuotaM,gastosOtrosM,sucursal,incentivo, incentivoM," &
            "compraOtra, compraOtraM, ventaOtra, ventaOtraM, transOtraS, transOtraSM, transOtraE, transOtraEM)" &
            "VALUES(@fecha,@Nosucursal,@saldoInicial,@saldoFinal,@compraDivisas,@ventaDivisas," &
            "@gastos,@transEnt,@transSal,@ventaDolares,@ventaEuros,@ventaDcan,@ventaLibras,@ventaMonedas," &
            "@transDolaresI,@transEurosI,@transDcanI,@transLibrasI,@traspasoBovedaI,@compraDolares,@compraEuros," &
            "@compraDcan,@compraLibras,@compraMonedas,@transDolaresE,@transEurosE,@transDcanE,@transLibrasE," &
            "@traspasoBovedaE,@gastosOperacion,@gastosPersonal,@gastosImpCouta,@gastosOtros,@saldoInicialM," &
            "@saldoFinalM,@compraDivisasM,@ventaDivisasM,@gastosM,@transEntM,@transSalM,@ventaDolaresM," &
            "@ventaEurosM,@ventaDcanM,@ventaLibrasM,@ventaMonedasM,@transDolaresIM,@transEurosIM,@transDcanIM," &
            "@transLibrasIM,@traspasoBovedaIM,@compraDolaresM,@compraEurosM,@compraDcanM,@compraLibrasM," &
            "@compraMonedasM,@transDolaresEM,@transEurosEM,@transDcanEM,@transLibrasEM,@traspasoBovedaEM," &
            "@gastosOperacionM,@gastosPersonalM,@gastosImpCuotaM,@gastosOtrosM,@sucursal,@incentivo, @incentivoM, " &
            "@compraOtra, @compraOtraM, @ventaOtra, @ventaOtraM, @transOtraS, @transOtraSM, @transOtraE, @transOtraEM)"
        cmd.Parameters.AddWithValue("@fecha", SqlDbType.VarChar).Value = data.fecha.ToString("dd/MM/yyyy")
        cmd.Parameters.AddWithValue("@Nosucursal", SqlDbType.VarChar).Value = data.Nosucursal
        cmd.Parameters.AddWithValue("@saldoInicial", SqlDbType.Float).Value = data.saldoi
        cmd.Parameters.AddWithValue("@saldoFinal", SqlDbType.Float).Value = data.saldof
        cmd.Parameters.AddWithValue("@compraDivisas", SqlDbType.Float).Value = data.compd
        cmd.Parameters.AddWithValue("@ventaDivisas", SqlDbType.Float).Value = data.vtad

        cmd.Parameters.AddWithValue("@gastos", SqlDbType.Float).Value = data.gastos
        cmd.Parameters.AddWithValue("@transEnt", SqlDbType.Float).Value = data.transTotalED
        cmd.Parameters.AddWithValue("@transSal", SqlDbType.Float).Value = data.transTotalID
        cmd.Parameters.AddWithValue("@ventaDolares", SqlDbType.Float).Value = data.vtadls
        cmd.Parameters.AddWithValue("@ventaEuros", SqlDbType.Float).Value = data.vtaeur
        cmd.Parameters.AddWithValue("@ventaDcan", SqlDbType.Float).Value = data.vtadc
        cmd.Parameters.AddWithValue("@ventaLibras", SqlDbType.Float).Value = data.vtalib
        cmd.Parameters.AddWithValue("@ventaMonedas", SqlDbType.Float).Value = data.vtamoro

        cmd.Parameters.AddWithValue("@transDolaresI", SqlDbType.Float).Value = data.trasdls
        cmd.Parameters.AddWithValue("@transEurosI", SqlDbType.Float).Value = data.traseur
        cmd.Parameters.AddWithValue("@transDcanI", SqlDbType.Float).Value = data.trasdc
        cmd.Parameters.AddWithValue("@transLibrasI", SqlDbType.Float).Value = data.traslib
        cmd.Parameters.AddWithValue("@traspasoBovedaI", SqlDbType.Float).Value = data.tdb
        cmd.Parameters.AddWithValue("@compraDolares", SqlDbType.Float).Value = data.cpadls
        cmd.Parameters.AddWithValue("@compraEuros", SqlDbType.Float).Value = data.cpaeur

        cmd.Parameters.AddWithValue("@compraDcan", SqlDbType.Float).Value = data.cpadc
        cmd.Parameters.AddWithValue("@compraLibras", SqlDbType.Float).Value = data.cpalib
        cmd.Parameters.AddWithValue("@compraMonedas", SqlDbType.Float).Value = data.cpamoro
        cmd.Parameters.AddWithValue("@transDolaresE", SqlDbType.Float).Value = data.trascdls
        cmd.Parameters.AddWithValue("@transEurosE", SqlDbType.Float).Value = data.trasceur
        cmd.Parameters.AddWithValue("@transDcanE", SqlDbType.Float).Value = data.trascdc
        cmd.Parameters.AddWithValue("@transLibrasE", SqlDbType.Float).Value = data.trasclib

        cmd.Parameters.AddWithValue("@traspasoBovedaE", SqlDbType.Float).Value = data.trab
        cmd.Parameters.AddWithValue("@gastosOperacion", SqlDbType.Float).Value = data.gs
        cmd.Parameters.AddWithValue("@gastosPersonal", SqlDbType.Float).Value = data.go
        cmd.Parameters.AddWithValue("@gastosImpCouta", SqlDbType.Float).Value = data.gf
        cmd.Parameters.AddWithValue("@gastosOtros", SqlDbType.Float).Value = data.gi
        cmd.Parameters.AddWithValue("@saldoInicialM", SqlDbType.Float).Value = data.saldoim

        cmd.Parameters.AddWithValue("@saldoFinalM", SqlDbType.Float).Value = data.saldofm
        cmd.Parameters.AddWithValue("@compraDivisasM", SqlDbType.Float).Value = data.compdm
        cmd.Parameters.AddWithValue("@ventaDivisasM", SqlDbType.Float).Value = data.vtadm
        cmd.Parameters.AddWithValue("@gastosM", SqlDbType.Float).Value = data.gastosM
        cmd.Parameters.AddWithValue("@transEntM", SqlDbType.Float).Value = data.transTotalEM
        cmd.Parameters.AddWithValue("@transSalM", SqlDbType.Float).Value = data.transTotalIM
        cmd.Parameters.AddWithValue("@ventaDolaresM", SqlDbType.Float).Value = data.vtadlsm

        cmd.Parameters.AddWithValue("@ventaEurosM", SqlDbType.Float).Value = data.vtaeurm
        cmd.Parameters.AddWithValue("@ventaDcanM", SqlDbType.Float).Value = data.vtadcm
        cmd.Parameters.AddWithValue("@ventaLibrasM", SqlDbType.Float).Value = data.vtalibm
        cmd.Parameters.AddWithValue("@ventaMonedasM", SqlDbType.Float).Value = data.vtamorom
        cmd.Parameters.AddWithValue("@transDolaresIM", SqlDbType.Float).Value = data.trasdlsm
        cmd.Parameters.AddWithValue("@transEurosIM", SqlDbType.Float).Value = data.traseum
        cmd.Parameters.AddWithValue("@transDcanIM", SqlDbType.Float).Value = data.trasdcm

        cmd.Parameters.AddWithValue("@transLibrasIM", SqlDbType.Float).Value = data.traslibm
        cmd.Parameters.AddWithValue("@traspasoBovedaIM", SqlDbType.Float).Value = data.tdbm
        cmd.Parameters.AddWithValue("@compraDolaresM", SqlDbType.Float).Value = data.cpadlsm
        cmd.Parameters.AddWithValue("@compraEurosM", SqlDbType.Float).Value = data.cpaeum
        cmd.Parameters.AddWithValue("@compraDcanM", SqlDbType.Float).Value = data.cpadcm
        cmd.Parameters.AddWithValue("@compraLibrasM", SqlDbType.Float).Value = data.cpalibm

        cmd.Parameters.AddWithValue("@compraMonedasM", SqlDbType.Float).Value = data.cpamorom
        cmd.Parameters.AddWithValue("@transDolaresEM", SqlDbType.Float).Value = data.trascdlsm
        cmd.Parameters.AddWithValue("@transEurosEM", SqlDbType.Float).Value = data.trasceum
        cmd.Parameters.AddWithValue("@transDcanEM", SqlDbType.Float).Value = data.trascdcm
        cmd.Parameters.AddWithValue("@transLibrasEM", SqlDbType.Float).Value = data.trasclibm
        cmd.Parameters.AddWithValue("@traspasoBovedaEM", SqlDbType.Float).Value = data.trabm

        cmd.Parameters.AddWithValue("@gastosOperacionM", SqlDbType.Float).Value = data.gsm
        cmd.Parameters.AddWithValue("@gastosPersonalM", SqlDbType.Float).Value = data.gom
        cmd.Parameters.AddWithValue("@gastosImpCuotaM", SqlDbType.Float).Value = data.gfm
        cmd.Parameters.AddWithValue("@gastosOtrosM", SqlDbType.Float).Value = data.gim
        cmd.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = data.sucursal
        cmd.Parameters.AddWithValue("@incentivo", SqlDbType.Float).Value = data.Total_Incentivo
        cmd.Parameters.AddWithValue("@incentivoM", SqlDbType.Float).Value = data.Total_IncentivoM

        cmd.Parameters.AddWithValue("@compraOtra", SqlDbType.Float).Value = data.CompraOtra
        cmd.Parameters.AddWithValue("@compraOtraM", SqlDbType.Float).Value = data.CompraOtraM
        cmd.Parameters.AddWithValue("@ventaOtra", SqlDbType.Float).Value = data.VentaOtra
        cmd.Parameters.AddWithValue("@ventaOtraM", SqlDbType.Float).Value = data.VentaOtraM
        cmd.Parameters.AddWithValue("@transOtraS", SqlDbType.Float).Value = data.TransOtraS
        cmd.Parameters.AddWithValue("@transOtraSM", SqlDbType.Float).Value = data.TransOtraSM
        cmd.Parameters.AddWithValue("@transOtraE", SqlDbType.Float).Value = data.TransOtraE
        cmd.Parameters.AddWithValue("@transOtraEM", SqlDbType.Float).Value = data.TransOtraEM

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Ecaja_diario(ByVal data As caja_diarioM) As Integer
        CargarVariables()
        'sql = "DELETE FROM caja_diario WHERE fecha=@fecha"
        cmd.Parameters.AddWithValue("@fecha", SqlDbType.VarChar).Value = data.fecha.ToString("dd/MM/yyyy")
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Mcaja_diario(ByVal data As caja_diarioM, ByVal fecha1 As DateTime, ByVal Nosuc As String) As Integer
        CargarVariables()

        sql = ""
        sql = sql & "UPDATE "
        sql = sql & "   repCajaDia "
        sql = sql & "SET "
        sql = sql & "   saldoInicial = @saldoInicial, "
        sql = sql & "   saldoFinal = @saldoFinal, "
        sql = sql & "   compraDivisas = @compraDivisas, "
        sql = sql & "   ventaDivisas = @ventaDivisas, "
        sql = sql & "   gastos = @gastos, "
        sql = sql & "   transEnt = @transEnt, "
        sql = sql & "   transSal = @transSal, "
        sql = sql & "   ventaDolares = @ventaDolares, "
        sql = sql & "   ventaEuros = @ventaEuros, "
        sql = sql & "   ventaDcan = @ventaDcan, "
        sql = sql & "   ventaLibras = @ventaLibras, "
        sql = sql & "   ventaMonedas = @ventaMonedas, "
        sql = sql & "   transDolaresI = @transDolaresI, "
        sql = sql & "   transEurosI = @transEurosI, "
        sql = sql & "   transDcanI = @transDcanI, "
        sql = sql & "   transLibrasI = @transLibrasI, "
        sql = sql & "   traspasoBovedaI = @traspasoBovedaI, "
        sql = sql & "   compraDolares = @compraDolares, "
        sql = sql & "   compraEuros = @compraEuros, "
        sql = sql & "   compraDcan = @compraDcan, "
        sql = sql & "   compraLibras = @compraLibras, "
        sql = sql & "   compraMonedas = @compraMonedas, "
        sql = sql & "   transDolaresE = @transDolaresE, "
        sql = sql & "   transEurosE = @transEurosE, "
        sql = sql & "   transDcanE = @transDcanE, "
        sql = sql & "   transLibrasE = @transLibrasE, "
        sql = sql & "   traspasoBovedaE = @traspasoBovedaE, "
        sql = sql & "   gastosOperacion = @gastosOperacion, "
        sql = sql & "   gastosPersonal = @gastosPersonal, "
        sql = sql & "   gastosImpCouta = @gastosImpCouta, "
        sql = sql & "   gastosOtros = @gastosOtros, "
        sql = sql & "   saldoInicialM = @saldoInicialM, "
        sql = sql & "   saldoFinalM = @saldoFinalM, "
        sql = sql & "   compraDivisasM = @compraDivisasM, "
        sql = sql & "   ventaDivisasM = @ventaDivisasM, "
        sql = sql & "   gastosM = @gastosM, "
        sql = sql & "   transEntM = @transEntM, "
        sql = sql & "   transSalM = @transSalM, "
        sql = sql & "   ventaDolaresM = @ventaDolaresM, "
        sql = sql & "   ventaEurosM = @ventaEurosM, "
        sql = sql & "   ventaDcanM = @ventaDcanM, "
        sql = sql & "   ventaLibrasM = @ventaLibrasM, "
        sql = sql & "   ventaMonedasM = @ventaMonedasM, "
        sql = sql & "   transDolaresIM = @transDolaresIM, "
        sql = sql & "   transEurosIM = @transEurosIM, "
        sql = sql & "   transDcanIM = @transDcanIM, "
        sql = sql & "   transLibrasIM = @transLibrasIM, "
        sql = sql & "   traspasoBovedaIM = @traspasoBovedaIM, "
        sql = sql & "   compraDolaresM = @compraDolaresM, "
        sql = sql & "   compraEurosM = @compraEurosM, "
        sql = sql & "   compraDcanM = @compraDcanM, "
        sql = sql & "   compraLibrasM = @compraLibrasM, "
        sql = sql & "   compraMonedasM = @compraMonedasM, "
        sql = sql & "   transDolaresEM = @transDolaresEM, "
        sql = sql & "   transEurosEM = @transEurosEM, "
        sql = sql & "   transDcanEM = @transDcanEM, "
        sql = sql & "   transLibrasEM = @transLibrasEM, "
        sql = sql & "   traspasoBovedaEM = @traspasoBovedaEM, "
        sql = sql & "   gastosOperacionM = @gastosOperacionM, "
        sql = sql & "   gastosPersonalM = @gastosPersonalM, "
        sql = sql & "   gastosImpCuotaM = @gastosImpCuotaM, "
        sql = sql & "   gastosOtrosM = @gastosOtrosM, "
        sql = sql & "   fecha = '" & fecha1.ToString("dd/MM/yyyy") & "', "
        sql = sql & "   incentivo = @incentivo, "
        sql = sql & "   incentivoM = @incentivoM, "
        sql = sql & "   cupon = @cupon, "
        sql = sql & "   cuponM = @cuponM, "
        sql = sql & "   compraOtra = @compraOtra, "
        sql = sql & "   compraOtraM = @compraOtraM, "
        sql = sql & "   ventaOtra = @ventaOtra, "
        sql = sql & "   ventaOtraM = @ventaOtraM, "
        sql = sql & "   transOtraS = @transOtraS, "
        sql = sql & "   transOtraSM = @transOtraSM, "
        sql = sql & "   transOtraE = @transOtraE, "
        sql = sql & "   transOtraEM = @transOtraEM "
        sql = sql & "WHERE "
        sql = sql & "   Nosucursal = '" & Nosuc & "'"
        cmd.Parameters.AddWithValue("@saldoInicial", SqlDbType.Float).Value = data.saldoi
        cmd.Parameters.AddWithValue("@saldoFinal", SqlDbType.Float).Value = data.saldof
        cmd.Parameters.AddWithValue("@compraDivisas", SqlDbType.Float).Value = data.compd
        cmd.Parameters.AddWithValue("@ventaDivisas", SqlDbType.Float).Value = data.vtad

        cmd.Parameters.AddWithValue("@gastos", SqlDbType.Float).Value = data.gastos
        cmd.Parameters.AddWithValue("@transEnt", SqlDbType.Float).Value = data.transTotalED
        cmd.Parameters.AddWithValue("@transSal", SqlDbType.Float).Value = data.transTotalID
        cmd.Parameters.AddWithValue("@ventaDolares", SqlDbType.Float).Value = data.vtadls
        cmd.Parameters.AddWithValue("@ventaEuros", SqlDbType.Float).Value = data.vtaeur
        cmd.Parameters.AddWithValue("@ventaDcan", SqlDbType.Float).Value = data.vtadc
        cmd.Parameters.AddWithValue("@ventaLibras", SqlDbType.Float).Value = data.vtalib
        cmd.Parameters.AddWithValue("@ventaMonedas", SqlDbType.Float).Value = data.vtamoro

        cmd.Parameters.AddWithValue("@transDolaresI", SqlDbType.Float).Value = data.trasdls
        cmd.Parameters.AddWithValue("@transEurosI", SqlDbType.Float).Value = data.traseur
        cmd.Parameters.AddWithValue("@transDcanI", SqlDbType.Float).Value = data.trasdc
        cmd.Parameters.AddWithValue("@transLibrasI", SqlDbType.Float).Value = data.traslib
        cmd.Parameters.AddWithValue("@traspasoBovedaI", SqlDbType.Float).Value = data.tdb
        cmd.Parameters.AddWithValue("@compraDolares", SqlDbType.Float).Value = data.cpadls
        cmd.Parameters.AddWithValue("@compraEuros", SqlDbType.Float).Value = data.cpaeur

        cmd.Parameters.AddWithValue("@compraDcan", SqlDbType.Float).Value = data.cpadc
        cmd.Parameters.AddWithValue("@compraLibras", SqlDbType.Float).Value = data.cpalib
        cmd.Parameters.AddWithValue("@compraMonedas", SqlDbType.Float).Value = data.cpamoro
        cmd.Parameters.AddWithValue("@transDolaresE", SqlDbType.Float).Value = data.trascdls
        cmd.Parameters.AddWithValue("@transEurosE", SqlDbType.Float).Value = data.trasceur
        cmd.Parameters.AddWithValue("@transDcanE", SqlDbType.Float).Value = data.trascdc
        cmd.Parameters.AddWithValue("@transLibrasE", SqlDbType.Float).Value = data.trasclib

        cmd.Parameters.AddWithValue("@traspasoBovedaE", SqlDbType.Float).Value = data.trab
        cmd.Parameters.AddWithValue("@gastosOperacion", SqlDbType.Float).Value = data.gs
        cmd.Parameters.AddWithValue("@gastosPersonal", SqlDbType.Float).Value = data.go
        cmd.Parameters.AddWithValue("@gastosImpCouta", SqlDbType.Float).Value = data.gf
        cmd.Parameters.AddWithValue("@gastosOtros", SqlDbType.Float).Value = data.gi
        cmd.Parameters.AddWithValue("@saldoInicialM", SqlDbType.Float).Value = data.saldoim

        cmd.Parameters.AddWithValue("@saldoFinalM", SqlDbType.Float).Value = data.saldofm
        cmd.Parameters.AddWithValue("@compraDivisasM", SqlDbType.Float).Value = data.compdm
        cmd.Parameters.AddWithValue("@ventaDivisasM", SqlDbType.Float).Value = data.vtadm
        cmd.Parameters.AddWithValue("@gastosM", SqlDbType.Float).Value = data.gastosM
        cmd.Parameters.AddWithValue("@transEntM", SqlDbType.Float).Value = data.transTotalEM
        cmd.Parameters.AddWithValue("@transSalM", SqlDbType.Float).Value = data.transTotalIM
        cmd.Parameters.AddWithValue("@ventaDolaresM", SqlDbType.Float).Value = data.vtadlsm

        cmd.Parameters.AddWithValue("@ventaEurosM", SqlDbType.Float).Value = data.vtaeurm
        cmd.Parameters.AddWithValue("@ventaDcanM", SqlDbType.Float).Value = data.vtadcm
        cmd.Parameters.AddWithValue("@ventaLibrasM", SqlDbType.Float).Value = data.vtalibm
        cmd.Parameters.AddWithValue("@ventaMonedasM", SqlDbType.Float).Value = data.vtamorom
        cmd.Parameters.AddWithValue("@transDolaresIM", SqlDbType.Float).Value = data.trasdlsm
        cmd.Parameters.AddWithValue("@transEurosIM", SqlDbType.Float).Value = data.traseum
        cmd.Parameters.AddWithValue("@transDcanIM", SqlDbType.Float).Value = data.trasdcm

        cmd.Parameters.AddWithValue("@transLibrasIM", SqlDbType.Float).Value = data.traslibm
        cmd.Parameters.AddWithValue("@traspasoBovedaIM", SqlDbType.Float).Value = data.tdbm
        cmd.Parameters.AddWithValue("@compraDolaresM", SqlDbType.Float).Value = data.cpadlsm
        cmd.Parameters.AddWithValue("@compraEurosM", SqlDbType.Float).Value = data.cpaeum
        cmd.Parameters.AddWithValue("@compraDcanM", SqlDbType.Float).Value = data.cpadcm
        cmd.Parameters.AddWithValue("@compraLibrasM", SqlDbType.Float).Value = data.cpalibm

        cmd.Parameters.AddWithValue("@compraMonedasM", SqlDbType.Float).Value = data.cpamorom
        cmd.Parameters.AddWithValue("@transDolaresEM", SqlDbType.Float).Value = data.trascdlsm
        cmd.Parameters.AddWithValue("@transEurosEM", SqlDbType.Float).Value = data.trasceum
        cmd.Parameters.AddWithValue("@transDcanEM", SqlDbType.Float).Value = data.trascdcm
        cmd.Parameters.AddWithValue("@transLibrasEM", SqlDbType.Float).Value = data.trasclibm
        cmd.Parameters.AddWithValue("@traspasoBovedaEM", SqlDbType.Float).Value = data.trabm

        cmd.Parameters.AddWithValue("@gastosOperacionM", SqlDbType.Float).Value = data.gsm
        cmd.Parameters.AddWithValue("@gastosPersonalM", SqlDbType.Float).Value = data.gom
        cmd.Parameters.AddWithValue("@gastosImpCuotaM", SqlDbType.Float).Value = data.gfm
        cmd.Parameters.AddWithValue("@gastosOtrosM", SqlDbType.Float).Value = data.gim
        cmd.Parameters.AddWithValue("@sucursal", SqlDbType.VarChar).Value = data.sucursal
        cmd.Parameters.AddWithValue("@incentivo", SqlDbType.Float).Value = data.Total_Incentivo
        cmd.Parameters.AddWithValue("@incentivoM", SqlDbType.Float).Value = data.Total_IncentivoM
        cmd.Parameters.AddWithValue("@cupon", SqlDbType.Float).Value = data.Total_Cupones
        cmd.Parameters.AddWithValue("@cuponM", SqlDbType.Float).Value = data.Total_CuponesM

        cmd.Parameters.AddWithValue("@compraOtra", SqlDbType.Float).Value = data.CompraOtra
        cmd.Parameters.AddWithValue("@compraOtraM", SqlDbType.Float).Value = data.CompraOtraM
        cmd.Parameters.AddWithValue("@ventaOtra", SqlDbType.Float).Value = data.VentaOtra
        cmd.Parameters.AddWithValue("@ventaOtraM", SqlDbType.Float).Value = data.VentaOtraM
        cmd.Parameters.AddWithValue("@transOtraS", SqlDbType.Float).Value = data.TransOtraS
        cmd.Parameters.AddWithValue("@transOtraSM", SqlDbType.Float).Value = data.TransOtraSM
        cmd.Parameters.AddWithValue("@transOtraE", SqlDbType.Float).Value = data.TransOtraE
        cmd.Parameters.AddWithValue("@transOtraEM", SqlDbType.Float).Value = data.TransOtraEM

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Private Sub maswhere(ByVal data As caja_diarioM, ByVal a As String, ByVal b As String, ByVal likeoigual As Boolean)
        Dim operador As String = ""
        Select Case likeoigual
            Case True
                operador = " like "
            Case False
                operador = "="
        End Select

        If data.fecha <> Nothing Then
            where = where & " fecha=? and"
            cmd.Parameters.AddWithValue("@fecha", data.fecha.ToString("dd/MM/yyyy"))
        End If

        If where.Trim.Length > 0 Then
            where = " WHERE " & where.Remove(where.Length - 3, 3)
        End If
        where += " order by ApellidoPaterno,Nombre;"
    End Sub

    Public Function Scaja_diario(ByVal data As caja_diarioM) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, "", "", False)
        sql = " SELECT * FROM caja_diario"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Fcaja_diario(ByVal data As Object, ByVal a As String, ByVal b As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, a, b, True)
        sql = " SELECT * FROM caja_diario"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Slstcaja_diario(ByVal data As caja_diarioM) As List(Of caja_diarioM)
        CargarVariables()
        CargarVarialbesLst()
        sql = "Select * from caja_diario"
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            data = New caja_diarioM()
            data.saldoi = dr.GetDouble(0)
            data.compd = dr.GetDouble(1)
            data.vtad = dr.GetDouble(2)
            data.trad = dr.GetDouble(3)
            data.saldof = dr.GetDouble(4)
            data.saldoicaja = dr.GetDouble(5)
            data.vtadls = dr.GetDouble(6)
            data.vtaeur = dr.GetDouble(7)
            data.vtadc = dr.GetDouble(8)
            data.vtalib = dr.GetDouble(9)
            data.vtamoro = dr.GetDouble(10)
            data.trasdls = dr.GetDouble(11)
            data.traseur = dr.GetDouble(12)
            data.trasdc = dr.GetDouble(13)
            data.traslib = dr.GetDouble(14)
            data.tdb = dr.GetDouble(15)
            data.totalic = dr.GetDouble(16)
            data.cpadls = dr.GetDouble(17)
            data.cpaeur = dr.GetDouble(18)
            data.cpadc = dr.GetDouble(19)
            data.cpalib = dr.GetDouble(20)
            data.cpamoro = dr.GetDouble(21)
            data.trascdls = dr.GetDouble(22)
            data.trasceur = dr.GetDouble(23)
            data.trascdc = dr.GetDouble(24)
            data.trasclib = dr.GetDouble(25)
            data.trab = dr.GetDouble(26)
            data.gs = dr.GetDouble(27)
            data.gi = dr.GetDouble(28)
            data.go = dr.GetDouble(29)
            data.gf = dr.GetDouble(30)
            data.totalec = dr.GetDouble(31)
            data.saldofcaja = dr.GetDouble(32)
            data.fecha = dr.GetDateTime(33)
            data.sucursal = dr.GetString(34)
            data.saldom = dr.GetDouble(35)
            data.compdm = dr.GetDouble(36)
            data.vtadm = dr.GetDouble(37)
            data.tradm = dr.GetDouble(38)
            data.saldofm = dr.GetDouble(39)
            data.saldoicajam = dr.GetDouble(40)
            data.vtadlsm = dr.GetDouble(41)
            data.vtaeurm = dr.GetDouble(42)
            data.vtadcm = dr.GetDouble(43)
            data.vtalibm = dr.GetDouble(44)
            data.vtamorom = dr.GetDouble(45)
            data.trasdlsm = dr.GetDouble(46)
            data.traseum = dr.GetDouble(47)
            data.trasdcm = dr.GetDouble(48)
            data.traslibm = dr.GetDouble(49)
            data.tdbm = dr.GetDouble(50)
            data.totalicm = dr.GetDouble(51)
            data.cpadlsm = dr.GetDouble(52)
            data.cpaeum = dr.GetDouble(53)
            data.cpadcm = dr.GetDouble(54)
            data.cpalibm = dr.GetDouble(55)
            data.cpamorom = dr.GetDouble(56)
            data.trascdlsm = dr.GetDouble(57)
            data.trasceum = dr.GetDouble(58)
            data.trascdcm = dr.GetDouble(59)
            data.trasclibm = dr.GetDouble(60)
            data.trabm = dr.GetDouble(61)
            data.gsm = dr.GetDouble(62)
            data.gim = dr.GetDouble(63)
            data.gom = dr.GetDouble(64)
            data.gfm = dr.GetDouble(65)
            data.totalecm = dr.GetDouble(66)
            data.saldofcajam = dr.GetDouble(67)
            lst.Add(data)
        End While
        LiberarVariables()
        Return lst
    End Function

    Public Function S1caja_diario(ByVal data As caja_diarioM) As caja_diarioM
        CargarVariables()
        sql = " SELECT * FROM caja_diario "
        If data.fecha <> Nothing Then
            sql = sql & "where  fecha = ? and"
            cmd.Parameters.AddWithValue("@fecha", data.fecha.ToString("dd/MM/yyyy"))
        End If
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            data.saldoi = dr.GetDouble(0)
            data.compd = dr.GetDouble(1)
            data.vtad = dr.GetDouble(2)
            data.trad = dr.GetDouble(3)
            data.saldof = dr.GetDouble(4)
            data.saldoicaja = dr.GetDouble(5)
            data.vtadls = dr.GetDouble(6)
            data.vtaeur = dr.GetDouble(7)
            data.vtadc = dr.GetDouble(8)
            data.vtalib = dr.GetDouble(9)
            data.vtamoro = dr.GetDouble(10)
            data.trasdls = dr.GetDouble(11)
            data.traseur = dr.GetDouble(12)
            data.trasdc = dr.GetDouble(13)
            data.traslib = dr.GetDouble(14)
            data.tdb = dr.GetDouble(15)
            data.totalic = dr.GetDouble(16)
            data.cpadls = dr.GetDouble(17)
            data.cpaeur = dr.GetDouble(18)
            data.cpadc = dr.GetDouble(19)
            data.cpalib = dr.GetDouble(20)
            data.cpamoro = dr.GetDouble(21)
            data.trascdls = dr.GetDouble(22)
            data.trasceur = dr.GetDouble(23)
            data.trascdc = dr.GetDouble(24)
            data.trasclib = dr.GetDouble(25)
            data.trab = dr.GetDouble(26)
            data.gs = dr.GetDouble(27)
            data.gi = dr.GetDouble(28)
            data.go = dr.GetDouble(29)
            data.gf = dr.GetDouble(30)
            data.totalec = dr.GetDouble(31)
            data.saldofcaja = dr.GetDouble(32)
            data.fecha = dr.GetString(33)
            data.sucursal = dr.GetString(34)
            data.saldom = dr.GetDouble(35)
            data.compdm = dr.GetDouble(36)
            data.vtadm = dr.GetDouble(37)
            data.tradm = dr.GetDouble(38)
            data.saldofm = dr.GetDouble(39)
            data.saldoicajam = dr.GetDouble(40)
            data.vtadlsm = dr.GetDouble(41)
            data.vtaeurm = dr.GetDouble(42)
            data.vtadcm = dr.GetDouble(43)
            data.vtalibm = dr.GetDouble(44)
            data.vtamorom = dr.GetDouble(45)
            data.trasdlsm = dr.GetDouble(46)
            data.traseum = dr.GetDouble(47)
            data.trasdcm = dr.GetDouble(48)
            data.traslibm = dr.GetDouble(49)
            data.tdbm = dr.GetDouble(50)
            data.totalicm = dr.GetDouble(51)
            data.cpadlsm = dr.GetDouble(52)
            data.cpaeum = dr.GetDouble(53)
            data.cpadcm = dr.GetDouble(54)
            data.cpalibm = dr.GetDouble(55)
            data.cpamorom = dr.GetDouble(56)
            data.trascdlsm = dr.GetDouble(57)
            data.trasceum = dr.GetDouble(58)
            data.trascdcm = dr.GetDouble(59)
            data.trasclibm = dr.GetDouble(60)
            data.trabm = dr.GetDouble(61)
            data.gsm = dr.GetDouble(62)
            data.gim = dr.GetDouble(63)
            data.gom = dr.GetDouble(64)
            data.gfm = dr.GetDouble(65)
            data.totalecm = dr.GetDouble(66)
            data.saldofcajam = dr.GetDouble(67)
            Exit While
        End While
        LiberarVariables()
        Return data
    End Function

    Public Function RptCAJA(ByVal suc As String, ByVal fecha As Date) As DataSet
        Dim oCajaDiarioDS As CajaDiario = New CajaDiario()
        CargarVariables()
        da = New SqlDataAdapter
        sql = "SELECT TOP 1 * FROM repCajaDia WHERE Nosucursal = '" & suc & "' AND fecha = '" & fecha & "'"
        cmd = New SqlCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oCajaDiarioDS, "caja_diario")
        LiberarVariables()
        Return oCajaDiarioDS
    End Function

    Public Sub Vaciar_caja_diario()
        CargarVariables()
        sql = "delete from caja_diario"
        AccesoDatos()
        cmd.ExecuteNonQuery()
        LiberarVariables()
    End Sub

    Public Function SaldoInicialMes(ByVal codigo As String, ByVal fecha1 As DateTime, ByVal fecha2 As String) As Double
        Dim condiciones As String = ""

        Select Case fecha2 Is Nothing
            Case True
                condiciones += " and tM.fecha ='" & fecha1.ToString("dd/MM/yyyy") & "'"
            Case False
                condiciones += " and tM.fecha between '" & fecha2 & "' and '" & fecha1.ToString("dd/MM/yyyy") & "'"
        End Select

        Select Case codigo.Length
            Case 1
                condiciones += " and tD.producto like '" & codigo & "%' and not SUBSTRING(tD.producto, 2, 1) between 'A' and 'Z'"
            Case 2
                condiciones += " and tD.producto like '" & codigo & "%'"
        End Select
        CargarVariables()
        sql = "select SUM(tD.cantidads*tD.p_unitario) as Salida from transferD as tD inner join transferM as tM on tD.folio_factura=" &
        "tM.folio_factura where tM.observaciones='SALIDA' AND tM.tipo='DIVISAS'" & condiciones & ";"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    'para saber si hay datos en la tabla
    Public Function VerificacionCaja(ByVal fecha1 As DateTime, ByVal suc As String) As Double
        CargarVariables()
        'sql = "SELECT COUNT(saldoFinal) FROM repCajaDia where fecha ='" & fecha1.ToString("dd/MM/yyyy") & "' and Nosucursal = '" & suc & "'"
        sql = "SELECT COUNT(saldoFinal) FROM repCajaDia where Nosucursal = '" & suc & "'"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function SaldoInicialC(ByVal fecha1 As DateTime, ByVal suc As String) As Double
        CargarVariables()
        'sql = "SELECT ISNULL(SUM(saldoFinal),0) FROM repCajaDia where fecha ='" & fecha1.ToString("dd/MM/yyyy") & "' and Nosucursal = '" & suc & "'"
        sql = "SELECT SaldoFinal FROM RepCajaMes where fecha = '" & fecha1 & "' and Nosucursal = '" & suc & "'"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

    Public Function SaldoInicialCM(ByVal fecha1 As DateTime, ByVal suc As String) As Double
        CargarVariables()
        ' sql = "SELECT ISNULL(SUM(ROUND(saldoInicialM,2)),0) FROM repCajaDia where fecha ='" & fecha1.ToString("dd/MM/yyyy") & "' and Nosucursal = '" & suc & "'"
        sql = "SELECT ISNULL(SUM(SaldoFinalM),0) as SaldoFinalM FROM RepCajaMes where fecha = '" & fecha1 & "' and Nosucursal = '" & suc & "'"
        AccesoDatos()
        VerificarValor()
        LiberarVariables()
        Return abc
    End Function

End Class
