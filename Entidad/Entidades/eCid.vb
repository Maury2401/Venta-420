Public Class eCid

    Private _cli_id As String
    Private _cli_fono As String
    Private _cli_fecha As String
    Private _cli_inicio As String
    Private _cli_termino As String
    Private _cli_agente As String
    Private _cli_callid As String

    Public Property CLI_ID() As String
        Get
            Return _cli_id
        End Get
        Set(ByVal value As String)
            _cli_id = value
        End Set
    End Property

    Public Property CLI_Fono() As String
        Get
            Return _cli_fono
        End Get
        Set(ByVal value As String)
            _cli_fono = value
        End Set
    End Property
    Public Property CLI_Fecha() As String
        Get
            Return _cli_fecha
        End Get
        Set(ByVal value As String)
            _cli_fecha = value
        End Set
    End Property
    Public Property CLI_Inicio() As String
        Get
            Return _cli_inicio
        End Get
        Set(ByVal value As String)
            _cli_inicio = value
        End Set
    End Property

    Public Property Cli_Termino() As String
        Get
            Return _cli_termino
        End Get
        Set(ByVal value As String)
            _cli_termino = value
        End Set
    End Property
    Public Property CLI_Agente() As String
        Get
            Return _cli_agente
        End Get
        Set(ByVal value As String)
            _cli_agente = value
        End Set
    End Property
    Public Property CLI_CALL_ID() As String
        Get
            Return _cli_callid
        End Get
        Set(ByVal value As String)
            _cli_callid = value
        End Set
    End Property
End Class
