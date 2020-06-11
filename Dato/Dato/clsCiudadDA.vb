Imports System.Collections.Generic
Imports Entidad
Public Class clsCiudadDA
    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim dt As New DataTable


    ''' <summary>
    ''' Obtiene una ciudad filtrado por idCiudad
    ''' </summary>
    ''' <param name="_idCiudad"></param>
    ''' <returns>Entidad ciudad</returns>
    ''' <remarks></remarks>
    Public Function BuscaCiudadPorIdCiudad(ByVal _idCiudad As Int32) As eCiudad
        Dim lstCiudadEnt As New List(Of eCiudad)

        tipoConexion = 1
        vlSqlParam.Clear()
        query = "dbo.pa_BuscaCiudadPorIdCiudad"
        vlSqlParam.Add("@idCiudad", _idCiudad, SqlDbType.Int)

        dt = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        Dim listComunas As New List(Of eCiudad)
        Dim row As New eCiudad
        For x As Int16 = 0 To dt.Rows.Count - 1

            row.idCiudad = IIf(IsDBNull(dt.Rows(x)("idCiudad")), Nothing, dt.Rows(x)("idCiudad"))
            row.idRegion = IIf(IsDBNull(dt.Rows(x)("idRegion")), Nothing, dt.Rows(x)("idRegion"))
            row.nombreCiudad = IIf(IsDBNull(dt.Rows(x)("nombreCiudad")), Nothing, dt.Rows(x)("nombreCiudad"))
        Next

        vlSqlParam.Clear()
        Return row

    End Function

    Public Function ListaCiudad() As List(Of eCiudad)
        Dim lstCiudadEnt As New List(Of eCiudad)

        tipoConexion = 1
        vlSqlParam.Clear()
        query = "Entidad.pa_ListaCiudad"

        dt = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        Dim list As New List(Of eCiudad)
        Dim row As New eCiudad
        row.idCiudad = 0
        row.nombreCiudad = "--- Sin selección ---"
        list.Add(row)

        For x As Int16 = 0 To dt.Rows.Count - 1
            row = New eCiudad
            row.idCiudad = IIf(IsDBNull(dt.Rows(x)("idCiudad")), Nothing, dt.Rows(x)("idCiudad"))
            row.idRegion = IIf(IsDBNull(dt.Rows(x)("idRegion")), Nothing, dt.Rows(x)("idRegion"))
            row.nombreCiudad = IIf(IsDBNull(dt.Rows(x)("nombreCiudad")), Nothing, dt.Rows(x)("nombreCiudad"))
            list.Add(row)
        Next

        vlSqlParam.Clear()
        Return list

    End Function

    


End Class
