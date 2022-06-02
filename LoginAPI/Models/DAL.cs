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
                        Id = Convert.ToInt32(dr["Id"]),
                    }); ;
                }
            }
            return Leadlist;
        }

        public int DeleteCustomer(int Id)
        {
            SqlConnection cont = new SqlConnection(conn);
            SqlCommand command = cont.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DeleteleadDetails_SP";
            command.Parameters.AddWithValue("@Id", Id);
          
            cont.Open();
            int i = command.ExecuteNonQuery();
            cont.Close();
            return i;
        }
        
        public int UpdateCustomer(Lead lead)
        {
            SqlConnection cont = new SqlConnection(conn);
            /* SqlCommand command = cont.CreateCommand();
             command.CommandType = CommandType.StoredProcedure;
             command.CommandText = "UpdateLeadDetails";
             */
            SqlCommand command = new SqlCommand("Masterinsertupdatedelete", cont);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@lName",lead.Name);
            command.Parameters.AddWithValue("@lProject_Name",lead.Project_Name);
         
            command.Parameters.AddWithValue("@lStatus",lead.Status);
            command.Parameters.AddWithValue("@lAdded",lead.Added);
            command.Parameters.AddWithValue("@lType",lead.Type);
            command.Parameters.AddWithValue("@lContact",lead.Contact);
            command.Parameters.AddWithValue("@lAction",lead.Action);
            command.Parameters.AddWithValue("@lAssignee",lead.Assignee);
            command.Parameters.AddWithValue("@lBid_Date",lead.Bid_Date);
            command.Parameters.AddWithValue("@lId", lead.Id);





            cont.Open();
            int i = command.ExecuteNonQuery();
            cont.Close();
            return i;
        }

        public string UpdateData(Lead lead)
        {
            SqlConnection cont = null;
            string result = "";
            try
            {
                cont = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                SqlCommand command = new SqlCommand("UpdateLeadDetails", cont);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", lead.Name);
                command.Parameters.AddWithValue("@Project_Name", lead.Project_Name);

                command.Parameters.AddWithValue("@Status", lead.Status);
                command.Parameters.AddWithValue("@Added", lead.Added);
                command.Parameters.AddWithValue("@Type", lead.Type);
                command.Parameters.AddWithValue("@Contact", lead.Contact);
                command.Parameters.AddWithValue("@Action", lead.Action);
                command.Parameters.AddWithValue("@Assignee", lead.Assignee);
                command.Parameters.AddWithValue("@Bid_Date", lead.Bid_Date);
                command.Parameters.AddWithValue("@Id", lead.Id);


                cont.Open();
                result = command.ExecuteScalar() as string;
                return result;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                cont.Close();
            }
        }

        public List<Lead> GetCustomers()
        {
            List<Lead> customers = new List<Lead>();
            SqlConnection cont = new SqlConnection(conn);
            SqlCommand command = cont.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_Lead";
          
            command.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            cont.Open();
            sd.Fill(dt);
            cont.Close();
            foreach (DataRow dr in dt.Rows)
            {
                customers.Add(
                    new Lead
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
                        Id = Convert.ToInt32(dr["Id"]),
                    });
            }
            return customers;
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
