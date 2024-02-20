Public Class localidadesM
    Dim localidad_, nombre_, estadopais_ As String

    Public Property localidad() As String
        Get
            Return Me.localidad_
        End Get
        Set(ByVal Value As String)
            Me.localidad_ = Value
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


    Public Property estadopais() As String
        Get
            Return Me.estadopais_
        End Get
        Set(ByVal Value As String)
            Me.estadopais_ = Value
        End Set
    End Property
End Class
