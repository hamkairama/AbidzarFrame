Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO

Public Enum ChartType
    Column
    StackedColumn
    Point
    Line
    Bar
    Area
    Pie
End Enum

Public Class MsChartProvider
    Implements IChartImageProvider

    Private _engine As Object
    Private _chartType As ChartType
    Private _width As Integer
    Private _height As Integer

    Public Sub New(ByVal diagramType As ChartType)
        SetChartEngine(_engine)

        _chartType = diagramType
    End Sub

    Protected Overridable Sub SetChartEngine(ByRef engine As Object)
        Dim _chart = New Chart()

        _chart.ChartAreas.Add("Default")
        _chart.ChartAreas.Last.AxisX.MajorGrid.LineWidth = 0
        _chart.ChartAreas.Last.AxisY.MajorGrid.LineWidth = 0
        _chart.ChartAreas.Last.AxisX2.MajorGrid.LineWidth = 0
        _chart.ChartAreas.Last.AxisY2.MajorGrid.LineWidth = 0

        _chart.ChartAreas.Last.AxisX.Minimum = 0
        _chart.ChartAreas.Last.AxisX.IsStartedFromZero = True

        _chart.ChartAreas.Last.AxisX.LabelStyle.Interval = 5
        _chart.ChartAreas.Last.AxisX.LabelStyle.IntervalOffset = 5
        _chart.ChartAreas.Last.AxisY.IsLabelAutoFit = True
        _chart.ChartAreas.Last.AxisY2.IsLabelAutoFit = True

        _chart.Legends.Add("Default")
        _chart.Legends.Last.Docking = Docking.Bottom
        _chart.Legends.Last.LegendStyle = LegendStyle.Table
        _chart.Legends.Last.Alignment = Drawing.StringAlignment.Center

        engine = _chart
    End Sub

    Protected Function GetEngine(Of T)() As T
        Return DirectCast(_engine, T)

    End Function

    Public Function GenerateChartImage(ByVal chartData As ChartDataBase, ByRef output As Stream) As BusinessErrors Implements IChartImageProvider.GenerateChartImage
        Dim errs As New BusinessErrors
        Try
            Dim _chart As Chart = GetEngine(Of Chart)()
            FillInDataSeries(_chart, chartData)
            output = GetImages(_chart)
        Catch ex As Exception
            Utils.FillErrors(errs, ex)
        End Try
        Return errs
    End Function

    'Protected Overridable Sub FillInDataSeries(ByRef chart As Chart, ByVal chartData As ChartDataBase)
    '    For Each _data In chartData.ChartData
    '        Dim d As New Series
    '        CreateDataPoint(d, _data)

    '        chart.Series.Add(d)
    '    Next
    'End Sub

    Protected Overridable Sub FillInDataSeries(ByRef chart As Chart, ByVal chartData As ChartDataBase)
        Dim _chart As Chart = GetEngine(Of Chart)()
        _chart.Titles.Add(chartData.Title)
        _chart.Titles.Last.Docking = Docking.Top
        If Not String.IsNullOrEmpty(chartData.YAxisTitle) Then
            '_chart.Titles.Add(chartData.YAxisTitle)
            '_chart.Titles.Last.Docking = Docking.Left
            '_chart.Titles.Last.TextOrientation = TextOrientation.Rotated270
            _chart.ChartAreas.Last.AxisY.Title = chartData.YAxisTitle
        End If
        If Not String.IsNullOrEmpty(chartData.XAxisTitle) Then
            '_chart.Titles.Add(chartData.XAxisTitle)
            '_chart.Titles.Last.Docking = Docking.Bottom
            '_chart.Titles.Last.TextOrientation = TextOrientation.Horizontal
            _chart.ChartAreas.Last.AxisX.Title = chartData.XAxisTitle
        End If
        _chart.Width = Me._width                        'PreferredWidth
        _chart.Height = Me._height                      'PreferredHeight
        _chart.AntiAliasing = AntiAliasingStyles.All

        Dim _secType As Object = Nothing
        For Each _d In chartData.ChartData
            Dim d As New Series
            AssignChartType(d, _d, Me._chartType)
            CreateDataPoint(d, CType(_d, Object))
            _chart.Series.Add(d)
            If d.YAxisType = AxisType.Secondary Then
                _chart.ChartAreas.Last.AxisY2.Title = _d.YAxisTitle
            End If
        Next
        _chart.ChartAreas.Last.RecalculateAxesScale()

    End Sub

    Sub CreateDataPoint(ByRef chartSeries As Series, ByVal series As DataSeriesXY)
        For Each point In series.SeriesData
            chartSeries.Points.Add(New DataPoint(point.xValue, point.yValue))
        Next
    End Sub

    Sub CreateDataPoint(ByRef chartSeries As Series, ByVal series As DataSeriesNameWithValue)
        Dim _dataDict As New Dictionary(Of String, Decimal)
        For Each point In series.SeriesData
            _dataDict.Add(point.CategoryName, point.Value)
        Next
        chartSeries.Points.DataBindXY(_dataDict.Keys, _dataDict.Values)
    End Sub

    Protected Overridable Function GetImages(ByRef chart As Chart) As Stream
        Dim output As Stream = New MemoryStream()
        chart.SaveImage(output, ChartImageFormat.Bmp)
        output.Position = 0

        Return output
    End Function

    Public Sub SetSize(ByVal height As Integer, ByVal width As Integer) Implements IChartImageProvider.SetSize
        Me._height = height
        Me._width = width
    End Sub

    Public Overridable Function CreateChartData() As ChartDataBase Implements IChartImageProvider.CreateChartData
        Return New ChartDataBase

    End Function

    Protected Overridable Sub AssignChartType(ByRef dataSeries As Series, ByVal chartData As DataSeriesBase, ByVal defaultType As ChartType)
        Dim chart = GetEngine(Of Chart)()
        dataSeries.Legend = chart.Legends.Last.Name
        dataSeries.IsVisibleInLegend = True
        dataSeries.LegendText = chartData.SeriesTitle

        If chartData.ChartType Is Nothing OrElse chartData.ChartType = defaultType Then
            dataSeries.ChartType = GetMsChartType(defaultType)
            Return
        End If

        dataSeries.ChartType = GetMsChartType(chartData.ChartType)
        dataSeries.YAxisType = AxisType.Secondary
        'If Not String.IsNullOrEmpty(chartData.YAxisTitle) Then
        '    chart.Titles.Add(chartData.YAxisTitle)
        '    chart.Titles.Last.Docking = Docking.Right
        '    chart.Titles.Last.TextOrientation = TextOrientation.Rotated90
        'End If
    End Sub

    Protected Overridable Function GetMsChartType(ByVal chartType As ChartType) As SeriesChartType
        Select Case chartType
            Case chartType.Area
                Return SeriesChartType.Area
            Case chartType.Bar
                Return SeriesChartType.Bar
            Case chartType.Line
                Return SeriesChartType.Line
            Case chartType.Pie
                Return SeriesChartType.Pie
            Case chartType.Point
                Return SeriesChartType.Point
            Case chartType.StackedColumn
                Return SeriesChartType.StackedColumn
            Case Else
                Return SeriesChartType.Column
        End Select
    End Function

End Class
