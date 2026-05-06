using System.ComponentModel.DataAnnotations;

namespace CP2.Entities;

public class Pedido
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o cliente do pedido")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Informe o produto do pedido")]
    public int ProdutoId { get; set; }

    [Required(ErrorMessage = "Informe a quantidade do pedido")]
    [Range(1, 999, ErrorMessage = "A quantidade deve ser maior que zero")]
    public int Quantidade { get; set; }

    [Range(0.01, 9999999999.0, ErrorMessage = "Valor inválido")]
    public decimal ValorTotal { get; set; }

    public DateTime DataPedido { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Informe o status do pedido")]
    [StringLength(50, MinimumLength = 3)]
    public string Status { get; set; } = string.Empty;
}