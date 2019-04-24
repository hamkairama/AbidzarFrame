Imports System.Configuration

Public Class LogConfiguration
    Inherits ConfigurationSection

    Protected Shared instance As LogConfiguration = Nothing

    Public Shared Function GetInstance() As LogConfiguration
        If (instance Is Nothing) Then
            instance = CType(ConfigurationManager.GetSection("LogConfiguration"), LogConfiguration)
        End If
        Return instance
    End Function

    <ConfigurationProperty("ConfigFilePath", DefaultValue:="")>
    Public Property ConfigFilePath As String
        Get
            Return Me("ConfigFilePath")
        End Get
        Set(ByVal value As String)
            Me("ConfigFilePath") = value
        End Set
    End Property

End Class
