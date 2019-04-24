Imports System.Collections.Concurrent

Public MustInherit Class ChatSession

    Private _sessionKey As ChatSessionKey

    Public Property SessionKey As ChatSessionKey
        Get
            Return _sessionKey
        End Get
        Set(ByVal value As ChatSessionKey)
            _sessionKey = value
        End Set
    End Property

    Public Sub New()
        Me.New(Nothing, Nothing)
    End Sub

    Public Sub New(ByVal creator As ChatUserKey, Optional ByVal participant As ChatUserKey = Nothing)
        _sessionKey = Nothing
        If creator IsNot Nothing Then
            Init(creator)
        End If
        If participant IsNot Nothing Then
            AddParticipant(participant)
        End If
    End Sub

    Public MustOverride Function HasUpdate(ByVal user As ChatUserKey, ByRef outstandingMessages As List(Of ChatMessage)) As Boolean
    Public MustOverride Sub Init(ByVal creator As ChatUserKey)
    Public MustOverride Sub AddParticipant(ByVal participant As ChatUserKey)
    Public MustOverride Sub RemoveParticipant(ByVal participant As ChatUserKey)
    Public MustOverride Sub WriteMessage(ByVal message As ChatMessage)

End Class
