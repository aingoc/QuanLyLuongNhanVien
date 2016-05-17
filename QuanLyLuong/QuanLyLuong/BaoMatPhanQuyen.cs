using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyLuong
{
  public partial class BaoMatPhanQuyen : Form
  {
    public BaoMatPhanQuyen()
    {
      InitializeComponent();
    }
    // Hiện Thị Dữ Liệu Trong DataGrid!
    private void HienThiDuLieuPhanQuyen()
    {
      try
      {
        using (var conn = Helper.getConnection())
        {
          var sql = "SELECT * FROM bQuanTri INNER JOIN bPhanQuyen ON bQuanTri.MaPQ = bPhanQuyen.MaPQ";
          using (var command = new SqlCommand(sql, conn))
          {
            conn.Open();
            var ds = new DataSet();
            var da = new SqlDataAdapter(command);
            da.Fill(ds, "PhanQuyen");

            dgvPhanQuyen.DataSource = ds.Tables["PhanQuyen"].DefaultView;
          }
        }
      }
      catch (Exception excep)
      {
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
    }

    public Boolean CheckDataPhanQuyen()
    {
      if (txttentruynhapQT.Text == "")
      {
        MessageBox.Show("Tên Truy Nhập Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txttentruynhapQT.Focus();
        return false;
      }
      if (txtMatKhauQT.Text == "")
      {
        MessageBox.Show("Mật Khẩu Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtMatKhauQT.Focus();
        return false;
      }
      if (tXacNhanQT.Text == "")
      {
        MessageBox.Show(" Xác Nhận Mật Khẩu Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        tXacNhanQT.Focus();
        return false;
      }
      if (txtMaQT.Text == "")
      {
        MessageBox.Show("Mã Quản Trị Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtMaQT.Focus();
        return false;
      }
      if (txtMaPQ.Text == "")
      {
        MessageBox.Show("Mã Phân Quyền Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtMaPQ.Focus();
        return false;
      }
      if (txtHoTenQT.Text == "")
      {
        MessageBox.Show(" Họ Tên Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtHoTenQT.Focus();
        return false;
      }
      if (txtTenPhanQuyen.Text == "")
      {
        MessageBox.Show(" Tên phân quyền Ko Ðuợc Ðể Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtTenPhanQuyen.Focus();
        return false;
      }
      if (cbPB.Text == "")
      {
        MessageBox.Show(" Phòng Ban Ko Ðược Ðể Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        cbPB.Focus();
        return false;
      }
      if (txtDiaChiQT.Text == "")
      {
        MessageBox.Show(" Ðịa chỉ Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtDiaChiQT.Focus();
        return false;
      }
      if (txtDienThoaiQT.Text == "")
      {
        MessageBox.Show(" Ðiện thoại Không Ðược Ðể Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtDienThoaiQT.Focus();
        return false;
      }
      if (txtEmailQT.Text == "")
      {
        MessageBox.Show(" Email Quản trị Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtEmailQT.Focus();
        return false;
      }

      return true;
    }
    public void taomoi()
    {
      txttentruynhapQT.Text = "";
      txtMatKhauQT.Text = "";
      tXacNhanQT.Text = "";
      txtHoTenQT.Text = "";
      cbPB.Text = "";
      txtMaPQ.Text = "";
      txtTenPhanQuyen.Text = "";
      txtMaQT.Text = "";
      txtDiaChiQT.Text = "";
      txtEmailQT.Text = "";
      txtDienThoaiQT.Text = "";
      ckbAdmin.Checked = false;
      ckbQuanLyNV.Checked = false;
      ckbThanhToan.Checked = false;
      ckbTinhTienLuong.Checked = false;
    }

    private void btnThemQ_Click(object sender, EventArgs e)
    {
      taomoi();
    }

    private void btnXemQ_Click(object sender, EventArgs e)
    {
      if (dgvPhanQuyen.CurrentRow != null)
      {
        txtMaQT.Text = dgvPhanQuyen.CurrentRow.Cells[0].Value.ToString();
        txtMaPQ.Text = dgvPhanQuyen.CurrentRow.Cells[1].Value.ToString();
        txttentruynhapQT.Text = dgvPhanQuyen.CurrentRow.Cells[2].Value.ToString();
        txtMatKhauQT.Text = dgvPhanQuyen.CurrentRow.Cells[3].Value.ToString();
        tXacNhanQT.Text = dgvPhanQuyen.CurrentRow.Cells[3].Value.ToString();
        txtHoTenQT.Text = dgvPhanQuyen.CurrentRow.Cells[4].Value.ToString();
        cbPB.Text = dgvPhanQuyen.CurrentRow.Cells[5].Value.ToString();
        txtDiaChiQT.Text = dgvPhanQuyen.CurrentRow.Cells[6].Value.ToString();
        txtDienThoaiQT.Text = dgvPhanQuyen.CurrentRow.Cells[7].Value.ToString();
        txtEmailQT.Text = dgvPhanQuyen.CurrentRow.Cells[8].Value.ToString();
        txtMaPQ.Text = dgvPhanQuyen.CurrentRow.Cells[9].Value.ToString();
        txtTenPhanQuyen.Text = dgvPhanQuyen.CurrentRow.Cells[10].Value.ToString();

        //-------------------------------
        string biQLNV = dgvPhanQuyen.CurrentRow.Cells[11].Value.ToString();
        ckbQuanLyNV.Checked = biQLNV == "True";

        //-------------------------------
        string biTinhLuong = dgvPhanQuyen.CurrentRow.Cells[12].Value.ToString();
        ckbTinhTienLuong.Checked = biTinhLuong == "True";

        //-------------------------------
        string biThanhToan = dgvPhanQuyen.CurrentRow.Cells[13].Value.ToString();
        ckbThanhToan.Checked = biThanhToan == "True";

        //-------------------------------
        string biAdmin = dgvPhanQuyen.CurrentRow.Cells[14].Value.ToString();
        ckbAdmin.Checked = biAdmin == "True";
      }
    }

    private void BaoMatPhanQuyen_Load(object sender, EventArgs e)
    {
      HienThiDuLieuPhanQuyen();
    }

    private void btnLuuQ_Click(object sender, EventArgs e)
    {
      if (CheckDataPhanQuyen() == true)
      {
        string PQMaQT = txtMaQT.Text;
        string PQHoTen = txtHoTenQT.Text;
        string PQTenTruyCap = txttentruynhapQT.Text;
        string PQMatKhau = txtMatKhauQT.Text;
        string PQXacNhan = tXacNhanQT.Text;
        string PQPhongBan = cbPB.Text;
        string PQTenPhanQuyen = txtTenPhanQuyen.Text;
        string PQMaPQ = txtMaPQ.Text;
        string PQDiaChi = txtDiaChiQT.Text;
        int PQSDT = Convert.ToInt32(txtDienThoaiQT.Text);
        string PQEmail = txtEmailQT.Text;
        //----------------------
        int PQQLNV = (ckbQuanLyNV.Checked == true) ? 1 : 0;
        //------------------
        int PQTinhTienLuong = (ckbTinhTienLuong.Checked == true) ? 1 : 0;
        //-------------------------
        int PQThanhToan = (ckbThanhToan.Checked == true) ? 1 : 0;
        //--------------------
        int PQAdmin = (ckbAdmin.Checked == true) ? 1 : 0;

        try
        {
          using (var conn = Helper.getConnection())
          {
            var sql = string.Format(@"INSERT INTO bPhanQuyen VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
              PQMaPQ, PQTenPhanQuyen, PQQLNV, PQTinhTienLuong, PQThanhToan, PQAdmin);

            conn.Open();
            using (var command = new SqlCommand(sql, conn))
            {
              command.ExecuteNonQuery();
            }

            //-----------------------luu cai bang Quan tri sau--------
            sql = string.Format(@"INSERT INTO bQuanTri VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
              PQMaQT, PQMaPQ, PQTenTruyCap, PQMatKhau, PQHoTen, PQPhongBan, PQDiaChi, PQSDT, PQEmail);
            using (var command = new SqlCommand(sql, conn))
            {
              command.ExecuteNonQuery();
            }
          }

          HienThiDuLieuPhanQuyen();
          MessageBox.Show("Ðã Thêm 1 Bản Ghi Vào CSDL", "Thông Báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception excep)
        {
          MessageBox.Show(excep.Message);
          MessageBox.Show(excep.StackTrace);
        }
      }
    }

    private void btnSuaQ_Click(object sender, EventArgs e)
    {
      if (CheckDataPhanQuyen() == true)
      {
        string PQMaQT = txtMaQT.Text;
        string PQHoTen = txtHoTenQT.Text;
        string PQTenTruyCap = txttentruynhapQT.Text;
        string PQMatKhau = txtMatKhauQT.Text;
        string PQXacNhan = tXacNhanQT.Text;
        string PQPhongBan = cbPB.Text;
        string PQTenPhanQuyen = txtTenPhanQuyen.Text;
        string PQMaPQ = txtMaPQ.Text;
        string PQDiaChi = txtDiaChiQT.Text;
        int PQSDT = Convert.ToInt32(txtDienThoaiQT.Text);
        string PQEmail = txtEmailQT.Text;
        //----------------------
        int PQQLNV = (ckbQuanLyNV.Checked == true) ? 1 : 0;
        //------------------
        int PQTinhTienLuong = (ckbTinhTienLuong.Checked == true) ? 1 : 0;
        //-------------------------
        int PQThanhToan = (ckbThanhToan.Checked == true) ? 1 : 0;
        //--------------------
        int PQAdmin = (ckbAdmin.Checked == true) ? 1 : 0;

        //Luu Lại Dữ Liệu Đã Cập Nhật
        try
        {
          using (var conn = Helper.getConnection())
          {
            string sql = string.Format(@"
            UPDATE bQuanTri
            SET TenTK='{0}', Pass='{1}', HoTen='{1}', PhongBan='{2}', DiaChi='{3}', SoDienThoai='{4}', Email='{5}'
            WHERE MaQT='{6}'", PQTenTruyCap, PQMatKhau, PQHoTen, PQPhongBan, PQDiaChi, PQSDT, PQEmail, PQMaQT);

            conn.Open();
            using (var command = new SqlCommand(sql, conn))
            {
              command.ExecuteNonQuery();
            }

            sql = string.Format(@"
            UPDATE bPhanQuyen
            SET TenPQ='{0}', QLNV='{1}', TinhLuong='{2}', ThanhToan='{3}', PhanQuyen='{4}'
            WHERE MaPQ='{5}'", PQTenPhanQuyen, PQQLNV, PQTinhTienLuong, PQThanhToan, PQAdmin, PQMaPQ);
            using (var command = new SqlCommand(sql, conn))
            {
              command.ExecuteNonQuery();
            }

            HienThiDuLieuPhanQuyen();
            MessageBox.Show("Ðã sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
        catch (Exception excep)
        {
          MessageBox.Show(excep.Message);
          MessageBox.Show(excep.StackTrace);
        }
      }
    }

    private void btnXoaQ_Click(object sender, EventArgs e)
    {
      if (dgvPhanQuyen.CurrentRow != null)
      {
        if (MessageBox.Show("Bạn đã chắc sẽ xóa bản ghi này chứ!", "Thông Báo",
          MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
          string MaQT = dgvPhanQuyen.CurrentRow.Cells[0].Value.ToString();
          string MaPQ = dgvPhanQuyen.CurrentRow.Cells[2].Value.ToString();

          using (var conn = Helper.getConnection())
          {
            var sql = string.Format("DELETE FORM bQuanTri WHERE MaQuanTri = {0} AND MaPQ = {1}", MaQT, MaQT);
            using (var command = new SqlCommand(sql, conn))
            {
              conn.Open();
              command.ExecuteNonQuery();
            }
          }
          HienThiDuLieuPhanQuyen();
        }
      }
    }

    private void ckbQuanLyNV_CheckedChanged(object sender, EventArgs e)
    {
      if (ckbQuanLyNV.Checked == true)
      {
        ckbThanhToan.Checked = false;
        ckbTinhTienLuong.Checked = false;
        ckbAdmin.Checked = false;
      }
    }

    private void ckbTinhTienLuong_CheckedChanged(object sender, EventArgs e)
    {
      if (ckbTinhTienLuong.Checked == true)
      {
        ckbQuanLyNV.Checked = false;
        ckbThanhToan.Checked = false;
        ckbAdmin.Checked = false;
      }
    }

    private void ckbAdmin_CheckedChanged(object sender, EventArgs e)
    {
      if (ckbAdmin.Checked == true)
      {
        ckbQuanLyNV.Checked = false;
        ckbTinhTienLuong.Checked = false;
        ckbThanhToan.Checked = false;
      }
    }

    private void ckbThanhToan_CheckedChanged(object sender, EventArgs e)
    {
      if (ckbThanhToan.Checked == true)
      {
        ckbQuanLyNV.Checked = false;
        ckbTinhTienLuong.Checked = false;
        ckbAdmin.Checked = false;
      }
    }
  }
}