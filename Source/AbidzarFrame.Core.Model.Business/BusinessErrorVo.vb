Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports System.Xml.Serialization
Imports System.Xml

<DataContract()> _
<Serializable()> _
<KnownType(GetType(BusinessMessageContent))> _
Public Class BusinessErrorVo
    Implements IDisposable

    <DataMember(name:="DEFAULT_LANGUAGE")> _
    Public Shared ReadOnly DEFAULT_LANGUAGE = "en"

    <DataMember(name:="ErrorCode")> _
    Protected _errorCode As String = Nothing
    <DataMember(name:="ErrorField")> _
    Protected _errorFieldName As String = Nothing
    <DataMember(name:="ErrorMessages")> _
    Protected _messages As Dictionary(Of String, String) = Nothing

    Public Sub New()
        Me.New(Nothing, Nothing)
    End Sub

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

    Public Overridable Property ErrorCode As String
        Get
            Return _errorCode
        End Get
        Set(ByVal value As String)
            _errorCode = value
        End Set
    End Property

    Public Overridable Property ErrorField As String
        Get
            Return _errorFieldName
        End Get
        Set(ByVal value As String)
            Me._errorFieldName = value
        End Set
    End Property

    Public Overridable Property LocalizedErrors As List(Of BusinessMessageContent)
        Get
            Dim _list As New List(Of BusinessMessageContent)
            For Each key In _messages.Keys
                _list.Add(New BusinessMessageContent(key, _messages(key)))
            Next
            Return _list
        End Get
        Set(ByVal value As List(Of BusinessMessageContent))
            _messages.Clear()
            For Each msg In value
                _messages.Add(msg.LanguageCode, msg.Message)
            Next
        End Set
    End Property

    Public Overridable Property ErrorMessage As String
        Get
            If _messages.Count > 0 Then
                Return _messages.Values.First()
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As String)
            If _messages.Count > 0 Then
                _messages(_messages.Keys.First()) = value
            Else
                _messages.Add(DEFAULT_LANGUAGE, value)
            End If
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
        If TypeOf obj Is BusinessErrorVo Then
            Return Me.ErrorCode.Equals(CType(obj, BusinessErrorVo).ErrorCode)
        Else
            Return False
        End If
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
            Utils.ClearObject(_messages)

            _messages = Nothing
            _errorCode = Nothing
            _errorFieldName = Nothing
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(False)
        MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
