Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.IO

<Serializable()>
<DataContract()>
Public Class Errors

    <DataMember()>
    Public Property Code As String
    <DataMember()>
    Public Property Message As String
    <DataMember()>
    Public Property Field As String

End Class
