Imports Entidad

Public Class clsGeneralDA
    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim Tabla As New DataTable
    '*********METODO PARA OBTENER LA FECHA DEL SERVIDOR*******************
    Function FechaServidor() As DateTime
        Dim fecha As DateTime
        fecha = Nothing
        tipoConexion = 1

            query = "[dbo].[Fecha_Servidor]"
        Tabla = con.TraeDatosSinP(query, tipoConexion)

            For Each row As DataRow In Tabla.Rows
                fecha = row.Item(0)
            Next

            Return fecha
    End Function
    '*********METODO PARA GUARDAR LLAMADA EN LA TABLA CID*******************
    Public Sub Insertar_Grabacion(ByVal _grabacion As eCid, ByVal tipo As UShort)
        vlSqlParam.Clear()

        query = "[Config].[Registrar_Call_Id]"
        tipoConexion = 2
        vlSqlParam.Add("@tipo", tipo, SqlDbType.Int)
        vlSqlParam.Add("@CAL_ID", _grabacion.CLI_ID, SqlDbType.BigInt)
        vlSqlParam.Add("@CAL_CALLID", _grabacion.CLI_CALL_ID, SqlDbType.VarChar)
        vlSqlParam.Add("@CAL_FONO", _grabacion.CLI_Fono, SqlDbType.VarChar)
        vlSqlParam.Add("@CAL_FECHA", _grabacion.CLI_Fecha, SqlDbType.VarChar)
        vlSqlParam.Add("@CAL_INICIO", _grabacion.CLI_Inicio, SqlDbType.VarChar)
        vlSqlParam.Add("@CAL_TERMINO", _grabacion.Cli_Termino, SqlDbType.VarChar)
        vlSqlParam.Add("@CAL_AGENTE", _grabacion.CLI_Agente, SqlDbType.VarChar)

        con.Ejecutar(query, vlSqlParam, tipoConexion)
        vlSqlParam.Clear()
    End Sub
    '*********METODO PARA GUARDAR LLAMADA EN LA TABLA LOGUEO_USUARIO*******************
    Public Sub Logear_Usuario(ByRef Usuario As String, ByRef estado As Short)

        vlSqlParam.Clear()
            Tabla.Clear()
        tipoConexion = 2

        query = "config.sp_" + nomcampania + "_LogeoUsuario"
            vlSqlParam.Add("@USUARIO", Usuario, SqlDbType.VarChar)
            vlSqlParam.Add("@ESTLOG", estado, SqlDbType.Int)
        con.Ejecutar(query, vlSqlParam, tipoConexion)

            vlSqlParam.Clear()
    End Sub
    '*********METODO PARA TRAER LOS PARENTESCOS*******************
    Function Listar_Parentesco() As DataTable
        Tabla.Clear()
        tipoConexion = 1
            query = "[dbo].[pa_ListarParentesco]"
        Tabla = con.TraeDatosSinP(query, tipoConexion)
            Return Tabla
    End Function
    '*********METODO PARA TRAER LOS PARENTESCOS PARA LOS BENEFICIARIOS*******************
    Function Listar_ParentescoBen() As DataTable

        Tabla.Clear()

        tipoConexion = 1
        query = "[dbo].[pa_ListarParentescoBen]"
        Tabla = con.TraeDatosSinP(query, tipoConexion)

        Return Tabla
    End Function

    '*********METODO PARA ACTUALIZAR ESTADO DE CLI_ESTADO DE LA TABLA CLI EN CASO DE QUE SE PRESIONE BOTON SALIR*******************
    Public Sub Respaldar_Estado(ByVal estado As String, ByVal id As UInteger)
        vlSqlParam.Clear()

        tipoConexion = 2
        vlSqlParam.Add("@estado", estado, SqlDbType.VarChar)
        vlSqlParam.Add("id", id, SqlDbType.BigInt)
        query = "[Config].[Respaldar_estado_anterior]"
        con.Ejecutar(query, vlSqlParam, tipoConexion)
        vlSqlParam.Clear()
    End Sub
    '*********METODO PARA BUSCAR VALOR UF*******************
    Public Function Busca_ValorUF() As String
        Dim s As String
        s = ""
        vlSqlParam.Clear()
        Tabla.Clear()
        query = "dbo.pa_Busca_ValorUF "
        tipoConexion = 1
        Tabla = con.TraeDatosSinP(query, tipoConexion)

        If Tabla.Rows.Count > 0 Then
            s = Tabla.Rows(0)("UF")
        End If

        Return s
    End Function

End Class
