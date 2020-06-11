Public Class eBeneficiario
    Private _cli_id As String
    Private _t_rut As String
    Private _t_certificado As String
    Private _b_nro As String
    Private _b_rut As String
    Private _b_dv As String
    Private _b_nombre1 As String
    Private _b_nombre2 As String
    Private _b_paterno As String
    Private _b_materno As String
    Private _b_parentesco As String
    Private _parentesco_text As String
    Private _b_pctje As String
    Private _b_fec_nac As String
    Private _b_contacto As String

    Public Property b_contacto() As String
        Get
            Return _b_contacto
        End Get
        Set(ByVal value As String)
            _b_contacto = value
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

    Public Property t_rut() As String
        Get
            Return _t_rut
        End Get
        Set(ByVal value As String)
            _t_rut = value
        End Set
    End Property
    Public Property t_certificado() As String
        Get
            Return _t_certificado
        End Get
        Set(ByVal value As String)
            _t_certificado = value
        End Set
    End Property
    Public Property b_nro() As String
        Get
            Return _b_nro
        End Get
        Set(ByVal value As String)
            _b_nro = value
        End Set
    End Property

    Public Property b_rut() As String
        Get
            Return _b_rut
        End Get
        Set(ByVal value As String)
            _b_rut = value
        End Set
    End Property
    Public Property b_dv() As String
        Get
            Return _b_dv
        End Get
        Set(ByVal value As String)
            _b_dv = value
        End Set
    End Property
    Public Property b_nombre1() As String
        Get
            Return _b_nombre1
        End Get
        Set(ByVal value As String)
            _b_nombre1 = value
        End Set
    End Property
    Public Property b_nombre2() As String
        Get
            Return _b_nombre2
        End Get
        Set(ByVal value As String)
            _b_nombre2 = value
        End Set
    End Property

    Public Property b_paterno() As String
        Get
            Return _b_paterno
        End Get
        Set(ByVal value As String)
            _b_paterno = value
        End Set
    End Property
    Public Property b_materno() As String
        Get
            Return _b_materno
        End Get
        Set(ByVal value As String)
            _b_materno = value
        End Set
    End Property
    Public Property b_parentesco() As String
        Get
            Return _b_parentesco
        End Get
        Set(ByVal value As String)
            _b_parentesco = value
        End Set
    End Property

    Public Property parentesco_text() As String
        Get
            Return _parentesco_text
        End Get
        Set(ByVal value As String)
            _parentesco_text = value
        End Set
    End Property
    Public Property b_pctje() As String
        Get
            Return _b_pctje
        End Get
        Set(ByVal value As String)
            _b_pctje = value
        End Set
    End Property

    Public Property b_fec_nac() As String
        Get
            Return _b_fec_nac
        End Get
        Set(ByVal value As String)
            _b_fec_nac = value
        End Set
    End Property
End Class
