using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknosipEntityLayer.Concrete
{
    public class Problem
    {
       
        public int ProblemId { get; set; }


        public string Title { get; set; }

        public string Description { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }

        public DateTime OlusturmaTarihi { get; set; }

        // Problemi oluşturan kullanıcı
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        // Hangi sektöre ait problem?
        public int SectorId { get; set; }
        public Sector Sector { get; set; }

        public ICollection<DestekTalebi> DestekTalepleri { get; set; }
        public ICollection<Cozum>Cozums { get; set; }

    }
}
