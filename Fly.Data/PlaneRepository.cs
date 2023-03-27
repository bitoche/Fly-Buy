using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly.Data
{
    public class PlaneRepository : IPlaneRepository
    {
        private readonly IDbContextFactory<FlyDbContext> dbContextFactory;
        public PlaneRepository(IDbContextFactory<FlyDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public Plane[] GetAll()
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var planes = dbContext.Planes;
            return planes.ToArray();
        }

        public Plane[] GetAllByQuery(string query)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var planes = dbContext.Planes.Where(plane => plane.Name.ToLower().Contains(query.ToLower()) || plane.Description.ToLower().Contains(query.ToLower())).ToArray();
            return planes;
        }

        public Plane GetById(int planeId)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var plane = dbContext.Planes.Single(x => x.Id == planeId);
            return plane;
        }

        public void RemovePlaneById(int planeId)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var plane = dbContext.Planes.Single(x => x.Id == planeId);
            dbContext.Remove(plane);
            dbContext.SaveChanges();
        }

        public void Create(Plane plane)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            dbContext.Planes.Add(plane);
            dbContext.SaveChanges();
        }
    }
}
