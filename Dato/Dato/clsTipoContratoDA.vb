Imports System.Collections.Generic
Imports Entidad

Public Class clsTipoContratoDA
    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim Tabla As New DataTable

    '**************METODO PARA LISTAR LOS PLANES POR CAMPAÑA**********************
    Public Function ListaTipoContratoPorCampania(ByVal _calCodigo As Int32) As List(Of eTipoContrato)
        Dim listTipoContrato As New List(Of eTipoContrato)
        vlSqlParam.Clear()
        Tabla.Clear()

        tipoConexion = 1
        query = "dbo.pa_ListaTipoContratoPorCampania2"
        vlSqlParam.Add("@calcodigo", _calCodigo, SqlDbType.Int)

        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        For x As Int16 = 0 To Tabla.Rows.Count - 1
            Dim row As New eTipoContrato
            row.idTipoContrato = IIf(IsDBNull(Tabla.Rows(x)("idTipoContrato")), Nothing, Tabla.Rows(x)("idTipoContrato"))
            row.nombreTipoContrato = IIf(IsDBNull(Tabla.Rows(x)("nombreTipoContrato")), Nothing, Tabla.Rows(x)("nombreTipoContrato"))
            listTipoContrato.Add(row)
        Next

        Return listTipoContrato

    End Function

    '**************METODO PARA BUSCAR LOS TIPOS DE CONTRATO POR ID DE CONTARTO***********************
    Public Function BuscarTipoContratoPorIdTipoContrato(ByVal _idTipoContrato As Int16) As eTipoContrato
        Dim row As New eTipoContrato
        vlSqlParam.Clear()
        Tabla.Clear()

        tipoConexion = 1
        query = "dbo.pa_BuscarTipoContratoPorIdTipoContrato"
        vlSqlParam.Add("@idTipoContrato", _idTipoContrato, SqlDbType.TinyInt)

        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        For x As Int16 = 0 To Tabla.Rows.Count - 1

            row.idTipoContrato = IIf(IsDBNull(Tabla.Rows(x)("idTipoContrato")), Nothing, Tabla.Rows(x)("idTipoContrato"))
            row.nombreTipoContrato = IIf(IsDBNull(Tabla.Rows(x)("nombreTipoContrato")), Nothing, Tabla.Rows(x)("nombreTipoContrato"))
            row.cantidadAdicionales = IIf(IsDBNull(Tabla.Rows(x)("cantidadAdicionales")), Nothing, Tabla.Rows(x)("cantidadAdicionales"))
            row.cantidadBeneficiarios = IIf(IsDBNull(Tabla.Rows(x)("cantidadBeneficiarios")), Nothing, Tabla.Rows(x)("cantidadBeneficiarios"))
            row.definido = IIf(IsDBNull(Tabla.Rows(x)("definido")), Nothing, Tabla.Rows(x)("definido"))

        Next

        Return row

    End Function

    '**************METODO PARA LISTAR LOS PLANES POR CAMPAÑA**********************
    Public Function ListaTipoContratoPosAdicionales(ByVal _calCodigo As Int32, ByVal _cantAdic As SByte) As List(Of eTipoContrato)
        Dim listTipoContrato As New List(Of eTipoContrato)
        vlSqlParam.Clear()
        Tabla.Clear()

        tipoConexion = 1
        query = "dbo.pa_ListaTipoContratoPosAdicionales"
        vlSqlParam.Add("@calcodigo", _calCodigo, SqlDbType.Int)
        vlSqlParam.Add("@CantAdicionales", _cantAdic, SqlDbType.Int)

        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        For x As Int16 = 0 To Tabla.Rows.Count - 1
            Dim row As New eTipoContrato
            row.idTipoContrato = IIf(IsDBNull(Tabla.Rows(x)("idTipoContrato")), Nothing, Tabla.Rows(x)("idTipoContrato"))
            row.nombreTipoContrato = IIf(IsDBNull(Tabla.Rows(x)("nombreTipoContrato")), Nothing, Tabla.Rows(x)("nombreTipoContrato"))
            listTipoContrato.Add(row)
        Next

        Return listTipoContrato

    End Function

End Class
