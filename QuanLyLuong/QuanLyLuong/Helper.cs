using System.Data.SqlClient;

namespace QuanLyLuong
{
  public static class Helper
  {
    public static SqlConnection getConnection()
    {
      var url = QuanLyLuong.Properties.Settings.Default.QuanLyTienLuongConnectionString;
      return new SqlConnection(url);
    }
  }
}