Public Class actividadesM
    Dim actividad_, nombre_ As String

    Public Property actividad() As String
        Get
            Return Me.actividad_
        End Get
        Set(ByVal Value As String)
            Me.actividad_ = Value
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
