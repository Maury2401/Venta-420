Public Class eCampoAdicional

    Private _idCampoAdicional As Int32
    Private _nombreCampoAdicional As String
    Private _valorCampo As String
    Private _calCodigo As String
    Private _fechaCreacion As DateTime
    Private _orden As Int16
    Private _activo As Boolean

    Public Property idCampoAdicional() As Int32
        Get
            Return _idCampoAdicional
        End Get
        Set(ByVal value As Int32)
            _idCampoAdicional = value
        End Set
    End Property

    Public Property nombreCampoAdicional() As String
        Get
            Return _nombreCampoAdicional
        End Get
        Set(ByVal value As String)
            _nombreCampoAdicional = value
        End Set
    End Property

    Public Property valorCampo() As String
        Get
            Return _valorCampo
        End Get
        Set(ByVal value As String)
            _valorCampo = value
        End Set
    End Property

    Public Property calCodigo() As String
        Get
            Return _calCodigo
        End Get
        Set(ByVal value As String)
            _calCodigo = value
        End Set
    End Property

    Public Property fechaCreacion() As DateTime
        Get
            Return _fechaCreacion
        End Get
        Set(ByVal value As DateTime)
            _fechaCreacion = value
        End Set
    End Property

    Public Property orden() As Int16
        Get
            Return _orden
        End Get
        Set(ByVal value As Int16)
            _orden = value
        End Set
    End Property

    Public Property activo() As Boolean
        Get
            Return _activo
        End Get
        Set(ByVal value As Boolean)
            _activo = value
        End Set
    End Property


End Class
