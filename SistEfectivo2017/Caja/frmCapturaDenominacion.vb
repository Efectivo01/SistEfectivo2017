Public Class frmCapturaDenominacion
    Public TotalDivisa As Decimal
    Dim Suma As Decimal
    Private Sub frmCapturaDenominacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtD1.Text = 0
        txtD5.Text = 0
        txtD10.Text = 0
        txtD20.Text = 0
        txtD50.Text = 0
        txtD100.Text = 0
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        If MsgBox("Estan correctos los importes?", vbOKCancel) = vbOK Then
            Suma = 0
            Suma = Suma + (txtD1.Text * 1)
            Suma = Suma + (txtD5.Text * 5)
            Suma = Suma + (txtD10.Text * 10)
            Suma = Suma + (txtD20.Text * 20)
            Suma = Suma + (txtD50.Text * 50)
            Suma = Suma + (txtD100.Text * 100)
            If TotalDivisa <> Suma Then
                MsgBox("La Suma de las divisas es diferente al Total", vbInformation)
                Exit Sub
            End If
            Me.Close()
        End If
    End Sub
End Class