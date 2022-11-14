using ASPNetCoreWebApp_ConsumeAzureSQLServer.Models;
using System.Data.SqlClient;
namespace ASPNetCoreWebApp_ConsumeAzureSQLServer.Services
{
    public class ProductService
    {
        
        private SqlConnection GetConnection() {
            // Use package System.Data.SqlClient
            var _builder= new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_user_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts(){
            SqlConnection conn = GetConnection();
            List<Product> _product_list = new List<Product>();
            string statement = "SELECT * from Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    _product_list.Add(product);
                }
            }
            conn.Close();
            return _product_list;
        }
    }
}
