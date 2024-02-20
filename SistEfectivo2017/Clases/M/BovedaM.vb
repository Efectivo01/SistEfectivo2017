Public Class BovedaM
    Dim Fecha_ As Date
    Dim movimiento_, descripcion_, usuario_ As String
    Dim TOTAL_ As Decimal
    Dim sucursal_ As String

    Public Property Fecha() As Date
        Get
            Return Me.Fecha_
        End Get
        Set(ByVal Value As Date)
            Me.Fecha_ = Value
        End Set
    End Property

    Public Property movimiento() As String
        Get
            Return Me.movimiento_
        End Get
        Set(ByVal Value As String)
            Me.movimiento_ = Value
        End Set
    End Property

    Public Property descripcion() As String
        Get
            Return Me.descripcion_
        End Get
        Set(ByVal Value As String)
            Me.descripcion_ = Value
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

    Public Property TOTAL() As Decimal
        Get
            Return Me.TOTAL_
        End Get
        Set(ByVal Value As Decimal)
            Me.TOTAL_ = Value
        End Set
    End Property

    Public Property sucursal() As String
        Get
            Return Me.sucursal_
        End Get
        Set(ByVal Value As String)
            Me.sucursal_ = Value
        End Set
    End Property
End Class
