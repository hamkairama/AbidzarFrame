Imports System.Data

Public Interface IDbConnFactory

    Function CreateConnection() As IDbConnection

    Function CreateCommand(ByRef conn As IDbConnection, ByVal command As String, ByVal ParamArray parameters As Object()) As IDbCommand

    Function CreateCommand(ByRef conn As IDbConnection, ByVal commandType As System.Data.CommandType, ByVal command As String, ByVal ParamArray parameters As Object()) As IDbCommand

    Function CreateInputParameter(ByVal fieldName As String, ByVal value As Object) As IDataParameter

    Function CreateOutputParameter(ByVal fieldName As String, ByVal dataType As Object, ByRef variable As IDataParameter) As IDataParameter

    Function CreateOutputParameter(ByVal fieldName As String, ByVal dataType As Object, ByVal size As Integer, ByRef variable As IDataParameter) As IDataParameter

    Function OpenDataTable(ByRef command As IDbCommand) As DataTable

    Function OpenDataSet(ByRef command As IDbCommand) As DataSet

    Sub ExecuteTransactions(ByRef connection As IDbConnection, ByRef commandList As List(Of IDbCommand))

    Function ReadCredential() As IDbCredential

    Sub CloseConnection(ByRef conn As IDbConnection)

End Interface
