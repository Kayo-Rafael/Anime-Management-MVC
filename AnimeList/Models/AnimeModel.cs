using System.ComponentModel.DataAnnotations;

namespace AnimeList.Models;

public class AnimeModel
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
    public int AnoLancamento { get; set; }
}
