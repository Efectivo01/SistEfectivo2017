Public Class tinventarioM
    Dim codigo_ As String
    Dim si_, en_, sal_, sf_, cpromedio_, te_ As Double
    Dim ts_ As Double
    Dim fecha_ As DateTime
    Public Property codigo() As String
        Get
            Return Me.codigo_
        End Get
        Set(ByVal Value As String)
            Me.codigo_ = Value
        End Set
    End Property

    Public Property si() As Double
        Get
            Return Me.si_
        End Get
        Set(ByVal Value As Double)
            Me.si_ = Value
        End Set
    End Property

    Public Property en() As Double
        Get
            Return Me.en_
        End Get
        Set(ByVal Value As Double)
            Me.en_ = Value
        End Set
    End Property

    Public Property sal() As Double
        Get
            Return Me.sal_
        End Get
        Set(ByVal Value As Double)
            Me.sal_ = Value
        End Set
    End Property

    Public Property sf() As Double
        Get
            Return Me.sf_
        End Get
        Set(ByVal Value As Double)
            Me.sf_ = Value
        End Set
    End Property

    Public Property cpromedio() As Double
        Get
            Return Me.cpromedio_
        End Get
        Set(ByVal Value As Double)
            Me.cpromedio_ = Value
        End Set
    End Property

    Public Property te() As Double
        Get
            Return Me.te_
        End Get
        Set(ByVal Value As Double)
            Me.te_ = Value
        End Set
    End Property

    Public Property ts() As Double
        Get
            Return Me.ts_
        End Get
        Set(ByVal Value As Double)
            Me.ts_ = Value
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
End Class
