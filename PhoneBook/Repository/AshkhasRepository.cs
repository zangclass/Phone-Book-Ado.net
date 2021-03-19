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
    public class AshkhasRepository : iAshkhas
    {
        SqlConnection conn;
        public AshkhasRepository()
        {
            conn = new SqlConnection(BbInformation.ConnectionStringDatabase);
        }
        public void Add(AshkhasEntity obj)
        {
            conn.Open();
            SqlCommand com = new SqlCommand("dbo.Ashkhas_Excute", conn);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Kind", 1);
            com.Parameters.AddWithValue("@ShahrId", obj.ShahrId);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@NameKhanevadegi", obj.NameKhanevadegi);
            com.Parameters.AddWithValue("@Tel", obj.Tel);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@CodePosti", obj.CodePosti);

            com.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public void Edit(AshkhasEntity obj, int? id)
        {
            conn.Open();
            SqlCommand com = new SqlCommand("dbo.Ashkhas_Excute", conn);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Kind", 2);
            com.Parameters.AddWithValue("@Id", id);
            com.Parameters.AddWithValue("@ShahrId", obj.ShahrId);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@NameKhanevadegi", obj.NameKhanevadegi);
            com.Parameters.AddWithValue("@Tel", obj.Tel);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@CodePosti", obj.CodePosti);

            com.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable GetEntitytList()
        {
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("dbo.Ashkhas_Query", conn);
            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
            ad.SelectCommand.Parameters.AddWithValue("@Kind", 1);
            var dt = new DataTable();
            ad.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable GetOstan()
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

        public DataTable GetShakhs(int? Id)
        {
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("dbo.Ashkhas_Query", conn);
            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
            ad.SelectCommand.Parameters.AddWithValue("@Kind", 3);
            ad.SelectCommand.Parameters.AddWithValue("@Id", Id);
            var dt = new DataTable();
            ad.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable Getshar(int IdOstan)
        {
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("dbo.Shahr_Query", conn);
            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
            ad.SelectCommand.Parameters.AddWithValue("@Kind", 3);
            ad.SelectCommand.Parameters.AddWithValue("@OstanId", IdOstan);
            var dt = new DataTable();
            ad.Fill(dt);
            conn.Close();
            return dt;
        }

        public AshkhasEntity GetSingleEntity(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
