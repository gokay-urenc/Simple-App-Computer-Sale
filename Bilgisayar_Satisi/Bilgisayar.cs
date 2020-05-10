using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgisayar_Satisi
{
    public class Bilgisayar
    {
        public string marka { get; set; }
        public int ram { get; set; }
        public string hdd { get; set; }
        public string anakart { get; set; }

        public List<int> RamDoldur()
        {
            List<int> ram_listesi = new List<int>() { 2, 4, 6, 8, 16, 32 };
            return ram_listesi;
        }
        public override string ToString()
        {
            return marka + " " + ram + " " + hdd + " " + anakart;
        }
    }
}