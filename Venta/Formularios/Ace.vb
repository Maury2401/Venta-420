Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic
Imports Entidad
Imports BI

Friend Class frmAce
    Inherits System.Windows.Forms.Form
    Public KeyAscii As Short
    Dim cnn As New SqlConnection("data source = " & vgCampania.calServidorBDD & "; initial catalog = Global; User Id= aspnet; Password=123")

    Public FilaAgregar2 As Integer
    Public FilaElimina As Integer
    Public FilaElimina2 As Integer
    Public fila As Integer
    Public fila2 As Integer
    Public Col As Integer
    Public i As Integer
    Public ufAdic As Double = 0
    Public totalUfAdic As Double = 0
    Public idPlanAdic As Int64
    Public TpoContratoAdicional As eTipoContrato
    Public valorPesosUf As Integer = 0
    Public TotalPesos As Integer

    Dim biClsComuna As New clsComunaBI
    Dim biClsCiudad As New clsCiudadBI
    Dim biClsEdoFono As New clsEstadoFonosBI
    Dim biClsScript As New clsScriptBI
    Dim biClsTipoContrato As New clsTipoContratoBI
    Dim biClsPlan As New clsPlanBI
    Dim biClsRestricion As New clsRestriccionBI
    Dim biClsParentesco As New clsParentescoBI
    Dim biClsParentescoCampania As New clsParentescoCampaniaBI
    Dim biClsBen As New clsBeneficiarioBI
    Dim biClsAdic As New clsAdicionalBI
    Dim biCorreoInv As New clsCorreoInvalidoBI

    Dim clsScript As New eScript
    Dim vlUF As String

    Dim ListTipoContrato As New List(Of eTipoContrato)
    Dim tipoContrato As New eTipoContrato
    Dim listPlanes As New List(Of ePlan)
    Dim planE As New ePlan
    Dim ePlanGlobal As New ePlan
    Dim listRestricciones As New List(Of eRestriccion)
    Dim restricionE As New eRestriccion
    Dim listParentesco As List(Of eParentesco)
    Dim listaCorreoInvalido As New List(Of eCorreoInvalido)

    Private IsInitializing As Boolean = True

    Dim biCliente As New clsClienteBI
    Dim biGeneral As New clsGeneralBI
    Dim biScrisp As New clsScriptBI
    Dim biGesRes As New clsRegrabacionesBI

    Private Sub Botones(ByRef activo As Boolean)
        Select Case activo
            Case False
                CmdLlamar1.Enabled = False
                CmdLlamar2.Enabled = False
                CmdLlamar3.Enabled = False
                CmdLlamar4.Enabled = False
                CmdLlamar5.Enabled = False
                CmdLlamar6.Enabled = False
                CmdLlamarAlt.Enabled = False
            Case True
                CmdLlamar1.Enabled = Not esVacio((Txt_Fono1.Text)) 'True
                CmdLlamar2.Enabled = Not esVacio((Txt_Fono2.Text)) 'True
                CmdLlamar3.Enabled = Not esVacio((Txt_Fono3.Text)) 'True
                CmdLlamar4.Enabled = Not esVacio((Txt_Fono4.Text)) 'True
                CmdLlamar5.Enabled = Not esVacio((Txt_Fono5.Text)) 'True
                CmdLlamar6.Enabled = Not esVacio((Txt_Fono6.Text)) 'True
                CmdLlamarAlt.Enabled = Not esVacio((Txt_Fono_alt.Text)) 'True
                CmdLlamarAlt.Enabled = IIf(perfil = "Regrabador", True, Not esVacio((Txt_Fono_alt.Text)))  'True
                Txt_Fono_alt.ReadOnly = IIf(perfil = "Regrabador", False, True)
                CmdLlamarVent.Enabled = IIf(perfil = "Regrabador", True, Not esVacio((txt_FonoVenta.Text)))  'True
                txt_FonoVenta.ReadOnly = IIf(perfil = "Regrabador", False, True)

        End Select
    End Sub

    'UPGRADE_WARNING: El evento chkMute.CheckStateChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub chkMute_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkMute.CheckStateChanged
        If chkMute.CheckState = 0 Then
            chkMute.Text = "Mute Desactivado"
        Else
            chkMute.Text = "Mute Activado"
            chkMute.BackColor = System.Drawing.ColorTranslator.FromOle(&H8000000F)
        End If

        If CmdLlamar1.Text = "COLGAR" Or CmdLlamar2.Text = "COLGAR" Or CmdLlamar3.Text = "COLGAR" Or CmdLlamar4.Text = "COLGAR" Or CmdLlamar5.Text = "COLGAR" Or CmdLlamar6.Text = "COLGAR" Or CmdLlamarAlt.Text = "COLGAR" Then
            Datos = ""
            Mute()
        ElseIf chkMute.CheckState = 1 Then
            MsgBox("Debe llamar antes de pasar al estado MUTE")
            chkMute.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If
    End Sub

    Private Sub llamarProgresivoFijo()
        

        If flg_progresivo_activado Then

            If (flg_fonoVent) And Not flg_EsCeluVent Then
                'Comenzar (1)
                LlamarFono(CmdLlamarVent, txt_FonoVenta, flg_fonoVent)
                lblNumero.Text = txt_FonoVenta.Text
                lblIdNumero.Text = "vent"
            Else

                If (flg_fono1) And Not flg_EsCelu1 Then
                    'Comenzar (1)
                    LlamarFono(CmdLlamar1, Txt_Fono1, flg_fono1)
                    lblNumero.Text = Txt_Fono1.Text
                    lblIdNumero.Text = "1"
                Else
                    If (flg_fono2) And Not flg_EsCelu2 Then
                        'Comenzar (2)
                        LlamarFono(CmdLlamar2, Txt_Fono2, flg_fono2)
                        lblNumero.Text = Txt_Fono2.Text
                        lblIdNumero.Text = "2"
                    Else
                        If (flg_fono3) And Not flg_EsCelu3 Then
                            'Comenzar (3)
                            LlamarFono(CmdLlamar3, Txt_Fono3, flg_fono3)
                            lblNumero.Text = Txt_Fono3.Text
                            lblIdNumero.Text = "3"
                        Else
                            If (flg_fono4) And Not flg_EsCelu4 Then
                                'Comenzar (4)
                                LlamarFono(CmdLlamar4, Txt_Fono4, flg_fono4)
                                lblNumero.Text = Txt_Fono4.Text
                                lblIdNumero.Text = "4"
                            Else
                                If (flg_fono5) And Not flg_EsCelu5 Then
                                    'Comenzar (5)
                                    LlamarFono(CmdLlamar5, Txt_Fono5, flg_fono5)
                                    lblNumero.Text = Txt_Fono5.Text
                                    lblIdNumero.Text = "5"
                                Else
                                    If (flg_fono6) And Not flg_EsCelu6 Then
                                        'Comenzar (6)
                                        LlamarFono(CmdLlamar6, Txt_Fono6, flg_fono6)
                                        lblNumero.Text = Txt_Fono6.Text
                                        lblIdNumero.Text = "6"
                                    Else
                                        If (flg_fonoalt) And Not flg_EsCeluAlt Then
                                            LlamarFono(CmdLlamarAlt, Txt_Fono_alt, flg_fonoalt)
                                            If flg_progresivo_activado Then
                                                flg_progresivo_activado = False
                                            End If
                                            lblNumero.Text = Txt_Fono_alt.Text
                                            lblIdNumero.Text = "alt"
                                        Else
                                            llamarProgresivoCelular()
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Else
            ' el progesivo se ha desactivado debido a que el ejecutivo
            ' ha marcado una llamada como contactada o la modalidad de la campaña no es progresiva
        End If

    End Sub

    Private Sub llamarProgresivoCelular()

        If flg_progresivo_activado Then
            If (flg_fonoVent) Then
                'Comenzar (1)
                LlamarFono(CmdLlamarVent, txt_FonoVenta, flg_fonoVent)
            Else

                If (flg_fono1) Then
                    'Comenzar (1)
                    LlamarFono(CmdLlamar1, Txt_Fono1, flg_fono1)
                Else
                    If (flg_fono2) Then
                        'Comenzar (2)
                        LlamarFono(CmdLlamar2, Txt_Fono2, flg_fono2)
                    Else
                        If (flg_fono3) Then
                            'Comenzar (3)
                            LlamarFono(CmdLlamar3, Txt_Fono3, flg_fono3)
                        Else
                            If (flg_fono4) Then
                                'Comenzar (4)
                                LlamarFono(CmdLlamar4, Txt_Fono4, flg_fono4)
                            Else
                                If (flg_fono5) Then
                                    'Comenzar (5)
                                    LlamarFono(CmdLlamar5, Txt_Fono5, flg_fono5)
                                Else
                                    If (flg_fono6) Then
                                        'Comenzar (6)
                                        LlamarFono(CmdLlamar6, Txt_Fono6, flg_fono6)
                                    Else
                                        If (flg_fonoalt) Then
                                            LlamarFono(CmdLlamarAlt, Txt_Fono_alt, flg_fonoalt)
                                            If flg_progresivo_activado Then
                                                flg_progresivo_activado = False
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Else
            ' el progesivo se ha desactivado debido a que el ejecutivo
            ' ha marcado una llamada como contactada o la modalidad de la campaña no es progresiva
        End If

    End Sub

    Private Sub llamarProgresivo()

        If flg_progresivo_activado Then


            If (flg_fono1) Then
                'Comenzar (1)
                LlamarFono(CmdLlamar1, Txt_Fono1, flg_fono1)
                lblNumero.Text = Txt_Fono1.Text
                lblIdNumero.Text = "1"
            Else
                If (flg_fono2) Then
                    'Comenzar (2)
                    LlamarFono(CmdLlamar2, Txt_Fono2, flg_fono2)
                    lblNumero.Text = Txt_Fono2.Text
                    lblIdNumero.Text = "2"
                Else
                    If (flg_fono3) Then
                        'Comenzar (3)
                        LlamarFono(CmdLlamar3, Txt_Fono3, flg_fono3)
                        lblNumero.Text = Txt_Fono3.Text
                        lblIdNumero.Text = "3"
                    Else
                        If (flg_fono4) Then
                            'Comenzar (4)
                            LlamarFono(CmdLlamar4, Txt_Fono4, flg_fono4)
                            lblNumero.Text = Txt_Fono4.Text
                            lblIdNumero.Text = "4"
                        Else
                            If (flg_fono5) Then
                                'Comenzar (5)
                                LlamarFono(CmdLlamar5, Txt_Fono5, flg_fono5)
                                lblNumero.Text = Txt_Fono5.Text
                                lblIdNumero.Text = "5"
                            Else
                                If (flg_fono6) Then
                                    'Comenzar (6)
                                    LlamarFono(CmdLlamar6, Txt_Fono6, flg_fono6)
                                    lblNumero.Text = Txt_Fono6.Text
                                    lblIdNumero.Text = "6"
                                Else
                                    If (flg_fonoalt) Then
                                        LlamarFono(CmdLlamarAlt, Txt_Fono_alt, flg_fonoalt)
                                        If flg_progresivo_activado Then
                                            flg_progresivo_activado = False
                                        End If
                                        lblNumero.Text = Txt_Fono_alt.Text
                                        lblIdNumero.Text = "alt"
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    'pasamos como parametros el fono a llamar y el valor del telefono
    Public Sub LlamarFono(ByRef CmdLlamar As System.Windows.Forms.Button, ByRef txtFono As System.Windows.Forms.TextBox, ByRef fonoActivo As Boolean)
        Dim cmdFonos(6) As String
        Dim i As Short
        Dim f As Short
        If txtFono.Text <> "" Then
            If CmdLlamar.Text = "COLGAR" Then
                grabarCallId("CORTAR", WS_CALL_ID, (txtFono.Text), claveRegistroActual)
                'cortar llamada fonox
                cortarFonos(CmdLlamar, False)
                'desactivamos el mute
                If chkMute.CheckState = 1 Then chkMute.CheckState = System.Windows.Forms.CheckState.Unchecked
                'volvemos a llamar al fono
                fonoActivo = False
            Else
                Botones(True)
                cmdFonos(0) = CmdLlamar1.Name
                cmdFonos(1) = CmdLlamar2.Name
                cmdFonos(2) = CmdLlamar3.Name
                cmdFonos(3) = CmdLlamar4.Name
                cmdFonos(4) = CmdLlamar5.Name
                cmdFonos(5) = CmdLlamar6.Name
                cmdFonos(6) = CmdLlamarAlt.Name

                f = UBound(cmdFonos)

                For i = 0 To f
                    If cmdFonos(i) <> CmdLlamar.Name Then
                        'validamos que no existan otras llamadas activas
                        If i = 0 Then
                            If (CmdLlamar2.Text = "COLGAR" Or CmdLlamar3.Text = "COLGAR" Or CmdLlamar4.Text = "COLGAR" Or CmdLlamar5.Text = "COLGAR" Or CmdLlamar6.Text = "COLGAR" Or CmdLlamarAlt.Text = "COLGAR") Then
                                MsgBox("No puede realizar otra llamada mientras ya tenga una activa!", MsgBoxStyle.Exclamation, "CALLSOUTH")
                                Exit Sub
                            End If
                        End If

                        If i = 1 Then
                            If (CmdLlamar1.Text = "COLGAR" Or CmdLlamar3.Text = "COLGAR" Or CmdLlamar4.Text = "COLGAR" Or CmdLlamar5.Text = "COLGAR" Or CmdLlamar6.Text = "COLGAR" Or CmdLlamarAlt.Text = "COLGAR") Then
                                MsgBox("No puede realizar otra llamada mientras ya tenga una activa!", MsgBoxStyle.Exclamation, "CALLSOUTH")
                                Exit Sub
                            End If
                        End If

                        If i = 2 Then
                            If (CmdLlamar1.Text = "COLGAR" Or CmdLlamar2.Text = "COLGAR" Or CmdLlamar4.Text = "COLGAR" Or CmdLlamar5.Text = "COLGAR" Or CmdLlamar6.Text = "COLGAR" Or CmdLlamarAlt.Text = "COLGAR") Then
                                MsgBox("No puede realizar otra llamada mientras ya tenga una activa!", MsgBoxStyle.Exclamation, "CALLSOUTH")
                                Exit Sub
                            End If
                        End If

                        If i = 3 Then
                            If (CmdLlamar1.Text = "COLGAR" Or CmdLlamar2.Text = "COLGAR" Or CmdLlamar3.Text = "COLGAR" Or CmdLlamar5.Text = "COLGAR" Or CmdLlamar6.Text = "COLGAR" Or CmdLlamarAlt.Text = "COLGAR") Then
                                MsgBox("No puede realizar otra llamada mientras ya tenga una activa!", MsgBoxStyle.Exclamation, "CALLSOUTH")
                                Exit Sub
                            End If
                        End If

                        If i = 4 Then
                            If (CmdLlamar1.Text = "COLGAR" Or CmdLlamar2.Text = "COLGAR" Or CmdLlamar3.Text = "COLGAR" Or CmdLlamar4.Text = "COLGAR" Or CmdLlamar6.Text = "COLGAR" Or CmdLlamarAlt.Text = "COLGAR") Then
                                MsgBox("No puede realizar otra llamada mientras ya tenga una activa!", MsgBoxStyle.Exclamation, "CALLSOUTH")
                                Exit Sub
                            End If
                        End If

                        If i = 5 Then
                            If (CmdLlamar1.Text = "COLGAR" Or CmdLlamar2.Text = "COLGAR" Or CmdLlamar3.Text = "COLGAR" Or CmdLlamar4.Text = "COLGAR" Or CmdLlamar5.Text = "COLGAR" Or CmdLlamarAlt.Text = "COLGAR") Then
                                MsgBox("No puede realizar otra llamada mientras ya tenga una activa!", MsgBoxStyle.Exclamation, "CALLSOUTH")
                                Exit Sub
                            End If
                        End If

                        If i = 6 Then
                            If (CmdLlamar1.Text = "COLGAR" Or CmdLlamar2.Text = "COLGAR" Or CmdLlamar3.Text = "COLGAR" Or CmdLlamar4.Text = "COLGAR" Or CmdLlamar5.Text = "COLGAR" Or CmdLlamar6.Text = "COLGAR") Then
                                MsgBox("No puede realizar otra llamada mientras ya tenga una activa!", MsgBoxStyle.Exclamation, "CALLSOUTH")
                                Exit Sub
                            End If
                        End If

                    End If
                Next
                'sino hay otras llamadas activas entonces
                'llamamos al fonox
                If Not llamar((txtFono.Text)) Then
                    MsgBox("No puede realizar otra llamada mientras ya tenga una activa!", MsgBoxStyle.Exclamation, "CALLSOUTH")
                Else
                    grabarCallId("LLAMAR", WS_CALL_ID, (txtFono.Text), claveRegistroActual)
                    CmdLlamar.Text = "COLGAR"
                    CmdLlamar.BackColor = System.Drawing.ColorTranslator.FromOle(&HFF)
                    txtCallId.Text = WS_CALL_ID
                End If
            End If
        End If
    End Sub
    '******************Metodo al cambiar item de combobox cmbComunicaCon de tab Conexion****************************************************************
    Private Sub CmbComunicaCon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbComunicaCon.SelectedIndexChanged
        '0 [No Especificado]
        '1 COMUNICA CON CLIENTE
        '2 COMUNICA CON CLIENTE NO VIGENTE EN METLIFE
        '3 COMUNICA CON CONYUGE
        '4 COMUNICA CON TERCERO VALIDO
        '5 COMUNICA CON REGISTRO NO VALIDO (NO VIVE/NO TRABAJA AHI)

        Select Case CmbComunicaCon.SelectedIndex
            Case 1, 3
                CmbComunicaTercero.SelectedIndex = -1
                Label12.Visible = True
                CmbComunicaTercero.Visible = False
                Label11.Visible = False
                Label13.Visible = False
            Case 2
                CmbComunicaTercero.SelectedIndex = -1
                Label12.Visible = True
                CmbComunicaTercero.Visible = True
                Label11.Visible = False
                Label13.Visible = True

        End Select
    End Sub
    '******************Metodo al cambiar item de combobox cmbConecta de tab Conexion****************************************************************
    Private Sub CmbConecta_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmbConecta.SelectedIndexChanged
        If CmbConecta.SelectedIndex = 1 Then
            CmbNoConecta.SelectedIndex = 0
            CmbComunicaCon.SelectedIndex = 0
            CmbComunicaTercero.SelectedIndex = 0
            Label11.Visible = False
            CmbNoConecta.Visible = False
            FrmConex.Visible = True
            Label13.Visible = False
            CmbComunicaTercero.Visible = False

            clsScript = CargaScript(1)
            wbScriptBienvenida.DocumentText = clsScript.contenidoScript

        ElseIf CmbConecta.SelectedIndex = 2 Then
            CmbNoConecta.SelectedIndex = 0
            CmbComunicaCon.SelectedIndex = 0
            CmbComunicaTercero.SelectedIndex = 0
            Label11.Visible = True
            CmbNoConecta.Visible = True
            FrmConex.Visible = False
            Label13.Visible = False
            CmbComunicaTercero.Visible = False

        End If
    End Sub

    Private Sub CmbEstAgenda_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmbEstAgenda.SelectedIndexChanged
        If CmbEstAgenda.SelectedIndex = 0 Or CmbEstAgenda.SelectedIndex = 1 Then
            FrmAgendamiento.Visible = True
            CmdSiguienteA.Visible = False
            CmdTerminarA.Visible = True
        Else
            FrmAgendamiento.Visible = False
            CmdSiguienteA.Visible = True
            CmdTerminarA.Visible = False
        End If
    End Sub

    Private Sub cmdAnexos_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnexos.Click
        frmAnexos.ShowDialog()
    End Sub
    '************************metodo de boton atras ***************************************************************
    Private Sub CmdAtras_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAtras.Click

        'If perfil <> "Regrabador" Then
        If MsgBox("Desea Retroceder?", MsgBoxStyle.YesNo, csNombreAplicacion) = MsgBoxResult.Yes Then
            ' reinicializa los controles y las variables que se modificaron
            ' al pasar de una pantalla a otra, al presionar el boton VOLVER
            ' se saca el ultimo elemento ingresado a la pila (pop). Este numero
            ' corresponde tambien al ultimo TAB visitado en el flujo. Sabiendo este dato
            ' podemos resetear lo que se hizo al pasar del tab anterior al actual
            Dim pantallaAnterior As Integer
            Dim pantallaActual As String


            ' saco el ultimo elemento en la pila (ultimo TAB que se visito)
            pantallaAnterior = pilaPop()
            ' guardo el TAB ACTUAL!
            pantallaActual = Cuerpo.TabPages.Item(Cuerpo.SelectedIndex).Name

            Select Case pantallaActual
                Case "_Cuerpo_Conex"
                    CmbConecta.SelectedIndex = 0
                    CmbNoConecta.SelectedIndex = 0
                    CmbComunicaCon.SelectedIndex = 0
                    CmbComunicaTercero.SelectedIndex = 0
                    Label11.Visible = False
                    CmbNoConecta.Visible = False
                    FrmConex.Visible = False
                    Label13.Visible = False
                    CmbComunicaTercero.Visible = False

                Case "_Cuerpo_MtvoLL"

                    LblCCli.Visible = True
                    CmbRealiza.SelectedIndex = 0
                    CmbRealiza.Visible = True

                Case "_Cuerpo_DatosCli"
                    txtNombre.Text = Trim(UCase(CLIENTE.cli_nombre))
                    txtPaterno.Text = Trim(UCase(CLIENTE.cli_paterno))
                    txtMaterno.Text = Trim(UCase(CLIENTE.cli_materno))
                    txtArut.Text = Mid(CLIENTE.cli_rut, 1, 4)
                    txtDv.Text = ""
                    txtEmail.Text = CLIENTE.cli_email
                    txtCalle.Text = CLIENTE.cli_direccion
                    txtNro.Text = ""
                    txtReferencia.Text = ""
                    cmbComuna.SelectedIndex = -1
                    cmbComuna.Text = ""
                    cmbCiudad.Text = ""
                    txtReferencia.Text = ""
                    txtFonoVenta.Text = ""
                    CmbAutorizaCorreo.SelectedIndex = 0
                    'cmbPlan.SelectedIndex = 0
                    cmbCiudad.DataSource = Nothing
                    cmbCiudad.ValueMember = Nothing

                Case "_Cuerpo_MPago"

                Case "_Cuerpo_InfAdic"

                Case "_Cuerpo_Certifica"
                    cmbAceptaPrima.SelectedIndex = 0
                    cmbAceptaContrato.SelectedIndex = 0

                Case "_Cuerpo_UltInfo"

                

                Case "_Cuerpo_Adicionales"

                    insertaAdicionalesGrilla()
                    limpiaAdicionales()

                Case "_Cuerpo_Objeciones"
                    TxtObj.Text = ""
                    CmbObj.SelectedIndex = 0

                Case "_Cuerpo_Agendar"
                    CmbEstAgenda.SelectedIndex = -1
                    FrmAgendamiento.Visible = False
                    TxtObsA.Text = ""
                    DTAgenFecha2.Value = Today
                    cmbHora.SelectedIndex = -1
                    cmbMin.SelectedIndex = -1
                    CmdTerminarA.Visible = True
                    CmdSiguienteA.Visible = True


                Case "_Cuerpo_Agenda2"
                    TxtObsAgen2.Text = ""
                    DTAgenFecha2.Value = Today
                    CmbHora2.SelectedIndex = -1
                    CmbMin2.SelectedIndex = -1


                Case "_Cuerpo_FinNC"

            End Select

            ' ahora se resetea la pantalla anterior, y tambien
            ' TODOS los campos de usuario que se pudieron haber llenado
            Select Case pantallaAnterior
                Case 0 '_Cuerpo_IngresoCli

                Case 1 ' _Cuerpo_Conex
                    Cuerpo.TabPages.Add(_Cuerpo_Conex)
                    CLIENTE.cli_conecta = ""
                    CLIENTE.cli_no_conecta = ""
                    CLIENTE.cli_comunica_con = ""
                    CLIENTE.cli_comunica_tercero = ""


                Case 2 '_Cuerpo_MtvoLL
                    Cuerpo.TabPages.Add(_Cuerpo_MtvoLL)
                    CmbRealiza.SelectedIndex = 0
                    CLIENTE.CLI_INTERESA = ""
                    CLIENTE.CLI_PREEXISTENCIA = ""


                Case 3 '_Cuerpo_DatosCli
                    Cuerpo.TabPages.Add(_Cuerpo_DatosCli)
                    If perfil <> "Regrabador" Then

                        CLIENTE.cli_anombre = ""
                        CLIENTE.cli_apaterno = ""
                        CLIENTE.cli_amaterno = ""
                        CLIENTE.cli_arut = 0
                        CLIENTE.cli_adv = ""
                        CLIENTE.cli_afechanacimiento = ""
                        CLIENTE.CLI_AREAFONOCONTACTO = ""
                        CLIENTE.CLI_AFONOCONTACTO = ""
                        CLIENTE.cli_acelular = ""
                        CLIENTE.cli_aemail = ""
                        CLIENTE.cli_acalle = ""
                        CLIENTE.cli_anro = ""
                        CLIENTE.CLI_AREFERENCIA = ""
                        CLIENTE.CLI_ACODCOMUNA = ""
                        CLIENTE.CLI_ACODCIUDAD = ""
                        CLIENTE.cli_acomuna = ""
                        CLIENTE.cli_aciudad = ""
                        'CLIENTE.cli_tpocontrato = 0
                        CLIENTE.cli_primapesos = 0
                        CLIENTE.cli_primaPesos_total = 0
                        CLIENTE.cli_primaUf_total = ""
                    End If

                Case 4 '_Cuerpo_Mpago
                    CLIENTE.cli_acepta_cargo = ""
                    Cuerpo.TabPages.Add(_Cuerpo_MPago)

                Case 5 '_Cuerpo_InfAdicional
                    CLIENTE.CLI_INTERESA = ""
                    CLIENTE.CLI_PREEXISTENCIA = ""
                    Cuerpo.TabPages.Add(_Cuerpo_InfAdic)

                Case 6 '10 _Cuerpo_Certifica
                    Cuerpo.TabPages.Add(_Cuerpo_Certifica)
                    cmbAceptaPrima.SelectedIndex = 0
                    cmbAceptaContrato.SelectedIndex = 0
                    CLIENTE.cli_acepta_cargo = ""
                    CLIENTE.cli_acepta_prima = ""
                    CLIENTE.CLI_ACEPTA_CORREO = ""

                Case 7 '_Cuerpo_InfLL
                    Cuerpo.TabPages.Add(_Cuerpo_UltInfo)

                Case 9 '_Cuerpo_Adicionales
                    limpiaAdicionales()
                    Cuerpo.TabPages.Add(_Cuerpo_Adicionales)

                Case 10 '5 _Cuerpo_Objeciones
                    CLIENTE.CLI_OBSERVACION = ""
                    Cuerpo.TabPages.Add(_Cuerpo_Objeciones)

                Case 11 '6 _Cuerpo_Agendar
                    CLIENTE.cli_agen_estado = ""
                    Cuerpo.TabPages.Add(_Cuerpo_Agendar)

                Case 12 '9 _Cuerpo_Agenda2
                    CLIENTE.cli_agen_estado = ""
                    Cuerpo.TabPages.Add(_Cuerpo_Agenda2)

                Case 13 '8 _Cuerpo_FinNC
                    Cuerpo.TabPages.Add(_Cuerpo_FinNC)

            End Select
            Cuerpo.TabPages.Item(Cuerpo.SelectedIndex).Parent = Nothing
            ' bloquea el boton volver en caso de que este en la primera pantalla
            Me.CmdAtras.Enabled = pantallaAnterior > 1
        End If

    End Sub

    Private Sub CmdLlamar1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdLlamar1.Click
        If CmdLlamar1.Text = "LLAMAR" And Trim$(Txt_Fono1.Text) <> "" Then
            txtCallId.Text = ""
            WS_CALL_ID = ""
        End If
        LlamarFono(CmdLlamar1, Txt_Fono1, flg_fono1)
        Fono_A_Llamar = Txt_Fono1.Text
        lblNumero.Text = Txt_Fono1.Text
        lblIdNumero.Text = "1"

    End Sub
    Private Sub CmdLlamar2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdLlamar2.Click
        If CmdLlamar2.Text = "LLAMAR" And Trim$(Txt_Fono2.Text) <> "" Then
            txtCallId.Text = ""
            WS_CALL_ID = ""
        End If
        LlamarFono(CmdLlamar2, Txt_Fono2, flg_fono2)
        Fono_A_Llamar = Txt_Fono2.Text
        lblNumero.Text = Txt_Fono2.Text
        lblIdNumero.Text = "2"
    End Sub
    Private Sub CmdLlamar3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdLlamar3.Click
        If CmdLlamar3.Text = "LLAMAR" And Trim$(Txt_Fono3.Text) <> "" Then
            txtCallId.Text = ""
            WS_CALL_ID = ""
        End If
        LlamarFono(CmdLlamar3, Txt_Fono3, flg_fono3)
        Fono_A_Llamar = Txt_Fono3.Text
        lblNumero.Text = Txt_Fono3.Text
        lblIdNumero.Text = "3"
    End Sub
    Private Sub CmdLlamar4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdLlamar4.Click
        If CmdLlamar4.Text = "LLAMAR" And Trim$(Txt_Fono4.Text) <> "" Then
            txtCallId.Text = ""
            WS_CALL_ID = ""
        End If
        LlamarFono(CmdLlamar4, Txt_Fono4, flg_fono4)
        Fono_A_Llamar = Txt_Fono4.Text
        lblNumero.Text = Txt_Fono4.Text
        lblIdNumero.Text = "4"
    End Sub
    Private Sub CmdLlamar5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdLlamar5.Click
        If CmdLlamar5.Text = "LLAMAR" And Trim$(Txt_Fono5.Text) <> "" Then
            txtCallId.Text = ""
            WS_CALL_ID = ""
        End If
        LlamarFono(CmdLlamar5, Txt_Fono5, flg_fono5)
        Fono_A_Llamar = Txt_Fono5.Text
        lblNumero.Text = Txt_Fono5.Text
        lblIdNumero.Text = "5"
    End Sub
    Private Sub CmdLlamar6_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdLlamar6.Click
        If CmdLlamar6.Text = "LLAMAR" And Trim$(Txt_Fono6.Text) <> "" Then
            txtCallId.Text = ""
            WS_CALL_ID = ""
        End If
        LlamarFono(CmdLlamar6, Txt_Fono6, flg_fono6)
        Fono_A_Llamar = Txt_Fono6.Text
        lblNumero.Text = Txt_Fono6.Text
        lblIdNumero.Text = "6"
    End Sub
    Private Sub CmdLlamarAlt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdLlamarAlt.Click
        If CmdLlamarAlt.Text = "LLAMAR" And Trim$(Txt_Fono_alt.Text) <> "" Then
            txtCallId.Text = ""
            WS_CALL_ID = ""
        End If
        LlamarFono(CmdLlamarAlt, Txt_Fono_alt, flg_fonoalt)
        Fono_A_Llamar = Txt_Fono_alt.Text
        lblNumero.Text = Txt_Fono_alt.Text
        lblIdNumero.Text = "alt"
    End Sub
    Private Sub CmdLlamarVent_Click(sender As Object, e As EventArgs) Handles CmdLlamarVent.Click
        If CmdLlamarVent.Text = "LLAMAR" And Trim$(txt_FonoVenta.Text) <> "" Then
            txtCallId.Text = ""
            WS_CALL_ID = ""
        End If
        LlamarFono(CmdLlamarVent, txt_FonoVenta, flg_fonoVent)
        Fono_A_Llamar = txt_FonoVenta.Text
        lblNumero.Text = txt_FonoVenta.Text
        lblIdNumero.Text = "vent"
    End Sub


    Public Sub Corta_Anteriores()
        If CmdLlamar1.Text = "COLGAR" Then
            grabarCallId("CORTAR", WS_CALL_ID, (Txt_Fono1.Text), claveRegistroActual)
            cortarFonos(CmdLlamar1)

        End If
        If CmdLlamar2.Text = "COLGAR" Then
            grabarCallId("CORTAR", WS_CALL_ID, (Txt_Fono2.Text), claveRegistroActual)
            cortarFonos(CmdLlamar2)

        End If
        If CmdLlamar3.Text = "COLGAR" Then
            grabarCallId("CORTAR", WS_CALL_ID, (Txt_Fono3.Text), claveRegistroActual)
            cortarFonos(CmdLlamar3)

        End If
        If CmdLlamar4.Text = "COLGAR" Then
            grabarCallId("CORTAR", WS_CALL_ID, (Txt_Fono4.Text), claveRegistroActual)
            cortarFonos(CmdLlamar4)

        End If
        If CmdLlamar5.Text = "COLGAR" Then
            grabarCallId("CORTAR", WS_CALL_ID, (Txt_Fono5.Text), claveRegistroActual)
            cortarFonos(CmdLlamar5)

        End If
        If CmdLlamar6.Text = "COLGAR" Then
            grabarCallId("CORTAR", WS_CALL_ID, (Txt_Fono6.Text), claveRegistroActual)
            cortarFonos(CmdLlamar6)

        End If
        If CmdLlamarAlt.Text = "COLGAR" Then
            grabarCallId("CORTAR", WS_CALL_ID, (Txt_Fono_alt.Text), claveRegistroActual)
            cortarFonos(CmdLlamarAlt)

        End If
        If CmdLlamarVent.Text = "COLGAR" Then
            grabarCallId("CORTAR", WS_CALL_ID, (txt_FonoVenta.Text), claveRegistroActual)
            cortarFonos(CmdLlamarVent)

        End If

    End Sub
    ''' <summary>
    ''' procedimiento para buscar cliente en la tabla cli
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Buscar_Cliente()
        Call Corta_Anteriores()
        Dim Tabla As New Data.DataTable

        Tabla = biCliente.Buscar_cliente(WS_IDUSUARIO) 'SI NO HAY NINGUN REGISTRO A EVALUAR SE TERMINA LA APLICACION
        If Tabla.Rows.Count <= 0 Then
            End
        End If

        For x As Integer = 0 To Tabla.Rows.Count - 1
            claveRegistroActual = Tabla.Rows(x)("CLI_ID")
        Next

        ' respaldar el estado en que venia el registro
        strQueryUpdateBackupRs = generarQueryBackupRs(Tabla, claveRegistroActual)

        CLIENTE = inicializarCliente(Tabla.Rows(0))

        flg_progresivo_activado = True

        lblEstadoLlamada.Text = ""
        WS_CALL_ID = ""
        txtCallId.Text = ""

        Txt_Fono1.Text = Trim(CLIENTE.cli_telefono1)
        flg_fono1 = Not esVacio(CLIENTE.cli_telefono1)
        flg_EsCelu1 = esCelular(CLIENTE.cli_telefono1)

        Txt_Fono2.Text = Trim(CLIENTE.cli_telefono2)
        flg_fono2 = Not esVacio(CLIENTE.cli_telefono2)
        flg_EsCelu2 = esCelular(CLIENTE.cli_telefono2)

        Txt_Fono3.Text = Trim(CLIENTE.cli_telefono3)
        flg_fono3 = Not esVacio(CLIENTE.cli_telefono3)
        flg_EsCelu3 = esCelular(CLIENTE.cli_telefono3)

        Txt_Fono4.Text = Trim(CLIENTE.cli_telefono4)
        flg_fono4 = Not esVacio(CLIENTE.cli_telefono4)
        flg_EsCelu4 = esCelular(CLIENTE.cli_telefono4)

        Txt_Fono5.Text = Trim(CLIENTE.cli_telefono5)
        flg_fono5 = Not esVacio(CLIENTE.cli_telefono5)
        flg_EsCelu5 = esCelular(CLIENTE.cli_telefono5)

        Txt_Fono6.Text = Trim(CLIENTE.cli_telefono6)
        flg_fono6 = Not esVacio(CLIENTE.cli_telefono6)
        flg_EsCelu6 = esCelular(CLIENTE.cli_telefono6)

        Txt_Fono_alt.Text = Trim(CLIENTE.cli_telefonoalt)
        flg_fonoalt = Not esVacio(CLIENTE.cli_telefonoalt)
        flg_EsCeluAlt = esCelular(CLIENTE.cli_telefonoalt)

        inicializarControles()
        'llamarProgresivoFijo()
        llamarProgresivo()
        cargaCamposAdic()

    End Sub

    Private Sub cargaCamposAdic()
        Dim ListaCamposAdic As New List(Of eCampoAdicional)
        Dim BiCampoAdic As New clsCampoAdicionalBI
        Dim style As New DataGridViewCellStyle

        ListaCamposAdic = BiCampoAdic.BuscaDatosCampoAdicional(vgCampania.calCodigo, CLIENTE.cli_id)
        dtgCamposAdicionales.DataSource = ListaCamposAdic
        dtgCamposAdicionales.Columns(0).Visible = False
        dtgCamposAdicionales.Columns(3).Visible = False
        dtgCamposAdicionales.Columns(4).Visible = False
        dtgCamposAdicionales.Columns(5).Visible = False
        dtgCamposAdicionales.Columns(6).Visible = False

        dtgCamposAdicionales.ColumnHeadersVisible = False
        dtgCamposAdicionales.RowHeadersVisible = False

        dtgCamposAdicionales.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        dtgCamposAdicionales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        style.Font = New Font(dtgCamposAdicionales.Font, FontStyle.Bold)
        dtgCamposAdicionales.Columns(1).DefaultCellStyle = style
        dtgCamposAdicionales.BorderStyle = BorderStyle.Fixed3D
        dtgCamposAdicionales.BackgroundColor = Color.White

    End Sub

    Public Sub cortarFonos(ByRef cmdBoton As System.Windows.Forms.Button, Optional ByRef ConGestion As Boolean = True)
        Dim respuesta As Short
        If Not colgar(ConGestion) Then MsgBox("Se ha detectado un problema al intentar colgar los fonos activos!", MsgBoxStyle.Exclamation, "CALLSOUTH")
        Select Case db_central
            Case 1, 3
                If txtCallId.Text <> "" Then
                    If ConGestion = False Then
                        respuesta = MsgBox("¿La llamada realizada fue venta?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Responder")
                        If respuesta = 6 Then
                            Botones(False)
                        End If
                    Else
                        If CDbl(CLIENTE.cli_venta) = 1 Then
                            respuesta = 6
                        End If
                    End If
                    Tiempo(respuesta)
                    cmdBoton.Text = "LLAMAR"
                    cmdBoton.BackColor = System.Drawing.ColorTranslator.FromOle(&H8000000F)

                    EstadoFono.lblNumero.Text = lblNumero.Text
                    EstadoFono.lblIdNumero.Text = lblIdNumero.Text
                    EstadoFono.ShowDialog()
                End If
            Case 2, 4
                cmdBoton.Text = "LLAMAR"
                cmdBoton.BackColor = System.Drawing.ColorTranslator.FromOle(&H8000000F)

                EstadoFono.lblNumero.Text = lblNumero.Text
                EstadoFono.lblIdNumero.Text = lblIdNumero.Text
                EstadoFono.ShowDialog()
        End Select

    End Sub
    '*******INICIALIZAMOS LOS CONTROLES PARA REGRABACION***********
    ''' <summary>
    ''' INICIALIZAMOS LOS CONTROLES PARA REGRABACION
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub inicializarControlesGes()

        Try
            Txtid.Text = CLIENTE.cli_id
            Txt_Nombre.Text = CLIENTE.cli_anombre + " " + CLIENTE.CLI_ANOMBRE2 + " " + CLIENTE.cli_apaterno + " " + CLIENTE.cli_amaterno
            TxtRut.Text = CLIENTE.cli_arut + "-" + CLIENTE.cli_adv
            TxtDireccion.Text = CLIENTE.cli_acalle + " " + CLIENTE.cli_anro + " " + CLIENTE.CLI_AREFERENCIA
            TxtNacimiento.Text = Format(Trim(CLIENTE.cli_fechanacimiento), "Short Date")
            TxtDatos.Text = Trim(CLIENTE.cli_codverificacion)
            txtIntentos.Text = CLIENTE.cli_intentos
            txtObs.Text = LTrim(CLIENTE.cli_agen_obs)
            Label36.Visible = False
            ComboBoxReconoce.Visible = False

            TxtObsA.Text = ""
            TxtObsAgen2.Text = ""

            If Trim(CLIENTE.cli_fechanacimiento) <> "" Then
                TxtNacimiento.Text = Mid(CLIENTE.cli_fechanacimiento, 7, 2) & "-" & Mid(CLIENTE.cli_fechanacimiento, 5, 2) & "-" & Mid(CLIENTE.cli_fechanacimiento, 1, 4)
                CLIENTE.cli_edad = CStr(edad(CDate(Mid(CLIENTE.cli_fechanacimiento, 7, 2) & "-" & Mid(CLIENTE.cli_fechanacimiento, 5, 2) & "-" & Mid(CLIENTE.cli_fechanacimiento, 1, 4))))
                dtFechaNac.Value = CDate(Mid(CLIENTE.cli_fechanacimiento, 7, 2) & "-" & Mid(CLIENTE.cli_fechanacimiento, 5, 2) & "-" & Mid(CLIENTE.cli_fechanacimiento, 1, 4))
            Else
                dtFechaNac.Value = DateAdd(DateInterval.Year, -30, DateAdd(DateInterval.Day, 1, Now))
            End If

            TxtEdad.Text = CLIENTE.cli_edad
            txt_FonoVenta.Visible = True
            lbFonoVenta.Visible = True
            CmdLlamarVent.Visible = True

            '****inicializamos las variables con la fecha y hora actuales*******
            CLIENTE.cli_fecha = Today.ToString("yyyyMMdd")
            CLIENTE.cli_hora = TimeOfDay.ToString("HHmmss")
            CLIENTE.cli_agente = WS_IDUSUARIO
            inicializar_controles_tab()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Exclamation, csNombreAplicacion)
        End Try

        cargaCamposAdic()

    End Sub

    '********* FIN CAMPO ADICIONALES ***********

    Public Sub AsiganaCamposAdicionales()

        'MUESTRA LOS CAMPOS ADICIONALES CONFIGURADOS EN LA CAMPAÑA

        Dim biCampoAdicional As New clsCampoAdicionalBI
        Dim listCampoAdicional As New List(Of eCampoAdicional)
        listCampoAdicional = biCampoAdicional.BuscaDatosCampoAdicional(vgCampania.calCodigo, CLIENTE.cli_id)

    End Sub


    '*******INICIALIZAMOS LOS CONTROLES VENTA***********
    ''' <summary>
    ''' INICIALIZAMOS LOS CONTROLES VENTA
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub inicializarControles()

        txtObs.Text = "" : txtIntentos.Text = ""
        Txt_Nombre.Text = ""
        Txtid.Text = Trim(CLIENTE.cli_id)
        TxtRut.Text = Mid(CLIENTE.cli_rut, 1, 4)
        'Dim nombre = ""
        'Dim apellido = ""
        'Dim index As Integer = Trim(CLIENTE.cli_nombre).IndexOf(" "c)
        'If (index = -1) Then
        '    ' No existe ningún espacio en blanco;
        '    nombre = Trim(CLIENTE.cli_nombre)
        '    apellido = String.Empty

        'Else
        '    ' Obtenemos el nombre
        '    nombre = Trim(CLIENTE.cli_nombre).Substring(0, index)

        '    ' Obtenemos el apellido
        '    apellido = Trim(CLIENTE.cli_nombre).Substring(index + 1, Trim(CLIENTE.cli_nombre).Length - index - 1)

        'End If
        Txt_Nombre.Text = CLIENTE.cli_nombre

        Txt_Nombre.Text = CLIENTE.cli_nombre & " " & Trim(CLIENTE.cli_paterno) & " " & Trim(CLIENTE.cli_materno)
        'Txt_Nombre.Text = Trim(CLIENTE.cli_nombre) & " " & Trim(CLIENTE.cli_paterno) & " " & Trim(CLIENTE.cli_materno)

        TxtDatos.Text = CLIENTE.cli_codverificacion

        If CLIENTE.cli_sexo = "M" Then
            CmbSexo.SelectedIndex = 1
        ElseIf CLIENTE.cli_sexo = "F" Then
            CmbSexo.SelectedIndex = 2
        Else
            CmbSexo.SelectedIndex = 0
        End If

        valorPesosUf = CInt(biGeneral.Buscar_Uf)

        TxtDireccion.Text = Trim(CLIENTE.cli_direccion)
        TxtNacimiento.Text = Format(Trim(CLIENTE.cli_fechanacimiento), "Short Date")

        txtIntentos.Text = CStr(CShort(Val(CLIENTE.cli_intentos)))
        'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If (Len(Trim(IIf(IsDBNull(CLIENTE.cli_agen_obs) = True, "", Trim(CLIENTE.cli_agen_obs)))) > 0) Then
            txtObs.Text = Trim(CLIENTE.cli_agen_obs) & " " & CLIENTE.CLI_NUMTARJETA_3
        End If

        CLIENTE.cli_fecha = Today.ToString("yyyyMMdd")
        CLIENTE.cli_hora = TimeOfDay.ToString("HHmmss")

        CLIENTE.cli_agente = Trim(WS_IDUSUARIO)
        CLIENTE.cli_ip_agente = Trim(usuario_actual.IP)
        Fono_A_Llamar = ""

        If Trim(CLIENTE.cli_fechanacimiento) <> "" Then
            TxtNacimiento.Text = Mid(CLIENTE.cli_fechanacimiento, 7, 2) & "-" & Mid(CLIENTE.cli_fechanacimiento, 5, 2) & "-" & Mid(CLIENTE.cli_fechanacimiento, 1, 4)
            CLIENTE.cli_edad = CStr(edad(CDate(Mid(CLIENTE.cli_fechanacimiento, 7, 2) & "-" & Mid(CLIENTE.cli_fechanacimiento, 5, 2) & "-" & Mid(CLIENTE.cli_fechanacimiento, 1, 4))))
            dtFechaNac.Value = CDate(Mid(CLIENTE.cli_fechanacimiento, 7, 2) & "-" & Mid(CLIENTE.cli_fechanacimiento, 5, 2) & "-" & Mid(CLIENTE.cli_fechanacimiento, 1, 4))
        Else
            dtFechaNac.Value = DateAdd(DateInterval.Year, -30, DateAdd(DateInterval.Day, 1, Now))
        End If
        TxtEdad.Text = Trim(CLIENTE.cli_edad)
        txtObs.Text = Trim(CLIENTE.cli_agen_obs)

        If perfil = "Regrabador" Then
            Txt_Fono_alt.ReadOnly = False
        Else
            Txt_Fono_alt.ReadOnly = True
        End If

        inicializar_controles_tab()
    End Sub
    ' inicializar controles de gestion en todos los tabs utilizados
    ''' <summary>
    ''' inicializar controles de gestion en todos los tabs utilizados
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub inicializar_controles_tab()

        ' >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        'TAB 1
        CmbConecta.Focus()
        CmbConecta.SelectedIndex = 0
        CmbNoConecta.SelectedIndex = 0
        CmbComunicaCon.SelectedIndex = 0
        CmbComunicaTercero.SelectedIndex = 0
        Label11.Visible = False
        CmbNoConecta.Visible = False
        FrmConex.Visible = False
        Label13.Visible = False
        CmbComunicaTercero.Visible = False


        'TAB 2

        LblCCli.Visible = True
        CmbRealiza.SelectedIndex = 0
        CmbRealiza.Visible = True

        'TAB 3

        txtNombre.Text = ""
        txtPaterno.Text = ""
        txtMaterno.Text = ""
        txtArut.Text = ""
        txtDv.Text = ""
        txtCelular.Text = ""
        txtEmail.Text = ""
        txtCalle.Text = ""
        txtNro.Text = ""
        txtReferencia.Text = ""
        txtFonoVenta.Text = ""

        'cmbTipoContrato.SelectedIndex = 0
        If perfil <> "Regrabador" Then
            cmbPlan.SelectedIndex = -1
            If dtAdicional.Rows.Count > 0 Then
                dtAdicional.Rows.Clear()
            End If

        End If
        CmbAutorizaCorreo.SelectedIndex = 0
        cmbComuna.SelectedIndex = -1
        cmbComuna.SelectedText = ""
        cmbCiudad.SelectedIndex = -1
        cmbCiudad.SelectedText = ""
        cmbCiudad.SelectedText = ""
        cmbCiudad.DataSource = Nothing
        cmbCiudad.ValueMember = Nothing

        'TAB 4
        txtNombreA.Text = ""
        txtPaternoA.Text = ""
        txtMaternoA.Text = ""
        txtRutA.Text = ""
        txtDvA.Text = ""
        cmbParentescoAdic.SelectedIndex = -1
        dtFechaNacAdic.Value = dtFechaNac.MinDate
        dtFechaNacAdic.MaxDate = DateAdd(DateInterval.Day, -6, Now)




        'TAB 5
        CmbObj.SelectedIndex = 0
        FrmObj.Visible = False
        TxtObj.Text = ""
        If perfil = "Regrabador" Then
            Label26.Visible = False
            cmbNoIntereso.Visible = False
        End If


        'TAB 6
        CmbEstAgenda.SelectedIndex = -1
        FrmAgendamiento.Visible = False
        TxtObsA.Text = ""
        DTFechaAgen.Value = Today
        cmbHora.SelectedIndex = -1
        cmbMin.SelectedIndex = -1
        CmdTerminarA.Visible = True
        CmdSiguienteA.Visible = True



        'TAB 9
        TxtObsAgen2.Text = ""
        DTAgenFecha2.Value = Today
        CmbHora2.SelectedIndex = -1
        CmbMin2.SelectedIndex = -1

        'TAB 10
        cmbAceptaPrima.SelectedIndex = -1
        cmbAceptaContrato.SelectedIndex = -1
        lblCargoTarjeta.Visible = True
        lblAcepta.Visible = True
        cmbAceptaPrima.Visible = True
        cmbAceptaContrato.Visible = True
        Panelotro.Visible = False
        txtNumeroCta.Text = ""
        cmbMedioPago.SelectedIndex = -1
        cmbMes.SelectedIndex = -1
        cmbAnio.SelectedIndex = -1


        ' inicializar pila para guardar pantallas visitadas
        ' >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        pilaInicializar()
        CmdAtras.Enabled = False
        ' (ocultar todos los tabs menos el del inicio)
        Dim i As Integer
        i = Cuerpo.TabCount - 1
        For i = i To 1 Step -1
            Cuerpo.TabPages.Item(i).Parent = Nothing
        Next i
        If Cuerpo.TabPages.Item(0).Name <> "_Cuerpo_Conex" Then
            Cuerpo.TabPages.Item(0).Parent = Nothing
            Cuerpo.TabPages.Add(_Cuerpo_Conex)
        End If


        Cuerpo.Visible = True
    End Sub
    '***********metodo de boton salir de la aplicacion****************
    Private Sub CmdSalir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSalir.Click
        Try
            If MsgBox("¿Está seguro que desea salir de la aplicación?", MsgBoxStyle.YesNo, "CALLSOUTH") = MsgBoxResult.Yes Then
                grabarCallId("CORTAR", WS_CALL_ID, Fono_A_Llamar, claveRegistroActual)


                If Cuerpo.TabPages.Item(0).Name <> "_Cuerpo_IngresoCli" Then
                    If perfil <> "Regrabador" Then
                        Dim x As UInteger
                        x = Convert.ToUInt32(claveRegistroActual)
                        biGeneral.respladar_estado(strQueryUpdateBackupRs, x)
                    End If

                End If
                Logear_Usuario(WS_IDUSUARIO, 2)
                If db_central = 4 Then
                    vpPosicion.LogoutTelefonia((vpPosicion.Usuario))
                End If
                End
            End If

        Catch ex As Exception
            MsgBox(Err.Description & " " & " Error : al salir de la aplicación", MsgBoxStyle.Critical, Me.Text)
            Err.Clear()
        End Try

    End Sub
    ''' <summary>
    ''' Metodo para registrar una venta al cual al cliente no se ha contactado y se da por terminada la gestion
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Terminar()

        CLIENTE.cli_estado = "T"
        CLIENTE.cli_venta = CStr(0)

        If perfil <> "Regrabador" Then

            CLIENTE.cli_call_id = WS_CALL_ID
            biCliente.GuardaDatosCliente(CLIENTE)
            biCliente.GuardaDatosLog(claveRegistroActual)
            MsgBox("Fin de la gestión. Presione ACEPTAR para continuar con el siguiente registro.", MsgBoxStyle.Information, "CALLSOUTH")
            limpiarPrimeraPantalla()
            Buscar_Cliente()
        Else
            CLIENTE.CLI_ESTADO_OBJECION_CALIDAD = 5
            CLIENTE.CLI_SEGUNDO_ESTADO_CALIDAD = "N"
            CLIENTE.CLI_CALL_ID_CALIDAD = Mid(WS_CALL_ID, 1, 10)
            CLIENTE.cli_fechavta = ""
            CLIENTE.cli_horavta = ""
            biGesRes.GuardaClienteGes(CLIENTE, vgCampania.calCodigo)
            biGesRes.ActualizaCteSinVta(CLIENTE.CLI_SEGUNDO_ESTADO_CALIDAD, CLIENTE.CLI_ESTADO_OBJECION_CALIDAD, CLIENTE.CLI_CALL_ID_CALIDAD, CLIENTE.cli_id)
            biCliente.GuardaDatosLog(CLIENTE.cli_id)
            biGesRes.GrabaAsignaCalidad(CLIENTE.cli_id, vgCampania.calCodigo, CLIENTE.cli_agente, CLIENTE.cli_fecha, 2, WS_IDUSUARIO)

            MsgBox("Fin de la gestión. Presione ACEPTAR para salir del formulario.", MsgBoxStyle.Information, csNombreAplicacion)
            limpiarPrimeraPantalla()
            Me.Hide()
            frmRegrabaciones.ShowDialog()
            BuscaGes()

        End If
    End Sub
    '******************Metodo al presionar boton Siguiente de tab Conexion****************************************************************
    Private Sub CmdSiguiente_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSiguiente.Click

        If Trim$(txtCallId.Text) = "" Then
            vpPosicion.CargarPosicion(vpPosicion.Usuario)
            txtCallId.Text = vpPosicion.IDLLAMADA
            WS_CALL_ID = vpPosicion.IDLLAMADA
        End If

        Select Case CmbConecta.SelectedIndex
            Case -1, 0
                MsgBox("Debe selecionar opción si conecta llamada.", vbInformation, "Callsouth.")
                CmbConecta.Focus()
                Exit Sub

            Case 1

                Select Case CmbComunicaCon.SelectedIndex
                    '0 [No Especificado]
                    '1 COMUNICA CON CLIENTE
                    '2 COMUNICA CON TERCERO VALIDO
                    '3 COMUNICA CON REGISTRO NO VALIDO (NO VIVE/NO TRABAJA AHI)

                    Case -1, 0
                        MsgBox("debe seleccionar con quien se comunica.", vbExclamation, "Callsouth.")
                        CmbComunicaCon.Focus()
                        Exit Sub

                    Case 1
                        CLIENTE.cli_conecta = Trim$(CmbConecta.Text)
                        CLIENTE.cli_comunica_con = Trim$(CmbComunicaCon.Text)

                        If perfil = "Regrabador" Then
                            ComboBoxReconoce.Visible = True
                            Label36.Visible = True
                        Else
                            ComboBoxReconoce.Visible = False
                            Label36.Visible = False
                        End If

                        clsScript = CargaScript(2)
                        wbScriptPresentacion.DocumentText = clsScript.contenidoScript

                        Cuerpo.TabPages.Add(_Cuerpo_MtvoLL)
                        Cuerpo.TabPages.Item(0).Parent = Nothing
                        guardarPantallaAnterior(1)

                    Case 3
                        CLIENTE.cli_conecta = Trim$(CmbConecta.Text)
                        CLIENTE.cli_comunica_con = Trim$(CmbComunicaCon.Text)

                        If perfil = "Regrabador" Then
                            CLIENTE.CLI_ESTADO_OBJECION_CALIDAD = 5 'no contactado para regrabacion                            
                        End If

                        LblFinNoC.Text = ScriptLblFinNoC()
                        Cuerpo.TabPages.Add(_Cuerpo_FinNC)
                        Cuerpo.TabPages.Item(0).Parent = Nothing
                        guardarPantallaAnterior(1)

                    Case 2

                        Select Case CmbComunicaTercero.SelectedIndex
                            '0  [No Especificado]
                            '1  TERCERO PIDE DEJAR PENDIENTE
                            '2  VIAJE
                            '3  FALLECIDO
                            '4  NO VIVE AHÍ
                            '5  PROBLEMA POR HORARIO
                            '6  NO DESEA CONTESTAR

                            Case -1, 0
                                MsgBox("Debe seleecionar motivo No comunica.", vbExclamation, "Callsouth.")
                                CmbComunicaTercero.Focus()
                                Exit Sub

                            Case 1, 2, 5
                                CLIENTE.cli_conecta = Trim$(CmbConecta.Text)
                                CLIENTE.cli_comunica_con = Trim$(CmbComunicaCon.Text)
                                CLIENTE.cli_comunica_tercero = Trim$(CmbComunicaTercero.Text)
                                Cuerpo.TabPages.Add(_Cuerpo_Agendar)
                                Cuerpo.TabPages.Item(0).Parent = Nothing
                                guardarPantallaAnterior(1)

                            Case 3, 4, 6
                                If perfil = "Regrabador" Then
                                    CLIENTE.CLI_ESTADO_OBJECION_CALIDAD = 5 'no contactado para regrabacion                                    
                                End If
                                CLIENTE.cli_conecta = Trim$(CmbConecta.Text)
                                CLIENTE.cli_comunica_con = Trim$(CmbComunicaCon.Text)
                                CLIENTE.cli_comunica_tercero = Trim$(CmbComunicaTercero.Text)

                                LblFinNoC.Text = ScriptLblFinNoC()
                                Cuerpo.TabPages.Add(_Cuerpo_FinNC)
                                Cuerpo.TabPages.Item(0).Parent = Nothing
                                guardarPantallaAnterior(1)
                        End Select
                End Select

            Case 2
                '0[No Especificado]
                '1 OCUPADO
                '2 FUERA DE SERVICIO
                '3 BUZÓN DE VOZ
                '4 NÚMERO NO VÁLIDO
                '5 NO CONTESTA
                '6 FAX O MODEM
                '7 CONGESTIONADO
                '8 FUERA DE ÁEREA O APAGADO

                Select Case CmbNoConecta.SelectedIndex
                    Case -1, 0
                        MsgBox("Debe seleccionar el motivo por el cual No Conecta.", vbExclamation, "Callsouth.")
                        CmbNoConecta.Focus()
                        Exit Sub

                    Case 1, 3, 5, 7, 8

                        CLIENTE.cli_conecta = Trim$(CmbConecta.Text)
                        CLIENTE.cli_no_conecta = Trim$(CmbNoConecta.Text)

                        If perfil = "Regrabador" Then
                            Cuerpo.TabPages.Add(_Cuerpo_Agendar)
                        Else
                            Cuerpo.TabPages.Add(_Cuerpo_Agenda2)
                        End If

                        Cuerpo.TabPages.Item(0).Parent = Nothing
                        guardarPantallaAnterior(1)

                    Case 2, 4, 6
                        CLIENTE.cli_conecta = Trim$(CmbConecta.Text)
                        CLIENTE.cli_no_conecta = Trim$(CmbNoConecta.Text)
                        Terminar()
                End Select
        End Select

    End Sub
    '************************************METODO DE BOTON SIGUIENTE TAB MOTIVO LLAMADO******************************
    Private Sub CmdSiguiente1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSiguiente1.Click

        If db_central = 4 And Trim(txtCallId.Text) = "" Then
            vpPosicion.CargarPosicion((vpPosicion.Usuario))
            txtCallId.Text = vpPosicion.IDLLAMADA
            WS_CALL_ID = vpPosicion.IDLLAMADA
        End If
        If perfil <> "Regrabador" Then

            '0 [No Especificado]
            '1 Interesa
            '2 No Interesa
            '3 Lo Pensara
            Select Case CmbRealiza.SelectedIndex
                Case 0, -1
                    MsgBox("Selecione opción si cliente interesa Seguro", MsgBoxStyle.Exclamation, csNombreAplicacion)
                    CmbRealiza.Focus()
                    Exit Sub
                Case 1

                    'Si
                    CLIENTE.cli_interesa_seg = Trim(CmbRealiza.Text)
                    Cuerpo.TabPages.Add(_Cuerpo_DatosCli)
                    Cuerpo.TabPages.Item(0).Parent = Nothing
                    llenar_planes()
                    cmbPlan.Visible = False
                    lblPlanes.Visible = False
                    btnAdicional.Visible = False
                    btnBeneficiarios.Visible = False
                    AsignadatosCli()
                    guardarPantallaAnterior(2)

                Case 2 ' NO
                    CLIENTE.cli_interesa_seg = Trim(CmbRealiza.Text)
                    Cuerpo.TabPages.Add(_Cuerpo_Objeciones)
                    Cuerpo.TabPages.Item(0).Parent = Nothing
                    guardarPantallaAnterior(2)

                Case 3 'lo pensara

                    CLIENTE.cli_interesa_seg = Trim(CmbRealiza.Text)
                    Cuerpo.TabPages.Add(_Cuerpo_Agenda2)
                    Cuerpo.TabPages.Item(0).Parent = Nothing
                    guardarPantallaAnterior(2)
            End Select
        Else

            Select Case ComboBoxReconoce.SelectedIndex
                '0 [No Especificado]
                '1 Si
                '2 No
                Case -1, 0
                    MsgBox("Selecione si cliente reconoce la venta", vbExclamation, "Callsouth.")
                    ComboBoxReconoce.Focus()
                    Exit Sub
                Case 1
                    CLIENTE.cli_interesa_seg = CmbRealiza.Text
                    Select Case CmbRealiza.SelectedIndex
                        Case -1, 0
                            MsgBox("Selecione si cliente acepta seguro", vbExclamation, "Callsouth.")
                            CmbRealiza.Focus()
                            Exit Sub
                        Case 1
                            CLIENTE.cli_interesa_seg = CmbRealiza.Text
                            Cuerpo.TabPages.Add(_Cuerpo_DatosCli)
                            Cuerpo.TabPages.Item(0).Parent = Nothing
                            llenar_planes()
                            AsignadatosCliGes()
                            guardarPantallaAnterior(2)

                        Case 2 'no interesa
                            CLIENTE.CLI_ESTADO_OBJECION_CALIDAD = 3
                            CLIENTE.cli_interesa_seg = CmbRealiza.Text
                            Cuerpo.TabPages.Add(_Cuerpo_Objeciones)
                            Cuerpo.TabPages.Item(0).Parent = Nothing
                            guardarPantallaAnterior(2)

                        Case 3 'Lo pensara
                            CLIENTE.cli_interesa_seg = CmbRealiza.Text
                            Cuerpo.TabPages.Add(_Cuerpo_Agenda2)
                            Cuerpo.TabPages.Item(0).Parent = Nothing
                            guardarPantallaAnterior(2)

                    End Select
                        

                Case 2
                    CLIENTE.CLI_ESTADO_OBJECION_CALIDAD = 7
                    CLIENTE.CLI_RECONOCEVTA = ComboBoxReconoce.Text
                    Cuerpo.TabPages.Add(_Cuerpo_Objeciones)
                    Cuerpo.TabPages.Item(0).Parent = Nothing
                    guardarPantallaAnterior(2)

            End Select
        End If
    End Sub

    ''' <summary>
    ''' metodo para hacer visible ciertos controles de el tab Motivo de llamado cuando el perfil sea de regrabador
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ocultar_cmbopcion()
        ComboBoxReconoce.Visible = True
        Label36.Visible = True
    End Sub
    '******************metodo de boton siguiente tab manejo de objeciones ***************************************
    Private Sub CmdSiguiente11_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSiguiente11.Click
        If perfil <> "Regrabador" Then
            If cmbNoIntereso.SelectedIndex <= 0 Then
                MsgBox("Seleccione porque el cliente No desea contratar seguro.", MsgBoxStyle.Exclamation, csNombreAplicacion)
                cmbNoIntereso.Focus()
                Exit Sub
            Else
                CLIENTE.cli_nointereso = cmbNoIntereso.Text
            End If

            If CmbObj.SelectedIndex <= 0 Then
                MsgBox("Debe ingresar observacion", MsgBoxStyle.Exclamation, csNombreAplicacion)
                CmbObj.Focus()
            Else
                CLIENTE.cli_aobsmtvo_nointeresa = TxtObj.Text
                CLIENTE.cli_mtvo_nocontrata = CmbObj.Text
                LblFinNoC.Text = ScriptLblFinNoC()
                Cuerpo.TabPages.Add(_Cuerpo_FinNC)
                Cuerpo.TabPages.Item(0).Parent = Nothing
                guardarPantallaAnterior(10)
            End If
        Else

            If CmbObj.SelectedIndex <= 0 Then
                MsgBox("Debe ingresar observacion", MsgBoxStyle.Exclamation, csNombreAplicacion)
                CmbObj.Focus()
            Else
                CLIENTE.CLI_OBSERVACION = TxtObj.Text
                CLIENTE.cli_mtvo_nocontrata = CmbObj.Text
                LblFinNoC.Text = ScriptLblFinNoC()
                Cuerpo.TabPages.Add(_Cuerpo_FinNC)
                Cuerpo.TabPages.Item(0).Parent = Nothing
                guardarPantallaAnterior(10)
            End If
        End If

    End Sub


    '********************metodo de boton siguiente de tab toma de datos********************************
    Private Sub CmdSiguiente2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSiguiente2.Click
        If db_central = 4 And Trim(txtCallId.Text) = "" Then
            vpPosicion.CargarPosicion((vpPosicion.Usuario))
            txtCallId.Text = vpPosicion.IDLLAMADA
            WS_CALL_ID = vpPosicion.IDLLAMADA
        End If

        If ValidaInformacion() Then



            If perfil <> "Regrabador" Then

                CLIENTE.cli_anombre = Trim(Replace(Trim(UCase(txtNombre.Text)), "'", "´"))
                CLIENTE.cli_anombre2 = Trim(Replace(Trim(UCase(txtNombre2.Text)), "'", "´"))
                CLIENTE.cli_apaterno = Trim(Replace(Trim(UCase(txtPaterno.Text)), "'", "´"))
                CLIENTE.cli_amaterno = Trim(Replace(Trim(UCase(txtMaterno.Text)), "'", "´"))

                CLIENTE.cli_afechanacimiento = dtFechaNac.Value.ToString("yyyyMMdd")
                CLIENTE.cli_arut = Trim(txtArut.Text)
                CLIENTE.cli_adv = Trim(txtDv.Text)
                CLIENTE.cli_codverificacion = "799927" + CLIENTE.cli_arut.Substring(CLIENTE.cli_arut.Length - 4) & CLIENTE.cli_adv

                CLIENTE.cli_asexo = CmbSexo.Text
                CLIENTE.CLI_ACEPTA_CORREO = CmbAutorizaCorreo.Text

                CLIENTE.cli_aareafonovta = ""
                CLIENTE.cli_afonovta = Trim(txtFonoVenta.Text)

                CLIENTE.cli_acelular = Trim(txtCelular.Text)
                CLIENTE.CLI_AFONOCONTACTO = Trim(txtCelular.Text)
                If txtEmail.Text = "" Then
                    CLIENTE.cli_aemail = ""
                Else
                    CLIENTE.cli_aemail = Replace(Trim(txtEmail.Text), "'", "´")
                End If

                CLIENTE.cli_acalle = Trim(UCase(Replace(txtCalle.Text, "'", "`")))
                CLIENTE.cli_anro = Trim(Replace(txtNro.Text, "'", "`"))
                If txtReferencia.Text = "" Then
                    CLIENTE.CLI_AREFERENCIA = ""
                Else
                    CLIENTE.CLI_AREFERENCIA = Trim$(Replace(txtReferencia.Text, "'", "`"))
                End If

                'COMUNA CIUDAD REGION
                Dim daCiudad As New clsCiudadBI
                Dim eCiudad As New eCiudad
                CLIENTE.CLI_ACODCOMUNA = cmbComuna.SelectedValue
                CLIENTE.cli_acomuna = Trim(cmbComuna.Text)
                CLIENTE.CLI_ACODCIUDAD = cmbCiudad.SelectedValue
                CLIENTE.cli_aciudad = Trim(cmbCiudad.Text)

                'PLANES Y TIPO DE CONTRATO|
                Dim ePlan As New ePlan
                ePlan = biClsPlan.BuscarPlanPorIdPlan(cmbPlan.SelectedValue)
                CLIENTE.cli_primauf = ePlan.primaUF
                CLIENTE.cli_primapesos = ePlan.primaCalculada
                CLIENTE.cli_plan = ePlan.idPlan
                CLIENTE.cli_tpocontrato = ePlan.idTipoContrato
                CLIENTE.cli_primaPesos_total = CInt(Math.Round(TotalPesos))
                CLIENTE.cli_primaUf_total = totalUfAdic.ToString("0.00")

            Else
                CLIENTE.cli_anombre = Replace(Trim(UCase(txtNombre.Text)), "'", "´")
                CLIENTE.cli_anombre2 = Replace(Trim(UCase(txtNombre2.Text)), "'", "´")
                CLIENTE.cli_apaterno = Replace(Trim(UCase(txtPaterno.Text)), "'", "`")
                CLIENTE.cli_amaterno = Replace(Trim(UCase(txtMaterno.Text)), "'", "`")
                CLIENTE.cli_arut = Trim(txtArut.Text)
                CLIENTE.cli_adv = Trim(txtDv.Text)
                CLIENTE.cli_afechanacimiento = dtFechaNac.Value.ToString("yyyyMMdd")
                CLIENTE.cli_asexo = Trim(CmbSexo.Text)
                CLIENTE.CLI_ACEPTA_CORREO = Trim(CmbAutorizaCorreo.Text)
                CLIENTE.cli_acalle = Trim(UCase(Replace(txtCalle.Text, "'", "`")))
                CLIENTE.cli_anro = Trim(Replace(txtNro.Text, "'", "`"))
                CLIENTE.cli_acelular = Trim(txtCelular.Text)
                CLIENTE.cli_acomuna = Trim(cmbComuna.Text)
                CLIENTE.cli_aciudad = Trim(cmbCiudad.Text)
                CLIENTE.cli_acod_comuna = cmbComuna.SelectedValue
                CLIENTE.cli_acod_ciudad = cmbCiudad.SelectedValue
                CLIENTE.cli_afonovta = Trim(txtFonoVenta.Text)
                CLIENTE.cli_primaPesos_total = CInt(Math.Round(TotalPesos))
                CLIENTE.cli_primaUf_total = totalUfAdic.ToString("0.00")

                If txtEmail.Text = "" Then
                    CLIENTE.cli_aemail = ""
                Else
                    CLIENTE.cli_aemail = Replace(Trim(txtEmail.Text), "'", "´")
                End If

                If txtReferencia.Text = "" Then
                    CLIENTE.CLI_AREFERENCIA = ""
                Else
                    CLIENTE.CLI_AREFERENCIA = Trim$(Replace(txtReferencia.Text, "'", "`"))
                End If

            End If

            Dim TpoContratoAdicional As New eTipoContrato

            TpoContratoAdicional = biClsTipoContrato.BuscarTipoContratoPorIdTipoContrato(tipoContrato.idTipoContrato)

            If TpoContratoAdicional.definido = False And lstAdi.Count = 0 Then
                MsgBox("Debe Agregar al menos 1 Adicional", MsgBoxStyle.Information, csNombreAplicacion)
                btnAdicional.Focus()
                Exit Sub
            Else
                If TpoContratoAdicional.definido = True And TpoContratoAdicional.cantidadAdicionales <> lstAdi.Count Then
                    If (TpoContratoAdicional.cantidadAdicionales < lstAdi.Count) Then
                        MsgBox("Debe seleccionar el tipo contrato con la cantidad de  Adicionales, de acuerdo a los adicionales agregados", MsgBoxStyle.Information, csNombreAplicacion)
                        btnAdicional.Focus()
                        Exit Sub
                    End If

                    If (TpoContratoAdicional.definido = True And lstAdi.Count < TpoContratoAdicional.cantidadAdicionales) Then
                        MsgBox("Debe ingresar la cantidad de Adicional(es) de acuerdo al tipo contrato seleccionado", MsgBoxStyle.Information, csNombreAplicacion)
                        btnAdicional.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If TpoContratoAdicional.cantidadBeneficiarios <> lstBen.Count Then
                If (lstBen.Count = 0) Then
                    MsgBox("Debe seleccionar el tipo contrato con la cantidad de " & lstBen.Count & " Beneficiario(s), de acuerdo a los beneficiarios agregados", MsgBoxStyle.Information, csNombreAplicacion)
                    btnBeneficiarios.Focus()
                    Exit Sub
                End If

                'If (lstBen.Count < TpoContratoAdicional.cantidadBeneficiarios) Then
                '    MsgBox("Debe ingresar la cantidad de " & TpoContratoAdicional.cantidadBeneficiarios & " Beneficiario(s) de acuerdo al tipo contrato seleccionado", MsgBoxStyle.Information, csNombreAplicacion)
                '    btnBeneficiarios.Focus()
                '    Exit Sub
                'End If
            End If

            If chkContacto.Checked = True Then
                If (txtNombre1contact.Text <> "") Then
                    CLIENTE.campo55 = txtNombre1contact.Text
                Else
                    MsgBox("Debe el Nombre del contactante ", MsgBoxStyle.Information, csNombreAplicacion)
                    txtNombre1contact.Focus()
                    Exit Sub
                End If
                If txtNombre2contact.Text <> "" Then
                    CLIENTE.campo56 = txtNombre2contact.Text
                Else
                    MsgBox("Debe el Segundo Nombre del contactante ", MsgBoxStyle.Information, csNombreAplicacion)
                    txtNombre2contact.Focus()
                    Exit Sub
                End If
                If txtaPaternocontact.Text <> "" Then
                    CLIENTE.campo57 = txtaPaternocontact.Text
                Else
                    MsgBox("Debe el Apellido Paterno del contactante ", MsgBoxStyle.Information, csNombreAplicacion)
                    txtaPaternocontact.Focus()
                    Exit Sub
                End If
                If txtaMaternocontact.Text <> "" Then
                    CLIENTE.campo58 = txtaMaternocontact.Text
                Else
                    MsgBox("Debe el Apellido Materno del contactante ", MsgBoxStyle.Information, csNombreAplicacion)
                    txtaMaternocontact.Focus()
                    Exit Sub
                End If

                If txtRutcontact.Text <> "" Then
                    If txtRutcontact.Text.Length < 7 Then
                        MsgBox("El RUT del cliente no es valido.", vbInformation, "Callsotuh.")
                        txtRutcontact.Focus()
                        Exit Sub
                    End If
                    If Not vgFuncionComun.validarRut(Trim(txtRutcontact.Text) & "-" & Trim(txtDvcontact.Text)) Then
                        MsgBox("El RUT del cliente no es valido.", vbInformation, "Callsouth.")
                        txtRutcontact.Focus()
                        Exit Sub
                    End If
                    CLIENTE.campo59 = txtRutcontact.Text
                Else
                    MsgBox("Debe el Rut del contactante ", MsgBoxStyle.Information, csNombreAplicacion)
                    txtRutcontact.Focus()
                    Exit Sub
                End If

                If cmbParentesco.SelectedIndex = -1 Or cmbParentesco.SelectedIndex = 0 Then
                    MsgBox("Debe seleccionar el parentesco de la carga.", vbExclamation, csNombreAplicacion)
                    cmbParentesco.Focus()
                    Exit Sub
                Else
                    CLIENTE.campo60 = Trim(cmbParentesco.Text)
                End If



            End If


            'script información adicional
            clsScript = CargaScript(5)
            WebInfAdicional.DocumentText = clsScript.contenidoScript

            Cuerpo.TabPages.Add(_Cuerpo_Certifica)
            Cuerpo.TabPages.Item(0).Parent = Nothing
            guardarPantallaAnterior(3)

        End If
    End Sub


    Private Sub CmdSiguienteA_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSiguienteA.Click
        Select Case CmbEstAgenda.SelectedIndex
            Case -1
                MsgBox("Debe seleccionar una opción para el estado del agendamiento.", MsgBoxStyle.Information, csNombreAplicacion)
                CmbEstAgenda.Focus()
                Exit Sub

            Case 2
                If perfil = "Regrabador" Then
                    CLIENTE.CLI_ESTADO_OBJECION_CALIDAD = 5 'no contactado para regrabacion
                End If

                CLIENTE.cli_agen_estado = Trim(CmbEstAgenda.Text)
                LblFinNoC.Text = ScriptLblFinNoC()
                Cuerpo.TabPages.Add(_Cuerpo_FinNC)
                Cuerpo.TabPages.Item(0).Parent = Nothing
                guardarPantallaAnterior(11)
        End Select
    End Sub
    '************METODO DE BOTON TERMINAR DE TAB AGENDAR**********************************
    Private Sub CmdTerminarA_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdTerminarA.Click
        If perfil <> "Regrabador" Then
            Select Case CmbEstAgenda.SelectedIndex
                Case -1
                    MsgBox("Debe seleccionar una opción para el estado del agendamiento.", MsgBoxStyle.Information, csNombreAplicacion)
                    CmbEstAgenda.Focus()
                    Exit Sub
                Case 0, 1
                    'UPGRADE_WARNING: El comportamiento de DateDiff puede ser diferente. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
                    If DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(FechaServidor()), DTFechaAgen.Value) > 7 Then
                        MsgBox("La fecha de agendamiento debe ser menor o igual a 1 semana.", MsgBoxStyle.Information, csNombreAplicacion)
                        Exit Sub
                    End If

                    If cmbHora.SelectedIndex = -1 Or cmbMin.SelectedIndex = -1 Then
                        MsgBox("Ingrese hora para agendar nuevo llamado.", MsgBoxStyle.Information, csNombreAplicacion)
                        cmbHora.Focus()
                        Exit Sub
                    Else
                        CLIENTE.cli_agen_estado = Trim(CmbEstAgenda.Text)
                        CLIENTE.cli_agen_fecha = DTFechaAgen.Value.ToString("yyyyMMdd")
                        CLIENTE.cli_agen_hora = cmbHora.Text & cmbMin.Text
                        CLIENTE.cli_agen_obs = Trim(Replace(TxtObsA.Text, "'", "`"))
                        CLIENTE.cli_call_id = WS_CALL_ID
                        CLIENTE.cli_venta = 0
                        CLIENTE.cli_estado = IIf(CLIENTE.cli_intentos >= CLIENTE.cli_intentos_max, "T", "A")

                        biCliente.GuardaDatosCliente(CLIENTE)
                        biCliente.GuardaDatosLog(claveRegistroActual)
                        MsgBox("Fin de la gestión. Presione ACEPTAR para continuar con el siguiente registro.", MsgBoxStyle.Information, csNombreAplicacion)
                        limpiarPrimeraPantalla()
                        Buscar_Cliente()
                    End If


            End Select
        Else
            Select Case CmbEstAgenda.SelectedIndex
                Case -1
                    MsgBox("Debe seleccionar una opción para el estado del agendamiento.", MsgBoxStyle.Information, csNombreAplicacion)
                    CmbEstAgenda.Focus()
                    Exit Sub
                Case 0, 1
                    'UPGRADE_WARNING: El comportamiento de DateDiff puede ser diferente. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
                    If DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(FechaServidor()), DTFechaAgen.Value) > 7 Then
                        MsgBox("La fecha de agendamiento debe ser menor o igual a 1 semana.", MsgBoxStyle.Information, csNombreAplicacion)
                        Exit Sub
                    End If

                    If cmbHora.SelectedIndex = -1 Or cmbMin.SelectedIndex = -1 Then
                        MsgBox("Ingrese hora para agendar nuevo llamado.", MsgBoxStyle.Information, csNombreAplicacion)
                        cmbHora.Focus()
                        Exit Sub
                    Else
                        CLIENTE.cli_agen_estado = Trim(CmbEstAgenda.Text)
                        CLIENTE.cli_agen_fecha = DTFechaAgen.Value.ToString("yyyyMMdd")
                        CLIENTE.cli_agen_hora = cmbHora.Text & cmbMin.Text
                        CLIENTE.cli_agen_obs = Trim(Replace(TxtObsA.Text, "'", "`"))
                        CLIENTE.CLI_CALL_ID_CALIDAD = WS_CALL_ID
                        CLIENTE.cli_venta = 0
                        CLIENTE.cli_estado = IIf(CLIENTE.cli_intentos >= CLIENTE.cli_intentos_max, "T", "A")
                        CLIENTE.CLI_ESTADO_OBJECION_CALIDAD = "2"
                        CLIENTE.cli_fechavta = ""
                        CLIENTE.cli_horavta = ""

                        biGesRes.GuardaClienteGes(CLIENTE, vgCampania.calCodigo)
                        biGesRes.ActualizaClienteAgen(CLIENTE.cli_id, CLIENTE.CLI_ESTADO_OBJECION_CALIDAD, CLIENTE.CLI_CALL_ID_CALIDAD)
                        biCliente.GuardaDatosLog(CLIENTE.cli_id)
                        MsgBox("Fin de la gestión. Presione ACEPTAR para salir del formulario.", MsgBoxStyle.Information, csNombreAplicacion)
                        limpiarPrimeraPantalla()
                        Me.Hide()
                        frmRegrabaciones.ShowDialog()
                        BuscaGes()
                    End If
                Case 2
                    CLIENTE.cli_agen_estado = Trim$(CmbEstAgenda.Text)
                    Terminar()
            End Select
        End If

    End Sub
    'UPGRADE_WARNING: Form evento frmAce.Activate tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
    Private Sub frmAce_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        ' verifica si es la primera vez que se activa el formulario
        ' en este caso busca un cliente inmediatamente y luego baja el flag
        If flag_primeravez Then
            flag_primeravez = False
        End If
    End Sub

    Private Sub frmAce_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        flag_primeravez = True
        ModGeneral.Main()
        Me.Text = vgCampania.calNombre & " " & perfil & "NEW Versión: " & My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString _
        & "." & My.Application.Info.Version.Revision.ToString

        If perfil = "Regrabador" Then
            frmRegrabaciones.ShowDialog()
        End If

        'asignamos  la fecha maxima ingreso de fecha 
        dtFechaNacIng.MaxDate = DateAdd(DateInterval.Year, -18, DateAdd(DateInterval.Day, 1, Now))
        dtFechaNac.MaxDate = DateAdd(DateInterval.Year, -18, DateAdd(DateInterval.Day, 1, Now))

        'asignamos  la fecha minima ingreso de fecha
        dtFechaNacIng.MinDate = dtFechaNacIng.MinDate
        dtFechaNac.MinDate = dtFechaNac.MinDate

        Fono_A_Llamar = ""
        vgListEdoFono = biClsEdoFono.listarEstadoFono

        Dim daComuna As New clsComunaBI
        Dim daCiudad As New clsCiudadBI
        vgListComuna = daComuna.listarComuna()
        vgListCiudad = daCiudad.ListaCiudad()
        vgFuncionComun.llenaComboBox(cmbComuna, "nombreComuna", "idComuna", vgListComuna.ToArray)
        cmbComuna.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbComuna.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbComunaIng.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbComunaIng.AutoCompleteSource = AutoCompleteSource.ListItems

        Dim listPatertescocontact As New List(Of eParentescoCampania)
        Dim parentesco As New clsParentescoCampaniaBI

        listParentescoCampania = biClsParentescoCampania.BuscarParentescoPorId(vgCampania.calCodigo, 3)
        vgFuncionComun.llenaComboBox(cmbParentesco, "nombreParentesco", "idParentesco", listParentescoCampania.ToArray)
        vgListParentescoCampania = biClsParentescoCampania.BuscarParentescoPorId(vgCampania.calCodigo, 2)

        Dim listMotivoRechazo As New List(Of eMotivoRechazo)
        Dim biMotivoRechazo As New clsMotivoRechazoBI
        listMotivoRechazo = biMotivoRechazo.BuscarMotivoRechazoPorSponsor(vgCampania)
        vgFuncionComun.llenaComboBox(CmbObj, "descripcionMotivoRechazo", "idMotivoRechazo", listMotivoRechazo.ToArray)


        listaCorreoInvalido.Clear()
        listaCorreoInvalido = biCorreoInv.listarCorreosInvalido


        If perfil = "Regrabador" Then
            BuscaGes()
        ElseIf perfil = "Ejecutivo" Then
            Buscar_Cliente()
        End If

        System.Windows.Forms.Application.DoEvents()
    End Sub

    Public Sub BuscaGes()
        CLIENTE = biCliente.Buscar_Gescliente(GesId)
        flg_progresivo_activado = True

        lblEstadoLlamada.Text = ""
        WS_CALL_ID = ""
        txtCallId.Text = ""
        Rellenar_fonos_Regrabaciones()

        inicializarControlesGes()
        'llamarProgresivoFijo()
        llamarProgresivo()
    End Sub

    Public Sub Rellenar_fonos_Regrabaciones()
        Txt_Fono1.Text = Trim(CLIENTE.cli_telefono1)
        flg_fono1 = Not esVacio(CLIENTE.cli_telefono1)
        flg_EsCelu1 = esCelular(CLIENTE.cli_telefono1)

        Txt_Fono2.Text = Trim(CLIENTE.cli_telefono2)
        flg_fono2 = Not esVacio(CLIENTE.cli_telefono2)
        flg_EsCelu2 = esCelular(CLIENTE.cli_telefono2)

        Txt_Fono3.Text = Trim(CLIENTE.cli_telefono3)
        flg_fono3 = Not esVacio(CLIENTE.cli_telefono3)
        flg_EsCelu3 = esCelular(CLIENTE.cli_telefono3)

        Txt_Fono4.Text = Trim(CLIENTE.cli_telefono4)
        flg_fono4 = Not esVacio(CLIENTE.cli_telefono4)
        flg_EsCelu4 = esCelular(CLIENTE.cli_telefono4)

        Txt_Fono5.Text = Trim(CLIENTE.cli_telefono5)
        flg_fono5 = Not esVacio(CLIENTE.cli_telefono5)
        flg_EsCelu5 = esCelular(CLIENTE.cli_telefono5)

        Txt_Fono6.Text = Trim(CLIENTE.cli_telefono6)
        flg_fono6 = Not esVacio(CLIENTE.cli_telefono6)
        flg_EsCelu6 = esCelular(CLIENTE.cli_telefono6)

        Txt_Fono_alt.Text = Trim(CLIENTE.cli_telefonoalt)
        flg_fonoalt = Not esVacio(CLIENTE.cli_telefonoalt)
        flg_EsCeluAlt = esCelular(CLIENTE.cli_telefonoalt)

        txt_FonoVenta.Text = Trim(CLIENTE.CLI_AFONOCONTACTO)
        flg_fonoVent = Not esVacio(CLIENTE.CLI_AFONOCONTACTO)
        flg_EsCeluVent = esCelular(CLIENTE.CLI_AFONOCONTACTO)

    End Sub

    Private Sub llenaCombobox(ByVal cmbParCombo As ComboBox, ByVal dt As DataTable, ByVal strDisplay As String, ByVal strValue As String)

        With cmbParCombo
            .ValueMember = strValue
            .DisplayMember = strDisplay
            .DataSource = dt
        End With

    End Sub

    Private Function TipoDato(ByVal typTipoDato As System.Type) As SqlDbType
        Try

            Select Case typTipoDato.ToString
                Case "System.String"
                    Return SqlDbType.VarChar
                Case "System.Int32"
                    Return SqlDbType.Int
                Case "System.Int64"
                    Return SqlDbType.BigInt
                Case "System.Double"
                    Return SqlDbType.Decimal
                Case "System.DateTime"
                    Return SqlDbType.DateTime
                Case "System.Boolean"
                    Return SqlDbType.Bit
                Case "System.Char"
                    Return SqlDbType.Char
                Case "System.Decimal"
                    Return SqlDbType.Decimal
            End Select

        Catch ex As Exception

        End Try

    End Function

    Public Function fecha_yyyymmdd(ByRef dia As String, ByRef mes As String, ByRef ano As String) As String
        If Len(Trim(dia)) = 1 Then
            dia = "0" & dia
        End If
        If Len(Trim(mes)) = 1 Then
            mes = "0" & mes
        End If

        fecha_yyyymmdd = ano & mes & dia
    End Function
    Private Sub tmCallID_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If db_central = 4 Then
            If CmdLlamar1.Text = "Colgar" Or CmdLlamar2.Text = "Colgar" Or CmdLlamar3.Text = "Colgar" Or CmdLlamar4.Text = "Colgar" Or CmdLlamar5.Text = "Colgar" Or CmdLlamar6.Text = "Colgar" Or CmdLlamarAlt.Text = "Colgar" Then
                If Trim(txtCallId.Text) = "" Then
                    vpPosicion.CargarPosicion((vpPosicion.Usuario))
                    txtCallId.Text = vpPosicion.IDLLAMADA
                    WS_CALL_ID = vpPosicion.IDLLAMADA

                End If
            End If
        End If
    End Sub

    Private Sub tmrEstadoLlamada_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrEstadoLlamada.Tick
        On Error Resume Next
        lblEstadoLlamada.Text = EstadoLLamada()
        If db_central = 4 Then
            If Not vpPosicion.EvaluaEstado((vpPosicion.Usuario)) Then
                Corta_Anteriores()
            End If
        End If
    End Sub


    Private Sub TxtObj_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtObj.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        KeyAscii = CaracterValido(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub TxtObsA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtObsA.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        KeyAscii = CaracterValido(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub TxtObsAgen2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtObsAgen2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        KeyAscii = CaracterValido(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub Txt_Fono_alt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Fono_alt.TextChanged
        Try
            If Txt_Fono_alt.Text <> "" Then
                CLIENTE.cli_telefonoalt = Txt_Fono_alt.Text
            Else
                CLIENTE.cli_telefonoalt = ""
            End If
        Catch ex As Exception

        End Try

    End Sub
    '*******************METODO AL PRESIONAR BOTON TERMINAR DE TAB FIN NO CONTRATA**********************************
    Private Sub CmdTerminarNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdTerminarNC.Click
        If perfil <> "Regrabador" Then
            CLIENTE.cli_call_id = WS_CALL_ID
            CLIENTE.cli_estado = "T"
            CLIENTE.cli_venta = "0"

            biCliente.GuardaDatosCliente(CLIENTE)
            biCliente.GuardaDatosLog(claveRegistroActual)
            MsgBox("Fin de la gestión. Presione ACEPTAR para continuar con el siguiente registro.", MsgBoxStyle.Information, "CALLSOUTH")
            limpiarPrimeraPantalla()
            Buscar_Cliente()
        Else

            CLIENTE.CLI_SEGUNDO_ESTADO_CALIDAD = "N"
            CLIENTE.cli_venta = 0
            CLIENTE.CLI_CALL_ID_CALIDAD = Mid(WS_CALL_ID, 1, 10)
            CLIENTE.cli_estado = "T"
            CLIENTE.cli_fechavta = ""
            CLIENTE.cli_horavta = ""

            biGesRes.GuardaClienteGes(CLIENTE, vgCampania.calCodigo)
            biGesRes.ActualizaCteSinVta(CLIENTE.CLI_SEGUNDO_ESTADO_CALIDAD, CLIENTE.CLI_ESTADO_OBJECION_CALIDAD, CLIENTE.CLI_CALL_ID_CALIDAD, CLIENTE.cli_id)
            biCliente.GuardaDatosLog(CLIENTE.cli_id)
            If CLIENTE.CLI_ESTADO_OBJECION_CALIDAD = 8 Then
                biGesRes.GrabaAsignaCalidad(CLIENTE.cli_id, vgCampania.calCodigo, WS_IDUSUARIO, CLIENTE.cli_fecha, 4, WS_IDUSUARIO)
            ElseIf CLIENTE.CLI_ESTADO_OBJECION_CALIDAD = 5 Then
                biGesRes.GrabaAsignaCalidad(CLIENTE.cli_id, vgCampania.calCodigo, WS_IDUSUARIO, CLIENTE.cli_fecha, 2, WS_IDUSUARIO)
            ElseIf CLIENTE.CLI_ESTADO_OBJECION_CALIDAD = 7 Then
                biGesRes.GrabaAsignaCalidad(CLIENTE.cli_id, vgCampania.calCodigo, WS_IDUSUARIO, CLIENTE.cli_fecha, 3, WS_IDUSUARIO)
            Else
                biGesRes.GrabaAsignaCalidad(CLIENTE.cli_id, vgCampania.calCodigo, WS_IDUSUARIO, CLIENTE.cli_fecha, 1, WS_IDUSUARIO)
            End If
            MsgBox("Fin de la gestión. Presione ACEPTAR para salir del formulario.", MsgBoxStyle.Information, csNombreAplicacion)
            limpiarPrimeraPantalla()
            Me.Hide()
            frmRegrabaciones.ShowDialog()
            BuscaGes()

        End If

    End Sub

    '*************METODO DE BOTON TERMINAR EN TAB AGENDAR 2********************************
    Private Sub CmdTerminarA2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdTerminarA2.Click
        If CmdLlamar1.Text = "COLGAR" Or CmdLlamar2.Text = "COLGAR" Or CmdLlamar3.Text = "COLGAR" Or CmdLlamar4.Text = "COLGAR" Or CmdLlamar5.Text = "COLGAR" Or CmdLlamar6.Text = "COLGAR" Or CmdLlamarAlt.Text = "COLGAR" Then
            MsgBox("Debe Colgar la llamada antes de terminar", vbExclamation, csNombreAplicacion)
            Exit Sub
        End If

        If perfil <> "Regrabador" Then
            If CmbHora2.SelectedIndex = -1 Or CmbMin2.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar FECHA y HORA ", vbInformation, "Callsouth")
                CmbHora2.Focus()
                Exit Sub
            Else
                CLIENTE.cli_call_id = WS_CALL_ID
                CLIENTE.cli_estado = IIf(CLIENTE.cli_intentos >= CLIENTE.cli_intentos_max, "T", "A")
                CLIENTE.cli_agen_obs = Trim$(Replace(TxtObsAgen2.Text, "'", "´"))
                CLIENTE.cli_agen_fecha = DTAgenFecha2.Value.ToString("yyyyMMdd")
                CLIENTE.cli_agen_hora = Trim(CmbHora2.Text) & Trim(CmbMin2.Text)

                CLIENTE.cli_venta = 0
                Dim fecha_agendamiento As String
                fecha_agendamiento = Format(DTAgenFecha2.Value, "dd/MM/yyyy") & " a las " & CmbHora2.Text & ":" & CmbMin2.Text & " Hrs."

                biCliente.GuardaDatosCliente(CLIENTE)
                biCliente.GuardaDatosLog(claveRegistroActual)
                MsgBox("Fin de la gestión. Presione ACEPTAR para continuar con el siguiente registro.", vbInformation, "Callsouth")
                limpiarPrimeraPantalla()
                Buscar_Cliente()
                'Cuerpo.TabPages.Add(_Cuerpo_Conex)
                'Cuerpo.TabPages.Item(0).Parent = Nothing
            End If
        Else
            If CmbHora2.SelectedIndex = -1 Or CmbMin2.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar FECHA y HORA ", vbInformation, "Callsouth")
                CmbHora2.Focus()
                Exit Sub
            Else
                CLIENTE.cli_agen_estado = ""
                CLIENTE.CLI_CALL_ID_CALIDAD = WS_CALL_ID
                CLIENTE.cli_estado = IIf(CLIENTE.cli_intentos >= CLIENTE.cli_intentos_max, "T", "A")
                CLIENTE.cli_agen_obs = Trim$(Replace(TxtObsAgen2.Text, "'", "´"))
                CLIENTE.cli_agen_fecha = DTAgenFecha2.Value.ToString("yyyyMMdd")
                CLIENTE.cli_agen_hora = Trim(CmbHora2.Text) & Trim(CmbMin2.Text)
                CLIENTE.CLI_ESTADO_OBJECION_CALIDAD = "2"
                CLIENTE.cli_venta = 0
                CLIENTE.cli_fechavta = ""
                CLIENTE.cli_horavta = ""
                Dim fecha_agendamiento As String
                fecha_agendamiento = Format(DTAgenFecha2.Value, "dd/MM/yyyy") & " a las " & CmbHora2.Text & ":" & CmbMin2.Text & " Hrs."
                biGesRes.GuardaClienteGes(CLIENTE, vgCampania.calCodigo)
                biGesRes.ActualizaClienteAgen(CLIENTE.cli_id, CLIENTE.CLI_ESTADO_OBJECION_CALIDAD, CLIENTE.CLI_CALL_ID_CALIDAD)
                biCliente.GuardaDatosLog(CLIENTE.cli_id)
                MsgBox("Fin de la gestión. Presione ACEPTAR para salir del formulario.", MsgBoxStyle.Information, csNombreAplicacion)
                limpiarPrimeraPantalla()
                Me.Hide()
                frmRegrabaciones.ShowDialog()
                BuscaGes()
            End If
        End If
    End Sub

    Private Sub TxtFechaN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If LlenaParentescoCondicion() <> True Then
            Exit Sub
        End If
        If ValAdicional(0) Then
            If paInsertaAdicional() Then
                'sumaUFAdicionales()
            End If
        End If
    End Sub

    Private Sub btnAdicionalSgt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionalSgt.Click
        Cuerpo.TabPages.Add(_Cuerpo_DatosCli)

        If db_central = 4 And Trim(txtCallId.Text) = "" Then
            vpPosicion.CargarPosicion((vpPosicion.Usuario))
            txtCallId.Text = vpPosicion.IDLLAMADA
            WS_CALL_ID = vpPosicion.IDLLAMADA
        End If

        'sumaUFAdicionales()

        insertaAdicionalesGrilla()
        limpiaAdicionales()

        Cuerpo.TabPages.Item(0).Parent = Nothing
        guardarPantallaAnterior(9)

    End Sub

    Private Sub insertaAdicionalesGrilla()

        If perfil <> "Regrabador" Then

            Dim TpoContratoAdicional As New eTipoContrato
            TpoContratoAdicional = biClsTipoContrato.BuscarTipoContratoPorIdTipoContrato(tipoContrato.idTipoContrato)

            Dim entPlan As New ePlan
            Dim listaEntPlan As New List(Of ePlan)
            lstAdi.Clear()

            'GUARDO LOS DATOS DE LOS ADICIONALES EN UNA LISTA
            For I As Int16 = 0 To dtAdicional.Rows.Count - 1

                Dim adi As New eAdicional

                adi.a_nombre = IIf(dtAdicional.Rows(I).Cells("nombre").Value Is DBNull.Value, Nothing, dtAdicional.Rows(I).Cells("nombre").Value)
                adi.a_nombre2 = IIf(dtAdicional.Rows(I).Cells("nombre2").Value Is DBNull.Value, Nothing, dtAdicional.Rows(I).Cells("nombre2").Value)
                adi.a_paterno = IIf(dtAdicional.Rows(I).Cells("paterno").Value Is DBNull.Value, Nothing, dtAdicional.Rows(I).Cells("paterno").Value)
                adi.a_materno = IIf(dtAdicional.Rows(I).Cells("materno").Value Is DBNull.Value, Nothing, dtAdicional.Rows(I).Cells("materno").Value)
                adi.a_rut = IIf(dtAdicional.Rows(I).Cells("rut").Value Is DBNull.Value, Nothing, dtAdicional.Rows(I).Cells("rut").Value)
                adi.a_dv = IIf(dtAdicional.Rows(I).Cells("dv").Value Is DBNull.Value, Nothing, dtAdicional.Rows(I).Cells("dv").Value)
                adi.a_id_parentesco = IIf(dtAdicional.Rows(I).Cells("idParentescoAdi").Value Is DBNull.Value, Nothing, dtAdicional.Rows(I).Cells("idParentescoAdi").Value)
                adi.a_parentesco = IIf(dtAdicional.Rows(I).Cells("tipo_parentesco").Value Is DBNull.Value, Nothing, dtAdicional.Rows(I).Cells("tipo_parentesco").Value)
                adi.a_sexo = IIf(dtAdicional.Rows(I).Cells("sexo").Value Is DBNull.Value, Nothing, dtAdicional.Rows(I).Cells("sexo").Value)
                adi.a_fecnacimiento = IIf(dtAdicional.Rows(I).Cells("fechaNacimiento").Value Is DBNull.Value, Nothing, dtAdicional.Rows(I).Cells("fechaNacimiento").Value)
                adi.a_primaUf = IIf(dtAdicional.Rows(I).Cells("ValorUf").Value Is DBNull.Value, Nothing, dtAdicional.Rows(I).Cells("ValorUf").Value)
                adi.idPlanAdic = IIf(dtAdicional.Rows(I).Cells("idPlan").Value Is DBNull.Value, Nothing, dtAdicional.Rows(I).Cells("idPlan").Value)
                adi.a_salud = IIf(dtAdicional.Rows(I).Cells("SistemaSalud").Value Is DBNull.Value, Nothing, dtAdicional.Rows(I).Cells("SistemaSalud").Value)

                lstAdi.Add(adi)

            Next I

        End If

    End Sub

    '****************Metodo para que se cargue ciudad al seleccionar comuna de combobox cmbComuna************************
    Private Sub cmbComuna_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbComuna.SelectedIndexChanged
        Dim lstCiudad As New List(Of eCiudad)

        If cmbComuna.ValueMember Is Nothing Or cmbComuna.ValueMember = "" Then
            Exit Sub
        End If
        If cmbComuna.SelectedValue Is Nothing Then
            Exit Sub
        End If

        'actualiza el combo box de ciudad
        Dim Ciudad As New eCiudad
        Dim comuna As New eComuna

        comuna = vgListComuna.Find(Function(tmpC As eComuna) tmpC.idComuna = cmbComuna.SelectedValue)
        Ciudad = biClsCiudad.BuscaCiudadPorIdCiudad(comuna.idCiudad)
        lstCiudad.Add(Ciudad)
        vgFuncionComun.llenaComboBox(cmbCiudad, "nombreCiudad", "idCiudad", lstCiudad.ToArray)

    End Sub

    '**************metodo de boton siguiente de tab certificador********************************
    Private Sub cmdSiguienteFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSiguienteFin.Click


        Select Case cmbAceptaPrima.SelectedIndex

            Case -1, 0
                MsgBox("Debe ingresar si acepta Cargo", MsgBoxStyle.Exclamation, csNombreAplicacion)
                cmbAceptaPrima.Focus()
                Exit Sub
            Case 1
                Select Case cmbAceptaContrato.SelectedIndex
                    Case 0, -1
                        MsgBox("Debe ingresar si acepta Contratación", MsgBoxStyle.Exclamation, csNombreAplicacion)
                        cmbAceptaContrato.Focus()
                        Exit Sub
                    Case 1
                        If perfil <> "Regrabador" Then
                            CLIENTE.cli_acepta_cargo = cmbAceptaPrima.Text
                            CLIENTE.cli_acepta_contrato = cmbAceptaContrato.Text
                        Else
                            CLIENTE.CLI_ACEPTA_CONTRATACION = cmbAceptaContrato.Text
                            CLIENTE.cli_acepta_prima = cmbAceptaPrima.Text
                        End If

                        clsScript = CargaScript(6)
                        WebBrowsercierre.DocumentText = clsScript.contenidoScript

                        Cuerpo.TabPages.Add(_Cuerpo_UltInfo)
                        Cuerpo.TabPages.Item(0).Parent = Nothing
                        guardarPantallaAnterior(6)
                    Case 2
                        If perfil <> "Regrabador" Then
                            CLIENTE.cli_acepta_contrato = cmbAceptaContrato.Text
                            CLIENTE.cli_acepta_prima = cmbAceptaPrima.Text
                        Else
                            CLIENTE.CLI_ACEPTA_CONTRATACION = cmbAceptaContrato.Text
                            CLIENTE.cli_acepta_prima = cmbAceptaPrima.Text
                        End If

                        Cuerpo.TabPages.Add(_Cuerpo_Objeciones)
                        Cuerpo.TabPages.Item(0).Parent = Nothing
                        guardarPantallaAnterior(6)

                End Select

            Case 2
                CLIENTE.cli_acepta_contrato = cmbAceptaContrato.Text
                CLIENTE.cli_acepta_prima = cmbAceptaPrima.Text
                Cuerpo.TabPages.Add(_Cuerpo_Objeciones)
                Cuerpo.TabPages.Item(0).Parent = Nothing
                guardarPantallaAnterior(6)
        End Select

    End Sub

    Private Sub InsertaAdicionales()

        Dim J As Integer
        Dim TotalAdicional As Integer = lstAdi.Count

        Dim cli As String = CLIENTE.cli_id
        Dim aru As String = CLIENTE.cli_arut
        Dim biAsegurado As New clsAdicionalBI
        Dim adi As New eAdicional
        Dim valor As Boolean

        valor = biAsegurado.Verificar(cli, aru)
        If valor = True Then
            biAsegurado.Eliminar(cli, aru)
        End If

        For J = 0 To TotalAdicional - 1
            adi.cli_id = cli
            adi.t_rut = aru
            adi.a_nro = J + 1
            adi.a_rut = IIf(lstAdi(J).a_rut.Trim = "", 0, lstAdi(J).a_rut)
            adi.a_dv = lstAdi(J).a_dv
            adi.a_nombre = lstAdi(J).a_nombre
            adi.a_paterno = lstAdi(J).a_paterno
            adi.a_materno = lstAdi(J).a_materno
            adi.a_fecnacimiento = Replace(lstAdi(J).a_fecnacimiento, "-", "")
            adi.a_sexo = lstAdi(J).a_sexo
            adi.a_id_parentesco = lstAdi(J).a_id_parentesco
            adi.a_parentesco = lstAdi(J).a_parentesco
            adi.a_primaUf = lstAdi(J).a_primaUf
            adi.idPlanAdic = lstAdi(J).idPlanAdic
            adi.a_salud = lstAdi(J).a_salud
            biAsegurado.Insertar(adi)
        Next J


    End Sub

    Private Sub InsertaBeneficiarios()
        Dim J As Integer
        Dim TotalBenficiarios As Integer
        Dim cli As String
        Dim aru As String
        Dim clsBen As New clsBeneficiarioBI
        Dim be As New eBeneficiario

        TotalBenficiarios = lstBen.Count
        cli = CLIENTE.cli_id
        aru = CLIENTE.cli_arut
        If perfil = "Regrabador" Then
            Try
                clsBen.Eliminar(cli)
            Catch ex As Exception
                MsgBox(Err.Description & " " & " Error : En la Función InsertaBeneficiarios()", MsgBoxStyle.Critical, Me.Text)
            End Try
        End If
        Try
            For J = 0 To TotalBenficiarios - 1
                be.cli_id = cli
                be.t_rut = aru
                be.t_certificado = 0
                be.b_nro = J + 1
                be.b_rut = IIf(lstBen(J).b_rut.Trim = "", 0, lstBen(J).b_rut)
                be.b_dv = lstBen(J).b_dv
                be.b_nombre1 = lstBen(J).b_nombre1
                be.b_nombre2 = lstBen(J).b_nombre2
                be.b_paterno = lstBen(J).b_paterno
                be.b_materno = lstBen(J).b_materno
                be.b_parentesco = lstBen(J).b_parentesco
                be.parentesco_text = lstBen(J).parentesco_text
                be.b_pctje = lstBen(J).b_pctje
                be.b_fec_nac = lstBen(J).b_fec_nac
                be.b_contacto = lstBen(J).b_contacto
                clsBen.Insertar(be)
            Next J

            '-------------------------------------------------------------------------------------
        Catch ex As Exception
            MsgBox(Err.Description & " " & " Error : En la Función InsertaBeneficiario()", MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

#Region "INGRESO CLIENTE"
    '*********metodo para cargar los datos en la toma de datos de regrabacion*******************
    ''' <summary>
    ''' carga los datos a los controles del tab toma de datos
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AsignadatosCli()
        Dim TotalDigito As Integer

        TotalDigito = Len(Fono_A_Llamar)
        If TotalDigito = 9 Then
            txtFonoVenta.Text = Trim(Fono_A_Llamar)
        End If
        If TotalDigito > 9 Then
            txtFonoVenta.Text = Microsoft.VisualBasic.Right(Fono_A_Llamar, 9)
        End If

        vgFuncionComun.LimpiaFormilarioBenAdi()

        Dim nombre = ""
        Dim apellido = ""
        Dim index As Integer = Trim(CLIENTE.cli_nombre).IndexOf(" "c)
        If (Index = -1) Then
            ' No existe ningún espacio en blanco;
            nombre = Trim(CLIENTE.cli_nombre)
            apellido = String.Empty

        Else
            ' Obtenemos el nombre
            nombre = Trim(CLIENTE.cli_nombre).Substring(0, Index)

            ' Obtenemos el apellido
            apellido = Trim(CLIENTE.cli_nombre).Substring(Index + 1, Trim(CLIENTE.cli_nombre).Length - Index - 1)

        End If

        txtNombre.Text = nombre
        txtNombre2.Text = apellido

        'txtNombre.Text = Trim(UCase(CLIENTE.cli_nombre))
        txtPaterno.Text = Trim(UCase(CLIENTE.cli_paterno))
        txtMaterno.Text = Trim(UCase(CLIENTE.cli_materno))

        txtArut.Text = Mid(CLIENTE.cli_rut, 1, 4)
        txtDv.Text = ""
        txtEmail.Text = CLIENTE.cli_email
        txtCalle.Text = "" 'CLIENTE.cli_direccion
        txtUltDigitos.Text = ""

        DatosMedioPago()
        lstAdi.Clear()
        'cmbMedioPago.Items.Clear()
        'cmbMedioPago.Items.Add("[No Especificado]")
        'If Trim(CLIENTE.CLI_NUMERO_CTACTE) <> "" Then
        '    cmbMedioPago.Items.Add("Cuenta Corriente - Nro: " & Strings.Right(CLIENTE.CLI_NUMERO_CTACTE, 4))
        'End If
        'If Trim(CLIENTE.CLI_TIPOTARJETA_1) <> "" Then
        '    cmbMedioPago.Items.Add(CLIENTE.CLI_TIPOTARJETA_1 & " - Nro:" & CLIENTE.CLI_NUMTARJETA_1)
        'End If
        'If Trim(CLIENTE.CLI_TIPOTARJETA_2) <> "" Then
        '    cmbMedioPago.Items.Add(CLIENTE.CLI_TIPOTARJETA_2 & " - Nro:" & CLIENTE.CLI_NUMTARJETA_2)
        'End If
        'If Trim(CLIENTE.CLI_TIPOTARJETA_3) <> "" Then
        '    cmbMedioPago.Items.Add(CLIENTE.CLI_TIPOTARJETA_3 & " - Nro:" & CLIENTE.CLI_NUMTARJETA_3)
        'End If

        'cmbMedioPago.Items.Add("Otro medio de pago")


        ListTipoContrato = biClsTipoContrato.ListaTipoContratoPorCampania(vgCampania.calCodigo)
        vgFuncionComun.llenaComboBox(cmbTipoContrato, "nombreTipoContrato", "idTipoContrato", ListTipoContrato.ToArray)

    End Sub

    Private Sub DatosMedioPago()

        'llena datos medio pago
        Dim biMedioPago As New clsMedioPagoBI
        Dim listMedioPago As New List(Of eMedioPago)
        Dim medioPagoVacio As New eMedioPago
        Dim listMedioPagoVacio As New List(Of eMedioPago)

        medioPagoVacio.nombreMedioPago = "[No Especificado]"
        medioPagoVacio.idMedioPago = "0"
        listMedioPagoVacio.Add(medioPagoVacio)

        listMedioPago = biMedioPago.BuscaDatosMedioPago(vgCampania.calCodigo, CLIENTE.cli_id)

        For x As Int16 = 0 To listMedioPago.Count - 1

            Dim medioPago As New eMedioPago
            medioPago.nombreMedioPago = listMedioPago(x).nombreMedioPago
            medioPago.numeroTarjeta = listMedioPago(x).numeroTarjeta
            medioPago.idMedioPago = listMedioPago(x).idMedioPago
            medioPago.otroMedioPago = listMedioPago(x).otroMedioPago

            If (medioPago.otroMedioPago = True) Then
                medioPago.nombreMedioPago = medioPago.nombreMedioPago
            Else
                medioPago.nombreMedioPago = medioPago.nombreMedioPago & " - Nro: " & medioPago.numeroTarjeta
            End If

            listMedioPagoVacio.Add(medioPago)

        Next

        vgFuncionComun.llenaComboBox(cmbMedioPago, "nombreMedioPago", "idMedioPago", listMedioPagoVacio.ToArray)

    End Sub

    ''' <summary>
    ''' metodo para cargar los datos en la toma de datos de regrabacion
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AsignadatosCliGes()
        Dim comunaGes As New eComuna
        Dim CiudadGes As New eCiudad
        Dim biciudad As New clsCiudadBI
        Dim lstCiudad As New List(Of eCiudad)

        txtNombre.Text = Trim(UCase(CLIENTE.cli_anombre))
        txtPaterno.Text = Trim(UCase(CLIENTE.cli_apaterno))
        txtMaterno.Text = Trim(UCase(CLIENTE.cli_amaterno))

        txtArut.Text = Trim(CLIENTE.cli_arut)
        txtDv.Text = Trim(CLIENTE.cli_adv)
        txtEmail.Text = Trim(CLIENTE.cli_email)
        txtFonoVenta.Text = Trim(CLIENTE.cli_afonovta)
        txtCelular.Text = Trim(CLIENTE.cli_acelular)
        txtCalle.Text = Trim(CLIENTE.cli_acalle)
        txtNro.Text = Trim(CLIENTE.cli_anro)
        txtReferencia.Text = Trim(CLIENTE.CLI_AREFERENCIA)


        comunaGes = vgListComuna.Find(Function(tmpC As eComuna) tmpC.idComuna = CLIENTE.cli_acod_comuna)
        cmbComuna.SelectedValue = comunaGes.idComuna
        CiudadGes = biciudad.BuscaCiudadPorIdCiudad(comunaGes.idCiudad)
        lstCiudad.Add(CiudadGes)
        vgFuncionComun.llenaComboBox(cmbCiudad, "nombreCiudad", "idCiudad", lstCiudad.ToArray)

        If CLIENTE.cli_asexo = "M" Then
            CmbSexo.SelectedIndex = 1
        ElseIf CLIENTE.cli_asexo = "F" Then
            CmbSexo.SelectedIndex = 2
        Else
            CmbSexo.SelectedIndex = 0
        End If

        If CLIENTE.CLI_ACEPTA_CORREO = "SI" Then
            CmbAutorizaCorreo.SelectedIndex = 1
        ElseIf CLIENTE.CLI_ACEPTA_CORREO = "NO" Then
            CmbAutorizaCorreo.SelectedIndex = 2
        Else
            CmbAutorizaCorreo.SelectedIndex = 0
        End If



        Carga_Beneficiarios()
        Carga_adicionales()

        ListTipoContrato = biClsTipoContrato.ListaTipoContratoPorCampania(vgCampania.calCodigo)
        vgFuncionComun.llenaComboBox(cmbTipoContrato, "nombreTipoContrato", "idTipoContrato", ListTipoContrato.ToArray)
        cmbTipoContrato.SelectedValue = CLIENTE.cli_tpocontrato

        llenar_planes()

        lblPrimaPesos.Text = CLIENTE.cli_primapesos
        lblPrimaUF.Text = CLIENTE.cli_primauf
        cmbPlan.Text = CLIENTE.cli_primauf
        DatosMedioPago()
        'cmbMedioPago.Items.Clear()
        'cmbMedioPago.Items.Add("[No Especificado]")
        'If Trim(CLIENTE.CLI_NUMERO_CTACTE) <> "" Then
        '    cmbMedioPago.Items.Add("Cuenta Corriente - Nro: " & Strings.Right(CLIENTE.CLI_NUMERO_CTACTE, 4))
        'End If
        'If Trim(CLIENTE.CLI_ABANCO) = "0" Then
        '    cmbMedioPago.Items.Add(CLIENTE.CLI_AMEDIO_PAGO)
        '    txtUltDigitos.Text = CLIENTE.cli_anrotarjeta
        'ElseIf Trim(CLIENTE.CLI_ABANCO) <> "0" Then
        '    cmbMedioPago.Items.Add("Otro medio de Pago")
        '    CmbBanco.Text = CLIENTE.CLI_ABANCO
        '    txtNumeroCta.Text = CLIENTE.cli_anrotarjeta
        '    cmbMes.Text = Mid(CLIENTE.CLI_ATARJETAVENCIMIENTO, 1, 2)
        '    cmbAnio.Text = Mid(CLIENTE.CLI_ATARJETAVENCIMIENTO, 4, 4)
        '    cmbTpoTarjeta.Text = CLIENTE.CLI_AMEDIO_PAGO
        'End If


        'cmbMedioPago.Items.Add("Otro medio de pago")

    End Sub


    Private Sub limpiarPrimeraPantalla()
        TxtEdad.Text = ""
        TxtRut.Text = ""
        Txt_Nombre.Text = ""
        Txtid.Text = ""
        TxtDireccion.Text = ""
        txtIntentos.Text = ""
        txtObs.Text = ""
        CmdAtras.Enabled = False
        limpiaring()

    End Sub

    Private Sub limpiaring()
        txtIdIng.Text = ""
        TxtNombreIng.Text = ""
        TxtPaternoIng.Text = ""
        TxtMaternoIng.Text = ""
        txtEmailIng.Text = ""
        txtAreaIng.Text = ""
        txtTelefonoing.Text = ""
        cmbComunaIng.SelectedIndex = -1
        dtFechaNacIng.Value = dtFechaNacIng.MaxDate
        txtNombre1contact.Text = ""
        txtNombre2contact.Text = ""
        txtaPaternocontact.Text = ""
        txtaMaternocontact.Text = ""
        txtRutcontact.Text = ""
        txtDvcontact.Text = ""

    End Sub

    Private Sub llenarDatosIng()
        Dim TotalDigito As Integer
        With CLIENTE
            txtIdIng.Text = .cli_id
            TxtNombreIng.Text = .cli_nombre
            TxtPaternoIng.Text = .cli_paterno
            TxtMaternoIng.Text = .cli_materno
            TotalDigito = Len(.cli_telefono1)
            If TotalDigito = 9 Then
                txtAreaIng.Text = "02"
                txtTelefonoing.Text = Trim(.cli_telefono1)
            End If
            If TotalDigito > 9 Then
                If Mid(.cli_telefono1, 1, 3) = "123" Then
                    txtAreaIng.Text = Mid(.cli_telefono1, 4, 2)
                    txtTelefonoing.Text = Mid(.cli_telefono1, 6, Len(.cli_telefono1))
                End If

                If Mid(.cli_telefono1, 1, 3) = "809" Then
                    txtAreaIng.Text = Mid(.cli_telefono1, 4, 1)
                    txtTelefonoing.Text = Mid(.cli_telefono1, 5, Len(.cli_telefono1))
                End If
            End If

            txtEmailIng.Text = .cli_email
            dtFechaNacIng.Value = IIf(.cli_fechanacimiento = "", dtFechaNacIng.MaxDate, .cli_fechanacimiento.Substring(6, 2) & "/" & .cli_fechanacimiento.Substring(4, 2) & "/" & .cli_fechanacimiento.Substring(0, 4))
            cmbComunaIng.SelectedValue = .CLI_ACODCOMUNA.Trim
        End With
    End Sub

#End Region

#Region "VALIDACIONES"
    Function DevuelveDias(ByVal fechaTermino As Date) As Integer
        Dim cantDias As Integer
        Dim i As Integer
        Dim j As Integer
        Dim diaActual As Date
        Dim CantFeriados As Integer
        CantFeriados = 0
        cantDias = 0
        fechaTermino = fechaTermino.Date()
        cantDias = DateDiff(DateInterval.Day, Now.Date, fechaTermino)
        diaActual = Now.Date

        For i = 0 To cantDias
            For j = 0 To UBound(feriados)
                If diaActual = feriados(j) Then
                    CantFeriados = CantFeriados + 1
                End If
            Next
            diaActual = DateAdd(DateInterval.Day, 1, diaActual)
        Next

        DevuelveDias = cantDias - CantFeriados + 1
    End Function

    ''' <summary>
    ''' validamos la informacion en la toma de datos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidaInformacion() As Boolean

        ValidaInformacion = False

        '' Validar Nombre
        If Len(Trim(txtNombre.Text)) < 3 Or _
            Len(Trim(txtPaterno.Text)) < 3 Or _
            Len(Trim(txtMaterno.Text)) < 3 Then
            MsgBox("Debe ingresar correctamente el NOMBRE COMPLETO del cliente ", vbInformation, "Callsouth.")
            txtNombre.Focus()
            Exit Function
        End If

        If Len(Trim(txtNombre2.Text)) < 3 Then
            If MsgBox("No ha ingresado segundo nombre del cliente, Cliente tiene segundo nombre?", MsgBoxStyle.YesNo, "Callsouth.") = MsgBoxResult.No Then
                txtNombre2.Focus()
            End If
            Exit Function
        End If

        If InStr(1, Trim(txtNombre.Text), Trim(txtNombre2.Text)) > 0 Or InStr(1, Trim(txtNombre2.Text), Trim(txtNombre.Text)) > 0 Then
            MsgBox("El nombre se encuentra duplicado", vbInformation, "Validacion de Nombre duplicado")
            txtNombre.Focus()
            txtNombre.SelectionLength = Len(Trim(txtNombre2.Text))
            Exit Function
        End If

        If InStr(1, Trim(txtNombre2.Text), Trim(txtNombre.Text)) > 0 Then
            MsgBox("El nombre se encuentra duplicado", vbInformation, "Validacion de Nombre duplicado")
            txtNombre2.Focus()
            txtNombre2.SelectionLength = Len(Trim(txtNombre.Text))
            Exit Function
        End If

        If Not vgFuncionComun.edad(dtFechaNac.Value, csEdadMinima, csEdadMaxima) Then
            MsgBox("La fecha de nacimiento no es válida.", vbInformation, "Callsouth.")
            Exit Function

        End If

        Select Case CmbSexo.SelectedIndex
            Case 0, -1
                MsgBox("Debe ingresar sexo del cliente.", MsgBoxStyle.Exclamation, csNombreAplicacion)
                CmbSexo.Focus()
                Exit Function
        End Select

        If txtArut.Text.Length < 7 Then
            MsgBox("El RUT del cliente no es valido.", vbInformation, "Callsotuh.")
            txtArut.Focus()
            Exit Function
        End If

        If Not vgFuncionComun.validarRut(Trim(txtArut.Text) & "-" & Trim(txtDv.Text)) Then
            MsgBox("El RUT del cliente no es valido.", vbInformation, "Callsouth.")
            txtArut.Focus()
            Exit Function
        End If

        'If perfil = "Regrabador" Then
        '    If txtArut.Text & txtDv.Text.ToUpper <> CLIENTE.cli_arut & CLIENTE.cli_adv.ToUpper Then
        '        MsgBox("El RUT del cliente es distinto al de la base original.", vbInformation, "Callsouth.")
        '        txtArut.Focus()
        '        Exit Function
        '    End If
        'Else
        '    If txtArut.Text & txtDv.Text.ToUpper <> CLIENTE.cli_rut & CLIENTE.cli_dv.ToUpper Then
        '        MsgBox("El RUT del cliente es distinto al de la base original.", vbInformation, "Callsouth.")
        '        txtArut.Focus()
        '        Exit Function
        '    End If
        'End If
        If txtFonoVenta.Text = "" Or txtFonoVenta.TextLength < 9 Then
            MsgBox("Debe ingresar fono venta valido 9 dígitos.", vbExclamation, csNombreAplicacion)
            txtFonoVenta.Focus()
            Exit Function
        End If

        If Trim(txtCelular.Text) <> "" Then
            If txtFonoVenta.TextLength < 9 Then
                MsgBox("Debe ingresar fono contacto valido 9 dígitos.", vbExclamation, csNombreAplicacion)
                txtCelular.Focus()
                Exit Function
            End If
        Else
            MsgBox("Debe ingresar un Número de celular", vbExclamation, csNombreAplicacion)
            txtCelular.Focus()
            Exit Function
        End If

        'If Trim(txtEmail.Text) <> "" Then
        '    If vgFuncionComun.ValidaEmail(txtEmail.Text) = False Then
        '        MsgBox("Correo ingresado no es valido.", MsgBoxStyle.Exclamation, csNombreAplicacion)
        '        txtEmail.Focus()
        '        Exit Function
        '    End If
        'Else
        '    MsgBox("Debe ingresar un email", vbExclamation, csNombreAplicacion)
        '    txtEmail.Focus()
        '    Exit Function
        'End If

        If Trim(txtEmail.Text) <> "" Then
            If vgFuncionComun.ValidaEmail(Trim(txtEmail.Text)) = False Then
                MsgBox("Correo ingresado no es valido.", MsgBoxStyle.Exclamation, csNombreAplicacion)
                txtEmail.Focus()
                Exit Function
            End If
        End If

        Dim correo As New eCorreoInvalido
        correo = listaCorreoInvalido.Find(Function(x As eCorreoInvalido) x.correo = txtEmail.Text)

        If Not correo Is Nothing Then
            MsgBox("El correo ingresado " + txtEmail.Text + " NO es válido, se eliminará el correo al momento de guardar.", MsgBoxStyle.Information)
            txtEmail.Text = ""
            Exit Function
        End If

        If txtEmail.Text = "" Then
            If MsgBox("Pasara la venta sin correo, desea proseguir?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Function

        End If


        Select Case CmbAutorizaCorreo.SelectedIndex
            Case -1, 0
                MsgBox("Debe indicar si cliente autoriza en envío de correo.", MsgBoxStyle.Exclamation, csNombreAplicacion)
                CmbAutorizaCorreo.Focus()
                Exit Function
        End Select

        If CmbAutorizaCorreo.Text = "SI" And Trim(txtEmail.Text) = "" Then
            MsgBox("Debe ingresar el correo electrónico.", MsgBoxStyle.Exclamation, csNombreAplicacion)
            txtEmail.Focus()
            Exit Function
        End If

        Select Case CmbSexo.SelectedIndex
            Case 0, -1
                MsgBox("Debe ingresar sexo del cliente.", MsgBoxStyle.Exclamation, csNombreAplicacion)
                CmbSexo.Focus()
                Exit Function
        End Select

        If Trim(txtCalle.Text) = "" Then
            MsgBox("El Campo calle es Obligatorio", vbExclamation, csNombreAplicacion)
            txtCalle.Focus()
            Exit Function
        End If

        If Trim(txtNro.Text) = "" Then
            MsgBox("El Campo Nº es obligatorio, si no tiene número ingrese S/N", vbExclamation, csNombreAplicacion)
            txtNro.Focus()
            Exit Function
        End If

        If InStr(1, Trim(txtCalle.Text), Trim(txtNro.Text)) > 0 Then
            If MsgBox("El Campo Nº ya se encuentra en la calle, ¿Se debe corregir esto? " & vbNewLine & txtCalle.Text & " " & txtNro.Text, vbOKCancel, "Validacion de Nro en Direccion") = vbOK Then
                txtCalle.Focus()
                txtCalle.SelectionStart = InStr(1, Trim(txtCalle.Text), Trim(txtNro.Text)) - 1
                txtCalle.SelectionLength = Len(Trim(txtNro.Text))
                Exit Function
            End If
        End If

        If cmbComuna.SelectedIndex = -1 Or cmbComuna.Text = "" Then
            MsgBox("Ingrese la comuna a la cual pertenece la dirección.", vbExclamation, csNombreAplicacion)
            cmbComuna.Focus()
            Exit Function
        End If


        If cmbCiudad.SelectedIndex = -1 Or cmbCiudad.Text = "" Or cmbCiudad.SelectedValue = 0 Then
            MsgBox("Ingrese la ciudad a la cual pertenece la comuna.", vbExclamation, csNombreAplicacion)
            cmbCiudad.Focus()
            Exit Function
        End If

        If cmbTipoContrato.SelectedIndex = -1 Or cmbTipoContrato.SelectedIndex = 0 Then
            MsgBox("Debe ingresar el tipo de contrato que se contratará.", vbExclamation, csNombreAplicacion)
            cmbTipoContrato.Focus()
            Exit Function
        End If

        If perfil = "Regrabador" Then
            If cmbPlan.SelectedIndex = -1 Then
                MsgBox("Debe selecionar el tipo de plan.", vbExclamation, csNombreAplicacion)
                cmbPlan.Focus()
                Exit Function
            End If
        Else
            If cmbPlan.SelectedValue = 0 Then
                MsgBox("Debe selecionar el tipo de plan.", vbExclamation, csNombreAplicacion)
                cmbPlan.Focus()
                Exit Function
            End If
        End If
        ValidaInformacion = True
    End Function

#End Region

#Region "ADICIONALES"
    ''' <summary>
    ''' PROCEDIMIENTO PARA CARGAR LOS ADICIONALES EN LA GRILLA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Carga_adicionales()

        lstAdi = biClsAdic.Carga_Adicional(CLIENTE.cli_arut, CLIENTE.cli_id)
        dtAdicional.DataSource = lstAdi
        'Si no pongo esta línea, se crean automáticamente los campos del grid dependiendo de los campos del DataTable
        dtAdicional.AutoGenerateColumns = False
        'Aquí le indico cuales campos del select de mi SP van con los campos de mi grid
        With dtAdicional
            .Columns("nombre").DataPropertyName = "A_NOMBRE"
            .Columns("paterno").DataPropertyName = "A_PATERNO"
            .Columns("materno").DataPropertyName = "A_MATERNO"
            .Columns("rut").DataPropertyName = "A_RUT"
            .Columns("dv").DataPropertyName = "A_DV"
            .Columns("tipo_parentesco").DataPropertyName = "A_PARENTESCO"
            .Columns("fechaNacimiento").DataPropertyName = "A_FECNACIMIENTO"
            .Columns("sexo").DataPropertyName = "A_SEXO"
            '.Columns("primaUf").DataPropertyName = "primaUf"
            .Columns("idPlan").DataPropertyName = "idPlan"
        End With
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If ValAdicional(1) Then
            Call paModificaAdicional()
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        If (MsgBox("Desea eliminar el adicional seleccionado", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, csNombreAplicacion)) = MsgBoxResult.No Then Exit Sub

        If paEliminaAdicional() Then
            MsgBox("Adicional eliminado", MsgBoxStyle.Information, csNombreAplicacion)
        Else
            MsgBox("No se ha podido eliminar el adicional, favor verificar rut", MsgBoxStyle.Exclamation, csNombreAplicacion)
            txtRutA.Focus()
        End If

    End Sub

    Private Sub dtAdicional_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtAdicional.CellClick

        If e.RowIndex = -1 Then Exit Sub

        txtNombreA.Text = dtAdicional.Rows(e.RowIndex).Cells("nombre").Value
        txtNombreA2.Text = dtAdicional.Rows(e.RowIndex).Cells("nombre2").Value
        txtPaternoA.Text = dtAdicional.Rows(e.RowIndex).Cells("paterno").Value
        txtMaternoA.Text = dtAdicional.Rows(e.RowIndex).Cells("materno").Value
        txtRutA.Text = dtAdicional.Rows(e.RowIndex).Cells("rut").Value
        txtDvA.Text = dtAdicional.Rows(e.RowIndex).Cells("dv").Value
        cmbParentescoAdic.Text = dtAdicional.Rows(e.RowIndex).Cells("tipo_parentesco").Value
        dtFechaNacAdic.Value = dtAdicional.Rows(e.RowIndex).Cells("fechaNacimiento").Value
        cmbSexoA.Text = dtAdicional.Rows(e.RowIndex).Cells("Sexo").Value
        cmbSaludAdic.Text = dtAdicional.Rows(e.RowIndex).Cells("SistemaSalud").Value

        numeroFila = e.RowIndex
    End Sub

    Private Function paEliminaAdicional() As Boolean

        paEliminaAdicional = False

        For i As Int16 = 0 To dtAdicional.Rows.Count - 1
            If dtAdicional.Rows(i).Cells("rut").Value = txtRutA.Text Then
                If perfil <> "Regrabador" Then
                    dtAdicional.Rows.RemoveAt(i)
                    paEliminaAdicional = True
                    sumaUFAdicionales()
                    Exit Function
                Else
                    Dim entityRem As eAdicional = lstAdi.FirstOrDefault(Function(e) e.a_rut = txtRutA.Text)
                    If entityRem IsNot Nothing Then
                        lstAdi.Remove(entityRem)
                        dtAdicional.DataSource = Nothing
                        dtAdicional.DataSource = lstAdi
                        dtAdicional.Refresh()
                    End If
                    paEliminaAdicional = True
                    sumaUFAdicionales()
                    Exit Function
                End If
            End If
        Next

    End Function

    Private Sub sumaUFAdicionales()
        Dim uf As Double = 0
        totalUfAdic = 0
        For i As Integer = 0 To dtAdicional.RowCount - 1
            uf = CDbl(dtAdicional.Item("valorUf", i).Value)
            totalUfAdic = totalUfAdic + uf
        Next

        lblTotalPrimaUf.Text = "Total UF: " + (totalUfAdic + CDbl(ePlanGlobal.primaUF)).ToString
        lblPrimaUF.Text = (totalUfAdic + CDbl(ePlanGlobal.primaUF)).ToString

        Dim SumaUF As Double
        Dim UfNumerico As Double = ePlanGlobal.primaUF
        SumaUF = (totalUfAdic + UfNumerico)

        TotalPesos = CInt(Math.Round(SumaUF * CDbl(valorPesosUf)))
        totalUfAdic = totalUfAdic + CDbl(ePlanGlobal.primaUF)

        lblPesosUF.Text = "Valor Pesos: " + TotalPesos.ToString
        lblPrimaPesos.Text = TotalPesos.ToString

    End Sub

    Private Sub paModificaAdicional()

        LlenaParentescoCondicion()

        If perfil <> "Regrabador" Then
            If dtAdicional.Rows.Count <> 0 Then
                dtAdicional.Rows(numeroFila).Cells("nombre").Value = txtNombreA.Text
                dtAdicional.Rows(numeroFila).Cells("nombre2").Value = txtNombreA2.Text
                dtAdicional.Rows(numeroFila).Cells("paterno").Value = txtPaternoA.Text
                dtAdicional.Rows(numeroFila).Cells("materno").Value = txtMaternoA.Text
                dtAdicional.Rows(numeroFila).Cells("rut").Value = txtRutA.Text
                dtAdicional.Rows(numeroFila).Cells("dv").Value = txtDvA.Text
                dtAdicional.Rows(numeroFila).Cells("tipo_parentesco").Value = cmbParentescoAdic.Text
                dtAdicional.Rows(numeroFila).Cells("fechaNacimiento").Value = dtFechaNacAdic.Value.ToString("yyyy-MM-dd")
                dtAdicional.Rows(numeroFila).Cells("ValorUf").Value = ufAdic
                dtAdicional.Rows(numeroFila).Cells("idPlan").Value = idPlanAdic
                dtAdicional.Rows(numeroFila).Cells("sistemaSalud").Value = cmbSaludAdic.Text
            Else
                MsgBox("Debe agregar Primero antes de Modificar!.", vbInformation, csNombreAplicacion)
                Exit Sub
            End If
        Else
            If dtAdicional.Rows.Count <> 0 Then
                Dim entityToEdit As eAdicional = lstAdi.FirstOrDefault(Function(e) e.a_rut = txtRutA.Text)
                If entityToEdit IsNot Nothing Then
                    entityToEdit.a_nombre = txtNombreA.Text
                    entityToEdit.a_nombre2 = txtNombreA2.Text
                    entityToEdit.a_paterno = txtPaternoA.Text
                    entityToEdit.a_materno = txtMaternoA.Text
                    entityToEdit.a_sexo = cmbSexoA.Text
                    entityToEdit.a_parentesco = cmbParentescoAdic.Text
                    entityToEdit.a_id_parentesco = cmbParentescoAdic.SelectedValue
                    entityToEdit.a_fecnacimiento = dtFechaNacAdic.Value.ToString("yyyy-MM-dd")
                    entityToEdit.a_primaUf = ufAdic
                    entityToEdit.idPlanAdic = idPlanAdic
                    entityToEdit.a_salud = cmbSaludAdic.Text

                    dtAdicional.DataSource = Nothing
                    dtAdicional.DataSource = lstAdi
                    dtAdicional.Refresh()
                End If
            Else
                MsgBox("Debe agregar Primero antes de Modificar!.", vbInformation, csNombreAplicacion)
                Exit Sub
            End If
        End If
        Call limpiaAdicionales()
        btnModificar.Enabled = True
        btnAgregar.Enabled = True
        sumaUFAdicionales()
    End Sub

    Private Function ValAdicional(ByVal num As Integer) As Boolean

        If txtNombreA.Text = "" Then
            MsgBox("El campo nombre es obligatorio.", vbExclamation, csNombreAplicacion)
            txtNombreA.Focus()
            Exit Function
        ElseIf Len(txtNombreA.Text) < 2 Then
            MsgBox("El nombre ingresado No es valido.", vbExclamation, csNombreAplicacion)
            txtNombreA.Focus()
            Exit Function
        End If

        If Len(Trim(txtNombreA2.Text)) < 3 Then
            If MsgBox("No ha ingresado segundo nombre del Asegurado, Asegurado tiene segundo nombre?", MsgBoxStyle.YesNo, "Callsouth.") = MsgBoxResult.Yes Then
                txtNombreA2.Focus()
                Exit Function
            End If
        End If

        If InStr(1, Trim(txtNombreA2.Text), Trim(txtNombreA.Text)) > 0 Then
            MsgBox("El nombre se encuentra duplicado", vbInformation, "Validacion de Nombre duplicado")
            txtNombreA2.Focus()
            txtNombreA2.SelectionLength = Len(Trim(txtNombreA.Text))
            Exit Function
        End If


        If txtPaternoA.Text = "" Then
            MsgBox("El campo Apellido Paterno es obligatorio.", vbExclamation, csNombreAplicacion)
            txtPaternoA.Focus()
            Exit Function
        ElseIf Len(txtPaternoA.Text) < 2 Then
            MsgBox("El Apellido Paterno ingresado, No es valido.", vbExclamation, csNombreAplicacion)
            txtPaternoA.Focus()
            Exit Function
        End If
        If txtMaternoA.Text = "" Then
            MsgBox("El campo Apellido Materno es obligatorio.", vbExclamation, csNombreAplicacion)
            txtMaternoA.Focus()
            Exit Function
        ElseIf Len(txtMaternoA.Text) < 2 Then
            MsgBox("El Apellido Materno ingresado, No es valido.", vbExclamation, csNombreAplicacion)
            txtMaternoA.Focus()
            Exit Function
        End If

        If cmbSexoA.SelectedIndex = -1 Or cmbSexoA.SelectedIndex = 0 Then
            MsgBox("Debe seleccionar el sexo.", vbExclamation, csNombreAplicacion)
            cmbSexoA.Focus()
            Exit Function
        End If

        If cmbParentescoAdic.SelectedIndex = -1 Or cmbParentescoAdic.SelectedIndex = 0 Then
            MsgBox("Debe seleccionar el parentesco de la carga.", vbExclamation, csNombreAplicacion)
            cmbParentescoAdic.Focus()
            Exit Function
        End If

        'If cmbSaludAdic.SelectedIndex < 1 Then
        '    MsgBox("Debe seleccionar el sistema de salud del adicional.", vbExclamation, csNombreAplicacion)
        '    cmbSaludAdic.Focus()
        '    Exit Function
        'End If

        If txtRutA.Text <> "" Then
            '    MsgBox("Debe ingresar rut del Adicional", MsgBoxStyle.Exclamation, csNombreAplicacion)
            '    txtRutA.Focus()
            '    Exit Function
            'Else
            If Not vgFuncionComun.validarRut(Trim(txtRutA.Text) & "-" & Trim(txtDvA.Text)) Then
                MsgBox("El RUT del Adicional no es valido.", vbInformation, "Callsouth.")
                txtRutA.Focus()
                Exit Function
            End If
        End If

        If txtRutA.Text = CLIENTE.cli_arut Then
            MsgBox("El RUT del Adicional no puede ser igual al rut del titular.", vbInformation, "Callsouth.")
            txtRutA.Focus()
            Exit Function
        End If

        If num = 0 Then
            For x As Int16 = 0 To dtAdicional.Rows.Count - 1
                If dtAdicional.Rows(x).Cells("rut").Value = txtRutA.Text Then
                    MsgBox("Titular ya se encuentra ingresado con ese rut", vbInformation, "Callsouth")
                    txtRutA.Focus()
                    Exit Function
                End If
            Next
        End If

        ValAdicional = True
    End Function

    Private Sub btnAdicional_Click(sender As Object, e As EventArgs) Handles btnAdicional.Click
        Cuerpo.TabPages.Add(_Cuerpo_Adicionales)
        totalUfAdic = 0
        If cmbTipoContrato.SelectedIndex <> 0 And cmbTipoContrato.SelectedIndex <> -1 Then
            listParentescoCampania = biClsParentescoCampania.BuscarParentescoPorId(vgCampania.calCodigo, 2)
            vgFuncionComun.llenaComboBox(cmbParentescoAdic, "nombreParentesco", "idParentesco", listParentescoCampania.ToArray)
        End If

        'sumaUFAdicionales()
        limpiaAdicionales()

        Cuerpo.TabPages.Item(0).Parent = Nothing
        guardarPantallaAnterior(3)
    End Sub

#End Region

#Region "BENEFICIARIOS"

    ''' <summary>
    ''' PROCEDIMIENTO PARA CARGAR LOS BENEFICIARIOS EN LA GRILLA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Carga_Beneficiarios()

        lstBen = biClsBen.CargaBeneficiarios(CLIENTE.cli_arut, CLIENTE.cli_id)
        frmBeneficiario.dtBeneficiario.DataSource = lstBen
        'Si no pongo esta línea, se crean automáticamente los campos del grid dependiendo de los campos del DataTable
        frmBeneficiario.dtBeneficiario.AutoGenerateColumns = False
        'Aquí le indico cuales campos del select de mi SP van con los campos de mi grid
        With frmBeneficiario.dtBeneficiario
            .Columns("nombreBen").DataPropertyName = "B_NOMBRE1"
            .Columns("nombre2Ben").DataPropertyName = "B_NOMBRE2"
            .Columns("paternoBen").DataPropertyName = "B_PATERNO"
            .Columns("maternoBen").DataPropertyName = "B_MATERNO"
            .Columns("rutBen").DataPropertyName = "B_RUT"
            .Columns("dvBen").DataPropertyName = "B_DV"
            .Columns("tipo_parentescoBen").DataPropertyName = "B_PARENTESCO_TEXT"
            .Columns("porcentaje").DataPropertyName = "B_PCTJE"
            .Columns("idParentescoBen").DataPropertyName = "B_PARENTESCO"
            '.Columns("fecNacBen").DataPropertyName = "B_FECHA_NAC"
        End With
    End Sub


    Private Sub limpiaAdicionales()
        txtNombreA.Text = ""
        txtNombreA2.Text = ""
        txtPaternoA.Text = ""
        txtMaternoA.Text = ""
        txtRutA.Text = ""
        txtDvA.Text = ""
        dtFechaNacAdic.Value = dtFechaNacAdic.MinDate
        cmbParentescoAdic.SelectedIndex = 0
        cmbSexoA.SelectedIndex = 0
        cmbSaludAdic.SelectedIndex = 0
    End Sub

    Private Sub btnBeneficiarios_Click(sender As Object, e As EventArgs) Handles btnBeneficiarios.Click
        If cmbTipoContrato.SelectedIndex <> 0 And cmbTipoContrato.SelectedIndex <> -1 Then

            frmBeneficiario.ShowDialog()
            'Me.Close()

        End If
    End Sub

#End Region


#Region "SCRIPTS"

    Private Function ScriptLblFinNoC() As String
        Dim mensaje As String
        mensaje = "Disculpe las molestias, gracias por su tiempo y que tenga un buen día." & vbNewLine
        ScriptLblFinNoC = mensaje
    End Function

    Private Function ScriptLblFinNoCumple() As String
        Dim mensaje As String
        mensaje = "Sr./Sra " & Trim$(CLIENTE.cli_nombre) & "  " & Trim$(CLIENTE.cli_paterno) & " " & Trim$(CLIENTE.cli_materno) & " Lamentablemente no podemos entregar el seguro ya no cumple con alguno de los requisitos anteriormente mencionado. Muchas gracias por su tiempo. " & vbNewLine
        ScriptLblFinNoCumple = mensaje
    End Function

#End Region


    Public Function CargaScript(ByVal _idTipoScript As Int32) As eScript

        Dim script As New eScript
        Dim biScript As New clsScriptBI
        script = biScript.BuscarScriptPorIdTipoScript(vgCampania.calCodigo, _idTipoScript)

        'datos generales
        script.contenidoScript = Replace(script.contenidoScript, "[FechaActual]", Now())
        script.contenidoScript = Replace(script.contenidoScript, "[Persona.Campo1]", CLIENTE.campo1)
        script.contenidoScript = Replace(script.contenidoScript, "[Persona.Campo2]", CLIENTE.campo2)
        script.contenidoScript = Replace(script.contenidoScript, "[Persona.Campo3]", CLIENTE.campo3)
        script.contenidoScript = Replace(script.contenidoScript, "[Persona.Campo4]", CLIENTE.campo4)
        script.contenidoScript = Replace(script.contenidoScript, "[Persona.Campo5]", CLIENTE.campo5)
        script.contenidoScript = Replace(script.contenidoScript, "[Persona.Campo6]", CLIENTE.campo6)
        script.contenidoScript = Replace(script.contenidoScript, "[Persona.Campo7]", CLIENTE.campo7)
        script.contenidoScript = Replace(script.contenidoScript, "[Persona.Campo8]", CLIENTE.campo8)
        script.contenidoScript = Replace(script.contenidoScript, "[Persona.Campo9]", CLIENTE.campo9)
        script.contenidoScript = Replace(script.contenidoScript, "[Persona.Campo10]", CLIENTE.campo10)

        If (script.idTipoScript < 3) Then '1.Bienvenida  2.Presentacion  3.Informacion Adicional

            '[Persona.nombre] [Persona.paterno] [Persona.materno]
            script.contenidoScript = Replace(script.contenidoScript, "[Agente.Nombre]", Replace(WS_IDUSUARIO, ".", " "))
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.nombre]", CLIENTE.cli_nombre)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.paterno]", CLIENTE.cli_paterno)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.materno]", CLIENTE.cli_materno)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.fechaNacimiento]", CLIENTE.cli_fechanacimiento)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.Rut]", CLIENTE.cli_rut & "-" & CLIENTE.cli_dv)
            script.contenidoScript = Replace(script.contenidoScript, "[DireccionParticular]", CLIENTE.cli_direccion)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.Comuna]", CLIENTE.cli_comuna)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.Ciudad]", CLIENTE.cli_ciudad)

        Else
            'datos venta

            script.contenidoScript = Replace(script.contenidoScript, "[Persona.nombre]", CLIENTE.cli_anombre)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.paterno]", CLIENTE.cli_apaterno)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.materno]", CLIENTE.cli_amaterno)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.fechaNacimiento]", CLIENTE.cli_afechanacimiento)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.Rut]", CLIENTE.cli_arut & "-" & CLIENTE.cli_adv)
            script.contenidoScript = Replace(script.contenidoScript, "[DireccionParticular]", CLIENTE.cli_acalle & " " & CLIENTE.cli_anro & " " & CLIENTE.CLI_AREFERENCIA)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.Comuna]", CLIENTE.cli_acomuna)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.mail]", CLIENTE.cli_aemail)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.FonoVenta]", CLIENTE.cli_afonovta)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.FonoContacto]", CLIENTE.CLI_AFONOCONTACTO)
            script.contenidoScript = Replace(script.contenidoScript, "[medioPago]", CLIENTE.CLI_AMEDIO_PAGO)
            script.contenidoScript = Replace(script.contenidoScript, "[banco]", CLIENTE.CLI_ABANCO)
            script.contenidoScript = Replace(script.contenidoScript, "[PrimaUf]", CLIENTE.cli_primauf)
            script.contenidoScript = Replace(script.contenidoScript, "[PrimaPesos]", CLIENTE.cli_primapesos)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.numeroTarjeta]", CLIENTE.cli_anrotarjeta)
            script.contenidoScript = Replace(script.contenidoScript, "[Persona.email]", CLIENTE.cli_aemail)
            script.contenidoScript = Replace(script.contenidoScript, "[CodigoVerificacion]", CLIENTE.cli_codverificacion)

            'Beneficiarios
            Dim beneficiario As New eBeneficiario

            For x As Int16 = 0 To lstBen.Count - 1

                script.contenidoScript = Replace(script.contenidoScript, "BeneficiarioNombre" + (x + 1).ToString, lstBen(x).b_nombre1)
                script.contenidoScript = Replace(script.contenidoScript, "BeneficiarioNombre" + (x + 1).ToString, lstBen(x).b_nombre2)
                script.contenidoScript = Replace(script.contenidoScript, "BeneficiarioPaterno" + (x + 1).ToString, lstBen(x).b_paterno)
                script.contenidoScript = Replace(script.contenidoScript, "BeneficiarioMaterno" + (x + 1).ToString, lstBen(x).b_materno)
                script.contenidoScript = Replace(script.contenidoScript, "BeneficiarioFechaNacimiento" + (x + 1).ToString, lstBen(x).b_fec_nac)
                script.contenidoScript = Replace(script.contenidoScript, "BeneficiarioRut" + (x + 1).ToString, lstBen(x).b_rut + "-" + lstBen(x).b_dv)
                script.contenidoScript = Replace(script.contenidoScript, "BeneficiarioParentesco" + (x + 1).ToString, lstBen(x).parentesco_text)
                script.contenidoScript = Replace(script.contenidoScript, "BeneficiarioPorcentaje" + (x + 1).ToString, lstBen(x).b_pctje)

            Next

        End If

        Return script

    End Function

    Private Sub llenar_planes()
        Dim biplan As New clsPlanBI
        Dim listPlan As New List(Of ePlan)
        Dim plan As New ePlan
        plan.idPlan = 0
        plan.primaUF = "---No ingresado---"
        listPlan.Add(plan)

        listPlan = biplan.BuscarPlanPorTipoContrato(cmbTipoContrato.SelectedValue, vgCampania.calCodigo)

        vgFuncionComun.llenaComboBox(cmbPlan, "primaUF", "idPlan", listPlan.ToArray)
    End Sub

    Private Sub cmbPlan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPlan.SelectedIndexChanged

        If cmbPlan.SelectedIndex <> -1 And cmbPlan.SelectedIndex <> 0 Then
            ePlanGlobal = biClsPlan.BuscarPlanPorIdPlan(cmbPlan.SelectedValue)

            lblPrimaUF.Text = ePlanGlobal.primaUF
            lblPrimaPesos.Text = ePlanGlobal.primaCalculada

            'lblPrimaUF.Text = IIf(totalUfAdic = 0, ePlanGlobal.primaUF, totalUfAdic).ToString
            'lblPrimaPesos.Text = IIf(TotalPesos = 0, ePlanGlobal.primaCalculada, TotalPesos)
        Else
            lblPrimaUF.Text = 0
            lblPrimaPesos.Text = 0
        End If

    End Sub

    Private Sub dtFechaNac_ValueChanged(sender As Object, e As EventArgs) Handles dtFechaNac.ValueChanged

        If dtFechaNac.Text <> "" Then
            txtCalculaEdad.Text = DateDiff(DateInterval.Year, Date.Parse(dtFechaNac.Text), Date.UtcNow)
        End If

        If cmbTipoContrato.SelectedIndex <> -1 And cmbTipoContrato.SelectedIndex <> 0 Then
            LlenaPlanesCondicion()
        Else
            lblPrimaUF.Text = "0"
            lblPrimaPesos.Text = "0"
        End If

    End Sub

    Private Function paInsertaAdicional() As Boolean

        If perfil <> "Regrabador" Then

            Dim FilaTotal As Integer

            FilaTotal = dtAdicional.Rows.Count + 1

            Dim TpoContratoAdicional As New eTipoContrato

            TpoContratoAdicional = biClsTipoContrato.BuscarTipoContratoPorIdTipoContrato(tipoContrato.idTipoContrato)

            FilaAgregar = dtAdicional.Rows.Count

            dtAdicional.Rows.Add(1)
            dtAdicional.Item("nombre", FilaAgregar).Value = txtNombreA.Text
            dtAdicional.Item("nombre2", FilaAgregar).Value = txtNombreA2.Text
            dtAdicional.Item("paterno", FilaAgregar).Value = txtPaternoA.Text
            dtAdicional.Item("materno", FilaAgregar).Value = txtMaternoA.Text
            dtAdicional.Item("rut", FilaAgregar).Value = txtRutA.Text
            dtAdicional.Item("dv", FilaAgregar).Value = txtDvA.Text
            dtAdicional.Item("Sexo", FilaAgregar).Value = cmbSexoA.Text
            dtAdicional.Item("idParentescoAdi", FilaAgregar).Value = cmbParentescoAdic.SelectedValue
            dtAdicional.Item("tipo_parentesco", FilaAgregar).Value = cmbParentescoAdic.Text
            dtAdicional.Item("fechaNacimiento", FilaAgregar).Value = dtFechaNacAdic.Value.ToString("yyyy-MM-dd")
            dtAdicional.Item("valorUf", FilaAgregar).Value = ufAdic.ToString
            dtAdicional.Item("idPlan", FilaAgregar).Value = idPlanAdic.ToString
            dtAdicional.Item("SistemaSalud", FilaAgregar).Value = cmbSaludAdic.Text.ToString
        Else
            lstAdi.Add(New eAdicional() With { _
             .a_nombre = txtNombreA.Text, _
             .a_nombre2 = txtNombreA2.Text, _
             .a_paterno = txtPaternoA.Text, _
             .a_materno = txtMaternoA.Text, _
             .a_rut = txtRutA.Text, _
             .a_dv = txtDvA.Text, _
             .a_sexo = cmbSexoA.Text, _
             .a_id_parentesco = cmbParentescoAdic.SelectedValue,
             .a_parentesco = cmbParentescoAdic.Text,
             .a_fecnacimiento = dtFechaNacAdic.Value.ToString("yyyy-MM-dd"), _
             .a_primaUf = ufAdic.ToString, _
             .idPlanAdic = idPlanAdic, _
             .a_salud = cmbSaludAdic.Text
        })
            dtAdicional.DataSource = Nothing
            dtAdicional.DataSource = lstAdi
            dtAdicional.Refresh()

        End If
        Call limpiaAdicionales()
        paInsertaAdicional = True
    End Function


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim biMedioPago As New clsMedioPagoBI

        If validaMedioPago() = True Then

            Dim medioPago As New eMedioPago
            medioPago = biMedioPago.BuscaDatosMedioPagoPorId(vgCampania.calCodigo, CLIENTE.cli_id, cmbMedioPago.SelectedValue)


            If perfil <> "Regrabador" Then

                CLIENTE.CLI_ABANCO = IIf(medioPago.otroMedioPago = True, CmbBanco.Text, "")
                CLIENTE.cli_AAVTO_TARJ = IIf(medioPago.otroMedioPago = True, cmbMes.Text + "/" + cmbAnio.Text, 0)
                CLIENTE.cli_anrotarjeta = IIf(medioPago.otroMedioPago = True, txtNumeroCta.Text, txtUltDigitos.Text)
                'CLIENTE.CLI_AMEDIO_PAGO = IIf(medioPago.otroMedioPago = True, cmbTpoTarjeta.Text, Mid(cmbMedioPago.Text, 1, InStr(cmbMedioPago.Text, "-") - 1))

                If (medioPago.otroMedioPago = True) Then
                    CLIENTE.CLI_AMEDIO_PAGO = cmbTpoTarjeta.Text
                Else
                    CLIENTE.CLI_AMEDIO_PAGO = Mid(cmbMedioPago.Text, 1, InStr(cmbMedioPago.Text, "-") - 1)
                End If

                'txtNumeroCta.Text
                'CLIENTE.CLI_DIACARGO = IIf(CmbDiaCargo.Visible = True, CmbDiaCargo.Text, "0")
            Else
                CLIENTE.cli_anrotarjeta = IIf(medioPago.otroMedioPago = True, txtNumeroCta.Text, txtUltDigitos.Text)
                CLIENTE.CLI_ABANCO = IIf(medioPago.otroMedioPago = True, CmbBanco.Text, CLIENTE.CLI_ABANCO)
                CLIENTE.cli_AAVTO_TARJ = IIf(medioPago.otroMedioPago = True, cmbMes.Text + "/" + cmbAnio.Text, CLIENTE.cli_AAVTO_TARJ)

                If (medioPago.otroMedioPago = True) Then
                    CLIENTE.CLI_AMEDIO_PAGO = cmbTpoTarjeta.Text
                Else
                    CLIENTE.CLI_AMEDIO_PAGO = Mid(cmbMedioPago.Text, 1, InStr(cmbMedioPago.Text, "-") - 1)
                End If

                'CLIENTE.CLI_DIACARGO = IIf(CmbDiaCargo.Visible = True, CmbDiaCargo.Text, "0")
            End If

            'CERTIFIOCACION
            clsScript = CargaScript(4)
            WebInfAdicional.DocumentText = clsScript.contenidoScript

            Cuerpo.TabPages.Add(_Cuerpo_InfAdic)
            Cuerpo.TabPages.Item(0).Parent = Nothing
            guardarPantallaAnterior(4)

        End If

    End Sub

    Private Function validaMedioPago() As Boolean

        Dim biMedioPago As New clsMedioPagoBI
        Dim medioPagoTar As New eMedioPago
        medioPagoTar = biMedioPago.BuscaMedioPagoPorId(cmbMedioPago.SelectedValue)

        validaMedioPago = False
        If medioPagoTar.otroMedioPago = True Then
            If CmbBanco.SelectedIndex = 0 Or CmbBanco.SelectedIndex = -1 Then
                MsgBox("Debe ingresar el banco.", MsgBoxStyle.Information, "CALLSOUTH")
                CmbBanco.Focus()
                Exit Function
            End If

            If txtNumeroCta.Text.Trim = "" Or Len(txtNumeroCta.Text.Trim) < 4 Then
                MsgBox("Debe ingresar los números de la tarjeta.", MsgBoxStyle.Information, "CALLSOUTH")
                txtNumeroCta.Focus()
                Exit Function
            End If

            If cmbMes.SelectedIndex = 0 Or cmbMes.SelectedIndex = -1 Then
                MsgBox("Debe ingresar el mes vencimiento de tarjeta.", MsgBoxStyle.Information, "CALLSOUTH")
                cmbMes.Focus()
                Exit Function
            End If

            If cmbAnio.SelectedIndex = 0 Or cmbAnio.SelectedIndex = -1 Then
                MsgBox("Debe ingresar el mes vencimiento de tarjeta.", MsgBoxStyle.Information, "CALLSOUTH")
                cmbAnio.Focus()
                Exit Function
            End If

            If cmbTpoTarjeta.SelectedIndex = 0 Or cmbTpoTarjeta.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar el tipo de tarjeta.", MsgBoxStyle.Information, "CALLSOUTH")
                cmbTpoTarjeta.Focus()
                Exit Function
            End If

        Else

            If cmbMedioPago.SelectedIndex = -1 Or cmbMedioPago.SelectedIndex = 0 Then
                MsgBox("Debe ingresar el medio de pago seleccionado por el cliente.", MsgBoxStyle.Information, "CALLSOUTH")
                cmbMedioPago.Focus()
                Exit Function
            End If

            If txtUltDigitos.Text.Length < 4 Or txtUltDigitos.Text.Length > 4 Then
                MsgBox("Debe ingresar los 4 ultimos números.", MsgBoxStyle.Information, "CALLSOUTH")
                txtUltDigitos.Focus()
                Exit Function
            End If

        End If
        validaMedioPago = True
    End Function

    Private Sub cmbAceptaPrima_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAceptaPrima.SelectedIndexChanged
        If cmbAceptaPrima.SelectedIndex = 1 Then

            'Script de certificación
            clsScript = CargaScript(5)
            WebBrowsercierre.DocumentText = clsScript.contenidoScript

            WebBrowsercierre.Visible = True
        Else
            WebBrowsercierre.Visible = False
        End If
    End Sub

    Private Sub cmbTipoContrato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoContrato.SelectedIndexChanged

        If cmbTipoContrato.SelectedIndex <> -1 And cmbTipoContrato.SelectedIndex <> 0 Then
            LlenaPlanesCondicion()
        Else
            lblPrimaUF.Text = "0"
            lblPrimaPesos.Text = "0"
        End If

    End Sub

    Private Sub LlenaPlanesCondicion()

        Dim tmpPlanes As New List(Of ePlan)
        Dim plan As New ePlan
        plan.idPlan = 0
        plan.primaUF = "---No ingresado---"
        plan.descripcionPlan = "---No ingresado---"
        tmpPlanes.Add(plan)

        If cmbTipoContrato.SelectedIndex <> -1 And cmbTipoContrato.SelectedIndex <> 0 Then

            tipoContrato.idTipoContrato = cmbTipoContrato.SelectedValue 'siempre analizara restriccion del titular
            listPlanes = biClsPlan.BuscarPlanPorTipoContrato(tipoContrato.idTipoContrato, vgCampania.calCodigo)
            Dim listRestriccion As New List(Of eRestriccion)

            For x As SByte = 0 To listPlanes.Count - 1
                planE = biClsPlan.BuscarPlanPorIdPlan(listPlanes(x).idPlan)

                listRestriccion = biClsRestricion.BuscarRestriccionPorIdPlan(planE.idPlan)
                Dim count As Int16 = 0
                For y As SByte = 0 To listRestriccion.Count - 1
                    restricionE.idRestriccionPlan = listRestriccion(y).idRestriccionPlan
                    restricionE.idPlan = listRestriccion(y).idPlan
                    restricionE.operacion = listRestriccion(y).operacion

                    Dim edadCliente As Int16 = edad(dtFechaNac.Value) 'DateDiff(DateInterval.Year, Date.Parse(dtFechaNac.Text), Date.UtcNow)

                    Select Case listRestriccion(y).operacion
                        Case ">"
                            If edadCliente > listRestriccion(y).valorRestriccion Then
                                count += 1
                            End If
                        Case "<"
                            If edadCliente < listRestriccion(y).valorRestriccion Then
                                count += 1
                            End If
                        Case "="
                            If edadCliente <> listRestriccion(y).valorRestriccion Then
                                count += 1
                            End If
                        Case "<="
                            If edadCliente <> listRestriccion(y).valorRestriccion Then
                                count += 1
                            End If
                        Case ">="
                            If edadCliente <> listRestriccion(y).valorRestriccion Then
                                count += 1
                            End If
                    End Select

                Next

                If count = 2 Then
                    tmpPlanes.Add(planE)
                    Dim TpoContrato As New eTipoContrato
                    TpoContrato = biClsTipoContrato.BuscarTipoContratoPorIdTipoContrato(tipoContrato.idTipoContrato)
                    btnAdicional.Visible = IIf(TpoContrato.cantidadAdicionales > 0, True, False)
                    btnBeneficiarios.Visible = IIf(TpoContrato.cantidadBeneficiarios > 0, True, False)
                End If
            Next
        End If

        If tmpPlanes.ToArray.Count > 0 Then
            cmbPlan.Visible = True
            lblPlanes.Visible = True
            vgFuncionComun.llenaComboBox(cmbPlan, "descripcionPlan", "idplan", tmpPlanes.ToArray)
        Else
            cmbPlan.Visible = False
            lblPlanes.Visible = False
        End If

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        clsScript = CargaScript(5)
        wbScriptCertificacion.DocumentText = clsScript.contenidoScript

        Cuerpo.TabPages.Add(_Cuerpo_Certifica)
        Cuerpo.TabPages.Item(0).Parent = Nothing
        guardarPantallaAnterior(5)
    End Sub

    Private Sub CmdFinVenta_Click(sender As Object, e As EventArgs) Handles CmdFinVenta.Click

        CLIENTE.cli_estado = "T"
        CLIENTE.cli_venta = "1"
        CLIENTE.cli_fechavta = Today.ToString("yyyyMMdd")
        CLIENTE.cli_horavta = TimeOfDay.ToString("HHmmss")
        If perfil <> "Regrabador" Then

            CLIENTE.cli_call_id = WS_CALL_ID
            CLIENTE.cli_acepta_prima = "Si"
            biCliente.GuardaDatosCliente(CLIENTE)
            biCliente.GuardaDatosLog(CLIENTE.cli_id)
            InsertaAdicionales()
            InsertaBeneficiarios()

            MsgBox("Fin de la gestión. Presione ACEPTAR para continuar con el siguiente registro.", MsgBoxStyle.Information, "CALLSOUTH")
            limpiarPrimeraPantalla()
            Buscar_Cliente()
        Else
            CLIENTE.CLI_CALL_ID_CALIDAD = WS_CALL_ID
            CLIENTE.CLI_AFONOCONTACTO = Fono_A_Llamar
            CLIENTE.CLI_ESTADO_OBJECION_CALIDAD = 1
            biGesRes.GuardaClienteGes(CLIENTE, vgCampania.calCodigo)
            biCliente.GuardaDatosLog(CLIENTE.cli_id)
            biGesRes.ActualizaClienteVenta(CLIENTE)

            InsertaAdicionales()
            InsertaBeneficiarios()

            MsgBox("Fin de la gestión. Presione ACEPTAR para salir del formulario.", MsgBoxStyle.Information, csNombreAplicacion)
            limpiarPrimeraPantalla()
            Me.Hide()
            frmRegrabaciones.ShowDialog()
            BuscaGes()
        End If

    End Sub

    Private Function LlenaParentescoCondicion() As Boolean
        LlenaParentescoCondicion = False

        Dim tmpParentesco As New List(Of eParentescoCampania)
        Dim listParentesco As New List(Of eParentescoCampania)
        Dim entParentesco As New eParentescoCampania

        Dim biPlan As New clsPlanBI
        entParentesco.idParentesco = 0
        entParentesco.nombreParentesco = "---No ingresado---"
        tmpParentesco.Add(entParentesco)
        tmpParentesco.Clear()

        entParentesco.idParentesco = cmbParentescoAdic.SelectedValue

        If cmbParentescoAdic.SelectedIndex <> -1 And cmbParentescoAdic.SelectedIndex <> 0 Then
            listParentesco = biClsParentescoCampania.BuscarParentescoPorId(vgCampania.calCodigo, 2)

            For y As SByte = 0 To listParentesco.Count - 1
                If entParentesco.idParentesco = listParentesco(y).idParentesco Then
                    entParentesco.edadMin = listParentesco(y).edadMin
                    entParentesco.edadMax = listParentesco(y).edadMax

                    Dim difFecha As String = DateDiff(DateInterval.Year, Date.Parse(dtFechaNacAdic.Text), Date.UtcNow)

                    If listParentesco(y).edadMin <= difFecha And listParentesco(y).edadMax > difFecha Then
                        LlenaParentescoCondicion = True
                    End If

                    If listParentesco(y).edadMax = difFecha Then
                        LlenaParentescoCondicion = False
                    End If

                    Dim listRestriccion As New List(Of eRestriccion)
                    For x As SByte = 0 To listPlanes.Count - 1
                        planE = biClsPlan.BuscarPlanPorIdPlan(listPlanes(x).idPlan)

                        listRestriccion = biClsRestricion.BuscarRestriccionPorIdPlan(planE.idPlan)
                        Dim count As Int16 = 0
                        For i As SByte = 0 To listRestriccion.Count - 1
                            restricionE.idRestriccionPlan = listRestriccion(i).idRestriccionPlan
                            restricionE.idPlan = listRestriccion(i).idPlan
                            restricionE.operacion = listRestriccion(i).operacion

                            Select Case listRestriccion(i).operacion
                                Case ">"
                                    If difFecha < listRestriccion(i).valorRestriccion Then
                                        count += 1
                                    End If
                                Case "<"
                                    If difFecha > listRestriccion(i).valorRestriccion Then
                                        count += 1
                                    End If
                                Case "="
                                    If difFecha <> listRestriccion(i).valorRestriccion Then
                                        count += 1
                                    End If
                            End Select
                        Next

                        If count <= 0 Then
                            ufAdic = planE.primaUF
                            idPlanAdic = planE.idPlan
                            totalUfAdic = CDbl(totalUfAdic) + CDbl(ufAdic)
                            sumaUFAdicionales()
                            
                        End If
                    Next

                End If
            Next
        Else
            MsgBox("Debe ingresar un parentezco.", vbExclamation, csNombreAplicacion)
        End If

        Return LlenaParentescoCondicion
    End Function

    Private Sub cmbMedioPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMedioPago.SelectedIndexChanged

        Dim biMedioPago As New clsMedioPagoBI
        Dim medioPago As New eMedioPago
        'medioPago = biMedioPago.BuscaMedioPagoPorId(cmbMedioPago.SelectedValue)
        medioPago = biMedioPago.BuscaDatosMedioPagoPorId(vgCampania.calCodigo, CLIENTE.cli_id, cmbMedioPago.SelectedValue)

        If medioPago.otroMedioPago = True Then
            Panelotro.Visible = True
            txtUltDigitos.Visible = False
            lblUltDig.Visible = False
            CmbBanco.SelectedIndex = 0
            cmbMes.SelectedIndex = 0
            cmbAnio.SelectedIndex = 0
            cmbTpoTarjeta.SelectedIndex = 0
            txtNumeroCta.Text = ""
        Else
            Panelotro.Visible = False
            txtUltDigitos.Text = medioPago.numeroTarjeta
            txtUltDigitos.Visible = True
            lblUltDig.Visible = True
        End If
    End Sub

    Private Sub ValidaNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNro.KeyPress, txtCelular.KeyPress, txtArut.KeyPress, txtFonoVenta.KeyPress, txtCelular.KeyPress, txtUltDigitos.KeyPress, txtNumeroCta.KeyPress
        vgFuncionComun.validaNumeros(e)
    End Sub

    Private Sub txtCalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalle.KeyPress, txtNombre.KeyPress, txtPaterno.KeyPress, txtMaterno.KeyPress, txtReferencia.KeyPress, txtEmail.KeyPress
        vgFuncionComun.validaCaracter(e)
    End Sub

    Private Sub chkContacto_CheckedChanged(sender As Object, e As EventArgs) Handles chkContacto.CheckedChanged

        If chkContacto.Checked = True Then
            Nuevo_Contacto.Visible = True
        Else
            Nuevo_Contacto.Visible = False
        End If

    End Sub

    Private Sub txtRutcontact_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRutcontact.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRutcontact_TextChanged(sender As Object, e As EventArgs) Handles txtRutcontact.TextChanged

    End Sub
End Class