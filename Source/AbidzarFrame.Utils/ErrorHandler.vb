Imports AbidzarFrame.Utils
Imports AbidzarFrame.Core.Model.Business
Imports System.Data.SqlClient

Public Class ErrorHandler

    Private Shared ErrorTables As New Dictionary(Of String, Dictionary(Of String, BusinessErrorVo))

    Public Const _MSG_SUCCESS As String = "00000"


    Public Const _DOC_LOG_NO_ERR As String = "00"
    Public Const _DOC_LOG_CORRUPTED As String = "01"
    Public Const _DOC_LOG_SEND_IEDMS As String = "02"


    Public Const _IP4ResultFailed As String = "FAIL"
    Public Const _IP4ResultSuccess As String = "SUCCESS"

    Public Const _ERRKEY_READJSONFILE = "READJSONFILE"
    Public Const _ERRKEY_ISACTIVEBRANCH = "ISACTIVEBRANCE"
    Public Const _ERRKEY_ISSERVICEHOUR = "ISSERVICEHOUR"

    Public Const _ERRKEY_GETAPPRESULT = "GETAPPRESULT"
    Public Const _ERRKEY_GETCERTDATA = "GETCERTDATA"

    Public Const _SUBMITAPP_SUCCESS_CODE = "00000"
    Public Const _SUBMITAPP_SUCCESS_DESC = "SUCCESS"
    Public Const _SUBMITAPP_FAIL_CODE = "10001"
    Public Const _SUBMITAPP_FAIL_DESC = "FAIL"
    Public Const _SUBMITAPP_INVALID_BR_CODE = "10002"
    Public Const _SUBMITAPP_INVALID_BR_DESC = "INVALID BRANCH CODE"

#Region "Applikasi public const"
    Public Const _ERRKEY_ABIDZARFRAME = "ABIDZARFRAME"
#End Region


    Public Sub New()
        If ErrorTables.Count = 0 Then
            Dim _errorMessage As New Dictionary(Of String, BusinessErrorVo)
            _errorMessage = New Dictionary(Of String, BusinessErrorVo)
            _errorMessage.Add("99999", ErrorMessages.UNKNOWN_ERROR)
            _errorMessage.Add("00001", ErrorMessages.IP1_MSG_CANNOTREAD_JSON_TBL)
            ErrorTables.Add(_ERRKEY_ISACTIVEBRANCH, _errorMessage)

            _errorMessage = New Dictionary(Of String, BusinessErrorVo)
            _errorMessage.Add("99999", ErrorMessages.UNKNOWN_ERROR)
            _errorMessage.Add(ErrorMessages.IP1CD_MSG_NOT_SERVICE_HOUR, ErrorMessages.IP1_NOT_SERVICE_HOUR)
            ErrorTables.Add(_ERRKEY_ISSERVICEHOUR, _errorMessage)

            _errorMessage = New Dictionary(Of String, BusinessErrorVo)
            _errorMessage.Add("99999", ErrorMessages.Msg_Unknown_Error)
            _errorMessage.Add(ErrorMessages.IP4CD_MSG_FILE_CORRUPTED, ErrorMessages.IP4_MSG_FILE_CORRUPTED)
            _errorMessage.Add(ErrorMessages.IP4CD_MSG_FAIL_UNZIPDECRYT, ErrorMessages.IP4_MSG_FAIL_UNZIPDECRYT)
            _errorMessage.Add(ErrorMessages.IP4CD_MSG_FAIL_GENERATE_ACK, ErrorMessages.IP4_MSG_FAIL_GENERATE_ACK)
            _errorMessage.Add(ErrorMessages.IP4CD_MSG_FAIL_SEND_IEDMS, ErrorMessages.IP4_MSG_FAIL_SEND_IEDMS)
            _errorMessage.Add(ErrorMessages.IP4CD_MSG_INTERNALWS_ERROR, ErrorMessages.IP4_MSG_INTERNALWS_ERROR)
            _errorMessage.Add(ErrorMessages.IP4CD_MSG_CANNOTREAD_JSON, ErrorMessages.IP4_MSG_CANNOTREAD_JSON)
            _errorMessage.Add(ErrorMessages.IP4CD_MSG_APPLICATION_NOTEXISTS, ErrorMessages.IP4_MSG_APPLICATION_NOTEXISTS)
            ErrorTables.Add(_ERRKEY_READJSONFILE, _errorMessage)

            _errorMessage = New Dictionary(Of String, BusinessErrorVo)
            _errorMessage.Add("99999", ErrorMessages.IP3I_GET_DATA_ERROR)
            ErrorTables.Add(_ERRKEY_GETCERTDATA, _errorMessage)

#Region "error message handler"
            _errorMessage = New Dictionary(Of String, BusinessErrorVo)
            _errorMessage.Add("99999", ErrorMessages.Msg_Unknown_Error)
            _errorMessage.Add(ErrorMessages.ERR_AUTH, ErrorMessages.AUTH_ERROR)
            _errorMessage.Add(ErrorMessages.ABIDZARFRAME_AD_NOT_FOUND_CD, ErrorMessages.ABIDZARFRAME_AD_NOT_FOUND)
            _errorMessage.Add(ErrorMessages.ABIDZARFRAME_DATA_NOT_FOUND_CD, ErrorMessages.ABIDZARFRAME_DATA_NOT_FOUND)
            _errorMessage.Add(ErrorMessages.ABIDZARFRAME_USER_IN_ACTIVE_CD, ErrorMessages.ABIDZARFRAME_USER_IN_ACTIVE)
            _errorMessage.Add(ErrorMessages.ABIDZARFRAME_USER_NOT_SAME_CD, ErrorMessages.ABIDZARFRAME_USER_NOT_SAME)
            _errorMessage.Add(ErrorMessages.ABIDZARFRAME_DATA_ALREADY_EXIST_CD, ErrorMessages.ABIDZARFRAME_DATA_ALREADY_EXIST)
            _errorMessage.Add(ErrorMessages.ABIDZARFRAME_TIER_LIMIT_CD, ErrorMessages.ABIDZARFRAME_TIER_LIMIT)
            _errorMessage.Add(ErrorMessages.ABIDZARFRAME_FUNDS_SELECT_CD, ErrorMessages.ABIDZARFRAME_FUNDS_SELECT)
            ErrorTables.Add(_ERRKEY_ABIDZARFRAME, _errorMessage)
#End Region

        End If
    End Sub

    Public Function ValidateManulifeObject(ByVal mlObject As Dictionary(Of String, Dictionary(Of String, String)), ByRef _errors As BusinessErrors) As Boolean
        Dim check As Boolean = True

        If Not (mlObject.ContainsKey("eAppCompleteFormDanamon") And mlObject("eAppCompleteFormDanamon").ContainsKey("ReferenceNumber")) Then
            check = False
            _errors = InterpretErrors("SUBMISSION", "WEB01")
        End If
        Return check
    End Function

    Public Function GetErrorMessage(ByVal errKey As String, ByVal errCode As String) As String
        Return ErrorTables(errKey)(errCode).ErrorMessage
    End Function


    Public Function InterpretErrors(ByVal functionName As String, ByVal dbErrorCodes As String) As BusinessErrors
        Dim errors As New BusinessErrors

        If (ErrorTables.ContainsKey(functionName)) Then
            Dim errorTable As Dictionary(Of String, BusinessErrorVo) = ErrorTables(functionName)
            Dim codes As String() = dbErrorCodes.Split(";")
            For Each code In codes
                If errorTable.ContainsKey(code) Then
                    errors.Add(errorTable(code))
                End If
            Next
        End If
        Return errors
    End Function

    ' [Tyo] : fungsi untuk sql excetion
    Public Function FillError(ByVal ex As SqlException) As BusinessErrors
        Dim errors As New BusinessErrors

        Dim sqlCode As String = "SQL" & ex.Number
        'Dim msg As String = GetErrorMessage(_ERRKEY_ABIDZARFRAME, sqlCode)
        'If String.IsNullOrWhiteSpace(msg) Then
        '    msg = ex.Message
        'End If
        errors.Add(New BusinessErrorVo(ErrorMessages.ERR_SQL_EXCEPTION, "", ex.Message))
        Return errors
    End Function

    Public Function FillError(ByVal ex As Exception) As BusinessErrors
        Dim errors As New BusinessErrors

        'Dim msg As String = ex.Message
        errors.Add(New BusinessErrorVo(ErrorMessages.ERR_EXCEPTION, "", ex.Message))
        Return errors
    End Function

    Public Sub FillError(ByVal ex As String, ByRef err As BusinessErrors)
        FillError(ErrorMessages.ERR_EXCEPTION, "", ex, err)
    End Sub


    Public Sub FillError(ByVal errCD As String, ByVal effFld As String, ByVal ex As String, ByRef err As BusinessErrors)
        If err Is Nothing Then
            err = New BusinessErrors()
        End If
        err.Add(New BusinessErrorVo(errCD, effFld, ex))

    End Sub

#Region "Applikasi"
    Public Function GetErrorMessage(ByVal err As BusinessErrors) As String
        Return err.ErrorList.FirstOrDefault().ErrorMessage
    End Function
#End Region

End Class
