Imports System.Runtime.Serialization

<DataContract()> _
<Serializable()> _
Public Class LocalizedStringPhrase

    <DataMember(name:="Locale")> _
    Protected _locale As String

    <DataMember(name:="StringPhrase")> _
    Protected _stringPhrase As String

    Public Sub New(ByVal locale As String, ByVal stringPhrase As String)
        Me._locale = locale
        Me._stringPhrase = stringPhrase
    End Sub

    Public Property Locale As String
        Get
            Return _locale
        End Get
        Set(ByVal value As String)
            _locale = value
        End Set
    End Property

    Public Property StringPhrase As String
        Get
            Return _stringPhrase
        End Get
        Set(ByVal value As String)
            _stringPhrase = value
        End Set
    End Property

End Class
