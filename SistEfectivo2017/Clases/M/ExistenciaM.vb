Public Class ExistenciaM
    Dim fecha_ As DateTime
    Dim divisa_, nosucursal_ As String
    Dim si_, en_, sal_, sf_, te_, ce_, cs_ As Integer
    Dim ts_ As Integer

    Public Property fecha() As DateTime
        Get
            Return Me.fecha_
        End Get
        Set(ByVal Value As DateTime)
            Me.fecha_ = Value
        End Set
    End Property

    Public Property divisa() As String
        Get
            Return Me.divisa_
        End Get
        Set(ByVal Value As String)
            Me.divisa_ = Value
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

    Public Property si() As Integer
        Get
            Return Me.si_
        End Get
        Set(ByVal Value As Integer)
            Me.si_ = Value
        End Set
    End Property

    Public Property en() As Integer
        Get
            Return Me.en_
        End Get
        Set(ByVal Value As Integer)
            Me.en_ = Value
        End Set
    End Property

    Public Property sal() As Integer
        Get
            Return Me.sal_
        End Get
        Set(ByVal Value As Integer)
            Me.sal_ = Value
        End Set
    End Property

    Public Property sf() As Integer
        Get
            Return Me.sf_
        End Get
        Set(ByVal Value As Integer)
            Me.sf_ = Value
        End Set
    End Property


    Public Property te() As Integer
        Get
            Return Me.te_
        End Get
        Set(ByVal Value As Integer)
            Me.te_ = Value
        End Set
    End Property

    Public Property ts() As Integer
        Get
            Return Me.ts_
        End Get
        Set(ByVal Value As Integer)
            Me.ts_ = Value
        End Set
    End Property

    Public Property cs() As Integer
        Get
            Return Me.cs_
        End Get
        Set(ByVal Value As Integer)
            Me.cs_ = Value
        End Set
    End Property

    Public Property ce() As Integer
        Get
            Return Me.ce_
        End Get
        Set(ByVal Value As Integer)
            Me.ce_ = Value
        End Set
    End Property

    Dim precio_ As Double
    Public Property precio() As Double
        Get
            Return Me.precio_
        End Get
        Set(ByVal Value As Double)
            Me.precio_ = Value
        End Set
    End Property

    Dim tipo_ As Integer
    Public Property tipo() As Integer
        Get
            Return Me.tipo_
        End Get
        Set(ByVal Value As Integer)
            Me.tipo_ = Value
        End Set
    End Property
End Class
