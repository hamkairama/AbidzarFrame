Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports Oracle.DataAccess.Types

Public Class DbHelper

    Public Shared Sub SetValue(ByRef variable As Object, ByVal value As Object)
        SetValue(variable, value, Nothing)
    End Sub

    Public Shared Function NullableDate(ByVal dateValue As DateTime) As Object
        If (dateValue = DateTime.MinValue) Then
            Return Nothing
        End If
        Return dateValue
    End Function

    Public Shared Sub SetValue(ByRef variable As Object, ByVal value As Object, ByVal defaultValue As Object)
        If TypeOf value Is OracleString OrElse _
           TypeOf value Is OracleDate OrElse _
           TypeOf value Is OracleDecimal Then
            SetOracleValue(variable, value, defaultValue)
        Else
            SetValue2(variable, value, defaultValue)
        End If
    End Sub

    Protected Shared Sub SetValue2(ByRef variable As Object, ByVal value As Object, ByVal defaultValue As Object)
        Dim val
        Dim _setDefault As Boolean = False
        'If v IsNot Nothing Then
        '    Dim _target As Type = r.GetType()
        '    _setDefault = Not v.GetType().Equals(_target)
        'End If
        If IsDBNull(value) OrElse _setDefault Then
            val = defaultValue
        Else
            val = value
        End If
        variable = val
    End Sub

    Protected Shared Sub SetOracleValue(ByRef variable As Object, ByVal value As Object, ByVal defaultValue As Object)
        Dim val
        Dim _setDefault As Boolean = False
        'If v IsNot Nothing Then
        '    Dim _target As Type = r.GetType()
        '    _setDefault = Not v.GetType().Equals(_target)
        'End If
        If value.IsNull() OrElse _setDefault Then
            val = defaultValue
        Else
            val = value.Value
        End If
        variable = val
    End Sub

End Class
