Public Interface IPdfToolHandler

    Function EncryptPdf(ByVal input As Byte(), ByVal userPassword As String, ByVal ownerPassword As String, ByRef output As Byte()) As BusinessErrors

End Interface
