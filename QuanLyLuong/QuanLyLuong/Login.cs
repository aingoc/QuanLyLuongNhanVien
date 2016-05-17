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
    public Login()
    {
      InitializeComponent();
    }

    private void btnDangNhap_Click_1(object sender, EventArgs e)
    {
      try
      {
        using (var conn = Helper.getConnection())
        {
          var sql = string.Format(@"
          SELECT MaPQ, TenTK, Pass FROM bQuanTri
          WHERE TenTK='{0}' AND Pass='{1}'", txtTaiKhoan.Text, txtMatKhau.Text);

          using (var command = new SqlCommand(sql, conn))
          {
            conn.Open();
            using (var reader = command.ExecuteReader())
            {
              if (reader.Read())
              {
                BienTC.MaPhanQuyen = reader.GetString(reader.GetOrdinal("MaPQ"));
                QuanTri frmQuanTri = new QuanTri();
                frmQuanTri.Show();

//              this.Close();
              }
              else
              {
                MessageBox.Show("Bạn Nhập Sai Tên Tài Khoản hoặc Pass", "Thông Báo",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
            }
          }
        }
      }
      catch (Exception excep)
      {
        MessageBox.Show("Có vấn đề khi kết nối đến CSDL", "Thông báo",
          MessageBoxButtons.OK, MessageBoxIcon.Warning);
        MessageBox.Show(excep.Message);
        MessageBox.Show(excep.StackTrace);
      }
    }

    private void btnThoat_Click_1(object sender, EventArgs e)
    {
      Application.Exit();
    }
  }
}