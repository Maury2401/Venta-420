Public Class eMedioPago

    Private _idMedioPago As Int64
    Public Property idMedioPago() As Int64
        Get
            Return _idMedioPago
        End Get
        Set(ByVal value As Int64)
            _idMedioPago = value
        End Set
    End Property

    Private _nombreMedioPago As String
    Public Property nombreMedioPago() As String
        Get
            Return _nombreMedioPago
        End Get
        Set(ByVal value As String)
            _nombreMedioPago = value
        End Set
    End Property

    Private _numeroTarjeta As String
    Public Property numeroTarjeta() As String
        Get
            Return _numeroTarjeta
        End Get
        Set(ByVal value As String)
            _numeroTarjeta = value
        End Set
    End Property

    Private _calCodigo As Int32
    Public Property calCodigo() As Int32
        Get
            Return _calCodigo
        End Get
        Set(ByVal value As Int32)
            _calCodigo = value
        End Set
    End Property

    Private _orden As Int16
    Public Property orden() As Int16
        Get
            Return _orden
        End Get
        Set(ByVal value As Int16)
            _orden = value
        End Set
    End Property

    Private _fechaCreacion As DateTime
    Public Property fechaCreacion() As DateTime
        Get
            Return _fechaCreacion
        End Get
        Set(ByVal value As DateTime)
            _fechaCreacion = value
        End Set
    End Property

    Private _activo As Boolean
    Public Property activo() As Boolean
        Get
            Return _activo
        End Get
        Set(ByVal value As Boolean)
            _activo = value
        End Set
    End Property

    Private _otroMedioPago As Boolean
    Public Property otroMedioPago() As Boolean
        Get
            Return _otroMedioPago
        End Get
        Set(ByVal value As Boolean)
            _otroMedioPago = value
        End Set
    End Property



End Class
