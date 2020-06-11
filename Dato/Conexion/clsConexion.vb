Public Class clsConexion
    Dim con As New Mok.SqlConexion
    Private Function CadenaConexion(ByVal IdBase As Integer) As String
        Dim stringConexion As String
        stringConexion = ""

        Select Case IdBase
            Case 1 '"GLOBAL"
                stringConexion = "Data Source=10.15.23.15;Initial Catalog=Global;Persist Security Info=True;User ID=aspnet;Password=123"
            Case 2 '"BASEACTUAL"
                stringConexion = "Data Source=10.15.23.15;Initial Catalog=BDD_" + nomcampania + ";Persist Security Info=True;User ID=;User ID=aspnet;Password=123"
            Case 3 '"SRVCS"
                stringConexion = "Data Source= srvcs-prd;Initial Catalog=Global;Persist Security Info=True;User ID=aspnet;Password=123"
        End Select
        Return stringConexion
    End Function

    Private Function conectar(ByVal x As Integer) As Boolean
        Try
            con = New Mok.SqlConexion(CadenaConexion(x))
            con.Open()
            Return True
        Catch ex As Exception
            MsgBox("Problemas al abrir conexión a base de datos", MsgBoxStyle.Critical, "CALLSOUTH")
            Return False
        End Try
    End Function
    Private Sub desconectar()
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MsgBox("Problemas al cerrar conexión a base de datos", MsgBoxStyle.Critical, "CALLSOUTH")
        End Try
    End Sub
    Public Sub Ejecutar(ByVal query As String, ByVal parametros As Mok.SqlParametros, ByVal x As Integer)
        Try

            If conectar(x) = True Then
                con.BeginTransaction()
                Dim rows As Integer
                Try
                    rows = con.ExecuteNonQuery(query, CommandType.StoredProcedure, parametros)
                    If rows > 0 Then
                        con.CommitTransaction()
                        'Else
                        '    con.RollbackTransaction()
                        '    MsgBox("ERROR: nombre procedimiento " + query + " Detalle: ", MsgBoxStyle.Critical, "CALLSOUTH")
                    End If

                Catch ex As Exception
                    con.RollbackTransaction()
                    MsgBox(ex, MsgBoxStyle.Critical, "CALLSOUTH")
                End Try
                desconectar()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function TraeDatosSinP(ByVal sql As String, ByVal x As Integer) As DataTable

        Dim Tabla As New DataTable
        Dim sqlp As New Mok.SqlParametros
        If conectar(x) = True Then
            Try
                Tabla = con.GetDataTable(sql, CommandType.StoredProcedure, sqlp)

            Catch ex As Exception
                MsgBox(ex, MsgBoxStyle.Critical, "CALLSOUTH")
            End Try
            desconectar()
        End If
        Return Tabla
    End Function
    Public Function TraeDatosConP(parametros As Mok.SqlParametros, ByVal sql As String, ByVal x As Integer) As DataTable
        Try

            Dim Tabla As New DataTable
            If conectar(x) = True Then
                Try
                    Tabla = con.GetDataTable(sql, CommandType.StoredProcedure, parametros)

                Catch ex As Exception
                    MsgBox(ex, MsgBoxStyle.Critical, "CALLSOUTH")
                End Try
                desconectar()
            End If
            Return Tabla
        Catch ex As Exception

        End Try
    End Function
End Class
