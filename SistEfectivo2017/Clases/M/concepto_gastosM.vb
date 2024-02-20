Public Class concepto_gastosM
    Dim concepto_ As String
    Dim nombre_ As String

    Public Property concepto() As String
        Get
            Return Me.concepto_
        End Get
        Set(ByVal Value As String)
            Me.concepto_ = Value
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
