Public Interface IValidationRule

    Function EndIfTrigger() As Boolean

    Function Validate(ByRef warnings As BusinessWarnings) As BusinessErrors

End Interface
