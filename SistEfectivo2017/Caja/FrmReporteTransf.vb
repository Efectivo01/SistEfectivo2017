Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Printing
Public Class FrmReporteTransf
    Dim Reporte As New ReportDocument()
    Dim oReportesUnicosC As New ReportesUnicosC

    Public Suc As String
    Public Nombre_suc As String
    Dim fecha As Date

    Private Sub FrmReporteTransf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fecha = Now.ToShortDateString
        Me.Cursor = Cursors.WaitCursor
        If Reporte IsNot Nothing Then
            Reporte.Close()
            crvRptTrans.ReportSource = Nothing
        End If
        Reporte = New Traspasos2
        Reporte.SetDataSource(oReportesUnicosC.ReporteTraspaso_Det(Suc, fecha.ToString("dd/MM/yyyy"), fecha.ToString("dd/MM/yyyy")))
        Reporte.SetParameterValue("fecha1", fecha.ToString("dd/MM/yyyy"))
        Reporte.SetParameterValue("fecha2", fecha.ToString("dd/MM/yyyy"))
        Reporte.SetParameterValue("Sucursal", "Sucursal: " & Nombre_suc)
        crvRptTrans.ReportSource = Reporte
        Me.Cursor = Cursors.Default
    End Sub
End Class