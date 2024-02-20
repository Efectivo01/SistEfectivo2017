Imports VIBlend.Utilities
'Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared.SharedUtils
'Imports CrystalDecisions.Shared
Imports System.ComponentModel
Imports System.Drawing.Printing
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Drawing
Imports MySql.Data.MySqlClient

Public Class FrmCaja
    Dim entrarM As Boolean
    Public UsuarioR As String
    Public NoSucursal, NomSucursal As String
    Public NoCajero As Integer
    Public UsuarioL As String
    Dim Importe_Incentivo, Incentivo As Single
    Dim oclsResizeForm As New clsResizeForm
    Dim idcli As Integer = 0
    Dim otipodivisasM As tipodivisasM
    Dim otipodivisasC As New tipodivisasC
    Dim odivisasM As divisasM
    Dim odivisasC As divisasC
    Dim oremisioMM, oremisioMM2 As remisioMM
    Dim oremisioMC As remisioMC
    Dim oremisioDM As remisioDM
    Dim oremisioDCA As remisioDCA
    Dim oremisioDC As remisioDC
    Dim oauxiliares As auxiliares
    Dim oclientescnbvM As clientescnbvM
    Dim oclientescnbvC As clientescnbvC

    Dim Reporte As New ReportDocument ' para reportes
    Dim ocaja_diario2C As caja_diario2C ' para reportes
    Dim otinventario2C As tinventario2C ' para reportes
    Dim ocaja_diarioM As caja_diarioM ' para reportes
    Dim omovimientosC As movimientosC ' para reportes
    'Dim ocontrolC As controlC
    Dim oCAJAM As CAJAM
    Dim oCAJAC As CAJAC
    Dim oPermitirOtrosC As New PermitirOtrosC

    Dim oReportesUnicosC As ReportesUnicosC
    'dt1 son los tipos ej:USA y dt2 son las divisas ej:5,10,20
    'dt3 es para checar precios dt2 que tiene todas las divisas, dt4r para recuperar los datos, dt2filtro para existencias,dt5 para cargar existencias de tinventario
    Dim dt1, dt2, dt3filtro2, dt2filtro, dt5Existencias, dtExistenciaDiv, dt1Promo, dtTiposDiv, dtTiposDiv2 As DataTable
    Dim dt3 As New DataTable
    Dim dtcalc As New DataTable
    Public compraoventa As String = ""
    Dim buscaRemision As Boolean = False
    Dim NoFolio As Integer = 0, BscFolio As Integer = 0, BscCliente As Integer = 0
    Dim tipdivi, billete As Integer
    Dim CoV, nombre_aux, apellido1_aux, nombre_completo As String
    Dim source1 As BindingSource
    Dim repetido As Boolean = False
    Dim precioCoV, precioC As Double
    Dim sumadivex, partemayor, partemenor, cantbilletes As Double
    Dim ruta_billeteimg As String = "billetes_gif\Denominaciones\" ' "..\..\images\Denominaciones\"
    Dim extencion_billeteimg As String = ".gif"
    Dim ruta_pdf As String = "..\..\PDFs_diarios\" 'se puede quitar
    Dim extencion_pdf As String = ".pdf" 'se puede quitar
    Dim valida_exist_divi As Integer = 0
    Dim operacion_especial As Boolean = False
    Dim No_sucursal, Nombre_sucursal, Cajero, Impresora1, Impresora2 As String
    Dim ImpresoraCarta As String = "HP" 'sepuede quitar
    Dim No_cajero As Integer
    Dim fechanowrep As DateTime 'se puede quitar
    Dim fechahoyrep As String  'se puede quitar
    Dim tiempo_actual As DateTime 'se puede quitar
    Dim transferenciasCOUNT As Integer = 0
    Dim cambiaprecio As Boolean = False
    Dim TarjetaVir, TarjetaCompra As String
    Dim AcumuladoInsentivo As Decimal
    Dim Conta As Integer
    Dim PrimeroGrupo As Boolean
    Dim PrimerCliente, PrimerFolio As Integer
    Dim EncontroMun As Integer

    'Dim ya_puesto As Boolean = False

    Dim oPersonasBloqueadasFisicasM As New PersonasBloqueadasFisicasM
    Dim oPersonasBloqueadasFisicasC As New PersonasBloqueadasFisicasC
    Dim dt_BloqFisicas As New DataTable
    Dim source_BloqFisicas As New BindingSource()
    Dim source_BloqListaInterna As New BindingSource()

    'UTIMOS AGREGADOS octubre2016
    Dim oExistenciaM As New ExistenciaM
    Dim oExistenciaC As New ExistenciaC

    Dim oPersonasPoliticasEM As New PersonasPoliticasEM
    Dim oPersonasPoliticasEC As New PersonasPoliticasEC
    Dim dt_PPoliticas As New DataTable
    Dim source_PPoliticas As New BindingSource()
    Public IdentificacionCorrecta As Boolean

    Dim cambio As Boolean = False
    Dim cantidadTot As Integer
    Dim conn As New ConexionSQLS
    Private lector As SqlDataReader
    Private cmd, cmd2 As New SqlCommand
    Dim Trans As SqlTransaction


    'Limites
    Dim ousuarios As UsuariosC
    'para la funcion de Tarjeta
    Dim oPuntosD As CPuntosDet
    Dim oPuntos As CPuntos
    Dim ConTarjeta As Boolean = False
    Dim ConTarjetaP As Boolean = False
    Dim Moral As Boolean = False
    Dim DivisaFracc As Integer
    Dim ContadorBotonAum, ContadorBotomRes As Integer

    Dim CB As String
    Dim FechaQR As Date
    Dim Cadenas As String
    Dim idQR As Integer
    Dim FolioQR As Integer
    Dim ImporteQR As Decimal
    Dim TerminoBien As Boolean
    Dim dtQR As New DataTable

    Dim Cadena As String
    Dim cnn As New MySqlConnection
    Dim comm As MySqlCommand
    Dim rsLector As MySqlDataReader
    Dim AplicarCupon As Boolean
    Dim LimiteGral As Double
    Dim TotalInventario As Double
    Dim MontoMaxCompra As Double
    Dim AcumMaxCompra As Double
    Dim FolioNC As Integer
    Dim Comando As SqlCommand
    Dim opuntosNC_Det As New puntosNC_Det

    Dim ArchivoSer As System.IO.StreamReader
    Dim conser As String = ""
    Dim dtbTabla As New DataTable

    Dim dt_ListaInterna As New DataTable
    Dim NumeroCelular As String

    Private Sub PrepararVariables()
        otipodivisasM = New tipodivisasM
        ' otipodivisasC = New tipodivisasC
        odivisasM = New divisasM
        odivisasC = New divisasC
        oremisioMM = New remisioMM
        oremisioMM2 = New remisioMM
        oremisioMC = New remisioMC
        oremisioDM = New remisioDM
        oremisioDC = New remisioDC
        oauxiliares = New auxiliares
        dt1 = New DataTable
        dt2 = New DataTable
        dt3 = New DataTable
        dt3filtro2 = New DataTable
        dt2filtro = New DataTable
        oCAJAM = New CAJAM
        oCAJAC = New CAJAC
        oclientescnbvM = New clientescnbvM
        oclientescnbvC = New clientescnbvC

        ocaja_diario2C = New caja_diario2C
        otinventario2C = New tinventario2C
        ocaja_diarioM = New caja_diarioM
        omovimientosC = New movimientosC

        nombre_aux = ""
        apellido1_aux = ""
        nombre_completo = ""
        CoV = ""
        source1 = New BindingSource()
        InicializarVariables1()
        No_sucursal = ""
        Impresora1 = ""
        No_cajero = 0
        Cajero = ""

        oReportesUnicosC = New ReportesUnicosC
        fechanowrep = DateTime.Now.ToShortDateString()
        fechahoyrep = fechanowrep.ToString("MM/dd/yyyy").Replace("/", "_")

        'Limites
        ousuarios = New UsuariosC

        oPuntos = New CPuntos
        oPuntosD = New CPuntosDet
    End Sub

    Private Sub InicializarVariables1()
        sumadivex = 0
        partemayor = 0
        partemenor = 0
        cantbilletes = 0
        BscFolio = 0
        BscCliente = 0
        valida_exist_divi = 0
    End Sub

    Private Sub InicializarVariables2()
        nombre_aux = ""
        apellido1_aux = ""
        nombre_completo = ""
        BscFolio = 0
        BscCliente = 0
    End Sub

    Private Sub LimpiarVariables()
        otipodivisasM = Nothing
        otipodivisasC.Dispose()
        odivisasM = Nothing
        odivisasC.Dispose()
        dt1.Dispose()
        dt2.Dispose()
        dt3.Dispose()

        oremisioMM = Nothing
        oremisioMM2 = Nothing
        oremisioMC = Nothing
        dt2filtro.Dispose()
        oauxiliares.Dispose()
        oclientescnbvM = Nothing
        oclientescnbvC.Dispose()
        source1.Dispose()

        ocaja_diario2C.Dispose()
        otinventario2C.Dispose()
        ocaja_diarioM = Nothing
        omovimientosC.Dispose()
        InicializarVariables1()
        oReportesUnicosC.Dispose()
        If source1 IsNot Nothing Then
            source1.Dispose()
        End If
        If source_BloqFisicas IsNot Nothing Then
            source_BloqFisicas.Dispose()
        End If
        If source_BloqListaInterna IsNot Nothing Then
            source_BloqListaInterna.Dispose()
        End If
        If dt1 IsNot Nothing Then
            dt1.Dispose()
        End If
        If dt2 IsNot Nothing Then
            dt2.Dispose()
        End If
        If dt3 IsNot Nothing Then
            dt3.Dispose()
        End If
        If dt3filtro2 IsNot Nothing Then
            dt3filtro2.Dispose()
        End If
        If dt2filtro IsNot Nothing Then
            dt2filtro.Dispose()
        End If
        If dt5Existencias IsNot Nothing Then
            dt5Existencias.Dispose()
        End If

        If oPersonasBloqueadasFisicasM IsNot Nothing Then
            oPersonasBloqueadasFisicasM = Nothing
        End If
        If oPersonasBloqueadasFisicasC IsNot Nothing Then
            oPersonasBloqueadasFisicasC.Dispose()
        End If
        If dt_BloqFisicas IsNot Nothing Then
            dt_BloqFisicas.Dispose()
        End If
        If source_BloqFisicas IsNot Nothing Then
            source_BloqFisicas.Dispose()
        End If

        If dt_ListaInterna IsNot Nothing Then
            dt_ListaInterna.Dispose()
        End If

        If oExistenciaC IsNot Nothing Then
            oExistenciaC.Dispose()
        End If
        oExistenciaM = Nothing

        If dt_PPoliticas IsNot Nothing Then
            dt_PPoliticas.Dispose()
        End If

        If oPersonasPoliticasEM IsNot Nothing Then
            oPersonasPoliticasEM = Nothing
        End If
        If oPersonasPoliticasEC IsNot Nothing Then
            oPersonasPoliticasEC.Dispose()
        End If

        ousuarios.Dispose()
    End Sub

    Private Sub FrmCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim form As New FrmLoguin
        form.ShowDialog(Me)
        entrarM = form.entrar
        UsuarioR = form.usuario
        NoSucursal = form.NOsucursal
        NomSucursal = form.NomSuc
        NoCajero = form.NoCaj
        UsuarioL = form.UsuLog
        ContadorBotonAum = 0
        ContadorBotomRes = 0

        dtbTabla.Columns.Add("Divisa")
        dtbTabla.Columns.Add("Existencia")

        form.Dispose()
        If entrarM = False Then
            Me.Close()
        Else
            Me.WindowState = FormWindowState.Maximized

            PrepararVariables()

            billete = -1

            dgvNoOrden(dgvCoV)

            Me.Text = NomSucursal ' form.lblSucursal.Text.Trim
            txtSugerido.Text = UsuarioR ' form.lblUsuario.Text
            No_sucursal = NoSucursal ' form.NOsucursal
            Nombre_sucursal = NomSucursal 'form.lblSucursal.Text.Trim
            No_cajero = CInt(NoCajero)
            Cajero = UsuarioR ' form.lblUsuario.Text

            dt1 = otipodivisasC.Stipodivisas2(No_sucursal).Tables(0)
            Dim x As Integer = dt1.Rows.Count
            otipodivisasC.LiberarDS()
            otipodivisasM = Nothing
            dt2 = odivisasC.Sdivisas2().Tables(0)
            odivisasC.LiberarDS()
            preciosCV()

            If dgvCoV.ColumnCount > 0 Then
                dgvCoV.Columns("codigo").Width = 70
                dgvCoV.Columns("Nombre").Width = 220
                dgvCoV.Columns("Cantidad").Width = 90
                dgvCoV.Columns("Importe").Width = 90
                dgvCoV.EnableHeadersVisualStyles = False
                dgvCoV.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
                dgvCoV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            End If

            If oremisioMC Is Nothing Then
                oremisioMC = New remisioMC
            End If
            NoFolio = oremisioMC.UFolioRemision(No_sucursal)
            txtFolio.Text = NoFolio.ToString
            Existencias1()
            txtid.Focus()
            txtid.Select()
            txtid.Focus()
            txtExistencias.BringToFront()
            txtExistenciasS.BringToFront()

            transferenciasCOUNT = oremisioMC.countransfer(No_sucursal, Date.Now.ToShortDateString)
            If oPermitirOtrosC Is Nothing Then
                oPermitirOtrosC = New PermitirOtrosC
            End If
            oPermitirOtrosC.Cambio0(No_sucursal)
            oPermitirOtrosC.Dispose()
            ImpresoraName()
            PrintDocument1.PrinterSettings.PrinterName = Impresora1
            AplicarCupon = False
            AcumuladoInsentivo = 0
            dtTiposDiv = odivisasC.TiposDivisas.Tables(0)
            dtTiposDiv2 = odivisasC.TiposDivisas.Tables(0)
            odivisasC.LiberarDS()

            cbDe.DataSource = dtTiposDiv
            cbDe.DisplayMember = "Nombre"
            cbDe.ValueMember = "tipo"

            cbA.DataSource = dtTiposDiv2
            cbA.DisplayMember = "Nombre"
            cbA.ValueMember = "tipo"

            Me.Text = "Sistema Efectivo " & Application.ProductVersion
            txtApellidos.Focus()
        End If

    End Sub

    Private Sub vbtndSalir_Click(sender As Object, e As EventArgs) Handles vbtndSalir.Click
        LimpiarVariables()
        Me.Close()
    End Sub

    Private Sub vbtna3_Click(sender As Object, e As EventArgs) Handles vbtna3.Click
        Dim dialog As DialogResult
        Dim form As New FrmClientes 'CapclientescnbvCoV
        form.txtID.Enabled = False
        form.lblModulo.Text += " en Compra/Venta"
        form.cove = True
        form.agre_bus = "agrega"
        form.num_usux = No_cajero
        form.nom_usux = Cajero
        form.no_sucursal = No_sucursal
        form.nom_sucursal = Me.Text
        dialog = form.ShowDialog()
        form.BringToFront()
        txtNombres.Text = form.txtNombre.Text.Trim
        txtApellidos.Text = form.txtAP.Text.Trim
        TxtTarjeta.Text = form.txtNoTarjeta.Text.Trim

        nombre_aux = ""
        apellido1_aux = ""
        nombre_completo = form.txtNombre.Text.Trim & " " & form.txtAP.Text.Trim & " " & form.txtAM.Text.Trim

        txtid.Text = form.txtNocli.Text.Trim
        If form.txtNocli.Text <> "" Then
            idcli = CInt(form.txtNocli.Text.Trim)
        Else
            idcli = 0
        End If
        infocliente()
        Moral = False
    End Sub

    Private Sub infocliente()
        BscCliente = idcli
        txtid.Text = idcli
        txtNumCliente.Text = idcli
        Try
            If idcli <> "0" Then
                Dim dtinfocliente As New DataTable
                dtinfocliente = oremisioMC.UInformclientecnbv(CInt(idcli)).Tables(0)
                If dtinfocliente.Rows.Count > 0 Then
                    txtuf.Text = Microsoft.VisualBasic.Left(dtinfocliente.Rows(0)("fecha").ToString, 10)
                    txtop.Text = dtinfocliente.Rows(0)("observaciones").ToString
                    txtmnt.Text = FormatNumber(dtinfocliente.Rows(0)("total").ToString, 2)
                    BscFolio = dtinfocliente.Rows(0)("folio_factura").ToString
                    TxtUltFolio.Text = dtinfocliente.Rows(0)("folio_factura").ToString
                    LblSucF.Text = dtinfocliente.Rows(0)("Nosucursal").ToString
                End If
                If txtuf.Text = "" Then
                    LimpiarInofoCliente2()
                End If
                dtinfocliente = Nothing
                infocliente2()
            End If
        Catch ex As Exception
            LimpiarInofoCliente2()
            nombre_aux = ""
            apellido1_aux = ""
            nombre_completo = ""
        End Try
    End Sub

    Private Sub infoempresa()
        BscCliente = idcli
        txtid.Text = idcli
        Try
            Dim dtinfocliente As New DataTable
            dtinfocliente = oremisioMC.UInformclientecnbv(CInt(idcli)).Tables(0)
            txtuf.Text = Microsoft.VisualBasic.Left(dtinfocliente.Rows(0)("fecha").ToString, 10)
            txtop.Text = dtinfocliente.Rows(0)("observaciones").ToString
            txtmnt.Text = FormatNumber(dtinfocliente.Rows(0)("total").ToString, 2)
            BscFolio = dtinfocliente.Rows(0)("folio_factura").ToString
            If txtuf.Text = "" Then
                LimpiarInofoCliente2()
            End If
            dtinfocliente = Nothing
        Catch ex As Exception
            'LimpiarInofoCliente2()
            'nombre_aux = ""
            'apellido1_aux = ""
            'nombre_completo = ""
        End Try
        Moral = True
        pnlOperaciones.Enabled = True
        PictureBox1.Enabled = True

    End Sub

    Private Sub infocliente2()
        Dim dtinfocliente As New DataTable
        Dim FechaCredencial As Date
        Dim FechaActual As Date
        Dim FechaVenComp As Date
        Dim FechaVenCue1 As Date
        Dim FechaVenCue2 As Date
        Dim FechaVenFor4 As Date
        Dim FechaVenFor5 As Date
        Dim curp As String = ""
        Dim rfc As String = ""
        Dim email As String = ""
        Dim firma As String = ""
        Dim telfijo As String = ""
        Dim telcel As String = ""
        Dim docCURP As String = ""
        Dim docRFC As String = ""
        Dim nancionalizado As Integer = 0
        Dim paisResidencia As Integer = 0
        Dim paisNace As Integer = 0
        Dim estadoResidencia As Integer = 0
        Dim actividad As Integer = 0
        Dim calle As String = ""
        Try
            dtinfocliente = oclientescnbvC.Selecciona4(idcli).Tables(0)
            txtNombres.Text = dtinfocliente.Rows(0)("Nombre").ToString
            txtApellidos.Text = dtinfocliente.Rows(0)("ApellidoPaterno").ToString
            TxtTarjeta.Text = dtinfocliente.Rows(0)("Tarjeta").ToString
            LblRiesgo.Text = dtinfocliente.Rows(0)("riesgo").ToString
            If validarcliente(dtinfocliente.Rows(0)("Nombre").ToString, dtinfocliente.Rows(0)("ApellidoPaterno").ToString, dtinfocliente.Rows(0)("ApellidoMaterno").ToString) = False Then Exit Sub
            If idcli = 0 Then
                TxtTarjeta.Enabled = True
            Else
                TxtTarjeta.Enabled = False
            End If
            apellido1_aux = dtinfocliente.Rows(0)("ApellidoPaterno").ToString
            nombre_aux = dtinfocliente.Rows(0)("Nombre").ToString
            nombre_completo = dtinfocliente.Rows(0)("Nombre").ToString & " " & dtinfocliente.Rows(0)("ApellidoPaterno").ToString _
                & " " & dtinfocliente.Rows(0)("ApellidoMaterno").ToString
            calle = dtinfocliente.Rows(0)("Calle").ToString
            If dtinfocliente.Rows(0)("vencimiento_id").ToString <> "" Then FechaCredencial = dtinfocliente.Rows(0)("vencimiento_id")

            If dtinfocliente.Rows(0)("vigencia_compro").ToString <> "" Then FechaVenComp = dtinfocliente.Rows(0)("vigencia_compro")
            If dtinfocliente.Rows(0)("vigencia_cuest1").ToString <> "" Then FechaVenCue1 = dtinfocliente.Rows(0)("vigencia_cuest1")
            If dtinfocliente.Rows(0)("vigencia_cuest2").ToString <> "" Then FechaVenCue2 = dtinfocliente.Rows(0)("vigencia_cuest2")
            If dtinfocliente.Rows(0)("vigencia_format4").ToString <> "" Then FechaVenFor4 = dtinfocliente.Rows(0)("vigencia_format4")
            If dtinfocliente.Rows(0)("vigencia_format5").ToString <> "" Then FechaVenFor5 = dtinfocliente.Rows(0)("vigencia_format5")

            If dtinfocliente.Rows(0)("CURP").ToString <> "" Then curp = dtinfocliente.Rows(0)("CURP")
            If dtinfocliente.Rows(0)("Rfc").ToString <> "" Then rfc = dtinfocliente.Rows(0)("Rfc")
            If dtinfocliente.Rows(0)("email").ToString <> "" Then email = dtinfocliente.Rows(0)("email")
            If dtinfocliente.Rows(0)("firma").ToString <> "" Then firma = dtinfocliente.Rows(0)("firma")
            If dtinfocliente.Rows(0)("Telfijo").ToString <> "" Then telfijo = dtinfocliente.Rows(0)("Telfijo")
            If dtinfocliente.Rows(0)("Telcelular").ToString <> "" Then telcel = dtinfocliente.Rows(0)("Telcelular")
            If dtinfocliente.Rows(0)("documentoCURP").ToString <> "" Then docCURP = dtinfocliente.Rows(0)("documentoCURP")
            If dtinfocliente.Rows(0)("documentoRFC").ToString <> "" Then docRFC = dtinfocliente.Rows(0)("documentoRFC")
            If dtinfocliente.Rows(0)("nacionalizado").ToString <> "" Then nancionalizado = oclientescnbvC.chequeopais(dtinfocliente.Rows(0)("nacionalizado").ToString)
            If dtinfocliente.Rows(0)("PaisResidencia").ToString <> "" Then paisResidencia = oclientescnbvC.chequeopais(dtinfocliente.Rows(0)("PaisResidencia").ToString)
            If dtinfocliente.Rows(0)("PaisNace").ToString <> "" Then paisNace = oclientescnbvC.chequeopais(dtinfocliente.Rows(0)("PaisNace").ToString)
            If dtinfocliente.Rows(0)("EstadoResidencia").ToString <> "" Then estadoResidencia = oclientescnbvC.chequeoEstado(dtinfocliente.Rows(0)("EstadoResidencia").ToString)
            If dtinfocliente.Rows(0)("actividadcomercial").ToString <> "" Then actividad = oclientescnbvC.chequeoActividad(dtinfocliente.Rows(0)("actividadcomercial").ToString)

            If dtinfocliente.Rows(0)("Fecha_Envio_P").ToString = "" Then
                txtid.Text = ""
                txtid.Enabled = False
                'Else
                '    txtid.Enabled = False
            End If

            pnlOperaciones.Enabled = True
            PictureBox1.Enabled = True
            FechaActual = DateTime.Now.Day & "/" & DateTime.Now.Month & "/" & DateTime.Now.Year
            If dtinfocliente.Rows(0)("cliente").ToString <> "1229" Then
                If Not System.IO.File.Exists(dtinfocliente.Rows(0)("identifica1").ToString) And dtinfocliente.Rows(0)("identifica2").ToString = "" Then
                    MessageBox.Show("EL CLIENTE NO TIENE UNA IDENTIFICACIÓN ASIGNADA" + Chr(13) + "NO PUEDE CONTINUAR CON LA OPERACIÓN HASTA QUE SE LE ASIGNE UN DOCUMENTO OFICIAL" + Chr(13) &
                                    "PORFAVOR PIDALE AL CLIENTE UNA IDENTIFICACIÓN PARA ESCANEAR")
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                    'pnlCalculadora.Enabled = False
                ElseIf dtinfocliente.Rows(0)("vencimiento_id").ToString = "" Then
                    MsgBox("No tiene la Fecha de Vencimiento de la Indentificación, Por Favor de Agregarlo ", MsgBoxStyle.Information)
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                    'pnlCalculadora.Enabled = False
                ElseIf FechaCredencial < FechaActual Then
                    MsgBox("La Fecha de Vencimiento de la Indentificación ya esta VENCIDA ", MsgBoxStyle.Information)
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                    'pnlCalculadora.Enabled = False
                ElseIf dtinfocliente.Rows(0)("riesgo").ToString = "ALTO" And dtinfocliente.Rows(0)("CURP").ToString = "" Then
                    MsgBox("El cliente es de ALTO riesgo y no tiene su CURP ", MsgBoxStyle.Information)
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                ElseIf dtinfocliente.Rows(0)("riesgo").ToString = "ALTO" And dtinfocliente.Rows(0)("Rfc").ToString = "" Then
                    MsgBox("El cliente es de ALTO riesgo y no tiene su RFC ", MsgBoxStyle.Information)
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                ElseIf dtinfocliente.Rows(0)("riesgo").ToString = "ALTO" And dtinfocliente.Rows(0)("email").ToString = "" Then
                    MsgBox("El cliente es de ALTO riesgo y no tiene su Correo Electronico ", MsgBoxStyle.Information)
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                ElseIf dtinfocliente.Rows(0)("riesgo").ToString = "ALTO" And dtinfocliente.Rows(0)("firma").ToString = "" Then
                    MsgBox("El cliente es de ALTO riesgo y no tiene su Firma", MsgBoxStyle.Information)
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                ElseIf dtinfocliente.Rows(0)("riesgo").ToString = "ALTO" And dtinfocliente.Rows(0)("Telfijo").ToString = "" And dtinfocliente.Rows(0)("Telcelular").ToString = "" Then
                    MsgBox("El cliente es de ALTO riesgo y no tiene su número telefonico ", MsgBoxStyle.Information)
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                ElseIf dtinfocliente.Rows(0)("riesgo").ToString = "ALTO" And dtinfocliente.Rows(0)("documentoCURP").ToString = "" And dtinfocliente.Rows(0)("documentoRFC").ToString = "" Then
                    MsgBox("El cliente es de ALTO riesgo y no tiene sus documentos hablar con Administración", MsgBoxStyle.Information)
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                ElseIf nancionalizado <= 0 Then
                    MsgBox("El Dato de la Nacionalidad es incorrecta", MsgBoxStyle.Information)
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                ElseIf paisResidencia <= 0 Then
                    MsgBox("El dato del Pais de residencia es incorrecto", MsgBoxStyle.Information)
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                ElseIf paisNace <= 0 Then
                    MsgBox("El dato del Pais es incorrecto", MsgBoxStyle.Information)
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                ElseIf estadoResidencia <= 0 Then
                    MsgBox("El dato del Estado de residencia es incorrecto", MsgBoxStyle.Information)
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                ElseIf actividad <= 0 Then
                    MsgBox("El dato de la Actividad es incorrecto", MsgBoxStyle.Information)
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                ElseIf Trim(calle) = "0" Or Trim(calle) = "" Then
                    MsgBox("El cliente no tiene Dirección", MsgBoxStyle.Information)
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                Else
                    IdentificacionCorrecta = False
                    Dim form As New FrmIdentificacionCaja

                    form.IdenLadoA = dtinfocliente.Rows(0)("identifica1").ToString
                    form.IdenLadoB = dtinfocliente.Rows(0)("identifica2").ToString
                    form.ShowDialog()
                    IdentificacionCorrecta = form.Respuesta

                    If IdentificacionCorrecta = False Then
                        MsgBox("Favor de Agregar la Identificación Oficial Correcta ", MsgBoxStyle.Information)
                        pnlOperaciones.Enabled = False
                        PictureBox1.Enabled = False
                    Else
                        pnlOperaciones.Enabled = True
                        PictureBox1.Enabled = True
                    End If
                End If
            Else
                pnlOperaciones.Enabled = True
                PictureBox1.Enabled = True
            End If

        Catch ex As Exception
            txtApellidos.Text = ""
            txtNombres.Text = ""
            TxtTarjeta.Text = ""
            nombre_aux = ""
            apellido1_aux = ""
            nombre_completo = ""
            MsgBox(ex.Message, vbCritical)
        End Try
        dtinfocliente = Nothing
    End Sub

    Private Sub dgvNoOrden(ByVal dgv As DataGridView)
        Dim x As DataGridViewColumn
        For Each x In dgv.Columns
            x.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        x = Nothing
        dgv = Nothing
    End Sub

    Private Sub LlenarDenominaciones()
        dt2 = Nothing
        dt2 = odivisasC.Sdivisas(odivisasM).Tables(0)
        odivisasC.LiberarDS()
    End Sub

    Private Sub filtrardt2(ByVal tipo As Integer) 'que dt3 es filtro de dt2
        dt3filtro2.Rows.Clear()
        dt3filtro2 = dt2.Select("tipo = " & tipo, "tipo,valor").CopyToDataTable
        btnb1.Text = dt3filtro2.Rows(0)("codigo").ToString
        btnb2.Text = dt3filtro2.Rows(1)("codigo").ToString
        btnb3.Text = dt3filtro2.Rows(2)("codigo").ToString
        btnb4.Text = dt3filtro2.Rows(3)("codigo").ToString

        Select Case dt3filtro2.Rows.Count - 1
            Case 3
                btnb5.Text = ""
                btnb6.Text = ""
                btnb7.Text = ""
                btnb5.Enabled = False
                btnb6.Enabled = False
                btnb7.Enabled = False
            Case 4
                btnb5.Text = dt3filtro2.Rows(4)("codigo").ToString
                btnb6.Text = ""
                btnb7.Text = ""
                btnb6.Enabled = False
                btnb7.Enabled = False
            Case 5
                btnb5.Text = dt3filtro2.Rows(4)("codigo").ToString
                btnb6.Text = dt3filtro2.Rows(5)("codigo").ToString
                btnb7.Text = ""
                btnb7.Enabled = False
            Case 6
                btnb5.Text = dt3filtro2.Rows(4)("codigo").ToString
                btnb6.Text = dt3filtro2.Rows(5)("codigo").ToString
                btnb7.Text = dt3filtro2.Rows(6)("codigo").ToString
        End Select
    End Sub

    Private Sub preciosCV()
        For Each dr As DataRow In dt1.Rows
            Select Case CInt(dr("tipo"))
                Case 1
                    'Format(cantidad, "##,##0.00")
                    txtcd1.Text = Format(dr("Compra"), "##,##0.00")
                    txtvd1.Text = Format(dr("Venta"), "##,##0.00")
                Case 2
                    txtcd2.Text = Format(dr("Compra"), "##,##0.00")
                    txtvd2.Text = Format(dr("Venta"), "##,##0.00")
                Case 3
                    txtcd3.Text = Format(dr("Compra"), "##,##0.00")
                    txtvd3.Text = Format(dr("Venta"), "##,##0.00")
                Case 4
                    txtcd4.Text = Format(dr("Compra"), "##,##0.00")
                    txtvd4.Text = Format(dr("Venta"), "##,##0.00")
                Case 5
                    txtcd5.Text = Format(dr("Compra"), "##,##0.00")
                    txtvd5.Text = Format(dr("Venta"), "##,##0.00")
                Case 6
                    txtcd6.Text = Format(dr("Compra"), "##,##0.00")
                    txtvd6.Text = Format(dr("Venta"), "##,##0.00")
                Case 7
                    txtcd7.Text = Format(dr("Compra"), "##,##0.00")
                    txtvd7.Text = Format(dr("Venta"), "##,##0.00")
                Case 8
                    txtcd8.Text = Format(dr("Compra"), "##,##0.00")
                    txtvd8.Text = Format(dr("Venta"), "##,##0.00")
            End Select
        Next
    End Sub

    Private Sub HabilitaBotonCalculadora2()
        btnb5.Enabled = True
        btnb6.Enabled = True
        btnb7.Enabled = True
    End Sub

    Private Sub HabilitaBotonCalculadora1()
        btnb1.Enabled = True
        btnb2.Enabled = True
        btnb3.Enabled = True
        btnb4.Enabled = True
    End Sub

    Private Sub HabilitaCambioPrecio()
        btnmas.Enabled = True
        btnmenos.Enabled = True
        btnreinicio.Enabled = True
    End Sub

    Private Sub DeshabilitaCambioPrecio()
        btnmas.Enabled = False
        btnmenos.Enabled = False
        btnreinicio.Enabled = False
    End Sub

    Private Sub LimpiaBotonesDenominaciones()
        btnb1.Text = ""
        btnb2.Text = ""
        btnb3.Text = ""
        btnb4.Text = ""
        btnb5.Text = ""
        btnb6.Text = ""
        btnb7.Text = ""
        btn14.Text = ""
        btn14.BackgroundImage = Nothing
    End Sub

    Private Sub btncompra_Click(sender As Object, e As EventArgs) Handles btncompra.Click
        If ConTarjeta Then
            MsgBox("Tiene escaneada la tarjeta para Venta de divisas", vbInformation)
            Exit Sub
        End If
        LimiteGral = 0
        TotalInventario = 0

        If tipdivi < 1 Then
            MessageBox.Show("NO SELECCIONÓ UNA DIVISA, PORFAVOR ELIJA UNA")
            Exit Sub
        End If

        If dgvAux.DataSource IsNot Nothing Then
            dgvAux.DataSource = Nothing
        End If
        HabilitaCambioPrecio()
        If dgvCoV.RowCount > 0 Then
            BtnFraccionar.Enabled = False
        Else
            BtnFraccionar.Enabled = True
        End If
        txtcv.Text = "COMPRA DE DIVISAS"
        CoV = "COMPRA"
        vbtnd5.Enabled = False

        If txtmonto1.Text.Trim <> "" Then
            If chGrupo.Checked Then
                If LimitesGrupo(sender, e) Then
                    Exit Sub
                End If
            End If
            If IsNumeric(txtmonto1.Text.Trim) Then
                Select Case tipdivi
                    Case 1
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd1.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        btnb7.Enabled = False
                        precioCoV = Convert.ToDouble(txtcd1.Text.Trim)
                        'filtrardt2(1)
                    Case 2
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd2.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtcd2.Text.Trim)
                        'filtrardt2(2)
                    Case 3
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd3.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtcd3.Text.Trim)
                        'filtrardt2(3)
                    Case 4
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd4.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtcd4.Text.Trim)
                        'filtrardt2(4)
                    Case 5
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd5.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtcd5.Text.Trim)
                        'filtrardt2(5)
                    Case 6
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd6.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtcd6.Text.Trim)
                        'filtrardt2(6)
                    Case 7
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd7.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtcd7.Text.Trim)
                        'filtrardt2(7)
                    Case 8
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd8.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtcd8.Text.Trim)
                        'filtrardt2(8)
                End Select
            End If
        End If
        If Not RevisarLimite(tipdivi) Then
            Exit Sub
        End If

        If Not RevisarLimiteCompra(tipdivi) Then
            Exit Sub
        End If
        If tipdivi > 0 And idcli > 0 Then
            LimitesC(sender, e)
        End If

        HabilitarBotones()

        If sumadivex = 0 And partemenor = 0 And partemenor = 0 And cantbilletes = 0 Then
            SumarizaExistencia()
        Else
            sumadivex = 0
            partemenor = 0
            partemenor = 0
            cantbilletes = 0
            SumarizaExistencia()
        End If

        dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
        dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
        dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
        dgvAux.DataSource = Nothing

    End Sub

    Private Sub btnventa_Click(sender As Object, e As EventArgs) Handles btnventa.Click
        Dim TotalExistencia As Integer = 0

        If chGrupo.Checked Then
            MsgBox("Tiene marcado la opcion de NOTAS DE GRUPO, no puede hacer VENTA", vbInformation)
            Exit Sub
        End If

        If ConTarjetaP Then
            MsgBox("Tiene escaneado la tarjeta para compra de divisas", vbInformation)
            Exit Sub
        End If

        If tipdivi < 1 Then
            MessageBox.Show("NO SELECCIONÓ UNA DIVISA, PORFAVOR ELIJA UNA")
            Exit Sub
        End If
        Existencias1()
        ExistenciasDivisa()

        For Each row As DataRow In dtExistenciaDiv.Rows
            TotalExistencia = row(0)
        Next

        If TotalExistencia < txtmonto1.Text Then
            MessageBox.Show("NO CUENTA CON LA EXISTENCIA SUFICIENTE PARA HACER" & vbCrLf & "ESTA OPERACION CON ESTA DIVISA", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'dt1 = otipodivisasC.Stipodivisas2(No_sucursal).Tables(0)
        'preciosCV()
        HabilitaCambioPrecio()
        cambio = False
        BtnFraccionar.Enabled = False
        'BtnCambio.Enabled = False
        txtcv.Text = "VENTA DE DIVISAS"
        CoV = "VENTA"
        vbtnd5.Enabled = True

        'Existencias2() 'hoy
        If txtmonto1.Text.Trim <> "" Then
            If IsNumeric(txtmonto1.Text.Trim) Then
                Select Case tipdivi
                    Case 1
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd1.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtvd1.Text.Trim)
                    Case 2
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd2.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtvd2.Text.Trim)
                    Case 3
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd3.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtvd3.Text.Trim)
                    Case 4
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd4.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtvd4.Text.Trim)
                    Case 5
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd5.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtvd5.Text.Trim)
                    Case 6
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd6.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtvd6.Text.Trim)
                    Case 7
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd7.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtvd7.Text.Trim)
                    Case 8
                        txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd8.Text.Trim)).ToString
                        txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
                        txtpesos.Text = FormatNumber(txtsubto.Text, 2)
                        precioCoV = Convert.ToDouble(txtvd8.Text.Trim)
                End Select
            End If
        End If
        Dim cantidadtransfer = oremisioMC.countransfer(No_sucursal, Date.Now.ToShortDateString)
        If cantidadtransfer > transferenciasCOUNT Then
            Me.Cursor = Cursors.WaitCursor
            'Existencias2()
            Existencias1()
            transferenciasCOUNT = cantidadtransfer
            Me.Cursor = Cursors.Default
        End If
        'Existencias2()

        FiltraMe(tipdivi)
        FiltrarExistencia2(tipdivi)
        filtrardt2(tipdivi)

        If dt2filtro.Columns.Count <= 1 Then
            MessageBox.Show("NO SELECCIONÓ UNA DIVISA, PORFAVOR ELIJA UNA")
        Else
            dgvAux.DataSource = dt2filtro
            dgvAux.Columns("divisa").Visible = False
            dgvAux.Columns("codigo").Visible = True
            dgvAux.Columns("valor").Visible = False
            dgvAux.Columns("tipo").Visible = False
            dgvAux.Columns("cpromedio").Visible = False
            dgvAux.Columns("divisa").HeaderText = "Divisa"
            dgvAux.EnableHeadersVisualStyles = False
            dgvAux.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            dgvAux.CellBorderStyle = DataGridViewCellBorderStyle.None
            dgvAux.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(218, 165, 32)
            dgvAux.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 12, FontStyle.Bold)
            dgvAux.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            dgvAux.Columns("divisa").Width = 100
            dgvAux.Columns("Existencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvNoOrden(dgvAux)
        End If

        If sumadivex = 0 And partemenor = 0 And partemenor = 0 And cantbilletes = 0 Then
            SumarizaExistencia()
        Else
            sumadivex = 0
            partemenor = 0
            partemenor = 0
            cantbilletes = 0
            SumarizaExistencia()
        End If

        dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
        dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
        dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke

        Select Case tipdivi
            Case 1
                precioCoV = Convert.ToDouble(txtvd1.Text.Trim)
            Case 2
                precioCoV = Convert.ToDouble(txtvd2.Text.Trim)
            Case 3
                precioCoV = Convert.ToDouble(txtvd3.Text.Trim)
            Case 4
                precioCoV = Convert.ToDouble(txtvd4.Text.Trim)
            Case 5
                precioCoV = Convert.ToDouble(txtvd5.Text.Trim)
            Case 6
                precioCoV = Convert.ToDouble(txtvd6.Text.Trim)
            Case 7
                precioCoV = Convert.ToDouble(txtvd7.Text.Trim)
            Case 8
                precioCoV = Convert.ToDouble(txtvd8.Text.Trim)
        End Select
        If tipdivi > 0 And idcli > 0 Then
            Limites(sender, e)
        End If
    End Sub

#Region "NUMEROS DEL 0 AL 9"
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

    Private Sub btn11_Click(sender As Object, e As EventArgs) Handles btn11.Click
        If btn14.BackgroundImage IsNot Nothing Then
            btn14.BackgroundImage = Nothing
        End If

        If txtsubto.Text.Replace("$", "") = "0" And dgvCoV.RowCount >= 1 Then
            MessageBox.Show("DEBE REINICIAR LA NOTA Y VOLVER A CAPTURAR LAS DIVISAS, DE LO CONTRARIO HABRÁN ERRORES AL GUARDAR LA OPERACIÓN")
        End If

        If btn13.Text.Replace("$", "") = "0" Or btn13.Text.Replace("$", "") = "" Or IsNumeric(btn13.Text.Replace("$", "")) = 0 Then 'no hay nada
            MessageBox.Show("NO PUEDE DEJAR 0 EN LA CANTIDAD, ESCRIBA OTRO NUMERO")
            btn13.Text = ""
            btn13.Focus()
        Else
            If btn13.Text <> "" And billete >= 0 And CoV <> "" Then
                Dim totalmn, totaldvs As Double
                totalmn = 0
                totaldvs = 0
                totalmn = Convert.ToDouble(btn13.Text) * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                totaldvs = Convert.ToDouble(btn13.Text)
                Select Case CoV
                    Case "COMPRA"
                        btnventa.Enabled = False
                        Select Case tipdivi
                            Case 1
                                totalmn = totalmn * Convert.ToDouble(txtcd1.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd2.Enabled = False
                                btnd3.Enabled = False
                                btnd4.Enabled = False
                                btnd5.Enabled = False
                                btnd6.Enabled = False
                                btnd7.Enabled = False
                                btnd8.Enabled = False
                            Case 2
                                totalmn = totalmn * Convert.ToDouble(txtcd2.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd1.Enabled = False
                                btnd3.Enabled = False
                                btnd4.Enabled = False
                                btnd5.Enabled = False
                                btnd6.Enabled = False
                                btnd7.Enabled = False
                                btnd8.Enabled = False
                            Case 3
                                totalmn = totalmn * Convert.ToDouble(txtcd3.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd1.Enabled = False
                                btnd2.Enabled = False
                                btnd4.Enabled = False
                                btnd5.Enabled = False
                                btnd6.Enabled = False
                                btnd7.Enabled = False
                                btnd8.Enabled = False
                            Case 4
                                totalmn = totalmn * Convert.ToDouble(txtcd4.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd1.Enabled = False
                                btnd2.Enabled = False
                                btnd3.Enabled = False
                                btnd5.Enabled = False
                                btnd6.Enabled = False
                                btnd7.Enabled = False
                                btnd8.Enabled = False
                            Case 5
                                totalmn = totalmn * Convert.ToDouble(txtcd5.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd1.Enabled = False
                                btnd2.Enabled = False
                                btnd3.Enabled = False
                                btnd4.Enabled = False
                                btnd6.Enabled = False
                                btnd7.Enabled = False
                                btnd8.Enabled = False
                            Case 6
                                totalmn = totalmn * Convert.ToDouble(txtcd6.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd1.Enabled = False
                                btnd2.Enabled = False
                                btnd3.Enabled = False
                                btnd4.Enabled = False
                                btnd5.Enabled = False
                                btnd7.Enabled = False
                                btnd8.Enabled = False
                            Case 7
                                totalmn = totalmn * Convert.ToDouble(txtcd7.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd1.Enabled = False
                                btnd2.Enabled = False
                                btnd3.Enabled = False
                                btnd4.Enabled = False
                                btnd5.Enabled = False
                                btnd6.Enabled = False
                                btnd8.Enabled = False
                            Case 8
                                totalmn = totalmn * Convert.ToDouble(txtcd8.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd1.Enabled = False
                                btnd2.Enabled = False
                                btnd3.Enabled = False
                                btnd4.Enabled = False
                                btnd5.Enabled = False
                                btnd6.Enabled = False
                                btnd7.Enabled = False
                        End Select
                    Case "VENTA"
                        btncompra.Enabled = False
                        Select Case tipdivi
                            Case 1
                                totalmn = totalmn * Convert.ToDouble(txtvd1.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd2.Enabled = False
                                btnd3.Enabled = False
                                btnd4.Enabled = False
                                btnd5.Enabled = False
                                btnd6.Enabled = False
                                btnd7.Enabled = False
                                btnd8.Enabled = False
                            Case 2
                                totalmn = totalmn * Convert.ToDouble(txtvd2.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd1.Enabled = False
                                btnd3.Enabled = False
                                btnd4.Enabled = False
                                btnd5.Enabled = False
                                btnd6.Enabled = False
                                btnd7.Enabled = False
                                btnd8.Enabled = False
                            Case 3
                                totalmn = totalmn * Convert.ToDouble(txtvd3.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd1.Enabled = False
                                btnd2.Enabled = False
                                btnd4.Enabled = False
                                btnd5.Enabled = False
                                btnd6.Enabled = False
                                btnd7.Enabled = False
                                btnd8.Enabled = False
                            Case 4
                                totalmn = totalmn * Convert.ToDouble(txtvd4.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd1.Enabled = False
                                btnd2.Enabled = False
                                btnd3.Enabled = False
                                btnd5.Enabled = False
                                btnd6.Enabled = False
                                btnd7.Enabled = False
                                btnd8.Enabled = False
                            Case 5
                                totalmn = totalmn * Convert.ToDouble(txtvd5.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd1.Enabled = False
                                btnd2.Enabled = False
                                btnd3.Enabled = False
                                btnd4.Enabled = False
                                btnd6.Enabled = False
                                btnd7.Enabled = False
                                btnd8.Enabled = False
                            Case 6
                                totalmn = totalmn * Convert.ToDouble(txtvd6.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd1.Enabled = False
                                btnd2.Enabled = False
                                btnd3.Enabled = False
                                btnd4.Enabled = False
                                btnd5.Enabled = False
                                btnd7.Enabled = False
                                btnd8.Enabled = False
                            Case 7
                                totalmn = totalmn * Convert.ToDouble(txtvd7.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd1.Enabled = False
                                btnd2.Enabled = False
                                btnd3.Enabled = False
                                btnd4.Enabled = False
                                btnd5.Enabled = False
                                btnd6.Enabled = False
                                btnd8.Enabled = False
                            Case 8
                                totalmn = totalmn * Convert.ToDouble(txtvd8.Text)
                                totaldvs = totaldvs * Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString)
                                btnd1.Enabled = False
                                btnd2.Enabled = False
                                btnd3.Enabled = False
                                btnd4.Enabled = False
                                btnd5.Enabled = False
                                btnd6.Enabled = False
                                btnd7.Enabled = False
                        End Select
                End Select
                If Convert.ToDouble(txtmonto2.Text) + totaldvs > Convert.ToDouble(txtmonto1.Text) Then ' + totalmn > Convert.ToDouble(txtmonto1.Text) Then
                    MessageBox.Show("NO SE PUEDE PROPORCIANAR ESA CANTIDAD DE DIVISA PORQUE:" + Chr(13) + Chr(13) + "* EXEDE EL TOTAL SOLICITADO Y/O ES MAYOR A LO NECESARIO" + Chr(13) + Chr(13) + "POR FAVOR DIGITE UNA CANTIDAD MENOR")
                    'btn12.Text = ""
                    btn13.Text = ""
                    btn12.Text = "$" & (Convert.ToDouble(txtmonto2.Text) * precioCoV).ToString
                Else
                    If repetido = False Then
                        Select Case CoV
                            Case "COMPRA"
                                dgvCoV.Rows.Add(dt3filtro2.Rows(billete)("codigo").ToString, dt3filtro2.Rows(billete)("divisa").ToString, btn13.Text,
                              totalmn.ToString("##,##0.00"), precioCoV.ToString("##,##0.00"))
                            Case "VENTA"
                                If valida_exist_divi > 0 And valida_exist_divi >= Convert.ToInt32(btn13.Text) Then
                                    dgvCoV.Rows.Add(dt3filtro2.Rows(billete)("codigo").ToString, dt3filtro2.Rows(billete)("divisa").ToString, btn13.Text,
                                       totalmn.ToString("##,##0.00"), precioCoV.ToString("##,##0.00"))
                                Else
                                    MessageBox.Show("LA CANTIDAD ES MAYOR A LA EXISTENCIA DE ESTA DIVISA")
                                    btn12.Text = "$" & (Convert.ToDouble(txtmonto2.Text) * precioCoV).ToString
                                    btn13.Text = ""
                                End If
                        End Select

                        'dgvCoV.Rows.Add(dt3filtro2.Rows(billete)("codigo").ToString, dt3filtro2.Rows(billete)("divisa").ToString, btn13.Text, _
                        '       totalmn.ToString, precioCoV)
                        btn13.Text = ""
                        btn14.Text = ""
                        autosumaGridCoV()
                        billete = -1
                        'btn12.Text = ""                
                    End If
                End If
            Else
                MessageBox.Show("DEBE ESCOGER UNA DIVISA Y PRESIONAR UNA CANTIDAD PARA CONTINUAR Ó VICEVERSA," + Chr(13) + " O BIEN ELEGIR SI ESTÁ REALIZANDO UNA COMPRA O VENTA")
                btn13.Text = ""
            End If
        End If
        'validaciones para las botones de Fraccionar y Cambio
        If dgvCoV.RowCount > 1 Then
            BtnFraccionar.Enabled = False
            'BtnCambio.Enabled = False
        ElseIf dgvCoV.RowCount = 1 And Trim(txtmonto1.Text) = Trim(txtmonto2.Text) And idcli <> 1229 And CoV = "COMPRA" Then
            For Each row As DataGridViewRow In dgvCoV.Rows
                If dgvCoV.Rows(row.Index).Cells(2).Value.ToString = 1 Then
                    BtnFraccionar.Enabled = False
                    'BtnCambio.Enabled = True
                Else
                    BtnFraccionar.Enabled = False
                    'BtnCambio.Enabled = False
                End If
            Next
        Else
            BtnFraccionar.Enabled = False
            'BtnCambio.Enabled = False
        End If
        btnb1.Focus()
    End Sub

    Private Sub ValidarRepetido()
        repetido = False
        For Each row As DataGridViewRow In dgvCoV.Rows
            If dgvCoV.Rows(row.Index).Cells(0).Value.ToString = dt3filtro2.Rows(billete)("codigo").ToString And dgvCoV.Rows(row.Index).Cells(0).Value IsNot Nothing Then
                MessageBox.Show("NO PUEDE AGREGAR UNA DIVISA QUE YA ESTÁ EN LA TABLA, SELECCIONE OTRA O ELIMINELA ANTES DE AGREGAR")
                btn12.Text = "$" & (Convert.ToDouble(txtmonto2.Text) * precioCoV).ToString
                repetido = True
                Exit For
            End If
        Next
    End Sub
#End Region

#Region "IMPEDIR ESCRIBIR TEXBOX"
    Private Sub txtcd1_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub txtcd2_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub txtcd3_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub txtcd4_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub txtvd1_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub txtvd2_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub txtvd3_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub txtvd4_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub txtsubto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsubto.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtmonto2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto2.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtuf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtuf.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtop_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtop.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtmnt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmnt.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtcv_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcv.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtdivisa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdivisa.KeyPress
        e.Handled = True
    End Sub
#End Region

    Private Sub txtid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtid.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Consultar_Tarjeta_Roja("Con")
        End If
    End Sub

    Private Sub txtmonto1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto1.KeyPress
        oauxiliares.SoloNumeros(e)
    End Sub

    Private Sub txtNombres_Enter(sender As Object, e As EventArgs) Handles txtNombres.Enter
        LimpiarInofoCliente()
    End Sub

    Private Sub txtNombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombres.KeyPress
        oauxiliares.SoloLetras1(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            e.Handled = True
            If dt_BloqFisicas.Rows.Count = 0 Or dt_BloqFisicas.Columns.Count < 2 Then
                PersonasBloqueadas1()
            End If
            If dt_PPoliticas.Rows.Count = 0 Or dt_PPoliticas.Columns.Count < 2 Then
                PersonasBloqueadas2()
            End If
            dgvClientes.DataSource = Nothing
            FiltrarCliente()

        End If
    End Sub

    Private Sub txtApellidos_Enter(sender As Object, e As EventArgs) Handles txtApellidos.Enter
        'LimpiarInofoCliente()
    End Sub

    Private Sub txtApellidos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellidos.KeyPress
        oauxiliares.SoloLetras1(e)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            e.Handled = True
            If dt_BloqFisicas.Rows.Count = 0 Or dt_BloqFisicas.Columns.Count < 2 Then
                PersonasBloqueadas1()
            End If
            If dt_PPoliticas.Rows.Count = 0 Or dt_PPoliticas.Columns.Count < 2 Then
                PersonasBloqueadas2()
            End If
            dgvClientes.DataSource = Nothing
            FiltrarCliente()
        End If
    End Sub

    Private Sub AsignaPrecios()
        Select Case CoV
            Case "COMPRA"
                Select Case tipdivi
                    Case 1
                        precioCoV = Convert.ToDouble(txtcd1.Text.Trim)
                    Case 2
                        precioCoV = Convert.ToDouble(txtcd2.Text.Trim)
                    Case 3
                        precioCoV = Convert.ToDouble(txtcd3.Text.Trim)
                    Case 4
                        precioCoV = Convert.ToDouble(txtcd4.Text.Trim)
                    Case 5
                        precioCoV = Convert.ToDouble(txtcd5.Text.Trim)
                    Case 6
                        precioCoV = Convert.ToDouble(txtcd6.Text.Trim)
                    Case 7
                        precioCoV = Convert.ToDouble(txtcd7.Text.Trim)
                    Case 8
                        precioCoV = Convert.ToDouble(txtcd8.Text.Trim)
                End Select
            Case "VENTA"
                Select Case tipdivi
                    Case 1
                        precioCoV = Convert.ToDouble(txtvd1.Text.Trim)
                    Case 2
                        precioCoV = Convert.ToDouble(txtvd2.Text.Trim)
                    Case 3
                        precioCoV = Convert.ToDouble(txtvd3.Text.Trim)
                    Case 4
                        precioCoV = Convert.ToDouble(txtvd4.Text.Trim)
                    Case 5
                        precioCoV = Convert.ToDouble(txtvd5.Text.Trim)
                    Case 6
                        precioCoV = Convert.ToDouble(txtvd6.Text.Trim)
                    Case 7
                        precioCoV = Convert.ToDouble(txtvd7.Text.Trim)
                    Case 8
                        precioCoV = Convert.ToDouble(txtvd8.Text.Trim)
                End Select
        End Select
    End Sub

#Region "DISMINUCION PRECIOS"
    Private Sub btnmas_Click(sender As Object, e As EventArgs) Handles btnmas.Click
        operacion_especial = True
        cambiaprecio = True
        ContadorBotonAum = ContadorBotonAum + 1
        Select Case tipdivi
            Case 1
                If txtcd1.Text.Trim <> "" Then
                    txtcd1.Text = (Convert.ToDouble(txtcd1.Text.Trim) + 0.05).ToString
                End If
                If txtvd1.Text.Trim <> "" Then
                    txtvd1.Text = (Convert.ToDouble(txtvd1.Text.Trim) + 0.05).ToString
                End If
                AsignaPrecios()
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd1.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd1.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
            Case 2
                If txtcd2.Text.Trim <> "" Then
                    txtcd2.Text = (Convert.ToDouble(txtcd2.Text.Trim) + 0.05).ToString
                End If
                If txtvd2.Text.Trim <> "" Then
                    txtvd2.Text = (Convert.ToDouble(txtvd2.Text.Trim) + 0.05).ToString
                End If
                AsignaPrecios()
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd2.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd2.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
            Case 3
                If txtcd3.Text.Trim <> "" Then
                    txtcd3.Text = (Convert.ToDouble(txtcd3.Text.Trim) + 0.05).ToString
                End If
                If txtvd3.Text.Trim <> "" Then
                    txtvd3.Text = (Convert.ToDouble(txtvd3.Text.Trim) + 0.05).ToString
                End If
                AsignaPrecios()
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd3.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd3.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
            Case 4
                If txtcd4.Text.Trim <> "" Then
                    txtcd4.Text = (Convert.ToDouble(txtcd4.Text.Trim) + 0.05).ToString
                End If
                If txtvd4.Text.Trim <> "" Then
                    txtvd4.Text = (Convert.ToDouble(txtvd4.Text.Trim) + 0.05).ToString
                End If
                AsignaPrecios()
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd4.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd4.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
        End Select
        If ContadorBotonAum >= 2 Then
            btnmas.Enabled = False
        End If
    End Sub

    Private Sub btnmenos_Click(sender As Object, e As EventArgs) Handles btnmenos.Click
        operacion_especial = True
        cambiaprecio = True
        ContadorBotomRes = ContadorBotomRes + 1
        Select Case tipdivi
            Case 1
                If txtcd1.Text.Trim <> "" Then
                    txtcd1.Text = (Convert.ToDouble(txtcd1.Text.Trim) - 0.05).ToString
                End If
                If txtvd1.Text.Trim <> "" Then
                    txtvd1.Text = (Convert.ToDouble(txtvd1.Text.Trim) - 0.05).ToString
                End If
                AsignaPrecios()
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd1.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd1.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
            Case 2
                If txtcd2.Text.Trim <> "" Then
                    txtcd2.Text = (Convert.ToDouble(txtcd2.Text.Trim) - 0.05).ToString
                End If
                If txtvd2.Text.Trim <> "" Then
                    txtvd2.Text = (Convert.ToDouble(txtvd2.Text.Trim) - 0.05).ToString
                End If
                AsignaPrecios()
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd2.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd2.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
            Case 3
                If txtcd3.Text.Trim <> "" Then
                    txtcd3.Text = (Convert.ToDouble(txtcd3.Text.Trim) - 0.05).ToString
                End If
                If txtvd3.Text.Trim <> "" Then
                    txtvd3.Text = (Convert.ToDouble(txtvd3.Text.Trim) - 0.05).ToString
                End If
                AsignaPrecios()
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd3.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd3.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
            Case 4
                If txtcd4.Text.Trim <> "" Then
                    txtcd4.Text = (Convert.ToDouble(txtcd4.Text.Trim) - 0.05).ToString
                End If
                If txtvd4.Text.Trim <> "" Then
                    txtvd4.Text = (Convert.ToDouble(txtvd4.Text.Trim) - 0.05).ToString
                End If
                AsignaPrecios()
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd4.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd4.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
        End Select
        If ContadorBotomRes >= 2 Then
            btnmenos.Enabled = False
        End If
    End Sub

    Private Sub btnreinicio_Click(sender As Object, e As EventArgs) Handles btnreinicio.Click
        btnmas.Enabled = True
        btnmenos.Enabled = True
        operacion_especial = False
        cambiaprecio = False
        Select Case tipdivi
            Case 1
                txtcd1.Text = dt1.Rows(0)("Compra").ToString
                txtvd1.Text = dt1.Rows(0)("Venta").ToString
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd1.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd1.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
            Case 2
                txtcd2.Text = dt1.Rows(1)("Compra").ToString
                txtvd2.Text = dt1.Rows(1)("Venta").ToString
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd2.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd2.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
            Case 3
                txtcd3.Text = dt1.Rows(2)("Compra").ToString
                txtvd3.Text = dt1.Rows(2)("Venta").ToString
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd3.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd3.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
            Case 4
                txtcd4.Text = dt1.Rows(3)("Compra").ToString
                txtvd4.Text = dt1.Rows(3)("Venta").ToString
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd4.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd4.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
            Case 5
                txtcd5.Text = dt1.Rows(4)("Compra").ToString
                txtvd5.Text = dt1.Rows(4)("Venta").ToString
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd5.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd5.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
            Case 6
                txtcd6.Text = dt1.Rows(5)("Compra").ToString
                txtvd6.Text = dt1.Rows(5)("Venta").ToString
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd6.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd6.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
            Case 7
                txtcd7.Text = dt1.Rows(6)("Compra").ToString
                txtvd7.Text = dt1.Rows(6)("Venta").ToString
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd7.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd7.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
            Case 8
                txtcd8.Text = dt1.Rows(7)("Compra").ToString
                txtvd8.Text = dt1.Rows(7)("Venta").ToString
                Select Case CoV
                    Case "COMPRA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtcd8.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                    Case "VENTA"
                        txtsubto.Text = "$" & FormatNumber((Convert.ToDouble(txtvd8.Text.Trim) * Convert.ToInt32(txtmonto1.Text.Trim)).ToString, 2)
                End Select
        End Select
    End Sub
#End Region

    Private Sub Valida_Existencia_divisa(ByVal billete_posicion As Integer)
        valida_exist_divi = 0
        For Each row As DataGridViewRow In dgvAux.Rows
            Dim valor As String = CStr(dgvAux.Rows(row.Index).Cells("Existencia").Value.ToString)
            If row.Index = billete_posicion Then 'CInt(row("valor")) 
                valida_exist_divi = CInt(dgvAux.Rows(row.Index).Cells("Existencia").Value.ToString)
                Exit For
            End If
        Next
    End Sub

#Region "SABER QUE BILLETE PRESIONÉ"
    Private Sub btnb1_Click(sender As Object, e As EventArgs) Handles btnb1.Click
        If btnb1.Text <> "" Then
            Valida_Existencia_divisa(0)
            billete = 0
            btn12.Text = "$0"
            ValidarRepetido()
            btn14.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta_billeteimg & btnb1.Text & extencion_billeteimg)
            btn14.BackgroundImageLayout = PictureBoxSizeMode.StretchImage
            btn13.Focus()
        Else
            MessageBox.Show("SELECCIONE UNA DIVISA")
        End If
    End Sub

    Private Sub btnb2_Click(sender As Object, e As EventArgs) Handles btnb2.Click
        If btnb2.Text <> "" Then
            Valida_Existencia_divisa(1)
            billete = 1
            btn12.Text = "$0"
            ValidarRepetido()
            btn14.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta_billeteimg & btnb2.Text & extencion_billeteimg)
            btn14.BackgroundImageLayout = PictureBoxSizeMode.StretchImage
            btn13.Focus()
        Else
            MessageBox.Show("SELECCIONE UNA DIVISA")
        End If
    End Sub

    Private Sub btnb3_Click(sender As Object, e As EventArgs) Handles btnb3.Click
        If btnb3.Text <> "" Then
            Valida_Existencia_divisa(2)
            billete = 2
            btn12.Text = "$0"
            ValidarRepetido()
            btn14.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta_billeteimg & btnb3.Text & extencion_billeteimg)
            btn14.BackgroundImageLayout = PictureBoxSizeMode.StretchImage
            btn13.Focus()
        Else
            MessageBox.Show("SELECCIONE UNA DIVISA")
        End If
    End Sub

    Private Sub btnb4_Click(sender As Object, e As EventArgs) Handles btnb4.Click
        If btnb4.Text <> "" Then
            Valida_Existencia_divisa(3)
            billete = 3
            btn12.Text = "$0"
            ValidarRepetido()
            btn14.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta_billeteimg & btnb4.Text & extencion_billeteimg)
            btn14.BackgroundImageLayout = PictureBoxSizeMode.StretchImage
            btn13.Focus()
        Else
            MessageBox.Show("SELECCIONE UNA DIVISA")
        End If
    End Sub

    Private Sub btnb5_Click(sender As Object, e As EventArgs) Handles btnb5.Click
        If btnb5.Text <> "" Then
            Valida_Existencia_divisa(4)
            billete = 4
            btn12.Text = "$0"
            ValidarRepetido()
            btn14.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta_billeteimg & btnb5.Text & extencion_billeteimg)
            btn14.BackgroundImageLayout = PictureBoxSizeMode.StretchImage
            btn13.Focus()
        Else
            MessageBox.Show("SELECCIONE UNA DIVISA")
        End If
    End Sub

    Private Sub btnb6_Click(sender As Object, e As EventArgs) Handles btnb6.Click
        If btnb6.Text <> "" Then
            Valida_Existencia_divisa(5)
            billete = 5
            btn12.Text = "$0"
            ValidarRepetido()
            btn14.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta_billeteimg & btnb6.Text & extencion_billeteimg)
            btn14.BackgroundImageLayout = PictureBoxSizeMode.StretchImage
            btn13.Focus()
        Else
            MessageBox.Show("SELECCIONE UNA DIVISA")
        End If
    End Sub

    Private Sub btnb7_Click(sender As Object, e As EventArgs) Handles btnb7.Click
        If btnb7.Text <> "" Then
            Valida_Existencia_divisa(6)
            billete = 6
            btn12.Text = "$0"
            ValidarRepetido()
            btn14.BackgroundImage = System.Drawing.Bitmap.FromFile(ruta_billeteimg & btnb7.Text & extencion_billeteimg)
            btn14.BackgroundImageLayout = PictureBoxSizeMode.StretchImage
            btn13.Focus()
        Else
            MessageBox.Show("SELECCIONE UNA DIVISA")
        End If
    End Sub
#End Region

    Private Sub vbtnd1_Click(sender As Object, e As EventArgs) Handles vbtnd1.Click
        If dgvCoV.Rows.Count > 0 Then
            Dim valor As String
            valor = dgvCoV.Rows(dgvCoV.CurrentRow.Index).Cells(0).Value.ToString
            valor = valor.Replace("C", "")
            valor = valor.Replace("D", "")
            valor = valor.Replace("E", "")
            valor = valor.Replace("L", "")
            valor = valor.Replace("Y", "")
            valor = valor.Replace("J", "")
            valor = valor.Replace("F", "")
            valor = valor.Replace("A", "")
            txtmonto2.Text = (Convert.ToDouble(txtmonto2.Text) - (Convert.ToDouble(valor) * Convert.ToDouble(dgvCoV.Rows(dgvCoV.CurrentRow.Index).Cells(2).Value.ToString))).ToString
            txtmonto2.Text = FormatNumber(txtmonto2.Text, 2)
            btn12.Text = "$" & (Convert.ToDouble(txtmonto2.Text) * precioCoV).ToString
            dgvCoV.Rows.RemoveAt(dgvCoV.CurrentRow.Index)
        End If
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
                        extraer = extraer.Replace("Y", "")
                        extraer = extraer.Replace("J", "")
                        extraer = extraer.Replace("F", "")
                        extraer = extraer.Replace("A", "")
                        totalDIV += Convert.ToDecimal(extraer) * Convert.ToDecimal(row.Cells(2).Value)
                    End If
                End If
            End If
        Next
        txtmonto2.Text = totalDIV
        btn12.Text = "$" & (Format(totalMN, "#########0.00")).ToString()
        row = Nothing
    End Sub

    Private Sub btn15_Click(sender As Object, e As EventArgs) Handles btn15.Click
        Dim frmImp As New frmImpNota
        Dim idCliente As String = ""
        Dim FolioFact As String = ""
        Dim NumSucursal As String = ""

        If CoV = "COMPRA" Then
            If Not RevisarLimite(tipdivi) Then
                Exit Sub
            End If
        End If

        Limites(sender, e)
        Me.Cursor = Cursors.WaitCursor
        btn15.Enabled = False
        lblMensage.Visible = True
        If (btn12.Text = "" Or btn12.Text.Replace("$", "") = "0") Or IsNumeric(btn12.Text.Replace("$", "")) = 0 And dgvCoV.RowCount > 0 Then
            autosumaGridCoV()
        End If

        Dim si As Boolean = False
        If (txtNombres.Text = "" And txtApellidos.Text = "") Or nombre_completo = "" Then
            MessageBox.Show("SELECCIONE UN CLIENTE PARA CONTINUAR, PRESIONE REINICIAR NOTA, SU SISTEMA TARDARÁ UN POCO PARA RESPONDER")
        Else
            si = True
            If Convert.ToDouble(txtmonto1.Text) <> Convert.ToDouble(txtmonto2.Text) Then
                MessageBox.Show("NO SE HA COMPLETADO EL MONTO CON EL TOTAL ACTUAL, " + Chr(13) + Chr(13) + """LAS CANTIDADES DEBEN SER IGUALES EN LOS RECUADROS DE ARRIBA""" + Chr(13) + Chr(13) &
                                "PUEDE MODIFICAR EL RECUADRO DE LA IZQUIERDA PARA IGUALAR LAS CANTIDADES")
                si = False
                txtid.BackColor = Color.White
                tiempo_actual = DateTime.Now
                lblMensage.Visible = False
                Me.Cursor = Cursors.Default
                btn15.Enabled = True
                cambio = False
                Moral = False
                Exit Sub
            Else
                si = True
                dgvCoV.Sort(dgvCoV.Columns(1), ListSortDirection.Ascending)
                '-------------------------------------------------------------
                Remision("A")

                If CoV = "VENTA" Then
                    Dim frm1 As New frmCobro
                    frm1.CobroTotal = oremisioMM.total
                    frm1.ShowDialog()
                    If frm1.Aceptar Then
                        oremisioMM.saldo = frm1.TotalEfectivo
                    Else
                        txtid.BackColor = Color.White
                        tiempo_actual = DateTime.Now
                        lblMensage.Visible = False
                        Me.Cursor = Cursors.Default
                        btn15.Enabled = True
                        cambio = False
                        Moral = False
                        Exit Sub
                    End If
                End If

                If oremisioMM.folio_factura > 0 And oremisioMM.total > 0 And oremisioMM.observaciones <> "" Then
                    If oremisioMC.ValidaRemision(oremisioMM.folio_factura, oremisioMM.Nosucursal, oremisioMM.fecha) = 0 Then
                        'checar si es de alto riesgo
                        If LblRiesgo.Text = "ALTO" Then
                            'si es de alto riesgo se guarda el dato en la tabla de autorizacion.
                            If oremisioMC.InsertAutorizacion(idcli, Now.ToString("dd/MM/yyyy HH:mm:ss"), oremisioMM.folio_factura, oremisioMM.Nosucursal, txtmonto2.Text, oremisioMM.observaciones, tipdivi, IIf(CoV = "COMPRA", txtcd1.Text, txtvd1.Text)) <= 0 Then
                                MsgBox("Hubo un Error en el momento de guardar la autorización, hablar al de sistemas", MsgBoxStyle.Information)
                                Exit Sub
                            End If
                            'si es de alto riesgo esperar la autorizacion de la operacion
                            Dim frm As New FrmVerificacionAut
                            frm.cliente = idcli
                            frm.folio = oremisioMM.folio_factura
                            frm.sucursal = oremisioMM.Nosucursal
                            frm.ShowDialog()
                            If frm.autorizo = False Then
                                'cancelar dato
                                If oremisioMC.EliminarAutorizacion(idcli, oremisioMM.folio_factura, oremisioMM.Nosucursal) <= 0 Then
                                    MsgBox("Hubo un Error en el momento de ELIMINAR la autorización, hablar al de sistemas", MsgBoxStyle.Information)
                                    Exit Sub
                                End If
                                vbtnd4_Click(sender, e)
                                Exit Sub
                            Else
                                'dtHora.Value = DateTime.Now
                                oremisioMM.hora = DateTime.Now 'dtHora.Value
                            End If
                        End If
                        conn.EstablecerConexion()
                        If conn.con.State = ConnectionState.Open Then
                            conn.CerrarConexion()
                        End If

                        conn.EstablecerConexion()
                        conn.AbrirConexion()
                        'cmd.Connection = conn.con
                        Trans = conn.con.BeginTransaction

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
                            Cadena = Cadena & "   saldo, "
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
                            Cadena = Cadena & "'" & txtdivisa.Text & "', "
                            Cadena = Cadena & "'" & oremisioMM.estatus & "', "
                            Cadena = Cadena & oremisioMM.stotal & ", "
                            Cadena = Cadena & oremisioMM.iva & ", "
                            Cadena = Cadena & oremisioMM.total & ", "
                            Cadena = Cadena & oremisioMM.saldo & ", "
                            Cadena = Cadena & "'" & oremisioMM.observaciones & "', "
                            Cadena = Cadena & oremisioMM.moneda & ", "
                            Cadena = Cadena & "'" & oremisioMM.letras & "', "
                            Cadena = Cadena & oremisioMM.cajero & ", "
                            Cadena = Cadena & oremisioMM.ncorte & ", "
                            Cadena = Cadena & "'" & oremisioMM.hora.ToString("dd/MM/yyyy HH:mm:ss") & "', "
                            Cadena = Cadena & "'" & oremisioMM.Nosucursal & "', "
                            Cadena = Cadena & "'" & oremisioMM.precio_especial & "', "
                            Cadena = Cadena & "'" & oremisioMM.cambio & "')"

                            cmd = New SqlCommand(Cadena, conn.con)
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

                                cmd = New SqlCommand(Cadena, conn.con)
                                cmd.Transaction = Trans
                                cmd.ExecuteNonQuery()
                            End If

                            'If oremisioMC.AremisioM(oremisioMM) > 0 Then

                            Cadena = ""
                            Cadena = Cadena & "UPDATE "
                            Cadena = Cadena & " Sucursales "
                            Cadena = Cadena & "SET "
                            Cadena = Cadena & " folio_remision = folio_remision + 1 "
                            Cadena = Cadena & "WHERE "
                            Cadena = Cadena & " id = '" & NoSucursal & "'"
                            cmd = New SqlCommand(Cadena, conn.con)
                            cmd.Transaction = Trans
                            cmd.ExecuteNonQuery()

                            DetallesRemision()

                            Trans.Commit()

                        Catch ex As Exception
                            MessageBox.Show("HUBO UN PROBLEMA CON EL PROCESAMIENTO DE INFORMACIÓN, DEBERA CAPTURAR DE NUEVO ESTA NOTA, " + Chr(13) + "" &
                                             "PORFAVOR ESPERE A QUE SE LIMPIEN LOS DATOS")
                            MsgBox(ex.Message, vbInformation)
                            Trans.Rollback()
                            Me.Cursor = Cursors.Default
                            conn.CerrarConexion()
                            preciosCV()
                            Exit Sub
                        End Try

                        '------------------------------------------------------------------------------
                        ImpresoraName()

                        idCliente = idcli
                        FolioFact = txtFolio.Text.Trim
                        NumSucursal = No_sucursal

                        Try
                            dt1Promo = oPuntos.Promociones(CoV).Tables(0)
                            For Each dr As DataRow In dt1Promo.Rows
                                If idcli <> 1229 And CoV = "VENTA" And TxtTarjeta.Text <> "" And ConTarjeta = True And tipdivi <= 4 Then 'Cualquier divisa y solo compra y que tenga tarjeta
                                    Dim Puntos As Double
                                    Dim PuntosTotal As Double
                                    Dim USDEntregar As Double
                                    Dim Residuo As Double
                                    Dim PrimeraVez As Boolean = False
                                    Dim D1Ent, D5Ent, D10Ent, PuntosEnt As Double
                                    Dim NCLetras As String
                                    Dim ExisteEncPuntos As Boolean = False
                                    Dim TotalContPuntos As Integer = 0
                                    'saber cuanto en total esta pagando
                                    Dim totalPesos As Double = oremisioMM.total
                                    'saber cuantos dolares se vendio
                                    Dim totalDll As Double = CDbl(txtmonto1.Text)
                                    'poner el porcentaje del total de dolares para generar los puntos
                                    Puntos = totalDll * dr("ValorXDolarPts")
                                    oPuntosD.puntos = Puntos
                                    oPuntosD.cliente = idcli
                                    oPuntosD.fecha = Now.ToLongDateString
                                    oPuntosD.tarjeta = TxtTarjeta.Text
                                    oPuntosD.folio = oremisioMM.folio_factura
                                    oPuntosD.NoSuc = NoSucursal

                                    TotalContPuntos = oPuntos.ExisteEncPuntos(TxtTarjeta.Text.Trim)
                                    If TotalContPuntos > 0 Then
                                        ExisteEncPuntos = True
                                    End If

                                    PuntosTotal = oPuntos.ChecarPuntos2(TxtTarjeta.Text.Trim) + Puntos
                                    oPuntosD.puntos = PuntosTotal

                                    ArchivoSer = New System.IO.StreamReader("servidor.txt")
                                    conser = ArchivoSer.ReadLine
                                    ArchivoSer.Close()

                                    Dim D1, D5, D10 As Double

                                    Dim tConection As New SqlConnection(conser)

                                    tConection.Open()
                                    Dim consulta As String = ""
                                    consulta = consulta & "select "
                                    consulta = consulta & " e.fecha, "
                                    consulta = consulta & " e.nosucursal, "
                                    consulta = consulta & " e.divisa, "
                                    consulta = consulta & " e.sf "
                                    consulta = consulta & "from "
                                    consulta = consulta & " Existencia e "
                                    consulta = consulta & " inner join divisas d ON d.codigo = e.divisa "
                                    consulta = consulta & "where "
                                    consulta = consulta & " e.nosucursal = '" & NoSucursal & "' "
                                    consulta = consulta & " And e.fecha = '" & Now.ToString("dd/MM/yyyy") & "' "
                                    consulta = consulta & " And e.tipo = 1 And e.divisa IN('D1', 'D5', 'D10') "
                                    consulta = consulta & "order by d.divisa"

                                    cmd = New SqlCommand(consulta, tConection)
                                    lector = cmd.ExecuteReader()
                                    While lector.Read
                                        Select Case lector(2)
                                            Case "D1"
                                                D1 = lector(3)
                                            Case "D5"
                                                D5 = lector(3)
                                            Case "D10"
                                                D10 = lector(3)
                                        End Select
                                    End While
                                    lector.Close()
                                    tConection.Close()

                                    Residuo = 0
                                    D1Ent = 0
                                    D5Ent = 0
                                    D10Ent = 0
                                    USDEntregar = Int((PuntosTotal * 0.05) / precioCoV)

                                    If USDEntregar > 0 Then
                                        If D1 >= USDEntregar Then
                                            D1Ent = USDEntregar
                                        Else
                                            If D5 * 5 >= USDEntregar Then
                                                D5Ent = Int(USDEntregar / 5)
                                                Residuo = USDEntregar - (D5Ent * 5)
                                                If Residuo > 0 Then
                                                    If D1 >= Residuo Then
                                                        D1Ent = Residuo
                                                        Residuo = Residuo - D1Ent
                                                    Else
                                                        If D1 > 0 Then
                                                            D1Ent = D1
                                                            Residuo = Residuo - D1Ent
                                                        End If
                                                    End If
                                                End If
                                            Else
                                                If D10 * 10 >= USDEntregar Then
                                                    D10Ent = Int(USDEntregar / 10)
                                                    Residuo = USDEntregar - (D10Ent * 10)
                                                    If Residuo > 0 Then
                                                        If D1 >= Residuo Then
                                                            D1Ent = Residuo
                                                            Residuo = Residuo - D1Ent
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                        'oPuntosD.puntos = 0

                                        If ExisteEncPuntos Then
                                            oPuntos.UpdatePts(oPuntosD)
                                        Else
                                            oPuntos.InsertarEncPts(oPuntosD)
                                        End If

                                        PuntosEnt = ((D1Ent + (D5Ent * 5) + (D10Ent * 10)) / 0.05) * precioCoV
                                        oPuntosD.puntos = PuntosEnt
                                        oPuntos.GuardarPtsDet(oPuntosD)

                                        Dim ValorDiv(2)
                                        Dim DivisasEnt(2)
                                        Dim ValorDivisas(2)
                                        Dim NombreDiv(2)
                                        Dim ValorTotal As Double

                                        ValorDiv(0) = "D1"
                                        ValorDiv(1) = "D5"
                                        ValorDiv(2) = "D10"

                                        DivisasEnt(0) = D1Ent
                                        DivisasEnt(1) = D5Ent * 5
                                        DivisasEnt(2) = D10Ent * 10

                                        ValorTotal = 0
                                        For I As Integer = 0 To 2
                                            ValorTotal = ValorTotal + (DivisasEnt(I) * precioCoV)
                                        Next

                                        Siguiente_Folio(NoSucursal)
                                        NCLetras = oauxiliares.EnLetras(Convert.ToDouble(ValorTotal)).ToUpper
                                        If NCLetras.Contains("CON") Then
                                            NCLetras = NCLetras.Replace("CON", "PESOS CON ") & "/100 M.N."
                                        Else
                                            NCLetras += " PESOS 00/100 M.N."
                                        End If
                                        ArchivoSer = New System.IO.StreamReader("servidor.txt")
                                        conser = ArchivoSer.ReadLine
                                        ArchivoSer.Close()

                                        tConection = New SqlConnection(conser)

                                        tConection.Open()
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
                                        Cadena = Cadena & idcli & ", "
                                        Cadena = Cadena & "'" & TxtTarjeta.Text & "', "
                                        Cadena = Cadena & PuntosEnt & ", "
                                        Cadena = Cadena & D1Ent + (D5Ent * 5) + (D10Ent * 10) & ", "
                                        Cadena = Cadena & "'" & Now.ToString("dd/MM/yyyy") & "', "
                                        Cadena = Cadena & 1 & ", "
                                        Cadena = Cadena & "'" & NCLetras & "', "
                                        Cadena = Cadena & (D1Ent + (D5Ent * 5) + (D10Ent * 10)) * precioCoV & ", "
                                        Cadena = Cadena & FolioNC & ", "
                                        Cadena = Cadena & "'" & NoSucursal & "', "
                                        Cadena = Cadena & "'" & oremisioMM.folio_factura & "')"

                                        Comando.Connection = tConection
                                        Comando.CommandText = Cadena
                                        Comando.ExecuteNonQuery()

                                        For I As Integer = 0 To 2
                                            Cadena = ""
                                            Cadena = Cadena & "Select divisa, valor From divisas Where codigo = '" & ValorDiv(I) & "'"
                                            Comando = New SqlCommand(Cadena, tConection)
                                            lector = Comando.ExecuteReader
                                            While lector.Read
                                                ValorDivisas(I) = lector(1)
                                                NombreDiv(I) = lector(0)
                                            End While
                                            lector.Close()
                                        Next
                                        Dim NumBilletes As Integer = 0
                                        For I As Integer = 0 To 2
                                            If DivisasEnt(I) > 0 Then
                                                If ValorDiv(I) = "D1" Then
                                                    NumBilletes = D1Ent
                                                Else
                                                    If ValorDiv(I) = "D5" Then
                                                        NumBilletes = D5Ent
                                                    Else
                                                        If ValorDiv(I) = "D10" Then
                                                            NumBilletes = D10Ent
                                                        End If
                                                    End If
                                                End If
                                                opuntosNC_Det.folio_NC = FolioNC
                                                opuntosNC_Det.p_unitario = precioCoV
                                                opuntosNC_Det.stotal = DivisasEnt(I) * precioCoV
                                                opuntosNC_Det.Nosucursal = NoSucursal
                                                opuntosNC_Det.cantidads = DivisasEnt(I)
                                                opuntosNC_Det.descripcion_larga = NumBilletes & " billetes de " & NombreDiv(I)
                                                opuntosNC_Det.producto = ValorDiv(I)

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

                                                Comando.CommandText = Cadena
                                                Comando.ExecuteNonQuery()

                                                Cadena = ""
                                                Cadena = Cadena & "update Existencia set "
                                                Cadena = Cadena & "pts=pts + " & NumBilletes & ", "
                                                Cadena = Cadena & "sf=(si + en + te + ce) - (sal + ts + cs + pts + " & NumBilletes & ") ,"
                                                Cadena = Cadena & "precio=" & opuntosNC_Det.p_unitario & " "
                                                Cadena = Cadena & "where fecha='" & Now.ToString("dd/MM/yyyy") & "' and nosucursal='" & NoSucursal & "' and divisa='" & ValorDiv(I) & "'"

                                                Comando.CommandText = Cadena
                                                Comando.ExecuteNonQuery()
                                            End If
                                        Next

                                        ImpresoraName()
                                        'Dim Nota2 = New NotaCreditoN
                                        'Dim datosdsc As New DataSet
                                        'datosdsc = oReportesUnicosC.ImprimeNotaPuntos(idcli, FolioNC, NoSucursal)
                                        'Nota2.SetDataSource(datosdsc)
                                        'Nota2.PrintOptions.PrinterName = Impresora1
                                        'Nota2.PrintToPrinter(1, False, 0, 0)

                                        'Nota2.Close()
                                        'Nota2.Dispose()

                                        Dim Nota3 = New NotaCreditoV
                                        Dim datosdsc2 As New DataSet
                                        datosdsc2 = oReportesUnicosC.ImprimeNotaPuntosVenta(idcli, FolioNC, NoSucursal)
                                        Nota3.SetDataSource(datosdsc2)
                                        Nota3.PrintOptions.PrinterName = Impresora1
                                        Nota3.PrintToPrinter(1, False, 0, 0)

                                        Nota3.Close()
                                        Nota3.Dispose()

                                    Else
                                        oPuntos.UpdatePts(oPuntosD)
                                        oPuntos.GuardarPtsDet(oPuntosD)
                                    End If

                                Else
                                    If chGrupo.Checked = False Then
                                        If idcli <> 1229 And CoV = "COMPRA" And ConTarjetaP = True And tipdivi = 1 Then
                                            Dim totalDlls As Double = CDbl(txtmonto1.Text)
                                            Dim ConLetras As String
                                            EncontroMun = 0
                                            If totalDlls >= 1000 Then
                                                Incentivo = 0.05
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
                                        End If
                                    Else
                                        Incentivo = 0.05
                                        Importe_Incentivo = 0
                                        Importe_Incentivo = CDbl(txtmonto1.Text) * Incentivo
                                        AcumuladoInsentivo = AcumuladoInsentivo + Importe_Incentivo
                                        If PrimeroGrupo Then
                                            PrimeroGrupo = False
                                            PrimerCliente = idcli
                                            PrimerFolio = oremisioMM.folio_factura
                                        End If
                                    End If
                                End If
                            Next
                        Catch ex As Exception
                            MsgBox(ex.Message, vbInformation)
                            Me.Cursor = Cursors.Default
                        End Try

                        If cambio Then vbtnd4.Enabled = True
                        txtmonto1.Text = "0"
                        LimpiarCampos1()
                        dgvCoV.Rows.Clear()
                        btncompra.Enabled = True
                        btnventa.Enabled = True
                        btn14.BackgroundImage = Nothing
                        DeshabilitaCambioPrecio()
                        HabilitaBotonesBanderas()
                        tcDivisas.SelectedIndex = 0
                        btn12.Text = "$0"
                        precioCoV = 0
                        txtFolio.Text = oremisioMC.UFolioRemision(No_sucursal).ToString
                        dgvAux.DataSource = Nothing
                        InicializarVariables1()
                        VButton1_Click(sender, e)

                        If dgvAux.Columns("CSugerida") IsNot Nothing And dgvAux.Columns.Count > 0 Then
                            dgvAux.Columns.RemoveAt(dgvAux.Columns.Count - 1)
                        End If
                        vbtnd5.Enabled = False
                    Else
                        MessageBox.Show("YA HAY UNA NOTA CON ESTE FOLIO, VERIFIQUE QUE NO TENGA LOS MISMOS DATOS QUE EN PANTALLA (DESDE EL MENU REPORTES)," + Chr(13) + "" &
                                        """AL CERRAR ESTE MENSAJE EL NUMERO DE FOLIO HABRÁ CAMBIADO, REVISE EL NÚMERO ANTERIOR"" Y " + Chr(13) + "" &
                                        "*SI NO HAY COINCIDENCIA, PRESIONE EL BOTÓN IMPRIMIR," + Chr(13) + "*SI HAY COINCIDENCIA, PRESIONE EL BOTÓN REINICIAR NOTA")
                        txtFolio.Text = (Convert.ToInt32(txtFolio.Text) + 1).ToString
                        si = False

                        If oremisioMC.UFolioRemision(No_sucursal) < Convert.ToInt32(txtFolio.Text) Then
                            oremisioMC.MFolioRemision(No_sucursal)
                        Else
                            txtFolio.Text = oremisioMC.UFolioRemision(No_sucursal)
                        End If
                    End If
                End If
            End If

            If si = True Then
                dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
                dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke
                LimpiaBotonesDenominaciones()
            End If
        End If
        Cadenas = ""
        FechaQR = Now.Date
        idQR = 0
        FolioQR = 0
        ImporteQR = 0
        ContadorBotonAum = 0
        ContadorBotomRes = 0
        AplicarCupon = False

        txtid.BackColor = Color.White
        tiempo_actual = DateTime.Now
        lblMensage.Visible = False
        Me.Cursor = Cursors.Default
        btn15.Enabled = True
        cambio = False
        Moral = False

        Dim Nota = New Notacv
        Try
            Dim datosds As New DataSet
            datosds = oReportesUnicosC.ImprimeNota2(idCliente, FolioFact, No_sucursal)
            Nota.SetDataSource(datosds)
            Nota.PrintOptions.PrinterName = Impresora1
            Nota.PrintToPrinter(1, False, 0, 0)
            If CoV = "VENTA" Then
                frmImp.Cliente = idCliente
                frmImp.Folio = FolioFact
                frmImp.Sucursal = No_sucursal
                frmImp.Show()
            End If
            idCliente = ""
            FolioFact = ""

            Nota.Close()
            Nota.Dispose()

        Catch ex As Exception
            Nota.Close()
            Nota.Dispose()
            MessageBox.Show("HUBO UN PROBLEMA CON LA IMPRESIÓN DE LA NOTA, SIN EMBARGO SI SE REGISTRO ESTA OPERACIÓN EN EL SISTEMA" & vbCrLf & ex.Message)
            lblMensage.Visible = False
            btn15.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
        CoV = ""
    End Sub

    Private Sub LimpiarCampos1()
        txtmonto2.Text = "0"
        txtcv.Text = ""
        txtdivisa.Text = ""
        txtsubto.Text = "$0"
        repetido = False
        btncompra.Enabled = True
        btnventa.Enabled = True
    End Sub

    Private Sub LimpiarCampos2()
        txtNombres.Clear()
        txtApellidos.Clear()
        txtid.Clear()
        txtNumCliente.Clear()
        txtuf.Clear()
        txtop.Clear()
        txtmnt.Clear()
        TxtTarjeta.Clear()
    End Sub

    Private Sub vbtnd4_Click(sender As Object, e As EventArgs) Handles vbtnd4.Click
        Me.Cursor = Cursors.WaitCursor
        If btn14.BackgroundImage IsNot Nothing Then
            btn14.BackgroundImage = Nothing
        End If
        precioCoV = 0
        tipdivi = 0
        dgvCoV.Rows.Clear()
        billete = -1
        CoV = ""
        LimpiarCampos1()
        btn12.Text = "0"
        HabilitaBotonesBanderas()
        InicializarVariables1()
        txtExistencias.Clear()
        txtExistenciasS.Clear()
        If dgvAux.Columns("CSugerida") IsNot Nothing And dgvAux.Columns.Count > 0 Then
            dgvAux.Columns.RemoveAt(dgvAux.Columns.Count - 1)
        End If
        If dgvAux.DataSource IsNot Nothing Then
            dgvAux.DataSource = Nothing
        End If
        dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
        dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        vbtnd5.Enabled = False
        txtmonto1.Text = "0"
        preciosCV()
        DeshabilitaCambioPrecio()
        BtnFraccionar.Enabled = False
        LimpiaBotonesDenominaciones()
        tcDivisas.SelectedIndex = 0
        ContadorBotonAum = 0
        ContadorBotomRes = 0
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub HabilitaBotonesBanderas()
        btnd1.Enabled = True
        btnd2.Enabled = True
        btnd3.Enabled = True
        btnd4.Enabled = True
        btnd5.Enabled = True
        btnd6.Enabled = True
        btnd7.Enabled = True
        btnd8.Enabled = True
    End Sub

    Private Sub btn13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btn13.KeyPress
        Select Case e.KeyChar
            Case "0"
                btn0.PerformClick()
            Case "1"
                btn1.PerformClick()
            Case "2"
                btn2.PerformClick()
            Case "3"
                btn3.PerformClick()
            Case "4"
                btn4.PerformClick()
            Case "5"
                btn5.PerformClick()
            Case "6"
                btn6.PerformClick()
            Case "7"
                btn7.PerformClick()
            Case "8"
                btn8.PerformClick()
            Case "9"
                btn9.PerformClick()
            Case ChrW(Keys.Back)
                btn10.PerformClick()
            Case ChrW(13)
                MessageBox.Show("enter")
            Case ChrW(Keys.P)
                btn15.PerformClick()
        End Select
    End Sub

    Private Sub btn13_TextChanged(sender As Object, e As EventArgs) Handles btn13.TextChanged
        If IsNumeric(btn13.Text) And billete > -1 Then
            Select Case CoV
                Case "COMPRA"
                    btn12.Text = "$" & Convert.ToDouble(btn13.Text) *
                        Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString) * precioCoV
                Case "VENTA"
                    btn12.Text = "$" & Convert.ToDouble(btn13.Text) *
                        Convert.ToDouble(dt3filtro2.Rows(billete)("valor").ToString) * precioCoV
            End Select
        End If
        If btn13.Text = "" Then
            btn12.Text = "$0"
        End If
    End Sub

    Private Sub FiltrarCliente()
        LimpiarInofoCliente2()
        oclientescnbvM.Nombre = txtNombres.Text
        oclientescnbvM.ApellidoPaterno = txtApellidos.Text
        oclientescnbvM.Tarjeta = TxtTarjeta.Text

        If (txtNombres.Text <> "" And txtNombres.Text <> nombre_aux) Or (txtApellidos.Text <> "" And txtApellidos.Text <> apellido1_aux) Then
            source1.DataSource = Nothing
            source1.DataSource = oclientescnbvC.Filtrar(oclientescnbvM, "%", "")

            dgvClientes.DataSource = source1
            dgvClientes.Columns("ApellidoPaterno").Width = 200
            dgvClientes.Columns("ApellidoMaterno").Width = 200
            dgvClientes.Columns("Nombre").Width = 200
            dgvClientes.Columns("Direccion").Width = 200
            dgvClientes.Columns("Direccion1").Width = 200
            dgvClientes.Columns("Municipio").Width = 200
            dgvClientes.Columns("Estado").Width = 200
            dgvClientes.Columns("Identificacion").Width = 200
            dgvClientes.Columns("Tarjeta").Width = 200
            dgvClientes.Columns("Fecha_Envio_P").Width = 200
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 10, FontStyle.Regular)
            dgvNoOrden(dgvClientes)
            If apellido1_aux <> txtApellidos.Text Then
                apellido1_aux = txtApellidos.Text
            End If
            If nombre_aux <> txtNombres.Text Then
                nombre_aux = txtNombres.Text
            End If
            If dgvClientes.RowCount = 0 Then
                dgvClientes.DataSource = Nothing
                nombre_aux = ""
                apellido1_aux = ""
                nombre_completo = ""
                source1.DataSource = Nothing
                source1.DataSource = oclientescnbvC.Filtrar(oclientescnbvM, "%", "")
                dgvClientes.DataSource = source1
                If dgvClientes.RowCount = 0 Then
                    MessageBox.Show("NO SE ENCUENTRA EL NOMBRE DEL CLIENTE ")
                End If
            End If

            txtApellidos.Focus()
        Else
            Dim dialog As DialogResult
            Dim form As New FrmClientes ' CapclientescnbvCoV
            form.txtID.Enabled = False
            form.lblModulo.Text += " en Compra/Venta"
            form.cove = True
            form.agre_bus = "busca"
            form.num_usux = No_cajero
            form.nom_usux = Cajero
            form.no_sucursal = No_sucursal
            form.nom_sucursal = Me.Text
            If IsNumeric(txtid.Text) Then
                form.txtNocli.Text = txtid.Text
            End If
            dialog = form.ShowDialog(Me)
            form.BringToFront()

            txtNombres.Text = form.txtNombre.Text.Trim
            txtApellidos.Text = form.txtAP.Text.Trim
            TxtTarjeta.Text = form.txtNoTarjeta.Text.Trim
            txtid.Text = form.txtID.Text.Trim
            txtNumCliente.Text = form.txtID.Text.Trim
            nombre_completo = form.txtNombre.Text.Trim & " " & form.txtAP.Text.Trim & " " & form.txtAM.Text.Trim
            If form.txtNocli.Text <> "" Then
                idcli = CInt(form.txtNocli.Text.Trim)
            Else
                idcli = 0
            End If
            infocliente()
        End If
    End Sub

    Private Sub FiltrarEmpresa()
        Dim dialog As DialogResult
        Dim form As New FrmPersonasMorales ' CapclientescnbvCoV
        form.TxtID.Enabled = False

        dialog = form.ShowDialog(Me)
        form.BringToFront()

        txtNombres.Text = form.txtRazonSocial.Text.Trim
        txtApellidos.Text = form.txtRazonSocial.Text.Trim
        'TxtTarjeta.Text = form.txtNoTarjeta.Text.Trim
        txtid.Text = form.TxtID.Text.Trim
        nombre_completo = form.txtRazonSocial.Text.Trim
        If form.TxtID.Text <> "" Then
            idcli = CInt(form.TxtID.Text.Trim)
        Else
            idcli = 0
        End If
        infoempresa()
    End Sub

    Private Sub ChequeoActivacion()
        If idcli <> "0" Then
            If oPuntos.ChecarEnvioTar(idcli) <> "" Then
                TxtTarjeta.Text = ""
                TxtTarjeta.Enabled = True
                MsgBox("El cliente tiene TARJETA VERDE, podria pasar la tarjeta en el escaner", MsgBoxStyle.Information)
            End If

            If oPuntos.ChecarEnvioTarP(idcli) <> "" Then
                txtid.Text = ""
                txtid.Enabled = True
                MsgBox("El cliente tiene TARJETA ROJA, podria pasar la tarjeta en el escaner", MsgBoxStyle.Information)
            End If
        Else
            If idcli <> "0" Then
                txtid.Text = ""
                txtid.Enabled = False
            End If
        End If
    End Sub

    Private Sub vbtna2_Click(sender As Object, e As EventArgs) Handles vbtna2.Click
        If ConTarjeta Then
            MsgBox("Ya se escaneo una Tarjeta, al entrar a Buscar tiene que volver a escanear", vbInformation)
        End If
        If ConTarjetaP Then
            MsgBox("Ya se escaneo una Tarjeta, al entrar a Buscar tiene que volver a escanear", vbInformation)
        End If
        FiltrarCliente()

        If idcli <> "0" Then
            If oPuntos.ChecarEnvioTarP(idcli) = "" Then
                txtid.Text = ""
                txtid.Enabled = False
            Else
                txtid.Enabled = False
            End If
        Else
            If idcli = "0" Then
                txtid.Text = ""
                txtid.Enabled = False
            End If
        End If

        ConTarjeta = False
        ConTarjetaP = False
        Moral = False
        TxtTarjeta.BackColor = Color.White
        txtid.BackColor = Color.White
        'If idcli <> "0" Then
        'ChequeoActivacion()
        'End If
    End Sub

    Private Sub LimpiarInofoCliente()
        txtid.Clear()
        txtuf.Clear()
        txtop.Clear()
        txtmnt.Clear()
        idcli = 0
    End Sub

    Private Sub LimpiarInofoCliente2()
        txtuf.Clear()
        txtop.Clear()
        txtmnt.Clear()
    End Sub

    Private Sub Aplicar_Filtro()
        Try
            Dim filtro As String = String.Empty
            If txtNombres.Text <> "" Then
                filtro += "[Nombre] like '" & txtNombres.Text & "%' and"
            End If
            If txtApellidos.Text <> "" Then
                filtro += "[ApellidoPaterno] like '" & txtApellidos.Text & "%' and"
            End If

            If filtro.Trim().Length > 1 Then
                filtro = filtro.Remove(filtro.Length - 3, 3)
            End If
            source1.Filter = filtro
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub txtApellidos_TextChanged(sender As Object, e As EventArgs) Handles txtApellidos.TextChanged
        If source1 IsNot Nothing Then
            ConTarjeta = False
            ConTarjetaP = False
            TxtTarjeta.BackColor = Color.White
            Aplicar_Filtro()
        End If
    End Sub

    Private Sub txtNombres_TextChanged(sender As Object, e As EventArgs) Handles txtNombres.TextChanged
        If source1 IsNot Nothing Then
            ConTarjeta = False
            ConTarjetaP = False
            TxtTarjeta.BackColor = Color.White
            Aplicar_Filtro()
        End If
    End Sub

#Region "Calcular Existencias2"
    Private Sub Existencias2()
        Dim otinventarioM As New tinventarioM
        Dim otinventario2C As New tinventario2C
        Dim dt1x, dt2x, dt2filtrox, dt3x As New DataTable
        dt1x = odivisasC.Sdivisas2.Tables(0)
        odivisasC.LiberarDS()
        dt2x = otipodivisasC.Stipodivisas2(No_sucursal).Tables(0)
        otipodivisasC.LiberarDS()
        otinventario2C.EliminaInventario()
        Dim entrada, salida, te, ts As Integer
        Dim saldoi, saldof, cprom, tcan, ttot As Double
        Dim otransferDC As New transferDC
        oremisioDC.LiberarDS()
        entrada = 0
        salida = 0
        te = 0
        ts = 0
        saldoi = 0
        saldof = 0
        cprom = 0
        tcan = 0
        ttot = 0

        If otinventario2C.VerificarRegistros() > 0 Then
            If otinventario2C.VerificarFecha < DateTime.Now.ToShortDateString Then
                otinventario2C.CambiaSiporSF()
            End If

            For i As Integer = 0 To dt1x.Rows.Count - 1
                tcan = oremisioDC.CantDivisasC1(dt1x.Rows(i)("codigo").ToString, New DateTime(Now.Date.Year, 1, 1), Now.Date, No_sucursal)
                ttot = oremisioDC.TotDivisasC2(dt1x.Rows(i)("codigo").ToString, New DateTime(Now.Date.Year, 1, 1), Now.Date, No_sucursal)
                If tcan > 0 Then
                    cprom = ttot / Convert.ToDouble(tcan)
                    cprom = Decimal.Round(Convert.ToDecimal(cprom), 2)
                End If
                odivisasC.Mcpromedio(dt1x.Rows(i)("codigo").ToString, cprom)
            Next
            otinventarioM.codigo = Nothing
            Dim tipo As Integer
            entrada = 0
            salida = 0
            te = 0
            ts = 0
            saldoi = 0
            saldof = 0
            cprom = 0
            tcan = 0
            ttot = 0
            'el segundo for, en funcionamiento primero se saca el saldo inicial, luego las entradas, salidas, ts, te de hoy y se restan
            For i As Integer = 0 To dt1x.Rows.Count - 1
                dt2filtrox = Nothing
                tipo = Convert.ToInt32(dt1x.Rows(i)("tipo").ToString)
                dt2filtrox = dt2x.Select("tipo = " & tipo, "tipo").CopyToDataTable

                entrada = oremisioDC.CantDivisasC6(dt1x.Rows(i)("codigo").ToString, Now.Date, No_sucursal) '/ Convert.ToInt32(dt1x.Rows(i)("valor").ToString)
                salida = oremisioDC.CantDivisasV7(dt1x.Rows(i)("codigo").ToString, Now.Date, No_sucursal) '/ Convert.ToInt32(dt1x.Rows(i)("valor").ToString)
                te = otransferDC.CantDivisasC6(dt1x.Rows(i)("codigo").ToString, Now.Date, No_sucursal)
                ts = otransferDC.CantDivisasV7(dt1x.Rows(i)("codigo").ToString, Now.Date, No_sucursal)

                cprom = 0
                saldoi = 0
                saldof = 0

                saldoi = otinventario2C.si(dt1x.Rows(i)("codigo").ToString)

                If entrada >= 0 And (salida >= 0 Or salida <= 0) Then
                    cprom = Convert.ToDouble(dt2filtrox.Rows(0)("Compra").ToString)
                    saldof = (saldoi + entrada - salida)
                    cprom = Decimal.Round(Convert.ToDecimal(cprom), 2)
                End If

                If te >= 0 And (ts >= 0 Or ts <= 0) Then
                    If saldof > 0 Then
                        saldof = saldof + te - ts
                    Else
                        saldof = saldoi + te - ts
                    End If
                End If

                otinventarioM.codigo = dt1x.Rows(i)("codigo").ToString
                otinventarioM.en = entrada
                otinventarioM.sal = salida
                otinventarioM.sf = saldof
                otinventarioM.cpromedio = cprom
                otinventarioM.te = te
                otinventarioM.ts = ts
                otinventario2C.Modifica2(otinventarioM)
                otinventarioM.en = Nothing
                otinventarioM.sal = Nothing
                otinventarioM.sf = Nothing
                otinventarioM.cpromedio = Nothing
                otinventarioM.te = Nothing
                otinventarioM.ts = Nothing
            Next
            dt5Existencias = Nothing
            dt5Existencias = New DataTable
            dt5Existencias = otinventario2C.Existencia
            otinventario2C.LiberarDt()
            dt1x.Dispose()
            dt2x.Dispose()
            dt2filtrox.Dispose()
            dt3x.Dispose()
            otransferDC.Dispose()

        Else

            For i As Integer = 0 To dt1x.Rows.Count - 1
                tcan = oremisioDC.CantDivisasC1(dt1x.Rows(i)("codigo").ToString, New DateTime(Now.Date.Year, 1, 1), Now.Date, No_sucursal)
                ttot = oremisioDC.TotDivisasC2(dt1x.Rows(i)("codigo").ToString, New DateTime(Now.Date.Year, 1, 1), Now.Date, No_sucursal)
                If tcan > 0 Then
                    cprom = ttot / Convert.ToDouble(tcan)
                    cprom = Decimal.Round(Convert.ToDecimal(cprom), 2)
                End If
                odivisasC.Mcpromedio(dt1x.Rows(i)("codigo").ToString, cprom)
                otinventarioM.codigo = dt1x.Rows(i)("codigo").ToString
                otinventario2C.Alta(otinventarioM)
            Next
            otinventarioM.codigo = Nothing
            Dim tipo As Integer
            Dim divi As String
            For i As Integer = 0 To dt1x.Rows.Count - 1
                dt2filtrox = Nothing
                tipo = Convert.ToInt32(dt1x.Rows(i)("tipo").ToString)
                dt2filtrox = dt2x.Select("tipo = " & tipo, "tipo").CopyToDataTable
                divi = dt1x.Rows(i)("codigo").ToString
                entrada = oremisioDC.CantDivisasC3(dt1x.Rows(i)("codigo").ToString, New DateTime(Now.Date.Year, 1, 1), Now.Date, No_sucursal)
                salida = oremisioDC.CantDivisasV4(dt1x.Rows(i)("codigo").ToString, New DateTime(Now.Date.Year, 1, 1), Now.Date, No_sucursal)
                te = otransferDC.CantDivisasC3(dt1x.Rows(i)("codigo").ToString, New DateTime(Now.Date.Year, 1, 1), Now.Date, No_sucursal)
                ts = otransferDC.CantDivisasV4(dt1x.Rows(i)("codigo").ToString, New DateTime(Now.Date.Year, 1, 1), Now.Date, No_sucursal)

                cprom = 0
                saldoi = 0
                saldof = 0

                If entrada >= 0 And (salida >= 0 Or salida <= 0) Then
                    cprom = Convert.ToDouble(dt2filtrox.Rows(0)("Compra").ToString)
                    saldoi = (entrada - salida)
                    cprom = Decimal.Round(Convert.ToDecimal(cprom), 2)
                End If

                If te >= 0 And (ts >= 0 Or ts <= 0) Then
                    saldoi = saldoi + (te - ts)
                End If
                otinventarioM.codigo = dt1x.Rows(i)("codigo").ToString
                otinventarioM.si = saldoi * Convert.ToInt32(dt1x.Rows(i)("valor").ToString)
                otinventarioM.cpromedio = cprom
                otinventario2C.Modifica2(otinventarioM)
                otinventarioM.codigo = Nothing
                otinventarioM.si = Nothing
                otinventarioM.cpromedio = Nothing
            Next
            entrada = 0
            salida = 0
            te = 0
            ts = 0
            saldoi = 0
            saldof = 0
            cprom = 0
            tcan = 0
            ttot = 0
            'el segundo for, en funcionamiento primero se saca el saldo inicial, luego las entradas, salidas, ts, te de hoy y se restan
            For i As Integer = 0 To dt1x.Rows.Count - 1
                dt2filtrox = Nothing
                tipo = Convert.ToInt32(dt1x.Rows(i)("tipo").ToString)
                dt2filtrox = dt2x.Select("tipo = " & tipo, "tipo").CopyToDataTable
                Dim divi2 As String
                divi2 = dt1x.Rows(i)("codigo").ToString
                entrada = oremisioDC.CantDivisasC6(dt1x.Rows(i)("codigo").ToString, Now.Date, No_sucursal) * Convert.ToInt32(dt1x.Rows(i)("valor").ToString)
                salida = oremisioDC.CantDivisasV7(dt1x.Rows(i)("codigo").ToString, Now.Date, No_sucursal) * Convert.ToInt32(dt1x.Rows(i)("valor").ToString)
                te = otransferDC.CantDivisasC6(dt1x.Rows(i)("codigo").ToString, Now.Date, No_sucursal) * Convert.ToInt32(dt1x.Rows(i)("valor").ToString)
                ts = otransferDC.CantDivisasV7(dt1x.Rows(i)("codigo").ToString, Now.Date, No_sucursal) * Convert.ToInt32(dt1x.Rows(i)("valor").ToString)

                cprom = 0
                saldoi = 0
                saldof = 0

                saldoi = otinventario2C.si(dt1x.Rows(i)("codigo").ToString)

                If entrada >= 0 And (salida >= 0 Or salida <= 0) Then
                    cprom = Convert.ToDouble(dt2filtrox.Rows(0)("Compra").ToString)
                    saldof = ((saldoi / 1) + entrada - salida)
                    cprom = Decimal.Round(Convert.ToDecimal(cprom), 2)
                End If

                If te >= 0 And (ts >= 0 Or ts <= 0) Then
                    saldof = saldof + te - ts
                End If

                otinventarioM.codigo = dt1x.Rows(i)("codigo").ToString
                otinventarioM.en = entrada '* Convert.ToInt32(dt1x.Rows(i)("valor").ToString) 'eli
                otinventarioM.sal = salida '* Convert.ToInt32(dt1x.Rows(i)("valor").ToString) 'eli
                otinventarioM.sf = saldof '* Convert.ToInt32(dt1x.Rows(i)("valor").ToString)  'eli
                otinventarioM.cpromedio = cprom
                otinventarioM.te = te
                otinventarioM.ts = ts
                otinventario2C.Modifica2(otinventarioM)
                otinventarioM.en = Nothing
                otinventarioM.sal = Nothing
                otinventarioM.sf = Nothing
                otinventarioM.cpromedio = Nothing
                otinventarioM.te = Nothing
                otinventarioM.ts = Nothing
            Next
        End If
        dt5Existencias = Nothing
        dt5Existencias = New DataTable
        dt5Existencias = otinventario2C.Existencia
        otinventario2C.LiberarDt()
        dt1x.Dispose()
        dt2x.Dispose()
        dt2filtrox.Dispose()
        dt3x.Dispose()
        otransferDC.Dispose()
    End Sub

    Private Sub Existencias1()
        dt5Existencias = oExistenciaC.ExistenciaHoy(Date.Now.ToShortDateString, No_sucursal)
        oExistenciaC.LiberarDt()

    End Sub

    Private Sub ExistenciasDivisa()
        dtExistenciaDiv = oExistenciaC.ExistenciaDivisa(Date.Now.ToShortDateString, No_sucursal, tipdivi)
        oExistenciaC.LiberarDt()

    End Sub
#End Region

    Private Sub FiltraMe(ByVal tipo As Integer)
        dt2filtro.Clear()
        dt2filtro = Nothing
        dt2filtro = New DataTable
        dt2filtro = dt2.Select("tipo = " & tipo, "tipo,valor").CopyToDataTable
        dt2filtro.Columns.Add("Existencia", Type.GetType("System.Int32"))
    End Sub

    Private Sub FiltrarExistencia2(ByVal tipo As Integer)
        Dim cell1 As DataGridViewCell = Nothing
        Dim existenciass As Integer = 0
        Dim valores1, valores2, valores3 As String
        For i As Integer = 0 To dt2filtro.Rows.Count - 1
            For f As Integer = 0 To dt5Existencias.Rows.Count - 1
                'If dt2filtro.Rows(i)("codigo").ToString = dt5Existencias.Rows(f)("codigo").ToString Then
                If dt2filtro.Rows(i)("codigo").ToString = dt5Existencias.Rows(f)("divisa").ToString Then

                    valores2 = dt2filtro.Rows(i)("valor").ToString
                    valores1 = dt5Existencias.Rows(f)("sf").ToString
                    valores3 = dt5Existencias.Rows(f)("si").ToString
                    'existenciass = Convert.ToInt32(dt5Existencias.Rows(f)("sf").ToString) / Convert.ToInt32(dt2filtro.Rows(i)("valor").ToString)
                    existenciass = Convert.ToInt32(dt5Existencias.Rows(f)("sf").ToString)
                    dt2filtro.Rows(i)("Existencia") = existenciass

                    If dt2filtro.Rows(i)("Existencia") IsNot Nothing Then
                        If Convert.ToInt32(dt2filtro.Rows(i)("Existencia").ToString) <= 0 Or dt2filtro.Rows(i)("Existencia").ToString = "" Then
                            Select Case i
                                Case 0
                                    btnb1.Enabled = False
                                Case 1
                                    btnb2.Enabled = False
                                Case 2
                                    btnb3.Enabled = False
                                Case 3
                                    btnb4.Enabled = False
                                Case 4
                                    btnb5.Enabled = False
                                Case 5
                                    btnb6.Enabled = False
                                Case 6
                                    btnb7.Enabled = False
                            End Select
                        Else
                            Select Case i
                                Case 0
                                    btnb1.Enabled = True
                                Case 1
                                    btnb2.Enabled = True
                                Case 2
                                    btnb3.Enabled = True
                                Case 3
                                    btnb4.Enabled = True
                                Case 4
                                    btnb5.Enabled = True
                                Case 5
                                    btnb6.Enabled = True
                                Case 6
                                    btnb7.Enabled = True
                            End Select
                        End If
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub Remision(ByVal accion As String)
        Select Case accion
            Case "A"

                Try
                    AsignaRemision()

                Catch ex As Exception
                    MessageBox.Show("INCORRECTO, FALTA UN TOTAL, NO PUEDE GUARDAR SI NO HAY CANTIDADES EN LA TABLA DE COMPRA / VENTA DE DIVISAS" + Chr(13) &
                                    "SI NO ES EL CASO ENTONCES HAY UN ERROR DE SISTEMA")
                End Try
            Case "B"
            Case "C"
                AsignaRemision()
                If oremisioMC.MremisioM(oremisioMM, oremisioMM2) > 0 Then
                    MessageBox.Show("HECHO")
                End If
            Case "S1"
                oremisioMM.folio_factura = txtFolio.Text.Trim
                oremisioMM.Nosucursal = No_sucursal
                oremisioMM2 = oremisioMC.S1remisioM(oremisioMM)
            Case "S"
        End Select
    End Sub

    Private Sub AsignaCAJA()
        oCAJAM.Fecha = Now.Date
        Select Case CoV
            Case "COMPRA"
                oCAJAM.movimiento = "17"
                oCAJAM.tipo = "S"
                oCAJAM.Referencia = "Compra de DIVISAS "
            Case "VENTA"
                oCAJAM.movimiento = "11"
                oCAJAM.tipo = "E"
                oCAJAM.Referencia = "Venta de DIVISAS "
        End Select
        If nombre_completo = "" Then
            MessageBox.Show("NO detecto el nombre") 'este
        End If
        oCAJAM.Referencia = nombre_completo
        oCAJAM.BC = "C"
        oCAJAM.Folio = txtFolio.Text
        oCAJAM.TOTAL = oremisioMM.stotal
        oCAJAM.valor = "0"
        oCAJAM.sucursal = No_sucursal
    End Sub

    Private Sub AsignaRemision()
        'dtpFecha.Value = DateTime.Now
        Dim stotal As String
        oremisioMM.folio_factura = txtFolio.Text.Trim
        oremisioMM.fecha = Now.Date
        oremisioMM.tipo = "DIVISAS"
        oremisioMM.cliente = idcli
        oremisioMM.vendedor = 0
        If ConTarjeta Then
            oremisioMM.vendedor = 1
        End If
        If ConTarjetaP Then
            oremisioMM.vendedor = 1
        End If
        oremisioMM.moneda = tipdivi
        oremisioMM.condiciones = txtdivisa.Text
        oremisioMM.estatus = "1"
        If cambio Then
            stotal = Convert.ToDouble(txtsubto.Text.Trim.Replace("$", "")).ToString
        Else
            If CInt(btn12.Text.Trim.Replace("$", "")) > 0 Then
                stotal = Convert.ToDouble(btn12.Text.Trim.Replace("$", "")).ToString
            Else
                stotal = (Val(Convert.ToDouble(txtmonto2.Text.Trim.Replace("$", "")) * precioCoV)).ToString
            End If
        End If

        oremisioMM.stotal = FormatNumber(Convert.ToDouble(stotal), 2)

        If oremisioMM.stotal = 0 Then
            For Each divisa As DataGridViewRow In dgvAux.Rows
                oremisioMM.stotal += FormatNumber(Convert.ToDouble(dgvAux.Rows(divisa.Index).Cells("Importe").Value.ToString), 2)
            Next
            MessageBox.Show("ERROR NO SE TOMÓ EL TOTAL DE LA OPERACIÓN")
        End If

        oremisioMM.iva = 0
        oremisioMM.total = FormatNumber(oremisioMM.stotal, 2)
        oremisioMM.observaciones = CoV.ToUpper
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
        oremisioMM.Nosucursal = No_sucursal
        Select Case CoV
            Case "COMPRA"
                If operacion_especial = True And precioCoV <> Convert.ToDouble(dt1.Rows(tipdivi - 1)("Compra").ToString) Then
                    oremisioMM.precio_especial = "SI"
                Else
                    oremisioMM.precio_especial = ""
                End If
            Case "VENTA"
                If operacion_especial = True And precioCoV <> Convert.ToDouble(dt1.Rows(tipdivi - 1)("Venta").ToString) Then
                    oremisioMM.precio_especial = "SI"
                Else
                    oremisioMM.precio_especial = ""
                End If
        End Select
        If dgvCoV.Rows(0).Cells("codigo").Value.ToString = "D100" And dgvCoV.Rows.Count = 1 Then
            oremisioMM.precio_especial = "SI"
        End If
        If cambio Then
            oremisioMM.cambio = "SI"
        Else
            oremisioMM.cambio = "NO"
        End If
    End Sub

    Private Sub DetallesRemision()
        Dim valor As String
        'Dim ruta As String = "D:\LogInserts\insertardetalle.txt"
        'Dim escritor As StreamWriter
        'escritor = File.AppendText(ruta)
        Select Case CoV
            Case "COMPRA"
                For denominacion As Integer = 0 To dgvCoV.Rows.Count - 1
                    If dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString <> "" And
                        dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString <> "" Then
                        valor = dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString
                        valor = valor.Replace("C", "")
                        valor = valor.Replace("D", "")
                        valor = valor.Replace("E", "")
                        valor = valor.Replace("L", "")
                        valor = valor.Replace("Y", "")
                        valor = valor.Replace("J", "")
                        valor = valor.Replace("F", "")
                        valor = valor.Replace("A", "")
                        If cambio Then
                            CargaCambio(oremisioMM.folio_factura, dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString,
                                        Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString) * Convert.ToDouble(valor),
                                        dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString, dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString & " billetes de " & dgvCoV.Rows(denominacion).Cells("Nombre").Value.ToString)
                        End If
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
                        oremisioDM.Nosucursal = No_sucursal
                        oremisioDM.fecha = Format(Now.Date, "dd/MM/yyyy") 'dtpFecha.Value.ToShortDateString
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
                            'escritor.WriteLine(Cadena)
                            'escritor.Flush()
                            cmd = New SqlCommand(Cadena, conn.con)
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
                        cmd = New SqlCommand(Cadena, conn.con)
                        cmd.Transaction = Trans
                        cmd.ExecuteNonQuery()

                        Cadena = ""
                        Cadena = Cadena & "UPDATE "
                        Cadena = Cadena & " Existencia "
                        Cadena = Cadena & "SET "
                        Cadena = Cadena & " precio = " & Convert.ToDouble(dt1.Rows(tipdivi - 1)("Compra").ToString) & " "
                        Cadena = Cadena & "WHERE "
                        Cadena = Cadena & " fecha = '" & oremisioDM.fecha.ToString("dd/MM/yyyy") & "' AND "
                        Cadena = Cadena & " nosucursal = '" & NoSucursal & "' AND "
                        Cadena = Cadena & " tipo = " & tipdivi
                        cmd = New SqlCommand(Cadena, conn.con)
                        cmd.Transaction = Trans
                        cmd.ExecuteNonQuery()
                        valor = ""
                    End If
                Next
            Case "VENTA"
                For denominacion As Integer = 0 To dgvCoV.Rows.Count - 1
                    If dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString <> "" And
                        dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString <> "" Then
                        If oremisioMM.folio_factura IsNot Nothing Then
                            oremisioDM.folio_factura = oremisioMM.folio_factura
                        Else
                            oremisioDM.folio_factura = oremisioMC.UFolioRemision(No_sucursal)
                        End If
                        oremisioDM.folio_factura = oremisioMM.folio_factura
                        oremisioDM.producto = dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString
                        valor = dgvCoV.Rows(denominacion).Cells("codigo").Value.ToString
                        valor = valor.Replace("C", "")
                        valor = valor.Replace("D", "")
                        valor = valor.Replace("E", "")
                        valor = valor.Replace("L", "")
                        valor = valor.Replace("Y", "")
                        valor = valor.Replace("J", "")
                        valor = valor.Replace("F", "")
                        valor = valor.Replace("A", "")
                        oremisioDM.cantidads = Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString) * Convert.ToDouble(valor)
                        oremisioDM.p_unitario = Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString) _
                        / (Convert.ToDouble(valor) * Convert.ToDouble(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString))

                        oremisioDM.stotal = dgvCoV.Rows(denominacion).Cells("Importe").Value.ToString
                        oremisioDM.descuento = 0
                        oremisioDM.capacidad = "1"
                        oremisioDM.unidad = "1"
                        oremisioDM.descripcion_larga = dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString & " billetes de " & dgvCoV.Rows(denominacion).Cells("Nombre").Value.ToString
                        oremisioDM.Nosucursal = No_sucursal
                        oremisioDM.fecha = Format(Now.Date, "dd/MM/yyyy") ' dtpFecha.Value.ToShortDateString
                        oremisioDM.operacion = "V"

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
                        Cadena = Cadena & "'" & oremisioDM.descuento & "', "
                        Cadena = Cadena & "'" & oremisioDM.capacidad & "', "
                        Cadena = Cadena & "'" & oremisioDM.unidad & "', "
                        Cadena = Cadena & "'" & oremisioDM.descripcion_larga & "', "
                        Cadena = Cadena & "'" & oremisioDM.Nosucursal & "', "
                        Cadena = Cadena & "'" & oremisioDM.fecha.ToString("dd/MM/yyyy") & "', "
                        Cadena = Cadena & "'" & oremisioDM.operacion & "')"

                        'escritor.WriteLine(Cadena)
                        'escritor.Flush()

                        cmd = New SqlCommand(Cadena, conn.con)
                        cmd.Transaction = Trans
                        cmd.ExecuteNonQuery()


                        Cadena = ""
                        Cadena = Cadena & "UPDATE "
                        Cadena = Cadena & " Existencia "
                        Cadena = Cadena & "SET "
                        Cadena = Cadena & " sal = sal + " & Convert.ToInt32(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString) & ", "
                        Cadena = Cadena & " sf = sf - " & Convert.ToInt32(dgvCoV.Rows(denominacion).Cells("Cantidad").Value.ToString) & ", "
                        Cadena = Cadena & " precio = " & Convert.ToDouble(dt1.Rows(tipdivi - 1)("Compra").ToString) & " "
                        Cadena = Cadena & "WHERE "
                        Cadena = Cadena & " fecha = '" & oremisioDM.fecha.ToString("dd/MM/yyyy") & "' AND "
                        Cadena = Cadena & " nosucursal = '" & oremisioDM.Nosucursal & "' AND "
                        Cadena = Cadena & " divisa = '" & oremisioDM.producto & "'"
                        cmd = New SqlCommand(Cadena, conn.con)
                        cmd.Transaction = Trans
                        cmd.ExecuteNonQuery()

                        Cadena = ""
                        Cadena = Cadena & "UPDATE "
                        Cadena = Cadena & " Existencia "
                        Cadena = Cadena & "SET "
                        Cadena = Cadena & " precio = " & Convert.ToDouble(dt1.Rows(tipdivi - 1)("Compra").ToString) & " "
                        Cadena = Cadena & "WHERE "
                        Cadena = Cadena & " fecha = '" & oremisioDM.fecha.ToString("dd/MM/yyyy") & "' AND "
                        Cadena = Cadena & " nosucursal = '" & NoSucursal & "' AND "
                        Cadena = Cadena & " tipo = " & tipdivi
                        cmd = New SqlCommand(Cadena, conn.con)
                        cmd.Transaction = Trans
                        cmd.ExecuteNonQuery()
                        valor = ""
                    End If
                Next
        End Select
        'escritor.Close()
        'escritor.Dispose()
    End Sub

    Private Sub CargaCambio(ByVal folioFact As Integer, ByVal productoEnt As String, ByVal Cantidad As Double, ByVal importeEnt As Double, ByVal descripcionEnt As String)
        Dim EntroCambio As Boolean = False
        Dim CantidadEnt As Double = 0
        Dim Precio_UEnt As Double = 0
        Dim TotalsEnt As Double = 0
        Try
            Conexion()
            cone.Open()

            Dim Sql As String = "SELECT * FROM remisioCA_DET WHERE folio_factura = '" & folioFact & "' and Nosucursal = '" & No_sucursal & "'"

            cmd = New SqlCommand(Sql, cone)
            lector = cmd.ExecuteReader()
            While lector.Read
                EntroCambio = True

                CantidadEnt += Convert.ToDouble(lector("cantidads"))
                Precio_UEnt = Convert.ToDouble(lector("p_unitario"))

                TotalsEnt += CDbl(lector("stotal"))

            End While

            If EntroCambio Then
                oremisioDM.folio_factura = folioFact
                oremisioDM.producto = productoEnt 'lector("producto").ToString

                oremisioDM.cantidads = Convert.ToDouble(Cantidad - CantidadEnt)
                oremisioDM.p_unitario = Convert.ToDouble(Precio_UEnt)
                oremisioDM.stotal = CDbl(importeEnt - TotalsEnt)
                oremisioDM.descuento = 0
                oremisioDM.capacidad = "1"
                oremisioDM.unidad = "1"
                oremisioDM.descripcion_larga = descripcionEnt 'lector("descripcion_larga").ToString
                oremisioDM.Nosucursal = No_sucursal
                oremisioDM.fecha = Now.Date 'dtpFecha.Value.ToShortDateString
                oremisioDM.operacion = "C"
                oremisioDC.AremisioD(oremisioDM)
            End If

            cone.Close()
        Catch ex As Exception
            cone.Close()
            MsgBox("Error: " & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub dgvClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellDoubleClick
        Dim idx, nombresx, apellidos1x, apellidos2x, tarjeta3x As String
        Dim fechaenvpx As String
        idx = dgvClientes.CurrentRow.Cells("cliente").Value.ToString()
        nombresx = dgvClientes.CurrentRow.Cells("Nombre").Value.ToString()
        apellidos1x = dgvClientes.CurrentRow.Cells("ApellidoPaterno").Value.ToString()
        apellidos2x = dgvClientes.CurrentRow.Cells("ApellidoMaterno").Value.ToString()
        tarjeta3x = dgvClientes.CurrentRow.Cells("Tarjeta").Value.ToString()
        fechaenvpx = dgvClientes.CurrentRow.Cells("Fecha_Envio_P").Value.ToString()
        txtApellidos.Text = apellidos1x
        LimpiarCampos2()
        LimpiarCampos1()
        txtid.Text = idx
        txtNombres.Text = nombresx
        txtApellidos.Text = apellidos1x
        TxtTarjeta.Text = tarjeta3x
        nombre_aux = nombresx
        apellido1_aux = apellidos1x
        nombre_completo = nombre_aux & " " & apellido1_aux & " " & apellidos2x
        If oPersonasPoliticasEC.PersonaBF(nombre_aux, apellido1_aux, apellidos2x) > 0 Then
            Dim notificacion As New FrmNotificacionPersonasBloqueadas
            notificacion.ShowDialog()
            If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                pnlOperaciones.Enabled = False
                PictureBox1.Enabled = False
                'pnlCalculadora.Enabled = False
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
                Exit Sub
            End If
        End If
        If oPersonasPoliticasEC.PersonaPE(nombre_aux, apellido1_aux, apellidos2x) > 0 Or oPersonasPoliticasEC.PersonaPEEx(nombre_aux, apellido1_aux, apellidos2x) > 0 Then
            Dim notificacion As New FrmNotificacionPersonasPoliticas
            notificacion.ShowDialog()
            If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                pnlOperaciones.Enabled = False
                PictureBox1.Enabled = False
                'pnlCalculadora.Enabled = False
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
                Exit Sub
            End If
        End If
        If oPersonasPoliticasEC.ListaInt(nombre_aux, apellido1_aux, apellidos2x) > 0 Or oPersonasPoliticasEC.ListaOFAC(nombre_aux, apellido1_aux, apellidos2x) > 0 Then
            Dim notificacion As New FrmNotificacionPersBloqListaInt
            notificacion.ShowDialog()
            If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                pnlOperaciones.Enabled = False
                PictureBox1.Enabled = False
                Exit Sub
            End If
        End If
        idcli = CInt(idx)
        infocliente()
        If fechaenvpx = "" Then
            txtid.Text = ""
            txtid.Enabled = False
        Else
            txtid.Enabled = False
        End If
    End Sub

    Private Sub SumarizaExistencia()
        sumadivex = 0
        partemayor = 0
        partemenor = 0
        cantbilletes = 0
        txtExistencias.Clear()
        txtExistenciasS.Clear()
        For Each row As DataGridViewRow In dgvAux.Rows
            If dgvAux.Rows(row.Index).Cells("Existencia").Value IsNot Nothing Then
                If dgvAux.Rows(row.Index).Cells("Existencia").Value.ToString() <> Nothing And IsNumeric(dgvAux.Rows(row.Index).Cells("Existencia").Value.ToString()) Then
                    If dgvAux.Rows(row.Index).Cells("Existencia").Value.ToString() <> Nothing Then
                        sumadivex += Convert.ToDecimal(row.Cells("Existencia").Value) * Convert.ToDecimal(row.Cells("valor").Value) * precioCoV
                        Select Case Convert.ToInt32(dgvAux.Rows(row.Index).Cells("valor").Value.ToString())
                            Case Is < 50
                                partemenor += Convert.ToDecimal(row.Cells("Existencia").Value) * Convert.ToDecimal(row.Cells("valor").Value) * precioCoV
                                cantbilletes += Convert.ToDecimal(row.Cells("Existencia").Value) * Convert.ToDecimal(row.Cells("valor").Value)

                            Case Is >= 50
                                partemayor += Convert.ToDecimal(row.Cells("Existencia").Value) * Convert.ToDecimal(row.Cells("valor").Value) * precioCoV
                                cantbilletes += Convert.ToDecimal(row.Cells("Existencia").Value) * Convert.ToDecimal(row.Cells("valor").Value)
                        End Select
                    End If
                End If
            End If
        Next
        txtExistencias.BringToFront()
        txtExistenciasS.BringToFront()
        txtExistencias.Text = FormatNumber(cantbilletes.ToString, 0) & " en billetes"
        If precioCoV > 0 Then
            txtExistenciasS.Text = "$" & FormatNumber((cantbilletes * precioCoV).ToString, 2) ' "Exist.$" & FormatNumber((cantbilletes * precioCoV).ToString, 2)
        Else
            txtExistenciasS.Text = "$" & FormatNumber((cantbilletes * precioC).ToString, 2) '"Exist.$" & FormatNumber((cantbilletes * precioC).ToString, 2)
        End If

        If CoV = "COMPRA" Or CoV = "" Then
            txtExistencias.Clear()
            txtExistenciasS.Clear()
        End If
    End Sub

    Private Sub txtcd1_TextChanged(sender As Object, e As EventArgs)
        If txtcd1.Text <> "" And Convert.ToDouble(txtcd1.Text.Trim) > 0 Then
            precioC = Convert.ToDouble(txtcd1.Text.Trim)
        Else
            MessageBox.Show("NO se le ha asignado valor a divisa1")
        End If
    End Sub

    Private Sub txtcd2_TextChanged(sender As Object, e As EventArgs)
        If txtcd2.Text <> "" And Convert.ToDouble(txtcd2.Text.Trim) > 0 Then
            precioC = Convert.ToDouble(txtcd2.Text.Trim)
        Else
            MessageBox.Show("NO se le ha asignado valor a divisa2")
        End If
    End Sub

    Private Sub txtcd3_TextChanged(sender As Object, e As EventArgs)
        If txtcd3.Text <> "" And Convert.ToDouble(txtcd3.Text.Trim) > 0 Then
            precioC = Convert.ToDouble(txtcd3.Text.Trim)
        Else
            MessageBox.Show("NO se le ha asignado valor a divisa3")
        End If
    End Sub

    Private Sub txtcd4_TextChanged(sender As Object, e As EventArgs)
        If txtcd4.Text <> "" And Convert.ToDouble(txtcd4.Text.Trim) > 0 Then
            precioC = Convert.ToDouble(txtcd4.Text.Trim)
        Else
            MessageBox.Show("NO se le ha asignado valor a divisa4")
        End If
    End Sub

#Region "PEDIDO SUGERIDO"
    Private Sub vbtnd5_Click(sender As Object, e As EventArgs) Handles vbtnd5.Click
        If Convert.ToDouble(txtsubto.Text.Trim.Replace("$", "")) > sumadivex Then
            MessageBox.Show("NO HAY SUFICIENTES DIVISAS PARA EFECTUAR LA OPERACIÓN")
        Else
            If dgvAux.Columns("CSugerida") Is Nothing And dgvAux.Columns.Count > 0 Then
                dgvCoV.EnableHeadersVisualStyles = False
                dgvCoV.ColumnHeadersHeight = 60
                dgvAux.Columns.Add("CSugerida", "CSugerida")
                dgvAux.Columns("CSugerida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
            Dim mitad1, mitad2, valor As Integer
            Dim cantidad, existencia As Integer
            Dim division2, division1, div, residuo As Double

            cantidad = Convert.ToDouble(txtmonto1.Text.Trim.Replace("$", ""))

            div = (cantidad) / 2
            mitad1 = Int(div)
            mitad2 = Int(div)
            If Int(div) <> div Then
                mitad2 += 1
            End If

            If mitad1 > (partemenor / precioCoV) Then 'And partemayor > mitad1 Then
                residuo += mitad1 - (partemenor / precioCoV)
                mitad1 = (partemenor / precioCoV)
                mitad2 += residuo
            End If
            If mitad2 > (partemayor / precioCoV) Then ' And partemenor > mitad2 Then
                residuo += mitad2 - (partemayor / precioCoV)
                mitad2 = (partemayor / precioCoV)
                mitad1 += residuo
            End If

            Dim decena As Integer = 0
            decena = Convert.ToInt32(Microsoft.VisualBasic.Right(mitad2.ToString, 2))
            If decena > 0 And decena <> 100 Then
                decena = 100 - decena
                mitad1 -= decena
                mitad2 += decena
            End If

            If cantidad > 0 And cantidad < 50 Then
                mitad1 = cantidad
                mitad2 = 0
            ElseIf cantidad >= 50 And cantidad < 100 Then
                mitad1 = cantidad - 50
                mitad2 = cantidad - mitad1
            End If

            Dim CountDivisasMe As Integer = 0
            Dim CountDivisasMa As Integer = 0
            Dim ExistenciaD1 As Integer = 0
            Dim ExistenciaD5 As Integer = 0
            Dim ExistenciaD10 As Integer = 0
            Dim ExistenciaD20 As Integer = 0
            Dim ExistenciaD50 As Integer = 0
            Dim ExistenciaD100 As Integer = 0
            Dim mitad1N As Double = 0
            Dim Auxmitad1N As Double = 0
            Dim BandD1 As Boolean = False
            Dim BandD5 As Boolean = False
            Dim BandD10 As Boolean = False
            Dim BandD20 As Boolean = False
            Dim BandD50 As Boolean = False
            Dim BandD100 As Boolean = False
            'fin
            If tipdivi = 1 Then

                For x As Integer = 0 To dgvAux.Rows.Count - 1
                    Select Case Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("valor").Value)
                        Case 1
                            If Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("Existencia").Value) <= 10 Then
                                ExistenciaD1 = Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("Existencia").Value) * Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("valor").Value)
                            Else
                                ExistenciaD1 = 10 * Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("valor").Value)
                            End If

                            If ExistenciaD1 > 0 Then
                                CountDivisasMe += 1
                                BandD1 = True
                            End If
                        Case 5
                            If Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("Existencia").Value) <= 15 Then
                                ExistenciaD5 = Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("Existencia").Value) * Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("valor").Value)
                            Else
                                ExistenciaD5 = 15 * Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("valor").Value)
                            End If

                            If ExistenciaD5 > 0 Then
                                CountDivisasMe += 1
                                BandD5 = True
                            End If
                        Case 10
                            ExistenciaD10 = Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("Existencia").Value) * Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("valor").Value)
                            If ExistenciaD10 > 0 Then
                                CountDivisasMe += 1
                                BandD10 = True
                            End If
                        Case 20
                            ExistenciaD20 = Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("Existencia").Value) * Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("valor").Value)
                            If ExistenciaD20 > 0 Then
                                CountDivisasMe += 1
                                BandD20 = True
                            End If
                        Case 50
                            ExistenciaD50 = Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("Existencia").Value) * Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("valor").Value)
                            If ExistenciaD50 > 0 Then
                                CountDivisasMa += 1
                                BandD50 = True
                            End If
                        Case 100
                            ExistenciaD100 = Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("Existencia").Value) * Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("valor").Value)
                            If ExistenciaD100 > 0 Then
                                CountDivisasMa += 1
                                BandD100 = True
                            End If
                    End Select
                Next
            End If

            Dim valor20 As Double = 0
            Dim valor10 As Double = 0
            Dim valor5 As Integer = 0
            Dim valor1 As Integer = 0
            Dim valorN As Double = 0
            Dim valor50 As Double = 0
            Dim valor100 As Double = 0
            Dim D100 As Double = 0
            Dim D50 As Double = 0
            Dim D20 As Double = 0
            Dim D10 As Double = 0
            Dim D5 As Double = 0
            Dim D1 As Double = 0
            Dim porcent As Double
            Dim diferencia As Integer = 0
            Dim AuxCountDivisasMe As Integer = 0
            Dim banderaDividir As Boolean = False
            Dim datos As Double = 0
            Dim porcent1, porcent2, porcent3, porcent4, SumaPorcent, porcentN As Double
            Dim auxtmitad1N As Double = 0

            porcent1 = 0
            porcent2 = 0
            porcent3 = 0
            porcent4 = 0
            SumaPorcent = 0
            porcentN = 0

            If CountDivisasMe = 4 Then
                porcent = 0.7
            ElseIf CountDivisasMe = 3 Then
                porcent = 0.8
            ElseIf CountDivisasMe = 2 Then
                porcent = 0.9
            Else
                porcent = 1
            End If

            Auxmitad1N = mitad1
            mitad1N = mitad1
            AuxCountDivisasMe = CountDivisasMe


RevisionExistencia:

            If Auxmitad1N = 20 Then
                valorN = Auxmitad1N
            Else
                valorN = Auxmitad1N * porcent
            End If

            If Int(valorN) <> valorN And valorN > 19 Then
                valorN = Int(valorN) + 1
            ElseIf valorN < 20 Then
                valorN = 0
            End If

            'dolas de 20
            If BandD20 Then
                D20 = valorN / 20

                If Int(D20) <> D20 Then
                    D20 = Int(D20) + 1
                End If

                valor20 = D20 * 20
                If valor20 > Auxmitad1N Then
                    If D20 > 1 Then
                        D20 -= 1
                        valor20 = D20 * 20
                    End If
                End If

                If valor20 > ExistenciaD20 And BandD20 Then
                    valor20 = ExistenciaD20
                    D20 = valor20 / 20
                    Auxmitad1N = mitad1N - valor20
                    mitad1N = Auxmitad1N
                    BandD20 = False
                    ExistenciaD20 = 0
                    porcent += 0.11
                    If porcent >= 1 Then
                        porcent = 1
                    End If
                    GoTo RevisionExistencia
                ElseIf BandD20 Then
                    Auxmitad1N = Auxmitad1N - valor20
                End If
            End If

            If Auxmitad1N = 10 Then
                valorN = Auxmitad1N
            Else
                valorN = Auxmitad1N * porcent
            End If


            If Int(valorN) <> valorN And valorN > 9 Then
                valorN = Int(valorN) + 1
            ElseIf valorN < 10 Then
                valorN = 0
            End If

            'dolar de 10
            If BandD10 Then
                D10 = valorN / 10

                If Int(D10) <> D10 Then
                    D10 = Int(D10) + 1
                End If

                valor10 = D10 * 10
                If valor10 > Auxmitad1N Then
                    If D10 > 1 Then
                        D10 -= 1
                        valor10 = D10 * 10
                    End If
                End If
                If valor10 > ExistenciaD10 And BandD10 Then
                    valor10 = ExistenciaD10
                    D10 = valor10 / 10
                    Auxmitad1N = mitad1N - valor10
                    mitad1N = Auxmitad1N
                    BandD10 = False
                    'ExistenciaD10 = 0
                    porcent += 0.11
                    If porcent >= 1 Then
                        porcent = 1
                    End If
                    GoTo RevisionExistencia
                ElseIf BandD10 Then
                    Auxmitad1N = Auxmitad1N - valor10
                End If

            End If

            If ExistenciaD1 > 0 And Auxmitad1N > 5 Then
                valorN = Auxmitad1N * porcent
            Else
                valorN = Auxmitad1N
            End If

            If Int(valorN) <> valorN And valorN > 4 Then
                valorN = Int(valorN) + 1
            ElseIf valorN < 5 Then
                valorN = 0
            End If

            'dolar de 5
            If ExistenciaD5 > 0 Then
                D5 = valorN / 5

                If Int(D5) <> D5 Then
                    D5 = Int(D5) + 1
                End If

                valor5 = D5 * 5
                If valor5 > Auxmitad1N Then
                    If D5 > 1 Then
                        D5 -= 1
                        valor5 = D5 * 5
                    End If
                End If

                If valor5 > ExistenciaD5 And BandD5 Then
                    valor5 = ExistenciaD5
                    D5 = valor5 / 5
                    auxtmitad1N = auxtmitad1N + valor5
                    Auxmitad1N = mitad1
                    mitad1N = mitad1
                    Auxmitad1N = mitad1N - auxtmitad1N
                    mitad1N = Auxmitad1N
                    BandD5 = False
                    ExistenciaD5 = 0
                    porcent += 0.11
                    If porcent >= 1 Then
                        porcent = 1
                    End If
                    BandD10 = True
                    BandD20 = True
                    GoTo RevisionExistencia
                ElseIf BandD5 Then
                    Auxmitad1N = Auxmitad1N - valor5
                End If
            End If

            valorN = Auxmitad1N '* porcent

            If Int(valorN) <> valorN And valorN >= 1 Then
                valorN = Int(valorN) + 1
            ElseIf valorN < 1 Then
                valorN = Auxmitad1N
            End If

            'dolar de 1
            If ExistenciaD1 > 0 Then
                D1 = valorN / 1

                If Int(D1) <> D1 Then
                    D1 = Int(D1) + 1
                End If

                valor1 = D1 * 1

                If valor1 > ExistenciaD1 And BandD1 Then
                    valor1 = ExistenciaD1
                    D1 = valor1 / 1
                    auxtmitad1N = auxtmitad1N + valor1
                    Auxmitad1N = mitad1
                    mitad1N = mitad1
                    Auxmitad1N = mitad1N - auxtmitad1N
                    mitad1N = Auxmitad1N
                    BandD1 = False
                    ExistenciaD1 = 0
                    porcent += 0.11
                    If porcent >= 1 Then
                        porcent = 1
                    End If
                    BandD10 = True
                    BandD20 = True
                    GoTo RevisionExistencia
                ElseIf BandD1 Then
                    Auxmitad1N = Auxmitad1N - valor1
                End If
            End If

            Dim totalMenor As Double
            totalMenor = 0
            totalMenor = totalMenor + (D20 * 20)
            totalMenor = totalMenor + (D10 * 10)
            totalMenor = totalMenor + (D5 * 5)
            totalMenor = totalMenor + (D1 * 1)
            totalMenor = totalMenor - mitad1


            'comienza de 100 y 50
            If CountDivisasMa = 2 Then
                porcent = 0.5
            Else
                porcent = 1
            End If

            Auxmitad1N = mitad2
            mitad1N = mitad2

RevisionExistenciaMayor:

            If Auxmitad1N = 100 Then
                valorN = Auxmitad1N
            Else
                valorN = Auxmitad1N * porcent
            End If

            If Int(valorN) <> valorN And valorN >= 100 Then
                valorN = Int(valorN) + 1
            ElseIf valorN < 100 Then
                valorN = 0
            End If

            'dolas de 100
            If BandD100 Then
                D100 = valorN / 100

                If Int(D100) <> D100 Then
                    D100 = Int(D100) + 1
                End If

                valor100 = D100 * 100

                If valor100 > ExistenciaD100 And BandD100 Then
                    valor100 = ExistenciaD100
                    D100 = valor100 / 100
                    Auxmitad1N = mitad1N - valor100
                    mitad1N = Auxmitad1N
                    BandD100 = False
                    ExistenciaD100 = 0
                    porcent += 0.11
                    If porcent >= 1 Then
                        porcent = 1
                    End If
                    GoTo RevisionExistencia
                ElseIf BandD100 Then
                    Auxmitad1N = Auxmitad1N - valor100
                End If
            End If

            valorN = Auxmitad1N '* porcent

            If Int(valorN) <> valorN And valorN >= 50 Then
                valorN = Int(valorN) + 1
            End If

            'dolas de 50
            If BandD50 Then
                D50 = valorN / 50

                If Int(D50) <> D50 Then
                    D50 = Int(D50) + 1
                End If

                valor50 = D50 * 50

                If valor50 > ExistenciaD100 And BandD50 Then
                    valor50 = ExistenciaD50
                    D50 = valor50 / 50
                    Auxmitad1N = mitad1N - valor50
                    mitad1N = Auxmitad1N
                    BandD50 = False
                    ExistenciaD50 = 0
                    porcent += 0.11
                    If porcent > 1 Then
                        porcent = 1
                    End If
                    GoTo RevisionExistencia
                ElseIf BandD50 Then
                    Auxmitad1N = Auxmitad1N - valor50
                End If
            End If

            Dim totalMayor As Double
            totalMayor = 0
            totalMayor = totalMayor + (D100 * 100)
            totalMayor = totalMayor + (D50 * 50)
            totalMayor = totalMayor - mitad2

            If totalMenor = 0 And totalMayor = 0 Then
                For x As Integer = 0 To dgvAux.Rows.Count - 1
                    Select Case Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("valor").Value)
                        Case 1
                            dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("CSugerida").Value = Int(D1).ToString
                        Case 5
                            dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("CSugerida").Value = Int(D5).ToString
                        Case 10
                            dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("CSugerida").Value = Int(D10).ToString
                        Case 20
                            dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("CSugerida").Value = Int(D20).ToString
                        Case 50
                            dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("CSugerida").Value = Int(D50).ToString
                        Case 100
                            dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("CSugerida").Value = Int(D100).ToString
                    End Select
                Next
            Else
                For x As Integer = 0 To dgvAux.Rows.Count - 1
                    Select Case Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("valor").Value)
                        Case Is < 50 And mitad1 > 0
                            valor = Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("valor").Value)
                            division1 = mitad1 / valor
                            existencia = Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("Existencia").Value)

                            If existencia >= division1 Then
                                mitad1 = mitad1 - (Int(division1) * valor)
                                dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("CSugerida").Value = Int(division1).ToString
                            Else
                                mitad1 = mitad1 - (existencia * valor)
                                dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("CSugerida").Value = existencia.ToString
                            End If
                        Case Is >= 50 And mitad2 > 0
                            valor = Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("valor").Value)
                            division2 = mitad2 / valor
                            existencia = Convert.ToInt32(dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("Existencia").Value)
                            If existencia >= division2 Then
                                mitad2 = mitad2 - (Int(division2) * valor)
                                dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("CSugerida").Value = Int(division2).ToString
                            Else
                                mitad2 = mitad2 - (existencia * valor)
                                dgvAux.Rows(dgvAux.Rows.Count - 1 - x).Cells("CSugerida").Value = existencia.ToString
                            End If
                            If (division2 < 1 And division2 <> 0.5) Or mitad2 < 50 Then '(valor = 50 And mitad2 > 0) Then
                                mitad1 += mitad2
                                mitad2 = 0
                            End If
                    End Select
                Next
            End If

            If dgvAux.Columns("CSugerida") Is Nothing Then
                Dim tot As Double
                For b As Integer = 0 To dgvAux.Rows.Count - 1
                    tot += Convert.ToDouble(dgvAux.Rows(b).Cells("CSugerida").Value.ToString) * Convert.ToDouble(dgvAux.Rows(b).Cells("valor").Value.ToString)
                Next
            End If

            txtExistenciasS.BringToFront()
        End If
    End Sub
#End Region

    Private Sub txtmonto1_TextChanged(sender As Object, e As EventArgs) Handles txtmonto1.TextChanged
        If IsNumeric(txtmonto1.Text.Trim) Then
            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * precioCoV).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)
        End If
    End Sub

    Private Sub txtExistenciasS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExistenciasS.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtExistencias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExistencias.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtSugerido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSugerido.KeyPress
        e.Handled = True
    End Sub

    Private Sub dgvAux_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAux.ColumnHeaderMouseClick
        Dim suma As Double = 0
        Dim multi As Double = 0
        Dim SumaTotal As Double = 0
        If dgvAux.Columns(e.ColumnIndex).Name = "CSugerida" Then
            If dgvCoV.Rows.Count > 0 Then
                MessageBox.Show("LA TABLA DE " & CoV & " DEBE ESTAR VACÍA PARA COLOCAR EL PEDIDO SUGERIDO")
            Else
                For Each divisa As DataGridViewRow In dgvAux.Rows
                    If dgvAux.Rows(divisa.Index).Cells("CSugerida").Value.ToString <> "0" And dgvAux.Rows(divisa.Index).Cells("CSugerida").Value.ToString IsNot Nothing Then
                        suma = (Int(dgvAux.Rows(divisa.Index).Cells("CSugerida").Value.ToString) *
                                        Int(dgvAux.Rows(divisa.Index).Cells("valor").Value.ToString)) * precioCoV
                        multi += (Convert.ToInt32(dgvAux.Rows(divisa.Index).Cells("valor").Value.ToString) *
                                                 Convert.ToInt32(dgvAux.Rows(divisa.Index).Cells("CSugerida").Value.ToString))
                        dgvCoV.Rows.Add(dgvAux.Rows(divisa.Index).Cells("codigo").Value.ToString, dgvAux.Rows(divisa.Index).Cells("divisa").Value.ToString,
                                        dgvAux.Rows(divisa.Index).Cells("CSugerida").Value, suma.ToString("##,##0.00"), precioCoV.ToString("##,##0.00"))
                        txtmonto2.Text = (multi).ToString
                        SumaTotal = SumaTotal + suma
                    End If
                Next
                btn12.Text = (SumaTotal).ToString("$#,##0.00")
            End If

            Select Case CoV
                Case "COMPRA"
                    btnventa.Enabled = False
                Case "VENTA"
                    btncompra.Enabled = False
            End Select
            Select Case tipdivi
                Case 1
                    btnd2.Enabled = False
                    btnd3.Enabled = False
                    btnd4.Enabled = False
                Case 2
                    btnd1.Enabled = False
                    btnd3.Enabled = False
                    btnd4.Enabled = False
                Case 3
                    btnd1.Enabled = False
                    btnd2.Enabled = False
                    btnd4.Enabled = False
                Case 4
                    btnd1.Enabled = False
                    btnd2.Enabled = False
                    btnd3.Enabled = False
            End Select
        End If
    End Sub

    Private Sub VButton1_Click(sender As Object, e As EventArgs) Handles VButton1.Click
        txtid.Clear()
        txtuf.Clear()
        txtop.Clear()
        txtmnt.Clear()
        TxtUltFolio.Clear()
        txtNombres.Clear()
        txtApellidos.Clear()
        TxtTarjeta.Clear()
        InicializarVariables2()
        dgvClientes.DataSource = Nothing
        txtApellidos.Focus()
        ConTarjetaP = False
        TxtTarjeta.Enabled = True
        txtid.Enabled = True
        txtid.BackColor = Color.White
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

    Private Sub vbtnRCaja_Click(sender As Object, e As EventArgs) Handles vbtnRCaja.Click
        If ConTarjeta Or ConTarjetaP Then
            If MsgBox("Se escaneo una Tarjeta, si sale de la opcion tendra que escanearla de nuevo, desea continuar?", vbOKCancel) = vbCancel Then
                VButton1_Click(sender, e)
                Exit Sub
            End If
        End If
        If vbtnRCaja.VIBlendTheme = VIBLEND_THEME.BLUEBLEND Then
            Dim formshow As New FrmTablaDivisas
            formshow.No_sucursal = No_sucursal
            formshow.ShowDialog()
            dt1 = otipodivisasC.Stipodivisas2(No_sucursal).Tables(0)
            preciosCV()
            AsignaPrecios()
        Else
            dt1 = otipodivisasC.Stipodivisas2(No_sucursal).Tables(0)
            preciosCV()
            AsignaPrecios()
            vbtnRCaja.VIBlendTheme = VIBLEND_THEME.BLUEBLEND
        End If
        ContadorBotonAum = 0
        ContadorBotomRes = 0
    End Sub

    Private Sub vbtnFCaja_Click(sender As Object, e As EventArgs) Handles vbtnFCaja.Click
        Dim form As New FrmMostrarReporte
        If ConTarjeta Or ConTarjetaP Then
            If MsgBox("Se escaneo una Tarjeta, si sale de la opcion tendra que escanearla de nuevo, desea continuar?", vbOKCancel) = vbCancel Then
                VButton1_Click(sender, e)
                Exit Sub
            End If
        End If
        form.No_sucursal = No_sucursal
        form.Nombre_sucursal = Nombre_sucursal
        form.Sistemas = UsuarioL
        form.ShowDialog()
        operacion_especial = False
    End Sub

    Private Sub Limites(ByVal sender As Object, ByVal e As EventArgs)
        ''nuevo proceso de limites
        Dim frmAlerta As New FrmAlerta
        Dim LimiteMax As Double
        Dim AcumuladoMax As Double

        LimiteMax = ousuarios.Limites(idcli, tipdivi)
        AcumuladoMax = ousuarios.LimitesAcumulado(idcli, tipdivi)
        cantidadTot = oremisioDC.CantidadxCliente3(Date.Now, idcli, No_sucursal)
        If IsNumeric(txtmonto1.Text) And Convert.ToInt32(txtmonto1.Text) > LimiteMax Then
            MessageBox.Show("NO SE PERMITE ESTA OPERACION QUE SEA MAYOR A " & LimiteMax)
            frmAlerta.empleado = Cajero
            frmAlerta.monto = txtmonto1.Text
            frmAlerta.operacion = ""
            frmAlerta.sucursal = NomSucursal
            frmAlerta.usuario = nombre_completo
            frmAlerta.no_caje = No_cajero
            Select Case tipdivi
                Case 1
                    frmAlerta.rbd1.Checked = True
                Case 2
                    frmAlerta.rbd2.Checked = True
                Case 3
                    frmAlerta.rbd3.Checked = True
                Case 4
                    frmAlerta.rbd4.Checked = True
            End Select
            frmAlerta.divisa = tipdivi.ToString
            frmAlerta.ShowDialog()
            frmAlerta.Dispose()
            txtmonto1.Text = "0"
        ElseIf Not idcli = 1229 And CoV <> "" Then
            Dim DivisasPrecio As Double
            Dim Monto As Integer
            Monto = Convert.ToInt32(txtmonto1.Text)
            If CoV = "COMPRA" Then
                Select Case tipdivi
                    Case 1
                        DivisasPrecio = Monto * CDbl(txtcd1.Text)
                    Case 2
                        DivisasPrecio = Monto * CDbl(txtcd2.Text)
                    Case 3
                        DivisasPrecio = Monto * CDbl(txtcd3.Text)
                    Case 4
                        DivisasPrecio = Monto * CDbl(txtcd4.Text)
                    Case 5
                        DivisasPrecio = Monto * CDbl(txtcd5.Text)
                    Case 6
                        DivisasPrecio = Monto * CDbl(txtcd6.Text)
                    Case 7
                        DivisasPrecio = Monto * CDbl(txtcd7.Text)
                    Case 8
                        DivisasPrecio = Monto * CDbl(txtcd8.Text)
                End Select
            Else
                Select Case tipdivi
                    Case 1
                        DivisasPrecio = Monto * CDbl(txtvd1.Text)
                    Case 2
                        DivisasPrecio = Monto * CDbl(txtvd2.Text)
                    Case 3
                        DivisasPrecio = Monto * CDbl(txtvd3.Text)
                    Case 4
                        DivisasPrecio = Monto * CDbl(txtvd4.Text)
                    Case 5
                        DivisasPrecio = Monto * CDbl(txtvd5.Text)
                    Case 6
                        DivisasPrecio = Monto * CDbl(txtvd6.Text)
                    Case 7
                        DivisasPrecio = Monto * CDbl(txtvd7.Text)
                    Case 8
                        DivisasPrecio = Monto * CDbl(txtvd8.Text)
                End Select
            End If
            If DivisasPrecio + cantidadTot > AcumuladoMax Then
                MessageBox.Show("ESTA OPERACION NO ESTA PERMITIDA por el MONTO, por Persona son " & AcumuladoMax & " Maximo")
                frmAlerta.empleado = Cajero
                frmAlerta.monto = txtmonto1.Text
                frmAlerta.operacion = ""
                frmAlerta.sucursal = Me.Text
                frmAlerta.usuario = nombre_completo
                frmAlerta.no_caje = No_cajero

                Select Case tipdivi
                    Case 1
                        frmAlerta.rbd1.Checked = True
                    Case 2
                        frmAlerta.rbd2.Checked = True
                    Case 3
                        frmAlerta.rbd3.Checked = True
                    Case 4
                        frmAlerta.rbd4.Checked = True
                    Case 5
                        frmAlerta.rbd5.Checked = True
                    Case 6
                        frmAlerta.rbd6.Checked = True
                    Case 7
                        frmAlerta.rbd7.Checked = True
                    Case 8
                        frmAlerta.rbd8.Checked = True
                End Select
                frmAlerta.divisa = tipdivi.ToString
                frmAlerta.ShowDialog()
                frmAlerta.Dispose()
                txtmonto1.Text = "0"
                vbtnd4_Click(sender, e)
                VButton1_Click(sender, e)
            End If
        End If

    End Sub

    Function LimitesGrupo(ByVal sender As Object, ByVal e As EventArgs) As Boolean
        ''nuevo proceso de limites
        Dim frmAlerta As New FrmAlerta
        Dim LimiteMax As Double
        Dim AcumuladoMax As Double
        Dim Valor As Boolean = False

        LimiteMax = ousuarios.Limites(idcli, tipdivi)
        AcumuladoMax = ousuarios.LimitesAcumulado(idcli, tipdivi)
        cantidadTot = oremisioDC.CantidadxCliente3(Date.Now, idcli, No_sucursal)
        If IsNumeric(txtmonto1.Text) And Convert.ToInt32(txtmonto1.Text) > LimiteMax Then
            MessageBox.Show("NO SE PERMITE ESTA OPERACION QUE SEA MAYOR A " & LimiteMax)
            frmAlerta.empleado = Cajero
            frmAlerta.monto = txtmonto1.Text
            frmAlerta.operacion = ""
            frmAlerta.sucursal = NomSucursal
            frmAlerta.usuario = nombre_completo
            frmAlerta.no_caje = No_cajero
            Select Case tipdivi
                Case 1
                    frmAlerta.rbd1.Checked = True
                Case 2
                    frmAlerta.rbd2.Checked = True
                Case 3
                    frmAlerta.rbd3.Checked = True
                Case 4
                    frmAlerta.rbd4.Checked = True
            End Select
            frmAlerta.divisa = tipdivi.ToString
            frmAlerta.ShowDialog()
            frmAlerta.Dispose()
            txtmonto1.Text = "0"
            Valor = True
        ElseIf Not idcli = 1229 And CoV <> "" Then
            Dim DivisasPrecio As Double
            Dim Monto As Integer
            Monto = Convert.ToInt32(txtmonto1.Text)
            If CoV = "COMPRA" Then
                Select Case tipdivi
                    Case 1
                        DivisasPrecio = Monto * CDbl(txtcd1.Text)
                    Case 2
                        DivisasPrecio = Monto * CDbl(txtcd2.Text)
                    Case 3
                        DivisasPrecio = Monto * CDbl(txtcd3.Text)
                    Case 4
                        DivisasPrecio = Monto * CDbl(txtcd4.Text)
                    Case 5
                        DivisasPrecio = Monto * CDbl(txtcd5.Text)
                    Case 6
                        DivisasPrecio = Monto * CDbl(txtcd6.Text)
                    Case 7
                        DivisasPrecio = Monto * CDbl(txtcd7.Text)
                    Case 8
                        DivisasPrecio = Monto * CDbl(txtcd8.Text)
                End Select
            Else
                Select Case tipdivi
                    Case 1
                        DivisasPrecio = Monto * CDbl(txtvd1.Text)
                    Case 2
                        DivisasPrecio = Monto * CDbl(txtvd2.Text)
                    Case 3
                        DivisasPrecio = Monto * CDbl(txtvd3.Text)
                    Case 4
                        DivisasPrecio = Monto * CDbl(txtvd4.Text)
                    Case 5
                        DivisasPrecio = Monto * CDbl(txtvd5.Text)
                    Case 6
                        DivisasPrecio = Monto * CDbl(txtvd6.Text)
                    Case 7
                        DivisasPrecio = Monto * CDbl(txtvd7.Text)
                    Case 8
                        DivisasPrecio = Monto * CDbl(txtvd8.Text)
                End Select
            End If
            If DivisasPrecio + cantidadTot > AcumuladoMax Then
                MessageBox.Show("ESTA OPERACION NO ESTA PERMITIDA por el MONTO, por Persona son " & AcumuladoMax & " Maximo")
                frmAlerta.empleado = Cajero
                frmAlerta.monto = txtmonto1.Text
                frmAlerta.operacion = ""
                frmAlerta.sucursal = Me.Text
                frmAlerta.usuario = nombre_completo
                frmAlerta.no_caje = No_cajero

                Select Case tipdivi
                    Case 1
                        frmAlerta.rbd1.Checked = True
                    Case 2
                        frmAlerta.rbd2.Checked = True
                    Case 3
                        frmAlerta.rbd3.Checked = True
                    Case 4
                        frmAlerta.rbd4.Checked = True
                End Select
                frmAlerta.divisa = tipdivi.ToString
                frmAlerta.ShowDialog()
                frmAlerta.Dispose()
                txtmonto1.Text = "0"
                vbtnd4_Click(sender, e)
                VButton1_Click(sender, e)
                Valor = True
            End If
        End If
        Return Valor

    End Function

    Private Sub LimitesC(ByVal sender As Object, ByVal e As EventArgs)
        ''nuevo proceso de limites
        Dim frmAlerta As New FrmAlerta
        Dim LimiteMax As Double
        Dim AcumuladoMax As Double

        If tipdivi >= 5 And idcli = 1229 Then
            If NoSucursal = "06" Then
                LimiteMax = ousuarios.Limites(idcli, tipdivi)
                AcumuladoMax = ousuarios.LimitesAcumulado(idcli, tipdivi)
            Else
                LimiteMax = 1
                AcumuladoMax = 1
            End If
        Else
            LimiteMax = ousuarios.Limites(idcli, tipdivi)
            AcumuladoMax = ousuarios.LimitesAcumulado(idcli, tipdivi)
        End If

        cantidadTot = oremisioDC.CantidadxCliente3(Date.Now, idcli, No_sucursal)
        If IsNumeric(txtmonto1.Text) And Convert.ToInt32(txtmonto1.Text) > LimiteMax Then
            MessageBox.Show("NO SE PERMITE ESTA OPERACION QUE SEA MAYOR A " & LimiteMax)
            frmAlerta.empleado = Cajero
            frmAlerta.monto = txtmonto1.Text
            frmAlerta.operacion = ""
            frmAlerta.sucursal = NomSucursal
            frmAlerta.usuario = nombre_completo
            frmAlerta.no_caje = No_cajero
            Select Case tipdivi
                Case 1
                    frmAlerta.rbd1.Checked = True
                Case 2
                    frmAlerta.rbd2.Checked = True
                Case 3
                    frmAlerta.rbd3.Checked = True
                Case 4
                    frmAlerta.rbd4.Checked = True
            End Select
            frmAlerta.divisa = tipdivi.ToString
            frmAlerta.ShowDialog()
            frmAlerta.Dispose()
            txtmonto1.Text = "0"
        ElseIf Not idcli = 1229 And CoV <> "" Then
            Dim DivisasPrecio As Double
            Dim Monto As Integer
            Monto = Convert.ToInt32(txtmonto1.Text)
            If CoV = "COMPRA" Then
                Select Case tipdivi
                    Case 1
                        DivisasPrecio = Monto * CDbl(txtcd1.Text)
                    Case 2
                        DivisasPrecio = Monto * CDbl(txtcd2.Text)
                    Case 3
                        DivisasPrecio = Monto * CDbl(txtcd3.Text)
                    Case 4
                        DivisasPrecio = Monto * CDbl(txtcd4.Text)
                    Case 5
                        DivisasPrecio = Monto * CDbl(txtcd5.Text)
                    Case 6
                        DivisasPrecio = Monto * CDbl(txtcd6.Text)
                    Case 7
                        DivisasPrecio = Monto * CDbl(txtcd7.Text)
                    Case 8
                        DivisasPrecio = Monto * CDbl(txtcd8.Text)
                End Select
            End If
            If DivisasPrecio + cantidadTot > AcumuladoMax Then
                MessageBox.Show("ESTA OPERACION NO ESTA PERMITIDA por el MONTO, por Persona son " & AcumuladoMax & " Maximo")
                frmAlerta.empleado = Cajero
                frmAlerta.monto = txtmonto1.Text
                frmAlerta.operacion = ""
                frmAlerta.sucursal = Me.Text
                frmAlerta.usuario = nombre_completo
                frmAlerta.no_caje = No_cajero

                Select Case tipdivi
                    Case 1
                        frmAlerta.rbd1.Checked = True
                    Case 2
                        frmAlerta.rbd2.Checked = True
                    Case 3
                        frmAlerta.rbd3.Checked = True
                    Case 4
                        frmAlerta.rbd4.Checked = True
                End Select
                frmAlerta.divisa = tipdivi.ToString
                frmAlerta.ShowDialog()
                frmAlerta.Dispose()
                txtmonto1.Text = "0"
                vbtnd4_Click(sender, e)
                VButton1_Click(sender, e)
            End If
        End If

    End Sub

    Private Sub dgvClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvClientes.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim idx, nombresx, apellidos1x, apellidos2x, tarjeta3x As String
            Dim fechaenvpx As String
            idx = dgvClientes.CurrentRow.Cells("cliente").Value.ToString()
            nombresx = dgvClientes.CurrentRow.Cells("Nombre").Value.ToString()
            apellidos1x = dgvClientes.CurrentRow.Cells("ApellidoPaterno").Value.ToString()
            apellidos2x = dgvClientes.CurrentRow.Cells("ApellidoMaterno").Value.ToString()
            tarjeta3x = dgvClientes.CurrentRow.Cells("Tarjeta").Value.ToString()
            fechaenvpx = dgvClientes.CurrentRow.Cells("Fecha_Envio_P").Value.ToString
            txtApellidos.Text = apellidos1x
            LimpiarCampos2()
            LimpiarCampos1()
            txtid.Text = idx
            txtNombres.Text = nombresx
            txtApellidos.Text = apellidos1x
            TxtTarjeta.Text = tarjeta3x
            nombre_aux = nombresx
            apellido1_aux = apellidos1x
            nombre_completo = nombre_aux & " " & apellido1_aux & " " & apellidos2x
            If oPersonasPoliticasEC.PersonaBF(nombre_aux, apellido1_aux, apellidos2x) > 0 Then
                Dim notificacion As New FrmNotificacionPersonasBloqueadas
                notificacion.ShowDialog()
                If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
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
                    Exit Sub
                End If
            End If
            If oPersonasPoliticasEC.ListaInt(nombre_aux, apellido1_aux, apellidos2x) > 0 Or oPersonasPoliticasEC.ListaOFAC(nombre_aux, apellido1_aux, apellidos2x) > 0 Then
                Dim notificacion As New FrmNotificacionPersBloqListaInt
                notificacion.ShowDialog()
                If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
                    Exit Sub
                End If
            End If
            If oPersonasPoliticasEC.PersonaPE(nombre_aux, apellido1_aux, apellidos2x) > 0 Or oPersonasPoliticasEC.PersonaPEEx(nombre_aux, apellido1_aux, apellidos2x) > 0 Then
                Dim notificacion As New FrmNotificacionPersonasPoliticas
                notificacion.ShowDialog()
                If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                    pnlOperaciones.Enabled = False
                    PictureBox1.Enabled = False
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
                    Exit Sub
                End If
            End If
            idcli = CInt(idx)
            infocliente()
        End If
    End Sub

    Private Sub btnPublico_Click(sender As Object, e As EventArgs) Handles btnPublico.Click
        If chGrupo.Checked Then
            MsgBox("Tiene seleccionado NOTA DE GRUPO, favor de terminar las " & vbCrLf & "NOTAS DE GRUPO", vbInformation)
            Exit Sub
        End If
        If txtNombres.Text = "" Or txtApellidos.Text = "" Then
            txtApellidos.Text = "GENERAL"
            txtApellidos.Focus()
            idcli = 1229
            BscCliente = idcli
            infocliente()
            txtmonto1.Focus()
            ConTarjeta = False
            ConTarjetaP = False
            TxtTarjeta.BackColor = Color.White
        Else
            MessageBox.Show("DEBE PRESIONAR EL BOTÓN ""LIMPIAR CLIENTE"" PRIMERO")
        End If
        If dt_BloqFisicas.Rows.Count = 0 Or dt_BloqFisicas.Columns.Count < 2 Then
            PersonasBloqueadas1()
        End If
        If dt_PPoliticas.Rows.Count = 0 Or dt_PPoliticas.Columns.Count < 2 Then
            PersonasBloqueadas2()
        End If
    End Sub

    Private Sub btn13_Click(sender As Object, e As EventArgs) Handles btn13.Click
        If IsNumeric(btn13.Text.Replace("$", "")) Then 'And btn13.Text <> "" And (btn13.Text.Replace("$", "") <> "0" Or CInt(btn13.Text.Replace("$", "")) = 0) Then
            btn11.PerformClick()
            btnb1.Focus()
        End If
    End Sub

    Private Sub txtmonto1_Leave(sender As Object, e As EventArgs) Handles txtmonto1.Leave
        If txtmonto1.Text = "" Then
            txtmonto1.Text = "0"
        End If
        If idcli > 0 Then
            If CoV = "COMPRA" Then
                LimitesC(sender, e)
            Else
                If CoV = "VENTA" Then
                    Limites(sender, e)
                End If
            End If
        End If
    End Sub

    Private Sub LimpiarBotones()
        btnb1.Text = ""
        btnb2.Text = ""
        btnb3.Text = ""
        btnb4.Text = ""
        btnb5.Text = ""
        btnb6.Text = ""
        btnb7.Text = ""
        btn14.BackgroundImage = Nothing
    End Sub

    Private Sub Filtra_bloqListaInterna()
        Try
            Dim filtro As String = String.Empty
            If txtNombres.Text.Trim <> "" And txtApellidos.Text.Trim <> "" Then

                source_BloqListaInterna.Filter = filtro
                If oPersonasBloqueadasFisicasC.FILTRAR_ListaInterna(nombre_completo) = 0 Then
                    'todo ok
                Else
                    Dim notificacion As New FrmNotificacionPersonasBloqueadas
                    notificacion.ShowDialog()
                    If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                        pnlOperaciones.Enabled = False
                        PictureBox1.Enabled = False
                        Dim frmAlerta As New FrmAlerta
                        frmAlerta.monto = "0"
                        frmAlerta.empleado = Cajero
                        frmAlerta.usuario = txtNombres.Text.Trim & " " & txtApellidos.Text.Trim
                        If nombre_completo.Trim <> "" Then
                            frmAlerta.usuario = nombre_completo
                        End If
                        frmAlerta.divisa = ""
                        frmAlerta.operacion = ""
                        frmAlerta.sucursal = Me.Text
                        frmAlerta.no_caje = No_cajero
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

    Private Sub chGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles chGrupo.CheckedChanged
        If chGrupo.Checked Then
            PrimeroGrupo = True
            cmdFinalizarGrupo.Enabled = True
        Else
            PrimeroGrupo = False
            cmdFinalizarGrupo.Enabled = False
        End If
    End Sub

    Private Sub btnd1_Click(sender As Object, e As EventArgs) Handles btnd1.Click
        tipdivi = 1

        If btn14.BackgroundImage IsNot Nothing Then
            btn14.BackgroundImage = Nothing
        End If
        If dgvAux.Columns("CSugerida") IsNot Nothing And dgvAux.Columns.Count > 0 Then
            dgvAux.Columns.RemoveAt(dgvAux.Columns.Count - 1)
        End If
        If dgvAux.DataSource IsNot Nothing And CoV = "VENTA" Then
            FiltraMe(1)
            FiltrarExistencia2(1) 'cambio
            filtrardt2(1)

            precioC = Convert.ToDouble(dt1.Rows(0)("Venta").ToString)
            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd1.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvAux.DataSource = dt2filtro
            dgvAux.Columns("divisa").Visible = False
            dgvAux.Columns("codigo").Visible = True
            dgvAux.Columns("valor").Visible = False
            dgvAux.Columns("tipo").Visible = False
            dgvAux.Columns("cpromedio").Visible = False
            dgvAux.Columns("divisa").HeaderText = "Divisa"
            BtnFraccionar.Enabled = False
            'BtnCambio.Enabled = False

        ElseIf CoV = "COMPRA" Then
            precioC = Convert.ToDouble(dt1.Rows(0)("Compra").ToString)
            If Not RevisarLimite(tipdivi) Then
                Exit Sub
            End If
            If Not RevisarLimiteCompra(tipdivi) Then
                Exit Sub
            End If
            FiltraMe(1)
            FiltrarExistencia2(1) 'cambio
            filtrardt2(1)

            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd1.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing

            If dgvCoV.RowCount > 0 Then
                BtnFraccionar.Enabled = False
                'BtnCambio.Enabled = True
            Else
                BtnFraccionar.Enabled = True
                'BtnCambio.Enabled = False
            End If

        End If
        txtdivisa.Text = dt1.Rows(0)("Nombre").ToString

        btnb6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold Or FontStyle.Regular)
        btnb7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold Or FontStyle.Regular)

        precioCoV = Convert.ToDouble(txtcd1.Text.Trim)

        If CoV = "COMPRA" Then
            'HabilitarBotones()
            btnb7.Enabled = False
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtcd1.Text.Trim)
        ElseIf CoV = "VENTA" Then
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtvd1.Text.Trim)
        End If

        SumarizaExistencia()
        If idcli > 0 Then
            Limites(sender, e)
        Else
            MsgBox("Debe de Seleccionar un Cliente", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub

    Private Sub btnd2_Click(sender As Object, e As EventArgs) Handles btnd2.Click
        tipdivi = 2
        cambio = False
        BtnFraccionar.Enabled = False
        ' BtnCambio.Enabled = False
        If btn14.BackgroundImage IsNot Nothing Then
            btn14.BackgroundImage = Nothing
        End If
        If dgvAux.Columns("CSugerida") IsNot Nothing And dgvAux.Columns.Count > 0 Then
            dgvAux.Columns.RemoveAt(dgvAux.Columns.Count - 1)
        End If
        If dgvAux.DataSource IsNot Nothing And CoV = "VENTA" Then
            FiltraMe(2)
            FiltrarExistencia2(2) 'cambio
            filtrardt2(2)

            precioC = Convert.ToDouble(dt1.Rows(1)("Venta").ToString)
            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd2.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvAux.DataSource = dt2filtro
            dgvAux.Columns("divisa").Visible = False
            dgvAux.Columns("codigo").Visible = True
            dgvAux.Columns("valor").Visible = False
            dgvAux.Columns("tipo").Visible = False
            dgvAux.Columns("cpromedio").Visible = False
            dgvAux.Columns("divisa").HeaderText = "Divisa"
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            BtnFraccionar.Enabled = True
        ElseIf CoV = "COMPRA" Then
            precioC = Convert.ToDouble(dt1.Rows(1)("Compra").ToString)
            If Not RevisarLimite(tipdivi) Then
                Exit Sub
            End If
            If Not RevisarLimiteCompra(tipdivi) Then
                Exit Sub
            End If
            FiltraMe(2)
            FiltrarExistencia2(2) 'cambio
            filtrardt2(2)

            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd2.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
        End If
        txtdivisa.Text = dt1.Rows(1)("Nombre").ToString

        btnb6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold Or FontStyle.Regular)
        btnb7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold Or FontStyle.Regular)

        precioCoV = Convert.ToDouble(txtcd2.Text.Trim)

        If CoV = "COMPRA" Then
            'HabilitarBotones()
            btnb7.Enabled = False
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtcd2.Text.Trim)
        ElseIf CoV = "VENTA" Then
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtvd2.Text.Trim)
        End If

        SumarizaExistencia()
        If idcli > 0 Then
            Limites(sender, e)
        End If
    End Sub

    Private Sub btnd3_Click(sender As Object, e As EventArgs) Handles btnd3.Click
        tipdivi = 3
        cambio = False
        BtnFraccionar.Enabled = False
        'BtnCambio.Enabled = False
        If btn14.BackgroundImage IsNot Nothing Then
            btn14.BackgroundImage = Nothing
        End If
        If dgvAux.Columns("CSugerida") IsNot Nothing And dgvAux.Columns.Count > 0 Then
            dgvAux.Columns.RemoveAt(dgvAux.Columns.Count - 1)
        End If
        If dgvAux.DataSource IsNot Nothing And CoV = "VENTA" Then
            FiltraMe(3)
            FiltrarExistencia2(3) 'cambio
            filtrardt2(3)

            precioC = Convert.ToDouble(dt1.Rows(2)("Venta").ToString)
            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd3.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvAux.DataSource = dt2filtro
            dgvAux.Columns("divisa").Visible = False
            dgvAux.Columns("codigo").Visible = True
            dgvAux.Columns("valor").Visible = False
            dgvAux.Columns("tipo").Visible = False
            dgvAux.Columns("cpromedio").Visible = False
            dgvAux.Columns("divisa").HeaderText = "Divisa"
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            BtnFraccionar.Enabled = True
        ElseIf CoV = "COMPRA" Then
            precioC = Convert.ToDouble(dt1.Rows(2)("Compra").ToString)
            If Not RevisarLimite(tipdivi) Then
                Exit Sub
            End If
            If Not RevisarLimiteCompra(tipdivi) Then
                Exit Sub
            End If
            FiltraMe(3)
            FiltrarExistencia2(3) 'cambio
            filtrardt2(3)

            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd3.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
        End If
        txtdivisa.Text = dt1.Rows(2)("Nombre").ToString

        btnb6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8, FontStyle.Bold Or FontStyle.Regular)
        btnb7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8, FontStyle.Bold Or FontStyle.Regular)

        precioCoV = Convert.ToDouble(txtcd3.Text.Trim)

        If CoV = "COMPRA" Then
            'HabilitarBotones()
            btnb7.Enabled = False
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtcd3.Text.Trim)
        ElseIf CoV = "VENTA" Then
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtvd3.Text.Trim)
        End If

        SumarizaExistencia()
        If idcli > 0 Then
            Limites(sender, e)
        End If
    End Sub

    Private Sub btnd4_Click(sender As Object, e As EventArgs) Handles btnd4.Click
        tipdivi = 4
        cambio = False
        BtnFraccionar.Enabled = False
        'BtnCambio.Enabled = False
        If btn14.BackgroundImage IsNot Nothing Then
            btn14.BackgroundImage = Nothing
        End If
        If dgvAux.Columns("CSugerida") IsNot Nothing And dgvAux.Columns.Count > 0 Then
            dgvAux.Columns.RemoveAt(dgvAux.Columns.Count - 1)
        End If
        If dgvAux.DataSource IsNot Nothing And CoV = "VENTA" Then
            FiltraMe(4)
            FiltrarExistencia2(4) 'cambio
            filtrardt2(4)

            precioC = Convert.ToDouble(dt1.Rows(3)("Venta").ToString)
            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd4.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvAux.DataSource = dt2filtro
            dgvAux.Columns("divisa").Visible = False
            dgvAux.Columns("codigo").Visible = True
            dgvAux.Columns("valor").Visible = False
            dgvAux.Columns("tipo").Visible = False
            dgvAux.Columns("cpromedio").Visible = False
            dgvAux.Columns("divisa").HeaderText = "Divisa"
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            BtnFraccionar.Enabled = True
        ElseIf CoV = "COMPRA" Then
            precioC = Convert.ToDouble(dt1.Rows(3)("Compra").ToString)
            If Not RevisarLimite(tipdivi) Then
                Exit Sub
            End If
            If Not RevisarLimiteCompra(tipdivi) Then
                Exit Sub
            End If
            FiltraMe(4)
            FiltrarExistencia2(4) 'cambio
            filtrardt2(4)

            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd4.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
        End If
        txtdivisa.Text = dt1.Rows(3)("Nombre").ToString

        btnb6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold Or FontStyle.Regular)
        btnb7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold Or FontStyle.Regular)

        precioCoV = Convert.ToDouble(txtcd4.Text.Trim)

        If CoV = "COMPRA" Then
            'HabilitarBotones()
            btnb7.Enabled = False
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtcd4.Text.Trim)
        ElseIf CoV = "VENTA" Then
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtvd4.Text.Trim)
        End If

        SumarizaExistencia()
        If idcli > 0 Then
            Limites(sender, e)
        End If
    End Sub

    Private Sub btnd5_Click(sender As Object, e As EventArgs) Handles btnd5.Click
        tipdivi = 5
        cambio = False
        BtnFraccionar.Enabled = False
        'BtnCambio.Enabled = False
        If btn14.BackgroundImage IsNot Nothing Then
            btn14.BackgroundImage = Nothing
        End If
        If dgvAux.Columns("CSugerida") IsNot Nothing And dgvAux.Columns.Count > 0 Then
            dgvAux.Columns.RemoveAt(dgvAux.Columns.Count - 1)
        End If
        If dgvAux.DataSource IsNot Nothing And CoV = "VENTA" Then
            FiltraMe(5)
            FiltrarExistencia2(5) 'cambio
            filtrardt2(5)

            precioC = Convert.ToDouble(dt1.Rows(4)("Venta").ToString)
            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd5.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvAux.DataSource = dt2filtro
            dgvAux.Columns("divisa").Visible = False
            dgvAux.Columns("codigo").Visible = True
            dgvAux.Columns("valor").Visible = False
            dgvAux.Columns("tipo").Visible = False
            dgvAux.Columns("cpromedio").Visible = False
            dgvAux.Columns("divisa").HeaderText = "Divisa"
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            BtnFraccionar.Enabled = True
        ElseIf CoV = "COMPRA" Then
            precioC = Convert.ToDouble(dt1.Rows(4)("Compra").ToString)
            If Not RevisarLimite(tipdivi) Then
                Exit Sub
            End If
            If Not RevisarLimiteCompra(tipdivi) Then
                Exit Sub
            End If
            FiltraMe(5)
            FiltrarExistencia2(5) 'cambio
            filtrardt2(5)

            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd5.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
        End If
        txtdivisa.Text = dt1.Rows(4)("Nombre").ToString

        btnb6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold Or FontStyle.Regular)
        btnb7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold Or FontStyle.Regular)

        precioCoV = Convert.ToDouble(txtcd5.Text.Trim)

        If CoV = "COMPRA" Then
            'HabilitarBotones()
            btnb7.Enabled = False
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtcd5.Text.Trim)
        ElseIf CoV = "VENTA" Then
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtvd5.Text.Trim)
        End If

        SumarizaExistencia()
        If idcli > 0 Then
            If CoV = "COMPRA" Then
                LimitesC(sender, e)
            Else
                If CoV = "VENTA" Then
                    Limites(sender, e)
                End If
            End If
        End If
    End Sub

    Private Sub btnd6_Click(sender As Object, e As EventArgs) Handles btnd6.Click
        tipdivi = 6
        cambio = False
        BtnFraccionar.Enabled = False
        'BtnCambio.Enabled = False
        If btn14.BackgroundImage IsNot Nothing Then
            btn14.BackgroundImage = Nothing
        End If
        If dgvAux.Columns("CSugerida") IsNot Nothing And dgvAux.Columns.Count > 0 Then
            dgvAux.Columns.RemoveAt(dgvAux.Columns.Count - 1)
        End If
        If dgvAux.DataSource IsNot Nothing And CoV = "VENTA" Then
            FiltraMe(6)
            FiltrarExistencia2(6) 'cambio
            filtrardt2(6)

            precioC = Convert.ToDouble(dt1.Rows(5)("Venta").ToString)
            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd6.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvAux.DataSource = dt2filtro
            dgvAux.Columns("divisa").Visible = False
            dgvAux.Columns("codigo").Visible = True
            dgvAux.Columns("valor").Visible = False
            dgvAux.Columns("tipo").Visible = False
            dgvAux.Columns("cpromedio").Visible = False
            dgvAux.Columns("divisa").HeaderText = "Divisa"
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            BtnFraccionar.Enabled = True
        ElseIf CoV = "COMPRA" Then
            precioC = Convert.ToDouble(dt1.Rows(5)("Compra").ToString)
            If Not RevisarLimite(tipdivi) Then
                Exit Sub
            End If
            If Not RevisarLimiteCompra(tipdivi) Then
                Exit Sub
            End If
            FiltraMe(6)
            FiltrarExistencia2(6) 'cambio
            filtrardt2(6)

            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd6.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
        End If
        txtdivisa.Text = dt1.Rows(5)("Nombre").ToString

        btnb6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold Or FontStyle.Regular)
        btnb7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold Or FontStyle.Regular)

        precioCoV = Convert.ToDouble(txtcd6.Text.Trim)

        If CoV = "COMPRA" Then
            'HabilitarBotones()
            btnb7.Enabled = False
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtcd6.Text.Trim)
        ElseIf CoV = "VENTA" Then
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtvd6.Text.Trim)
        End If

        SumarizaExistencia()
        If idcli > 0 Then
            If CoV = "COMPRA" Then
                LimitesC(sender, e)
            Else
                If CoV = "VENTA" Then
                    Limites(sender, e)
                End If
            End If
        End If
    End Sub

    Private Sub btnd7_Click(sender As Object, e As EventArgs) Handles btnd7.Click
        tipdivi = 7
        cambio = False
        BtnFraccionar.Enabled = False
        'BtnCambio.Enabled = False
        If btn14.BackgroundImage IsNot Nothing Then
            btn14.BackgroundImage = Nothing
        End If
        If dgvAux.Columns("CSugerida") IsNot Nothing And dgvAux.Columns.Count > 0 Then
            dgvAux.Columns.RemoveAt(dgvAux.Columns.Count - 1)
        End If
        If dgvAux.DataSource IsNot Nothing And CoV = "VENTA" Then
            FiltraMe(7)
            FiltrarExistencia2(7) 'cambio
            filtrardt2(7)

            precioC = Convert.ToDouble(dt1.Rows(6)("Venta").ToString)
            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd7.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvAux.DataSource = dt2filtro
            dgvAux.Columns("divisa").Visible = False
            dgvAux.Columns("codigo").Visible = True
            dgvAux.Columns("valor").Visible = False
            dgvAux.Columns("tipo").Visible = False
            dgvAux.Columns("cpromedio").Visible = False
            dgvAux.Columns("divisa").HeaderText = "Divisa"
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            BtnFraccionar.Enabled = True
        ElseIf CoV = "COMPRA" Then
            precioC = Convert.ToDouble(dt1.Rows(6)("Compra").ToString)
            If Not RevisarLimite(tipdivi) Then
                Exit Sub
            End If
            If Not RevisarLimiteCompra(tipdivi) Then
                Exit Sub
            End If
            FiltraMe(7)
            FiltrarExistencia2(7) 'cambio
            filtrardt2(7)

            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd7.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
        End If
        txtdivisa.Text = dt1.Rows(6)("Nombre").ToString

        btnb6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold Or FontStyle.Regular)
        btnb7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold Or FontStyle.Regular)

        precioCoV = Convert.ToDouble(txtcd7.Text.Trim)

        If CoV = "COMPRA" Then
            'HabilitarBotones()
            btnb7.Enabled = False
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtcd7.Text.Trim)
        ElseIf CoV = "VENTA" Then
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtvd7.Text.Trim)
        End If

        SumarizaExistencia()
        If idcli > 0 Then
            If CoV = "COMPRA" Then
                LimitesC(sender, e)
            Else
                If CoV = "VENTA" Then
                    Limites(sender, e)
                End If
            End If
        End If
    End Sub

    Private Sub btnd8_Click(sender As Object, e As EventArgs) Handles btnd8.Click
        tipdivi = 8
        cambio = False
        BtnFraccionar.Enabled = False
        'BtnCambio.Enabled = False
        If btn14.BackgroundImage IsNot Nothing Then
            btn14.BackgroundImage = Nothing
        End If
        If dgvAux.Columns("CSugerida") IsNot Nothing And dgvAux.Columns.Count > 0 Then
            dgvAux.Columns.RemoveAt(dgvAux.Columns.Count - 1)
        End If
        If dgvAux.DataSource IsNot Nothing And CoV = "VENTA" Then
            FiltraMe(8)
            FiltrarExistencia2(8) 'cambio
            filtrardt2(8)

            precioCoV = Convert.ToDouble(dt1.Rows(7)("Venta").ToString)
            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtvd8.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvAux.DataSource = dt2filtro
            dgvAux.Columns("divisa").Visible = False
            dgvAux.Columns("codigo").Visible = True
            dgvAux.Columns("valor").Visible = False
            dgvAux.Columns("tipo").Visible = False
            dgvAux.Columns("cpromedio").Visible = False
            dgvAux.Columns("divisa").HeaderText = "Divisa"
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            BtnFraccionar.Enabled = True
        ElseIf CoV = "COMPRA" Then
            precioC = Convert.ToDouble(dt1.Rows(7)("Compra").ToString)

            If Not RevisarLimite(tipdivi) Then
                Exit Sub
            End If
            If Not RevisarLimiteCompra(tipdivi) Then
                Exit Sub
            End If
            FiltraMe(8)
            FiltrarExistencia2(8) 'cambio
            filtrardt2(8)

            txtsubto.Text = (Convert.ToDouble(txtmonto1.Text.Trim) * Convert.ToDouble(txtcd8.Text.Trim)).ToString
            txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
            txtpesos.Text = FormatNumber(txtsubto.Text, 2)

            dgvAux.DataSource = Nothing
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
        End If
        txtdivisa.Text = dt1.Rows(7)("Nombre").ToString

        btnb6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold Or FontStyle.Regular)
        btnb7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold Or FontStyle.Regular)

        precioCoV = Convert.ToDouble(txtcd8.Text.Trim)

        If CoV = "COMPRA" Then
            'HabilitarBotones()
            btnb7.Enabled = False
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtcd8.Text.Trim)
        ElseIf CoV = "VENTA" Then
            dgvCoV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0)
            dgvCoV.ColumnHeadersDefaultCellStyle.Font = New Font("Century Schoolbook", 11, FontStyle.Regular)
            dgvCoV.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            precioCoV = Convert.ToDouble(txtvd8.Text.Trim)
        End If

        SumarizaExistencia()
        If idcli > 0 Then
            If CoV = "COMPRA" Then
                LimitesC(sender, e)
            Else
                If CoV = "VENTA" Then
                    Limites(sender, e)
                End If
            End If
        End If
    End Sub

    Private Sub cmdFinalizarGrupo_Click(sender As Object, e As EventArgs) Handles cmdFinalizarGrupo.Click

        Dim ConLetras As String
        If PrimerCliente <> 0 Then
            ConLetras = oauxiliares.EnLetras(Convert.ToDouble(AcumuladoInsentivo)).ToUpper()

            If ConLetras.Contains("CON") Then
                ConLetras = ConLetras.Replace("CON", "PESOS CON ") & "/100 M.N."
            Else
                ConLetras += " PESOS 00/100 M.N."
            End If
            Conta = oclientescnbvC.Grabar_Nota_Cargo(PrimerCliente, Now, AcumuladoInsentivo, PrimerFolio, oremisioMM.Nosucursal, ConLetras)
            Dim NotasCar As New NotaIN
            cambio = False
            Dim datosNI As New DataSet
            datosNI = oReportesUnicosC.ImprimeNotaCargo(PrimerCliente, Conta, oremisioMM.Nosucursal)
            NotasCar.SetDataSource(datosNI)
            NotasCar.PrintOptions.PrinterName = Impresora1
            NotasCar.PrintToPrinter(1, False, 0, 0)

            NotasCar.Close()
            NotasCar.Dispose()
        End If
        chGrupo.Checked = False
        cmdFinalizarGrupo.Enabled = False
        AcumuladoInsentivo = 0
        PrimerCliente = 0
        PrimerFolio = 0
    End Sub

    Private Sub PersonasBloqueadas1()
        dt_BloqFisicas = oPersonasBloqueadasFisicasC.FILTRAR_ALL(oPersonasBloqueadasFisicasM, "", "").Tables(0)
        source_BloqFisicas.DataSource = dt_BloqFisicas
    End Sub

    Private Sub cmdCalcular_Click(sender As Object, e As EventArgs) Handles cmdCalcular.Click
        Dim PrecioCompra, PrecioVenta As Decimal
        Dim TotalPagar As Decimal

        Select Case cbDe.SelectedValue
            Case 1
                PrecioCompra = txtcd1.Text
            Case 2
                PrecioCompra = txtcd2.Text
            Case 3
                PrecioCompra = txtcd3.Text
            Case 4
                PrecioCompra = txtcd4.Text
            Case 5
                PrecioCompra = txtcd5.Text
            Case 6
                PrecioCompra = txtcd6.Text
            Case 7
                PrecioCompra = txtcd7.Text
            Case 8
                PrecioCompra = txtcd8.Text
        End Select

        Select Case cbA.SelectedValue
            Case 1
                PrecioVenta = txtvd1.Text
            Case 2
                PrecioVenta = txtvd2.Text
            Case 3
                PrecioVenta = txtvd3.Text
            Case 4
                PrecioVenta = txtvd4.Text
            Case 5
                PrecioVenta = txtvd5.Text
            Case 6
                PrecioVenta = txtvd6.Text
            Case 7
                PrecioVenta = txtvd7.Text
            Case 8
                PrecioVenta = txtvd8.Text
        End Select

        TotalPagar = PrecioCompra * txtCantidad.Text
        TotalPagar = TotalPagar / PrecioVenta

        lbTotal.Text = Format(TotalPagar, "$ ###,###,##0.00")
        Timer2.Enabled = True
    End Sub

    Private Sub vbtna1_Click(sender As Object, e As EventArgs) Handles vbtna1.Click
        If TxtUltFolio.Text.Length > 0 Then
            Dim VerNota As New FrmMostrarNota
            VerNota.cliente_buscar = BscCliente
            VerNota.folio_buscar = TxtUltFolio.Text 'BscFolio
            VerNota.Nosucursal = LblSucF.Text
            VerNota.ShowDialog()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        txtCantidad.Text = "0"
        lbTotal.Text = "$ 0.00"
        Timer2.Enabled = False
    End Sub

    Private Sub cmdMetas_Click(sender As Object, e As EventArgs) Handles cmdMetas.Click
        Dim frm As New frmMetas
        frm.Sucursal = NoSucursal
        frm.ShowDialog()
    End Sub

    Private Sub VBEmpresa_Click(sender As Object, e As EventArgs) Handles VBEmpresa.Click
        FiltrarEmpresa()
        ConTarjeta = False
        ConTarjetaP = False
        TxtTarjeta.BackColor = Color.White
    End Sub

    Private Sub Filtra_bloqFisicas()
        Try
            Dim filtro As String = String.Empty
            If txtNombres.Text.Trim <> "" And txtApellidos.Text.Trim <> "" Then
                filtro += "[NomCompleto] like '%" & txtNombres.Text.Trim & "%' and"
                filtro += "[NomCompleto] like '%" & txtApellidos.Text.Trim & "%' and"
                If filtro.Trim().Length > 1 Then
                    filtro = filtro.Remove(filtro.Length - 3, 3)
                End If
                filtro += " or [Alias] like '%" & txtNombres.Text.Trim & "%' and [Alias] like '%" & txtApellidos.Text.Trim & "%'"

                source_BloqFisicas.Filter = filtro
                If source_BloqFisicas.Count = 0 Then
                    'todo ok
                Else
                    Dim notificacion As New FrmNotificacionPersonasBloqueadas
                    notificacion.ShowDialog()
                    If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                        pnlOperaciones.Enabled = False
                        PictureBox1.Enabled = False
                        Dim frmAlerta As New FrmAlerta
                        frmAlerta.monto = "0"
                        frmAlerta.empleado = Cajero
                        frmAlerta.usuario = txtNombres.Text.Trim & " " & txtApellidos.Text.Trim
                        If nombre_completo.Trim <> "" Then
                            frmAlerta.usuario = nombre_completo
                        End If
                        frmAlerta.divisa = ""
                        frmAlerta.operacion = ""
                        frmAlerta.sucursal = Me.Text
                        frmAlerta.no_caje = No_cajero
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

    Private Sub cmdCelularVerde_Click(sender As Object, e As EventArgs) Handles cmdCelularVerde.Click
        Dim frm As New frmCelular
        frm.ColorTarjeta = "VERDE"
        frm.ShowDialog()

        If frm.NumTarjeta <> "" Then
            NumeroCelular = frm.NumCelular
            TxtTarjeta.Text = frm.NumTarjeta
            Consultar_Tarjeta_Verde("Sin")
        End If
        If frm.FechaEmvioP = "" Then
            txtid.Text = ""
            txtid.Enabled = False
        End If
    End Sub

    Private Sub cmdCelularRojo_Click(sender As Object, e As EventArgs) Handles cmdCelularRojo.Click
        Dim frm As New frmCelular
        frm.ColorTarjeta = "ROJO"
        frm.ShowDialog()
        If frm.Cliente <> "" Then
            NumeroCelular = frm.NumCelular
            txtid.Text = frm.Cliente
            Consultar_Tarjeta_Roja("Sin")
        End If
    End Sub

    Private Sub ElWord()
        Dim miWord As New Word.Application
        'Creamos una instancia de Word
        miWord = CreateObject("Word.Application")
        miWord.Documents.Open(Application.StartupPath & "\Oficio.doc")
        miWord.Visible = True

        With miWord.ActiveDocument.Bookmarks
            .Item("fecha").Range.Text = Date.Now.ToString("dd/MM/yyyy")
            .Item("d1").Range.Text = txtNombres.Text
            .Item("d2").Range.Text = txtApellidos.Text
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
            If txtNombres.Text.Trim <> "" And txtApellidos.Text.Trim <> "" Then
                filtro += "[Nombre] like '" & txtNombres.Text.Trim & "' and "
                filtro += "[ApellidoPaterno] like '%" & txtApellidos.Text.Trim & "%' and "
                If filtro.Trim().Length > 1 Then
                    filtro = filtro.Remove(filtro.Length - 4, 4)
                End If

                source_PPoliticas.Filter = filtro
                If source_PPoliticas.Count = 0 Then
                    'todo ok
                Else
                    Dim notificacion As New FrmNotificacionPersonasPoliticas
                    notificacion.ShowDialog()
                    If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                        pnlOperaciones.Enabled = False
                        PictureBox1.Enabled = False
                        'pnlCalculadora.Enabled = False
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
            .Item("Nombre").Range.Text = txtNombres.Text & " " & txtApellidos.Text
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
            .Item("Nombre").Range.Text = txtNombres.Text & " " & txtApellidos.Text
        End With
        miWord = Nothing
    End Sub

    Private Sub vbtnRInventarios_Click(sender As Object, e As EventArgs) Handles vbtnRInventarios.Click
        Dim form As New FrmTransferencias
        If ConTarjeta Or ConTarjetaP Then
            If MsgBox("Se escaneo una Tarjeta, si sale de la opcion tendra que escanearla de nuevo, desea continuar?", vbOKCancel) = vbCancel Then
                VButton1_Click(sender, e)
                Exit Sub
            End If
        End If
        form.No_sucursal = No_sucursal
        form.UsuarioT = UsuarioL
        form.Nombre_sucursal = Nombre_sucursal
        form.ShowDialog()
        ChecarTransferencias()
    End Sub

    Private Sub BtnFraccionar_Click(sender As Object, e As EventArgs) Handles BtnFraccionar.Click
        cambio = False
        Select Case tipdivi
            Case 1
                Dim form As New FrmFraccionarD
                form.No_Sucursal = No_sucursal
                form.DolarEfec = txtmonto1.Text
                form.PrecioD = txtcd1.Text
                form.ShowDialog()
                form.Dispose()
            Case 2
                Dim form As New FrmFraccionarE
                form.No_Sucursal = No_sucursal
                form.DolarEfec = txtmonto1.Text
                form.PrecioD = txtcd2.Text
                form.ShowDialog()
                form.Dispose()
            Case 3
                Dim form As New FrmFraccionarDC
                form.No_Sucursal = No_sucursal
                form.DolarEfec = txtmonto1.Text
                form.PrecioD = txtcd3.Text
                form.ShowDialog()
                form.Dispose()
            Case 4
                Dim form As New FrmFraccionarL
                form.No_Sucursal = No_sucursal
                form.DolarEfec = txtmonto1.Text
                form.PrecioD = txtcd4.Text
                form.ShowDialog()
                form.Dispose()
        End Select
        vbtnd4_Click(sender, e)
    End Sub

    Private Sub BtnCambio_Click(sender As Object, e As EventArgs) Handles BtnCambio.Click
        'Dim frm As New FrmCambioD
        'frm.FolioFActura = txtFolio.Text.Trim
        'frm.No_Sucursal = No_sucursal
        'frm.PrecioD = txtcd1.Text
        'frm.cliente = idcli
        'frm.totalvender = CInt(txtmonto2.Text)
        'frm.ShowDialog()
        'cambio = frm.cambioEfectuado
        'If cambio Then
        '    txtsubto.Text = CDbl(txtsubto.Text) - frm.TotalDev
        '    txtsubto.Text = "$" & FormatNumber(txtsubto.Text, 2)
        '    vbtnd4.Enabled = False
        'End If
        'frm.Dispose()
    End Sub

    Private Sub TxtTarjeta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTarjeta.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Consultar_Tarjeta_Verde("Con")
        End If
    End Sub

    Sub Consultar_Tarjeta_Verde(ConSin As String)
        If ConSin = "Con" Then
            TarjetaVir = TxtTarjeta.Text
            If TxtTarjeta.Text <> "" Then
                If chGrupo.Checked Then
                    MsgBox("Tiene seleccionado NOTA DE GRUPO, favor de terminar las " & vbCrLf & "NOTAS DE GRUPO", vbInformation)
                    Exit Sub
                End If
                If UCase(Mid(TarjetaVir, Len(TarjetaVir), 1)) <> "P" Then
                    MsgBox("Debe de escanear la tarjeta", vbInformation)
                    Exit Sub
                End If
                TxtTarjeta.Text = TarjetaVir.Substring(0, Len(TarjetaVir) - 1)
                idcli = oclientescnbvC.clientecnbvTarjeta(TxtTarjeta.Text.Trim)
                If idcli = 0 Then
                    MsgBox("No Existe la Tarjeta", MsgBoxStyle.Information)
                Else
                    infocliente()
                    ConTarjeta = True
                    oPuntos.ActivarTarjeta(TxtTarjeta.Text)
                    TxtTarjeta.BackColor = Color.Green
                    Dim ruta As String = "C:\CBProveedor\Tarjetas.txt"
                    Dim escritor As StreamWriter
                    escritor = File.AppendText(ruta)
                    escritor.Write(TxtTarjeta.Text & " " & Now & " " & NoSucursal & vbCrLf)
                    escritor.Flush()
                    escritor.Close()
                    txtmonto1.Focus()
                End If
            End If
        Else
            TarjetaVir = TxtTarjeta.Text
            If TxtTarjeta.Text <> "" Then
                If chGrupo.Checked Then
                    MsgBox("Tiene seleccionado NOTA DE GRUPO, favor de terminar las " & vbCrLf & "NOTAS DE GRUPO", vbInformation)
                    Exit Sub
                End If
                TxtTarjeta.Text = TarjetaVir
                idcli = oclientescnbvC.clientecnbvTarjeta(TxtTarjeta.Text.Trim)
                If idcli = 0 Then
                    MsgBox("No Existe la Tarjeta", MsgBoxStyle.Information)
                ElseIf oPuntos.ConsultaActTar(idcli) = 0 Then
                    MsgBox("Tienen que escanear el QR la primera vez", MsgBoxStyle.Information)
                Else
                    infocliente()
                    ConTarjeta = True
                    TxtTarjeta.BackColor = Color.Green
                    Dim ruta As String = "C:\CBProveedor\Tarjetas.txt"
                    Dim escritor As StreamWriter
                    escritor = File.AppendText(ruta)
                    escritor.Write(TxtTarjeta.Text & " " & Now & " " & NoSucursal & vbCrLf)
                    escritor.Flush()
                    escritor.Close()
                    txtmonto1.Focus()
                End If
            End If
        End If
    End Sub

    Sub Consultar_Tarjeta_Roja(ConSin As String)
        If ConSin = "Con" Then
            TarjetaCompra = txtid.Text
            If UCase(Mid(TarjetaCompra, Len(TarjetaCompra), 1)) <> "P" Then
                MsgBox("Debe de escanear la tarjeta", vbInformation)
                Exit Sub
            End If
            If UCase(Mid(TarjetaCompra, 1, 2)) = "00" Then
                TarjetaCompra = TarjetaCompra.Substring(0, Len(TarjetaCompra) - 1)
                txtid.Text = TarjetaCompra.Substring(2, Len(TarjetaCompra) - 2)
            Else
                txtid.Text = TarjetaCompra.Substring(0, Len(TarjetaCompra) - 1)
            End If
            If txtid.Text.Length > 9 Then
                Exit Sub
            End If
            idcli = Convert.ToInt32(txtid.Text)
            infocliente()
            txtid.BackColor = Color.Red
            ConTarjetaP = True
            Dim ruta As String = "C:\CBProveedor\Tarclientes.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.Write(txtid.Text & " " & Now & " " & NoSucursal & vbCrLf)
            escritor.Flush()
            escritor.Close()
            txtmonto1.Focus()
        Else
            TarjetaCompra = txtid.Text

            If UCase(Mid(TarjetaCompra, 1, 2)) = "00" Then
                TarjetaCompra = TarjetaCompra.Substring(0, Len(TarjetaCompra) - 1)
                txtid.Text = TarjetaCompra.Substring(2, Len(TarjetaCompra) - 2)
            Else
                txtid.Text = TarjetaCompra
            End If

            If txtid.Text.Length > 9 Then
                Exit Sub
            End If
            idcli = Convert.ToInt32(txtid.Text)
            infocliente()
            txtid.BackColor = Color.Red
            ConTarjetaP = True
            Dim ruta As String = "C:\CBProveedor\Tarclientes.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.Write(txtid.Text & " " & Now & " " & NoSucursal & vbCrLf)
            escritor.Flush()
            escritor.Close()
            txtmonto1.Focus()
        End If
    End Sub
    Private Sub vbPuntos_Click(sender As Object, e As EventArgs) Handles vbPuntos.Click
        If TxtTarjeta.Text.Trim <> "" And idcli <> 0 Then
            If ConTarjeta Then
                Dim frmM As New FrmMensajePts
                Dim canjear As Boolean = False
                frmM.ClienteCanj = idcli
                frmM.TarjetaCanj = TxtTarjeta.Text.Trim
                frmM.NoSucursalCanj = No_sucursal
                frmM.DeCaja = False
                frmM.ShowDialog()
                canjear = frmM.canjearPts
                If frmM.CambioTarjeta = True Then
                    TxtTarjeta.Text = frmM.TarjetaN
                End If
                frmM.Dispose()
            Else
                MsgBox("Debe de escanear la Tarjeta para Canjear o Consultar los Puntos", vbInformation)
                TxtTarjeta.Focus()
            End If
        End If
    End Sub

    Private Sub vbtnRGastos_Click(sender As Object, e As EventArgs) Handles vbtnRGastos.Click
        Dim form As New FrmGatos
        form.No_sucursal = NoSucursal
        form.ShowDialog()
        form.Dispose()
    End Sub

    Private Sub vbtndAlarma_Click(sender As Object, e As EventArgs) Handles vbtndAlarma.Click
        Dim form As New FrmAlerta
        form.empleado = UsuarioR
        form.usuario = UsuarioL
        form.sucursal = NomSucursal
        form.ShowDialog()
        form.Dispose()
    End Sub

    Private Sub ChecarActPrecios()
        dt3 = otipodivisasC.Stipodivisas2(No_sucursal).Tables(0)
        For Each dr As DataRow In dt3.Rows
            Select Case CInt(dr("tipo"))
                Case 1
                    If CDbl(txtcd1.Text) <> Format(CDbl(dr("Compra")), "##0.00") Or CDbl(txtvd1.Text) <> Format(CDbl(dr("Venta")), "##0.00") Then
                        vbtnRCaja.VIBlendTheme = VIBLEND_THEME.METROORANGE
                    End If
                Case 2
                    If CDbl(txtcd2.Text) <> Format(CDbl(dr("Compra")), "##0.00") Or CDbl(txtvd2.Text) <> Format(CDbl(dr("Venta")), "##0.00") Then
                        vbtnRCaja.VIBlendTheme = VIBLEND_THEME.METROORANGE
                    End If
                Case 3
                    If CDbl(txtcd3.Text) <> Format(CDbl(dr("Compra")), "##0.00") Or CDbl(txtvd3.Text) <> Format(CDbl(dr("Venta")), "##0.00") Then
                        vbtnRCaja.VIBlendTheme = VIBLEND_THEME.METROORANGE
                    End If
                Case 4
                    If CDbl(txtcd4.Text) <> Format(CDbl(dr("Compra")), "##0.00") Or CDbl(txtvd4.Text) <> Format(CDbl(dr("Venta")), "##0.00") Then
                        vbtnRCaja.VIBlendTheme = VIBLEND_THEME.METROORANGE
                    End If
                Case 5
                    If CDbl(txtcd5.Text) <> Format(CDbl(dr("Compra")), "##0.00") Or CDbl(txtvd5.Text) <> Format(CDbl(dr("Venta")), "##0.00") Then
                        vbtnRCaja.VIBlendTheme = VIBLEND_THEME.METROORANGE
                    End If
                Case 6
                    If CDbl(txtcd6.Text) <> Format(CDbl(dr("Compra")), "##0.00") Or CDbl(txtvd6.Text) <> Format(CDbl(dr("Venta")), "##0.00") Then
                        vbtnRCaja.VIBlendTheme = VIBLEND_THEME.METROORANGE
                    End If
                Case 7
                    If CDbl(txtcd7.Text) <> Format(CDbl(dr("Compra")), "##0.00") Or CDbl(txtvd7.Text) <> Format(CDbl(dr("Venta")), "##0.00") Then
                        vbtnRCaja.VIBlendTheme = VIBLEND_THEME.METROORANGE
                    End If
                Case 8
                    If CDbl(txtcd8.Text) <> Format(CDbl(dr("Compra")), "##0.00") Or CDbl(txtvd8.Text) <> Format(CDbl(dr("Venta")), "##0.00") Then
                        vbtnRCaja.VIBlendTheme = VIBLEND_THEME.METROORANGE
                    End If
            End Select
        Next
    End Sub

    Private Sub ChecarTransferencias()
        If otipodivisasC.Transferencias(No_sucursal) > 0 Then
            vbtnRInventarios.VIBlendTheme = VIBLEND_THEME.METROORANGE
            vbtndSalir.Enabled = False
        Else
            vbtnRInventarios.VIBlendTheme = VIBLEND_THEME.BLUEBLEND
            vbtndSalir.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If UsuarioL <> "" Then
            ChecarActPrecios()
            ChecarTransferencias()
        End If
    End Sub

    Private Sub txtmonto1_Enter(sender As Object, e As EventArgs) Handles txtmonto1.Enter
        If txtmonto1.Text = "0" Then
            txtmonto1.Text = ""
        End If
        If CInt(idcli) = 0 Then
            MessageBox.Show("SELECCIONE UN CLIENTE ANTES DE CONTINUAR")
            txtmonto1.Text = "0"
            txtApellidos.Focus()
        End If
    End Sub

    Private Sub vbtnRTransferencia_Click(sender As Object, e As EventArgs) Handles vbtnRTransferencia.Click
        Dim form As New Traspasos
        form.sucursal = No_sucursal
        form.txtNombre.Text = Cajero
        form.ShowDialog()
    End Sub

    Private Sub txtpesos_Enter(sender As Object, e As EventArgs) Handles txtpesos.Enter
        If txtpesos.Text = "0" Then
            txtpesos.Text = ""
        End If
        If CInt(idcli) = 0 Then
            MessageBox.Show("SELECCIONE UN CLIENTE ANTES DE CONTINUAR")
            txtpesos.Text = "0"
            txtApellidos.Focus()
        End If
    End Sub

    Private Sub txtpesos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpesos.KeyPress
        oauxiliares.SoloNumeros(e)
        If Asc(e.KeyChar) = 13 Then
            If IsNumeric(txtpesos.Text.Trim) And precioCoV > 0 Then
                Dim divisas As Double = 0
                Dim importe As Integer = 0
                divisas = txtpesos.Text.Trim / precioCoV
                importe = Int(divisas)
                txtpesos.Text = FormatNumber(importe * precioCoV, 2)
                txtmonto1.Text = importe
                If tipdivi > 0 And idcli > 0 Then
                    Limites(sender, e)
                End If
            End If
        End If
    End Sub

    Private Sub txtpesos_Leave(sender As Object, e As EventArgs) Handles txtpesos.Leave
        If txtpesos.Text = "" Then
            txtpesos.Text = "0"
        End If
    End Sub

    Function validarcliente(ByVal NombreX As String, ByVal ApePaternoX As String, ApeMaternoX As String) As Boolean
        Dim valor As Boolean = True
        If oPersonasPoliticasEC.PersonaBF(NombreX, ApePaternoX, ApeMaternoX) > 0 Then
            valor = False
            Dim notificacion As New FrmNotificacionPersonasBloqueadas
            notificacion.ShowDialog()
            If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                pnlOperaciones.Enabled = False
                PictureBox1.Enabled = False
                'pnlCalculadora.Enabled = False
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
        If oPersonasPoliticasEC.PersonaPE(NombreX, ApePaternoX, ApeMaternoX) > 0 Or oPersonasPoliticasEC.PersonaPEEx(NombreX, ApePaternoX, ApeMaternoX) > 0 Then
            valor = False
            Dim notificacion As New FrmNotificacionPersonasPoliticas
            notificacion.ShowDialog()
            If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                pnlOperaciones.Enabled = False
                PictureBox1.Enabled = False
                'pnlCalculadora.Enabled = False
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
        If oPersonasPoliticasEC.ListaInt(NombreX, ApePaternoX, ApeMaternoX) > 0 Or oPersonasPoliticasEC.ListaOFAC(NombreX, ApePaternoX, ApeMaternoX) > 0 Then
            valor = False
            Dim notificacion As New FrmNotificacionPersBloqListaInt
            notificacion.ShowDialog()
            If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                pnlOperaciones.Enabled = False
                PictureBox1.Enabled = False
            End If
        End If

        If oPersonasPoliticasEC.ListaPersonasBloqueadas(NombreX & " " & ApePaternoX & " " & ApeMaternoX) > 0 Or oPersonasPoliticasEC.ListaOFAC(NombreX, ApePaternoX, ApeMaternoX) > 0 Or oPersonasPoliticasEC.ListaPersonasBloqueadas(ApePaternoX & " " & ApeMaternoX & " " & NombreX) > 0 Then
            valor = False
            Dim notificacion As New FrmNotificacionPersBloqListaInt
            notificacion.ShowDialog()
            If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                pnlOperaciones.Enabled = False
                PictureBox1.Enabled = False
            End If
        End If

        If oPersonasPoliticasEC.ListaPersonasBloqueadas(ApePaternoX & " " & ApeMaternoX & " " & NombreX) > 0 Or oPersonasPoliticasEC.ListaOFAC(NombreX, ApePaternoX, ApeMaternoX) > 0 Or oPersonasPoliticasEC.ListaPersonasBloqueadas(ApePaternoX & " " & ApeMaternoX & " " & NombreX) > 0 Then
            valor = False
            Dim notificacion As New FrmNotificacionPersBloqListaInt
            notificacion.ShowDialog()
            If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                pnlOperaciones.Enabled = False
                PictureBox1.Enabled = False
            End If
        End If

        If oPersonasPoliticasEC.ListaPersonas69B(NombreX & " " & ApePaternoX & " " & ApeMaternoX, "FI") > 0 Or oPersonasPoliticasEC.ListaOFAC(NombreX, ApePaternoX, ApeMaternoX) > 0 Or oPersonasPoliticasEC.ListaPersonasBloqueadas(ApePaternoX & " " & ApeMaternoX & " " & NombreX) > 0 Then
            valor = False
            Dim notificacion As New FrmNotificacionLista69B
            notificacion.ShowDialog()
            If notificacion.Valor = "OK" Then
                pnlOperaciones.Enabled = False
                PictureBox1.Enabled = False
            End If
        End If

        If oPersonasPoliticasEC.ListaPersonas69B(ApePaternoX & " " & ApeMaternoX & " " & NombreX, "FI") > 0 Or oPersonasPoliticasEC.ListaOFAC(NombreX, ApePaternoX, ApeMaternoX) > 0 Or oPersonasPoliticasEC.ListaPersonasBloqueadas(ApePaternoX & " " & ApeMaternoX & " " & NombreX) > 0 Then
            valor = False
            Dim notificacion As New FrmNotificacionLista69B
            notificacion.ShowDialog()
            If notificacion.Valor = "OK" Then
                pnlOperaciones.Enabled = False
                PictureBox1.Enabled = False
            End If
        End If

        If oPersonasPoliticasEC.ListaPersonas69B(NombreX & " " & ApePaternoX & " " & ApeMaternoX, "MO") > 0 Or oPersonasPoliticasEC.ListaOFAC(NombreX, ApePaternoX, ApeMaternoX) > 0 Or oPersonasPoliticasEC.ListaPersonasBloqueadas(ApePaternoX & " " & ApeMaternoX & " " & NombreX) > 0 Then
            valor = False
            Dim notificacion As New FrmNotificacionLista69B
            notificacion.ShowDialog()
            If notificacion.Valor = "OK" Then
                pnlOperaciones.Enabled = False
                PictureBox1.Enabled = False
            End If
        End If

        If oPersonasPoliticasEC.ListaPersonas69B(ApePaternoX & " " & ApeMaternoX & " " & NombreX, "MO") > 0 Or oPersonasPoliticasEC.ListaOFAC(NombreX, ApePaternoX, ApeMaternoX) > 0 Or oPersonasPoliticasEC.ListaPersonasBloqueadas(ApePaternoX & " " & ApeMaternoX & " " & NombreX) > 0 Then
            valor = False
            Dim notificacion As New FrmNotificacionLista69B
            notificacion.ShowDialog()
            If notificacion.Valor = "OK" Then
                pnlOperaciones.Enabled = False
                PictureBox1.Enabled = False
            End If
        End If

        If oPersonasPoliticasEC.ListaReportados(NombreX, ApePaternoX, ApeMaternoX) > 0 Then
            Dim oAlertaC As New alertasC
            Dim oAlertaM As New alertasM
            valor = False
            Dim notificacion As New FrmNotificacionPersBloqListaInt
            notificacion.ShowDialog()
            If notificacion.DialogResult = Windows.Forms.DialogResult.OK Then
                pnlOperaciones.Enabled = False
                PictureBox1.Enabled = False
                oAlertaM.Sucursal = NomSucursal
                oAlertaM.Fecha = Date.Now.ToShortDateString
                oAlertaM.Hora = Date.Now
                oAlertaM.Empleado = UsuarioR
                oAlertaM.Motivo = ""
                oAlertaM.Operacion = ""
                oAlertaM.Monto = 0
                oAlertaM.Divisa = 1
                oAlertaM.Observaciones = ""
                oAlertaM.Usuario = UsuarioL
                If oAlertaC.Alta(oAlertaM) = 1 Then
                    MessageBox.Show("Alerta Guardada")
                End If
            End If
        End If

        Return valor
    End Function

    Function RevisarLimite(Tipo As Integer) As Boolean
        conn.EstablecerConexion()
        conn.AbrirConexion()

        cmd = New SqlCommand("select SUM((divisas.valor * sf)) as Total " &
                "From " &
                "Existencia INNER JOIN divisas ON Existencia.divisa = divisas.codigo " &
                "Where " &
                "fecha = '" & Format(Now.Date, "dd/MM/yyyy") & "' AND Existencia.tipo = " & Tipo, conn.con)
        lector = cmd.ExecuteReader

        While lector.Read
            TotalInventario = lector(0) * precioCoV
        End While
        lector.Close()
        cmd = Nothing

        cmd = New SqlCommand("Select limiteC From limitegral Where tipo = " & Tipo, conn.con)
        lector = cmd.ExecuteReader

        While lector.Read
            LimiteGral = lector(0)
        End While
        lector.Close()
        cmd = Nothing

        If LimiteGral > 0 Then
            If TotalInventario + CDbl(txtpesos.Text) > LimiteGral Then
                MessageBox.Show("Llego al limite de Compra de la Divisa que es de: " & LimiteGral & " MXN")
                Return False
            End If
        End If
        Return True
    End Function

    Sub HabilitarBotones()
        conn.EstablecerConexion()
        conn.AbrirConexion()
        Dim TotalDivisas As Double = 0
        Dim Y As Double = 0

        cmd = New SqlCommand("Select COUNT(*) as Total From divisas Where tipo = " & tipdivi, conn.con)
        lector = cmd.ExecuteReader

        While lector.Read
            TotalDivisas = lector(0)
        End While

        lector.Close()
        cmd = Nothing
        filtrardt2(tipdivi)

        For Y = 1 To TotalDivisas
            Select Case Y
                Case 1
                    btnb1.Enabled = True
                Case 2
                    btnb2.Enabled = True
                Case 3
                    btnb3.Enabled = True
                Case 4
                    btnb4.Enabled = True
                Case 5
                    btnb5.Enabled = True
                Case 6
                    btnb6.Enabled = True
                Case 7
                    btnb7.Enabled = True
            End Select
        Next
    End Sub

    Function RevisarLimiteCompra(Tipo As Integer) As Boolean
        conn.EstablecerConexion()
        conn.AbrirConexion()

        cmd = New SqlCommand("Select * From limitescompra Where tipoDivisa = " & Tipo, conn.con)
        lector = cmd.ExecuteReader

        While lector.Read
            MontoMaxCompra = lector(1)
            AcumMaxCompra = lector(2)
        End While
        lector.Close()
        cmd = Nothing

        If MontoMaxCompra > 0 Then
            If CDbl(txtmonto1.Text) > MontoMaxCompra Then
                MessageBox.Show("El Maximo de Compra de la Divisa que es de: " & MontoMaxCompra)
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub Siguiente_Folio(ByVal Sucursal As String)
        Dim tConection As New SqlConnection(conser)

        ArchivoSer = New System.IO.StreamReader("servidor.txt")
        conser = ArchivoSer.ReadLine
        ArchivoSer.Close()

        tConection.Open()
        Cadena = "update Sucursales set folio_NC=folio_NC+1 where id='" & Sucursal & "';"
        Comando = New SqlCommand(Cadena, tConection)
        Comando.ExecuteNonQuery()

        Cadena = "Select folio_NC From Sucursales Where id = '" & Sucursal & "'"
        Comando = New SqlCommand(Cadena, tConection)
        lector = Comando.ExecuteReader()
        While lector.Read
            FolioNC = lector(0)
        End While
        lector.Close()
        tConection.Close()
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

        Dim tConection As New SqlConnection(conser)

        ArchivoSer = New System.IO.StreamReader("servidor.txt")
        conser = ArchivoSer.ReadLine
        ArchivoSer.Close()

        tConection.Open()

        Comando = New SqlCommand(sql & strSet, tConection)

        If Comando.ExecuteNonQuery() <= 0 Then
            MsgBox("Registro no Guardado", MsgBoxStyle.Information)
        End If
        tConection.Close()
    End Sub
End Class
