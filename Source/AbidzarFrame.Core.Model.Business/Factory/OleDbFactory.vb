Imports System.Data.OleDb
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Data

Public MustInherit Class OleDbFactory
    Inherits GenericOfflineDbFactory
    Implements IOfflineDbConnFactory

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal dbName As String)
        Me.New()
        MyBase.DBName = dbName
    End Sub

    Public Overrides Function CreateConnection() As System.Data.IDbConnection
        Dim credential As IDbCredential = ReadCredential()
        Dim conn As OleDbConnection
        conn = New OleDbConnection(String.Format(credential.ConnectionString, credential.UserId, IIf(IsNothing(MyBase.DBPassword), credential.Password, MyBase.DBPassword)))
        conn.Open()
        Return conn
    End Function

    Public Overrides Function CreateCommand(ByRef conn As System.Data.IDbConnection, _
                                  ByVal commandType As System.Data.CommandType,
                                  ByVal command As String, _
                                  ByVal ParamArray parameters As Object()) _
                              As System.Data.IDbCommand
        Dim cmd As OleDbCommand = conn.CreateCommand()
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
        Return New OleDbParameter(fieldName, value)
    End Function

    Public Overrides Function CreateOutputParameter(ByVal fieldName As String, ByVal dataType As Object, ByVal size As Integer, _
                                                    ByRef variable As IDataParameter) As System.Data.IDataParameter
        Dim para As IDataParameter = Nothing

        Dim t = CType(dataType, OleDbType)
        If t = OleDb.OleDbType.VarChar Then
            size = IIf(size = -1, 1024, size)
            para = New OleDbParameter(fieldName, CType(dataType, OleDbType), size) With {.Direction = ParameterDirection.Output}
        Else
            para = New OleDbParameter(fieldName, CType(dataType, OleDbType)) With {.Direction = ParameterDirection.Output}
        End If

        variable = para
        Return para
    End Function

    Public Overrides Function OpenDataTable(ByRef command As IDbCommand) As DataTable
        Dim table As New DataTable
        Dim dataAdaptor As OleDbDataAdapter = New OleDbDataAdapter(command)
        dataAdaptor.Fill(table)
        Return table
    End Function

    Public Sub ChangeDBPassword(ByVal dbName As String, ByVal oldPassword As String, ByVal newPassword As String) Implements IOfflineDbConnFactory.ChangeDBPassword
        'to be implement
    End Sub

    Public Sub CreateDB(ByVal dbName As String, Optional ByVal password As String = Nothing) Implements IOfflineDbConnFactory.CreateDB
        'to be implement
    End Sub

    Public Sub CopyDB(ByVal fromDBName As String, ByVal toDBName As String) Implements IOfflineDbConnFactory.CopyDB
        'to be implement
    End Sub

    Public Sub DeleteDB(ByVal dbName As String) Implements IOfflineDbConnFactory.DeleteDB
        'to be implement
    End Sub

    Public Function IsDBExist(ByVal dbName As String) As Boolean Implements IOfflineDbConnFactory.IsDBExist
        Dim result As Boolean = True
        Try
            'to be implement
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Public Function TestDBConnection(ByVal dbName As String, Optional ByVal password As String = Nothing) As Boolean Implements IOfflineDbConnFactory.TestDBConnection
        Dim result As Boolean = True
        Try
            'to be implement
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Public Overridable Function GetDBFullPath(ByVal relativePath As String) As String Implements IOfflineDbConnFactory.GetDBFullPath
        'Return CurDir.Substring(0, InStr(CurDir, BusinessModelSetting.GetInstance().Parameters(BusinessModelSetting.OFFLINE_SPIS_INSTALLATION_PATH)) - 1) & relativePath
        Return CurDir.Substring(0, Path.Combine(CurDir, relativePath))
    End Function
End Class
