using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public interface IFlightRepository
    {
        public Flight GetByAId(int id);
        public Flight GetByUserName(string userName);
        public void RemoveFlightById(int flightid);
        public void AccessFirst(int flightid);
        public void AccessSecond(int flightid);
        public void StartFlight(int flightid);
        public void StopFlight(int flightid);
        public Flight[] GetAll();
        public void Create(int userid, int planeid);
    }
}
