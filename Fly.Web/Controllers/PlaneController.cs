using Fly.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fly.Web.Controllers
{
    public class PlaneController : Controller
    {
        private readonly IPlaneRepository planeRepository;
        private readonly PlaneService planeService;
        public PlaneController(IPlaneRepository planeRepository, PlaneService planeService)
        {
            this.planeRepository = planeRepository;
            this.planeService = planeService;
        }
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated == true)
            {
                var model = planeRepository.GetAll();
                return View(model);
            }
            else
                return RedirectToAction("Login", "Account");
            
        }

        public IActionResult RemovePlane(int planeId)
        {
            planeRepository.RemovePlaneById(planeId);
            return RedirectToAction("Index", "Plane");
        }

        [HttpGet]
        public IActionResult AddPlane()
        {
            return View("AddPlane", "Plane");
        }

        [HttpPost]
        public IActionResult AddPlane(string name, string description, string image, int pricePerHour, string coordRunwStrip)
        {
            var plane = new Plane { Description = description, Name = name, Image = image, PricePerHour = pricePerHour, CoordRunwStrip = coordRunwStrip };
            planeRepository.Create(plane);
            return RedirectToAction("Index", "Plane");
        }
        
    }
}
