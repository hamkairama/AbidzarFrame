Public Class EnumList
#Region "Active directory"
    Public Enum FilterAdBy As Integer
        UserId = 0
        Email = 1
    End Enum

    Public Enum ActiveDirectoryBy As Integer
        REGISTRATION = 0
        APPROVERREGISTRATION = 1
    End Enum

#End Region

#Region "Common"
    Public Enum Status As Integer
        InActive = 0
        Active = 1
    End Enum
#End Region

    Public Enum RequestType As Integer
        USR = 0
        APV = 1
        ARC = 2
    End Enum

    Public Enum RequestStatus As Integer
        Submitted = 0
        Approved = 1
    End Enum
End Class
