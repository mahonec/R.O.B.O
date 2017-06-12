using Microsoft.AspNetCore.Mvc;

namespace Robo.Controllers
{
    public class EditController : Controller
    {
        [HttpGet, ActionName("Edit")]
        public ActionResult Edit()
        {
            Robo.Models.Robo _model = Robo.API.RoboAPI.GetRobo();
            return View(_model);
        }

        [HttpPost, ActionName("Save")]
        public IActionResult Save(Robo.Models.Robo _model)
        {
            Robo.API.RoboAPI.UpdateRobo(_model);
            //return RedirectToAction("Index#Parts", "Home");
            return Redirect("/Home/Index");
        }
    }
}
