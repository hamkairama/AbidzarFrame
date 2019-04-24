Imports System.Runtime.Serialization

<DataContract()> _
<Serializable()> _
Public MustInherit Class ErrorMessages

    <DataMember()> _
    Public Shared ReadOnly Msg_Unknown_Error As BusinessErrorVo = New BusinessErrorVo("", "", "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.")

    <DataMember()> _
    Public Shared ReadOnly Msg_Proposal_Print_Report_Starting_Root_Not_Found As BusinessErrorVo = New BusinessErrorVo("", "", _
            New BusinessMessageContent("en", "Sorry, the specific report definition cannot be found in the report."), _
            New BusinessMessageContent("id", "Sorry, the specific report definition cannot be found in the report."))

    <DataMember()> _
    Public Shared ReadOnly Msg_Print_Node_Not_Found As BusinessErrorVo = New BusinessErrorVo("E45003", "", _
            New BusinessMessageContent("en", "Sorry, the specific node cannot be found in the report."), _
            New BusinessMessageContent("id", "Sorry, the specific node cannot be found in the report."))

    <DataMember()> _
    Public Shared ReadOnly Msg_Proposal_Print_Document_Not_Compiled As BusinessErrorVo = New BusinessErrorVo("E45004", "", _
            New BusinessMessageContent("en", "Sorry, the proposal object is not compiled."), _
            New BusinessMessageContent("id", "Sorry, the proposal object is not compiled."))

    <DataMember()> _
    Public Shared ReadOnly Msg_Print_Element_Starting_Root_Not_Found As BusinessErrorVo = New BusinessErrorVo("E45005", "", _
            New BusinessMessageContent("en", "Sorry, the proposal element starting root cannot be found."), _
            New BusinessMessageContent("id", "Sorry, the proposal element starting root cannot be found."))

    <DataMember()> _
    Public Shared ReadOnly Msg_Invalid_Date_Format As BusinessErrorVo = New BusinessErrorVo("", "", "Invalid date format. Please follow DD-MMM-YYYY.")

    Public Shared Function NewError(ByVal field As String, ByVal err As BusinessErrorVo, ByVal ParamArray parameters As Object()) As BusinessErrorVo
        Dim messages As New List(Of BusinessMessageContent)
        For Each message In err.LocalizedErrors
            messages.Add(New BusinessMessageContent(message.LanguageCode, String.Format(message.Message, parameters)))
        Next
        Return New BusinessErrorVo(err.ErrorCode, field, messages.ToArray())
    End Function

    Public Shared Function NewError(ByVal field As String, ByVal err As BusinessWarningVo, ByVal ParamArray parameters As Object()) As BusinessWarningVo
        Dim messages As New List(Of BusinessMessageContent)
        For Each message In err.LocalizedErrors
            messages.Add(New BusinessMessageContent(message.LanguageCode, String.Format(message.Message, parameters)))
        Next
        Return New BusinessWarningVo(err.ErrorCode, field, messages.ToArray())
    End Function

End Class
