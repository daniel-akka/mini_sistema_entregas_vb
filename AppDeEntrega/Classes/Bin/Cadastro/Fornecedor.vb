Public Class Fornecedor

    Private _id As Int64
    Private _nome As String
    Private _comissao_fornecedor As Double
    Private _comissao_entregador As Double
    Private _valorKM As Double

    Sub New()
        Me.ZeraValores()
    End Sub

    Sub New(vFornecedor As Fornecedor)

        Me.ZeraValores()
        With Me
            ._id = vFornecedor.Id
            ._nome = vFornecedor.Nome
            ._comissao_fornecedor = vFornecedor.ComissaoFornecedor
            ._comissao_entregador = vFornecedor.ComissaoEntregador
            ._valorKM = vFornecedor.ValorKM
        End With
    End Sub

    Sub New(vId As Int64, vNome As String, vComissaoFornecedor As Double, vComissaoEntregador As Double,
            vValorKM As Double)

        With Me
            ._id = vId
            ._nome = vNome
            ._comissao_fornecedor = vComissaoFornecedor
            ._comissao_entregador = vComissaoEntregador
            ._valorKM = vValorKM
        End With
    End Sub

    Sub SetaFornecedor(vFornecedor As Fornecedor)

        If IsNothing(vFornecedor) Then Return
        Me.ZeraValores()
        With Me
            ._id = vFornecedor.Id
            ._nome = vFornecedor.Nome
            ._comissao_fornecedor = vFornecedor.ComissaoFornecedor
            ._comissao_entregador = vFornecedor.ComissaoEntregador
            ._valorKM = vFornecedor.ValorKM
        End With
    End Sub

    Sub ZeraValores()
        _id = 0
        _nome = ""
        _comissao_fornecedor = 0.0
        _comissao_entregador = 0.0
        _valorKM = 0.0
    End Sub

    Public Property Id() As Int64
        Get
            Return _id
        End Get
        Set(value As Int64)
            _id = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return _nome
        End Get
        Set(value As String)
            _nome = value
        End Set
    End Property

    Public Property ComissaoFornecedor() As Double
        Get
            Return _comissao_fornecedor
        End Get
        Set(value As Double)
            _comissao_fornecedor = value
        End Set
    End Property

    Public Property ComissaoEntregador() As Double
        Get
            Return _comissao_entregador
        End Get
        Set(value As Double)
            _comissao_entregador = value
        End Set
    End Property

    Public Property ValorKM() As Double
        Get
            Return _valorKM
        End Get
        Set(value As Double)
            _valorKM = value
        End Set
    End Property

End Class
