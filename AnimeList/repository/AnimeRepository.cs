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

   
}
