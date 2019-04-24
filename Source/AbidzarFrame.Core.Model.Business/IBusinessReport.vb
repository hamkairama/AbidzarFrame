Imports System.IO

Public Interface IBusinessReport

    Function Print(ByVal printData As PrintingParameters, ByRef output As Byte()) As BusinessErrors

End Interface
