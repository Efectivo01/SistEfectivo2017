Imports System.Drawing
Imports System.IO

Public Class FrmTransferencias
    Public No_sucursal As String
    Public UsuarioT As String
    Public Nombre_sucursal As String
    Dim dt1, dt2, dt3, dt4, dtExistencia As DataTable

    Dim otransferDC As New transferDC
    Dim ProcesoExistencia As Boolean
    Dim Estatus As Integer = 0
    Dim oExistenciaM As New ExistenciaM
    Dim oExistenciaC As New ExistenciaC

    Private Sub FrmTransferencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarGrids()
        Label12.Visible = False
        LblDestino.Visible = False
    End Sub

    Private Sub CargarGrids()
        Dim folio_orig As Integer
        Dim folio_dest As Integer
        Dim importe_orig As Double
        Dim importe_dest As Double

        dt1 = otransferDC.TransferenciaOrigen(No_sucursal).Tables(0)
        For Each dr As DataRow In dt1.Rows
            folio_orig = CInt(dr("folio_orig"))
            importe_orig = dr("importe")
            dgvCoV.Rows.Add(folio_orig, Format(importe_orig, "$#,##0.00"), CInt(dr("folio_dest")), dr("nosucursal_dest"), dr("hora"))
        Next

        dt2 = otransferDC.TransferenciaDestino(No_sucursal).Tables(0)
        For Each dr As DataRow In dt2.Rows
            folio_dest = CInt(dr("folio_dest"))
            importe_dest = dr("importe")
            dgvCoV2.Rows.Add(folio_dest, Format(importe_dest, "$#,##0.00"), dr("nosucursal_orig"), dr("hora"))
        Next
    End Sub

    Private Sub dgvCoV_Click(sender As Object, e As EventArgs) Handles dgvCoV.Click
        Dim TotalImporte As Double = 0
        Dim TotalMonto As Integer = 0
        Dim TotalCant As Integer = 0
        Dim ImportDolares As Double = 0
        Dim ImportEuros As Double = 0
        Dim ImporteCanadi As Double = 0
        Dim ImporteLibras As Double = 0
        Dim ImporteYuan As Double = 0
        Dim ImporteAustralia As Double = 0
        Dim ImporteFranco As Double = 0
        Dim ImporteYen As Double = 0
        Dim MontoD As Integer = 0
        Dim MontoE As Integer = 0
        Dim MontoC As Integer = 0
        Dim MontoL As Integer = 0
        Dim MontoYu As Integer = 0
        Dim MontoDA As Integer = 0
        Dim MontoF As Integer = 0
        Dim MontoYe As Integer = 0
        Dim CantD As Integer = 0
        Dim CantE As Integer = 0
        Dim CantC As Integer = 0
        Dim CantL As Integer = 0
        Dim CantYu As Integer = 0
        Dim CantDA As Integer = 0
        Dim CantF As Integer = 0
        Dim CantYe As Integer = 0
        Dim i As Integer = -1

        If dgvCoV.Rows.Count > 0 Then
            dgvCoV4.Rows.Clear()
            TxtTransfer.Text = dgvCoV.Rows(dgvCoV.CurrentRow.Index).Cells(0).Value.ToString
            dt4 = otransferDC.TransferenciaRegistro(No_sucursal, dgvCoV.Rows(dgvCoV.CurrentRow.Index).Cells(0).Value).Tables(0)
            TxtFolioDest.Text = dgvCoV.Rows(dgvCoV.CurrentRow.Index).Cells(2).Value.ToString
            TxtNoSucDest.Text = dgvCoV.Rows(dgvCoV.CurrentRow.Index).Cells(3).Value.ToString
            Label12.Visible = True
            LblDestino.Visible = True
            Label12.Text = "Destino:"
            LblDestino.Text = otransferDC.SucursalesDestOrig(dgvCoV.Rows(dgvCoV.CurrentRow.Index).Cells(3).Value.ToString)
            For Each dr As DataRow In dt4.Rows
                i = i + 1
                Estatus = 1
                ProcesoExistencia = True
                dgvCoV4.Rows.Add(dr("divisa"), Image.FromFile(Directory.GetCurrentDirectory() & "\billetes_gif\Denominaciones\" & dr("producto") & ".gif"), dr("producto"), dr("ts"), dr("cantidads"), Format(dr("precio"), "##0.00"), Format(dr("importe"), "$#,#00.00"))
                TotalImporte = TotalImporte + dr("importe")
                TotalMonto = TotalMonto + dr("cantidads")
                TotalCant = TotalCant + dr("ts")

                If dr("divisa") = "DOLARES" Then
                    ImportDolares = ImportDolares + dr("importe")
                    MontoD = MontoD + dr("cantidads")
                    CantD = CantD + dr("ts")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
                ElseIf dr("divisa") = "EUROS" Then
                    ImportEuros = ImportEuros + dr("importe")
                    MontoE = MontoE + dr("cantidads")
                    CantE = CantE + dr("ts")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.Beige
                ElseIf dr("divisa") = "CANADIENSES" Then
                    ImporteCanadi = ImporteCanadi + dr("importe")
                    MontoC = MontoC + dr("cantidads")
                    CantC = CantC + dr("ts")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.Gray
                ElseIf dr("divisa") = "LIBRAS" Then
                    ImporteLibras = ImporteLibras + dr("importe")
                    MontoL = MontoL + dr("cantidads")
                    CantL = CantL + dr("ts")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf dr("divisa") = "YUAN CHINO" Then
                    ImporteYuan = ImporteLibras + dr("importe")
                    MontoYu = MontoYu + dr("cantidads")
                    CantYu = CantYu + dr("ts")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf dr("divisa") = "DAUSTRALIANO" Then
                    ImporteAustralia = ImporteAustralia + dr("importe")
                    MontoDA = MontoDA + dr("cantidads")
                    CantDA = CantDA + dr("ts")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf dr("divisa") = "FRANCO SUIZO" Then
                    ImporteFranco = ImporteFranco + dr("importe")
                    MontoF = MontoF + dr("cantidads")
                    CantF = CantF + dr("ts")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf dr("divisa") = "YEN JAPONES" Then
                    ImporteYen = ImporteYen + dr("importe")
                    MontoYe = MontoYe + dr("cantidads")
                    CantYe = CantYe + dr("ts")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Next
            TxtImporteT.Text = Format(TotalImporte, "$#,##0.00")
            TxtImporteD.Text = Format(ImportDolares, "$#,##0.00")
            TxtImporteE.Text = Format(ImportEuros, "$#,##0.00")
            TxtImporteC.Text = Format(ImporteCanadi, "$#,##0.00")
            TxtImporteL.Text = Format(ImporteLibras, "$#,##0.00")
            txtImporteYu.Text = Format(ImporteYuan, "$#,##0.00")
            txtImporteDA.Text = Format(ImporteAustralia, "$#,##0.00")
            txtImporteF.Text = Format(ImporteFranco, "$#,##0.00")
            txtImporteYe.Text = Format(ImporteYen, "$#,##0.00")

            TxtTotalI.Text = Format(TotalImporte, "$#,##0.00")
            TxtMontoD.Text = Format(MontoD, "#,##0")
            TxtMontoE.Text = Format(MontoE, "#,##0")
            TxtMontoC.Text = Format(MontoC, "#,##0")
            TxtMontoL.Text = Format(MontoL, "#,##0")
            TxtMontoYu.Text = Format(MontoYu, "#,##0")
            TxtMontoDA.Text = Format(MontoDA, "#,##0")
            TxtMontoF.Text = Format(MontoF, "#,##0")
            TxtMontoYe.Text = Format(MontoYe, "#,##0")

            TxtTotalM.Text = Format(TotalMonto, "#,##0")
            TxtCantD.Text = Format(CantD, "#,##0")
            TxtCantE.Text = Format(CantE, "#,##0")
            TxtCantC.Text = Format(CantC, "#,##0")
            TxtCantL.Text = Format(CantL, "#,##0")
            TxtCantYu.Text = Format(CantYu, "#,##0")
            TxtCantDA.Text = Format(CantDA, "#,##0")
            TxtCantF.Text = Format(CantF, "#,##0")
            TxtCantYe.Text = Format(CantYe, "#,##0")

            TxtTotalC.Text = Format(TotalCant, "#,##0")
        End If
    End Sub

    Private Sub BtnConfirmar_Click(sender As Object, e As EventArgs) Handles BtnConfirmar.Click
        'checar la contraseña que se ingreso
        If dgvCoV4.Rows.Count > 0 Then
            If otransferDC.ValidarContrasena(TextBox3.Text) > 0 Then
                If otransferDC.UpdateTranfer(CInt(TxtTransfer.Text), Estatus, No_sucursal, UsuarioT, Now.ToShortDateString, TextBox3.Text) > 0 Then
                    LimpiarCampos()
                End If
            Else
                MsgBox("Contraseña Incorrecta por favor de Agregar la Correcta", MsgBoxStyle.Information)
            End If
        End If

    End Sub

    Private Sub dgvCoV2_Click(sender As Object, e As EventArgs) Handles dgvCoV2.Click
        Dim TotalImporte As Double = 0
        Dim TotalMonto As Integer = 0
        Dim TotalCant As Integer = 0
        Dim ImportDolares As Double = 0
        Dim ImportEuros As Double = 0
        Dim ImporteCanadi As Double = 0
        Dim ImporteLibras As Double = 0
        Dim ImporteYuan As Double = 0
        Dim ImporteAustralia As Double = 0
        Dim ImporteFranco As Double = 0
        Dim ImporteYen As Double = 0

        Dim MontoD As Integer = 0
        Dim MontoE As Integer = 0
        Dim MontoC As Integer = 0
        Dim MontoL As Integer = 0
        Dim MontoYu As Integer = 0
        Dim MontoDA As Integer = 0
        Dim MontoF As Integer = 0
        Dim MontoYe As Integer = 0

        Dim CantD As Integer = 0
        Dim CantE As Integer = 0
        Dim CantC As Integer = 0
        Dim CantL As Integer = 0
        Dim CantYu As Integer = 0
        Dim CantDA As Integer = 0
        Dim CantF As Integer = 0
        Dim CantYe As Integer = 0

        Dim i As Integer = -1

        If dgvCoV2.Rows.Count > 0 Then
            dgvCoV4.Rows.Clear()
            TxtTransfer.Text = dgvCoV2.Rows(dgvCoV2.CurrentRow.Index).Cells(0).Value.ToString
            dt4 = otransferDC.TransferenciaRegistro2(No_sucursal, dgvCoV2.Rows(dgvCoV2.CurrentRow.Index).Cells(0).Value).Tables(0)
            Label12.Visible = True
            LblDestino.Visible = True
            Label12.Text = "Origen:"
            LblDestino.Text = otransferDC.SucursalesDestOrig(dgvCoV2.Rows(dgvCoV2.CurrentRow.Index).Cells(2).Value.ToString)
            For Each dr As DataRow In dt4.Rows
                i = i + 1
                Estatus = 2
                ProcesoExistencia = True
                dgvCoV4.Rows.Add(dr("divisa"), Image.FromFile(Directory.GetCurrentDirectory() & "\billetes_gif\Denominaciones\" & dr("producto") & ".gif"), dr("producto"), dr("te"), dr("cantidads"), Format(dr("precio"), "##0.00"), Format(dr("importe"), "$#,#00.00"))
                TotalImporte = TotalImporte + dr("importe")
                TotalMonto = TotalMonto + dr("cantidads")
                TotalCant = TotalCant + dr("te")

                If dr("divisa") = "DOLARES" Then
                    ImportDolares = ImportDolares + dr("importe")
                    MontoD = MontoD + dr("cantidads")
                    CantD = CantD + dr("te")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
                ElseIf dr("divisa") = "EUROS" Then
                    ImportEuros = ImportEuros + dr("importe")
                    MontoE = MontoE + dr("cantidads")
                    CantE = CantE + dr("te")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.Beige
                ElseIf dr("divisa") = "CANADIENSES" Then
                    ImporteCanadi = ImporteCanadi + dr("importe")
                    MontoC = MontoC + dr("cantidads")
                    CantC = CantC + dr("te")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.Gray
                ElseIf dr("divisa") = "LIBRAS" Then
                    ImporteLibras = ImporteLibras + dr("importe")
                    MontoL = MontoL + dr("cantidads")
                    CantL = CantL + dr("te")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf dr("divisa") = "YUAN CHINO" Then
                    ImporteYuan = ImporteLibras + dr("importe")
                    MontoYu = MontoYu + dr("cantidads")
                    CantYu = CantYu + dr("te")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf dr("divisa") = "DAUSTRALIANO" Then
                    ImporteAustralia = ImporteAustralia + dr("importe")
                    MontoDA = MontoDA + dr("cantidads")
                    CantDA = CantDA + dr("te")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf dr("divisa") = "FRANCO SUIZO" Then
                    ImporteFranco = ImporteFranco + dr("importe")
                    MontoF = MontoF + dr("cantidads")
                    CantF = CantF + dr("te")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf dr("divisa") = "YEN JAPONES" Then
                    ImporteYen = ImporteYen + dr("importe")
                    MontoYe = MontoYe + dr("cantidads")
                    CantYe = CantYe + dr("te")
                    dgvCoV4.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Next
            TxtImporteT.Text = Format(TotalImporte, "$#,##0.00")
            TxtImporteD.Text = Format(ImportDolares, "$#,##0.00")
            TxtImporteE.Text = Format(ImportEuros, "$#,##0.00")
            TxtImporteC.Text = Format(ImporteCanadi, "$#,##0.00")
            TxtImporteL.Text = Format(ImporteLibras, "$#,##0.00")
            txtImporteYu.Text = Format(ImporteYuan, "$#,##0.00")
            txtImporteDA.Text = Format(ImporteAustralia, "$#,##0.00")
            txtImporteF.Text = Format(ImporteFranco, "$#,##0.00")
            txtImporteYe.Text = Format(ImporteYen, "$#,##0.00")

            TxtTotalI.Text = Format(TotalImporte, "$#,##0.00")
            TxtMontoD.Text = Format(MontoD, "#,##0")
            TxtMontoE.Text = Format(MontoE, "#,##0")
            TxtMontoC.Text = Format(MontoC, "#,##0")
            TxtMontoL.Text = Format(MontoL, "#,##0")
            TxtMontoYu.Text = Format(MontoYu, "#,##0")
            TxtMontoDA.Text = Format(MontoDA, "#,##0")
            TxtMontoF.Text = Format(MontoF, "#,##0")
            TxtMontoYe.Text = Format(MontoYe, "#,##0")

            TxtTotalM.Text = Format(TotalMonto, "#,##0")
            TxtCantD.Text = Format(CantD, "#,##0")
            TxtCantE.Text = Format(CantE, "#,##0")
            TxtCantC.Text = Format(CantC, "#,##0")
            TxtCantL.Text = Format(CantL, "#,##0")
            TxtCantYu.Text = Format(CantYu, "#,##0")
            TxtCantDA.Text = Format(CantDA, "#,##0")
            TxtCantF.Text = Format(CantF, "#,##0")
            TxtCantYe.Text = Format(CantYe, "#,##0")

            TxtTotalC.Text = Format(TotalCant, "#,##0")
        End If

    End Sub

    Private Sub LimpiarCampos()
        dgvCoV.Rows.Clear()
        dgvCoV2.Rows.Clear()
        dgvCoV4.Rows.Clear()
        CargarGrids()
        TxtTransfer.Text = ""
        TxtImporteT.Text = ""
        TxtImporteD.Text = ""
        TxtImporteE.Text = ""
        TxtImporteC.Text = ""
        TxtImporteL.Text = ""
        txtImporteYu.Text = ""
        txtImporteDA.Text = ""
        txtImporteF.Text = ""
        txtImporteYe.Text = ""
        TextBox3.Text = ""
        TxtTotalI.Text = ""
        TxtMontoD.Text = ""
        TxtMontoE.Text = ""
        TxtMontoC.Text = ""
        TxtMontoL.Text = ""
        TxtMontoYu.Text = ""
        TxtMontoDA.Text = ""
        TxtMontoF.Text = ""
        TxtMontoYe.Text = ""
        TxtTotalM.Text = ""
        TxtCantD.Text = ""
        TxtCantE.Text = ""
        TxtCantC.Text = ""
        TxtCantL.Text = ""
        TxtCantYu.Text = ""
        TxtCantDA.Text = ""
        TxtCantF.Text = ""
        TxtCantYe.Text = ""
        TxtTotalC.Text = ""
        'TxtObservaciones.Text = ""
        Label12.Visible = False
        LblDestino.Visible = False
    End Sub

    Private Sub BtnTraspasosDet_Click(sender As Object, e As EventArgs) Handles BtnTraspasosDet.Click
        Dim frm As New FrmReporteTransf
        frm.Suc = No_sucursal
        frm.Nombre_suc = Nombre_sucursal
        frm.ShowDialog()
    End Sub
End Class