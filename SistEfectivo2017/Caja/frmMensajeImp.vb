Public Class frmMensajeImp
    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmMensajeImp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim reader = My.Computer.FileSystem.ReadAllText("D:\Mensajes\mensaje.txt")
        lbMensaje.Text = reader
    End Sub
End Class