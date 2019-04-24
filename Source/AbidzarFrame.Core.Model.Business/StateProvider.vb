Public Class StateProvider

    Private Shared _stateServiceProvider As IStateService

    Public Shared ReadOnly Property CacheProvider As IStateService
        Get
            Return CreateProvider()
        End Get
    End Property

    Shared Sub New()

    End Sub

    Public Shared Function CreateProvider() As IStateService
        If _stateServiceProvider Is Nothing Then
        Dim _provider As String = BusinessModelSetting.GetInstance().Parameters(BusinessModelSetting.STATE_SERVICE_PROVIDER)
        Dim _s As String() = _provider.Split(".")
        Dim _n As String = _provider.Substring(0, _provider.Length - _s(_s.Count - 1).Length - 1)
        _stateServiceProvider = Utils.LoadClass(Of IStateService)(_n, _s(_s.Count - 1))
        End If
        Return _stateServiceProvider
    End Function

    Public Shared Sub SetSharedVariable(ByVal objectName As String, ByVal value As Object)
        CacheProvider.SetValue(StateScope.Application, objectName, value)
    End Sub

    Public Shared Function GetSharedVariable(ByVal objectName As String) As Object
        Return CacheProvider.GetValue(StateScope.Application, objectName)
    End Function

    Public Shared Sub SetVariable(ByVal objectName As String, ByVal value As Object)
        CacheProvider.SetValue(StateScope.Session, objectName, value)
    End Sub

    Public Shared Function GetVariable(ByVal objectName As String) As Object
        Return CacheProvider.GetValue(StateScope.Session, objectName)
    End Function

End Class
