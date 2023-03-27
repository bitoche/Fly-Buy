using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly.Services
{
    public class FlightService
    {
        private readonly IFlightRepository flightRepository;
        public FlightService(IFlightRepository flightRepository)
        {
            this.flightRepository = flightRepository;
        }
    }
}
