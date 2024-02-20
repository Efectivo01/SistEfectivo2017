﻿Imports System.Data.SQLite
Imports System.Data.SqlClient

Public Class tinventario2C
    Implements IDisposable
    Dim con As ConexionSQLite
    Dim ds As DataSet
    Dim sql, where, strSet, execute As String
    Dim cmd As SQLiteCommand
    Dim da As SQLiteDataAdapter
    Dim dr As SQLiteDataReader
    Dim abc As Double = 0
    Dim lst As List(Of tinventarioM)
    Dim dt As DataTable
    Dim disposed As Boolean = False
    Public No As String

    Public tinventario2C()

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
        con = New ConexionSQLite
        cmd = New SQLiteCommand
        sql = ""
        where = ""
        strSet = ""
        execute = ""
        abc = 0
    End Sub

    Private Sub CargarVariablesDS()
        ds = New DataSet
        da = New SQLiteDataAdapter
    End Sub

    Private Sub CargarVariablesDt()
        da = New SQLiteDataAdapter
        dt = New DataTable
    End Sub

    Private Sub CargarVariableLst()
        lst = New List(Of tinventarioM)
    End Sub

    Private Sub AccesoDatos()
        cmd.Connection = con.EstablecerConexion()
        con.AbrirConexion()
        cmd.Connection.CreateCommand()
        cmd.CommandText = sql & strSet & where
    End Sub

    Private Function EjecutarABC() As Integer
        If cmd.ExecuteNonQuery() <= 0 Then
            Return 0
        End If
        Return 1
    End Function

    Private Sub EjecutarCantidades()
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

    Public Sub LiberarLst()
        lst = Nothing
    End Sub
#End Region

    Public Function Alta(ByVal data As tinventarioM) As Integer
        CargarVariables()
        cmd.Parameters.AddWithValue("codigo", data.codigo)
        cmd.Parameters.AddWithValue("si", data.si)
        cmd.Parameters.AddWithValue("en", data.en)
        cmd.Parameters.AddWithValue("sal", data.sal)
        cmd.Parameters.AddWithValue("sf", data.sf)
        cmd.Parameters.AddWithValue("cpromedio", data.cpromedio)
        cmd.Parameters.AddWithValue("te", data.te)
        cmd.Parameters.AddWithValue("ts", data.ts)

        sql = "INSERT INTO tinventario(codigo,si,en,sal,sf,cpromedio,te,ts)VALUES" &
            "(?,?,?,?,?,?,?,?)"

        'cmd.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = data.codigo
        'cmd.Parameters.Add("@si", SqlDbType.NVarChar).Value = data.si
        'cmd.Parameters.Add("@en", SqlDbType.Real).Value = data.en
        'cmd.Parameters.Add("@sal", SqlDbType.Real).Value = data.sal
        'cmd.Parameters.Add("@sf", SqlDbType.Real).Value = data.sf
        'cmd.Parameters.Add("@cpromedio", SqlDbType.Real).Value = data.cpromedio
        'cmd.Parameters.Add("@te", SqlDbType.Float).Value = data.te
        'cmd.Parameters.Add("@ts", SqlDbType.Float).Value = data.ts

        'sql = "INSERT INTO tinventario(codigo,si,en,sal,sf,cpromedio,te,ts)VALUES" &
        '    "(@codigo,@si,@en,@sal,@sf,@cpromedio,@te,@ts)"

        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Elimina(ByVal data As tinventarioM) As Integer
        CargarVariables()
        sql = "DELETE FROM tinventario WHERE codigo=?"
        cmd.Parameters.AddWithValue("codigo", data.codigo)
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Modifica1(ByVal data As tinventarioM, ByVal data2 As tinventarioM) As Integer
        CargarVariables()
        sql = "update tinventario set "

        If data.codigo <> data2.codigo And data.codigo <> Nothing Then
            strSet += "codigo=? ,"
            cmd.Parameters.AddWithValue("codigo", data.codigo)
        End If

        If data.si <> data2.si And data.si <> Nothing Then
            strSet += "si=? ,"
            cmd.Parameters.AddWithValue("si", data.si)
        End If

        If data.en <> data2.en And data.en <> Nothing Then
            strSet += "en=? ,"
            cmd.Parameters.AddWithValue("en", data.en)
        End If

        If data.sal <> data2.sal And data.sal <> Nothing Then
            strSet += "sal=? ,"
            cmd.Parameters.AddWithValue("sal", data.sal)
        End If

        If data.sf <> data2.sf And data.sf <> Nothing Then
            strSet += "sf=? ,"
            cmd.Parameters.AddWithValue("sf", data.sf)
        End If

        If data.cpromedio <> data2.cpromedio And data.cpromedio <> Nothing Then
            strSet += "cpromedio=? ,"
            cmd.Parameters.AddWithValue("cpromedio", data.cpromedio)
        End If

        If data.te <> data2.te And data.te <> Nothing Then
            strSet += "te=? ,"
            cmd.Parameters.AddWithValue("te", data.te)
        End If

        If data.ts <> data2.ts And data.ts <> Nothing Then
            strSet += "ts=? ,"
            cmd.Parameters.AddWithValue("ts", data.ts)
        End If

        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += "where codigo=?"
        cmd.Parameters.AddWithValue("codigo2", data2.codigo)
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function Modifica2(ByVal data As tinventarioM) As Integer
        CargarVariables()
        sql = "update tinventario set "

        'If data.codigo <> Nothing Then
        '    strSet += "codigo=? ,"
        '    cmd.Parameters.AddWithValue("codigo", data.codigo)
        'End If

        If data.si <> Nothing Then
            strSet += "si=? ,"
            cmd.Parameters.AddWithValue("si", data.si)
        End If

        If data.en <> Nothing Then
            strSet += "en=? ,"
            cmd.Parameters.AddWithValue("en", data.en)
        End If

        If data.sal <> Nothing Then
            strSet += "sal=? ,"
            cmd.Parameters.AddWithValue("sal", data.sal)
        End If

        If data.sf <> Nothing Then
            strSet += "sf=? ,"
            cmd.Parameters.AddWithValue("sf", data.sf)
        End If

        If data.cpromedio <> Nothing Then
            strSet += "cpromedio=? ,"
            cmd.Parameters.AddWithValue("cpromedio", data.cpromedio)
        End If

        If data.te <> Nothing Then
            strSet += "te=? ,"
            cmd.Parameters.AddWithValue("te", data.te)
        End If

        If data.ts <> Nothing Then
            strSet += "ts=? ,"
            cmd.Parameters.AddWithValue("ts", data.ts)
        End If

        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += "where codigo=?"
        cmd.Parameters.AddWithValue("codigo", data.codigo)
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function AsignaFecha(ByVal fecha As Date) As Integer
        CargarVariables()
        sql = "update tinventario set fecha=?"
        cmd.Parameters.AddWithValue("fecha", fecha.ToString("dd/MM/yyyy"))
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function CambiaSiporSF() As Integer
        CargarVariables()
        sql = "update tinventario set si=sf,en=0,sal=0,te=0,ts=0"
        AccesoDatos()
        abc = EjecutarABC()
        LiberarVariables()
        Return abc
    End Function

    Public Function VerificarRegistros() As Integer
        CargarVariables()
        sql = "select COUNT(*) from tinventario"
        AccesoDatos()
        abc = Convert.ToInt32(cmd.ExecuteScalar().ToString())
        LiberarVariables()
        Return abc
    End Function

    Public Function VerificarFecha() As Date
        CargarVariables()
        sql = "select distinct(fecha) from tinventario;"
        AccesoDatos()
        Dim execute As String
        execute = cmd.ExecuteScalar().ToString()
        If execute Is Nothing Or execute = "NULL" Or execute = "" Then
            execute = Date.Now.ToShortDateString
        Else
            execute = Convert.ToDateTime(execute)
        End If
        LiberarVariables()
        Return execute
    End Function

    Public Function si(ByVal codigo As String) As Double
        CargarVariables()
        sql = "select si from tinventario where codigo='" & codigo & "';"
        AccesoDatos()
        EjecutarCantidades()
        LiberarVariables()
        Return abc
    End Function

    Public Function Existencia() As DataTable
        CargarVariables()
        CargarVariablesDt()
        sql = "select codigo,si,sf from tinventario"
        AccesoDatos()
        RecopilarDatosDt()
        'MessageBox.Show(dt.Rows.Count.ToString & "" & sql & where)
        LiberarVariables()
        Return dt
    End Function

    Public Function Selecciona(ByVal data As tinventarioM) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, "", "", False)
        sql = "SELECT * FROM tinventario"

        If data.codigo <> Nothing Then
            where = where + "codigo=? and"
            cmd.Parameters.AddWithValue("codigo", data.codigo)
        End If

        If where.Trim().Length > 0 Then
            where = " where " & where.Remove(where.Length - 3, 3)
        End If
        'where += " order by tipo;"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function SeleccionaTodo() As DataSet
        CargarVariables()
        CargarVariablesDS()
        sql = "SELECT * FROM tinventario;"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function


    Public Function Filtra(ByVal data As tinventarioM, ByVal a As String, ByVal b As String) As DataSet
        CargarVariables()
        CargarVariablesDS()
        maswhere(data, a, b, True)
        sql = "SELECT * FROM tinventario"
        If Not data.codigo Is Nothing Then
            where = where & " where codigo like '" & b & "?" & a & "'"
            cmd.Parameters.AddWithValue("codigo", data.codigo).Value = data.codigo
        End If
        'where += " order by codigo;"
        AccesoDatos()
        RecopilarDatos()
        LiberarVariables()
        Return ds
    End Function

    Public Function Filtrar(ByVal data As tinventarioM, ByVal a As String, ByVal b As String) As DataTable
        CargarVariables()
        CargarVariablesDt()
        maswhere(data, a, b, True)
        sql = "SELECT * FROM tinventario"
        AccesoDatos()
        RecopilarDatosDt()
        'MessageBox.Show(dt.Rows.Count.ToString & "" & sql & where)
        LiberarVariables()
        Return dt
    End Function

    Public Function SeleccionaTodo(ByVal data As tinventarioM) As List(Of tinventarioM)
        CargarVariables()
        sql = "Select * from tinventario;"
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            data = New tinventarioM()
            data.codigo = dr.GetString(0)
            data.si = dr.GetDouble(1)
            data.en = dr.GetDouble(2)
            data.sal = dr.GetDouble(3)
            data.sf = dr.GetDouble(4)
            data.cpromedio = dr.GetDouble(5)
            data.te = dr.GetDouble(6)
            data.ts = dr.GetDouble(7)
            lst.Add(data)
        End While
        LiberarVariables()
        Return lst
    End Function

    Public Function Selecciona1(ByVal data As tinventarioM) As tinventarioM
        CargarVariables()
        maswhere(data, "", "", False)
        sql = " SELECT * FROM tinventario "
        If Not data.codigo Is Nothing Then
            sql = sql & " where codigo='" & "?" & "'"
            cmd.Parameters.AddWithValue("codigo", data.codigo)
        End If
        AccesoDatos()
        dr = cmd.ExecuteReader()
        While dr.Read()
            data.codigo = dr.GetString(0)
            data.si = dr.GetDouble(1)
            data.en = dr.GetDouble(2)
            data.sal = dr.GetDouble(3)
            data.sf = dr.GetDouble(4)
            data.cpromedio = dr.GetDouble(5)
            data.te = dr.GetDouble(6)
            data.ts = dr.GetDouble(7)
            Exit While
        End While
        LiberarVariables()
        Return data
    End Function

    Private Sub maswhere(ByVal data As tinventarioM, ByVal a As String, ByVal b As String, ByVal likeoigual As Boolean)
        Dim operador As String = ""
        Select Case likeoigual
            Case True
                operador = " like "
            Case False
                operador = "="
        End Select

        If Not data.codigo Is Nothing Then
            where = where & " codigo" & operador & " '" & b & "'+?+'" & a & "' and"
            cmd.Parameters.AddWithValue("codigo", data.codigo)
        End If

        If where.Trim.Length > 0 Then
            where = " WHERE " & where.Remove(where.Length - 3, 3)
        End If
        'where += " order by codigo"
    End Sub


    Public Function RptTipado() As DataSet
        Dim oReportetinventarioDs As ReporteDivisasDs = New ReporteDivisasDs()
        CargarVariables()
        da = New SQLiteDataAdapter
        sql = "SELECT * FROM tinventario;"
        cmd = New SQLiteCommand(sql, con.EstablecerConexion())
        con.AbrirConexion()
        da.SelectCommand = cmd
        da.Fill(oReportetinventarioDs, "tinventario")
        sql = "SELECT * FROM divisas"
        Dim consql As New ConexionSQLS
        Dim cmdsql As New SqlCommand(sql, consql.EstablecerConexion())
        consql.AbrirConexion()
        Dim dasql As New SqlDataAdapter
        dasql.SelectCommand = cmdsql
        dasql.Fill(oReportetinventarioDs, "divisas")
        LiberarVariables()
        cmdsql.Connection.Close()
        consql.CerrarConexion()
        dasql = Nothing
        cmdsql = Nothing
        Return oReportetinventarioDs
    End Function

    Public Sub EliminaInventario()
        CargarVariables()
        sql = "delete from tinventario"
        AccesoDatos()
        cmd.ExecuteNonQuery()
        LiberarVariables()
    End Sub
End Class
