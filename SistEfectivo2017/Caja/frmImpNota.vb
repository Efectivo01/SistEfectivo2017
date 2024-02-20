Imports CrystalDecisions.CrystalReports.Engine
Public Class frmImpNota
    Dim oReportesUnicosC As New ReportesUnicosC
    Dim Reporte As New ReportDocument()
    Public Cliente, Folio, Sucursal As String
    Private Sub crReporte_Load(sender As Object, e As EventArgs) Handles crReporte.Load
        If Reporte IsNot Nothing Then
            Reporte.Close()
            crReporte.ReportSource = Nothing
        End If

        Reporte = New Notacv
        Reporte.SetDataSource(oReportesUnicosC.RptNota2(Folio, Sucursal))
        crReporte.ReportSource = Reporte
    End Sub
End Class