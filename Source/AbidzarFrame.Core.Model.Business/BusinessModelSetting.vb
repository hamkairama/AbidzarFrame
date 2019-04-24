Imports System
Imports System.Collections
Imports System.Text
Imports System.Configuration
Imports System.Xml

Public Class BusinessModelSetting
    Inherits ModelConfigurationSetting

    Public Const DEFAULT_DATABASE_SETTING_PATH = "DEFAULT_DATABASE_SETTING_PATH"
    Public Const DATABASE_ENCRYPTION_KEY = "DATABASE_ENCRYPTION_KEY"
    'Public Const OFFLINE_SPIS_INSTALLATION_PATH = "OFFLINE_SPIS_INSTALLATION_PATH"
    Public Const STATE_SERVICE_PROVIDER = "STATE_SERVICE_PROVIDER"
    'Public Const CHAT_SERVICE_PROVIDER = "CHAT_SERVICE_PROVIDER"
    Public Const PDF_SOURCE_PATH = "PDF_SOURCE_PATH"
    Public Const PDF_SOURCE_OUTPUT = "PDF_SOURCE_OUTPUT"
    Public Const PDF_SOURCE_FAIL_OUTPUT = "PDF_SOURCE_FAIL_OUTPUT"
    Public Const TRANSFER_CERTIFICATE_URL = "TRANSFER_CERTIFICATE_URL"
    Protected Shared instance As BusinessModelSetting = Nothing

    Public Const PREPRINT_FORM_PRINT_ENGINE_NAMESPACE = "PREPRINT_FORM_PRINT_ENGINE_NAMESPACE"
    Public Const PREPRINT_FORM_PRINT_ENGINE_CLASSNAME = "PREPRINT_FORM_PRINT_ENGINE_CLASSNAME"

    Public Shared Function GetInstance() As BusinessModelSetting
        If instance Is Nothing Then
            instance = New BusinessModelSetting
        End If
        Return instance
    End Function

    Protected Overrides Sub InitDefaultSetting()
        AddParameter(DEFAULT_DATABASE_SETTING_PATH, "D:/Hamka/GitHub/AbidzarFrame/Source/AbidzarFrame.API.Service/AppSetting/Db/")
        AddParameter(DATABASE_ENCRYPTION_KEY, "4426552i")
        AddParameter(STATE_SERVICE_PROVIDER, "AbidzarFrame.Core.Model.StateProvider.Web.WebStateProvider")
        AddParameter(PDF_SOURCE_PATH, "D:/Hamka/GitHub/AbidzarFrame/Documents/")
        AddParameter(PDF_SOURCE_OUTPUT, "D:\Hamka\GitHub\AbidzarFrame\output\")
        AddParameter(TRANSFER_CERTIFICATE_URL, "http://10.244.33.13:8081/id-danamon-eapplication-dev/api/eApplicationService/TransferPolicyCertificateDanamon")

        'AddParameter(OFFLINE_SPIS_INSTALLATION_PATH, "\AbidzarFrame\SPISOffline\") 'production
        'AddParameter(OFFLINE_SPIS_INSTALLATION_PATH, "\SVN\") ' development
    End Sub

End Class
