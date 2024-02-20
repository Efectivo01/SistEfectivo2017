Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmListados
    Public cual_reporte As String
    Public fecha1, fecha2 As Date
    Public Nombre_sucursal, No_sucursal As String

    Dim Reporte As New ReportDocument

    Private Sub FrmListados_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Reporte IsNot Nothing Then
            Reporte.Close()
            Reporte.Dispose()
            Me.Dispose()
        End If
    End Sub

    Private Sub FrmListados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case cual_reporte
            Case "lstcliente"
                Dim oclientescnbvC As New clientescnbvC
                Reporte = New LstClientesDia
                Reporte.SetDataSource(oclientescnbvC.RptClientesDia(fecha1.ToString("dd/MM/yyyy"), fecha2.ToString("dd/MM/yyyy"), No_sucursal))
                Reporte.SetParameterValue("fecha1", fecha1.ToString("dd/MM/yyyy"))
                Reporte.SetParameterValue("fecha2", fecha2.ToString("dd/MM/yyyy"))
                Reporte.SetParameterValue("Sucursal", Nombre_sucursal)
                CrystalReportViewer1.ReportSource = Reporte
                oclientescnbvC.Dispose()
        End Select
    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        Dim oclientescnbvC As New clientescnbvC
        fecha1 = dtpFecha1.Text
        fecha2 = dtpFecha2.Text
        If oclientescnbvC.RptClientesDia2(fecha1.ToString("dd/MM/yyyy"), fecha2.ToString("dd/MM/yyyy"), No_sucursal) > 0 Then 
            If Reporte IsNot Nothing Then
                Reporte.Close()
            End If
            Reporte = New LstClientesDia
            Reporte.SetDataSource(oclientescnbvC.RptClientesDia(fecha1.ToString("dd/MM/yyyy"), fecha2.ToString("dd/MM/yyyy"), No_sucursal))
            Reporte.SetParameterValue("fecha1", fecha1.ToString("dd/MM/yyyy"))
            Reporte.SetParameterValue("fecha2", fecha2.ToString("dd/MM/yyyy"))
            Reporte.SetParameterValue("Sucursal", Nombre_sucursal)
            CrystalReportViewer1.ReportSource = Reporte
            oclientescnbvC.Dispose()
        Else
            MsgBox("No Hay Clientes Dados de Alta", MsgBoxStyle.Information)
        End If
        
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BTNFOLIOS_Click(sender As Object, e As EventArgs) Handles BTNFOLIOS.Click
        fecha1 = dtpFecha1.Text
        fecha2 = dtpFecha2.Text
        If Reporte IsNot Nothing Then
            Reporte.Close()
        End If
        Dim OReportesUnicosC As New ReportesUnicosC
        Reporte = New foliosDnotas
        Reporte.SetDataSource(OReportesUnicosC.folio_rpt(No_sucursal, fecha1.ToString("dd/MM/yyyy"), fecha2.ToString("dd/MM/yyyy")))
        Reporte.SetParameterValue("fecha1", fecha1.ToString("dd/MM/yyyy"))
        Reporte.SetParameterValue("fecha2", fecha2.ToString("dd/MM/yyyy"))
        Reporte.SetParameterValue("Sucursal", Nombre_sucursal)
        CrystalReportViewer1.ReportSource = Reporte
        OReportesUnicosC.Dispose()
    End Sub

    Private Sub btnduplica2_Click(sender As Object, e As EventArgs) Handles btnduplica2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim oclientesduplicadosC As New clientesduplicadosC
        'Dim dtdupli, dtdupli2 As DataTable
        Dim oclientescnbvC As New clientescnbvC
        Dim nombre, apeP, apeM As String
        Dim No As Integer
        nombre = ""
        apeP = ""
        apeM = ""
        No = 0
        'Dim ap, am, nom As String
        'oclientesduplicadosC.Elimina()
        'dtdupli = oclientescnbvC.clientesDuplicados1
        'oclientescnbvC.LiberarDt()
        'For x As Integer = 0 To dtdupli.Rows.Count - 1
        '    dtdupli2 = oclientescnbvC.clientesDuplicados2(dtdupli.Rows(x)("Nombre").ToString, dtdupli.Rows(x)("ApellidoPaterno").ToString, dtdupli.Rows(x)("ApellidoMaterno").ToString)
        '    nom = dtdupli.Rows(x)("Nombre").ToString
        '    ap = dtdupli.Rows(x)("ApellidoPaterno").ToString
        '    am = dtdupli.Rows(x)("ApellidoMaterno").ToString
        '    If dtdupli2.Rows.Count >= 1 Then
        '        For z As Integer = 0 To dtdupli2.Rows.Count - 1
        '            No = Convert.ToInt32(dtdupli2.Rows(z)("cliente").ToString())
        '            nombre = dtdupli2.Rows(z)("Nombre").ToString
        '            apeP = dtdupli2.Rows(z)("ApellidoPaterno").ToString
        '            apeM = dtdupli2.Rows(z)("ApellidoMaterno").ToString
        '            If nombre <> "" And (apeP <> "" Or apeM <> "") Then
        '                oclientesduplicadosC.Alta(No, apeP, apeM, nombre)
        '            End If
        '        Next
        '    End If
        '    oclientescnbvC.LiberarDt()
        'Next

        'If Reporte IsNot Nothing Then
        '    Reporte.Close()
        'End If
        'Reporte = New cliDuplica2
        'Reporte.SetDataSource(oclientesduplicadosC.RptcliDuplicados)
        'CrystalReportViewer1.ReportSource = Reporte
        'Me.Cursor = Cursors.Default

        If Reporte IsNot Nothing Then
            Reporte.Close()
        End If
        Reporte = New cliDuplica2
        Reporte.SetDataSource(oclientescnbvC.clientesDuplicados1)
        CrystalReportViewer1.ReportSource = Reporte
        Me.Cursor = Cursors.Default
    End Sub
End Class