using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.Entities;
[Table("TB_PRDUTO")]
public class Produto
{
    [Key]
    public int Id { get; set;  }
    [Required(ErrorMessage = "Informe o nome do produto")]
    [StringLength(150,  MinimumLength = 3)]
    public string Nome { get; set; } = string.Empty;
    [Range( 0.01, 9999999999.0, ErrorMessage = "Preço deve ser superior que 0")]
    public decimal Preco { get; set; }
}