Imports Npgsql
Public Class ConfiguracaoDAO

    Public Sub altConfiguracoes(ByVal configuracoes As Configuracoes, ByVal conexao As String)

        Dim connection As New NpgsqlConnection(conexao)
        Dim transacao As NpgsqlTransaction
        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
            connection = Nothing : Return
        End Try


        sql = "UPDATE configuracoes SET tipo_comissao = @tipo_comissao, iniciais_produtos = @iniciais_produtos WHERE id = " & configuracoes.id

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, connection)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", configuracoes.id)
        comm.Parameters.Add("@tipo_comissao", configuracoes.TipoPagamentoComissao)
        comm.Parameters.Add("@iniciais_produtos", configuracoes.IniciaisDosProdutosTEXT)
        comm.ExecuteNonQuery()

        TrazConfiguracoes(MdlConfiguracoes.Configuracoes, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function TrazConfiguracoes(ByRef configuracoes As Configuracoes, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ConfiguracaoDAO:TrazConfiguracoes"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT id, tipo_comissao, iniciais_produtos FROM configuracoes LIMIT 1"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With configuracoes

                .id = dr(0)
                .TipoPagamentoComissao = dr(1).ToString
                .IniciaisDosProdutosTEXT = dr(2).ToString
                configuracoes.preencheIniciais(.IniciaisDosProdutosTEXT)
            End With


        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

End Class
