Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.Collections.Generic

<KnownType(GetType(BusinessSoapMessageContent))> _
<KnownType(GetType(BusinessMessageContent))> _
<MessageContract()> _
Public Class BusinessSoapErrorVo

    Public Shared ReadOnly DEFAULT_LANGUAGE = "en"

    Protected _errorCode As String = Nothing
    Protected _errorFieldName As String = Nothing
    Protected _messages As Dictionary(Of String, String) = Nothing

    Public Sub New()
        Me.New(Nothing, Nothing)
    End Sub

    Public Sub New(ByVal errorCode As String, ByVal errorFieldName As String,
                   ByVal errorMessage As String)
        Me.New(errorCode, errorFieldName, New BusinessSoapMessageContent(DEFAULT_LANGUAGE, errorMessage))
    End Sub

    Public Sub New(ByVal errorCode As String, ByVal errorFieldName As String,
                   ByVal ParamArray errorMessages As BusinessSoapMessageContent())
        Me._messages = New Dictionary(Of String, String)
        Me._errorCode = errorCode
        Me._errorFieldName = errorFieldName
        If errorMessages IsNot Nothing Then
            For Each _err In errorMessages
                _messages.Add(_err.LanguageCode, _err.Message)
            Next
        End If
    End Sub

    Public Sub New(ByVal err As BusinessErrorVo)
        Me._errorCode = err.ErrorCode
        Me._errorFieldName = err.ErrorField

        Me._messages = New Dictionary(Of String, String)
        If err.ErrorMessages IsNot Nothing Then
            For Each e In err.ErrorMessages
                Me._messages.Add(e.Key, e.Value)
            Next
        End If
    End Sub

    <MessageHeader()> _
    Public Overridable Property ErrorCode As String
        Get
            Return _errorCode
        End Get
        Set(ByVal value As String)
            _errorCode = value
        End Set
    End Property

    <MessageHeader()> _
    Public Overridable Property ErrorField As String
        Get
            Return _errorFieldName
        End Get
        Set(ByVal value As String)
            Me._errorFieldName = value
        End Set
    End Property

    <MessageHeader()> _
    Public Overridable Property LocalizedErrors As List(Of BusinessSoapMessageContent)
        Get
            Dim _list As New List(Of BusinessSoapMessageContent)
            For Each key In _messages.Keys
                _list.Add(New BusinessSoapMessageContent(key, _messages(key)))
            Next
            Return _list
        End Get
        Set(ByVal value As List(Of BusinessSoapMessageContent))
            _messages.Clear()
            For Each msg In value
                _messages.Add(msg.LanguageCode, msg.Message)
            Next
        End Set
    End Property

    Public Overridable Property ErrorMessage As String
        Get
            Return _messages.Values.First()
        End Get
        Set(ByVal value As String)
            _messages(_messages.Keys.First()) = value
        End Set
    End Property

    Public Overridable Property ErrorMessages As Dictionary(Of String, String)
        Get
            Return _messages
        End Get
        Set(ByVal value As Dictionary(Of String, String))
            _messages = value
        End Set
    End Property

    Public Overridable ReadOnly Property ErrorString As List(Of String)
        Get
            Return ErrorsString.Values.First()
        End Get
    End Property

    Public Overridable ReadOnly Property ErrorsString As Dictionary(Of String, List(Of String))
        Get
            Dim _errors As New Dictionary(Of String, List(Of String))
            For Each _key In _messages.Keys
                Dim _l As New List(Of String)
                _l.Add(_errorCode)
                _l.Add(_errorFieldName)
                _l.Add(_messages(_key))
                _errors.Add(_key, _l)
            Next
            Return _errors
        End Get
    End Property

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If TypeOf obj Is BusinessSoapErrorVo Then
            Return Me.ErrorCode.Equals(CType(obj, BusinessSoapErrorVo).ErrorCode)
        Else
            Return False
        End If
    End Function

    Public Function ToBusinessErrorVo() As BusinessErrorVo
        Return New BusinessErrorVo With {.ErrorCode = Me.ErrorCode, _
                                         .ErrorField = Me.ErrorField, _
                                         .ErrorMessage = Me.ErrorMessage, _
                                         .ErrorMessages = Me.ErrorMessages, _
                                         .LocalizedErrors = Me.ToBusinessLocalizedErrors() _
                                        }
    End Function

    Private Function ToBusinessLocalizedErrors() As List(Of BusinessMessageContent)
        If Me.LocalizedErrors Is Nothing Then
            Return Nothing
        End If

        Dim b As New List(Of BusinessMessageContent)

        For Each s In Me.LocalizedErrors
            b.Add(New BusinessMessageContent With {.LanguageCode = s.LanguageCode, .Message = s.Message})
        Next
        Return b
    End Function

End Class
