using System.ComponentModel.DataAnnotations;

namespace AnimeUserManager.Models;

public class UserModel
{
    public int Id { get; set; }
    [Required(ErrorMessage ="O Nome de usuario é Obrigatorio")]
    public string Usuario { get; set; } = string.Empty;
    [Required(ErrorMessage = "O Nome do Anime é Obrigatorio")]
    public string NomeAnime { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    [Required(ErrorMessage = "O Nome de Criador é Obrigatorio")]
    public string Criador { get; set; } = string.Empty;
    [Required(ErrorMessage = "A Data de lançamento é Obrigatoria")]
    [RegularExpression(@"^[0-9]+$", ErrorMessage = "Apenas números são permitidos.")]
    public int AnoLancamento { get; set; }
}
