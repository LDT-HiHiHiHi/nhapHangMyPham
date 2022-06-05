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
    public partial class frmChiTietPN : Form
    {
        BUS_PhieuNhap bus_pn = new BUS_PhieuNhap();
        BUS_SanPham bus_sp = new BUS_SanPham();
        public frmChiTietPN()
        {
            InitializeComponent();
            dgvChiTietPN.Columns["DONGIA"].DefaultCellStyle.Format = "#,##0";
            btnXacNhan.Visible = false;
            xóaToolStripMenuItem.Enabled = false;
        }

        private void frmChiTietPN_Load(object sender, EventArgs e)
        {
            if (bus_pn.getTrangThai(frmPhieuNhap.mapn) == true)
            {
                btnLuu.Visible = false;
                txtSoLuong.Enabled = false;
                label6.Text = "Đã xác nhận";
                label6.ForeColor = Color.Green;
            }
            else
            {
                label6.Text = "Chưa xác nhận";
                label6.ForeColor = Color.Red;
                if (bus_pn.check_ChiTietPN(frmPhieuNhap.mapn))
                {
                    btnXacNhan.Visible = false;
                }
                else
                {
                    btnXacNhan.Visible = true;
                }
            }
           
            dgvChiTietPN.DataSource = bus_pn.getList_ChiTietPN(frmPhieuNhap.mapn);
            cboTenSP.DataSource = bus_sp.getList_TenSP();
            cboTenSP.Text = string.Empty;

            cboMaPN.DataSource = bus_pn.getList_PN();
            cboMaPN.DisplayMember = "ID";
            cboMaPN.Text = frmPhieuNhap.mapn;
        }

        private void cboTenSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboTenSP.DroppedDown = true;
        }

        private void cboMaPN_KeyDown(object sender, KeyEventArgs e)
        {
            cboMaPN.DroppedDown = true;
        }

        private void cboTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDonGia.Text = string.Format("{0:0,0}", bus_sp.getDonGia_SP(bus_sp.getID_Name(cboTenSP.Text)));
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvChiTietPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnLuu.Enabled = btnXacNhan.Enabled = true;
            xóaToolStripMenuItem.Enabled = true;
            cboMaPN.Text = dgvChiTietPN.CurrentRow.Cells["IDPN"].Value.ToString();
            cboTenSP.Text = dgvChiTietPN.CurrentRow.Cells["IDSP"].Value.ToString();
            txtDonGia.Text = string.Format("{0:0,0}",dgvChiTietPN.CurrentRow.Cells["DONGIA"].Value.ToString());
            txtSoLuong.Text = dgvChiTietPN.CurrentRow.Cells["SOLUONG"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //kiểm tra rỗng
            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                txtSoLuong.Focus();
                Program.AlertMessage("Vui lòng nhập " + label5.Text.ToLower(), MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                cboTenSP.Focus();
                Program.AlertMessage("Vui lòng chọn sản phẩm ", MessageBoxIcon.Warning);
                return;
            }
            if (int.Parse(txtSoLuong.Text) <= 0)
            {
                txtSoLuong.Focus();
                txtSoLuong.Text = "1";
                Program.AlertMessage("Số lượng phải lớn hơn 0", MessageBoxIcon.Warning);
                return;
            }

            string mapn = cboMaPN.Text;
            string masp = bus_sp.getID_Name(cboTenSP.Text);
            double? gia = bus_sp.getDonGia_SP(bus_sp.getID_Name(cboTenSP.Text));
            CHITIETPN pn = new CHITIETPN
            {
                ID_PN = mapn,
                ID_SP = masp,
                SOLUONG = int.Parse(txtSoLuong.Text),
                GIANHAP = gia
            };
            //Kiểm tra trùng khóa chí tiết phiếu nhập
            int? sl = bus_pn.getSoLuong(mapn, masp);
            if (bus_pn.check_PrimaryKey_CTPN(mapn, masp))
            {
                if (bus_pn.update_CTPN(pn))
                {
                    loadCTPN();
                    Program.AlertMessage("Cập nhật thành công", MessageBoxIcon.Information);
                    //Cập nhật thành tiên ở bảng phiếu nhập
                    if (!bus_pn.update_ThanhTien(mapn))
                    {
                        Program.AlertMessage("Đã xảy ra lỗi cập nhật thành tiền", MessageBoxIcon.Error);
                        return;
                    }
                    //Cập nhật số lượng sản phẩm ở bảng sản phẩm
                    if (!bus_sp.update_SoLuongSP(masp,(int.Parse(txtSoLuong.Text) - sl)))
                    {
                        Program.AlertMessage("Đã xảy ra lỗi cập nhật số lượng", MessageBoxIcon.Error);
                        return;
                    }
                    txtSoLuong.Text = string.Empty;
                    txtDonGia.Text = bus_sp.getDonGia_SP(bus_sp.getID_Name(cboTenSP.Text)).ToString();
                    return;
                }
                Program.AlertMessage("Đã xảy ra lỗi cập nhật", MessageBoxIcon.Error);
                return;
            }

            if (bus_pn.insert_CTPN(pn))
            {
                loadCTPN();
                Program.AlertMessage("Thêm thành công", MessageBoxIcon.Information);
                //Cập nhật thành tiên ở bảng phiếu nhập
                if (!bus_pn.update_ThanhTien(mapn))
                {
                    Program.AlertMessage("Đã xảy ra lỗi cập nhật thành tiền", MessageBoxIcon.Error);
                    return;
                }
                //Cập nhật số lượng sản phẩm ở bảng sản phẩm
                if (!bus_sp.update_SoLuongSP(masp, int.Parse(txtSoLuong.Text)))
                {
                    Program.AlertMessage("Đã xảy ra lỗi cập nhật số lượng", MessageBoxIcon.Error);
                    return;
                }
                txtSoLuong.Text = string.Empty;
                txtDonGia.Text = bus_sp.getDonGia_SP(bus_sp.getID_Name(cboTenSP.Text)).ToString();
                return;
            }
            Program.AlertMessage("Đã xảy ra lỗi khi thêm", MessageBoxIcon.Warning);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mapn = dgvChiTietPN.CurrentRow.Cells["IDPN"].Value.ToString();
            string masp = bus_sp.getID_Name(dgvChiTietPN.CurrentRow.Cells["IDSP"].Value.ToString());

            if (bus_pn.delete_CTPN(mapn, masp))
            {

                loadCTPN();
                xóaToolStripMenuItem.Enabled = false;
                //Cập nhật thành tiên ở bảng phiếu nhập
                if (!bus_pn.update_ThanhTien(mapn))
                {
                    Program.AlertMessage("Đã xảy ra lỗi cập nhật thành tiền", MessageBoxIcon.Error);
                    return;
                }
                //Cập nhật số lượng sản phẩm ở bảng sản phẩm
                if (!bus_sp.update_SoLuongSP(masp, -int.Parse(txtSoLuong.Text)))
                {
                    Program.AlertMessage("Đã xảy ra lỗi cập nhật số lượng", MessageBoxIcon.Error);
                    return;
                }
                txtSoLuong.Text = string.Empty;
                txtDonGia.Text = bus_sp.getDonGia_SP(bus_sp.getID_Name(cboTenSP.Text)).ToString();
                Program.AlertMessage("Xóa thành công", MessageBoxIcon.Information);
                return;
            }
            Program.AlertMessage("Đã xảy ra lỗi khi xóa", MessageBoxIcon.Error);
        }

        private void cboMaPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCTPN();
        }

        public void loadCTPN()
        {
            if (bus_pn.getTrangThai(cboMaPN.Text) == true)
            {
                btnLuu.Visible = false;
                txtSoLuong.Enabled = false;
                label6.Text = "Đã xác nhận";
                label6.ForeColor = Color.Green;
            }
            else
            {
                btnLuu.Visible = true;
                txtSoLuong.Enabled = true;
                label6.Text = "Chưa xác nhận";
                label6.ForeColor = Color.Red;
                if (bus_pn.check_ChiTietPN(cboMaPN.Text))
                {
                    btnXacNhan.Visible = false;
                }
                else
                {
                    btnXacNhan.Visible = true;
                }
            }
            
            dgvChiTietPN.DataSource = bus_pn.getList_ChiTietPN(cboMaPN.Text);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn xác nhân phiếu nhập này", "Thông báo",

            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1);

            if (r == DialogResult.Yes)
            {
                bus_pn.updateTrangThai(cboMaPN.Text);
                loadCTPN();
                btnXacNhan.Visible = false;
            }
               
        }
    }
}
