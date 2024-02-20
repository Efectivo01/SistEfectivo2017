Public Class puntosNC
    Dim tarjeta_, folio_factura_, folio_NC_ As String
    Dim fecha_ As DateTime
    Dim estatus_, letra_, nosucursal_ As String
    Dim cliente_, dolares_ As Integer
    Dim puntos_, total_ As Double

    Public Property tarjeta() As String
        Get
            Return Me.tarjeta_
        End Get
        Set(ByVal Value As String)
            Me.tarjeta_ = Value
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

    Public Property folio_NC() As String
        Get
            Return Me.folio_NC_
        End Get
        Set(ByVal Value As String)
            Me.folio_NC_ = Value
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

    Public Property estatus() As String
        Get
            Return Me.estatus_
        End Get
        Set(ByVal Value As String)
            Me.estatus_ = Value
        End Set
    End Property

    Public Property letra() As String
        Get
            Return Me.letra_
        End Get
        Set(ByVal Value As String)
            Me.letra_ = Value
        End Set
    End Property

    Public Property nosucursal() As String
        Get
            Return Me.nosucursal_
        End Get
        Set(ByVal Value As String)
            Me.nosucursal_ = Value
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

    Public Property dolares() As Integer
        Get
            Return Me.dolares_
        End Get
        Set(ByVal Value As Integer)
            Me.dolares_ = Value
        End Set
    End Property

    Public Property puntos() As Double
        Get
            Return Me.puntos_
        End Get
        Set(ByVal Value As Double)
            Me.puntos_ = Value
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
End Class
