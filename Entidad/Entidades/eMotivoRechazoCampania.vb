Public Class eMotivoRechazoCampania

    Private _idMotivoRechazoCampania As Int32
    Public Property idMotivoRechazoCampania() As Int32
        Get
            Return _idMotivoRechazoCampania
        End Get
        Set(ByVal value As Int32)
            _idMotivoRechazoCampania = value
        End Set
    End Property

    Private _idMotivoRechazo As Int32
    Public Property idMotivoRechazo() As Int32
        Get
            Return _idMotivoRechazo
        End Get
        Set(ByVal value As Int32)
            _idMotivoRechazo = value
        End Set
    End Property

    Private _espCodigo As Int32
    Public Property espCodigo() As Int32
        Get
            Return _espCodigo
        End Get
        Set(ByVal value As Int32)
            _espCodigo = value
        End Set
    End Property

    Private _calcodigo As Int32
    Public Property calcodigo() As Int32
        Get
            Return _calcodigo
        End Get
        Set(ByVal value As Int32)
            _calcodigo = value
        End Set
    End Property

    Private _otro As Boolean
    Public Property otro() As Boolean
        Get
            Return _otro
        End Get
        Set(ByVal value As Boolean)
            _otro = value
        End Set
    End Property



End Class
