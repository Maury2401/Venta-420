Imports Entidad
Imports BI
Imports System.Collections.Generic

Public Class frmBeneficiario

    Dim biClsCiudad As New clsCiudadBI
    Dim biClsParentescoCampania As New clsParentescoCampaniaBI
    Dim biClsComuna As New clsComunaBI

    Private Sub frmBeneficiario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If (insertaBeneficiarioGrilla() = False) Then
                e.Cancel = True
                Return
            End If
            limpiaBeneficiario()
            'Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmBeneficiario_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        listParentescoCampania = biClsParentescoCampania.BuscarParentescoPorId(vgCampania.calCodigo, 1)
        vgFuncionComun.llenaComboBox(cmbParentescoBen, "nombreParentesco", "idParentesco", listParentescoCampania.ToArray)

        'Carga Comuna
        vgListComuna = biClsComuna.listarComuna

        If cmbComunaBen.Items.Count > 0 Then
            cmbComunaBen.SelectedIndex = 0
        Else
            vgFuncionComun.llenaComboBox(cmbComunaBen, "nombreComuna", "idComuna", vgListComuna.ToArray)
        End If

    End Sub

    Private Sub cmdAgregarBen_Click_1(sender As Object, e As EventArgs) Handles cmdAgregarBen.Click
        If validaBeneficiarios() Then
            insertaBenefiriarioGrilla()
            limpiaBeneficiario()
        End If
    End Sub

    Private Sub cmdModificarBen_Click(sender As Object, e As EventArgs) Handles cmdModificarBen.Click
        If validaBeneficiarios() Then
            modificaBeneficiarioGrilla()
            limpiaBeneficiario()
        End If
    End Sub
    Private Sub cmdEliminarBen_Click(sender As Object, e As EventArgs) Handles cmdEliminarBen.Click
        If dtBeneficiario.Rows.Count <> 0 Then
            If (MsgBox("Desea eliminar el beneficiario seleccionado", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, csNombreAplicacion)) = MsgBoxResult.No Then
                Exit Sub
            Else
                eliminaBeneficiarioGrilla()
                limpiaBeneficiario()
            End If
        Else
            MsgBox("Debe agregar Primero antes de Eliminar!.", vbInformation, csNombreAplicacion)
            Exit Sub
        End If
    End Sub
    Private Sub txtPorcentajeBen_KeyPress(sender As Object, e As KeyPressEventArgs)
        vgFuncionComun.validaNumeros(e)
    End Sub
    Private Sub cmbComunaBen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComunaBen.Click

        If cmbComunaBen.ValueMember Is Nothing Or cmbComunaBen.ValueMember = "" Then
            Exit Sub
        End If
        If cmbComunaBen.SelectedValue Is Nothing Then
            Exit Sub
        End If

        'actualiza el combo box de ciudad
        Dim Ciudad As New eCiudad
        Dim comuna As New eComuna
        Dim lstCiudad As New List(Of eCiudad)

        comuna = vgListComuna.Find(Function(tmpC As eComuna) tmpC.idComuna = cmbComunaBen.SelectedValue)
        Ciudad = biClsCiudad.BuscaCiudadPorIdCiudad(comuna.idCiudad)
        lstCiudad.Add(Ciudad)
        vgFuncionComun.llenaComboBox(cmbCiudadBen, "nombreCiudad", "idCiudad", lstCiudad.ToArray)

    End Sub

    Private Sub CmdSiguiente12_Click(sender As Object, e As EventArgs) Handles CmdSiguiente.Click

        If (insertaBeneficiarioGrilla() = False) Then
            Return
        End If
        limpiaBeneficiario()

        Me.Close()

    End Sub



    ''' <summary>
    ''' Modificación de beneficiarios
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub modificaBeneficiarioGrilla()

        If perfil <> "Regrabador" Then
            If dtBeneficiario.Rows.Count <> 0 Then
                dtBeneficiario.Rows(numeroFila).Cells("nombreBen").Value = txtNombreBen.Text
                dtBeneficiario.Rows(numeroFila).Cells("nombre2Ben").Value = txtNombreBen2.Text
                dtBeneficiario.Rows(numeroFila).Cells("paternoBen").Value = txtPaternoBen.Text()
                dtBeneficiario.Rows(numeroFila).Cells("maternoBen").Value = txtMaternoBen.Text
                dtBeneficiario.Rows(numeroFila).Cells("rutBen").Value = txtRutBen.Text
                dtBeneficiario.Rows(numeroFila).Cells("dvBen").Value = txtDvBen.Text
                dtBeneficiario.Rows(numeroFila).Cells("tipo_parentescoBen").Value = cmbParentescoBen.Text
                dtBeneficiario.Rows(numeroFila).Cells("porcentaje").Value = txtPorcentajeBen.Text
                dtBeneficiario.Rows(numeroFila).Cells("idParentescoBen").Value = cmbParentescoBen.SelectedValue
                dtBeneficiario.Rows(numeroFila).Cells("fechaNacimientoBen").Value = dtFechaNacBen.Value.ToString("yyyyMMdd")
            Else
                MsgBox("Debe agregar Primero antes de Modificar!.", vbInformation, csNombreAplicacion)
                Exit Sub
            End If
        Else
            If dtBeneficiario.Rows.Count <> 0 Then
                Dim entityToEdit As eBeneficiario = lstBen.FirstOrDefault(Function(e) e.b_rut = txtRutBen.Text)
                If entityToEdit IsNot Nothing Then
                    entityToEdit.b_nombre1 = txtNombreBen.Text
                    entityToEdit.b_nombre2 = txtNombreBen2.Text
                    entityToEdit.b_paterno = txtPaternoBen.Text
                    entityToEdit.b_materno = txtMaternoBen.Text
                    entityToEdit.t_rut = txtRutBen.Text
                    entityToEdit.b_dv = txtDvBen.Text
                    entityToEdit.parentesco_text = cmbParentescoBen.Text
                    'entityToEdit.b_pctje = cmbSexoA.Text
                    entityToEdit.b_parentesco = cmbParentescoBen.SelectedValue
                    entityToEdit.b_fec_nac = dtFechaNacBen.Value.ToString("yyyyMMdd")

                    dtBeneficiario.DataSource = Nothing
                    dtBeneficiario.DataSource = lstBen
                    dtBeneficiario.Refresh()
                End If
            End If
        End If

    End Sub

    Private Sub limpiaBeneficiario()
        txtNombreBen.Text = ""
        txtNombreBen2.Text = ""
        txtPaternoBen.Text = ""
        txtMaternoBen.Text = ""
        txtRutBen.Text = ""
        txtDvBen.Text = ""
        cmbParentescoBen.SelectedIndex = -1
        txtPorcentajeBen.Text = ""
        dtFechaNacBen.Value = "1900-01-01" 'Date.Now
        txtDireccionBen.Text = ""
        cmbComunaBen.SelectedIndex = -1
        txtTelefonoBen.Text = ""
        txtCorreoBen.Text = ""

    End Sub

    Private Function validaPorcentaje() As Boolean
        Dim sumPorcentaje As Int16
        sumPorcentaje = 0

        If (dtBeneficiario.Rows.Count > 0) Then

            For i As Int16 = 0 To dtBeneficiario.Rows.Count - 1
                sumPorcentaje = sumPorcentaje + dtBeneficiario.Rows(i).Cells("porcentaje").Value
            Next

            If sumPorcentaje <> 100 Then
                validaPorcentaje = False
                MsgBox("La suma de los porcentajes de los beneficiarios dee ser 100%", vbExclamation, csNombreAplicacion)
                Exit Function
            End If

            validaPorcentaje = True

        Else
            validaPorcentaje = True
        End If

    End Function

    Private Function validaBeneficiarios() As Boolean
        If Trim(txtNombreBen.Text) = "" Then
            MsgBox("El campo nombre es obligatorio.", vbExclamation, csNombreAplicacion)
            txtNombreBen.Focus()
            validaBeneficiarios = False
            Exit Function
        End If

        If Trim(txtPaternoBen.Text) = "" Then
            MsgBox("El campo Apellido Paterno es obligatorio.", vbExclamation, csNombreAplicacion)
            txtPaternoBen.Focus()
            validaBeneficiarios = False
            Exit Function
        End If

        If Trim(txtMaternoBen.Text) = "" Then
            MsgBox("El campo Apellido Materno es obligatorio.", vbExclamation, csNombreAplicacion)
            txtMaternoBen.Focus()
            validaBeneficiarios = False
            Exit Function
        End If

        'SE QUITA VALIDACION TICKET 44286
        'se vuelve a agregar validacion ticket 44831
        If txtNombreBen.Text <> "HEREDEROS LEGALES" Then
            If ((Trim(txtRutBen.Text) = "")) Then 'And Trim(dtFechaNacBen.Text = ("01-01-1900"))) Then
                MsgBox("El RUT o la Fecha de Nacimiento del Beneficiario no puede estar vacío.", vbInformation, csNombreAplicacion)
                Exit Function
            End If

        End If


        If cmbParentescoBen.SelectedIndex <= 0 Then
            MsgBox("Debe seleccionar el parentesco del beneficiario.", vbExclamation, csNombreAplicacion)
            cmbParentescoBen.Focus()
            validaBeneficiarios = False
            Exit Function
        End If

        If txtPorcentajeBen.Text = "" Then
            MsgBox("Debe ingresar procentaje de beneficiario", vbExclamation, csNombreAplicacion)
            txtPorcentajeBen.Focus()
            validaBeneficiarios = False
            Exit Function
        End If

        validaBeneficiarios = True
    End Function

    Private Sub insertaBenefiriarioGrilla()
        If perfil <> "Regrabador" Then
            FilaAgregar = dtBeneficiario.Rows.Count
            dtBeneficiario.Rows.Add(1)
            dtBeneficiario.Item("nombreBen", FilaAgregar).Value = txtNombreBen.Text
            dtBeneficiario.Item("nombre2Ben", FilaAgregar).Value = txtNombreBen2.Text
            dtBeneficiario.Item("paternoBen", FilaAgregar).Value = txtPaternoBen.Text
            dtBeneficiario.Item("maternoBen", FilaAgregar).Value = txtMaternoBen.Text
            dtBeneficiario.Item("rutBen", FilaAgregar).Value = txtRutBen.Text
            dtBeneficiario.Item("dvBen", FilaAgregar).Value = txtDvBen.Text
            dtBeneficiario.Item("idParentescoBen", FilaAgregar).Value = cmbParentescoBen.SelectedValue
            dtBeneficiario.Item("tipo_parentescoBen", FilaAgregar).Value = cmbParentescoBen.Text
            dtBeneficiario.Item("porcentaje", FilaAgregar).Value = txtPorcentajeBen.Text
            dtBeneficiario.Item("idParentescoBen", FilaAgregar).Value = cmbParentescoBen.SelectedValue
            dtBeneficiario.Item("contactoBen", FilaAgregar).Value = ""
            dtBeneficiario.Item("fechaNacimientoBen", FilaAgregar).Value = IIf(cmbParentescoBen.Text <> "HEREDEROS LEGALES", dtFechaNacBen.Value.ToString("yyyyMMdd"), "")

            'Dim contacto As String
            'contacto = IIf(Len(txtDireccionBen.Text) < 3, "", "Dirección: " & txtDireccionBen.Text & "|")
            'contacto = contacto & IIf(cmbComunaBen.SelectedIndex = -1 Or cmbComunaBen.Text = "", "", "Comuna: " & cmbComunaBen.Text & "|")
            'contacto = contacto & IIf(cmbCiudadBen.SelectedIndex = -1 Or cmbCiudadBen.Text = "" Or cmbCiudadBen.SelectedValue = 0, "", "Ciudad: " & cmbCiudadBen.Text & "|")

            'contacto = contacto & IIf(Len(txtTelefonoBen.Text) < 3, "", "Teléfono: " & txtTelefonoBen.Text & "|")
            'contacto = contacto & IIf(Len(txtCorreoBen.Text) < 3, "", "Correo: " & txtCorreoBen.Text & "|")

            'dtBeneficiario.Item("contactoBen", FilaAgregar).Value = contacto

        Else

            Dim contacto As String
            contacto = IIf(Len(txtDireccionBen.Text) < 3, "", "Dirección: " & txtDireccionBen.Text) & "|"
            contacto = contacto & IIf(cmbComunaBen.SelectedIndex = -1 Or cmbComunaBen.Text = "", "", "Comuna: " & cmbComunaBen.Text) & "|"
            contacto = contacto & IIf(cmbCiudadBen.SelectedIndex = -1 Or cmbCiudadBen.Text = "" Or cmbCiudadBen.SelectedValue = 0, "", "Ciudad: " & cmbCiudadBen.Text) & "|"

            contacto = contacto & IIf(Len(txtTelefonoBen.Text) < 3, "", "Teléfono: " & txtTelefonoBen.Text) & "|"
            contacto = contacto & IIf(Len(txtCorreoBen.Text) < 3, "", "Correo: " & txtCorreoBen.Text) & "|"

            lstBen.Add(New eBeneficiario() With {
             .b_nombre1 = txtNombreBen.Text,
             .b_nombre2 = txtNombreBen2.Text,
             .b_paterno = txtPaternoBen.Text,
             .b_materno = txtMaternoBen.Text,
             .b_rut = txtRutBen.Text,
             .b_dv = txtDvBen.Text,
             .parentesco_text = cmbParentescoBen.Text,
             .b_pctje = txtPorcentajeBen.Text,
             .b_parentesco = cmbParentescoBen.SelectedValue,
             .b_contacto = contacto,
            .b_fec_nac = dtFechaNacBen.Value.ToString("yyyyMMdd")
        })
            dtBeneficiario.DataSource = Nothing
            dtBeneficiario.DataSource = lstBen
            dtBeneficiario.Refresh()
        End If

    End Sub

    ''' <summary>
    ''' metodo para eliminar un beneficiario de la grilla
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub eliminaBeneficiarioGrilla()
        If perfil <> "Regrabador" Then
            dtBeneficiario.Rows.RemoveAt(numeroFila)
        Else
            Dim entityRem As eBeneficiario = lstBen.FirstOrDefault(Function(e) e.b_nombre1 = txtNombreBen.Text)
            If entityRem IsNot Nothing Then
                lstBen.Remove(entityRem)

                dtBeneficiario.DataSource = Nothing
                dtBeneficiario.DataSource = lstBen
                dtBeneficiario.Refresh()
            End If
        End If
    End Sub


    Private Function insertaBeneficiarioGrilla() As Boolean

        Try



            If validaPorcentaje() Then
                If perfil <> "Regrabador" Then
                    lstBen.Clear()

                    For I As Int16 = 0 To dtBeneficiario.Rows.Count - 1

                        Dim ben As New eBeneficiario

                        ben.b_nombre1 = IIf(dtBeneficiario.Rows(I).Cells("nombreBen").Value Is DBNull.Value, Nothing, dtBeneficiario.Rows(I).Cells("nombreBen").Value)
                        ben.b_nombre2 = IIf(dtBeneficiario.Rows(I).Cells("nombre2Ben").Value Is DBNull.Value, Nothing, dtBeneficiario.Rows(I).Cells("nombre2Ben").Value)
                        ben.b_paterno = IIf(dtBeneficiario.Rows(I).Cells("paternoBen").Value Is DBNull.Value, Nothing, dtBeneficiario.Rows(I).Cells("paternoBen").Value)
                        ben.b_materno = IIf(dtBeneficiario.Rows(I).Cells("maternoBen").Value Is DBNull.Value, Nothing, dtBeneficiario.Rows(I).Cells("maternoBen").Value)
                        ben.b_rut = IIf(dtBeneficiario.Rows(I).Cells("rutBen").Value Is DBNull.Value, Nothing, dtBeneficiario.Rows(I).Cells("rutBen").Value)
                        ben.b_dv = IIf(dtBeneficiario.Rows(I).Cells("dvBen").Value Is DBNull.Value, Nothing, dtBeneficiario.Rows(I).Cells("dvBen").Value)
                        ben.parentesco_text = IIf(dtBeneficiario.Rows(I).Cells("tipo_parentescoBen").Value Is DBNull.Value, Nothing, dtBeneficiario.Rows(I).Cells("tipo_parentescoBen").Value)
                        ben.b_pctje = IIf(dtBeneficiario.Rows(I).Cells("porcentaje").Value Is DBNull.Value, Nothing, dtBeneficiario.Rows(I).Cells("porcentaje").Value)
                        ben.b_parentesco = IIf(dtBeneficiario.Rows(I).Cells("idParentescoBen").Value Is DBNull.Value, Nothing, dtBeneficiario.Rows(I).Cells("idParentescoBen").Value)
                        ben.b_contacto = IIf(dtBeneficiario.Rows(I).Cells("ContactoBen").Value Is DBNull.Value, Nothing, dtBeneficiario.Rows(I).Cells("ContactoBen").Value)
                        ben.b_fec_nac = IIf(dtBeneficiario.Rows(I).Cells("fechaNacimientoBen").Value Is DBNull.Value, Nothing, dtBeneficiario.Rows(I).Cells("fechaNacimientoBen").Value)

                        lstBen.Add(ben)
                    Next I
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try

    End Function

    Private Sub dtBeneficiario_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtBeneficiario.CellClick
        If e.RowIndex = -1 Then Exit Sub

        txtNombreBen.Text = dtBeneficiario.Rows(e.RowIndex).Cells("nombreBen").Value
        txtNombreBen2.Text = dtBeneficiario.Rows(e.RowIndex).Cells("nombre2Ben").Value
        txtPaternoBen.Text = dtBeneficiario.Rows(e.RowIndex).Cells("paternoBen").Value
        txtMaternoBen.Text = dtBeneficiario.Rows(e.RowIndex).Cells("maternoBen").Value
        txtRutBen.Text = dtBeneficiario.Rows(e.RowIndex).Cells("rutBen").Value
        txtDvBen.Text = dtBeneficiario.Rows(e.RowIndex).Cells("dvBen").Value
        cmbParentescoBen.Text = dtBeneficiario.Rows(e.RowIndex).Cells("tipo_parentescoBen").Value
        txtPorcentajeBen.Text = dtBeneficiario.Rows(e.RowIndex).Cells("porcentaje").Value
        'dtFechaNacBen.Value = IIf(dtBeneficiario.Rows(e.RowIndex).Cells("fechaNacimientoBen").Value Is Nothing Or dtBeneficiario.Rows(e.RowIndex).Cells("fechaNacimientoBen").Value = "", "", Format(dtBeneficiario.Rows(e.RowIndex).Cells("fechaNacimientoBen").Value, "dd/MM/yyyy"))
        'dtFechaNacBen.Value = Mid(dtBeneficiario.Rows(e.RowIndex).Cells("fechaNacimientoBen").Value, 7, 2) & "-" & Mid(dtBeneficiario.Rows(e.RowIndex).Cells("fechaNacimientoBen").Value, 5, 2) & "-" & Mid(dtBeneficiario.Rows(e.RowIndex).Cells("fechaNacimientoBen").Value, 1, 4)

        numeroFila = e.RowIndex
    End Sub


    Private Sub cmbParentescoBen_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbParentescoBen.SelectedIndexChanged
        If cmbParentescoBen.SelectedIndex > 0 Then
            If cmbParentescoBen.Text = "HEREDEROS LEGALES" Then
                txtNombreBen.Text = "HEREDEROS LEGALES"
                txtNombreBen2.Text = "HEREDEROS LEGALES"
                txtPaternoBen.Text = "HEREDEROS"
                txtMaternoBen.Text = "LEGALES"
                txtPorcentajeBen.Text = "100"
                dtFechaNacBen.Value = "01-01-1900"
            End If
        End If
    End Sub

End Class