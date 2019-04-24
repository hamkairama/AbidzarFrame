Public Class DataPointNameWithValue
    Inherits DataPointBase

    Dim _categoryName As String
    Dim _value As Decimal

    Public Sub New()
        Me.New("", 0)
    End Sub

    Public Sub New(ByVal categoryName As String, ByVal value As Decimal)
        Me._categoryName = categoryName
        Me._value = value

    End Sub

    Public Property CategoryName As String
        Get
            Return _categoryName
        End Get
        Set(ByVal value As String)
            _categoryName = value
        End Set
    End Property

    Public Property Value As Decimal
        Get
            Return _value
        End Get
        Set(ByVal value As Decimal)
            Me._value = value
        End Set
    End Property

End Class
