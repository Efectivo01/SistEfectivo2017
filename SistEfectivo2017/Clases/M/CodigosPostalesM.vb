Public Class CodigosPostalesM
    Dim CodigoPostal_ As Integer
    Dim Colonia_, Municipio_, Estado_ As String

    Public Property CodigoPostal() As Integer
        Get
            Return Me.CodigoPostal_
        End Get
        Set(ByVal Value As Integer)
            Me.CodigoPostal_ = Value
        End Set
    End Property

    Public Property Colonia() As String
        Get
            Return Me.Colonia_
        End Get
        Set(ByVal Value As String)
            Me.Colonia_ = Value
        End Set
    End Property

    Public Property Municipio() As String
        Get
            Return Me.Municipio_
        End Get
        Set(ByVal Value As String)
            Me.Municipio_ = Value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return Me.Estado_
        End Get
        Set(ByVal Value As String)
            Me.Estado_ = Value
        End Set
    End Property
End Class
