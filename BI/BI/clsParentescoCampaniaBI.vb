Imports System.Collections.Generic
Imports Dato
Imports Entidad
Public Class clsParentescoCampaniaBI

    Public Function BuscarParentescoPorId(ByVal _calcodigo As Int16, ByVal _tipoPersona As SByte) As List(Of eParentescoCampania)
        Dim daParentescoCampania As New clsParentescoCampaniaDA
        Return daParentescoCampania.BuscaParentescoPorId(_calcodigo, _tipoPersona)
    End Function
End Class
