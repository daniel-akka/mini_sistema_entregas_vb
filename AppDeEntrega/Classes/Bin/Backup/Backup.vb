Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Windows.Forms
Public Class Backup

    Dim _camihoArquivoConfiguracao As String = "\Sincroniza\config.sys"
    Dim _caminhoZIP As String = "\Sincroniza\Dropbox\"
    Dim _caminhoBackup As String = "\Sincroniza\Backup\"
    Dim Hora As String = ""
    Dim Hora2 As String = ""
    Dim HoraArq As String = ""
    Dim _caminhoSGBD As String = ""
    Dim _NomeDoArquivo As String = ""

    Sub New()

        _caminhoSGBD = trazCaminhoSGBD(_camihoArquivoConfiguracao)

        ''SETA EVENTO
        'AddHandler _Timer.Tick, AddressOf SetaHora


    End Sub

    'Sub SetaHora()

    '    Hora = TimeString
    '    If Hora.Equals(HoraArq) OrElse Hora.Equals(Hora2) Then
    '        'backup()
    '        System.Threading.Thread.Sleep(2000) '1 minuto
    '    End If

    'End Sub

    Public Function trazCaminhoSGBD(ByVal caminhoArqConfigBD As String) As String
        Dim sr As StreamReader = New StreamReader(caminhoArqConfigBD, System.Text.Encoding.Default)
        Dim mLinha As String
        Dim mcont As Integer = 1
        mLinha = ""

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If mcont = 1 Then Exit Do
            mcont += 1
        Loop Until mLinha Is Nothing
        sr.Close()

        Return mLinha
    End Function

    Sub compactar()

        Dim ok As Boolean = False
        Dim cont As Int16 = 0

        While ok = False AndAlso cont < 100

            Try
                Dim arqBackup As New FileStream(_caminhoBackup & "Backup_" & _NomeDoArquivo & ".backup", FileMode.Open, FileAccess.Read)
                Dim fileInfo As New FileInfo(_caminhoBackup & "Backup_" & _NomeDoArquivo & ".backup")

                Using originalFileStream As FileStream = fileInfo.OpenRead()
                    Using compressedFileStream As FileStream = File.Create(_caminhoZIP & "Backup_" & _NomeDoArquivo & ".gz")
                        Using compressionStream As GZipStream = New GZipStream(compressedFileStream, CompressionMode.Compress)
                            originalFileStream.CopyTo(compressionStream)
                        End Using
                    End Using
                End Using
                ok = True
                arqBackup.Close()
                File.Delete(arqBackup.Name)
            Catch ex As Exception
                cont += 1
            End Try

        End While


    End Sub

    Public Sub fazerBackup()

        Try

            Dim fs As FileStream
            Try
                fs = New FileStream("\Entrega\Backup.bat", FileMode.Create, FileAccess.ReadWrite)

            Catch ex As Exception
                Try
                    File.Delete("\Entrega\Backup.bat")
                    fs = New FileStream("\Entrega\Backup.bat", FileMode.Create, FileAccess.ReadWrite)

                Catch ex1 As Exception
                    fs = New FileStream("\Entrega\Backup.bat", FileMode.Create, FileAccess.ReadWrite)
                End Try

            End Try

            Dim sw As New StreamWriter(fs)
            Dim comando As String = ""
            _NomeDoArquivo = Format(Date.Now, "dd-MM-yyyy HH-mm-ss")
            comando = "SET PGPASSWORD=" & MdlConexaoBD.senhaDoSGBD & vbNewLine & _
            """" & _caminhoSGBD & "\bin\pg_dump.exe"" -h " & MdlConexaoBD.nomeServidor & " -p 5432 -U postgres -F t -b -v -f """ & _
             _caminhoBackup & "Backup_" & _NomeDoArquivo & ".backup" & """ """ & MdlConexaoBD.nomeDoBanco & """ " & vbNewLine & _
             "exit" & vbNewLine

            sw.WriteLine(comando)
            sw.Close()
            sw.Dispose()

            Shell("\Entrega\Backup.bat", AppWinStyle.NormalFocus)

            MsgBox("Backup Realizado com Sucesso!")
            compactar()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Public Sub fazerBackup2()

        Try

            Dim fs As FileStream
            Try
                fs = New FileStream("\Entrega\Backup.bat", FileMode.Create, FileAccess.ReadWrite)

            Catch ex As Exception
                Try
                    File.Delete("\Entrega\Backup.bat")
                    fs = New FileStream("\Entrega\Backup.bat", FileMode.Create, FileAccess.ReadWrite)

                Catch ex1 As Exception
                    fs = New FileStream("\Entrega\Backup.bat", FileMode.Create, FileAccess.ReadWrite)
                End Try

            End Try

            Dim sw As New StreamWriter(fs)
            Dim comando As String = ""
            _NomeDoArquivo = Format(Date.Now, "dd-MM-yyyy HH-mm-ss")
            comando = "SET PGPASSWORD=" & MdlConexaoBD.senhaDoSGBD & vbNewLine & _
            """" & _caminhoSGBD & "\bin\pg_dump.exe"" -h " & MdlConexaoBD.nomeServidor & " -p 5432 -U postgres -F t -b -v -f """ & _
             _caminhoBackup & "Backup_" & _NomeDoArquivo & ".backup" & """ """ & MdlConexaoBD.nomeDoBanco & """ " & vbNewLine & _
             "exit" & vbNewLine

            sw.WriteLine(comando)
            sw.Close()
            sw.Dispose()

            Shell("\Entrega\Backup.bat", AppWinStyle.NormalFocus)

            compactar()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Public Sub fazerBackupBackGround()

        Try

            Dim fs As FileStream
            Try
                fs = New FileStream("\Entrega\Backup.bat", FileMode.Create, FileAccess.ReadWrite)

            Catch ex As Exception
                Try
                    File.Delete("\Entrega\Backup.bat")
                    fs = New FileStream("\Entrega\Backup.bat", FileMode.Create, FileAccess.ReadWrite)

                Catch ex1 As Exception
                    fs = New FileStream("\Entrega\Backup.bat", FileMode.Create, FileAccess.ReadWrite)
                End Try

            End Try

            Dim sw As New StreamWriter(fs)
            Dim comando As String = ""
            _NomeDoArquivo = Format(Date.Now, "dd-MM-yyyy HH-mm-ss")
            comando = "SET PGPASSWORD=" & MdlConexaoBD.senhaDoSGBD & vbNewLine & _
            """" & _caminhoSGBD & "\bin\pg_dump.exe"" -h " & MdlConexaoBD.nomeServidor & " -p 5432 -U postgres -F t -b -v -f """ & _
             _caminhoBackup & "Backup_" & _NomeDoArquivo & ".backup" & """ """ & MdlConexaoBD.nomeDoBanco & """ " & vbNewLine & _
             "exit" & vbNewLine

            sw.WriteLine(comando)
            sw.Close()
            sw.Dispose()

            Shell("\Entrega\Backup.bat", AppWinStyle.Hide)
            compactar()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

End Class
