Imports Entidad
Imports Dato

Public Class clsAdicionalBI

    Dim clsAdic As New clsAdicionalDA

    Public Sub Insertar(ByVal adicional As eAdicional)
        clsAdic.Insertar(adicional)
    End Sub

    Public Function Verificar(ByVal _id As String, ByVal _rut As String) As Boolean
        clsAdic.Verificar(_id, _rut)
    End Function

    Public Function Carga_Adicional(ByVal _rut As String, ByVal _id As String) As List(Of eAdicional)
        Return clsAdic.Carga_Adicional(_rut, _id)
    End Function

    Public Sub Eliminar(ByVal _cli As String, ByVal _rut As String)
        clsAdic.Eliminar(_cli, _rut)
    End Sub

End Class
