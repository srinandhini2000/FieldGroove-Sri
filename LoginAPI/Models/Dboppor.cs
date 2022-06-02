using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LoginAPI.Models
{
    public class Dboppor
    {
        string conn = ConfigurationManager.ConnectionStrings["con"].ToString();






        public List<Opportunity> Show_data()
        {
            List<Opportunity> opplist = new List<Opportunity>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_opportunity";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();



                connection.Open();
                da.Fill(dt);
                connection.Close();



                foreach (DataRow dr in dt.Rows)
                {
                    opplist.Add(new Opportunity
                    {
                        Customer = dr["Customer"].ToString(),
                       Created  = dr["Created"].ToString(),
                        Modified = dr["Modified"].ToString(),
                        Status = dr["Status"].ToString(),
                        Name_Number = dr["Name_Number"].ToString(),
                        Address = dr["Address"].ToString(),
                        Salesperson = dr["Salesperson"].ToString(),
                        Action = dr["Action"].ToString(),
                        Due_Date = dr["Due_Date"].ToString(),
                    });
                }
            }
            return opplist;
        }
    }
}