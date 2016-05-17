using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace QuanLyLuong
{
  static class Helper
  {
    static public SqlConnection getConnection()
    {
      var url = ConfigurationManager.ConnectionStrings["dev"].ConnectionString;
      return new SqlConnection(url);
    }
  }
}