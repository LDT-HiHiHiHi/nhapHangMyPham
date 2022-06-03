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
        public frmSanPham()
        {
            InitializeComponent();
           
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = bus_sp.getList_SP();
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

    }
}
