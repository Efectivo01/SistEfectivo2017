Public Class UsuariosM
    Dim num_ As Integer
    Dim nombre_, contrasenia_, usuario_ As String

    Public Property num() As Integer
        Get
            Return Me.num_
        End Get
        Set(ByVal Value As Integer)
            Me.num_ = Value
        End Set
    End Property

    Public Property nombre() As String
        Get
            Return Me.nombre_
        End Get
        Set(ByVal Value As String)
            Me.nombre_ = Value
        End Set
    End Property

    Public Property contrasenia() As String
        Get
            Return Me.contrasenia_
        End Get
        Set(ByVal Value As String)
            Me.contrasenia_ = Value
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
