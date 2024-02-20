Public Class FrmVerificacionAut
    Public folio, cliente, sucursal As String
    Public autorizo As Boolean = False
    Dim oremisioMC As New remisioMC

    Private Sub vBtnCancelar_Click(sender As Object, e As EventArgs) Handles vBtnCancelar.Click
        autorizo = False
        Me.Close()
    End Sub

    Private Sub vbtnVerificacion_Click(sender As Object, e As EventArgs) Handles vbtnVerificacion.Click
        If oremisioMC.ChequeAutorizacion(cliente, sucursal, folio) > 0 Then
            autorizo = True
            Me.Close()
        End If
    End Sub
End Class