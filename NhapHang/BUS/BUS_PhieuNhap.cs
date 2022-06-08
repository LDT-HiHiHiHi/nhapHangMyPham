using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAL;
using DTO;
namespace BUS
{
    public class BUS_PhieuNhap
    {
        DAL_PhieuNhap dal_pn = new DAL_PhieuNhap();
        public DataTable getList_PN()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("NGTAO", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("THOIGIAN", typeof(TimeSpan)));
            dt.Columns.Add(new DataColumn("THANHTIEN", typeof(string)));
            dt.Columns.Add(new DataColumn("TRANGTHAI", typeof(string)));
            dal_pn.getList_PN().ForEach(pn =>
            {
                DataRow r = dt.NewRow();
                r["ID"] = pn.ID;
                r["NGTAO"] = pn.NGTAO;
                r["THOIGIAN"] = pn.THOIGIAN;
                if (pn.THANHTIEN == 0)
                    r["THANHTIEN"] = 0;
                else
                    r["THANHTIEN"] = string.Format("{0:0,0}", pn.THANHTIEN);
                if(pn.TRANGTHAI == true)
                    r["TRANGTHAI"] = "Đã xác nhận";
                else
                    r["TRANGTHAI"] = "Chưa xác nhận";
                dt.Rows.Add(r);
            });
            return dt;
        }

        public DataTable getList_PN_XN()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("NGTAO", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("THOIGIAN", typeof(TimeSpan)));
            dt.Columns.Add(new DataColumn("THANHTIEN", typeof(string)));
            dt.Columns.Add(new DataColumn("TRANGTHAI", typeof(string)));
            dal_pn.getList_PN_XN().ForEach(pn =>
            {
                DataRow r = dt.NewRow();
                r["ID"] = pn.ID;
                r["NGTAO"] = pn.NGTAO;
                r["THOIGIAN"] = pn.THOIGIAN;
                if (pn.THANHTIEN == 0)
                    r["THANHTIEN"] = 0;
                else
                    r["THANHTIEN"] = string.Format("{0:0,0}", pn.THANHTIEN);
                if (pn.TRANGTHAI == true)
                    r["TRANGTHAI"] = "Đã xác nhận";
                else
                    r["TRANGTHAI"] = "Chưa xác nhận";
                dt.Rows.Add(r);
            });
            return dt;
        }

        public DataTable getList_PN_CXN()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("NGTAO", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("THOIGIAN", typeof(TimeSpan)));
            dt.Columns.Add(new DataColumn("THANHTIEN", typeof(string)));
            dt.Columns.Add(new DataColumn("TRANGTHAI", typeof(string)));
            dal_pn.getList_PN_CXN().ForEach(pn =>
            {
                DataRow r = dt.NewRow();
                r["ID"] = pn.ID;
                r["NGTAO"] = pn.NGTAO;
                r["THOIGIAN"] = pn.THOIGIAN;
                if (pn.THANHTIEN == 0)
                    r["THANHTIEN"] = 0;
                else
                    r["THANHTIEN"] = string.Format("{0:0,0}", pn.THANHTIEN);
                if (pn.TRANGTHAI == true)
                    r["TRANGTHAI"] = "Đã xác nhận";
                else
                    r["TRANGTHAI"] = "Chưa xác nhận";
                dt.Rows.Add(r);
            });
            return dt;
        }

        public bool lapPhieuNhap(string _idpn, string _idnv)
        {
            return dal_pn.lapPhieuNhap(_idpn,_idnv);
        }

        public bool check_PK(string _ma)
        {
            return dal_pn.check_PK(_ma);
        }
        public bool xoaPN(string _idpn)
        {
            return dal_pn.xoaPN(_idpn);
        }
        public bool check_ChiTietPN(string _idpn)
        {
            return dal_pn.check_ChiTietPN(_idpn);
        }

        public DataTable timKiemPN(string id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("NGTAO", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("THOIGIAN", typeof(TimeSpan)));
            dt.Columns.Add(new DataColumn("THANHTIEN", typeof(string)));
            dt.Columns.Add(new DataColumn("TRANGTHAI", typeof(string)));
            dal_pn.timKiemPN(id).ForEach(pn =>
            {
                DataRow r = dt.NewRow();
                r["ID"] = pn.ID;
                r["NGTAO"] = pn.NGTAO;
                r["THOIGIAN"] = pn.THOIGIAN;
                if (pn.THANHTIEN == 0)
                    r["THANHTIEN"] = 0;
                else
                    r["THANHTIEN"] = string.Format("{0:0,0}", pn.THANHTIEN);
                if (pn.TRANGTHAI == true)
                    r["TRANGTHAI"] = "Đã xác nhận";
                else
                    r["TRANGTHAI"] = "Chưa xác nhận";
                dt.Rows.Add(r);
            });
            return dt;
        }

        public DataTable timKiemPN_XN(string id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("NGTAO", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("THOIGIAN", typeof(TimeSpan)));
            dt.Columns.Add(new DataColumn("THANHTIEN", typeof(string)));
            dt.Columns.Add(new DataColumn("TRANGTHAI", typeof(string)));
            dal_pn.timKiemPN_XN(id).ForEach(pn =>
            {
                DataRow r = dt.NewRow();
                r["ID"] = pn.ID;
                r["NGTAO"] = pn.NGTAO;
                r["THOIGIAN"] = pn.THOIGIAN;
                if (pn.THANHTIEN == 0)
                    r["THANHTIEN"] = 0;
                else
                    r["THANHTIEN"] = string.Format("{0:0,0}", pn.THANHTIEN);
                if (pn.TRANGTHAI == true)
                    r["TRANGTHAI"] = "Đã xác nhận";
                else
                    r["TRANGTHAI"] = "Chưa xác nhận";
                dt.Rows.Add(r);
            });
            return dt;
        }

        public DataTable timKiemPN_CXN(string id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("NGTAO", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("THOIGIAN", typeof(TimeSpan)));
            dt.Columns.Add(new DataColumn("THANHTIEN", typeof(string)));
            dt.Columns.Add(new DataColumn("TRANGTHAI", typeof(string)));
            dal_pn.timKiemPN_CXN(id).ForEach(pn =>
            {
                DataRow r = dt.NewRow();
                r["ID"] = pn.ID;
                r["NGTAO"] = pn.NGTAO;
                r["THOIGIAN"] = pn.THOIGIAN;
                if (pn.THANHTIEN == 0)
                    r["THANHTIEN"] = 0;
                else
                    r["THANHTIEN"] = string.Format("{0:0,0}", pn.THANHTIEN);
                if (pn.TRANGTHAI == true)
                    r["TRANGTHAI"] = "Đã xác nhận";
                else
                    r["TRANGTHAI"] = "Chưa xác nhận";
                dt.Rows.Add(r);
            });
            return dt;
        }

        public List<ChiTietPN> getList_ChiTietPN(string mapn)
        {
            return dal_pn.getList_ChiTietPN(mapn);
        }

        public bool insert_CTPN(CHITIETPN pn)
        {
            return dal_pn.insert_CTPN(pn);
        }

        public bool update_CTPN(CHITIETPN pn)
        {
            return dal_pn.update_CTPN(pn);
        }

        public bool delete_CTPN(string _mapn, string _masp)
        {
            return dal_pn.delete_CTPN(_mapn, _masp);
        }

        public bool check_PrimaryKey_CTPN(string _mapn, string _masp)
        {
            return dal_pn.check_PrimaryKey_CTPN(_mapn, _masp);
        }

        public bool update_ThanhTien(string _mapn)
        {
            return dal_pn.update_ThanhTien(_mapn);
        }

        public int? getSoLuong(string _mapn, string _masp)
        {
            return dal_pn.getSoLuong(_mapn, _masp);
        }

        public bool? getTrangThai(string _mapn)
        {
            return dal_pn.getTrangThai(_mapn);
        }
        public bool updateTrangThai(string _mapn)
        {
            return dal_pn.updateTrangThai(_mapn);
        }
        public double? getThanhTien(string mapn)
        {

            return dal_pn.getThanhTien(mapn);
        }
    }
}
