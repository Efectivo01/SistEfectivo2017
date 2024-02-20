Imports System.Data.SqlClient
Public Class FrmCambioD
    Public cliente As Integer
    Public No_Sucursal As String
    Public FolioFActura As Integer
    Public cantidadDV As Double
    Public TotalDev As Double
    Public totalvender As Integer
    Dim ruta_billeteimg As String = "billetes_gif\Denominaciones\" ' "..\..\images\Denominaciones\"
    Dim extencion_billeteimg As String = ".gif"
    Dim oExistenciaM As New ExistenciaM
    Dim oExistenciaC As New ExistenciaC
    Public PrecioD As Double
    Dim valor As Integer
    Dim codigoD, descripcionD As String
    Dim repetido As Boolean = False
    Dim ArchivoSer As System.IO.StreamReader
    Dim conser As String = ""
    Dim FechaAct As Date
    Private lector As SqlDataReader
    Dim dtbTabla As New System.Data.DataTable
    Dim estatus As Boolean

    Dim oremisioDM As New remisioDM
    Dim oremisioDC As New remisioDC
    Dim oremisioMM As New remisioMM
    Dim oremisioMC As New remisioMC
    Dim oauxiliares As New auxiliares
    Public cambioEfectuado As Boolean = False
    Private Sub FrmCambioD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvNoOrden(dgvCoV)
        Dim frm As New FrmDialogo
        frm.ShowDialog()
        txtmonto1.Text = frm.devolucion
        frm.Close()
        valor = 0
        codigoD = ""
        descripcionD = ""
        DTExistencia.AllowUserToAddRows = False

        dtbTabla.Columns.Add("Divisa")
        dtbTabla.Columns.Add("Existencia")
        FechaAct = Now.ToShortDateString
        CargarExistencia()

        With DTExistencia
            .Columns(0).Width = 45
            .Columns(1).Width = 80
        End With
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        cambioEfectuado = False
        Me.Close()
    End Sub

    Private Sub CargarExistencia()
        Dim dtrFila As DataRow
        Dim cmd As New SqlCommand

        ArchivoSer = New System.IO.StreamReader("servidor.txt")
        conser = ArchivoSer.ReadLine
        ArchivoSer.Close()

        Dim tConection As New SqlConnection(conser)

        'Conexion()
        tConection.Open()
        Dim consulta As String = "SELECT * FROM Existencia where fecha='" & FechaAct.ToString("dd/MM/yyyy") & "' and nosucursal='" & No_Sucursal & "' and tipo = 1"
        cmd = New SqlCommand(consulta, tConection)
        lector = cmd.ExecuteReader()
        While lector.Read
            dtrFila = dtbTabla.NewRow()
            dtrFila("Divisa") = lector("divisa")
            dtrFila("Existencia") = lector("sf")
            dtbTabla.Rows.Add(dtrFila)
        End While
        tConection.Close()
        DTExistencia.DataSource = dtbTabla
    End Sub

    Private Sub dgvNoOrden(ByVal dgv As DataGridView)
        Dim x As DataGridViewColumn
        For Each x In dgv.Columns
            x.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        x = Nothing
        dgv = Nothing
    End Sub

    Private Sub btn11_Click(sender As Object, e As EventArgs) Handles btn11.Click
        If btn14.BackgroundImage IsNot Nothing Then
            btn14.BackgroundImage = Nothing
        End If

        If btn13.Text.Replace("$", "") = "0" Or btn13.Text.Replace("$", "") = "" Or IsNumeric(btn13.Text.Replace("$", "")) = 0 Then 'no hay nada
            MessageBox.Show("NO PUEDE DEJAR 0 EN LA CANTIDAD, ESCRIBA OTRO NUMERO")
            btn13.Text = ""
            btn13.Focus()
        Else
            If btn13.Text <> "" Then
                Dim totalmn, totaldvs As Double
                totalmn = 0
                totaldvs = 0
                totalmn = Convert.ToDouble(btn13.Text) * valor
                totalmn = totalmn * PrecioD
                totaldvs = Convert.ToDouble(btn13.Text) * valor

                If Convert.ToDouble(txtmonto2.Text) + totaldvs > Convert.ToDouble(txtmonto1.Text) Then ' + totalmn > Convert.ToDouble(txtmonto1.Text) Then
                    MessageBox.Show("NO SE PUEDE PROPORCIANAR ESA CANTIDAD DE DIVISA PORQUE:" + Chr(13) + Chr(13) + "* EXEDE EL TOTAL SOLICITADO Y/O ES MAYOR A LO NECESARIO" + Chr(13) + Chr(13) + "PORFAVOR DIGITE UNA CANTIDAD MENOR")

                    btn13.Text = ""
                Else
                    validarExistencia()
                    If repetido = False Then
                        dgvCoV.Rows.Add(codigoD, descripcionD, btn13.Text, _
                                totalmn.ToString("##,##0.00"), PrecioD)

                        btn13.Text = ""
                        btn14.Text = ""
                        autosumaGridCoV()
                        valor = 0
                        codigoD = ""
                        descripcionD = ""
                    End If
                End If
            Else
                MessageBox.Show("DEBE ESCOGER UNA DIVISA Y PRESIONAR UNA CANTIDAD PARA CONTINUAR Ó VICEVERSA," + Chr(13) + " O BIEN ELEGIR SI ESTÁ REALIZANDO UNA COMPRA O VENTA")
                btn13.Text = ""
            End If
        End If
        btnb1.Focus()
    End Sub

    Private Sub autosumaGridCoV()
        Dim row As DataGridViewRow
        Dim totalMN, totalDIV As Decimal
        Dim extraer As String
        For Each row In dgvCoV.Rows
            If dgvCoV.Rows(row.Index).Cells(1).Value IsNot Nothing Then
                If dgvCoV.Rows(row.Index).Cells(1).Value.ToString() <> Nothing And IsNumeric(dgvCoV.Rows(row.Index).Cells(2).Value.ToString()) Then
                    If dgvCoV.Rows(row.Index).Cells(1).Value.ToString() <> Nothing Then
                        totalMN += Convert.ToDecimal(row.Cells(3).Value)
                        extraer = row.Cells(0).Value.ToString.Replace("C", "")
                        extraer = extraer.Replace("D", "")
                        extraer = extraer.Replace("E", "")
                        extraer = extraer.Replace("L", "")
                        totalDIV += Convert.ToDecimal(extraer) * Convert.ToDecimal(row.Cells(2).Value)
                    End If
                End If
            End If
        Next
        txtmonto2.Text = totalDIV ' (Format(totalDIV, "#########0.00")).ToString()
        btn12.Text = "$" & (Format(totalMN, "#########0.00")).ToString()
        row = Nothing
    End Sub

    Private Sub btnb1_Click(sender As Object, e As EventArgs) Handles btnb1.Click
        If btnb1.Text <> "" Then
            btn12.Text = "$0"
            codigoD = "D1"
            descripcionD = "DÓLAR 001"
            ValidarRepetido()
            btn14.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta_billeteimg & btnb1.Text & extencion_billeteimg)
            btn14.BackgroundImageLayout = PictureBoxSizeMode.StretchImage
            btn13.Focus()
            valor = 1

        Else
            MessageBox.Show("SELECCIONE UNA DIVISA")
        End If
    End Sub

    Private Sub btnb2_Click(sender As Object, e As EventArgs) Handles btnb2.Click
        If btnb1.Text <> "" Then
            btn12.Text = "$0"
            codigoD = "D5"
            descripcionD = "DÓLAR 005"
            ValidarRepetido()
            btn14.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta_billeteimg & btnb2.Text & extencion_billeteimg)
            btn14.BackgroundImageLayout = PictureBoxSizeMode.StretchImage
            btn13.Focus()
            valor = 5

        Else
            MessageBox.Show("SELECCIONE UNA DIVISA")
        End If
    End Sub

    Private Sub btnb3_Click(sender As Object, e As EventArgs) Handles btnb3.Click
        If btnb1.Text <> "" Then
            btn12.Text = "$0"
            codigoD = "D10"
            descripcionD = "DÓLAR 010"
            ValidarRepetido()
            btn14.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta_billeteimg & btnb3.Text & extencion_billeteimg)
            btn14.BackgroundImageLayout = PictureBoxSizeMode.StretchImage
            btn13.Focus()
            valor = 10

        Else
            MessageBox.Show("SELECCIONE UNA DIVISA")
        End If
    End Sub

    Private Sub btnb4_Click(sender As Object, e As EventArgs) Handles btnb4.Click
        If btnb1.Text <> "" Then
            btn12.Text = "$0"
            codigoD = "D20"
            descripcionD = "DÓLAR 020"
            ValidarRepetido()
            btn14.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta_billeteimg & btnb4.Text & extencion_billeteimg)
            btn14.BackgroundImageLayout = PictureBoxSizeMode.StretchImage
            btn13.Focus()
            valor = 20

        Else
            MessageBox.Show("SELECCIONE UNA DIVISA")
        End If
    End Sub

    Private Sub btnb5_Click(sender As Object, e As EventArgs) Handles btnb5.Click
        If btnb1.Text <> "" Then
            btn12.Text = "$0"
            codigoD = "D50"
            descripcionD = "DÓLAR 050"
            ValidarRepetido()
            btn14.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta_billeteimg & btnb5.Text & extencion_billeteimg)
            btn14.BackgroundImageLayout = PictureBoxSizeMode.StretchImage
            btn13.Focus()
            valor = 50

        Else
            MessageBox.Show("SELECCIONE UNA DIVISA")
        End If
    End Sub

    Private Sub btnb6_Click(sender As Object, e As EventArgs) Handles btnb6.Click
        If btnb1.Text <> "" Then
            btn12.Text = "$0"
            codigoD = "D100"
            descripcionD = "DÓLAR 100"
            ValidarRepetido()
            btn14.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta_billeteimg & btnb6.Text & extencion_billeteimg)
            btn14.BackgroundImageLayout = PictureBoxSizeMode.StretchImage
            btn13.Focus()
            valor = 100

        Else
            MessageBox.Show("SELECCIONE UNA DIVISA")
        End If
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        btn13.Text += "0"
        btn13.Focus()
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        btn13.Text += "1"
        btn13.Focus()
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        btn13.Text += "2"
        btn13.Focus()
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        btn13.Text += "3"
        btn13.Focus()
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        btn13.Text += "4"
        btn13.Focus()
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        btn13.Text += "5"
        btn13.Focus()
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        btn13.Text += "6"
        btn13.Focus()
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        btn13.Text += "7"
        btn13.Focus()
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        btn13.Text += "8"
        btn13.Focus()
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        btn13.Text += "9"
        btn13.Focus()
    End Sub

    Private Sub btn10_Click(sender As Object, e As EventArgs) Handles btn10.Click
        If btn13.Text.Trim.Length > 0 Then
            btn13.Text = Mid(btn13.Text, 1, Len(btn13.Text) - 1)
        End If
        btn13.Focus()
    End Sub

    Private Sub vbtnd1_Click(sender As Object, e As EventArgs) Handles vbtnd1.Click
        If dgvCoV.Rows.Count > 0 Then
            Dim valor As String
            valor = dgvCoV.Rows(dgvCoV.CurrentRow.Index).Cells(0).Value.ToString
            valor = valor.Replace("C", "")
            valor = valor.Replace("D", "")
            valor = valor.Replace("E", "")
            valor = valor.Replace("L", "")
            txtmonto2.Text = (Convert.ToDouble(txtmonto2.Text) - (Convert.ToDouble(valor) * Convert.ToDouble(dgvCoV.Rows(dgvCoV.CurrentRow.Index).Cells(2).Value.ToString))).ToString
            txtmonto2.Text = FormatNumber(txtmonto2.Text, 2)
            btn12.Text = "$" & (Convert.ToDouble(txtmonto2.Text) * PrecioD).ToString
            dgvCoV.Rows.RemoveAt(dgvCoV.CurrentRow.Index)
        End If
    End Sub

    Private Sub BtnProcesar_Click(sender As Object, e As EventArgs) Handles BtnProcesar.Click
        If dgvCoV.Rows.Count > 0 Then
            estatus = True
            Dim valor2 As String
            AsignaRemision()
            If oremisioMC.AremisioCA(oremisioMM) > 0 Then
                For denominacion As Integer = 0 To dgvCoV.Rows.Count - 1
                    If dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString <> "" And _
                        dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString <> "" Then

                        oremisioDM.folio_factura = FolioFActura

                        oremisioDM.producto = dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString
                        valor2 = dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString
                        valor2 = valor2.Replace("C", "")
                        valor2 = valor2.Replace("D", "")
                        valor2 = valor2.Replace("E", "")
                        valor2 = valor2.Replace("L", "")
                        oremisioDM.cantidads = Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString) * Convert.ToDouble(valor2)
                        oremisioDM.p_unitario = Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString) _
                        / (Convert.ToDouble(valor2) * Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString))
                        oremisioDM.stotal = dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString
                        oremisioDM.descuento = 0
                        oremisioDM.capacidad = "1"
                        oremisioDM.unidad = "1"
                        oremisioDM.descripcion_larga = dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString & " billetes de " & dgvCoV.Rows(denominacion).Cells("Nombre").Value.ToString
                        oremisioDM.Nosucursal = No_Sucursal
                        oremisioDM.fecha = FechaAct
                        oremisioDM.operacion = "CA"
                        oremisioDC.AremisioCA_DET(oremisioDM)

                        ModificarExistencias(FechaAct, No_Sucursal, dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString, Nothing, Convert.ToInt32(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString), Convert.ToDouble(PrecioD), Convert.ToInt32(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString))

                    End If
                Next

            End If

            If estatus Then
                MsgBox("Proceso Realizado", MsgBoxStyle.Information)
                cambioEfectuado = True
                Me.Close()
            End If
        Else
            MsgBox("No ha ingresado la cantidad", MsgBoxStyle.Information)
        End If
        
    End Sub

    Private Sub AsignaRemision()
        'dtpFecha.Value = DateTime.Now
        Dim stotal As String
        oremisioMM.folio_factura = FolioFActura.ToString
        oremisioMM.fecha = FechaAct
        oremisioMM.tipo = "DIVISAS"
        oremisioMM.cliente = cliente
        oremisioMM.vendedor = 0
        oremisioMM.condiciones = "ESPECIAL"
        oremisioMM.estatus = "1"
        If CInt(btn12.Text.Trim.Replace("$", "")) > 0 Then
            stotal = Convert.ToDouble(btn12.Text.Trim.Replace("$", "")).ToString
        Else
            stotal = (Val(Convert.ToDouble(txtmonto2.Text.Trim.Replace("$", "")) * PrecioD)).ToString
        End If
        oremisioMM.stotal = FormatNumber(Convert.ToDouble(stotal), 2)
        TotalDev = FormatNumber(Convert.ToDouble(stotal), 2)

        oremisioMM.iva = 0
        oremisioMM.total = FormatNumber(oremisioMM.stotal, 2)
        oremisioMM.observaciones = "CAMBIO"
        oremisioMM.letras = oauxiliares.EnLetras(Convert.ToDouble(stotal)).ToUpper
        If oremisioMM.letras.Contains("CON") Then
            oremisioMM.letras = oremisioMM.letras.Replace("CON", "PESOS CON ") & "/100 M.N."
            'oremisioMM.letras += "/100 M.N.""
        Else
            oremisioMM.letras += " PESOS 00/100 M.N."
        End If
        oremisioMM.cajero = 2
        oremisioMM.ncorte = 0
        oremisioMM.hora = DateTime.Now
        oremisioMM.Nosucursal = No_Sucursal
        oremisioMM.precio_especial = ""
        If dgvCoV.Rows(0).Cells("codigo").Value.ToString = "D100" And dgvCoV.Rows.Count = 1 Then
            oremisioMM.precio_especial = "SI"
        End If
    End Sub

    Private Sub ModificarExistencias(ByVal fecha As Date, ByVal sucursal As String, ByVal divisa As String, ByVal ce As Integer, ByVal cs As Integer, ByVal precio As Double, ByVal sf As Integer)
        Dim sql, where, strSet As String
        Dim cmd As New SqlCommand
        strSet = ""

        sql = "update Existencia set "

        If cs <> Nothing Then
            strSet += "cs=cs + " & cs & " ,"
            If sf <> Nothing Then
                strSet += "sf=(si + en + te + ce) - (sal + ts + cs + pts + " & sf & ") ,"
            End If
        End If

        If ce <> Nothing Then
            strSet += "ce=ce + " & ce & " ,"
            If sf <> Nothing Then
                strSet += "sf=(si + en + te + ce + " & sf & ") - (sal + ts + cs + pts) ,"
            End If
        End If

        If precio <> Nothing Then
            strSet += "precio=" & precio & " ,"
        End If

        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += "where fecha='" & fecha & "' and nosucursal='" & sucursal & "' and divisa='" & divisa & "'"

        ArchivoSer = New System.IO.StreamReader("servidor.txt")
        conser = ArchivoSer.ReadLine
        ArchivoSer.Close()

        Dim tConection As New SqlConnection

        tConection.ConnectionString = conser
        tConection.Open()
        cmd.Connection = tConection

        cmd.CommandText = sql & strSet

        If cmd.ExecuteNonQuery() <= 0 Then
            MsgBox("Registro no Guardado", MsgBoxStyle.Information)
            estatus = False
        End If

        cmd.Connection.Close()
        tConection.Open()
        tConection = Nothing
        cmd = Nothing
        sql = Nothing
        where = Nothing
        strSet = Nothing
    End Sub

    Private Sub ValidarRepetido()
        repetido = False
        For Each row As DataGridViewRow In dgvCoV.Rows
            If dgvCoV.Rows(row.Index).Cells(0).Value.ToString = codigoD And dgvCoV.Rows(row.Index).Cells(0).Value IsNot Nothing Then
                MessageBox.Show("NO PUEDE AGREGAR UNA DIVISA QUE YA ESTÁ EN LA TABLA, SELECCIONE OTRA O ELIMINELA ANTES DE AGREGAR")
                btn12.Text = "$" & (Convert.ToDouble(txtmonto2.Text) * PrecioD).ToString
                repetido = True
                Exit For
            End If
        Next
    End Sub

    Private Sub validarExistencia()
        For Each row As DataGridViewRow In Me.DTExistencia.Rows
            If row.Cells(0).Value = codigoD Then
                If CInt(btn13.Text) > row.Cells(1).Value Then
                    MessageBox.Show("LA CANTIDAD ES MAYOR A LA EXISTENCIA DE ESTA DIVISA")
                    repetido = True
                    Exit For
                End If
            End If
        Next
    End Sub
End Class