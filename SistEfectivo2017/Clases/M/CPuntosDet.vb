Public Class CPuntosDet
    Dim tarjeta_, folio_, NoSuc_ As String
    Dim fecha_ As DateTime
    Dim puntos_ As Double
    Dim cliente_ As Integer
    Public Property tarjeta() As String
        Get
            Return Me.tarjeta_
        End Get
        Set(ByVal Value As String)
            Me.tarjeta_ = Value
        End Set
    End Property

    Public Property folio() As String
        Get
            Return Me.folio_
        End Get
        Set(ByVal Value As String)
            Me.folio_ = Value
        End Set
    End Property

    Public Property NoSuc() As String
        Get
            Return Me.NoSuc_
        End Get
        Set(ByVal Value As String)
            Me.NoSuc_ = Value
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

    Public Property puntos() As Double
        Get
            Return Me.puntos_
        End Get
        Set(ByVal Value As Double)
            Me.puntos_ = Value
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
End Class
