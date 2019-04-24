Imports System.IO

Public MustInherit Class MsAccessDbFactory
    Inherits OleDbFactory

    Public Sub New(ByVal dbName As String)
        MyBase.New(dbName)
    End Sub

    Public Overrides Function GetDBFullPath(ByVal relativePath As String) As String
        Return Path.Combine(CurDir(), relativePath) & "\"
    End Function

    Public MustOverride Overrides Function DefaultCredential() As IDbCredential
    Public MustOverride Overrides Sub SetConnectionSettingPath()

End Class
