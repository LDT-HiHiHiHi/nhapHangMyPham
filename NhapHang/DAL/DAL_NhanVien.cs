using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_NhanVien
    {
        QlyMyPhamDataContext qlmp = new QlyMyPhamDataContext();
        public string getIDNV_ID(string _id)
        {
            return qlmp.NHANVIENs.Where(nv => nv.ID_TK == _id).Select(t => t.ID).FirstOrDefault();
        }
    }
}
