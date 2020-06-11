Imports Dato
Imports Entidad

Public Class clsClienteBI
    Dim daCliente As New clsClienteDA
    '********* Guarda los datos obtenidos de la venta ***************
    Public Sub GuardaDatosCliente(ByVal _cliente As eCliente)
        daCliente.GuardaDatosCliente(_cliente)
    End Sub

    '********* Guarda los datos obtenidos de la venta en la tabla log ***************
    Public Sub GuardaDatosLog(ByVal _claveRegistroActual As String)
        daCliente.GuardaDatosLog(_claveRegistroActual)
    End Sub
    '********* Trae los datos del cliente ***************
    Public Function Buscar_cliente(ByVal user As String) As DataTable
        Return daCliente.BuscarCliente(user)
    End Function
    '********* Trae los datos del cliente para regrabacion ***************
    Public Function Buscar_Gescliente(ByVal id As Integer) As eCliente
        Return daCliente.GesCliente(id)
    End Function


End Class
