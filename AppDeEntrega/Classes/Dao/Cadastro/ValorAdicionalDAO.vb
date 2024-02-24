Imports Npgsql
Public Class ValorAdicionalDAO

    Public Sub incValorAdicional(ByVal vValorAdicional As ValorAdicional, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO valor_adicional(id, descricao, valor) "
        sql += "VALUES (DEFAULT, @descricao, @valor)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@descricao", vValorAdicional.Descricao)
        comm.Parameters.Add("@valor", vValorAdicional.Valor)
        comm.ExecuteNonQuery()

        TrazListValorAdicionalDoBD(MdlConexaoBD.ListaValorAdicional, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altValorAdicional(ByVal vValorAdicional As ValorAdicional, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE valor_adicional SET descricao = @descricao, valor = @valor WHERE id = @id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vValorAdicional.Id)
        comm.Parameters.Add("@descricao", vValorAdicional.Descricao)
        comm.Parameters.Add("@valor", vValorAdicional.Valor)
        comm.ExecuteNonQuery()

        TrazListValorAdicionalDoBD(MdlConexaoBD.ListaValorAdicional, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaValorAdicional(ByVal vValorAdicional As ValorAdicional, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(vValorAdicional.Descricao).Equals("") Then MsgBox("Informe uma DESCRICAO para o Valor Adicional!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT descricao FROM valor_adicional WHERE descricao = '" & vValorAdicional.Descricao & "'"
        Else
            consulta = "SELECT descricao FROM valor_adicional WHERE id <> " & vValorAdicional.Id & " AND descricao = '" & vValorAdicional.Descricao & "'"
        End If
        If ValorAdicionalConsulta(vValorAdicional, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O Valor Adicional """ & vValorAdicional.Descricao & """ já existe em outro CADASTRO !") : Return False
        End If

        Return True
    End Function

    Public Sub TrazListValorAdicionalDoBD(ByRef ValorAdicional As List(Of ValorAdicional), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ValorAdicionalDAO:TrazListValorAdicionalBD"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, descricao, valor FROM valor_adicional "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        ValorAdicional.Clear()
        While dr.Read

            ValorAdicional.Add(New ValorAdicional(dr(0), dr(1).ToString, dr(2)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazValorAdicionalPorID(ByRef vValorAdicional As ValorAdicional, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ValorAdicionalDAO:TrazValorAdicionalID"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT id, descricao, valor FROM valor_adicional WHERE id = " & vValorAdicional.Id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vValorAdicional

                .Id = dr(0)
                .Descricao = dr(1).ToString
                .Valor = dr(2)
            End With
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazValorAdicionalPorNome(ByRef vValorAdicional As ValorAdicional, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ValorAdicionalDAO:TrazValorAdicionalNome"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT id, descricao, valor FROM valor_adicional WHERE descricao = '" & vValorAdicional.Descricao & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vValorAdicional

                .Id = dr(0)
                .Descricao = dr(1).ToString
                .Valor = dr(2)
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazValorAdicionalPorNomeDaLista(ByRef vValorAdicional As ValorAdicional) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As ValorAdicional In MdlConexaoBD.ListaValorAdicional

            If a.Descricao.Equals(vValorAdicional.Descricao) Then

                With vValorAdicional

                    .Id = a.Id
                    .Descricao = a.Descricao
                    .Valor = a.Valor
                End With
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazValorAdicionalPorNomeDaLista(ByRef vValorAdicional As ValorAdicional, ByVal ListaValorAdicionals As List(Of ValorAdicional)) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As ValorAdicional In ListaValorAdicionals

            If a.Descricao.Equals(vValorAdicional.Descricao) Then

                With vValorAdicional

                    .Id = a.Id
                    .Descricao = a.Descricao
                    .Valor = a.Valor
                End With
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Sub PreencheCboValorAdicionalBD(ByRef cboValorAdicional As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ValorAdicionalDAO:PreencheCboValorAdicional"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT descricao, valor FROM valor_adicional "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboValorAdicional.Items.Clear()
        If dr.HasRows = True Then
            cboValorAdicional.AutoCompleteCustomSource.Clear()
            cboValorAdicional.Items.Clear()
            cboValorAdicional.Refresh()
            While dr.Read

                cboValorAdicional.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboValorAdicional.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboValorAdicional.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboValorAdicionalPesquisaBD(ByRef cboValorAdicional As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ValorAdicionalDAO:PreencheCboValorAdicionals"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT descricao, valor FROM valor_adicional "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboValorAdicional.Items.Clear()
        cboValorAdicional.AutoCompleteCustomSource.Clear()
        cboValorAdicional.Items.Clear()
        cboValorAdicional.Refresh()
        cboValorAdicional.AutoCompleteCustomSource.Add("<< NENHUM >>")
        cboValorAdicional.Items.Add("<< NENHUM >>")
        If dr.HasRows = True Then
            

            While dr.Read

                cboValorAdicional.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboValorAdicional.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboValorAdicional.SelectedIndex = -1
            If cboValorAdicional.Items.Count > 1 Then cboValorAdicional.SelectedIndex = 0
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboValorAdicionalLista(ByRef cboValorAdicional As ComboBox, ByVal listValorAdicionals As List(Of ValorAdicional))

        If listValorAdicionals.Count > 0 Then

            cboValorAdicional.AutoCompleteCustomSource.Clear()
            cboValorAdicional.Items.Clear()
            cboValorAdicional.Refresh()

            For Each a As ValorAdicional In listValorAdicionals

                cboValorAdicional.AutoCompleteCustomSource.Add(a.Descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboValorAdicional.Items.Add(a.Descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
        End If

    End Sub

    Public Sub PreencheCboValorAdicionalListaPesquisa(ByRef cboValorAdicional As ComboBox, ByVal listValorAdicionals As List(Of ValorAdicional))

        If listValorAdicionals.Count > 0 Then

            cboValorAdicional.AutoCompleteCustomSource.Clear()
            cboValorAdicional.Items.Clear()
            cboValorAdicional.Refresh()
            cboValorAdicional.AutoCompleteCustomSource.Add("<< TODOS >>")
            cboValorAdicional.Items.Add("<< TODOS >>")
            For Each a As ValorAdicional In listValorAdicionals

                cboValorAdicional.AutoCompleteCustomSource.Add(a.Descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboValorAdicional.Items.Add(a.Descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
            cboValorAdicional.SelectedIndex = 0
        End If

    End Sub

    Public Sub PreencheCboValorAdicionalRelatorio(ByRef cboValorAdicional As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ValorAdicionalDAO:PreencheCboValorAdicional"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, descricao, valor FROM valor_adicional "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboValorAdicional.Items.Clear()
        If dr.HasRows = True Then
            cboValorAdicional.AutoCompleteCustomSource.Clear()
            cboValorAdicional.Items.Clear()
            cboValorAdicional.Refresh()
            cboValorAdicional.AutoCompleteCustomSource.Add("< TODOS >")
            cboValorAdicional.Items.Add("< TODOS >")

            While dr.Read

                cboValorAdicional.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboValorAdicional.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboValorAdicional.SelectedIndex = -1
            If cboValorAdicional.Items.Count > 1 Then cboValorAdicional.SelectedIndex = 0
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delValorAdicional(ByVal vValorAdicional As ValorAdicional, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM valor_adicional WHERE id = @id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vValorAdicional.Id)

        comm.ExecuteNonQuery()

        TrazListValorAdicionalDoBD(MdlConexaoBD.ListaValorAdicional, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function ValorAdicionalConsulta(ByRef ValorAdicional As ValorAdicional, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ValorAdicionalDAO:ValorAdicionalConsulta"":: " & ex.Message)
            Return False
        End Try

        consulta = Query
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader
        If dr.HasRows Then
            Return True
        Else
            Return False
        End If

        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

End Class
