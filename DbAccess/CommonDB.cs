using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess
{
    public abstract class CommonDB
    {
        private readonly string connectionString;

        public CommonDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string ConnectionString
        {
            get { return connectionString; }
        }

        public bool ExecuteNonQuery(string query)
        {
            if(!string.IsNullOrEmpty(query))
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            return false;
        }

        public DataSet ExecueQuery(string query, CommandType type)
        {
            if (!string.IsNullOrEmpty(query))
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con) { CommandType = type })
                    {
                        DataSet ds = new DataSet();
                        SqlDataAdapter a = new SqlDataAdapter(command);
                        a.Fill(ds);
                        return ds;
                    }
                }
                
            }
            throw new ArgumentException("Something went wrong. Check query syntax");
        }
    }
}
