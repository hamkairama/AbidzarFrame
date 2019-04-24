Imports System.Collections
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.Xml
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Text
Imports System.Xml.Serialization

Public Class DataContractHelper
    Public Shared Function ContractToString(ByRef _contract As Object, ByVal _type As Type) As String
        Dim stream As New MemoryStream
        If (_type Is Nothing) Then
            _type = GetType(String)
        End If
        Dim _serializer = New DataContractSerializer(_type)
        _serializer.WriteObject(stream, _contract)

        Dim s As String = System.Text.Encoding.UTF8.GetString(stream.ToArray())
        Return s.ToString()
    End Function

    Public Shared Function XmlToString(ByRef _contract As Object, ByVal _type As Type) As String
        Dim stream As New MemoryStream
        Dim _serializer = New XmlSerializer(_type)
        _serializer.Serialize(stream, _contract)

        Dim s As String = System.Text.Encoding.UTF8.GetString(stream.ToArray())
        Return s.ToString()
    End Function
End Class
