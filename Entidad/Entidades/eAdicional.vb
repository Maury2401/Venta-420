Public Class eAdicional
    Private _cli_id As String
    Private _t_rut As String
    Private _a_nro As String
    Private _a_rut As String
    Private _a_dv As String
    Private _a_nombre As String
    Private _a_paterno As String
    Private _a_materno As String
    Private _a_fecnacimiento As String
    Private _a_valorPrima As String
    Private _a_parentesco As String
    Private _a_id_parentesco As Int16
    Private _a_sexo As String
    Private _a_primaUf As String
    Private _idPlanAdic As String
    Private _a_nombre2 As String
    Public Property a_nombre2() As String
        Get
            Return _a_nombre2
        End Get
        Set(ByVal value As String)
            _a_nombre2 = value
        End Set
    End Property

    Private _a_salud As String
    Public Property a_salud() As String
        Get
            Return _a_salud
        End Get
        Set(ByVal value As String)
            _a_salud = value
        End Set
    End Property


    Public Property idPlanAdic() As String
        Get
            Return _idPlanAdic
        End Get
        Set(ByVal value As String)
            _idPlanAdic = value
        End Set
    End Property


    Public Property a_primaUf() As String
        Get
            Return _a_primaUf
        End Get
        Set(ByVal value As String)
            _a_primaUf = value
        End Set
    End Property

    Public Property a_sexo() As String
        Get
            Return _a_sexo
        End Get
        Set(ByVal value As String)
            _a_sexo = value
        End Set
    End Property

    Public Property a_id_parentesco() As Int16
        Get
            Return _a_id_parentesco
        End Get
        Set(ByVal value As Int16)
            _a_id_parentesco = value
        End Set
    End Property

    Public Property a_parentesco() As String
        Get
            Return _a_parentesco
        End Get
        Set(ByVal value As String)
            _a_parentesco = value
        End Set
    End Property

    Public Property a_valorPrima() As String
        Get
            Return _a_valorPrima
        End Get
        Set(ByVal value As String)
            _a_valorPrima = value
        End Set
    End Property

    Public Property a_fecnacimiento() As String
        Get
            Return _a_fecnacimiento
        End Get
        Set(ByVal value As String)
            _a_fecnacimiento = value
        End Set
    End Property

    Public Property a_materno() As String
        Get
            Return _a_materno
        End Get
        Set(ByVal value As String)
            _a_materno = value
        End Set
    End Property

    Public Property a_paterno() As String
        Get
            Return _a_paterno
        End Get
        Set(ByVal value As String)
            _a_paterno = value
        End Set
    End Property

    Public Property a_nombre() As String
        Get
            Return _a_nombre
        End Get
        Set(ByVal value As String)
            _a_nombre = value
        End Set
    End Property

    Public Property a_dv() As String
        Get
            Return _a_dv
        End Get
        Set(ByVal value As String)
            _a_dv = value
        End Set
    End Property

    Public Property a_rut() As String
        Get
            Return _a_rut
        End Get
        Set(ByVal value As String)
            _a_rut = value
        End Set
    End Property

    Public Property a_nro() As String
        Get
            Return _a_nro
        End Get
        Set(ByVal value As String)
            _a_nro = value
        End Set
    End Property

    Public Property t_rut() As String
        Get
            Return _t_rut
        End Get
        Set(ByVal value As String)
            _t_rut = value
        End Set
    End Property

    Public Property cli_id() As String
        Get
            Return _cli_id
        End Get
        Set(ByVal value As String)
            _cli_id = value
        End Set
    End Property

End Class
