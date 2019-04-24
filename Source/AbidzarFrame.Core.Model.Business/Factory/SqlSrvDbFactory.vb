Imports System.Data.SqlServerCe
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Data
Imports System.Collections.Concurrent
Imports System.Data.SqlClient

Public MustInherit Class SqlSrvDbFactory
    Inherits GenericDbFactory

    Public Overrides Function CreateConnection() As System.Data.IDbConnection
        Dim credential As IDbCredential = ReadCredential()
        Dim conn As SqlConnection
        'conn = New SqlConnection(String.Format(credential.ConnectionString, credential.UserId, credential.Password))
        conn = New SqlConnection(String.Format(credential.ConnectionString, credential.UserId, credential.Password, credential.Database, credential.Datasource))

        conn.Open()

        'connetionString = "Data Source=mlidev20;Initial Catalog=REVAMP_CCM;User ID=adira;Password=adira1234"
        'sCon = New SqlConnection(connetionString)
        'sCon.Open()
        Return conn
    End Function

    Public Overloads Overrides Function CreateCommand(ByRef conn As System.Data.IDbConnection, ByVal commandType As System.Data.CommandType, ByVal command As String, ByVal ParamArray parameters() As Object) As System.Data.IDbCommand
        Dim cmd As SqlCommand = conn.CreateCommand()
        cmd.CommandType = commandType
        cmd.CommandText = TransformSql(command)
        For i = 0 To parameters.Count - 1
            Dim p As SqlParameter = Nothing
            If (parameters(i) Is Nothing) Then
                p = New SqlParameter("p" & i, DBNull.Value)
            Else
                p = New SqlParameter("p" & i, parameters(i))
            End If
            cmd.Parameters.Add(p)
        Next
        Return cmd
    End Function

    Public Function TransformSql(ByVal sql As String)
        Dim out As String = ""
        Dim stmtPhases As String() = sql.Split("?")
        For i = 0 To stmtPhases.Count - 1
            out = out & stmtPhases(i)
            If (i < stmtPhases.Count - 1) Then
                out = out & ":p" & i.ToString()
            End If
        Next
        Return out
    End Function
    Public Overrides Function CreateInputParameter(ByVal fieldName As String, ByVal value As Object) As System.Data.IDataParameter
        Return New SqlParameter(fieldName, value)
    End Function

    Public Overloads Overrides Function CreateOutputParameter(ByVal fieldName As String, ByVal dataType As Object, ByVal size As Integer, ByRef variable As System.Data.IDataParameter) As System.Data.IDataParameter
        Dim para As IDataParameter = Nothing

        Dim t = CType(dataType, SqlDbType)
        If t = SqlDbType.VarChar Then
            size = IIf(size = -1, 1024, size)
            para = New SqlParameter(fieldName, CType(dataType, SqlDbType), size) With {.Direction = ParameterDirection.Output}
        Else
            para = New SqlParameter(fieldName, CType(dataType, SqlDbType)) With {.Direction = ParameterDirection.Output}
        End If

        variable = para
        Return para
    End Function



    Public Overrides Function OpenDataSet(ByRef command As System.Data.IDbCommand) As System.Data.DataSet
        Dim dst As New DataSet
        Dim dataAdaptor As SqlDataAdapter = New SqlDataAdapter(command)
        dataAdaptor.Fill(dst)
        Return dst
    End Function

    Public Overrides Function OpenDataTable(ByRef command As System.Data.IDbCommand) As System.Data.DataTable
        Dim table As New DataTable
        Dim dataAdaptor As SqlDataAdapter = New SqlDataAdapter(command)
        dataAdaptor.Fill(table)
        Return table
    End Function

    Public Overrides Sub SetConnectionSettingPath()

    End Sub
End Class
