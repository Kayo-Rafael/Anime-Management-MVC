using Microsoft.AspNetCore.Mvc;

namespace AnimeList.Controllers;
public class Anime : Controller
{
    public IActionResult Index()
    {
        return View();
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
}
