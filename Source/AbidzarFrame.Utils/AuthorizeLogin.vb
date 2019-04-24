Imports System.ComponentModel.DataAnnotations
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Class AuthorizeLogin
    Inherits AuthorizeAttribute

    Protected Overrides Function AuthorizeCore(ByVal httpContext As HttpContextBase) As Boolean
        Dim isValid As Boolean = False
        If httpContext.Session("loginSession") IsNot Nothing And httpContext.Session("userSession") IsNot Nothing Then
            isValid = True
        End If

        Return isValid
    End Function

    Protected Overrides Sub HandleUnauthorizedRequest(ByVal filterContext As AuthorizationContext)
        filterContext.Result = New RedirectToRouteResult(New RouteValueDictionary(New With {.controller = "Account", .action = "LogOff", .id = UrlParameter.Optional}))
    End Sub
End Class
