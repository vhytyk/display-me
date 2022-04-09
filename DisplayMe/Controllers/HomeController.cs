using DisplayMe.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DisplayMe.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (System.IO.File.Exists("tmpdata.json"))
            {
                return View(JsonConvert.DeserializeObject<TryvohaPayload>(System.IO.File.ReadAllText("tmpdata.json")));
            }
            else
            {
                return View();
            }
        }
    }
}
