using System.ComponentModel.DataAnnotations;

namespace agenda_api.Models;

public class Contact
{
    [Key] 
    [Required] 
    public int Id { get; set;}

    [Required(ErrorMessage = "O nome é obrigatório")] 
    [MaxLength(255, ErrorMessage = "O tamanho do nome não pode exceder 255 caracteres")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório")] 
    [MaxLength(15, ErrorMessage = "O tamanho do telefone não pode exceder 15 caracteres")]
    public required string Phone { get; set; }

    [Required(ErrorMessage = "O email é obrigatório")] 
    [MaxLength(255, ErrorMessage = "O tamanho do email não pode exceder 255 caracteres")]
    public required string Email { get; set; }

}
