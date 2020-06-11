Imports Entidad
Public Class clsBeneficiarioDA
    Dim con As New clsConexion 'SE CREA OBJETO DE CLSCONEXION PARA PODER CONECTARNOS A BASE DE DATOS
    Dim query As String 'VARIABLE QUE ALMACENARA EL PROCEDIMIENTO ALMACENDADO A CONSULTAR
    Dim tipoConexion As Integer 'VARIABLE QUE ALMACENARA LA BASE A LA CUAL CONSULTAR
    Dim vlSqlParam As New Mok.SqlParametros 'VARIABLE QUE ALMACENARA LOS PARAMETROS A LA BASE DE DATOS
    Dim Tabla As New DataTable
    '**********************Netodo para eliminar beneficiario***********************************
    Public Sub Eliminar(ByVal id As String)
        vlSqlParam.Clear()

        tipoConexion = 2
        query = "[Config].[Eliminar_Beneficiario]"
        vlSqlParam.Add("@cli_id", id, SqlDbType.BigInt)
        con.Ejecutar(query, vlSqlParam, tipoConexion)

        vlSqlParam.Clear()
    End Sub
    '**********************Netodo para insertar beneficiario***********************************
    Public Sub Insertar(ByVal ben As eBeneficiario)
        Dim dt As DataTable
        vlSqlParam.Clear()

        tipoConexion = 2
        query = "[Config].pa_" + nomcampania + "_InsertaBeneficiario"
        vlSqlParam.Add("@CLI_ID", ben.cli_id, SqlDbType.BigInt)
        vlSqlParam.Add("@T_RUT", ben.t_rut, SqlDbType.Int)
        vlSqlParam.Add("@B_NRO", ben.b_nro, SqlDbType.SmallInt)
        vlSqlParam.Add("@B_RUT", ben.b_rut, SqlDbType.Int)
        vlSqlParam.Add("@B_DV", ben.b_dv, SqlDbType.Char)
        vlSqlParam.Add("@B_NOMBRE1", ben.b_nombre1, SqlDbType.VarChar)
        vlSqlParam.Add("@B_NOMBRE2", ben.b_nombre2, SqlDbType.VarChar)
        vlSqlParam.Add("@B_PATERNO", ben.b_paterno, SqlDbType.VarChar)
        vlSqlParam.Add("@B_MATERNO", ben.b_materno, SqlDbType.VarChar)
        vlSqlParam.Add("@B_PARENTESCO", ben.b_parentesco, SqlDbType.Int)
        vlSqlParam.Add("@B_PARENTESCO_TEXT", ben.parentesco_text, SqlDbType.VarChar)
        vlSqlParam.Add("@B_PCTJE", ben.b_pctje, SqlDbType.VarChar)
        vlSqlParam.Add("@B_FEC_NAC", ben.b_fec_nac, SqlDbType.VarChar)
        'vlSqlParam.Add("@B_CONTACTO", ben.b_contacto, SqlDbType.VarChar)

        dt = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        vlSqlParam.Clear()
    End Sub

    Public Function Carga_Beneficiarios(ByVal rut As String, ByVal id As String) As List(Of eBeneficiario)
        vlSqlParam.Clear()
        Dim lista As New List(Of eBeneficiario)
        query = "[Config].[pa_" + nomcampania + "_BuscaBeneficiarios]"
        vlSqlParam.Add("@T_RUT", rut, SqlDbType.Int)
        vlSqlParam.Add("@CLI_ID", id, SqlDbType.BigInt)
        tipoConexion = 2
        Tabla = con.TraeDatosConP(vlSqlParam, query, tipoConexion)

        For i As Int16 = 0 To Tabla.Rows.Count - 1

            Dim com As New eBeneficiario

            com.b_nombre1 = Tabla.Rows(i)("B_NOMBRE1")
            com.b_nombre2 = Tabla.Rows(i)("B_NOMBRE2")
            com.B_PATERNO = Tabla.Rows(i)("B_AP_PAT")
            com.B_MATERNO = Tabla.Rows(i)("B_AP_MAT")
            com.B_RUT = Tabla.Rows(i)("B_RUT")
            com.B_DV = Tabla.Rows(i)("B_DV")
            com.b_parentesco = Tabla.Rows(i)("B_PARENTESCO")
            com.B_PCTJE = Tabla.Rows(i)("B_PCTJE")
            com.parentesco_text = Tabla.Rows(i)("B_PARENTESCO_TEXT")
            'com.b_fecha_nac = IIf(Tabla.Rows(i)("B_FECHANACIMIENTO") = "", "1990-01-01", Format(Tabla.Rows(i)("B_FECHANACIMIENTO"), "yyyy-MM-dd"))
            'com.b_fecha_nac = IIf(Tabla.Rows(i)("B_FECHANACIMIENTO") = "", "1990-01-01", DateTime.ParseExact(Tabla.Rows(i)("B_FECHANACIMIENTO"), "yyyyMMdd", Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd"))

            lista.Add(com)
        Next
        vlSqlParam.Clear()
        Return lista
    End Function

End Class
