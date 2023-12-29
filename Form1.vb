
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CriarDocumento()
    End Sub

    Public Shared Sub CriarDocumento()
        'Local Variable Declaration
        Dim application As New Microsoft.Office.Interop.Word.Application
        Dim document As Microsoft.Office.Interop.Word.Document
        Dim range As Microsoft.Office.Interop.Word.Range

        application.Visible = True

        'Add a new document
        document = application.Documents.Add()

        range = document.Range()

        'Add Header and Footer
        For Each Item As Microsoft.Office.Interop.Word.Section In document.Sections
            'Header
            Dim header As Microsoft.Office.Interop.Word.Range = Item.Headers(Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range
            header.Fields.Add(header, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage)
            header.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
            header.Text = "Header"
            header.Font.Name = "Arial"
            header.Font.Size = 10.0
            header.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorRed

            'Footer
            Dim footer As Microsoft.Office.Interop.Word.Range = Item.Footers(Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range
            footer.Fields.Add(footer, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage)
            footer.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
            footer.Text = "Footer"
            footer.Font.Name = "Arial"
            footer.Font.Size = 10.0
            footer.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorRed
        Next

        'Setup Default Range

        range.Font.Name = "Arial"
        range.Font.Size = 10.0
        range.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorBlack

        'range.Text = "Line 1" & vbCrLf
        'range.Text &= "Line 2" & vbCrLf & vbCrLf

        Dim paragraph As Microsoft.Office.Interop.Word.Paragraph = range.Paragraphs.Add
        paragraph.Range.Text = "Primeira lista numerada:"
        paragraph.Range.ListFormat.ApplyNumberDefault(Microsoft.Office.Interop.Word.WdDefaultListBehavior.wdWord10ListBehavior)
        paragraph.Outdent()

        Dim list = paragraph.Range.ListFormat.ListTemplate.ListLevels(1).NumberStyle = Microsoft.Office.Interop.Word.WdListNumberStyle.wdListNumberStyleUppercaseLetter

        paragraph.Range.Paragraphs.Add()
        paragraph.Range.Paragraphs(1).Range.Text = "Segunda"
        paragraph.Range.Paragraphs(1).Range.ListFormat.ApplyListTemplate(document.ListTemplates(1), True, list)
        paragraph.Range.Paragraphs(1).Indent()

        paragraph.Range.InsertParagraphAfter()

        Dim ParagraphTemplate = application.ListGalleries(Microsoft.Office.Interop.Word.WdListGalleryType.wdOutlineNumberGallery).ListTemplates(1)

        With ParagraphTemplate.ListLevels(1)
            .NumberStyle = Microsoft.Office.Interop.Word.WdListNumberStyle.wdListNumberStyleUppercaseLetter
            .NumberFormat = "%1."
            '.TrailingCharacter = Microsoft.Office.Interop.Word.WdListNumberStyle.wdTrailingTab
            '.NumberPosition = CentimetersToPoints(0.63)
            '.Alignment = wdListLevelAlignLeft
            '.TextPosition = CentimetersToPoints(1.27)
            '.TabPosition = wdUndefined
            '.ResetOnHigher = 0
            '.StartAt = 1
        End With

        paragraph.Range.ListFormat.ApplyListTemplate(ParagraphTemplate)
    End Sub


End Class
