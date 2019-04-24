Public Interface IDbCredential

    Property UserId As String
    Property Password As String
    Property Database As String 'Noted: for SQL Server Only
    Property Datasource As String 'Noted: for SQL Server Only
    Property ConnectionString As String

End Interface
