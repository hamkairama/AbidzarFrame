Public Class DataSeriesXY
    Inherits DataSeriesBase

    Private _seriesData As List(Of DataPointXY)

    Public Sub New()
        MyBase.New()
        _seriesData = New List(Of DataPointXY)
    End Sub

    Public Property SeriesData As List(Of DataPointXY)
        Get
            Return _seriesData
        End Get
        Set(ByVal value As List(Of DataPointXY))
            _seriesData = value
        End Set
    End Property

End Class
