Public Class SaidaDeProdutos

    Private _id As Int64
    Private _data_saida As Date
    Private _entregador_id As Int64
    Private _entregador_nome As String
    Private _cidade_id As Int64
    Private _cidade_nome As String
    Private _produto_id As Int64
    Private _produto_descricao As String
    Private _quantidade As Double
    Private _fornecedor_id As Int64
    Private _fornecedor_nome As String
    Private _comisao As Double
    Private _descricao_rota As String
    Private _finalizado As Boolean
    Private _devolvido As Boolean
    Private _data_devolucao As Date
    Private _data_entrega As Date

    Sub New()
        Me.ZeraValores()
    End Sub

    Sub New(vSaidaDeProduto As SaidaDeProdutos)

        Me.ZeraValores()
        With Me
            ._id = vSaidaDeProduto.Id
            ._data_saida = vSaidaDeProduto.DataSaida
            ._entregador_id = vSaidaDeProduto.EntregadorID
            ._entregador_nome = vSaidaDeProduto.EntregadorNome
            ._cidade_id = vSaidaDeProduto.CidadeID
            ._cidade_nome = vSaidaDeProduto.CidadeNome
            ._produto_id = vSaidaDeProduto.ProdutoID
            ._produto_descricao = vSaidaDeProduto.ProdutoDescricao
            ._quantidade = vSaidaDeProduto.Quantidade
            ._fornecedor_id = vSaidaDeProduto.FornecedorID
            ._fornecedor_nome = vSaidaDeProduto.FornecedorNome
            ._comisao = vSaidaDeProduto.Comissao
            ._descricao_rota = vSaidaDeProduto.DescricaoRota
            ._finalizado = vSaidaDeProduto.Finalizado
            ._devolvido = vSaidaDeProduto.Devolvido
            ._data_devolucao = vSaidaDeProduto.DataDevolucao
            ._data_entrega = vSaidaDeProduto.DataEntrega
        End With
    End Sub

    Sub SetaValores(vSaidaDeProduto As SaidaDeProdutos)

        Me.ZeraValores()
        With Me
            ._id = vSaidaDeProduto.Id
            ._data_saida = vSaidaDeProduto.DataSaida
            ._entregador_id = vSaidaDeProduto.EntregadorID
            ._entregador_nome = vSaidaDeProduto.EntregadorNome
            ._cidade_id = vSaidaDeProduto.CidadeID
            ._cidade_nome = vSaidaDeProduto.CidadeNome
            ._produto_id = vSaidaDeProduto.ProdutoID
            ._produto_descricao = vSaidaDeProduto.ProdutoDescricao
            ._quantidade = vSaidaDeProduto.Quantidade
            ._fornecedor_id = vSaidaDeProduto.FornecedorID
            ._fornecedor_nome = vSaidaDeProduto.FornecedorNome
            ._comisao = vSaidaDeProduto.Comissao
            ._descricao_rota = vSaidaDeProduto.DescricaoRota
            ._finalizado = vSaidaDeProduto.Finalizado
            ._devolvido = vSaidaDeProduto.Devolvido
            ._data_devolucao = vSaidaDeProduto.DataDevolucao
            ._data_entrega = vSaidaDeProduto.DataEntrega
        End With
    End Sub

    Sub ZeraValores()

        With Me
            ._id = 0
            ._data_saida = Nothing
            ._entregador_id = 0
            ._entregador_nome = ""
            ._cidade_id = 0
            ._cidade_nome = ""
            ._produto_id = 0
            ._produto_descricao = ""
            ._quantidade = 0.0
            ._fornecedor_id = 0
            ._fornecedor_nome = ""
            ._comisao = 0.0
            ._descricao_rota = ""
            ._finalizado = False
            ._devolvido = False
            ._data_devolucao = Nothing
            ._data_entrega = Nothing
        End With
        
    End Sub

    Public Property Id() As Int64
        Get
            Return _id
        End Get
        Set(value As Int64)
            _id = value
        End Set
    End Property

    Public Property DataSaida() As Date
        Get
            Return _data_saida
        End Get
        Set(value As Date)
            _data_saida = value
        End Set
    End Property

    Public Property EntregadorID() As Int64
        Get
            Return _entregador_id
        End Get
        Set(value As Int64)
            _entregador_id = value
        End Set
    End Property

    Public Property EntregadorNome() As String
        Get
            Return _entregador_nome
        End Get
        Set(value As String)
            _entregador_nome = value
        End Set
    End Property

    Public Property CidadeID() As Int64
        Get
            Return _cidade_id
        End Get
        Set(value As Int64)
            _cidade_id = value
        End Set
    End Property

    Public Property CidadeNome() As String
        Get
            Return _cidade_nome
        End Get
        Set(value As String)
            _cidade_nome = value
        End Set
    End Property

    Public Property ProdutoID() As Int64
        Get
            Return _produto_id
        End Get
        Set(value As Int64)
            _produto_id = value
        End Set
    End Property

    Public Property ProdutoDescricao() As String
        Get
            Return _produto_descricao
        End Get
        Set(value As String)
            _produto_descricao = value
        End Set
    End Property

    Public Property Quantidade() As Double
        Get
            Return _quantidade
        End Get
        Set(value As Double)
            _quantidade = value
        End Set
    End Property

    Public Property FornecedorID() As Int64
        Get
            Return _fornecedor_id
        End Get
        Set(value As Int64)
            _fornecedor_id = value
        End Set
    End Property

    Public Property FornecedorNome() As String
        Get
            Return _fornecedor_nome
        End Get
        Set(value As String)
            _fornecedor_nome = value
        End Set
    End Property

    Public Property Comissao() As Double
        Get
            Return _comisao
        End Get
        Set(value As Double)
            _comisao = value
        End Set
    End Property

    Public Property DescricaoRota() As String
        Get
            Return _descricao_rota
        End Get
        Set(value As String)
            _descricao_rota = value
        End Set
    End Property

    Public Property Finalizado() As Boolean
        Get
            Return _finalizado
        End Get
        Set(value As Boolean)
            _finalizado = value
        End Set
    End Property
    
    Public Property Devolvido() As Boolean
        Get
            Return _devolvido
        End Get
        Set(value As Boolean)
            _devolvido = value
        End Set
    End Property

    Public Property DataDevolucao() As Date
        Get
            Return _data_devolucao
        End Get
        Set(value As Date)
            If IsDate(value) Then
                _data_devolucao = value
            Else
                _data_devolucao = Nothing
            End If

        End Set
    End Property

    Public Property DataEntrega() As Date
        Get
            Return _data_entrega
        End Get
        Set(value As Date)
            If IsDate(value) Then
                _data_entrega = value
            Else
                _data_entrega = Nothing
            End If

        End Set
    End Property
    
End Class
