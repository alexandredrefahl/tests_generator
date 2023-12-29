
Imports System.Data.OleDb

Public Class FrmPrincipal
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        CriarDocumento()
        txtGabarito.Enabled = True
        txtQuestoes.Enabled = True
        MsgBox("A Prova terminou de ser gerada. Confira o arquivo Word Anexo.")
        Me.Cursor = Cursors.Arrow

    End Sub

    Public Sub CriarDocumento()

        '***  SELEÇÃO DAS QUESTÕES

        'Primeiro pega as questões da prova no arquivo do Access
        Dim Table_ As String = "Prova_por_Selecao"
        Dim Query As String

        Query = "SELECT * FROM " & Table_
        'Se quiser em ordem aleatória
        If chkRand.Checked Then
            Query &= " ORDER BY RND(INT(NOW*Código)-NOW*Código)"
        End If

        Dim MDBConnString_ As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Provas_Enade.mdb;"
        Dim ds As New DataSet
        Dim cnn As OleDbConnection = New OleDbConnection(MDBConnString_)
        cnn.Open()
        Dim cmd As New OleDbCommand(query, cnn)
        Dim da As New OleDbDataAdapter(cmd)
        da.Fill(ds, Table_)
        cnn.Close()

        '*** CRIAÇÃO DO DOCUMENTO WORD

        'Declaração de Variáveis locais
        Dim application As New Microsoft.Office.Interop.Word.Application
        Dim document As Microsoft.Office.Interop.Word.Document
        Dim DocRange As Microsoft.Office.Interop.Word.Range

        'Aplicação visível
        application.Visible = True

        'Cria um novo documento do Word
        document = application.Documents.Add()

        'Carrega na memória o documento criado
        DocRange = document.Range()

        'Formata o texto do documento
        DocRange.Font.Name = "Arial"
        DocRange.Font.Size = 10.0
        DocRange.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorBlack
        DocRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify

        Dim objSelection = application.Selection
        Dim Quest_Num As Int16 = 1

        Dim t1 As DataTable = ds.Tables(Table_)
        Dim row As DataRow

        'Armazena a ordem e o gabarito da prova em questão.
        Dim Gabarito As String = String.Empty
        Dim Questoes As String = String.Empty

        '*** PREENCHENDO AS QUESTÕES

        For Each row In t1.Rows
            Dim EN_Ano As Int16 = row.Item("Ano")
            Dim EN_Quest As Int16 = row.Item("Questão")

            Gabarito &= row.Item("Gabarito")
            Questoes &= row.Item("Código") & ","

            DocRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify
            objSelection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify
            objSelection.Font.Bold = True
            objSelection.TypeText("Questão " & Format(Quest_Num, "00") & " [" & Format(EN_Ano, "0000") & " - " & Format(EN_Quest, "00") & "] ")
            objSelection.Font.Bold = False

            '*** MONTAGEM DO ENUNCIADO

            'Se não tiver Figura nenhuma na questão!
            If IsDBNull(row.Item("Arquivo")) Then
                'Inserção de conteúdo HTML da questão
                Dim vs_html As String = "<html>" & row.Item("Enunciado") & "</html>"
                ' Cria os arquivos temporários na pasta Temp do Windows
                Dim vs_File_Temp As String = IO.Path.Combine(IO.Path.GetTempPath, "Q" & Quest_Num & ".html")

                Dim fso As Object
                fso = CreateObject("Scripting.FileSystemObject")
                Dim oFile As Object
                oFile = fso.CreateTextFile(vs_File_Temp)

                oFile.write(vs_html)
                oFile.Close
                fso = Nothing
                oFile = Nothing

                objSelection.InsertFile(vs_File_Temp, , , False, False)

            Else
                'Se tiver figura tem que posicionar de acordo com a chave [ imagem ]
                Dim Parte1 As String, Parte2 As String
                Dim Pos1 As Int16, Pos2 As Int16
                'Determina as posições da Chave "[ imagem ]"
                Pos1 = row.Item("Enunciado").ToString.IndexOf("[ imagem ]")
                Pos2 = Pos1 + 10
                'Recorta o enunciado em duas partes
                Parte1 = "<html>" & row.Item("Enunciado").ToString.Substring(0, Pos1) & "</html>"
                Parte2 = "<html>" & row.Item("Enunciado").ToString.Substring(Pos2) & "</html>"

                '*** PRIMEIRA PARTE DO ENUNCIADO
                Dim P1_File_Temp As String = IO.Path.Combine(IO.Path.GetTempPath, "Q" & Quest_Num & "_p1.html")
                Dim fso As Object
                fso = CreateObject("Scripting.FileSystemObject")
                Dim oFile As Object
                oFile = fso.CreateTextFile(P1_File_Temp)

                oFile.write(Parte1)
                oFile.Close
                fso = Nothing
                oFile = Nothing

                objSelection.InsertFile(P1_File_Temp, , , False, False)

                '*** INSERÇÃO DA IMAGEM
                Dim Pasta As String = My.Application.Info.DirectoryPath
                Dim imgArquivo = Pasta & "\Imagens_ENADE\" & row.Item("Ano") & "\" & row.Item("Arquivo")
                objSelection.TypeParagraph()
                objSelection.InlineShapes.AddPicture(imgArquivo, False, True)
                objSelection.TypeParagraph()

                '*** PARTE FINAL DO ENUNCIADO
                Dim P2_File_Temp As String = IO.Path.Combine(IO.Path.GetTempPath, "Q" & Quest_Num & "_p2.html")
                fso = CreateObject("Scripting.FileSystemObject")
                oFile = fso.CreateTextFile(P2_File_Temp)

                oFile.write(Parte2)
                oFile.Close
                fso = Nothing
                oFile = Nothing

                objSelection.InsertFile(P2_File_Temp, , , False, False)

            End If

            If Not row.Item("Discursiva") Then
                objSelection.TypeParagraph()
                objSelection.TypeText("A. " & row.Item("RespostaA") & vbCrLf)
                objSelection.TypeText("B. " & row.Item("RespostaB") & vbCrLf)
                objSelection.TypeText("C. " & row.Item("RespostaC") & vbCrLf)
                objSelection.TypeText("D. " & row.Item("RespostaD") & vbCrLf)
                objSelection.TypeText("E. " & row.Item("RespostaE") & vbCrLf)
            End If

            objSelection.TypeParagraph()
            Quest_Num = Quest_Num + 1
        Next

        '*********************************************************************
        '***
        '***                       G A B A R I T O 
        '***
        '*********************************************************************

        'Insere Quebra de Página
        objSelection.InsertBreak(Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak)

        objSelection.Style = Microsoft.Office.Interop.Word.WdBuiltinStyle.wdStyleHeading2
        objSelection.TypeText("GABARITO")
        'Dá um espaço
        objSelection.TypeParagraph()
        objSelection.TypeParagraph()

        'Volta para o estilo de corpo do texto.
        objSelection.Style = Microsoft.Office.Interop.Word.WdBuiltinStyle.wdStyleBodyText

        'Cria a tabela para colocar o gabarito
        Dim Tabela As Microsoft.Office.Interop.Word.Table
        Dim nLinhas As Int16 = t1.Rows.Count + 1

        'Cria uma tabela com 41 linhas e 6 colunas
        Tabela = document.Tables.Add(objSelection.Range, nLinhas, 7)

        'Formata as linhas de grade da tabela
        Tabela.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle
        Tabela.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle

        'Faz o Cabeçalho
        Tabela.Cell(1, 1).Range.Text = "Questão"
        Tabela.Cell(1, 2).Range.Text = "Gabarito"
        Tabela.Cell(1, 3).Range.Text = "Ano"
        Tabela.Cell(1, 4).Range.Text = "Original"
        Tabela.Cell(1, 5).Range.Text = "Dificuldade"
        Tabela.Cell(1, 6).Range.Text = "Tema"
        Tabela.Cell(1, 7).Range.Text = "ID"

        'Zera o número da questão
        Quest_Num = 1

        For Each row In t1.Rows
            'objSelection.TypeText(Format(Quest_Num, "00") & " - " & vbTab & row.Item("Gabarito").ToString.ToUpper & vbLf)
            Tabela.Cell(Quest_Num + 1, 1).Range.Text = Format(Quest_Num, "00")
            Tabela.Cell(Quest_Num + 1, 2).Range.Text = row.Item("Gabarito").ToString.ToUpper
            Tabela.Cell(Quest_Num + 1, 3).Range.Text = row.Item("Ano")
            Tabela.Cell(Quest_Num + 1, 4).Range.Text = row.Item("Questão")
            Tabela.Cell(Quest_Num + 1, 5).Range.Text = NaoENulo(row.Item("indice_dificuldade"))
            Tabela.Cell(Quest_Num + 1, 6).Range.Text = row.Item("Siglas")
            Tabela.Cell(Quest_Num + 1, 7).Range.Text = row.Item("Código")
            Quest_Num = Quest_Num + 1
        Next

        If txtArquivo.Text <> "" Then
            document.SaveAs2(txtArquivo.Text)
        Else
            svfdArquivo.ShowDialog()
            txtArquivo.Text = svfdArquivo.FileName
            document.SaveAs2(txtArquivo.Text)
        End If

        txtGabarito.Text = Gabarito
        txtQuestoes.Text = Questoes

        'Se a opção de salvar estiver habilitada, grava a prova na tabela.
        If chkSalvar.Checked Then
            Try
                Dim sqlquery As New OleDb.OleDbCommand
                cnn.ConnectionString = MDBConnString_
                sqlquery.Connection = cnn
                cnn.Open()
                sqlquery.CommandText = "INSERT INTO Registro_Provas (Data,Questoes,Gabarito,Descricao) VALUES(@data, @Questoes, @Gabarito, @Descricao)"
                sqlquery.Parameters.AddWithValue("@data", txtData.Value)
                sqlquery.Parameters.AddWithValue("@Questoes", txtQuestoes.Text)
                sqlquery.Parameters.AddWithValue("@Gabarito", txtGabarito.Text)
                sqlquery.Parameters.AddWithValue("@Descricao", txtDescricao.Text)
                sqlquery.ExecuteNonQuery()
                cnn.Close()
                MsgBox("Prova salva com sucesso", MsgBoxStyle.OkOnly, "Confirmação")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        svfdArquivo.ShowDialog()
        txtArquivo.Text = svfdArquivo.FileName
    End Sub

    Private Function NaoENulo(ByVal Numero) As String
        If IsDBNull(Numero) Then
            NaoENulo = String.Empty
        Else
            NaoENulo = Format(Numero, "0.0%")
        End If
    End Function

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
