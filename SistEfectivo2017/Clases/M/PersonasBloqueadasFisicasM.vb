Public Class PersonasBloqueadasFisicasM
    Dim Num_ As Integer
    Dim Nombres_, ApellidoPaterno_, ApellidoMaterno_ As String

    Public Property Num() As Integer
        Get
            Return Me.Num_
        End Get
        Set(ByVal Value As Integer)
            Me.Num_ = Value
        End Set
    End Property


    Public Property Nombres() As String
        Get
            Return Me.Nombres_
        End Get
        Set(ByVal Value As String)
            Me.Nombres_ = Value
        End Set
    End Property

    Public Property ApellidoPaterno() As String
        Get
            Return Me.ApellidoPaterno_
        End Get
        Set(ByVal Value As String)
            Me.ApellidoPaterno_ = Value
        End Set
    End Property

    Public Property ApellidoMaterno() As String
        Get
            Return Me.ApellidoMaterno_
        End Get
        Set(ByVal Value As String)
            Me.ApellidoMaterno_ = Value
        End Set
    End Property

    Dim FechaN_, Alias__ As String
    Dim Relacion_ As Integer

    Public Property FechaN() As String
        Get
            Return Me.FechaN_
        End Get
        Set(ByVal Value As String)
            Me.FechaN_ = Value
        End Set
    End Property

    Public Property Alias_() As String
        Get
            Return Me.Alias__
        End Get
        Set(ByVal Value As String)
            Me.Alias__ = Value
        End Set
    End Property

    Public Property Relacion() As Integer
        Get
            Return Me.Relacion_
        End Get
        Set(ByVal Value As Integer)
            Me.Relacion_ = Value
        End Set
    End Property
End Class
