Imports System.Collections.Concurrent
Imports System.Collections
Imports System.Collections.Generic

Public Class WebChatSession
    Inherits ChatSession

    Private _participants As New ConcurrentDictionary(Of ChatUserKey, ChatUserKey)                                                                       '<-- participants
    Private _messages As New ConcurrentDictionary(Of ChatMessageKey, ChatMessage)                                                                           '<-- Message Id 
    Private _boardcastHistory As New ConcurrentDictionary(Of ChatMessageKey, ConcurrentDictionary(Of ChatUserKey, Object))           '<-- {Message Id, {User Id, Nothing}}

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal creator As ChatUserKey, ByVal participant As ChatUserKey)
        MyBase.New(creator, participant)
    End Sub

    Public Property Messages As ConcurrentDictionary(Of ChatMessageKey, ChatMessage)
        Get
            Return _messages
        End Get
        Set(ByVal value As ConcurrentDictionary(Of ChatMessageKey, ChatMessage))
            _messages = value
        End Set
    End Property

    Public Property BoardcastHistory As ConcurrentDictionary(Of ChatMessageKey, ConcurrentDictionary(Of ChatUserKey, Object))
        Get
            Return _boardcastHistory
        End Get
        Set(ByVal value As ConcurrentDictionary(Of ChatMessageKey, ConcurrentDictionary(Of ChatUserKey, Object)))
            _boardcastHistory = value
        End Set
    End Property

    Public Overrides Function HasUpdate(ByVal user As ChatUserKey, ByRef outstandingMessages As List(Of ChatMessage)) As Boolean
        outstandingMessages = New List(Of ChatMessage)
        For i = _messages.Values.Count - 1 To 0
            Dim _msg = _messages.Values(i)
            Dim _msgBcRec As ConcurrentDictionary(Of ChatUserKey, Object) = Nothing

            If _boardcastHistory.ContainsKey(_msg.MessageKey) Then
                _msgBcRec = _boardcastHistory(_msg.MessageKey)

                If _msgBcRec.ContainsKey(user) Then
                    'No more message
                    Exit For
                Else
                    'update users
                    outstandingMessages.Add(_msg)

                    _msgBcRec.AddOrUpdate(user, Nothing, Function(key, oldValue) Nothing)
                End If
            Else
                _msgBcRec = New ConcurrentDictionary(Of ChatUserKey, Object)
                _msgBcRec.AddOrUpdate(user, "", Function(key, oldValue) "")

                While Not (_boardcastHistory.TryGetValue(_msg.MessageKey, _msgBcRec))
                    _boardcastHistory.TryAdd(_msg.MessageKey, New ConcurrentDictionary(Of ChatUserKey, Object))
                    Threading.Thread.Sleep(1000)
                End While

                outstandingMessages.Add(_msg)
            End If
        Next
        Return (outstandingMessages.Count > 0)
    End Function

    Public Overrides Sub AddParticipant(ByVal participant As ChatUserKey)
        _participants.TryAdd(participant, participant)
    End Sub

    Public Overrides Sub Init(ByVal creator As ChatUserKey)
        AddParticipant(creator)
    End Sub

    Public Overrides Sub RemoveParticipant(ByVal participant As ChatUserKey)
        _participants.TryRemove(participant, participant)
    End Sub

    Public Overrides Sub WriteMessage(ByVal message As ChatMessage)
        _messages.AddOrUpdate(message.MessageKey, message, Function(key, oldvalue) message)
    End Sub

End Class
