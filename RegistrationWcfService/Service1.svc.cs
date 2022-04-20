using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace RegistrationWcfService
{
    
    public class Service1 : IService1
    {
        string cs = "server=DESKTOP-BDS6074\\SQLEXPRESS; database=sampledata; integrated security=SSPI";
        public string InsertStudDetails(StudDetails stud)
        {
            string Status;

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GridCrud", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(new SqlParameter[]
                        {
                       new SqlParameter("@Event","Insert"),
                        new SqlParameter("@firstname", stud.Firstname),
                        new SqlParameter("@lastname",stud.Lastname),
                        new SqlParameter("@studaddress",stud.Studaddress),
                        new SqlParameter("@gender",stud.Gender),
                        new SqlParameter("@course",stud.Course),
                        new SqlParameter("@sports",stud.Sports),
                        new SqlParameter("@phone",stud.Phone),
                        new SqlParameter("@emailaddress",stud.Emailaddress),
                        new SqlParameter("@username",stud.Username),
                        new SqlParameter("@password",stud.Password)
                        });

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Status = "Record Inserted successfully";
                    }
                    else
                    {
                        Status = "Record could not be Inserted";
                    }
                    con.Close();
                    return Status;
                }
            }




        }
        public DataSet GetStudDetails(StudDetails stud)
        {


            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GridCrud", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Event", "Select");

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();


                }

            }

        }
        public DataSet FetchUpdatedRecords(StudDetails stud)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("Sp_GridCrud", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Event", "SelectOne");
                    cmd.Parameters.AddWithValue("@studid", stud.Studid);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return ds;
                }
            }


        }

        public string UpdateStudDetails(StudDetails stud)
        {
            string Status;
            using (SqlConnection con = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("Sp_GridCrud", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(new SqlParameter[]
                        {
                       new SqlParameter("@Event","Update"),
                       new SqlParameter("@studid",stud.Studid),
                       new SqlParameter("@firstname", stud.Firstname),
                        new SqlParameter("@lastname",stud.Lastname),
                        new SqlParameter("@studaddress",stud.Studaddress),
                        new SqlParameter("@gender",stud.Gender),
                        new SqlParameter("@course",stud.Course),
                        new SqlParameter("@sports",stud.Sports),
                        new SqlParameter("@phone",stud.Phone),
                        new SqlParameter("@emailaddress",stud.Emailaddress),
                        new SqlParameter("@username",stud.Username),
                        new SqlParameter("@password",stud.Password)

                        });

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Status = "Record updated successfully";
                    }
                    else
                    {
                        Status = "Record could not be updated";
                    }
                    con.Close();
                    return Status;
                }
            }

        }

        public bool DeleteStudDetails(StudDetails stud)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GridCrud", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Event", "");
                    cmd.Parameters.AddWithValue("@studid", stud.Studid);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }

        }

        public bool CheckLogin(StudDetails stud)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                bool res;

                SqlParameter par = new SqlParameter("@username", stud.Username);
                SqlParameter par1 = new SqlParameter("@password", stud.Password);

                SqlCommand cmd = new SqlCommand("select username,password from tblstudents where username=@username and password=@password", con);
                cmd.Parameters.Add(par);
                cmd.Parameters.Add(par1);

                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                return res = dr.Read();
                con.Close();

            }
        }

    }
}
