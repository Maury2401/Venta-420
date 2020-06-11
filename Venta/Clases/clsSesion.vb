Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class clsSesion
    Public Conexion_BDD_Local As New Mok.SqlConexion
    Public Conexion_BDD_GLOBAL As New Mok.SqlConexion
	
	Public Sub Conectar_BDD_Local()
		Dim Parametros As String
        If Conexion_BDD_Local.State = ConnectionState.Closed Then
            Parametros = "Data Source=" & vgCampania.calServidorBDD & ";Initial Catalog=BDD_" & My.Settings.vgcCentroCosto & ";Persist Security Info=True;User ID=aspnet;Password=123"

            Conexion_BDD_Local.ConnectionString = Parametros


            Conexion_BDD_Local.Open()
        End If



	End Sub
	Public Sub Desconectar_BDD_Local()
        If Conexion_BDD_Local.State = ConnectionState.Open Then
            Conexion_BDD_Local.Close()
        End If
    End Sub
	
	Public Sub Conectar_BDD_GLOBAL()
		Dim Parametros As String	        
        If Conexion_BDD_GLOBAL.State = ConnectionState.Closed Then
            Parametros = "Data Source=" & vgCampania.calServidorBDD & ";Initial Catalog=GLOBAL;Persist Security Info=True;User ID=aspnet;Password=123"
            Conexion_BDD_GLOBAL.ConnectionString = Parametros

            Conexion_BDD_GLOBAL.Open()
        End If
    End Sub
    Public Sub Desconectar_BDD_GLOBAL()
        If Conexion_BDD_GLOBAL.State = ConnectionState.Open Then
            Conexion_BDD_GLOBAL.Close()
        End If

    End Sub
End Class