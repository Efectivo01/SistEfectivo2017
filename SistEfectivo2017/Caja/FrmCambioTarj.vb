Public Class FrmCambioTarj
    Public ClienteCamTar As Integer
    Dim oPuntos As New CPuntos
    Dim oauxiliares As New auxiliares
    Public cambio As Boolean = False
    Public TarjetaNueva As String

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If oPuntos.CambioTarjeta(ClienteCamTar, TxtTarjetaN.Text.Trim) > 0 Then
                If oPuntos.CambioTarjetaD(ClienteCamTar, TxtTarjetaN.Text.Trim) > 0 Then
                    If oPuntos.CambioTarjetaC(ClienteCamTar, TxtTarjetaN.Text.Trim) > 0 Then
                        MsgBox("Tarjeta Cambiada", MsgBoxStyle.Information)
                        cambio = True
                        TarjetaNueva = TxtTarjetaN.Text.Trim
                    Else
                        MsgBox("Error en el Sistema", MsgBoxStyle.Information)
                    End If
                End If
            End If
            Me.Close()
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub

    Private Sub TxtTarjetaN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTarjetaN.KeyPress
        oauxiliares.SoloNumerosLetras(e)
    End Sub
End Class