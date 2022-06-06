using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
namespace GUI
{
    public partial class frmMain : Form
    {
        BUS_PhieuNhap bus_pn = new BUS_PhieuNhap();
        BUS_TaiKhoan bus_tk = new BUS_TaiKhoan();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        public frmMain()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void xemSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            frm.MdiParent = this;

            frm.Show();
        }

        private void xemPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuNhap frm = new frmPhieuNhap();
            frm.MdiParent = this;

            frm.Show();
        }

        private void lậpPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mapn = "PN-" + DateTime.Today.Day + DateTime.Today.Month + DateTime.Today.Year + "-" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            string idnv = bus_nv.getIDNV_ID(bus_tk.getID_Name("admin"));
            if (bus_pn.lapPhieuNhap(mapn, idnv))
            {
                frmPhieuNhap.MAPN = mapn;
                frmChiTietPN frm = new frmChiTietPN();
                frm.MdiParent = this;
                frm.Show();
                return;
            }
            Program.AlertMessage("Đã xảy ra lỗi", MessageBoxIcon.Error);
            frmPhieuNhap form = new frmPhieuNhap();
        }
    }
}
