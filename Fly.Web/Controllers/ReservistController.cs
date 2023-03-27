using Microsoft.AspNetCore.Mvc;

namespace Fly.Web.Controllers
{
    public class ReservistController : Controller
    {
        private readonly IFlightRepository flightRepository;
        private readonly IUserRepository userRepository;
        private readonly IPlaneRepository planeRepository;
        public ReservistController(IFlightRepository flightRepository, IUserRepository userRepository, IPlaneRepository planeRepository)
        {
            this.flightRepository = flightRepository;
            this.userRepository = userRepository;
            this.planeRepository = planeRepository;
        }
        public IActionResult Index()
        {
            var model = flightRepository.GetByUserName(User.Claims.First().Value);
            return View(model);
        }
    }
}
