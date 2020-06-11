Public Class eMotivoRechazo


    Private _idMotivoRechazo As Int32
    Public Property idMotivoRechazo() As Int32
        Get
            Return _idMotivoRechazo
        End Get
        Set(ByVal value As Int32)
            _idMotivoRechazo = value
        End Set
    End Property

    Private _descripcionMotivoRechazo As String
    Public Property descripcionMotivoRechazo() As String
        Get
            Return _descripcionMotivoRechazo
        End Get
        Set(ByVal value As String)
            _descripcionMotivoRechazo = value
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


End Class
