Public Class EntradaDeProdutos

    Private _id As Int64
    Private _descricao_produto As String
    Private _data_entrada As Date
    Private _quantidade As Double
    Private _fornecedor_id As Int64
    Private _fornecedor_nome As String
    Private _cidade_id As Int64
    Private _cidade_nome As String
    Private _produto_id As Int64

    Sub New()
        Me.ZeraValores()
    End Sub

    Sub New(vEntradaDeProduto As EntradaDeProdutos)

        Me.ZeraValores()
        With Me
            ._id = vEntradaDeProduto.Id
            ._descricao_produto = vEntradaDeProduto.DescricaoProduto
            ._data_entrada = vEntradaDeProduto.DataEntrada
            ._quantidade = vEntradaDeProduto.Quantidade
            ._fornecedor_id = vEntradaDeProduto.FornecedorID
            ._fornecedor_nome = vEntradaDeProduto.FornecedorNome
            ._cidade_id = vEntradaDeProduto.CidadeID
            ._cidade_nome = vEntradaDeProduto.CidadeNome
            ._produto_id = vEntradaDeProduto.ProdutoId
        End With
    End Sub

    Sub SetaValores(vEntradaDeProduto As EntradaDeProdutos)

        Me.ZeraValores()
        With Me
            ._id = vEntradaDeProduto.Id
            ._descricao_produto = vEntradaDeProduto.DescricaoProduto
            ._data_entrada = vEntradaDeProduto.DataEntrada
            ._quantidade = vEntradaDeProduto.Quantidade
            ._fornecedor_id = vEntradaDeProduto.FornecedorID
            ._fornecedor_nome = vEntradaDeProduto.FornecedorNome
            ._cidade_id = vEntradaDeProduto.CidadeID
            ._cidade_nome = vEntradaDeProduto.CidadeNome
            ._produto_id = vEntradaDeProduto.ProdutoId
        End With
    End Sub

    Sub ZeraValores()

        With Me
            ._id = 0
            ._descricao_produto = ""
            ._data_entrada = Nothing
            ._quantidade = 0.0
            ._fornecedor_id = 0
            ._fornecedor_nome = ""
            ._cidade_id = 0
            ._cidade_nome = ""
            ._produto_id = 0
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

    Public Property ProdutoId() As Int64
        Get
            Return _produto_id
        End Get
        Set(value As Int64)
            _produto_id = value
        End Set
    End Property

    Public Property DescricaoProduto() As String
        Get
            Return _descricao_produto
        End Get
        Set(value As String)
            _descricao_produto = value
        End Set
    End Property

    Public Property DataEntrada() As Date
        Get
            Return _data_entrada
        End Get
        Set(value As Date)
            _data_entrada = value
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

End Class
