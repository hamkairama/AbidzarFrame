
Imports System.IO
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Media
Imports Syncfusion.Windows.Chart

Public Class ChartEngine
    Implements IChartEngine

    Private _chartType As ChartTypes
    Private _chart As Chart
    Private _provider As SyncfusionChartProvider

    Public Sub New(ByVal provider As SyncfusionChartProvider, _
                   ByVal chartType As ChartTypes, _
                   ByVal height As Integer, _
                   ByVal width As Integer, _
                   ByVal background As Brush)
        _chart = New Chart
        _chart.Height = height
        _chart.Width = width
        _chart.Background = background
        ' _chart.Areas.Add(New ChartArea With {.Legend = legend})
        _chartType = chartType
        _provider = provider
    End Sub

    Public Overridable ReadOnly Property Chart As Object Implements IChartEngine.Chart
        Get
            Return _chart
        End Get
    End Property

    Public Overridable ReadOnly Property Height As Integer Implements IChartEngine.Height
        Get
            Return _chart.Height
        End Get
    End Property

    Public Overridable ReadOnly Property Width As Integer Implements IChartEngine.Width
        Get
            Return _chart.Width
        End Get
    End Property

    Public Sub FillInDataSeries(ByVal chartData As ChartDataBase) Implements IChartEngine.FillInDataSeries

        For Each _data In chartData.ChartData
            Dim _series As New ChartSeries()

            If _data.ChartType Is Nothing Then
                _series.Type = _chartType
            Else
                _series.Type = _data.ChartType
            End If

            _series.Label = _data.SeriesTitle

            AcceptChartData(_series, CType(_data, Object))
            _series.IsIndexed = True
            _series.IsVisibleOnLegend = _data.IsVisibleOnLegend

            If _data.ChartAreaIndex <= Chart.Areas.Count - 1 Then
                _chart.Areas(_data.ChartAreaIndex).Series.Add(_series)
            End If

        Next

    End Sub

    Public Sub Save(ByRef out As Stream) Implements IChartEngine.Save
        '_chart.Save(out)
        out = Utils.GetImageOfControl(_chart)

    End Sub

    Overridable Sub AcceptChartData(ByRef list As ChartSeries, ByVal records As DataSeriesXY)
        Dim _listData As New ChartListData
        For Each _rec In records.SeriesData
            _listData.AddPoint(_rec.xValue, _rec.yValue)
        Next
        list.Data = _listData
        _provider.FormatSeries(records.SeriesTitle, _listData)
    End Sub

    Overridable Sub AcceptChartData(ByRef series As ChartSeries, ByVal records As DataSeriesNameWithValue)
        Dim ds As New ObservableCollection(Of DataPointNameWithValue)
        For Each rec In records.SeriesData
            ds.Add(rec)
        Next
        series.DataSource = ds
        series.BindingPathsY = {"Value"}
        series.BindingPathX = "CategoryName"
        _provider.FormatSeries(records.SeriesTitle, series)
    End Sub

    Public Sub SetSize(ByVal height As Integer, ByVal width As Integer) Implements IChartEngine.SetSize
        _chart.Height = height
        _chart.Width = width
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                If TypeOf _chart Is Chart Then
                    If _chart IsNot Nothing Then
                        Dim _removeList As New List(Of ChartArea)

                        For Each a In _chart.Areas
                            _removeList.Add(a)
                        Next
                        For Each a In _removeList
                            _chart.Areas.Remove(a)
                            a.Dispose()
                            a = Nothing
                        Next
                        _removeList.Clear()
                        _removeList = Nothing

                        _chart.Dispose()
                    End If
                End If


                _chart = Nothing
                _chartType = Nothing
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
