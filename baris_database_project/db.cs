using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Web.Routing;
using System.Security.Cryptography;

namespace baris_database_project
{
    internal class db
    {
        private SqlConnection con;
        private SqlCommand cmd ;
        private DataSet ds;
        private SqlDataAdapter da;
        private BindingSource bs;
        private string sql;




        public  void openConnection()
        {
            con = new SqlConnection("Data Source=localhost;Initial Catalog=AdventureWorks2012;User ID=sa;Password=v3r1s1s");

            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                    //MessageBox.Show("the conneciton is: " + con.State.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("connection failed:" + ex.Message);
                throw;
            }
        }
        public  void closeConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    //MessageBox.Show("the conneciton is: " + con.State.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("close connection error:" + ex.Message);
                throw;
            }
        }

        public void getdata(string sQ, DataGridView dataGridView)
        {
            DataTable dt = new DataTable();
            using (con)
            {
                try
                {
                    openConnection();

                    // Your data retrieval and modification code will go here
                    
                    string sqlQuery = sQ;
                    using (da = new SqlDataAdapter(sqlQuery, con))
                    {
                        da.Fill(dt);
                        
                    }
                    dataGridView.DataSource = dt;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally 
                { 
                    closeConnection(); 
                }
                
            }
        }

        public void getperson(string sQ, DataGridView dataGridView)
        {
            DataTable dt = new DataTable();
            using (con)
            {
                try
                {
                    openConnection();

                    // Your data retrieval and modification code will go here

                    string sqlQuery = sQ;
                    using (da = new SqlDataAdapter(sqlQuery, con))
                    {
                        da.Fill(dt);

                    }
                    dataGridView.DataSource = dt;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    closeConnection();
                }

            }
        }

        public DataTable getrow (string sQ,int id)
        {
            DataTable dt = new DataTable();
            using (con)
            {
                try
                {
                    openConnection();

                    // Your data retrieval and modification code will go here

                    using(cmd = new SqlCommand(sQ,con))
                    {
                        cmd.Parameters.AddWithValue("@BusinessEntityId", id);
                        using (da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(dt);

                        }
                    }
                    
                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    closeConnection();
                }

            }
            return dt;
        }


        public void update(string sQ, Person person, int id)
        {
   
            using (con)
            {
                try
                {
                    openConnection();

                    // Update Person.Person set FirstName = @FirstName Where BusinessEntintyId = @id

                    
                    using (cmd = new SqlCommand(sQ, con))
                    {
                        cmd.Parameters.AddWithValue ("@BusinessEntityId", id);
                        
                        //cmd.Parameters.AddWithValue("@PersonType", person.PersonType);
                        //cmd.Parameters.AddWithValue("@NameStyle", person.NameStyle);
                        //cmd.Parameters.AddWithValue("@Title", person.Title);

                        cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", person.MiddleName);
                        cmd.Parameters.AddWithValue("@LastName", person.LastName);

                        //cmd.Parameters.AddWithValue("@Suffix", person.Suffix);
                        //cmd.Parameters.AddWithValue("@EmailPromotion", person.EmailPromotion);
                        //cmd.Parameters.AddWithValue("@AdditionalContactInfo", person.AdditionalContactInfo);

                        //cmd.Parameters.AddWithValue("@Demographics", person.Demographics);
                        //cmd.Parameters.AddWithValue("@rowquid", person.rowquid);
                        //cmd.Parameters.AddWithValue("@ModifiedDate", person.ModifiedDate);

                        cmd.ExecuteNonQuery();

                    }
                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    closeConnection();
                }

            }
        }
        public void adddata(string sq, string first, string mid, string last)
        {
            using (con)
            {
                try
                {
                    openConnection();

                    // Update Person.Person set FirstName = @FirstName Where BusinessEntintyId = @id


                    using (cmd = new SqlCommand(sq, con))
                    {
                        //cmd.Parameters.AddWithValue("@bid", id);
                        //cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@FirstName", first);
                        cmd.Parameters.AddWithValue("@MiddleName", mid);
                        cmd.Parameters.AddWithValue("@LastName", last);

                        cmd.ExecuteNonQuery();

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    closeConnection();
                }

            }
        }
        public void deletedata(string sq,string id)
        {
            using (con)
            {
                try
                {
                    openConnection();

                    // Update Person.Person set FirstName = @FirstName Where BusinessEntintyId = @id


                    using (cmd = new SqlCommand(sq, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@eid", id);
                        cmd.Parameters.AddWithValue("@bid", id);


                        cmd.ExecuteNonQuery();

                    }  


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    closeConnection();
                }

            }
        }

      
    }
    

}
