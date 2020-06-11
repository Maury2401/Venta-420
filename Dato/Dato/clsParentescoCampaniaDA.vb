Imports System.Collections.Generic
Imports Entidad

Public Class clsParentescoCampaniaDA
    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim dt As New DataTable

    Public Function BuscaParentescoPorId(ByVal _calCodigo As Int32, ByVal _tipoPersona As SByte) As List(Of eParentescoCampania)
        
        tipoConexion = 1
        vlSqlParam.Clear()
        query = "dbo.pa_BuscarParentescoPorId"
        vlSqlParam.Add("@calCodigo", _calCodigo, SqlDbType.Int)
        vlSqlParam.Add("@idTipoPersonaAgregado", _tipoPersona, SqlDbType.Int)

        dt = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        Dim listParentesco As New List(Of eParentescoCampania)

        For x As Int16 = 0 To dt.Rows.Count - 1
            Dim row As New eParentescoCampania
            row.idParentescoCampania = IIf(IsDBNull(dt.Rows(x)("idParentescoCampania")), Nothing, dt.Rows(x)("idParentescoCampania"))
            row.idParentesco = IIf(IsDBNull(dt.Rows(x)("idParentesco")), Nothing, dt.Rows(x)("idParentesco"))
            row.nombreParentesco = IIf(IsDBNull(dt.Rows(x)("nombreParentesco")), Nothing, dt.Rows(x)("nombreParentesco"))
            row.calCodigo = IIf(IsDBNull(dt.Rows(x)("calCodigo")), Nothing, dt.Rows(x)("calCodigo"))
            row.edadMin = IIf(IsDBNull(dt.Rows(x)("edadMin")), Nothing, dt.Rows(x)("edadMin"))
            row.edadMax = IIf(IsDBNull(dt.Rows(x)("edadMax")), Nothing, dt.Rows(x)("edadMax"))
            listParentesco.Add(row)
        Next

        vlSqlParam.Clear()
        Return listParentesco

    End Function
End Class
