Imports System.Drawing
Imports System.Drawing.Image
Imports System.Drawing.Drawing2D
Imports System.Net
Imports System.Net.Mail
Imports ZXing.Common
Imports ZXing
Imports ZXing.QrCode


Public Class FrmCBProveedor

    Public IDCliente As Integer
    Public oNombre As String
    Dim EMail As String

    Private Sub cmdGenerar_Click(sender As Object, e As EventArgs) Handles cmdGenerar.Click
        Dim bmp As Bitmap = Nothing
        Dim options As New QrCodeEncodingOptions
        options.DisableECI = True
        options.CharacterSet = "UTF-8"
        options.Width = 250
        options.Height = 250

        Dim writer As New BarcodeWriter
        writer.Format = BarcodeFormat.QR_CODE
        writer.Options = options

        Dim qr As New ZXing.BarcodeWriter
        qr.Options = options
        qr.Format = BarcodeFormat.QR_CODE
        Dim result As New Bitmap(qr.Write(txtCodigo.Text.Trim))
        pbCBP.Image = result

        Try
            pbCBP.Image.Save("C:\CBProveedor\" & txtCodigo.Text & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
            Enviar_Correo("C:\CBProveedor\" & txtCodigo.Text & ".jpg")
            System.IO.File.Delete("C:\CBProveedor\" & txtCodigo.Text & ".jpg")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Sub Enviar_Correo(ByVal Archivo As String)
        Dim message As New MailMessage
        Dim adjunto = New System.Net.Mail.Attachment(Archivo)
        Dim smtp As New SmtpClient
        Dim cclientesmail As New clientescnbvC
        Dim Cont As Integer

        EMail = cclientesmail.Get_EMail(IDCliente)

        If EMail = "" Then
            MsgBox("El cliente no tiene asignado un correo, favor de capturarlo", vbInformation)
            Exit Sub
        End If

        Cont = cclientesmail.Actualiza_Proveedor(IDCliente)

        With message
            .From = New System.Net.Mail.MailAddress("efectivo@efectivodivisas.com.mx")
            '.To.Add("sdquijano@gmail.com")
            .To.Add(EMail)
            .Body = "Por este medio le hago llegar el Codigo QR que lo acredita como Proveedor de divisas, favor de presentarlo al momento de llevar sus divisas. "
            .Subject = "Codigo QR Proveedor"
            .Attachments.Add(adjunto)
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

    Private Sub FrmCBProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCodigo.Text = IDCliente
        lbNombre.Text = oNombre
    End Sub
End Class