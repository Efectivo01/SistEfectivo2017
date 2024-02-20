Public Class FrmMensajePts
    Public canjearPts As Boolean = False
    Public PuntosCanj As Double
    Public PuntosCanj2 As Double = 0
    Public PuntosCanj3 As Double = 0
    Public PesosCanj As Double
    Public DolaresCanj As Integer
    Public ClienteCanj As Integer
    Public TarjetaCanj As String
    Public NoSucursalCanj As String
    Public PrecioCanj As Double
    Public PrecioCanjPesos As Double
    Dim oPuntos As New CPuntos
    Public DeCaja As Boolean
    Public MaximoPtsCaja As Boolean = False
    Public CambioTarjeta As Boolean = False
    Public TarjetaN As String
    Dim dt1Promo As New DataTable
    Public ValorPts As Double
    Public ValorPts2 As Double

    Private Sub FrmMensajePts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DeCaja = False Then
            If MaximoPtsCaja = True Then
                BtnCancelar.Enabled = False
                BtnCuentaTic.Enabled = False
                BtnCuenta.Enabled = False
                TxtFolioNC.Enabled = False
                BtnImprmir.Enabled = False
            Else
                BtnCancelar.Enabled = True
                BtnCuentaTic.Enabled = True
                BtnCuenta.Enabled = True
                TxtFolioNC.Enabled = True
                BtnImprmir.Enabled = True
            End If
            
            dt1Promo = oPuntos.Promociones("VENTA").Tables(0)
            For Each dr As DataRow In dt1Promo.Rows
                'checar cuanto tiempo ya paso sin generar puntos
                'dependiendo del resulta si tiene mas de 30 dias se eliminan los puntos
                If oPuntos.ChecarDiasPts(TarjetaCanj) > dr("DiasSinCompra") Then
                    'Eliminar los puntos
                    oPuntos.UpdatePtsCanjeados(0, TarjetaCanj)
                End If

                'checar de donde se abre la ventana, d caja o d clientes
                'si es de clientes hay que consultar si realizo una operacion el cliente de compra de dolares, venta de dolares para nosotros.
                'luego checar el precio que nosotros estamos vendiendo los dolares
                'y checar cuantos puntos tiene el cliente
                PrecioCanj = PrecioVenta(NoSucursalCanj)
                PrecioCanjPesos = PrecioCompra(NoSucursalCanj)
                PuntosCanj = oPuntos.ChecarPuntos2(TarjetaCanj)
                If PuntosCanj >= dr("MaximoPts") Then
                    ValorPts = dr("ValorPtsMax")
                    PuntosCanj2 = PuntosCanj - 5000
                    PuntosCanj3 = 5000
                    PesosCanj = PuntosCanj3 * ValorPts
                    PesosCanj = PesosCanj + (PuntosCanj2 * dr("ValorPts"))
                    LblPesos.Text = 0
                    LbPesos2.Text = ValorPts
                    LbPesos3.Text = dr("ValorPts")
                Else
                    ValorPts = dr("ValorPts")
                    PesosCanj = PuntosCanj * ValorPts
                    LblPesos.Text = ValorPts
                    LbPesos2.Text = 0
                    LbPesos3.Text = 0
                End If
                'PesosCanj = PuntosCanj / 100

                DolaresCanj = CInt(Int(PesosCanj / CDbl(PrecioCanj))) 'El precio sale de la consulta anterior
            Next
        Else
            BtnCancelar.Enabled = False
            BtnCuentaTic.Enabled = False
            BtnCuenta.Enabled = False
            TxtFolioNC.Enabled = False
            BtnImprmir.Enabled = False
            LblPesos.Text = 0
            LbPesos2.Text = ValorPts
            LbPesos3.Text = ValorPts2
        End If

        LblPrecioV.Text = Math.Round(PrecioCanj, 2)
        TxtPuntos.Text = PuntosCanj
        TxtPesos.Text = PesosCanj
        TxtDolares.Text = DolaresCanj
        'txtEqPesos.Text = DolaresCanj * PrecioCanjPesos
        If DolaresCanj > 0 Then
            'If oPuntos.Consulta2Compras(ClienteCanj) >= 2 Then
            'si realizo compra el dia que quiere canjear los puntos
            If oPuntos.ConsultaComprasPts(ClienteCanj, Now.ToShortDateString, NoSucursalCanj) > 0 Then
                BtnCanjear.Enabled = True
            Else
                If oPuntos.ConsultaComprasPts(ClienteCanj, Now.ToShortDateString, "08") > 0 Then
                    BtnCanjear.Enabled = True
                Else
                    BtnCanjear.Enabled = False
                End If
            End If
            'Else
            'BtnCanjear.Enabled = False
            'End If
        Else
            BtnCanjear.Enabled = False
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        canjearPts = False
        Me.Close()
    End Sub

    Private Sub BtnCanjear_Click(sender As Object, e As EventArgs) Handles BtnCanjear.Click
        'Dim precioPts As Double
        Dim puntosTOT As Integer = 0
        Dim puntosMay5 As Double = 0
        Dim pesosMay5 As Double = 0
        Dim pesosMay5R As Double = 0
        Dim puntosMay5R As Double = 0
        Dim puntosMen5 As Double = 0
        Dim pesosMen5 As Double = 0
        Dim residuoPesMay5 As Double = 0
        Dim puntosCanjMay5 As Integer = 0
        Dim puntosCanjMay5R As Integer = 0
        Dim residuoPtsMay5 As Integer = 0
        If CInt(TxtDolares.Text) >= 1 Then
            Dim frm As New FrmPuntosNC
            frm.cliente = ClienteCanj
            'para saber cuantos puntos va a canjera
            puntosTOT = TxtPuntos.Text

            If puntosTOT >= 5000 Then
                puntosMay5 = 5000
                pesosMay5 = puntosMay5 * CDbl(LbPesos2.Text)
                puntosCanjMay5 = Int(pesosMay5 / PrecioCanj)
                If (PuntosCanj - 5000) > 0 Then
                    puntosMay5R = PuntosCanj - 5000
                    If (5000 - puntosCanjMay5) > 0 Then
                        residuoPesMay5 = puntosCanjMay5 * PrecioCanj
                        residuoPtsMay5 = residuoPesMay5 / LbPesos2.Text
                        residuoPtsMay5 = 5000 - residuoPtsMay5
                        residuoPesMay5 = residuoPtsMay5 * CDbl(LbPesos2.Text)
                    Else
                        residuoPesMay5 = 0
                    End If
                    pesosMay5R = puntosMay5R * CDbl(LbPesos3.Text)
                    puntosCanjMay5R = Int((pesosMay5R + residuoPesMay5) / PrecioCanj)
                Else
                    puntosCanjMay5R = 0
                End If
                If puntosCanjMay5 > 0 Then
                    pesosMay5 = puntosCanjMay5 * PrecioCanj
                    PuntosCanj = pesosMay5 / LbPesos2.Text
                    If residuoPesMay5 > 0 Then
                        PuntosCanj = 5000
                    End If
                End If
                If puntosCanjMay5R > 0 Then
                    If residuoPesMay5 > 0 Then
                        pesosMay5R = pesosMay5R - residuoPesMay5
                    End If
                    PuntosCanj = PuntosCanj + (pesosMay5R / LbPesos3.Text)
                End If
            Else
                puntosMen5 = puntosTOT
                pesosMen5 = puntosMen5 * CDbl(LblPesos.Text)
                PuntosCanj = pesosMen5 / CDbl(LblPesos.Text)
            End If

            frm.PuntosC = PuntosCanj
            frm.tarjetaC = TarjetaCanj
            frm.DolaresEntregar = CInt(DolaresCanj)
            frm.No_Sucursal = NoSucursalCanj
            frm.PrecioD = PrecioCanj
            frm.ValorPtsC = ValorPts
            frm.ShowDialog()
            frm.Dispose()
            canjearPts = True
            Me.Close()
        Else
            MsgBox("No Tienes los suficientes puntos para Canjear por Dolares", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub BtnCuenta_Click(sender As Object, e As EventArgs) Handles BtnCuenta.Click
        Dim FrmC As New FrmEstadoCuenta
        FrmC.ECcliente = ClienteCanj
        FrmC.ECnosucursal = NoSucursalCanj
        FrmC.ShowDialog()
        FrmC.Dispose()
    End Sub

    Private Sub BtnImprmir_Click(sender As Object, e As EventArgs) Handles BtnImprmir.Click
        Dim frmnc As New FrmReimprimeNC
        frmnc.FolioReNC = TxtFolioNC.Text.Trim
        frmnc.ClienteNC = ClienteCanj
        frmnc.SucNC = NoSucursalCanj
        frmnc.ShowDialog()
        frmnc.Dispose()
    End Sub

    Private Sub BtnCuentaTic_Click(sender As Object, e As EventArgs) Handles BtnCuentaTic.Click
        BtnCuentaTic.Enabled = False
        Dim FrmC As New FrmEstadoCuentaT
        FrmC.ECcliente = ClienteCanj
        FrmC.ECnosucursal = NoSucursalCanj
        FrmC.ShowDialog()
        FrmC.Dispose()
        BtnCuentaTic.Enabled = True
    End Sub

End Class