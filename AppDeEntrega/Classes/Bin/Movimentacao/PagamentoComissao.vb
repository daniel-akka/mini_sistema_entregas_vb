Public Class PagamentoComissao

    Private _id As Int64
    Private _data_pagamento As Date
    Private _entregador_id As Int64
    Private _entregador_nome As String
    Private _valor_pago As Double
    Private _observacao As String
    Private _fornecedor_id As Int64
    Private _fornecedor_nome As String

    Sub New()
        ZeraValores()
    End Sub

    Sub New(vPagamento As PagamentoComissao)

        If IsNothing(vPagamento) Then
            Me.ZeraValores()
            Return
        End If

        With Me
            ._id = vPagamento.Id
            ._data_pagamento = vPagamento.DataPagamento
            ._entregador_id = vPagamento.EntregadorID
            ._entregador_nome = vPagamento.EntregadorNome
            ._valor_pago = vPagamento.ValorPago
            ._observacao = vPagamento.Observacao
            ._fornecedor_id = vPagamento.FornecedorID
            ._fornecedor_nome = vPagamento.FornecedorNome
        End With
    End Sub

    Sub SetaPagamentoComissao(vPagamento As PagamentoComissao)

        If IsNothing(vPagamento) Then
            Me.ZeraValores()
            Return
        End If

        With Me
            ._id = vPagamento.Id
            ._data_pagamento = vPagamento.DataPagamento
            ._entregador_id = vPagamento.EntregadorID
            ._entregador_nome = vPagamento.EntregadorNome
            ._valor_pago = vPagamento.ValorPago
            ._observacao = vPagamento.Observacao
            ._fornecedor_id = vPagamento.FornecedorID
            ._fornecedor_nome = vPagamento.FornecedorNome
        End With

    End Sub

    Sub ZeraValores()

        With Me
            ._id = 0
            ._data_pagamento = Nothing
            ._entregador_id = 0
            ._entregador_nome = ""
            ._valor_pago = 0.0
            ._observacao = ""
            ._fornecedor_id = 0
            ._fornecedor_nome = ""
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

    Public Property DataPagamento() As Date
        Get
            Return _data_pagamento
        End Get
        Set(value As Date)
            _data_pagamento = value
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

    Public Property ValorPago() As Double
        Get
            Return _valor_pago
        End Get
        Set(value As Double)
            _valor_pago = value
        End Set
    End Property

    Public Property Observacao() As String
        Get
            Return _observacao
        End Get
        Set(value As String)
            _observacao = value
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
End Class
