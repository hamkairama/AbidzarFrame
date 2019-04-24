Public Enum StateScope
    Application
    Session
End Enum

Public Interface IStateService

    Sub SetValue(ByVal scope As StateScope, ByVal objectName As String, ByVal value As Object)

    Function GetValue(ByVal scope As StateScope, ByVal objectName As String) As Object

End Interface
