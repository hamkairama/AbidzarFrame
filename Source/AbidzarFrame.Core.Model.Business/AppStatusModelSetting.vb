Imports System
Imports System.Collections
Imports System.Text
Imports System.Configuration
Imports System.Xml

Public Class AppStatusModelSetting


    Public Const Save_as_draft = "00"
    Public Const Pending_eApps_before_complete = "01"
    Public Const Complete_eApps = "02"
    Public Const Pending_documents_after_submission = "03"

    Public Const Success_copy_data_to_eapps_Online = "10"
    Public Const Failed_copy_data_to_eapps_Online = "11"
    Public Const Sucessfully_upload_document = "12"
    Public Const Failed_Upload_document = "13"
    Public Const sucessfully_submitted_to_CAS = "14"
    Public Const Failed_submitted_to_CAS = "15"
    Public Const sucessfully_trigger_BPM = "16"
    Public Const Failed_trigger_BPM = "17"
    Public Const sucessfully_upload_new_document = "18"
    Public Const Failed_upload_new_document = "19"
    Public Const Sent_to_UW = "20"


    Public Const Step_0 = "0"
    Public Const Step_1 = "1"
    Public Const Step_2 = "2"
    Public Const Step_3 = "3"
    Public Const Step_4 = "4"
    Public Const Step_5 = "5"

End Class
