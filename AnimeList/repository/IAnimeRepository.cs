using AnimeList.Models;

namespace AnimeList.repository;

public interface IAnimeRepository
{
    List<AnimeModel> BuscarTodos();
    AnimeModel Adicionar(AnimeModel anime);
}
