Public Class PrintingParameters

    Public Enum OUTPUT_FORMAT
        PDF
        EXCEL
        TIFF
        WORDS
    End Enum

    Public Enum PAPER_SIZE
        A3
        A4Portrait
        A4Landscape
        B5
        LEGAL
        LETTER
    End Enum

    Public Enum PAPER_ORIENTATION
        PORTRAIT_STANDARD
        LANDSCAPE_STANDARD
    End Enum

    Private _outputFormat As OUTPUT_FORMAT
    Private _pageWidth As Decimal
    Private _pageHeight As Decimal
    Private _marginTop As Decimal
    Private _marginLeft As Decimal
    Private _marginRight As Decimal
    Private _marginBottom As Decimal

    Public Sub New(ByVal outputFormat As OUTPUT_FORMAT, _
                   ByVal paperSize As PAPER_SIZE, _
                   ByVal orientation As PAPER_ORIENTATION)
        Me._outputFormat = outputFormat
        SetPaperSize(paperSize)
        SetOrientation(orientation)
    End Sub

    Public Sub New(ByVal outputFormat As OUTPUT_FORMAT, _
                   ByVal pageWidth As Decimal, _
                   ByVal pageHeight As Decimal, _
                   ByVal marginTop As Decimal, _
                   ByVal marginLeft As Decimal, _
                   ByVal marginRight As Decimal, _
                   ByVal marginBottom As Decimal)
        Me._outputFormat = outputFormat
        SetPaperSize(pageWidth, pageHeight)
        SetMargins(marginTop, marginBottom, marginLeft, marginRight)
    End Sub

    Public ReadOnly Property ReportFormat As String
        Get
            Return ToSqlReportFormatCode(Me._outputFormat)
        End Get
    End Property


    Public Sub SetOrientation(ByVal orientation As PAPER_ORIENTATION)
        Select Case orientation
            Case PAPER_ORIENTATION.LANDSCAPE_STANDARD
                SetMargins(0.5, 0.5, 0.25, 0.25)
            Case PAPER_ORIENTATION.PORTRAIT_STANDARD
                'SetMargins(0.2, 0.2, 0.2, 0.2)
                SetMargins(0.1, 0.1, 0.1, 0.1)
        End Select
    End Sub

    Public Sub SetPaperSize(ByVal paperSize As PAPER_SIZE)
        Select Case paperSize
            Case PAPER_SIZE.A3
                SetPaperSize(11.69, 16.54)
            Case PAPER_SIZE.A4Portrait
                SetPaperSize(8.27, 11.69)
            Case PAPER_SIZE.A4Landscape
                SetPaperSize(11.69, 8.27)
            Case PAPER_SIZE.B5
                SetPaperSize(7.17, 10.12)
            Case PAPER_SIZE.LEGAL
                SetPaperSize(8.5, 14)
            Case PAPER_SIZE.LETTER
                SetPaperSize(8.5, 11)
        End Select
    End Sub

    Public Sub SetPaperSize(ByVal width As Decimal, ByVal height As Decimal)
        _pageWidth = width
        _pageHeight = height
    End Sub

    Public Sub SetMargins(ByVal top As Decimal?, ByVal bottom As Decimal?, ByVal left As Decimal?, ByVal right As Decimal?)
        If top IsNot Nothing Then
            _marginTop = top
        End If
        If bottom IsNot Nothing Then
            _marginBottom = bottom
        End If
        If left IsNot Nothing Then
            _marginLeft = left
        End If
        If right IsNot Nothing Then
            _marginRight = right
        End If
    End Sub

    Public Function ToXml() As String
        Dim xml As String = _
                "<DeviceInfo>" & _
                "  <OutputFormat>" & ToSqlReportFormatCode(_outputFormat) & "</OutputFormat>" & _
                "  <PageWidth>" & _pageWidth & "in</PageWidth>" & _
                "  <PageHeight>" & _pageHeight & "in</PageHeight>" & _
                "  <MarginTop>" & _marginTop & "in</MarginTop>" & _
                "  <MarginLeft>" & _marginLeft & "in</MarginLeft>" & _
                "  <MarginRight>" & _marginRight & "in</MarginRight>" & _
                "  <MarginBottom>" & _marginBottom & "in</MarginBottom>" & _
                "  <HumanReadablePDF>True</HumanReadablePDF>" & _
                "</DeviceInfo>"
        Return xml
    End Function

    Private Function ToSqlReportFormatCode(ByVal outputFormat As OUTPUT_FORMAT)
        Select Case outputFormat
            Case OUTPUT_FORMAT.EXCEL
                'Return "XLS" '<<20140515>>
                Return "EXCEL" '<<20140515>>
            Case OUTPUT_FORMAT.PDF
                Return "PDF"
            Case OUTPUT_FORMAT.TIFF
                Return "TIF"
            Case OUTPUT_FORMAT.WORDS
                Return "DOC"
            Case Else
                Return "PDF"
        End Select
    End Function


End Class
