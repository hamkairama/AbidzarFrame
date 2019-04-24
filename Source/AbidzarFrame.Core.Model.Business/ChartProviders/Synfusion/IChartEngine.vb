Imports Syncfusion.Windows.Chart
Imports System.IO
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Media

Public Interface IChartEngine
    Inherits IDisposable

    ReadOnly Property Chart As Object

    ReadOnly Property Height As Integer

    ReadOnly Property Width As Integer

    Sub FillInDataSeries(ByVal chartData As ChartDataBase)

    Sub Save(ByRef out As Stream)

    Sub SetSize(ByVal height As Integer, ByVal width As Integer)

End Interface
