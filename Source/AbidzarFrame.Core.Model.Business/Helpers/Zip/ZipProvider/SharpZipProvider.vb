Imports ICSharpCode.SharpZipLib.Core
Imports ICSharpCode.SharpZipLib.Zip
Imports System.IO
Imports Manulife.Core.Model.Business

Public Class SharpZipProvider
    Inherits ZipProviderBase

    Private _zipFile As ZipFile

    Public Overrides Sub Initialize(ByRef input As Stream, Optional ByVal password As String = Nothing)
        _zipFile = New ZipFile(input)
        _zipFile.IsStreamOwner = False
        If password IsNot Nothing Then
            _zipFile.Password = password
        End If

    End Sub

    Public Overrides Function ExtractAll(ByRef items As List(Of ZipItem)) As BusinessErrors
        Dim _err As New BusinessErrors

        items = New List(Of ZipItem)
        For i = 0 To _zipFile.Count - 1
            Dim _name As String = _zipFile.EntryByIndex(i).Name
            Dim _zipItem As ZipItem = Nothing
            _err.Add(Extract(_name, _zipItem))
            If _err.HasError Then
                Exit For
            Else
                items.Add(_zipItem)
            End If
        Next

        Return _err

    End Function

    Public Overrides Function Extract(ByVal itemName As String, ByRef item As ZipItem) As BusinessErrors
        Dim err As New BusinessErrors
        Try
            Dim entry As ZipEntry = _zipFile.GetEntry(itemName)
            If entry IsNot Nothing And Not entry.IsDirectory Then
                item = New ZipItem(entry.Name, Nothing, False, entry.DateTime)

                Dim s As Stream = _zipFile.GetInputStream(0)
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

    Public Overrides Sub Close()
        _zipFile.Close()
    End Sub

End Class

