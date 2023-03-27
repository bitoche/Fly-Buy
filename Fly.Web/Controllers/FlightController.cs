using Fly.Data;
using Microsoft.AspNetCore.Mvc;

namespace Fly.Web.Controllers
{
	public class FlightController : Controller
	{
		private readonly IFlightRepository flightRepository;
		private readonly IUserRepository userRepository;
        private readonly IPlaneRepository planeRepository;
        public FlightController(IFlightRepository flightRepository, IUserRepository userRepository, IPlaneRepository planeRepository)
		{
			this.flightRepository = flightRepository;
			this.userRepository = userRepository;
			this.planeRepository = planeRepository;
		}

		public IActionResult Index()
		{
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("Common"))
                {
                    if (User.IsInRole("Accountant"))
                    {
                        var model = flightRepository.GetAll();
                        return View(model);
                    }
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult RemoveFlight(int flightid)
        {
            flightRepository.RemoveFlightById(flightid);
            return RedirectToAction("Index", "Flight");
        }
        public IActionResult AccessFirstPay(int flightid)
        {
            flightRepository.AccessFirst(flightid);
            return RedirectToAction("Index", "Flight");
        }
        public IActionResult PaymentFirst(int flightid)
        {
            userRepository.WriteOffBalance(flightRepository.GetByUserName(User.Claims.First().Value).UserID, 30000);
            flightRepository.AccessFirst(flightid);
            return RedirectToAction("Index", "Reservist");
        }
        public IActionResult AccessSecondPay(int flightid)
        {
            flightRepository.AccessSecond(flightid);
            flightRepository.RemoveFlightById(flightid);
            return RedirectToAction("Index", "Flight");
        }
        
        
        [HttpPost]
        public IActionResult AddFlight(string login, int planeId)
		{
			var user = userRepository.GetByLogin(login);
            var plane = planeRepository.GetById(planeId);
			flightRepository.Create(user.Id, plane.Id);
            userRepository.ChangeRoleToReservist(login);
            return RedirectToAction("Index", "Plane");
		}
        [HttpPost]
        public IActionResult Start(int flightid)
        {
            flightRepository.StartFlight(flightid);
            return RedirectToAction("Index", "Pilot");
        }
        [HttpPost]
        public IActionResult Stop(int flightid)
        {
            flightRepository.StopFlight(flightid);
            return RedirectToAction("Index", "Pilot");
        }
        [HttpGet]
        public IActionResult AddFlight()
        {
            return RedirectToAction("Index", "Plane");
        }

    }
}
