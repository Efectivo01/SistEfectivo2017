Public Class CAJAM
    Dim Fecha_ As Date
    Dim movimiento_, tipo_, Referencia_, BC_ As String
    Dim Folio_ As Integer
    Dim TOTAL_, valor_ As Decimal
    Dim sucursal_ As String

    Dim Avaluo_, Prestamo_ As Integer

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

    Public Property tipo() As String
        Get
            Return Me.tipo_
        End Get
        Set(ByVal Value As String)
            Me.tipo_ = Value
        End Set
    End Property

    Public Property Referencia() As String
        Get
            Return Me.Referencia_
        End Get
        Set(ByVal Value As String)
            Me.Referencia_ = Value
        End Set
    End Property

    Public Property BC() As String
        Get
            Return Me.BC_
        End Get
        Set(ByVal Value As String)
            Me.BC_ = Value
        End Set
    End Property

    Public Property Folio() As Integer
        Get
            Return Me.Folio_
        End Get
        Set(ByVal Value As Integer)
            Me.Folio_ = Value
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

    Public Property valor() As Decimal
        Get
            Return Me.valor_
        End Get
        Set(ByVal Value As Decimal)
            Me.valor_ = Value
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
