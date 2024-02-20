Imports System.IO
Imports System.IO.StreamReader
Imports System.Drawing.Printing
Imports System.Drawing

Public Class FrmGatos
    'Sección para instancias de las clases usadas en este form
    Dim ogastosM As gastosM
    Dim ogastosC As gastosC
    Dim oCAJAM As CAJAM
    Dim oconcepto_gastosM As concepto_gastosM
    Dim oconcepto_gastosC As concepto_gastosC
    Dim oauxiliares As New auxiliares

    'Sección para variables usadas en este form
    Public cajero_name As String
    Public cajero As Integer
    Public No_sucursal As String

    Private Sub FrmGatos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oconcepto_gastosM = Nothing
        oconcepto_gastosC.Dispose()
        ogastosM = Nothing
        ogastosC.Dispose()
        Me.Dispose()
    End Sub

    Private Sub FrmGatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ogastosM = New gastosM
        ogastosC = New gastosC
        oCAJAM = New CAJAM
        oconcepto_gastosC = New concepto_gastosC
        cmbTipoDe.DataSource = oconcepto_gastosC.BuscarTodo
        cmbTipoDe.DisplayMember = "nombre"
        cmbTipoDe.ValueMember = "concepto"
        'cmbTipoDe.Text = "Seleccione un concepto..."
        txtFecha.Text = Date.Now.ToShortDateString
    End Sub

#Region "botones"
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        If Not validacion() Then
            MsgBox("Llenar los campos que están de color rojo", MsgBoxStyle.Information)
            Exit Sub
        End If

        AsignarGasto()
        AsignaCAJA()
        Try
            Dim dialogResult As DialogResult = MessageBox.Show("¿DESEA IMPRIMIR LA NOTA?", "CONFIRMAR", MessageBoxButtons.YesNo)
            If dialogResult = DialogResult.Yes Then
                Dim oSW As New StreamWriter("NOTA_Gastos.txt")
                Dim Linea As String = "               EFECTIVO" &
                vbNewLine & "           Triton Software" &
                vbNewLine & "                Merida" &
                vbNewLine & "           MeridaTel.9268846" &
                vbNewLine & "               RFC : RFC" &
                vbNewLine & "" &
                vbNewLine & "** COMPROBANTE de GASTOS **" &
                vbNewLine & "" &
                vbNewLine & "CAJERO : " & ogastosM.cajero &
                vbNewLine & "FECHA  :" & ogastosM.hora &
                vbNewLine & "CORTE  :" &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "TIPO : " & ogastosM.concepto &
                vbNewLine & "TOTAL :  $" & ogastosM.total &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "" &
                vbNewLine & "-----------------------------" &
                vbNewLine & "     C A J E R O -A-"
                oSW.WriteLine(Linea)
                oSW.Flush()
                oSW.Dispose()

                Process.Start("notepad.exe", "NOTA_Gastos.txt")
                ogastosC.Alta(ogastosM)
                If ogastosC.AltaEnCAJA(oCAJAM) > 0 Then
                    MessageBox.Show("REGISTRO DE GASTO CONCLUIDO")
                    'txtCantidad.Text = "$0"
                    txtTotal.Text = "$0"
                    txtFolio.Text = ""
                    txtDescripcion.Text = ""
                Else
                    MessageBox.Show("EL GASTO SE REGISTRO PERO NO EN CAJA")
                    'txtCantidad.Text = "$0"
                    txtTotal.Text = "$0"
                    txtFolio.Text = ""
                    txtDescripcion.Text = ""
                End If
            ElseIf dialogResult = DialogResult.No Then
                ogastosC.Alta(ogastosM)
                If ogastosC.AltaEnCAJA(oCAJAM) > 0 Then
                    MessageBox.Show("REGISTRO DE GASTO CONCLUIDO")
                    'txtCantidad.Text = "$0"
                    txtTotal.Text = "$0"
                    txtFolio.Text = ""
                    txtDescripcion.Text = ""
                Else
                    MessageBox.Show("EL GASTO SE REGISTRO PERO NO EN CAJA")
                    'txtCantidad.Text = "$0"
                    txtTotal.Text = "$0"
                    txtFolio.Text = ""
                    txtDescripcion.Text = ""
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("REGISTRO DE GASTO NO CONCLUIDO")
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub
#End Region

#Region "Eventos Texbox Keypress y Leave"
    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub txtFecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFecha.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbTipoDe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbTipoDe.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtTotal_Enter(sender As Object, e As EventArgs) Handles txtTotal.Enter
        txtTotal.Text = "$0"
    End Sub

    Private Sub txtTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotal.KeyPress
        oauxiliares.SoloNumeros2(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) And IsNumeric(txtTotal.Text) Then
            e.Handled = True
            txtTotal.Text = "$" & FormatNumber(txtTotal.Text.Trim, 2)
            txtDescripcion.Focus()
        End If
    End Sub

    Private Sub txtTotal_Leave(sender As Object, e As EventArgs) Handles txtTotal.Leave
        If IsNumeric(txtTotal.Text) Then
            'txtCantidad.Text = "$" & FormatNumber(txtCantidad.Text.Trim, 2)
            txtTotal.Text = "$" & FormatNumber(txtTotal.Text.Trim, 2)
        End If
    End Sub

    Private Sub txtCantidad_Enter(sender As Object, e As EventArgs)
        'txtCantidad.Text = ""
        txtTotal.Text = "$0"
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs)
        oauxiliares.SoloNumeros2(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) And IsNumeric(txtTotal.Text) Then
            e.Handled = True
            'txtCantidad.Text = "$" & FormatNumber(txtCantidad.Text.Trim, 2)
            txtTotal.Text = "$" & FormatNumber(txtTotal.Text.Trim, 2)
            txtDescripcion.Focus()
        End If
    End Sub

    Private Sub txtCantidad_Leave(sender As Object, e As EventArgs)
        If IsNumeric(txtTotal.Text) Then
            'txtCantidad.Text = "$" & FormatNumber(txtCantidad.Text.Trim, 2)
            txtTotal.Text = "$" & FormatNumber(txtTotal.Text.Trim, 2)
        End If
    End Sub

    Private Sub txtDescripcion_Leave(sender As Object, e As EventArgs) Handles txtDescripcion.Leave
        txtDescripcion.Text = txtDescripcion.Text.ToUpper
    End Sub
#End Region

    Private Sub AsignarGasto()
        ogastosM.concepto = cmbTipoDe.SelectedValue
        ogastosM.fecha = Date.Now.ToShortDateString
        ogastosM.hora = DateTime.Now.ToLongTimeString
        ogastosM.cajero = cajero
        ogastosM.ncorte = 0
        ogastosM.total = FormatNumber(Convert.ToDouble(txtTotal.Text.Trim.Replace("$", "")), 2)
        ogastosM.referencia = txtDescripcion.Text
        ogastosM.Nosucursal = No_sucursal
        ogastosM.factura = txtFolio.Text
        ogastosM.usuario = FrmCaja.UsuarioL
        ogastosM.conceptoDet = IIf(CmbGastosDet.SelectedValue = Nothing, 0, CmbGastosDet.SelectedValue)
    End Sub

    Private Sub AsignaCAJA()
        oCAJAM.Fecha = ogastosM.fecha
        oCAJAM.movimiento = "14"
        oCAJAM.tipo = "S"
        oCAJAM.Referencia = "GASTOS " & ogastosM.referencia
        oCAJAM.BC = "G"
        oCAJAM.Folio = ogastosM.concepto
        oCAJAM.TOTAL = ogastosM.total
        oCAJAM.valor = 0.0
        oCAJAM.sucursal = ogastosM.Nosucursal
    End Sub

    Private Sub cmbTipoDe_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoDe.SelectedValueChanged
        Dim value As Object = cmbTipoDe.SelectedValue
        If (TypeOf value Is DataRowView) Then Return
        If cmbTipoDe.SelectedValue = "4" Then
            CmbGastosDet.Enabled = False
            txtDescripcion.Focus()
        Else
            CmbGastosDet.Enabled = True
            CmbGastosDet.DataSource = oconcepto_gastosC.GastosDetalle(cmbTipoDe.SelectedValue)
            CmbGastosDet.DisplayMember = "nombre"
            CmbGastosDet.ValueMember = "concepto_det"
            CmbGastosDet.Text = "Seleccione un concepto..."
        End If
    End Sub

    Private Function validacion() As Boolean
        Dim valor As Boolean = True
        If txtFolio.Text = "" Or txtFolio.Text.Length = 0 Then
            txtFolio.BackColor = Color.Red
            valor = False
        End If
        If txtDescripcion.Text = "" Or txtDescripcion.Text.Length = 0 Then
            txtDescripcion.BackColor = Color.Red
            valor = False
        End If
        If cmbTipoDe.SelectedIndex < 3 Then
            If CmbGastosDet.Text = "Seleccione un concepto..." Then
                CmbGastosDet.BackColor = Color.Red
                valor = False
            End If
        End If
        If txtTotal.Text = "" Or txtTotal.Text.Length = 0 Or txtTotal.Text = "$0" Then
            txtTotal.BackColor = Color.Red
            valor = False
        End If
        Return valor
    End Function

    Private Sub txtFolio_TextChanged(sender As Object, e As EventArgs) Handles txtFolio.TextChanged
        txtFolio.BackColor = Color.White
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcion.TextChanged
        txtDescripcion.BackColor = Color.White
    End Sub

    Private Sub CmbGastosDet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbGastosDet.SelectedIndexChanged
        CmbGastosDet.BackColor = Color.White
    End Sub

    Private Sub txtTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotal.TextChanged
        txtTotal.BackColor = Color.White
    End Sub
End Class