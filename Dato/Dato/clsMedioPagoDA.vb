Imports System.Collections.Generic
Imports Dato
Imports Entidad

Public Class clsMedioPagoDA

    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim dt As New DataTable


    '********* BUSCA TODOS LOS DATOS CONFIGURADOS EN LA TABLA CAMPOADICIONAL ***************
    Public Function BuscaDatosMedioPago(ByVal _calcodigo As Int32, ByVal _idCliente As Int32) As List(Of eMedioPago)

        tipoConexion = 1
        vlSqlParam.Clear()
        query = "dbo.pa_BuscaDatosMedioPago"
        vlSqlParam.Add("@calCodigo", _calcodigo, SqlDbType.Int)
        vlSqlParam.Add("@idCliente", _idCliente, SqlDbType.Int)

        dt = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        Dim listMedioPago As New List(Of eMedioPago)

        For x As Int16 = 0 To dt.Rows.Count - 1
            Dim row As New eMedioPago

            row.idMedioPago = (IIf(IsDBNull(dt.Rows(x)("idMedioPago")), Nothing, dt.Rows(x)("idMedioPago")))
            row.nombreMedioPago = (IIf(IsDBNull(dt.Rows(x)("nombreMedioPago")), Nothing, dt.Rows(x)("nombreMedioPago")))
            row.numeroTarjeta = (IIf(IsDBNull(dt.Rows(x)("numeroTarjeta")), Nothing, dt.Rows(x)("numeroTarjeta")))
            row.otroMedioPago = (IIf(IsDBNull(dt.Rows(x)("otroMedioPago")), Nothing, dt.Rows(x)("otroMedioPago")))

            listMedioPago.Add(row)
        Next

        vlSqlParam.Clear()

        Return listMedioPago

    End Function


    '********* BUSCA TODOS LOS DATOS CONFIGURADOS EN LA TABLA CAMPOADICIONAL ***************
    Public Function BuscaDatosMedioPagoPorId(ByVal _calcodigo As Int32, ByVal _idCliente As Int32, ByVal _idMedioPago As Int32) As eMedioPago

        tipoConexion = 1
        vlSqlParam.Clear()
        query = "dbo.pa_BuscaDatosMedioPagoPorId"
        vlSqlParam.Add("@calCodigo", _calcodigo, SqlDbType.Int)
        vlSqlParam.Add("@idCliente", _idCliente, SqlDbType.Int)
        vlSqlParam.Add("@idMedioPago", _idMedioPago, SqlDbType.BigInt)

        dt = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        Dim row As New eMedioPago

        For x As Int16 = 0 To dt.Rows.Count - 1

            row.nombreMedioPago = (IIf(IsDBNull(dt.Rows(x)("nombreMedioPago")), Nothing, dt.Rows(x)("nombreMedioPago")))
            row.numeroTarjeta = (IIf(IsDBNull(dt.Rows(x)("numeroTarjeta")), Nothing, dt.Rows(x)("numeroTarjeta")))
            row.otroMedioPago = (IIf(IsDBNull(dt.Rows(x)("otroMedioPago")), Nothing, dt.Rows(x)("otroMedioPago")))

        Next

        vlSqlParam.Clear()

        Return row

    End Function


    '********* BUSCA TODOS LOS DATOS CONFIGURADOS EN LA TABLA CAMPOADICIONAL ***************
    Public Function BuscaMedioPagoPorId(ByVal _idCliente As Int32) As eMedioPago

        tipoConexion = 1
        vlSqlParam.Clear()
        query = "dbo.pa_BuscaMedioPagoPorId"
        vlSqlParam.Add("@idMedioPago", _idCliente, SqlDbType.Int)

        dt = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        Dim row As New eMedioPago
        For x As Int16 = 0 To dt.Rows.Count - 1

            row.idMedioPago = (IIf(IsDBNull(dt.Rows(x)("idMedioPago")), Nothing, dt.Rows(x)("idMedioPago")))
            row.nombreMedioPago = (IIf(IsDBNull(dt.Rows(x)("nombreMedioPago")), Nothing, dt.Rows(x)("nombreMedioPago")))
            row.numeroTarjeta = (IIf(IsDBNull(dt.Rows(x)("numeroTarjeta")), Nothing, dt.Rows(x)("numeroTarjeta")))
            row.otroMedioPago = (IIf(IsDBNull(dt.Rows(x)("otroMedioPago")), Nothing, dt.Rows(x)("otroMedioPago")))

        Next

        vlSqlParam.Clear()

        Return row

    End Function


End Class
