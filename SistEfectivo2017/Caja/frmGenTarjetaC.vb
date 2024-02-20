Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Image
Imports System.Drawing.Drawing2D
Imports System.Net
Imports System.Net.Mail
Imports ZXing.Common
Imports ZXing
Imports ZXing.QrCode
Imports System.Xml

Public Class frmGenTarjetaC
    Dim cnn As SqlConnection
    Dim rs As SqlDataReader
    Dim comm As SqlCommand
    Dim strSQL As String

    Sub Enviar_Correo(ByVal Archivo As String)
        Dim EMail As String
        Dim message As New MailMessage
        Dim adjunto = New System.Net.Mail.Attachment(Archivo)
        Dim smtp As New SmtpClient

        EMail = txtEmail.Text

        If EMail = "" Then
            MsgBox("El cliente no tiene asignado un correo, favor de capturarlo", vbInformation)
            Exit Sub
        End If

        With message
            .From = New System.Net.Mail.MailAddress("efectivo@efectivodivisas.com.mx")
            '.To.Add("sdquijano@gmail.com")
            .To.Add(EMail)
            '.Bcc.Add("camara_91@hotmail.com")
            '.Bcc.Add("mano_922@hotmail.com")
            strSQL = ""
            strSQL = strSQL & "<!DOCTYPE html>"
            strSQL = strSQL & "<html lang = en >"
            strSQL = strSQL & "<head>"
            strSQL = strSQL & "     <meta charset=UTF-8>"
            strSQL = strSQL & "     <meta name=viewport content=width=device-width, initial-scale=1.0>"
            strSQL = strSQL & "    <title>Monedero Electronico</title>"
            strSQL = strSQL & "</head>"
            strSQL = strSQL & "<body>"
            strSQL = strSQL & "<font size=4px>"
            strSQL = strSQL & "Estimado usuario: <P> Por medio del presente le hacemos llegar su NUEVO MONEDERO DIGITAL EFECTIVO. <P>"
            strSQL = strSQL & "Para comenzar a utilizarlo y gozar de sus beneficios realice las siguientes acciones: <P>"
            strSQL = strSQL & "1.- Guardar en su smartphone el archivo adjunto que contiene su Monedero Digital. <P>"
            strSQL = strSQL & "2.- Antes de realizar alguna operación, presente en la ventanilla su nuevo Monedero para proceder a la activación del mismo. <P>"
            strSQL = strSQL & "3.- Reciba de inmediato los beneficios generados por su operación de compra o venta de divisas. <P>"
            strSQL = strSQL & "NOTA: El uso del nuevo MONEDERO DIGITAL EFECTIVO implica la aceptación de los términos y las condiciones del mismo, consulte las mismas en https://www.efectivodivisas.com.mx"
            strSQL = strSQL & "    </font>"
            strSQL = strSQL & "</body>"
            strSQL = strSQL & "</html>"

            .Body = strSQL
            .Subject = "Monedero Electronico"

            .Attachments.Add(adjunto)
            .Priority = System.Net.Mail.MailPriority.High
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

    Private Sub cmdGenerar_Click(sender As Object, e As EventArgs) Handles cmdGenerar.Click
        ' Cargo la imagen...
        If txtCliente.Text = "" Then
            MsgBox("No tiene Codigo el cliente, favor de verificar o cargar de nuevo", vbInformation)
            Exit Sub
        End If
        Dim oDibujo As Image = Bitmap.FromFile(Directory.GetCurrentDirectory & "\compra.png")

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
        Dim result As Bitmap
        If Len(txtCliente.Text) = 1 Then
            result = New Bitmap(qr.Write("00" & txtCliente.Text.Trim & "P"))
        Else
            result = New Bitmap(qr.Write(txtCliente.Text.Trim & "P"))
        End If

        pbCBP.Image = result

        Try
            pbCBP.Image.Save("C:\CBProveedor\" & txtCliente.Text & "_1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try


        Dim oDibujo2 As Image = Bitmap.FromFile("C:\CBProveedor\" & txtCliente.Text & "_1.jpg")

        ' Creo un objeto Graphics a partir del mismo
        Dim oGraphics As Graphics = Graphics.FromImage(oDibujo)

        ' Escrito el texto en el grafico

        oGraphics.DrawString(lbNombre.Text, New Font("Arial", 20),
        Brushes.White, 90, 260)

        oGraphics.DrawString(lbApellidos.Text, New Font("Arial", 20),
        Brushes.White, 90, 285)

        oGraphics.DrawString(txtCliente.Text, New Font("Arial", 20),
        Brushes.White, 90, 350)

        oGraphics.DrawImage(oDibujo2, 250, 450)

        ' Libero el objeto Graphics
        oGraphics.Dispose()

        ' Guardo el resultado en un nuevo archivo (o pudiera asignarlo a un
        'PictureBox,
        oDibujo.Save("C:\CBProveedor\" & txtCliente.Text & ".jpg")
        Enviar_Correo("C:\CBProveedor\" & txtCliente.Text & ".jpg")
        System.IO.File.Delete("C:\CBProveedor\" & txtCliente.Text & ".jpg")

        Dim cnn As ConexionSQLS = Nothing
        Dim Commando As SqlCommand
        cnn = New ConexionSQLS

        cnn.EstablecerConexion()
        cnn.AbrirConexion()
        Commando = New SqlCommand("UPDATE clientescnbv SET EsProveedor = 1, Fecha_Envio_P = '" & Format(Now.Date, "dd/MM/yyyy") & "' WHERE cliente = " & txtCliente.Text, cnn.con)
        Commando.ExecuteNonQuery()

        cnn.CerrarConexion()
        ' Libero el objeto Bitmap
        oDibujo.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtGeneraSMS_Click(sender As Object, e As EventArgs) Handles txtGeneraSMS.Click
        Dim Mensaje As String
        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode
        Dim mCodigo = ""

        If txtCelular.TextLength < 12 Then
            MsgBox("Favor de verificar el numero de Celular, tiene menos digitos", vbInformation)
            Exit Sub
        End If

        Mensaje = "Centro Cambiario Efectivo. http://www.efectivodivisas.com.mx/webservice/qr/compra.php?tarjeta=" & txtCliente.Text & "P-" & lbNombre.Text.Replace(" ", "-") & "-" & lbApellidos.Text.Replace(" ", "-")
        Dim requestUrl As String = "https://api.labsmobile.com/get/send.php?username=divisas@efectivodivisas.com.mx&password=Meritrade2020&message=" & Mensaje & "&msisdn=" & txtCelular.Text & "&sender=EFECTIVO"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(requestUrl), HttpWebRequest)
        Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        Dim result = responseFromServer
        reader.Close()
        response.Close()

        m_xmld = New XmlDocument()
        m_xmld.LoadXml(result)

        m_nodelist = m_xmld.SelectNodes("/response")
        For Each m_node In m_nodelist
            mCodigo = m_node.ChildNodes.Item(1).InnerText
        Next

        Dim cnn As ConexionSQLS = Nothing
        Dim Commando As SqlCommand
        cnn = New ConexionSQLS

        cnn.EstablecerConexion()
        cnn.AbrirConexion()
        Commando = New SqlCommand("UPDATE clientescnbv SET EsProveedor = 1, Fecha_Envio_P = '" & Format(Now.Date, "dd/MM/yyyy") & "' WHERE cliente = " & txtCliente.Text, cnn.con)
        Commando.ExecuteNonQuery()

        If mCodigo <> "0" Then
            MsgBox("Se envio el mensaje con error: " & mCodigo, vbInformation)
        Else
            MsgBox("Se envio el mensaje existosamente", vbInformation)
        End If
    End Sub

End Class