Imports System.Data.SqlServerCe
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Data
Imports System.Collections.Concurrent

Public MustInherit Class SqlCeDbFactory
    Inherits GenericOfflineDbFactory
    Implements IOfflineDbConnFactory

    Private _connectionString = "Data Source='{0}'; Max Buffer Size=1024; Max Database Size=2048; Database Password={1}; File Mode=Read Write; Case Sensitive=True;"
    Protected Shared _connPool As New ConcurrentDictionary(Of String, SqlCeConnection)
    Protected _isPool As Boolean = True

    Public Sub New(ByVal dbName As String, Optional ByVal dbPassword As String = Nothing)
        MyBase.New()
        MyBase.DBName = dbName
        MyBase.DBPassword = dbPassword
    End Sub

    Public Overrides Function CreateConnection() As System.Data.IDbConnection
        Dim credential As IDbCredential = ReadCredential()
        Dim conn As SqlCeConnection = Nothing
        Dim connectionName As String = Me.GetType.FullName & "." & MyBase.DBName
        If _isPool Then
            If Not _connPool.TryGetValue(connectionName, conn) Then
                conn = New SqlCeConnection(String.Format(credential.ConnectionString, IIf(IsNothing(MyBase.DBPassword), credential.Password, MyBase.DBPassword)))
                conn.Open()
                _connPool.TryAdd(connectionName, conn)
            End If

            If conn.State <> ConnectionState.Open Then
                CloseConnection(conn)
                conn = New SqlCeConnection(String.Format(credential.ConnectionString, IIf(IsNothing(MyBase.DBPassword), credential.Password, MyBase.DBPassword)))
                conn.Open()
            End If
        Else
            conn = New SqlCeConnection(String.Format(credential.ConnectionString, IIf(IsNothing(MyBase.DBPassword), credential.Password, MyBase.DBPassword)))
            conn.Open()
        End If

        Return conn
    End Function

    Public Overrides Sub CloseConnection(ByRef conn As IDbConnection)
        If Not _isPool Then
            'Close connection if not using pool
            Try
                If conn IsNot Nothing Then
                    conn.Close()
                    conn.Dispose()
                End If
            Catch ex As Exception
                'Do Nothing 

            End Try
        End If
    End Sub

    Public Overrides Function CreateCommand(ByRef conn As System.Data.IDbConnection, _
                                  ByVal commandType As System.Data.CommandType,
                                  ByVal command As String, _
                                  ByVal ParamArray parameters As Object()) _
                              As System.Data.IDbCommand
        Dim cmd As SqlCeCommand = conn.CreateCommand()
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = command
        For i = 0 To parameters.Count - 1
            If (parameters(i) Is Nothing) Then
                cmd.Parameters.AddWithValue(i, DBNull.Value)
            Else
                cmd.Parameters.AddWithValue(i, parameters(i))
            End If
        Next
        Return cmd
    End Function

    Public Overrides Function CreateInputParameter(ByVal fieldName As String, ByVal value As Object) As System.Data.IDataParameter
        Return New SqlCeParameter(fieldName, value)
    End Function

    Public Overrides Function CreateOutputParameter(ByVal fieldName As String, ByVal dataType As Object, ByVal size As Integer, _
                                                    ByRef variable As IDataParameter) As System.Data.IDataParameter
        Dim para As IDataParameter = Nothing
        variable = para
        Return para
    End Function

    Public Overrides Function OpenDataTable(ByRef command As IDbCommand) As DataTable
        Dim table As New DataTable
        Dim dataAdaptor As SqlCeDataAdapter = New SqlCeDataAdapter(command)
        dataAdaptor.Fill(table)
        Return table
    End Function

    Public Sub CreateDB(ByVal dbName As String, Optional ByVal Password As String = Nothing) Implements IOfflineDbConnFactory.CreateDB
        Dim filePath As String = ConnectionSettingPath & dbName & ".sdf"
        Dim dbPassword As String

        If IsNothing(Password) Then
            Dim credential As IDbCredential = ReadCredential()
            dbPassword = credential.Password
        Else
            dbPassword = Password
        End If

        If File.Exists(filePath) Then
            File.Delete(filePath)
        End If

        Dim ceEngine As New SqlCeEngine(String.Format(_connectionString, filePath, dbPassword))
        ceEngine.CreateDatabase()
        ceEngine.Verify()
        ceEngine.Dispose()
    End Sub

    Public Sub CopyDB(ByVal fromDBName As String, ByVal toDBName As String) Implements IOfflineDbConnFactory.CopyDB
        Dim filePath As String = ConnectionSettingPath & fromDBName & ".sdf"
        Dim NewfilePath As String = ConnectionSettingPath & toDBName & ".sdf"

        File.Copy(filePath, NewfilePath, True)
    End Sub

    Sub DeleteDB(ByVal dbName As String) Implements IOfflineDbConnFactory.DeleteDB
        Dim filePath As String = ConnectionSettingPath & dbName & ".sdf"

        File.Delete(filePath)
    End Sub

    Public Sub ChangeDBPassword(ByVal dbName As String, ByVal oldPassword As String, ByVal newPassword As String) Implements IOfflineDbConnFactory.ChangeDBPassword
        Dim filePath As String = ConnectionSettingPath & dbName & ".sdf"
        Dim ceEngine As New SqlCeEngine(String.Format(_connectionString, filePath, oldPassword))

        ceEngine.Compact(Nothing)
        ceEngine.Compact(String.Format(_connectionString, filePath, newPassword))
    End Sub

    Public Function IsDBExist(ByVal dbName As String) As Boolean Implements IOfflineDbConnFactory.IsDBExist
        Dim filePath As String = ConnectionSettingPath & dbName & ".sdf"
        Return File.Exists(filePath)
    End Function

    Public Function TestDBConnection(ByVal dbName As String, Optional ByVal password As String = Nothing) As Boolean Implements IOfflineDbConnFactory.TestDBConnection
        Dim result As Boolean = True
        Dim conn As SqlCeConnection
        Try
            Dim filePath As String = ConnectionSettingPath & dbName & ".sdf"
            conn = New SqlCeConnection(String.Format(_connectionString, filePath, password))
            conn.Open()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Public Function GetDBFullPath(ByVal relativePath As String) As String Implements IOfflineDbConnFactory.GetDBFullPath
        'Return CurDir.Substring(0, InStr(CurDir, BusinessModelSetting.GetInstance().Parameters(BusinessModelSetting.OFFLINE_SPIS_INSTALLATION_PATH)) - 1) & relativePath
        Return Path.Combine(CurDir(), relativePath) & "\"
    End Function
End Class
