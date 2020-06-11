Imports System.Collections.Generic
Imports Dato
Imports Entidad

Public Class clsCampoAdicionalDA

    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim dt As New DataTable

    '********* Busca todos los campos adicionales de la campaña filtrada ***************
    Public Function BuscarCampoAdicionalPorCalCodigo(ByVal _Calcodigo As Int32) As List(Of eCampoAdicional)

        tipoConexion = 1
        vlSqlParam.Clear()
        query = "dbo.pa_BuscarCampoAdicionalPorCalCodigo"
        vlSqlParam.Add("@calCodigo", _Calcodigo, SqlDbType.Int)

        dt = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        Dim listCampoAdicional As New List(Of eCampoAdicional)

        For x As Int16 = 0 To dt.Rows.Count - 1
            Dim row As New eCampoAdicional

            row.idCampoAdicional = IIf(IsDBNull(dt.Rows(x)("idCampoAdicional")), Nothing, dt.Rows(x)("idCampoAdicional"))
            row.nombreCampoAdicional = IIf(IsDBNull(dt.Rows(x)("nombreCampoAdicional")), Nothing, dt.Rows(x)("nombreCampoAdicional"))
            row.valorCampo = IIf(IsDBNull(dt.Rows(x)("valorCampo")), Nothing, dt.Rows(x)("valorCampo"))
            row.calCodigo = IIf(IsDBNull(dt.Rows(x)("calCodigo")), Nothing, dt.Rows(x)("calCodigo"))
            row.fechaCreacion = IIf(IsDBNull(dt.Rows(x)("fechaCreacion")), Nothing, dt.Rows(x)("fechaCreacion"))
            row.orden = IIf(IsDBNull(dt.Rows(x)("orden")), Nothing, dt.Rows(x)("orden"))
            row.activo = IIf(IsDBNull(dt.Rows(x)("activo")), Nothing, dt.Rows(x)("activo"))

            listCampoAdicional.Add(row)
        Next

        vlSqlParam.Clear()

        Return listCampoAdicional

    End Function

    '********* BUSCA TODOS LOS DATOS CONFIGURADOS EN LA TABLA CAMPOADICIONAL ***************
    Public Function BuscaDatosCampoAdicional(ByVal _Calcodigo As Int32, ByVal _idCliente As Int32) As List(Of eCampoAdicional)

        tipoConexion = 1
        vlSqlParam.Clear()
        query = "dbo.pa_BuscaDatosCampoAdicional"
        vlSqlParam.Add("@calCodigo", _Calcodigo, SqlDbType.Int)
        vlSqlParam.Add("@idCliente", _idCliente, SqlDbType.Int)

        dt = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        Dim listCampoAdicional As New List(Of eCampoAdicional)

        For x As Int16 = 0 To dt.Rows.Count - 1
            Dim row As New eCampoAdicional

            row.nombreCampoAdicional = (IIf(IsDBNull(dt.Rows(x)("nombreCampo")), Nothing, dt.Rows(x)("nombreCampo")))
            row.valorCampo = (IIf(IsDBNull(dt.Rows(x)("camposTabla")), Nothing, dt.Rows(x)("camposTabla")))

            listCampoAdicional.Add(row)
        Next

        vlSqlParam.Clear()

        Return listCampoAdicional

    End Function


End Class
