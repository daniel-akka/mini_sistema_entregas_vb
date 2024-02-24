Public Class Cidade

    Private _id As Int64
    Private _nome As String
    Private _distanciaKm As Double

    Sub New()
        Me.ZeraValores()
    End Sub

    Sub New(vID As Int64, vNome As String, vDistanciaKM As Double)
        With Me
            ._id = vID
            ._nome = vNome
            ._distanciaKm = vDistanciaKM
        End With
    End Sub
    Sub New(vCidade As Cidade)

        Me.ZeraValores()
        With Me
            ._id = vCidade.Id
            ._nome = vCidade.Nome
            ._distanciaKm = vCidade.DistanciaKM
        End With
    End Sub

    Sub SetaCidade(vCidade As Cidade)

        If IsNothing(vCidade) Then Return
        Me.ZeraValores()
        With Me
            ._id = vCidade.Id
            ._nome = vCidade.Nome
            ._distanciaKm = vCidade.DistanciaKM
        End With
    End Sub

    Sub ZeraValores()
        _id = 0
        _nome = ""
        _distanciaKm = 0
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

    Public Property DistanciaKM() As Double
        Get
            Return _distanciaKm
        End Get
        Set(value As Double)
            _distanciaKm = value
        End Set
    End Property

End Class
