<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegrabaciones
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridViewGes = New System.Windows.Forms.DataGridView()
        Me.btnSalirGes = New System.Windows.Forms.Button()
        Me.TextGesColor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridViewGes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewGes
        '
        Me.DataGridViewGes.AllowUserToAddRows = False
        Me.DataGridViewGes.AllowUserToDeleteRows = False
        Me.DataGridViewGes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewGes.Location = New System.Drawing.Point(27, 135)
        Me.DataGridViewGes.Name = "DataGridViewGes"
        Me.DataGridViewGes.ReadOnly = True
        Me.DataGridViewGes.Size = New System.Drawing.Size(600, 150)
        Me.DataGridViewGes.TabIndex = 0
        '
        'btnSalirGes
        '
        Me.btnSalirGes.Location = New System.Drawing.Point(544, 51)
        Me.btnSalirGes.Name = "btnSalirGes"
        Me.btnSalirGes.Size = New System.Drawing.Size(75, 23)
        Me.btnSalirGes.TabIndex = 1
        Me.btnSalirGes.Text = "Salir"
        Me.btnSalirGes.UseVisualStyleBackColor = True
        '
        'TextGesColor
        '
        Me.TextGesColor.Location = New System.Drawing.Point(152, 53)
        Me.TextGesColor.Name = "TextGesColor"
        Me.TextGesColor.Size = New System.Drawing.Size(73, 20)
        Me.TextGesColor.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(231, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Registros agendados"
        '
        'frmRegrabaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 353)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextGesColor)
        Me.Controls.Add(Me.btnSalirGes)
        Me.Controls.Add(Me.DataGridViewGes)
        Me.Name = "frmRegrabaciones"
        Me.Text = "Ventas Rechazadas en 1 Instancia"
        CType(Me.DataGridViewGes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewGes As System.Windows.Forms.DataGridView
    Friend WithEvents btnSalirGes As System.Windows.Forms.Button
    Friend WithEvents TextGesColor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
