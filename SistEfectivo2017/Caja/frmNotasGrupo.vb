Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing.Printing

Public Class frmNotasGrupo
    Dim TarjetaCompra As String
    Dim Reporte As New ReportDocument ' para reportes
    Dim ocaja_diario2C As caja_diario2C ' para reportes
    Dim otinventario2C As tinventario2C ' para reportes
    Dim ocaja_diarioM As caja_diarioM ' para reportes
    Dim omovimientosC As movimientosC ' para reportes
    Dim Conectar As New ConexionSQLS
    'Dim ocontrolC As controlC
    Dim oCAJAM As CAJAM
    Dim oCAJAC As CAJAC
    Dim oPermitirOtrosC As New PermitirOtrosC
    Dim oremisioMM, oremisioMM2 As remisioMM
    Dim oremisioMC As remisioMC
    Dim oremisioDM As remisioDM
    Dim oremisioDCA As remisioDCA
    Dim oremisioDC As remisioDC
    Dim oauxiliares As auxiliares
    Dim oclientescnbvM As clientescnbvM
    Dim oclientescnbvC As clientescnbvC
    Dim oReportesUnicosC As ReportesUnicosC
    Dim strSQL, Cadena As String
    Dim cmd As SqlCommand
    Dim rs As SqlDataReader
    Dim Trans As SqlTransaction
    Dim FolioNota As String
    Dim CantD1, CantD5, CantD10, CantD20, CantD50, CantD100, TotalDivisas As Decimal
    Dim idcli, CoV, Impresora1 As String
    Dim NoCajero As Integer

    Private Sub frmNotasGrupo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CoV = "COMPRA"
    End Sub

    Dim precioCoV, Incentivo, Importe_Incentivo As Decimal
    Dim cambio As Boolean

    Sub Generar_Notas(ByVal Cliente As String)

        Remision("A")

        If oremisioMC.ValidaRemision(oremisioMM.folio_factura, oremisioMM.Nosucursal, oremisioMM.fecha) = 0 Then
            'checar si es de alto riesgo
            cmd.Connection = Conectar.EstablecerConexion
            Conectar.AbrirConexion()
            Trans = Conectar.con.BeginTransaction

            Try
                Cadena = ""
                Cadena = Cadena & "INSERT INTO remisioM("
                Cadena = Cadena & "   folio_factura, "
                Cadena = Cadena & "   fecha, "
                Cadena = Cadena & "   tipo, "
                Cadena = Cadena & "   cliente, "
                Cadena = Cadena & "   vendedor, "
                Cadena = Cadena & "   condiciones, "
                Cadena = Cadena & "   estatus, "
                Cadena = Cadena & "   stotal, "
                Cadena = Cadena & "   iva, "
                Cadena = Cadena & "   total, "
                Cadena = Cadena & "   observaciones, "
                Cadena = Cadena & "   moneda, "
                Cadena = Cadena & "   letras, "
                Cadena = Cadena & "   cajero, "
                Cadena = Cadena & "   ncorte, "
                Cadena = Cadena & "   hora, "
                Cadena = Cadena & "   Nosucursal, "
                Cadena = Cadena & "   precio_especial, "
                Cadena = Cadena & "   cambio) "
                Cadena = Cadena & "VALUES("
                Cadena = Cadena & oremisioMM.folio_factura & " ,"
                Cadena = Cadena & "'" & oremisioMM.fecha.ToString("dd/MM/yyyy") & "', "
                Cadena = Cadena & "'" & oremisioMM.tipo & "', "
                Cadena = Cadena & oremisioMM.cliente & ", "
                Cadena = Cadena & oremisioMM.vendedor & ", "
                Cadena = Cadena & "'" & oremisioMM.condiciones & "', "
                Cadena = Cadena & "'" & oremisioMM.estatus & "', "
                Cadena = Cadena & oremisioMM.stotal & ", "
                Cadena = Cadena & oremisioMM.iva & ", "
                Cadena = Cadena & oremisioMM.total & ", "
                Cadena = Cadena & "'" & oremisioMM.observaciones & "', "
                Cadena = Cadena & oremisioMM.moneda & ", "
                Cadena = Cadena & "'" & oremisioMM.letras & "', "
                Cadena = Cadena & oremisioMM.cajero & ", "
                Cadena = Cadena & oremisioMM.ncorte & ", "
                Cadena = Cadena & "'" & oremisioMM.hora.ToString("dd/MM/yyyy HH:mm:ss") & "', "
                Cadena = Cadena & "'" & oremisioMM.Nosucursal & "', "
                Cadena = Cadena & "'" & oremisioMM.precio_especial & "', "
                Cadena = Cadena & "'" & oremisioMM.cambio & "')"

                cmd = New SqlCommand(Cadena, Conectar.con)
                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()

                AsignaCAJA()
                If oCAJAC.ValidaCaja(oCAJAM.Folio, oCAJAM.sucursal, oCAJAM.Fecha) = 0 Then
                    Cadena = ""
                    Cadena = Cadena & "INSERT INTO CAJA("
                    Cadena = Cadena & " Fecha, "
                    Cadena = Cadena & " movimiento, "
                    Cadena = Cadena & " tipo, "
                    Cadena = Cadena & " Referencia, "
                    Cadena = Cadena & " BC, "
                    Cadena = Cadena & " Folio, "
                    Cadena = Cadena & " TOTAL, "
                    Cadena = Cadena & " valor, "
                    Cadena = Cadena & " NoSucursal) "
                    Cadena = Cadena & "VALUES("
                    Cadena = Cadena & "'" & oCAJAM.Fecha.ToString("dd/MM/yyyy") & "', "
                    Cadena = Cadena & "'" & oCAJAM.movimiento & "', "
                    Cadena = Cadena & "'" & oCAJAM.tipo & "', "
                    Cadena = Cadena & "'" & oCAJAM.Referencia & "',"
                    Cadena = Cadena & "'" & oCAJAM.BC & "',"
                    Cadena = Cadena & oCAJAM.Folio & ", "
                    Cadena = Cadena & oCAJAM.TOTAL & ", "
                    Cadena = Cadena & oCAJAM.valor & ", "
                    Cadena = Cadena & "'" & oCAJAM.sucursal & "')"

                    cmd = New SqlCommand(Cadena, Conectar.con)
                    cmd.Transaction = Trans
                    cmd.ExecuteNonQuery()
                End If

                Cadena = ""
                Cadena = Cadena & "UPDATE "
                Cadena = Cadena & " Sucursales "
                Cadena = Cadena & "SET "
                Cadena = Cadena & " folio_remision = folio_remision + 1 "
                Cadena = Cadena & "WHERE "
                Cadena = Cadena & " id = '" & NoSucursal & "'"
                cmd = New SqlCommand(Cadena, Conectar.con)
                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()

                DetallesRemision()
                ImpresoraName()

                Trans.Commit()

            Catch ex As Exception
                MessageBox.Show("HUBO UN PROBLEMA CON EL PROCESAMIENTO DE INFORMACIÓN, DEBERA CAPTURAR DE NUEVO ESTA NOTA, " + Chr(13) + "" &
                                     "PORFAVOR ESPERE A QUE SE LIMPIEN LOS DATOS")
                MsgBox(ex.Message, vbInformation)
                Trans.Rollback()
                Conectar.CerrarConexion()
                Exit Sub
            End Try

            '------------------------------------------------------------------------------
            If MsgBox("¿DESEA IMPRIMIR LA NOTA?", MsgBoxStyle.YesNo, "CONFIRMAR") = MsgBoxResult.Yes Then
                Dim Nota = New Notacv
                Try
                    Dim datosds As New DataSet
                    datosds = oReportesUnicosC.ImprimeNota2(idcli, FolioNota, NOsucursal)
                    Nota.SetDataSource(datosds)
                    Nota.PrintOptions.PrinterName = Impresora1
                    Nota.PrintToPrinter(1, False, 0, 0)

                    Nota.Close()
                    Nota.Dispose()
                    Nota.Close()
                Catch ex As Exception
                    Nota.Close()
                    Nota.Dispose()
                    MessageBox.Show("HUBO UN PROBLEMA CON LA IMPRESIÓN DE LA NOTA, SIN EMBARGO SI SE REGISTRO ESTA OPERACIÓN EN EL SISTEMA")
                    Me.Cursor = Cursors.Default
                End Try
            End If

            Try
                If idcli <> 1229 And CoV = "COMPRA" Then
                    Dim totalDlls As Double = CDbl(TotalDivisas)
                    Dim Conta As Integer
                    Dim ConLetras As String
                    Incentivo = 0.025
                    Importe_Incentivo = totalDlls * Incentivo
                    ConLetras = oauxiliares.EnLetras(Convert.ToDouble(Importe_Incentivo)).ToUpper()

                    If ConLetras.Contains("CON") Then
                        ConLetras = ConLetras.Replace("CON", "PESOS CON ") & "/100 M.N."
                    Else
                        ConLetras += " PESOS 00/100 M.N."
                    End If
                    Conta = oclientescnbvC.Grabar_Nota_Cargo(idcli, Now, Importe_Incentivo, oremisioMM.folio_factura, oremisioMM.Nosucursal, ConLetras)
                    Dim NotasCar As New NotaIN
                    cambio = False
                    Dim datosNI As New DataSet
                    datosNI = oReportesUnicosC.ImprimeNotaCargo(idcli, Conta, oremisioMM.Nosucursal)
                    NotasCar.SetDataSource(datosNI)
                    NotasCar.PrintOptions.PrinterName = Impresora1
                    NotasCar.PrintToPrinter(1, False, 0, 0)

                    NotasCar.Close()
                    NotasCar.Dispose()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        Else
            MessageBox.Show("YA HAY UNA NOTA CON ESTE FOLIO, VERIFIQUE QUE NO TENGA LOS MISMOS DATOS QUE EN PANTALLA (DESDE EL MENU REPORTES)," + Chr(13) + "" &
                                """AL CERRAR ESTE MENSAJE EL NUMERO DE FOLIO HABRÁ CAMBIADO, REVISE EL NÚMERO ANTERIOR"" Y " + Chr(13) + "" &
                                "*SI NO HAY COINCIDENCIA, PRESIONE EL BOTÓN IMPRIMIR," + Chr(13) + "*SI HAY COINCIDENCIA, PRESIONE EL BOTÓN REINICIAR NOTA")
            txtFolio.Text = (Convert.ToInt32(txtFolio.Text) + 1).ToString
            si = False

            If oremisioMC.UFolioRemision(NOsucursal) < Convert.ToInt32(txtFolio.Text) Then
                oremisioMC.MFolioRemision(NOsucursal)
            Else
                txtFolio.Text = oremisioMC.UFolioRemision(NOsucursal)
            End If

        End If

    End Sub

    Private Sub Remision(ByVal accion As String)
        Dim stotal As String
        strSQL = ""
        strSQL = strSQL & "Select MAX(CAST(folio_factura as INT)) + 1 as Folio "
        strSQL = strSQL & "From remisioM Where Nosucursal = '" & NOsucursal & "'"

        cmd = New SqlCommand(strSQL, Conectar.con)
        rs = cmd.ExecuteReader

        While rs.Read
            FolioNota = rs(0).ToString
        End While
        rs.Close()

        oremisioMM.folio_factura = FolioNota
        oremisioMM.fecha = Now.Date ' dtpFecha.Value 'dtpFecha.Text.Trim
        oremisioMM.tipo = "DIVISAS"
        oremisioMM.cliente = idcli
        oremisioMM.vendedor = 0
        oremisioMM.moneda = 1
        oremisioMM.condiciones = ""
        oremisioMM.estatus = "1"
        stotal = (Val(Convert.ToDouble(TotalDivisas * precioCoV)))

        oremisioMM.stotal = FormatNumber(Convert.ToDouble(stotal), 2)

        oremisioMM.iva = 0
        oremisioMM.total = FormatNumber(oremisioMM.stotal, 2)
        oremisioMM.observaciones = "COMPRA"
        oremisioMM.letras = oauxiliares.EnLetras(Convert.ToDouble(stotal)).ToUpper
        If oremisioMM.letras.Contains("CON") Then
            oremisioMM.letras = oremisioMM.letras.Replace("CON", "PESOS CON ") & "/100 M.N."
        Else
            oremisioMM.letras += " PESOS 00/100 M.N."
        End If
        oremisioMM.cajero = NoCajero
        oremisioMM.ncorte = 0
        'dtHora.Value = DateTime.Now
        oremisioMM.hora = DateTime.Now 'dtHora.Value
        oremisioMM.Nosucursal = NOsucursal
        Select Case CoV
            Case "COMPRA"
                oremisioMM.precio_especial = ""
            Case "VENTA"
                oremisioMM.precio_especial = ""
        End Select
        oremisioMM.cambio = "NO"
    End Sub

    Private Sub cmdGenerar_Click(sender As Object, e As EventArgs) Handles cmdGenerar.Click
        Dim frm As New frmCapturaDenominacion

        For I = 0 To lvClientes.Items.Count - 1
            frm.TotalDivisa = lvClientes.Items(I).SubItems(1).Text
            TotalDivisas = lvClientes.Items(I).SubItems(1).Text
            frm.ShowDialog()
            CantD1 = frm.txtD1.Text
            CantD5 = frm.txtD5.Text
            CantD10 = frm.txtD10.Text
            CantD20 = frm.txtD20.Text
            CantD50 = frm.txtD50.Text
            CantD100 = frm.txtD100.Text
            idcli = lvClientes.Items(I).Text
            Generar_Notas(lvClientes.Items(I).Text)
        Next
    End Sub

    Private Sub txtCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCliente.KeyPress
        TarjetaCompra = txtCliente.Text

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If Mid(TarjetaCompra, Len(TarjetaCompra), 1) <> "P" Then
                MsgBox("Debe de escanear la tarjeta", vbInformation)
                Exit Sub
            End If
            txtCliente.Text = TarjetaCompra.Substring(0, Len(TarjetaCompra) - 1)
            lbNombre.Text = oclientescnbvC.Buscar_Nombre(txtCliente.Text)
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Dim TotalLineas As Integer
            TotalLineas = lvClientes.Items.Count
            If TotalLineas < 0 Then
                TotalLineas = 0
            Else
                TotalLineas = TotalLineas - 1
            End If
            lvClientes.Items.Add(txtCliente.Text)
            lvClientes.Items(TotalLineas).SubItems.Add(lbNombre.Text)
            lvClientes.Items(TotalLineas).SubItems.Add(txtCantidad.Text)
        End If
    End Sub

    Private Sub ImpresoraName()
        Dim a As PrinterSettings = New PrinterSettings()
        For i As Integer = 0 To PrinterSettings.InstalledPrinters.Count - 1 Step i + 1
            a.PrinterName = PrinterSettings.InstalledPrinters(i).ToString()
            If a.IsDefaultPrinter Then
                Impresora1 = PrinterSettings.InstalledPrinters(i).ToString()
            End If
        Next
    End Sub

    Private Sub DetallesRemision()
        Dim valor As String
        For denominacion As Integer = 0 To dgvCoV.Rows.Count - 1
            If dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString <> "" And
                dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString <> "" Then
                valor = dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString
                valor = valor.Replace("C", "")
                valor = valor.Replace("D", "")
                valor = valor.Replace("E", "")
                valor = valor.Replace("L", "")
                If oremisioMM.folio_factura IsNot Nothing Then
                    oremisioDM.folio_factura = oremisioMM.folio_factura
                Else
                    oremisioDM.folio_factura = oremisioMC.UFolioRemision(No_sucursal)
                End If
                oremisioDM.producto = dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString

                oremisioDM.cantidads = Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString) * Convert.ToDouble(valor)
                oremisioDM.p_unitario = Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString) _
                / (Convert.ToDouble(valor) * Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString))
                oremisioDM.stotal = dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString

                oremisioDM.descuento = 0
                oremisioDM.capacidad = "1"
                oremisioDM.unidad = "1"
                oremisioDM.descripcion_larga = dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString & " billetes de " & dgvCoV.Rows(denominacion).Cells("Nombre").Value.ToString
                oremisioDM.Nosucursal = NOsucursal
                oremisioDM.fecha = Now.Date 'dtpFecha.Value.ToShortDateString
                oremisioDM.operacion = "C"
                If cambio Then
                    oremisioDC.AremisioCA_ENT(oremisioDM)
                Else

                    Cadena = ""
                    Cadena = Cadena & "INSERT INTO remisioD("
                    Cadena = Cadena & " folio_factura, "
                    Cadena = Cadena & " producto, "
                    Cadena = Cadena & " cantidads, "
                    Cadena = Cadena & " p_unitario, "
                    Cadena = Cadena & " stotal, "
                    Cadena = Cadena & " descuento, "
                    Cadena = Cadena & " capacidad, "
                    Cadena = Cadena & " unidad, "
                    Cadena = Cadena & " descripcion_larga, "
                    Cadena = Cadena & " Nosucursal, "
                    Cadena = Cadena & " fecha, "
                    Cadena = Cadena & " operacion) "
                    Cadena = Cadena & "VALUES( "
                    Cadena = Cadena & "'" & oremisioDM.folio_factura & "', "
                    Cadena = Cadena & "'" & oremisioDM.producto & "', "
                    Cadena = Cadena & oremisioDM.cantidads & ", "
                    Cadena = Cadena & oremisioDM.p_unitario & ","
                    Cadena = Cadena & oremisioDM.stotal & ", "
                    Cadena = Cadena & oremisioDM.descuento & ", "
                    Cadena = Cadena & "'" & oremisioDM.capacidad & "', "
                    Cadena = Cadena & "'" & oremisioDM.unidad & "', "
                    Cadena = Cadena & "'" & oremisioDM.descripcion_larga & "', "
                    Cadena = Cadena & "'" & oremisioDM.Nosucursal & "', "
                    Cadena = Cadena & "'" & oremisioDM.fecha.ToString("dd/MM/yyyy") & "', "
                    Cadena = Cadena & "'" & oremisioDM.operacion & "')"
                    cmd = New SqlCommand(Cadena, Conectar.con)
                    cmd.Transaction = Trans
                    cmd.ExecuteNonQuery()

                End If

                Cadena = ""
                Cadena = Cadena & "UPDATE "
                Cadena = Cadena & " Existencia "
                Cadena = Cadena & "SET "
                Cadena = Cadena & " en = en + " & Convert.ToInt32(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString) & ", "
                Cadena = Cadena & " sf = sf + " & Convert.ToInt32(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString) & ", "
                Cadena = Cadena & " precio = " & Convert.ToDouble(dt1.Rows(tipdivi - 1)("Compra").ToString) & " "
                Cadena = Cadena & "WHERE "
                Cadena = Cadena & " fecha = '" & oremisioDM.fecha.ToString("dd/MM/yyyy") & "' AND "
                Cadena = Cadena & " nosucursal = '" & oremisioDM.Nosucursal & "' AND "
                Cadena = Cadena & " divisa = '" & oremisioDM.producto & "'"
                cmd = New SqlCommand(Cadena, Conectar.con)
                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()

                Cadena = ""
                Cadena = Cadena & "UPDATE "
                Cadena = Cadena & " Existencia "
                Cadena = Cadena & "SET "
                Cadena = Cadena & " precio = " & Convert.ToDouble(dt1.Rows(tipdivi - 1)("Compra").ToString) & " "
                Cadena = Cadena & "WHERE "
                Cadena = Cadena & " fecha = '" & oremisioDM.fecha.ToString("dd/MM/yyyy") & "' AND "
                Cadena = Cadena & " nosucursal = '" & NOsucursal & "' AND "
                Cadena = Cadena & " tipo = " & 1
                cmd = New SqlCommand(Cadena, Conectar.con)
                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()

                valor = ""
            End If
        Next
    End Sub
End Class