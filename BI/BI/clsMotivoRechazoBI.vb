Imports Dato
Imports Entidad

Public Class clsMotivoRechazoBI


    Public Function BuscarMotivoRechazoPorSponsor(ByVal campania As eCampania) As List(Of eMotivoRechazo)
        Dim daMotivoRechazo As New clsMotivoRechazoDA
        Return daMotivoRechazo.BuscarMotivoRechazoPorSponsor(campania)
    End Function

    Public Function BuscaMotivoRechazoCampaniaPorId(ByVal _idMotivoRechazo As Int32) As eMotivoRechazoCampania
        Dim daMotivoRechazo As New clsMotivoRechazoDA
        Return daMotivoRechazo.BuscaMotivoRechazoCampaniaPorId(_idMotivoRechazo)
    End Function

End Class
