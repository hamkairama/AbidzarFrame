Imports Syncfusion.Windows.Chart
Imports System.IO
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Media
Imports Manulife.Core.Model.Business
Imports Syncfusion.Windows.Gauge

Public Class GaugeEngine
    Implements IChartEngine

    Private _provider As SyncfusionChartProvider
    Private _gauge As CircularGauge

    Public Sub New(ByRef provider As SyncfusionChartProvider, _
                   ByVal height As Integer, _
                   ByVal width As Integer, _
                   ByRef scale As CircularScale)
        _gauge = New CircularGauge
        _gauge.Height = height
        _gauge.Width = width
        _gauge.Scales.Add(scale)

        _provider = provider
    End Sub

    Public ReadOnly Property Chart As Object Implements IChartEngine.Chart
        Get
            Return _gauge
        End Get
    End Property

    Public Sub FillInDataSeries(ByVal chartData As ChartDataBase) Implements IChartEngine.FillInDataSeries

        For Each _data In chartData.ChartData
            Dim _scale As CircularScale = _gauge.Scales(0)
            AcceptChartData(_scale, CType(_data, Object))
            _gauge.Scales.Add(_scale)
        Next

    End Sub

    Overloads Sub AcceptChartData(ByRef scale As CircularScale, ByVal gauge As DataSeriesGauage)
        Dim _base As Decimal = 0
        For Each g In gauge.Ranges
            Dim r As New CircularRange
            If _base = 0 Then
                _base = g.EndValue - g.StartValue
            End If
            If _base > 0 Then
                r.StartValue = g.StartValue / _base * 100
                r.EndValue = g.EndValue / _base * 100
            End If

            _provider.FormatSeries(g.CategoryName, r)
            scale.Ranges.Add(r)
        Next
        For Each p In gauge.Points
            Dim r As New CircularPointer
            If _base > 0 Then
                r.Value = p.PointValue / _base * 100
            End If

            _provider.FormatSeries(p.CategoryName, r)
            scale.Pointers.Add(r)
        Next

        Dim _maxVal As Decimal = -1
        For Each _pointer In scale.Pointers
            If _pointer.Value > _maxVal Then
                _maxVal = _pointer.Value
            End If
        Next

        If _maxVal >= scale.Maximum Then
            _maxVal = ((_maxVal / scale.MajorIntervalValue) + 1) * scale.MajorIntervalValue
            scale.Maximum = _maxVal
            If scale.Ranges.Count > 0 Then
                scale.Ranges.Last.EndValue = _maxVal
            End If
        End If

    End Sub

    Public ReadOnly Property Height As Integer Implements IChartEngine.Height
        Get
            Return _gauge.Height
        End Get
    End Property

    Public Sub Save(ByRef out As System.IO.Stream) Implements IChartEngine.Save
        out = Utils.GetImageOfControl(_gauge)
    End Sub

    Public ReadOnly Property Width As Integer Implements IChartEngine.Width
        Get
            Return _gauge.Width
        End Get
    End Property

    Public Sub SetSize(ByVal height As Integer, ByVal width As Integer) Implements IChartEngine.SetSize
        _gauge.Height = height
        _gauge.Width = width
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                _gauge = Nothing
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
