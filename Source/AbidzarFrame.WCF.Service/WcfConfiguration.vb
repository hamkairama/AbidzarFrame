Imports System.Configuration

Public Class WcfConfiguration
    Inherits ConfigurationSection

    Protected Shared instance As WcfConfiguration = Nothing

    Public Shared Function GetInstance() As WcfConfiguration
        If (instance Is Nothing) Then
            instance = CType(ConfigurationManager.GetSection("WcfConfiguration"), WcfConfiguration)
        End If
        Return instance
    End Function

    <ConfigurationProperty("ConfigFilePath", defaultvalue:="")> _
    Public Property ConfigFilePath As String
        Get
            Return Me("ConfigFilePath")
        End Get
        Set(ByVal value As String)
            Me("ConfigFilePath") = value
        End Set
    End Property

End Class
