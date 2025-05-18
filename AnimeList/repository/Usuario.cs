using AnimeUserManager.Data;
using AnimeUserManager.Models;

namespace AnimeUserManager.repository;

public class Usuario : IUsuarioRepository
{
    private readonly BancoContext _bancoContext;
    // Construtor que recebe o contexto do banco de dados
    public Usuario(BancoContext bancoContext)
    {
        _bancoContext = bancoContext;
    }
    
    // Método para buscar um Usuario pelo ID
    public UserModel BuscarPorId(int id)
    {
        return _bancoContext.Users.FirstOrDefault(user => user.Id == id); // Retorna o usuario com o ID especificado
    }

    // Método para buscar todos os usuarios do banco de dados
    public List<UserModel> BuscarTodos()
    {
       return _bancoContext.Users.ToList(); // Retorna todos os usuarios do banco de dados
    }

    // Método para adicionar um novo usuario ao banco de dados
    public UserModel Adicionar(UserModel user)
    {
        _bancoContext.Users.Add(user); // Adiciona o usuario ao contexto    

        _bancoContext.SaveChanges(); // Salva as alterações no banco de dados

        return user; // Retorna o usuario criado
    }

    public UserModel EditarUsuario(UserModel user)
    {
        UserModel UserDb = BuscarPorId(user.Id); // Busca o anime existente no banco de dados
        if (UserDb == null)
        {
            throw new Exception($"Anime com o ID {user.Id} não encontrado."); // Lança uma exceção se o anime não for encontrado
        }

        UserDb.Usuario = user.Usuario; // Atualiza o usuário
        UserDb.NomeAnime = user.NomeAnime; // Atualiza o nome do anime
        UserDb.Genero = user.Genero; // Atualiza o gênero
        UserDb.Criador = user.Criador; // Atualiza o criador
        UserDb.AnoLancamento = user.AnoLancamento; // Atualiza o ano de lançamento

        _bancoContext.Users.Update(UserDb); // Atualiza o anime no contexto

        _bancoContext.SaveChanges(); // Salva as alterações no banco de dados

        return UserDb;  // Retorna o anime atualizado
    }

    public bool ExcluirUsuario(int id)
    {
        UserModel UserDb = BuscarPorId(id); // Busca o anime pelo ID
        if (UserDb == null)
        {
            throw new Exception($"Anime com o ID {id} não encontrado."); // Lança uma exceção se o anime não for encontrado
        }
        _bancoContext.Users.Remove(UserDb); // Remove o anime do contexto

        _bancoContext.SaveChanges(); // Salva as alterações no banco de dados
        
        return true; // Retorna verdadeiro se a exclusão for bem-sucedida
    }
}
