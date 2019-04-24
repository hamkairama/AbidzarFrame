Imports System.Runtime.Serialization

<DataContract()> _
<Serializable()> _
Public Class BusinessMessageContent

    <DataMember(name:="LanguageCode")> _
    Protected _languageCode As String = Nothing
    <DataMember(name:="Message")> _
    Protected _message As String = Nothing

    Public Sub New()
        Me.New(Nothing, Nothing)
    End Sub

    Public Sub New(ByVal languageCode As String, ByVal message As String)
        Me._languageCode = languageCode
        Me._message = message
    End Sub

    Public Overridable Property LanguageCode As String
        Get
            Return _languageCode
        End Get
        Set(ByVal value As String)
            _languageCode = value
        End Set
    End Property

    Public Overridable Property Message As String
        Get
            Return _message
        End Get
        Set(ByVal value As String)
            _message = value
        End Set
    End Property

End Class
