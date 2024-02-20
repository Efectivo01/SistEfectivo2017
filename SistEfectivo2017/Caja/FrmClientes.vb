Imports System.ComponentModel
Imports System.Drawing
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class FrmClientes
    Dim oclientescnbvM, oclientescnbvM2 As New clientescnbvM
    Dim oclientescnbvC As clientescnbvC
    Dim olocalidadesC As localidadesC
    Dim opaisesC As paisesC
    Dim oactividadesC As actividadesC
    Dim oauxiliares As auxiliares
    Dim oPermitirOtrosC As New PermitirOtrosC

    Dim dt1e, dt3p, dt4a, dt5e, dt6p, dt7c, dt8c As DataTable
    Dim OpenFileDialog1 As OpenFileDialog
    Dim oCodigosPostalesM As CodigosPostalesM
    Dim oCodigosPostalesC As CodigosPostalesC
    Dim fracc As String
    Public borrando, buscado As Boolean
    Dim Imagen1 As Bitmap
    Dim Imagen2 As Bitmap
    Dim Imagen3 As Bitmap
    Dim permiso_registro As Boolean

    Dim ultimocliente As Integer
    Public cove As Boolean = False
    Public agre_bus As String
    Dim ruta_identificacion As String = "D:\IDENTIFICACIONES\"
    Public num_usux As Integer
    Public nom_usux, no_sucursal, nom_sucursal As String
    Public FechaEnvP As Date

    Dim oPersonasBloqueadasFisicasM As New PersonasBloqueadasFisicasM
    Dim oPersonasBloqueadasFisicasC As New PersonasBloqueadasFisicasC
    Dim dt_BloqFisicas As New DataTable
    Dim source_BloqFisicas As New BindingSource()

    'ultimos agregados octubre 2013

    Dim oPersonasPoliticasEM As New PersonasPoliticasEM
    Dim oPersonasPoliticasEC As New PersonasPoliticasEC
    Dim dt_PPoliticas As New DataTable
    Dim source_PPoliticas As New BindingSource()
    Dim guardado As Boolean
    Dim oPuntos As New CPuntos
    Dim dt_Bloqueados As New DataTable
    Dim PagAut As Boolean = False
    Dim CambioCel As String

    Private Sub PrepararVariables()
        oclientescnbvM = New clientescnbvM
        oclientescnbvM2 = New clientescnbvM
        oclientescnbvC = New clientescnbvC
        olocalidadesC = New localidadesC
        opaisesC = New paisesC
        oactividadesC = New actividadesC
        oauxiliares = New auxiliares
        OpenFileDialog1 = New OpenFileDialog
        oCodigosPostalesM = New CodigosPostalesM
        oCodigosPostalesC = New CodigosPostalesC
        fracc = ""
        borrando = False
        buscado = False
        ultimocliente = 0

        oPersonasBloqueadasFisicasM = New PersonasBloqueadasFisicasM
        oPersonasBloqueadasFisicasC = New PersonasBloqueadasFisicasC
    End Sub

    Private Sub LiberarVariables()
        oclientescnbvM = Nothing
        oclientescnbvM2 = Nothing
        oclientescnbvC.Dispose()
        oclientescnbvC = Nothing
        olocalidadesC = Nothing
        opaisesC = Nothing
        oactividadesC = Nothing
        oauxiliares = Nothing
        OpenFileDialog1 = Nothing
        oCodigosPostalesM = Nothing
        oCodigosPostalesC.Dispose()
        oCodigosPostalesC = Nothing
        fracc = ""
        borrando = False
        ultimocliente = 0
        dt1e.Dispose()
        dt1e = Nothing
        dt3p.Dispose()
        dt3p = Nothing
        dt4a.Dispose()
        dt4a = Nothing
        dt5e.Dispose()
        dt5e = Nothing
        dt6p.Dispose()
        dt6p = Nothing
        dt7c.Dispose()
        dt7c = Nothing
        If Imagen1 IsNot Nothing Then
            Imagen1.Dispose()
        End If
        Imagen1 = Nothing

        'If QR IsNot Nothing Then
        '    QR.Dispose()
        'End If
        'QR = Nothing

        ultimocliente = 0
        cove = False
        agre_bus = ""
        oPermitirOtrosC.Dispose()

        oPersonasBloqueadasFisicasM = Nothing
        oPersonasBloqueadasFisicasC.Dispose()
        If dt_BloqFisicas IsNot Nothing Then
            dt_BloqFisicas.Dispose()
        End If
        If source_BloqFisicas IsNot Nothing Then
            source_BloqFisicas.Dispose()
        End If

    End Sub

    Private Sub FrmClientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        cmbPaisR.DataSource = Nothing
        cmbCiudadR.DataSource = Nothing
        LiberarVariables()
        oPermitirOtrosC.Cambio0(no_sucursal)
        Dim oauxiliares2 As New auxiliares2
        oauxiliares2.ClearMemory()
        oauxiliares2.Dispose()
    End Sub

    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        classResize.ResizeForm(Me, 1167, 734)
        Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        Me.Location = New Point(0, 0)
        PrepararVariables()
        LLenarDataTables()
        'dtpFechaN.Value = dtpFechaN.Value.Date.AddYears(-18)
        dtpFechaN.Value = Now.Date
        permiso_registro = True

        'pkb5.Location = New Point((Me.Width - pkb5.Width) - 4, Encabezado.Height + 5)

        'pkb6.Location = New Point(Me.Width - pkb6.Width - 4, Encabezado.Height + pkb5.Height + 10)
        ''QR.Location = New Point(Me.Width - (pkb5.Width - QR.Width / 2), Encabezado.Height + pkb5.Height + pkb6.Height + (QR.Height / 2) + 40)
        btnVer.Location = New Point(Me.Width - (pkb5.Width - 65), Encabezado.Height + pkb5.Height + 5 + pkb6.Height + 5)
        OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        OpenFileDialog1.Filter = "Archivos PDF (*.pdf) | *.pdf|Archivos JPEG (*.jpg)|*.jpg|Todos los archivos (*.*)|*.*"

        lblTitulo.Location = New Point((Me.Width - lblTitulo.Width) / 2, 0)
        lblTitulo2.Location = New Point((Me.Width - lblTitulo2.Width) / 2, (lblTitulo.Height))
        lblTitulo3.Location = New Point((Me.Width - lblTitulo3.Width) / 2, (lblTitulo.Height + lblTitulo2.Height))
        pkb4.Location = New Point(Me.Width - pkb4.Width, 0)
        pkb3.Location = New Point(0, 0)

        lblTitulo.Parent = Encabezado
        lblTitulo.BackColor = Color.Transparent
        lblTitulo2.Parent = Encabezado
        lblTitulo2.BackColor = Color.Transparent
        lblTitulo3.Parent = Encabezado
        lblTitulo3.BackColor = Color.Transparent
        pkb4.Parent = Encabezado
        pkb4.BackColor = Color.Transparent

        cmbRiesgo.SelectedItem = "BAJO"
        PersonasBloqueadas1()
        PersonasBloqueadas2()
        If cove = False Then
            Me.btnN.Select()
            Me.btnN.Focus()
            SendKeys.Send("{ENTER}")
            txtNombre.Focus()
        Else
            btnN.Enabled = True
            btnA.Enabled = False
            btnE.Enabled = False
            btnC.Enabled = False
            Select Case agre_bus
                Case "agrega"
                    btnS.Enabled = False
                    'btnS.Visible = False
                    btnS.Enabled = False
                    'chkDirec2.Enabled = False
                    btnN.PerformClick()
                    txtTelcelu.ReadOnly = False
                    guardado = False
                Case "busca"
                    btnN.Enabled = False
                    If txtNocli.Text = "" Or txtNocli.Text = "0" Then
                        Me.Focus()
                        btnS.Focus()
                        btnS.Select()
                        btnS.PerformClick()
                    Else
                        clientescnbvAcciones("S1")
                        CambioCel = txtTelcelu.Text
                        If txtTelcelu.Text.Length > 0 Then
                            txtTelcelu.PasswordChar = "*"
                            txtTelcelu.ReadOnly = True
                        Else
                            txtTelcelu.PasswordChar = ""
                            txtTelcelu.ReadOnly = False
                        End If
                        If txtNoTarjeta.Text.Trim = "" Then
                            txtNoTarjeta.Enabled = True
                        Else
                            txtNoTarjeta.Enabled = False
                        End If
                        btnC.Enabled = True
                        BtnDocumentacion.Enabled = True
                    End If
            End Select
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If agre_bus = "agrega" And guardado = False Then
            If txtNombre.Text <> "" And txtAP.Text <> "" Then
                If MsgBox("Oprima el Boton de GUARDAR para dar de Alta al Cliente, o Desea Salir sin Guardar el Cliente", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Close()
                End If
            Else
                Close()
            End If

        Else
            'If Not validar2() Then Exit Sub
            'If Not valordatos() Then Exit Sub
            If Not ChecaModificaciones(oclientescnbvM2) Then
                Close()
            Else
                If MsgBox("Oprima el Boton de MODIFICAR para Guardar los Cambios del Cliente, o Desea Salir sin Guardar los Cambios", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Close()
                End If
            End If

        End If
        CambioCel = ""
    End Sub

    Private Sub AsignarValores()
        Dim split As String() = cmbCiudadR.Text.Split(",")
        Dim direcc As String = ""
        oclientescnbvM.ID = txtID.Text
        oclientescnbvM.Iniciales = Microsoft.VisualBasic.Left(txtNombre.Text.Trim, 2)
        oclientescnbvM.Nombre = txtNombre.Text.Trim
        oclientescnbvM.ApellidoPaterno = txtAP.Text.Trim
        oclientescnbvM.ApellidoMaterno = txtAM.Text.Trim
        oclientescnbvM.PaisNace = cmbPaisN.Text.Trim
        oclientescnbvM.EstadoNace = cmbEstadoN.Text.Trim
        oclientescnbvM.CiudadResidencia = cmbCiudadR.Text.Trim
        oclientescnbvM.PaisResidencia = cmbPaisR.Text.Trim
        oclientescnbvM.EstadoResidencia = cmbEstadoR.Text.Trim
        oclientescnbvM.Calle = txtCalle.Text.Trim
        oclientescnbvM.No_Interior = txtNoInt.Text.Trim
        oclientescnbvM.No_Exterior = txtNoExt.Text.Trim
        oclientescnbvM.EntreCalles = txtEntreCalles.Text.Trim
        oclientescnbvM.Colonia = txtColonia.Text.Trim
        oclientescnbvM.Direccion = txtDireccion.Text.Trim
        'oclientescnbvM.Referencias = rtxReferencias.Text.Trim
        oclientescnbvM.Municipio = split(0).Trim
        oclientescnbvM.Estado = cmbEstadoR.Text.Trim
        oclientescnbvM.Telfijo = txtTelFijo.Text.Trim
        oclientescnbvM.Telcelular = txtTelcelu.Text.Trim
        oclientescnbvM.Identificacion = txtIdentificacion.Text.Trim
        oclientescnbvM.email = txtCorreoE.Text.Trim
        oclientescnbvM.CP = txtCP.Text.Trim
        oclientescnbvM.Rfc = txtRfc.Text.Trim
        oclientescnbvM.Fecnac = dtpFechaN.Value.ToShortDateString
        oclientescnbvM.Sexo = CmbSexo.SelectedIndex
        oclientescnbvM.Nacionalidad = cmbNacionalidad.Text.Trim
        oclientescnbvM.Empresa = ""
        oclientescnbvM.CURP = txtCurp.Text.Trim
        oclientescnbvM.fiel = TxtFiel.Text.Trim
        oclientescnbvM.actividadcomercial = cmbActividad.Text.Trim

        oclientescnbvM.identifica1 = txtIdentifca1.Text.Trim
        oclientescnbvM.identifica2 = txtIdentifca2.Text.Trim
        oclientescnbvM.firma = TxtFirma.Text.Trim

        oclientescnbvM.Tarjeta = txtNoTarjeta.Text.Trim
        split = Nothing
        oclientescnbvM.nacionalizado = txtNacionalizado.Text.Trim
        oclientescnbvM.Nosucursal = no_sucursal
        oclientescnbvM.VencID = DTVencimiento.Value.ToShortDateString
        oclientescnbvM.riesgo = cmbRiesgo.Text
    End Sub

    Private Sub LLenarDataTables()
        'dt1e = olocalidadesC.Sestado.Tables(0)
        dt1e = olocalidadesC.EstadosCNBV.Tables(0)
        dt5e = dt1e.Copy()
        dt3p = opaisesC.Spaises().Tables(0)
        dt6p = dt3p.Copy()
        dt4a = oactividadesC.Sactividades().Tables(0)
        dt7c = olocalidadesC.ciudadesCNBV.Tables(0)
    End Sub

    Private Sub LlenarCombos()
        cmbEstadoN.Select()
        cmbPaisN.Select()
        cmbPaisR.Select()
        cmbEstadoR.Select()
        cmbCiudadR.Select()
        cmbActividad.Select()
    End Sub

    Private Sub clientescnbvAcciones(ByVal accion As String)
        'las lineas comentadas son para ejecutar la accion fuera del try-catch y me muestre los errores
        Select Case accion
            Case "A"
                AsignarValores()
                oclientescnbvM.num_usu = num_usux
                oclientescnbvM.nom_usu = nom_usux
                oclientescnbvM.fechar = Date.Now.ToShortDateString
                oclientescnbvM.horar = DateTime.Now.ToLongTimeString
                oclientescnbvM.VencID = DTVencimiento.Value.ToShortDateString

                'oclientescnbvC.Aclientecnbv(oclientescnbvM)

                Try
                    If cmbNacionalidad.SelectedIndex = 0 Then
                        If oclientescnbvM.Nombre <> "" And oclientescnbvM.ApellidoPaterno <> "" And oclientescnbvM.Fecnac < Date.Now.AddYears(-18) _
                        And oclientescnbvM.PaisNace <> "" And oclientescnbvM.PaisResidencia <> "" And oclientescnbvM.Identificacion <> "" _
                        And oclientescnbvM.actividadcomercial <> "" And oclientescnbvM.Calle <> "" And oclientescnbvM.No_Exterior <> "" _
                        And oclientescnbvM.EntreCalles <> "" And oclientescnbvM.Colonia <> "" And oclientescnbvM.CP <> "" Then

                            If oclientescnbvC.Aclientecnbv(oclientescnbvM) > 0 Then
                                MessageBox.Show("NUEVO CLIENTE REGISTRADO")
                                HabilitaDesabilitaBotones("Guardar")
                                buscado = False
                                btnN.Select()
                                btnN.Focus()
                                SendKeys.Send("{Enter}")
                            Else
                                MessageBox.Show("NO SE PUDO REGISTRAR ESTE CLIENTE")
                            End If
                        Else
                            CamposVacios()
                            MessageBox.Show("NO ESCRIBIÓ EN UNO DE LOS CAMPOS OBLIGATORIOS, " + Chr(13) + "LOS CAMPOS NO OBLIGATORIOS SON: " + Chr(13) +
                                            "NUMERO DE TARJETA, APP, " + Chr(13) + "NO INTERIOR Y TODOS LOS DATOS DE CONTACTO" + Chr(13) + Chr(13) +
                                            "NORMALMENTE LOS CAMPOS QUE PODRÍAN ESTAR VACÍOS SON:" + Chr(13) + "El COMBO O CAMPO DE ""Actividad""" + Chr(13) +
                                            "LOS CAMPOS QUE COMPONEN LA DIRECCIÓN O LA NACIONALIDAD")
                        End If
                    ElseIf cmbNacionalidad.SelectedIndex = 1 Then
                        If oclientescnbvM.Nombre <> "" And oclientescnbvM.ApellidoPaterno <> "" And oclientescnbvM.Fecnac < Date.Now.AddYears(-18) _
                        And oclientescnbvM.PaisNace <> "" And oclientescnbvM.PaisResidencia <> "" And oclientescnbvM.Identificacion <> "" _
                        And oclientescnbvM.actividadcomercial <> "" _
                        And oclientescnbvM.EntreCalles <> "" And oclientescnbvM.Colonia <> "" And oclientescnbvM.CP <> "" Then

                            If oclientescnbvC.Aclientecnbv(oclientescnbvM) > 0 Then
                                MessageBox.Show("NUEVO CLIENTE REGISTRADO")
                                HabilitaDesabilitaBotones("Guardar")
                                buscado = False
                                btnN.Select()
                                btnN.Focus()
                                SendKeys.Send("{Enter}")
                            Else
                                MessageBox.Show("NO SE PUDO REGISTRAR ESTE CLIENTE")
                            End If
                        Else
                            MessageBox.Show("NO ESCRIBIÓ EN UNO DE LOS CAMPOS OBLIGATORIOS, " + Chr(13) + "LOS CAMPOS NO OBLIGATORIOS SON: " + Chr(13) +
                                            "NUMERO DE TARJETA, APP, " + Chr(13) + "NO INTERIOR Y TODOS LOS DATOS DE CONTACTO" + Chr(13) + Chr(13) +
                                            "NORMALMENTE LOS CAMPOS QUE PODRÍAN ESTAR VACÍOS SON:" + Chr(13) + "El COMBO O CAMPO DE ""Actividad""" + Chr(13) +
                                            "LOS CAMPOS QUE COMPONEN LA DIRECCIÓN O LA NACIONALIDAD")
                        End If
                    End If


                Catch ex As Exception
                    MessageBox.Show("ERROR, REVISE LOS DATOS INTRODUCIDOS")
                    MsgBox("Se ha producido el siguiente error: " + ex.Message,
                MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                End Try
            Case "B"
                'oclientescnbvM.cliente = Convert.ToInt32(txtID.Text)
                'oclientescnbvC.Eclientecnbv(oclientescnbvM)
                Try
                    oclientescnbvM.cliente = Convert.ToInt32(txtID.Text)
                    If oclientescnbvC.Eclientecnbv(oclientescnbvM) > 0 Then
                        MessageBox.Show("CLIENTE ELIMINADO CORRECTAMENTE")
                        buscado = False
                        LimpiarForm()
                        txtID.Text = ""
                        txtNocli.Text = ""
                    Else
                        MessageBox.Show("NO SE PUDO ELIMINAR")
                    End If
                Catch ex As Exception
                    MessageBox.Show("EL CLIENTE NO SE ENCUENTRA EN LA BASE DE DATOS")
                End Try
            Case "C"
                AsignarValores()

                Try
                    If oclientescnbvC.Mclientecnbv(oclientescnbvM, oclientescnbvM2) > 0 Then
                        MessageBox.Show("INFORMACIÓN DEL CLIENTE ACTUALIZADA")
                        txtNocli.Text = oclientescnbvM2.cliente
                        clientescnbvAcciones("S1")
                    Else
                        MessageBox.Show("NO SE PUDO ACTUALIZAR LA INFORMACIÓN DEL CLIENTE")
                    End If
                Catch ex As Exception
                    MessageBox.Show("ERROR CON LA INFORMACIÓN, VERIFIQUE LOS DATOS INTRODUCIDOS")
                End Try
            Case "S1"
                dtpFechaN.Text = DateTime.Now.Date.AddYears(-18)

                Try
                    oclientescnbvM.cliente = Convert.ToInt32(txtNocli.Text)
                    oclientescnbvM2 = oclientescnbvC.S1clientescnbv(oclientescnbvM)
                    oclientescnbvC.LiberarDS()
                    DatosCliente()
                    buscado = True
                Catch ex As Exception
                    dtpFechaN.Text = DateTime.Now.Date.AddYears(-18)
                    cmbActividad.Text = ""
                    MessageBox.Show("NO SE PUDO TRAER LA INFORMACIÓN DEL CLIENTE PORQUE NO SE ENCONTRÓ EN LA BASE DE DATOS O PROVOCÓ UN ERROR")
                    txtNocli.Select()
                End Try
            Case "F"
        End Select
    End Sub

    Private Sub CamposVacios()
        If oclientescnbvM.Nombre = "" Then
            MsgBox("El Campo del Nombre esta Vacío, por favor de Agregar el Dato", MsgBoxStyle.Information)
        ElseIf oclientescnbvM.ApellidoPaterno = "" Then
            MsgBox("El Campo del Apellido Paterno esta Vacío, por favor de Agregar el Dato", MsgBoxStyle.Information)
        ElseIf oclientescnbvM.Calle = "" Then
            MsgBox("El Campo de Calle esta Vacío, por favor de Agregar el Dato", MsgBoxStyle.Information)
        ElseIf oclientescnbvM.No_Exterior = "" Then
            MsgBox("El Campo de No. Exterior esta Vacío, por favor de Agregar el Dato", MsgBoxStyle.Information)
        ElseIf oclientescnbvM.EntreCalles = "" Then
            MsgBox("El Campo de Entre Calles esta Vacío, por favor de Agregar el Dato", MsgBoxStyle.Information)
        ElseIf oclientescnbvM.Fecnac > Date.Now.AddYears(-18) Then
            MsgBox("El Campo de Fecha de Nacimiento es Incorrecto, por favor de Agregar el Dato Correcto", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub DatosCliente()
        LLenarDataTables()
        LlenarCombos()
        'txtNoTarjeta.Text = oclientescnbvM.Iniciales
        txtID.Text = oclientescnbvM.ID
        txtNombre.Text = oclientescnbvM.Nombre
        txtAP.Text = oclientescnbvM.ApellidoPaterno
        txtAM.Text = oclientescnbvM.ApellidoMaterno
        cmbNacionalidad.SelectedItem = oclientescnbvM.Nacionalidad
        If cmbNacionalidad.Text = "" Then
            cmbNacionalidad.Text = oclientescnbvM.Nacionalidad
        End If
        txtNacionalizado.Text = oclientescnbvM.nacionalizado
        If oclientescnbvM.PaisNace <> Nothing Then
            cmbPaisN.SelectedItem = oclientescnbvM.PaisNace
            cmbPaisN.SelectedValue = oclientescnbvM.PaisNace
        Else
            cmbPaisN.Text = ""
        End If

        If oclientescnbvM.EstadoNace <> Nothing Then
            cmbEstadoN.SelectedItem = oclientescnbvM.EstadoNace
            cmbEstadoN.SelectedValue = oclientescnbvM.EstadoNace
        Else
            cmbEstadoN.Text = ""
        End If

        If oclientescnbvM.PaisResidencia <> Nothing Then
            cmbPaisR.SelectedItem = oclientescnbvM.PaisResidencia
            cmbPaisR.SelectedValue = oclientescnbvM.PaisResidencia
        Else
            cmbPaisR.Text = ""
        End If

        If oclientescnbvM.EstadoResidencia <> Nothing Then
            cmbEstadoR.SelectedItem = oclientescnbvM.EstadoResidencia
            cmbEstadoR.SelectedValue = oclientescnbvM.EstadoResidencia
            cmbEstadoR.Text = oclientescnbvM.EstadoResidencia
        Else
            cmbEstadoR.Text = ""
        End If
        If cmbEstadoR.Text = "" And oclientescnbvM.EstadoResidencia <> "" Then
            cmbEstadoR.Text = oclientescnbvM.EstadoResidencia
        End If

        cmbCiudadR.Text = oclientescnbvM.CiudadResidencia
        txtDireccion.Visible = False
        lblDireccion.Visible = False
        txtDireccion.SendToBack()
        lblDireccion.SendToBack()

        CmbSexo.SelectedIndex = oclientescnbvM.Sexo

        txtCalle.Text = oclientescnbvM.Calle
        txtNoExt.Text = oclientescnbvM.No_Exterior
        txtNoInt.Text = oclientescnbvM.No_Interior
        txtEntreCalles.Text = oclientescnbvM.EntreCalles
        cmbColonia.Text = oclientescnbvM.Colonia
        txtColonia.Text = oclientescnbvM.Colonia
        txtTelFijo.Text = oclientescnbvM.Telfijo
        txtTelcelu.Text = oclientescnbvM.Telcelular
        txtIdentificacion.Text = oclientescnbvM.Identificacion
        txtCorreoE.Text = oclientescnbvM.email
        txtCP.Text = oclientescnbvM.CP
        txtRfc.Text = oclientescnbvM.Rfc
        dtpFechaN.Text = oclientescnbvM.Fecnac


        txtCurp.Text = oclientescnbvM.CURP
        TxtFiel.Text = oclientescnbvM.fiel
        If oclientescnbvM.actividadcomercial <> Nothing Then
            Dim split As String()
            If oclientescnbvM.actividadcomercial.Contains(";") Then
                split = oclientescnbvM.actividadcomercial.Split(";")
                cmbActividad.Text = split(0)
            Else
                cmbActividad.Text = oclientescnbvM.actividadcomercial
            End If
        End If

        txtIdentifca1.Text = oclientescnbvM.identifica1
        txtIdentifca2.Text = oclientescnbvM.identifica2
        Dim fs As System.IO.FileStream
        If System.IO.File.Exists(txtIdentifca1.Text) Then
            fs = New System.IO.FileStream(txtIdentifca1.Text, IO.FileMode.Open, IO.FileAccess.Read)
            Imagen1 = System.Drawing.Image.FromStream(fs)
            pkb5.Image = Imagen1
            pkb5.SizeMode = PictureBoxSizeMode.StretchImage
            fs.Close()
        Else
            LimpiarImagen1()
        End If

        If System.IO.File.Exists(txtIdentifca2.Text) Then
            fs = New System.IO.FileStream(txtIdentifca2.Text, IO.FileMode.Open, IO.FileAccess.Read)
            Imagen2 = System.Drawing.Image.FromStream(fs)
            pkb6.Image = Imagen2
            pkb6.SizeMode = PictureBoxSizeMode.StretchImage
            fs.Close()
        Else
            LimpiarImagen2()
        End If

        TxtFirma.Text = oclientescnbvM.firma
        If System.IO.File.Exists(TxtFirma.Text) Then
            fs = New System.IO.FileStream(TxtFirma.Text, IO.FileMode.Open, IO.FileAccess.Read)
            Imagen3 = System.Drawing.Image.FromStream(fs)
            pkd7.Image = Imagen3
            pkd7.SizeMode = PictureBoxSizeMode.StretchImage
            fs.Close()
        Else
            LimpiarImagen3()
        End If

        If oclientescnbvM.riesgo <> Nothing Then
            cmbRiesgo.Text = oclientescnbvM.riesgo
        Else
            cmbRiesgo.Text = ""
        End If

        txtNoTarjeta.Text = oclientescnbvM.Tarjeta
        FechaEnvP = oclientescnbvM.fechaenvp

        CkAPPR.Checked = IIf(oclientescnbvC.clientesRelaciones(txtNocli.Text) = 0, False, True)

        DTVencimiento.Text = oclientescnbvM.VencID
        oclientescnbvM = New clientescnbvM
    End Sub

    Private Sub LimpiarImagenes()
        If Not Imagen1 Is Nothing Then
            Imagen1.Dispose()
            Imagen1 = Nothing
        End If
        LimpiarImagen1()
        LimpiarImagen2()
        LimpiarImagen3()
    End Sub

    Private Sub LimpiarImagen1()
        If Not pkb5.Image Is Nothing Then
            pkb5.Image.Dispose()
            pkb5.Image = Nothing
        End If
        pkb5.Refresh()
    End Sub

    Private Sub LimpiarImagen2()
        If Not pkb6.Image Is Nothing Then
            pkb6.Image.Dispose()
            pkb6.Image = Nothing
        End If
        pkb6.Refresh()
    End Sub

    Private Sub LimpiarImagen3()
        If Not pkd7.Image Is Nothing Then
            pkd7.Image.Dispose()
            pkd7.Image = Nothing
        End If
        pkd7.Refresh()
    End Sub

    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        If Not validar() Then Exit Sub
        If Not valordatos() Then Exit Sub
        If permiso_registro = True And cmbActividad.Text <> "" And txtNombre.Text.Trim <> "" And (cmbPaisN.Text <> "" Or cmbPaisR.Text.Trim <> "") And (txtIdentificacion.Text <> "") _
            And (txtNoExt.Text.Trim <> "" Or txtDireccion.Text <> "" Or txtEntreCalles.Text = "") Then
            clientescnbvAcciones("A")
            guardado = True
            txtNocli.Text = oclientescnbvC.Uclientecnbv2.ToString
            clientescnbvAcciones("S1")
            txtCP.Enabled = False
            oPermitirOtrosC.Cambio0(no_sucursal)
            permiso_registro = False
        Else
            MessageBox.Show("ES NECESARIO CONFIRMAR CON EL PERSONAL DE SISTEMAS EL PERMISO PARA DAR DE ALTA AL CLIENTE")
            If cmbActividad.Text.Trim = "" Then
                MessageBox.Show("ESCOJA LA ACTIVIDAD COMERCIAL DEL CLIENTE")
            End If
            guardado = False
        End If
    End Sub

    Public Function ChecaModificaciones(ByVal oclientescnbvM As clientescnbvM) As Integer
        Dim valor As Boolean
        valor = False

        If txtNombre.Text <> oclientescnbvM.Nombre Then valor = True
        If txtAP.Text <> oclientescnbvM.ApellidoPaterno Then valor = True
        If txtAM.Text <> oclientescnbvM.ApellidoMaterno Then valor = True
        If cmbPaisN.Text <> oclientescnbvM.PaisNace Then valor = True
        If cmbEstadoN.Text <> oclientescnbvM.EstadoNace Then valor = True
        If cmbCiudadR.Text <> oclientescnbvM.CiudadResidencia Then valor = True
        If cmbPaisR.Text <> oclientescnbvM.PaisResidencia Then valor = True
        If cmbEstadoR.Text <> oclientescnbvM.EstadoResidencia Then valor = True
        If txtCalle.Text <> oclientescnbvM.Calle Then valor = True
        If txtNoInt.Text <> oclientescnbvM.No_Interior Then valor = True
        If txtNoExt.Text <> oclientescnbvM.No_Exterior Then valor = True
        If txtEntreCalles.Text <> oclientescnbvM.EntreCalles Then valor = True
        If txtColonia.Text <> oclientescnbvM.Colonia Then valor = True
        If txtTelFijo.Text <> oclientescnbvM.Telfijo Then valor = True
        If txtTelcelu.Text <> oclientescnbvM.Telcelular Then valor = True
        If txtIdentificacion.Text <> oclientescnbvM.Identificacion Then valor = True
        If txtCorreoE.Text <> oclientescnbvM.email Then valor = True
        If txtCP.Text <> oclientescnbvM.CP Then valor = True
        If txtRfc.Text <> oclientescnbvM.Rfc Then valor = True
        If dtpFechaN.Value <> oclientescnbvM.Fecnac Then valor = True
        If CmbSexo.SelectedIndex <> oclientescnbvM.Sexo Then valor = True
        If cmbNacionalidad.Text <> oclientescnbvM.Nacionalidad Then valor = True
        If txtCurp.Text <> oclientescnbvM.CURP Then valor = True
        If TxtFiel.Text <> oclientescnbvM.fiel Then valor = True
        If cmbActividad.Text <> oclientescnbvM.actividadcomercial Then valor = True
        If txtIdentifca1.Text <> oclientescnbvM.identifica1 Then valor = True
        If txtIdentifca2.Text <> oclientescnbvM.identifica2 Then valor = True
        If txtNoTarjeta.Text <> oclientescnbvM.Tarjeta Then valor = True
        If txtNacionalizado.Text <> oclientescnbvM.nacionalizado Then valor = True
        If DTVencimiento.Value <> oclientescnbvM.VencID Then valor = True
        If TxtFirma.Text <> oclientescnbvM.firma Then valor = True

        Return valor
    End Function

    Private Function validar()
        Dim fecha As Date
        Dim fecha2 As Date
        fecha2 = DTVencimiento.Value.ToShortDateString
        fecha = Now
        Dim valor As Boolean
        valor = True
        If cmbActividad.Text = "" Then
            MsgBox("El campo de la Actividad no puede estar vacía", MsgBoxStyle.Information)
            cmbActividad.Focus()
            cmbActividad.BackColor = Color.Red
            valor = False
        ElseIf Trim(txtNombre.Text) = "" Or txtNombre.Text.Length = 0 Then
            MsgBox("El campo del Nombre no puede estar vacía", MsgBoxStyle.Information)
            txtNombre.Focus()
            valor = False
        ElseIf Trim(txtAP.Text) = "" Or txtAP.Text.Length = 0 Then
            MsgBox("El campo del Apellido Paterno no puede estar vacía", MsgBoxStyle.Information)
            txtAP.Focus()
            valor = False
        ElseIf cmbNacionalidad.Text = "" Then
            MsgBox("El campo de Nacionalidad no puede estar vacía", MsgBoxStyle.Information)
            cmbNacionalidad.Focus()
            valor = False
        ElseIf cmbPaisN.Text = "" Then
            MsgBox("El campo de Pais no puede estar vacía", MsgBoxStyle.Information)
            cmbPaisN.Focus()
            valor = False
        ElseIf cmbPaisR.Text = "" Then
            MsgBox("El campo de Pais de Residencia no puede estar vacía", MsgBoxStyle.Information)
            cmbPaisR.Focus()
            valor = False
        ElseIf Trim(txtIdentificacion.Text) = "" Or txtIdentificacion.Text.Length = 0 Then
            MsgBox("El campo de Identificación no puede estar vacía", MsgBoxStyle.Information)
            txtIdentificacion.Focus()
            valor = False
        ElseIf fecha2 <= fecha Then '2015*12+1
            MsgBox("El campo de Vencimiento no puede tener una fecha Menor a la Actual", MsgBoxStyle.Information)
            DTVencimiento.Focus()
            valor = False
        ElseIf Trim(txtCalle.Text) = "" Or txtCalle.Text.Length = 0 Or txtCalle.Text = "0" Then
            MsgBox("El campo de la Calle no esta correcto", MsgBoxStyle.Information)
            txtCalle.Focus()
            txtCalle.BackColor = Color.Red
            valor = False
        ElseIf txtNoInt.Text = "" Or txtNoInt.Text.Length = 0 Then
            MsgBox("El Campo de Numero Interior no puede estar vacía, si no tiene poner un 0 (cero)", MsgBoxStyle.Information)
            txtNoInt.Focus()
            txtNoInt.BackColor = Color.Red
            valor = False
        ElseIf txtColonia.Text = "" Or txtColonia.Text.Length = 0 Then
            MsgBox("El Campo de Colonia no puede estar vacía", MsgBoxStyle.Information)
            txtColonia.Focus()
            txtColonia.BackColor = Color.Red
            valor = False
        ElseIf txtNoExt.Text = "" Or txtNoExt.Text.Length = 0 Then
            MsgBox("El Campo de Numero Exterior no puede estar vacía, si no tiene poner un 0 (cero)", MsgBoxStyle.Information)
            txtNoExt.Focus()
            txtNoExt.BackColor = Color.Red
            valor = False
        ElseIf txtEntreCalles.Text = "" Or txtEntreCalles.Text.Length = 0 Then
            MsgBox("El Campo de Entre Calles no puede estar vacía, si no tiene poner un 0 (cero)", MsgBoxStyle.Information)
            txtEntreCalles.Focus()
            txtEntreCalles.BackColor = Color.Red
            valor = False
        ElseIf txtNacionalizado.Text = "" Then
            MsgBox("El Campo de Nacionalidad no pueden estar vacia", MsgBoxStyle.Information)
            txtNacionalizado.Focus()
            valor = False
        ElseIf dtpFechaN.Value > Date.Now.AddYears(-18) Then
            MsgBox("El Campo de Fecha de Nacimiento debe ser Mayor a 18 años", MsgBoxStyle.Information)
            dtpFechaN.Focus()
            valor = False
        ElseIf Trim(CmbSexo.Text) = "" Then
            MsgBox("El campo de Genero no puede estar vacía", MsgBoxStyle.Information)
            CmbSexo.Focus()
            valor = False
        ElseIf cmbNacionalidad.Text = "MEXICANO" Then
            If Trim(txtIdentifca1.Text) = "" Or txtIdentifca1.Text.Length = 0 Then
                MsgBox("La Imagen de Identificacion Lado A no puede estar vacia", MsgBoxStyle.Information)
                btnIa.Focus()
                valor = False
            ElseIf Trim(txtIdentifca2.Text) = "" Or txtIdentifca2.Text.Length = 0 Then
                MsgBox("La Imagen de Identificacion Lado B no puede estar vacia", MsgBoxStyle.Information)
                btnIb.Focus()
                valor = False
            ElseIf Trim(cmbEstadoN.Text) = "" Then
                MsgBox("El campo de Estado no puede estar vacía", MsgBoxStyle.Information)
                cmbEstadoN.Focus()
                valor = False
            End If
        ElseIf cmbNacionalidad.Text = "EXTRANJERO" Then
            If Trim(txtIdentifca1.Text) = "" Or txtIdentifca1.Text.Length = 0 Then
                MsgBox("La Imagen de Identificacion Lado A no puede estar vacia", MsgBoxStyle.Information)
                btnIa.Focus()
                valor = False
            End If
        End If
        If Not (cmbPaisN.SelectedValue Is Nothing) Then
            dt_Bloqueados = opaisesC.P_Bloqueados
            For Each row As DataRow In dt_Bloqueados.Rows
                If Not (cmbPaisN.SelectedValue Is Nothing) Then
                    If cmbPaisN.SelectedValue.ToString = row("Nombre") Then
                        MsgBox("NO SE PUEDE DAR DE ALTA A CIUDADANOS DE ESTE PAIS", MsgBoxStyle.Critical)
                        valor = False
                    End If
                End If
            Next
            dt_Bloqueados = Nothing
        End If
        Return valor
    End Function

    Private Function validar2()
        Dim fecha As Date
        Dim fecha2 As Date
        fecha2 = DTVencimiento.Value.ToShortDateString
        fecha = Now
        Dim valor As Boolean
        valor = True
        If cmbActividad.Text = "" Then
            MsgBox("El campo de la Actividad no puede estar vacía", MsgBoxStyle.Information)
            cmbActividad.Focus()
            cmbActividad.BackColor = Color.Red
            valor = False
        ElseIf Trim(txtNombre.Text) = "" Or txtNombre.Text.Length = 0 Then
            MsgBox("El campo del Nombre no puede estar vacía", MsgBoxStyle.Information)
            txtNombre.Focus()
            valor = False
        ElseIf Trim(txtAP.Text) = "" Or txtAP.Text.Length = 0 Then
            MsgBox("El campo del Apellido Paterno no puede estar vacía", MsgBoxStyle.Information)
            txtAP.Focus()
            valor = False
        ElseIf cmbNacionalidad.Text = "" Then
            MsgBox("El campo de Nacionalidad no puede estar vacía", MsgBoxStyle.Information)
            cmbNacionalidad.Focus()
            valor = False
        ElseIf cmbPaisN.Text = "" Then
            MsgBox("El campo de Pais no puede estar vacía", MsgBoxStyle.Information)
            cmbPaisN.Focus()
            valor = False
        ElseIf cmbPaisR.Text = "" Then
            MsgBox("El campo de Pais de Residencia no puede estar vacía", MsgBoxStyle.Information)
            cmbPaisR.Focus()
            valor = False
        ElseIf txtNoInt.Text = "" Or txtNoInt.Text.Length = 0 Then
            MsgBox("El Campo de Numero Interior no puede estar vacía, si no tiene poner un 0 (cero)", MsgBoxStyle.Information)
            txtNoInt.Focus()
            txtNoInt.BackColor = Color.Red
            valor = False
        ElseIf txtColonia.Text = "" Or txtColonia.Text.Length = 0 Then
            MsgBox("El Campo de Colonia no puede estar vacía", MsgBoxStyle.Information)
            txtColonia.Focus()
            txtColonia.BackColor = Color.Red
            valor = False
        ElseIf txtNoExt.Text = "" Or txtNoExt.Text.Length = 0 Then
            MsgBox("El Campo de Numero Exterior no puede estar vacía, si no tiene poner un 0 (cero)", MsgBoxStyle.Information)
            txtNoExt.Focus()
            txtNoExt.BackColor = Color.Red
            valor = False
        ElseIf txtEntreCalles.Text = "" Or txtEntreCalles.Text.Length = 0 Then
            MsgBox("El Campo de Entre Calles no puede estar vacía, si no tiene poner un 0 (cero)", MsgBoxStyle.Information)
            txtEntreCalles.Focus()
            txtEntreCalles.BackColor = Color.Red
            valor = False
        ElseIf txtNacionalizado.Text = "" Then
            MsgBox("El Campo de Nacionalidad no pueden estar vacia", MsgBoxStyle.Information)
            txtNacionalizado.Focus()
            valor = False
        ElseIf txtNoTarjeta.Text <> "" And (Trim(txtCorreoE.Text) = "" Or txtCorreoE.Text.Length = 0) Then
            MsgBox("El Cliente que Tiene Tarjeta, no puede esta vacio el Campo de Correo Electronico", MsgBoxStyle.Information)
            txtCorreoE.Focus()
            valor = False
        End If
        Return valor
    End Function

    Private Function valordatos() As Boolean
        Dim valor As Boolean
        valor = True
        If txtNacionalizado.Text <> "" Then
            If oclientescnbvC.chequeopais(txtNacionalizado.Text) <= 0 Then
                MsgBox("El Dato de la Nacionalidad es incorrecta", MsgBoxStyle.Information)
                txtNacionalizado.Focus()
                txtNacionalizado.BackColor = Color.Red
                valor = False
            End If
        End If

        If cmbPaisN.Text <> "" Then
            If oclientescnbvC.chequeopais(cmbPaisN.Text) <= 0 Then
                MsgBox("El dato del Pais es incorrecto", MsgBoxStyle.Information)
                cmbPaisN.Focus()
                cmbPaisN.BackColor = Color.Red
                valor = False
            End If
        End If

        If cmbPaisR.Text <> "" Then
            If oclientescnbvC.chequeopais(cmbPaisR.Text) <= 0 Then
                MsgBox("El dato del Pais de residencia es incorrecto", MsgBoxStyle.Information)
                cmbPaisR.Focus()
                cmbPaisR.BackColor = Color.Red
                valor = False
            End If
        End If

        If cmbEstadoR.Text <> "" Then
            If oclientescnbvC.chequeoEstado(cmbEstadoR.Text) <= 0 Then
                MsgBox("El dato del Estado de residencia es incorrecto", MsgBoxStyle.Information)
                cmbEstadoR.Focus()
                cmbEstadoR.BackColor = Color.Red
                valor = False
            End If
        End If

        If cmbActividad.Text <> "" Then
            If oclientescnbvC.chequeoActividad(cmbActividad.Text) <= 0 Then
                MsgBox("El dato de la Actividad es incorrecto", MsgBoxStyle.Information)
                cmbActividad.Focus()
                cmbActividad.BackColor = Color.Red
                valor = False
            End If
        End If

        If txtTelcelu.Text <> "" Then
            If Buscar_Celular() Then
                valor = False
            End If
        End If

        Return valor
    End Function

    Private Sub cmbEstadoN_Enter(sender As Object, e As EventArgs) Handles cmbEstadoN.Enter
        If cmbEstadoN.Text = "" Then
            cmbEstadoN.DataSource = dt1e
            cmbEstadoN.DisplayMember = "estadopais"
            cmbEstadoN.ValueMember = "estadopais"
            cmbEstadoN.Text = ""
        End If
    End Sub

    Private Sub cmbEstadoR_Enter(sender As Object, e As EventArgs) Handles cmbEstadoR.Enter
        If cmbEstadoR.Items.Count = 0 Then
            cmbEstadoR.DataSource = dt5e
            cmbEstadoR.DisplayMember = "estadopais"
            cmbEstadoR.ValueMember = "estadopais"
            cmbEstadoR.Text = ""
            cmbEstadoR.SelectedItem = cmbEstadoN.Text.Trim.ToUpper
            cmbEstadoR.SelectedText = cmbEstadoN.Text.Trim.ToUpper
            cmbEstadoR.SelectedValue = cmbEstadoR.FindString(cmbEstadoN.Text.Trim.ToUpper)
        End If
    End Sub

    Private Sub cmbPaisR_Enter(sender As Object, e As EventArgs) Handles cmbPaisR.Enter
        If cmbPaisR.Items.Count = 0 Then
            cmbPaisR.DataSource = dt6p
            cmbPaisR.DisplayMember = "pais"
            cmbPaisR.ValueMember = "pais"
            cmbPaisR.Text = ""
        End If

    End Sub

    Private Sub cmbPaisR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbPaisR.KeyPress
        oauxiliares.SoloLetras2(e)
    End Sub

    Private Sub cmbPaisR_Leave(sender As Object, e As EventArgs) Handles cmbPaisR.Leave
        If cmbPaisR.Text <> "MEXICO" Then
            txtCP.Enabled = True
        End If
    End Sub

    Private Sub cmbPaisR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaisR.SelectedIndexChanged
        If cmbPaisR.Text.Trim = "NO DEFINIDA UIF" Then
            cmbEstadoR.Enabled = False
            cmbCiudadR.Enabled = False
        Else
            cmbEstadoR.Enabled = True
            cmbCiudadR.Enabled = True
        End If
    End Sub
    Private Sub cmbPaisR_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPaisR.SelectedValueChanged
        Dim value As Object = cmbPaisR.SelectedValue

        If (TypeOf value Is DataRowView) Then Return
        If cmbPaisR.Items.Count <= 0 Then Return
        If cmbPaisR.Text.Trim = "MEXICO" Then
            dt5e = olocalidadesC.EstadosCNBV(16).Tables(0)
            cmbEstadoR.DataSource = dt5e
            cmbEstadoR.DisplayMember = "estadopais"
            cmbEstadoR.ValueMember = "estadopais"
            cmbEstadoR.SelectedValue = "YUCATAN"
        Else
            dt5e = olocalidadesC.EstadosCNBV(1).Tables(0)
            cmbEstadoR.DataSource = dt5e
            cmbEstadoR.DisplayMember = "estadopais"
            cmbEstadoR.ValueMember = "estadopais"
        End If

    End Sub

    Private Sub cmbActividad_Enter(sender As Object, e As EventArgs) Handles cmbActividad.Enter
        If cmbActividad.Text = "" Then
            cmbActividad.DataSource = dt4a
            cmbActividad.DisplayMember = "nombre"
            cmbActividad.ValueMember = "nombre"
            cmbActividad.Text = ""
        End If
    End Sub

    Private Sub txtTelcelu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelcelu.KeyPress
        oauxiliares.SoloNumeros(e)
    End Sub

    Private Sub txtTelFijo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelFijo.KeyPress
        oauxiliares.SoloNumeros(e)
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        oauxiliares.SoloLetras2(e)
        If btnN.Enabled = True And btnC.Enabled = False Then
            MessageBox.Show("OLVIDÓ PRESIONAR EL BOTÓN NUEVO, SI CONTINÚA NO SE PODRÁN GUARDAR LOS DATOS")
        End If
    End Sub

    Private Sub txtNombre_Leave(sender As Object, e As EventArgs) Handles txtNombre.Leave
        txtNombre.Text = oauxiliares.EliminarAcentos(txtNombre.Text)
    End Sub

    Private Sub txtAP_Enter(sender As Object, e As EventArgs) Handles txtAP.Enter
        If txtNombre.Text = "" Then
            txtNombre.Focus()
        End If
    End Sub

    Private Sub txtAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAP.KeyPress
        oauxiliares.SoloLetras2(e)
    End Sub

    Private Sub txtAP_Leave(sender As Object, e As EventArgs) Handles txtAP.Leave
        txtAP.Text = oauxiliares.EliminarAcentos(txtAP.Text)
    End Sub

    Private Sub txtAM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAM.KeyPress
        oauxiliares.SoloLetras2(e)
    End Sub

    Private Sub txtAM_Leave(sender As Object, e As EventArgs) Handles txtAM.Leave
        txtAM.Text = oauxiliares.EliminarAcentos(txtAM.Text)
        cmbNacionalidad.SelectedItem = "MEXICANA"
    End Sub

    Private Sub txtNoExt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoExt.KeyPress
        oauxiliares.LetrasyNumeros2(e)
    End Sub

    Private Sub txtNoInt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoInt.KeyPress
        oauxiliares.LetrasyNumeros2(e)
    End Sub

    Private Sub txtCP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCP.KeyPress
        oauxiliares.SoloNumeros(e)
    End Sub

    Private Sub txtCalle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCalle.KeyPress
        oauxiliares.LetrasyNumeros2(e)
    End Sub

    Private Sub txtIdentificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdentificacion.KeyPress
        oauxiliares.LetrasyNumeros2(e)
    End Sub

    Private Sub txtCurp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCurp.KeyPress
        oauxiliares.LetrasyNumeros2(e)
    End Sub

    Private Sub txtRfc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRfc.KeyPress
        oauxiliares.LetrasyNumeros2(e)
    End Sub

    Private Sub txtRfc_Leave(sender As Object, e As EventArgs) Handles txtRfc.Leave
        txtRfc.Text = oauxiliares.EliminarAcentos(txtRfc.Text)
        If txtRfc.Text.Trim.Length < 11 And txtRfc.Text.Trim.Length > 0 Then
            Dim result = MessageBox.Show("EL RFC NO TIENE LA EXTENSIÓN ADECUADA, ¿DESEA DEJAR ESTE CAMPO EN BLANCO?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                txtRfc.Text = ""
            ElseIf result = DialogResult.No Then
                txtRfc.Focus()
                txtRfc.SelectionStart = txtRfc.Text.Length
            End If
        End If
    End Sub

    Private Sub txtCurp_Leave(sender As Object, e As EventArgs) Handles txtCurp.Leave
        txtCurp.Text = oauxiliares.EliminarAcentos(txtCurp.Text)
        If txtCurp.Text.Trim.Length < 18 And txtCurp.Text.Trim.Length > 0 Then
            Dim result = MessageBox.Show("LA CURP NO TIENE LA EXTENSIÓN ADECUADA, ¿DESEA DEJAR ESTE CAMPO EN BLANCO?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                txtCurp.Text = ""
            ElseIf result = DialogResult.No Then
                txtCurp.Focus()
                txtCurp.SelectionStart = txtCurp.Text.Length
            End If
        End If
    End Sub

    Private Sub TxtFiel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFiel.KeyPress
        oauxiliares.LetrasyNumeros2(e)
    End Sub

    'Private Sub TxtFiel_Leave(sender As Object, e As EventArgs) Handles TxtFiel.Leave
    '    TxtFiel.Text = oauxiliares.EliminarAcentos(TxtFiel.Text)
    'End Sub

    Private Sub txtEntreCalles_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEntreCalles.KeyPress
        oauxiliares.LetrasyNumeros1(e)
    End Sub

    Private Sub txtEntreCalles_Leave(sender As Object, e As EventArgs) Handles txtEntreCalles.Leave
        txtEntreCalles.Text = oauxiliares.EliminarAcentos(txtEntreCalles.Text)
        If cmbCiudadR.Text <> "" Then
            cmbColonia.BringToFront()
            cmbColonia.Select()
            cmbColonia.Focus()
        Else
            cmbColonia.BringToFront()
            cmbColonia.Select()
            cmbColonia.Focus()
        End If
        If txtDireccion.Text = "" Then
            txtDireccion.Text = "C " & txtCalle.Text.Trim & " NO " & txtNoExt.Text.Trim & " " & txtEntreCalles.Text.Trim
        End If
    End Sub

    Private Sub cmbEstadoN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbEstadoN.KeyPress
        oauxiliares.SoloLetras2(e)
    End Sub

    Private Sub cmbEstadoN_Leave(sender As Object, e As EventArgs) Handles cmbEstadoN.Leave
        cmbEstadoN.Text = cmbEstadoN.Text.ToUpper()
    End Sub

    Private Sub dtpFechaN_Leave(sender As Object, e As EventArgs) Handles dtpFechaN.Leave
        If dtpFechaN.Value.Year < DateTime.Now.AddYears(-17).Year Then

        Else
            Dim dial As DialogResult = MessageBox.Show("¡INCORRECTO! EL AÑO DEBE SER 18 AÑOS MENOR QUE EL AÑO ACTUAL" + Chr(13) +
                                                       """PARA QUITAR ESTE MENSAJE PONGA UN AÑO CORRECTO""" + Chr(13) + "EJ: " & (Date.Now.Year - 18).ToString, "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Question)
            If dial = DialogResult.OK Then
                dtpFechaN.Select()
            End If
        End If
    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        If Not validar() Then Exit Sub
        If Not valordatos() Then Exit Sub
        LimpiarImagenes()
        clientescnbvAcciones("C")
        clientescnbvAcciones("S1")
        txtTelcelu.PasswordChar = "*"
        txtTelcelu.ReadOnly = True
    End Sub

    Private Sub btnE_Click(sender As Object, e As EventArgs) Handles btnE.Click
        LimpiarImagenes()

        'Application.DoEvents()
        If txtIdentifca1.Text <> "" Then
            Try
                If System.IO.File.Exists(System.IO.Path.GetFullPath(txtIdentifca1.Text)) = True Then
                    System.IO.File.Delete(txtIdentifca1.Text)
                End If
            Catch ex As Exception
            End Try

        End If
        If txtIdentifca2.Text <> "" Then
            Try
                If System.IO.File.Exists(System.IO.Path.GetFullPath(txtIdentifca2.Text)) = True Then
                    System.IO.File.Delete(txtIdentifca2.Text)
                End If
            Catch ex As Exception
            End Try
        End If
        If TxtFirma.Text <> "" Then
            Try
                If System.IO.File.Exists(System.IO.Path.GetFullPath(TxtFirma.Text)) = True Then
                    System.IO.File.Delete(TxtFirma.Text)
                End If
            Catch ex As Exception
            End Try
        End If
        clientescnbvAcciones("B")
        HabilitaDesabilitaBotones("Eliminar")
    End Sub

    Private Sub HabilitaDesabilitaBotones(ByVal habilida As String)
        Select Case habilida
            Case "Nuevo"
                btnA.Enabled = Enabled
                btnE.Enabled = False
                btnC.Enabled = False
                btnN.Enabled = False
                txtNombre.Select()
                txtNombre.Focus()
            Case "Guardar"
                btnA.Enabled = False
                btnE.Enabled = False
                btnC.Enabled = False
                btnN.Enabled = True
            Case "Buscar"
                btnA.Enabled = False
                btnE.Enabled = Enabled
                btnC.Enabled = Enabled
                btnN.Enabled = False
                If cove = True Then
                    btnE.Enabled = False
                End If
                If buscado = False Then 'permiso_registro = False And txtNombre.Text.Trim <> "" Then
                    btnA.Enabled = Enabled
                    btnE.Enabled = False
                    btnC.Enabled = False
                    btnN.Enabled = False
                End If
            Case "Eliminar"
                btnA.Enabled = False
                btnE.Enabled = False
                btnC.Enabled = False
                btnN.Enabled = True
        End Select
    End Sub

    Private Sub btnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        If cove = True Then
            txtID.Clear()
        End If
        'If chkDirec2.Checked = True Then
        '    chkDirec2.CheckState = CheckState.Unchecked
        'End If

        LimpiarImagenes()
        If IsNumeric(txtID.Text.Trim) Then
            txtID.Clear()
            SendKeys.Send("{ENTER}")

        Else
            Dim dialog As DialogResult
            Dim form As New FrmBscCliente
            dialog = form.ShowDialog(Me)
            txtNocli.Text = form.clave
            If IsNumeric(txtNocli.Text.Trim) Then
                clientescnbvAcciones("S1")
                CambioCel = txtTelcelu.Text
                txtColonia.BringToFront()
                txtID.SelectAll()
                BtnDocumentacion.Enabled = True
                If txtTelcelu.Text.Length > 0 Then
                    txtTelcelu.ReadOnly = True
                    txtTelcelu.PasswordChar = "*"
                Else
                    txtTelcelu.ReadOnly = False
                    txtTelcelu.PasswordChar = ""
                End If
            Else
                txtID.SelectAll()
            End If
            txtID.Focus()
            txtID.SelectAll()
        End If
        HabilitaDesabilitaBotones("Buscar")

        If txtNoTarjeta.Text.Trim = "" Then
            txtNoTarjeta.Enabled = True
        Else
            txtNoTarjeta.Enabled = False
        End If

        btnS.Focus()
    End Sub

    Private Sub LimpiarForm()
        oclientescnbvM = Nothing
        oclientescnbvM = New clientescnbvM
        txtNoTarjeta.Text = ""
        txtNombre.Text = ""
        txtAP.Text = ""
        txtAM.Text = ""
        cmbPaisN.Text = ""
        cmbEstadoN.Text = ""
        cmbCiudadR.Text = ""
        cmbPaisR.Text = ""
        cmbEstadoR.Text = ""
        CmbSexo.SelectedIndex = -1
        txtCalle.Text = "0"
        txtNoExt.Text = "0"
        txtNoInt.Text = "0"
        txtEntreCalles.Text = "0"
        txtColonia.Text = ""
        cmbEstadoR.Text = ""
        txtTelFijo.Text = ""
        txtTelcelu.Text = ""
        txtIdentificacion.Text = ""
        txtCorreoE.Text = ""
        txtCP.Text = ""
        txtRfc.Text = ""
        'dtpFechaN.Text = DateTime.Now.Date.AddYears(-18)
        dtpFechaN.Text = DateTime.Now.Date
        cmbNacionalidad.Text = ""
        txtCurp.Text = ""
        TxtFiel.Text = ""
        cmbActividad.Text = ""
        txtIdentifca1.Text = ""
        txtIdentifca2.Text = ""
        TxtFirma.Text = ""
        cmbColonia.Text = ""
        LimpiarImagenes()
        ultimocliente = 0
        lblDireccion.Visible = False
        txtDireccion.Visible = False
        txtDireccion.Text = ""
        chk2.CheckState = CheckState.Unchecked
        fracc = ""
        If txtID.Text.Trim <> "" Then
            txtID.Clear()
        End If
        txtNacionalizado.Clear()
        txtNacionalizado.Text = ""
        DTVencimiento.Text = "31/12/" & DateTime.Now.Year
        borrando = False
        oclientescnbvM2 = Nothing
        oclientescnbvM2 = New clientescnbvM
        CkAPPR.Checked = False
    End Sub

    Private Sub btnIa_Click(sender As Object, e As EventArgs) Handles btnIa.Click
        IdentificacionJPG("A")
    End Sub

    Private Sub btnIb_Click(sender As Object, e As EventArgs) Handles btnIb.Click
        IdentificacionJPG("B")
    End Sub

    Private Sub IdentificacionJPG(ByVal AB As String)
        'C:\IDENTIFICA

        Dim IMAGENJPG As String = "\\tsclient\C\IDENTIFICA\" & txtID.Text & AB & ".JPG"
        'Dim SERVIDORJPG As String = "C:\IDENTIFICA\" & txtID.Text & AB & ".JPG"
        Dim SERVIDORJPG As String = "D:\IDENTIFICACIONES\" & txtID.Text & AB & ".JPG"
        Dim fs As System.IO.FileStream
        Select Case Not System.IO.File.Exists(IMAGENJPG)
            Case True
                IMAGENJPG = IMAGENJPG.Replace(AB, AB.ToLower)
                Select Case Not System.IO.File.Exists(IMAGENJPG)
                    Case True
                        MessageBox.Show("NO EXISTE UNA IMAGEN CON ESTE FOLIO, PORFAVOR RENOMBRE LA IMAGEN CON EL NÚMERO DEL CLIENTE" &
                           "" + Chr(13) + "A: PARA EL FRENTE" + Chr(13) + "B: PARA EL REVERSO" + Chr(13) +
                           "SI ES PASAPORTE PONERLE LA LETRA ""A"", SOLO ES UNA IMAGEN" + Chr(13) + "NO PONER ESPACIO ENTRE EL NÚMERO DEL CLIENTE Y LA LETRA")
                    Case False

                        If System.IO.File.Exists(SERVIDORJPG) Then
                            Dim NOMBREORI, NOMBRECAM As String
                            NOMBREORI = ""
                            NOMBRECAM = ""
                            For NO As Integer = 0 To 100
                                If Not System.IO.File.Exists(SERVIDORJPG.Replace(".JPG", NO.ToString & ".JPG")) Then
                                    NOMBREORI = SERVIDORJPG
                                    NOMBRECAM = SERVIDORJPG.Replace("D:\IDENTIFICACIONES\", "").Replace(".JPG", NO.ToString & ".JPG")
                                    My.Computer.FileSystem.RenameFile(SERVIDORJPG, NOMBRECAM)
                                    Exit For
                                End If
                            Next
                        End If

                        Try
                            Me.Cursor = Cursors.WaitCursor
                            Dim copiar As Process
                            copiar = Process.Start("C:\Windows\System32\cmd.exe", "/c copy " & IMAGENJPG & " D:\IDENTIFICACIONES")
                            copiar.StartInfo.CreateNoWindow = False
                            copiar.WaitForExit()
                            copiar.Close()
                            copiar.Dispose()
                            ' Dim bmp As Bitmap
                            If AB = "A".ToLower Then
                                txtIdentifca1.Text = SERVIDORJPG

                                fs = New System.IO.FileStream(txtIdentifca1.Text, IO.FileMode.Open, IO.FileAccess.Read)
                                Imagen1 = System.Drawing.Image.FromStream(fs)
                                pkb5.Image = Imagen1
                                pkb5.SizeMode = PictureBoxSizeMode.StretchImage
                                fs.Close()
                            ElseIf AB = "B".ToLower Then
                                txtIdentifca2.Text = SERVIDORJPG
                                fs = New System.IO.FileStream(txtIdentifca2.Text, IO.FileMode.Open, IO.FileAccess.Read)
                                Imagen2 = System.Drawing.Image.FromStream(fs)
                                pkb6.Image = Imagen2
                                pkb6.SizeMode = PictureBoxSizeMode.StretchImage
                                fs.Close()
                            End If
                            oclientescnbvC.Mimagen(Convert.ToInt32(txtID.Text), txtIdentifca1.Text, txtIdentifca2.Text)
                            Me.Cursor = Cursors.Default

                        Catch ex As Exception
                            Me.Cursor = Cursors.Default
                            MessageBox.Show("HUBO UN ERROR AL SUBIR LA IMAGEN " & IMAGENJPG & " AL SERVIDOR")
                        End Try
                End Select
            Case False
                If System.IO.File.Exists(SERVIDORJPG) Then
                    Dim NOMBREORI, NOMBRECAM As String
                    NOMBREORI = ""
                    NOMBRECAM = ""
                    For NO As Integer = 0 To 100
                        If Not System.IO.File.Exists(SERVIDORJPG.Replace(".JPG", NO.ToString & ".JPG")) Then
                            NOMBREORI = SERVIDORJPG
                            NOMBRECAM = SERVIDORJPG.Replace("D:\IDENTIFICACIONES\", "").Replace(".JPG", NO.ToString & ".JPG")
                            My.Computer.FileSystem.RenameFile(SERVIDORJPG, NOMBRECAM)
                            Exit For
                        End If
                    Next
                End If
                Try
                    Me.Cursor = Cursors.WaitCursor
                    Dim copiar As Process
                    copiar = Process.Start("C:\Windows\System32\cmd.exe", "/c copy " & IMAGENJPG & " D:\IDENTIFICACIONES")
                    copiar.StartInfo.CreateNoWindow = False
                    copiar.WaitForExit()
                    copiar.Close()
                    copiar.Dispose()

                    If AB = "A" Then
                        txtIdentifca1.Text = SERVIDORJPG
                        fs = New System.IO.FileStream(txtIdentifca1.Text, IO.FileMode.Open, IO.FileAccess.Read)
                        Imagen1 = System.Drawing.Image.FromStream(fs)
                        pkb5.Image = Imagen1
                        pkb5.SizeMode = PictureBoxSizeMode.StretchImage
                        fs.Close()
                    ElseIf AB = "B" Then
                        txtIdentifca2.Text = SERVIDORJPG
                        fs = New System.IO.FileStream(txtIdentifca2.Text, IO.FileMode.Open, IO.FileAccess.Read)
                        Imagen2 = System.Drawing.Image.FromStream(fs)
                        pkb6.Image = Imagen2
                        pkb6.SizeMode = PictureBoxSizeMode.StretchImage
                        fs.Close()
                    End If
                    oclientescnbvC.Mimagen(Convert.ToInt32(txtID.Text), txtIdentifca1.Text, txtIdentifca2.Text)
                    Me.Cursor = Cursors.Default

                Catch ex As Exception
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("HUBO UN ERROR AL SUBIR LA IMAGEN " & IMAGENJPG & " AL SERVIDOR")
                End Try
        End Select

    End Sub

    Private Sub cmbColonia_Enter(sender As Object, e As EventArgs) Handles cmbColonia.Enter
        If txtCP.Text = "" Then
            txtCP.Text = "00000"
        End If
    End Sub

    Private Sub cmbColonia_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbColonia.KeyDown
        If e.KeyCode = Keys.Back And (e.KeyCode <> Keys.Enter And e.KeyCode <> Keys.Tab) Then
            borrando = True
        Else
            borrando = False
        End If
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            ' txtTelFijo.Focus()
            txtCP.Focus()
        End If
    End Sub

    Private Sub cmbColonia_TextChanged(sender As Object, e As EventArgs) Handles cmbColonia.TextChanged
        'If cmbColonia.Text.Length > 2 And borrando = False And cmbCiudadR.Text <> "" Then
        '    AutoCompletarCP()
        'End If
    End Sub

    'Private Sub AutoCompletarCP()
    '    'oCodigosPostalesM.Estado = cmbEstadoR.Text.Trim
    '    'Dim split As String() = cmbCiudadR.Text.Trim.Split(",")
    '    'oCodigosPostalesM.Municipio = split(0)
    '    'oCodigosPostalesM.Colonia = cmbColonia.Text.Trim

    '    'cmbColonia.AutoCompleteCustomSource = oCodigosPostalesC.AutoCompletarCP(oCodigosPostalesM, "%", "%") 'aqui
    '    'cmbColonia.AutoCompleteMode = AutoCompleteMode.Suggest
    '    'cmbColonia.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    'oCodigosPostalesC.LiberarDt()
    '    'SendKeys.Send("{RIGHT}")
    'End Sub

    Private Sub AutoCompletarCiudad()
        oCodigosPostalesM.Estado = cmbEstadoR.Text
        oCodigosPostalesM.Municipio = cmbCiudadR.Text
        cmbCiudadR.AutoCompleteCustomSource = oCodigosPostalesC.AutoCompletarMunicipio(oCodigosPostalesM, "%", "%") 'aqui
        cmbCiudadR.AutoCompleteMode = AutoCompleteMode.Suggest
        cmbCiudadR.AutoCompleteSource = AutoCompleteSource.CustomSource
        oCodigosPostalesC.LiberarDt()
        SendKeys.Send("{RIGHT}")
    End Sub

    Private Sub cmbCiudadR_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCiudadR.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            txtIdentificacion.Focus()
        End If
    End Sub

    'Private Sub cmbCiudadR_TextChanged(sender As Object, e As EventArgs) Handles cmbCiudadR.TextChanged
    '    'Me.Cursor = Cursors.WaitCursor
    '    'If cmbCiudadR.Text.Trim.Length > 1 Then
    '    '    AutoCompletarCiudad()
    '    'End If
    '    'Me.Cursor = Cursors.Default
    'End Sub

    Private Sub txtCorreoE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorreoE.KeyPress
        oauxiliares.LetrasyNumeros3(e)
    End Sub

    Private Sub txtCorreoE_Leave(sender As Object, e As EventArgs) Handles txtCorreoE.Leave
        If oclientescnbvC.Email_Valido(txtCorreoE.Text) = False Then
            Dim result = MessageBox.Show("EL CORREO ELECTRONICO NO TIENE EL FORMATO CORRECTO, ¿DESEA DEJAR ESTE CAMPO EN BLANCO?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                txtCorreoE.Text = ""
            ElseIf result = DialogResult.No Then
                txtCorreoE.Focus()
                txtCorreoE.SelectionStart = txtCorreoE.Text.Length
            End If
        End If
    End Sub

    Private Sub cmbColonia_Leave(sender As Object, e As EventArgs) Handles cmbColonia.Leave
        If cmbCiudadR.Text <> "" Then
            Dim split2 As String() = cmbColonia.Text.Split(" ")
            If IsNumeric(split2(split2.Length - 1).ToString()) Then

                txtCP.Text = "00000" 'split2(split2.Length - 1).ToString()
                txtCP.Focus()
                txtCP.SelectAll()

            End If

            If txtCP.Text.Trim.Length = 5 Then
                txtColonia.BringToFront()
            End If

        End If
        If cmbPaisR.Text <> "MEXICO" Then
            cmbColonia.Text = cmbColonia.Text.ToUpper()
        End If
        txtColonia.Text = "COL " & cmbColonia.Text
        If Not cmbColonia.SelectedValue = Nothing Then
            txtCP.Text = cmbColonia.SelectedValue.ToString
        Else
            txtCP.Text = "00000"
        End If

        If txtCP.Text.Trim.Length < 5 Or txtCP.Text.Trim.Length > 5 Then
            MessageBox.Show("CODIGO POSTAL INVALIDO, PORFAVOR DIGITE UN C.P. DE 5 NUMEROS AL LADO DE LA COLONIA")
            cmbColonia.BringToFront()
            cmbColonia.Focus()
        End If
    End Sub

    Private Sub cmbNacionalidad_Click(sender As Object, e As EventArgs) Handles cmbNacionalidad.Click
        If cmbNacionalidad.Text = "MEXICANO" Then
            txtNacionalizado.Text = "MEXICO"
            dt3p = opaisesC.Spaises(1).Tables(0)
        Else
            dt3p = opaisesC.Spaises(2).Tables(0)
        End If
    End Sub

    Private Sub cmbNacionalidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbNacionalidad.KeyPress
        oauxiliares.SoloLetras2(e)
        e.Handled = True
    End Sub

    Private Sub cmbNacionalidad_Leave(sender As Object, e As EventArgs) Handles cmbNacionalidad.Leave
        cmbNacionalidad.Text = cmbNacionalidad.Text.Trim.ToUpper
        cmbPaisN.Focus()
    End Sub

    Private Sub txtColonia_Click(sender As Object, e As EventArgs) Handles txtColonia.Click
        txtColonia.SendToBack()
        cmbColonia.Focus()
    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        Dim form As New FrmIdentificacion
        If oclientescnbvM2 IsNot Nothing Then
            If oclientescnbvM2.identifica1 Is Nothing Or oclientescnbvM2.identifica1 = "" Then
                oclientescnbvM2.identifica1 = txtIdentifca1.Text
            End If
            If oclientescnbvM2.identifica2 Is Nothing Or oclientescnbvM2.identifica2 = "" Then
                oclientescnbvM2.identifica2 = txtIdentifca2.Text
            End If
        End If

        form.oclientescnbvM = oclientescnbvM2
        form.ShowDialog()
    End Sub

    Private Sub btnN_Click(sender As Object, e As EventArgs) Handles btnN.Click
        LimpiarForm()

        buscado = False
        HabilitaDesabilitaBotones("Nuevo")
        If cove = True Then
            txtID.Clear()
        End If
        'se pide el folio del cliente +1 para la credencial
        txtID.Text = seguiente_folio("CLIENTE")

        txtNombre.Focus()
        txtNombre.Focus()
    End Sub

    Private Sub txtColonia_Enter(sender As Object, e As EventArgs) Handles txtColonia.Enter
        chk2.CheckState = CheckState.Unchecked
    End Sub

    Private Sub txtColonia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtColonia.KeyPress
        oauxiliares.LetrasyNumeros1(e)
    End Sub

    Private Sub txtNoTarjeta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoTarjeta.KeyPress
        oauxiliares.SoloNumerosLetras(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If oPuntos.ChecarTarjeta(txtNoTarjeta.Text) > 0 Then
                MsgBox("La Tarjeta ya fue asignada a un cliente", MsgBoxStyle.Information)
                txtNoTarjeta.Text = ""
                txtNoTarjeta.Focus()
            Else
                txtCorreoE.Focus()
            End If
        End If
    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress
        oauxiliares.LetrasyNumeros1(e)
    End Sub

    Private Sub cmbPaisN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbPaisN.KeyPress
        'oauxiliares.SoloLetras2(e)
    End Sub

    Private Sub cmbRiesgo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbRiesgo.KeyPress
        oauxiliares.SoloLetras2(e)
    End Sub

    Private Sub cmbEstadoR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbEstadoR.KeyPress
        oauxiliares.SoloLetras2(e)
    End Sub

    Private Sub cmbCiudadR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbCiudadR.KeyPress
        oauxiliares.SoloLetras2(e)
    End Sub

    Private Sub cmbColonia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbColonia.KeyPress
        oauxiliares.LetrasyNumeros2(e)
    End Sub

    Private Sub cmbActividad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbActividad.KeyPress
        oauxiliares.SoloLetras2(e)
    End Sub

    Private Sub chk2_CheckedChanged(sender As Object, e As EventArgs) Handles chk2.CheckedChanged
        If chk2.CheckState = CheckState.Checked And Not txtColonia.Text.Contains("FRACC ") Then
            txtColonia.Text = txtColonia.Text.Replace("COL ", "")
            txtColonia.Text = "FRACC " & txtColonia.Text
        Else
            txtColonia.Text = txtColonia.Text.Replace("FRACC ", "")
        End If
    End Sub

    Private Sub chkApp_Leave(sender As Object, e As EventArgs)
        txtTelFijo.Focus()
    End Sub

    Private Sub txtID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtID.KeyPress
        oauxiliares.SoloNumeros(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) And IsNumeric(txtID.Text.Trim) Then
            clientescnbvAcciones("S1")
            HabilitaDesabilitaBotones("Buscar")
            txtColonia.BringToFront()
            txtID.Focus()
            'txtID.Select()
        End If
    End Sub

    Private Sub cmbCiudadR_Leave(sender As Object, e As EventArgs) Handles cmbCiudadR.Leave
        cmbCiudadR.Text = cmbCiudadR.Text.Trim.ToUpper
    End Sub

    Private Sub cmbPaisN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaisN.SelectedIndexChanged
        'If cmbPaisN.Text.Trim = "NO DEFINIDA UIF" Then
        '    cmbEstadoN.Enabled = False
        'ElseIf cmbPaisN.Text.Trim = "MEXICO" Then
        '    cmbEstadoN.Enabled = True
        'Else
        '    cmbEstadoN.Enabled = True
        '    If txtNacionalizado.Text = "System.Data.DataRowView" Then
        '        txtNacionalizado.Text = "MEXICO"
        '    Else
        '        txtNacionalizado.Text = cmbPaisN.Text
        '    End If
        'End If
    End Sub

    Private Sub chk2_Leave(sender As Object, e As EventArgs) Handles chk2.Leave
        txtCP.Focus()
    End Sub

    Private Sub txtCP_Leave(sender As Object, e As EventArgs) Handles txtCP.Leave
        If txtCP.Text.Trim.Length < 5 Then
            MessageBox.Show("EL CODIGO POSTAL NO TIENE LA EXTENCIÓN CORRECTA, VERIFIQUE QUE SEAN 5 CARÁCTERES")
            txtCP.Focus()
        End If
    End Sub

    Private Sub txtIdentifca1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdentifca1.KeyPress
        'e.Handled = True
    End Sub

    Private Sub txtIdentifca2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdentifca2.KeyPress
        'e.Handled = True
    End Sub

    Private Sub txtNacionalizado_Enter(sender As Object, e As EventArgs) Handles txtNacionalizado.Enter
        If txtNacionalizado.Text = "SU PAIS" Then
            txtNacionalizado.Clear()
        End If
    End Sub

    Private Sub txtNacionalizado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNacionalizado.KeyPress
        oauxiliares.SoloLetras2(e)
    End Sub

    Private Sub txtNocli_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNocli.KeyPress
        oauxiliares.SoloNumeros(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) And IsNumeric(txtNocli.Text.Trim) Then
            clientescnbvAcciones("S1")
            HabilitaDesabilitaBotones("Buscar")
            txtColonia.BringToFront()
            txtNocli.Focus()
        End If
    End Sub

    Private Sub GroupBox1_Leave(sender As Object, e As EventArgs) Handles GroupBox1.Leave
        Dim conec As New ConexionSQLS
        Dim comm As New SqlCommand
        Dim rs As SqlDataReader
        Dim SQL As String
        Dim Encontro As Boolean = False
        Dim Resultado As Boolean = False
        Dim MensajeRojoLocal As String = ""
        Dim MensajeGeneral As String = ""
        Dim Tipo As String = ""

        If buscado = False Then
            If txtNombre.Text.Trim <> "" And (txtAP.Text.Trim <> "" Or txtAM.Text.Trim <> "") And guardado = False Then 'And permiso_registro = False" Then

                SQL = "SELECT cliente,ApellidoPaterno,ApellidoMaterno,Nombre, 'CLIENTE EXISTENTES' as Mensaje, '1' as Tipo from clientescnbv where "
                SQL += "ApellidoPaterno = '" & txtAP.Text.Trim & "' and "
                SQL += "ApellidoMaterno = '" & txtAM.Text.Trim & "' and "
                SQL += " Nombre = '" & txtNombre.Text.Trim & "'"

                SQL += " UNION SELECT Num,ApellidoPaterno,ApellidoMaterno,Nombres, 'PERSONAS POLITICAMENTE EXPUESTAS' as Mensaje, '1' as Tipo from PersonasPoliticasE where "
                SQL += "ApellidoPaterno = '" & txtAP.Text.Trim & "' and "
                SQL += "ApellidoMaterno = '" & txtAM.Text.Trim & "' and "
                SQL += " Nombres = '" & txtNombre.Text.Trim & "'"

                SQL += " UNION SELECT Num,ApellidoPaterno,ApellidoMaterno,Nombres, 'PERSONAS POLITICAMENTE EXPUESTAS EXTRANJERA' as Mensaje, '1' as Tipo from PersonasPoliticasEEx where "
                SQL += "ApellidoPaterno = '" & txtAP.Text.Trim & "' and "
                SQL += "ApellidoMaterno = '" & txtAM.Text.Trim & "' and "
                SQL += " Nombres = '" & txtNombre.Text.Trim & "'"

                SQL += " UNION SELECT id,ApellidoPaterno,ApellidoMaterno,Nombre, 'LISTADO OFAC' as Mensaje, '2' as Tipo from OFAC where "
                SQL += "ApellidoPaterno = '" & txtAP.Text.Trim & "' and "
                SQL += "ApellidoMaterno = '" & txtAM.Text.Trim & "' and "
                SQL += " Nombre = '" & txtNombre.Text.Trim & "'"

                SQL += " UNION SELECT Num,ApellidoPaterno,ApellidoMaterno,Nombres, 'PERSONAS BLOQUEADAS FISICAS' as Mensaje, '3' as Tipo from PersonasBloqueadasFisicas where "
                SQL += "ApellidoPaterno = '" & txtAP.Text.Trim & "' and "
                SQL += "ApellidoMaterno = '" & txtAM.Text.Trim & "' and "
                SQL += " Nombres = '" & txtNombre.Text.Trim & "'"

                SQL += " UNION SELECT '1' as cliente, '' as ApellidoPaterno, '' as ApellidoMaterno, Nombre, 'LISTA PERSONAS BLOQUEADAS' as Mensaje, '2' as Tipo from ListaPersonasBloqueadas "
                SQL += "Where Nombre = '" & txtNombre.Text.Trim & " " & txtAP.Text.Trim & " " & txtAM.Text.Trim & "' "

                SQL += " UNION SELECT '1' as cliente, '' as ApellidoPaterno, '' as ApellidoMaterno, Nombre, 'LISTA PERSONAS BLOQUEADAS' as Mensaje, '2' as Tipo from ListaPersonasBloqueadas "
                SQL += "Where Nombre = '" & txtAP.Text.Trim & " " & txtAM.Text.Trim & " " & txtNombre.Text.Trim & "'"

                SQL += " UNION SELECT '1' as cliente, '' as ApellidoPaterno, '' as ApellidoMaterno, Nombre, 'LISTA PERSONAS BLOQUEADAS 69 B CFF' as Mensaje, '2' as Tipo from Listado69BFisica "
                SQL += "Where Nombre = '" & txtNombre.Text.Trim & " " & txtAP.Text.Trim & " " & txtAM.Text.Trim & "' "

                SQL += " UNION SELECT '1' as cliente, '' as ApellidoPaterno, '' as ApellidoMaterno, Nombre, 'LISTA PERSONAS BLOQUEADAS 69 B CFF' as Mensaje, '2' as Tipo from Listado69BFisica "
                SQL += "Where Nombre = '" & txtAP.Text.Trim & " " & txtAM.Text.Trim & " " & txtNombre.Text.Trim & "'"

                SQL += " UNION SELECT '1' as cliente, '' as ApellidoPaterno, '' as ApellidoMaterno, Nombre, 'LISTA PERSONAS BLOQUEADAS 69 B CFF' as Mensaje, '2' as Tipo from Listado69BMoral "
                SQL += "Where Nombre = '" & txtNombre.Text.Trim & " " & txtAP.Text.Trim & " " & txtAM.Text.Trim & "' "

                SQL += " UNION SELECT '1' as cliente, '' as ApellidoPaterno, '' as ApellidoMaterno, Nombre, 'LISTA PERSONAS BLOQUEADAS 69 B CFF' as Mensaje, '2' as Tipo from Listado69BMoral "
                SQL += "Where Nombre = '" & txtAP.Text.Trim & " " & txtAM.Text.Trim & " " & txtNombre.Text.Trim & "'"
                comm.Connection = conec.EstablecerConexion()
                conec.AbrirConexion()

                comm.CommandText = SQL

                rs = comm.ExecuteReader
                While rs.Read
                    MensajeRojoLocal = "MARCADOS POR EL COLOR ROJO SON " & rs(4)
                    MensajeGeneral = "Si es una " & rs(4) & " lo Seleccionas en el Grid y Precionas el Boton de Persona Registrada."
                    Encontro = True
                    Tipo = rs(5)
                End While
                rs.Close()
                conec.CerrarConexion()

                If Encontro Then
                    permiso_registro = False
                    'MessageBox.Show("YA SE ENCUENTRA UN REGISTRO CON ESTE NOMBRE, PORFAVOR REVISE QUE NO EXISTA UN CLIENTE CON ESTE NOMBRE, CUANDO" + Chr(13) + " CONFIRME QUE EL CLIENTE OTRA PERSONA CON LOS MISMOS DATOS" + Chr(13) +
                    '                " PREISONE EL BOTÓN DE HOMONIMOS ACEPTADO, SI NO CANCELAR")
                    Dim frm As New FrmBsOnonimos
                    frm.MensajeRojo = MensajeRojoLocal
                    frm.MensajeGral = MensajeGeneral
                    frm.ApellidoPat = txtAP.Text
                    frm.ApellidoMat = txtAM.Text
                    frm.Nombre = Mid(txtNombre.Text, 1, 3)
                    frm.ShowDialog()
                    permiso_registro = frm.homonimo
                    If frm.homonimo = False Then
                        If frm.PPE = True Then
                            Select Case Tipo
                                Case "1"
                                    Dim notificacion As New FrmNotificacionPersonasPoliticas
                                    notificacion.ShowDialog()
                                    If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                                        Resultado = True
                                    End If
                                Case "2"
                                    Dim notificacion As New FrmNotificacionPersonasBloqueadas
                                    notificacion.ShowDialog()
                                    If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                                        Resultado = True
                                    End If
                                Case "3"
                                    Dim notificacion As New FrmNotificacionPersonasBloqueadas
                                    notificacion.ShowDialog()
                                    If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                                        Resultado = True
                                    End If
                            End Select
                            If Resultado Then
                                If Tipo < 3 Then
                                    btnA.Enabled = False
                                    Dim doc As String = Application.StartupPath & "\Cuestionario.doc"
                                    If My.Computer.FileSystem.FileExists(doc) Then
                                        My.Computer.FileSystem.DeleteFile(doc)
                                    End If

                                    My.Computer.FileSystem.CopyFile(
                                        doc.Replace("Cuestionario.doc", "notificacion\Cuestionario.doc"),
                                        doc, overwrite:=True)

                                    Dim doc2 As String = Application.StartupPath & "\Autorizacion.doc"
                                    If My.Computer.FileSystem.FileExists(doc2) Then
                                        My.Computer.FileSystem.DeleteFile(doc2)
                                    End If

                                    My.Computer.FileSystem.CopyFile(
                                        doc2.Replace("Autorizacion.doc", "notificacion\Autorizacion.doc"),
                                        doc2, overwrite:=True)
                                    ElWord2()
                                    ElWord3()
                                Else
                                    btnA.Enabled = False
                                    Dim doc As String = Application.StartupPath & "\bloquedas.docx"
                                    'If My.Computer.FileSystem.FileExists(doc) Then
                                    '    My.Computer.FileSystem.DeleteFile(doc)
                                    'End If

                                    'My.Computer.FileSystem.CopyFile(
                                    '    doc.Replace("bloqueadas.docx", "notificacion\bloqueadas.docx"),
                                    '    doc, overwrite:=True)
                                    ElWord4()
                                End If
                            End If
                        End If
                        txtNombre.Focus()
                        txtNombre.SelectAll()
                        txtAP.Text = ""
                        txtAM.Text = ""
                    End If
                Else
                    permiso_registro = True
                End If
            End If
        End If
    End Sub

    Private Sub btnValidar_Click(sender As Object, e As EventArgs) Handles btnValidar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim dialogResult As DialogResult = MessageBox.Show("¿DESEA VALIDAR QUE EL CLIENTE ES NUEVO?", "CONFIRMAR", MessageBoxButtons.YesNo)
        If dialogResult = DialogResult.Yes Then
            If oPermitirOtrosC.Cambio1(no_sucursal) = 1 Then
                MessageBox.Show("PERMISO VALIDADO")
            Else
                MessageBox.Show("NO SE PUDO VALIDAR")
            End If
        ElseIf dialogResult = DialogResult.No Then
            'do something else
        End If
        If oPermitirOtrosC.Permitir(no_sucursal) = 1 Then
            permiso_registro = True
        Else
            permiso_registro = False
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PersonasBloqueadas1()
        dt_BloqFisicas = oPersonasBloqueadasFisicasC.FILTRAR_ALL(oPersonasBloqueadasFisicasM, "", "").Tables(0)
        source_BloqFisicas.DataSource = dt_BloqFisicas
    End Sub

    Private Sub Filtra_bloqFisicas()
        Try
            Dim filtro As String = String.Empty
            If txtNombre.Text.Trim <> "" And txtAP.Text.Trim <> "" Then
                filtro += "[NomCompleto] Like '%" & txtNombre.Text.Trim & "%' and"
                filtro += "[NomCompleto] like '%" & txtAP.Text.Trim & "%' and"
                If filtro.Trim().Length > 1 Then
                    filtro = filtro.Remove(filtro.Length - 3, 3)
                End If
                filtro += " or [Alias] like '%" & txtNombre.Text.Trim & "%' and [Alias] like '%" & txtAP.Text.Trim & "%'"

                source_BloqFisicas.Filter = filtro
                If source_BloqFisicas.Count = 0 Then
                    'todo ok
                Else
                    Dim notificacion As New FrmNotificacionPersonasBloqueadas
                    notificacion.ShowDialog()
                    If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                        btnA.Enabled = False

                        Dim frmAlerta As New FrmAlerta
                        frmAlerta.monto = "0"
                        frmAlerta.empleado = nom_usux
                        frmAlerta.usuario = txtNombre.Text.Trim & " " & txtAP.Text.Trim
                        frmAlerta.divisa = ""
                        frmAlerta.operacion = ""
                        frmAlerta.sucursal = nom_sucursal
                        frmAlerta.no_caje = num_usux
                        frmAlerta.razon = "lista"
                        frmAlerta.ShowDialog()

                        Dim doc As String = Application.StartupPath & "\Oficio.doc"
                        If My.Computer.FileSystem.FileExists(doc) Then
                            My.Computer.FileSystem.DeleteFile(doc)
                        End If

                        My.Computer.FileSystem.CopyFile(
                            doc.Replace("Oficio.doc", "notificacion\Oficio.doc"),
                            doc, overwrite:=True)

                        ElWord()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ElWord()
        Dim miWord As New Word.Application
        'Creamos una instancia de Word
        miWord = CreateObject("Word.Application")
        miWord.Documents.Open(Application.StartupPath & "\Oficio.doc")
        miWord.Visible = True

        With miWord.ActiveDocument.Bookmarks
            .Item("fecha").Range.Text = Date.Now.ToString("dd/MM/yyyy")
            .Item("d1").Range.Text = txtNombre.Text
            .Item("d2").Range.Text = txtAP.Text
        End With
        miWord = Nothing
    End Sub

    Private Sub PersonasBloqueadas2()
        dt_PPoliticas = oPersonasPoliticasEC.FILTRAR_ALL(oPersonasPoliticasEM, "", "").Tables(0)
        source_PPoliticas.DataSource = dt_PPoliticas
    End Sub

    Private Sub Filtra_bloqFisicas2()
        Try
            Dim filtro As String = String.Empty
            If txtNombre.Text.Trim <> "" And txtAP.Text.Trim <> "" Then
                filtro += "[NomCompleto] like '%" & txtNombre.Text.Trim & "%' and"
                filtro += "[NomCompleto] like '%" & txtAP.Text.Trim & "%' and"
                If filtro.Trim().Length > 1 Then
                    filtro = filtro.Remove(filtro.Length - 3, 3)
                End If

                source_PPoliticas.Filter = filtro
                If source_PPoliticas.Count = 0 Then
                    'todo ok
                Else
                    Dim notificacion As New FrmNotificacionPersonasPoliticas
                    notificacion.ShowDialog()
                    If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                        btnA.Enabled = False
                        Dim doc As String = Application.StartupPath & "\Cuestionario.doc"
                        If My.Computer.FileSystem.FileExists(doc) Then
                            My.Computer.FileSystem.DeleteFile(doc)
                        End If

                        My.Computer.FileSystem.CopyFile(
                            doc.Replace("Cuestionario.doc", "notificacion\Cuestionario.doc"),
                            doc, overwrite:=True)

                        Dim doc2 As String = Application.StartupPath & "\Autorizacion.doc"
                        If My.Computer.FileSystem.FileExists(doc2) Then
                            My.Computer.FileSystem.DeleteFile(doc2)
                        End If

                        My.Computer.FileSystem.CopyFile(
                            doc2.Replace("Autorizacion.doc", "notificacion\Autorizacion.doc"),
                            doc2, overwrite:=True)
                        ElWord2()
                        ElWord3()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ElWord2()
        Dim miWord As New Word.Application
        'Creamos una instancia de Word
        miWord = CreateObject("Word.Application")
        miWord.Documents.Open(Application.StartupPath & "\Cuestionario.doc")
        miWord.Visible = True

        With miWord.ActiveDocument.Bookmarks
            .Item("Fecha").Range.Text = Date.Now.ToString("dd/MM/yyyy")
            .Item("Nombre").Range.Text = txtNombre.Text & " " & txtAP.Text & " " & txtAM.Text
        End With
        miWord = Nothing
    End Sub

    Private Sub ElWord3()
        Dim miWord As New Word.Application
        'Creamos una instancia de Word
        miWord = CreateObject("Word.Application")
        miWord.Documents.Open(Application.StartupPath & "\Autorizacion.doc")
        miWord.Visible = True

        With miWord.ActiveDocument.Bookmarks
            .Item("Fecha").Range.Text = Date.Now.ToString("dd/MM/yyyy")
            .Item("Nombre").Range.Text = txtNombre.Text & " " & txtAP.Text & " " & txtAM.Text
        End With
        miWord = Nothing
    End Sub
    Private Sub ElWord4()
        Dim miWord As New Word.Application
        'Creamos una instancia de Word
        miWord = CreateObject("Word.Application")
        miWord.Documents.Open(Application.StartupPath & "\bloqueadas.docx")
        miWord.Visible = True

        With miWord.ActiveDocument.Bookmarks
            .Item("Fecha").Range.Text = Date.Now.ToString("dd/MM/yyyy")
            .Item("Nombre").Range.Text = txtNombre.Text & " " & txtAP.Text & " " & txtAM.Text
        End With
        miWord = Nothing
    End Sub

    Private Sub cmbNacionalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNacionalidad.SelectedIndexChanged
        If cmbNacionalidad.Text = "MEXICANO" Then
            txtNacionalizado.Text = "MEXICO"
            txtNacionalizado.Enabled = False
            dt3p = opaisesC.Spaises(1).Tables(0)
            cmbPaisN.DataSource = dt3p
            cmbPaisN.DisplayMember = "pais"
            cmbPaisN.ValueMember = "pais"
            cmbEstadoN.DataSource = Nothing
            dt1e = olocalidadesC.EstadosCNBV(16).Tables(0)
            cmbEstadoN.DataSource = dt1e
            cmbEstadoN.DisplayMember = "estadopais"
            cmbEstadoN.ValueMember = "estadopais"
        ElseIf cmbNacionalidad.Text = "EXTRANJERO" Then
            txtNacionalizado.Text = ""
            txtNacionalizado.Enabled = True
            dt3p = opaisesC.Spaises(2).Tables(0)
            cmbPaisN.DataSource = dt3p
            cmbPaisN.DisplayMember = "pais"
            cmbPaisN.ValueMember = "pais"
            cmbEstadoN.DataSource = Nothing
            dt1e = olocalidadesC.EstadosCNBV(1).Tables(0)
            cmbEstadoN.DataSource = dt1e
            cmbEstadoN.DisplayMember = "estadopais"
            cmbEstadoN.ValueMember = "estadopais"
        End If
    End Sub

    Private Sub BtnDocumentacion_Click(sender As Object, e As EventArgs) Handles BtnDocumentacion.Click

        Dim IMAGENJPG As String = "\\tsclient\C\FIRMAS\" & txtID.Text & "F.JPG"
        Dim SERVIDORJPG As String = "D:\FIRMAS\" & txtID.Text & "F.JPG"
        Dim fs As System.IO.FileStream
        Select Case Not System.IO.File.Exists(IMAGENJPG)
            Case True
                'IMAGENJPG = IMAGENJPG.Replace(AB, AB.ToLower)
                Select Case Not System.IO.File.Exists(IMAGENJPG)
                    Case True
                        MessageBox.Show("NO EXISTE UNA IMAGEN CON ESTE FOLIO, PORFAVOR RENOMBRE LA IMAGEN CON EL NÚMERO DEL CLIENTE" &
                           "" + Chr(13) + "A: PARA EL FRENTE" + Chr(13) + "B: PARA EL REVERSO" + Chr(13) +
                           "SI ES PASAPORTE PONERLE LA LETRA ""A"", SOLO ES UNA IMAGEN" + Chr(13) + "NO PONER ESPACIO ENTRE EL NÚMERO DEL CLIENTE Y LA LETRA")
                    Case False

                        If System.IO.File.Exists(SERVIDORJPG) Then
                            Dim NOMBREORI, NOMBRECAM, FECHAFIRMAR As String
                            NOMBREORI = ""
                            NOMBRECAM = ""
                            FECHAFIRMAR = "" & Now.Day.ToString & Now.Month.ToString & Now.Year.ToString
                            For NO As Integer = 0 To 100
                                If Not System.IO.File.Exists(SERVIDORJPG.Replace(".JPG", FECHAFIRMAR.ToString & ".JPG")) Then
                                    NOMBREORI = SERVIDORJPG
                                    NOMBRECAM = SERVIDORJPG.Replace("D:\FIRMAS\", "").Replace(".JPG", FECHAFIRMAR.ToString & ".JPG")
                                    My.Computer.FileSystem.RenameFile(SERVIDORJPG, NOMBRECAM)
                                    Exit For
                                End If
                            Next
                        End If

                        Try
                            Me.Cursor = Cursors.WaitCursor
                            Dim copiar As Process
                            copiar = Process.Start("C:\Windows\System32\cmd.exe", "/c copy " & IMAGENJPG & " D:\FIRMAS")
                            copiar.StartInfo.CreateNoWindow = False
                            copiar.WaitForExit()
                            copiar.Close()
                            copiar.Dispose()
                            ' Dim bmp As Bitmap
                            TxtFirma.Text = SERVIDORJPG

                            fs = New System.IO.FileStream(TxtFirma.Text, IO.FileMode.Open, IO.FileAccess.Read)
                            Imagen3 = System.Drawing.Image.FromStream(fs)
                            pkd7.Image = Imagen3
                            pkd7.SizeMode = PictureBoxSizeMode.StretchImage
                            fs.Close()

                            oclientescnbvC.Mifirma(Convert.ToInt32(txtID.Text), TxtFirma.Text)
                            Me.Cursor = Cursors.Default
                            'MessageBox.Show("IMAGEN SUBIDA")

                        Catch ex As Exception
                            Me.Cursor = Cursors.Default
                            MessageBox.Show("HUBO UN ERROR AL SUBIR LA IMAGEN " & IMAGENJPG & " AL SERVIDOR")
                        End Try
                End Select
            Case False
                If System.IO.File.Exists(SERVIDORJPG) Then
                    Dim NOMBREORI, NOMBRECAM, FECHAFIRMAR As String
                    NOMBREORI = ""
                    NOMBRECAM = ""
                    FECHAFIRMAR = "" & Now.Day.ToString & Now.Month.ToString & Now.Year.ToString
                    For NO As Integer = 0 To 100
                        If Not System.IO.File.Exists(SERVIDORJPG.Replace(".JPG", FECHAFIRMAR.ToString & ".JPG")) Then
                            NOMBREORI = SERVIDORJPG
                            NOMBRECAM = SERVIDORJPG.Replace("D:\FIRMAS\", "").Replace(".JPG", FECHAFIRMAR.ToString & ".JPG")
                            My.Computer.FileSystem.RenameFile(SERVIDORJPG, NOMBRECAM)
                            Exit For
                        End If
                    Next
                End If
                Try
                    Me.Cursor = Cursors.WaitCursor
                    Dim copiar As Process
                    copiar = Process.Start("C:\Windows\System32\cmd.exe", "/c copy " & IMAGENJPG & " D:\FIRMAS")
                    copiar.StartInfo.CreateNoWindow = False
                    copiar.WaitForExit()
                    copiar.Close()
                    copiar.Dispose()

                    TxtFirma.Text = SERVIDORJPG
                    fs = New System.IO.FileStream(TxtFirma.Text, IO.FileMode.Open, IO.FileAccess.Read)
                    Imagen3 = System.Drawing.Image.FromStream(fs)
                    pkd7.Image = Imagen3
                    pkd7.SizeMode = PictureBoxSizeMode.StretchImage
                    fs.Close()

                    oclientescnbvC.Mifirma(Convert.ToInt32(txtID.Text), TxtFirma.Text)
                    Me.Cursor = Cursors.Default

                Catch ex As Exception
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("HUBO UN ERROR AL SUBIR LA IMAGEN " & IMAGENJPG & " AL SERVIDOR")
                End Try
        End Select
    End Sub

    Private Sub cmbEstadoR_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEstadoR.SelectedValueChanged
        Dim value As Object = cmbEstadoR.SelectedValue

        If (TypeOf value Is DataRowView) Then Return
        If cmbEstadoR.Items.Count <= 0 Then Return
        If cmbEstadoR.Text.Trim = "YUCATAN" Then
            dt7c = olocalidadesC.ciudadesCNBV("31").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            cmbCiudadR.SelectedValue = "MERIDA"
            CargarGridColonia("YUCATAN")
        ElseIf cmbEstadoR.Text.Trim = "AGUASCALIENTES" Then
            dt7c = olocalidadesC.ciudadesCNBV("01").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("AGUASCALIENTES")
        ElseIf cmbEstadoR.Text.Trim = "BAJA CALIFORNIA" Then
            dt7c = olocalidadesC.ciudadesCNBV("02").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("BAJA CALIFORNIA")
        ElseIf cmbEstadoR.Text.Trim = "BAJA CALIFORNIA SUR" Then
            dt7c = olocalidadesC.ciudadesCNBV("03").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("BAJA CALIFORNIA SUR")
        ElseIf cmbEstadoR.Text.Trim = "CAMPECHE" Then
            dt7c = olocalidadesC.ciudadesCNBV("04").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("CAMPECHE")
        ElseIf cmbEstadoR.Text.Trim = "COAHUILA" Then
            dt7c = olocalidadesC.ciudadesCNBV("05").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("COAHUILA")
        ElseIf cmbEstadoR.Text.Trim = "COLIMA" Then
            dt7c = olocalidadesC.ciudadesCNBV("06").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("COLIMA")
        ElseIf cmbEstadoR.Text.Trim = "CHIAPAS" Then
            dt7c = olocalidadesC.ciudadesCNBV("07").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("CHIAPAS")
        ElseIf cmbEstadoR.Text.Trim = "CHIHUAHUA" Then
            dt7c = olocalidadesC.ciudadesCNBV("08").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("CHIHUAHUA")
        ElseIf cmbEstadoR.Text.Trim = "CIUDAD DE MEXICO" Then
            dt7c = olocalidadesC.ciudadesCNBV("09").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("CIUDAD DE MEXICO")
        ElseIf cmbEstadoR.Text.Trim = "DURANGO" Then
            dt7c = olocalidadesC.ciudadesCNBV("10").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("DURANGO")
        ElseIf cmbEstadoR.Text.Trim = "GUANAJUATO" Then
            dt7c = olocalidadesC.ciudadesCNBV("11").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("GUANAJUATO")
        ElseIf cmbEstadoR.Text.Trim = "GUERRERO" Then
            dt7c = olocalidadesC.ciudadesCNBV("12").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("GUERRERO")
        ElseIf cmbEstadoR.Text.Trim = "HIDALGO" Then
            dt7c = olocalidadesC.ciudadesCNBV("13").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("HIDALGO")
        ElseIf cmbEstadoR.Text.Trim = "JALISCO" Then
            dt7c = olocalidadesC.ciudadesCNBV("14").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("JALISCO")
        ElseIf cmbEstadoR.Text.Trim = "ESTADO DE MEXICO" Then
            dt7c = olocalidadesC.ciudadesCNBV("15").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("ESTADO DE MEXICO")
        ElseIf cmbEstadoR.Text.Trim = "MICHOACAN" Then
            dt7c = olocalidadesC.ciudadesCNBV("16").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("MICHOACAN")
        ElseIf cmbEstadoR.Text.Trim = "MORELOS" Then
            dt7c = olocalidadesC.ciudadesCNBV("17").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("MORELOS")
        ElseIf cmbEstadoR.Text.Trim = "NAYARIT" Then
            dt7c = olocalidadesC.ciudadesCNBV("18").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("NAYARIT")
        ElseIf cmbEstadoR.Text.Trim = "NUEVO LEON" Then
            dt7c = olocalidadesC.ciudadesCNBV("19").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("NUEVO LEON")
        ElseIf cmbEstadoR.Text.Trim = "OAXACA" Then
            dt7c = olocalidadesC.ciudadesCNBV("20").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("OAXACA")
        ElseIf cmbEstadoR.Text.Trim = "PUEBLA" Then
            dt7c = olocalidadesC.ciudadesCNBV("21").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("PUEBLA")
        ElseIf cmbEstadoR.Text.Trim = "QUERETARO" Then
            dt7c = olocalidadesC.ciudadesCNBV("22").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("QUERETARO")
        ElseIf cmbEstadoR.Text.Trim = "QUINTANA ROO" Then
            dt7c = olocalidadesC.ciudadesCNBV("23").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("QUINTANA ROO")
        ElseIf cmbEstadoR.Text.Trim = "SAN LUIS POTOSI" Then
            dt7c = olocalidadesC.ciudadesCNBV("24").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("SAN LUIS POTOSI")
        ElseIf cmbEstadoR.Text.Trim = "SINALOA" Then
            dt7c = olocalidadesC.ciudadesCNBV("25").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("SINALOA")
        ElseIf cmbEstadoR.Text.Trim = "SONORA" Then
            dt7c = olocalidadesC.ciudadesCNBV("26").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("SONORA")
        ElseIf cmbEstadoR.Text.Trim = "TABASCO" Then
            dt7c = olocalidadesC.ciudadesCNBV("27").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("TABASCO")
        ElseIf cmbEstadoR.Text.Trim = "TAMAULIPAS" Then
            dt7c = olocalidadesC.ciudadesCNBV("28").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("TAMAULIPAS")
        ElseIf cmbEstadoR.Text.Trim = "TLAXCALA" Then
            dt7c = olocalidadesC.ciudadesCNBV("29").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("TLAXCALA")
        ElseIf cmbEstadoR.Text.Trim = "VERACRUZ" Then
            dt7c = olocalidadesC.ciudadesCNBV("30").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("VERACRUZ")
        ElseIf cmbEstadoR.Text.Trim = "ZACATECAS" Then
            dt7c = olocalidadesC.ciudadesCNBV("32").Tables(0)
            cmbCiudadR.DataSource = dt7c
            cmbCiudadR.DisplayMember = "ciudad"
            cmbCiudadR.ValueMember = "ciudad"
            CargarGridColonia("ZACATECAS")
        Else
            cmbCiudadR.DataSource = Nothing
            cmbColonia.DataSource = Nothing
        End If
    End Sub

    Private Sub CargarGridColonia(ByVal estado As String)
        Dim dtbTabla As New System.Data.DataTable
        dtbTabla.Columns.Add("Colonia")
        dtbTabla.Columns.Add("CodigoPostal")
        Dim dtrFila As DataRow
        dt8c = olocalidadesC.coloniaCNBV(estado).Tables(0)
        Dim split2 As String()
        For Each row As DataRow In dt8c.Rows
            split2 = row("Colonia").ToString().Split(";")
            For i As Integer = 0 To split2.Length - 1
                dtrFila = dtbTabla.NewRow()
                dtrFila("Colonia") = split2(i)
                dtrFila("CodigoPostal") = row("CodigoPostal").ToString()
                dtbTabla.Rows.Add(dtrFila)
            Next
            split2 = Nothing
        Next
        cmbColonia.DataSource = dtbTabla
        cmbColonia.DisplayMember = "Colonia"
        cmbColonia.ValueMember = "CodigoPostal"
    End Sub

    Private Sub txtColonia_Leave(sender As Object, e As EventArgs) Handles txtColonia.Leave
        txtColonia.SendToBack()
        cmbColonia.Focus()
    End Sub

    Private Sub cmdGenTarjeta_Click(sender As Object, e As EventArgs) Handles cmdGenTarjeta.Click
        Dim frm As New frmGenerarTarjeta
        If txtNocli.Text <> "" Then
            frm.txtCliente.Text = txtNocli.Text
            frm.lbNombre.Text = txtNombre.Text
            frm.lbApellidos.Text = txtAP.Text & " " & txtAM.Text
            frm.txtCelular.Text = "52" & txtTelcelu.Text
            frm.txtEmail.Text = txtCorreoE.Text
            frm.lbTarjeta.Text = txtNoTarjeta.Text
            frm.ShowDialog()
            txtNoTarjeta.Text = frm.lbTarjeta.Text
        End If
    End Sub

    Private Sub cmdGenProv_Click(sender As Object, e As EventArgs) Handles cmdGenProv.Click
        Dim frm As New frmGenTarjetaC
        frm.txtCliente.Text = txtNocli.Text
        frm.lbNombre.Text = txtNombre.Text
        frm.lbApellidos.Text = txtAP.Text & " " & txtAM.Text
        frm.txtCelular.Text = "52" & txtTelcelu.Text
        frm.txtEmail.Text = txtCorreoE.Text
        frm.ShowDialog()
    End Sub

    Private Sub cmdGenUsPed_Click(sender As Object, e As EventArgs) Handles cmdGenUsPed.Click
        Dim frm As New frmGenerarPass
        frm.txtCliente.Text = txtNocli.Text
        frm.lbNombre.Text = txtNombre.Text & " " & txtAP.Text & " " & txtAM.Text
        frm.txtEmail.Text = txtCorreoE.Text
        frm.txtTarjeta.Text = txtNoTarjeta.Text
        frm.ShowDialog()
    End Sub

    Private Sub txtTelcelu_MouseClick(sender As Object, e As MouseEventArgs) Handles txtTelcelu.MouseClick
        If txtTelcelu.Text.Trim <> "" Then
            Dim frm As New frmAutCambioCel
            PagAut = True
            frm.ShowDialog()
            If frm.Encontrado Then
                txtTelcelu.PasswordChar = ""
                txtTelcelu.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub txtColonia_TextChanged(sender As Object, e As EventArgs) Handles txtColonia.TextChanged
        'txtColonia.SendToBack()
        txtColonia.BackColor = Color.White
        If txtColonia.Text = "" And txtColonia.Text.Length = 0 Then
            cmbColonia.Focus()
        End If
    End Sub

    Private Sub txtTelcelu_Leave(sender As Object, e As EventArgs) Handles txtTelcelu.Leave
        If agre_bus = "busca" Then
            If txtTelcelu.Text <> CambioCel Then
                oPuntos.ActivarDesacTarj(txtNocli.Text, 0)
                CambioCel = txtTelcelu.Text
            End If
        End If
    End Sub

    Private Sub txtNoInt_TextChanged(sender As Object, e As EventArgs) Handles txtNoInt.TextChanged
        txtNoInt.BackColor = Color.White
    End Sub

    Private Sub cmbActividad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbActividad.SelectedIndexChanged
        cmbActividad.BackColor = Color.White
    End Sub

    Private Sub txtNoExt_TextChanged(sender As Object, e As EventArgs) Handles txtNoExt.TextChanged
        txtNoExt.BackColor = Color.White
    End Sub

    Private Sub txtEntreCalles_TextChanged(sender As Object, e As EventArgs) Handles txtEntreCalles.TextChanged
        txtEntreCalles.BackColor = Color.White
    End Sub

    Private Sub TxtFirma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFirma.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtNacionalizado_TextChanged(sender As Object, e As EventArgs) Handles txtNacionalizado.TextChanged
        txtNacionalizado.BackColor = Color.White
    End Sub

    Private Sub cmbPaisN_TextChanged(sender As Object, e As EventArgs) Handles cmbPaisN.TextChanged
        'cmbPaisN.BackColor = Color.White
    End Sub

    Private Sub cmbPaisR_TextChanged(sender As Object, e As EventArgs) Handles cmbPaisR.TextChanged
        cmbPaisR.BackColor = Color.White
    End Sub

    Private Sub cmbEstadoR_TextChanged(sender As Object, e As EventArgs) Handles cmbEstadoR.TextChanged
        cmbEstadoR.BackColor = Color.White
    End Sub

    Private Function Buscar_Celular() As Boolean

        Dim conec As New ConexionSQLS
        Dim comm As New SqlCommand
        Dim rs As SqlDataReader
        Dim SQL As String
        Dim CantCelular As Integer = 0

        conec.EstablecerConexion()
        conec.AbrirConexion()

        SQL = ""
        SQL = SQL & "Select COUNT(*) as Total "
        SQL = SQL & "From clientescnbv "
        SQL = SQL & "Where Telcelular = '" & txtTelcelu.Text & "' AND "
        SQL = SQL & "cliente <> '" & txtNocli.Text & "'"
        comm = New SqlCommand(SQL, conec.con)
        rs = comm.ExecuteReader

        While rs.Read
            CantCelular = rs(0)
        End While
        rs.Close()
        conec.CerrarConexion()

        If CantCelular > 0 Then
            MsgBox("Este Numero de Celular ya fue asignado a otro Cliente", vbInformation)
            If CantCelular > 1 Then
                txtTelcelu.Text = ""
            End If
            txtTelcelu.Focus()
            Return True
        End If
        Return False

    End Function

End Class