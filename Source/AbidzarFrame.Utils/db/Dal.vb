﻿Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32
Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Configuration

Public Class dal
    Private mvar_conn As String
    Private mvar_return_val As String
    Private oConn As SqlConnection

    Public Property RETURN_VALU() As String
        Get
            Return Me.mvar_return_val
        End Get
        Set
            Me.mvar_return_val = Value
        End Set
    End Property

    Public Property p_constring() As String
        Get
            Return Me.mvar_conn
        End Get
        Set
            Me.mvar_conn = Value
        End Set
    End Property

    Private ReadOnly Property p_GetConStringRegistry() As Object
        Get
            Return DirectCast(Me.f_getConString(), Object)
        End Get
    End Property

    Public Sub New()
        Me.oConn = New SqlConnection()
    End Sub

    Protected Function WriteToEventLog(Entry As String, Optional AppName As String = "VB.NET Application", Optional EventType As EventLogEntryType = EventLogEntryType.Information, Optional LogName As String = "Application") As Boolean
        Dim eventLog__1 As New EventLog()
        Dim flag As Boolean
        Try
            If Not EventLog.SourceExists(AppName) Then
                EventLog.CreateEventSource(AppName, LogName)
            End If
            eventLog__1.Source = AppName
            eventLog__1.WriteEntry(Entry, EventType)
            flag = True
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function

    Protected Sub sbCloseConnection()
        If Me.oConn.State <> ConnectionState.Open Then
            Return
        End If
        Me.oConn.Close()
    End Sub

    Protected Sub sbPrepareParameters(ByRef cmd As SqlCommand, ArrL As ArrayList, ArrO As ArrayList)
        Dim num1 As Integer = 0
        Dim num2 As Integer = ArrL.Count - 1
        Dim index1 As Integer = num1
        While index1 <= num2
            Dim cArrayList As cArrayList = DirectCast(ArrL(index1), cArrayList)
            cmd.Parameters.AddWithValue(cArrayList.p_name, RuntimeHelpers.GetObjectValue(cArrayList.p_value))
            index1 += 1

        End While
        Dim num3 As Integer = 0
        Dim num4 As Integer = ArrO.Count - 1
        Dim index2 As Integer = num3
        While index2 <= num4
            Dim cArrayList As cArrayList = DirectCast(ArrO(index2), cArrayList)
            cmd.Parameters.Add(New SqlParameter() With {
                .Direction = ParameterDirection.Output,
                .ParameterName = cArrayList.p_name,
                .DbType = cArrayList.p_dbtype,
                .Size = cArrayList.p_size
            })
            index2 += 1

        End While
    End Sub

    Protected Sub sbPrepareParameters(ByRef cmd As SqlCommand, ArrL As ArrayList)
        Dim sqlParameter As New SqlParameter()
        Dim num1 As Integer = 0
        Dim num2 As Integer = ArrL.Count - 1
        Dim index As Integer = num1
        While index <= num2
            Dim cArrayList As cArrayList = DirectCast(ArrL(index), cArrayList)
            cmd.Parameters.AddWithValue(cArrayList.p_name, RuntimeHelpers.GetObjectValue(cArrayList.p_value))
            index += 1

        End While
        cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue
    End Sub

    Public Function fn_GetSQLDataReader(sSPName As String, ArrayL As ArrayList, ByRef dr As SqlDataReader) As Long
        Dim num1 As Long = 0
        Dim cmd As New SqlCommand()
        If Me.oConn.State = ConnectionState.Open Then
            Me.oConn.Close()
        Else
            Me.oConn = New SqlConnection(Conversions.ToString(Me.p_GetConStringRegistry))
            Try
                Me.oConn.Open()
            Catch ex As Exception
                ProjectData.SetProjectError(ex)
                Me.WriteToEventLog(ex.Message, "VB.NET Application", EventLogEntryType.Information, "Application")
                ProjectData.ClearProjectError()
                GoTo label_6
            End Try
        End If
        cmd.Connection = Me.oConn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = sSPName
        Me.sbPrepareParameters(cmd, ArrayL)
        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Dim num2 As Long = num1
label_6:
        Return num2
    End Function

    Public Function fn_AddRecordSP(sSPName As String, ByRef ArrayL As ArrayList, ByRef ArrayLOut As ArrayList) As Long
        Dim num1 As Long = 0
        Dim cmd As New SqlCommand()
        Dim sqlCommand As SqlCommand = cmd
        If Me.oConn.State = ConnectionState.Open Then
            Me.oConn.Close()
        Else
            Me.oConn = New SqlConnection(Conversions.ToString(Me.p_GetConStringRegistry))
            Try
                Me.oConn.Open()
            Catch ex As Exception
                ProjectData.SetProjectError(ex)
                Me.WriteToEventLog(ex.Message, "VB.NET Application", EventLogEntryType.Information, "Application")
                ProjectData.ClearProjectError()
                GoTo label_15
            End Try
        End If
        sqlCommand.Connection = Me.oConn
        sqlCommand.CommandText = sSPName
        sqlCommand.CommandType = CommandType.StoredProcedure
        Me.sbPrepareParameters(cmd, ArrayL, ArrayLOut)
        sqlCommand.ExecuteNonQuery()
        ArrayLOut.Clear()
        Try
            For Each parameter As SqlParameter In cmd.Parameters
                If parameter.Direction = ParameterDirection.Output Then
                    ArrayLOut.Add(DirectCast(New cArrayList(parameter.ParameterName, RuntimeHelpers.GetObjectValue(parameter.Value), parameter.DbType, parameter.Size), Object))
                End If
            Next
        Finally
            Dim enumerator As IEnumerator
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        Me.sbCloseConnection()
        Dim num2 As Long = num1
label_15:
        Return num2
    End Function

    Public Function fn_AddRecordSP(sSPName As String, ByRef ArrayL As ArrayList, Optional ByRef nReturnValue As Integer = 0) As Long
        Dim num1 As Long = 0
        Dim cmd As New SqlCommand()
        Dim sqlCommand As SqlCommand = cmd
        If Me.oConn.State = ConnectionState.Open Then
            Me.oConn.Close()
        Else
            Me.oConn = New SqlConnection(Conversions.ToString(Me.p_GetConStringRegistry))
            Try
                Me.oConn.Open()
            Catch ex As Exception
                ProjectData.SetProjectError(ex)
                Me.WriteToEventLog(ex.Message, "VB.NET Application", EventLogEntryType.Information, "Application")
                ProjectData.ClearProjectError()
                GoTo label_6
            End Try
        End If
        sqlCommand.Connection = Me.oConn
        sqlCommand.CommandText = sSPName
        sqlCommand.CommandType = CommandType.StoredProcedure
        Me.sbPrepareParameters(cmd, ArrayL)
        sqlCommand.ExecuteNonQuery()
        nReturnValue = Conversions.ToInteger(cmd.Parameters("@RETURN_VALUE").Value)
        Me.sbCloseConnection()
        Dim num2 As Long = num1
label_6:
        Return num2
    End Function

    Public Function fn_GetSQLDataReader(sSPName As String, ByRef dr As SqlDataReader) As Long
        Dim num1 As Long = 0
        Dim sqlCommand As New SqlCommand()
        If Me.oConn.State = ConnectionState.Open Then
            Me.oConn.Close()
        Else
            Me.oConn = New SqlConnection(Conversions.ToString(Me.p_GetConStringRegistry))
            Try
                Me.oConn.Open()
            Catch ex As Exception
                ProjectData.SetProjectError(ex)
                Me.WriteToEventLog(ex.Message, "VB.NET Application", EventLogEntryType.Information, "Application")
                ProjectData.ClearProjectError()
                GoTo label_6
            End Try
        End If
        sqlCommand.Connection = Me.oConn
        sqlCommand.CommandType = CommandType.StoredProcedure
        sqlCommand.CommandText = sSPName
        dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)

        Dim num2 As Long = num1
label_6:
        Return num2
    End Function

    Public Function fn_GetSQLDataReader(sSPName As String) As DataSet
        Dim dataSet1 As New DataSet()
        Dim table As New DataTable()
        Dim dataSet2 As DataSet
        If Me.oConn.State = ConnectionState.Open Then
            Me.oConn.Close()
        Else
            Me.oConn = New SqlConnection(Conversions.ToString(Me.p_GetConStringRegistry))
            Try
                Me.oConn.Open()
            Catch ex As Exception
                ProjectData.SetProjectError(ex)
                Me.WriteToEventLog(ex.Message, "VB.NET Application", EventLogEntryType.Information, "Application")
                dataSet2 = dataSet1
                ProjectData.ClearProjectError()
                GoTo label_6
            End Try
        End If
        Dim sqlDataReader As SqlDataReader = New SqlCommand(sSPName, Me.oConn).ExecuteReader(CommandBehavior.CloseConnection)
        table.Load(DirectCast(sqlDataReader, IDataReader))
        dataSet1.Tables.Add(table)
        dataSet2 = dataSet1
label_6:
        Return dataSet2
    End Function

    Public Function fn_GetSQLDataReader(sSPName As String, ArrayL As ArrayList) As DataSet
        Dim table As New DataTable()
        Dim dataSet1 As New DataSet()
        Dim cmd As New SqlCommand()
        Dim dataSet2 As DataSet
        If Me.oConn.State = ConnectionState.Open Then
            Me.oConn.Close()
        Else
            Me.oConn = New SqlConnection(Conversions.ToString(Me.p_GetConStringRegistry))
            Try
                Me.oConn.Open()
            Catch ex As Exception
                ProjectData.SetProjectError(ex)
                Me.WriteToEventLog(ex.Message, "VB.NET Application", EventLogEntryType.Information, "Application")
                dataSet2 = dataSet1
                ProjectData.ClearProjectError()
                GoTo label_6
            End Try
        End If
        cmd.Connection = Me.oConn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = sSPName
        Me.sbPrepareParameters(cmd, ArrayL)
        Dim sqlDataReader As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        table.Load(DirectCast(sqlDataReader, IDataReader))
        dataSet1.Tables.Add(table)
        dataSet2 = dataSet1
label_6:
        Return dataSet2
    End Function

    Private Function f_getConString() As String
        Dim curCon As String = BaseConnstringSql.ConnString()
        'Dim curCon As String = ConfigurationManager.ConnectionStrings("IvrDb").ConnectionString

        Dim sConnectionString As String = curCon
        Return sConnectionString
    End Function
End Class