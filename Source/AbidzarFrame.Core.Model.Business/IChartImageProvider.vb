Imports System.IO

Public Interface IChartImageProvider

    Function CreateChartData() As ChartDataBase

    Function GenerateChartImage(ByVal chartData As ChartDataBase, ByRef output As Stream) As BusinessErrors

    Sub SetSize(ByVal height As Integer, ByVal width As Integer)

End Interface
