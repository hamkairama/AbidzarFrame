Public Class DataPointXY
    Inherits DataPointBase

    Private _xValue As Decimal
    Private _yValue As Decimal

    Public Sub New()
        Me.New(0, 0)
    End Sub

    Public Sub New(ByVal x As Decimal, ByVal y As Decimal)
        _xValue = x
        _yValue = y
    End Sub

    Public Property xValue As Decimal
        Get
            Return _xValue
        End Get
        Set(ByVal value As Decimal)
            _xValue = value
        End Set
    End Property

    Public Property yValue As Decimal
        Get
            Return _yValue
        End Get
        Set(ByVal value As Decimal)
            _yValue = value
        End Set
    End Property

End Class
