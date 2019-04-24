Imports System.Runtime.Serialization

<DataContract()> _
<Serializable()> _
<KnownType(GetType(BusinessWarningVo))> _
Public Class BusinessErrors
    Implements IDisposable

    <DataMember(name:="ErrorList")> _
    Private _errorList As List(Of BusinessErrorVo) = Nothing

    Public Sub New()
        _errorList = New List(Of BusinessErrorVo)()
    End Sub

    Public Sub Clear()
        _errorList.Clear()
    End Sub

    Public Sub Add(ByVal errs As BusinessErrors)
        For Each e In errs.ErrorList
            Add(e)
        Next
    End Sub

    Public Overridable Sub Add(ByVal err As BusinessErrorVo)
        _errorList.Add(err)
    End Sub

    Public Overridable ReadOnly Property HasError As Boolean
        Get
            Return (_errorList.Count > 0)
        End Get
    End Property

    Public Overridable ReadOnly Property ErrorList As BusinessErrorVo()
        Get
            Return _errorList.ToArray()
        End Get
    End Property

    Public Function ContainsError(ByVal err As BusinessErrorVo) As Boolean
        For Each e In Me._errorList
            If e.Equals(err) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function RemoveError(ByVal err As BusinessErrorVo) As Integer
        Dim j = 0
        Dim i = 0
        While i < Me._errorList.Count
            If err.Equals(Me._errorList(i)) Then
                Me._errorList.RemoveAt(i)
                j += 1
            Else
                i += 1
            End If
        End While
        Return j
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
            Utils.ClearObject(_errorList)

            _errorList = Nothing
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
