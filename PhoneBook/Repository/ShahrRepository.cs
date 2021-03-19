using PhoneBook.Class;
using PhoneBook.Entity;
using PhoneBook.inteface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Repository
{
    public class ShahrRepository : iShahr
    {
        SqlConnection conn;
        public ShahrRepository()
        {
            conn = new SqlConnection(BbInformation.ConnectionStringDatabase);
        }
        public void Add(ShahrEntity obj)
        {
            conn.Open();
            SqlCommand com = new SqlCommand("dbo.Shahr_Excute", conn);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Kind", 1);
            com.Parameters.AddWithValue("@OstanId", obj.OstanId);
            com.Parameters.AddWithValue("@NameShahr", obj.NameShahr);

            com.ExecuteNonQuery();
            conn.Close();
        }

        public void Edit(ShahrEntity obj, int? id)
        {
            conn.Open();
            SqlCommand com = new SqlCommand("dbo.Shahr_Excute", conn);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Kind", 2);
            com.Parameters.AddWithValue("@OstanId", obj.OstanId);
            com.Parameters.AddWithValue("@NameShahr", obj.NameShahr);
            com.Parameters.AddWithValue("@Id", id);

            com.ExecuteNonQuery();
            conn.Close();
        }
        public void Delete(int? id)
        {
            conn.Open();
            SqlCommand com = new SqlCommand("dbo.Shahr_Excute", conn);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Kind", 3);
            com.Parameters.AddWithValue("@Id", id);

            com.ExecuteNonQuery();
            conn.Close();
        }


        public DataTable GetEntitytList()
        {
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("dbo.Shahr_Query", conn);
            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
            ad.SelectCommand.Parameters.AddWithValue("@Kind", 1);
            var dt = new DataTable();
            ad.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable GetOstanList()
        {
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("dbo.Ostan_Query", conn);
            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
            ad.SelectCommand.Parameters.AddWithValue("@Kind", 1);
            var dt = new DataTable();
            ad.Fill(dt);
            conn.Close();
            return dt;
        }

        public ShahrEntity GetSingleEntity(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
