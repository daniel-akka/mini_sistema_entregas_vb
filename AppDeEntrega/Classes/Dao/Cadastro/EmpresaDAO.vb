Imports Npgsql
Public Class EmpresaDAO

    Public Sub incEmpresa(ByVal vEmpresa As Empresa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO empresa(id, nome) "
        sql += "VALUES (DEFAULT, @nome)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@nome", vEmpresa.Nome)
        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
        MdlConexaoBD.empresaPadrao.SetaEmpresa(TrazEmpresa(MdlConexaoBD.conectionPadrao))
    End Sub

    Public Sub altEmpresa(ByVal vEmpresa As Empresa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE empresa SET nome = @nome WHERE id = @id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vEmpresa.Id)
        comm.Parameters.Add("@nome", vEmpresa.Nome)
        comm.ExecuteNonQuery()

        MdlConexaoBD.empresaPadrao.SetaEmpresa(TrazEmpresa(MdlConexaoBD.conectionPadrao))
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaEmpresa(ByVal vEmpresa As Empresa, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(vEmpresa.Nome).Equals("") Then MsgBox("Informe um NOME para a Empresa!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT nome FROM empresa WHERE nome = '" & vEmpresa.Nome & "'"
        Else
            consulta = "SELECT nome FROM empresa WHERE id <> " & vEmpresa.Id & " AND nome = '" & vEmpresa.Nome & "'"
        End If
        If EmpresaConsulta(vEmpresa, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("A Empresa """ & vEmpresa.Nome & """ já existe em outro CADASTRO !") : Return False
        End If

        Return True
    End Function

    Public Function TrazEmpresa(ByVal strConection As String) As Empresa

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EmpresaDAO:TrazEmpresa"":: " & ex.Message)
            Return Nothing
        End Try

        consulta = "SELECT id, nome FROM empresa LIMIT 1 "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Dim novaEmpresa As New Empresa
        While dr.Read

            With novaEmpresa
                .Id = dr(0)
                .Nome = dr(1).ToString
            End With
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return novaEmpresa
    End Function

    Public Sub PreencheCboEmpresasBD(ByRef cboEmpresa As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EmpresaDAO:PreencheCboEmpresas"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT nome, id FROM empresa "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY nome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboEmpresa.Items.Clear()
        If dr.HasRows = True Then
            cboEmpresa.AutoCompleteCustomSource.Clear()
            cboEmpresa.Items.Clear()
            cboEmpresa.Refresh()
            While dr.Read

                cboEmpresa.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboEmpresa.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboEmpresa.SelectedIndex = -1
            If cboEmpresa.Items.Count > 0 Then cboEmpresa.SelectedIndex = 0

        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboEmpresasPesquisaBD(ByRef cboEmpresa As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EmpresaDAO:PreencheCboEmpresas"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT nome, id FROM empresa "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY nome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboEmpresa.Items.Clear()
        If dr.HasRows = True Then
            cboEmpresa.AutoCompleteCustomSource.Clear()
            cboEmpresa.Items.Clear()
            cboEmpresa.Refresh()
            cboEmpresa.AutoCompleteCustomSource.Add("<< TODOS >>")
            cboEmpresa.Items.Add("<< TODOS >>")

            While dr.Read

                cboEmpresa.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboEmpresa.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboEmpresa.SelectedIndex = -1
            If cboEmpresa.Items.Count > 0 Then cboEmpresa.SelectedIndex = 0
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delEmpresa(ByVal vEmpresa As Empresa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM empresa WHERE id = @id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vEmpresa.Id)

        comm.ExecuteNonQuery()

        MdlConexaoBD.empresaPadrao.SetaEmpresa(TrazEmpresa(MdlConexaoBD.conectionPadrao))
        comm = Nothing : sql = Nothing

    End Sub

    Public Function EmpresaConsulta(ByRef vEmpresa As Empresa, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EmpresaDAO:EmpresaConsulta"":: " & ex.Message)
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
