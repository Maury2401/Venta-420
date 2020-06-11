Imports System.Collections.Generic
Imports Entidad

Public Class clsMotivoRechazoDA

    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim Tabla As New DataTable

    Public Function BuscarMotivoRechazoPorSponsor(ByVal _campania As eCampania) As List(Of eMotivoRechazo)
        vlSqlParam.Clear()
        Tabla.Clear()

        tipoConexion = 1
        query = "[dbo].[pa_BuscarMotivoRechazoPorSponsor]"
        vlSqlParam.Add("@centroCosto", _campania.calCentroCosto, SqlDbType.Int)

        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)
        Dim ListData As New List(Of eMotivoRechazo)
        For x As Int16 = 0 To Tabla.Rows.Count - 1
            Dim row As New eMotivoRechazo
            row.idMotivoRechazo = IIf(IsDBNull(Tabla.Rows(x)("idMotivoRechazo")), Nothing, Tabla.Rows(x)("idMotivoRechazo"))
            row.descripcionMotivoRechazo = IIf(IsDBNull(Tabla.Rows(x)("nombreRechazo")), Nothing, Tabla.Rows(x)("nombreRechazo"))
            ListData.Add(row)
        Next

        Return ListData

    End Function


    Public Function BuscaMotivoRechazoCampaniaPorId(ByVal _idMotivoRechazo As Int32) As eMotivoRechazoCampania
        vlSqlParam.Clear()
        Tabla.Clear()

        tipoConexion = 1
        query = "Config.[pa_BuscaMotivoRechazoCampaniaPorId]"
        vlSqlParam.Add("@idMotivoRechazoCampania", _idMotivoRechazo, SqlDbType.Int)

        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)
        'Dim ListData As New List(Of eMotivoRechazoCampania)
        Dim row As New eMotivoRechazoCampania
        For x As Int16 = 0 To Tabla.Rows.Count - 1

            row.idMotivoRechazoCampania = IIf(IsDBNull(Tabla.Rows(x)("idMotivoRechazoCampania")), Nothing, Tabla.Rows(x)("idMotivoRechazoCampania"))
            row.idMotivoRechazo = IIf(IsDBNull(Tabla.Rows(x)("idMotivoRechazo")), Nothing, Tabla.Rows(x)("idMotivoRechazo"))
            row.espCodigo = IIf(IsDBNull(Tabla.Rows(x)("espCodigo")), Nothing, Tabla.Rows(x)("espCodigo"))
            row.calcodigo = IIf(IsDBNull(Tabla.Rows(x)("calcodigo")), Nothing, Tabla.Rows(x)("calcodigo"))
            row.otro = IIf(IsDBNull(Tabla.Rows(x)("otro")), Nothing, Tabla.Rows(x)("otro"))
            'ListData.Add(row)
        Next

        Return row

    End Function

End Class
