Public Class FrmDialogo
    Public devolucion As String
    Private Sub FrmDialogo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtDevolucion.Text = "0"
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If TxtDevolucion.Text = "" Then
            MsgBox("No puedes dejar vacío el campo de devolución", MsgBoxStyle.Information)
        ElseIf CInt(TxtDevolucion.Text) = 0 Then
            MsgBox("No Puede ser menor a 1 el campo de devolución", MsgBoxStyle.Information)
        Else
            devolucion = TxtDevolucion.Text
            Me.Close()
        End If
    End Sub
End Class