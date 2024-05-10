using Microsoft.AspNetCore.Mvc;
using CrudTarefa.Models;


namespace CrudTarefa.Controllers
{
    public class FazendoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}