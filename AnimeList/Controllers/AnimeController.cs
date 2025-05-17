using AnimeList.Models;
using AnimeList.repository;
using Microsoft.AspNetCore.Mvc;

namespace AnimeList.Controllers;
public class AnimeController : Controller
{
    private readonly IAnimeRepository _animeRepository;
    public AnimeController(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public IActionResult Index()
    {
        List<AnimeModel> animes = _animeRepository.BuscarTodos();
        return View(animes);
    }

    public IActionResult Criar()
    {
        return View();
    }

    public IActionResult Editar(int id)
    {
        AnimeModel anime = _animeRepository.BuscarPorId(id);
        return View(anime);
    }

    public IActionResult ExcluirConfirmacao(int id)
    {
        AnimeModel anime = _animeRepository.BuscarPorId(id);
        return View(anime);
    }

    public IActionResult ConfirmarExclusao(int id)
    {
        try
        {
            bool excluidoComSucesso = _animeRepository.ExcluirAnime(id);

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
    public IActionResult Criar(AnimeModel anime)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _animeRepository.Adicionar(anime);
                TempData["MensagemSucesso"] = "Usuario adicionado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(anime);
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Usuario não foi adicionado com sucesso, tente novamente! Detalhe do erro {erro.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Editar(AnimeModel anime)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _animeRepository.EditarAnime(anime);
                TempData["MensagemSucesso"] = "Usuario Alterado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(anime);
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Erro ao alterar Usuario, Detalhe do erro: {erro.Message}";
            return RedirectToAction("Index");
        }
    }
}
