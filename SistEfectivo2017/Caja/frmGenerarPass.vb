Imports System.Text
Imports System.Net
Imports System.Net.Mail
Imports MySql.Data.MySqlClient

Public Class frmGenerarPass
    Dim cnnMy As MySqlConnection
    Dim rs As MySqlDataReader
    Dim commMy As MySqlCommand
    Dim commMy2 As MySqlCommand
    Dim strSQL As String
    Private Sub cmdGenerar_Click(sender As Object, e As EventArgs) Handles cmdGenerar.Click
        txtPassword.Text = GenerarPassword(10)
    End Sub

    Private Function GenerarPassword(ByVal longitud As Integer) As String
        Dim caracteres As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim res As New StringBuilder()
        Dim rnd As New Random()
        While 0 < System.Math.Max(System.Threading.Interlocked.Decrement(longitud), longitud + 1)
            res.Append(caracteres(rnd.[Next](caracteres.Length)))
        End While
        Return res.ToString()
    End Function

    Sub Enviar_Correo()
        Dim EMail As String
        Dim message As New MailMessage
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
            .Bcc.Add("sdquijano@gmail.com")
            strSQL = ""
            strSQL = strSQL & "<!DOCTYPE html>"
            strSQL = strSQL & "<html lang = en >"
            strSQL = strSQL & "<head>"
            strSQL = strSQL & "<meta charset=UTF-8>"
            strSQL = strSQL & "<meta name=viewport content=width=device-width, initial-scale=1.0>"
            strSQL = strSQL & "<title>Alta Usuario</title>"
            strSQL = strSQL & "</head>"
            strSQL = strSQL & "<body>"
            strSQL = strSQL & "<font size = 4px >"
            strSQL = strSQL & "Por este medio le hago llegar su Usuario y Contraseña para realizar Pedidos en la Aplicacion y WEB"
            strSQL = strSQL & "</font>"
            strSQL = strSQL & "<P></P>"
            strSQL = strSQL & "<font size = 4px >"
            strSQL = strSQL & "Usuario: " & txtEmail.Text
            strSQL = strSQL & "</font>"
            strSQL = strSQL & "<P></P>"
            strSQL = strSQL & "<font size = 4px >"
            strSQL = strSQL & "Password: " & txtPassword.Text
            strSQL = strSQL & "</font>"
            strSQL = strSQL & "</body>"
            strSQL = strSQL & "</html>"
            .Body = strSQL
            .Subject = "Usuario Pedidos"
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

    Private Sub cmdEnviar_Click(sender As Object, e As EventArgs) Handles cmdEnviar.Click
        If Len(txtEmail.Text) = 0 Then
            MsgBox("Debe asignarle un Correo primero", vbInformation)
            Exit Sub
        End If
        If Len(txtTarjeta.Text) = 0 Then
            MsgBox("Debe de generar un Numero de Tarjeta para poder asignarle usuario de pedido", vbInformation)
            Exit Sub
        End If
        Enviar_Correo()
        cnnMy = New MySqlConnection("server=162.222.225.91;database=efect571_efectivo;Uid=efect571;password=Efec1@N2017$;port=3306;")
        cnnMy.Open()

        strSQL = ""
        strSQL = strSQL & "Select COUNT(*) as Total From usuarios Where correo = '" & txtEmail.Text & "'"
        commMy = New MySqlCommand(strSQL, cnnMy)

        rs = commMy.ExecuteReader

        While rs.Read
            If rs(0) > 0 Then
                strSQL = ""
                strSQL = strSQL & "UPDATE usuarios SET contrasenia = '" & txtPassword.Text & "' "
                strSQL = strSQL & "WHERE correo = '" & txtEmail.Text & "'"
            Else
                strSQL = ""
                strSQL = strSQL & "INSERT INTO usuarios VALUES("
                strSQL = strSQL & "'" & txtCliente.Text & "', '" & txtEmail.Text & "', "
                strSQL = strSQL & "'" & txtPassword.Text & "', '" & txtTarjeta.Text & "', 1, 0)"
            End If
        End While
        rs.Close()
        commMy2 = New MySqlCommand(strSQL, cnnMy)
        commMy2.ExecuteNonQuery()
        rs.Close()
        cnnMy.Close()
        Me.Close()
    End Sub
End Class
