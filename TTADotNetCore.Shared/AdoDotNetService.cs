using System.Data;
using System.Data.SqlClient;

namespace TTADotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString = "";

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DataTable Query(string Query, params SqlParameterModel[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(Query, connection);
            if(sqlParameters != null)
            {
                foreach (var SqlParameter in sqlParameters)
                {
                    cmd.Parameters.AddWithValue(SqlParameter.Name, SqlParameter.Value);
                }
            }
            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public int Execute(string Query, params SqlParameterModel[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(Query, connection);
            if (sqlParameters != null)
            {
                foreach (var SqlParameter in sqlParameters)
                {
                    cmd.Parameters.AddWithValue(SqlParameter.Name, SqlParameter.Value);
                }
            }

            var result=cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }

    }

    public class SqlParameterModel
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public SqlParameterModel() { }
        public SqlParameterModel(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
