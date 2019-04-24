' NOTE: You can use the "Rename" command on the context menu to change the class name "BOAJMIBondsService" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select BOAJMIBondsService.svc or BOAJMIBondsService.svc.vb at the Solution Explorer and start debugging.
Imports AbidzarFrame.Core.Model.Business
Imports System.ServiceModel.Activation
Imports AbidzarFrame.Master.Manager
Imports AbidzarFrame.Master.Interface
Imports AbidzarFrame.Master

<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Required)>
<ServiceBehavior(InstanceContextMode:=InstanceContextMode.PerCall)>
Public Class AbidzarFrameMasterService
    Inherits MasterManager
    Implements IMasterManager

    Public Sub New()
        MyBase.New()
        'ModelConfigurationSetting.DocumentLocation = DocumentConfiguration.GetInstance.ConfigFilePath
        ModelConfigurationSetting.ConfigurationLocation = WcfConfiguration.GetInstance.ConfigFilePath

        With Properties.Settings.Default
            .Save()
        End With

    End Sub

End Class
