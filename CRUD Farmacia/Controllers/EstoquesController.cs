using Microsoft.AspNetCore.Mvc;

namespace CRUD_Farmacia.Controllers
{
    public class EstoquesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
