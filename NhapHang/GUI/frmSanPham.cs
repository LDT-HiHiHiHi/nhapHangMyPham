using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
namespace GUI
{
    public partial class frmSanPham : Form
    {
        BUS_SanPham bus_sp = new BUS_SanPham();
        public static string tensp;
        public static bool flag_sp = false;
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = bus_sp.getList_SP();
            this.KeyPreview = true;
            this.KeyDown +=frmSanPham_KeyDown;
        }

        private void frmSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem.PerformClick();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // kiểm tra rỗng
            if (string.IsNullOrEmpty(txtFind.Text.Trim()))
            {
                Program.AlertMessage("Vui lòng nhập thông tin tìm kiếm");
                txtFind.Focus();

                dgvSanPham.DataSource = bus_sp.getList_SP();
                return;
            }
            dgvSanPham.DataSource = bus_sp.timKiemSP(txtFind.Text.Trim());
        }

        private void làmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanPham_Load(sender, e);
        }

        private void dgvSanPham_DoubleClick(object sender, EventArgs e)
        {
            tensp = dgvSanPham.CurrentRow.Cells["TENSP"].Value.ToString();
            if (flag_sp == true)
            {
                flag_sp = false;
                this.Dispose();
            }
        }
    }
}
