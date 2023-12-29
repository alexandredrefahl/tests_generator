<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrincipal
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtArquivo = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.svfdArquivo = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chkRand = New System.Windows.Forms.CheckBox()
        Me.txtGabarito = New System.Windows.Forms.TextBox()
        Me.txtQuestoes = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.chkSalvar = New System.Windows.Forms.CheckBox()
        Me.txtData = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(335, 310)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Gerar Prova"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtArquivo
        '
        Me.txtArquivo.Location = New System.Drawing.Point(12, 12)
        Me.txtArquivo.Name = "txtArquivo"
        Me.txtArquivo.Size = New System.Drawing.Size(360, 20)
        Me.txtArquivo.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(378, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'svfdArquivo
        '
        Me.svfdArquivo.Filter = "Arquivos MS Word|*.docx"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox5)
        Me.GroupBox1.Controls.Add(Me.CheckBox4)
        Me.GroupBox1.Controls.Add(Me.CheckBox3)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(191, 100)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Selecione as Provas "
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(80, 43)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox5.TabIndex = 8
        Me.CheckBox5.Text = "2017"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(80, 19)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox4.TabIndex = 7
        Me.CheckBox4.Text = "2014"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(7, 67)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox3.TabIndex = 6
        Me.CheckBox3.Text = "2011"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(7, 43)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox2.TabIndex = 5
        Me.CheckBox2.Text = "2008"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(6, 19)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "2005"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chkRand
        '
        Me.chkRand.AutoSize = True
        Me.chkRand.Location = New System.Drawing.Point(209, 57)
        Me.chkRand.Name = "chkRand"
        Me.chkRand.Size = New System.Drawing.Size(101, 17)
        Me.chkRand.TabIndex = 4
        Me.chkRand.Text = "Ordem Aleatória"
        Me.chkRand.UseVisualStyleBackColor = True
        '
        'txtGabarito
        '
        Me.txtGabarito.Enabled = False
        Me.txtGabarito.Location = New System.Drawing.Point(12, 215)
        Me.txtGabarito.Name = "txtGabarito"
        Me.txtGabarito.Size = New System.Drawing.Size(398, 20)
        Me.txtGabarito.TabIndex = 5
        '
        'txtQuestoes
        '
        Me.txtQuestoes.Enabled = False
        Me.txtQuestoes.Location = New System.Drawing.Point(12, 254)
        Me.txtQuestoes.Name = "txtQuestoes"
        Me.txtQuestoes.Size = New System.Drawing.Size(398, 20)
        Me.txtQuestoes.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Gabarito"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 238)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Questões"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Descrição Prova"
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(12, 173)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(398, 20)
        Me.txtDescricao.TabIndex = 10
        '
        'chkSalvar
        '
        Me.chkSalvar.AutoSize = True
        Me.chkSalvar.Location = New System.Drawing.Point(12, 319)
        Me.chkSalvar.Name = "chkSalvar"
        Me.chkSalvar.Size = New System.Drawing.Size(87, 17)
        Me.chkSalvar.TabIndex = 11
        Me.chkSalvar.Text = "Salvar Prova"
        Me.chkSalvar.UseVisualStyleBackColor = True
        '
        'txtData
        '
        Me.txtData.CustomFormat = "dd/MM/yyyy"
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtData.Location = New System.Drawing.Point(12, 293)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(103, 20)
        Me.txtData.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 277)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Data da Prova"
        '
        'FrmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 345)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.chkSalvar)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtQuestoes)
        Me.Controls.Add(Me.txtGabarito)
        Me.Controls.Add(Me.chkRand)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtArquivo)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmPrincipal"
        Me.Text = "Gerador Provas Simuladas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents txtArquivo As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents svfdArquivo As SaveFileDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents chkRand As CheckBox
    Friend WithEvents txtGabarito As TextBox
    Friend WithEvents txtQuestoes As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDescricao As TextBox
    Friend WithEvents chkSalvar As CheckBox
    Friend WithEvents txtData As DateTimePicker
    Friend WithEvents Label4 As Label
End Class
