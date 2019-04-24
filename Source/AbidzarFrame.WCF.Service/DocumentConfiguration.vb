Imports System.Configuration

Public Class DocumentConfiguration
    Inherits ConfigurationSection

    Protected Shared instance As DocumentConfiguration = Nothing

    Public Shared Function GetInstance() As DocumentConfiguration
        If (instance Is Nothing) Then
            instance = CType(ConfigurationManager.GetSection("DocumentConfiguration"), DocumentConfiguration)
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
