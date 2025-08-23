using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TollAppWebApp.Models;
using TollAppWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace TollAppWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TollRecordsController : ControllerBase
    {
        private readonly TollContext _context;

        public TollRecordsController(TollContext context)
        {
            _context = context;
        }

        //GET api/tollrecords
        [HttpGet]
        

    }
}