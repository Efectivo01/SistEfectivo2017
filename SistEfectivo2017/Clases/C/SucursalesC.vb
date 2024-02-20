Imports System.Data.SqlClient

Public Class SucursalesC
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

    Public SucursalesC()

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

    Public Function Alta(ByVal data As SucursalesM) As Integer
        CargarVariables()
        sql = "INSERT INTO Sucursales(id,nombre) values(@id,@nombre)"
        cmd.Parameters.Add("@num", SqlDbType.Int).Value = data.id
        cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = data.nombre
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Baja(ByVal data As SucursalesM) As Integer
        CargarVariables()
        sql = "DELETE FROM Sucursales WHERE id=@id"
        cmd.Parameters.Add("@num", SqlDbType.Int)
        cmd.Parameters("@id").Value = data.id
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Cambio(ByVal data As SucursalesM, ByVal oSucursalesM As SucursalesM) As Integer
        CargarVariables()
        sql = "update Sucursales set nombre=@nombre where id=@id"
        cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = data.nombre
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = oSucursalesM.id
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function STodo(ByVal data As SucursalesM) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT * FROM Sucursales "
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function SiguienteIdNum() As Integer
        CargarVariables()
        sql = "SELECT MAX(num)+1 FROM Sucursales"
        AccesoDatos()
        Dim execute As String = cmd.ExecuteScalar().ToString()
        If IsNumeric(execute) Then 'If execute IsNot Nothing Or execute <> "NULL" Or execute <> "" Then
            abc = Convert.ToInt32(execute)
        End If
        LiberarVariables()
        Return abc
    End Function

    Public Function SucursalE1(ByVal id As String) As String
        Dim SucNom As String = ""
        CargarVariables()
        sql = "SELECT * FROM Sucursales where id='" & id & "';"
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()

            If Not dr.IsDBNull(1) Then
                SucNom = dr.GetString(1)
            End If
            Exit While
        End While
        dr.Close()
        LiberarVariables()
        Return SucNom
    End Function

    Public Function Elige1(ByVal oSucursalesM As SucursalesM) As SucursalesM
        CargarVariables()
        sql = "SELECT * FROM Sucursales where id='" & oSucursalesM.id & "';"
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            If Not IsDBNull(0) Then
                oSucursalesM.id = dr.GetString(0)
            End If

            If Not dr.IsDBNull(1) Then
                oSucursalesM.nombre = dr.GetString(1)
            End If
            Exit While
        End While
        dr.Close()
        LiberarVariables()
        Return oSucursalesM
    End Function

    Public Function FiltraDt(ByVal data As SucursalesM, ByVal a As String, ByVal b As String) As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT * FROM Sucursales "
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function Sucursales() As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT id,replace(nombre,'Sucursal ','') as nombre FROM Sucursales "
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function STodoDt() As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "SELECT * FROM Sucursales "
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
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
