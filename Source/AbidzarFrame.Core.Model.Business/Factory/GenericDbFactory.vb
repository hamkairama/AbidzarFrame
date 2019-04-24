Imports Oracle.DataAccess.Client
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Data
Imports System.Collections.Concurrent
Imports System.Web

Public MustInherit Class GenericDbFactory
    Implements IDbConnFactory

    Private _settingPath As String = Nothing

    Public MustOverride Sub SetConnectionSettingPath()

    Public MustOverride Function DefaultCredential() As IDbCredential

    Public MustOverride Function CreateConnection() As System.Data.IDbConnection Implements IDbConnFactory.CreateConnection

    Public MustOverride Function CreateCommand(ByRef conn As System.Data.IDbConnection,
                                  ByVal commandType As System.Data.CommandType,
                                  ByVal command As String,
                                  ByVal ParamArray parameters As Object()) _
                              As System.Data.IDbCommand Implements IDbConnFactory.CreateCommand

    Public MustOverride Function CreateInputParameter(ByVal fieldName As String, ByVal value As Object) As System.Data.IDataParameter Implements IDbConnFactory.CreateInputParameter

    Public MustOverride Function CreateOutputParameter(ByVal fieldName As String, ByVal dataType As Object, ByVal size As Integer,
                                                       ByRef variable As IDataParameter) As IDataParameter Implements IDbConnFactory.CreateOutputParameter

    Public MustOverride Function OpenDataTable(ByRef command As IDbCommand) As DataTable Implements IDbConnFactory.OpenDataTable

    Public MustOverride Function OpenDataSet(ByRef command As IDbCommand) As DataSet Implements IDbConnFactory.OpenDataSet

    Public Sub New()
        SetConnectionSettingPath()
    End Sub

    Protected Property ConnectionSettingPath As String
        Get
            Return _settingPath
        End Get
        Set(ByVal value As String)
            _settingPath = value
        End Set
    End Property

    Public Function CreateOutputParameter(ByVal fieldName As String, ByVal dataType As Object,
                                          ByRef variable As IDataParameter) As IDataParameter Implements IDbConnFactory.CreateOutputParameter
        Return CreateOutputParameter(fieldName, dataType, -1, variable)
    End Function

    Protected Overridable Function fileName() As String
        Dim Name As String = Me.GetType().ToString() & ".xml"
        Return Name
    End Function

    Dim _DbCredentialDict As New ConcurrentDictionary(Of String, IDbCredential)

    Private Function ReplacePath(path As String) As String
        Dim NewPath = path.Replace("AbidzarFrame.WCF.Service\", "AppSetting\Db\")

        Return NewPath
    End Function

    Private Function ConcatPath(path As String) As String
        Dim NewPath = path + "AppSetting\Db\"

        Return NewPath
    End Function

    Protected Function ReadCredential() As IDbCredential Implements IDbConnFactory.ReadCredential
        Dim setting As DbCredential = Nothing

        If Not _DbCredentialDict.TryGetValue(fileName(), setting) Then
            If _settingPath = "...\Db\" Then
                Dim path As String = HttpRuntime.AppDomainAppPath
                _settingPath = ConcatPath(path)
            End If

            If Not File.Exists(_settingPath & fileName()) Then
                setting = DefaultCredential()

                Try
                    Directory.CreateDirectory(_settingPath)
                Catch e As Exception
                    'Do nothing

                End Try
                WriteDbCredential(setting, _settingPath & fileName())
            Else
                Dim encryptedSetting As EncryptedDbCredential = Nothing
                encryptedSetting = RetrieveDbCredential(Of EncryptedDbCredential)(_settingPath & fileName())

                If encryptedSetting Is Nothing Then
                    'Credential is not encrypted, encryption is started now
                    Dim originalSetting As DbCredential = RetrieveDbCredential(Of DbCredential)(_settingPath & fileName())

                    encryptedSetting = New EncryptedDbCredential(originalSetting)
                    WriteDbCredential(encryptedSetting, _settingPath & fileName())
                End If

                setting = encryptedSetting.DecryptedDbCredential()
            End If

            _DbCredentialDict.AddOrUpdate(fileName(), setting, Function(key, oldValue) setting)
        End If

        Return setting
    End Function

    'Protected Function ReadCredential() As IDbCredential Implements IDbConnFactory.ReadCredential
    '    Dim setting As DbCredential = Nothing

    '    If Not File.Exists(_settingPath & fileName()) Then
    '        setting = DefaultCredential()

    '        Try
    '            Directory.CreateDirectory(_settingPath)
    '        Catch e As Exception
    '            Do nothing
    '        End Try
    '        WriteDbCredential(setting, _settingPath & fileName())
    '    Else
    '        Dim encryptedSetting As EncryptedDbCredential = Nothing
    '        encryptedSetting = RetrieveDbCredential(Of EncryptedDbCredential)(_settingPath & fileName())

    '        If encryptedSetting Is Nothing Then
    '            Credential is not encrypted, encryption is started now
    '            Dim originalSetting As DbCredential = RetrieveDbCredential(Of DbCredential)(_settingPath & fileName())

    '            encryptedSetting = New EncryptedDbCredential(originalSetting)
    '            WriteDbCredential(encryptedSetting, _settingPath & fileName())
    '        End If

    '        setting = encryptedSetting.DecryptedDbCredential()
    '    End If

    '    Return setting
    'End Function

    Protected Overridable Function RetrieveDbCredential(Of T)(ByVal filePath As String) As T

        Dim output As FileStream = Nothing
        Dim setting As T = Nothing
        Try
            output = New FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(T))
            setting = CType(serializer.Deserialize(output), T)
        Catch e As Exception
            setting = Nothing
        Finally
            If output IsNot Nothing Then
                output.Close()
            End If
        End Try
        Return setting
    End Function

    Protected Overridable Sub WriteDbCredential(ByVal credential As DbCredential, ByVal filePath As String)
        Dim output As FileStream = Nothing
        Try
            output = New FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
            Dim serializer As XmlSerializer = New XmlSerializer(credential.GetType())
            serializer.Serialize(output, credential)
        Catch e As Exception

        Finally
            If output IsNot Nothing Then
                output.Close()
            End If
        End Try
    End Sub

    Public Function CreateCommand(ByRef conn As System.Data.IDbConnection,
                                  ByVal command As String,
                                  ByVal ParamArray parameters As Object()) _
                              As System.Data.IDbCommand Implements IDbConnFactory.CreateCommand
        Return CreateCommand(conn, System.Data.CommandType.Text, command, parameters)
    End Function

    Public Sub ExecuteTransactions(ByRef connection As IDbConnection, ByRef commandList As List(Of System.Data.IDbCommand)) _
        Implements IDbConnFactory.ExecuteTransactions

        Dim transaction As IDbTransaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
        Try
            For Each _cmd In commandList
                _cmd.Transaction = transaction
                _cmd.ExecuteNonQuery()
            Next
            transaction.Commit()

        Catch ex As Exception
            transaction.Rollback()
            Throw ex
        Finally

        End Try
    End Sub

    Public Overridable Sub CloseConnection(ByRef conn As System.Data.IDbConnection) Implements IDbConnFactory.CloseConnection
        Try
            If conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
