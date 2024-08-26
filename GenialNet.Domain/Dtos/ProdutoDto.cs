using GenialNet.Domain.Enums;

namespace GenialNet.Domain.Dtos;

public class ProdutoDto
{       
    public Guid Id { get; set; }
    public string Descricao { get; set; } = string.Empty!;
    public string Marca { get; set; } = string.Empty!;    
    public UnidadeMedida Medida { get; set; }
}
