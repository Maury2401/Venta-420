Public Class eCampania

    Private _calCodigo As Int32
    Private _espCodigo As Int32
    Private _tgCodigo As Int16
    Private _tpoCodigo As Int16
    Private _calFecCambioCentral As Date
    Private _calNombre As String
    Private _calCentroCosto As String
    Private _calCodProducto As String
    Private _calCodProducto2 As String
    Private _calBDD As String
    Private _calTablappal As String
    Private _calTablaReg As String
    Private _calTablaAgen As String
    Private _calConBeneficiarios As Boolean
    Private _calConRegrabacion As Boolean
    Private _calConFormaPago As Boolean
    Private _calNeoIsla As Int16
    Private _calIdCRMNeo As Int32
    Private _calIdCampanaNeo As Int32
    Private _calPsFonoAltNeo As String
    Private _calPsBuscaCasos As String
    Private _calPsBuscaBeneficiarios As String
    Private _calPsBuscaVentasRechazadas As String
    Private _calPsGrabaControl1 As String
    Private _calPsGrabaControl2 As String
    Private _calPsGrabaGesRegrabac As String
    Private _calRutaWavGrabacion As String
    Private _calRutaWavRegrabacion As String
    Private _calNombreProyectoReportes As String
    Private _calEnProduccion As Boolean
    Private _calPsBuscaGrabaciones As String
    Private _calPsBuscaVentasFueradePlazo As String
    Private _calConAsignacionReg As Boolean
    Private _calPsSincronizacion As String
    Private _calConAdicional As Boolean
    Private _calSoloAdicional As Boolean
    Private _calTimestamp As DateTime
    Private _calEnUso As Boolean
    Private _calEnvioCorreoSMS As Int16
    Private _calIso As Boolean
    Private _calAprobacion As Boolean
    Private _calRequirente As Boolean
    Private _calResponsable As Boolean
    Private _calConAgenda As Boolean
    Private _calConAsistencia As Boolean
    Private _calAdicionalPagado As Boolean
    Private _calServidorBDD As String
    Private _calIntentosMaximos As String
    Private _idTipoCampania As Int16
    Private _IslaServidor As String
    Private _rutaWebService As String
    Private _rutaWebServiceRegrabacion As String


    Public Property calCodigo() As String
        Get
            Return _calCodigo
        End Get
        Set(ByVal value As String)
            _calCodigo = value
        End Set
    End Property


    Public Property espCodigo() As Int32
        Get
            Return _espCodigo
        End Get
        Set(ByVal value As Int32)
            _espCodigo = value
        End Set
    End Property


    Public Property tgCodigo() As Int32
        Get
            Return _tgCodigo
        End Get
        Set(ByVal value As Int32)
            _tgCodigo = value
        End Set
    End Property


    Public Property tpoCodigo() As String
        Get
            Return _tpoCodigo
        End Get
        Set(ByVal value As String)
            _tpoCodigo = value
        End Set
    End Property


    Public Property calFecCambioCentral() As Date
        Get
            Return _calFecCambioCentral
        End Get
        Set(ByVal value As Date)
            _calFecCambioCentral = value
        End Set
    End Property


    Public Property calNombre() As String
        Get
            Return _calNombre
        End Get
        Set(ByVal value As String)
            _calNombre = value
        End Set
    End Property


    Public Property calCentroCosto() As String
        Get
            Return _calCentroCosto
        End Get
        Set(ByVal value As String)
            _calCentroCosto = value
        End Set
    End Property


    Public Property calCodProducto() As String
        Get
            Return _calCodProducto
        End Get
        Set(ByVal value As String)
            _calCodProducto = value
        End Set
    End Property


    Public Property calCodProducto2() As String
        Get
            Return _calCodProducto2
        End Get
        Set(ByVal value As String)
            _calCodProducto2 = value
        End Set
    End Property


    Public Property calBDD() As String
        Get
            Return _calBDD
        End Get
        Set(ByVal value As String)
            _calBDD = value
        End Set
    End Property


    Public Property calTablappal() As String
        Get
            Return _calTablappal
        End Get
        Set(ByVal value As String)
            _calTablappal = value
        End Set
    End Property


    Public Property calTablaReg() As String
        Get
            Return _calTablaReg
        End Get
        Set(ByVal value As String)
            _calTablaReg = value
        End Set
    End Property


    Public Property calTablaAgen() As String
        Get
            Return _calTablaAgen
        End Get
        Set(ByVal value As String)
            _calTablaAgen = value
        End Set
    End Property


    Public Property calConBeneficiarios() As Boolean
        Get
            Return _calConBeneficiarios
        End Get
        Set(ByVal value As Boolean)
            _calConBeneficiarios = value
        End Set
    End Property


    Public Property calConRegrabacion() As Boolean
        Get
            Return _calConRegrabacion
        End Get
        Set(ByVal value As Boolean)
            _calConRegrabacion = value
        End Set
    End Property


    Public Property calConFormaPago() As Boolean
        Get
            Return _calConFormaPago
        End Get
        Set(ByVal value As Boolean)
            _calConFormaPago = value
        End Set
    End Property


    Public Property calNeoIsla() As Int16
        Get
            Return _calNeoIsla
        End Get
        Set(ByVal value As Int16)
            _calNeoIsla = value
        End Set
    End Property


    Public Property calIdCRMNeo() As Int32
        Get
            Return _calIdCRMNeo
        End Get
        Set(ByVal value As Int32)
            _calIdCRMNeo = value
        End Set
    End Property


    Public Property calIdCampanaNeo() As Int32
        Get
            Return _calIdCampanaNeo
        End Get
        Set(ByVal value As Int32)
            _calIdCampanaNeo = value
        End Set
    End Property


    Public Property calPsFonoAltNeo() As String
        Get
            Return _calPsFonoAltNeo
        End Get
        Set(ByVal value As String)
            _calPsFonoAltNeo = value
        End Set
    End Property


    Public Property calPsBuscaCasos() As String
        Get
            Return _calPsBuscaCasos
        End Get
        Set(ByVal value As String)
            _calPsBuscaCasos = value
        End Set
    End Property


    Public Property calPsBuscaBeneficiarios() As String
        Get
            Return _calPsBuscaBeneficiarios
        End Get
        Set(ByVal value As String)
            _calPsBuscaBeneficiarios = value
        End Set
    End Property


    Public Property calPsBuscaVentasRechazadas() As String
        Get
            Return _calPsBuscaVentasRechazadas
        End Get
        Set(ByVal value As String)
            _calPsBuscaVentasRechazadas = value
        End Set
    End Property


    Public Property calPsGrabaControl1() As String
        Get
            Return _calPsGrabaControl1
        End Get
        Set(ByVal value As String)
            _calPsGrabaControl1 = value
        End Set
    End Property


    Public Property calPsGrabaControl2() As String
        Get
            Return _calPsGrabaControl2
        End Get
        Set(ByVal value As String)
            _calPsGrabaControl2 = value
        End Set
    End Property


    Public Property calPsGrabaGesRegrabac() As String
        Get
            Return _calPsGrabaGesRegrabac
        End Get
        Set(ByVal value As String)
            _calPsGrabaGesRegrabac = value
        End Set
    End Property


    Public Property calRutaWavGrabacion() As String
        Get
            Return _calRutaWavGrabacion
        End Get
        Set(ByVal value As String)
            _calRutaWavGrabacion = value
        End Set
    End Property


    Public Property calRutaWavRegrabacion() As String
        Get
            Return _calRutaWavRegrabacion
        End Get
        Set(ByVal value As String)
            _calRutaWavRegrabacion = value
        End Set
    End Property


    Public Property calNombreProyectoReportes() As String
        Get
            Return _calNombreProyectoReportes
        End Get
        Set(ByVal value As String)
            _calNombreProyectoReportes = value
        End Set
    End Property


    Public Property calEnProduccion() As Boolean
        Get
            Return _calEnProduccion
        End Get
        Set(ByVal value As Boolean)
            _calEnProduccion = value
        End Set
    End Property


    Public Property calPsBuscaGrabaciones() As String
        Get
            Return _calPsBuscaGrabaciones
        End Get
        Set(ByVal value As String)
            _calPsBuscaGrabaciones = value
        End Set
    End Property


    Public Property calPsBuscaVentasFueradePlazo() As String
        Get
            Return _calPsBuscaVentasFueradePlazo
        End Get
        Set(ByVal value As String)
            _calPsBuscaVentasFueradePlazo = value
        End Set
    End Property


    Public Property calConAsignacionReg() As Boolean
        Get
            Return _calConAsignacionReg
        End Get
        Set(ByVal value As Boolean)
            _calConAsignacionReg = value
        End Set
    End Property


    Public Property calPsSincronizacion() As String
        Get
            Return _calPsSincronizacion
        End Get
        Set(ByVal value As String)
            _calPsSincronizacion = value
        End Set
    End Property


    Public Property calConAdicional() As Boolean
        Get
            Return _calConAdicional
        End Get
        Set(ByVal value As Boolean)
            _calConAdicional = value
        End Set
    End Property


    Public Property calSoloAdicional() As Boolean
        Get
            Return _calSoloAdicional
        End Get
        Set(ByVal value As Boolean)
            _calSoloAdicional = value
        End Set
    End Property


    Public Property calTimestamp() As DateTime
        Get
            Return _calTimestamp
        End Get
        Set(ByVal value As DateTime)
            _calTimestamp = value
        End Set
    End Property


    Public Property calEnUso() As Boolean
        Get
            Return _calEnUso
        End Get
        Set(ByVal value As Boolean)
            _calEnUso = value
        End Set
    End Property


    Public Property calEnvioCorreoSMS() As Int16
        Get
            Return _calEnvioCorreoSMS
        End Get
        Set(ByVal value As Int16)
            _calEnvioCorreoSMS = value
        End Set
    End Property


    Public Property calIso() As Boolean
        Get
            Return _calIso
        End Get
        Set(ByVal value As Boolean)
            _calIso = value
        End Set
    End Property


    Public Property calAprobacion() As Boolean
        Get
            Return _calAprobacion
        End Get
        Set(ByVal value As Boolean)
            _calAprobacion = value
        End Set
    End Property


    Public Property calRequirente() As String
        Get
            Return _calRequirente
        End Get
        Set(ByVal value As String)
            _calRequirente = value
        End Set
    End Property


    Public Property calResponsable() As String
        Get
            Return _calResponsable
        End Get
        Set(ByVal value As String)
            _calResponsable = value
        End Set
    End Property


    Public Property calConAgenda() As Boolean
        Get
            Return _calConAgenda
        End Get
        Set(ByVal value As Boolean)
            _calConAgenda = value
        End Set
    End Property


    Public Property calConAsistencia() As Boolean
        Get
            Return _calConAsistencia
        End Get
        Set(ByVal value As Boolean)
            _calConAsistencia = value
        End Set
    End Property


    Public Property calAdicionalPagado() As Boolean
        Get
            Return _calAdicionalPagado
        End Get
        Set(ByVal value As Boolean)
            _calAdicionalPagado = value
        End Set
    End Property


    Public Property calServidorBDD() As String
        Get
            Return _calServidorBDD
        End Get
        Set(ByVal value As String)
            _calServidorBDD = value
        End Set
    End Property


    Public Property calIntentosMaximos() As Int16
        Get
            Return _calIntentosMaximos
        End Get
        Set(ByVal value As Int16)
            _calIntentosMaximos = value
        End Set
    End Property

    Public Property idTipoCampania() As Int16
        Get
            Return _idTipoCampania
        End Get
        Set(ByVal value As Int16)
            _idTipoCampania = value
        End Set
    End Property

    Private _IslaID As Int16
    Public Property IslaID() As Int16
        Get
            Return _IslaID
        End Get
        Set(ByVal value As Int16)
            _IslaID = value
        End Set
    End Property

    Public Property IslaServidor() As String
        Get
            Return _IslaServidor
        End Get
        Set(ByVal value As String)
            _IslaServidor = value
        End Set
    End Property

    Public Property rutaWebService() As String
        Get
            Return _rutaWebService
        End Get
        Set(ByVal value As String)
            _rutaWebService = value
        End Set
    End Property

    Public Property rutaWebServiceRegrabacion() As String
        Get
            Return _rutaWebServiceRegrabacion
        End Get
        Set(ByVal value As String)
            _rutaWebServiceRegrabacion = value
        End Set
    End Property

    Private _IdCampanaNeoRegrabacion As Int16
    Public Property IdCampanaNeoRegrabacion() As Int16
        Get
            Return _IdCampanaNeoRegrabacion
        End Get
        Set(ByVal value As Int16)
            _IdCampanaNeoRegrabacion = value
        End Set
    End Property



End Class
