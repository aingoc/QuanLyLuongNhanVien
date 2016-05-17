using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace QuanLyLuong
{
  public static class Helper
  {
    public static SqlConnection getConnection()
    {
      var url = ConfigurationManager.ConnectionStrings["dev"].ConnectionString;
      return new SqlConnection(url);
    }
  }
}