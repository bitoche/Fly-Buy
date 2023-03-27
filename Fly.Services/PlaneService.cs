using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly.Services
{
    public class PlaneService
    {
        private readonly IPlaneRepository planeRepository;
        public PlaneService(IPlaneRepository planeRepository)
        {
            this.planeRepository = planeRepository;
        }
    }
}
