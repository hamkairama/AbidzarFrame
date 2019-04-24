Imports System.Runtime.Serialization
Imports System.ServiceModel

<MessageContract()> _
Public Class BusinessSoapErrors
    Private _errorList As List(Of BusinessSoapErrorVo) = Nothing

    Public Sub New()
        _errorList = New List(Of BusinessSoapErrorVo)()
    End Sub

    Public Sub New(ByVal errs As BusinessErrors)
        Me.New()
        Add(errs)
    End Sub

    Public Sub Clear()
        _errorList.Clear()
    End Sub

    Public Overridable Sub Add(ByVal errs As BusinessErrors)
        For Each e In errs.ErrorList
            Add(e)
        Next
    End Sub

    Public Overridable Sub Add(ByVal errs As BusinessSoapErrors)
        For Each e In errs.ErrorList
            Add(e)
        Next
    End Sub

    Public Overridable Sub Add(ByVal err As BusinessErrorVo)
        _errorList.Add(New BusinessSoapErrorVo(err))
    End Sub

    Public Overridable Sub Add(ByVal err As BusinessSoapErrorVo)
        _errorList.Add(err)
    End Sub

    <MessageHeader()> _
    Public Overridable ReadOnly Property HasError As Boolean
        Get
            Return (_errorList.Count > 0)
        End Get
    End Property

    <MessageHeader()> _
    Public Overridable ReadOnly Property ErrorList As BusinessSoapErrorVo()
        Get
            Return _errorList.ToArray()
        End Get
    End Property

    Public Function ContainsError(ByVal err As BusinessSoapErrorVo) As Boolean
        For Each e In Me._errorList
            If e.Equals(err) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Overridable ReadOnly Property ErrorListString As List(Of List(Of String))
        Get
            Dim _l As List(Of List(Of String)) = New List(Of List(Of String))
            For Each e In _errorList
                _l.Add(e.ErrorString)
            Next
            Return _l
        End Get
    End Property

    Public Function ToBusinessErros() As BusinessErrors
        If Me.ErrorList Is Nothing Then
            Return Nothing
        End If
        Dim b As New BusinessErrors
        For Each s In Me.ErrorList
            b.Add(s.ToBusinessErrorVo())
        Next
        Return b
    End Function


End Class

