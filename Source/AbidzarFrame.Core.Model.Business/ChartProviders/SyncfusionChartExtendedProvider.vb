Imports Syncfusion.Windows.Chart
Imports System.IO
Imports System.Drawing
Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public MustInherit Class SyncfusionChartExtendedProvider
    Implements IChartImageProvider

    Private _chartType As ChartTypes

    Public Sub New()
        SetChartParameters(_chartType)
    End Sub

    Public MustOverride Sub SetChartParameters(ByRef chartType As ChartTypes)

    Public Overridable Function CreateChartData() As ChartDataBase Implements IChartImageProvider.CreateChartData
        Return New ChartDataBase
    End Function

    Public Overridable Function CreateChartArea() As ChartArea
        Return New ChartArea()
    End Function

    Public Function GenerateChartImage(ByVal chartData As ChartDataBase) As System.IO.Stream Implements IChartImageProvider.GenerateChartImage
        Dim _chartControl As New Syncfusion.Windows.Chart.Chart
        Dim _area = CreateChartArea()
        _chartControl.Areas.Add(_area)
        FillInDataSeries(_area, chartData)

        Dim _output As New MemoryStream
        _chartControl.Save(_output)
        Return _output

    End Function

    Protected Sub FillInDataSeries(ByRef area As ChartArea, ByVal chartData As ChartDataBase)
        For Each _data In chartData.ChartData
            Dim _series As New ChartSeries(chartData.Title)
            _series.Type = _chartType
            _series.Label = _data.SeriesTitle

            Dim _listData As New ChartListData
            For Each _rec In _data.SeriesData
                _listData.AddPoint(_rec.xValue, _rec.yValue)
            Next
            _series.Data = _listData

            area.Series.Add(_series)
        Next

    End Sub

End Class

