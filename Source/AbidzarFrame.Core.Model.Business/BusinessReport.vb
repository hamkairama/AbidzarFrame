Imports Microsoft.Reporting.WinForms
Imports System.Reflection

Public MustInherit Class BusinessReport
    Implements IBusinessReport

    Private _recordIndex As Long

    Private _reportFile As String = Nothing
    Private _data As List(Of ReportDataSource) = New List(Of ReportDataSource)

    Protected MustOverride Sub SetReportFile(ByRef reportFile As String)

    Protected MustOverride Sub SetDataSource(ByRef dataSource As List(Of ReportDataSource))

    Protected Overridable Sub InitOtherReportParameters(ByRef viewer As ReportViewer)
        'Reserve for local customerization
    End Sub

    Protected Overridable Sub SetSubreportDataSource(ByVal reportPath As String, ByRef parentRecord As DataRow, _
                                                     ByRef dataSource As List(Of ReportDataSource))
        'Reserve for sub-report printing
    End Sub

    Protected ReadOnly Property Report As String
        Get
            Return _reportFile
        End Get
    End Property

    Public Sub New()
        SetReportFile(_reportFile)
    End Sub

    Public Sub New(ByVal reportFile As String)
        _reportFile = reportFile
    End Sub

    Private Sub SetSecondaryDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        If _data IsNot Nothing Then
        Dim p As ReportDataSource = _data(0)
        Dim dt As DataTable = CType(p.Value, DataTable)

        Dim ds As New List(Of ReportDataSource)
        SetSubreportDataSource(e.ReportPath, dt.Rows(_recordIndex), ds)

        e.DataSources.Clear()
        For Each d In ds
            e.DataSources.Add(d)
        Next
        _recordIndex = _recordIndex + 1
        End If
    End Sub

    Private Sub PrepareReport(ByRef viewer As ReportViewer)
        InitReportParameters(viewer)
        InitOtherReportParameters(viewer)
        SetDataSource(_data)
        SetReportDataSources(viewer)
    End Sub

    Private Sub InitReportParameters(ByRef viewer As ReportViewer)
        _recordIndex = 0
        viewer.Reset()
        viewer.LocalReport.ReportPath = _reportFile

        AddHandler viewer.LocalReport.SubreportProcessing, AddressOf SetSecondaryDataSource
    End Sub

    Private Sub SetReportDataSources(ByRef viewer As ReportViewer)
        If _data IsNot Nothing Then
        viewer.LocalReport.DataSources.Clear()
        For Each d In _data
            viewer.LocalReport.DataSources.Add(d)
        Next
        End If
    End Sub

    Public Function Print(ByVal printData As PrintingParameters, ByRef output() As Byte) As BusinessErrors Implements IBusinessReport.Print
        Dim errs As New BusinessErrors
        'Dim trys As Integer = 3
        Dim b As Byte() = Nothing
        Dim reportViewer As ReportViewer = Nothing
        'Dim done As Boolean = False
        'While trys > 0 AndAlso Not done
        Try
            reportViewer = New ReportViewer

            PrepareReport(reportViewer)
            'If errors throws here, please check the field name in rdlc is duplicated
            b = reportViewer.LocalReport.Render(printData.ReportFormat, printData.ToXml())
            output = b
            'done = True
        Catch ex As Exception
            'If trys > 0 Then
            '    trys -= 1
            '    Threading.Thread.Sleep(500)
            'Else
            Utils.FillErrors(errs, ex)
            'Exit While
            'End If
        Finally
            If reportViewer IsNot Nothing Then
                reportViewer.Dispose()
            End If
            reportViewer = Nothing
            b = Nothing
            'If BusinessReport.ReportViewer IsNot Nothing Then
            '    BusinessReport.ReportViewer.Dispose()
            'End If
        End Try
        'End While
        Return errs
    End Function

End Class
