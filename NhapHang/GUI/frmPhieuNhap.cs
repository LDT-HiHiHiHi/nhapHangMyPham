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
    public partial class frmPhieuNhap : Form
    {
        BUS_PhieuNhap bus_pn = new BUS_PhieuNhap();
        public static string mapn;
        public frmPhieuNhap()
        {
            InitializeComponent();
            btnXoa.Enabled = false;
        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            dgvPhieuNhap.DataSource = bus_pn.getList_PN();
            dgvPhieuNhap.Columns["THANHTIEN"].DefaultCellStyle.Format = "#,##0";
            dgvPhieuNhap.Columns["THOIGIAN"].DefaultCellStyle.Format = "%h\\:%m\\:%s";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string idpn = dgvPhieuNhap.CurrentRow.Cells["ID"].Value.ToString();

            if (!bus_pn.check_ChiTietPN(idpn))
            {
                Program.AlertMessage("Phiếu nhập có tồn tại chi tiết");
                btnXoa.Enabled = false;
                return;
            }

            if (bus_pn.xoaPN(idpn))
            {
                this.frmPhieuNhap_Load(sender,e);
                Program.AlertMessage("Xóa thành công", MessageBoxIcon.Information);
                btnXoa.Enabled = false;
                return;
            }
            Program.AlertMessage("Đã xảy ra lỗi khi xóa");
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoa.Enabled = true;
        }

        private void dgvPhieuNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoa.Enabled = false;
            mapn = dgvPhieuNhap.CurrentRow.Cells["ID"].Value.ToString();
            frmChiTietPN frm = new frmChiTietPN();
            frm.ShowDialog();
            this.frmPhieuNhap_Load(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // kiểm tra rỗng
            if (string.IsNullOrEmpty(txtFind.Text.Trim()))
            {
                Program.AlertMessage("Vui lòng nhập thông tin tìm kiếm");
                txtFind.Focus();

                dgvPhieuNhap.DataSource = bus_pn.getList_PN();
                return;
            }

            dgvPhieuNhap.DataSource = bus_pn.timKiemPN(txtFind.Text.Trim());
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            frmLapPhieu frm = new frmLapPhieu();
            frm.ShowDialog();
            this.frmPhieuNhap_Load(sender, e);
        }

    }
}
