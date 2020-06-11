Imports Dato
Imports Entidad

Public Class clsConfiguracionCampaniaBI

    Public Function ObtenerConfiguracionCampania(ByRef _centroCosto As String) As eCampania
        Dim daConfiguracionCampania As New clsConfiguracionCampaniaDA
        Return daConfiguracionCampania.ObtenerConfiguracionCampania(_centroCosto)
    End Function

End Class
