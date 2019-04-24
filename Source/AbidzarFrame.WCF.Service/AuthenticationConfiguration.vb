Imports System.Configuration

Public Class AuthenticationConfiguration
    Inherits ConfigurationSection

    Protected Shared instance As AuthenticationConfiguration = Nothing

    Public Shared Function GetInstance() As AuthenticationConfiguration
        If (instance Is Nothing) Then
            instance = CType(ConfigurationManager.GetSection("AuthenticationConfiguration"), AuthenticationConfiguration)
        End If
        Return instance
    End Function

    <ConfigurationProperty("Token", DefaultValue:="")>
    Public Property Token As String
        Get
            Return Me("Token")
        End Get
        Set(ByVal value As String)
            Me("Token") = value
        End Set
    End Property

End Class
