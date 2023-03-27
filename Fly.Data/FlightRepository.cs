

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Fly.Data
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IDbContextFactory<FlyDbContext> dbContextFactory;
        public FlightRepository(IDbContextFactory<FlyDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public Flight[] GetAll()
        {
            var dbConrext = dbContextFactory.CreateDbContext();
            var flights = dbConrext.Flights.ToArray();
            return flights;
        }

        public Flight GetByAId(int id)
        {
            var dbConrext = dbContextFactory.CreateDbContext();
            var flight = dbConrext.Flights.Single(flight => flight.Id == id);
            return flight;
        }

        public Flight GetByUserName(string userName)
        {
            var dbConrext = dbContextFactory.CreateDbContext();
            var user = dbConrext.Users.Single(user => user.Name == userName);
            var flight = dbConrext.Flights.Single(flight => flight.UserID == dbConrext.Users.Single(user => user.Name == userName).Id);
            return flight;
        }

        public void Create(int userid, int planeid)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var flight = new Flight
            {
                PlaneID = planeid,
                PlaneName = dbContext.Planes.First(plane => plane.Id == planeid).Name,
                UserID = userid,
                UserLogin = dbContext.Users.First(user => user.Id == userid).Login,
                PlanePrice = dbContext.Planes.First(plane => plane.Id == planeid).PricePerHour
            };
            dbContext.Flights.Add(flight);

            dbContext.SaveChanges();
        }
        public void RemoveFlightById(int flightid)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var flight = dbContext.Flights.Single(x => x.Id == flightid);
            var user = dbContext.Users.Single(user => user.Id == flight.UserID);
            user.Role = Role.Common;
            dbContext.Remove(flight);
            dbContext.SaveChanges();
        }
        public void AccessFirst(int flightid)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var flight = dbContext.Flights.Single(x => x.Id == flightid);
            dbContext.Users.Single(user => user.Id == flight.UserID).Role = Role.Pilot; 
            dbContext.SaveChanges();
        }
        public void AccessSecond(int flightid)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var flight = dbContext.Flights.Single(x => x.Id == flightid);
            dbContext.Users.Single(user => user.Id == flight.UserID).Role = Role.Common;
            dbContext.SaveChanges();
        }
        public void StartFlight(int flightid)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var flight = dbContext.Flights.Single(x => x.Id == flightid);
            flight.Flew = DateTime.Now;
            dbContext.SaveChanges();
        }
        public void StopFlight(int flightid)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var flight = dbContext.Flights.Single(x => x.Id == flightid);
            flight.Arrive = DateTime.Now;
            dbContext.SaveChanges();
        }

    }
}
