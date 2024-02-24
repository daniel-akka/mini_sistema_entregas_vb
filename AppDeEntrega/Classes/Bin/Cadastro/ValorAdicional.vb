Public Class ValorAdicional

    Private _id As Int64
    Private _descricao As String
    Private _valor As Double

    Sub New()
        Me.ZeraValores()
    End Sub

    Sub New(vId As Int64, vDescricao As String, vValor As Double)

        With Me
            ._id = vId
            ._descricao = vDescricao
            ._valor = vValor
        End With
    End Sub

    Sub New(vValorAdicional As ValorAdicional)

        Me.ZeraValores()
        With Me
            ._id = vValorAdicional.Id
            ._descricao = vValorAdicional.Descricao
            ._valor = vValorAdicional.Valor
        End With
    End Sub

    Sub ZeraValores()
        _id = 0
        _descricao = ""
        _valor = 0.0
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

    Public Property Valor() As Double
        Get
            Return _valor
        End Get
        Set(value As Double)
            _valor = value
        End Set
    End Property

End Class
