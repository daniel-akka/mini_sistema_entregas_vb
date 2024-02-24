Imports Npgsql
Public Class RotaDAO


    Public Sub incRota(ByVal vRota As Rota, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO rotas(id, descricao, data_rota, fornecedor_id, fornecedor_nome, valor_km, "
        sql += "quantidade_km, total_comissao) "
        sql += "VALUES (DEFAULT, @descricao, @data_rota, @fornecedor_id, @fornecedor_nome, "
        sql += "@valor_km, @quantidade_km, @total_comissao) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@descricao", vRota.Descricao)
        comm.Parameters.Add("@data_rota", vRota.DataRota)
        comm.Parameters.Add("@fornecedor_id", vRota.FornecedorId)
        comm.Parameters.Add("@fornecedor_nome", vRota.FornecedorNome)
        comm.Parameters.Add("@valor_km", vRota.ValorKM)
        comm.Parameters.Add("@quantidade_km", vRota.QuantidadeKM)
        comm.Parameters.Add("@total_comissao", vRota.TotalComissao)

        comm.ExecuteNonQuery()

        TrazListRotasBD(MdlConexaoBD.ListaDeRotas, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altRota(ByVal vRota As Rota, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE rotas SET descricao = @descricao, data_rota = @data_rota, fornecedor_id = @fornecedor_id, "
        sql += "fornecedor_nome = @fornecedor_nome, valor_km = @valor_km, "
        sql += "quantidade_km = @quantidade_km, total_comissao = @total_comissao "
        sql += "WHERE id = @id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentross
        comm.Parameters.Add("@id", vRota.Id)
        comm.Parameters.Add("@descricao", vRota.Descricao)
        comm.Parameters.Add("@data_rota", vRota.DataRota)
        comm.Parameters.Add("@fornecedor_id", vRota.FornecedorId)
        comm.Parameters.Add("@fornecedor_nome", vRota.FornecedorNome)
        comm.Parameters.Add("@valor_km", vRota.ValorKM)
        comm.Parameters.Add("@quantidade_km", vRota.QuantidadeKM)
        comm.Parameters.Add("@total_comissao", vRota.TotalComissao)

        comm.ExecuteNonQuery()

        TrazListRotasBD(MdlConexaoBD.ListaDeRotas, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function RotaConsulta(ByRef vRota As Rota, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""RotaDAO:TrazRota"":: " & ex.Message)
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

    Public Sub CopiaListaRotaDeOutraLISTA(ByRef NovaLista As List(Of Rota), ByVal ListaAnterior As List(Of Rota))

        Dim Rota As New Rota
        NovaLista.Clear()
        For Each lc As Rota In ListaAnterior

            Rota.ZeraValores()
            Rota.SetaRota(lc)
            NovaLista.Add(New Rota(Rota))
        Next

    End Sub

    Public Function TrazRotaPorID(ByRef vRota As Rota, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""RotaDAO:TrazRota"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT id, descricao, data_rota, fornecedor_id, fornecedor_nome, valor_km, " '5
        consulta += "quantidade_km, total_comissao " '7
        consulta += "FROM rotas WHERE id = " & vRota.Id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vRota

                .Id = dr(0)
                .Descricao = dr(1).ToString
                .DataRota = dr(2)
                .FornecedorId = dr(3)
                .FornecedorNome = dr(4).ToString
                .ValorKM = dr(5)
                .QuantidadeKM = dr(6)
                .TotalComissao = dr(7)
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub TrazRotaDaListaPorID(ByRef vRota As Rota, ByVal ListRotaes As List(Of Rota))


        For Each p As Rota In ListRotaes
            If p.Id.Equals(vRota.Id) Then

                vRota.SetaRota(p)
                Exit For
            End If

        Next

    End Sub

    Public Sub TrazListRotasBD(ByRef vListaDeRotas As List(Of Rota), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vRota As New Rota


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""RotaDAO:TrazListRotaes"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, descricao, data_rota, fornecedor_id, fornecedor_nome, valor_km, " '5
        consulta += "quantidade_km, total_comissao " '7
        consulta += "FROM rotas "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        vListaDeRotas.Clear()
        While dr.Read

            With vRota

                .Id = dr(0)
                .Descricao = dr(1).ToString
                .DataRota = dr(2)
                .FornecedorId = dr(3)
                .FornecedorNome = dr(4).ToString
                .ValorKM = dr(5)
                .QuantidadeKM = dr(6)
                .TotalComissao = dr(7)
            End With

            vListaDeRotas.Add(New Rota(vRota))
            vRota.ZeraValores()
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub TrazListRotasBD_WHERE(ByRef vListaDeRotas As List(Of Rota), ByVal strConection As String, _
                               Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vRota As New Rota


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""RotaDAO:TrazListRotaes"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT id, descricao, data_rota, fornecedor_id, fornecedor_nome, valor_km, " '5
        consulta += "quantidade_km, total_comissao " '7
        consulta += "FROM rotas "
        If Not condicao.Equals("") Then
            consulta += condicao
        End If

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        vListaDeRotas.Clear()
        While dr.Read

            With vRota

                .Id = dr(0)
                .Descricao = dr(1).ToString
                .DataRota = dr(2)
                .FornecedorId = dr(3)
                .FornecedorNome = dr(4).ToString
                .ValorKM = dr(5)
                .QuantidadeKM = dr(6)
                .TotalComissao = dr(7)
            End With

            vListaDeRotas.Add(New Rota(vRota))
            vRota.zeraValores()
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delRota(ByVal vRota As Rota, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM rotas WHERE id = @id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", vRota.Id)

        comm.ExecuteNonQuery()

        TrazListRotasBD(MdlConexaoBD.ListaDeRotas, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function TrazIdUltimaRota(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction) As Int64


        Dim dr As NpgsqlDataReader
        Dim com As New NpgsqlCommand
        Dim consulta As String = ""
        Dim mId As Integer = 0

        Try
            consulta = "SELECT MAX(id) FROM rotas"
            com.Transaction = transacao
            com = New NpgsqlCommand(consulta, conexao)
            dr = com.ExecuteReader

            While dr.Read
                mId = dr(0)
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox("ERRO ao Trazer ID Ultima Venda Seviço - VendaServicoDAO:: " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            com = Nothing : dr = Nothing : consulta = Nothing
        End Try


        Return mId
    End Function

End Class
