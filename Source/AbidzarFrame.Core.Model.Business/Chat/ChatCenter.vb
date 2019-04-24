Imports Setting = Manulife.Core.Model.Business.BusinessModelSetting

Public Class ChatCenter

    Private Shared _chatService As IChatService = Nothing

    Shared Sub New()
        If _chatService Is Nothing Then
            SyncLock _chatService
                If _chatService Is Nothing Then
                    Dim _chatServiceProvider As String = Setting.GetInstance().Parameters(Setting.CHAT_SERVICE_PROVIDER)
                    Dim _s As String() = _chatServiceProvider.Split(".")
                    Dim _n As String = _chatServiceProvider.Substring(0, _chatServiceProvider.Length - _s(_s.Count - 1).Length - 1)
                    _chatService = Utils.LoadClass(Of IChatService)(_n, _s(_s.Count - 1))
                End If
            End SyncLock
        End If
    End Sub

    Public Shared Function CreateSession(ByVal openUser As ChatUserKey, ByVal targetUser As ChatUserKey, ByVal isGroup As Boolean, ByRef success As Boolean, ByRef chatSessionKey As ChatSessionKey) As BusinessErrors
        Return _chatService.CreateSession(openUser, targetUser, isGroup, success, chatSessionKey)
    End Function

    Public Shared Function IsUpdated(ByVal user As ChatUserKey, ByVal chatSession As ChatSessionKey, ByRef isUpdate As Boolean, ByRef message As System.Collections.Generic.List(Of ChatMessage)) As BusinessErrors
        Return _chatService.IsUpdated(user, chatSession, isUpdate, message)
    End Function

    Public Shared Function JoinSession(ByVal user As ChatUserKey, ByVal chatSession As ChatSessionKey) As BusinessErrors
        Return _chatService.JoinSession(user, chatSession)
    End Function

    Public Shared Function TerminateSession(ByVal user As ChatUserKey, ByVal chatSession As ChatSessionKey) As BusinessErrors
        Return _chatService.TerminateSession(user, chatSession)
    End Function

    Public Shared Function Write(ByVal message As ChatMessage) As BusinessErrors
        Return _chatService.Write(message)
    End Function

End Class
