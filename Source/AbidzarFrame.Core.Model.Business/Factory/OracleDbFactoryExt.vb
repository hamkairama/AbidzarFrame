Imports Manulife.Core.Model.Business
Imports Oracle.DataAccess.Client

Public MustInherit Class OracleDbFactoryExt
    Inherits OracleDbFactory
    Implements IDbConnFactoryExt

    Public Shadows Function CreateCommand(ByRef conn As System.Data.IDbConnection, _
                                  ByVal commandType As System.Data.CommandType,
                                  ByVal command As String, _
                                  ByVal ParamArray parameters As Object()) As System.Data.IDbCommand
        Dim cmd As OracleCommand = conn.CreateCommand()
        cmd.CommandType = commandType
        cmd.CommandText = TransformSql(command)
        For i = 0 To parameters.Count - 1
            Dim p As OracleParameter = Nothing
            If (parameters(i) Is Nothing) Then
                p = New OracleParameter("p" & i, DBNull.Value)
            Else
                If TypeOf parameters(i) Is OracleParameter Then
                    p = parameters(i)
                Else
                    p = New OracleParameter("p" & i, parameters(i))
                End If
            End If
            cmd.Parameters.Add(p)
        Next
        Return cmd
    End Function

    Public Overloads Function CreateInputParameter(ByVal fieldName As String, ByVal udtTypeName As String, ByVal value As Object) As System.Data.IDataParameter Implements IDbConnFactoryExt.CreateInputParameter
        Dim para As OracleParameter = New OracleParameter With {.OracleDbType = OracleDbType.Array, _
                                                                .ParameterName = fieldName, _
                                                                .UdtTypeName = udtTypeName, _
                                                                .Value = value}
        Return para
    End Function
End Class
