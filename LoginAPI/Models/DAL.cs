using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using LoginAPI.Models;



namespace LoginAPI.Models
{
    public class DAL
    {
        string conn = ConfigurationManager.ConnectionStrings["con"].ToString();






        public List<Lead> Show_data()
        {
            List<Lead> Leadlist = new List<Lead>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_Lead";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();



                connection.Open();
                da.Fill(dt);
                connection.Close();



                foreach (DataRow dr in dt.Rows)
                {
                    Leadlist.Add(new Lead
                    {
                        Name = dr["Name"].ToString(),
                        Project_Name = dr["Project_Name"].ToString(),
                        Status = dr["Status"].ToString(),
                        Added = dr["Added"].ToString(),
                        Type = dr["Type"].ToString(),
                        Contact = dr["Contact"].ToString(),
                        Action = dr["Action"].ToString(),
                        Assignee = dr["Assignee"].ToString(),
                        Bid_Date = dr["Bid_Date"].ToString(),
                    });
                }
            }
            return Leadlist;
        }

        /*public int User_Login(string Email,string Password)
        {
            int res = 0;
            string s = "";
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand com = new SqlCommand("sp_Login", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Email",Email);
            com.Parameters.AddWithValue("@Password",Password);
            connection.Open();
            com.ExecuteNonQuery();
            res = Convert.ToInt32(s);
            return res;
            
            


        }*/

   /* public int User_Login(string Email,string Password)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                //Create the SqlCommand object
                SqlCommand cmd = new SqlCommand("sp_Login", con);

                //Specify that the SqlCommand is a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd.Parameters.AddWithValue("@Email", "");
                cmd.Parameters.AddWithValue("@Password", "");


                //Add the output parameter to the command object
                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@responseMessage";
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outPutParameter);

                //Open the connection and execute the query
                con.Open();
                cmd.ExecuteNonQuery();

                //Retrieve the value of the output parameter
                string ResponseMessage = outPutParameter.Value.ToString();
            }
*/
}





}
