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
    public class OstanRepository : iOstan
    {
        SqlConnection conn;
        public OstanRepository()
        {
            conn = new SqlConnection(BbInformation.ConnectionStringDatabase);
        }
        public void Add(OstanEntity obj)
        {
            conn.Open();
            SqlCommand com = new SqlCommand("dbo.Ostan_Excute", conn);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Kind", 1);
            com.Parameters.AddWithValue("@NameOstan", obj.NameOstan);

            com.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(OstanEntity obj, int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetEntitytList()
        {
            throw new NotImplementedException();
        }

        public OstanEntity GetSingleEntity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
