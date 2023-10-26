using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TimeDisplay.Models;

namespace TimeDisplay.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        DateTime FechaAhora = DateTime.Now;
        DateTime FechaTermino = new DateTime(2023, 11, 11, 23, 59, 59);
        ViewBag.startTime = FechaAhora.ToString("MMM dd, yyyy  HH:mm tt");
        ViewBag.endTime = FechaTermino.ToString("MMM dd, yyyy  HH:mm tt");

        TimeSpan restante = (FechaTermino - FechaAhora);
        Console.WriteLine(restante);
        ViewBag.remainingDay = restante.Days;
        ViewBag.remainingHour = restante.Hours;
        ViewBag.remainingMinute = restante.Minutes;

        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
