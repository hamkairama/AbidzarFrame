Public Class DataSeriesGauage
    Inherits DataSeriesBase

    Private _ranges As List(Of DataRangeGauge)
    Private _points As List(Of DataPointPointer)

    Public Sub New()
        MyBase.New()
        _ranges = New List(Of DataRangeGauge)
        _points = New List(Of DataPointPointer)
    End Sub

    Public Property Ranges As List(Of DataRangeGauge)
        Get
            Return _ranges
        End Get
        Set(ByVal value As List(Of DataRangeGauge))
            _ranges = value
        End Set
    End Property

    Public Property Points As List(Of DataPointPointer)
        Get
            Return _points
        End Get
        Set(ByVal value As List(Of DataPointPointer))
            _points = value
        End Set
    End Property

End Class
