Imports AbidzarFrame.Core.Model.Business

Public MustInherit Class ValidationRule
    Implements IValidationRule

    Private _errs As BusinessErrors
    Private _warnings As BusinessErrors

    Protected Function AddNewError(ByVal fieldName As String, ByVal err As BusinessErrorVo, _
                                   ByVal ParamArray parameters As Object()) As BusinessErrorVo
        Dim _err As BusinessErrorVo = ErrorMessages.NewError(fieldName, err, parameters)
        _errs.Add(_err)
        Return _err
    End Function

    Protected Function AddNewError(ByVal fieldName As String, ByVal err As BusinessWarningVo, _
                                   ByVal ParamArray parameters As Object()) As BusinessWarningVo
        Dim _err As BusinessErrorVo = ErrorMessages.NewError(fieldName, err, parameters)
        _warnings.Add(_err)
        Return _err
    End Function

    Public Function Validate(ByRef warnings As Core.Model.Business.BusinessWarnings) As Core.Model.Business.BusinessErrors Implements Core.Model.Business.IValidationRule.Validate
        _errs = New BusinessErrors
        _warnings = New BusinessWarnings
        Execute()
        warnings = _warnings
        Return _errs
    End Function

    Protected MustOverride Sub Execute()

    Protected MustOverride Function EndIfTrigger() As Boolean Implements Core.Model.Business.IValidationRule.EndIfTrigger

End Class
