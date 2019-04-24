Public Class ObservableBase(Of T)
    Implements IObservable(Of T)

    Private _observers As List(Of IObserver(Of T))

    Public Sub New()
        _observers = New List(Of IObserver(Of T))

    End Sub

    Protected Sub Notify(ByRef subject As T)
        For Each _observer In _observers
            _observer.OnNext(subject)
        Next

    End Sub

    Public Overridable Function Subscribe(ByVal observer As System.IObserver(Of T)) As System.IDisposable Implements System.IObservable(Of T).Subscribe
        If Not _observers.Contains(observer) Then
            _observers.Add(observer)
        End If
        Return New UnSubscriber(_observers, observer)

    End Function

    Private Class UnSubscriber
        Implements IDisposable

        Private _observers As List(Of IObserver(Of T))
        Private _observer As IObserver(Of T)

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls
        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).

                    If Me._observer IsNot Nothing Then
                        Me._observers.Remove(Me._observer)
                    End If
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
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

        Public Sub New(ByRef observers As List(Of IObserver(Of T)), ByRef observer As IObserver(Of T))
            Me._observers = observers
            Me._observer = observer

        End Sub



    End Class

End Class
