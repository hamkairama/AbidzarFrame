Imports System.Runtime.Serialization

<DataContract()> _
<Serializable()> _
Public Class BusinessWarningVo
    Inherits BusinessErrorVo

    Public Sub New(ByVal errorCode As String, ByVal errorFieldName As String,
                   ByVal errorMessage As String)
        Me.New(errorCode, errorFieldName, New BusinessMessageContent(DEFAULT_LANGUAGE, errorMessage))
    End Sub

    Public Sub New(ByVal errorCode As String, ByVal errorFieldName As String,
                   ByVal ParamArray errorMessages As BusinessMessageContent())
        Me._messages = New Dictionary(Of String, String)
        Me._errorCode = errorCode
        Me._errorFieldName = errorFieldName
        If errorMessages IsNot Nothing Then
            For Each _err In errorMessages
                _messages.Add(_err.LanguageCode, _err.Message)
            Next
        End If
    End Sub

End Class
