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
  public partial class ThanhToan : Form
  {
    private const string sqlGrid = @"
          SELECT a.MaNhanVien
          , HoDem
          , Ten
          , PhongBan
          , ChucVu
          , TenBacLuong
          , TenTroCap
          , a.MaNgayCong
          , TenThuong
          , TenKhauTru
          , SoTienLuong
          , ThanhToan
          FROM bThongTinNhanVien a
          LEFT JOIN bBacLuong b ON a.MaBacLuong = b.MaBacLuong
          LEFT JOIN bTroCap c ON a.MaTroCap = c.MaTroCap
          LEFT JOIN bNgayCong d ON a.MaNgayCong = d.MaNgayCong
          LEFT JOIN bThuong e ON a.MaThuong = e.MaThuong
          LEFT JOIN bKhauTru f ON a.MaKhauTru = f.MaKhauTru
          LEFT JOIN bLuong g ON a.MaNhanVien = g.MaNhanVien";
    private SqlDataAdapter mDataAdapter;
    private DataSet ds = new DataSet();
    private DataTable dt = new DataTable();
    private Int32 maNhanVien;

    public ThanhToan()
    {
      InitializeComponent();
    }

    private void HienThiDataGrid()
    {
      try
      {
        using (var conn = Helper.getConnection())
        {
          conn.Open();

          var ds = new DataSet();
          var da = new SqlDataAdapter(new SqlCommand(sqlGrid, conn));
          da.Fill(ds, "NhanVien");

          dtGrid_TTL.DataSource = ds.Tables["NhanVien"].DefaultView;
        }
      }
      catch (Exception excep)
      {
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
    }

    private void ThanhToan_Load(object sender, EventArgs e)
    {
      HienThiDataGrid();
    }

    private void btnTim_Click(object sender, EventArgs e)
    {
      string TKMaNV = txtTimMa.Text;
      string TKTenNV = txtTimTen.Text;
      try
      {

        using (var conn = Helper.getConnection())
        {
          var sql = sqlGrid + string.Format(@" WHERE a.MaNhanVien ='{0}'", TKMaNV);
          if (TKTenNV.Length > 0)
          {
            sql += string.Format(@" OR Ten LIKE'%{0}%'", TKTenNV);
          }

          using (var command = new SqlCommand(sql, conn))
          {
            conn.Open();
            var ds = new DataSet();
            var da = new SqlDataAdapter(command);
            da.Fill(ds, "TimKiemt");
            dtGrid_TTL.DataSource = ds.Tables["TimKiemt"].DefaultView;
          }
        }
      }
      catch (Exception excep)
      {
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
    }

    private void btnLuu_Click(object sender, EventArgs e)
    {
      try
      {
        var sql = string.Format("Update bLuong set ThanhToan={0} where MaNhanVien='{1}'",
          chbThanhToan.Checked == true ? 1 : 0, maNhanVien);
        using (var conn = Helper.getConnection())
        {
          conn.Open();
          var commnd = new SqlCommand(sql, conn);
          commnd.ExecuteNonQuery();
        }
        HienThiDataGrid();
        MessageBox.Show("Đã Cập Nhật Cơ Sở Dữ Liệu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception excep)
      {
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
    }

    private void btnXem_Click(object sender, EventArgs e)
    {
      if (dtGrid_TTL.CurrentRow != null)
      {
        maNhanVien = int.Parse(dtGrid_TTL.Rows[dtGrid_TTL.CurrentRow.Index].Cells[0].Value.ToString());
        string check = dtGrid_TTL.Rows[dtGrid_TTL.CurrentRow.Index].Cells[11].Value.ToString();
        if(check=="1")
        //chbThanhToan.Checked = Convert.ToBoolean(check);
     //   var cells = dtGrid_TTL.CurrentRow.Cells;
   //     maNhanVien = int.Parse(cells[0].Value.ToString());
       // string check = cells[1].Value.ToString();
        chbThanhToan.Checked = true;
        else
          chbThanhToan.Checked = false;
      }
    }
  }
}