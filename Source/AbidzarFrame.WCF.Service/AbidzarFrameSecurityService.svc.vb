Imports AbidzarFrame.Security
Imports AbidzarFrame.Security.Interface
Imports AbidzarFrame.Core.Model.Business
Imports System.ServiceModel.Activation
Imports AbidzarFrame.Security.Manager

<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Required)>
<ServiceBehavior(InstanceContextMode:=InstanceContextMode.PerCall)>
Public Class AbidzarFrameSecurityService
    Inherits SecurityManager
    Implements ISecurityManager

    Public Sub New()
        MyBase.New()
        'ModelConfigurationSetting.DocumentLocation = DocumentConfiguration.GetInstance.ConfigFilePath
        ModelConfigurationSetting.ConfigurationLocation = WcfConfiguration.GetInstance.ConfigFilePath

        With Properties.Settings.Default
            .Save()
        End With

    End Sub

End Class
