Imports System.IO

Public Class ZipItem
    Implements IDisposable

    Private _name As String
    Private _data As Stream
    Private _time As DateTime
    Private _autoClose As Boolean

    Public Sub New(ByVal name As String, ByRef data As Stream)
        Me.New(name, data, True, Now)

    End Sub

    Public Sub New(ByVal name As String, ByRef data As Stream, ByVal autoClose As Boolean)
        Me.New(name, data, autoClose, Now)
    End Sub

    Public Sub New(ByVal name As String, ByRef data As Stream, ByVal autoClose As Boolean, ByVal time As DateTime)
        Me._name = name
        Me._data = data
        Me._time = time
    End Sub

    Public Property Name As String
        Get
            Return Me._name
        End Get
        Set(ByVal value As String)
            Me._name = value
        End Set
    End Property

    Public Property Data As Stream
        Get
            Return Me._data
        End Get
        Set(ByVal value As Stream)
            _data = value
        End Set
    End Property

    Public Property CreateTime As DateTime
        Get
            Return _time
        End Get
        Set(ByVal value As DateTime)
            _time = value
        End Set
    End Property

    Public Property AutoClose As Boolean
        Get
            Return _autoClose
        End Get
        Set(ByVal value As Boolean)
            _autoClose = value
        End Set
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

            Try
                If _data IsNot Nothing Then
                    _data.Close()
                End If
            Catch
            End Try

            Try
                If _data IsNot Nothing Then
                    _data.Dispose()
                End If
            Catch
            End Try

            _name = Nothing
            _data = Nothing
            _time = Nothing
            _autoClose = Nothing
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
