Public Class PreprintFormSignatureField
    Inherits PreprintFormField

    Public Sub New(_pageIndex As Integer, _xPosition As Single, _yPosition As Single, _height As Single, _width As Single, _fieldName As String)
        PageIndex = _pageIndex
        Xposition = _xPosition
        Yposition = _yPosition
        Height = _height
        Width = _width
        FieldName = _fieldName
    End Sub
End Class
