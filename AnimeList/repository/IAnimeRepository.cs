using AnimeList.Models;

namespace AnimeList.repository;

public interface IAnimeRepository
{
    List<AnimeModel> BuscarTodos();
    AnimeModel BuscarPorId(int id);
    AnimeModel EditarAnime(AnimeModel anime);
    AnimeModel Adicionar(AnimeModel anime);
    bool ExcluirAnime(int id);
}
