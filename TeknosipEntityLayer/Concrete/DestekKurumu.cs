using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknosipEntityLayer.Concrete
{
 
        public class DestekKurumu
        {
            public int DestekKurumuId { get; set; }
            public string KurumAdi { get; set; }
            public string Email { get; set; }
            // Diğer gerekli alanlar...

            public ICollection<DestekTalebi> DestekTalepleri { get; set; }
        public ICollection<Cozum>Cozums { get; set; }

    }

}
