Imports System.IO

Public Class DosHelper

    Public Shared Sub CreateDirectoryExcludeFileName(ByVal fileAndPath As String)
        Directory.CreateDirectory(fileAndPath)
        Directory.Delete(fileAndPath)
    End Sub

End Class
