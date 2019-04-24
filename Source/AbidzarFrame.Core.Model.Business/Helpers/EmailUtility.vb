Imports System.Net.Mail
Imports System.IO
Imports System.Net.Mime

Public Class EmailUtility

    Public Shared Sub SendEmail(ByVal fromAddress As String, ByVal toAddress As String, ByVal subject As String, _
                                ByVal message As String, ByVal proxy As String, ByVal proxyPort As String, _
                                Optional ByVal htmlMessage As Boolean = False)

        Dim client As New SmtpClient(proxy, proxyPort)
        Dim m As New MailMessage(fromAddress, toAddress, subject, message)

        m.Priority = MailPriority.Normal

        If htmlMessage Then
            Dim html As AlternateView = Nothing
            ToAlternateView(message, html)
            m.AlternateViews.Add(html)
        End If

        client.Send(m)

    End Sub

    Public Shared Sub SendEmail(ByVal fromAddress As String, ByVal toAddressList As List(Of String), ByVal ccAddressList As List(Of String), _
                                ByVal subject As String, ByVal message As String, ByVal attachmentName As String, _
                                ByVal attachmentContent As Stream, ByVal proxy As String, ByVal proxyPort As String, _
                                Optional ByVal htmlMessage As Boolean = False)

        Dim _client As New SmtpClient(proxy, proxyPort)
        Dim _mailMessage As New MailMessage()
        _mailMessage.Priority = MailPriority.Normal

        _mailMessage.From = New MailAddress(fromAddress)
        For Each receiver In toAddressList
            _mailMessage.To.Add(New MailAddress(receiver))
        Next
        For Each cc In ccAddressList
            _mailMessage.CC.Add(New MailAddress(cc))
        Next
        _mailMessage.Subject = subject

        If Not String.IsNullOrEmpty(attachmentName) Then
            Dim _attachment As Attachment = New Attachment(attachmentContent, attachmentName, MediaTypeNames.Application.Octet)
            _mailMessage.Attachments.Add(_attachment)
        End If

        If htmlMessage Then
            Dim _html As AlternateView = Nothing
            ToAlternateView(message, _html)
            _mailMessage.AlternateViews.Add(_html)
        End If

        _client.Send(_mailMessage)

    End Sub

    Public Shared Sub ToAlternateView(ByVal message As String, ByRef HtmlMessage As AlternateView)
        Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(message, Nothing, "text/html")
        HtmlMessage = htmlView
    End Sub
End Class
