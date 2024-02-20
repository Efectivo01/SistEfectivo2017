Public Class alertasM
    Dim Id_ As Integer

    Public Property Id() As Integer
        Get
            Return Me.Id_
        End Get
        Set(ByVal Value As Integer)
            Me.Id_ = Value
        End Set
    End Property

    Dim Fecha_, Hora_ As DateTime

    Public Property Fecha() As DateTime
        Get
            Return Me.Fecha_
        End Get
        Set(ByVal Value As DateTime)
            Me.Fecha_ = Value
        End Set
    End Property

    Public Property Hora() As DateTime
        Get
            Return Me.Hora_
        End Get
        Set(ByVal Value As DateTime)
            Me.Hora_ = Value
        End Set
    End Property

    Dim Sucursal_, Empleado_, Motivo_, Operacion_, Observaciones_ As String

    Public Property Sucursal() As String
        Get
            Return Me.Sucursal_
        End Get
        Set(ByVal Value As String)
            Me.Sucursal_ = Value
        End Set
    End Property

    Public Property Empleado() As String
        Get
            Return Me.Empleado_
        End Get
        Set(ByVal Value As String)
            Me.Empleado_ = Value
        End Set
    End Property

    Public Property Motivo() As String
        Get
            Return Me.Motivo_
        End Get
        Set(ByVal Value As String)
            Me.Motivo_ = Value
        End Set
    End Property

    Public Property Operacion() As String
        Get
            Return Me.Operacion_
        End Get
        Set(ByVal Value As String)
            Me.Operacion_ = Value
        End Set
    End Property

    Public Property Observaciones() As String
        Get
            Return Me.Observaciones_
        End Get
        Set(ByVal Value As String)
            Me.Observaciones_ = Value
        End Set
    End Property

    Dim Monto_, Divisa_ As Double

    Public Property Monto() As Double
        Get
            Return Me.Monto_
        End Get
        Set(ByVal Value As Double)
            Me.Monto_ = Value
        End Set
    End Property

    Public Property Divisa() As Double
        Get
            Return Me.Divisa_
        End Get
        Set(ByVal Value As Double)
            Me.Divisa_ = Value
        End Set
    End Property

    Dim Usuario_ As String

    Public Property Usuario() As String
        Get
            Return Me.Usuario_
        End Get
        Set(ByVal Value As String)
            Me.Usuario_ = Value
        End Set
    End Property

End Class
