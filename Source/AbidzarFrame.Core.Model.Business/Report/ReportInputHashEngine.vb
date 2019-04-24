Public Class ReportInputHashEngine
    Implements IPreprintFormPrintEngine

    Private _fieldDict As New Dictionary(Of String, String)

    Public Function Print(ByVal report As IFormReport, Optional ByVal ownerPassword As String = Nothing, Optional ByVal userPassword As String = Nothing,
                   Optional ByVal flatteningOption As PdfFlatteningOption = PdfFlatteningOption.NoFlattening,
                   Optional ByVal enableEncryption As Boolean = True) As Byte() Implements IPreprintFormPrintEngine.Print
        Throw New NotImplementedException()
    End Function

    Public Sub SetFieldValue(ByVal fieldName As String, ByVal value As Object, Optional ByVal defaultValue As Object = "", Optional ByVal append As Boolean = False, Optional ByVal separator As String = "") Implements IPreprintFormPrintEngine.SetFieldValue
        Dim _value As Object = value
        If String.IsNullOrEmpty(_value) Then
            _value = defaultValue
        End If

        'Only record non-empty field
        If Not String.IsNullOrEmpty(_value) Then
            If _fieldDict.ContainsKey(fieldName) Then
                If append Then
                    _fieldDict(fieldName) = _fieldDict(fieldName) & separator & _value
                Else
                    _fieldDict(fieldName) = _value
                End If
            Else
                _fieldDict.Add(fieldName, _value)
            End If
        End If

    End Sub

    Public ReadOnly Property FieldDict As Dictionary(Of String, String)
        Get
            Return _fieldDict
        End Get
    End Property


    Public Sub AddField(ByVal field As PreprintFormField) Implements IPreprintFormPrintEngine.AddField

    End Sub

    Public Sub RemoveField(ByVal fieldName As String) Implements IPreprintFormPrintEngine.RemoveField

    End Sub

    Public Function AppendPages(ByVal source() As Byte, ByVal append() As Byte) As Byte() Implements IPreprintFormPrintEngine.AppendPages
        Throw New NotImplementedException
    End Function
End Class
