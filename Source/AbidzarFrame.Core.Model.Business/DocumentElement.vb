Imports System.Xml
Imports AbidzarFrame.Core.Model.Business
Imports System.IO
Imports System.Globalization

Public MustInherit Class DocumentElement

    Private _language As String
    Private _startingRoot As String
    Private _xmlLayout As XmlDocument

    Protected Const INCH_TO_CM_RATE As Decimal = 2.54
    Protected Const ROUND_TO As Decimal = 1000

    Protected ReadOnly Property XmlLayout As XmlDocument
        Get
            Return _xmlLayout
        End Get
    End Property

    Protected ReadOnly Property StartingRoot As String
        Get
            Return _startingRoot
        End Get
    End Property

    Protected ReadOnly Property Language As String
        Get
            Return _language
        End Get
    End Property

    Public Sub New()
        Me.New("en")
    End Sub

    Public Sub New(ByVal language As String)
        _language = language
        Init(language, _startingRoot, _xmlLayout)
    End Sub

    Public MustOverride Function MoveElements(ByRef reportLength As Decimal) As BusinessErrors
    Public MustOverride Function ReportPath() As String

    Protected Overridable ReadOnly Property DefaultReportFileName As String
        Get
            Dim clsName As String = Me.GetType().Name
            Return clsName.Replace("Element", "") & ".rdlc"
        End Get
    End Property

    Protected Overridable Function Init(ByVal language As String, _
                                        ByRef startingRoot As String, _
                                        ByRef xmlLayout As XmlDocument) As BusinessErrors
        Dim errors As New BusinessErrors

        startingRoot = DefaultElementStartingRoot
        Try
            xmlLayout = New XmlDocument()
            xmlLayout.Load(Path.Combine(ReportPath(), language, DefaultReportFileName))
        Catch ex As Exception
            Utils.FillErrors(errors, ex)
        End Try
        Return errors

    End Function

    Protected Overridable ReadOnly Property DefaultElementStartingRoot As String
        Get
            Return "descendant::ns:Report/ns:Body/ns:ReportItems"
        End Get
    End Property

    Public Overridable Function AppendTo(ByRef output As XmlNode) As BusinessErrors
        Dim errors As New BusinessErrors
        Dim node As XmlNode = FindNode(_xmlLayout, _startingRoot)
        If node IsNot Nothing Then
            Dim copy = output.OwnerDocument.ImportNode(node, True)
            For Each item As XmlNode In copy.ChildNodes
                output.InsertAfter(item.CloneNode(True), output.LastChild)
            Next
        Else
            errors.Add(ErrorMessages.Msg_Print_Element_Starting_Root_Not_Found)
        End If
        Return errors
    End Function

    Protected Overridable Function FillValue(ByVal tagLocation As String, ByVal value As String) As BusinessErrors
        Dim errs As New BusinessErrors

        Dim node As XmlNode = FindNode(Me._xmlLayout, String.Concat(tagLocation, "/descendant::ns:Value"))
        If node IsNot Nothing Then
            node.InnerText = value
        Else
            errs.Add(ErrorMessages.Msg_Print_Node_Not_Found)
        End If

        Return errs
    End Function

    Protected Overridable Function GetValue(ByVal tagLocation As String) As String
        Dim node As XmlNode = FindNode(Me._xmlLayout, String.Concat(tagLocation, "/descendant::ns:Value"))
        If node IsNot Nothing Then
            Return node.InnerText
        End If
        Return ""
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

    Protected Overridable Function FindNodes(ByVal document As XmlDocument, ByVal findLocation As String) As XmlNodeList
        Dim nsmgr As XmlNamespaceManager = CreateNamespaceManager(document)
        Dim nodes As XmlNodeList = document.SelectNodes(findLocation, nsmgr)
        Return nodes
    End Function

    Private Function CreateNamespaceManager(ByVal document As XmlDocument) As XmlNamespaceManager
        Dim nsmgr As New XmlNamespaceManager(document.NameTable)
        nsmgr.AddNamespace("ns", "http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition")
        nsmgr.AddNamespace("rd", "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner")
        Return nsmgr
    End Function

    Protected Function SetLocation(ByVal nodePath As String, ByVal left As Decimal, ByVal top As Decimal) As BusinessErrors
        Dim errors As New BusinessErrors

        Dim x As XmlNode = FindNode(Me._xmlLayout, String.Concat(nodePath, "/descendant::ns:Left"))
        If x IsNot Nothing Then
            x.InnerText = left.ToString("N", New CultureInfo("en-US")) + "cm"
        Else
            errors.Add(ErrorMessages.Msg_Print_Node_Not_Found)
        End If

        Dim y As XmlNode = FindNode(Me._xmlLayout, String.Concat(nodePath, "/descendant::ns:Top"))
        If y IsNot Nothing Then
            y.InnerText = top.ToString("N", New CultureInfo("en-US")) + "cm"
        Else
            errors.Add(ErrorMessages.Msg_Print_Node_Not_Found)
        End If

        Return errors
    End Function

    Protected Overloads Function SetElementHeight(ByVal nodePath As String, ByVal height As Decimal) As BusinessErrors
        Dim errors As New BusinessErrors
        Dim node As XmlNode = FindNode(Me._xmlLayout, String.Concat(nodePath, "/ns:Height"))
        If node IsNot Nothing Then
            node.InnerText = height.ToString + "cm"
        Else
            errors.Add(ErrorMessages.Msg_Print_Node_Not_Found)
        End If
        Return errors
    End Function

    Protected Overloads Function GetElementHeight(ByVal nodePath As String) As Decimal
        Dim node As XmlNode = FindNode(Me._xmlLayout, String.Concat(nodePath, "/ns:Height"))
        If node IsNot Nothing Then
            If InStr(node.InnerText, "cm") Then
                Return Convert.ToDecimal(node.InnerText.Replace("cm", ""), New CultureInfo("en-US"))
            Else
                Return Convert.ToDecimal(node.InnerText.Replace("in", ""), New CultureInfo("en-US")) * INCH_TO_CM_RATE
            End If
        Else
            Return 0
        End If
    End Function

    Protected Overloads Function GetElementHeight(ByVal nodes As XmlNodeList) As Decimal
        Dim height As Decimal = 0
        For i = 0 To nodes.Count - 1
            If InStr(nodes(i).Item("Height").InnerText, "cm") Then
                height += Convert.ToDecimal(nodes(i).Item("Height").InnerText.Replace("cm", ""), New CultureInfo("en-US"))
            Else
                height += Convert.ToDecimal(nodes(i).Item("Height").InnerText.Replace("in", ""), New CultureInfo("en-US")) * INCH_TO_CM_RATE
            End If
        Next
        Return height
    End Function

    Protected Overloads Function GetElementWidth(ByVal nodePath As String) As Decimal
        Dim node As XmlNode = FindNode(Me._xmlLayout, String.Concat(nodePath, "/ns:Width"))
        If node IsNot Nothing Then
            If InStr(node.InnerText, "cm") Then
                Return Convert.ToDecimal(node.InnerText.Replace("cm", ""), New CultureInfo("en-US"))
            Else
                Return Convert.ToDecimal(node.InnerText.Replace("in", ""), New CultureInfo("en-US")) * INCH_TO_CM_RATE
            End If
        Else
            Return 0
        End If
    End Function

    Protected Overloads Function GetElementWidth(ByVal nodes As XmlNodeList) As Decimal
        Dim width As Decimal = 0
        For i = 0 To nodes.Count - 1
            If InStr(nodes(i).Item("Width").InnerText, "cm") Then
                width += Convert.ToDecimal(nodes(i).Item("Width").InnerText.Replace("cm", ""), New CultureInfo("en-US"))
            Else
                width += Convert.ToDecimal(nodes(i).Item("Width").InnerText.Replace("in", ""), New CultureInfo("en-US")) * INCH_TO_CM_RATE
            End If
        Next
        Return width
    End Function
End Class
