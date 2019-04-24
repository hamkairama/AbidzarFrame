Public Class ChatMessage

    Private _messageKey As ChatMessageKey
    Private _chatUser As ChatUserKey
    Private _chatSessionKey As ChatSessionKey
    Private _message As String
    Private _submitTime As Date

    Public Property MessageKey As ChatMessageKey
        Get
            Return _messageKey
        End Get
        Set(ByVal value As ChatMessageKey)
            _messageKey = value
        End Set
    End Property

    Public Property ChatUser As ChatUserKey
        Get
            Return _chatUser
        End Get
        Set(ByVal value As ChatUserKey)
            _chatUser = value
        End Set
    End Property

    Public Property ChatSessionKey As ChatSessionKey
        Get
            Return _chatSessionKey
        End Get
        Set(ByVal value As ChatSessionKey)
            _chatSessionKey = value
        End Set
    End Property

    Public Property Message As String
        Get
            Return _message
        End Get
        Set(ByVal value As String)
            _message = value
        End Set
    End Property

    Public Property SubmitTime As Date
        Get
            Return _submitTime
        End Get
        Set(ByVal value As Date)
            _submitTime = value
        End Set
    End Property

End Class
