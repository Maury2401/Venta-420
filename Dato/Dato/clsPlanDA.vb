Imports System.Collections.Generic
Imports Entidad

Public Class clsPlanDA
    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim Tabla As New DataTable

    '******************************METODO PARA BUSCRA LOS PLANES POR TIPO DE CONTRATO************
    Public Function BuscarPlanPorTipoContrato(ByVal _idTipoContrato As Int16, ByVal _calCodigo As Int32) As List(Of ePlan)
        Dim listTipoContrato As New List(Of ePlan)
        vlSqlParam.Clear()
        tipoConexion = 1
        query = "dbo.pa_BuscarPlanPorTipoContrato"
        vlSqlParam.Add("@idTipoContrato", _idTipoContrato, SqlDbType.TinyInt)
        vlSqlParam.Add("@calCodigo", _calCodigo, SqlDbType.Int)

        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        For x As Int16 = 0 To Tabla.Rows.Count - 1
            Dim row As New ePlan
            row.idPlan = IIf(IsDBNull(Tabla.Rows(x)("idPlan")), Nothing, Tabla.Rows(x)("idPlan"))
            row.primaUF = IIf(IsDBNull(Tabla.Rows(x)("primaUF")), Nothing, Tabla.Rows(x)("primaUF"))
            row.primaCalculada = IIf(IsDBNull(Tabla.Rows(x)("primaCalculada")), Nothing, Tabla.Rows(x)("primaCalculada"))
            row.idTipoContrato = IIf(IsDBNull(Tabla.Rows(x)("idTipoContrato")), Nothing, Tabla.Rows(x)("idTipoContrato"))
            row.descripcionPlan = IIf(IsDBNull(Tabla.Rows(x)("descripcionPlan")), Nothing, Tabla.Rows(x)("descripcionPlan"))
            row.calCodigo = IIf(IsDBNull(Tabla.Rows(x)("calCodigo")), Nothing, Tabla.Rows(x)("calCodigo"))
            row.activo = IIf(IsDBNull(Tabla.Rows(x)("activo")), Nothing, Tabla.Rows(x)("activo"))
            listTipoContrato.Add(row)
        Next
        Return listTipoContrato
    End Function


    '**********************METODO PARA BUSCAR LOS PLANES POR ID DE PLAN*****************************************
    Public Function BuscarPlanPorIdPlan(ByVal _idPlan As Int64) As ePlan
        Dim row As New ePlan
        Tabla.Clear()
        vlSqlParam.Clear()
        Tabla.Clear()
        query = "dbo.pa_BuscarPlanPorIdPlan"
        tipoConexion = 1
        vlSqlParam.Add("@idPlan", _idPlan, SqlDbType.SmallInt)

        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        For x As Int16 = 0 To Tabla.Rows.Count - 1

            row.idPlan = IIf(IsDBNull(Tabla.Rows(x)("idPlan")), Nothing, Tabla.Rows(x)("idPlan"))
            row.primaUF = IIf(IsDBNull(Tabla.Rows(x)("primaUF")), Nothing, Tabla.Rows(x)("primaUF"))
            row.primaCalculada = IIf(IsDBNull(Tabla.Rows(x)("primaCalculada")), Nothing, Tabla.Rows(x)("primaCalculada"))
            row.idTipoContrato = IIf(IsDBNull(Tabla.Rows(x)("idTipoContrato")), Nothing, Tabla.Rows(x)("idTipoContrato"))
            row.descripcionPlan = IIf(IsDBNull(Tabla.Rows(x)("descripcionPlan")), Nothing, Tabla.Rows(x)("descripcionPlan"))
            row.calCodigo = IIf(IsDBNull(Tabla.Rows(x)("calCodigo")), Nothing, Tabla.Rows(x)("calCodigo"))
            row.activo = IIf(IsDBNull(Tabla.Rows(x)("activo")), Nothing, Tabla.Rows(x)("activo"))
            'listTipoContrato.Add(row)
        Next
        Return row
    End Function
    '******************METODO PARA LISTAR LOS PLANES ADICIONALES*******************************
    Public Function ListaPlanAdicionales(ByVal _idTipoContrato As eTipoContrato, ByVal _calCodigo As Int32) As List(Of ePlan)
        Dim listPlanes As New List(Of ePlan)
        vlSqlParam.Clear()
        Tabla.Clear()

        tipoConexion = 1
        query = "dbo.pa_ListaPlanAdicionales"
        vlSqlParam.Add("@idTipoContrato", _idTipoContrato.idTipoContrato, SqlDbType.TinyInt)
        vlSqlParam.Add("@calCodigo", _calCodigo, SqlDbType.Int)

        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)
        For x As Int16 = 0 To Tabla.Rows.Count - 1
            Dim row As New ePlan

            row.idPlan = IIf(IsDBNull(Tabla.Rows(x)("idPlan")), Nothing, Tabla.Rows(x)("idPlan"))
            row.primaUF = IIf(IsDBNull(Tabla.Rows(x)("primaUF")), Nothing, Tabla.Rows(x)("primaUF"))
            row.primaCalculada = IIf(IsDBNull(Tabla.Rows(x)("primaCalculada")), Nothing, Tabla.Rows(x)("primaCalculada"))
            'row.idTipoContrato = IIf(IsDBNull(dt.Rows(x)("idTipoContrato")), Nothing, dt.Rows(x)("idTipoContrato"))
            'row.calCodigo = IIf(IsDBNull(dt.Rows(x)("calCodigo")), Nothing, dt.Rows(x)("calCodigo"))
            'row.activo = IIf(IsDBNull(dt.Rows(x)("activo")), Nothing, dt.Rows(x)("activo"))
            listPlanes.Add(row)
        Next

        Return listPlanes

    End Function
    '***************METODO PARA LISTAR  LOS PLANES DE BENEFICIARIOS********************************
    Public Function ListaPlanBeneficiario(ByVal _idTipoContrato As eTipoContrato, ByVal _calCodigo As Int32) As List(Of ePlan)
        Dim listPlanes As New List(Of ePlan)
        vlSqlParam.Clear()
        Tabla.Clear()

        tipoConexion = 1
        query = "dbo.pa_ListaPlanBeneficiario"
        vlSqlParam.Add("@idTipoContrato", _idTipoContrato.idTipoContrato, SqlDbType.TinyInt)
        vlSqlParam.Add("@calCodigo", _calCodigo, SqlDbType.Int)

        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        For x As Int16 = 0 To Tabla.Rows.Count - 1
            Dim row As New ePlan

            row.idPlan = IIf(IsDBNull(Tabla.Rows(x)("idPlan")), Nothing, Tabla.Rows(x)("idPlan"))
            row.primaUF = IIf(IsDBNull(Tabla.Rows(x)("primaUF")), Nothing, Tabla.Rows(x)("primaUF"))
            row.primaCalculada = IIf(IsDBNull(Tabla.Rows(x)("primaCalculada")), Nothing, Tabla.Rows(x)("primaCalculada"))
            'row.idTipoContrato = IIf(IsDBNull(Tabla.Rows(x)("idTipoContrato")), Nothing, dt.Rows(x)("idTipoContrato"))
            'row.calCodigo = IIf(IsDBNull(dt.Rows(x)("calCodigo")), Nothing, dt.Rows(x)("calCodigo"))
            'row.activo = IIf(IsDBNull(dt.Rows(x)("activo")), Nothing, dt.Rows(x)("activo"))
            listPlanes.Add(row)
        Next


        Return listPlanes

    End Function

End Class
