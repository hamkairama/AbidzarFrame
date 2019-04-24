Imports System.Reflection

Public Class ConvertUtils

    'ObjectSetProp buat konversi Satu Object ke Object Lain dengan mencocokan nama & tipe object
    Public Shared Function ObjectSetProp(Of T As New)(ByVal entty As Object) As T
        Return ObjectSetProp(Of T)(entty, New List(Of String))
    End Function
    'Kalo mau ada property Name yang di ignore tambahin list
    Public Shared Function ObjectSetProp(Of T As New)(ByVal entty As Object, ByVal listIgnore As List(Of String)) As T
        Dim dto As New T()

        If Not (entty Is Nothing) Then
            For Each enttyProp As PropertyInfo In entty.GetType().GetProperties
                Dim enttyPropName = enttyProp.Name
                Dim enttyPropValue = enttyProp.GetValue(entty, Nothing)
                Dim enttyPropType = enttyProp.PropertyType
                Dim dtoProp = dto.GetType.GetProperty(enttyPropName)
                If (dtoProp IsNot Nothing And Not listIgnore.Contains(enttyPropName)) Then
                    If dtoProp.PropertyType = enttyPropType Then
                        dto.GetType.GetProperty(enttyPropName).SetValue(dto, enttyPropValue, Nothing)
                    End If
                End If
            Next
        End If
        Return dto
    End Function

End Class
