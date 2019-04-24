'Imports AbidzarFrame.Core.Model.Business
Imports AbidzarFrame.Core.Model.Business
Imports System.Collections.Concurrent
Imports System.Web
Imports System.Web.SessionState

Public Class LocalStateProvider
    Implements IStateService

    Private Shared AppData As New ConcurrentDictionary(Of String, Object)
    Private Shared SessData As New ConcurrentDictionary(Of String, Dictionary(Of String, Object))

    Private _sessionKey As String = Guid.NewGuid.ToString()

    Public Sub New()
        If Not IsNothing(HttpContext.Current) Then
            _sessionKey = HttpContext.Current.Session.SessionID
        End If
    End Sub

    Public Function GetValue(ByVal scope As Business.StateScope, ByVal objectName As String) As Object Implements Business.IStateService.GetValue
        If scope = Business.StateScope.Application Then
            Dim data As Object = Nothing
            If AppData.TryGetValue(objectName, data) Then
                Return data
            Else
                Return Nothing
            End If
        End If

        If scope = Business.StateScope.Session Then
            Dim session As Dictionary(Of String, Object) = Nothing
            If SessData.TryGetValue(_sessionKey, session) Then
                Dim data As Object = Nothing
                If session.TryGetValue(objectName, data) Then
                    Return data
                Else
                    Return Nothing
                End If
            End If
        End If

        Return Nothing
    End Function

    Public Sub SetValue(ByVal scope As Business.StateScope, ByVal objectName As String, ByVal value As Object) Implements Business.IStateService.SetValue
        If scope = Business.StateScope.Application Then
            AppData.AddOrUpdate(objectName, value, Function(k, o) value)
        End If

        If scope = Business.StateScope.Session Then
            Dim session As Dictionary(Of String, Object) = Nothing
            If Not SessData.TryGetValue(_sessionKey, session) Then
                session = New Dictionary(Of String, Object)
                SessData.AddOrUpdate(_sessionKey, session, Function(k, o) session)
            End If

            If session.ContainsKey(objectName) Then
                session(objectName) = value
            Else
                session.Add(objectName, value)
            End If
        End If
    End Sub

End Class
