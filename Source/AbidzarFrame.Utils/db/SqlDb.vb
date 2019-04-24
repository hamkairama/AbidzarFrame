Imports AbidzarFrame.Core.Model.Business


Public Class SqlDb
    Inherits SqlSrvDbFactory

    Public Overrides Function DefaultCredential() As Core.Model.Business.IDbCredential
        'Return New DbCredential("Abitech", "Abitech", "Abitech", "Initial Catalog={2};User ID={0}; Password={1}; Data Source=Abitech")
        'Return New DbCredential("Abitech", "Abitech ", "User ID={0}; Password={1}; Data Source=Abitech")
    End Function

    Public Overrides Sub SetConnectionSettingPath()
        Me.ConnectionSettingPath = BusinessModelSetting.GetInstance().Parameters(BusinessModelSetting.DEFAULT_DATABASE_SETTING_PATH)
    End Sub

End Class
