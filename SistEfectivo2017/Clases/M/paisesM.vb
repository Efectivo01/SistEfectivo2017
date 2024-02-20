Public Class paisesM
    Dim pais_ As String

    Public Property pais() As String
        Get
            Return Me.pais_
        End Get
        Set(ByVal Value As String)
            Me.pais_ = Value
        End Set
    End Property
End Class
