Imports AbidzarFrame.Core.Model.Business

Public MustInherit Class RulesHandler

    Protected _rules As List(Of IValidationRule) = Nothing

    Public Sub New()
        _rules = New List(Of IValidationRule)
        SetRules(Me._rules)
    End Sub

    Protected ReadOnly Property Rules As List(Of IValidationRule)
        Get
            Return _rules
        End Get
    End Property

    Protected MustOverride Sub SetRules(ByRef rules As List(Of IValidationRule))

    Protected Sub AddRule(ByRef rule As IValidationRule)
        _rules.Add(rule)
    End Sub

    Public Function Execute(ByRef warnings As BusinessWarnings) As BusinessErrors
        Dim errs As New BusinessErrors
        Dim warns As New BusinessWarnings
        For Each r In _rules
            Try
                Dim e = r.Validate(warns)
                errs.Add(e)
                If (r.EndIfTrigger() AndAlso e.HasError) Then
                    Exit For
                End If
            Catch ex As Exception
                Utils.FillErrors(errs, ex)
                If (r.EndIfTrigger()) Then
                    Exit For
                End If
            End Try
        Next
        warnings = warns
        Return errs
    End Function

End Class
