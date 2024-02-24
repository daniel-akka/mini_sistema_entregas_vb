Public Class Produto

    Private _id As Int64
    Private _descricao As String
    Private _fornecedor_id As Int64
    Private _fornecedor_nome As String
    Private _fornecedor_comissao As Double
    Private _fornecedor_comissao_entregador As Double
    Private _adicional_id As Int64
    Private _adicional_descricao As String
    Private _adicional_valor As Double
    Private _data_entrada As Date
    Private _data_saida As Date
    Private _data_entrega As Date
    Private _estoque As Double

    Sub New()
        Me.ZeraValores()
    End Sub

    Sub New(vProduto As Produto)

        Me.ZeraValores()
        With Me
            ._id = vProduto.Id
            ._descricao = vProduto.Descricao
            ._fornecedor_id = vProduto.FornecedorID
            ._fornecedor_nome = vProduto.FornecedorNome
            ._fornecedor_comissao = vProduto.FornecedorComissao
            ._fornecedor_comissao_entregador = vProduto.FornecedorComissaoEntregador
            ._adicional_id = vProduto.AdicionalID
            ._adicional_descricao = vProduto.AdicionalDescricao
            ._adicional_valor = vProduto.AdicionalValor
            ._data_entrada = vProduto.DataEntrada
            ._data_saida = vProduto.DataSaida
            ._data_entrega = vProduto.DataEntrega
            ._estoque = vProduto.Estoque
        End With
    End Sub

    Sub SetaProduto(vProduto As Produto)

        If IsNothing(vProduto) Then Return
        Me.ZeraValores()
        With Me
            ._id = vProduto.Id
            ._descricao = vProduto.Descricao
            ._fornecedor_id = vProduto.FornecedorID
            ._fornecedor_nome = vProduto.FornecedorNome
            ._fornecedor_comissao = vProduto.FornecedorComissao
            ._fornecedor_comissao_entregador = vProduto.FornecedorComissaoEntregador
            ._adicional_id = vProduto.AdicionalID
            ._adicional_descricao = vProduto.AdicionalDescricao
            ._adicional_valor = vProduto.AdicionalValor
            ._data_entrada = vProduto.DataEntrada
            ._data_saida = vProduto.DataSaida
            ._data_entrega = vProduto.DataEntrega
            ._estoque = vProduto.Estoque
        End With
    End Sub

    Sub ZeraValores()

        With Me
            ._id = 0
            ._descricao = ""
            ._fornecedor_id = 0
            ._fornecedor_nome = ""
            ._fornecedor_comissao = 0.0
            ._fornecedor_comissao_entregador = 0.0
            ._adicional_id = 0
            ._adicional_descricao = ""
            ._adicional_valor = 0.0
            ._data_entrada = Nothing
            ._data_saida = Nothing
            ._data_entrega = Nothing
            ._estoque = 0.0
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

    Public Property Descricao() As String
        Get
            Return _descricao
        End Get
        Set(value As String)
            _descricao = value
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

    Public Property FornecedorComissao() As Double
        Get
            Return _fornecedor_comissao
        End Get
        Set(value As Double)
            _fornecedor_comissao = value
        End Set
    End Property

    Public Property FornecedorComissaoEntregador() As Double
        Get
            Return _fornecedor_comissao_entregador
        End Get
        Set(value As Double)
            _fornecedor_comissao_entregador = value
        End Set
    End Property

    Public Property AdicionalID() As Int64
        Get
            Return _adicional_id
        End Get
        Set(value As Int64)
            _adicional_id = value
        End Set
    End Property

    Public Property AdicionalDescricao() As String
        Get
            Return _adicional_descricao
        End Get
        Set(value As String)
            _adicional_descricao = value
        End Set
    End Property

    Public Property AdicionalValor() As Double
        Get
            Return _adicional_valor
        End Get
        Set(value As Double)
            _adicional_valor = value
        End Set
    End Property
    
    Public Property DataEntrada() As Date
        Get
            Return _data_entrada
        End Get
        Set(value As Date)
            If IsDate(value) Then
                _data_entrada = value
            Else
                _data_entrada = Nothing
            End If

        End Set
    End Property

    Public Property DataSaida() As Date
        Get
            Return _data_saida
        End Get
        Set(value As Date)
            If IsDate(value) Then
                _data_saida = value
            Else
                _data_saida = Nothing
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

    Public Property Estoque() As Double
        Get
            Return _estoque
        End Get
        Set(value As Double)
            _estoque = value
        End Set
    End Property


End Class
