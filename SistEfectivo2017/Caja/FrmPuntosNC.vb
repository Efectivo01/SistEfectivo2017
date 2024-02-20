Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing
Public Class FrmPuntosNC
    Public cliente As Integer
    Public No_Sucursal As String
    Dim FolioNC As Integer
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
    Dim Cadena As String

    Dim oremisioDC As New remisioDC
    Dim oremisioMC As New remisioMC
    Dim oauxiliares As New auxiliares

    Dim tConection As New SqlConnection
    Dim tcomm As SqlCommand
    Dim bTrans As SqlTransaction
    Dim rs As SqlDataReader

    Dim opuntosNC As New puntosNC
    Dim opuntosNC_Det As New puntosNC_Det
    Dim oReportesUnicosC As New ReportesUnicosC
    Dim Impresora1, Impresora2 As String
    Dim ImpresoraCarta As String = "HP" 'sepuede quitar
    Dim oPuntos As New CPuntos
    Public PuntosC As Double
    Public tarjetaC As String
    Public DolaresEntregar As Integer
    Dim CambioParcial As Boolean = False
    Public ValorPtsC As Double

    Private Sub FrmPuntosNC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvNoOrden(dgvCoV)
        txtmonto1.Text = DolaresEntregar
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

        FolioNC = oremisioMC.UFolioNC(No_Sucursal)
        BtnProcesar.Enabled = False
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub CargarExistencia()
        Dim dtrFila As DataRow
        Dim cmd As New SqlCommand
        Dim BloqueoBtn As Boolean = False
        Dim D1Exi As Integer

        ArchivoSer = New System.IO.StreamReader("servidor.txt")
        conser = ArchivoSer.ReadLine
        ArchivoSer.Close()

        Dim tConection As New SqlConnection(conser)

        tConection.Open()
        Dim consulta As String = "select e.fecha, e.nosucursal, e.divisa, e.sf from Existencia e " &
        "inner join divisas d ON d.codigo = e.divisa where e.nosucursal = '" & No_Sucursal & "' " &
        "And e.fecha = '" & FechaAct.ToString("dd/MM/yyyy") & "' and e.tipo = 1 AND e.divisa IN('D1', 'D5', 'D10') " &
        "order by d.divisa"
        cmd = New SqlCommand(consulta, tConection)
        lector = cmd.ExecuteReader()
        While lector.Read
            dtrFila = dtbTabla.NewRow()
            dtrFila("Divisa") = lector("divisa")
            dtrFila("Existencia") = lector("sf")
            If lector("divisa") = "D1" Then
                If lector("sf") >= DolaresEntregar Then
                    btnb2.Enabled = False
                    btnb3.Enabled = False
                    btnb4.Enabled = False
                    btnb5.Enabled = False
                    btnb6.Enabled = False
                    BloqueoBtn = True
                Else
                    D1Exi = lector("sf")
                End If
            End If
            If lector("divisa") = "D5" Then
                If lector("sf") + D1Exi >= DolaresEntregar Then
                    btnb2.Enabled = True
                    btnb3.Enabled = False
                    btnb4.Enabled = False
                    btnb5.Enabled = False
                    btnb6.Enabled = False
                    BloqueoBtn = True
                Else
                    D1Exi = D1Exi + lector("sf")
                End If
            End If
            If lector("divisa") = "D10" Then
                If lector("sf") + D1Exi >= DolaresEntregar Then
                    btnb2.Enabled = True
                    btnb3.Enabled = True
                    btnb4.Enabled = False
                    btnb5.Enabled = False
                    btnb6.Enabled = False
                    BloqueoBtn = True
                Else
                    D1Exi = D1Exi + lector("sf")
                End If
                'ElseIf lector("divisa") = "D20" And BloqueoBtn = False Then
                '    If lector("sf") + D1Exi >= DolaresEntregar Then
                '        btnb5.Enabled = False
                '        btnb6.Enabled = False
                '        BloqueoBtn = True
                '    Else
                '        D1Exi = D1Exi + lector("sf")
                '    End If
                'ElseIf lector("divisa") = "D50" And BloqueoBtn = False Then
                '    If lector("sf") + D1Exi >= DolaresEntregar Then
                '        btnb6.Enabled = False
                '        BloqueoBtn = True
                '    Else
                '        D1Exi = D1Exi + lector("sf")
                '    End If
            End If
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
        If valor <= 0 Then
            MessageBox.Show("DEBE SELECCIONAR EL BILLETE A ENTREGAR")
            Exit Sub
        End If

        If btn13.Text.Replace("$", "") = "0" Or btn13.Text.Replace("$", "") = "" Or IsNumeric(btn13.Text.Replace("$", "")) = 0 Then 'no hay nada
            MessageBox.Show("NO PUEDE DEJAR 0 EN LA CANTIDAD, ESCRIBA OTRO NUMERO")
            btn13.Text = ""
            btn13.Focus()
        Else
            If btn13.Text <> "" Then ' And billete >= 0 And CoV <> ""
                Dim totalmn, totaldvs As Double
                totalmn = 0
                totaldvs = 0
                totalmn = Convert.ToDouble(btn13.Text) * valor
                totalmn = totalmn * PrecioD
                totaldvs = Convert.ToDouble(btn13.Text) * valor

                If Convert.ToDouble(txtmonto2.Text) + totaldvs > Convert.ToDouble(txtmonto1.Text) Then ' + totalmn > Convert.ToDouble(txtmonto1.Text) Then
                    MessageBox.Show("NO SE PUEDE PROPORCIANAR ESA CANTIDAD DE DIVISA PORQUE:" + Chr(13) + Chr(13) + "* EXEDE EL TOTAL SOLICITADO Y/O ES MAYOR A LO NECESARIO" + Chr(13) + Chr(13) + "PORFAVOR DIGITE UNA CANTIDAD MENOR")

                    btn13.Text = ""
                    'ElseIf Convert.ToDouble(txtmonto2.Text) + totaldvs < Convert.ToDouble(txtmonto1.Text) Then ' + totalmn > Convert.ToDouble(txtmonto1.Text) Then
                    '    MessageBox.Show("NO SE PUEDE PROPORCIANAR ESA CANTIDAD DE DIVISA PORQUE:" + Chr(13) + Chr(13) + "* ES MINIMO EL TOTAL SOLICITADO" + Chr(13) + Chr(13) + "PORFAVOR DIGITE UNA CANTIDAD MAYOR")

                    '    btn13.Text = ""
                Else
                    BtnProcesar.Enabled = True
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
        BtnProcesar.Enabled = False
        If Int(txtmonto1.Text) <> Int(txtmonto2.Text) Then
            MessageBox.Show("EL MONTO TOTAL DE LA OPERACION NO DEBE SER DIFERENTE AL MONTO A ENTREGAR")
            BtnProcesar.Enabled = True
            Exit Sub
        End If
        If Not Validar() Then Exit Sub
        estatus = True
        Dim valor2 As String

        ArchivoSer = New System.IO.StreamReader("servidor.txt")
        conser = ArchivoSer.ReadLine
        ArchivoSer.Close()

        tConection.ConnectionString = conser
        tConection.Open()

        bTrans = tConection.BeginTransaction()

        tcomm = New SqlCommand
        tcomm.Connection = tConection
        tcomm.Transaction = bTrans

        Try
            'Actualiza el Folio de la Nota de Credito
            Siguiente_Folio(No_Sucursal)

            'Graba Encabezado de Nota de Credito
            AsignaRemision()

            If AremisioNC(opuntosNC) > 0 Then
                For denominacion As Integer = 0 To dgvCoV.Rows.Count - 1
                    If dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString <> "" And
                    dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString <> "" Then
                        opuntosNC_Det.folio_NC = FolioNC
                        opuntosNC_Det.producto = dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString
                        valor2 = dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString
                        valor2 = valor2.Replace("C", "")
                        valor2 = valor2.Replace("D", "")
                        valor2 = valor2.Replace("E", "")
                        valor2 = valor2.Replace("L", "")

                        opuntosNC_Det.cantidads = Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString) * Convert.ToDouble(valor2)
                        opuntosNC_Det.p_unitario = Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString) _
                    / (Convert.ToDouble(valor2) * Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString))
                        opuntosNC_Det.stotal = dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString
                        opuntosNC_Det.descripcion_larga = dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString & " billetes de " & dgvCoV.Rows(denominacion).Cells("Nombre").Value.ToString
                        opuntosNC_Det.Nosucursal = No_Sucursal
                        opuntosNC_Det.fecha = FechaAct
                        opuntosNC_Det.operacion = "CA"

                        'Graba Detalle de Nota de Credito

                        Cadena = ""
                        Cadena = Cadena & "INSERT INTO Nota_Credito_Det("
                        Cadena = Cadena & " folio_NC, "
                        Cadena = Cadena & " producto, "
                        Cadena = Cadena & " cantidad, "
                        Cadena = Cadena & " p_unitario, "
                        Cadena = Cadena & " total, "
                        Cadena = Cadena & " descripcion_larga, "
                        Cadena = Cadena & " Nosucursal)"
                        Cadena = Cadena & "VALUES("
                        Cadena = Cadena & "'" & opuntosNC_Det.folio_NC & "', "
                        Cadena = Cadena & "'" & opuntosNC_Det.producto & "', "
                        Cadena = Cadena & opuntosNC_Det.cantidads & ", "
                        Cadena = Cadena & opuntosNC_Det.p_unitario & ", "
                        Cadena = Cadena & opuntosNC_Det.stotal & ", "
                        Cadena = Cadena & "'" & opuntosNC_Det.descripcion_larga & "', "
                        Cadena = Cadena & "'" & opuntosNC_Det.Nosucursal & "')"

                        tcomm.CommandText = Cadena
                        tcomm.ExecuteNonQuery()

                        'oremisioDC.AremisioNC_DET(opuntosNC_Det)

                        'Actualiza Existencias
                        ModificarExistenciasPTS(FechaAct, No_Sucursal, dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString, Convert.ToInt32(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString), Convert.ToDouble(PrecioD), Convert.ToInt32(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString))
                    End If
                Next

            End If

            bTrans.Commit()
            tConection.Close()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            bTrans.Rollback()
            tConection.Close()
            Exit Sub
        End Try


        ImpresoraName()
        Dim Nota2 = New NotaCreditoN
        Dim datosdsc As New DataSet
        datosdsc = oReportesUnicosC.ImprimeNotaPuntos(cliente, FolioNC, No_Sucursal)
        Nota2.SetDataSource(datosdsc)
        Nota2.PrintOptions.PrinterName = Impresora1
        Nota2.PrintToPrinter(1, False, 0, 0)

        Nota2.Close()
        Nota2.Dispose()

        Dim Nota3 = New NotaCreditoV
        Dim datosdsc2 As New DataSet
        datosdsc2 = oReportesUnicosC.ImprimeNotaPuntosVenta(cliente, FolioNC, No_Sucursal)
        Nota3.SetDataSource(datosdsc2)
        Nota3.PrintOptions.PrinterName = Impresora1
        Nota3.PrintToPrinter(1, False, 0, 0)

        Nota3.Close()
        Nota3.Dispose()
        Me.Close()

        BtnProcesar.Enabled = True
    End Sub

    Function Validar() As Boolean
        Dim valor As Boolean = True
        Dim Monto1 As Integer = Int(txtmonto1.Text)
        Dim Monto2 As Integer = Int(txtmonto2.Text)
        If Monto1 < Monto2 Then
            valor = False
            MsgBox("No a ingresado los Dolares Correctos", MsgBoxStyle.Information)
        ElseIf Monto2 = 0 Then
            valor = False
            MsgBox("No a ingresado Datos", MsgBoxStyle.Information)
        ElseIf Int(txtmonto1.Text) > Int(txtmonto2.Text) Then
            CambioParcial = True
        End If
        Return valor
    End Function

    Private Sub AsignaRemision()
        Dim stotal As String
        opuntosNC.folio_NC = FolioNC.ToString
        opuntosNC.fecha = FechaAct
        opuntosNC.tarjeta = tarjetaC
        opuntosNC.cliente = cliente
        'If CambioParcial Then
        '    PuntosC = (CInt(txtmonto2.Text.Trim) * PrecioD) / ValorPtsC
        'End If
        opuntosNC.puntos = PuntosC
        opuntosNC.dolares = CInt(txtmonto2.Text.Trim) 'CInt(txtmonto1.Text.Trim)
        opuntosNC.estatus = "1"
        If CInt(btn12.Text.Trim.Replace("$", "")) > 0 Then
            stotal = Convert.ToDouble(btn12.Text.Trim.Replace("$", "")).ToString
        Else
            stotal = (Val(Convert.ToDouble(txtmonto2.Text.Trim.Replace("$", "")) * PrecioD)).ToString
        End If
        opuntosNC.total = FormatNumber(Convert.ToDouble(stotal), 2)
        TotalDev = FormatNumber(Convert.ToDouble(stotal), 2)


        opuntosNC.letra = oauxiliares.EnLetras(Convert.ToDouble(stotal)).ToUpper
        If opuntosNC.letra.Contains("CON") Then
            opuntosNC.letra = opuntosNC.letra.Replace("CON", "PESOS CON ") & "/100 M.N."
        Else
            opuntosNC.letra += " PESOS 00/100 M.N."
        End If
        'modificado para buscar la ultima venta del cliente y si no tiene ponerle 0
        'opuntosNC.folio_factura = oremisioMC.UFolioRemision(No_Sucursal)
        opuntosNC.folio_factura = UltFolioVentaNC(No_Sucursal, cliente, Now.ToShortDateString)

        opuntosNC.nosucursal = No_Sucursal

        Cadena = "UPDATE Puntos SET Puntos = puntos - " & PuntosC & " WHERE Tarjeta = '" & tarjetaC & "'"
        tcomm.CommandText = Cadena
        tcomm.ExecuteNonQuery()
        'oPuntos.UpdatePtsCanjeados(PuntosC, tarjetaC)
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

    Private Sub ModificarExistenciasPTS(ByVal fecha As Date, ByVal sucursal As String, ByVal divisa As String, ByVal pts As Integer, ByVal precio As Double, ByVal sf As Integer)
        Dim sql, strSet As String
        strSet = ""

        sql = "update Existencia set "

        If pts <> Nothing Then
            strSet += "pts=pts + " & pts & " ,"
            If sf <> Nothing Then
                strSet += "sf=(si + en + te + ce) - (sal + ts + cs + pts + " & sf & ") ,"
            End If
        End If

        If precio <> Nothing Then
            strSet += "precio=" & precio & " ,"
        End If

        If strSet.Trim().Length > 0 Then
            strSet = strSet.Remove(strSet.Length - 1, 1)
        End If

        strSet += "where fecha='" & fecha & "' and nosucursal='" & sucursal & "' and divisa='" & divisa & "'"

        tcomm.CommandText = sql & strSet

        If tcomm.ExecuteNonQuery() <= 0 Then
            MsgBox("Registro no Guardado", MsgBoxStyle.Information)
            estatus = False
        End If

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

    Private Sub ImpresoraName()
        Dim a As PrinterSettings = New PrinterSettings()
        For i As Integer = 0 To PrinterSettings.InstalledPrinters.Count - 1 Step i + 1
            a.PrinterName = PrinterSettings.InstalledPrinters(i).ToString()
            If a.IsDefaultPrinter Then
                Impresora1 = PrinterSettings.InstalledPrinters(i).ToString()
            End If
            If PrinterSettings.InstalledPrinters(i).ToString.Contains(ImpresoraCarta) Then
                Impresora2 = PrinterSettings.InstalledPrinters(i).ToString()
            End If
        Next
    End Sub

    Private Sub Siguiente_Folio(ByVal Sucursal As String)
        Cadena = "update Sucursales set folio_NC=folio_NC+1 where id='" & Sucursal & "';"
        tcomm.CommandText = Cadena
        tcomm.ExecuteNonQuery()
    End Sub

    Public Function UltFolioVentaNC(ByVal NoSucursal As String, ByVal cliente As String, ByVal fecha As Date) As Integer

        Dim UltFolio As Integer

        Cadena = ""
        Cadena = Cadena & "select "
        Cadena = Cadena & "   ISNULL(MAX(folio_factura),0) as folio "
        Cadena = Cadena & "from "
        Cadena = Cadena & "   remisioM "
        Cadena = Cadena & "where "
        Cadena = Cadena & "   fecha = '" & fecha.ToString("dd/MM/yyyy") & "' and "
        Cadena = Cadena & "   observaciones = 'VENTA' and "
        Cadena = Cadena & "   cliente = '" & cliente & "' and "
        Cadena = Cadena & "   Nosucursal ='" & NoSucursal & "';"

        tcomm.CommandText = Cadena
        rs = tcomm.ExecuteReader

        While rs.Read
            UltFolio = rs(0)
        End While
        rs.Close()

        Return UltFolio
    End Function

    Public Function AremisioNC(ByVal data As puntosNC) As Integer
        Dim NumReg As Integer
        Cadena = ""
        Cadena = Cadena & "insert into Nota_Credito("
        Cadena = Cadena & "   cliente, "
        Cadena = Cadena & "   tarjeta, "
        Cadena = Cadena & "   puntos, "
        Cadena = Cadena & "   dolares, "
        Cadena = Cadena & "   fecha, "
        Cadena = Cadena & "   estatus, "
        Cadena = Cadena & "   letra, "
        Cadena = Cadena & "   total, "
        Cadena = Cadena & "   folio_NC, "
        Cadena = Cadena & "   nosucursal, "
        Cadena = Cadena & "   folio_factura) "
        Cadena = Cadena & "values("
        Cadena = Cadena & "   @cliente, "
        Cadena = Cadena & "   @tarjeta, "
        Cadena = Cadena & "   @puntos, "
        Cadena = Cadena & "   @dolares, "
        Cadena = Cadena & "   @fecha, "
        Cadena = Cadena & "   @estatus, "
        Cadena = Cadena & "   @letra, "
        Cadena = Cadena & "   @total, "
        Cadena = Cadena & "   @folio_NC, "
        Cadena = Cadena & "   @nosucursal, "
        Cadena = Cadena & "   @folio_factura)"
        tcomm.Parameters.Add("@cliente", SqlDbType.Int).Value = data.cliente
        tcomm.Parameters.Add("@tarjeta", SqlDbType.NVarChar).Value = data.tarjeta
        tcomm.Parameters.Add("@puntos", SqlDbType.Float).Value = data.puntos
        tcomm.Parameters.Add("@dolares", SqlDbType.Int).Value = data.dolares
        tcomm.Parameters.Add("@fecha", SqlDbType.SmallDateTime).Value = data.fecha
        tcomm.Parameters.Add("@estatus", SqlDbType.NVarChar).Value = data.estatus
        tcomm.Parameters.Add("@letra", SqlDbType.NVarChar).Value = data.letra
        tcomm.Parameters.Add("@total", SqlDbType.Float).Value = data.total
        tcomm.Parameters.Add("@folio_NC", SqlDbType.NVarChar).Value = data.folio_NC
        tcomm.Parameters.Add("@Nosucursal", SqlDbType.NVarChar).Value = data.nosucursal
        tcomm.Parameters.Add("@folio_factura", SqlDbType.NVarChar).Value = data.folio_factura

        tcomm.CommandText = Cadena
        NumReg = tcomm.ExecuteNonQuery()

        Return NumReg
    End Function

End Class