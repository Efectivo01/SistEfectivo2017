Imports System.IO

Public Class FrmMostrarNota
    Dim nota As Notacv
    Dim oReportesUnicosC As ReportesUnicosC
    Public folio_buscar As Integer = 0
    Public cliente_buscar As Integer = 0
    Public Nosucursal As String

    Private Sub FrmMostrarNota_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oReportesUnicosC.Dispose()
        nota.Close()
        nota.Dispose()
    End Sub

    Private Sub FrmMostrarNota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            For Each fichero As String In Directory.GetFiles(Path.GetTempPath(), "*.rpt")
                File.Delete(fichero)
            Next
        Catch ex As Exception
        End Try

        nota = New Notacv
        oReportesUnicosC = New ReportesUnicosC
        nota.SetDataSource(oReportesUnicosC.ImprimeNota22(cliente_buscar, folio_buscar, Nosucursal))
        visor.ReportSource = nota
        oReportesUnicosC.LiberarDS()
        Me.Cursor = Cursors.Default
    End Sub
End Class