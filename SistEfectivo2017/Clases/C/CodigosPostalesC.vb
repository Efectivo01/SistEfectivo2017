Imports System.Data.SqlClient

Public Class CodigosPostalesC
    Implements IDisposable
    Dim con As ConexionSQLS = Nothing
    Dim ds As DataSet = Nothing
    Dim sql, where, strSet As String
    Dim cmd As SqlCommand = Nothing
    Dim da As SqlDataAdapter = Nothing
    Dim dr As SqlDataReader = Nothing
    Dim abc As Integer = Nothing
    Dim dt As DataTable
    Dim disposed As Boolean = False
    Dim stringCol As AutoCompleteStringCollection

    Public CodigosPostalesC()

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

    Private Sub CargarVariablesDt()
        da = New SqlDataAdapter
        dt = New DataTable
        stringCol = New AutoCompleteStringCollection()
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

    Private Sub RecopilarDatosDs()
        da.SelectCommand = cmd
        da.Fill(ds)
    End Sub

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
        stringCol = Nothing
        dr = Nothing
    End Sub
#End Region

    Private Sub maswhere(ByVal data As CodigosPostalesM, ByVal a As String, ByVal b As String, ByVal likeoigual As Boolean)
        Dim operador As String = ""
        Select Case likeoigual
            Case True
                operador = " like "
            Case False
                operador = "="
        End Select
        If data.CodigoPostal <> Nothing Then
            where = where & " CodigoPostal=@CodigoPostal and"
            cmd.Parameters.Add("@CodigoPostal", SqlDbType.NVarChar).Value = data.CodigoPostal
        End If
        If data.Municipio <> Nothing Then
            where = where & " Municipio" & operador & "'" & b & "'+@Municipio+'" & a & "' and"
            cmd.Parameters.Add("@Municipio", SqlDbType.NVarChar).Value = data.Municipio
        End If
        If data.Estado <> Nothing Then
            where = where & " Estado" & operador & "'" & b & "'+@Estado+'" & a & "' and"
            cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = data.Estado
        End If
        If data.Colonia <> Nothing Then
            where = where & " Colonia" & operador & "'" & b & "'+@Colonia+'" & a & "' and"
            cmd.Parameters.Add("@Colonia", SqlDbType.NVarChar).Value = data.Colonia
        End If

        If where.Trim.Length > 0 Then
            where = " WHERE " & where.Remove(where.Length - 3, 3)
        End If
    End Sub

    Public Function SCodigosPostales(ByVal data As CodigosPostalesM) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, "", "", False)
        sql = "SELECT * FROM CodigosPostales"
        AccesoDatos()
        RecopilarDatosDs()
        LiberarVariables()
        Return ds
    End Function

    Public Function FCodigosPostales(ByVal data As CodigosPostalesM, ByVal a As String, ByVal b As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, a, b, True)
        sql = "SELECT * FROM CodigosPostales "
        AccesoDatos()
        RecopilarDatosDs()
        LiberarVariables()
        Return ds
    End Function

    Public Function SCodigosPostales() As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = " SELECT distinct * FROM CodigosPostales"
        AccesoDatos()
        RecopilarDatosDs()
        LiberarVariables()
        Return ds
    End Function

    Public Function S1CodigosPostales(ByVal oCodigosPostalesM As CodigosPostalesM) As CodigosPostalesM
        CargarVariables()
        maswhere(oCodigosPostalesM, "", "", False)
        sql = "SELECT * FROM CodigosPostales"
        AccesoDatos()
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        While dr.Read()
            oCodigosPostalesM.CodigoPostal = dr.GetString(0)
            oCodigosPostalesM.Colonia = dr.GetString(1)
            oCodigosPostalesM.Municipio = dr.GetString(2)
            oCodigosPostalesM.Estado = dr.GetString(3)
            Exit While
        End While
        LiberarVariables()
        Return oCodigosPostalesM
    End Function

    Private Sub maswhere2(ByVal data As CodigosPostalesM, ByVal a As String, ByVal b As String)
        If data.Municipio <> Nothing Then
            where = where & " Municipio= @Municipio and"
            cmd.Parameters.Add("@Municipio", SqlDbType.NVarChar).Value = data.Municipio
        End If
        If data.Estado <> Nothing Then
            where = where & " Estado= @Estado and"
            cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = data.Estado
        End If
        If data.Colonia <> Nothing Then
            where = where & " Colonia like '" & b & "'+@Colonia+'" & a & "' and"
            cmd.Parameters.Add("@Colonia", SqlDbType.NVarChar).Value = data.Colonia
        End If

        If where.Trim.Length > 0 Then
            where = " WHERE " & where.Remove(where.Length - 3, 3)
        End If
    End Sub

    Public Function CargarDT_CP(ByVal data As CodigosPostalesM, ByVal a As String, ByVal b As String) As DataTable
        LiberarDt()
        CargarVariables()
        CargarVariablesDt()
        maswhere2(data, a, b)
        sql = "SELECT * FROM CodigosPostales"

        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function AutoCompletarCP(ByVal data As CodigosPostalesM, ByVal a As String, ByVal b As String) As AutoCompleteStringCollection
        CargarDT_CP(data, a, b)
        'stringCol = New AutoCompleteStringCollection()
        If stringCol IsNot Nothing Then
            stringCol = New AutoCompleteStringCollection
        Else
            stringCol = Nothing
            stringCol = New AutoCompleteStringCollection
        End If
        Dim split2 As String()
        Try
            For Each row As DataRow In dt.Rows
                If row("Colonia").ToString().Contains(data.Colonia.ToUpper()) Then
                    split2 = row("Colonia").ToString().Split(";")
                    For i As Integer = 0 To split2.Length - 1
                        If split2(i).Contains(data.Colonia.ToUpper()) Then
                            stringCol.Add(split2(i)) '& " " & row("CodigoPostal").ToString()
                        End If
                    Next
                    split2 = Nothing
                Else
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try

        Return stringCol
    End Function

    Public Function CargarDT_Municipios(ByVal data As CodigosPostalesM, ByVal a As String, ByVal b As String) As DataTable
        LiberarDt()
        CargarVariables()
        CargarVariablesDt()
        maswhere(data, a, b, True)
        sql = "SELECT MUNICIPIO FROM CodigosPostales"
        AccesoDatos()
        RecopilarDatosDt()
        LiberarVariables()
        Return dt
    End Function

    Public Function AutoCompletarMunicipio(ByVal data As CodigosPostalesM, ByVal a As String, ByVal b As String) As AutoCompleteStringCollection
        CargarDT_Municipios(data, a, b)
        If stringCol IsNot Nothing Then
            stringCol = New AutoCompleteStringCollection
        Else
            stringCol = Nothing
            stringCol = New AutoCompleteStringCollection
        End If
        'Dim stringCol As New AutoCompleteStringCollection()
        Try
            For Each row As DataRow In dt.Rows
                If row("Municipio").ToString().Contains(data.Municipio.ToUpper()) Then
                    stringCol.Add(row("Municipio").ToString())
                    'Else
                    '    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
        Return stringCol
    End Function

    Public Function CiudadesPorEstado(ByVal data As CodigosPostalesM) As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT distinct(Municipio) FROM CodigosPostales where Estado= @Estado"
        cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = data.Estado
        AccesoDatos()
        RecopilarDatosDs()
        LiberarVariables()
        Return ds
    End Function

    Public Function ColoniasPorCiudad(ByVal oCodigosPostalesM As CodigosPostalesM) As List(Of CP)
        Dim lstCP As List(Of CP)
        lstCP = Nothing
        lstCP = New List(Of CP)
        Dim oCP As CP
        CargarVariables()
        maswhere(oCodigosPostalesM, "", "", False)
        sql = "SELECT CodigoPostal,Colonia FROM CodigosPostales "
        AccesoDatos()
        dr = cmd.ExecuteReader()
        Dim colonias, cp As String
        Dim split2 As String()
        While dr.Read()
            cp = dr.GetInt32(0)
            colonias = dr.GetString(1)
            split2 = colonias.Split(";")
            For i As Integer = 0 To split2.Length - 1
                oCP = New CP
                oCP.colonia = split2(i)
                oCP.cp = dr.GetInt32(0)
                lstCP.Add(oCP)
            Next
        End While
        LiberarVariables()
        oCP = Nothing
        Return lstCP
    End Function

End Class

Public Class CP
    Dim colonia_, cp_ As String

    Public Property colonia() As String
        Get
            Return Me.colonia_
        End Get
        Set(ByVal Value As String)
            Me.colonia_ = Value
        End Set
    End Property

    Public Property cp() As String
        Get
            Return Me.cp_
        End Get
        Set(ByVal Value As String)
            Me.cp_ = Value
        End Set
    End Property
End Class
