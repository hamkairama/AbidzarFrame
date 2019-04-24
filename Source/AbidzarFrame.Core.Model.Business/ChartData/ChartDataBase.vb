Public Class ChartDataBase

    Private _title As String
    Private _yaxisTitle As String
    Private _xaxisTitle As String
    Private _chartData As List(Of DataSeriesBase)

    Public Sub New()
        _title = Nothing
        _chartData = New List(Of DataSeriesBase)
    End Sub

    Public Property Title As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
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

    Public Property XAxisTitle As String
        Get
            Return _xaxisTitle
        End Get
        Set(ByVal value As String)
            _xaxisTitle = value
        End Set
    End Property

    Public Property ChartData As List(Of DataSeriesBase)
        Get
            Return _chartData
        End Get
        Set(ByVal value As List(Of DataSeriesBase))
            _chartData = value
        End Set
    End Property

End Class
