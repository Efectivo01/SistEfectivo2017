Imports System.Drawing
Imports System.Net.Mail

Public Class FrmAlerta
    Public monto As String
    Public divisa As String
    Public operacion As String
    Public usuario As String
    Public sucursal, no_caje, empleado As String
    Public razon As String = ""
    Dim oOPERACIONESC As OPERACIONESC
    Dim oalertasC As alertasC
    Dim oalertasM As alertasM
    Dim dt As DataTable
    Dim nombredivisa As String = ""
    Dim EMail As String
    Dim Asigno As Boolean = False

    Private Sub CreaInstancias()
        oalertasC = New alertasC
        oalertasM = New alertasM
        oOPERACIONESC = New OPERACIONESC
    End Sub

    Private Sub FrmAlerta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtmonto.Text = monto
        txtdivisa.Text = divisa
        txtempleado.Text = empleado
        txtsucursal.Text = sucursal
        txtoperacion.Text = operacion
        CreaInstancias()
        cmbcausales.DisplayMember = "CAUSA"
        cmbcausales.ValueMember = "CAUSA"
        cmbcausales.SelectedValue = ""
    End Sub

    Private Sub NombraDivisa()
        Dim tipodivisa As Integer = 0
        If CInt(divisa) > 0 Then
            tipodivisa = Convert.ToInt32(divisa)
        End If
        If CInt(txtdivisa.Text) > 0 Then
            tipodivisa = Convert.ToInt32(txtdivisa.Text)
        End If

        Select Case tipodivisa
            Case 1
                nombredivisa = "DOLARES US"
            Case 2
                nombredivisa = "EUROS"
            Case 3
                nombredivisa = "DOLARES CANADIENSES"
            Case 4
                nombredivisa = "LIBRAS"
            Case 5
                nombredivisa = "YUAN CHINO"
            Case 6
                nombredivisa = "DOLAR AUSTRALIANO"
            Case 7
                nombredivisa = "FRANCO SUIZO"
            Case 8
                nombredivisa = "YEN JAPONES"
        End Select

    End Sub

    Private Sub AsignaObjeto1()
        If rbV.Checked Then
            oalertasM.Sucursal = "Anonimo"
            oalertasM.Empleado = "Anonimo"
            oalertasM.Usuario = "Anonimo"
        Else
            oalertasM.Sucursal = txtsucursal.Text
            oalertasM.Empleado = txtempleado.Text
            oalertasM.Usuario = usuario
        End If
        oalertasM.Fecha = Date.Now.ToShortDateString
        oalertasM.Hora = Date.Now 'DateTime.Now.ToShortTimeString
        oalertasM.Motivo = cmbcausales.Text
        oalertasM.Operacion = txtoperacion.Text
        oalertasM.Monto = txtmonto.Text
        oalertasM.Divisa = txtdivisa.Text
        oalertasM.Observaciones = rtxObservaciones.Text

    End Sub

    Private Sub Alta()
        If rtxObservaciones.Text = "" Or rtxObservaciones.Text.Length = 0 Then
            MsgBox("El campo de Observaciones no puede estar vacío", MsgBoxStyle.Information)
            Asigno = False
            Exit Sub
            rtxObservaciones.Focus()
        End If
        AsignaObjeto1()
        If oalertasC.Alta(oalertasM) = 1 Then
            MessageBox.Show("Alerta Guardada")
            Asigno = True
        End If
    End Sub

#Region "RadioButtons"
    Private Sub rbd1_CheckedChanged(sender As Object, e As EventArgs) Handles rbd1.CheckedChanged
        If rbd1.Checked = True Then
            txtdivisa.Text = "1"
        End If
    End Sub

    Private Sub rbd2_CheckedChanged(sender As Object, e As EventArgs) Handles rbd2.CheckedChanged
        If rbd2.Checked = True Then
            txtdivisa.Text = "2"
        End If
    End Sub

    Private Sub rbd3_CheckedChanged(sender As Object, e As EventArgs) Handles rbd3.CheckedChanged
        If rbd3.Checked = True Then
            txtdivisa.Text = "3"
        End If
    End Sub

    Private Sub rbd4_CheckedChanged(sender As Object, e As EventArgs) Handles rbd4.CheckedChanged
        If rbd4.Checked = True Then
            txtdivisa.Text = "4"
        End If
    End Sub

    Private Sub rbC_CheckedChanged(sender As Object, e As EventArgs) Handles rbC.CheckedChanged
        If rbC.Checked = True Then
            txtoperacion.Text = "INUSUAL"
            dt = oOPERACIONESC.SCausasCmb(1)
            oOPERACIONESC.LiberarDt()
            oOPERACIONESC.Dispose()
            cmbcausales.DataSource = dt
            chTentativa.Enabled = False
            chTentativa.Checked = False
        End If
    End Sub

    Private Sub rbV_CheckedChanged(sender As Object, e As EventArgs) Handles rbV.CheckedChanged
        If rbV.Checked = True Then
            txtoperacion.Text = "INTERNA PREOCUPANTE"
            dt = oOPERACIONESC.SCausasCmb(2)
            oOPERACIONESC.LiberarDt()
            oOPERACIONESC.Dispose()
            cmbcausales.DataSource = dt
            cmbcausales.Text = ""
            chTentativa.Enabled = False
            chTentativa.Checked = False
        End If
    End Sub
#End Region

    Private Sub rtxObservaciones_Leave(sender As Object, e As EventArgs) Handles rtxObservaciones.Leave
        rtxObservaciones.Text = rtxObservaciones.Text.ToUpper
    End Sub

    Private Sub txtmonto_Enter(sender As Object, e As EventArgs) Handles txtmonto.Enter
        If txtmonto.Text = "0" Then
            txtmonto.Clear()
        End If
    End Sub

    Private Sub txtmonto_Leave(sender As Object, e As EventArgs) Handles txtmonto.Leave
        If txtmonto.Text = "" Then
            txtmonto.Text = "0"
        End If
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Alta()
        If Not Asigno Then
            MsgBox("No se grabo la alerta, favor de intentar de nuevo", vbInformation)
            Exit Sub
        End If
        Dim body As String = ""
        NombraDivisa()
        body += "Alerta" & vbCr & vbCr
        body += "Operación: " & txtoperacion.Text & vbCrLf
        body += "Cantidad: " & txtmonto.Text & " " & nombredivisa & vbCrLf
        If rbV.Checked = True Then
            body += "Sucursal: Anonimo" & vbCrLf
        Else
            body += "Sucursal:" & txtsucursal.Text & vbCrLf
        End If

        body += "Causa:" & cmbcausales.Text & vbCrLf
        If rbV.Checked = True Then
            body += "Usuario: Anonimo" & vbCrLf
        Else
            body += "Usuario:" & usuario & vbCrLf
        End If

        body += rtxObservaciones.Text
        Enviar_Correo(body)
        Asigno = False
        Me.Close()
    End Sub

    Private Sub btnAlta_MouseDown(sender As Object, e As MouseEventArgs) Handles btnAlta.MouseDown
        btnAlta.BackColor = Color.GhostWhite
    End Sub

    Private Sub btnAlta_MouseHover(sender As Object, e As EventArgs) Handles btnAlta.MouseHover
        btnAlta.BackColor = Color.Crimson
    End Sub

    Private Sub btnAlta_MouseLeave(sender As Object, e As EventArgs) Handles btnAlta.MouseLeave
        btnAlta.BackColor = Color.Green
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnSalir_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSalir.MouseDown
        'btnSalir.BackColor = Color.Green
        btnSalir.BackColor = Color.GhostWhite
    End Sub

    Private Sub btnSalir_MouseHover(sender As Object, e As EventArgs) Handles btnSalir.MouseHover
        btnSalir.BackColor = Color.GhostWhite
    End Sub

    Private Sub rbTen24_CheckedChanged(sender As Object, e As EventArgs) Handles rbTen24.CheckedChanged
        If rbTen24.Checked Then
            txtoperacion.Text = "24 HORAS"
            dt = oOPERACIONESC.SCausasCmb(3)
            oOPERACIONESC.LiberarDt()
            oOPERACIONESC.Dispose()
            cmbcausales.DataSource = dt
            chTentativa.Enabled = True
        End If
    End Sub

    Private Sub chTentativa_CheckedChanged(sender As Object, e As EventArgs) Handles chTentativa.CheckedChanged
        If chTentativa.Checked Then
            txtoperacion.Text = "TENTATIVA " & txtoperacion.Text
        Else
            If rbTen24.Checked Then
                txtoperacion.Text = "24 HORAS"
            Else
                If rbC.Checked Then
                    txtoperacion.Text = "INUSUAL"
                Else
                    If rbV.Checked Then
                        txtoperacion.Text = "INTERNA PREOCUPANTE"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub rbd5_CheckedChanged(sender As Object, e As EventArgs) Handles rbd5.CheckedChanged
        If rbd5.Checked = True Then
            txtdivisa.Text = "5"
        End If
    End Sub

    Private Sub rbd6_CheckedChanged(sender As Object, e As EventArgs) Handles rbd6.CheckedChanged
        If rbd6.Checked = True Then
            txtdivisa.Text = "6"
        End If
    End Sub

    Private Sub rbd7_CheckedChanged(sender As Object, e As EventArgs) Handles rbd7.CheckedChanged
        If rbd7.Checked = True Then
            txtdivisa.Text = "7"
        End If
    End Sub

    Private Sub rbd8_CheckedChanged(sender As Object, e As EventArgs) Handles rbd8.CheckedChanged
        If rbd8.Checked = True Then
            txtdivisa.Text = "8"
        End If
    End Sub

    Private Sub btnSalir_MouseLeave(sender As Object, e As EventArgs) Handles btnSalir.MouseLeave
        'btnSalir.BackColor = Color.Crimson
        btnSalir.BackColor = Color.Green
    End Sub

    Sub Enviar_Correo(ByVal Mensaje As String)
        Dim message As New MailMessage
        Dim smtp As New SmtpClient

        EMail = "mano_922@hotmail.com"

        If EMail = "" Then
            MsgBox("El cliente no tiene asignado un correo, favor de capturarlo", vbInformation)
            Exit Sub
        End If

        With message
            .From = New System.Net.Mail.MailAddress("efectivo@efectivodivisas.com.mx")
            '.To.Add("sdquijano@gmail.com")
            .To.Add(EMail)
            .Body = Mensaje
            If rbV.Checked = True Then
                .Subject = "Alerta Anonimo"
            Else
                .Subject = "Alerta " & txtsucursal.Text
            End If
            .Priority = System.Net.Mail.MailPriority.Normal
            .IsBodyHtml = True
        End With
        Try
            With smtp
                .EnableSsl = True
                .Port = "587"
                .Host = "smtp.ionos.mx"
                .Credentials = New Net.NetworkCredential("efectivo@efectivodivisas.com.mx", "Efectivo2019$")
                .Send(message)
            End With
            message.Dispose()

            MessageBox.Show("Su mensaje de correo ha sido enviado.", "Correo enviado",
                             MessageBoxButtons.OK)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error al enviar correo",
                             MessageBoxButtons.OK)
        End Try
    End Sub
End Class