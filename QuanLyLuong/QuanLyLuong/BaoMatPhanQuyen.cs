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
    private int PQMaQT;
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
          var sql = "SELECT bQuanTri.MaQuanTri,bQuanTri.TenTK,bQuanTri.Pass,bQuanTri.XacNhanPass,bQuanTri.HoTen,bQuanTri.PhongBan,bQuanTri.DiaChi,bQuanTri.Email,bQuanTri.SoDienThoai, bPhanQuyen.MaPQ,bPhanQuyen.TenPQ,bPhanQuyen.QLNV,bPhanQuyen.Admin FROM bQuanTri  INNER JOIN bPhanQuyen ON bQuanTri.MaPQ = bPhanQuyen.MaPQ";
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
        txttentruynhapQT.Text = dgvPhanQuyen.CurrentRow.Cells[1].Value.ToString();
        txtMatKhauQT.Text = dgvPhanQuyen.CurrentRow.Cells[2].Value.ToString();
        tXacNhanQT.Text = dgvPhanQuyen.CurrentRow.Cells[3].Value.ToString();
        txtHoTenQT.Text = dgvPhanQuyen.CurrentRow.Cells[4].Value.ToString();
        cbPB.Text = dgvPhanQuyen.CurrentRow.Cells[5].Value.ToString();
        txtDiaChiQT.Text = dgvPhanQuyen.CurrentRow.Cells[6].Value.ToString();
        txtEmailQT.Text = dgvPhanQuyen.CurrentRow.Cells[7].Value.ToString();
        txtDienThoaiQT.Text = dgvPhanQuyen.CurrentRow.Cells[8].Value.ToString();
        txtMaPQ.Text = dgvPhanQuyen.CurrentRow.Cells[9].Value.ToString();
        txtTenPhanQuyen.Text = dgvPhanQuyen.CurrentRow.Cells[10].Value.ToString();
        
        
        string biQLNV = dgvPhanQuyen.CurrentRow.Cells[11].Value.ToString();
        ckbQuanLyNV.Checked = biQLNV.Equals("1");
        
        string biAdmin = dgvPhanQuyen.CurrentRow.Cells[12].Value.ToString();
        ckbAdmin.Checked = biAdmin.Equals("1");

        PQMaQT = int.Parse(dgvPhanQuyen.CurrentRow.Cells[0].Value.ToString());
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
        string PQHoTen = txtHoTenQT.Text;
        string PQTenTruyCap = txttentruynhapQT.Text;
        string PQMatKhau = txtMatKhauQT.Text;
        string PQXacNhan = tXacNhanQT.Text;
        string PQPhongBan = cbPB.Text;
        string PQTenPhanQuyen = txtTenPhanQuyen.Text;
        string PQDiaChi = txtDiaChiQT.Text;
        int PQSDT = Convert.ToInt32(txtDienThoaiQT.Text);
        string PQEmail = txtEmailQT.Text;
        //----------------------
        int PQQLNV = (ckbQuanLyNV.Checked == true) ? 1 : 0;
        //------------------
        int PQAdmin = (ckbAdmin.Checked == true) ? 1 : 0;

        try
        {
          using (var conn = Helper.getConnection())
          {
            int PQMaPQ = 0;
            var sql = string.Format(@"INSERT INTO bPhanQuyen (TenPQ,QLNV,Admin)
            OUTPUT INSERTED.MaPQ
            VALUES('{0}','{1}','{2}')",  PQTenPhanQuyen, PQQLNV, PQAdmin);

            conn.Open();
            using (var command = new SqlCommand(sql, conn))
            {
              PQMaPQ = (Int32)command.ExecuteScalar();
            }

            //-----------------------INSERT bang Quan tri sau--------
            sql = string.Format(@"INSERT INTO bQuanTri (TenTK,Pass,XacNhanPass,HoTen,PhongBan,DiaChi,SoDienThoai,Email,MaPQ)
            OUTPUT INSERTED.MaQuanTri
            VALUES('{0}','{1}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
              PQTenTruyCap, PQMatKhau, PQHoTen, PQPhongBan, PQDiaChi, PQSDT, PQEmail, PQMaPQ);
            using (var command = new SqlCommand(sql, conn))
            {
              PQMaQT = (Int32)command.ExecuteScalar();
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
        string PQHoTen = txtHoTenQT.Text;
        string PQTenTruyCap = txttentruynhapQT.Text;
        string PQMatKhau = txtMatKhauQT.Text;
        string PQXacNhan = tXacNhanQT.Text;
        string PQPhongBan = cbPB.Text;
        string PQTenPhanQuyen = txtTenPhanQuyen.Text;
        int PQMaPQ = Convert.ToInt32(txtMaPQ.Text);
        string PQDiaChi = txtDiaChiQT.Text;
        int PQSDT = Convert.ToInt32(txtDienThoaiQT.Text);
        string PQEmail = txtEmailQT.Text;
        //----------------------
        int PQQLNV = (ckbQuanLyNV.Checked == true) ? 1 : 0;
 
        //--------------------
        int PQAdmin = (ckbAdmin.Checked == true) ? 1 : 0;

        //Luu Lại Dữ Liệu Đã Cập Nhật
        try
        {
          using (var conn = Helper.getConnection())
          {
            conn.Open();
            string sql = string.Format(@"
            UPDATE bQuanTri
            SET TenTK='{1}', Pass='{2}', HoTen='{3}', PhongBan='{4}', DiaChi='{5}',Email='{6}', SoDienThoai='{7}'
            WHERE MaQuanTri='{0}'", PQMaQT, PQTenTruyCap, PQMatKhau, PQHoTen, PQPhongBan, PQDiaChi, PQEmail, PQSDT);

            
            using (var command = new SqlCommand(sql, conn))
            {
              command.ExecuteNonQuery();
            }

            sql = string.Format(@"
            UPDATE bPhanQuyen
            SET TenPQ='{1}', QLNV='{2}', Admin='{3}'
            WHERE MaPQ='{0}'", PQMaPQ, PQTenPhanQuyen, PQQLNV, PQAdmin);
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
          int MaQT = int.Parse(dgvPhanQuyen.CurrentRow.Cells["MaQuanTri"].Value.ToString());
          int MaPQ = int.Parse(dgvPhanQuyen.CurrentRow.Cells["MaPQ"].Value.ToString());

          using (var conn = Helper.getConnection())
          {
            var sql = string.Format("DELETE  bQuanTri WHERE MaQuanTri = {0} AND MaPQ = {1}", MaQT, MaPQ);
            using (var command = new SqlCommand(sql, conn))
            {
              conn.Open();
              command.ExecuteNonQuery();
            }
          }
          HienThiDuLieuPhanQuyen();
          MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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