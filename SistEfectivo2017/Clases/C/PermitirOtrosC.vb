Imports System.Data.SqlClient

Public Class PermitirOtrosC
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet = Nothing
    Dim sql As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim dr As SqlDataReader = Nothing
    Dim abc As Integer = Nothing
    Dim lst As List(Of SucursalesM)
    Dim dt As DataTable
    Dim disposed As Boolean = False

    Public PermitirOtrosC()

    Private Sub CargarVariables()
        con = New ConexionSQLS
        cmd = New SqlCommand
        sql = ""
        abc = 0
    End Sub

    Private Sub CargarVariablesDS()
        ds = New DataSet
        da = New SqlDataAdapter
    End Sub

    Private Sub CargarVariablesLst()
        da = New SqlDataAdapter
        lst = New List(Of SucursalesM)
    End Sub

    Private Sub CargarVariablesDt()
        da = New SqlDataAdapter
        dt = New DataTable
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


#Region "Dispose"
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

    Public Function Permitir(ByVal nocucursal As String) As Integer
        CargarVariables()
        sql = "SELECT distinct(acliente) FROM PermitirOtros where nosucursal='" & nocucursal & "';"
        AccesoDatos()
        Dim execute As String = cmd.ExecuteScalar().ToString()
        If IsNumeric(execute) Then 'If execute IsNot Nothing Or execute <> "NULL" Or execute <> "" Then
            abc = Convert.ToInt32(execute)
        End If
        LiberarVariables()
        Return abc
    End Function

    Public Function Cambio0(ByVal nocucursal As String) As Integer
        CargarVariables()
        sql = "update PermitirOtros set acliente=0 where nosucursal='" & nocucursal & "';"
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Cambio1(ByVal nocucursal As String) As Integer
        CargarVariables()
        sql = "update PermitirOtros set acliente=1 where nosucursal='" & nocucursal & "';"
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function
End Class
