Option Strict Off
Option Explicit On

Imports Entidad

Module modCliente
    Public CLIENTE As eCliente

    ' variable global que guardara los datos del cliente y su gestion hasta el final
    Public Function inicializarCliente(ByRef row As DataRow) As eCliente
        Dim dummy As New eCliente

        With dummy
            Call InicializaVariables(dummy)
            '----------------------------
            .cli_id = row("CLI_ID") & ""
            .cli_rut = row("CLI_RUT") & ""
            .cli_dv = row("CLI_DV") & ""
            .cli_edad = row("CLI_EDAD") & UShort.MinValue
            .cli_fechanacimiento = row("CLI_FECHANACIMIENTO") & ""
            .cli_nombre = row("CLI_NOMBRE") & ""
            .cli_paterno = row("CLI_PATERNO") & ""
            .cli_materno = row("CLI_MATERNO") & ""
            .cli_sexo = row("CLI_SEXO") & ""
            .cli_direccion = row("CLI_DIRECCION") & ""
            .cli_comuna = row("CLI_COMUNA") & ""
            .CLI_ACODCOMUNA = row("CLI_ACOD_COMUNA") & ""
            .cli_region = row("CLI_REGION") & ""
            .cli_email = row("CLI_EMAIL") & ""
            .cli_areabase1 = row("CLI_AREABASE1") & ""
            .cli_fonobase1 = row("CLI_FONOBASE1") & ""
            .cli_telefono1 = row("CLI_TELEFONO1") & ""
            .cli_areabase2 = row("CLI_AREABASE2") & ""
            .cli_fonobase2 = row("CLI_FONOBASE2") & ""
            .cli_telefono2 = row("CLI_TELEFONO2") & ""
            .cli_areabase3 = row("CLI_AREABASE3") & ""
            .cli_fonobase3 = row("CLI_FONOBASE3") & ""
            .cli_telefono3 = row("CLI_TELEFONO3") & ""
            .cli_areabase4 = row("CLI_AREABASE4") & ""
            .cli_fonobase4 = row("CLI_FONOBASE4") & ""
            .cli_telefono4 = row("CLI_TELEFONO4") & ""
            .cli_areabase5 = row("CLI_AREABASE5") & ""
            .cli_fonobase5 = row("CLI_FONOBASE5") & ""
            .cli_telefono5 = row("CLI_TELEFONO5") & ""
            .cli_areabase6 = row("CLI_AREABASE6") & ""
            .cli_fonobase6 = row("CLI_FONOBASE6") & ""
            .cli_telefono6 = row("CLI_TELEFONO6") & ""
            .cli_telefonoalt = row("CLI_TELEFONOALT") & ""
            .CLI_NUMERO_CTACTE = row("CLI_NUMERO_CTACTE") & ""
            .CLI_TIPOTARJETA_1 = row("CLI_TIPOTARJETA_1") & ""
            .CLI_NUMTARJETA_1 = row("CLI_NUMTARJETA_1") & ""
            .CLI_TIPOTARJETA_2 = row("CLI_TIPOTARJETA_2") & ""
            .CLI_NUMTARJETA_2 = row("CLI_NUMTARJETA_2") & ""
            .CLI_TIPOTARJETA_3 = row("CLI_TIPOTARJETA_3") & ""
            .CLI_NUMTARJETA_3 = row("CLI_NUMTARJETA_3") & ""
            .CLI_APERTURA_CTACTE = row("CLI_APERTURA_CTACTE") & ""
            .cli_tipobase = row("CLI_TIPOBASE") & ""

            .cli_agen_obs = row("CLI_AGEN_OBS") & ""

            If IsDBNull(row("CLI_INTENTOS_MAX")) Then
                .cli_intentos_max = "5"
            Else
                .cli_intentos_max = Trim(row("CLI_INTENTOS_MAX"))
            End If

            If IsDBNull(row("CLI_INTENTOS")) Then
                .cli_intentos = 1
            Else
                .cli_intentos = row("CLI_INTENTOS") + 1
            End If

            .cli_codverificacion = row("CLI_CODVERIFICACION") & ""

            .campo1 = row("campo1") & ""
            .campo2 = row("campo2") & ""
            .campo3 = row("campo3") & ""
            .campo4 = row("campo4") & ""
            .campo5 = row("campo5") & ""
            .campo6 = row("campo6") & ""
            .campo7 = row("campo7") & ""
            .campo8 = row("campo8") & ""
            .campo9 = row("campo9") & ""
            .campo10 = row("campo10") & ""
            .campo11 = row("campo11") & ""
            .campo12 = row("campo12") & ""
            .campo13 = row("campo13") & ""
            .campo14 = row("campo14") & ""
            .campo15 = row("campo15") & ""
            .campo16 = row("campo16") & ""
            .campo17 = row("campo17") & ""
            .campo18 = row("campo18") & ""
            .campo19 = row("campo19") & ""
            .campo20 = row("campo20") & ""
            .campo21 = row("campo21") & ""
            .campo22 = row("campo22") & ""
            .campo23 = row("campo23") & ""
            .campo24 = row("campo24") & ""
            .campo25 = row("campo25") & ""
            .campo26 = row("campo26") & ""
            .campo27 = row("campo27") & ""
            .campo28 = row("campo28") & ""
            .campo29 = row("campo29") & ""
            .campo30 = row("campo30") & ""
            .campo31 = row("campo31") & ""
            .campo32 = row("campo32") & ""
            .campo33 = row("campo33") & ""
            .campo34 = row("campo34") & ""
            .campo35 = row("campo35") & ""
            .campo36 = row("campo36") & ""
            .campo37 = row("campo37") & ""
            .campo38 = row("campo38") & ""
            .campo39 = row("campo39") & ""
            .campo40 = row("campo40") & ""
            .campo41 = row("campo41") & ""
            .campo42 = row("campo42") & ""
            .campo43 = row("campo43") & ""
            .campo44 = row("campo44") & ""
            .campo45 = row("campo45") & ""
            .campo46 = row("campo46") & ""
            .campo47 = row("campo47") & ""
            .campo48 = row("campo48") & ""
            .campo49 = row("campo49") & ""
            .campo50 = row("campo50") & ""
            .campo51 = row("campo51") & ""
            .campo52 = row("campo52") & ""
            .campo53 = row("campo53") & ""
            .campo54 = row("campo54") & ""
            .campo55 = row("campo55") & ""
            .campo56 = row("campo56") & ""
            .campo57 = row("campo57") & ""
            .campo58 = row("campo58") & ""
            .campo59 = row("campo59") & ""
            .campo60 = row("campo60") & ""

            .cli_segmento = row("campo3") & ""
            .CLI_NOMBRE_EJECUTIVO = row("campo4") & ""
            .CLI_NOMBRE_SUCURSAL = row("Campo5") & ""
            .CLI_AVTO_TARJ = row("campo2") & ""

        End With

        inicializarCliente = dummy
        If db_central = 4 Then
            vpPosicion.LLAMANDO = False
        End If
    End Function

    Public Sub InicializaVariables(ByRef dummy As eCliente)

        With dummy
            .cli_id = Short.MinValue
            .CLI_PRODUCTO = ""
            .CLI_ID_CLIENTE = ""
            .cli_rut = ""
            .cli_dv = ""
            .cli_nombre = ""
            .cli_paterno = ""
            .cli_materno = ""
            .cli_fechanacimiento = ""
            .cli_sexo = ""
            .cli_edad = ""
            .cli_direccion = ""
            .CLI_NUMERO = ""
            .cli_comuna = ""
            .CLI_CIUDAD = ""
            .cli_region = ""
            .CLI_TIPO_PAGO = ""
            .CLI_BANCO = ""
            .CLI_CUENTACTE = ""
            .CLI_CUENTACTE_PANTALLA = ""
            .CLI_TIPO_TARJETA = ""
            .CLI_CODTARJETA = ""
            .cli_email = ""
            .CLI_AMPLIA_MUESTRA = ""
            .cli_medio_pago = ""
            .cli_areabase1 = ""
            .cli_fonobase1 = ""
            .cli_telefono1 = ""
            .cli_areabase2 = ""
            .cli_fonobase2 = ""
            .cli_telefono2 = ""
            .cli_areabase3 = ""
            .cli_fonobase3 = ""
            .cli_telefono3 = ""
            .cli_areabase4 = ""
            .cli_fonobase4 = ""
            .cli_telefono4 = ""
            .cli_areabase5 = ""
            .cli_fonobase5 = ""
            .cli_telefono5 = ""
            .cli_areabase6 = ""
            .cli_fonobase6 = ""
            .cli_telefono6 = ""
            .cli_telefonoalt = ""

            .cli_plan = 0
            .cli_fecha = ""
            .cli_hora = ""
            .cli_fechavta = ""
            .cli_horavta = ""
            .cli_agente = ""
            .cli_ip_agente = ""
            .cli_estado = ""
            .cli_intentos = ""
            .cli_call_id = ""
            .cli_agen_estado = ""
            .cli_agen_fecha = ""
            .cli_agen_hora = ""
            .cli_agen_obs = ""
            .cli_primauf = ""
            .cli_primapesos = 0
            .cli_fecha_carga = ""

            .cli_conecta = ""
            .cli_no_conecta = ""
            .cli_comunica_con = ""
            .cli_comunica_tercero = ""

            .CLI_INTERESA = ""
            .cli_anombre = ""
            .CLI_ANOMBRE2 = ""
            .cli_apaterno = ""
            .cli_amaterno = ""
            .cli_arut = ""
            .cli_adv = ""
            .cli_afechanacimiento = ""
            .cli_aemail = ""
            .cli_codactividad = 0
            .cli_acalle = ""
            .cli_anro = ""
            .CLI_ADPTO = ""
            .CLI_APISO = ""
            .cli_acomuna = ""
            .cli_aciudad = ""
            .cli_acod_comuna = ""
            .cli_acod_ciudad = ""

            .cli_aregion = ""
            .cli_tpopago = 0
            .cli_nro_conmodificacion = 0
            .CLI_ATARJETA = ""
            .CLI_ANROTARJETA = ""
            .CLI_AFECHAVCTO = ""
            .CLI_DIACARGO = ""
            .cli_acepta_cargo = ""
            .CLI_ACEPTA_FECHACARGO = ""
            .cli_mtvo_nocontrata = ""
            .cli_mtvo_ncobs = ""

            .cli_venta = 0
            .CLI_TIPOFONO = 0
            .cli_areafono = ""
            .cli_numfono = ""
            .cli_nointereso = ""
            .CLI_PROPENSO = ""
            .CLI_PREEXISTENCIA = ""
            .CLI_NOMBRE_SUCURSAL = ""
            .cli_acod_comuna = ""
            .CLI_ACODCOMUNA = ""
            .CLI_ACODCIUDAD = ""
            .CLI_ACEPTA_CORREO = ""
            .CLI_AMEDIO_PAGO = ""
            .CLI_OBSERVACION = ""
            .cli_aareafonovta = ""
            .cli_afonovta = ""
            .cli_tpopago = ""
            .cli_plan = "0"
            .CLI_TPO_DIRECION = ""
            .cli_acelular = ""
            .cli_acepta_prima = ""
            .CLI_AREFERENCIA = ""


            .cli_interesa_seg = ""
            .cli_aobsmtvo_nointeresa = ""
            .CLI_AVTO_TARJ = ""
            .cli_prima_precio = ""
            .cli_prima_periodo = ""




        End With
    End Sub
End Module