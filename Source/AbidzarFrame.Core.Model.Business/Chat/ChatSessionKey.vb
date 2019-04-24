Public Class ChatSessionKey

    Private _sessionId As String

    Public Property SessionId As String
        Get
            Return _sessionId
        End Get
        Set(ByVal value As String)
            _sessionId = value
        End Set
    End Property

    Public Overrides Function GetHashCode() As Integer
        Return New With {Key .A = _sessionId}.GetHashCode()
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If TypeOf obj Is ChatSessionKey Then
            Return _sessionId.Equals(DirectCast(obj, ChatSessionKey).SessionId)
        Else
            Return False
        End If
    End Function

End Class
