Public Class eCliente

    Private _cli_id As String
    Private _cli_rut As String
    Private _cli_dv As String
    Private _cli_edad As String
    Private _cli_fechanacimiento As String
    Private _cli_nombre As String
    Private _cli_paterno As String
    Private _cli_materno As String
    Private _cli_direccion As String
    Private _cli_comuna As String
    Private _cli_aemail As String
    Private _cli_areabase1 As String
    Private _cli_fonobase1 As String
    Private _cli_telefono1 As String
    Private _cli_areabase2 As String
    Private _cli_fonobase2 As String
    Private _cli_telefono2 As String
    Private _cli_areabase3 As String
    Private _cli_fonobase3 As String
    Private _cli_telefono3 As String
    Private _cli_areabase4 As String
    Private _cli_fonobase4 As String
    Private _cli_telefono4 As String
    Private _cli_areabase5 As String
    Private _cli_fonobase5 As String
    Private _cli_telefono5 As String
    Private _cli_areabase6 As String
    Private _cli_fonobase6 As String
    Private _cli_telefono6 As String
    Private _cli_telefonoalt As String
    Private _cli_agente As String
    Private _cli_estado As String
    Private _cli_intentos As String
    Private _cli_agen_obs As String
    Private _cli_intentos_max As UShort
    Private _cli_primauf As String
    Private _cli_primapesos As String
    Private _cli_tpocontrato As Int32
    Private _cli_plan As Int32
    Private _cli_codverificacion As String
    Private _cli_asegurado As String
    Private _cli_nointereso As String
    Private _cli_region As String
    Private _cli_estadofono1 As Int16
    Private _cli_estadofono2 As Int16
    Private _cli_estadofono3 As Int16
    Private _cli_estadofono4 As Int16
    Private _cli_estadofono5 As Int16
    Private _cli_estadofono6 As Int16
    Private _cli_estadofonoalt As Int16
    Private _cli_email As String
    Private _cli_fecha As String
    Private _cli_hora As String
    Private _cli_fechavta As String
    Private _cli_horavta As String
    Private _cli_ip_agente As String
    Private _cli_call_id As String
    Private _cli_agen_estado As String
    Private _cli_agen_fecha As String
    Private _cli_agen_hora As String
    Private _cli_fecha_carga As String
    Private _cli_conecta As String
    Private _cli_no_conecta As String
    Private _cli_comunica_con As String
    Private _cli_comunica_tercero As String
    Private _CLI_INTERESA As String
    Private _cli_producto As String
    Private _cli_anombre As String
    Private _cli_anombre2 As String
    Private _cli_apaterno As String
    Private _cli_amaterno As String
    Private _cli_arut As String
    Private _cli_adv As String
    Private _cli_afechanacimiento As String
    Private _cli_codactividad As String
    Private _cli_acalle As String
    Private _cli_anro As String
    Private _cli_acomuna As String
    Private _cli_acod_comuna As String
    Private _cli_aciudad As String
    Private _cli_acod_ciudad As String
    Private _cli_aregion As String
    Private _cli_tpopago As String
    Private _cli_nro_conmodificacion As String
    Private _cli_atarjeta As String
    Private _cli_afechavcto As String
    Private _cli_diacarga As String
    Private _cli_acepta As String
    Private _cli_mtvo_nocontrata As String
    Private _cli_mtvo_ncobs As String
    Private _cli_motivonointeresa As String
    Private _cli_aobsmtvo_nointeresa As String
    Private _cli_acepta_contrato As String
    Private _cli_acepta_prima As String
    Private _cli_acepta_cargo As String
    Private _cli_venta As String
    Private _cli_tipofono As String
    Private _cli_areafono As String
    Private _cli_numfono As String
    Private _cli_estado_civil As String
    Private _cli_aareafonovta As String
    Private _cli_afonovta As String
    Private _cli_acelular As String
    Private _cli_formapago As String
    Private _cli_medio_pago As String
    Private _cli_referencia As String
    Private _cli_fecha_apertura As String
    Private _cli_tipobase As String
    Private _cli_asexo As String
    Private _cli_id_cliente As String
    Private _cli_numero As String

    'CAMPOS EXTRAS


    Private _campo1 As String
    Private _campo2 As String
    Private _campo3 As String
    Private _campo4 As String
    Private _campo5 As String
    Private _campo6 As String
    Private _campo7 As String
    Private _campo8 As String
    Private _campo9 As String
    Private _campo10 As String
    Private _campo11 As String
    Private _campo12 As String
    Private _campo13 As String
    Private _campo14 As String
    Private _campo15 As String
    Private _campo16 As String
    Private _campo17 As String
    Private _campo18 As String
    Private _campo19 As String
    Private _campo20 As String
    Private _campo21 As String
    Private _campo22 As String
    Private _campo23 As String
    Private _campo24 As String
    Private _campo25 As String
    Private _campo26 As String
    Private _campo27 As String
    Private _campo28 As String
    Private _campo29 As String
    Private _campo30 As String
    Private _campo31 As String
    Private _campo32 As String
    Private _campo33 As String
    Private _campo34 As String
    Private _campo35 As String
    Private _campo36 As String
    Private _campo37 As String
    Private _campo38 As String
    Private _campo39 As String
    Private _campo40 As String
    Private _campo41 As String
    Private _campo42 As String
    Private _campo43 As String
    Private _campo44 As String
    Private _campo45 As String
    Private _campo46 As String
    Private _campo47 As String
    Private _campo48 As String
    Private _campo49 As String
    Private _campo50 As String
    Private _campo51 As String
    Private _campo52 As String
    Private _campo53 As String
    Private _campo54 As String
    Private _campo55 As String
    Private _campo56 As String
    Private _campo57 As String
    Private _campo58 As String
    Private _campo59 As String
    Private _campo60 As String

    Private _cli_primaPesos_total As String
    Public Property cli_primaPesos_total() As String
        Get
            Return _cli_primaPesos_total
        End Get
        Set(ByVal value As String)
            _cli_primaPesos_total = value
        End Set
    End Property

    Private _cli_primaUf_total As String
    Public Property cli_primaUf_total() As String
        Get
            Return _cli_primaUf_total
        End Get
        Set(ByVal value As String)
            _cli_primaUf_total = value
        End Set
    End Property


    Private _cli_AAVTO_TARJ As String
    Public Property cli_AAVTO_TARJ() As String
        Get
            Return _cli_AAVTO_TARJ
        End Get
        Set(ByVal value As String)
            _cli_AAVTO_TARJ = value
        End Set
    End Property


    Private _cli_nombre2 As String
    Public Property cli_nombre2() As String
        Get
            Return _cli_nombre2
        End Get
        Set(ByVal value As String)
            _cli_nombre2 = value
        End Set
    End Property

    Private _CLI_PRIMER_MOT_SUBCALIDAD As String
    Public Property CLI_PRIMER_MOT_SUBCALIDAD() As String
        Get
            Return _CLI_PRIMER_MOT_SUBCALIDAD
        End Get
        Set(ByVal value As String)
            _CLI_PRIMER_MOT_SUBCALIDAD = value
        End Set
    End Property


    Private _CLI_PRIMER_MOT_CALIDAD As String
    Public Property CLI_PRIMER_MOT_CALIDAD() As String
        Get
            Return _CLI_PRIMER_MOT_CALIDAD
        End Get
        Set(ByVal value As String)
            _CLI_PRIMER_MOT_CALIDAD = value
        End Set
    End Property


    Private _CLI_RECONOCEVTA As String
    Public Property CLI_RECONOCEVTA() As String
        Get
            Return _CLI_RECONOCEVTA
        End Get
        Set(ByVal value As String)
            _CLI_RECONOCEVTA = value
        End Set
    End Property

    Private _CLI_CALL_ID_CALIDAD As String
    Public Property CLI_CALL_ID_CALIDAD() As String
        Get
            Return _CLI_CALL_ID_CALIDAD
        End Get
        Set(ByVal value As String)
            _CLI_CALL_ID_CALIDAD = value
        End Set
    End Property


    Private _CLI_SEGUNDO_ESTADO_CALIDAD As String
    Public Property CLI_SEGUNDO_ESTADO_CALIDAD() As String
        Get
            Return _CLI_SEGUNDO_ESTADO_CALIDAD
        End Get
        Set(ByVal value As String)
            _CLI_SEGUNDO_ESTADO_CALIDAD = value
        End Set
    End Property


    Private _CLI_ESTADO_OBJECION_CALIDAD As String
    Public Property CLI_ESTADO_OBJECION_CALIDAD() As String
        Get
            Return _CLI_ESTADO_OBJECION_CALIDAD
        End Get
        Set(ByVal value As String)
            _CLI_ESTADO_OBJECION_CALIDAD = value
        End Set
    End Property


    Private _CLI_ACEPTA_CONTRATACION As String
    Public Property CLI_ACEPTA_CONTRATACION() As String
        Get
            Return _CLI_ACEPTA_CONTRATACION
        End Get
        Set(ByVal value As String)
            _CLI_ACEPTA_CONTRATACION = value
        End Set
    End Property


    Private _CLI_NOMBRE_EJECUTIVO As String
    Public Property CLI_NOMBRE_EJECUTIVO() As String
        Get
            Return _CLI_NOMBRE_EJECUTIVO
        End Get
        Set(ByVal value As String)
            _CLI_NOMBRE_EJECUTIVO = value
        End Set
    End Property


    Private _cli_segmento As String
    Public Property cli_segmento() As String
        Get
            Return _cli_segmento
        End Get
        Set(ByVal value As String)
            _cli_segmento = value
        End Set
    End Property


    Private _cli_prima_periodo As String
    Public Property cli_prima_periodo() As String
        Get
            Return _cli_prima_periodo
        End Get
        Set(ByVal value As String)
            _cli_prima_periodo = value
        End Set
    End Property


    Private _cli_prima_precio As String
    Public Property cli_prima_precio() As String
        Get
            Return _cli_prima_precio
        End Get
        Set(ByVal value As String)
            _cli_prima_precio = value
        End Set
    End Property


    Private _CLI_AVTO_TARJ As String
    Public Property CLI_AVTO_TARJ() As String
        Get
            Return _CLI_AVTO_TARJ
        End Get
        Set(ByVal value As String)
            _CLI_AVTO_TARJ = value
        End Set
    End Property


    Private _cli_interesa_seg As String
    Public Property cli_interesa_seg() As String
        Get
            Return _cli_interesa_seg
        End Get
        Set(ByVal value As String)
            _cli_interesa_seg = value
        End Set
    End Property


    Private _CLI_NOMBRE_SUCURSAL As String
    Public Property CLI_NOMBRE_SUCURSAL() As String
        Get
            Return _CLI_NOMBRE_SUCURSAL
        End Get
        Set(ByVal value As String)
            _CLI_NOMBRE_SUCURSAL = value
        End Set
    End Property


    Private _CLI_PREEXISTENCIA As String
    Public Property CLI_PREEXISTENCIA() As String
        Get
            Return _CLI_PREEXISTENCIA
        End Get
        Set(ByVal value As String)
            _CLI_PREEXISTENCIA = value
        End Set
    End Property


    Private _CLI_PROPENSO As String
    Public Property CLI_PROPENSO() As String
        Get
            Return _CLI_PROPENSO
        End Get
        Set(ByVal value As String)
            _CLI_PROPENSO = value
        End Set
    End Property


    Private _CLI_ACEPTA_FECHACARGO As String
    Public Property CLI_ACEPTA_FECHACARGO() As String
        Get
            Return _CLI_ACEPTA_FECHACARGO
        End Get
        Set(ByVal value As String)
            _CLI_ACEPTA_FECHACARGO = value
        End Set
    End Property


    Private _CLI_DIACARGO As String
    Public Property CLI_DIACARGO() As String
        Get
            Return _CLI_DIACARGO
        End Get
        Set(ByVal value As String)
            _CLI_DIACARGO = value
        End Set
    End Property


    Private _CLI_APISO As String
    Public Property CLI_APISO() As String
        Get
            Return _CLI_APISO
        End Get
        Set(ByVal value As String)
            _CLI_APISO = value
        End Set
    End Property


    Private _CLI_ADPTO As String
    Public Property CLI_ADPTO() As String
        Get
            Return _CLI_ADPTO
        End Get
        Set(ByVal value As String)
            _CLI_ADPTO = value
        End Set
    End Property

    Public Property cli_anombre2() As String
        Get
            Return _cli_anombre2
        End Get
        Set(ByVal value As String)
            _cli_anombre2 = value
        End Set
    End Property


    Private _CLI_AMPLIA_MUESTRA As String
    Public Property CLI_AMPLIA_MUESTRA() As String
        Get
            Return _CLI_AMPLIA_MUESTRA
        End Get
        Set(ByVal value As String)
            _CLI_AMPLIA_MUESTRA = value
        End Set
    End Property


    Private _CLI_CODTARJETA As String
    Public Property CLI_CODTARJETA() As String
        Get
            Return _CLI_CODTARJETA
        End Get
        Set(ByVal value As String)
            _CLI_CODTARJETA = value
        End Set
    End Property


    Private _CLI_TIPO_TARJETA As String
    Public Property CLI_TIPO_TARJETA() As String
        Get
            Return _CLI_TIPO_TARJETA
        End Get
        Set(ByVal value As String)
            _CLI_TIPO_TARJETA = value
        End Set
    End Property


    Private _cli_cuentacte_pantalla As String
    Public Property cli_cuentacte_pantalla() As String
        Get
            Return _cli_cuentacte_pantalla
        End Get
        Set(ByVal value As String)
            _cli_cuentacte_pantalla = value
        End Set
    End Property


    Private _cli_cuentacte As String
    Public Property cli_cuentacte() As String
        Get
            Return _cli_cuentacte
        End Get
        Set(ByVal value As String)
            _cli_cuentacte = value
        End Set
    End Property


    Private _cli_banco As String
    Public Property cli_banco() As String
        Get
            Return _cli_banco
        End Get
        Set(ByVal value As String)
            _cli_banco = value
        End Set
    End Property


    Private _cli_tipo_pago As String
    Public Property cli_tipo_pago() As String
        Get
            Return _cli_tipo_pago
        End Get
        Set(ByVal value As String)
            _cli_tipo_pago = value
        End Set
    End Property


    Private _cli_ciudad As String
    Public Property cli_ciudad() As String
        Get
            Return _cli_ciudad
        End Get
        Set(ByVal value As String)
            _cli_ciudad = value
        End Set
    End Property

    Public Property cli_numero() As String
        Get
            Return _cli_numero
        End Get
        Set(ByVal value As String)
            _cli_numero = value
        End Set
    End Property

    Public Property cli_id_cliente() As String
        Get
            Return _cli_id_cliente
        End Get
        Set(ByVal value As String)
            _cli_id_cliente = value
        End Set
    End Property


    Public Property cli_producto() As String
        Get
            Return _cli_producto
        End Get
        Set(ByVal value As String)
            _cli_producto = value
        End Set
    End Property

    Public Property cli_asexo() As String
        Get
            Return _cli_asexo
        End Get
        Set(ByVal value As String)
            _cli_asexo = value
        End Set
    End Property

    Private _cli_sexo As String
    Public Property cli_sexo() As String
        Get
            Return _cli_sexo
        End Get
        Set(ByVal value As String)
            _cli_sexo = value
        End Set
    End Property

    Private _CLI_ACODCOMUNA As String
    Public Property CLI_ACODCOMUNA() As String
        Get
            Return _CLI_ACODCOMUNA
        End Get
        Set(ByVal value As String)
            _CLI_ACODCOMUNA = value
        End Set
    End Property

    Private _CLI_NUMERO_CTACTE As String
    Public Property CLI_NUMERO_CTACTE() As String
        Get
            Return _CLI_NUMERO_CTACTE
        End Get
        Set(ByVal value As String)
            _CLI_NUMERO_CTACTE = value
        End Set
    End Property

    Private _CLI_TIPOTARJETA_1 As String
    Public Property CLI_TIPOTARJETA_1() As String
        Get
            Return _CLI_TIPOTARJETA_1
        End Get
        Set(ByVal value As String)
            _CLI_TIPOTARJETA_1 = value
        End Set
    End Property

    Private _CLI_NUMTARJETA_1 As String
    Public Property CLI_NUMTARJETA_1() As String
        Get
            Return _CLI_NUMTARJETA_1
        End Get
        Set(ByVal value As String)
            _CLI_NUMTARJETA_1 = value
        End Set
    End Property

    Private _CLI_TIPOTARJETA_2 As String
    Public Property CLI_TIPOTARJETA_2() As String
        Get
            Return _CLI_TIPOTARJETA_2
        End Get
        Set(ByVal value As String)
            _CLI_TIPOTARJETA_2 = value
        End Set
    End Property

    Private _CLI_NUMTARJETA_2 As String
    Public Property CLI_NUMTARJETA_2() As String
        Get
            Return _CLI_NUMTARJETA_2
        End Get
        Set(ByVal value As String)
            _CLI_NUMTARJETA_2 = value
        End Set
    End Property

    Private _CLI_TIPOTARJETA_3 As String
    Public Property CLI_TIPOTARJETA_3() As String
        Get
            Return _CLI_TIPOTARJETA_3
        End Get
        Set(ByVal value As String)
            _CLI_TIPOTARJETA_3 = value
        End Set
    End Property

    Private _CLI_NUMTARJETA_3 As String
    Public Property CLI_NUMTARJETA_3() As String
        Get
            Return _CLI_NUMTARJETA_3
        End Get
        Set(ByVal value As String)
            _CLI_NUMTARJETA_3 = value
        End Set
    End Property

    Private _CLI_APERTURA_CTACTE As String
    Public Property CLI_APERTURA_CTACTE() As String
        Get
            Return _CLI_APERTURA_CTACTE
        End Get
        Set(ByVal value As String)
            _CLI_APERTURA_CTACTE = value
        End Set
    End Property

    Private _CLI_OBSERVACION As String
    Public Property CLI_OBSERVACION() As String
        Get
            Return _CLI_OBSERVACION
        End Get
        Set(ByVal value As String)
            _CLI_OBSERVACION = value
        End Set
    End Property

    Private _CLI_AREAFONOCONTACTO As String
    Public Property CLI_AREAFONOCONTACTO() As String
        Get
            Return _CLI_AREAFONOCONTACTO
        End Get
        Set(ByVal value As String)
            _CLI_AREAFONOCONTACTO = value
        End Set
    End Property

    Private _CLI_AFONOCONTACTO As String
    Public Property CLI_AFONOCONTACTO() As String
        Get
            Return _CLI_AFONOCONTACTO
        End Get
        Set(ByVal value As String)
            _CLI_AFONOCONTACTO = value
        End Set
    End Property

    Private _CLI_AREFERENCIA As String
    Public Property CLI_AREFERENCIA() As String
        Get
            Return _CLI_AREFERENCIA
        End Get
        Set(ByVal value As String)
            _CLI_AREFERENCIA = value
        End Set
    End Property

    Private _CLI_ACODCIUDAD As String
    Public Property CLI_ACODCIUDAD() As String
        Get
            Return _CLI_ACODCIUDAD
        End Get
        Set(ByVal value As String)
            _CLI_ACODCIUDAD = value
        End Set
    End Property

    Private _CLI_NROTARJETA As String
    Public Property CLI_NROTARJETA() As String
        Get
            Return _CLI_NROTARJETA
        End Get
        Set(ByVal value As String)
            _CLI_NROTARJETA = value
        End Set
    End Property

    Private _CLI_NUM_CUENTACTE As String
    Public Property CLI_NUM_CUENTACTE() As String
        Get
            Return _CLI_NUM_CUENTACTE
        End Get
        Set(ByVal value As String)
            _CLI_NUM_CUENTACTE = value
        End Set
    End Property

    Private _CLI_NUM_TARJETA As String
    Public Property CLI_NUM_TARJETA() As String
        Get
            Return _CLI_NUM_TARJETA
        End Get
        Set(ByVal value As String)
            _CLI_NUM_TARJETA = value
        End Set
    End Property

    Private _CLI_ATIPO_CUENTA As String
    Public Property CLI_ATIPO_CUENTA() As String
        Get
            Return _CLI_ATIPO_CUENTA
        End Get
        Set(ByVal value As String)
            _CLI_ATIPO_CUENTA = value
        End Set
    End Property

    Private _CLI_ACEPTA_CORREO As String
    Public Property CLI_ACEPTA_CORREO() As String
        Get
            Return _CLI_ACEPTA_CORREO
        End Get
        Set(ByVal value As String)
            _CLI_ACEPTA_CORREO = value
        End Set
    End Property


    Private _CLI_PRIMA_MENSUAL As String
    Public Property CLI_PRIMA_MENSUAL() As String
        Get
            Return _CLI_PRIMA_MENSUAL
        End Get
        Set(ByVal value As String)
            _CLI_PRIMA_MENSUAL = value
        End Set
    End Property


    Private _CLI_TPO_DIRECION As String
    Public Property CLI_TPO_DIRECION() As String
        Get
            Return _CLI_TPO_DIRECION
        End Get
        Set(ByVal value As String)
            _CLI_TPO_DIRECION = value
        End Set
    End Property

    Private _CLI_AMEDIO_PAGO As String
    Public Property CLI_AMEDIO_PAGO() As String
        Get
            Return _CLI_AMEDIO_PAGO
        End Get
        Set(ByVal value As String)
            _CLI_AMEDIO_PAGO = value
        End Set
    End Property

    Private _CLI_ABANCO As String
    Public Property CLI_ABANCO() As String
        Get
            Return _CLI_ABANCO
        End Get
        Set(ByVal value As String)
            _CLI_ABANCO = value
        End Set
    End Property

    Private _CLI_ATARJETAVENCIMIENTO As String
    Public Property CLI_ATARJETAVENCIMIENTO() As String
        Get
            Return _CLI_ATARJETAVENCIMIENTO
        End Get
        Set(ByVal value As String)
            _CLI_ATARJETAVENCIMIENTO = value
        End Set
    End Property


    Private _CLI_ADIAPAGO As String
    Public Property CLI_ADIAPAGO() As String
        Get
            Return _CLI_ADIAPAGO
        End Get
        Set(ByVal value As String)
            _CLI_ADIAPAGO = value
        End Set
    End Property

    Public Property cli_referencia() As String
        Get
            Return _cli_referencia
        End Get
        Set(ByVal value As String)
            _cli_referencia = value
        End Set
    End Property

    Public Property cli_medio_pago() As String
        Get
            Return _cli_medio_pago
        End Get
        Set(ByVal value As String)
            _cli_medio_pago = value
        End Set
    End Property

    Public Property cli_formapago() As String
        Get
            Return _cli_formapago
        End Get
        Set(ByVal value As String)
            _cli_formapago = value
        End Set
    End Property

    Public Property cli_acelular() As String
        Get
            Return _cli_acelular
        End Get
        Set(ByVal value As String)
            _cli_acelular = value
        End Set
    End Property

    Public Property cli_afonovta() As String
        Get
            Return _cli_afonovta
        End Get
        Set(ByVal value As String)
            _cli_afonovta = value
        End Set
    End Property

    Public Property cli_aareafonovta() As String
        Get
            Return _cli_aareafonovta
        End Get
        Set(ByVal value As String)
            _cli_aareafonovta = value
        End Set
    End Property


    Public Property cli_estado_civil() As String
        Get
            Return _cli_estado_civil
        End Get
        Set(ByVal value As String)
            _cli_estado_civil = value
        End Set
    End Property


    Public Property cli_numfono() As String
        Get
            Return _cli_numfono
        End Get
        Set(ByVal value As String)
            _cli_numfono = value
        End Set
    End Property


    Public Property cli_areafono() As String
        Get
            Return _cli_areafono
        End Get
        Set(ByVal value As String)
            _cli_areafono = value
        End Set
    End Property

    Public Property cli_tipofono() As String
        Get
            Return _cli_tipofono
        End Get
        Set(ByVal value As String)
            _cli_tipofono = value
        End Set
    End Property

    Public Property cli_venta() As String
        Get
            Return _cli_venta
        End Get
        Set(ByVal value As String)
            _cli_venta = value
        End Set
    End Property


    Public Property cli_acepta_cargo() As String
        Get
            Return _cli_acepta_cargo
        End Get
        Set(ByVal value As String)
            _cli_acepta_cargo = value
        End Set
    End Property

    Public Property cli_acepta_prima() As String
        Get
            Return _cli_acepta_prima
        End Get
        Set(ByVal value As String)
            _cli_acepta_prima = value
        End Set
    End Property

    Public Property cli_acepta_contrato() As String
        Get
            Return _cli_acepta_contrato
        End Get
        Set(ByVal value As String)
            _cli_acepta_contrato = value
        End Set
    End Property

    Public Property cli_aobsmtvo_nointeresa() As String
        Get
            Return _cli_aobsmtvo_nointeresa
        End Get
        Set(ByVal value As String)
            _cli_aobsmtvo_nointeresa = value
        End Set
    End Property

    Public Property cli_motivonointeresa() As String
        Get
            Return _cli_motivonointeresa
        End Get
        Set(ByVal value As String)
            _cli_motivonointeresa = value
        End Set
    End Property

    Public Property cli_mtvo_ncobs() As String
        Get
            Return _cli_mtvo_ncobs
        End Get
        Set(ByVal value As String)
            _cli_mtvo_ncobs = value
        End Set
    End Property

    Public Property cli_mtvo_nocontrata() As String
        Get
            Return _cli_mtvo_nocontrata
        End Get
        Set(ByVal value As String)
            _cli_mtvo_nocontrata = value
        End Set
    End Property

    Public Property cli_acepta() As String
        Get
            Return _cli_acepta
        End Get
        Set(ByVal value As String)
            _cli_acepta = value
        End Set
    End Property


    Public Property cli_diacarga() As String
        Get
            Return _cli_diacarga
        End Get
        Set(ByVal value As String)
            _cli_diacarga = value
        End Set
    End Property

    Public Property cli_afechavcto() As String
        Get
            Return _cli_afechavcto
        End Get
        Set(ByVal value As String)
            _cli_afechavcto = value
        End Set
    End Property


    Private _cli_anrotarjeta As String
    Public Property cli_anrotarjeta() As String
        Get
            Return _cli_anrotarjeta
        End Get
        Set(ByVal value As String)
            _cli_anrotarjeta = value
        End Set
    End Property


    Public Property cli_atarjeta() As String
        Get
            Return _cli_atarjeta
        End Get
        Set(ByVal value As String)
            _cli_atarjeta = value
        End Set
    End Property

    Public Property cli_nro_conmodificacion() As String
        Get
            Return _cli_nro_conmodificacion
        End Get
        Set(ByVal value As String)
            _cli_nro_conmodificacion = value
        End Set
    End Property

    Public Property cli_tpopago() As String
        Get
            Return _cli_tpopago
        End Get
        Set(ByVal value As String)
            _cli_tpopago = value
        End Set
    End Property

    Public Property cli_aregion() As String
        Get
            Return _cli_aregion
        End Get
        Set(ByVal value As String)
            _cli_aregion = value
        End Set
    End Property


    Public Property cli_acod_ciudad() As String
        Get
            Return _cli_acod_ciudad
        End Get
        Set(ByVal value As String)
            _cli_acod_ciudad = value
        End Set
    End Property

    Public Property cli_aciudad() As String
        Get
            Return _cli_aciudad
        End Get
        Set(ByVal value As String)
            _cli_aciudad = value
        End Set
    End Property

    Public Property cli_acod_comuna() As String
        Get
            Return _cli_acod_comuna
        End Get
        Set(ByVal value As String)
            _cli_acod_comuna = value
        End Set
    End Property


    Public Property cli_acomuna() As String
        Get
            Return _cli_acomuna
        End Get
        Set(ByVal value As String)
            _cli_acomuna = value
        End Set
    End Property

    Public Property cli_anro() As String
        Get
            Return _cli_anro
        End Get
        Set(ByVal value As String)
            _cli_anro = value
        End Set
    End Property

    Public Property cli_acalle() As String
        Get
            Return _cli_acalle
        End Get
        Set(ByVal value As String)
            _cli_acalle = value
        End Set
    End Property

    Public Property cli_codactividad() As String
        Get
            Return _cli_codactividad
        End Get
        Set(ByVal value As String)
            _cli_codactividad = value
        End Set
    End Property

    Public Property cli_afechanacimiento() As String
        Get
            Return _cli_afechanacimiento
        End Get
        Set(ByVal value As String)
            _cli_afechanacimiento = value
        End Set
    End Property

    Public Property cli_adv() As String
        Get
            Return _cli_adv
        End Get
        Set(ByVal value As String)
            _cli_adv = value
        End Set
    End Property

    Public Property cli_arut() As String
        Get
            Return _cli_arut
        End Get
        Set(ByVal value As String)
            _cli_arut = value
        End Set
    End Property

    Public Property cli_amaterno() As String
        Get
            Return _cli_amaterno
        End Get
        Set(ByVal value As String)
            _cli_amaterno = value
        End Set
    End Property

    Public Property cli_apaterno() As String
        Get
            Return _cli_apaterno
        End Get
        Set(ByVal value As String)
            _cli_apaterno = value
        End Set
    End Property

    Public Property cli_anombre() As String
        Get
            Return _cli_anombre
        End Get
        Set(ByVal value As String)
            _cli_anombre = value
        End Set
    End Property

    Public Property CLI_INTERESA() As String
        Get
            Return _CLI_INTERESA
        End Get
        Set(ByVal value As String)
            _CLI_INTERESA = value
        End Set
    End Property

    Public Property cli_comunica_tercero() As String
        Get
            Return _cli_comunica_tercero
        End Get
        Set(ByVal value As String)
            _cli_comunica_tercero = value
        End Set
    End Property

    Public Property cli_comunica_con() As String
        Get
            Return _cli_comunica_con
        End Get
        Set(ByVal value As String)
            _cli_comunica_con = value
        End Set
    End Property

    Public Property cli_no_conecta() As String
        Get
            Return _cli_no_conecta
        End Get
        Set(ByVal value As String)
            _cli_no_conecta = value
        End Set
    End Property

    Public Property cli_conecta() As String
        Get
            Return _cli_conecta
        End Get
        Set(ByVal value As String)
            _cli_conecta = value
        End Set
    End Property


    Public Property cli_fecha_carga() As String
        Get
            Return _cli_fecha_carga
        End Get
        Set(ByVal value As String)
            _cli_fecha_carga = value
        End Set
    End Property

    Public Property cli_agen_hora() As String
        Get
            Return _cli_agen_hora
        End Get
        Set(ByVal value As String)
            _cli_agen_hora = value
        End Set
    End Property

    Public Property cli_agen_fecha() As String
        Get
            Return _cli_agen_fecha
        End Get
        Set(ByVal value As String)
            _cli_agen_fecha = value
        End Set
    End Property

    Public Property cli_agen_estado() As String
        Get
            Return _cli_agen_estado
        End Get
        Set(ByVal value As String)
            _cli_agen_estado = value
        End Set
    End Property

    Public Property cli_call_id() As String
        Get
            Return _cli_call_id
        End Get
        Set(ByVal value As String)
            _cli_call_id = value
        End Set
    End Property




    Public Property cli_ip_agente() As String
        Get
            Return _cli_ip_agente
        End Get
        Set(ByVal value As String)
            _cli_ip_agente = value
        End Set
    End Property

    Public Property cli_horavta() As String
        Get
            Return _cli_horavta
        End Get
        Set(ByVal value As String)
            _cli_horavta = value
        End Set
    End Property

    Public Property cli_fechavta() As String
        Get
            Return _cli_fechavta
        End Get
        Set(ByVal value As String)
            _cli_fechavta = value
        End Set
    End Property

    Public Property cli_hora() As String
        Get
            Return _cli_hora
        End Get
        Set(ByVal value As String)
            _cli_hora = value
        End Set
    End Property

    Public Property cli_fecha() As String
        Get
            Return _cli_fecha
        End Get
        Set(ByVal value As String)
            _cli_fecha = value
        End Set
    End Property


    Public Property cli_email() As String
        Get
            Return _cli_email
        End Get
        Set(ByVal value As String)
            _cli_email = value
        End Set
    End Property


    Public Property cli_estadofonoalt() As Int16
        Get
            Return _cli_estadofonoalt
        End Get
        Set(ByVal value As Int16)
            _cli_estadofonoalt = value
        End Set
    End Property

    Public Property cli_estadofono6() As Int16
        Get
            Return _cli_estadofono6
        End Get
        Set(ByVal value As Int16)
            _cli_estadofono6 = value
        End Set
    End Property
    Public Property cli_estadofono5() As Int16
        Get
            Return _cli_estadofono5
        End Get
        Set(ByVal value As Int16)
            _cli_estadofono5 = value
        End Set
    End Property
    Public Property cli_estadofono4() As Int16
        Get
            Return _cli_estadofono4
        End Get
        Set(ByVal value As Int16)
            _cli_estadofono4 = value
        End Set
    End Property
    Public Property cli_estadofono3() As Int16
        Get
            Return _cli_estadofono3
        End Get
        Set(ByVal value As Int16)
            _cli_estadofono3 = value
        End Set
    End Property
    Public Property cli_estadofono2() As Int16
        Get
            Return _cli_estadofono2
        End Get
        Set(ByVal value As Int16)
            _cli_estadofono2 = value
        End Set
    End Property

    Public Property cli_estadofono1() As Int16
        Get
            Return _cli_estadofono1
        End Get
        Set(ByVal value As Int16)
            _cli_estadofono1 = value
        End Set
    End Property


    Public Property cli_region() As String
        Get
            Return _cli_region
        End Get
        Set(ByVal value As String)
            _cli_region = value
        End Set
    End Property

    Public Property cli_nointereso() As String
        Get
            Return _cli_nointereso
        End Get
        Set(ByVal value As String)
            _cli_nointereso = value
        End Set
    End Property

    Public Property cli_asegurado() As String
        Get
            Return _cli_asegurado
        End Get
        Set(ByVal value As String)
            _cli_asegurado = value
        End Set
    End Property

    Public Property cli_codverificacion() As String
        Get
            Return _cli_codverificacion
        End Get
        Set(ByVal value As String)
            _cli_codverificacion = value
        End Set
    End Property

    Public Property cli_plan() As UShort
        Get
            Return _cli_plan
        End Get
        Set(ByVal value As UShort)
            _cli_plan = value
        End Set
    End Property


    Public Property cli_tpocontrato() As UShort
        Get
            Return _cli_tpocontrato
        End Get
        Set(ByVal value As UShort)
            _cli_tpocontrato = value
        End Set
    End Property

    Public Property cli_primapesos() As String
        Get
            Return _cli_primapesos
        End Get
        Set(ByVal value As String)
            _cli_primapesos = value
        End Set
    End Property

    Public Property cli_primauf() As String
        Get
            Return _cli_primauf
        End Get
        Set(ByVal value As String)
            _cli_primauf = value
        End Set
    End Property


    Public Property cli_intentos_max() As UShort
        Get
            Return _cli_intentos_max
        End Get
        Set(ByVal value As UShort)
            _cli_intentos_max = value
        End Set
    End Property


    Public Property cli_agen_obs() As String
        Get
            Return _cli_agen_obs
        End Get
        Set(ByVal value As String)
            _cli_agen_obs = value
        End Set
    End Property

    Public Property cli_intentos() As String
        Get
            Return _cli_intentos
        End Get
        Set(ByVal value As String)
            _cli_intentos = value
        End Set
    End Property

    Public Property cli_estado() As String
        Get
            Return _cli_estado
        End Get
        Set(ByVal value As String)
            _cli_estado = value
        End Set
    End Property

    Public Property cli_agente() As String
        Get
            Return _cli_agente
        End Get
        Set(ByVal value As String)
            _cli_agente = value
        End Set
    End Property





    Public Property cli_telefonoalt() As String
        Get
            Return _cli_telefonoalt
        End Get
        Set(ByVal value As String)
            _cli_telefonoalt = value
        End Set
    End Property


    Public Property cli_telefono1() As String
        Get
            Return _cli_telefono1
        End Get
        Set(ByVal value As String)
            _cli_telefono1 = value
        End Set
    End Property

    Public Property cli_fonobase1() As String
        Get
            Return _cli_fonobase1
        End Get
        Set(ByVal value As String)
            _cli_fonobase1 = value
        End Set
    End Property

    Public Property cli_areabase1() As String
        Get
            Return _cli_areabase1
        End Get
        Set(ByVal value As String)
            _cli_areabase1 = value
        End Set
    End Property

    Public Property cli_telefono2() As String
        Get
            Return _cli_telefono2
        End Get
        Set(ByVal value As String)
            _cli_telefono2 = value
        End Set
    End Property

    Public Property cli_fonobase2() As String
        Get
            Return _cli_fonobase2
        End Get
        Set(ByVal value As String)
            _cli_fonobase2 = value
        End Set
    End Property

    Public Property cli_areabase2() As String
        Get
            Return _cli_areabase2
        End Get
        Set(ByVal value As String)
            _cli_areabase2 = value
        End Set
    End Property
    Public Property cli_telefono3() As String
        Get
            Return _cli_telefono3
        End Get
        Set(ByVal value As String)
            _cli_telefono3 = value
        End Set
    End Property

    Public Property cli_fonobase3() As String
        Get
            Return _cli_fonobase3
        End Get
        Set(ByVal value As String)
            _cli_fonobase3 = value
        End Set
    End Property

    Public Property cli_areabase3() As String
        Get
            Return _cli_areabase3
        End Get
        Set(ByVal value As String)
            _cli_areabase3 = value
        End Set
    End Property
    Public Property cli_telefono4() As String
        Get
            Return _cli_telefono4
        End Get
        Set(ByVal value As String)
            _cli_telefono4 = value
        End Set
    End Property

    Public Property cli_fonobase4() As String
        Get
            Return _cli_fonobase4
        End Get
        Set(ByVal value As String)
            _cli_fonobase4 = value
        End Set
    End Property

    Public Property cli_areabase4() As String
        Get
            Return _cli_areabase4
        End Get
        Set(ByVal value As String)
            _cli_areabase4 = value
        End Set
    End Property
    Public Property cli_telefono5() As String
        Get
            Return _cli_telefono5
        End Get
        Set(ByVal value As String)
            _cli_telefono5 = value
        End Set
    End Property

    Public Property cli_fonobase5() As String
        Get
            Return _cli_fonobase5
        End Get
        Set(ByVal value As String)
            _cli_fonobase5 = value
        End Set
    End Property

    Public Property cli_areabase5() As String
        Get
            Return _cli_areabase5
        End Get
        Set(ByVal value As String)
            _cli_areabase5 = value
        End Set
    End Property
    Public Property cli_telefono6() As String
        Get
            Return _cli_telefono6
        End Get
        Set(ByVal value As String)
            _cli_telefono6 = value
        End Set
    End Property

    Public Property cli_fonobase6() As String
        Get
            Return _cli_fonobase6
        End Get
        Set(ByVal value As String)
            _cli_fonobase6 = value
        End Set
    End Property

    Public Property cli_areabase6() As String
        Get
            Return _cli_areabase6
        End Get
        Set(ByVal value As String)
            _cli_areabase6 = value
        End Set
    End Property

    Public Property cli_aemail() As String
        Get
            Return _cli_aemail
        End Get
        Set(ByVal value As String)
            _cli_aemail = value
        End Set
    End Property

    Public Property cli_comuna() As String
        Get
            Return _cli_comuna
        End Get
        Set(ByVal value As String)
            _cli_comuna = value
        End Set
    End Property

    Public Property cli_direccion() As String
        Get
            Return _cli_direccion
        End Get
        Set(ByVal value As String)
            _cli_direccion = value
        End Set
    End Property

    Public Property cli_materno() As String
        Get
            Return _cli_materno
        End Get
        Set(ByVal value As String)
            _cli_materno = value
        End Set
    End Property

    Public Property cli_paterno() As String
        Get
            Return _cli_paterno
        End Get
        Set(ByVal value As String)
            _cli_paterno = value
        End Set
    End Property

    Public Property cli_nombre() As String
        Get
            Return _cli_nombre
        End Get
        Set(ByVal value As String)
            _cli_nombre = value
        End Set
    End Property

    Public Property cli_fechanacimiento() As String
        Get
            Return _cli_fechanacimiento
        End Get
        Set(ByVal value As String)
            _cli_fechanacimiento = value
        End Set
    End Property

    Public Property cli_edad() As String
        Get
            Return _cli_edad
        End Get
        Set(ByVal value As String)
            _cli_edad = value
        End Set
    End Property

    Public Property cli_dv() As String
        Get
            Return _cli_dv
        End Get
        Set(ByVal value As String)
            _cli_dv = value
        End Set
    End Property

    Public Property cli_rut() As String
        Get
            Return _cli_rut
        End Get
        Set(ByVal value As String)
            _cli_rut = value
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

    Public Property cli_fecha_apertura() As String
        Get
            Return _cli_fecha_apertura
        End Get
        Set(ByVal value As String)
            _cli_fecha_apertura = value
        End Set
    End Property
    Public Property cli_tipobase() As String
        Get
            Return _cli_tipobase
        End Get
        Set(ByVal value As String)
            _cli_tipobase = value
        End Set
    End Property

    'capos extras

    Public Property campo1() As String
        Get
            Return _campo1
        End Get
        Set(ByVal value As String)
            _campo1 = value
        End Set
    End Property

    Public Property campo2() As String
        Get
            Return _campo2
        End Get
        Set(ByVal value As String)
            _campo2 = value
        End Set
    End Property

    Public Property campo3() As String
        Get
            Return _campo3
        End Get
        Set(ByVal value As String)
            _campo3 = value
        End Set
    End Property

    Public Property campo4() As String
        Get
            Return _campo4
        End Get
        Set(ByVal value As String)
            _campo4 = value
        End Set
    End Property

    Public Property campo5() As String
        Get
            Return _campo5
        End Get
        Set(ByVal value As String)
            _campo5 = value
        End Set
    End Property

    Public Property campo6() As String
        Get
            Return _campo6
        End Get
        Set(ByVal value As String)
            _campo6 = value
        End Set
    End Property

    Public Property campo7() As String
        Get
            Return _campo7
        End Get
        Set(ByVal value As String)
            _campo7 = value
        End Set
    End Property

    Public Property campo8() As String
        Get
            Return _campo8
        End Get
        Set(ByVal value As String)
            _campo8 = value
        End Set
    End Property

    Public Property campo9() As String
        Get
            Return _campo9
        End Get
        Set(ByVal value As String)
            _campo9 = value
        End Set
    End Property

    Public Property campo10() As String
        Get
            Return _campo10
        End Get
        Set(ByVal value As String)
            _campo10 = value
        End Set
    End Property

    Public Property campo11() As String
        Get
            Return _campo11
        End Get
        Set(ByVal value As String)
            _campo11 = value
        End Set
    End Property

    Public Property campo12() As String
        Get
            Return _campo12
        End Get
        Set(ByVal value As String)
            _campo12 = value
        End Set
    End Property

    Public Property campo13() As String
        Get
            Return _campo13
        End Get
        Set(ByVal value As String)
            _campo13 = value
        End Set
    End Property

    Public Property campo14() As String
        Get
            Return _campo14
        End Get
        Set(ByVal value As String)
            _campo14 = value
        End Set
    End Property

    Public Property campo15() As String
        Get
            Return _campo15
        End Get
        Set(ByVal value As String)
            _campo15 = value
        End Set
    End Property

    Public Property campo16() As String
        Get
            Return _campo16
        End Get
        Set(ByVal value As String)
            _campo16 = value
        End Set
    End Property

    Public Property campo17() As String
        Get
            Return _campo17
        End Get
        Set(ByVal value As String)
            _campo17 = value
        End Set
    End Property

    Public Property campo18() As String
        Get
            Return _campo18
        End Get
        Set(ByVal value As String)
            _campo18 = value
        End Set
    End Property

    Public Property campo19() As String
        Get
            Return _campo19
        End Get
        Set(ByVal value As String)
            _campo19 = value
        End Set
    End Property

    Public Property campo20() As String
        Get
            Return _campo20
        End Get
        Set(ByVal value As String)
            _campo20 = value
        End Set
    End Property

    Public Property campo21() As String
        Get
            Return _campo21
        End Get
        Set(ByVal value As String)
            _campo21 = value
        End Set
    End Property

    Public Property campo22() As String
        Get
            Return _campo22
        End Get
        Set(ByVal value As String)
            _campo22 = value
        End Set
    End Property

    Public Property campo23() As String
        Get
            Return _campo23
        End Get
        Set(ByVal value As String)
            _campo23 = value
        End Set
    End Property

    Public Property campo24() As String
        Get
            Return _campo24
        End Get
        Set(ByVal value As String)
            _campo24 = value
        End Set
    End Property

    Public Property campo25() As String
        Get
            Return _campo25
        End Get
        Set(ByVal value As String)
            _campo25 = value
        End Set
    End Property

    Public Property campo26() As String
        Get
            Return _campo26
        End Get
        Set(ByVal value As String)
            _campo26 = value
        End Set
    End Property

    Public Property campo27() As String
        Get
            Return _campo27
        End Get
        Set(ByVal value As String)
            _campo27 = value
        End Set
    End Property

    Public Property campo28() As String
        Get
            Return _campo28
        End Get
        Set(ByVal value As String)
            _campo28 = value
        End Set
    End Property

    Public Property campo29() As String
        Get
            Return _campo29
        End Get
        Set(ByVal value As String)
            _campo29 = value
        End Set
    End Property

    Public Property campo30() As String
        Get
            Return _campo30
        End Get
        Set(ByVal value As String)
            _campo30 = value
        End Set
    End Property

    Public Property campo31() As String
        Get
            Return _campo31
        End Get
        Set(ByVal value As String)
            _campo31 = value
        End Set
    End Property

    Public Property campo32() As String
        Get
            Return _campo32
        End Get
        Set(ByVal value As String)
            _campo32 = value
        End Set
    End Property

    Public Property campo33() As String
        Get
            Return _campo33
        End Get
        Set(ByVal value As String)
            _campo33 = value
        End Set
    End Property

    Public Property campo34() As String
        Get
            Return _campo34
        End Get
        Set(ByVal value As String)
            _campo34 = value
        End Set
    End Property

    Public Property campo35() As String
        Get
            Return _campo35
        End Get
        Set(ByVal value As String)
            _campo35 = value
        End Set
    End Property

    Public Property campo36() As String
        Get
            Return _campo36
        End Get
        Set(ByVal value As String)
            _campo36 = value
        End Set
    End Property

    Public Property campo37() As String
        Get
            Return _campo37
        End Get
        Set(ByVal value As String)
            _campo37 = value
        End Set
    End Property

    Public Property campo38() As String
        Get
            Return _campo38
        End Get
        Set(ByVal value As String)
            _campo38 = value
        End Set
    End Property

    Public Property campo39() As String
        Get
            Return _campo39
        End Get
        Set(ByVal value As String)
            _campo39 = value
        End Set
    End Property

    Public Property campo40() As String
        Get
            Return _campo40
        End Get
        Set(ByVal value As String)
            _campo40 = value
        End Set
    End Property

    Public Property campo41() As String
        Get
            Return _campo41
        End Get
        Set(ByVal value As String)
            _campo41 = value
        End Set
    End Property

    Public Property campo42() As String
        Get
            Return _campo42
        End Get
        Set(ByVal value As String)
            _campo42 = value
        End Set
    End Property

    Public Property campo43() As String
        Get
            Return _campo43
        End Get
        Set(ByVal value As String)
            _campo43 = value
        End Set
    End Property

    Public Property campo44() As String
        Get
            Return _campo44
        End Get
        Set(ByVal value As String)
            _campo44 = value
        End Set
    End Property

    Public Property campo45() As String
        Get
            Return _campo45
        End Get
        Set(ByVal value As String)
            _campo45 = value
        End Set
    End Property

    Public Property campo46() As String
        Get
            Return _campo46
        End Get
        Set(ByVal value As String)
            _campo46 = value
        End Set
    End Property

    Public Property campo47() As String
        Get
            Return _campo47
        End Get
        Set(ByVal value As String)
            _campo47 = value
        End Set
    End Property

    Public Property campo48() As String
        Get
            Return _campo48
        End Get
        Set(ByVal value As String)
            _campo48 = value
        End Set
    End Property

    Public Property campo49() As String
        Get
            Return _campo49
        End Get
        Set(ByVal value As String)
            _campo49 = value
        End Set
    End Property

    Public Property campo50() As String
        Get
            Return _campo50
        End Get
        Set(ByVal value As String)
            _campo50 = value
        End Set
    End Property

    Public Property campo51() As String
        Get
            Return _campo51
        End Get
        Set(ByVal value As String)
            _campo51 = value
        End Set
    End Property

    Public Property campo52() As String
        Get
            Return _campo52
        End Get
        Set(ByVal value As String)
            _campo52 = value
        End Set
    End Property

    Public Property campo53() As String
        Get
            Return _campo53
        End Get
        Set(ByVal value As String)
            _campo53 = value
        End Set
    End Property

    Public Property campo54() As String
        Get
            Return _campo54
        End Get
        Set(ByVal value As String)
            _campo54 = value
        End Set
    End Property

    Public Property campo55() As String
        Get
            Return _campo55
        End Get
        Set(ByVal value As String)
            _campo55 = value
        End Set
    End Property

    Public Property campo56() As String
        Get
            Return _campo56
        End Get
        Set(ByVal value As String)
            _campo56 = value
        End Set
    End Property

    Public Property campo57() As String
        Get
            Return _campo57
        End Get
        Set(ByVal value As String)
            _campo57 = value
        End Set
    End Property

    Public Property campo58() As String
        Get
            Return _campo58
        End Get
        Set(ByVal value As String)
            _campo58 = value
        End Set
    End Property

    Public Property campo59() As String
        Get
            Return _campo59
        End Get
        Set(ByVal value As String)
            _campo59 = value
        End Set
    End Property

    Public Property campo60() As String
        Get
            Return _campo60
        End Get
        Set(ByVal value As String)
            _campo60 = value
        End Set
    End Property



End Class