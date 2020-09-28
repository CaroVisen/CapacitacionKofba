using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CargaCapacitacion.Models;
using Microsoft.EntityFrameworkCore;
using CargaCapacitacion.ViewModels;

namespace CargaCapacitacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly MaestrosContext _contextM;
        public HomeController(ILogger<HomeController> logger, MaestrosContext _context)
        {
            _logger = logger;
            _contextM = _context;
        }

        public async Task<IActionResult> Index()
        {
            var request = HttpContext.;

            return View();
        }

        private IActionResult ErrorViewModel()
        {
            throw new NotImplementedException();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
