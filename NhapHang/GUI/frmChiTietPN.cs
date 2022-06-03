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
        }

        private void frmChiTietPN_Load(object sender, EventArgs e)
        {
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
            btnXoa.Enabled = btnCapNhat.Enabled = true;

            cboMaPN.Text = dgvChiTietPN.CurrentRow.Cells["IDPN"].Value.ToString();
            cboTenSP.Text = dgvChiTietPN.CurrentRow.Cells["IDSP"].Value.ToString();
            txtDonGia.Text = string.Format("{0:0,0}",dgvChiTietPN.CurrentRow.Cells["DONGIA"].Value.ToString());
            txtSoLuong.Text = dgvChiTietPN.CurrentRow.Cells["SOLUONG"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
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
                    this.frmChiTietPN_Load(sender, e);
                    Program.AlertMessage("Cập nhật thành công", MessageBoxIcon.Information);
                    //Cập nhật thành tiên
                    if (!bus_pn.update_ThanhTien(mapn))
                    {
                        Program.AlertMessage("Đã xảy ra lỗi cập nhật thành tiền", MessageBoxIcon.Information);
                        return;
                    }

                    if (!bus_sp.update_SoLuongSP(masp,(int.Parse(txtSoLuong.Text) - sl)))
                    {
                        Program.AlertMessage("Đã xảy ra lỗi cập nhật số lượng", MessageBoxIcon.Information);
                        return;
                    }
                    txtSoLuong.Text = txtDonGia.Text = string.Empty;
                    return;
                }
                Program.AlertMessage("Đã xảy ra lỗi cập nhật", MessageBoxIcon.Warning);
                return;
            }

            if (bus_pn.insert_CTPN(pn))
            {
                this.frmChiTietPN_Load(sender, e);
                Program.AlertMessage("Thêm thành công", MessageBoxIcon.Information);
                //Cập nhật thành tiền
                if (!bus_pn.update_ThanhTien(mapn))
                {
                    Program.AlertMessage("Đã xảy ra lỗi cập nhật thành tiền", MessageBoxIcon.Information);
                    return;
                }
                if (!bus_sp.update_SoLuongSP(masp, int.Parse(txtSoLuong.Text)))
                {
                    Program.AlertMessage("Đã xảy ra lỗi cập nhật số lượng", MessageBoxIcon.Information);
                    return;
                }
                txtSoLuong.Text = txtDonGia.Text = string.Empty;
                return;
            }
            Program.AlertMessage("Đã xảy ra lỗi khi thêm", MessageBoxIcon.Warning);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mapn = cboMaPN.Text;
            string masp = bus_sp.getID_Name(cboTenSP.Text);

            if (bus_pn.delete_CTPN(mapn, masp))
            {
                btnXoa.Enabled = btnCapNhat.Enabled = false;
                this.frmChiTietPN_Load(sender, e);
                if (!bus_pn.update_ThanhTien(mapn))
                {
                    Program.AlertMessage("Đã xảy ra lỗi cập nhật thành tiền", MessageBoxIcon.Information);
                    return;
                }
                if (!bus_sp.update_SoLuongSP(masp, -int.Parse(txtSoLuong.Text)))
                {
                    Program.AlertMessage("Đã xảy ra lỗi cập nhật số lượng", MessageBoxIcon.Information);
                    return;
                }
                txtSoLuong.Text = txtDonGia.Text = string.Empty;
                Program.AlertMessage("Xóa thành công", MessageBoxIcon.Information);
                return;
            }
            Program.AlertMessage("Đã xảy ra lỗi khi xóa", MessageBoxIcon.Warning);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                txtSoLuong.Focus();
                Program.AlertMessage("Vui lòng nhập " + label5.Text.ToLower(), MessageBoxIcon.Warning);
                return;
            }

            string mapn = cboMaPN.Text;
            string masp = bus_sp.getID_Name(cboTenSP.Text);
            int? sl = bus_pn.getSoLuong(mapn, masp);
            CHITIETPN pn = new CHITIETPN
            {
                ID_PN = mapn,
                ID_SP = masp,
                SOLUONG = int.Parse(txtSoLuong.Text),
            };

            if (bus_pn.update_CTPN(pn))
            {
                btnXoa.Enabled = btnCapNhat.Enabled = false;
                this.frmChiTietPN_Load(sender, e);
                Program.AlertMessage("Cập nhật thành công", MessageBoxIcon.Information);
                //Cập nhật thành tiên
                if (!bus_pn.update_ThanhTien(mapn))
                {
                    Program.AlertMessage("Đã xảy ra lỗi cập nhật thành tiền", MessageBoxIcon.Information);
                    return;
                }

                if (!bus_sp.update_SoLuongSP(masp, (int.Parse(txtSoLuong.Text) - sl)))
                {
                    Program.AlertMessage("Đã xảy ra lỗi cập nhật số lượng", MessageBoxIcon.Information);
                    return;
                }
                txtSoLuong.Text = txtDonGia.Text = string.Empty;
                return;
            }
            Program.AlertMessage("Đã xảy ra lỗi cập nhật", MessageBoxIcon.Warning);
            return;

        }

        private void cboMaPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvChiTietPN.DataSource = bus_pn.getList_ChiTietPN(cboMaPN.Text);
        }
    }
}
