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
    public class BUS_SanPham
    {
        DAL_SanPham dal_sp = new DAL_SanPham();

        public List<SanPham> getList_SP()
        {
            return dal_sp.getList_SP();
        }

        public List<string> getList_TenSP()
        {
            return dal_sp.getList_TenSP();
        }
        public DataTable timKiemSP(string pTenSP)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("TENSP", typeof(string)));
            dt.Columns.Add(new DataColumn("MOTA", typeof(string)));
            dt.Columns.Add(new DataColumn("SOLUONG", typeof(int)));
            dt.Columns.Add(new DataColumn("NSX", typeof(string)));

            dal_sp.timKiemSP(pTenSP).ForEach(sp =>
            {
                DataRow r = dt.NewRow();
                r["ID"] = sp.ID;
                r["TENSP"] = sp.TENSP;
                r["MOTA"] = sp.MOTA;
                r["SOLUONG"] = sp.SOLUONG;
                r["NSX"] = sp.NSX;

                dt.Rows.Add(r);
            });
            return dt;
        }

        public double? getDonGia_SP(string _idsp)
        {
            return dal_sp.getDonGia_SP(_idsp);
        }

        public bool update_SoLuongSP(string _masp, int? _sl)
        {
            return dal_sp.update_SoLuongSP(_masp, _sl);
        }


        public string getID_Name(string _name)
        {
            return dal_sp.getID_Name(_name);
        }
    }
}
