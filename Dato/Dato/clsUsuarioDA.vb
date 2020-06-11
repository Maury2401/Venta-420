Imports System.Collections.Generic
Imports Entidad
Public Class clsUsuarioDA
    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim tabla As New DataTable


    Function FechaServidor() As DateTime
        Dim fecha As DateTime
        fecha = Nothing
        tipoConexion = 1

        query = "[dbo].[Fecha_Servidor]"
        Tabla = con.TraeDatosSinP(query, tipoConexion)

        For Each row As DataRow In Tabla.Rows
            fecha = row.Item(0)
        Next

        Return fecha
    End Function

    ''' <summary>
    ''' Obtiene una usuario filtrado por usuario
    ''' </summary>
    ''' <param name="user"></param>
    ''' <returns>Entidad usuario</returns>
    ''' <remarks></remarks>
    Public Function Validar_user(ByVal user As String) As Boolean
        Dim est As Boolean
        est = False
        Dim fecha As String
        vlSqlParam.Clear()
        fecha = FechaServidor.ToString("yyyyMMdd")
        tipoConexion = 2

        query = "[Config].[sp_Valida_Logueo]"
        vlSqlParam.Add("@USUARIO", user, SqlDbType.VarChar)
        vlSqlParam.Add("@FECHA", fecha, SqlDbType.Int)
        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        If Tabla.Rows.Count <= 0 Then
            Return est
        Else
            est = True
        End If
        Return est
    End Function

    ''' <summary>
    ''' Indica si usuario es regrabador
    ''' </summary>
    ''' <param name="user"></param>
    ''' <returns>Entidad usuario</returns>
    ''' <remarks></remarks>
    Public Function Validar_REG(ByVal user As String, ByVal tipo As String) As Boolean
        vlSqlParam.Clear()
        Dim est As Boolean
        est = False
        tipoConexion = 1

        query = "[dbo].[pa_Valida_Usuario]"
        vlSqlParam.Add("@usuario", user, SqlDbType.VarChar)
        vlSqlParam.Add("@tipo", tipo, SqlDbType.Int)
        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        If Tabla.Rows.Count <= 0 Then
            Return est
        Else
            est = True
        End If
        Return est
    End Function
End Class
