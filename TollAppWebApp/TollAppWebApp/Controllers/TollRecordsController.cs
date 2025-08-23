using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TollAppWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TollRecordsController : ControllerBase
    {
        private readonly ILogger<TollRecordsController> _logger;

        public TollRecordsController(ILogger<TollRecordsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}