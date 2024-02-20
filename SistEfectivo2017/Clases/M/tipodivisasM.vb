Public Class tipodivisasM
    Dim tipo_ As Integer
    Dim Nombre_ As String
    Dim Compra_ As Double
    Dim Venta_ As Double

    Public Property tipo() As Integer
        Get
            Return Me.tipo_
        End Get
        Set(ByVal Value As Integer)
            Me.tipo_ = Value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return Me.Nombre_
        End Get
        Set(ByVal Value As String)
            Me.Nombre_ = Value
        End Set
    End Property

    Public Property Compra() As Double
        Get
            Return Me.Compra_
        End Get
        Set(ByVal Value As Double)
            Me.Compra_ = Value
        End Set
    End Property

    Public Property Venta() As Double
        Get
            Return Me.Venta_
        End Get
        Set(ByVal Value As Double)
            Me.Venta_ = Value
        End Set
    End Property

    Dim nosucursal_ As String
    Public Property nosucursal() As String
        Get
            Return Me.nosucursal_
        End Get
        Set(ByVal Value As String)
            Me.nosucursal_ = Value
        End Set
    End Property
End Class
