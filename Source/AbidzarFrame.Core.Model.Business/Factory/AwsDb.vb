Imports System.Data.OleDb
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Data

Public Class AwsDb
    Inherits OracleDbFactory

    Public Overrides Function DefaultCredential() As IDbCredential
        Return New DbCredential("aws", "aws", "User ID={0}; Password={1}; Data Source=VNDEV")
    End Function

    Public Overrides Sub SetConnectionSettingPath()
        Me.ConnectionSettingPath = BusinessModelSetting.GetInstance().Parameters(BusinessModelSetting.DEFAULT_DATABASE_SETTING_PATH)
    End Sub

End Class