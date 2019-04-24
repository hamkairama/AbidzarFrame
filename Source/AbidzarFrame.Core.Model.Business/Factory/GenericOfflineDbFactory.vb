Imports Oracle.DataAccess.Client
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Data

Public MustInherit Class GenericOfflineDbFactory
    Inherits GenericDbFactory

    Private _dbName As String = Nothing
    Private _dbPassword As String = Nothing

    Protected Property DBName As String
        Get
            Return _dbName
        End Get
        Set(ByVal value As String)
            _dbName = value
        End Set
    End Property

    Protected Property DBPassword As String
        Get
            Return _dbPassword
        End Get
        Set(ByVal value As String)
            _dbPassword = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    Protected Overrides Function fileName() As String
        Dim Name As String = Me.GetType().ToString() & "." & _dbName & ".xml"
        Return Name
    End Function
End Class
