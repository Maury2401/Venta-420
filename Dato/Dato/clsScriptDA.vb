Imports System.Collections.Generic
Imports Entidad

Public Class clsScriptDA
    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim dt As New DataTable

    '**********METODO PARA BUSCAR SCRIPT PARA VISUALIZAR EN UN WEB BROWSER****************
    Public Function BuscarScriptPorIdTipoScript(ByVal _calCodigo As Int32, ByVal _idTipoScript As Int32) As eScript

        Dim row As New eScript
        tipoConexion = 1
        vlSqlParam.Clear()
        query = "dbo.pa_BuscarScriptPorIdTipoScript"
        vlSqlParam.Add("@calCodigo", _calCodigo, SqlDbType.Int)
        vlSqlParam.Add("@idTipoScript", _idTipoScript, SqlDbType.Int)

        dt = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        For x As Int16 = 0 To dt.Rows.Count - 1

            row.idScripts = IIf(IsDBNull(dt.Rows(x)("idScript")), Nothing, dt.Rows(x)("idScript"))
            row.contenidoScript = IIf(IsDBNull(dt.Rows(x)("contenidoScript")), Nothing, dt.Rows(x)("contenidoScript"))
            row.idTipoScript = IIf(IsDBNull(dt.Rows(x)("idTipoScript")), Nothing, dt.Rows(x)("idTipoScript"))

        Next
        vlSqlParam.Clear()

        Return row

    End Function


End Class
