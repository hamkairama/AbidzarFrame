Public Class ChatMessageKey

    Private _messageId As String

    Private Property MessageId As String
        Get
            Return _messageId
        End Get
        Set(ByVal value As String)
            _messageId = value
        End Set

    End Property

    Public Overrides Function GetHashCode() As Integer
        Return New With {Key .A = _messageId}.GetHashCode()

    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If TypeOf obj Is ChatMessageKey Then
            Return Me.MessageId.Equals(DirectCast(obj, ChatMessageKey).MessageId)
        Else
            Return False
        End If

    End Function

End Class
