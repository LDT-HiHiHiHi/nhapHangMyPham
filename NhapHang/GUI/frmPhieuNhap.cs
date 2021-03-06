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
        BUS_TaiKhoan bus_tk = new BUS_TaiKhoan();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        public static string MAPN;
        public static bool flag_xn = false;
        public static bool flag_cxn = false;
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            xóaToolStripMenuItem.Enabled = false;
            xemChiTiếtToolStripMenuItem.Enabled = false;
            if (flag_xn == true)
                dgvPhieuNhap.DataSource = bus_pn.getList_PN_XN();
            else
            {
                if (flag_cxn == true)
                    dgvPhieuNhap.DataSource = bus_pn.getList_PN_CXN();
                else
                    dgvPhieuNhap.DataSource = bus_pn.getList_PN();
            }
            dgvPhieuNhap.Columns["NGTAO"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPhieuNhap.Columns["THANHTIEN"].DefaultCellStyle.Format = "#,##0";
            dgvPhieuNhap.Columns["THOIGIAN"].DefaultCellStyle.Format = "%h\\:%m";
            this.KeyPreview = true;
            this.KeyDown +=frmPhieuNhap_KeyDown;
        }

        private void frmPhieuNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem.PerformClick();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string idpn = dgvPhieuNhap.CurrentRow.Cells["ID"].Value.ToString();

            if (!bus_pn.check_ChiTietPN(idpn))
            {
                Program.AlertMessage("Phiếu nhập "+idpn+" có tồn tại chi tiết",MessageBoxIcon.Warning);
                xóaToolStripMenuItem.Enabled = true;
                return;
            }
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu " + idpn + " ?", "Thông báo",

            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1);

            if (r == DialogResult.Yes)
            {
                if (bus_pn.xoaPN(idpn))
                {
                    this.frmPhieuNhap_Load(sender, e);
                    xóaToolStripMenuItem.Enabled = false;
                    return;
                }
                Program.AlertMessage("Đã xảy ra lỗi khi xóa", MessageBoxIcon.Warning);
            }
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string idpn = dgvPhieuNhap.CurrentRow.Cells["ID"].Value.ToString();
            if (bus_pn.getTrangThai(idpn) == true)
            {
                xóaToolStripMenuItem.Enabled = false;
            }
            else
            {
                xóaToolStripMenuItem.Enabled = true;
            }
            xemChiTiếtToolStripMenuItem.Enabled = true;
        }

        private void dgvPhieuNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            xóaToolStripMenuItem.Enabled = false;
            MAPN = dgvPhieuNhap.CurrentRow.Cells["ID"].Value.ToString();
            xóaToolStripMenuItem.Enabled = false;
            frmChiTietPN frm = new frmChiTietPN();
            frm.ShowDialog();
            this.frmPhieuNhap_Load(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // kiểm tra rỗng
            if (string.IsNullOrEmpty(txtFind.Text.Trim()))
            {
                Program.AlertMessage("Vui lòng nhập thông tin tìm kiếm",MessageBoxIcon.Warning);
                txtFind.Focus();
                dgvPhieuNhap.DataSource = bus_pn.getList_PN();
                return;
            }
            if (flag_xn == true)
            {
                dgvPhieuNhap.DataSource = bus_pn.timKiemPN_XN(txtFind.Text.Trim());
                return;
            }
            if (flag_cxn == true)
            {
                dgvPhieuNhap.DataSource = bus_pn.timKiemPN_CXN(txtFind.Text.Trim());
                return;
            }
            dgvPhieuNhap.DataSource = bus_pn.timKiemPN(txtFind.Text.Trim());
        }

        private void xemChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MAPN = dgvPhieuNhap.CurrentRow.Cells["ID"].Value.ToString();
            frmChiTietPN frm = new frmChiTietPN();
            frm.ShowDialog();
            this.frmPhieuNhap_Load(sender, e);
        }

        private void laToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mapn = "PN-" + DateTime.Today.Day + DateTime.Today.Month + DateTime.Today.Year + "-" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            string idnv = bus_nv.getIDNV_ID(bus_tk.getID_Name("admin"));
            if (bus_pn.lapPhieuNhap(mapn, idnv))
            {
                frmPhieuNhap.MAPN = mapn;
                frmChiTietPN frm = new frmChiTietPN();
                frm.ShowDialog();
                return;
            }
            Program.AlertMessage("Đã xảy ra lỗi", MessageBoxIcon.Error);
        }

        private void làmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmPhieuNhap_Load(sender, e);
        }

        private void chưaXácNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag_cxn == false)
            {
                flag_cxn = true;
                dgvPhieuNhap.DataSource = bus_pn.getList_PN_CXN();
                chưaXácNhậnToolStripMenuItem.Checked = flag_cxn;
                if (flag_xn == true)
                {
                    flag_xn = false;
                    đãXácNhậnToolStripMenuItem.Checked = flag_xn;
                }
            }
            else
            {
                flag_cxn = false;
                dgvPhieuNhap.DataSource = bus_pn.getList_PN();
                chưaXácNhậnToolStripMenuItem.Checked = flag_cxn;
            }
        }

        private void đãXácNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag_xn == false)
            {
                flag_xn = true;
                dgvPhieuNhap.DataSource = bus_pn.getList_PN_XN();
                đãXácNhậnToolStripMenuItem.Checked = flag_xn;
                if (flag_cxn == true)
                {
                    flag_cxn = false;
                    chưaXácNhậnToolStripMenuItem.Checked = flag_cxn;
                }
            }
            else
            {
                flag_xn = false;
                dgvPhieuNhap.DataSource = bus_pn.getList_PN();
                đãXácNhậnToolStripMenuItem.Checked = flag_xn;
            }
        }
    }
}
