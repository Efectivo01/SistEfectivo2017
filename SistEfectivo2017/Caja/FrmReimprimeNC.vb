Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Drawing.Printing

Public Class FrmReimprimeNC
    Public FolioReNC As String
    Public SucNC As String
    Public ClienteNC As Integer
    Dim oReportesUnicosC As New ReportesUnicosC
    Dim Reporte As New ReportDocument()
    Dim Impresora1, Impresora2 As String
    Dim ImpresoraCarta As String = "HP" 'sepuede quitar

    Private Sub FrmReimprimeNC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ImpresoraName()
        Me.Cursor = Cursors.WaitCursor
        If Reporte IsNot Nothing Then
            Reporte.Close()
            CrystalReportViewer1.ReportSource = Nothing
        End If
        Reporte = New NotaCreditoN
        Reporte.SetDataSource(oReportesUnicosC.ImprimeNotaPuntos(ClienteNC, FolioReNC, SucNC))
        CrystalReportViewer1.ReportSource = Reporte
        Me.Cursor = Cursors.Default

        'Dim NotaC As Integer
        'NotaC = FolioNC(txtFolio.Text.Trim, No_sucursal)
        'Reporte = New NotaCreditoV
        'Reporte.SetDataSource(oReportesUnicosC.ImprimeNotaPuntosVenta2(txtFolio.Text.Trim, No_sucursal, NotaC))
        'CrystalReportViewer1.ReportSource = Reporte
        'Me.Cursor = Cursors.Default

        Dim Nota3 = New NotaCreditoN
        Dim datosdsc2 As New DataSet
        datosdsc2 = oReportesUnicosC.ImprimeNotaPuntos(ClienteNC, FolioReNC, SucNC)
        Nota3.SetDataSource(datosdsc2)
        Nota3.PrintOptions.PrinterName = Impresora1
        Nota3.PrintToPrinter(1, False, 0, 0)

        Dim Nota4 = New NotaCreditoV
        Dim datosdsc3 As New DataSet
        datosdsc3 = oReportesUnicosC.ImprimeNotaPuntosVenta(ClienteNC, FolioReNC, SucNC)
        Nota4.SetDataSource(datosdsc3)
        Nota4.PrintOptions.PrinterName = Impresora1
        Nota4.PrintToPrinter(1, False, 0, 0)

        Nota4.Close()
        Nota4.Dispose()
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