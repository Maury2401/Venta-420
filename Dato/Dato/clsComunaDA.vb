Imports System.Collections.Generic
Imports Entidad

Public Class clsComunaDA
    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim dt As New DataTable

    '****************Metodo para listar todas las comunas**********************************
    ''' <summary>
    ''' Metodo para listar todas las comunas
    ''' </summary>
    ''' <returns>List(Of clsComunaEnt)</returns>
    ''' <remarks></remarks>
    Public Function listarComuna() As List(Of eComuna)

        tipoConexion = 1
        vlSqlParam.Clear()
        query = "dbo.pa_ListaComunas"

        dt = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        Dim listComunas As New List(Of eComuna)

        For x As Int16 = 0 To dt.Rows.Count - 1
            Dim row As New eComuna

            row.idComuna = IIf(IsDBNull(dt.Rows(x)("idComuna")), Nothing, dt.Rows(x)("idComuna"))
            row.nombreComuna = IIf(IsDBNull(dt.Rows(x)("nombreComuna")), Nothing, dt.Rows(x)("nombreComuna"))
            row.idCiudad = IIf(IsDBNull(dt.Rows(x)("idCiudad")), Nothing, dt.Rows(x)("idCiudad"))
            listComunas.Add(row)
        Next

        vlSqlParam.Clear()
        Return listComunas

    End Function

End Class
