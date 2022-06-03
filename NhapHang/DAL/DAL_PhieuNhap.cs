using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_PhieuNhap
    {
        QlyMyPhamDataContext qlmp = new QlyMyPhamDataContext();
        public List<PhieuNhap> getList_PN()
        {
            return qlmp.PHIEUNHAPs.Select(t => new PhieuNhap
            {
                ID = t.ID,
                NGTAO = t.NGTAO,
                THOIGIAN = t.THOIGIAN,
                THANHTIEN = t.THANHTIEN
            }).ToList();
        }

        public bool check_PK(string _ma)
        {
            return qlmp.PHIEUNHAPs.Where(pn => pn.ID == _ma).Count() == 0; 
        }

        public bool lapPhieuNhap(string _idpn, string _idnv)
        {
            try {
                PHIEUNHAP ob = new PHIEUNHAP{
                ID = _idpn,
                ID_NV = _idnv,
                NGTAO = DateTime.Today,
                THOIGIAN = DateTime.Now.TimeOfDay,
                THANHTIEN = 0,
            };
                qlmp.PHIEUNHAPs.InsertOnSubmit(ob);
                qlmp.SubmitChanges();
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }

        public bool xoaPN(string _idpn)
        {
            try {
                PHIEUNHAP ob = qlmp.PHIEUNHAPs.Where(pn => pn.ID == _idpn).FirstOrDefault();
                qlmp.PHIEUNHAPs.DeleteOnSubmit(ob);
                qlmp.SubmitChanges();
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }

        public bool check_ChiTietPN(string _idpn)
        {
            return qlmp.CHITIETPNs.Where(pn => pn.ID_PN == _idpn).Count() == 0;
        }

        public List<PhieuNhap> timKiemPN(string _id)
        {
            return qlmp.PHIEUNHAPs.Where(pn => pn.ID.Contains(_id)).Select(t => new PhieuNhap
            {
                ID = t.ID,
                NGTAO = t.NGTAO,
                THOIGIAN = t.THOIGIAN,
                THANHTIEN = t.THANHTIEN,
            }).ToList();
         }

        public List<ChiTietPN> getList_ChiTietPN(string mapn)
        {
            return qlmp.CHITIETPNs.Where(ct => ct.ID_PN == mapn).Join(qlmp.SANPHAMs, a => a.ID_SP, b => b.ID, (a, b) => new ChiTietPN
            {
                MAPN = a.ID_PN,
                TENSP = b.TENSP,
                SOLUONG = a.SOLUONG,
                DONGIA = a.GIANHAP
            }).ToList();
        }

        public bool insert_CTPN(CHITIETPN pn)
        {
            try {
                qlmp.CHITIETPNs.InsertOnSubmit(pn);
                qlmp.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool update_CTPN(CHITIETPN pn)
        {
            try
            {
                CHITIETPN ct = qlmp.CHITIETPNs.Where(t => t.ID_PN == pn.ID_PN && t.ID_SP == pn.ID_SP).FirstOrDefault();
                ct.SOLUONG = pn.SOLUONG;
                qlmp.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool delete_CTPN(string _mapn, string _masp)
        {
            try
            {
                CHITIETPN ct = qlmp.CHITIETPNs.Where(t => t.ID_PN == _mapn && t.ID_SP == _masp).FirstOrDefault();
                qlmp.CHITIETPNs.DeleteOnSubmit(ct);
                qlmp.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool check_PrimaryKey_CTPN(string _mapn, string _masp)
        {
            return qlmp.CHITIETPNs.Where(t=>t.ID_PN == _mapn && t.ID_SP == _masp).Count() > 0;
        }

        public int? getSoLuong(string _mapn, string _masp)
        {
            return qlmp.CHITIETPNs.Where(t => t.ID_PN == _mapn && t.ID_SP == _masp).Select(a=>a.SOLUONG).FirstOrDefault();
        }

        public bool update_ThanhTien(string _mapn)
        {
            try {
                PHIEUNHAP pn = qlmp.PHIEUNHAPs.Where(t => t.ID == _mapn).FirstOrDefault();
                double? thanhTien = qlmp.CHITIETPNs.Where(ct => ct.ID_PN == _mapn).Sum(tt => tt.GIANHAP * tt.SOLUONG);
                pn.THANHTIEN = thanhTien;
                qlmp.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
