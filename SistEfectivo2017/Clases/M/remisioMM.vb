Public Class remisioMM
    Dim folio_pedido_, folio_factura_, cambio_ As String
    Dim fecha_ As DateTime
    Dim tipo_ As String
    Dim cliente_, vendedor_ As Integer
    Public Property folio_pedido() As String
        Get
            Return Me.folio_pedido_
        End Get
        Set(ByVal Value As String)
            Me.folio_pedido_ = Value
        End Set
    End Property

    Public Property folio_factura() As String
        Get
            Return Me.folio_factura_
        End Get
        Set(ByVal Value As String)
            Me.folio_factura_ = Value
        End Set
    End Property

    Public Property fecha() As DateTime
        Get
            Return Me.fecha_
        End Get
        Set(ByVal Value As DateTime)
            Me.fecha_ = Value
        End Set
    End Property

    Public Property tipo() As String
        Get
            Return Me.tipo_
        End Get
        Set(ByVal Value As String)
            Me.tipo_ = Value
        End Set
    End Property

    Public Property cliente() As Integer
        Get
            Return Me.cliente_
        End Get
        Set(ByVal Value As Integer)
            Me.cliente_ = Value
        End Set
    End Property

    Public Property vendedor() As Integer
        Get
            Return Me.vendedor_
        End Get
        Set(ByVal Value As Integer)
            Me.vendedor_ = Value
        End Set
    End Property

    Dim consignar_dir_, consignar_col_, consignar_est_ As String
    Dim consignar_pais_, sucursal_postal_, condiciones_, estatus_ As String
    Public Property consignar_dir() As String
        Get
            Return Me.consignar_dir_
        End Get
        Set(ByVal Value As String)
            Me.consignar_dir_ = Value
        End Set
    End Property

    Public Property consignar_col() As String
        Get
            Return Me.consignar_col_
        End Get
        Set(ByVal Value As String)
            Me.consignar_col_ = Value
        End Set
    End Property

    Public Property consignar_est() As String
        Get
            Return Me.consignar_est_
        End Get
        Set(ByVal Value As String)
            Me.consignar_est_ = Value
        End Set
    End Property

    Public Property consignar_pais() As String
        Get
            Return Me.consignar_pais_
        End Get
        Set(ByVal Value As String)
            Me.consignar_pais_ = Value
        End Set
    End Property

    Public Property sucursal_postal() As String
        Get
            Return Me.sucursal_postal_
        End Get
        Set(ByVal Value As String)
            Me.sucursal_postal_ = Value
        End Set
    End Property

    Public Property condiciones() As String
        Get
            Return Me.condiciones_
        End Get
        Set(ByVal Value As String)
            Me.condiciones_ = Value
        End Set
    End Property

    Public Property estatus() As String
        Get
            Return Me.estatus_
        End Get
        Set(ByVal Value As String)
            Me.estatus_ = Value
        End Set
    End Property
    Dim stotal_, iva_, total_, saldo_ As Double
    Dim fecha_cobro_ As DateTime
    Dim observaciones_ As String
    Dim descuento_ As Double
    Dim moneda_ As Integer
    Dim tipo_cambio_ As Double
    Public Property stotal() As Double
        Get
            Return Me.stotal_
        End Get
        Set(ByVal Value As Double)
            Me.stotal_ = Value
        End Set
    End Property

    Public Property iva() As Double
        Get
            Return Me.iva_
        End Get
        Set(ByVal Value As Double)
            Me.iva_ = Value
        End Set
    End Property

    Public Property total() As Double
        Get
            Return Me.total_
        End Get
        Set(ByVal Value As Double)
            Me.total_ = Value
        End Set
    End Property

    Public Property saldo() As Double
        Get
            Return Me.saldo_
        End Get
        Set(ByVal Value As Double)
            Me.saldo_ = Value
        End Set
    End Property

    Public Property fecha_cobro() As DateTime
        Get
            Return Me.fecha_cobro_
        End Get
        Set(ByVal Value As DateTime)
            Me.fecha_cobro_ = Value
        End Set
    End Property

    Public Property observaciones() As String
        Get
            Return Me.observaciones_
        End Get
        Set(ByVal Value As String)
            Me.observaciones_ = Value
        End Set
    End Property

    Public Property descuento() As Double
        Get
            Return Me.descuento_
        End Get
        Set(ByVal Value As Double)
            Me.descuento_ = Value
        End Set
    End Property


    Public Property moneda() As Integer
        Get
            Return Me.moneda_
        End Get
        Set(ByVal Value As Integer)
            Me.moneda_ = Value
        End Set
    End Property


    Public Property tipo_cambio() As Double
        Get
            Return Me.tipo_cambio_
        End Get
        Set(ByVal Value As Double)
            Me.tipo_cambio_ = Value
        End Set
    End Property
    Dim letras_ As String
    Dim cajero_ As Integer
    Dim procesado_ As String
    Dim ncorte_ As Integer
    Dim hora_ As DateTime
    Dim Nosucursal_ As String

    Public Property letras() As String
        Get
            Return Me.letras_
        End Get
        Set(ByVal Value As String)
            Me.letras_ = Value
        End Set
    End Property

    Public Property cajero() As Integer
        Get
            Return Me.cajero_
        End Get
        Set(ByVal Value As Integer)
            Me.cajero_ = Value
        End Set
    End Property

    Public Property procesado() As String
        Get
            Return Me.procesado_
        End Get
        Set(ByVal Value As String)
            Me.procesado_ = Value
        End Set
    End Property

    Public Property ncorte() As Integer
        Get
            Return Me.ncorte_
        End Get
        Set(ByVal Value As Integer)
            Me.ncorte_ = Value
        End Set
    End Property

    Public Property hora() As DateTime
        Get
            Return Me.hora_
        End Get
        Set(ByVal Value As DateTime)
            Me.hora_ = Value
        End Set
    End Property

    Public Property Nosucursal() As String
        Get
            Return Me.Nosucursal_
        End Get
        Set(ByVal Value As String)
            Me.Nosucursal_ = Value
        End Set
    End Property

    Dim precio_especial_ As String

    Public Property precio_especial() As String
        Get
            Return Me.precio_especial_
        End Get
        Set(ByVal Value As String)
            Me.precio_especial_ = Value
        End Set
    End Property

    Public Property cambio() As String
        Get
            Return Me.cambio_
        End Get
        Set(ByVal Value As String)
            Me.cambio_ = Value
        End Set
    End Property
End Class
