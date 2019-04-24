Imports System.Runtime.Serialization
Imports AbidzarFrame.Core.Model.Business

<DataContract()> _
<Serializable()> _
Public Class LocalizedString
    Implements ICloneable, IDisposable

    <DataMember()> _
    Public Const DEFAULT_LOCALE = "en"

    <DataMember(name:="Value")> _
    Protected _stringTable As New Dictionary(Of String, String)

    Public Sub New()
        _stringTable = New Dictionary(Of String, String)
    End Sub

    Public Sub New(ByRef phraseTable As Dictionary(Of String, String))
        For Each i In phraseTable
            _stringTable.Add(i.Key, i.Value)
        Next

        '_stringTable = phraseTable
    End Sub

    Public Sub New(ByVal ParamArray phrases As LocalizedStringPhrase())
        For Each phrase In phrases
            Add(phrase)
        Next
    End Sub

    Public Sub Add(ByRef phrase As LocalizedStringPhrase)
        _stringTable.Add(phrase.Locale, phrase.StringPhrase)
    End Sub

    Public ReadOnly Property Value As Dictionary(Of String, String)
        Get
            Return _stringTable
        End Get
    End Property

    Public Function TryGet(ByVal lang As String) As String
        If _stringTable.ContainsKey(lang) Then
            Return _stringTable(lang)
        ElseIf _stringTable.Count > 0 Then
            Return _stringTable.First.Value
        End If

        Return Nothing
    End Function

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim c As New LocalizedString
        For Each p In Me._stringTable
            c._stringTable.Add(p.Key, p.Value)
        Next
        Return c
        'Return DirectCast(Me.MemberwiseClone, LocalizedString)
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
            Utils.ClearObject(_stringTable)

            _stringTable = Nothing
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(False)
        MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
