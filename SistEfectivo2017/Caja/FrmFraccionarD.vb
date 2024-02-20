Imports System.Data.SqlClient
Public Class FrmFraccionarD
    Public No_Sucursal As String
    Dim ruta_billeteimg As String = "billetes_gif\Denominaciones\" ' "..\..\images\Denominaciones\"
    Dim extencion_billeteimg As String = ".gif"
    Public DolarEfec As Integer
    Public PrecioD As Double
    Dim valor As Integer
    Dim codigoD, descripcionD As String
    Dim DolarEntregado As Boolean
    Dim oExistenciaM As New ExistenciaM
    Dim oExistenciaC As New ExistenciaC
    Dim estatus As Boolean
    Dim repetido As Boolean = False
    Dim ArchivoSer As System.IO.StreamReader
    Dim conser As String = ""
    Dim FechaAct As Date
    Private lector As SqlDataReader
    Dim dtbTabla As New System.Data.DataTable
    Dim tConection As New SqlConnection
    Dim transacc As SqlTransaction
    Dim cmd As New SqlCommand

    Dim oauxiliares As New auxiliares

    Private Sub FrmFraccionarD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTExistencia.AllowUserToAddRows = False

        dtbTabla.Columns.Add("Divisa")
        dtbTabla.Columns.Add("Existencia")
        FechaAct = Now.ToShortDateString
        DolarEntregado = True
        dgvNoOrden(dgvCoV)
        dgvNoOrden(DGEntrega)
        btnb1.Enabled = False
        btnb7.Enabled = False
        txtmonto1.Text = DolarEfec
        valor = 0
        codigoD = ""
        descripcionD = ""
        CargarExistencia()
        BtnProcesar.Enabled = False
        With DTExistencia
            .Columns(0).Width = 45
            .Columns(1).Width = 80
        End With
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btn11_Click(sender As Object, e As EventArgs) Handles btn11.Click
        If DolarEntregado Then
            If btn14.BackgroundImage IsNot Nothing Then
                btn14.BackgroundImage = Nothing
            End If

            If btn13.Text.Replace("$", "") = "0" Or btn13.Text.Replace("$", "") = "" Or IsNumeric(btn13.Text.Replace("$", "")) = 0 Then 'no hay nada
                MessageBox.Show("NO PUEDE DEJAR 0 EN LA CANTIDAD, ESCRIBA OTRO NUMERO")
                btn13.Text = ""
                btn13.Focus()
            ElseIf CInt(btn13.Text) <> 1 Then
                MessageBox.Show("NO PUEDE AGREGAR MAS DE 2 BILLETES EN LA CANTIDAD, ESCRIBA 1")
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

                    Else
                        If repetido = False Then
                            dgvCoV.Rows.Add(codigoD, descripcionD, btn13.Text, _
                                    totalmn.ToString("##,##0.00"), PrecioD)

                            btn13.Text = ""
                            btn14.Text = ""
                            autosumaGridCoV()
                            btn11.Enabled = False
                            codigoD = ""
                            descripcionD = ""
                        End If
                    End If
                Else
                    MessageBox.Show("DEBE ESCOGER UNA DIVISA Y PRESIONAR UNA CANTIDAD PARA CONTINUAR Ó VICEVERSA," + Chr(13) + " O BIEN ELEGIR SI ESTÁ REALIZANDO UNA COMPRA O VENTA")
                    btn13.Text = ""
                End If
            End If
        Else
            If btn14.BackgroundImage IsNot Nothing Then
                btn14.BackgroundImage = Nothing
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
                    Else
                        validarExistencia()
                        If repetido = False Then
                            DGEntrega.Rows.Add(codigoD, descripcionD, btn13.Text, _
                                    totalmn.ToString("##,##0.00"), PrecioD)

                            btn13.Text = ""
                            btn14.Text = ""
                            autosumaGridEntraD()
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

    Private Sub autosumaGridEntraD()
        Dim row As DataGridViewRow
        Dim totalMN, totalDIV As Decimal
        Dim extraer As String
        For Each row In DGEntrega.Rows
            If DGEntrega.Rows(row.Index).Cells(1).Value IsNot Nothing Then
                If DGEntrega.Rows(row.Index).Cells(1).Value.ToString() <> Nothing And IsNumeric(DGEntrega.Rows(row.Index).Cells(2).Value.ToString()) Then
                    If DGEntrega.Rows(row.Index).Cells(1).Value.ToString() <> Nothing Then
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

    Private Sub CargarExistencia()
        Dim dtrFila As DataRow
        Dim cmd As New SqlCommand

        ArchivoSer = New System.IO.StreamReader("servidor.txt")
        conser = ArchivoSer.ReadLine
        ArchivoSer.Close()

        Dim tConection As New SqlConnection(conser)

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

    Private Sub btnb1_Click(sender As Object, e As EventArgs) Handles btnb1.Click
        If btnb1.Text <> "" Then
            btn12.Text = "$0"
            codigoD = "D1"
            descripcionD = "DÓLAR 001"
            If DolarEntregado Then
                ValidarRepetido()
            Else
                ValidarRepetido2()
            End If
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
            If DolarEntregado Then
                ValidarRepetido()
            Else
                ValidarRepetido2()
            End If
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
            If DolarEntregado Then
                ValidarRepetido()
            Else
                ValidarRepetido2()
            End If
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
            If DolarEntregado Then
                ValidarRepetido()
            Else
                ValidarRepetido2()
            End If
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
            If DolarEntregado Then
                ValidarRepetido()
            Else
                ValidarRepetido2()
            End If
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
            If DolarEntregado Then
                ValidarRepetido()
            Else
                ValidarRepetido2()
            End If
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

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        'reniciar los datos
        'los txt de monto limpiar y habilitar el monto1
        If DolarEntregado Then
            If Trim(txtmonto1.Text) = Trim(txtmonto2.Text) Then
                btnb6.Enabled = False
                btnb7.Enabled = False
                txtmonto2.Text = "0"
                habilitarBtnD(valor)
                valor = 0
                codigoD = ""
                descripcionD = ""
                Label1.Visible = False
                Label2.Visible = True
                dgvCoV.Visible = False
                DGEntrega.Visible = True
                DolarEntregado = False
                btnb1.Enabled = True
                BtnGuardar.Visible = False
                btn11.Enabled = True
                BtnProcesar.Enabled = True
            Else
                MsgBox("No se Puede Guardar por que el Total de Operación es Menor", MsgBoxStyle.Information)
            End If

        Else
            'hacer las modificaciones correspondientes
        End If
    End Sub

    Private Sub habilitarBtnD(ByVal Btn As Integer)
        Select Case Btn
            Case 5
                btnb5.Enabled = False
                btnb4.Enabled = False
                btnb3.Enabled = False
                btnb2.Enabled = False
            Case 10
                btnb5.Enabled = False
                btnb4.Enabled = False
                btnb3.Enabled = False
            Case 20
                btnb5.Enabled = False
                btnb4.Enabled = False
            Case 50
                btnb5.Enabled = False
        End Select
    End Sub

    Private Sub vbtnd1_Click(sender As Object, e As EventArgs) Handles vbtnd1.Click
        If DolarEntregado Then
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
            btn11.Enabled = True
        Else
            If DGEntrega.Rows.Count > 0 Then
                Dim valor As String
                valor = DGEntrega.Rows(DGEntrega.CurrentRow.Index).Cells(0).Value.ToString
                valor = valor.Replace("C", "")
                valor = valor.Replace("D", "")
                valor = valor.Replace("E", "")
                valor = valor.Replace("L", "")
                txtmonto2.Text = (Convert.ToDouble(txtmonto2.Text) - (Convert.ToDouble(valor) * Convert.ToDouble(DGEntrega.Rows(DGEntrega.CurrentRow.Index).Cells(2).Value.ToString))).ToString
                txtmonto2.Text = FormatNumber(txtmonto2.Text, 2)
                btn12.Text = "$" & (Convert.ToDouble(txtmonto2.Text) * PrecioD).ToString
                DGEntrega.Rows.RemoveAt(DGEntrega.CurrentRow.Index)
            End If
        End If
    End Sub

    Private Sub BtnProcesar_Click(sender As Object, e As EventArgs) Handles BtnProcesar.Click
        Dim Folio As String
        Dim stotal As Double
        Dim letras As String
        Dim valor2, descripcion_larga As String
        Dim cantidads As Integer

        If Trim(txtmonto1.Text) <> Trim(txtmonto2.Text) Then
            MsgBox("NO SE PUEDE PROCESAR POR EL MONTO DE LA OPERACION ES DIFERENTE AL REGISTRADO", MsgBoxStyle.Information)
            Exit Sub
        End If
        estatus = True

        ArchivoSer = New System.IO.StreamReader("servidor.txt")
        conser = ArchivoSer.ReadLine
        ArchivoSer.Close()

        tConection.ConnectionString = conser
        tConection.Open()

        transacc = tConection.BeginTransaction

        Try
            Folio = "FR" & seguiente_folio("FRACCIONAR")
            For denominacion As Integer = 0 To dgvCoV.Rows.Count - 1
                If dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString <> "" And
                    dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString <> "" Then

                    stotal = FormatNumber(Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString), 2)
                    letras = oauxiliares.EnLetras(Convert.ToDouble(stotal)).ToUpper
                    If letras.Contains("CON") Then
                        letras = letras.Replace("CON", "PESOS CON ") & "/100 M.N."
                    Else
                        letras += " PESOS 00/100 M.N."
                    End If
                    valor2 = dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString
                    valor2 = valor2.Replace("C", "")
                    valor2 = valor2.Replace("D", "")
                    valor2 = valor2.Replace("E", "")
                    valor2 = valor2.Replace("L", "")
                    cantidads = Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString) * Convert.ToDouble(valor2)
                    descripcion_larga = dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString & " billetes de " & dgvCoV.Rows(denominacion).Cells("Nombre").Value.ToString

                    'insertar remisioCA                          
                    InsertarDatosCA(FechaAct, "DIVISAS", 1229, 0, "ESPECIAL", 1, stotal, 0, stotal, "FRACCIONAR", letras, 2, 0, FechaAct, No_Sucursal, Folio, "EF")

                    'insertar remisioCA_Det
                    InsertarDatosCADET(dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString, cantidads, Convert.ToDouble(PrecioD), stotal, 1, 1, descripcion_larga, No_Sucursal, FechaAct, "EF", Folio)

                    'Insertar Existencia
                    ModificarExistencias(FechaAct, No_Sucursal, dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString, Convert.ToInt32(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString), Nothing, Convert.ToDouble(PrecioD), Convert.ToInt32(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString))

                End If
            Next

            If estatus Then
                letras = oauxiliares.EnLetras(Convert.ToDouble(stotal)).ToUpper
                If letras.Contains("CON") Then
                    letras = letras.Replace("CON", "PESOS CON ") & "/100 M.N."
                Else
                    letras += " PESOS 00/100 M.N."
                End If
                'insertar remisioCA                          
                InsertarDatosCA(FechaAct, "DIVISAS", 1229, 0, "ESPECIAL", 1, stotal, 0, stotal, "FRACCIONAR", letras, 2, 0, FechaAct, No_Sucursal, Folio, "SF")

                For Each row In DGEntrega.Rows
                    If DGEntrega.Rows(row.Index).Cells(2).Value.ToString <> "" And
                        DGEntrega.Rows(row.Index).Cells(3).Value.ToString <> "" Then

                        stotal = FormatNumber(Convert.ToDouble(DGEntrega.Rows(row.Index).Cells(3).Value.ToString), 2)
                        valor2 = DGEntrega.Rows(row.Index).Cells(0).Value.ToString
                        valor2 = valor2.Replace("C", "")
                        valor2 = valor2.Replace("D", "")
                        valor2 = valor2.Replace("E", "")
                        valor2 = valor2.Replace("L", "")
                        cantidads = Convert.ToDouble(DGEntrega.Rows(row.Index).Cells(2).Value.ToString) * Convert.ToDouble(valor2)
                        descripcion_larga = DGEntrega.Rows(row.Index).Cells(2).Value.ToString & " billetes de " & DGEntrega.Rows(row.Index).Cells(1).Value.ToString

                        'insertar remisioCA_Det
                        InsertarDatosCADET(DGEntrega.Rows(row.Index).Cells(0).Value.ToString, cantidads, Convert.ToDouble(PrecioD), stotal, 1, 1, descripcion_larga, No_Sucursal, FechaAct, "SF", Folio)

                        'Insertar Existencia
                        ModificarExistencias(FechaAct, No_Sucursal, DGEntrega.Rows(row.Index).Cells(0).Value.ToString, Nothing, Convert.ToInt32(DGEntrega.Rows(row.Index).Cells(2).Value.ToString), Convert.ToDouble(PrecioD), Convert.ToInt32(DGEntrega.Rows(row.Index).Cells(2).Value.ToString))

                    End If
                Next
            End If
            transacc.Commit()
            tConection.Close()
            tConection = Nothing

            MsgBox("Proceso realizado con exito", MsgBoxStyle.Information)
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
            transacc.Rollback()
            tConection.Close()
        End Try

    End Sub

    Public Sub InsertarDatosCA(ByVal fecha As Date, ByVal tipo As String, ByVal cliente As Integer, ByVal vendedor As Integer,
                               ByVal condiciones As String, ByVal estatus As String, ByVal stotal As Double, ByVal iva As Double,
                               ByVal total As Double, ByVal observaciones As String, ByVal letras As String, ByVal cajero As Integer,
                               ByVal ncorte As Integer, ByVal hora As Date, ByVal Nosucursal As String, ByVal folio As String, ByVal operacion As String)

        Dim Sql As String = "insert into remisioCA(folio_factura,fecha,tipo,cliente,vendedor,condiciones,estatus,stotal,iva,total," &
            "observaciones,letras,cajero,ncorte,hora,Nosucursal,folio_fraccion,operacion)values(0,'" & fecha & "','" & tipo & "'," & cliente & "," &
            "" & vendedor & ",'" & condiciones & "','" & estatus & "'," & stotal & "," & iva & "," & total & ",'" & observaciones & "'," &
            "'" & letras & "'," & cajero & "," & ncorte & ",'" & hora & "','" & Nosucursal & "','" & folio & "','" & operacion & "')"


        cmd = New SqlCommand(Sql, tConection)
        cmd.Transaction = transacc
        cmd.ExecuteNonQuery()


    End Sub


    Public Sub InsertarDatosCADET(ByVal producto As String, ByVal cantidads As Integer, ByVal p_unitario As Double, ByVal stotal As Double,
                                  ByVal capacidad As String, ByVal unidad As String, ByVal descripcion_larga As String,
                                  ByVal Nosucursal As String, ByVal fecha As Date, ByVal operacion As String, ByVal folio As String)
        Dim Sql As String = "INSERT INTO remisioCA_Det(folio_factura,producto,cantidads," &
                "p_unitario,stotal,capacidad,unidad,descripcion_larga,Nosucursal,fecha,operacion,folio_fraccion)" &
                "VALUES(0,'" & producto & "'," & cantidads & "," & p_unitario & "," &
                "" & stotal & ",'" & capacidad & "','" & unidad & "','" & descripcion_larga & "','" & Nosucursal & "'," &
                "'" & fecha & "','" & operacion & "','" & folio & "')"

        cmd = New SqlCommand(Sql, tConection)
        cmd.Transaction = transacc
        cmd.ExecuteNonQuery()
        cmd = Nothing

    End Sub

    Private Sub ModificarExistencias(ByVal fecha As Date, ByVal sucursal As String, ByVal divisa As String, ByVal ce As Integer, ByVal cs As Integer, ByVal precio As Double, ByVal sf As Integer)
        Dim sql, where, strSet As String

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

        cmd = New SqlCommand(sql & strSet, tConection)
        cmd.Transaction = transacc
        cmd.ExecuteNonQuery()

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

    Private Sub ValidarRepetido2()
        repetido = False
        For Each row As DataGridViewRow In DGEntrega.Rows
            If DGEntrega.Rows(row.Index).Cells(0).Value.ToString = codigoD And DGEntrega.Rows(row.Index).Cells(0).Value IsNot Nothing Then
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