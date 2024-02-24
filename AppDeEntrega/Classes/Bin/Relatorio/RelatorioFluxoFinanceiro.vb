Public Class RelatorioFluxoFinanceiro

    Private _Coluna_Texto1 As String
    Private _Coluna_Texto2 As String
    Private _Coluna_Texto3 As String
    Private _Coluna_Texto4 As String
    Private _Coluna_Texto5 As String
    Private _Coluna_Valor1 As Double
    Private _Coluna_Valor2 As Double

    Sub New()
        zeraValores()
    End Sub

    Sub New(vRelatorio As RelatorioFluxoFinanceiro)

        Me.zeraValores()
        If IsNothing(vRelatorio) Then Return
        With Me
            ._Coluna_Texto1 = vRelatorio.Texto1
            ._Coluna_Texto2 = vRelatorio.Texto2
            ._Coluna_Texto3 = vRelatorio.Texto3
            ._Coluna_Texto4 = vRelatorio.Texto4
            ._Coluna_Texto5 = vRelatorio.Texto5
            ._Coluna_Valor1 = vRelatorio.Valor1
            ._Coluna_Valor2 = vRelatorio.Valor2
        End With
    End Sub

    Sub zeraValores()

        With Me
            ._Coluna_Texto1 = ""
            ._Coluna_Texto2 = ""
            ._Coluna_Texto3 = ""
            ._Coluna_Texto4 = ""
            ._Coluna_Texto4 = ""
            ._Coluna_Valor1 = 0.0
            ._Coluna_Valor2 = 0.0
        End With
    End Sub

    Sub SetaValores(vRelatorio As RelatorioFluxoFinanceiro)

        Me.zeraValores()
        If IsNothing(vRelatorio) Then Return
        With Me
            ._Coluna_Texto1 = vRelatorio.Texto1
            ._Coluna_Texto2 = vRelatorio.Texto2
            ._Coluna_Texto3 = vRelatorio.Texto3
            ._Coluna_Texto4 = vRelatorio.Texto4
            ._Coluna_Texto5 = vRelatorio.Texto5
            ._Coluna_Valor1 = vRelatorio.Valor1
            ._Coluna_Valor2 = vRelatorio.Valor2
        End With
    End Sub

    Public Property Texto1() As String
        Get
            Return _Coluna_Texto1
        End Get
        Set(value As String)
            _Coluna_Texto1 = value
        End Set
    End Property

    Public Property Texto2() As String
        Get
            Return _Coluna_Texto2
        End Get
        Set(value As String)
            _Coluna_Texto2 = value
        End Set
    End Property

    Public Property Texto3() As String
        Get
            Return _Coluna_Texto3
        End Get
        Set(value As String)
            _Coluna_Texto3 = value
        End Set
    End Property

    Public Property Texto4() As String
        Get
            Return _Coluna_Texto4
        End Get
        Set(value As String)
            _Coluna_Texto4 = value
        End Set
    End Property

    Public Property Texto5() As String
        Get
            Return _Coluna_Texto5
        End Get
        Set(value As String)
            _Coluna_Texto5 = value
        End Set
    End Property

    Public Property Valor1() As Double
        Get
            Return _Coluna_Valor1
        End Get
        Set(value As Double)
            _Coluna_Valor1 = value
        End Set
    End Property

    Public Property Valor2() As Double
        Get
            Return _Coluna_Valor2
        End Get
        Set(value As Double)
            _Coluna_Valor2 = value
        End Set
    End Property

End Class
