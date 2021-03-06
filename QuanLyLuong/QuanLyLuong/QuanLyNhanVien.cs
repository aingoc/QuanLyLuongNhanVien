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
  public partial class QuanLyNhanVien : Form
  {
    private DataSet ds = new DataSet();
    private DataTable dt = new DataTable();

    private const string sqlGrid = @"
    SELECT
      MaNhanVien
    , HoDem
    , Ten
    , NgaySinh
    , GioiTinh
    , PhongBan
    , ChucVu
    , DiaChi
    , DienThoai
    , CMND
    , EMail
    , TenBacLuong
    , TenTroCap
    FROM bThongTinNhanVien a
    LEFT JOIN bBacLuong b ON a.MaBacLuong = b.MaBacLuong
    LEFT JOIN bTroCap c ON a.MaTroCap = c.MaTroCap";
    private Int32 maNhanVien;

    public QuanLyNhanVien()
    {
      InitializeComponent();
    }

    private void QuanLyNhanVien_Load(object sender, EventArgs e)
    {
      // TODO: This line of code loads data into the 'quanLyTienLuongDataSet1.bTroCap' table. You can move, or remove it, as needed.
      this.bTroCapTableAdapter.Fill(this.quanLyTienLuongDataSet.bTroCap);
      // TODO: This line of code loads data into the 'quanLyTienLuongDataSet.bBacLuong' table. You can move, or remove it, as needed.
      this.bBacLuongTableAdapter.Fill(this.quanLyTienLuongDataSet.bBacLuong);

      HienThiDuLieuXemTruoc();
    }

    private void HienThiDuLieuXemTruoc()
    {
      try
      {
        using (var conn = Helper.getConnection())
        {
          conn.Open();

          var ds = new DataSet();
          var da = new SqlDataAdapter(new SqlCommand(sqlGrid, conn));
          da.Fill(ds, "NhanVien");

          DataGV.DataSource = ds.Tables["NhanVien"].DefaultView;
        }
      }
      catch (Exception excep)
      {
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
    }

    public void ResetField()
    {
      maNhanVien = 0;
      txtHoDem.Text = "";
      txtTen.Text = "";
      cbPhongBan.Text = "";
      txtChucVu.Text = "";
      txtDiaChi.Text = "";
      txtDienThoai.Text = "";
      txtCMND.Text = "";
      txtNgaySinh.Text = "";
      txtEmail.Text = "";
      cbBacLuong.Text = "";
      cbTroCap.Text = "";
      rdNam.Checked = true;
      rdNu.Checked = false;
    }

    //Hàm kiểm tra thông tin nhập liệu
    private Boolean CheckData()
    {
      if (txtHoDem.Text == "")
      {
        MessageBox.Show("Họ Đệm Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtHoDem.Focus();
        return false;
      }
      if (txtTen.Text == "")
      {
        MessageBox.Show("Tên Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtTen.Focus();
        return false;
      }
      if (cbPhongBan.Text == "")
      {
        MessageBox.Show("Phòng Ban Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        cbPhongBan.Focus();
        return false;
      }
      if (txtChucVu.Text == "")
      {
        MessageBox.Show("Chức Vụ Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtChucVu.Focus();
        return false;
      }
      if (txtDiaChi.Text == "")
      {
        MessageBox.Show("Địa Chỉ Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtDiaChi.Focus();
        return false;
      }
      if (txtDienThoai.Text == "")
      {
        MessageBox.Show("Điện Thoại Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtDienThoai.Focus();
        return false;
      }
      try
      {
        int i = Convert.ToInt32(txtDienThoai.Text);
      }
      catch
      {
        MessageBox.Show("Điện Thoại Ko Phải Là Kiểu Số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtDienThoai.Focus();
        return false;
      }
      if (txtCMND.Text == "")
      {
        MessageBox.Show("Số CMND Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtCMND.Focus();
        return false;
      }
      try
      {
        int j = Convert.ToInt32(txtCMND.Text);
      }
      catch
      {
        MessageBox.Show("số CMND Ko Phải Là Kiểu Số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtCMND.Focus();
        return false;
      }
      if (txtNgaySinh.Text == "")
      {
        MessageBox.Show("Ngày Sinh Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtNgaySinh.Focus();
        return false;
      }
      if (txtEmail.Text == "")
      {
        MessageBox.Show("Email Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtEmail.Focus();
        return false;
      }
      if (cbBacLuong.Text == "")
      {
        MessageBox.Show("Bậc Lương Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        cbBacLuong.Focus();
        return false;
      }
      if (cbTroCap.Text == "")
      {
        MessageBox.Show("Trợ Cấp Ko Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        cbTroCap.Focus();
        return false;
      }
      if (rdNam.Checked == false && rdNu.Checked == false)
      {
        MessageBox.Show("Chưa Chọn Giới Tính Cho Nhân Viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;

      }
      return true;
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
      if (CheckData() == true)
      {
        //Gia Tri Cac O TextBox dc gan cho cac bien trung gian
        //GiaTriTextBox();
        string HD = txtHoDem.Text;
        string Ten = txtTen.Text;
        string PB = cbPhongBan.Text;
        string CV = txtChucVu.Text;
        string DC = txtDiaChi.Text;
        int SoDT = Convert.ToInt32(txtDienThoai.Text);
        int CMND = Convert.ToInt32(txtCMND.Text);
        string NS = txtNgaySinh.Text;
        string Email = txtEmail.Text;
        int GioiTinh = (rdNam.Checked == true) ? 1 : 0;


        //Lấy ra mã bậc lương và mã trợ cấp từ tên BLuong và tên TCap
        try
        {
          //Lấy ra mã bậc lương và mã trợ cấp từ tên BLuong và tên bTroCap
          using (var conn = Helper.getConnection())
          {
            var MaBL = (cbBacLuong.SelectedItem as DataRowView)["MaBacLuong"].ToString();
            var MaTC = (cbTroCap.SelectedItem as DataRowView)["MaTroCap"].ToString();
            if (MaBL != null && MaTC != null)
            {
              conn.Open();
              //Insert Data vào bThongTinNhanVien
              var sql = string.Format(@"
                  INSERT INTO bThongTinNhanVien(HoDem,Ten,Ngaysinh,GioiTinh,PhongBan,ChucVu,DiaChi,DienThoai,CMND,Email,MaBacLuong,MaTroCap)
                  OUTPUT INSERTED.MaNhanVien
                  VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                  HD, Ten, NS, GioiTinh, PB, CV, DC, SoDT, CMND, Email, MaBL, MaTC);

              using (var insertCommand = new SqlCommand(sql, conn))
              {
                maNhanVien = (Int32)insertCommand.ExecuteScalar();
              }

              //Khoi Tao 1 Gia Tri Tuong ung voi Ma Nhan Vien do trong bang bLuong
              sql = string.Format("INSERT INTO bLuong(MaNhanVien) VALUES('{0}')", maNhanVien);
              using (var insertCommand = new SqlCommand(sql, conn))
              {
                insertCommand.ExecuteNonQuery();
              }

              ResetField();

              //Thong Bao Da Hoan Thanh
              MessageBox.Show("Đã Thêm 1 Bản Ghi Vào CSDL", "Thông Báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
              HienThiDuLieuXemTruoc();
            }
            else
            {
              MessageBox.Show("Không tìm thấy Mã Trợ Cấp hoặc Mã Bậc Lương!", "Thông Báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          }
        }
        catch (Exception excep)
        {
          MessageBox.Show(excep.Message);
          MessageBox.Show(excep.StackTrace);
        }
      }
    }
    private void btnTim_Click(object sender, EventArgs e)
    {
      string TKMaNV = txtTimMa.Text;
      string TKTenNV = txtTimTen.Text;
      try
      {

        using (var conn = Helper.getConnection())
        {
          var sql = sqlGrid + string.Format(@" WHERE MaNhanVien ='{0}'", TKMaNV);
          if (TKTenNV.Length > 0)
          {
            sql += string.Format(@" OR Ten LIKE'%{0}%'", TKTenNV);
          }

          using (var command = new SqlCommand(sql, conn))
          {
            conn.Open();
            var ds = new DataSet();
            var da = new SqlDataAdapter(command);
            da.Fill(ds, "TimKiem");
            DataGV.DataSource = ds.Tables["TimKiem"].DefaultView;
          }
        }
      }
      catch (Exception excep)
      {
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {

      if (DataGV.CurrentRow != null)
      {
        if (MessageBox.Show("Bạn đã chắc chắn sẽ xóa bản ghi này chứ!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
          int MaNV = int.Parse(DataGV.CurrentRow.Cells["MaNhanVien"].Value.ToString());
          using (var conn = Helper.getConnection())
          {
            conn.Open();
            // Xóa bản ghi trong bảng bLuong trước khi xóa bản ghi trong bản bThongTinNhanVien
            using (var command = new SqlCommand(
              string.Format("DELETE bLuong WHERE MaNhanVien='{0}'", MaNV), conn))
            {
              command.ExecuteNonQuery();
            }

            using (var command = new SqlCommand(
              string.Format("DELETE bThongTinNhanVien WHERE MaNhanVien='{0}'", MaNV), conn))
            {
              command.ExecuteNonQuery();
            }
          }
          HienThiDuLieuXemTruoc();
        }
      }
    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
      txtNgaySinh.Text = dateTimePicker1.Value.ToShortDateString();
    }

    private void btnXem_Click(object sender, EventArgs e)
    {
      if (DataGV.CurrentRow != null)
      {
        var cells = DataGV.CurrentRow.Cells;
        maNhanVien = int.Parse(cells[0].Value.ToString());
        txtHoDem.Text = cells[1].Value.ToString();
        txtTen.Text = cells[2].Value.ToString();

        txtNgaySinh.Text = Convert.ToDateTime(cells[3].Value.ToString()).ToShortDateString();

        string check = cells[4].Value.ToString();
        rdNam.Checked = check.Equals("1");
        rdNu.Checked = check.Equals("0");

        cbPhongBan.Text = cells[5].Value.ToString();
        txtChucVu.Text = cells[6].Value.ToString();
        txtDiaChi.Text = cells[7].Value.ToString();
        txtDienThoai.Text = cells[8].Value.ToString();
        txtCMND.Text = cells[9].Value.ToString();
        txtEmail.Text = cells[10].Value.ToString();
        cbBacLuong.Text = cells[11].Value.ToString();
        cbTroCap.Text = cells[12].Value.ToString();
      }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      if (CheckData() == true)
      {
        //Gia Tri Cac O TextBox dc gan cho cac bien trung gian
        string HD = txtHoDem.Text;
        string Ten = txtTen.Text;
        string PB = cbPhongBan.Text;
        string CV = txtChucVu.Text;
        string DC = txtDiaChi.Text;
        int SoDT = Convert.ToInt32(txtDienThoai.Text);
        int CMND = Convert.ToInt32(txtCMND.Text);
        string NS = txtNgaySinh.Text;
        string Email = txtEmail.Text;
        int GioiTinh = (rdNam.Checked == true) ? 1 : 0;

        try
        {
          //Lấy ra mã bậc lương và mã trợ cấp từ tên BLuong và tên bTroCap
          using (var conn = Helper.getConnection())
          {
            var MaBL = (cbBacLuong.SelectedItem as DataRowView)["MaBacLuong"].ToString();
            var MaTC = (cbTroCap.SelectedItem as DataRowView)["MaTroCap"].ToString();
            if (MaBL != null && MaTC != null)
            {
              var sql = string.Format(@"
                  UPDATE bThongTinNhanVien
                  SET
                    HoDem='{0}', Ten ='{1}', NgaySinh='{2}', GioiTinh={3}, PhongBan='{4}', ChucVu='{5}'
                  , DiaChi='{6}', DienThoai='{7}', CMND='{8}', Email='{9}', MaBacLuong='{10}', MaTroCap='{11}'
                  WHERE MaNhanVien='{12}'", HD, Ten, NS, GioiTinh, PB, CV, DC, SoDT, CMND, Email, MaBL, MaTC, maNhanVien);

              using (var updateCommand = new SqlCommand(sql, conn))
              {
                conn.Open();
                updateCommand.ExecuteNonQuery();
              }

              HienThiDuLieuXemTruoc();
              MessageBox.Show("Đã Cập Nhật Dữ Liệu Thành Công!", "Thông Báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
              MessageBox.Show("Không tìm thấy Mã Trợ Cấp hoặc Mã Bậc Lương!", "Thông Báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          }
        }
        catch (Exception excep)
        {
          MessageBox.Show(excep.Message);
          MessageBox.Show(excep.StackTrace);
        }
      }
    }
  }
}