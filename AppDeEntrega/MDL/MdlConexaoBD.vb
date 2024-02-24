Module MdlConexaoBD

    Public conectionPadrao As String = _
    "Server=localhost;Port=5432;UserId=postgres;Password=.akka.;Database=Entregas;" & _
    "maxPoolSize=100;Timeout=7;CommandTimeout=7;"

    Public nomeDoBanco As String = "Entregas"
    Public senhaDoSGBD As String = ".akka."
    Public nomeServidor As String = "localhost"

    Public sincronizado As Boolean = False

    'Objetos Lista:
    Public empresaPadrao As New Empresa
    Public ListaCidades As New List(Of Cidade)
    Public ListaEntregadores As New List(Of Entregador)
    Public ListaFornecedores As New List(Of Fornecedor)
    Public ListaProdutos As New List(Of Produto)
    Public ListaValorAdicional As New List(Of ValorAdicional)
    Public ListaEntradaProduto As New List(Of EntradaDeProdutos)
    Public ListaSaidaProduto As New List(Of SaidaDeProdutos)
    Public ListaDeRotas As New List(Of Rota)
    Public ListaGrupoDespMensal As New List(Of ClGrupoDespMensal)
    Public ListaDespesaMensal As New List(Of ClDespesaMensal)
    Public ListaSubGrupoDespMensal As New List(Of ClSubGrupoDespMensal)

End Module
