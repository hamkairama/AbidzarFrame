Imports System.Runtime.Serialization
Imports System.Xml.Serialization
Imports System.Xml
Imports System.IO

<Serializable()>
Public Class EncryptedDbCredential
    Inherits DbCredential

    Private key1 As String = "A24c68zB"
    Private key2 As String = BusinessModelSetting.GetInstance().Parameters(BusinessModelSetting.DATABASE_ENCRYPTION_KEY)

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByRef dbCredential As DbCredential)
        If Not IsNothing(dbCredential.UserId) Then
            Me._userId = CipherUtility.EncryptData(dbCredential.UserId, key1 & key2)
        End If
        Me._password = CipherUtility.EncryptData(dbCredential.Password, key1 & key2)
        Me._database = CipherUtility.EncryptData(dbCredential.Database, key1 & key2) 'Noted: SQL Server
        Me._dataSource = CipherUtility.EncryptData(dbCredential.Datasource, key1 & key2) 'Noted: SQL Server
        Me._connString = dbCredential.ConnectionString
    End Sub

    Public Function DecryptedDbCredential() As IDbCredential
        Dim _id As String
        If IsNothing(Me.UserId) Then
            _id = Nothing
        Else
            _id = CipherUtility.DecryptData(Me._userId, key1 & key2)
        End If
        Dim _pw As String = CipherUtility.DecryptData(Me._password, key1 & key2)
        Dim _db As String = CipherUtility.DecryptData(Me._database, key1 & key2) 'Noted: SQL Server
        Dim _ds As String = CipherUtility.DecryptData(Me._dataSource, key1 & key2) 'Noted: SQL Server
        Return New DbCredential(_id, _pw, _db, _ds, Me._connString)
    End Function

End Class
