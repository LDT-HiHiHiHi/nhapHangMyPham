using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_SanPham
    {
        QlyMyPhamDataContext qlmp = new QlyMyPhamDataContext();

        public List<SanPham> getList_SP()
        {
            return qlmp.SANPHAMs.Select(sp => new SanPham { 
                ID = sp.ID,
                TENSP = sp.TENSP,
                MOTA = sp.MOTA,
                SOLUONG = sp.SOLUONG,
                NSX = sp.NSX
            }).ToList();
        }

        public List<string> getList_TenSP()
        {
            return qlmp.SANPHAMs.Select(t => t.TENSP).ToList();
        }

        public List<SanPham> timKiemSP(string pTenSP)
        {
            return qlmp.SANPHAMs.Where(sp => sp.TENSP.Contains(pTenSP)).Select(sp => new SanPham
            {
                ID = sp.ID,
                TENSP = sp.TENSP,
                MOTA = sp.MOTA,
                SOLUONG = sp.SOLUONG,
                NSX = sp.NSX
            }).ToList();
        }

        public double? getDonGia_SP(string _idsp)
        {
            return qlmp.DONGIAs.Where(dg => dg.ID_SP == _idsp).Select(t => t.GIA).FirstOrDefault();
        }

        public bool update_SoLuongSP(string _masp, int? _sl)
        {
            try {
                SANPHAM sp = qlmp.SANPHAMs.Where(t => t.ID == _masp).FirstOrDefault();
                sp.SOLUONG = sp.SOLUONG + _sl;
                qlmp.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string getID_Name(string _name)
        {
            return qlmp.SANPHAMs.Where(t => t.TENSP == _name).Select(t => t.ID).FirstOrDefault();
        }
    }
}
