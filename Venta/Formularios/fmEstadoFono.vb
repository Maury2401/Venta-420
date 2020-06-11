Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

Friend Class EstadoFono
    Inherits System.Windows.Forms.Form
    Dim biClsEdoFono As New BI.clsEstadoFonosBI

    Private Sub fmEstadoFono_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        If cmbEstadoFono.Items.Count <= 0 Then
            vgFuncionComun.llenaComboBox(cmbEstadoFono, "efDescripcion", "efId", vgListEdoFono.ToArray)
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'If cmbEstadoFono.SelectedIndex = 0 Then
        '    MsgBox("Debe seleccionar el estado del teléfono discado", MsgBoxStyle.Exclamation)
        '    Exit Sub
        'End If
        If perfil <> "Regrabador" Then
            Select Case lblIdNumero.Text
                Case "1"
                    CLIENTE.cli_estadofono1 = cmbEstadoFono.SelectedValue
                Case "2"
                    CLIENTE.cli_estadofono2 = cmbEstadoFono.SelectedValue
                Case "3"
                    CLIENTE.cli_estadofono3 = cmbEstadoFono.SelectedValue
                Case "4"
                    CLIENTE.cli_estadofono4 = cmbEstadoFono.SelectedValue
                Case "5"
                    CLIENTE.cli_estadofono5 = cmbEstadoFono.SelectedValue
                Case "6"
                    CLIENTE.cli_estadofono6 = cmbEstadoFono.SelectedValue
                Case "alt"
                    CLIENTE.cli_estadofonoalt = cmbEstadoFono.SelectedValue
            End Select
        End If

        biClsEdoFono.guardarEstadoFono(WS_CALL_ID, CLIENTE.cli_id, cmbEstadoFono.SelectedValue)

        lblIdNumero.Text = ""
        lblNumero.Text = ""
        cmbEstadoFono.SelectedIndex = 0

        Me.Hide()

    End Sub
End Class