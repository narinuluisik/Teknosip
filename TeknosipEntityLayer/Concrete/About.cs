using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknosipEntityLayer.Concrete
{
    public class About
    {
        public int Id { get; set; }
        public string Meta { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Ozellikler1 { get; set; }  // ; ile ayrılmış

        public string CeoResimUrl { get; set; }
        public string Telefon { get; set; }
    }
}
