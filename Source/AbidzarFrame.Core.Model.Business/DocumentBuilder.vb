Imports System.Xml
Imports System.IO
Imports AbidzarFrame.Core.Model.Business

Public MustInherit Class DocumentBuilder

    Protected _language As String
    Protected _document As XmlDocument
    Protected _reportLength As Decimal

    Private _header As List(Of DocumentElement)
    Private _body As List(Of DocumentElement)
    Private _footer As List(Of DocumentElement)

    Private _isPreview As Boolean = False

    Public Sub New()
        Me.New("en")
    End Sub

    Protected ReadOnly Property Header As List(Of DocumentElement)
        Get
            Return _header
        End Get
    End Property

    Protected Property Body As List(Of DocumentElement)
        Get
            Return _body
        End Get
        Set(ByVal value As List(Of DocumentElement))
            _body = value
        End Set
    End Property

    Protected ReadOnly Property Footer As List(Of DocumentElement)
        Get
            Return _footer
        End Get
    End Property

    Public Sub New(ByVal language As String)
        _language = language
        Init(_language, _header, _body, _footer)
    End Sub

    Public MustOverride Function Init(ByVal language As String, _
                                      ByRef header As List(Of DocumentElement), _
                                      ByRef body As List(Of DocumentElement), _
                                      ByRef footer As List(Of DocumentElement)) As BusinessErrors

    Protected MustOverride Function NewDocument(ByVal language As String) As XmlDocument
    Public MustOverride Function FillInElements() As BusinessErrors

    Protected Overridable Function CreateNamespaceManager(ByRef document As XmlDocument) As XmlNamespaceManager
        Dim nsmgr As New XmlNamespaceManager(document.NameTable)
        nsmgr.AddNamespace("ns", "http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition")
        nsmgr.AddNamespace("rd", "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner")
        Return nsmgr
    End Function

    Protected Overridable Function GetHeaderNode(ByRef document As XmlDocument, ByRef manager As XmlNamespaceManager) As XmlNode
        Return _document.SelectSingleNode("descendant::ns:Report/ns:Page/ns:PageHeader/ns:ReportItems", manager)
    End Function

    Protected Overridable Function GetBodyNode(ByRef document As XmlDocument, ByRef manager As XmlNamespaceManager) As XmlNode
        Dim _node = _document.SelectSingleNode("descendant::ns:Rectangle[@Name='ReportFrame']", manager)
        _node.PrependChild(GetHeaderNode(document, manager).CloneNode(False))
        _node = _document.SelectSingleNode("descendant::ns:Rectangle[@Name='ReportFrame']/ns:ReportItems", manager)

        Return _node
    End Function

    Protected Overridable Function GetFooterNode(ByRef document As XmlDocument, ByRef manager As XmlNamespaceManager) As XmlNode
        Return _document.SelectSingleNode("descendant::ns:Report/ns:Page/ns:PageFooter/ns:ReportItems", manager)
    End Function

    Public Overridable Function CompileDocument() As BusinessErrors
        _document = NewDocument(Me._language)
        Dim nsmgr As XmlNamespaceManager = CreateNamespaceManager(_document)

        Dim _headerNode As XmlNode = GetHeaderNode(_document, nsmgr)
        Dim _bodyNode As XmlNode = GetBodyNode(_document, nsmgr)
        Dim _footerNode As XmlNode = GetFooterNode(_document, nsmgr)

        Dim elementsList(,) = {{_header, _headerNode}, {_body, _bodyNode}, {_footer, _footerNode}}
        Dim errors As New BusinessErrors

        Dim size = elementsList.GetUpperBound(0)
        For i = 0 To size
            If elementsList(i, 0) IsNot Nothing Then
                For Each element In elementsList(i, 0)
                    errors.Add(element.AppendTo(elementsList(i, 1)))
                Next
            End If
        Next
        Return errors
    End Function

    Public Overridable Function PrintDocument(ByRef stream As Stream) As BusinessErrors
        Dim errs As New BusinessErrors
        Try
            Dim _writer As XmlTextWriter = New XmlTextWriter(stream, Text.Encoding.UTF8)
            _document.WriteTo(_writer)
            _writer.Close()
        Catch ex As Exception
            Utils.FillErrors(errs, ex)
        End Try
        Return errs
    End Function
End Class
