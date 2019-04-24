Imports Manulife.Core.Model.Business
Imports System.IO
Public MustInherit Class PreprintFormReport
    Implements IPreprintFormReport

    Protected Property report As IPreprintFormPrintEngine = Nothing

    Public Sub New()
        Try
            Dim _ns As String = BusinessModelSetting.GetInstance().Parameters(BusinessModelSetting.PREPRINT_FORM_PRINT_ENGINE_NAMESPACE)
            Dim _cl As String = BusinessModelSetting.GetInstance().Parameters(BusinessModelSetting.PREPRINT_FORM_PRINT_ENGINE_CLASSNAME)
            report = Utils.LoadClass(Of IPreprintFormPrintEngine)(_ns, _cl)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Print(ByRef output() As Byte, Optional ByVal ownerPassword As String = Nothing,
                          Optional ByVal userPassword As String = Nothing) _
                      As Core.Model.Business.BusinessErrors Implements IPreprintFormReport.Print
        Dim errs As New BusinessErrors
        Try
            If (Not String.IsNullOrEmpty(userPassword) And String.IsNullOrEmpty(ownerPassword)) Then
                ownerPassword = userPassword
            End If
            Dim _output = report.Print(Me, ownerPassword, userPassword)
            output = _output
        Catch ex As Exception
            Utils.FillErrors(errs, ex)
        End Try
        Return errs
    End Function

    Public MustOverride ReadOnly Property PdfForm As String Implements IPreprintFormReport.PdfForm

    Public Overridable Sub CreateReportFields(ByVal docProperties As PreprintFormProperties, ByRef report As IPreprintFormPrintEngine) Implements IFormReport.CreateReportFields
        'To be override
    End Sub

    Public MustOverride Sub SetReportFields(ByRef report As IPreprintFormPrintEngine) Implements IFormReport.SetReportFields

    Public MustOverride Sub RemoveReportFields(ByRef report As IPreprintFormPrintEngine) Implements IFormReport.RemoveReportFields
End Class
