namespace AnimeList.Models;

public class AnimeModel
{
    public int Id { get; set; }
    public string Usuario { get; set; } = string.Empty;
    public string NomeAnime { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public string Criador { get; set; } = string.Empty;
    public int AnoLancamento { get; set; }
}
