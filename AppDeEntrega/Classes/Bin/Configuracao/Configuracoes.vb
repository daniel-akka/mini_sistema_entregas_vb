Public Class Configuracoes

    Public id As Int64 = 1
    Public TipoPagamentoComissao As String = "F"
    Public IniciaisDosProdutos As New List(Of String)
    Public IniciaisDosProdutosTEXT As String = ""

    Public Function validaIniciaisProduto(vDescricaoProduto As String) As Boolean

        If Me.IniciaisDosProdutos.Count < 1 Then Return True
        For Each Str As String In Me.IniciaisDosProdutos
            If vDescricaoProduto.StartsWith(Str) Then Return True
        Next

        Return False
    End Function

    Public Sub preencheIniciais(vIniciais As String)

        Me.IniciaisDosProdutos.Clear()
        Try
            For Each inicial As String In vIniciais.Split("|")

                If inicial.Equals("") = False Then
                    Me.IniciaisDosProdutos.Add(inicial)
                End If
            Next
        Catch ex As Exception
        End Try
        
    End Sub

End Class
