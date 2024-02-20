Public Class clientescnbvM
    Dim Iniciales_, Nombre_, ApellidoPaterno_, ApellidoMaterno_, Tarjeta_ As String
    Dim PaisNace_, EstadoNace_, CiudadResidencia_, PaisResidencia_ As String
    Dim EstadoResidencia_, Calle_, No_Interior_, No_Exterior_, EntreCalles_, Referencias_ As String
    Dim Colonia_, Municipio_, Estado_, Direccion_ As String
    Dim Telfijo_, Telcelular_, Identificacion_, email_ As String
    Dim CP_, Rfc_, Nacionalidad_, Empresa_, CURP_ As String
    Dim actividadcomercial_, identifica1_, identifica2_ As String
    Dim Fecnac_, Venc_ID As Date
    Dim cliente_, ID_, Sexo_ As Integer
    Dim app_ As Integer
    Dim riesgo_ As String
    Dim Autorizado_ As Integer
    Dim fiel_, firma_ As String
    Dim fechaenvp__ As Date

    Public Property cliente() As Integer
        Get
            Return Me.cliente_
        End Get
        Set(ByVal Value As Integer)
            Me.cliente_ = Value
        End Set
    End Property

    Public Property ID() As Integer
        Get
            Return Me.ID_
        End Get
        Set(ByVal Value As Integer)
            Me.ID_ = Value
        End Set
    End Property

    Public Property Iniciales() As String
        Get
            Return Me.Iniciales_
        End Get
        Set(ByVal Value As String)
            Me.Iniciales_ = Value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return Me.Nombre_
        End Get
        Set(ByVal Value As String)
            Me.Nombre_ = Value
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

    Public Property Tarjeta() As String
        Get
            Return Me.Tarjeta_
        End Get
        Set(ByVal Value As String)
            Me.Tarjeta_ = Value
        End Set
    End Property

    Public Property PaisNace() As String
        Get
            Return Me.PaisNace_
        End Get
        Set(ByVal Value As String)
            Me.PaisNace_ = Value
        End Set
    End Property

    Public Property EstadoNace() As String
        Get
            Return Me.EstadoNace_
        End Get
        Set(ByVal Value As String)
            Me.EstadoNace_ = Value
        End Set
    End Property

    Public Property CiudadResidencia() As String
        Get
            Return Me.CiudadResidencia_
        End Get
        Set(ByVal Value As String)
            Me.CiudadResidencia_ = Value
        End Set
    End Property

    Public Property PaisResidencia() As String
        Get
            Return Me.PaisResidencia_
        End Get
        Set(ByVal Value As String)
            Me.PaisResidencia_ = Value
        End Set
    End Property

    Public Property EstadoResidencia() As String
        Get
            Return Me.EstadoResidencia_
        End Get
        Set(ByVal Value As String)
            Me.EstadoResidencia_ = Value
        End Set
    End Property


    Public Property Direccion() As String
        Get
            Return Me.Direccion_
        End Get
        Set(ByVal Value As String)
            Me.Direccion_ = Value
        End Set
    End Property


    Public Property Calle() As String
        Get
            Return Me.Calle_
        End Get
        Set(ByVal Value As String)
            Me.Calle_ = Value
        End Set
    End Property

    Public Property No_Interior() As String
        Get
            Return Me.No_Interior_
        End Get
        Set(ByVal Value As String)
            Me.No_Interior_ = Value
        End Set
    End Property

    Public Property No_Exterior() As String
        Get
            Return Me.No_Exterior_
        End Get
        Set(ByVal Value As String)
            Me.No_Exterior_ = Value
        End Set
    End Property

    Public Property Referencias() As String
        Get
            Return Me.Referencias_
        End Get
        Set(ByVal Value As String)
            Me.Referencias_ = Value
        End Set
    End Property

    Public Property EntreCalles() As String
        Get
            Return Me.EntreCalles_
        End Get
        Set(ByVal Value As String)
            Me.EntreCalles_ = Value
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

    Public Property Telfijo() As String
        Get
            Return Me.Telfijo_
        End Get
        Set(ByVal Value As String)
            Me.Telfijo_ = Value
        End Set
    End Property

    Public Property Telcelular() As String
        Get
            Return Me.Telcelular_
        End Get
        Set(ByVal Value As String)
            Me.Telcelular_ = Value
        End Set
    End Property

    Public Property Identificacion() As String
        Get
            Return Me.Identificacion_
        End Get
        Set(ByVal Value As String)
            Me.Identificacion_ = Value
        End Set
    End Property

    Public Property email() As String
        Get
            Return Me.email_
        End Get
        Set(ByVal Value As String)
            Me.email_ = Value
        End Set
    End Property

    Public Property CP() As String
        Get
            Return Me.CP_
        End Get
        Set(ByVal Value As String)
            Me.CP_ = Value
        End Set
    End Property

    Public Property Rfc() As String
        Get
            Return Me.Rfc_
        End Get
        Set(ByVal Value As String)
            Me.Rfc_ = Value
        End Set
    End Property

    Public Property Fecnac() As Date
        Get
            Return Me.Fecnac_
        End Get
        Set(ByVal Value As Date)
            Me.Fecnac_ = Value
        End Set
    End Property

    Public Property VencID() As Date
        Get
            Return Me.Venc_ID
        End Get
        Set(ByVal Value As Date)
            Me.Venc_ID = Value
        End Set
    End Property

    Public Property Sexo() As Integer
        Get
            Return Me.Sexo_
        End Get
        Set(ByVal Value As Integer)
            Me.Sexo_ = Value
        End Set
    End Property

    Public Property Nacionalidad() As String
        Get
            Return Me.Nacionalidad_
        End Get
        Set(ByVal Value As String)
            Me.Nacionalidad_ = Value
        End Set
    End Property

    Public Property Empresa() As String
        Get
            Return Me.Empresa_
        End Get
        Set(ByVal Value As String)
            Me.Empresa_ = Value
        End Set
    End Property

    Public Property CURP() As String
        Get
            Return Me.CURP_
        End Get
        Set(ByVal Value As String)
            Me.CURP_ = Value
        End Set
    End Property

    Public Property actividadcomercial() As String
        Get
            Return Me.actividadcomercial_
        End Get
        Set(ByVal Value As String)
            Me.actividadcomercial_ = Value
        End Set
    End Property

    Public Property identifica1() As String
        Get
            Return Me.identifica1_
        End Get
        Set(ByVal Value As String)
            Me.identifica1_ = Value
        End Set
    End Property

    Public Property identifica2() As String
        Get
            Return Me.identifica2_
        End Get
        Set(ByVal Value As String)
            Me.identifica2_ = Value
        End Set
    End Property

    Public Property app() As Integer
        Get
            Return Me.app_
        End Get
        Set(ByVal Value As Integer)
            Me.app_ = Value
        End Set
    End Property

    Dim num_usu_ As String

    Public Property num_usu() As String
        Get
            Return Me.num_usu_
        End Get
        Set(ByVal Value As String)
            Me.num_usu_ = Value
        End Set
    End Property

    Dim fechar_ As Date
    Dim horar_, nom_usu_ As String

    Public Property fechar() As Date
        Get
            Return Me.fechar_
        End Get
        Set(ByVal Value As Date)
            Me.fechar_ = Value
        End Set
    End Property

    Public Property horar() As String
        Get
            Return Me.horar_
        End Get
        Set(ByVal Value As String)
            Me.horar_ = Value
        End Set
    End Property

    Public Property nom_usu() As String
        Get
            Return Me.nom_usu_
        End Get
        Set(ByVal Value As String)
            Me.nom_usu_ = Value
        End Set
    End Property

    Dim Nosucursal_, nacionalizado_ As String
    Public Property Nosucursal() As String
        Get
            Return Me.Nosucursal_
        End Get
        Set(ByVal Value As String)
            Me.Nosucursal_ = Value
        End Set
    End Property

    Public Property nacionalizado() As String
        Get
            Return Me.nacionalizado_
        End Get
        Set(ByVal Value As String)
            Me.nacionalizado_ = Value
        End Set
    End Property

    Public Property riesgo() As String
        Get
            Return Me.riesgo_
        End Get
        Set(ByVal Value As String)
            Me.riesgo_ = Value
        End Set
    End Property

    Public Property Autorizado() As Integer
        Get
            Return Me.Autorizado_
        End Get
        Set(value As Integer)
            Me.Autorizado_ = value
        End Set
    End Property

    Public Property fiel() As String
        Get
            Return Me.fiel_
        End Get
        Set(ByVal Value As String)
            Me.fiel_ = Value
        End Set
    End Property

    Public Property firma() As String
        Get
            Return Me.firma_
        End Get
        Set(ByVal Value As String)
            Me.firma_ = Value
        End Set
    End Property

    Public Property fechaenvp() As String
        Get
            Return Me.fechaenvp__
        End Get
        Set(ByVal Value As String)
            Me.fechaenvp__ = Value
        End Set
    End Property
End Class
