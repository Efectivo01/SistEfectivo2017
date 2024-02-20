Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Printing
Imports System.Drawing

Public Class FrmMostrarReporte
    'instancias
    Dim Reporte As New ReportDocument()
    Dim oCAJAC As CAJAC
    Dim omovimientosC As movimientosC

    Dim ocaja_diarioM As caja_diarioM
    Dim ocaja_diario2C As caja_diario2C
    Dim otinventario2C As tinventario2C

    'Dim ocaja_diarioC As New caja_diarioC
    Dim oReportesUnicosC As ReportesUnicosC
    'variables
    'Public que_reporte As String
    Public No_sucursal As String
    Public Nombre_sucursal As String
    Public Sistemas As String
    Dim Impresora1, Impresora2 As String
    Dim ImpresoraCarta As String = "HP"
    Dim INICIAL As Double = 0

    'UTIMOS AGREGADOS
    Dim oExistenciaC As New ExistenciaC
    Dim opuntos As New CPuntos

    Private Sub FrmMostrarReporte_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        LiberarInstancias()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FrmMostrarReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Focus()
        CrearInstancias()
        crv.Width = (Me.Width - Panel1.Width) - 10
        crv.Height = Me.Height
    End Sub

    Private Sub CrearInstancias()
        oCAJAC = New CAJAC
        omovimientosC = New movimientosC

        ocaja_diarioM = New caja_diarioM
        ocaja_diario2C = New caja_diario2C
        otinventario2C = New tinventario2C

        oReportesUnicosC = New ReportesUnicosC
    End Sub

    Private Sub LiberarInstancias()
        If Reporte IsNot Nothing Then
            crv.ReportSource = Nothing
            Reporte.Close()
            Reporte.Dispose()
        End If

        If oCAJAC IsNot Nothing Then
            oCAJAC.Dispose()
        End If
        If omovimientosC IsNot Nothing Then
            omovimientosC.Dispose()
        End If
        ocaja_diarioM = Nothing
        If ocaja_diario2C IsNot Nothing Then
            ocaja_diario2C.Dispose()
        End If

        If oReportesUnicosC IsNot Nothing Then
            oReportesUnicosC.Dispose()
        End If

        If oExistenciaC IsNot Nothing Then
            oExistenciaC.Dispose()
        End If
    End Sub

#Region "Botones Colores"

    Private Sub btn1_MouseDown(sender As Object, e As MouseEventArgs) Handles btn1.MouseDown
        btn1.BackColor = Color.GhostWhite
    End Sub

    Private Sub btn1_MouseHover(sender As Object, e As EventArgs) Handles btn1.MouseHover
        btn1.BackColor = Color.Crimson
    End Sub

    Private Sub btn1_MouseLeave(sender As Object, e As EventArgs) Handles btn1.MouseLeave
        btn1.BackColor = Color.Goldenrod
    End Sub

    Private Sub btn2_MouseDown(sender As Object, e As MouseEventArgs) Handles btn2.MouseDown
        btn2.BackColor = Color.GhostWhite
    End Sub

    Private Sub btn2_MouseHover(sender As Object, e As EventArgs) Handles btn2.MouseHover
        btn2.BackColor = Color.Crimson
    End Sub

    Private Sub btn2_MouseLeave(sender As Object, e As EventArgs) Handles btn2.MouseLeave
        btn2.BackColor = Color.Goldenrod
    End Sub

    Private Sub btn3_MouseDown(sender As Object, e As MouseEventArgs) Handles btn3.MouseDown
        btn3.BackColor = Color.GhostWhite
    End Sub

    Private Sub btn3_MouseHover(sender As Object, e As EventArgs) Handles btn3.MouseHover
        btn3.BackColor = Color.Crimson
    End Sub

    Private Sub btn3_MouseLeave(sender As Object, e As EventArgs) Handles btn3.MouseLeave
        btn3.BackColor = Color.Goldenrod
    End Sub

    Private Sub btn4_MouseDown(sender As Object, e As MouseEventArgs) Handles btn4.MouseDown
        btn4.BackColor = Color.GhostWhite
    End Sub

    Private Sub btn4_MouseHover(sender As Object, e As EventArgs) Handles btn4.MouseHover
        btn4.BackColor = Color.Crimson
    End Sub

    Private Sub btn4_MouseLeave(sender As Object, e As EventArgs) Handles btn4.MouseLeave
        btn4.BackColor = Color.Goldenrod
    End Sub

    Private Sub Btn6_MouseDown(sender As Object, e As MouseEventArgs) Handles Btn6.MouseDown
        Btn6.BackColor = Color.GhostWhite
    End Sub

    Private Sub Btn6_MouseHover(sender As Object, e As EventArgs) Handles Btn6.MouseHover
        Btn6.BackColor = Color.Crimson
    End Sub

    Private Sub Btn6_MouseLeave(sender As Object, e As EventArgs) Handles Btn6.MouseLeave
        Btn6.BackColor = Color.Goldenrod
    End Sub

    Private Sub btn5_MouseDown(sender As Object, e As MouseEventArgs) Handles btn5.MouseDown
        btn5.BackColor = Color.GhostWhite
    End Sub

    Private Sub btn5_MouseHover(sender As Object, e As EventArgs) Handles btn5.MouseHover
        btn5.BackColor = Color.Crimson
    End Sub

    Private Sub btn5_MouseLeave(sender As Object, e As EventArgs) Handles btn5.MouseLeave
        btn5.BackColor = Color.Goldenrod
    End Sub

    Private Sub Btn7_MouseDown(sender As Object, e As MouseEventArgs) Handles Btn7.MouseDown
        Btn7.BackColor = Color.GhostWhite
    End Sub

    Private Sub Btn7_MouseHover(sender As Object, e As EventArgs) Handles Btn7.MouseHover
        Btn7.BackColor = Color.Crimson
    End Sub

    Private Sub Btn7_MouseLeave(sender As Object, e As EventArgs) Handles Btn7.MouseLeave
        Btn7.BackColor = Color.Goldenrod
    End Sub

    Private Sub Btn8_MouseDown(sender As Object, e As MouseEventArgs) Handles Btn8.MouseDown
        Btn8.BackColor = Color.GhostWhite
    End Sub

    Private Sub Btn8_MouseHover(sender As Object, e As EventArgs) Handles Btn8.MouseHover
        Btn8.BackColor = Color.Crimson
    End Sub

    Private Sub Btn8_MouseLeave(sender As Object, e As EventArgs) Handles Btn8.MouseLeave
        Btn8.BackColor = Color.Goldenrod
    End Sub
#End Region


#Region "Botones Click"
    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        If dtpFecha.Value.ToString("dd/MM/yyyy") = Now.ToString("dd/MM/yyyy") Or Sistemas = "SQUIJANO" Then
            Me.Cursor = Cursors.WaitCursor
            If Reporte IsNot Nothing Then
                Reporte.Close()
                crv.ReportSource = Nothing
            End If
            Reporte = New FlujoCompras
            Reporte.SetDataSource(omovimientosC.ReporteMovimientos("COMPRA", No_sucursal, dtpFecha.Value.ToString("dd/MM/yyyy")))
            Reporte.SetParameterValue("fecha1", dtpFecha.Value.ToString("dd/MM/yyyy"))
            Reporte.SetParameterValue("Sucursal", "Sucursal: " & Nombre_sucursal)
            crv.ReportSource = Reporte
            Me.Cursor = Cursors.Default
        Else
            MsgBox("No se puede Generar de Dias Anterior", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        If dtpFecha.Value.ToString("dd/MM/yyyy") = Now.ToString("dd/MM/yyyy") Or Sistemas = "SQUIJANO" Then
            Me.Cursor = Cursors.WaitCursor
            If Reporte IsNot Nothing Then
                Reporte.Close()
                crv.ReportSource = Nothing
            End If
            Reporte = New FlujoVentas
            Reporte.SetDataSource(omovimientosC.ReporteMovimientos("VENTA", No_sucursal, dtpFecha.Value.ToString("dd/MM/yyyy")))
            Reporte.SetParameterValue("fecha1", dtpFecha.Value.ToString("dd/MM/yyyy"))
            Reporte.SetParameterValue("Sucursal", "Sucursal: " & Nombre_sucursal)
            crv.ReportSource = Reporte
            Me.Cursor = Cursors.Default
        Else
            MsgBox("No se puede Generar de Dias Anterior", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        If dtpFecha.Value.ToString("dd/MM/yyyy") = Now.ToString("dd/MM/yyyy") Or Sistemas = "SQUIJANO" Then
            Me.Cursor = Cursors.WaitCursor
            If Reporte IsNot Nothing Then
                Reporte.Close()
                crv.ReportSource = Nothing
            End If
            Caja()
            Reporte = New repcaja
            Reporte.SetDataSource(ocaja_diario2C.RptCAJA(No_sucursal, dtpFecha.Value.ToString("dd/MM/yyyy")))
            Reporte.SetParameterValue("Sucursal", Nombre_sucursal)
            crv.ReportSource = Reporte
            Me.Cursor = Cursors.Default
        Else
            MsgBox("No se puede Generar de Dias Anterior", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        Me.Cursor = Cursors.WaitCursor
        ImprimirReporteInventario2()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Btn6_Click(sender As Object, e As EventArgs) Handles Btn6.Click
        If dtpFecha.Value.ToString("dd/MM/yyyy") = Now.ToString("dd/MM/yyyy") Or Sistemas = "SQUIJANO" Then
            Me.Cursor = Cursors.WaitCursor
            If Reporte IsNot Nothing Then
                Reporte.Close()
                crv.ReportSource = Nothing
            End If
            Reporte = New ReportePuntosMov
            Reporte.SetDataSource(opuntos.ReportePuntos(No_sucursal, dtpFecha.Value.ToString("dd/MM/yyyy")))
            crv.ReportSource = Reporte
            Me.Cursor = Cursors.Default
        Else
            MsgBox("No se puede Generar de Dias Anterior", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Btn7_Click(sender As Object, e As EventArgs) Handles Btn7.Click
        Me.Cursor = Cursors.WaitCursor
        If Reporte IsNot Nothing Then
            Reporte.Close()
            crv.ReportSource = Nothing
        End If
        Reporte = New ReporteGastos
        Reporte.SetDataSource(omovimientosC.ReporteGatos(No_sucursal, dtpFecha.Value.ToString("dd/MM/yyyy")))
        crv.ReportSource = Reporte
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Btn8_Click(sender As Object, e As EventArgs) Handles Btn8.Click
        Dim form As New FrmListados
        form.No_sucursal = No_sucursal
        form.Nombre_sucursal = Nombre_sucursal
        form.ShowDialog()
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        ImprimirReporteGlobal()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
#End Region

    Private Sub ImprimirReporteInventario()
        If Reporte IsNot Nothing Then
            Reporte.Close()
            crv.ReportSource = Nothing
        End If
        Existencias2()

        Reporte = New invedetallediv
        Reporte.SetDataSource(otinventario2C.RptTipado)
        Reporte.SetParameterValue("fecha2", dtpFecha.Value.ToString("dd/MM/yyyy"))
        Reporte.SetParameterValue("Sucursal", "Sucursal: " & Nombre_sucursal)
        crv.ReportSource = Reporte
    End Sub

    Private Sub ImprimirReporteInventario2()
        If Reporte IsNot Nothing Then
            Reporte.Close()
            crv.ReportSource = Nothing
        End If
        Reporte = New ExistenciaDiv
        Reporte.SetDataSource(oExistenciaC.RptTipado(dtpFecha.Value.ToShortDateString, No_sucursal))
        Reporte.SetParameterValue("fecha2", dtpFecha.Value.ToString("dd/MM/yyyy"))
        Reporte.SetParameterValue("Sucursal", "Sucursal: " & Nombre_sucursal)
        crv.ReportSource = Reporte
    End Sub

#Region "existencias"
    Private Sub Existencias2()
        Dim odivisasC As New divisasC
        Dim otipodivisasC As New tipodivisasC
        Dim otinventarioM As New tinventarioM
        Dim oremisioDC As New remisioDC
        Dim dt1x, dt2x, dt2filtrox, dt3x As New DataTable
        dt1x = odivisasC.Sdivisas2.Tables(0)
        odivisasC.LiberarDS()
        dt2x = otipodivisasC.Stipodivisas2(No_sucursal).Tables(0)
        otipodivisasC.LiberarDS()

        otinventario2C.EliminaInventario()
        Dim entrada, salida, te, ts As Integer
        Dim saldoi, saldof, cprom, tcan, ttot As Double
        Dim otransferDC As New transferDC
        oremisioDC.LiberarDS()
        entrada = 0
        salida = 0
        te = 0
        ts = 0
        saldoi = 0
        saldof = 0
        cprom = 0
        tcan = 0
        ttot = 0
        Dim fecha As Date

        fecha = dtpFecha.Value.ToShortDateString
        For i As Integer = 0 To dt1x.Rows.Count - 1
            tcan = oremisioDC.CantDivisasC1(dt1x.Rows(i)("codigo").ToString, New DateTime(fecha.Year, 1, 1), fecha, No_sucursal)
            ttot = oremisioDC.TotDivisasC2(dt1x.Rows(i)("codigo").ToString, New DateTime(fecha.Year, 1, 1), fecha, No_sucursal)
            If tcan > 0 Then
                cprom = ttot / Convert.ToDouble(tcan)
                cprom = Decimal.Round(Convert.ToDecimal(cprom), 2)
            End If
            odivisasC.Mcpromedio(dt1x.Rows(i)("codigo").ToString, cprom)
            otinventarioM.codigo = dt1x.Rows(i)("codigo").ToString
            otinventario2C.Alta(otinventarioM)
        Next
        otinventarioM.codigo = Nothing

        Dim tipo As Integer
        Dim divi As String
        For i As Integer = 0 To dt1x.Rows.Count - 1
            dt2filtrox = Nothing
            tipo = Convert.ToInt32(dt1x.Rows(i)("tipo").ToString)
            dt2filtrox = dt2x.Select("tipo = " & tipo, "tipo").CopyToDataTable
            divi = dt1x.Rows(i)("codigo").ToString
            entrada = oremisioDC.CantDivisasC3(dt1x.Rows(i)("codigo").ToString, New DateTime(fecha.Year, 1, 1), fecha, No_sucursal)
            salida = oremisioDC.CantDivisasV4(dt1x.Rows(i)("codigo").ToString, New DateTime(fecha.Year, 1, 1), fecha, No_sucursal)
            te = otransferDC.CantDivisasC3(dt1x.Rows(i)("codigo").ToString, New DateTime(fecha.Year, 1, 1), fecha, No_sucursal)
            ts = otransferDC.CantDivisasV4(dt1x.Rows(i)("codigo").ToString, New DateTime(fecha.Year, 1, 1), fecha, No_sucursal)

            cprom = 0
            saldoi = 0
            saldof = 0

            If entrada >= 0 And (salida >= 0 Or salida <= 0) Then
                cprom = Convert.ToDouble(dt2filtrox.Rows(0)("Compra").ToString)
                saldoi = (entrada - salida)
                cprom = Decimal.Round(Convert.ToDecimal(cprom), 2)
            End If

            If te >= 0 And (ts >= 0 Or ts <= 0) Then
                saldoi = saldoi + (te - ts)
            End If
            otinventarioM.codigo = dt1x.Rows(i)("codigo").ToString
            otinventarioM.si = saldoi * Convert.ToInt32(dt1x.Rows(i)("valor").ToString)
            otinventarioM.cpromedio = cprom
            otinventario2C.Modifica2(otinventarioM)
            otinventarioM.codigo = Nothing
            otinventarioM.si = Nothing
            otinventarioM.cpromedio = Nothing
        Next
        entrada = 0
        salida = 0
        te = 0
        ts = 0
        saldoi = 0
        saldof = 0
        cprom = 0
        tcan = 0
        ttot = 0
        'el segundo for, en funcionamiento primero se saca el saldo inicial, luego las entradas, salidas, ts, te de hoy y se restan
        For i As Integer = 0 To dt1x.Rows.Count - 1
            dt2filtrox = Nothing
            tipo = Convert.ToInt32(dt1x.Rows(i)("tipo").ToString)
            dt2filtrox = dt2x.Select("tipo = " & tipo, "tipo").CopyToDataTable
            Dim divi2 As String
            divi2 = dt1x.Rows(i)("codigo").ToString
            entrada = oremisioDC.CantDivisasC6(dt1x.Rows(i)("codigo").ToString, fecha, No_sucursal) * Convert.ToInt32(dt1x.Rows(i)("valor").ToString)
            salida = oremisioDC.CantDivisasV7(dt1x.Rows(i)("codigo").ToString, fecha, No_sucursal) * Convert.ToInt32(dt1x.Rows(i)("valor").ToString)
            te = otransferDC.CantDivisasC6(dt1x.Rows(i)("codigo").ToString, fecha, No_sucursal) * Convert.ToInt32(dt1x.Rows(i)("valor").ToString)
            ts = otransferDC.CantDivisasV7(dt1x.Rows(i)("codigo").ToString, fecha, No_sucursal) * Convert.ToInt32(dt1x.Rows(i)("valor").ToString)

            cprom = 0
            saldoi = 0
            saldof = 0

            saldoi = otinventario2C.si(dt1x.Rows(i)("codigo").ToString)

            If entrada >= 0 And (salida >= 0 Or salida <= 0) Then
                cprom = Convert.ToDouble(dt2filtrox.Rows(0)("Compra").ToString)
                saldof = ((saldoi / 1) + entrada - salida)
                cprom = Decimal.Round(Convert.ToDecimal(cprom), 2)
            End If

            If te >= 0 And (ts >= 0 Or ts <= 0) Then
                saldof = saldof + te - ts
            End If

            otinventarioM.codigo = dt1x.Rows(i)("codigo").ToString
            otinventarioM.en = entrada
            otinventarioM.sal = salida
            otinventarioM.sf = saldof
            otinventarioM.cpromedio = cprom
            otinventarioM.te = te
            otinventarioM.ts = ts
            otinventario2C.Modifica2(otinventarioM)
            otinventarioM.en = Nothing
            otinventarioM.sal = Nothing
            otinventarioM.sf = Nothing
            otinventarioM.cpromedio = Nothing
            otinventarioM.te = Nothing
            otinventarioM.ts = Nothing
        Next

        otinventario2C.LiberarDt()
        dt1x.Dispose()
        dt2x.Dispose()
        dt2filtrox.Dispose()
        dt3x.Dispose()
        otransferDC.Dispose()
    End Sub
#End Region

#Region "REPORTE CAJA sqlite"
    Private Sub Caja()
        '####################### Nuevo Sistema #################################
        oCAJAC = New CAJAC

        'variables normales
        Dim dt As DataTable
        Dim diaactual As Date
        Dim iniciomes As String = ""
        diaactual = dtpFecha.Value.ToShortDateString
        iniciomes = diaactual.AddDays(-diaactual.Day + 1).ToString("dd/MM/yyyy")
        Dim totalventadivisasaldia As Double = 0
        Dim totalventadivisasalmes As Double = 0
        Dim totalcompradivisasaldia As Double = 0
        Dim totalcompradivisasalmes As Double = 0
        Dim compradivisasD As Double = 0
        Dim ventadivisasD As Double = 0
        Dim compradivisasM As Double = 0
        Dim ventadivisasM As Double = 0
        Dim totaltransferenciaEDaldia As Double = 0
        Dim totaltransferenciaSDaldia As Double = 0
        Dim totaltransferenciaEDalmes As Double = 0
        Dim totaltransferenciaSDalmes As Double = 0
        Dim transferenciaED As Double = 0
        Dim transferenciaSD As Double = 0
        Dim transferenciaEM As Double = 0
        Dim transferenciaSM As Double = 0
        Dim traspasoBovedaID As Double = 0
        Dim traspasoBovedaIM As Double = 0
        Dim traspasoBovedaED As Double = 0
        Dim traspasoBovedaEM As Double = 0
        Dim Total_Incentivos As Double = 0
        Dim Total_IncentivosM As Double = 0
        Dim Total_Cupones As Double = 0
        Dim Total_CuponesM As Double = 0

        dt = oCAJAC.BuscaTodasLasDivisas()
        oCAJAC.LiberarDt()

        ocaja_diarioM.CompraOtra = 0
        ocaja_diarioM.CompraOtraM = 0
        ocaja_diarioM.VentaOtra = 0
        ocaja_diarioM.VentaOtraM = 0

        ocaja_diarioM.TransOtraS = 0
        ocaja_diarioM.TransOtraSM = 0
        ocaja_diarioM.TransOtraE = 0
        ocaja_diarioM.TransOtraEM = 0


        For i As Integer = 0 To dt.Rows.Count - 1 'consulta las diferentes divisas por su inicials D,E,L y DC
            ventadivisasD = 0
            ventadivisasM = 0
            compradivisasD = 0
            compradivisasM = 0
            ventadivisasD = oCAJAC.VentaDivisa(dt.Rows(i)("CODIGO").ToString, diaactual, Nothing, No_sucursal)
            totalventadivisasaldia += ventadivisasD
            compradivisasD = oCAJAC.CompraDivisa(dt.Rows(i)("CODIGO").ToString, diaactual, Nothing, No_sucursal)
            totalcompradivisasaldia += compradivisasD
            ventadivisasM = oCAJAC.VentaDivisa(dt.Rows(i)("CODIGO").ToString, diaactual, iniciomes, No_sucursal)
            totalventadivisasalmes += ventadivisasM
            compradivisasM = oCAJAC.CompraDivisa(dt.Rows(i)("CODIGO").ToString, diaactual, iniciomes, No_sucursal)
            totalcompradivisasalmes += compradivisasM

            transferenciaED = 0
            transferenciaSD = 0
            transferenciaEM = 0
            transferenciaSM = 0
            transferenciaED = oCAJAC.TransferenciaEntrada(dt.Rows(i)("CODIGO").ToString, diaactual, Nothing, No_sucursal)
            totaltransferenciaEDaldia += transferenciaED
            transferenciaSD = oCAJAC.TransferenciaSalida(dt.Rows(i)("CODIGO").ToString, diaactual, Nothing, No_sucursal)
            totaltransferenciaSDaldia += transferenciaSD
            transferenciaEM = oCAJAC.TransferenciaEntrada(dt.Rows(i)("CODIGO").ToString, diaactual, iniciomes, No_sucursal)
            totaltransferenciaEDalmes += transferenciaEM
            transferenciaSM = oCAJAC.TransferenciaSalida(dt.Rows(i)("CODIGO").ToString, diaactual, iniciomes, No_sucursal)
            totaltransferenciaSDalmes += transferenciaSM

            Select Case CInt(dt.Rows(i)("tipo").ToString) 'para ir asignando el valor por tipo de divisa
                Case 1
                    ocaja_diarioM.cpadls = compradivisasD
                    ocaja_diarioM.cpadlsm = compradivisasM
                    ocaja_diarioM.vtadls = ventadivisasD
                    ocaja_diarioM.vtadlsm = ventadivisasM

                    ocaja_diarioM.trasdls = transferenciaSD
                    ocaja_diarioM.trasdlsm = transferenciaSM
                    ocaja_diarioM.trascdls = transferenciaED
                    ocaja_diarioM.trascdlsm = transferenciaEM
                Case 2
                    ocaja_diarioM.cpaeur = compradivisasD
                    ocaja_diarioM.cpaeum = compradivisasM
                    ocaja_diarioM.vtaeur = ventadivisasD
                    ocaja_diarioM.vtaeurm = ventadivisasM

                    ocaja_diarioM.traseur = transferenciaSD
                    ocaja_diarioM.traseum = transferenciaSM
                    ocaja_diarioM.trasceur = transferenciaED
                    ocaja_diarioM.trasceum = transferenciaEM
                Case 3
                    ocaja_diarioM.cpadc = compradivisasD
                    ocaja_diarioM.cpadcm = compradivisasM
                    ocaja_diarioM.vtadc = ventadivisasD
                    ocaja_diarioM.vtadcm = ventadivisasM

                    ocaja_diarioM.trasdc = transferenciaSD
                    ocaja_diarioM.trasdcm = transferenciaSM
                    ocaja_diarioM.trascdc = transferenciaED
                    ocaja_diarioM.trascdcm = transferenciaEM
                Case 4
                    ocaja_diarioM.cpalib = compradivisasD
                    ocaja_diarioM.cpalibm = compradivisasM
                    ocaja_diarioM.vtalib = ventadivisasD
                    ocaja_diarioM.vtalibm = ventadivisasM

                    ocaja_diarioM.traslib = transferenciaSD
                    ocaja_diarioM.traslibm = transferenciaSM
                    ocaja_diarioM.trasclib = transferenciaED
                    ocaja_diarioM.trasclibm = transferenciaEM
                Case 5, 6, 7, 8
                    ocaja_diarioM.CompraOtra = ocaja_diarioM.CompraOtra + compradivisasD
                    ocaja_diarioM.CompraOtraM = ocaja_diarioM.CompraOtraM + compradivisasM
                    ocaja_diarioM.VentaOtra = ocaja_diarioM.VentaOtra + ventadivisasD
                    ocaja_diarioM.VentaOtraM = ocaja_diarioM.VentaOtraM + ventadivisasM

                    ocaja_diarioM.TransOtraS = ocaja_diarioM.TransOtraS + transferenciaSD
                    ocaja_diarioM.TransOtraSM = ocaja_diarioM.TransOtraSM + transferenciaSM
                    ocaja_diarioM.TransOtraE = ocaja_diarioM.TransOtraE + transferenciaED
                    ocaja_diarioM.TransOtraEM = ocaja_diarioM.TransOtraEM + transferenciaEM
            End Select
        Next

        traspasoBovedaID = oCAJAC.TraspasoDebobeda(diaactual, Nothing, No_sucursal)
        ocaja_diarioM.tdb = traspasoBovedaID
        traspasoBovedaIM = oCAJAC.TraspasoDebobeda(diaactual, iniciomes, No_sucursal)
        ocaja_diarioM.tdbm = traspasoBovedaIM
        traspasoBovedaED = oCAJAC.TraspasoAbobeda(diaactual, Nothing, No_sucursal)
        ocaja_diarioM.trab = traspasoBovedaED
        traspasoBovedaEM = oCAJAC.TraspasoAbobeda(diaactual, iniciomes, No_sucursal)
        ocaja_diarioM.trabm = traspasoBovedaEM

        dt = Nothing
        dt = oCAJAC.BuscaTodosLosGastos
        For i As Integer = 0 To dt.Rows.Count - 1 'gastos del dia, el FormatNumber es para usar 2 decimales
            Select Case CInt(dt.Rows(i)("concepto").ToString)
                Case 1
                    'Gastos de Operacion
                    ocaja_diarioM.gs = FormatNumber(oCAJAC.Gastos(dt.Rows(i)("concepto").ToString, diaactual, Nothing, No_sucursal), 2)
                    ocaja_diarioM.gsm = FormatNumber(oCAJAC.Gastos(dt.Rows(i)("concepto").ToString, diaactual, iniciomes, No_sucursal), 2)
                Case 2
                    'Gastos de Personal
                    ocaja_diarioM.go = FormatNumber(oCAJAC.Gastos(dt.Rows(i)("concepto").ToString, diaactual, Nothing, No_sucursal), 2)
                    ocaja_diarioM.gom = FormatNumber(oCAJAC.Gastos(dt.Rows(i)("concepto").ToString, diaactual, iniciomes, No_sucursal), 2)
                Case 3
                    'Gastos de Impuestos y Cuota
                    ocaja_diarioM.gf = FormatNumber(oCAJAC.Gastos(dt.Rows(i)("concepto").ToString, diaactual, Nothing, No_sucursal), 2)
                    ocaja_diarioM.gfm = FormatNumber(oCAJAC.Gastos(dt.Rows(i)("concepto").ToString, diaactual, iniciomes, No_sucursal), 2)
                Case 4
                    'Otros Gastos
                    ocaja_diarioM.gi = FormatNumber(oCAJAC.Gastos(dt.Rows(i)("concepto").ToString, diaactual, Nothing, No_sucursal), 2)
                    ocaja_diarioM.gim = FormatNumber(oCAJAC.Gastos(dt.Rows(i)("concepto").ToString, diaactual, iniciomes, No_sucursal), 2)
            End Select
        Next 'fin del for de gastos

        Dim gastosDia As Double = 0
        Dim gastosMes As Double = 0
        gastosDia = ocaja_diarioM.gs + ocaja_diarioM.go + ocaja_diarioM.gi + ocaja_diarioM.gf
        gastosMes = ocaja_diarioM.gsm + ocaja_diarioM.gom + ocaja_diarioM.gim + ocaja_diarioM.gfm
        ocaja_diarioM.gastos = gastosDia
        ocaja_diarioM.gastosM = gastosMes

        ocaja_diarioM.transTotalED = totaltransferenciaEDaldia
        ocaja_diarioM.transTotalEM = totaltransferenciaEDalmes
        ocaja_diarioM.transTotalID = totaltransferenciaSDaldia
        ocaja_diarioM.transTotalIM = totaltransferenciaSDalmes

        ocaja_diarioM.vtamoro = 0
        ocaja_diarioM.vtamorom = 0
        ocaja_diarioM.cpamoro = 0
        ocaja_diarioM.cpamorom = 0
        ocaja_diarioM.Nosucursal = No_sucursal
        ocaja_diarioM.sucursal = Nombre_sucursal

        ocaja_diarioM.compd = totalcompradivisasaldia
        ocaja_diarioM.compdm = totalcompradivisasalmes
        ocaja_diarioM.vtad = totalventadivisasaldia
        ocaja_diarioM.vtadm = totalventadivisasalmes

        ocaja_diarioM.trad = totaltransferenciaSDaldia - totaltransferenciaEDaldia
        ocaja_diarioM.tradm = FormatNumber(totaltransferenciaSDalmes - totaltransferenciaEDalmes, 2)

        ocaja_diarioM.fecha = diaactual.ToString("dd/MM/yyyy")

        Total_Incentivos = oCAJAC.Incentivos(diaactual.ToString("dd/MM/yyyy"), No_sucursal)
        Total_IncentivosM = oCAJAC.IncentivosM(diaactual.ToString("dd/MM/yyyy"), No_sucursal)

        ocaja_diarioM.Total_Incentivo = Total_Incentivos
        ocaja_diarioM.Total_IncentivoM = Total_IncentivosM

        Total_Cupones = oCAJAC.Cupones(diaactual.ToString("dd/MM/yyyy"), No_sucursal)
        Total_CuponesM = oCAJAC.CuponesM(diaactual.ToString("dd/MM/yyyy"), No_sucursal)

        ocaja_diarioM.Total_Cupones = Total_Cupones
        ocaja_diarioM.Total_CuponesM = Total_CuponesM

        Dim ayer As Date = diaactual.AddDays(-1)
        Dim FechaUltDiaMesAnt As String = ""
        FechaUltDiaMesAnt = diaactual.AddDays(-diaactual.Day).ToString("dd/MM/yyyy")
        Dim SaldoInicial As Double = 0
        Dim SaldoInicialM As Double = 0
        Dim SaldoFinal As Double = 0
        Dim SaldoFinalM As Double = 0
        Dim IngresosD As Double = 0
        Dim EgresosD As Double = 0
        Dim IngresosM As Double = 0
        Dim EgresosM As Double = 0
        'saldo inicial = Saldo Final del dia anterior
        'SaldoInicial = ocaja_diario2C.SaldoInicialC(ayer, No_sucursal)
        'ocaja_diarioM.saldoi = SaldoInicial
        SaldoInicialM = ocaja_diario2C.SaldoInicialCM(FechaUltDiaMesAnt, No_sucursal)
        ocaja_diarioM.saldoim = SaldoInicialM

        If diaactual.Day = 1 Then
            SaldoInicial = ocaja_diario2C.SaldoInicialC(FechaUltDiaMesAnt, No_sucursal)
            ocaja_diarioM.saldoi = SaldoInicial
        Else
            SaldoInicial = SaldoInicialCaja2(SaldoInicialM, iniciomes, ayer)
            ocaja_diarioM.saldoi = SaldoInicial
        End If

        'Saldo Final =  Saldo Inicial + Ingresos - Egresos
        IngresosD = totalventadivisasaldia + totaltransferenciaSDaldia + traspasoBovedaID
        EgresosD = totalcompradivisasaldia + totaltransferenciaEDaldia + traspasoBovedaED + gastosDia + Total_Incentivos + Total_Cupones
        IngresosM = totalventadivisasalmes + totaltransferenciaSDalmes + traspasoBovedaIM
        EgresosM = totalcompradivisasalmes + totaltransferenciaEDalmes + traspasoBovedaEM + gastosMes + Total_IncentivosM + Total_CuponesM
        SaldoFinal = SaldoInicial + IngresosD - EgresosD
        SaldoFinalM = SaldoInicialM + IngresosM - EgresosM
        ocaja_diarioM.saldof = SaldoFinal
        ocaja_diarioM.saldofm = SaldoFinalM

        'checar si ya estam los datos en la base de datos para saber si se hace un UPDATE o un INSERT
        If ocaja_diario2C.VerificacionCaja(diaactual, No_sucursal) > 0 Then
            'UPDATE
            ocaja_diario2C.Mcaja_diario(ocaja_diarioM, diaactual, No_sucursal)
        Else
            'INSERT
            ocaja_diario2C.Acaja_diario(ocaja_diarioM)
        End If

    End Sub

    Private Function SaldoInicialCaja2(ByVal SaldoIM As Double, ByVal FechaI As String, ByVal FechaAyer As Date) As Double
        'Estas consultas son para saber el saldo Inicial del dia anterior
        Dim TotVentasAyer As Double = 0
        Dim TotComprasAyer As Double = 0
        TotVentasAyer = oCAJAC.VentasAl(FechaAyer, FechaI, 2, No_sucursal)
        TotComprasAyer = oCAJAC.ComprasAl(FechaAyer, FechaI, 2, No_sucursal)
        Dim TransferenciasSAyer As Double = 0
        TransferenciasSAyer = oCAJAC.TransferenciaSalida2(FechaAyer, FechaI, No_sucursal)
        Dim TransferenciasEAyer As Double = 0
        TransferenciasEAyer = oCAJAC.TransferenciaEntrada2(FechaAyer, FechaI, No_sucursal)

        Dim GastosdeAyer As Double = 0
        GastosdeAyer = oCAJAC.TraspasosBobedaGastos(FechaAyer, FechaI, 14, "G", No_sucursal)
        Dim TraspasoBA_Ayer As Double = 0
        Dim TraspasoBD_Ayer As Double = 0
        TraspasoBA_Ayer = oCAJAC.TraspasosBobedaGastos(FechaAyer, FechaI, 12, "B", No_sucursal)
        TraspasoBD_Ayer = oCAJAC.TraspasosBobedaGastos(FechaAyer, FechaI, 1, "B", No_sucursal)

        Dim Incentivo_ayer As Double = 0
        Dim Cupones_Ayer As Double = 0

        Incentivo_ayer = oCAJAC.IncentivosMes(FechaAyer, FechaI, No_sucursal)

        Cupones_Ayer = oCAJAC.CuponesMes(FechaAyer, FechaI, No_sucursal)

        Dim Ingresos_Ayer, Egresos_Ayer As Double
        Ingresos_Ayer = TotVentasAyer + TransferenciasSAyer + TraspasoBD_Ayer
        Egresos_Ayer = TotComprasAyer + TransferenciasEAyer + TraspasoBA_Ayer + GastosdeAyer + Incentivo_ayer + Cupones_Ayer

        Return (Ingresos_Ayer + SaldoIM) - Egresos_Ayer
    End Function
#End Region

    Private Sub dtpFecha_Leave(sender As Object, e As EventArgs) Handles dtpFecha.Leave
        Try
            dtpFecha.Value = Convert.ToDateTime(dtpFecha.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ImprimirReporteGlobal()
        Me.Cursor = Cursors.WaitCursor
        If Reporte IsNot Nothing Then
            Reporte.Close()
            crv.ReportSource = Nothing
        End If

        Reporte = New repglobaldivisas2
        Reporte.SetDataSource(oReportesUnicosC.RptGlobalDivisas2(dtpFecha.Value.ToShortDateString, dtpFecha2.Value.ToShortDateString, No_sucursal))
        crv.ReportSource = Reporte
        Me.Cursor = Cursors.Default
        oReportesUnicosC.Dispose()
    End Sub

    Private Sub btnNota_Click(sender As Object, e As EventArgs) Handles btnNota.Click
        Dim cambio As Boolean = False
        Dim Nota = New Notacv
        Dim Nota2 = New NotacvCA
        Me.Cursor = Cursors.WaitCursor
        If Reporte IsNot Nothing Then
            Reporte.Close()
            crv.ReportSource = Nothing
        End If
        ImpresoraName()
        Dim datosds As DataSet
        datosds = New DataSet
        cambio = ProcesoCambio(txtFolio.Text.Trim, No_sucursal)
        If cambio Then
            datosds = oReportesUnicosC.ImprimeNotaCambio2(txtFolio.Text.Trim, No_sucursal)
        Else
            datosds = oReportesUnicosC.RptNota2(txtFolio.Text.Trim, No_sucursal)
        End If
        If No_sucursal = "08" Then
            Dim direccli, divis, descrip As String
            Dim tota As Double
            Dim cant, pro As Integer
            divis = ""
            direccli = ""
            descrip = ""
            tota = 0
            cant = 0
            pro = 0

            Dim whats As String = ""
            whats = datosds.Tables("clientescnbv").Rows(0)("Direccion").ToString
            If whats = "" Then
                direccli = "C " & datosds.Tables("clientescnbv").Rows(0)("Calle").ToString &
                    "No " & datosds.Tables("clientescnbv").Rows(0)("No_Interior").ToString &
                     " " & datosds.Tables("clientescnbv").Rows(0)("EntreCalles").ToString
            Else
                direccli = datosds.Tables("clientescnbv").Rows(0)("Direccion").ToString
            End If
            For Each dr As DataRow In datosds.Tables("RemisioD").Rows
                pro = Convert.ToInt32(dr("Producto").ToString.Replace("L", "").Replace("E", "").Replace("D", "").Replace("C", ""))
                divis += dr("Cantidads").ToString
                Select Case dr("Cantidads").ToString.Length
                    Case 1
                        divis += "   "
                    Case 2
                        divis += "  "
                    Case 3
                        divis += " "
                    Case 4
                        divis += " "
                End Select
                descrip = dr("descripcion_larga").ToString
                If descrip.Contains("CANADIENSE") Then
                    descrip = descrip.Replace("CANADIENSE", "CANAD.")
                    descrip = descrip.Replace(" 0", "")
                End If
                descrip = descrip.Replace("Ó", "O")
                divis += descrip + Chr(13) + Chr(10) + "    A " & dr("p_unitario").ToString & " = $" & Format(dr("stotal"), "##,##0.00").ToString + Chr(13) + Chr(10)
                tota += Convert.ToDouble(dr("stotal").ToString)
                cant += Convert.ToInt32(dr("Cantidads"))
            Next

            Dim que_divisa As String = ""
            If descrip.Contains("DOLAR") And Not descrip.Contains("CANA") Then
                que_divisa = " DOLARES"
            End If
            If descrip.Contains("EURO") Then
                que_divisa = " EUROS"
            End If
            If descrip.Contains("CANA") Then
                que_divisa = " DOLARES CANADIENSES"
            End If
            If descrip.Contains("LIBRA") Then
                que_divisa = " LIBRAS"
            End If


            Dim legal As String = ""
            'legal = "El usuario declara que es propietario real de" + Chr(13) + Chr(10) +
            '    "los recursos con los que efectua la presente" + Chr(13) + Chr(10) +
            '    "operacion, que son de origen y procedencia" + Chr(13) + Chr(10) +
            '    "licita  y que conocen los articulos" + Chr(13) + Chr(10) +
            '    "139,Quarter y 400 Bis del código penal federal"
            legal = "El usuario declara que es propietario real de " &
            "los recursos con los que efectua la presente " &
            "operacion, que son de origen y procedencia " &
            "licita  y que conocen los articulos " &
            "139,Quarter y 400 Bis del codigo penal federal. "

            Dim Estado_Municipio_Pais As String = ""
            Estado_Municipio_Pais = datosds.Tables("Sucursales").Rows(0)("Estado").ToString & ", " & datosds.Tables("Sucursales").Rows(0)("Municipio").ToString & ", " & datosds.Tables("Sucursales").Rows(0)("Pais").ToString
            Estado_Municipio_Pais = Estado_Municipio_Pais.Replace("ú", "u").Replace("ó", "o").Replace("í", "i").Replace("é", "e").Replace("á", "a")
            Dim direccionsucu As String = ""
            direccionsucu = datosds.Tables("Sucursales").Rows(0)("direccion").ToString & " " & datosds.Tables("Sucursales").Rows(0)("Colonia").ToString
            direccionsucu = direccionsucu.Replace("ú", "u").Replace("ó", "o").Replace("í", "i").Replace("é", "e").Replace("á", "a")
            Dim oSW As New StreamWriter("notaCV.txt")
            Dim Linea As String = "EFECTIVO" &
            vbNewLine & "CENTRO CAMBIARIO MERITRADE SA DE CV" &
            vbNewLine & "RFC:CCM121002HZ4   No. Registro CNBV:21624" &
            vbNewLine & "CALLE 49 NO.305 X 46 Y 48 LOCAL 3 COL. BENITO JUAREZ NORTE CP.97119" &
            vbNewLine & "MERIDA,YUC,MEX  FOLIO: " & datosds.Tables("Sucursales").Rows(0)("letra").ToString & " " & datosds.Tables("RemisioM").Rows(0)("folio_factura").ToString &
            vbNewLine & "----------------------------------" &
            vbNewLine & "SUCURSAL:" & "     Fecha: " + Microsoft.VisualBasic.Left(datosds.Tables("remisioM").Rows(0)("fecha").ToString(), 10) &
            vbNewLine & direccionsucu &
            vbNewLine & "Lugar de Expedicion: " &
            vbNewLine & Estado_Municipio_Pais &
            vbNewLine & "----------------------------------" &
            vbNewLine & "CLIENTE: " &
            vbNewLine & datosds.Tables("clientescnbv").Rows(0)("Nombre").ToString &
            vbNewLine & datosds.Tables("clientescnbv").Rows(0)("ApellidoPaterno").ToString & " " & datosds.Tables("clientescnbv").Rows(0)("ApellidoMaterno").ToString &
            vbNewLine & "Direccion:" &
            vbNewLine & direccli &
            vbNewLine & datosds.Tables("clientescnbv").Rows(0)("Colonia").ToString &
            vbNewLine & datosds.Tables("clientescnbv").Rows(0)("Municipio").ToString &
            vbNewLine & datosds.Tables("clientescnbv").Rows(0)("Estado").ToString &
            vbNewLine & "identifica: " & datosds.Tables("clientescnbv").Rows(0)("identificacion").ToString &
            vbNewLine & "----------------------------------" &
            vbNewLine & "CNT  Descripcion   Precio: $" & datosds.Tables("remisioD").Rows(0)("p_unitario").ToString &
            vbNewLine & divis &
            vbNewLine & "----------------------------------" &
            vbNewLine & cant.ToString & que_divisa & " EN " & datosds.Tables("remisioM").Rows(0)("observaciones").ToString &
            vbNewLine & "Total: $" & Format(tota, "##,##0.00").ToString & " PESOS MX" &
             vbNewLine & "----------------------------------" &
            vbNewLine & legal &
            vbNewLine & "SON: " + Chr(13) + Chr(10) &
            vbNewLine & datosds.Tables("remisioM").Rows(0)("letras").ToString
            oSW.WriteLine(Linea)
            oSW.Flush()
            oSW.Dispose()

            Dim process As New Process
            process.StartInfo.FileName = "notaCV.txt"
            process.StartInfo.Verb = "Print"
            process.StartInfo.CreateNoWindow = True
            process.Start()
            process.Dispose()
            datosds.Dispose()
        Else
            If cambio Then
                Nota2.SetDataSource(datosds)
                Nota2.PrintOptions.PrinterName = Impresora1
                Nota2.PrintToPrinter(1, False, 0, 0)
            Else
                Nota.SetDataSource(datosds)
                Nota.PrintOptions.PrinterName = Impresora1
                Nota.PrintToPrinter(1, False, 0, 0)
            End If

        End If
        If cambio Then
            Nota2.Close()
            Nota2.Dispose()
        Else
            Nota.Close()
            Nota.Dispose()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolio.KeyPress
        Dim cambio As Boolean = False
        Dim puntos As Boolean = False
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Me.Cursor = Cursors.WaitCursor
            If Reporte IsNot Nothing Then
                Reporte.Close()
                crv.ReportSource = Nothing
            End If

            cambio = ProcesoCambio(txtFolio.Text.Trim, No_sucursal)
            'puntos = ProcesoPuntos(txtFolio.Text.Trim, No_sucursal)
            If cambio Then
                Reporte = New NotacvCA
                Reporte.SetDataSource(oReportesUnicosC.ImprimeNotaCambio2(txtFolio.Text.Trim, No_sucursal))
                crv.ReportSource = Reporte
                Me.Cursor = Cursors.Default
                'ElseIf puntos Then
                '    Dim NotaC As Integer
                '    NotaC = FolioNC(txtFolio.Text.Trim, No_sucursal)
                '    Reporte = New NotaCreditoV
                '    Reporte.SetDataSource(oReportesUnicosC.ImprimeNotaPuntosVenta2(txtFolio.Text.Trim, No_sucursal, NotaC))
                '    crv.ReportSource = Reporte
                '    Me.Cursor = Cursors.Default
            Else
                Reporte = New Notacv
                Reporte.SetDataSource(oReportesUnicosC.RptNota2(txtFolio.Text, No_sucursal))
                crv.ReportSource = Reporte
                Me.Cursor = Cursors.Default
            End If

        End If
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

    Private Sub cmdRepIncentivo_Click(sender As Object, e As EventArgs) Handles cmdRepIncentivo.Click
        If Reporte IsNot Nothing Then
            Reporte.Close()
            crv.ReportSource = Nothing
        End If
        Reporte = New RepMontoIncentivo
        Reporte.SetDataSource(opuntos.RptMonto_Incentivo(CDate(dtpFecha.Value.ToShortDateString), CDate(dtpFecha2.Value.ToShortDateString), No_sucursal))
        Reporte.SetParameterValue("FechaIni", dtpFecha.Value.ToString("dd/MM/yyyy"))
        Reporte.SetParameterValue("FechaFin", dtpFecha2.Value.ToString("dd/MM/yyyy"))
        Reporte.SetParameterValue("Sucursal", Nombre_sucursal)
        crv.ReportSource = Reporte
    End Sub

    Private Sub BtnTraspasosDet_Click(sender As Object, e As EventArgs) Handles BtnTraspasosDet.Click
        Me.Cursor = Cursors.WaitCursor
        If Reporte IsNot Nothing Then
            Reporte.Close()
            crv.ReportSource = Nothing
        End If
        Reporte = New Traspasos2
        Reporte.SetDataSource(oReportesUnicosC.ReporteTraspaso_Det(No_sucursal, dtpFecha.Value.ToString("dd/MM/yyyy"), dtpFecha2.Value.ToString("dd/MM/yyyy")))
        Reporte.SetParameterValue("fecha1", dtpFecha.Value.ToString("dd/MM/yyyy"))
        Reporte.SetParameterValue("fecha2", dtpFecha2.Value.ToString("dd/MM/yyyy"))
        Reporte.SetParameterValue("Sucursal", "Sucursal: " & Nombre_sucursal)
        crv.ReportSource = Reporte
        Me.Cursor = Cursors.Default
    End Sub

End Class