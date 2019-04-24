Imports System.Runtime.Serialization
Imports System.Xml.Serialization
Imports System.Xml
Imports System.IO

<Serializable()>
Public Class DbCredential
    Implements IDbCredential

    Protected _connString As String = Nothing
    Protected _userId As String = Nothing
    Protected _password As String = Nothing
    Protected _database As String = Nothing 'Noted: for SQL Server
    Protected _dataSource As String = Nothing 'Noted: for SQL Server

    Public Sub New()
        Me.New(Nothing, Nothing, Nothing, Nothing, Nothing)
    End Sub

    Public Sub New(ByVal userId As String, ByVal password As String, ByVal database As String, ByVal dataSource As String, ByVal connectionString As String)
        Me._connString = connectionString
        Me._userId = userId
        Me._password = password
        Me._database = database
        Me._dataSource = dataSource


    End Sub

    Public Overridable Property UserId As String Implements IDbCredential.UserId
        Get
            Return _userId
        End Get
        Set(ByVal value As String)
            _userId = value
        End Set
    End Property

    Public Overridable Property Password As String Implements IDbCredential.Password
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property

    Public Overridable Property Database As String Implements IDbCredential.Database
        Get
            Return _database
        End Get
        Set(ByVal value As String)
            _database = value
        End Set
    End Property

    Public Property ConnectionString As String Implements IDbCredential.ConnectionString
        Get
            Return _connString
        End Get
        Set(ByVal value As String)
            _connString = value
        End Set
    End Property

    Public Property Datasource As String Implements IDbCredential.Datasource
        Get
            Return _dataSource
        End Get
        Set(value As String)
            _dataSource = value
        End Set
    End Property

End Class
