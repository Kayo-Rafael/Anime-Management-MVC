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
        _animeRepository.ExcluirAnime(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Criar(AnimeModel anime)
    {
        _animeRepository.Adicionar(anime);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Editar(AnimeModel anime)
    {
        _animeRepository.EditarAnime(anime);

        return RedirectToAction("Index");
    }
}
