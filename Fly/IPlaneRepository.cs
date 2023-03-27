using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public interface IPlaneRepository
    {
        public Plane[] GetAll();
        public Plane[] GetAllByQuery(string query);
        public Plane GetById(int planeId);
        public void RemovePlaneById(int planeId);
        public void Create(Plane plane);
    }
}
