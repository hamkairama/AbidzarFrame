Imports System.Security.Cryptography
Imports System.Text

Public Class CipherUtility

    Public Shared Function GenerateRandomNumber() As Integer
        Dim b As Integer = DateTime.Now.Ticks Mod Integer.MaxValue
        Dim v As Integer = (New Random(b)).Next()
        Return v
    End Function

    'Functions for encryption / decryption
    Private Shared Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
        Dim sha1 As New SHA1CryptoServiceProvider

        ' Hash the key.
        Dim keyBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ' Truncate or pad the hash.
        ReDim Preserve hash(length - 1)
        Return hash
    End Function

    Public Shared Function EncryptData(ByVal plaintext As String, ByVal key As String) As String
        Dim TripleDes As New TripleDESCryptoServiceProvider
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)

        ' Convert the plaintext string to a byte array.
        Dim plaintextBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(plaintext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the encoder to write to the stream.
        Dim encStream As New CryptoStream(ms,
            TripleDes.CreateEncryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        ' Convert the encrypted stream to a printable string.
        Return Convert.ToBase64String(ms.ToArray)
    End Function

    Public Shared Function DecryptData(ByVal encryptedtext As String, ByVal key As String) As String
        Dim TripleDes As New TripleDESCryptoServiceProvider
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)

        ' Convert the encrypted text string to a byte array.
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the decoder to write to the stream.
        Dim decStream As New CryptoStream(ms, TripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plaintext stream to a string.
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function

    Public Shared Function HashSHA(ByVal value As String) As String
        Dim engine As SHA1 = New SHA1Managed()
        Dim valueData() As Byte = System.Text.Encoding.Unicode.GetBytes(value)
        Dim hashData() As Byte = engine.ComputeHash(valueData)
        Return Convert.ToBase64String(hashData)
    End Function

    Public Shared Function HashMD5(ByVal value As String) As String
        Dim engine As MD5 = MD5.Create()
        Dim valueData() As Byte = System.Text.Encoding.Unicode.GetBytes(value)
        Dim hashData() As Byte = engine.ComputeHash(valueData)
        Return Convert.ToBase64String(hashData)
    End Function

    Public Shared Sub EncryptStream(ByRef input As System.IO.Stream, ByVal key As String, ByRef output As System.IO.Stream)
        If output Is Nothing Then
            output = New System.IO.MemoryStream
        End If

        Dim encryptor As New RijndaelManaged()
        ToCryptStream(encryptor.CreateEncryptor(CreateKey(key), CreateKey(key)), _
                      input, output)
    End Sub

    Public Shared Sub DecryptStream(ByRef input As System.IO.Stream, ByVal key As String, ByRef output As System.IO.Stream)
        If output Is Nothing Then
            output = New System.IO.MemoryStream
        End If

        Dim encryptor As New RijndaelManaged()
        ToCryptStream(encryptor.CreateDecryptor(CreateKey(key), CreateKey(key)), _
                      input, output)
    End Sub

    Private Shared Sub ToCryptStream(ByRef cryptor As ICryptoTransform, _
                                     ByRef input As System.IO.Stream, _
                                     ByRef output As System.IO.Stream)
        Dim cs As New CryptoStream(output, cryptor, CryptoStreamMode.Write)
        Dim d As Integer
        While True
            d = input.ReadByte()
            If (d = -1) Then
                Exit While
            End If

            cs.WriteByte(CByte(d))
        End While
    End Sub

    Private Shared Function CreateKey(ByVal encryptionKey As String) As Byte()
        Dim s As String = "012345678"
        Dim k As String = (encryptionKey + s).Substring(0, 8)
        Dim UE As New UnicodeEncoding
        Dim key As Byte() = UE.GetBytes(k)

        Return key
    End Function

End Class
