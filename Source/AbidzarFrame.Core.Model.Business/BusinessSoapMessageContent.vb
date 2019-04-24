Imports System.ServiceModel
Imports System.Runtime.Serialization

<MessageContract()> _
Public Class BusinessSoapMessageContent
    Inherits BusinessMessageContent

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal languageCode As String, ByVal message As String)
        MyBase.New(languageCode, message)
    End Sub

    <MessageHeader()> _
    Public Overrides Property LanguageCode As String
        Get
            Return MyBase.LanguageCode
        End Get
        Set(ByVal value As String)
            MyBase.LanguageCode = value
        End Set
    End Property

    <MessageHeader()> _
    Public Overrides Property Message As String
        Get
            Return MyBase.Message
        End Get
        Set(ByVal value As String)
            MyBase.Message = value
        End Set
    End Property

End Class
