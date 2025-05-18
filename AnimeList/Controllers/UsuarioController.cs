using AnimeUserManager.Models;
using AnimeUserManager.repository;
using Microsoft.AspNetCore.Mvc;

namespace AnimeUserManager.Controllers;
public class UsuarioController : Controller
{
    private readonly IUsuarioRepository _userRepository;
    public UsuarioController(IUsuarioRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        List<UserModel> users = _userRepository.BuscarTodos();
        return View(users);
    }

    public IActionResult Criar()
    {
        return View();
    }

    public IActionResult Editar(int id)
    {
        UserModel user = _userRepository.BuscarPorId(id);
        return View(user);
    }

    public IActionResult ExcluirConfirmacao(int id)
    {
        UserModel user = _userRepository.BuscarPorId(id);
        return View(user);
    }

    public IActionResult ConfirmarExclusao(int id)
    {
        try
        {
            bool excluidoComSucesso = _userRepository.ExcluirUsuario(id);

            if (excluidoComSucesso)
            {
                TempData["MensagemSucesso"] = "Usuario excluido com sucesso!";
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Não foi possivel excluir o usuario, Detalhe do erro {erro.Message}";
            return RedirectToAction("Index");
        }       
    }

    [HttpPost]
    public IActionResult Criar(UserModel user)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _userRepository.Adicionar(user);
                TempData["MensagemSucesso"] = "Usuario adicionado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(user);
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Usuario não foi adicionado com sucesso, tente novamente! Detalhe do erro {erro.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Editar(UserModel user)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _userRepository.EditarUsuario(user);
                TempData["MensagemSucesso"] = "Usuario Alterado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(user);
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Erro ao alterar Usuario, Detalhe do erro: {erro.Message}";
            return RedirectToAction("Index");
        }
    }
}
