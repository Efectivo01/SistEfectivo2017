Imports System.IO
Imports System.IO.StreamReader
Imports System.Drawing.Printing
Imports System.Drawing

Public Class Traspasos
    Dim oCAJAM As CAJAM
    Dim oCAJAC As CAJAC
    Dim oBovedaM As BovedaM
    Dim oauxiliares As New auxiliares
    Public cajero_name, sucursal As String

    Private Sub Traspasos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oCAJAM = Nothing
        oCAJAC.Dispose()
        oBovedaM = Nothing
        oauxiliares.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Traspasos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecha.Text = Date.Now.ToShortDateString
        oCAJAM = New CAJAM
        oCAJAC = New CAJAC
        oBovedaM = New BovedaM
    End Sub

    Private Sub btnDe_Click(sender As Object, e As EventArgs) Handles btnDe.Click
        lblTipoDe.Text = "TRASPASO DE BOVEDA"
        btn1.BackColor = Color.Green
        oCAJAM.movimiento = "1"
        oCAJAM.tipo = "E"
        oCAJAM.Referencia = "Traspaso de Boveda"
        oCAJAM.BC = "B"
        txtCantidad.Focus()
    End Sub

    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        lblTipoDe.Text = "TRASPASO A BOVEDA"
        btn1.BackColor = Color.Red
        oCAJAM.movimiento = "12"
        oCAJAM.tipo = "S"
        oCAJAM.Referencia = "Traspaso a Boveda"
        oCAJAM.BC = "B"
        txtCantidad.Focus()
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Close()
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        AsignarTraspaso()
        Try
            If oCAJAC.Alta(oCAJAM) > 0 Then
                If oCAJAC.MovimientoB(oBovedaM) > 0 Then
                    MessageBox.Show("EL TRASPASO HA SIDO COMPLETADO")
                End If
            End If
            Dim dialogResult As DialogResult = MessageBox.Show("¿DESEA IMPRIMIR LA NOTA?", "Some Title", MessageBoxButtons.YesNo)
            If dialogResult = DialogResult.Yes Then
                Dim oSW As New StreamWriter("NOTA_Traspasos.txt")
                Dim Linea As String = "               EFECTIVO" &
                vbNewLine & "           Triton Software" &
                vbNewLine & "                Merida" &
                vbNewLine & "           MeridaTel.9268846" &
                vbNewLine & "               RFC : RFC" &
                vbNewLine & "" &
                vbNewLine & "** COMPROBANTE de GASTOS **" &
                vbNewLine & "" &
                vbNewLine & "CAJERO : " & "" &
                vbNewLine & "FECHA  :" & Date.Now &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "TIPO : " & lblTipoDe.Text &
                vbNewLine & "TOTAL :  $" & oCAJAM.TOTAL &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "-----------------------------" &
                vbNewLine & "     C A J E R O -A-" &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "-----------------------------" &
                vbNewLine & "RECIBIO (Nombre y Firma)"
                oSW.WriteLine(Linea)
                oSW.Flush()
                oSW.Dispose()

                Process.Start("notepad.exe", "NOTA_Traspasos.txt")

            ElseIf dialogResult = DialogResult.No Then
            End If
        Catch ex As Exception
            MessageBox.Show("REGISTRO DE TRASPASO CONCLUIDO")
        End Try
    End Sub

#Region "Eventos Texbox Keypress y Leave"
    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtFecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFecha.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtCantidad_Enter(sender As Object, e As EventArgs) Handles txtCantidad.Enter
        txtCantidad.Text = ""
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        oauxiliares.SoloNumeros2(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) And IsNumeric(txtCantidad.Text) Then
            e.Handled = True
            txtCantidad.Text = "$" & FormatNumber(txtCantidad.Text.Trim, 2)
            'txtTotal.Text = "$" & FormatNumber(txtCantidad.Text.Trim, 2)
            txtDescripcion.Focus()
        End If
    End Sub

    Private Sub txtCantidad_Leave(sender As Object, e As EventArgs) Handles txtCantidad.Leave
        If IsNumeric(txtCantidad.Text) Then
            txtCantidad.Text = "$" & FormatNumber(txtCantidad.Text.Trim, 2)
            'txtTotal.Text = "$" & FormatNumber(txtCantidad.Text.Trim, 2)
        End If
    End Sub

    Private Sub txtDescripcion_Leave(sender As Object, e As EventArgs) Handles txtDescripcion.Leave
        txtDescripcion.Text = txtDescripcion.Text.ToUpper
    End Sub
#End Region

    Private Sub AsignarTraspaso()
        oCAJAM.Fecha = txtFecha.Text
        oCAJAM.Folio = 0
        oCAJAM.TOTAL = Convert.ToDouble(txtCantidad.Text.Trim.Replace("$", ""))
        oCAJAM.valor = 0
        oCAJAM.sucursal = sucursal
        If oCAJAM.movimiento Is Nothing Or oCAJAM.tipo Is Nothing Or oCAJAM.Referencia Is Nothing Or oCAJAM.BC Is Nothing Then
            MessageBox.Show("NO PRESIONO UN BOTON QUE INDIQUE EL TIPO DE TRASPASO, PORFAVOR PRESIONE UNO")
        Else
            AsignarTraspasoDet()
        End If
    End Sub

    Private Sub AsignarTraspasoDet()
        oBovedaM.movimiento = oCAJAM.movimiento
        oBovedaM.TOTAL = oCAJAM.TOTAL
        oBovedaM.descripcion = Trim(txtDescripcion.Text)
        oBovedaM.usuario = Trim(txtNombre.Text)
        oBovedaM.Fecha = oCAJAM.Fecha
        oBovedaM.sucursal = oCAJAM.sucursal
    End Sub

End Class