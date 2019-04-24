Public Interface IPreprintFormPrintEngine

    Sub SetFieldValue(ByVal fieldName As String, ByVal value As Object, Optional ByVal defaultValue As Object = "", Optional ByVal append As Boolean = False, Optional ByVal separator As String = "")
    'Sub SetFieldValue(ByVal fieldName As String, ByVal value As Object)

    'Function Print(ByVal report As IPreprintFormReport, Optional ByVal ownerPassword As String = Nothing,
    '               Optional ByVal userPassword As String = Nothing) As Byte()


    ''' <summary>
    ''' Print pdf
    ''' </summary>
    ''' <param name="report">Form Report to print</param>
    ''' <param name="ownerPassword">Optional owner password</param>
    ''' <param name="userPassword">Optional user password</param>
    ''' <param name="flatteningOption">Optional flattening option</param>
    ''' <returns>Byte()</returns>
    ''' <remarks>Work with API to print</remarks>
    Function Print(ByVal report As IFormReport,
                   Optional ByVal ownerPassword As String = Nothing,
                   Optional ByVal userPassword As String = Nothing,
                   Optional ByVal flatteningOption As PdfFlatteningOption = PdfFlatteningOption.NoFlattening,
                   Optional ByVal enableEncryption As Boolean = True) As Byte()

    ''' <summary>
    ''' Add Acro field to pdf
    ''' </summary>
    ''' <param name="field">filed object</param>
    ''' <remarks>Work with API to add field</remarks>
    Sub AddField(ByVal field As PreprintFormField)

    ''' <summary>
    ''' Remove field from pdf, which happen when some field is condition dependent
    ''' </summary>
    ''' <param name="fieldName"></param>
    ''' <remarks></remarks>
    Sub RemoveField(ByVal fieldName As String)

    Function AppendPages(ByVal source As Byte(), ByVal append As Byte()) As Byte()
End Interface
