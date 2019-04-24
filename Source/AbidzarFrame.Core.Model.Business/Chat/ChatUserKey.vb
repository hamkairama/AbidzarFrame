Public Class ChatUserKey

    Private _chatUserId As String

    Public Property ChatUserId As String
        Get
            Return _chatUserId
        End Get
        Set(ByVal value As String)
            _chatUserId = value
        End Set
    End Property

    Public Overrides Function GetHashCode() As Integer
        Return New With {Key .A = _chatUserId}.GetHashCode()
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If TypeOf obj Is ChatUserKey Then
            Return _chatUserId.Equals(DirectCast(obj, ChatUserKey).ChatUserId)
        Else
            Return False
        End If
    End Function

End Class
