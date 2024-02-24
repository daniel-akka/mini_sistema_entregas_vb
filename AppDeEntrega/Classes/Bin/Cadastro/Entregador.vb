Public Class Entregador

    Private _id As Int64
    Private _nome As String
    Private _comissao As Double

    Sub New()
        Me.ZeraValores()
    End Sub

    Sub New(vId As Int64, vNome As String, vComissao As Double)
        With Me
            ._id = vId
            ._nome = vNome
            ._comissao = vComissao
        End With

    End Sub
    Sub New(vEntregador As Entregador)

        Me.ZeraValores()
        With Me
            ._id = vEntregador.Id
            ._nome = vEntregador.Nome
            ._comissao = vEntregador.Comissao
        End With
    End Sub

    Sub SetaEntregador(vEntregador As Entregador)

        If IsNothing(vEntregador) Then Return
        Me.ZeraValores()
        With Me
            ._id = vEntregador.Id
            ._nome = vEntregador.Nome
            ._comissao = vEntregador.Comissao
        End With
    End Sub

    Sub ZeraValores()
        _id = 0
        _nome = ""
        _comissao = 0.0
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

    Public Property Comissao() As Double
        Get
            Return _comissao
        End Get
        Set(value As Double)
            _comissao = value
        End Set
    End Property

End Class
