Imports PdfSharp.Pdf
Imports PdfSharp.Pdf.IO
Imports System.IO

Public Class DocumentMerger
    Private _pdfStream As Stream()

    Public Sub New(ByVal fileArray As String())
        Dim list As New ArrayList
        For Each filePath In fileArray
            list.Add(New FileStream(filePath, FileMode.Open))
        Next
        _pdfStream = list.ToArray(GetType(Stream))
    End Sub

    Public Sub New(ByVal streamArray As Stream())
        _pdfStream = streamArray
    End Sub

    Public Function MergeFiles(ByRef outputStream As Stream) As BusinessErrors
        Dim errors As New BusinessErrors
        Dim outputDoc As New PdfDocument
        Try
            For Each stream In _pdfStream
                Dim pdfDoc As PdfDocument = PdfReader.Open(stream, PdfDocumentOpenMode.Import)
                For Each page In pdfDoc.Pages
                    outputDoc.AddPage(page)
                Next
            Next
            outputDoc.Save(outputStream, False)
        Catch ex As Exception
            Utils.FillErrors(errors, ex)
        End Try

        Return errors
    End Function
End Class
