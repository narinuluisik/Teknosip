using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknosipEntityLayer.Concrete
{

    public class DestekTalebi
    {
        public int DestekTalebiId { get; set; }
        public int ProblemId { get; set; }
        public int DestekKurumuId { get; set; }
        public string Mesaj { get; set; }
        public DateTime Tarih { get; set; }

        public Problem Problem { get; set; }
        public DestekKurumu DestekKurumu { get; set; }
    }
}
