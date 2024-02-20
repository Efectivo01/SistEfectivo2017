Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource

Public Class FrmEstadoCuenta
    Dim Reporte As New ReportDocument()
    Dim oPuntos As New CPuntos
    Public ECcliente As Integer
    Public ECnosucursal As String

    Private Sub FrmEstadoCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        If Reporte IsNot Nothing Then
            Reporte.Close()
            CrystalReportViewer1.ReportSource = Nothing
        End If
        Reporte = New ReporteEstCuen
        Reporte.SetDataSource(oPuntos.ReporteEstadoCuenta(ECcliente, ECnosucursal))
        CrystalReportViewer1.ReportSource = Reporte
        Me.Cursor = Cursors.Default
    End Sub
End Class