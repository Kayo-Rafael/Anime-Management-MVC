using AnimeUserManager.Models;

namespace AnimeUserManager.repository;

public interface IUsuarioRepository
{
    List<UserModel> BuscarTodos();
    UserModel BuscarPorId(int id);
    UserModel EditarUsuario(UserModel anime);
    UserModel Adicionar(UserModel anime);
    bool ExcluirUsuario(int id);
}
