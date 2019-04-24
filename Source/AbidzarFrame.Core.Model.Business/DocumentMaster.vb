Imports System.Xml
Imports AbidzarFrame.Core.Model.Business
Imports System.IO
Imports System.Globalization

Public MustInherit Class DocumentMaster
    Implements IDocument

    Private _fileName As String
    Private _reportNames As List(Of String)
    Private _xmlLayout As XmlDocument
    Private _defaultPlaceholder As XmlNode

    Protected Overridable ReadOnly Property DefaultPlaceholderXPath As String
        Get
            Return "descendant::ns:Subreport"
        End Get
    End Property

    Protected Overridable ReadOnly Property DefaultPlaceholderFile As String
        Get
            Return ReportPath() & "Subreport.rdlc"
        End Get
    End Property

    Protected Overridable ReadOnly Property DefaultMasterReportFile As String
        Get
            Return ReportPath() & "MainWithSubRpt.rdlc"
        End Get
    End Property

    Protected Property ReportNames As List(Of String)
        Get
            Return _reportNames
        End Get
        Set(ByVal value As List(Of String))
            _reportNames = value
        End Set
    End Property

    Protected Overridable Function InitDocument() As BusinessErrors
        Dim errors As New BusinessErrors
        Try
            _xmlLayout = New XmlDocument
            _xmlLayout.Load(DefaultMasterReportFile)

            Dim placeholderXml As New XmlDocument
            placeholderXml.Load(DefaultPlaceholderFile)
            _defaultPlaceholder = FindNode(placeholderXml, DefaultPlaceholderXPath)

            _reportNames = New List(Of String)
        Catch ex As Exception
            Utils.FillErrors(errors, ex)
        End Try
        Return errors
    End Function

    Protected Overridable Function InsertSubreports() As BusinessErrors
        Dim errors As New BusinessErrors
        errors.Add(InitDocument())
        If Not errors.HasError Then
            For Each name In _reportNames
                If _defaultPlaceholder IsNot Nothing Then
                    Dim newplaceholder = _defaultPlaceholder.CloneNode(True)
                    errors.Add(RenamePlaceholder(newplaceholder, "SubRpt" & name))
                    errors.Add(SetLocation(newplaceholder, 0, 0))
                    errors.Add(SetSubreport(newplaceholder, name))
                    Dim imported As XmlNode = _xmlLayout.OwnerDocument.ImportNode(newplaceholder, True)
                End If
            Next
        End If
        Return errors
    End Function

    Protected Function SetSubreport(ByRef subreportNode As XmlNode, ByVal reportName As String) As BusinessErrors
        Dim errors As New BusinessErrors
        Dim rptName As XmlNode = FindNode(subreportNode, "descendant::ns:ReportName")
        If rptName IsNot Nothing Then
            rptName.InnerText = reportName
        Else
            errors.Add(ErrorMessages.Msg_Print_Node_Not_Found)
        End If
        Return errors
    End Function

    Protected Function RenamePlaceholder(ByRef subreportNode As XmlNode, ByVal nodeName As String)
        Dim errors As New BusinessErrors
        If subreportNode IsNot Nothing Then
            subreportNode.Attributes("Name").Value = nodeName
        Else
            errors.Add(ErrorMessages.Msg_Print_Node_Not_Found)
        End If
        Return errors
    End Function

    Protected Function SetLocation(ByVal nodePath As XmlNode, ByVal left As Decimal, ByVal top As Decimal) As BusinessErrors
        Dim errors As New BusinessErrors

        Dim x As XmlNode = FindNode(nodePath, "descendant::ns:Left")
        If x IsNot Nothing Then
            x.InnerText = left.ToString("N", New CultureInfo("en-US")) + "cm"
        Else
            errors.Add(ErrorMessages.Msg_Print_Node_Not_Found)
        End If

        Dim y As XmlNode = FindNode(nodePath, "descendant::ns:Top")
        If y IsNot Nothing Then
            y.InnerText = top.ToString("N", New CultureInfo("en-US")) + "cm"
        Else
            errors.Add(ErrorMessages.Msg_Print_Node_Not_Found)
        End If

        Return errors
    End Function

    Protected Overridable Function FindNode(ByVal document As XmlDocument, ByVal findLocation As String) As XmlNode
        Dim nsmgr As XmlNamespaceManager = CreateNamespaceManager(document)
        Dim node As XmlNode = document.SelectSingleNode(findLocation, nsmgr)
        Return node
    End Function

    Protected Overridable Function FindNode(ByVal node As XmlNode, ByVal findLocation As String) As XmlNode
        Dim nsmgr As XmlNamespaceManager = CreateNamespaceManager(node.OwnerDocument)
        Dim child As XmlNode = node.SelectSingleNode(findLocation, nsmgr)
        Return child
    End Function

    Private Function CreateNamespaceManager(ByVal document As XmlDocument) As XmlNamespaceManager
        Dim nsmgr As New XmlNamespaceManager(document.NameTable)
        nsmgr.AddNamespace("ns", "http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition")
        nsmgr.AddNamespace("rd", "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner")
        Return nsmgr
    End Function

    Public Function DocumentPath() As String Implements IDocument.DocumentPath
        Return MasterOutputPath()
    End Function

    Public MustOverride Function ReportPath() As String

    Protected MustOverride Function PrepareDocument(ByRef directors As List(Of DocumentDirector), ByRef reportNames As List(Of String)) As BusinessErrors

    Protected MustOverride Function MasterOutputPath() As String

    Public Overridable Function Print(ByRef directors As List(Of DocumentDirector)) As BusinessErrors
        Dim errors As New BusinessErrors
        Dim stream As New FileStream(MasterOutputPath(), FileMode.Create)
        errors.Add(PrepareDocument(directors, _reportNames))
        If Not errors.HasError Then
            errors.Add(InsertSubreports())
            Try
                Dim _writer As XmlTextWriter = New XmlTextWriter(stream, Text.Encoding.UTF8)
                _xmlLayout.WriteTo(_writer)
                _writer.Close()
            Catch ex As Exception
                Utils.FillErrors(errors, ex)
            End Try
        End If
        Return errors
    End Function
End Class
