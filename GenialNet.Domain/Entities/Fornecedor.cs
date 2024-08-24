namespace GenialNet.Domain.Entities
{
    public class Fornecedor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty!;
        public string Cnpj { get; set; } = string.Empty!;
        public string Endereço {  get; set; } = string.Empty!;
        public string Telefone {  get; set; } = string.Empty!;
        public IList<ProdutoFornecedor> ProdutoFornecedores { get; set; } = new List<ProdutoFornecedor>();
    }
}
