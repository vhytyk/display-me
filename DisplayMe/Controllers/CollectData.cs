using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisplayMe.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DisplayMe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectData : ControllerBase
    {
        
        [HttpPost]
        public void Post(TryvohaPayload payload)
        {
            System.IO.File.WriteAllText("tmpdata.json", JsonConvert.SerializeObject(payload));
        }
    }
}
