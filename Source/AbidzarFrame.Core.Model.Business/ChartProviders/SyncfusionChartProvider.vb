Imports Syncfusion.Windows.Chart
Imports System.IO
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Media

Public MustInherit Class SyncfusionChartProvider
    Implements IChartImageProvider

    Private _engine As IChartEngine

    Public Sub New()
        'SetChart(_engine)
    End Sub

    Protected MustOverride Sub SetChart(ByRef engine As IChartEngine)

    MustOverride Sub FormatSeries(ByVal dataName As String, ByRef series As Object)

    Protected Overridable Function CreateChartWindow() As Window
        Dim _window As Window = New Window
        _window.Visibility = Windows.Visibility.Collapsed
        _window.WindowStyle = Windows.WindowStyle.SingleBorderWindow
        _window.ShowInTaskbar = False
        _window.ShowActivated = False
        _window.WindowState = Windows.WindowState.Minimized
        _window.Height = _engine.Height
        _window.Width = _engine.Width
        _window.SizeToContent = SizeToContent.WidthAndHeight

        Return _window

    End Function

    Public Overridable Function CreateChartData() As ChartDataBase Implements IChartImageProvider.CreateChartData
        Return New ChartDataBase

    End Function

    Public Function GenerateChartImage(ByVal chartData As ChartDataBase, ByRef output As Stream) As BusinessErrors Implements IChartImageProvider.GenerateChartImage
        Dim errs As New BusinessErrors
      
        Dim _output As New MemoryStream
        Dim _window As Window = Nothing
        Try
            SetChart(Me._engine)
            _engine.FillInDataSeries(chartData)

            _window = CreateChartWindow()
            _window.Content = _engine.Chart
            _window.Show()

            _engine.Save(_output)

            AddHandler _window.Closed, Sub(sender, e)
                                           sender.Dispatcher.InvokeShutdown()
                                           _window = Nothing
                                       End Sub
            _window.Content = Nothing
            
        Catch ex As Exception
            Utils.FillErrors(errs, ex)
        Finally
            If Me._engine IsNot Nothing Then
                Me._engine.Dispose()
                Me._engine = Nothing
            End If

            If _window IsNot Nothing Then
                _window.Close()
                _window = Nothing
            End If

        End Try

        output = _output
        Return errs
    End Function

    Public Sub SetSize(ByVal height As Integer, ByVal width As Integer) Implements IChartImageProvider.SetSize
        _engine.SetSize(height, width)
    End Sub

End Class

