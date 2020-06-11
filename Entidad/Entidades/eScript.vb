Public Class eScript

    Private _idScripts As Int64
    Private _contenidoScript As String
    Private _idTipoScript As Int16
    Private _calcodigo As Int32

    Public Property idScripts() As int64
        Get
            Return _idScripts
        End Get
        Set(ByVal value As int64)
            _idScripts = value
        End Set
    End Property

    Public Property contenidoScript() As String
        Get
            Return _contenidoScript
        End Get
        Set(ByVal value As String)
            _contenidoScript = value
        End Set
    End Property

    Public Property idTipoScript() As Int16
        Get
            Return _idTipoScript
        End Get
        Set(ByVal value As Int16)
            _idTipoScript = value
        End Set
    End Property

    Public Property calcodigo() As Int32
        Get
            Return _calcodigo
        End Get
        Set(ByVal value As Int32)
            _calcodigo = value
        End Set
    End Property



End Class
