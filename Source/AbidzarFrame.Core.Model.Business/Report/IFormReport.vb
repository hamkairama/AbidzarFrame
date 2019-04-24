Imports Manulife.Core.Model.Business

Public Interface IFormReport
    ''' <summary>
    ''' Use print engine to fill in report fields
    ''' </summary>
    ''' <param name="report">Print Engine Object</param>
    Sub SetReportFields(ByRef report As IPreprintFormPrintEngine)
    ''' <summary>
    ''' Use print engine to create field
    ''' </summary>
    ''' <param name="docProperties">Form properties</param>
    ''' <param name="report">Print Engine Object</param>
    Sub CreateReportFields(ByVal docProperties As PreprintFormProperties, ByRef report As IPreprintFormPrintEngine)
    ''' <summary>
    ''' Print pdf to byte() format
    ''' </summary>
    ''' <param name="output">Output file(Byte())</param>
    ''' <param name="ownerPassword">Optional owner password (String)</param>
    ''' <param name="userPassword">Optional</param>
    ''' <returns>Business Errors</returns>
    Function Print(ByRef output As Byte(), Optional ByVal ownerPassword As String = Nothing,
               Optional ByVal userPassword As String = Nothing) As BusinessErrors

    ''' <summary>
    ''' Use print engine to remove fields
    ''' </summary>
    ''' <param name="report">Print engine object</param>
    ''' <remarks></remarks>
    Sub RemoveReportFields(ByRef report As IPreprintFormPrintEngine)
End Interface
