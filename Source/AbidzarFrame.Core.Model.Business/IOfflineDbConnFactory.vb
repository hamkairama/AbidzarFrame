Public Interface IOfflineDbConnFactory
    Inherits IDbConnFactory

    Sub CreateDB(ByVal dbName As String, Optional ByVal password As String = Nothing)

    Sub ChangeDBPassword(ByVal dbName As String, ByVal oldPassword As String, ByVal newPassword As String)

    Sub CopyDB(ByVal fromDBName As String, ByVal toDBName As String)

    Sub DeleteDB(ByVal dbName As String)

    Function IsDBExist(ByVal dbName As String) As Boolean

    Function TestDBConnection(ByVal dbName As String, Optional ByVal password As String = Nothing) As Boolean

    Function GetDBFullPath(ByVal relativePath As String) As String
End Interface
