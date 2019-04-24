Imports System.Data
Imports System.Runtime.CompilerServices

Public Class cArrayList

        Private mvar_data_type As DbType

        Private mvar_size As Integer

        Private mvar_sname As String

        Private mvar_value As Object

        Public Sub New(ByVal sName As String, ByVal oValue As Object)
            Me.p_name = sName
            Me.p_value = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(oValue)))
        End Sub

        Public Sub New(ByVal sName As String, ByVal oValue As Object, ByVal oDbType As DbType)
            Me.p_name = sName
            Me.p_value = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(oValue)))
            Me.p_dbtype = oDbType
        End Sub

        Public Sub New(ByVal sName As String, ByVal oValue As Object, ByVal nSize As Integer)
            Me.p_name = sName
            Me.p_value = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(oValue)))
            Me.p_size = nSize
        End Sub

        Public Sub New(ByVal sName As String, ByVal oValue As Object, ByVal oDBType As DbType, ByVal nSize As Integer)
            Me.p_name = sName
            Me.p_value = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(oValue)))
            Me.p_size = nSize
            Me.p_dbtype = oDBType
        End Sub

        Public Property p_dbtype As DbType
            Get
                Return Me.mvar_data_type
            End Get

            Set(ByVal value As DbType)
                Me.mvar_data_type = value
            End Set
        End Property

        Public Property p_name As String
            Get
                Return Me.mvar_sname
            End Get

            Set(ByVal value As String)
                Me.mvar_sname = value
            End Set
        End Property

        Public Property p_size As Integer
            Get
                Return Me.mvar_size
            End Get

            Set(ByVal value As Integer)
                Me.mvar_size = value
            End Set
        End Property

        Public Property p_value As Object
            Get
                Return Me.mvar_value
            End Get

            Set(ByVal value As Object)
                Me.mvar_value = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(value)))
            End Set
        End Property
    End Class
