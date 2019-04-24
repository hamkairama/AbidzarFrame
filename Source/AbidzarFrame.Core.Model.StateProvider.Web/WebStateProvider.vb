Imports AbidzarFrame.Core.Model.Business
Imports System.Web
Imports System.Web.SessionState

Public Class WebStateProvider
    Implements IStateService

    Public Sub New()

    End Sub

    Public Function GetValue(ByVal scope As Business.StateScope, ByVal objectName As String) _
        As Object Implements Business.IStateService.GetValue

        If scope = StateScope.Application Then
            If IsNothing(HttpContext.Current) Then
                Return Nothing
            Else
                Return HttpContext.Current.Application(objectName)
            End If
        Else
            If IsNothing(HttpContext.Current) Then
                Return Nothing
            Else
                Return HttpContext.Current.Session(objectName)
            End If
        End If
    End Function

    Public Sub SetValue(ByVal scope As Business.StateScope, ByVal objectName As String, ByVal value As Object) _
        Implements Business.IStateService.SetValue

        If scope = StateScope.Application Then
            HttpContext.Current.Application(objectName) = value
        Else
            HttpContext.Current.Session(objectName) = value
        End If
    End Sub

End Class
