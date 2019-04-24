Public MustInherit Class ChatServiceBase

    Public Const CHAT_SESSIONS = "__CHAT_SESSION"
    Public Const CHAT_SLEEP_INTERVAL = 1000

    Public MustOverride Function NewChatSession(ByVal creator As ChatUserKey, ByVal participant As ChatUserKey) As ChatSession

End Class
