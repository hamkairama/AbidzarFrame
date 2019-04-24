Imports AbidzarFrame.Core.Model.Business
Imports System.Runtime.Serialization

<DataContract()>
<Serializable()>
Public Class ErrorMessages
    Inherits AbidzarFrame.Core.Model.Business.ErrorMessages


#Region "Common Internal Erros"
    Public Const ERR_AUTH As String = "E200001"
    Public Const ERR_UNKNOWN As String = "99999"
    Public Const ERR_TIMEOUT As String = "E200008"
    Public Const ERR_EXCEPTION As String = "E200009"
    Public Const ERR_SQL_EXCEPTION As String = "E200010"

    <DataMember()>
    Public Shared ReadOnly AUTH_ERROR As BusinessErrorVo = New BusinessErrorVo(ERR_AUTH, "",
        New BusinessMessageContent("en", "Unauthorized access."),
            New BusinessMessageContent("id", "Akses tidak sah."))

    <DataMember()>
    Public Shared ReadOnly UNKNOWN_ERROR As BusinessErrorVo = New BusinessErrorVo(ERR_UNKNOWN, "",
       New BusinessMessageContent("en", "Unknown Error"),
       New BusinessMessageContent("id", "Error tidak dikenal"))

    <DataMember()>
    Public Shared ReadOnly TIMEOUT_ERROR As BusinessErrorVo = New BusinessErrorVo(ERR_TIMEOUT, "",
       New BusinessMessageContent("en", "Timeout Error"),
       New BusinessMessageContent("id", "Waktu habis"))

    <DataMember()>
    Public Shared ReadOnly EXCEPTION_ERROR As BusinessErrorVo = New BusinessErrorVo(ERR_EXCEPTION, "",
       New BusinessMessageContent("en", "Exception Error"),
       New BusinessMessageContent("id", "Error pengecualian"))

    <DataMember()>
    Public Shared ReadOnly SQL_EXCEPTION_ERROR As BusinessErrorVo = New BusinessErrorVo(ERR_SQL_EXCEPTION, "",
       New BusinessMessageContent("en", "SQL Exception Error"),
       New BusinessMessageContent("id", "Error pengecualian pada SQL"))
#End Region

#Region "BOAJMI Internal Errors"
    Public Const ABIDZARFRAME_AD_NOT_FOUND_CD As String = "BO00001"
    Public Const ABIDZARFRAME_DATA_NOT_FOUND_CD As String = "BO00002"
    Public Const ABIDZARFRAME_USER_IN_ACTIVE_CD As String = "BO00003"
    Public Const ABIDZARFRAME_USER_NOT_SAME_CD As String = "BO00004"
    Public Const ABIDZARFRAME_DATA_ALREADY_EXIST_CD As String = "BO00005"
    Public Const ABIDZARFRAME_TIER_LIMIT_CD As String = "BO00006"
    Public Const ABIDZARFRAME_FUNDS_SELECT_CD As String = "BO00007"

    <DataMember()>
    Public Shared ReadOnly ABIDZARFRAME_AD_NOT_FOUND As BusinessErrorVo = New BusinessErrorVo(ABIDZARFRAME_AD_NOT_FOUND_CD, "",
       New BusinessMessageContent("en", "AD is not found"),
       New BusinessMessageContent("id", "AD tidak ditemukan"))

    <DataMember()>
    Public Shared ReadOnly ABIDZARFRAME_DATA_NOT_FOUND As BusinessErrorVo = New BusinessErrorVo(ABIDZARFRAME_DATA_NOT_FOUND_CD, "",
       New BusinessMessageContent("en", "Data is not found"),
       New BusinessMessageContent("id", "Data tidak ditemukan"))

    <DataMember()>
    Public Shared ReadOnly ABIDZARFRAME_USER_IN_ACTIVE As BusinessErrorVo = New BusinessErrorVo(ABIDZARFRAME_USER_IN_ACTIVE_CD, "",
       New BusinessMessageContent("en", "User inactive. Need approve by approver or contact your administrator for further info"),
       New BusinessMessageContent("id", "User belum aktif. Menunggu approve atau hubungi administrator untuk info lebih lanjut"))

    <DataMember()>
    Public Shared ReadOnly ABIDZARFRAME_USER_NOT_SAME As BusinessErrorVo = New BusinessErrorVo(ABIDZARFRAME_USER_NOT_SAME_CD, "",
       New BusinessMessageContent("en", "User credential not registered in your domain computer"),
       New BusinessMessageContent("id", "User tidak terdaftar di komputer anda"))

    <DataMember()>
    Public Shared ReadOnly ABIDZARFRAME_DATA_ALREADY_EXIST As BusinessErrorVo = New BusinessErrorVo(ABIDZARFRAME_DATA_ALREADY_EXIST_CD, "",
       New BusinessMessageContent("en", "Data already exist"),
       New BusinessMessageContent("id", "Data sudah ada"))

    <DataMember()>
    Public Shared ReadOnly ABIDZARFRAME_TIER_LIMIT As BusinessErrorVo = New BusinessErrorVo(ABIDZARFRAME_TIER_LIMIT_CD, "",
       New BusinessMessageContent("en", "Set the last limit as 99,999,999,999,999"),
       New BusinessMessageContent("id", "Masukan batas akhir : 99,999,999,999,999"))

    <DataMember()>
    Public Shared ReadOnly ABIDZARFRAME_FUNDS_SELECT As BusinessErrorVo = New BusinessErrorVo(ABIDZARFRAME_FUNDS_SELECT_CD, "",
       New BusinessMessageContent("en", "No Funds to select"),
       New BusinessMessageContent("id", "Tidak ada Funds yang dipilih"))



#End Region

#Region "IP1 Internal Errors"
    Public Const IP1CD_MSG_NOT_SERVICE_HOUR As String = "E200010"
    <DataMember()>
    Public Shared ReadOnly IP1_NOT_SERVICE_HOUR As BusinessErrorVo = New BusinessErrorVo(IP1CD_MSG_NOT_SERVICE_HOUR, "",
       New BusinessMessageContent("en", "Submit not allowed out of Service Hours"),
       New BusinessMessageContent("id", "Submit tidak di izinkan diluar jam kerja"))

#End Region

#Region "IP2 Internal Errors"
    '<DataMember()>
    'Public Shared ReadOnly IP2I_DB_ERROR As BusinessErrorVo = New BusinessErrorVo("E22001", "",
    '   New BusinessMessageContent("en", "Error getting certificate data"),
    '   New BusinessMessageContent("id", "Error mendapatkan data sertifikat"))

    <DataMember()>
    Public Shared ReadOnly IP2I_TIMEOUT_ERROR As BusinessErrorVo = New BusinessErrorVo("E22004", "",
       New BusinessMessageContent("en", "Error timeout calling External WS"),
       New BusinessMessageContent("id", "Error timeout memanggil WS Eksternal"))

    <DataMember()>
    Public Shared ReadOnly IP2I_UNKNOWN_ERROR As BusinessErrorVo = New BusinessErrorVo("E22000", "",
       New BusinessMessageContent("en", "Unknown Error in IP2 Internal WS"),
       New BusinessMessageContent("id", "Error tidak dikenal di WS Internal IP2"))

#End Region

#Region "IP3 Internal Errors"
    <DataMember()>
    Public Shared ReadOnly IP3I_GET_DATA_ERROR As BusinessErrorVo = New BusinessErrorVo("E23001", "",
       New BusinessMessageContent("en", "Error getting certificate data"),
       New BusinessMessageContent("id", "Error mendapatkan data sertifikat"))

    <DataMember()>
    Public Shared ReadOnly IP3I_GEN_CERT_ERROR As BusinessErrorVo = New BusinessErrorVo("E23002", "",
       New BusinessMessageContent("en", "Error generating certificate"),
       New BusinessMessageContent("id", "Error membentuk sertifikat"))

    <DataMember()>
    Public Shared ReadOnly IP3I_IEDMS_ERROR As BusinessErrorVo = New BusinessErrorVo("E23003", "",
       New BusinessMessageContent("en", "Error send to IEDMS"),
       New BusinessMessageContent("id", "Error mengirim ke IEDMS"))

    <DataMember()>
    Public Shared ReadOnly IP3I_EXTERNAL_TIMEOUT_ERROR As BusinessErrorVo = New BusinessErrorVo("E23004", "",
       New BusinessMessageContent("en", "Error timeout calling External WS"),
       New BusinessMessageContent("id", "Error timeout memanggil WS Eksternal"))

    <DataMember()>
    Public Shared ReadOnly IP3I_INTERNAL_UNKNOWN_ERROR As BusinessErrorVo = New BusinessErrorVo("E23000", "",
       New BusinessMessageContent("en", "Unknown Error in IP3 Internal WS"),
       New BusinessMessageContent("id", "Error tidak dikenal di WS Internal IP3"))
#End Region

#Region "IP4 Internal Errors"
    Public Const IP4CD_MSG_APPLICATION_NOTEXISTS As String = "E240009"
    Public Const IP4CD_MSG_FILE_CORRUPTED As String = "E240001"
    Public Const IP4CD_MSG_FAIL_UNZIPDECRYT As String = "E240002"
    Public Const IP4CD_MSG_FAIL_GENERATE_ACK As String = "E240003"
    Public Const IP4CD_MSG_FAIL_SEND_IEDMS As String = "E240005"
    Public Const IP4CD_MSG_INTERNALWS_ERROR As String = "E240006"
    Public Const IP4CD_MSG_CANNOTREAD_JSON As String = "E240008"
    Public Const IP4CD_DNBatchErrorCorupt As String = "Corrupted"
    Public Const IP4CD_DNBatchErrorOthers As String = "Others"

    <DataMember()>
    Public Shared ReadOnly IP4_MSG_FILE_CORRUPTED As BusinessErrorVo = New BusinessErrorVo(IP4CD_MSG_FILE_CORRUPTED, "",
      New BusinessMessageContent("en", "File Corrupted"),
      New BusinessMessageContent("id", "File rusak"))

    <DataMember()>
    Public Shared ReadOnly IP4_MSG_FAIL_UNZIPDECRYT As BusinessErrorVo = New BusinessErrorVo(IP4CD_MSG_FAIL_UNZIPDECRYT, "",
       New BusinessMessageContent("en", "MLI fail to unzip/decryted the uploaded content"),
       New BusinessMessageContent("id", "MLI gagal unzip/decryted konten file"))

    <DataMember()>
    Public Shared ReadOnly IP4_MSG_FAIL_GENERATE_ACK As BusinessErrorVo = New BusinessErrorVo(IP4CD_MSG_FAIL_GENERATE_ACK, "",
       New BusinessMessageContent("en", "MLI fail to generate acknowledgement"),
       New BusinessMessageContent("id", "MLI gagal generate ack"))

    <DataMember()>
    Public Shared ReadOnly IP4_MSG_FAIL_SEND_IEDMS As BusinessErrorVo = New BusinessErrorVo(IP4CD_MSG_FAIL_SEND_IEDMS, "",
       New BusinessMessageContent("en", "MLI iEDMS error"),
       New BusinessMessageContent("id", "MLI Gagal kirim ke IEDMS"))

    <DataMember()>
    Public Shared ReadOnly IP4_MSG_INTERNALWS_ERROR As BusinessErrorVo = New BusinessErrorVo(IP4CD_MSG_INTERNALWS_ERROR, "",
       New BusinessMessageContent("en", "MLI internal webservice Error"),
       New BusinessMessageContent("id", "MLI internal webservice Error"))


    <DataMember()>
    Public Shared ReadOnly IP4_MSG_CANNOTREAD_JSON As BusinessErrorVo = New BusinessErrorVo(IP4CD_MSG_CANNOTREAD_JSON, "",
       New BusinessMessageContent("en", "Cannot Read JSON File"),
       New BusinessMessageContent("id", "JSON File tidak bisa di baca"))

    <DataMember()>
    Public Shared ReadOnly IP4_MSG_APPLICATION_NOTEXISTS As BusinessErrorVo = New BusinessErrorVo(IP4CD_MSG_APPLICATION_NOTEXISTS, "",
       New BusinessMessageContent("en", "Application Number is not exists."),
       New BusinessMessageContent("id", "Application Number tidak ada"))

    <DataMember()>
    Public Shared ReadOnly IP1_MSG_CANNOTREAD_JSON_TBL As BusinessErrorVo = New BusinessErrorVo("00001", "",
       New BusinessMessageContent("en", "Error Read JSON Table"),
       New BusinessMessageContent("id", "Error baca Table JSON"))
#End Region

#Region "SQL Errors"
    Public Const SQL_LDB_TBL_NOT_DROP_CD As String = "SQL01500"
    Public Const SQL_UPD_DEL_AFFECT_ENTIRE_CD As String = "SQL01501"
    Public Const SQL_CONTEXT_MISMATCH_CD As String = "SQL07500"
    Public Const SQL_LDB_UNAVAILABLE_CD As String = "SQL08500"
    Public Const SQL_INVALID_QUERY_LANGUANGE_CD As String = "SQL0A500"
    Public Const SQL_INVALID_DATA_TYPE_CD As String = "SQL22500"
    Public Const SQL_TABLE_NOT_FOUND_CD As String = "SQL2A500"
    Public Const SQL_COLUMN_NOT_FOUND_CD As String = "SQL2A501"
    Public Const SQL_DUPLICATE_OBJECT_NAME_CD As String = "SQL2A502"
    Public Const SQL_INSUFFICATE_PRIVILEGE_CD As String = "SQL2A503"
    Public Const SQL_CURSOR_NOT_FOUND_CD As String = "SQL2A504"
    Public Const SQL_OBJECT_NOT_FOUND_CD As String = "SQL2A505"
    Public Const SQL_INVALID_IDENTIFIER_CD As String = "SQL2A506"
    Public Const SQL_RESERVED_IDENTIFIER_CD As String = "SQL2A507"
    Public Const SQL_MISC_SPECIFIC_ERR_CD As String = "SQL50000"
    Public Const SQL_INVALID_DUPLICATE_ROW_CD As String = "SQL50001"
    Public Const SQL_LIMIT_EXCEED_CD As String = "SQL50002"
    Public Const SQL_RESOURCE_EXHAUSTED_CD As String = "SQL50003"
    Public Const SQL_SYSTEM_CONFIG_ERR_CD As String = "SQL50004"
    Public Const SQL_ENTERPRISE_ACCESS_PRODUCT_CD As String = "SQL50005"
    Public Const SQL_FATAL_ERR_CD As String = "SQL50006"
    Public Const SQL_INVALID_STAT_ID_CD As String = "SQL50007"
    Public Const SQL_UNSUPPORTED_STAT_CD As String = "SQL50008"
    Public Const SQL_DB_PROC_ERR_CD As String = "SQL50009"
    Public Const SQL_QUERY_ERR_CD As String = "SQL5000A"
    Public Const SQL_INTERNAL_ERR_CD As String = "SQL5000B"
    Public Const SQL_INVALID_CURSOR_NAME_CD As String = "SQL5000D"
    Public Const SQL_DUPLICATE_STAT_ID_CD As String = "SQL5000E"
    Public Const SQL_TEXTUAL_INFORMATION_CD As String = "SQL5000F"
    Public Const SQL_DB_PROC_MSG_CD As String = "SQL5000G"
    Public Const SQL_UNKNOWN_RESOURCE_CD As String = "SQL5000H"
    Public Const SQL_UNEXPECTED_LDB_SCH_CHANGE_CD As String = "SQL5000I"
    Public Const SQL_INCONSISTENT_DBMS_CATALOG_CD As String = "SQL5000J"
    Public Const SQL_SQLSTATE_STATUS_UNAVAILABLE_CD As String = "SQL5000K"
    Public Const SQL_PROTOCOL_ERR_CD As String = "SQL5000L"
    Public Const SQL_IPC_ERR_CD As String = "SQL5000M"


    <DataMember()>
    Public Shared ReadOnly SQL_LDB_TBL_NOT_DROP As BusinessErrorVo = New BusinessErrorVo(SQL_LDB_TBL_NOT_DROP_CD, "",
       New BusinessMessageContent("en", "LDB Table not dropped"),
       New BusinessMessageContent("id", "Tabel LDB tidak dihapus"))

    <DataMember()>
    Public Shared ReadOnly SQL_UPD_DEL_AFFECT_ENTIRE As BusinessErrorVo = New BusinessErrorVo(SQL_UPD_DEL_AFFECT_ENTIRE_CD, "",
      New BusinessMessageContent("en", "Update or delete affects entire table"),
      New BusinessMessageContent("id", "Edit atau hapus dapat mempengaruhi seluruh tabel"))

    <DataMember()>
    Public Shared ReadOnly SQL_CONTEXT_MISMATCH As BusinessErrorVo = New BusinessErrorVo(SQL_CONTEXT_MISMATCH_CD, "",
      New BusinessMessageContent("en", "Context mismatch"),
      New BusinessMessageContent("id", "Konteks tidak cocok"))

    <DataMember()>
    Public Shared ReadOnly SQL_LDB_UNAVAILABLE As BusinessErrorVo = New BusinessErrorVo(SQL_LDB_UNAVAILABLE_CD, "",
      New BusinessMessageContent("en", "LDB is unavailable"),
      New BusinessMessageContent("id", "LDB tidak tersedia"))

    <DataMember()>
    Public Shared ReadOnly SQL_INVALID_QUERY_LANGUANGE As BusinessErrorVo = New BusinessErrorVo(SQL_INVALID_QUERY_LANGUANGE_CD, "",
      New BusinessMessageContent("en", "Invalid query languange"),
      New BusinessMessageContent("id", "Bahasa query tidak valid"))

    <DataMember()>
    Public Shared ReadOnly SQL_INVALID_DATA_TYPE As BusinessErrorVo = New BusinessErrorVo(SQL_INVALID_DATA_TYPE_CD, "",
      New BusinessMessageContent("en", "Invalid data type"),
      New BusinessMessageContent("id", "Tipe data tidak valid"))

    <DataMember()>
    Public Shared ReadOnly SQL_TABLE_NOT_FOUND As BusinessErrorVo = New BusinessErrorVo(SQL_TABLE_NOT_FOUND_CD, "",
      New BusinessMessageContent("en", "Table not found"),
      New BusinessMessageContent("id", "tabel tidak ditemukan"))

    <DataMember()>
    Public Shared ReadOnly SQL_COLUMN_NOT_FOUND As BusinessErrorVo = New BusinessErrorVo(SQL_COLUMN_NOT_FOUND_CD, "",
      New BusinessMessageContent("en", "Column not found"),
      New BusinessMessageContent("id", "Kolom tidak ditemukan"))

    <DataMember()>
    Public Shared ReadOnly SQL_DUPLICATE_OBJECT_NAME As BusinessErrorVo = New BusinessErrorVo(SQL_DUPLICATE_OBJECT_NAME_CD, "",
      New BusinessMessageContent("en", "Duplicate object name"),
      New BusinessMessageContent("id", "Nama objek duplikat"))

    <DataMember()>
    Public Shared ReadOnly SQL_INSUFFICATE_PRIVILEGE As BusinessErrorVo = New BusinessErrorVo(SQL_INSUFFICATE_PRIVILEGE_CD, "",
      New BusinessMessageContent("en", "Insufficate privilege"),
      New BusinessMessageContent("id", "Tidak cukup hak akses"))

    <DataMember()>
    Public Shared ReadOnly SQL_CURSOR_NOT_FOUND As BusinessErrorVo = New BusinessErrorVo(SQL_CURSOR_NOT_FOUND_CD, "",
      New BusinessMessageContent("en", "Cursor not found"),
      New BusinessMessageContent("id", "Indikator posisi tidak ditemukan"))

    <DataMember()>
    Public Shared ReadOnly SQL_OBJECT_NOT_FOUND As BusinessErrorVo = New BusinessErrorVo(SQL_OBJECT_NOT_FOUND_CD, "",
      New BusinessMessageContent("en", "Object not found"),
      New BusinessMessageContent("id", "Objek tidak ditemukan"))

    <DataMember()>
    Public Shared ReadOnly SQL_INVALID_IDENTIFIER As BusinessErrorVo = New BusinessErrorVo(SQL_INVALID_IDENTIFIER_CD, "",
      New BusinessMessageContent("en", "Invalid identifier"),
      New BusinessMessageContent("id", "Tanda pengenal tidak valid"))

    <DataMember()>
    Public Shared ReadOnly SQL_MISC_SPECIFIC_ERR As BusinessErrorVo = New BusinessErrorVo(SQL_MISC_SPECIFIC_ERR_CD, "",
      New BusinessMessageContent("en", "Miscellaneous specific errors"),
      New BusinessMessageContent("id", "Berbagai macam kesalahan yang spesifik"))

    <DataMember()>
    Public Shared ReadOnly SQL_INVALID_DUPLICATE_ROW As BusinessErrorVo = New BusinessErrorVo(SQL_INVALID_DUPLICATE_ROW_CD, "",
      New BusinessMessageContent("en", "Invalid duplicate row"),
      New BusinessMessageContent("id", "Baris yang duplikat tidak valid"))

    <DataMember()>
    Public Shared ReadOnly SQL_LIMIT_EXCEED As BusinessErrorVo = New BusinessErrorVo(SQL_LIMIT_EXCEED_CD, "",
      New BusinessMessageContent("en", "Limit has been exceeded"),
      New BusinessMessageContent("id", "Batas telah terlewati"))

    <DataMember()>
    Public Shared ReadOnly SQL_RESOURCE_EXHAUSTED As BusinessErrorVo = New BusinessErrorVo(SQL_RESOURCE_EXHAUSTED_CD, "",
      New BusinessMessageContent("en", "Resource exhausted"),
      New BusinessMessageContent("id", "Sumber daya habis"))

    <DataMember()>
    Public Shared ReadOnly SQL_SYSTEM_CONFIG_ERR As BusinessErrorVo = New BusinessErrorVo(SQL_SYSTEM_CONFIG_ERR_CD, "",
      New BusinessMessageContent("en", "System configuration error"),
      New BusinessMessageContent("id", "Kesalahan konfigurasi sistem"))

    <DataMember()>
    Public Shared ReadOnly SQL_ENTERPRISE_ACCESS_PRODUCT As BusinessErrorVo = New BusinessErrorVo(SQL_ENTERPRISE_ACCESS_PRODUCT_CD, "",
      New BusinessMessageContent("en", "Enterprise access product related error"),
      New BusinessMessageContent("id", "Kesalahan terkait akses produk perusahaan"))

    <DataMember()>
    Public Shared ReadOnly SQL_FATAL_ERR As BusinessErrorVo = New BusinessErrorVo(SQL_FATAL_ERR_CD, "",
      New BusinessMessageContent("en", "Fatal error"),
      New BusinessMessageContent("id", "Kesalahan fatal"))

    <DataMember()>
    Public Shared ReadOnly SQL_INVALID_STAT_ID As BusinessErrorVo = New BusinessErrorVo(SQL_INVALID_STAT_ID_CD, "",
      New BusinessMessageContent("en", "Invalid SQL Statement ID"),
      New BusinessMessageContent("id", "Pernyataan ID pada SQL tidak valid"))

    <DataMember()>
    Public Shared ReadOnly SQL_UNSUPPORTED_STAT As BusinessErrorVo = New BusinessErrorVo(SQL_UNSUPPORTED_STAT_CD, "",
      New BusinessMessageContent("en", "Unsupported statement"),
      New BusinessMessageContent("id", "Pernyataan tidak didukung"))

    <DataMember()>
    Public Shared ReadOnly SQL_DB_PROC_ERR As BusinessErrorVo = New BusinessErrorVo(SQL_DB_PROC_ERR_CD, "",
      New BusinessMessageContent("en", "Database procedure error raised"),
      New BusinessMessageContent("id", "Kesalahan aturan database meningkat"))

    <DataMember()>
    Public Shared ReadOnly SQL_QUERY_ERR As BusinessErrorVo = New BusinessErrorVo(SQL_QUERY_ERR_CD, "",
      New BusinessMessageContent("en", "Query error"),
      New BusinessMessageContent("id", "Kesalahan query"))

    <DataMember()>
    Public Shared ReadOnly SQL_INTERNAL_ERR As BusinessErrorVo = New BusinessErrorVo(SQL_INTERNAL_ERR_CD, "",
      New BusinessMessageContent("en", "Internal error"),
      New BusinessMessageContent("id", "Kesalahan internal"))

    <DataMember()>
    Public Shared ReadOnly SQL_INVALID_CURSOR_NAME As BusinessErrorVo = New BusinessErrorVo(SQL_INVALID_CURSOR_NAME_CD, "",
      New BusinessMessageContent("en", "Invalid cursor name"),
      New BusinessMessageContent("id", "Nama kursor tidak valid"))

    <DataMember()>
    Public Shared ReadOnly SQL_DUPLICATE_STAT_ID As BusinessErrorVo = New BusinessErrorVo(SQL_DUPLICATE_STAT_ID_CD, "",
      New BusinessMessageContent("en", "Duplicate SQL statement ID"),
      New BusinessMessageContent("id", "Pernyataan ID SQL duplikat"))

    <DataMember()>
    Public Shared ReadOnly SQL_TEXTUAL_INFORMATION As BusinessErrorVo = New BusinessErrorVo(SQL_TEXTUAL_INFORMATION_CD, "",
      New BusinessMessageContent("en", "Textual information"),
      New BusinessMessageContent("id", "Informasi tekstual"))

    <DataMember()>
    Public Shared ReadOnly SQL_DB_PROC_MSG As BusinessErrorVo = New BusinessErrorVo(SQL_DB_PROC_MSG_CD, "",
      New BusinessMessageContent("en", "Database procedure message"),
      New BusinessMessageContent("id", "Pesan pernyataan database"))

    <DataMember()>
    Public Shared ReadOnly SQL_UNKNOWN_RESOURCE As BusinessErrorVo = New BusinessErrorVo(SQL_UNKNOWN_RESOURCE_CD, "",
      New BusinessMessageContent("en", "Unknown/unavailable resource"),
      New BusinessMessageContent("id", "Sumber daya tidak diketahui"))

    <DataMember()>
    Public Shared ReadOnly SQL_UNEXPECTED_LDB_SCH_CHANGE As BusinessErrorVo = New BusinessErrorVo(SQL_UNEXPECTED_LDB_SCH_CHANGE_CD, "",
      New BusinessMessageContent("en", "Unexpected LDB schema change"),
      New BusinessMessageContent("id", "Perubahan skema LDB tidak terduga"))

    <DataMember()>
    Public Shared ReadOnly SQL_INCONSISTENT_DBMS_CATALOG As BusinessErrorVo = New BusinessErrorVo(SQL_INCONSISTENT_DBMS_CATALOG_CD, "",
      New BusinessMessageContent("en", "Inconsistent DBMS catalog"),
      New BusinessMessageContent("id", "Katalog DBMS tidak konsisten"))

    <DataMember()>
    Public Shared ReadOnly SQL_SQLSTATE_STATUS_UNAVAILABLE As BusinessErrorVo = New BusinessErrorVo(SQL_SQLSTATE_STATUS_UNAVAILABLE_CD, "",
      New BusinessMessageContent("en", "SQLSTATE status code unavailable"),
      New BusinessMessageContent("id", "Kode status SQLSTATE tidak tersedia"))

    <DataMember()>
    Public Shared ReadOnly SQL_PROTOCOL_ERR As BusinessErrorVo = New BusinessErrorVo(SQL_PROTOCOL_ERR_CD, "",
      New BusinessMessageContent("en", "Protocol error"),
      New BusinessMessageContent("id", "Kesalahan protokol"))

    <DataMember()>
    Public Shared ReadOnly SQL_IPC_ERR As BusinessErrorVo = New BusinessErrorVo(SQL_IPC_ERR_CD, "",
      New BusinessMessageContent("en", "IPC error"),
      New BusinessMessageContent("id", "Kesalahan IPC"))
#End Region

End Class

