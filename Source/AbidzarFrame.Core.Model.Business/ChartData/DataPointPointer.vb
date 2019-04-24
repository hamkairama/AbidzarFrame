Public Class DataPointPointer
    Inherits DataPointBase

    Private _category As String
    Private _pointValue As Decimal

    Public Sub New()
        _category = ""
        _pointValue = 0
    End Sub

    Public Sub New(ByVal category As String, ByVal pointValue As Decimal)
        _category = category
        _pointValue = pointValue
    End Sub

    Public Property CategoryName As String
        Get
            Return _category
        End Get
        Set(ByVal value As String)
            _category = value
        End Set
    End Property

    Public Property PointValue As Decimal
        Get
            Return _pointValue
        End Get
        Set(ByVal value As Decimal)
            _pointValue = value
        End Set
    End Property

End Class
