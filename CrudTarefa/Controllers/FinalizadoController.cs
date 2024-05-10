using Microsoft.AspNetCore.Mvc;
using CrudTarefa.Models;

namespace CrudTarefa.Controllers
{
    public class FinalizadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
