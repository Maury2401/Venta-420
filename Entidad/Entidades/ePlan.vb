Public Class ePlan

    Private _idPlan As Int64
    Private _primaUF As String
    Private _primaCalculada As String
    Private _idTipoContrato As Int16
    Private _calCodigo As Int32
    Private _activo As Boolean

    Private _descripcionPlan As String
    Public Property descripcionPlan() As String
        Get
            Return _descripcionPlan
        End Get
        Set(ByVal value As String)
            _descripcionPlan = value
        End Set
    End Property


    Public Property idPlan() As Int64
        Get
            Return _idPlan
        End Get
        Set(ByVal value As Int64)
            _idPlan = value
        End Set
    End Property

    Public Property primaUF() As String
        Get
            Return _primaUF
        End Get
        Set(ByVal value As String)
            _primaUF = value
        End Set
    End Property

    Public Property primaCalculada() As String
        Get
            Return _primaCalculada
        End Get
        Set(ByVal value As String)
            _primaCalculada = value
        End Set
    End Property


    Public Property idTipoContrato() As Int16
        Get
            Return _idTipoContrato
        End Get
        Set(ByVal value As Int16)
            _idTipoContrato = value
        End Set
    End Property

    Public Property calCodigo() As Int32
        Get
            Return _calCodigo
        End Get
        Set(ByVal value As Int32)
            _calCodigo = value
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
