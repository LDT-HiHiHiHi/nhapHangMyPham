using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        string tensp;

        public string TENSP
        {
            get { return tensp; }
            set { tensp = value; }
        }
        int? soluong;

        public int? SOLUONG
        {
            get { return soluong; }
            set { soluong = value; }
        }
        string nsx;

        public string NSX
        {
            get { return nsx; }
            set { nsx = value; }
        }
        string mota;

        public string MOTA
        {
            get { return mota; }
            set { mota = value; }
        }

        public SanPham() { }
    }
}
