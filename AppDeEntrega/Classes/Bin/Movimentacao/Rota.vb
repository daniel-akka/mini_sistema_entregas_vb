Public Class Rota

    Private _id As Int64
    Private _descricao As String
    Private _dataRota As Date
    Private _fornecedorId As Int64
    Private _fornecedorNome As String
    Private _valorKm As Double
    Private _quantidadeKM As Double
    Private _totalComissao As Double

    Sub New()

        With Me
            ._id = 0
            ._descricao = ""
            ._dataRota = Date.Now
            ._fornecedorNome = ""
            ._fornecedorId = 0
            ._valorKm = 0.0
            ._quantidadeKM = 0.0
            ._totalComissao = 0.0
        End With
    End Sub

    Sub New(vRotas As Rota)


        With Me

            ._id = vRotas.Id
            ._descricao = vRotas.Descricao
            ._dataRota = vRotas.DataRota
            ._fornecedorNome = vRotas.FornecedorNome
            ._fornecedorId = vRotas.FornecedorId
            ._valorKm = vRotas.ValorKM
            ._quantidadeKM = vRotas.QuantidadeKM
            ._totalComissao = vRotas.TotalComissao
        End With
    End Sub

    Sub SetaRota(vRotas As Rota)

        With Me

            ._id = vRotas.Id
            ._descricao = vRotas.Descricao
            ._dataRota = vRotas.DataRota
            ._fornecedorNome = vRotas.FornecedorNome
            ._fornecedorId = vRotas.FornecedorId
            ._valorKm = vRotas.ValorKM
            ._quantidadeKM = vRotas.QuantidadeKM
            ._totalComissao = vRotas.TotalComissao
        End With
    End Sub

    Sub zeraValores()

        With Me
            ._id = 0
            ._descricao = ""
            ._dataRota = Date.Now
            ._fornecedorNome = ""
            ._fornecedorId = 0
            ._valorKm = 0.0
            ._quantidadeKM = 0.0
            ._totalComissao = 0.0
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

    Public Property DataRota() As Date
        Get
            Return _dataRota
        End Get
        Set(value As Date)
            _dataRota = value
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

    Public Property FornecedorId() As Int64
        Get
            Return _fornecedorId
        End Get
        Set(value As Int64)
            _fornecedorId = value
        End Set
    End Property

    Public Property FornecedorNome() As String
        Get
            Return _fornecedorNome
        End Get
        Set(value As String)
            _fornecedorNome = value
        End Set
    End Property

    Public Property ValorKM() As Double
        Get
            Return _valorKm
        End Get
        Set(value As Double)
            _valorKm = value
        End Set
    End Property

    Public Property QuantidadeKM() As Double
        Get
            Return _quantidadeKM
        End Get
        Set(value As Double)
            _quantidadeKM = value
        End Set
    End Property

    Public Property TotalComissao() As Double
        Get
            Return _totalComissao
        End Get
        Set(value As Double)
            _totalComissao = value
        End Set
    End Property


End Class
