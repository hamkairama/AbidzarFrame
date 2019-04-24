Imports Syncfusion.Windows.Forms.Chart
Imports System.IO
Imports System.Drawing

Public MustInherit Class SyncfusionChartProvider
    Implements IChartImageProvider

    Private _chartType As ChartSeriesType

    Public Sub New()
        SetChartParameters(_chartType)
    End Sub

    Public MustOverride Sub SetChartParameters(ByRef chartType As ChartSeriesType)

    Public Function CreateChartData() As ChartDataBase Implements IChartImageProvider.CreateChartData
        Return New ChartDataBase
    End Function

    Public Function GenerateChartImage(ByVal chartData As ChartDataBase) As System.IO.Stream Implements IChartImageProvider.GenerateChartImage
        Dim chartControl As New ChartControl
        FillInDataSeries(chartControl, chartData)

        Dim _output As New MemoryStream
        Dim _image As System.Drawing.Image = Nothing
        chartControl.Draw(_image)
        _image.Save(_output, Drawing.Imaging.ImageFormat.Jpeg)

        Return _output

    End Function

    Protected Sub FillInDataSeries(ByRef control As ChartControl, ByVal chartData As ChartDataBase)
        For Each _data In chartData.ChartData
            Dim _series As New ChartSeries(chartData.Title)
            _series.Type = _chartType
            _series.Text = _data.SeriesTitle
            For Each _point In _data.SeriesData
                _series.Points.Add(New ChartPoint(_point.xValue, _point.yValue))
            Next
            control.Series.Add(_series)
        Next

    End Sub

End Class