Imports Entidad

Public Class clsConfiguracionCampaniaDA

    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim dt As New DataTable

    Public Function ObtenerConfiguracionCampania(ByRef _centroCosto As String) As eCampania

        tipoConexion = 1
        vlSqlParam.Clear()
        query = "[Calidad].[ConfiguracionCampania]"
        vlSqlParam.Add("@centroCosto", _centroCosto, SqlDbType.VarChar)

        dt = con.TraeDatosConP(vlSqlParam, query, tipoConexion)
        Dim row As New eCampania
        For x As Int16 = 0 To dt.Rows.Count - 1

            row.IslaID = IIf(dt.Rows(x)("IslaID") Is DBNull.Value, Nothing, dt.Rows(x)("IslaID"))
            row.IslaServidor = IIf(dt.Rows(x)("IslaServidor") Is DBNull.Value, Nothing, dt.Rows(x)("IslaServidor"))
            row.rutaWebService = IIf(dt.Rows(x)("rutaWebService") Is DBNull.Value, Nothing, dt.Rows(x)("rutaWebService"))
            row.calCentroCosto = IIf(dt.Rows(x)("calCentroCosto") Is DBNull.Value, Nothing, dt.Rows(x)("calCentroCosto"))
            row.calIdCampanaNeo = IIf(dt.Rows(x)("calIdCampanaNeo") Is DBNull.Value, Nothing, dt.Rows(x)("calIdCampanaNeo"))
            row.calCodigo = IIf(dt.Rows(x)("calCodigo") Is DBNull.Value, Nothing, dt.Rows(x)("calCodigo"))
            row.calServidorBDD = IIf(dt.Rows(x)("calServidorBDD") Is DBNull.Value, Nothing, dt.Rows(x)("calServidorBDD"))
            row.calIntentosMaximos = IIf(dt.Rows(x)("calIntentosMaximos") Is DBNull.Value, Nothing, dt.Rows(x)("calIntentosMaximos"))
            row.calBDD = IIf(dt.Rows(x)("calBDD") Is DBNull.Value, Nothing, dt.Rows(x)("calBDD"))
            row.calNombre = IIf(dt.Rows(x)("calNombre") Is DBNull.Value, Nothing, dt.Rows(x)("calNombre"))
            row.rutaWebServiceRegrabacion = IIf(dt.Rows(x)("rutaWebServiceRegrabacion") Is DBNull.Value, Nothing, dt.Rows(x)("rutaWebServiceRegrabacion"))
            row.espCodigo = IIf(dt.Rows(x)("espCodigo") Is DBNull.Value, Nothing, dt.Rows(x)("espCodigo"))
            row.IdCampanaNeoRegrabacion = IIf(dt.Rows(x)("IdCampanaNeoRegrabacion") Is DBNull.Value, Nothing, dt.Rows(x)("IdCampanaNeoRegrabacion"))

        Next

        vlSqlParam.Clear()
        Return row

    End Function

End Class

