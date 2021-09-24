using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;
        public PlanetController(PlanetService planetService, ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;
        }

        [Route("planets")]
        public IActionResult Index()
        {
            return View();
        }


        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name { set; get; }
        public IActionResult Mercury(){
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();

            return View("Detail", planet);
        }
        public IActionResult Venus(){
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();

            return View("Detail", planet);
        }
        public IActionResult Mars(){
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();

            return View("Detail", planet);
        }
        public IActionResult Earth(){
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();

            return View("Detail", planet);
        }


        [Route("planet/{id:int}")]
        public IActionResult PlanetInfo(int id){
            var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
            return View("Detail",planet);
        }
    }
}