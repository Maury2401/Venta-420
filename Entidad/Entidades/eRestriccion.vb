Public Class eRestriccion

    Private _idRestriccionPlan As Int32
    Private _idPlan As Int64
    Private _valorRestriccion As String
    Private _operacion As String
    Private _fechaCreacion As DateTime
    Private _activo As Boolean


    Public Property idRestriccionPlan() As Int32
        Get
            Return _idRestriccionPlan
        End Get
        Set(ByVal value As Int32)
            _idRestriccionPlan = value
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

    Public Property operacion() As String
        Get
            Return _operacion
        End Get
        Set(ByVal value As String)
            _operacion = value
        End Set
    End Property

    Public Property valorRestriccion() As String
        Get
            Return _valorRestriccion
        End Get
        Set(ByVal value As String)
            _valorRestriccion = value
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

    Public Property activo() As Boolean
        Get
            Return _activo
        End Get
        Set(ByVal value As Boolean)
            _activo = value
        End Set
    End Property


End Class
