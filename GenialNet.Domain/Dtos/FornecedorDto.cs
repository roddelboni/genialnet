namespace GenialNet.Domain.Dtos
{
    public class FornecedorDto
    {    
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty!;   
        public string Cnpj { get; set; } = string.Empty!;     
        public string Endereco { get; set; } = string.Empty!;
        public string Telefone { get; set; } = string.Empty!;
    }
}
