using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dal_nv = new DAL_NhanVien();
        public string getIDNV_ID(string _id)
        {
            return dal_nv.getIDNV_ID(_id);
        }
    }
}
