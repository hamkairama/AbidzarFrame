Public Class PreprintFormTextField
    Inherits PreprintFormField
    Public Property Maxlength As Integer = 1000000000
    Public Property MultiLine As Boolean = False
    Public Property FontSize As Integer
    Public Property DefaultValue As String
    Public Property IsReadOnly As Boolean = False

    Public Sub New(_pageIndex As Integer, _xPosition As Single, _yPosition As Single, _height As Single, _width As Single, _fieldName As String)
        PageIndex = _pageIndex
        Xposition = _xPosition
        Yposition = _yPosition
        Height = _height
        Width = _width
        FieldName = _fieldName
    End Sub
End Class
