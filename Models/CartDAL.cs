using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace ECommWeb.Models
{
    public class CartDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;

        public CartDAL(IConfiguration configuration)
        {
                this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("SqlConnection"));
        }

        public DataTable GetCartForUser(int userId) { 
        DataTable dt = new DataTable();

            string qry = @"select * 
from Product
inner join Cart on Product.Id=Cart.ProductID
where Cart.UserID=@userId";

            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@userId", userId);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);

            con.Close();

           
            return dt;
        
        }
        

    }
}
