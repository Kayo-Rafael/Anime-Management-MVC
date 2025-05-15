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

    public IActionResult Editar()
    {
        return View();
    }

    public IActionResult ExcluirConfirmacao()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Criar(AnimeModel anime)
    {
        _animeRepository.Adicionar(anime);

        return RedirectToAction("Index");
    }
}
