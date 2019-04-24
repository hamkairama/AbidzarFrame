Public Class DataSeriesNameWithValue
    Inherits DataSeriesBase

    Private _seriesData As List(Of DataPointNameWithValue)

    Public Sub New()
        MyBase.New()
        _seriesData = New List(Of DataPointNameWithValue)
    End Sub

    Public Property SeriesData As List(Of DataPointNameWithValue)
        Get
            Return _seriesData
        End Get
        Set(ByVal value As List(Of DataPointNameWithValue))
            _seriesData = value
        End Set
    End Property

End Class
