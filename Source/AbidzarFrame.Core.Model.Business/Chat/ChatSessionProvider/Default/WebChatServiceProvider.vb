Imports System.Collections.Generic
Imports System.Collections.Concurrent

Public Class WebChatServiceProvider
    Inherits ChatServiceBase
    Implements IChatService

    Private _chatSessions As ConcurrentDictionary(Of ChatSessionKey, ChatSession) = Nothing

    Protected ReadOnly Property ChatSessions As ConcurrentDictionary(Of ChatSessionKey, ChatSession)
        Get
            If _chatSessions Is Nothing Then
                Dim _chatSessions = StateProvider.GetSharedVariable(CHAT_SESSIONS)
                If _chatSessions Is Nothing Then
                    _chatSessions = New ConcurrentDictionary(Of ChatSessionKey, ChatSession)
                    StateProvider.SetSharedVariable(CHAT_SESSIONS, _chatSessions)
                End If
            End If
            Return _chatSessions
        End Get
    End Property

    Protected Function CreateKey() As ChatSessionKey
        Return New ChatSessionKey With {.SessionId = Guid.NewGuid.ToString}
    End Function

    Public Function CreateSession(ByVal openUser As ChatUserKey, ByVal targetUser As ChatUserKey, _
                                  ByVal isGroup As Boolean, ByRef success As Boolean, _
                                  ByRef chatSessionKey As ChatSessionKey) As BusinessErrors Implements IChatService.CreateSession
        Dim _errs As New BusinessErrors
        Try
            Dim _key As ChatSessionKey = CreateKey()
            While Not (ChatSessions.TryAdd(_key, NewChatSession(openUser, targetUser)))
                Threading.Thread.Sleep(CHAT_SLEEP_INTERVAL)
                _key = CreateKey()
            End While
            chatSessionKey = _key

        Catch ex As Exception
            Utils.FillErrors(_errs, ex)
        End Try
        Return _errs
    End Function

    Public Function IsUpdated(ByVal user As ChatUserKey, ByVal chatSession As ChatSessionKey, _
                              ByRef isUpdate As Boolean, ByRef message As System.Collections.Generic.List(Of ChatMessage)) _
                          As BusinessErrors Implements IChatService.IsUpdated
        Dim _errs As New BusinessErrors
        Try
            Dim _session As ChatSession = Nothing
            If ChatSessions.TryGetValue(chatSession, _session) Then
                isUpdate = _session.HasUpdate(user, message)
            End If

        Catch ex As Exception
            Utils.FillErrors(_errs, ex)
        End Try
        Return _errs
    End Function

    Public Function JoinSession(ByVal user As ChatUserKey, ByVal chatSession As ChatSessionKey) _
        As BusinessErrors Implements IChatService.JoinSession
        Dim _errs As New BusinessErrors
        Try
            Dim _session As WebChatSession = Nothing
            If ChatSessions.TryGetValue(chatSession, _session) Then
                _session.AddParticipant(user)
            End If

        Catch ex As Exception
            Utils.FillErrors(_errs, ex)
        End Try
        Return _errs
    End Function

    Public Function TerminateSession(ByVal user As ChatUserKey, ByVal chatSession As ChatSessionKey) _
        As BusinessErrors Implements IChatService.TerminateSession
        Dim _errs As New BusinessErrors
        Try
            Dim _session As WebChatSession = Nothing
            If ChatSessions.TryGetValue(chatSession, _session) Then
                _session.RemoveParticipant(user)
            End If

        Catch ex As Exception
            Utils.FillErrors(_errs, ex)
        End Try
        Return _errs
    End Function

    Public Function Write(ByVal message As ChatMessage) As BusinessErrors Implements IChatService.Write
        Dim _errs As New BusinessErrors
        Try
            Dim _session As WebChatSession = Nothing
            If ChatSessions.TryGetValue(message.ChatSessionKey, _session) Then
                _session.WriteMessage(message)
            End If

        Catch ex As Exception
            Utils.FillErrors(_errs, ex)
        End Try
        Return _errs
    End Function

    Public Overrides Function NewChatSession(ByVal creator As ChatUserKey, ByVal participant As ChatUserKey) As ChatSession
        Return New WebChatSession(creator, participant)

    End Function

End Class
