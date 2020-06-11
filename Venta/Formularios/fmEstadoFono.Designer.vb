<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class EstadoFono
#Region "Código generado por el Diseñador de Windows Forms "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub
    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar mediante el Diseñador de Windows Forms.
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmbEstadoFono = New System.Windows.Forms.ComboBox()
        Me.lblIdNumero = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.lblTitTelefono = New System.Windows.Forms.Label()
        Me.lblTitEstadoFono = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmbEstadoFono
        '
        Me.cmbEstadoFono.BackColor = System.Drawing.SystemColors.Window
        Me.cmbEstadoFono.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbEstadoFono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoFono.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoFono.Location = New System.Drawing.Point(108, 41)
        Me.cmbEstadoFono.Name = "cmbEstadoFono"
        Me.cmbEstadoFono.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbEstadoFono.Size = New System.Drawing.Size(277, 21)
        Me.cmbEstadoFono.TabIndex = 85
        '
        'lblIdNumero
        '
        Me.lblIdNumero.AutoSize = True
        Me.lblIdNumero.Location = New System.Drawing.Point(13, 77)
        Me.lblIdNumero.Name = "lblIdNumero"
        Me.lblIdNumero.Size = New System.Drawing.Size(63, 13)
        Me.lblIdNumero.TabIndex = 84
        Me.lblIdNumero.Text = "lblIdNumero"
        Me.lblIdNumero.Visible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(310, 68)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 83
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.ForeColor = System.Drawing.Color.Blue
        Me.lblNumero.Location = New System.Drawing.Point(218, 9)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(44, 13)
        Me.lblNumero.TabIndex = 82
        Me.lblNumero.Text = "Numero"
        '
        'lblTitTelefono
        '
        Me.lblTitTelefono.AutoSize = True
        Me.lblTitTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitTelefono.Location = New System.Drawing.Point(12, 9)
        Me.lblTitTelefono.Name = "lblTitTelefono"
        Me.lblTitTelefono.Size = New System.Drawing.Size(200, 13)
        Me.lblTitTelefono.TabIndex = 81
        Me.lblTitTelefono.Text = "El teléfono que está llamando es: "
        '
        'lblTitEstadoFono
        '
        Me.lblTitEstadoFono.AutoSize = True
        Me.lblTitEstadoFono.BackColor = System.Drawing.Color.Transparent
        Me.lblTitEstadoFono.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTitEstadoFono.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitEstadoFono.ForeColor = System.Drawing.Color.Black
        Me.lblTitEstadoFono.Location = New System.Drawing.Point(12, 41)
        Me.lblTitEstadoFono.Name = "lblTitEstadoFono"
        Me.lblTitEstadoFono.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitEstadoFono.Size = New System.Drawing.Size(90, 16)
        Me.lblTitEstadoFono.TabIndex = 80
        Me.lblTitEstadoFono.Text = "Estado fono:"
        '
        'EstadoFono
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(509, 104)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbEstadoFono)
        Me.Controls.Add(Me.lblIdNumero)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.lblNumero)
        Me.Controls.Add(Me.lblTitTelefono)
        Me.Controls.Add(Me.lblTitEstadoFono)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(500, 500)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EstadoFono"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents cmbEstadoFono As System.Windows.Forms.ComboBox
    Friend WithEvents lblIdNumero As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents lblTitTelefono As System.Windows.Forms.Label
    Public WithEvents lblTitEstadoFono As System.Windows.Forms.Label
#End Region
End Class