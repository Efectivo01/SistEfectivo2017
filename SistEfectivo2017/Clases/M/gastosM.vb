Public Class gastosM
    Dim concepto_, hora_, referencia_, conceptoDet_, factura_, usuario_ As String
    Dim fecha_ As DateTime
    Dim cajero_, ncorte_ As Integer
    Dim total_ As Double

    Public Property concepto() As String
        Get
            Return Me.concepto_
        End Get
        Set(ByVal Value As String)
            Me.concepto_ = Value
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

    Public Property hora() As String
        Get
            Return Me.hora_
        End Get
        Set(ByVal Value As String)
            Me.hora_ = Value
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

    Public Property ncorte() As Integer
        Get
            Return Me.ncorte_
        End Get
        Set(ByVal Value As Integer)
            Me.ncorte_ = Value
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

    Public Property referencia() As String
        Get
            Return Me.referencia_
        End Get
        Set(ByVal Value As String)
            Me.referencia_ = Value
        End Set
    End Property

    Dim Nosucursal_ As String

    Public Property Nosucursal() As String
        Get
            Return Me.Nosucursal_
        End Get
        Set(ByVal Value As String)
            Me.Nosucursal_ = Value
        End Set
    End Property

    Public Property conceptoDet() As String
        Get
            Return Me.conceptoDet_
        End Get
        Set(ByVal Value As String)
            Me.conceptoDet_ = Value
        End Set
    End Property

    Public Property factura() As String
        Get
            Return Me.factura_
        End Get
        Set(ByVal Value As String)
            Me.factura_ = Value
        End Set
    End Property

    Public Property usuario() As String
        Get
            Return Me.usuario_
        End Get
        Set(ByVal Value As String)
            Me.usuario_ = Value
        End Set
    End Property
End Class
