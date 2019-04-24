Public Class DataRangeGauge
    Inherits DataRangeBase

    Private _category As String
    Private _startValue As Decimal
    Private _endValue As Decimal

    Public Sub New()
        _category = ""
        _startValue = 0
        _endValue = 0
    End Sub

    Public Sub New(ByVal category As String, _
                   ByVal startValue As Decimal, _
                   ByVal endValue As Decimal)
        _category = category
        _startValue = startValue
        _endValue = endValue
    End Sub

    Public Property CategoryName As String
        Get
            Return _category
        End Get
        Set(ByVal value As String)
            _category = value
        End Set
    End Property

    Public Property StartValue As Decimal
        Get
            Return _startValue
        End Get
        Set(ByVal value As Decimal)
            _startValue = value
        End Set
    End Property

    Public Property EndValue As Decimal
        Get
            Return _endValue
        End Get
        Set(ByVal value As Decimal)
            _endValue = value
        End Set
    End Property

End Class
