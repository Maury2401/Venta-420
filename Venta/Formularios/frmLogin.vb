Option Strict Off
Option Explicit On

Imports Entidad
Imports BI

Friend Class frmLogin
    Inherits System.Windows.Forms.Form
    Dim opc As Short
    '*******metodo al presionar boton aceptar de boton login****************
    Private Sub btnAceptar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnAceptar.Click
        opc = 1
        Dim valido As Boolean
        Dim bigene As New clsGeneralBI
        Dim biUsuario As New clsUsuarioBI
        If CheckBoxLogin.Checked = True Then ' si checkbox esta marcado es para entrar como regrabador
            valido = biUsuario.Validar_Reg(WS_IDUSUARIO, 4) ' validamos si el usuario tiene  el perfil de ejecutivo regrabador
            If valido = True Then
                perfil = "Regrabador"
            Else
                valido = biUsuario.Validar_Reg(WS_IDUSUARIO, 12) ' validamos si el usuario tiene  el perfil de sistemas
                If valido = True Then
                    perfil = "Regrabador"
                End If
            End If
            If valido = False Then
                MsgBox("El usuario no tiene permisos como Ejecutivo de Regrabación", MsgBoxStyle.Exclamation, "Atención")
                End
            End If

        ElseIf CheckBoxLogin.Checked = False Then ' si checkbox no esta marcado entra como ventas
            valido = biUsuario.Validar_user(WS_IDUSUARIO) ' validamos el usuario para ventas
            If valido = True Then
                perfil = "Ejecutivo"
            Else
                MsgBox("El usuario no tiene permisos como Ejecutivo de Ventas", MsgBoxStyle.Exclamation, "Atención")
                End
            End If
        End If

        If perfil = "Regrabador" Then
            vgCampania.rutaWebService = vgCampania.rutaWebServiceRegrabacion
            vgCampania.calIdCampanaNeo = vgCampania.IdCampanaNeoRegrabacion
            oSoapClient.Url = vgCampania.rutaWebServiceRegrabacion
        End If

        If db_central = 4 Then

            If ConectaNeotel((txtusuxlite.Text)) Then
                ModGeneral.conectarTelefonia()
                Logear_Usuario(WS_IDUSUARIO, 1)
                frmAce.Show()
                Me.Close()
            End If
        Else
            ModGeneral.conectarTelefonia()
            Logear_Usuario(WS_IDUSUARIO, 1)
            frmAce.Show()
            Me.Close()
        End If
    End Sub


    Private Sub frmLogin_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Me.Text = "NEW Versión: " & My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString _
      & "." & My.Application.Info.Version.Revision.ToString & "-" & csNombreAplicacion
        TxtUsuarioLog.Text = Trim(WS_IDUSUARIO)
        TXT_USUARIO.Text = WS_Usuario
        WS_NOMUSUARIO = WS_Usuario
        If db_central = 4 Then
            fraxlite.Visible = True
        End If
        opc = 0
    End Sub

    Public Function ConectaNeotel(ByRef Usuario As String) As Boolean
        If Usuario = "" Then
            MsgBox("Debe ingresar usuario XLite", MsgBoxStyle.Exclamation, "Atención")
            txtusuxlite.Focus()
        Else

            vpPosicion = New clsSoapNeo
            If vpNeotel.CargarPosicion(Usuario) <> "" Then
                If vpPosicion.Usuario = Usuario Then
                    ConectaNeotel = True
                Else
                    MsgBox("El usuario XLite no corresponde", MsgBoxStyle.Exclamation, "Atención")
                End If
            End If
        End If
    End Function

    Private Sub frmLogin_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If opc = 0 Then
            End
        End If
    End Sub
End Class