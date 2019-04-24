Imports System.Configuration

Public Class BaseConnstringSql
    Public Shared ReadOnly Property ConnString() As String
        Get
            Return DataSource()
        End Get
    End Property

    Private Shared Function DataSource() As String
        Dim curCon As String = "Data Source=eZGgnL8CTTN3729T+UJpGA==; Port=riKEWlu/4sPF9z5Mr1uGNQ==;Initial Catalog=WFtX4Uq+q0VD1/QHYsYDUw==;Integrated Security=False;User ID=qm3FH4v9vuY2hIqGN46iZw==;Password=FJiOkQbsvFZA6XRrkud99A==;"
        Dim splitCon As String() = curCon.Split(";"c)
        Dim dtCurrent As String = Nothing
        Dim dtIdx As Integer = -1
        For i As Integer = 0 To splitCon.Length - 2
            If splitCon(i).TrimStart().ToUpper().StartsWith("DATA SOURCE") Then
                dtIdx = i
                dtCurrent = splitCon(i)
                Exit For
            End If
        Next
        If dtCurrent IsNot Nothing Then
            Try
                Dim idx As Integer = dtCurrent.IndexOf("="c) + 1
                Dim newdt As String = Cryptoghrap.DecryptString(dtCurrent.Substring(idx).Trim())
                splitCon(dtIdx) = dtCurrent.Substring(0, idx) & newdt
            Catch generatedExceptionName As Exception
                Throw New ArgumentException("Invalid Connection String")
            End Try
        End If
        Return Port(String.Join(";", splitCon))
    End Function

    Private Shared Function Port(BaseConnStr As String) As String
        Dim curCon As String = BaseConnStr
        Dim splitCon As String() = curCon.Split(";"c)
        Dim portPassword As String = Nothing
        Dim portIdx As Integer = -1
        For i As Integer = 0 To splitCon.Length - 2
            If splitCon(i).TrimStart().ToUpper().StartsWith("PORT") Then
                portIdx = i
                portPassword = splitCon(i)
                Exit For
            End If
        Next
        If portPassword IsNot Nothing Then
            Try
                Dim idx As Integer = portPassword.IndexOf("="c) + 1
                Dim newPort As String = Cryptoghrap.DecryptString(portPassword.Substring(idx).Trim())
                splitCon(portIdx) = portPassword.Substring(0, idx) & newPort
            Catch generatedExceptionName As Exception
                Throw New ArgumentException("Invalid Connection String")
            End Try
        End If
        Dim _Port As String = ProbablePort(String.Join(";", splitCon))
        Return InitialCatalog(_Port)
    End Function

    Private Shared Function InitialCatalog(BaseConnStr As String) As String
        Dim curCon As String = BaseConnStr
        Dim splitCon As String() = curCon.Split(";"c)
        Dim initialCurrent As String = Nothing
        Dim initialIdx As Integer = -1
        For i As Integer = 0 To splitCon.Length - 2
            If splitCon(i).TrimStart().ToUpper().StartsWith("INITIAL CATALOG") Then
                initialIdx = i
                initialCurrent = splitCon(i)
                Exit For
            End If
        Next
        If initialCurrent IsNot Nothing Then
            Try
                Dim idx As Integer = initialCurrent.IndexOf("="c) + 1
                Dim newInitial As String = Cryptoghrap.DecryptString(initialCurrent.Substring(idx).Trim())
                splitCon(initialIdx) = initialCurrent.Substring(0, idx) & newInitial
            Catch generatedExceptionName As Exception
                Throw New ArgumentException("Invalid Connection String")
            End Try
        End If
        Return UserID(String.Join(";", splitCon))
    End Function

    Private Shared Function UserID(BaseConnStr As String) As String
        Dim curCon As String = BaseConnStr
        Dim splitCon As String() = curCon.Split(";"c)
        Dim UidCurrent As String = Nothing
        Dim uIdx As Integer = -1
        For i As Integer = 0 To splitCon.Length - 1
            If splitCon(i).TrimStart().ToUpper().StartsWith("USER ID") Then
                uIdx = i
                UidCurrent = splitCon(i)
                Exit For
            End If
        Next
        If UidCurrent IsNot Nothing Then
            Try
                Dim idx As Integer = UidCurrent.IndexOf("="c) + 1
                Dim newUid As String = Cryptoghrap.DecryptString(UidCurrent.Substring(idx).Trim())
                splitCon(uIdx) = UidCurrent.Substring(0, idx) & newUid
            Catch generatedExceptionName As Exception
                Throw New ArgumentException("Invalid Connection String")
            End Try
        End If
        Return Password(String.Join(";", splitCon))
    End Function

    Private Shared Function Password(BaseConnStr As String) As String
        Dim curCon As String = BaseConnStr
        Dim splitCon As String() = curCon.Split(";"c)
        Dim pwdCurrent As String = Nothing
        Dim pwdIdx As Integer = -1
        For i As Integer = 0 To splitCon.Length - 2
            If splitCon(i).TrimStart().ToUpper().StartsWith("PASSWORD") Then
                pwdIdx = i
                pwdCurrent = splitCon(i)
                Exit For
            End If
        Next
        If pwdCurrent IsNot Nothing Then
            Try
                Dim idx As Integer = pwdCurrent.IndexOf("="c) + 1
                Dim newpass As String = Cryptoghrap.DecryptString(pwdCurrent.Substring(idx).Trim())
                splitCon(pwdIdx) = pwdCurrent.Substring(0, idx) & newpass
            Catch generatedExceptionName As Exception
                Throw New ArgumentException("Invalid Connection String")
            End Try
        End If
        Return String.Join(";", splitCon)
    End Function

    Private Shared Function ProbablePort(Param As String) As String
        Dim _Port As String = ""
        If Param.Contains("; Port=") = True Then
            _Port = Param.Replace("; Port=", ", ")
        ElseIf Param.Contains(";Port=") = True Then
            _Port = Param.Replace(";Port=", ", ")
        ElseIf Param.Contains(" ; Port=") = True Then
            _Port = Param.Replace(" ; Port=", ", ")
        ElseIf Param.Contains(" ; Port =") = True Then
            _Port = Param.Replace(" ; Port =", ", ")
        ElseIf Param.Contains(" ; Port = ") = True Then
            _Port = Param.Replace(" ; Port = ", ", ")
        Else
            _Port = Param
        End If
        Return _Port
    End Function


End Class
