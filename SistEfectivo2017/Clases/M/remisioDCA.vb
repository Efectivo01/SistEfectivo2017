Public Class remisioDCA
    Dim folio_factura_, producto_ As String
    Dim cantidads_, p_unitario_, stotal_ As Double
    Dim descuento_ As Integer
    Dim Nosucursal_ As String
    Dim fecha_ As DateTime
    Dim operacion_ As String

    Public Property folio_factura() As String
        Get
            Return Me.folio_factura_
        End Get
        Set(ByVal Value As String)
            Me.folio_factura_ = Value
        End Set
    End Property

    Public Property producto() As String
        Get
            Return Me.producto_
        End Get
        Set(ByVal Value As String)
            Me.producto_ = Value
        End Set
    End Property

    Public Property cantidads() As Double
        Get
            Return Me.cantidads_
        End Get
        Set(ByVal Value As Double)
            Me.cantidads_ = Value
        End Set
    End Property

    Public Property p_unitario() As Double
        Get
            Return Me.p_unitario_
        End Get
        Set(ByVal Value As Double)
            Me.p_unitario_ = Value
        End Set
    End Property

    Public Property stotal() As Double
        Get
            Return Me.stotal_
        End Get
        Set(ByVal Value As Double)
            Me.stotal_ = Value
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

    Dim capacidad_, unidad_, descripcion_larga_ As String

    Public Property capacidad() As String
        Get
            Return Me.capacidad_
        End Get
        Set(ByVal Value As String)
            Me.capacidad_ = Value
        End Set
    End Property

    Public Property unidad() As String
        Get
            Return Me.unidad_
        End Get
        Set(ByVal Value As String)
            Me.unidad_ = Value
        End Set
    End Property


    Public Property descripcion_larga() As String
        Get
            Return Me.descripcion_larga_
        End Get
        Set(ByVal Value As String)
            Me.descripcion_larga_ = Value
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

    Public Property fecha() As DateTime
        Get
            Return Me.fecha_
        End Get
        Set(ByVal Value As DateTime)
            Me.fecha_ = Value
        End Set
    End Property

    Public Property operacion() As String
        Get
            Return Me.operacion_
        End Get
        Set(ByVal Value As String)
            Me.operacion_ = Value
        End Set
    End Property
End Class
