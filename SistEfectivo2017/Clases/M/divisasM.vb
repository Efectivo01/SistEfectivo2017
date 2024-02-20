Public Class divisasM
    Dim codigo_, divisa_ As String
    Dim tipo_ As Integer
    Dim valor_, cpromedio_ As Double

    Public Property codigo() As String
        Get
            Return Me.codigo_
        End Get
        Set(ByVal Value As String)
            Me.codigo_ = Value
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

    Public Property valor() As Double
        Get
            Return Me.valor_
        End Get
        Set(ByVal Value As Double)
            Me.valor_ = Value
        End Set
    End Property

    Public Property tipo() As Integer
        Get
            Return Me.tipo_
        End Get
        Set(ByVal Value As Integer)
            Me.tipo_ = Value
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
End Class
