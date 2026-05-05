using System.ComponentModel.DataAnnotations;

namespace CP2.Entities;

public class Cliente
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Informe o nome do cliente")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 100 caracteres")]
    public string Nome { get; set; } =  string.Empty;
    [Required(ErrorMessage = "Informe o e-mail do cliente")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    [StringLength(150)]
    public string Email { get; set; }  = string.Empty;
}