Imports System.Drawing

Public Class frmCobro
    Public CobroTotal As Double
    Public TotalEfectivo As Double
    Public Aceptar As Boolean
    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        If txtEfectivo.Text.Trim <> "" Then
            If CDbl(txtEfectivo.Text) >= CDbl(lbTotal.Text) Then
                TotalEfectivo = CDbl(txtEfectivo.Text)
                Aceptar = True
                Me.Close()
            Else
                Dim frm As New frmMensajeImp
                frm.ShowDialog()
                txtEfectivo.Focus()
            End If
        Else
            Dim frm As New frmMensajeImp
            frm.ShowDialog()
            txtEfectivo.Focus()
        End If

    End Sub

    Private Sub txtEfectivo_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivo.TextChanged
        If txtEfectivo.Text <> "" Then
            lbCambio.Text = FormatCurrency(CDbl(txtEfectivo.Text) - CobroTotal)
        Else
            lbCambio.Text = FormatCurrency(CobroTotal)
            lbCambio.BackColor = Color.Tomato
            txtEfectivo.BackColor = Color.Tomato
        End If
        If CDbl(lbCambio.Text) < 0 Then
            lbCambio.BackColor = Color.Tomato
            txtEfectivo.BackColor = Color.Tomato
        Else
            If txtEfectivo.Text = "" Then
                lbCambio.BackColor = Color.Tomato
                txtEfectivo.BackColor = Color.Tomato
            Else
                lbCambio.BackColor = Color.Green
                txtEfectivo.BackColor = Color.Green
            End If
        End If
    End Sub

    Private Sub frmCobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbTotal.Text = FormatCurrency(CobroTotal)
        lbCambio.Text = FormatCurrency(CobroTotal)
        txtEfectivo.BackColor = Color.Tomato
        Aceptar = False
        txtEfectivo.Focus()
    End Sub

    'Private Sub frmCobro_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '    If e.CloseReason = 3 Then
    '        If TotalEfectivo <= 0 Then
    '            e.Cancel = True ' Se cancela la solicitud de cerrar
    '        Else
    '            e.Cancel = False
    '        End If
    '    End If
    'End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Aceptar = False
        Me.Close()
    End Sub
End Class