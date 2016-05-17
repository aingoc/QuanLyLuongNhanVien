using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyLuong
{
  public partial class Login : Form
  {
    private SqlConnection conn;
    private SqlCommand commnd;
    private SqlDataAdapter da;
    public Login()
    {
      InitializeComponent();
    }

    private void btnDangNhap_Click_1(object sender, EventArgs e)
    {
      string name = txtTaiKhoan.Text;
      string pass = txtMatKhau.Text;
      string url;
      string strSQL;
      DataSet ds = new DataSet();
      url = ConfigurationManager.ConnectionStrings["dev"].ConnectionString;

      try
      {
        conn = new SqlConnection(url);
        conn.Open();
      }
      catch (Exception excep)
      {
        MessageBox.Show("Có vấn đề khi kết nối đến CSDL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
      strSQL = "Select MaPQ,TenTK,Pass from bQuanTri";
      try
      {
        commnd = new SqlCommand(strSQL, conn);
      }
      catch (Exception excep)
      {
        MessageBox.Show("Có vấn đề khi truy vấn đến CSDL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
      try
      {
        da = new SqlDataAdapter(commnd);
        da.Fill(ds, "DangNhap");

      }
      catch (Exception excep)
      {
        MessageBox.Show("Có vấn đề khi tao ra dataset", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
      if (ds.Tables["DangNhap"].Rows.Count == 0)

      {
        MessageBox.Show("Không có dữ liệu trong cơ sở dữ liệu");
        conn.Close();
      }
      Boolean check = false;
      for (int i = 0; i < ds.Tables["DangNhap"].Rows.Count; i++)
      {
        if (ds.Tables["DangNhap"].Rows[i]["TenTK"].ToString() == name && ds.Tables["DangNhap"].Rows[i]["Pass"].ToString() == pass)
        {
          BienTC.MaPhanQuyen = ds.Tables["DangNhap"].Rows[i]["MaPQ"].ToString();
          check = true;
          i = ds.Tables["DangNhap"].Rows.Count;
        }
      }
      if (check == false)
      {
        MessageBox.Show("Bạn Nhập Sai Tên Tài Khoản hoặc Pass", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        QuanTri frmQuanTri = new QuanTri();
        frmQuanTri.Show();
      }
    }

    private void btnThoat_Click_1(object sender, EventArgs e)
    {
      Application.Exit();
    }
  }
}
