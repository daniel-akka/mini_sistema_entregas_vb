Public Class Empresa

    Private _id As Int64
    Private _nome As String

    Sub New()
        Me.ZeraValores()
    End Sub

    Sub New(vEmpresa As Empresa)

        Me.ZeraValores()
        With Me
            ._id = vEmpresa.Id
            ._nome = vEmpresa.Nome
        End With
    End Sub

    Sub SetaEmpresa(vEmpresa As Empresa)

        If IsNothing(vEmpresa) Then Return
        Me.ZeraValores()
        With Me
            ._id = vEmpresa.Id
            ._nome = vEmpresa.Nome
        End With
    End Sub

    Sub ZeraValores()
        _id = 0
        _nome = ""
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


End Class
