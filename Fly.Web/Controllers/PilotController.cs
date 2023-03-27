using Microsoft.AspNetCore.Mvc;

namespace Fly.Web.Controllers
{
    public class PilotController : Controller
    {
        private readonly IFlightRepository flightRepository;
        public PilotController(IFlightRepository flightRepository)
        {
            this.flightRepository = flightRepository;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("Common"))
                {
                    if (User.IsInRole("Pilot"))
                    {
                        var user = User.Claims.First().Value;
                        var model = flightRepository.GetByUserName(user);
                        return View(model);
                    }
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
