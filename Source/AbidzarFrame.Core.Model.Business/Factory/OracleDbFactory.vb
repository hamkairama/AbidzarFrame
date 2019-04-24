Imports Oracle.DataAccess.Client
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Data

Public MustInherit Class OracleDbFactory
    Inherits GenericDbFactory

    Public Overrides Function CreateConnection() As System.Data.IDbConnection
        Dim credential As IDbCredential = ReadCredential()
        Dim conn As OracleConnection
        conn = New OracleConnection(String.Format(credential.ConnectionString, credential.UserId, credential.Password))
        conn.Open()
        Return conn
    End Function

    Public Overrides Function CreateCommand(ByRef conn As System.Data.IDbConnection, _
                                  ByVal commandType As System.Data.CommandType,
                                  ByVal command As String, _
                                  ByVal ParamArray parameters As Object()) _
                              As System.Data.IDbCommand
        Dim cmd As OracleCommand = conn.CreateCommand()
        cmd.CommandType = commandType
        cmd.CommandText = TransformSql(command)
        For i = 0 To parameters.Count - 1
            Dim p As OracleParameter = Nothing
            If (parameters(i) Is Nothing) Then
                p = New OracleParameter("p" & i, DBNull.Value)
            Else
                p = New OracleParameter("p" & i, parameters(i))
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

    Private Function GetOracleDataType(ByVal o As Object) As Oracle.DataAccess.Client.OracleDbType
        If TypeOf o Is Integer Then
            Return Oracle.DataAccess.Client.OracleDbType.Int16
        End If
        If TypeOf o Is Long Then
            Return Oracle.DataAccess.Client.OracleDbType.Int64
        End If
        If TypeOf o Is Double Then
            Return Oracle.DataAccess.Client.OracleDbType.Double
        End If
        If TypeOf o Is Decimal Then
            Return Oracle.DataAccess.Client.OracleDbType.Decimal
        End If
        If TypeOf o Is String Then
            Return Oracle.DataAccess.Client.OracleDbType.Varchar2
        End If
        If TypeOf o Is Date Then
            Return Oracle.DataAccess.Client.OracleDbType.Date
        End If
        If TypeOf o Is DateTime Then
            Return Oracle.DataAccess.Client.OracleDbType.Date
        End If
        If TypeOf o Is Boolean Then
            Return Oracle.DataAccess.Client.OracleDbType.Varchar2
        End If
        Return Oracle.DataAccess.Client.OracleDbType.Varchar2
    End Function

    Public Overrides Function CreateInputParameter(ByVal fieldName As String, ByVal value As Object) As System.Data.IDataParameter
        Return New OracleParameter(fieldName, value)
    End Function

    Public Overrides Function CreateOutputParameter(ByVal fieldName As String, ByVal dataType As Object, ByVal size As Integer, _
                                                    ByRef variable As IDataParameter) As System.Data.IDataParameter
        Dim para As IDataParameter = Nothing

        Dim t = CType(dataType, OracleDbType)
        If t = Oracle.DataAccess.Client.OracleDbType.Varchar2 Then
            size = IIf(size = -1, 1024, size)
            para = New OracleParameter(fieldName, CType(dataType, OracleDbType), size) With {.Direction = ParameterDirection.Output}
        Else
            para = New OracleParameter(fieldName, CType(dataType, OracleDbType)) With {.Direction = ParameterDirection.Output}
        End If

        variable = para
        Return para
    End Function

    Public Overrides Function OpenDataTable(ByRef command As IDbCommand) As DataTable
        Dim table As New DataTable
        Dim dataAdaptor As OracleDataAdapter = New OracleDataAdapter(command)
        dataAdaptor.Fill(table)
        Return table
    End Function

End Class
