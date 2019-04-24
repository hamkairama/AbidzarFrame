Imports System.Data.SqlClient
Imports System.IO
Imports AbidzarFrame.Core.Model.Business
Imports AbidzarFrame.Core.Mvc.Helpers

Public Class FunctionLog
#Region "private variable"
    Private userId As String = "Unauthenticated User"
    Private sessionId As String = "Undefined_Session_Id"
    'Private _user = Utility.currentUser
    Private _user = CurrentUserWcf.GetCurrentUserId

#End Region

    Public Sub WriteFunctionException(ByVal serviceName As String, ByVal functionName As String, ByVal level As Integer, ByRef ex As Exception, ByVal contract As Object, ByVal contractType As Type)
        Dim userData As String = ""
        If (contractType Is GetType(String)) Then
            userData = contract
        Else
            userData = DataContractHelper.ContractToString(contract, contractType)
        End If

        If Not _user Is Nothing Then
            userId = _user
        End If

        Dim msg As String = ex.Message + "||" + ex.Data.ToString + "||" + ex.StackTrace + "||" + ex.Source + "||"
        Dim _log As LogData = New LogData(LogData.STAGE.error, serviceName, functionName, "", userId, System.DateTime.Now, "", msg, userData)
        Logger.GetInstance().WriteLogData(_log, level, LogData.LOG_TYPE.data)
    End Sub

    ' Tyo : constructor untuk sql exception
    Public Sub WriteFunctionException(ByVal serviceName As String, ByVal functionName As String, ByVal level As Integer, ByRef ex As SqlException, ByVal contract As Object, ByVal contractType As Type)
        Dim userData As String = ""
        If (contractType Is GetType(String)) Then
            userData = contract
        Else
            userData = DataContractHelper.ContractToString(contract, contractType)
        End If

        If Not _user Is Nothing Then
            userId = _user
        End If

        Dim sqlCode As String = "SQL" & ex.Number
        Dim errHand = New ErrorHandler
        'Dim msg As String = errHand.GetErrorMessage(ErrorHandler._ERRKEY_ABIDZARFRAME, sqlCode)
        'If String.IsNullOrWhiteSpace(msg) Then
        '    msg = ex.Message
        'End If

        Dim msg As String = ex.Message + "||" + ex.Data.ToString + "||" + ex.StackTrace + "||" + ex.Source + "||" + sqlCode + "||"
        Dim _log As LogData = New LogData(LogData.STAGE.error, serviceName, functionName, "", userId, System.DateTime.Now, "", msg, userData)
        Logger.GetInstance().WriteLogData(_log, level, LogData.LOG_TYPE.data)
    End Sub

    Public Sub WriteFunctionDebug(ByVal serviceName As String, ByVal functionName As String, ByVal level As Integer, ByRef msg As String, ByVal contract As Object, ByVal contractType As Type)
        Dim userData As String = ""
        If (contractType Is GetType(String)) Then
            userData = contract
        Else
            userData = DataContractHelper.ContractToString(contract, contractType)
        End If

        If Not _user Is Nothing Then
            userId = _user
        End If

        Dim _log As LogData = New LogData(LogData.STAGE.error, serviceName, functionName, "", userId, System.DateTime.Now, "", msg, userData)
        Logger.GetInstance().WriteLogData(_log, level, LogData.LOG_TYPE.data)
    End Sub

    Public Sub WriteFunctionLog(ByVal serviceName As String, ByVal functionName As String, ByVal level As Integer, ByVal logType As LogData.LOG_TYPE)
        If Not _user Is Nothing Then
            userId = _user
        End If

        Dim _log As LogData = New LogData(LogData.STAGE.api, serviceName, functionName, "", userId, System.DateTime.Now, "", "", "")
        Logger.GetInstance().WriteLogData(_log, 1, logType)
    End Sub

    Public Sub WriteFunctionAuthentication(ByVal serviceName As String, ByVal functionName As String, ByVal level As Integer, ByVal logType As LogData.STAGE, ByVal msg As BusinessErrorVo)
        If Not _user Is Nothing Then
            userId = _user
        End If

        Dim _log As LogData = New LogData(LogData.STAGE.controller, serviceName, functionName, "", userId, System.DateTime.Now, "", msg.ErrorMessage, "")
        Logger.GetInstance().WriteLogData(_log, 1, logType)
    End Sub

End Class
