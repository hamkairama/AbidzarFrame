Imports System.IO

Public MustInherit Class ModelConfigurationSetting

    Private Shared filePath As String
    Protected configFile As String = Nothing
    Protected settings As New Dictionary(Of String, String)

    Public Sub New()
        Try
            ReadConfiguration()
            WriteMissingConfigurationItems()
        Catch ex As FileNotFoundException
            WriteDefaultConfiguration()
        End Try

    End Sub

    Protected MustOverride Sub InitDefaultSetting()

    Public ReadOnly Property Parameters As Dictionary(Of String, String)
        Get
            Return settings
        End Get
    End Property

    Public Shared Property ConfigurationLocation As String
        Get
            Return filePath
        End Get
        Set(ByVal value As String)
            filePath = value
        End Set
    End Property

    Public Overridable Property ConfigurationFile As String
        Get
            If configFile Is Nothing Then
                Return Me.GetType().ToString() & ".ini"
            Else
                Return configFile
            End If
        End Get
        Set(ByVal value As String)
            configFile = value
        End Set
    End Property

    Protected Overridable ReadOnly Property ConfigurationFileFullPath As String
        Get
            Return BusinessModelSetting.ConfigurationLocation & Me.ConfigurationFile
        End Get
    End Property

    Protected Sub AddParameter(ByVal key As String, ByVal value As String)
        settings.Add(key, value)
    End Sub

    Public Sub UpdateParameter(ByVal key As String, ByVal value As String)
        If (Not Parameters.ContainsKey(key)) Then
            Throw New Exception("Parameter Key cannot be found.")
        End If

        Parameters(key) = value
        Try
            Dim _i As Integer = 0
            Dim _settings As New List(Of String)
            FileOpen(1, ConfigurationFileFullPath, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
            While Not EOF(1)
                Dim s = LineInput(1)

                If Not s.StartsWith("//") Then
                    Dim a = s.IndexOf("=")
                    If a > 0 Then
                        Dim _key = s.Substring(0, a)
                        Dim _value = s.Substring(a + 1)

                        If (key.Equals(_key)) Then
                            _settings.Add(key & "=" & value)
                            _i = _settings.Count - 1
                        Else
                            _settings.Add(s)
                        End If
                    Else
                        _settings.Add(s)
                    End If
                Else
                    _settings.Add(s)
                End If
            End While
            FileClose(1)

            FileOpen(1, ConfigurationFileFullPath, OpenMode.Output, OpenAccess.Write, OpenShare.LockWrite)
            For Each l In _settings
                PrintLine(1, l)
            Next

        Catch ex2 As Exception
            Throw ex2

        Finally
            FileClose(1)

        End Try

    End Sub

    Protected Sub ReadConfiguration()
        Try
            FileOpen(1, ConfigurationFileFullPath, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
            While Not EOF(1)
                Dim s = LineInput(1)

                If Not s.StartsWith("//") Then
                    Dim a = s.IndexOf("=")
                    If a > 0 Then
                        Dim key = s.Substring(0, a)
                        Dim value = s.Substring(a + 1)

                        AddParameter(key, value)
                    Else
                        'Invalid Line - Ignore
                    End If
                End If
            End While

        Catch ex2 As Exception
            Throw ex2

        Finally
            FileClose(1)

        End Try

    End Sub

    Protected Sub WriteMissingConfigurationItems()
        'Add new parameters into existing configuration file

        Dim settingBackup As Dictionary(Of String, String) = Me.settings

        Dim newSettings As New Dictionary(Of String, String)
        Me.settings = New Dictionary(Of String, String)
        InitDefaultSetting()
        For Each _pair In Me.settings
            If Not settingBackup.ContainsKey(_pair.Key) Then
                newSettings.Add(_pair.Key, _pair.Value)
            End If
        Next

        If (newSettings.Count > 0) Then
            Try
                FileOpen(1, ConfigurationFileFullPath, OpenMode.Append, OpenAccess.Write, OpenShare.Shared)
                For Each k In newSettings
                    PrintLine(1, k.Key & "=" & k.Value)
                    settingBackup.Add(k.Key, k.Value)
                Next

            Catch ex1 As Exception
                Throw ex1

            Finally
                Me.settings = settingBackup
                FileClose(1)

            End Try
        Else
            Me.settings = settingBackup
        End If

    End Sub

    Protected Sub WriteDefaultConfiguration()
        InitDefaultSetting()
        Try
            DosHelper.CreateDirectoryExcludeFileName(ConfigurationFileFullPath)

            FileOpen(1, ConfigurationFileFullPath, OpenMode.Output, OpenAccess.Write, OpenShare.LockWrite)
            For Each k In settings
                PrintLine(1, k.Key & "=" & k.Value)
            Next

        Catch ex1 As Exception
            Throw ex1

        Finally
            FileClose(1)

        End Try

    End Sub
End Class
