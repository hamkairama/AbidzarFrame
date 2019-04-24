Imports System.Collections.Generic

Public Class DataSeriesBase

    Private _seriesId As String
    Private _seriesTitle As String
    Private _yaxisTitle As String
    Private _chartType As Object
    Private _chartAreaIndex As Integer
    Private _isVisibleOnLegend As Boolean

    Public Sub New()
        _seriesId = Nothing
        _seriesTitle = Nothing
        _chartType = Nothing
        _chartAreaIndex = 0
        _isVisibleOnLegend = True
    End Sub

    Public Property SeriesId As String
        Get
            Return _seriesId
        End Get
        Set(ByVal value As String)
            _seriesId = value
        End Set
    End Property

    Public Property SeriesTitle As String
        Get
            Return _seriesTitle
        End Get
        Set(ByVal value As String)
            _seriesTitle = value
        End Set
    End Property

    Public Property YAxisTitle As String
        Get
            Return _yaxisTitle
        End Get
        Set(ByVal value As String)
            _yaxisTitle = value
        End Set
    End Property

    Public Property ChartType As Object
        Get
            Return _chartType
        End Get
        Set(ByVal value As Object)
            _chartType = value
        End Set
    End Property

    Public Property ChartAreaIndex As Integer
        Get
            Return _chartAreaIndex
        End Get
        Set(ByVal value As Integer)
            _chartAreaIndex = value
        End Set
    End Property

    Public Property IsVisibleOnLegend As Boolean
        Get
            Return _isVisibleOnLegend
        End Get
        Set(ByVal value As Boolean)
            _isVisibleOnLegend = value
        End Set
    End Property

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If TypeOf obj Is DataSeriesBase Then
            Dim other = DirectCast(obj, DataSeriesBase)
            If other.SeriesId = Me.SeriesId Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return New With {Key .A = Me.SeriesId}.GetHashCode()
    End Function

End Class
