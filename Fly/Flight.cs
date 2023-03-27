using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class Flight
    {
        public int Id { get; set; }
        public int PlaneID { get; set; }
        public string PlaneName { get; set; }
        public int PlanePrice { get; set; }
        public int UserID { get; set; }
        public string UserLogin { get; set; }
        public DateTime? Flew { get; set; }
        public DateTime? Arrive { get; set; }
    }
}
