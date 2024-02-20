Public Class SucursalesM
    Dim id_, nombre_ As String

    Public Property id() As String
        Get
            Return Me.id_
        End Get
        Set(ByVal Value As String)
            Me.id_ = Value
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
End Class
