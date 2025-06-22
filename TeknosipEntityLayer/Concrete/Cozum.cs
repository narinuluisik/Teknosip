using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknosipEntityLayer.Concrete
{
    public class Cozum
    {
        public int CozumId { get; set; }

        public int ProblemId { get; set; }
        public Problem Problem { get; set; }

        // Hangi destek kurumuna gönderildi?
        public int DestekKurumuId { get; set; }
        public DestekKurumu DestekKurumu { get; set; }



        // Çözüm metni
        public string CozumMetni { get; set; }

        public DateTime Tarih { get; set; }

        // Çözüm yapan kurum bilgileri (direkt burada tutulacak)
        public string KurumAdi { get; set; }
        public string KurumEmail { get; set; }
        public string KurumTelefon { get; set; }
    }
}
