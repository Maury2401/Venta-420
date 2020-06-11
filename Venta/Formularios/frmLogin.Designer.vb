<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmLogin
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
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents txtusuxlite As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents fraxlite As System.Windows.Forms.Panel
	Public WithEvents TxtUsuarioLog As System.Windows.Forms.TextBox
	Public WithEvents btnAceptar As System.Windows.Forms.Button
	Public WithEvents LblBienvenida As System.Windows.Forms.Label
    Public WithEvents TXT_USUARIO As System.Windows.Forms.Label
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.fraxlite = New System.Windows.Forms.Panel()
        Me.txtusuxlite = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtUsuarioLog = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.LblBienvenida = New System.Windows.Forms.Label()
        Me.TXT_USUARIO = New System.Windows.Forms.Label()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.CheckBoxLogin = New System.Windows.Forms.CheckBox()
        Me.fraxlite.SuspendLayout()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraxlite
        '
        Me.fraxlite.BackColor = System.Drawing.Color.White
        Me.fraxlite.Controls.Add(Me.txtusuxlite)
        Me.fraxlite.Controls.Add(Me.Label1)
        Me.fraxlite.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraxlite.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraxlite.Location = New System.Drawing.Point(19, 256)
        Me.fraxlite.Name = "fraxlite"
        Me.fraxlite.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraxlite.Size = New System.Drawing.Size(297, 50)
        Me.fraxlite.TabIndex = 4
        Me.fraxlite.Text = "Frame1"
        Me.fraxlite.Visible = False
        '
        'txtusuxlite
        '
        Me.txtusuxlite.AcceptsReturn = True
        Me.txtusuxlite.BackColor = System.Drawing.SystemColors.Window
        Me.txtusuxlite.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtusuxlite.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtusuxlite.Location = New System.Drawing.Point(128, 16)
        Me.txtusuxlite.MaxLength = 0
        Me.txtusuxlite.Name = "txtusuxlite"
        Me.txtusuxlite.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtusuxlite.Size = New System.Drawing.Size(81, 20)
        Me.txtusuxlite.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(3, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(119, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Ingrese usuario XLite"
        '
        'TxtUsuarioLog
        '
        Me.TxtUsuarioLog.AcceptsReturn = True
        Me.TxtUsuarioLog.BackColor = System.Drawing.SystemColors.Window
        Me.TxtUsuarioLog.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtUsuarioLog.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtUsuarioLog.Location = New System.Drawing.Point(123, 231)
        Me.TxtUsuarioLog.MaxLength = 0
        Me.TxtUsuarioLog.Name = "TxtUsuarioLog"
        Me.TxtUsuarioLog.ReadOnly = True
        Me.TxtUsuarioLog.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtUsuarioLog.Size = New System.Drawing.Size(193, 20)
        Me.TxtUsuarioLog.TabIndex = 2
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAceptar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAceptar.Location = New System.Drawing.Point(123, 327)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAceptar.Size = New System.Drawing.Size(100, 33)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Ingresar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'LblBienvenida
        '
        Me.LblBienvenida.BackColor = System.Drawing.Color.White
        Me.LblBienvenida.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblBienvenida.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblBienvenida.Location = New System.Drawing.Point(19, 234)
        Me.LblBienvenida.Name = "LblBienvenida"
        Me.LblBienvenida.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblBienvenida.Size = New System.Drawing.Size(105, 25)
        Me.LblBienvenida.TabIndex = 3
        Me.LblBienvenida.Text = "Usuario Logeado"
        '
        'TXT_USUARIO
        '
        Me.TXT_USUARIO.BackColor = System.Drawing.Color.White
        Me.TXT_USUARIO.Cursor = System.Windows.Forms.Cursors.Default
        Me.TXT_USUARIO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TXT_USUARIO.Location = New System.Drawing.Point(64, 256)
        Me.TXT_USUARIO.Name = "TXT_USUARIO"
        Me.TXT_USUARIO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TXT_USUARIO.Size = New System.Drawing.Size(203, 13)
        Me.TXT_USUARIO.TabIndex = 1
        Me.TXT_USUARIO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Image = Global.APP_4942.My.Resources.Resources.LogoCallsouth
        Me.Image1.Location = New System.Drawing.Point(34, 12)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(282, 213)
        Me.Image1.TabIndex = 5
        Me.Image1.TabStop = False
        '
        'CheckBoxLogin
        '
        Me.CheckBoxLogin.AutoSize = True
        Me.CheckBoxLogin.Location = New System.Drawing.Point(19, 336)
        Me.CheckBoxLogin.Name = "CheckBoxLogin"
        Me.CheckBoxLogin.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxLogin.TabIndex = 6
        Me.CheckBoxLogin.UseVisualStyleBackColor = True
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ClientSize = New System.Drawing.Size(325, 365)
        Me.Controls.Add(Me.CheckBoxLogin)
        Me.Controls.Add(Me.fraxlite)
        Me.Controls.Add(Me.TxtUsuarioLog)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.LblBienvenida)
        Me.Controls.Add(Me.Image1)
        Me.Controls.Add(Me.TXT_USUARIO)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 27)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.fraxlite.ResumeLayout(False)
        Me.fraxlite.PerformLayout()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Image1 As System.Windows.Forms.PictureBox
    Friend WithEvents CheckBoxLogin As System.Windows.Forms.CheckBox
#End Region 
End Class