Imports Entidad

Public Class clsClienteDA
    Dim con As New clsConexion
    Dim query As String
    Dim tipoConexion As Integer
    Dim vlSqlParam As New Mok.SqlParametros
    '********* Guarda los datos obtenidos de la venta ***************
    ''' <summary>
    ''' GUARDA LOS DATOS OBTENIDOS DE LA APLICACION DE VENTAS EN LA TABLA CLI
    ''' </summary>
    ''' <param name="_cliente"></param>
    ''' <remarks></remarks>
    Public Sub GuardaDatosCliente(ByVal _cliente As eCliente)
        vlSqlParam.Clear()
        query = "[GestionVenta].sp_" + nomcampania + "_Guarda_Cliente"
        vlSqlParam.Add("@CLI_ID", _cliente.cli_id, SqlDbType.BigInt)
        vlSqlParam.Add("@CLI_FECHA", _cliente.cli_fecha, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_HORA", _cliente.cli_hora, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_FECHAVTA", _cliente.cli_fechavta, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_HORAVTA", _cliente.cli_horavta, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_AGENTE", _cliente.cli_agente, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_IP_AGENTE", _cliente.cli_ip_agente, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ESTADO", _cliente.cli_estado, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_INTENTOS", _cliente.cli_intentos, SqlDbType.TinyInt)
        vlSqlParam.Add("@CLI_CALL_ID", _cliente.cli_call_id, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_AGEN_ESTADO", _cliente.cli_agen_estado, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_AGEN_FECHA", _cliente.cli_agen_fecha, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_AGEN_HORA", _cliente.cli_agen_hora, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_AGEN_OBS", _cliente.cli_agen_obs, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_CONECTA", _cliente.cli_conecta, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_NO_CONECTA", _cliente.cli_no_conecta, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_COMUNICA_CON", _cliente.cli_comunica_con, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_COMUNICA_TERCERO", _cliente.cli_comunica_tercero, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_INTERESA_SEG", _cliente.cli_interesa_seg, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ACEPTA_CARGO", _cliente.cli_acepta_cargo, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ACEPTA_PRIMA", _cliente.cli_acepta_prima, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ACEPTA_CORREO", _cliente.CLI_ACEPTA_CORREO, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ANOMBRE", _cliente.cli_anombre, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ANOMBRE2", _cliente.CLI_ANOMBRE2, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_APATERNO", _cliente.cli_apaterno, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_AMATERNO", _cliente.cli_amaterno, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_AFECHANACIMIENTO", _cliente.cli_afechanacimiento, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ARUT", IIf(_cliente.cli_arut.Trim = "", 0, _cliente.cli_arut), SqlDbType.Int)
        vlSqlParam.Add("@CLI_ADV", _cliente.cli_adv, SqlDbType.Char)
        vlSqlParam.Add("@CLI_ASEXO", IIf(_cliente.cli_asexo = "", "", _cliente.cli_asexo), SqlDbType.Char)
        vlSqlParam.Add("@CLI_AEMAIL", _cliente.cli_aemail, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_PLAN", _cliente.cli_plan, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_TPOCONTRATO", IIf(Trim(_cliente.cli_tpocontrato) = "", 0, (_cliente.cli_tpocontrato)), SqlDbType.Int)
        vlSqlParam.Add("@CLI_PRIMAUF", _cliente.cli_primauf, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_PRIMAPESOS", _cliente.cli_primapesos, SqlDbType.Int)
        vlSqlParam.Add("@CLI_ACALLE", _cliente.cli_acalle, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ANRO", _cliente.cli_anro, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_AREFERENCIA", _cliente.CLI_AREFERENCIA, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ACOMUNA", _cliente.cli_acomuna, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ACOD_COMUNA", _cliente.CLI_ACODCOMUNA, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ACIUDAD", _cliente.cli_aciudad, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ACOD_CIUDAD", _cliente.CLI_ACODCIUDAD, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_AAREAFONOVTA", _cliente.cli_aareafonovta, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_AFONOVTA", _cliente.cli_afonovta, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ACELULAR", _cliente.cli_acelular, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_MOTIVONOINTERESA", _cliente.cli_mtvo_nocontrata, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_AOBSMTVO_NOINTERESA", _cliente.cli_aobsmtvo_nointeresa, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_VENTA", _cliente.cli_venta, SqlDbType.Int)
        vlSqlParam.Add("@CLI_CODVERIFICACION", _cliente.cli_codverificacion, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_MEDIOPAGO", _cliente.CLI_AMEDIO_PAGO, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ABANCO", IIf(Trim(_cliente.CLI_ABANCO) = "", 0, (_cliente.CLI_ABANCO)), SqlDbType.VarChar)
        vlSqlParam.Add("@cli_anrotarjeta", IIf(Trim(_cliente.cli_anrotarjeta) = "", 0, (_cliente.cli_anrotarjeta)), SqlDbType.VarChar)
        'vlSqlParam.Add("@CLI_ATARJETAVENCIMIENTO", IIf(Trim(_cliente.cli_AAVTO_TARJ) = "", 0, (_cliente.cli_AAVTO_TARJ)), SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ADIAPAGO", IIf(Trim(_cliente.CLI_DIACARGO) = "", 0, (_cliente.CLI_DIACARGO)), SqlDbType.VarChar)



        tipoConexion = 2
        con.Ejecutar(query, vlSqlParam, tipoConexion)

        vlSqlParam.Clear()

    End Sub

    '********* Guarda los datos obtenidos de la venta en la tabla log ***************
    Public Sub GuardaDatosLog(ByVal _claveRegistroActual As String)
        vlSqlParam.Clear()
        query = "[GestionVenta].SP_" + nomcampania + "_LOG"
        vlSqlParam.Add("@id", _claveRegistroActual, SqlDbType.Int)
        vlSqlParam.Add("@fecha_ter_gestion", DateTime.Now.ToString("yyyyMMdd"), SqlDbType.VarChar)
        vlSqlParam.Add("@hora_ter_gestion", DateTime.Now.ToString("HHmmss"), SqlDbType.VarChar)
        tipoConexion = 2
        con.Ejecutar(query, vlSqlParam, tipoConexion)
        vlSqlParam.Clear()

    End Sub
    '********* Obtiene los datos del cliente para la venta***************
    Public Function BuscarCliente(ByVal WS_IDUSUARIO As String) As DataTable
        Dim clgen As New clsGeneralDA
        Dim Fecha As String = ""
        Dim Tabla As New DataTable
        vlSqlParam.Clear()

        Fecha = clgen.FechaServidor.ToString("yyyyMMdd")
        query = "config.SP_VALIDA_LOGUEO"
        vlSqlParam.Add("@FECHA", Fecha, SqlDbType.VarChar)
        vlSqlParam.Add("@USUARIO", WS_IDUSUARIO, SqlDbType.VarChar)
        tipoConexion = 2
        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        If Tabla.Rows.Count > 0 Then
            If Tabla.Rows(0)("resultado") = 0 Then
                MsgBox("Usuario No se encuentra Logueado HOY, Favor Intentelo Nuevamente", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CALLSOUTH")
                Return Tabla
            End If
        End If

        Tabla.Clear()
        vlSqlParam.Clear()
        query = "Config.SP_" + nomcampania + "_TCL"
        vlSqlParam.Add("@Agente", WS_IDUSUARIO, SqlDbType.VarChar)
        tipoConexion = 2
        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        If Tabla.Rows.Count <= 0 Then
            MsgBox("No hay registros por recorrer", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CALLSOUTH")
            Return Tabla
        ElseIf Tabla.Rows(0)("CLI_ID") = 0 Then
            MsgBox("No hay registros por recorrer", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CALLSOUTH")
            Return Tabla
        End If

        vlSqlParam.Clear()
        Return Tabla
    End Function

    '*********METODO PARA OBTENER CLIENTE PARA REGRABACION*******************
    Public Function GesCliente(ByVal id As Integer) As eCliente
        Dim dt As New DataTable
        Dim xt As New eCliente

        vlSqlParam.Clear()
        query = "[GestionReGrabacion].[Traer_cliente_VentaR]"
        vlSqlParam.Add("@id", id, SqlDbType.Int)
        tipoConexion = 2
        dt = con.TraeDatosConP(vlSqlParam, query, tipoConexion)
        xt.cli_id = IIf(IsDBNull(dt.Rows(0)("CLI_ID")), Nothing, dt.Rows(0)("CLI_ID"))
        xt.cli_anombre = IIf(IsDBNull(dt.Rows(0)("CLI_ANOMBRE")), Nothing, dt.Rows(0)("CLI_ANOMBRE"))
        xt.cli_nombre2 = IIf(IsDBNull(dt.Rows(0)("CLI_ANOMBRE2")), Nothing, dt.Rows(0)("CLI_ANOMBRE2"))
        xt.cli_apaterno = IIf(IsDBNull(dt.Rows(0)("CLI_APATERNO")), Nothing, dt.Rows(0)("CLI_APATERNO"))
        xt.cli_amaterno = IIf(IsDBNull(dt.Rows(0)("CLI_AMATERNO")), Nothing, dt.Rows(0)("CLI_AMATERNO"))
        xt.cli_telefono1 = IIf(IsDBNull(dt.Rows(0)("CLI_TELEFONO1")), Nothing, dt.Rows(0)("CLI_TELEFONO1"))
        xt.cli_telefono2 = IIf(IsDBNull(dt.Rows(0)("CLI_TELEFONO2")), Nothing, dt.Rows(0)("CLI_TELEFONO2"))
        xt.cli_telefono3 = IIf(IsDBNull(dt.Rows(0)("CLI_TELEFONO3")), Nothing, dt.Rows(0)("CLI_TELEFONO3"))
        xt.cli_telefono4 = IIf(IsDBNull(dt.Rows(0)("CLI_TELEFONO4")), Nothing, dt.Rows(0)("CLI_TELEFONO4"))
        xt.cli_telefono5 = IIf(IsDBNull(dt.Rows(0)("CLI_TELEFONO5")), Nothing, dt.Rows(0)("CLI_TELEFONO5"))
        xt.cli_telefono6 = IIf(IsDBNull(dt.Rows(0)("CLI_TELEFONO6")), Nothing, dt.Rows(0)("CLI_TELEFONO6"))
        xt.cli_telefonoalt = IIf(IsDBNull(dt.Rows(0)("CLI_TELEFONOALT")), Nothing, dt.Rows(0)("CLI_TELEFONOALT"))
        xt.cli_arut = IIf(IsDBNull(dt.Rows(0)("CLI_ARUT")), Nothing, dt.Rows(0)("CLI_ARUT"))
        xt.cli_adv = IIf(IsDBNull(dt.Rows(0)("CLI_ADV")), Nothing, dt.Rows(0)("CLI_ADV"))
        xt.cli_comuna = IIf(IsDBNull(dt.Rows(0)("CLI_ACOMUNA")), Nothing, dt.Rows(0)("CLI_ACOMUNA"))
        xt.CLI_CIUDAD = IIf(IsDBNull(dt.Rows(0)("CLI_ACIUDAD")), Nothing, dt.Rows(0)("CLI_ACIUDAD"))
        xt.cli_fechanacimiento = IIf(IsDBNull(dt.Rows(0)("CLI_AFECHANACIMIENTO")), Nothing, dt.Rows(0)("CLI_AFECHANACIMIENTO"))
        xt.cli_producto = IIf(IsDBNull(dt.Rows(0)("CLI_PRODUCTO")), Nothing, dt.Rows(0)("CLI_PRODUCTO"))
        xt.cli_asexo = IIf(IsDBNull(dt.Rows(0)("CLI_ASEXO")), Nothing, dt.Rows(0)("CLI_ASEXO"))
        xt.cli_codverificacion = IIf(IsDBNull(dt.Rows(0)("CLI_CODVERIFICACION")), Nothing, dt.Rows(0)("CLI_CODVERIFICACION"))
        xt.cli_acalle = IIf(IsDBNull(dt.Rows(0)("CLI_ACALLE")), Nothing, dt.Rows(0)("CLI_ACALLE"))
        xt.cli_anro = IIf(IsDBNull(dt.Rows(0)("CLI_ANRO")), Nothing, dt.Rows(0)("CLI_ANRO"))
        xt.CLI_AREFERENCIA = IIf(IsDBNull(dt.Rows(0)("CLI_AREFERENCIA")), Nothing, dt.Rows(0)("CLI_AREFERENCIA"))
        xt.CLI_AMEDIO_PAGO = IIf(IsDBNull(dt.Rows(0)("CLI_AMEDIO_PAGO")), Nothing, dt.Rows(0)("CLI_AMEDIO_PAGO"))
        xt.cli_anrotarjeta = IIf(IsDBNull(dt.Rows(0)("CLI_ANROTARJETA")), Nothing, dt.Rows(0)("CLI_ANROTARJETA"))
        xt.CLI_ABANCO = IIf(IsDBNull(dt.Rows(0)("CLI_ABANCO")), Nothing, dt.Rows(0)("CLI_ABANCO"))
        'xt.CLI_ATARJETAVENCIMIENTO = IIf(IsDBNull(dt.Rows(0)("CLI_ATARJETAVENCIMIENTO")), Nothing, dt.Rows(0)("CLI_ATARJETAVENCIMIENTO"))
        xt.cli_primapesos = IIf(IsDBNull(dt.Rows(0)("CLI_PRIMAPESOS")), Nothing, dt.Rows(0)("CLI_PRIMAPESOS"))
        xt.cli_primauf = IIf(IsDBNull(dt.Rows(0)("CLI_PRIMAUF")), Nothing, dt.Rows(0)("CLI_PRIMAUF"))
        xt.cli_plan = IIf(IsDBNull(dt.Rows(0)("CLI_PLAN")), Nothing, dt.Rows(0)("CLI_PLAN"))
        xt.cli_tpocontrato = IIf(IsDBNull(dt.Rows(0)("CLI_TPOCONTRATO")), Nothing, dt.Rows(0)("CLI_TPOCONTRATO"))
        xt.cli_email = IIf(IsDBNull(dt.Rows(0)("CLI_AEMAIL")), Nothing, dt.Rows(0)("CLI_AEMAIL"))
        xt.CLI_ACEPTA_CORREO = IIf(IsDBNull(dt.Rows(0)("CLI_ACEPTA_CORREO")), Nothing, dt.Rows(0)("CLI_ACEPTA_CORREO"))
        xt.cli_acelular = IIf(IsDBNull(dt.Rows(0)("CLI_ACELULAR")), Nothing, dt.Rows(0)("CLI_ACELULAR"))
        xt.cli_afonovta = IIf(IsDBNull(dt.Rows(0)("CLI_AFONOVTA")), Nothing, dt.Rows(0)("CLI_AFONOVTA"))
        xt.cli_acod_comuna = IIf(IsDBNull(dt.Rows(0)("CLI_ACOD_COMUNA")), Nothing, dt.Rows(0)("CLI_ACOD_COMUNA"))
        xt.cli_intentos_max = IIf(IsDBNull(dt.Rows(0)("CLI_INTENTOS_MAX")), Nothing, dt.Rows(0)("CLI_INTENTOS_MAX"))
        xt.cli_intentos = IIf(IsDBNull(dt.Rows(0)("CLI_INTENTOS")), Nothing, dt.Rows(0)("CLI_INTENTOS"))
        xt.CLI_PRIMER_MOT_CALIDAD = IIf(IsDBNull(dt.Rows(0)("CLI_PRIMER_MOTIVO_CALIDAD")), Nothing, dt.Rows(0)("CLI_PRIMER_MOTIVO_CALIDAD"))
        xt.CLI_PRIMER_MOT_SUBCALIDAD = IIf(IsDBNull(dt.Rows(0)("CLI_PRIMER_SUBMOTIVO_CALIDAD")), Nothing, dt.Rows(0)("CLI_PRIMER_SUBMOTIVO_CALIDAD"))
        'xt.CLI_NUMTARJETA_1 = IIf(IsDBNull(dt.Rows(0)("CLI_NUMTARJETA_1")), Nothing, dt.Rows(0)("CLI_NUMTARJETA_1"))
        'xt.CLI_NUMERO_CTACTE = IIf(IsDBNull(dt.Rows(0)("CLI_NUMERO_CTACTE")), Nothing, dt.Rows(0)("CLI_NUMERO_CTACTE"))
        'xt.cli_prima_precio = IIf(IsDBNull(dt.Rows(0)("CLI_PRIMA_PRECIO")), Nothing, dt.Rows(0)("CLI_PRIMA_PRECIO"))
        'xt.cli_prima_periodo = IIf(IsDBNull(dt.Rows(0)("CLI_PRIMA_PERIODO")), Nothing, dt.Rows(0)("CLI_PRIMA_PERIODO"))
        'xt.cli_agen_obs = IIf(IsDBNull(dt.Rows(0)("CLI_OBSERVACION")), Nothing, dt.Rows(0)("CLI_OBSERVACION"))
        xt.CLI_AFONOCONTACTO = IIf(IsDBNull(dt.Rows(0)("CLI_AFONOCONTACTO")), Nothing, dt.Rows(0)("CLI_AFONOCONTACTO"))


        Return xt
    End Function

End Class
