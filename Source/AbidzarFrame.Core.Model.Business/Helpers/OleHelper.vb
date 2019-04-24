Imports System.IO
Imports System.Data
Imports System.Data.OleDb

Public Class OleHelper

    Public Shared Sub SetValue(ByRef variable As Object, ByRef value As Object)
        SetValue(variable, value, Nothing)
    End Sub

    Public Shared Function NullableDate(ByVal dateValue As DateTime) As Object
        If (dateValue = DateTime.MinValue) Then
            Return Nothing
        End If
        Return dateValue
    End Function

    Protected Shared Sub SetValue(ByRef variable As Object, ByRef value As Object, ByVal defaultValue As Object)
        Dim val
        Dim _setDefault As Boolean = False
        If IsDBNull(value) OrElse _setDefault Then
            val = defaultValue
        Else
            val = value
        End If
        variable = val
    End Sub

End Class
