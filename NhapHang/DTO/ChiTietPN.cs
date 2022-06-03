using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPN
    {
        string mapn;

        public string MAPN
        {
            get { return mapn; }
            set { mapn = value; }
        }
        string tensp;

        public string TENSP
        {
            get { return tensp; }
            set { tensp = value; }
        }

        double? dongia;

        public double? DONGIA
        {
            get { return dongia; }
            set { dongia = value; }
        }
        int? soluong;

        public int? SOLUONG
        {
            get { return soluong; }
            set { soluong = value; }
        }
    }
}
