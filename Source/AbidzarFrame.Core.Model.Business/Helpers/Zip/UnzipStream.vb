Imports ICSharpCode.SharpZipLib.Core
Imports ICSharpCode.SharpZipLib.Zip
Imports System.IO
Imports AbidzarFrame.Core.Model.Business

Public Class UnzipStream
    Implements IDisposable

    Private _zipFile As ZipFile

    Public Sub New(ByRef input As Stream, Optional ByVal password As String = Nothing)
        _zipFile = New ZipFile(input)
        _zipFile.IsStreamOwner = False
        If password IsNot Nothing Then
            _zipFile.Password = password
        End If

    End Sub

    Public Function Extract(ByVal itemName As String, ByRef item As ZipItem) As BusinessErrors
        Dim err As New BusinessErrors
        Try
            Dim entry As ZipEntry = _zipFile.GetEntry(itemName)
            If entry IsNot Nothing Then
                item = New ZipItem(entry.Name, Nothing, False, entry.DateTime)

                Dim s As Stream = _zipFile.GetInputStream(entry)
                Dim d As Stream = New MemoryStream
                StreamUtils.Copy(s, d, New Byte(4096) {})
                d.Position = 0
                item.Data = d
            Else
                item = Nothing
            End If
        Catch ex As Exception
            Core.Model.Business.Utils.FillErrors(err, ex)

        End Try
        Return err

    End Function

    Public Sub Close()
        _zipFile.Close()

    End Sub

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
                If _zipFile IsNot Nothing Then
                    _zipFile.Close()
                End If
            Catch
            End Try

            _zipFile = Nothing
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
