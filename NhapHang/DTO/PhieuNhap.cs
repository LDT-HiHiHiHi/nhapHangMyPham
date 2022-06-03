using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhap
    {
        string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        DateTime? ngtao;

        public DateTime? NGTAO
        {
            get { return ngtao; }
            set { ngtao = value; }
        }
        TimeSpan? thoigian;

        public TimeSpan? THOIGIAN
        {
            get { return thoigian; }
            set { thoigian = value; }
        }
        double? thanhtien;

        public double? THANHTIEN
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }
    }
}
