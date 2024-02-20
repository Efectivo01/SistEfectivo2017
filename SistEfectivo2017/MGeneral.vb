Imports System.Data
Imports System.Data.SqlClient

Module MGeneral
    Dim file As System.IO.StreamReader
    Dim cs As String = ""

    Public cone As SqlConnection
    Private lector As SqlDataReader
    Private cmd, cmd2 As New SqlCommand

    Public Function Conexion() As SqlConnection
        Try
            file = New System.IO.StreamReader("servidor.txt")
            cs = file.ReadLine
            file.Close()
            cone = New SqlConnection(cs)
        Catch exc As Exception
            MessageBox.Show("Error en la cadena de conexion")
        End Try

        Return cone
    End Function
    Public Function seguiente_folio(ByVal Tabla As String)
        Dim dato As Integer = 0
        Try
            Conexion()
            cone.Open()

            Dim consulta As String = "select ultimo_folio+1 as folios from folios where tipo_folio = '" & Tabla & "'"

            cmd = New SqlCommand(consulta, cone)
            lector = cmd.ExecuteReader
            While lector.Read
                dato = lector("folios")
            End While
            cone.Close()
            If dato > 0 Then
                cone.Open()
                Dim consulta2 As String = "update folios set ultimo_folio = " & dato & "  where tipo_folio = '" & Tabla & "'"
                cmd2 = New SqlCommand(consulta2, cone)
                cmd2.ExecuteNonQuery()
                cone.Close()
            End If
            Return dato
        Catch ex As Exception
            cone.Close()
            Return 0
        End Try
    End Function

    Public Function ProcesoCambio(ByVal folio As String, ByVal sucursal As String) As Boolean
        Dim dato As Boolean = False
        Try
            Conexion()
            cone.Open()

            Dim consulta As String = "select * from remisioCA where folio_factura = '" & folio & "' and Nosucursal = '" & sucursal & "'"

            cmd = New SqlCommand(consulta, cone)
            lector = cmd.ExecuteReader
            While lector.Read
                dato = True
            End While
            cone.Close()

            Return dato
        Catch ex As Exception
            cone.Close()
            Return dato
        End Try
    End Function
    Public Function ProcesoPuntos(ByVal folio As String, ByVal sucursal As String) As Boolean
        Dim dato As Boolean = False
        Try
            Conexion()
            cone.Open()

            Dim consulta As String = "select * from Nota_Credito where folio_factura = '" & folio & "' and Nosucursal = '" & sucursal & "'"

            cmd = New SqlCommand(consulta, cone)
            lector = cmd.ExecuteReader
            While lector.Read
                dato = True
            End While
            cone.Close()

            Return dato
        Catch ex As Exception
            cone.Close()
            Return dato
        End Try
    End Function

    Public Function FolioNC(ByVal factura As String, ByVal sucursal As String) As Integer
        Dim dato As Integer = 0
        Try
            Conexion()
            cone.Open()

            Dim consulta As String = "SELECT folio_NC FROM Nota_Credito where folio_factura = '" & factura & "' and nosucursal = '" & sucursal & "' "

            cmd = New SqlCommand(consulta, cone)
            lector = cmd.ExecuteReader
            While lector.Read
                dato = lector("folio_NC")
            End While
            cone.Close()

            Return dato
        Catch ex As Exception
            MsgBox("Error: " & vbCrLf & ex.Message)
            cone.Close()
            Return dato
        End Try
    End Function

    Public Function PrecioVenta(ByVal sucursal As String) As Double
        Dim dato As Double = 0
        Try
            Conexion()
            cone.Open()

            Dim consulta As String = "select Venta from tipodivisas where nosucursal = '" & sucursal & "' and tipo = 1 "

            cmd = New SqlCommand(consulta, cone)
            lector = cmd.ExecuteReader
            While lector.Read
                dato = lector("Venta")
            End While
            cone.Close()

            Return dato
        Catch ex As Exception
            MsgBox("Error: " & vbCrLf & ex.Message)
            cone.Close()
            Return dato
        End Try
    End Function

    Public Function PrecioCompra(ByVal sucursal As String) As Double
        Dim dato As Double = 0
        Try
            Conexion()
            cone.Open()

            Dim consulta As String = "select Compra from tipodivisas where nosucursal = '" & sucursal & "' and tipo = 1 "

            cmd = New SqlCommand(consulta, cone)
            lector = cmd.ExecuteReader
            While lector.Read
                dato = lector("Compra")
            End While
            cone.Close()

            Return dato
        Catch ex As Exception
            MsgBox("Error: " & vbCrLf & ex.Message)
            cone.Close()
            Return dato
        End Try
    End Function


End Module
