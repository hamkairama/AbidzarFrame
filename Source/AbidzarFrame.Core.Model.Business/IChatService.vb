Public Interface IChatService

    Function CreateSession(ByVal openUser As ChatUserKey, ByVal targetUser As ChatUserKey, _
                        ByVal isGroup As Boolean, ByRef success As Boolean, _
                        ByRef chatSessionKey As ChatSessionKey) As BusinessErrors

    Function Write(ByVal message As ChatMessage) As BusinessErrors

    Function IsUpdated(ByVal user As ChatUserKey, ByVal chatSession As ChatSessionKey, _
                       ByRef isUpdate As Boolean, ByRef message As List(Of ChatMessage)) As BusinessErrors

    Function TerminateSession(ByVal user As ChatUserKey, ByVal chatSession As ChatSessionKey) As BusinessErrors

    Function JoinSession(ByVal user As ChatUserKey, ByVal chatSession As ChatSessionKey) As BusinessErrors

End Interface
