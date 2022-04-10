using System.Globalization;
using System.Linq;
using System.Resources;
using DisplayMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace DisplayMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _stringLocalizer;

        public HomeController(IStringLocalizer<HomeController> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public IActionResult Index()
        {
            ViewData["Test"] = _stringLocalizer["Test"].Value;
            TryvohaPayload payload = System.IO.File.Exists("tmpdata.json")
                ? JsonConvert.DeserializeObject<TryvohaPayload>(System.IO.File.ReadAllText("tmpdata.json"))
                : null;

            return View(payload);
        }
    }
}
