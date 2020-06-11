Imports Entidad
Imports Dato

Public Class clsMedioPagoBI


    Public Function BuscaDatosMedioPago(ByVal _calcodigo As Int32, ByVal _idCliente As Int32) As List(Of eMedioPago)
        Dim daMedioPago As New clsMedioPagoDA
        Return daMedioPago.BuscaDatosMedioPago(_calcodigo, _idCliente)
    End Function

    Public Function BuscaDatosMedioPagoPorId(ByVal _calcodigo As Int32, ByVal _idCliente As Int32, ByVal _idMedioPago As Int32) As eMedioPago
        Dim daMedioPago As New clsMedioPagoDA
        Return daMedioPago.BuscaDatosMedioPagoPorId(_calcodigo, _idCliente, _idMedioPago)
    End Function

    Public Function BuscaMedioPagoPorId(ByVal _idMedioPago As Int32) As eMedioPago
        Dim daMedioPago As New clsMedioPagoDA
        Return daMedioPago.BuscaMedioPagoPorId(_idMedioPago)
    End Function


End Class
