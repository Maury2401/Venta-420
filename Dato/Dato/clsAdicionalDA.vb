Imports Entidad
Public Class clsAdicionalDA
    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim Tabla As New DataTable

    Public Sub Insertar(ByVal adic As eAdicional)
        vlSqlParam.Clear()
        tipoConexion = 2
        query = "[Config].pa_" + nomcampania + "_InsertaAdicional"
        vlSqlParam.Add("@CLI_ID", adic.CLI_ID, SqlDbType.BigInt)
        vlSqlParam.Add("@T_RUT", adic.T_RUT, SqlDbType.Int)
        vlSqlParam.Add("@A_NRO", adic.A_NRO, SqlDbType.SmallInt)
        vlSqlParam.Add("@A_RUT", adic.A_RUT, SqlDbType.Int)
        vlSqlParam.Add("@A_DV", adic.A_DV, SqlDbType.Char)
        vlSqlParam.Add("@A_NOMBRE", adic.a_nombre, SqlDbType.VarChar)
        vlSqlParam.Add("@A_NOMBRE2", adic.A_NOMBRE2, SqlDbType.VarChar)
        vlSqlParam.Add("@A_PATERNO", adic.A_PATERNO, SqlDbType.VarChar)
        vlSqlParam.Add("@A_MATERNO", adic.A_MATERNO, SqlDbType.VarChar)
        vlSqlParam.Add("@A_FECNACIMIENTO", adic.a_fecnacimiento, SqlDbType.VarChar)
        vlSqlParam.Add("@A_SEXO", adic.a_sexo, SqlDbType.VarChar)
        vlSqlParam.Add("@A_ID_PARENTESCO", adic.a_id_parentesco, SqlDbType.VarChar)
        vlSqlParam.Add("@A_PARENTESCO", adic.a_parentesco, SqlDbType.VarChar)
        vlSqlParam.Add("@primaUf", adic.a_primaUf, SqlDbType.VarChar)
        vlSqlParam.Add("@idPlan", adic.idPlanAdic, SqlDbType.VarChar)
        vlSqlParam.Add("@a_salud", adic.a_salud, SqlDbType.VarChar)
        con.Ejecutar(query, vlSqlParam, tipoConexion)
        vlSqlParam.Clear()
    End Sub

    Public Function Verificar(ByVal id As String, ByVal rut As String) As Boolean
        Try

            vlSqlParam.Clear()

            tipoConexion = 1
            query = "[dbo].[Verifica_Adicional]"
            vlSqlParam.Add("@cli_id", id, SqlDbType.BigInt)
            vlSqlParam.Add("@cli_arut", rut, SqlDbType.Int)
            Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)
            If Tabla.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

            vlSqlParam.Clear()
        Catch ex As Exception

        End Try
    End Function

    Public Sub Eliminar(ByVal _id As String, ByVal _rut As String)
        vlSqlParam.Clear()

        tipoConexion = 2
        query = "[Config].[Elimina_Adicional]"
        vlSqlParam.Add("@cli_id", _id, SqlDbType.BigInt)
        vlSqlParam.Add("@cli_arut", _rut, SqlDbType.Int)

        con.Ejecutar(query, vlSqlParam, tipoConexion)

        vlSqlParam.Clear()
    End Sub

    Public Function Carga_Adicional(ByVal _rut As String, ByVal _id As String) As List(Of eAdicional)
        vlSqlParam.Clear()
        Dim lista As New List(Of eAdicional)
        query = "[Config].[pa_BuscaAdicionales]"
        vlSqlParam.Add("@RutTitular", _rut, SqlDbType.Int)
        vlSqlParam.Add("@CLI_ID", _id, SqlDbType.BigInt)
        tipoConexion = 2
        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        For i As Int16 = 0 To Tabla.Rows.Count - 1

            Dim adic As New eAdicional
            adic.a_nro = Tabla.Rows(i)("A_NRO")
            adic.a_rut = Tabla.Rows(i)("A_RUT")
            adic.a_dv = Tabla.Rows(i)("A_DV")
            adic.a_nombre = Tabla.Rows(i)("A_NOMBRE")
            adic.a_paterno = Tabla.Rows(i)("A_PATERNO")
            adic.a_materno = Tabla.Rows(i)("A_MATERNO")
            adic.a_fecnacimiento = DateTime.ParseExact(Tabla.Rows(i)("A_FECNACIMIENTO"), "yyyyMMdd", Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd")
            adic.a_parentesco = Tabla.Rows(i)("A_PARENTESCO")
            adic.a_sexo = Tabla.Rows(i)("A_SEXO")
            adic.idPlanAdic = Tabla.Rows(i)("idPlan")
            adic.a_primaUf = Tabla.Rows(i)("primaUf")

            lista.Add(adic)
        Next
        vlSqlParam.Clear()
        Return lista

    End Function

End Class
