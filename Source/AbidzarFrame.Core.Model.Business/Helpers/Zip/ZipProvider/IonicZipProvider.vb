Imports Ionic.Zip
Imports System.IO
Imports Manulife.Core.Model.Business

Public Class IonicZipProvider
    Inherits ZipProviderBase

    Private _zipFile As ZipFile
    
    Public Overrides Sub Initialize(ByRef input As Stream, Optional ByVal password As String = Nothing)
        _zipFile = ZipFile.Read(input)
    End Sub

    Public Overrides Function ExtractAll(ByRef items As List(Of ZipItem)) As BusinessErrors
        Dim _err As New BusinessErrors

        items = New List(Of ZipItem)
        For Each entry In _zipFile
            Dim _name As String = entry.FileName
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
            Dim query As IEnumerable(Of ZipEntry) = _zipFile.Where(Function(entry) entry.FileName.Equals(itemName))

            If query.Count > 0 Then
                Dim entry As ZipEntry = query.First
                item = New ZipItem(entry.FileName, Nothing, False, entry.CreationTime)
                item.Data = New MemoryStream
                entry.Extract(item.Data)
            Else
                item = Nothing
            End If
        Catch ex As Exception
            Core.Model.Business.Utils.FillErrors(err, ex)

        End Try
        Return err

    End Function

    Public Overrides Sub Close()
        Try
            If _zipFile IsNot Nothing Then
                _zipFile.Dispose()
            End If
        Catch ex As Exception
            'DO Nothing
        End Try
    End Sub

End Class

