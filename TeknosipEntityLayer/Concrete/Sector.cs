using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknosipEntityLayer.Concrete
{
    public class Sector
    {
        public int SectorId { get; set; }
        public string Name { get; set; }

        public ICollection<Problem> Problems { get; set; }
    }
}
