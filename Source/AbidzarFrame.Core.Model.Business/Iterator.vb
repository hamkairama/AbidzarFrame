Imports System.AccessViolationException

Public Interface Iterator

    Sub FirstOne()
    Function NextOne() As Boolean       'True if next one is available else false
    Function IsDone() As Boolean        'True if the end is reached else false
    Function CurrentItem(Of T)() As T

End Interface
