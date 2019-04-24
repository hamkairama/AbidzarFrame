Imports Manulife.Core.Model.Business

Public Interface IPdfVerifier

    Function VerifySignatures(ByVal file As String, ByRef completed As Boolean, ByRef signatureFields As Dictionary(Of String, Boolean)) As BusinessErrors

    Function VerifySignatures(ByVal content As Byte(), ByRef completed As Boolean, ByRef signatureFields As Dictionary(Of String, Boolean)) As BusinessErrors

End Interface
