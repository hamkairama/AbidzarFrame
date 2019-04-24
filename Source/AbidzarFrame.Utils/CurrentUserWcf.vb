Imports System.Web

Public Class CurrentUserWcf
    Public Shared Function GetCurrentUserId() As String
        Dim result As String = "ApiService"
        'Dim result As String = HttpContext.Current.Session("userIdSession")

        If result IsNot Nothing Then
            Return result
        Else
            Return Nothing
        End If
    End Function

End Class
