using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.Entities;

[Table("TB_CLIENTE")]
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
    [Required(ErrorMessage = "Informe o endereço do cliente")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "O endereço deve conter entre 10 e 100 caracteres")]
    public string Endereco { get; set; } = string.Empty;
}