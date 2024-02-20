Imports System.Data.SqlClient
Imports System.Drawing

Public Class frmMetas
    Dim conn As New ConexionSQLS
    Private lector As SqlDataReader
    Private cmd, cmd2 As New SqlCommand
    Dim Cadena As String
    Public Sucursal As String
    Dim DiasMesAct As Integer
    Private Sub frmMetas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TotalOperaciones(String.Format("{0:0#}", Now.Month), Now.Year.ToString, Sucursal)
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdRefrescar_Click(sender As Object, e As EventArgs) Handles cmdRefrescar.Click
        TotalOperaciones(String.Format("{0:0#}", Now.Month), Now.Year.ToString, Sucursal)
    End Sub

    Private Sub TotalOperaciones(ByVal Mes As String, ByVal Anio As String, ByVal NoSucursal As String)
        Dim FechaCont As Date
        Dim UltimoDiaDelMes As Date
        Dim DiasInhabiles As Integer

        conn.EstablecerConexion()
        conn.AbrirConexion()
        Cadena = ""
        Cadena = Cadena & "Select * From BaseBonoHistoria "
        Cadena = Cadena & "Where Mes = '" & Mes & "' AND "
        Cadena = Cadena & "Anio = '" & Anio & "' AND "
        Select Case Sucursal
            Case "09"
                Cadena = Cadena & "Sucursal = '01'"
            Case "11"
                Cadena = Cadena & "Sucursal = '02'"
            Case "12"
                Cadena = Cadena & "Sucursal = '03'"
            Case Else
                Cadena = Cadena & "Sucursal = '" & Sucursal & "'"
        End Select

        cmd = New SqlCommand(Cadena, conn.con)
        lector = cmd.ExecuteReader

        While lector.Read
            txtEstMesC.Text = String.Format("{0:c}", lector(3))
            txtEstMesV.Text = String.Format("{0:c}", lector(4))
            If Sucursal = "12" Or Sucursal = "03" Or Sucursal = "05" Then
                txtMetaC.Text = String.Format("{0:c}", lector(3) * 1.12)
                txtMetaV.Text = String.Format("{0:c}", lector(4) * 1.12)
            Else
                txtMetaC.Text = String.Format("{0:c}", lector(3) * 1.08)
                txtMetaV.Text = String.Format("{0:c}", lector(4) * 1.08)
            End If
        End While
        lector.Close()

        UltimoDiaDelMes = DateSerial(Year(Now.Date), Month(Now.Date) + 1, 0)

        Cadena = ""
        Cadena = Cadena & "Select DiasInhabilesMes = COUNT(*) "
        Cadena = Cadena & "From Dias_Festivos "
        Cadena = Cadena & "Where Fecha Between '" & Format(Now.Date, "dd/MM/yyyy") & "' "
        Cadena = Cadena & "And '" & Format(UltimoDiaDelMes, "dd/MM/yyyy") & "' "
        Cadena = Cadena & "And Sucursal = '" & Sucursal & "'"

        cmd = New SqlCommand(Cadena, conn.con)
        lector = cmd.ExecuteReader
        DiasInhabiles = 0
        While lector.Read
            DiasInhabiles = lector(0)
        End While
        lector.Close()

        FechaCont = Now.Date
        While FechaCont <= UltimoDiaDelMes
            If Weekday(FechaCont) <> 7 Then
                DiasMesAct = DiasMesAct + 1
            End If
            FechaCont = DateAdd(DateInterval.Day, 1, FechaCont)
        End While
        DiasMesAct = DiasMesAct - DiasInhabiles

        cmd = New SqlCommand("sp_ComprasMes '" & Mes & "', '" & Anio & "', '" & Sucursal & "'", conn.con)
        lector = cmd.ExecuteReader
        While lector.Read
            txtAcumuladoC.Text = String.Format("{0:c}", lector(0))
        End While
        lector.Close()

        cmd = New SqlCommand("sp_VentaMes '" & Mes & "', '" & Anio & "', '" & Sucursal & "'", conn.con)
        lector = cmd.ExecuteReader
        While lector.Read
            txtAcumuladoV.Text = String.Format("{0:c}", lector(0))
        End While
        lector.Close()
        conn.CerrarConexion()

        txtVariacionC.Text = String.Format("{0:c}", CDbl(txtAcumuladoC.Text) - CDbl(txtMetaC.Text))
        txtVariacionV.Text = String.Format("{0:c}", CDbl(txtAcumuladoV.Text) - CDbl(txtMetaV.Text))

        If CDbl(txtVariacionC.Text) < 0 Then
            txtVariacionC.Text = String.Format("{0:c}", txtVariacionC.Text * -1)
            txtVariacionC.ForeColor = Color.Red
        Else
            txtVariacionC.ForeColor = Color.Green
        End If

        If CDbl(txtVariacionV.Text) < 0 Then
            txtVariacionV.Text = String.Format("{0:c}", txtVariacionV.Text * -1)
            txtVariacionV.ForeColor = Color.Red
        Else
            txtVariacionV.ForeColor = Color.Green
        End If
        txtMetaDiariaC.Text = String.Format("{0:c}", txtVariacionC.Text / DiasMesAct)
        txtMetaDiariaV.Text = String.Format("{0:c}", txtVariacionV.Text / DiasMesAct)
    End Sub
End Class