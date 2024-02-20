Imports System.Data.SqlClient

Public Class gastosC
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim sql As String
    Dim cmd As SqlCommand = Nothing
    Dim abc As Integer = Nothing
    Dim disposed As Boolean = False

    Public gastosC()

#Region "Variables con acceso a Datos en BD"
    Private Sub CargarVariables()
        con = New ConexionSQLS
        cmd = New SqlCommand
        sql = ""
        abc = 0
    End Sub

    Private Sub AccesoDatos()
        cmd.Connection = con.EstablecerConexion()
        con.AbrirConexion()
        cmd.CommandText = sql
    End Sub

    Private Function EjecutarABC() As Integer
        If cmd.ExecuteNonQuery() <= 0 Then
            Return 0
        End If
        Return 1
    End Function

    Private Sub LiberarVariables()
        cmd.Connection.Close()
        con.CerrarConexion()
        con = Nothing
        cmd = Nothing
        sql = Nothing
    End Sub
#End Region

    Public Function Alta(ByVal data As gastosM) As Integer
        CargarVariables()
        sql = "INSERT INTO gastos(concepto,fecha,hora,cajero,ncorte,total,referencia,Nosucursal,factura,usuario,concepto_det) values " &
            "(@concepto,@fecha,@hora,@cajero,@ncorte,@total,@referencia,@Nosucursal,@factura,@usuario,@concepto_det);"
        cmd.Parameters.Add("@concepto", SqlDbType.NVarChar).Value = data.concepto
        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = data.fecha
        cmd.Parameters.Add("@hora", SqlDbType.NVarChar).Value = data.hora
        cmd.Parameters.Add("@cajero", SqlDbType.Int).Value = data.cajero
        cmd.Parameters.Add("@ncorte", SqlDbType.Int).Value = data.ncorte
        cmd.Parameters.Add("@total", SqlDbType.Real).Value = data.total
        cmd.Parameters.Add("@referencia", SqlDbType.NVarChar).Value = data.referencia
        cmd.Parameters.Add("@Nosucursal", SqlDbType.NVarChar).Value = data.Nosucursal
        cmd.Parameters.Add("@factura", SqlDbType.NVarChar).Value = data.factura
        cmd.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = data.usuario
        cmd.Parameters.Add("@concepto_det", SqlDbType.Int).Value = data.conceptoDet
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function AltaEnCAJA(ByVal data As CAJAM) As Integer
        CargarVariables()
        sql = "INSERT INTO CAJA(Fecha,movimiento,tipo,Referencia,BC,Folio,TOTAL,valor,Nosucursal)VALUES " &
            "(@Fecha,@movimiento,@tipo,@Referencia,@BC,@Folio,@TOTAL,@valor,@Nosucursal)"
        cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = data.Fecha
        cmd.Parameters.Add("@movimiento", SqlDbType.NVarChar).Value = data.movimiento
        cmd.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = data.tipo
        cmd.Parameters.Add("@Referencia", SqlDbType.NVarChar).Value = data.Referencia
        cmd.Parameters.Add("@BC", SqlDbType.NVarChar).Value = data.BC
        cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = data.Folio
        cmd.Parameters.Add("@TOTAL", SqlDbType.Float).Value = data.TOTAL
        cmd.Parameters.Add("@valor", SqlDbType.Float).Value = data.valor
        cmd.Parameters.Add("@Nosucursal", SqlDbType.NVarChar).Value = data.sucursal
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

#Region "Dispose"
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
