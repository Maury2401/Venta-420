Imports Entidad

Public Class clsGesRegrabacionDA
    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim dt As New DataTable
    '***********METODO PARA TRAER TODOS LOS DATOS DE LAS VENTAS A SER GESTIONADAS EN REGRABACIONES***************************
    ''' <summary>
    ''' METODO PARA TRAER TODOS LOS DATOS DE LAS VENTAS A SER GESTIONADAS EN REGRABACIONES
    ''' </summary>
    ''' <returns>Datatable</returns>
    ''' <remarks></remarks>
    Public Function Regrabaciones() As DataTable

        tipoConexion = 2
        query = "[dbo].[pa_ctrol_VentasRechazadas]"

        dt = con.TraeDatosSinP(query, tipoConexion)

        Return dt
    End Function
    
    ''' <summary>
    ''' Guarda datos en tabla GES_REGRABACIONES
    ''' </summary>
    ''' <param name="_ges">Entidad cliente  que se guardara</param>
    ''' <param name="_calcodigo_centro">Centro de costo de la campaña</param>
    ''' <remarks></remarks>

    Public Sub GuardaClienteGes(ByVal _ges As eCliente, ByVal _calcodigo_centro As Integer)

        vlSqlParam.Clear()
        query = "[GestionReGrabacion].[pa_" + nomcampania + "_InsertaGesRegrab]"
        vlSqlParam.Add("@CLI_ID", _ges.cli_id, SqlDbType.BigInt)
        vlSqlParam.Add("@CLI_CALL_ID_CALIDAD", IIf(_ges.CLI_CALL_ID_CALIDAD = Nothing, "", _ges.CLI_CALL_ID_CALIDAD), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_FECHAINGRESO", IIf(_ges.cli_fecha = Nothing, "", _ges.cli_fecha), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_HORAINGRESO", IIf(_ges.cli_hora = Nothing, "", _ges.cli_hora), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_AGEN_ESTADO", IIf(_ges.cli_agen_estado = Nothing, "", _ges.cli_agen_estado), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_AGEN_FECHA", IIf(_ges.cli_agen_fecha = Nothing, "", _ges.cli_agen_fecha), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_AGEN_HORA", IIf(_ges.cli_agen_hora = Nothing, "", _ges.cli_agen_hora), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_AGEN_OBS", IIf(_ges.cli_agen_obs = Nothing, "", _ges.cli_agen_obs), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_CONECTA", IIf(_ges.cli_conecta = Nothing, "", _ges.cli_conecta), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_NO_CONECTA", IIf(_ges.cli_no_conecta = Nothing, "", _ges.cli_no_conecta), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_COMUNICACON", IIf(_ges.cli_comunica_con = Nothing, "", _ges.cli_comunica_con), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_COMUNICA_TERCERO", IIf(_ges.cli_comunica_tercero = Nothing, "", _ges.cli_comunica_tercero), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_ACEPTA_CONTRATO", IIf(_ges.CLI_ACEPTA_CONTRATACION = Nothing, "", _ges.CLI_ACEPTA_CONTRATACION), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_ACEPTA_PRIMA", IIf(_ges.cli_acepta_prima = Nothing, "", _ges.cli_acepta_prima), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_MOTVNOINTERESA", IIf(_ges.cli_mtvo_nocontrata = Nothing, "", _ges.cli_mtvo_nocontrata), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_VENTA", IIf(_ges.cli_venta = Nothing, "", _ges.cli_venta), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_ESTADO", IIf(_ges.cli_estado = Nothing, "", _ges.cli_estado), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_FECHAVTA", IIf(_ges.cli_fechavta = Nothing, "", _ges.cli_fechavta), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_HORAVTA", IIf(_ges.cli_horavta = Nothing, "", _ges.cli_horavta), SqlDbType.VarChar)
        vlSqlParam.Add("@REG_AGENTE", _ges.cli_agente, SqlDbType.VarChar)
        vlSqlParam.Add("@REG_RECONOCEVTA", IIf(_ges.CLI_RECONOCEVTA = "Si", 1, 0), SqlDbType.Int)
        vlSqlParam.Add("@CALCODIGO", _calcodigo_centro, SqlDbType.Int)

        tipoConexion = 2
        con.Ejecutar(query, vlSqlParam, tipoConexion)

        'vlSqlParam.Add("@CLI_CODVERIFICACION", _cliente.cli_codverificacion, SqlDbType.VarChar)
        vlSqlParam.Clear()

    End Sub
    '************PROCEDIMIENTO PARA ACTUALIZAR LOS CAMPOS EN LA TABLA CLIENTE SIN VENTA  ************************
    ''' <summary>
    ''' PROCEDIMIENTO PARA ACTUALIZAR LOS CAMPOS EN LA TABLA CLIENTE SIN VENTA
    ''' </summary>
    ''' <param name="_seg_est"></param>
    ''' <param name="_est_obj"></param>
    ''' <param name="_call_id"></param>
    ''' <param name="_cli_id"></param>
    ''' <remarks></remarks>
    Public Sub ActualizaCteSinVta(ByVal _seg_est As String, ByVal _est_obj As String, ByVal _call_id As String, ByVal _cli_id As String)

        vlSqlParam.Clear()
        query = "[GestionReGrabacion].[ActualizaCteSinVta]"
        vlSqlParam.Add("@CLI_ID", _cli_id, SqlDbType.BigInt)
        vlSqlParam.Add("@CLI_SEGUNDO_ESTADO_CALIDAD", _seg_est, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_CALL_ID_CALIDAD", _call_id, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ESTADO_OBJECION_CALIDAD", _est_obj, SqlDbType.Int)

        tipoConexion = 2
        con.Ejecutar(query, vlSqlParam, tipoConexion)

        vlSqlParam.Clear()

    End Sub
    '************PROCEDIMIENTO PARA ACTUALIZAR LOS CAMPOS EN LA TABLA AsignacionCalidad  ************************
    Public Sub GrabaAsignaCalidad(ByVal _cliid As String, ByVal _calcodigo_centro As Integer, ByVal _agent As String, ByVal fecha As String, ByVal opcion As Integer, ByVal _agent_vta As String)

        vlSqlParam.Clear()
        query = "[dbo].[pa_Inserta_AsigCalidad_Rechaza]"
        vlSqlParam.Add("@cliid", _cliid, SqlDbType.BigInt)
        vlSqlParam.Add("@calCodigo", _calcodigo_centro, SqlDbType.Int)
        vlSqlParam.Add("@agente", _agent, SqlDbType.VarChar)
        vlSqlParam.Add("@fechavta", fecha, SqlDbType.VarChar)
        vlSqlParam.Add("@Opcion", opcion, SqlDbType.Int)
        vlSqlParam.Add("@Agente_Venta", _agent_vta, SqlDbType.VarChar)

        tipoConexion = 1
        con.Ejecutar(query, vlSqlParam, tipoConexion)

        vlSqlParam.Clear()

    End Sub
    '*********************METODO PARA ACTUALIZAR CLIENTE AGENDADO DE REGRABACIONES***********
    Public Sub ActualizaClienteAgen(ByVal _cliid As String, ByVal _est_obj As String, ByVal _call_id As String)

        vlSqlParam.Clear()
        query = "[GestionReGrabacion].[ActualizaClienteAgen]"
        vlSqlParam.Add("@cli_id ", _cliid, SqlDbType.BigInt)
        vlSqlParam.Add("@CLI_ESTADO_OBJECION_CALIDAD", _est_obj, SqlDbType.Int)
        vlSqlParam.Add("@CLI_CALL_ID_CALIDAD", _call_id, SqlDbType.VarChar)

        tipoConexion = 2
        con.Ejecutar(query, vlSqlParam, tipoConexion)

        vlSqlParam.Clear()

    End Sub
    '*********************METODO PARA ACTUALIZAR CLIENTE ACON VENTA EN REGRABACIONES***********
    Public Sub ActualizaClienteVenta(ByVal _ges As eCliente)

        vlSqlParam.Clear()
        query = "[GestionReGrabacion].[ActualizaClienteVentaGes]"
        vlSqlParam.Add("@CLI_ID", _ges.cli_id, SqlDbType.BigInt)
        vlSqlParam.Add("@CLI_ANOMBRE", _ges.cli_anombre, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ANOMBRE2", _ges.cli_anombre2, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_APATERNO", _ges.cli_apaterno, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_AMATERNO", _ges.cli_amaterno, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ARUT", _ges.cli_arut, SqlDbType.Int)
        vlSqlParam.Add("@CLI_ADV", _ges.cli_adv, SqlDbType.Char)
        vlSqlParam.Add("@CLI_AFECHANACIMIENTO", _ges.cli_afechanacimiento, SqlDbType.VarChar)
        'vlSqlParam.Add("@CLI_ACEPTA_CORREO", _ges.CLI_ACEPTA_CORREO, SqlDbType.VarChar)
        'vlSqlParam.Add("@CLI_ASEXO", _ges.cli_asexo, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ACALLE", _ges.cli_acalle, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ANRO", _ges.cli_anro, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_AREFERENCIA", _ges.CLI_AREFERENCIA, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ACOMUNA", _ges.cli_acomuna, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ACOD_COMUNA", _ges.cli_acod_comuna, SqlDbType.NChar)
        vlSqlParam.Add("@CLI_ACIUDAD", _ges.cli_aciudad, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ACOD_CIUDAD", _ges.cli_acod_ciudad, SqlDbType.NChar)
        vlSqlParam.Add("@CLI_AEMAIL", _ges.cli_aemail, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_AFONOCONTACTO", _ges.CLI_AFONOCONTACTO, SqlDbType.VarChar)
        'vlSqlParam.Add("@CLI_ACELULAR", _ges.cli_acelular, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_ESTADO_OBJECION_CALIDAD", _ges.CLI_ESTADO_OBJECION_CALIDAD, SqlDbType.Int)
        vlSqlParam.Add("@CLI_CALL_ID_CALIDAD", _ges.CLI_CALL_ID_CALIDAD, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_MEDIO_PAGO", _ges.CLI_AMEDIO_PAGO, SqlDbType.VarChar)

        vlSqlParam.Add("@CLI_PRIMAUF", _ges.cli_primauf, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_PRIMAPESOS", _ges.cli_primapesos, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_TPOCONTRATO", _ges.cli_tpocontrato, SqlDbType.VarChar)
        vlSqlParam.Add("@CLI_PLAN", _ges.cli_plan, SqlDbType.VarChar)

        tipoConexion = 2
        con.Ejecutar(query, vlSqlParam, tipoConexion)

        vlSqlParam.Clear()

    End Sub

End Class
