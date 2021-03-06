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
    public partial class QuanTri : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter da;
        private string TenPhanQuyen;
        public QuanTri()
        {
            InitializeComponent();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien frmQLNV = new QuanLyNhanVien();
            frmQLNV.Show();

        }

        private void btnQLL_Click(object sender, EventArgs e)
        {
            QuanLyTienLuong frmQLTL = new QuanLyTienLuong();
            frmQLTL.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThanhToan frmTT = new ThanhToan();
            frmTT.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BaoMatPhanQuyen frmBMPQ = new BaoMatPhanQuyen();
            frmBMPQ.Show();
        }

        private void QuanTri_Load(object sender, EventArgs e)
        {
            // Tu TenPhanQuyen Lay ra Ten Phan Quyen
            try
            {
                conn = new SqlConnection("Server=TIEN-A62E5B5725;Initial Catalog=QuanLyTienLuong;Integrated Security=True");
                conn.Open();
                SqlCommand commnd;
                commnd = new SqlCommand("Select TenPQ from bPhanQuyen where MaPQ='" + BienTC.MaPhanQuyen.ToString() + "'", conn);
                DataSet ds = new DataSet();
                da = new SqlDataAdapter(commnd);
                da.Fill(ds, "TenPQ");
                TenPhanQuyen = ds.Tables["TenPQ"].Rows[0]["TenPQ"].ToString();              

            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                MessageBox.Show(excep.StackTrace);
            }

            if (TenPhanQuyen == "AD")
            {
                btnQLNV.Enabled = true;
                btnQLL.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
            }
            if (TenPhanQuyen == "QLNV")
            {
                btnQLNV.Enabled = true;
                btnQLL.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = false;
            }
            if (TenPhanQuyen == "TTL")
            {
                btnQLNV.Enabled = false;
                btnQLL.Enabled = true;
                button3.Enabled = false;
                button5.Enabled = false;
            }
            if (TenPhanQuyen == "TT")
            {
                btnQLNV.Enabled = false;
                btnQLL.Enabled = false;
                button3.Enabled = true;
                button5.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phần mềm được xây dựng bởi Nguyễn Tiến Hưng,Nguyễn Hữu Hải,Nguyễn Thị Lai,Nguyễn Hoàng Tuấn mọi chi tiết xin liên hệ nthung86@gmail.com","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

    }
}