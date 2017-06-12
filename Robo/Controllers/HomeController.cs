using Microsoft.AspNetCore.Mvc;

namespace Robo.Controllers
{
    public class HomeController : Controller
    {      

        [HttpGet, ActionName("Index")]
        public IActionResult Index()
        {
            Robo.API.RoboAPI api = new Robo.API.RoboAPI();
            Robo.Models.Robo _model = Robo.API.RoboAPI.GetRobo();

            ViewBag.CotoveloDireitoOptions = _model.CotoveloDireitoOptions;
            ViewBag.CotoveloEsquerdoOptions = _model.CotoveloEsquerdoOptions;
            ViewBag.PulsoDireitoOptions = _model.PulsoDireitoOptions;
            ViewBag.PulsoEsquerdoOptions = _model.PulsoEsquerdoOptions;
            ViewBag.JoelhoDireitoOptions = _model.JoelhoDireitoOptions;
            ViewBag.JoelhoEsquerdoOptions = _model.JoelhoEsquerdoOptions;
            ViewBag.QuadrilOptions = _model.QuadrilOptions;
            ViewBag.HeadInclinationOptions = _model.HeadInclinationOptions;
            ViewBag.HeadRotationOptions = _model.HeadRotationOptions;           
            ViewBag.Model = _model;

            return View(_model);
        }

        [HttpGet, ActionName("Edit")]
        public ActionResult Edit()
        {
            Robo.Models.Robo _model = Robo.API.RoboAPI.GetRobo();            
            return View(_model);
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
