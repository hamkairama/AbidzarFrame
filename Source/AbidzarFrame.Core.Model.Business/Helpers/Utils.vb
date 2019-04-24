Imports System.Reflection
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Drawing.Imaging
Imports System.IO
Imports Syncfusion.Windows.Gauge
Imports System.Windows.Media
Imports System.Windows
Imports System.Windows.Media.Imaging
Imports System.Windows.Controls
Imports System.Collections.Concurrent
Imports System.Resources
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Public Class Utils

    Public Shared Sub FillErrors(ByRef errors As BusinessErrors, ByRef ex As Exception)
        If (errors Is Nothing) Then
            errors = New BusinessErrors()
        End If
        errors.Add(New BusinessErrorVo("E0000", "", ex.Message))
    End Sub

    Public Shared Sub FillErrors(ByRef errors As BusinessSoapErrors, ByRef ex As Exception)
        If (errors Is Nothing) Then
            errors = New BusinessSoapErrors()
        End If
        errors.Add(New BusinessErrorVo("E0000", "", ex.Message))
    End Sub

    Public Shared Function RunMethod(ByRef instance As Object, ByRef output As Object, ByVal functionName As String, ByVal parameters As Object()) As Boolean
        Dim _success = False

        Dim _type = instance.GetType()

        Dim _typeArray As New List(Of System.Type)
        For Each _p In parameters
            _typeArray.Add(_p.GetType())
        Next

        Dim _method = _type.GetMethod(functionName, _typeArray.ToArray())
        If _method IsNot Nothing Then
            Try
                output = _method.Invoke(instance, parameters)
                _success = True
            Catch ex As Exception
                _success = False
            End Try
        End If

        Return _success
    End Function

    Public Overloads Shared Function LoadClass(Of T)(ByVal package As String, ByVal className As String) As T

        Dim ab As Assembly = Assembly.Load(package)
        Dim type = ab.GetType(package & "." & className)
        Dim instance As T = DirectCast(Activator.CreateInstance(type), T)

        Return instance

    End Function

    Public Overloads Shared Function LoadClass(Of T)(ByVal package As String, ByVal className As String, ByVal parameters As Object()) As T

        Dim typeList As New List(Of Type)
        For Each param In parameters
            typeList.Add(param.GetType())
        Next

        Dim ab As Assembly = Assembly.Load(package)
        Dim instance As T = Nothing
        Dim assemblyObj As Type = ab.GetType(package & "." & className)
        If (assemblyObj IsNot Nothing) Then
            Dim ci As System.Reflection.ConstructorInfo = assemblyObj.GetConstructor(typeList.ToArray())
            If ci IsNot Nothing Then
                instance = ci.Invoke(parameters)
            End If
        End If

        Return instance
    End Function

    Public Overloads Shared Function LoadClass(Of T)(ByVal assemblyName As String, ByVal namesapce As String, ByVal className As String, ByVal parameters As Object()) As T

        Dim typeList As New List(Of Type)
        For Each param In parameters
            typeList.Add(param.GetType())
        Next

        Dim ab As Assembly = Assembly.Load(assemblyName)
        Dim instance As T = Nothing
        Dim assemblyObj As Type = ab.GetType(namesapce & "." & className)
        If (assemblyObj IsNot Nothing) Then
            Dim ci As System.Reflection.ConstructorInfo = assemblyObj.GetConstructor(typeList.ToArray())
            instance = ci.Invoke(parameters)
        End If

        Return instance

    End Function

    Public Overloads Shared Function LoadClassByReference(Of T)(ByVal package As String, ByVal className As String, ByRef parameters As Object()) As T

        Dim typeList As New List(Of Type)
        For Each param In parameters
            typeList.Add(param.GetType())
        Next

        Dim ab As Assembly = Assembly.Load(package)
        Dim instance As T = Nothing
        Dim assemblyObj As Type = ab.GetType(package & "." & className)
        If (assemblyObj IsNot Nothing) Then
            Dim ciArr() As System.Reflection.ConstructorInfo = assemblyObj.GetConstructors '(typeList.ToArray())
            For Each ci In ciArr
                If ci.GetParameters.Length = parameters.Length Then
                    Dim haveSameParam = True
                    Dim ciParam = ci.GetParameters.ToArray()
                    For i = 0 To parameters.Count - 1
                        If parameters(i).GetType.IsSubclassOf(ciParam(i).ParameterType) Then
                            haveSameParam = False
                            Exit For
                        End If
                    Next
                    If haveSameParam Then
                        instance = ci.Invoke(parameters)
                        Exit For
                    End If
                End If
            Next

        End If

        Return instance

    End Function

    Public Shared Sub SetFieldValue(ByRef dataVariable As Object, ByVal propertyName As String, ByRef value As Object, ByVal defaultValue As Object, Optional ByVal index() As Object = Nothing)
        Dim prop As System.Reflection.PropertyInfo = dataVariable.GetType().GetProperty(propertyName)
        If value IsNot Nothing Then
            prop.SetValue(dataVariable, value, index)
        Else
            prop.SetValue(dataVariable, defaultValue, index)
        End If
    End Sub

    Public Shared Function GetFieldValue(Of T)(ByRef dataVariable As Object, ByVal propertyName As String, ByVal defaultValue As T) As Object
        Dim rtnValue As T = defaultValue
        Try
            Dim prop As PropertyInfo = dataVariable.GetType().GetProperty(propertyName)
            If Not IsNothing(prop) Then
                rtnValue = DirectCast(prop.GetValue(dataVariable, Nothing), T)
            End If
        Catch ex As Exception
            'Cannot convert
        End Try
        Return rtnValue

    End Function

    Public Shared Function GetFieldValue(ByRef dataVariable As Object, ByVal propertyName As String) As Object
        Dim rtnValue = Nothing
        Try
            Dim prop As PropertyInfo = dataVariable.GetType().GetProperty(propertyName)
            If Not IsNothing(prop) Then
                rtnValue = prop.GetValue(dataVariable, Nothing)
            End If
        Catch ex As Exception
            'Cannot convert
        End Try
        Return rtnValue

    End Function

    Public Shared Function GetFieldValue(ByRef dataVariable As Object, ByVal ParamArray propertyName() As String) As Object
        Dim rtnValue = Nothing
        Try
            Dim innerdataVariable As Object = dataVariable

            For i = 0 To propertyName.Count - 1
                Dim innerProperty As PropertyInfo = innerdataVariable.GetType().GetProperty(propertyName(i))
                innerdataVariable = innerProperty.GetValue(innerdataVariable, Nothing)
            Next

            rtnValue = innerdataVariable
        Catch ex As Exception
            'Cannot convert
        End Try
        Return rtnValue

    End Function

    Public Shared Function GetProperties(ByRef dataVariable As Object) As PropertyInfo()
        Dim _fields As PropertyInfo() = Nothing
        Try
            Dim props As PropertyInfo() = dataVariable.GetType().GetProperties()
            _fields = props
        Catch ex As Exception
            'Cannot read properties
        End Try
        Return _fields

    End Function

    Public Shared Function ListToDataTable(ByRef dataList) As DataTable
        Dim dt As New DataTable
        Try
            Dim firstObject = dataList(0)
            'Dim ab As Assembly = Assembly.Load(firstObject.GetType().Namespace)
            'Dim type As Type = ab.GetType(firstObject.GetType().Name)
            Dim type As Type = firstObject.GetType()
            For Each p In type.GetProperties
                If p.MemberType.Equals(MemberTypes.Property) And Not p.PropertyType.IsGenericType Then
                    dt.Columns.Add(p.Name, p.PropertyType)
                End If
            Next

            For Each d In dataList
                Dim l As New List(Of Object)
                For Each c As DataColumn In dt.Columns
                    Dim v = type.GetProperty(c.ColumnName).GetValue(d, Nothing)
                    l.Add(v)
                Next
                dt.Rows.Add(l.ToArray())
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return dt

    End Function

    Public Shared Function ConvertDate(ByVal dateFormat As String, ByVal s As String, ByRef d As Date) As Boolean
        Dim b As Boolean = Date.TryParseExact(s, dateFormat, New CultureInfo("en-GB"), DateTimeStyles.None, d)
        Return b

    End Function

    Public Shared Function VerifyEmailAddress(ByVal emailAddress As String) As Boolean
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch = Regex.Match(emailAddress, pattern)
        Return emailAddressMatch.Success

    End Function

    Public Shared Function GetImageOfControl(ByVal controlToConvert As Control) As Stream
        Dim _image As Byte() = Nothing

        ' create a file stream for saving image
        Dim outStream As New MemoryStream
        ' save encoded data to stream
        GetImageFromControl(controlToConvert).Save(outStream)

        Return outStream

    End Function

    Private Shared Function GetImageFromControl(ByVal controlToConvert As Control) As PngBitmapEncoder
        ' save current canvas transform
        Dim transform As Transform = controlToConvert.LayoutTransform

        ' get size of control
        Dim sizeOfControl As New Size(controlToConvert.ActualWidth, controlToConvert.ActualHeight)
        ' measure and arrange the control
        controlToConvert.Measure(sizeOfControl)
        ' arrange the surface
        controlToConvert.Arrange(New Rect(sizeOfControl))

        ' craete and render surface and push bitmap to it
        Dim renderBitmap As New RenderTargetBitmap(sizeOfControl.Width, sizeOfControl.Height, 96.0, 96.0, PixelFormats.Pbgra32)
        ' now render surface to bitmap
        renderBitmap.Render(controlToConvert)

        ' encode png data
        Dim pngEncoder As New PngBitmapEncoder()
        ' puch rendered bitmap into it
        pngEncoder.Frames.Add(BitmapFrame.Create(renderBitmap))

        ' return encoder
        Return pngEncoder

    End Function

    Public Shared Function DataTableToRowList(ByVal dt As DataTable) As ConcurrentBag(Of DataRow)
        Dim _list As ConcurrentBag(Of DataRow) = Nothing
        Dim _dummyRow As DataRow = Nothing
        Try
            If dt.Rows.Count = 0 Then
                For i = 0 To dt.Columns.Count - 1
                    dt.Columns(i).AllowDBNull = True
                Next
                _dummyRow = dt.NewRow()
            End If
            If _dummyRow IsNot Nothing Then
                _list = New ConcurrentBag(Of DataRow)
                _list.Add(_dummyRow)
            Else
                _list = New ConcurrentBag(Of DataRow)(dt.Select().ToList)
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return _list
    End Function

    Public Shared Function RowListToDataTable(ByRef dl As ConcurrentBag(Of DataRow)) As DataTable
        Dim dt As New DataTable
        Dim IsAllColumnsDbNull As Boolean = False
        Try
            If dl.Count > 0 Then
                If dl.Count = 1 Then
                    IsAllColumnsDbNull = True
                    For i = 0 To dl(0).Table.Columns.Count - 1
                        If IsAllColumnsDbNull Then
                            IsAllColumnsDbNull = IsAllColumnsDbNull And dl(0).IsNull(i)
                        Else
                            Exit For
                        End If
                    Next
                End If
                dt = dl.CopyToDataTable()
                If IsAllColumnsDbNull Then
                    dt.Rows.RemoveAt(0)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return dt

    End Function

    Public Shared Function DictionaryDataTableToRowList(ByVal dict As Dictionary(Of String, DataTable)) As Dictionary(Of String, ConcurrentBag(Of DataRow))
        Dim result As New Dictionary(Of String, ConcurrentBag(Of DataRow))
        For Each item In dict
            result.Add(item.Key, DataTableToRowList(item.Value))
        Next
        Return result
    End Function

    Public Shared Function DictionaryRowListToDataTable(ByVal dict As Dictionary(Of String, ConcurrentBag(Of DataRow))) As Dictionary(Of String, DataTable)
        Dim result As New Dictionary(Of String, DataTable)
        For Each item In dict
            result.Add(item.Key, RowListToDataTable(item.Value))
        Next
        Return result
    End Function



    'public static void ClearObject(Object data)
    '{

    '    if (data is IDisposable)
    '    {
    '        ((IDisposable)data).Dispose();
    '    }

    '    try
    '    {
    '        MethodInfo method = data.GetType().GetMethod("Clear");
    '        if (method != null)
    '        {
    '            method.Invoke(data, null);
    '        }
    '    }
    '    catch (Exception e)
    '    {
    '        String a = e.Message;
    '    }

    '}

    Public Shared Sub ClearObject(ByRef data As Object)
        If data IsNot Nothing Then
            If (TypeOf data Is IDisposable) Then
                DirectCast(data, IDisposable).Dispose()
            End If

            Try
                Dim method As MethodInfo = data.GetType().GetMethod("Clear")
                If method IsNot Nothing Then
                    method.Invoke(data, Nothing)
                End If
            Catch ex As Exception
                Dim a = ex.Message
            End Try

            data = Nothing
        End If
    End Sub

    Public Shared Function WriteFile(ByVal filename As String, ByVal data As Byte()) As BusinessErrors
        Dim errs As New BusinessErrors
        Dim s As FileStream = Nothing
        Try
            s = New FileStream(filename, FileMode.Create)
            s.Write(data, 0, data.Length)
            s.Close()
        Catch ex As Exception
            Utils.FillErrors(errs, ex)
        Finally
            Utils.ClearObject(s)
        End Try
        Return errs
    End Function

    Public Shared Function WriteFile(ByVal filename As String, ByVal input As Stream) As BusinessErrors
        Dim _error As New BusinessErrors
        Dim output As FileStream = Nothing
        Try
            output = New FileStream(filename, FileMode.Create)

            Dim buffer As Byte() = New Byte(8 * 1024 - 1) {}
            Dim len As Integer
            While True
                len = input.Read(buffer, 0, buffer.Length)
                If len > 0 Then
                    output.Write(buffer, 0, len)
                Else
                    Exit While
                End If
            End While

        Catch ex As Exception
            Utils.FillErrors(_error, ex)

        Finally
            If output IsNot Nothing Then
                output.Close()
            End If

        End Try
        Return _error
    End Function

    Public Shared Function GenerateFileKey(ByVal file As FileInfo) As String
        Dim _lastUpdate = file.LastWriteTime.ToString("yyyyMMddHHmmss")
        Dim _fileSize = file.Length
        Dim _creation = file.CreationTime.ToString("yyyyMMddHHmmss")
        Dim _fileName = file.Name.Substring(0, file.Name.IndexOf("."))
        Dim _hashCode As Long = New With {Key .A = _fileName, Key .B = _creation, Key .C = _fileSize, Key .D = _lastUpdate}.GetHashCode()
        Return String.Format("{0}_{1}_{2}_{3}_{4}", _fileName, _creation, _fileSize, _lastUpdate, _hashCode)
    End Function

    Public Shared Function ReadObjectFromFile(Of T)(ByVal source As String, Optional ByVal binder As SerializationBinder = Nothing) As T
        If File.Exists(source) Then
            Try
                Dim formatter As IFormatter = New BinaryFormatter()
                If binder IsNot Nothing Then
                    formatter.Binder = binder
                End If
                Dim stream As Stream = New FileStream(source, FileMode.Open, FileAccess.Read, FileShare.Read)
                Dim obj As T = DirectCast(formatter.Deserialize(stream), T)
                stream.Close()
                Return obj
            Catch ex As Exception
                Return Nothing
            End Try
        Else
            Return Nothing
        End If
    End Function

    Public Shared Sub WriteObjectToFile(ByVal data As Object, ByVal source As String)
        Dim formatter As IFormatter = New BinaryFormatter()
        Dim stream As Stream = New FileStream(source, FileMode.Create, FileAccess.Write, FileShare.None)
        formatter.Serialize(stream, data)
        stream.Close()
    End Sub

End Class
