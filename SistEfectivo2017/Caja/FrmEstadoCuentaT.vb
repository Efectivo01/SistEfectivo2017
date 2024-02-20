Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Drawing.Printing

Public Class FrmEstadoCuentaT
    Dim Reporte As New ReportDocument()
    Dim oPuntos As New CPuntos
    Public ECcliente As Integer
    Public ECnosucursal As String
    Dim Impresora1, Impresora2 As String
    Dim ImpresoraCarta As String = "HP"

    Private Sub FrmEstadoCuentaT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        If Reporte IsNot Nothing Then
            Reporte.Close()
            CrystalReportViewer1.ReportSource = Nothing
        End If
        ImpresoraName()
        Reporte = New ReporteEstCuenTick
        Reporte.SetDataSource(oPuntos.ReporteEstadoCuenta(ECcliente, ECnosucursal))
        'CrystalReportViewer1.ReportSource = Reporte
        'Me.Cursor = Cursors.Default
        Reporte.PrintOptions.PrinterName = Impresora1
        Reporte.PrintToPrinter(1, False, 0, 0)
        Me.Close()
    End Sub

    Private Sub ImpresoraName()
        Dim a As PrinterSettings = New PrinterSettings()
        For i As Integer = 0 To PrinterSettings.InstalledPrinters.Count - 1 Step i + 1
            a.PrinterName = PrinterSettings.InstalledPrinters(i).ToString()
            If a.IsDefaultPrinter Then
                Impresora1 = PrinterSettings.InstalledPrinters(i).ToString()
            End If
            If PrinterSettings.InstalledPrinters(i).ToString.Contains(ImpresoraCarta) Then
                Impresora2 = PrinterSettings.InstalledPrinters(i).ToString()
            End If
        Next
    End Sub
End Class