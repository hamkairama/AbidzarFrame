Imports AbidzarFrame.Core.Model.Business
Imports System.IO
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.Core

Public Class ZipStream

    Private _zipStream As ZipOutputStream

    Public Sub New(ByRef output As Stream, ByVal compressionLevel As Integer, Optional ByVal password As String = Nothing)
        If compressionLevel < 0 Or compressionLevel > 9 Then
            compressionLevel = 0
        End If

        _zipStream = New ZipOutputStream(output)
        _zipStream.SetLevel(compressionLevel)
        _zipStream.IsStreamOwner = False
        If password IsNot Nothing Then
            _zipStream.Password = password
        End If

    End Sub

    Public Function Append(ByVal items As List(Of ZipItem)) As BusinessErrors
        Dim err As New BusinessErrors
        For Each item In items
            err.Add(Append(item))
        Next
        Return err
    End Function

    Public Function Append(ByVal item As ZipItem) As BusinessErrors
        Dim err As New BusinessErrors
        Try
            Dim zipEntry As New ZipEntry(item.Name)
            zipEntry.DateTime = item.CreateTime

            _zipStream.PutNextEntry(zipEntry)
            StreamUtils.Copy(item.Data, _zipStream, New Byte(4096) {})
            _zipStream.CloseEntry()

            If item.AutoClose Then
                item.Data.Close()
            End If

        Catch ex As Exception
            Core.Model.Business.Utils.FillErrors(err, ex)
        End Try
        Return err

    End Function

    Public Sub Close()
        _zipStream.Close()
    End Sub

End Class
