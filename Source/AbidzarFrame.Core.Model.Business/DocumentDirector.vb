Imports System.IO
Imports AbidzarFrame.Core.Model.Business

Public MustInherit Class DocumentDirector
    Implements IDocument

    Private _builder As DocumentBuilder

    Protected Property Builder As DocumentBuilder
        Get
            Return _builder
        End Get
        Set(ByVal value As DocumentBuilder)
            _builder = value
        End Set
    End Property

    Public Sub New(ByRef builder As DocumentBuilder)
        _builder = builder
    End Sub

    Public Overridable Function Print(ByRef output As Stream) As BusinessErrors
        Dim errs As New BusinessErrors

        errs.Add(Builder.FillInElements())
        If (Not errs.HasError) Then
            errs.Add(Builder.CompileDocument())
        End If
        If (Not errs.HasError) Then
            errs.Add(Builder.PrintDocument(output))
        End If

        Return errs
    End Function

    Public MustOverride Function DocumentPath() As String Implements IDocument.DocumentPath
End Class
