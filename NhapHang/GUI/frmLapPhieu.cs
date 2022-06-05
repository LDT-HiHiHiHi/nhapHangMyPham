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
using DTO;

namespace GUI
{
    
    public partial class frmLapPhieu : Form
    {
        BUS_PhieuNhap bus_pn = new BUS_PhieuNhap();
        BUS_TaiKhoan bus_tk = new BUS_TaiKhoan();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        public frmLapPhieu()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            //kiểm tra rôcng
            if (string.IsNullOrEmpty(txtMaPN.Text))
            {
                Program.AlertMessage("Vui lòng nhập mã phiếu nhập");
                txtMaPN.Focus();
                return;
            }

            //Kiểm tra trùng
            string idpn = txtMaPN.Text;
            if (!bus_pn.check_PK(idpn))
            {
                Program.AlertMessage("Mã phiếu nhập bị trùng");
                txtMaPN.Focus();
                return;
            }

            string idnv = bus_nv.getIDNV_ID(bus_tk.getID_Name("admin"));
            if (bus_pn.lapPhieuNhap(idpn, idnv))
            {
                this.Close();
                Program.AlertMessage("Lập phiếu thành công", MessageBoxIcon.Information);
                return;
            }
            Program.AlertMessage("Đã xảy ra lỗi",MessageBoxIcon.Error);
        }

        private void frmLapPhieu_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown +=frmLapPhieu_KeyDown;
        }

        private void frmLapPhieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               btnXacNhan.PerformClick();
            }
        }
    }
}
