using System.ComponentModel.DataAnnotations;

namespace CP2.Entities;

public class Categoria
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o nome da categoria")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 100 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [StringLength(255)]
    public string? Descricao { get; set; }
}