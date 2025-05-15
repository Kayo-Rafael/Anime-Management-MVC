using AnimeList.Data;
using AnimeList.Models;
using AnimeList.repository;

namespace AnimeList.Repositorio;

public class AnimeRepository : IAnimeRepository
{
    private readonly BancoContext _bancoContext;
    // Construtor que recebe o contexto do banco de dados
    public AnimeRepository(BancoContext bancoContext)
    {
        _bancoContext = bancoContext;
    }
    
    // Método para buscar um anime pelo ID
    public AnimeModel BuscarPorId(int id)
    {
        return _bancoContext.Animes.FirstOrDefault(anime => anime.Id == id); // Retorna o anime com o ID especificado
    }

    // Método para buscar todos os animes do banco de dados
    public List<AnimeModel> BuscarTodos()
    {
       return _bancoContext.Animes.ToList(); // Retorna todos os animes do banco de dados
    }

    // Método para adicionar um novo anime ao banco de dados
    public AnimeModel Adicionar(AnimeModel anime)
    {
        _bancoContext.Animes.Add(anime); // Adiciona o anime ao contexto    

        _bancoContext.SaveChanges(); // Salva as alterações no banco de dados

        return anime; // Retorna o anime criado
    }

    public AnimeModel EditarAnime(AnimeModel anime)
    {
        AnimeModel animeDb = BuscarPorId(anime.Id); // Busca o anime existente no banco de dados
        if (animeDb == null)
        {
            throw new Exception($"Anime com o ID {anime.Id} não encontrado."); // Lança uma exceção se o anime não for encontrado
        }

        animeDb.Usuario = anime.Usuario; // Atualiza o usuário
        animeDb.NomeAnime = anime.NomeAnime; // Atualiza o nome do anime
        animeDb.Genero = anime.Genero; // Atualiza o gênero
        animeDb.Criador = anime.Criador; // Atualiza o criador
        animeDb.AnoLancamento = anime.AnoLancamento; // Atualiza o ano de lançamento

        _bancoContext.Animes.Update(animeDb); // Atualiza o anime no contexto

        _bancoContext.SaveChanges(); // Salva as alterações no banco de dados

        return animeDb;  // Retorna o anime atualizado
    }

    public bool ExcluirAnime(int id)
    {
        AnimeModel animeDb = BuscarPorId(id); // Busca o anime pelo ID
        if (animeDb == null)
        {
            throw new Exception($"Anime com o ID {id} não encontrado."); // Lança uma exceção se o anime não for encontrado
        }
        _bancoContext.Animes.Remove(animeDb); // Remove o anime do contexto

        _bancoContext.SaveChanges(); // Salva as alterações no banco de dados
        
        return true; // Retorna verdadeiro se a exclusão for bem-sucedida
    }
}
