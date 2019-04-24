Imports System.Reflection

Public Class StringUtils
    Public Shared Function DoubleQuote(ByVal str As String) As String
        'Return str
        Return Chr(34) & str & Chr(34)
    End Function

    Public Shared Function isEmpty(ByVal str As String) As Boolean

        Dim ret = False
        str = "" + str
        If str = "" Then
            ret = True
        End If
        Return ret
    End Function

    Public Shared Function GetFileName(ByVal fullPath As String) As String
        Dim split As String() = fullPath.Split({"\"}, StringSplitOptions.None)
        Dim rs As String = split(split.Count() - 1)

        Return rs
    End Function
End Class
