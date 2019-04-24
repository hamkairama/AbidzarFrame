Public MustInherit Class GenericIterator
    Implements Iterator

    Private _isDone As Boolean = True
    Private _currentObject As Object = Nothing

    Public MustOverride Function NextOne() As Boolean Implements Iterator.NextOne
    Public MustOverride Sub FirstOne() Implements Iterator.FirstOne

    Public Sub New()
        Reset()
    End Sub

    Protected Sub Reset()
        _isDone = False
        FirstOne()
    End Sub

    Protected Sub SetCurrent(ByRef obj As Object)
        _currentObject = obj
    End Sub

    Public Function CurrentItem(Of T)() As T Implements Iterator.CurrentItem
        Return DirectCast(_currentObject, T)
    End Function

    Public Function IsDone() As Boolean Implements Iterator.IsDone
        Return _isDone
    End Function


End Class
