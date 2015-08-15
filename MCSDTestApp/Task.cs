using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace MCSDTestApp
{
    class Tasks
    {

        public static void Main(string[] args)
        {
            string query1 = "select name,groupname from HumanResources.Department";
            string query2 = "select * from HumanResources.Employee";

            try
            {
                DataSet ds1, ds2;
                SqlConnection sqlcon = new SqlConnection();
                sqlcon.ConnectionString = "Server=localhost;Database=AdventureWorks2012;User Id=sa;Password=p@$$w0rd;";
                sqlcon.OpenAsync();

                Console.WriteLine("Connected Successfully..!!");

                Console.WriteLine(DateTime.Now.ToString());
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = sqlcon;
                cmd1.CommandText = query1;
                cmd1.CommandType = CommandType.Text;
                SqlCommand cmd2 = cmd1.Clone();
                cmd2.CommandText = query2;


               // cmd2.ExecuteNonQuery();

                ds2 = new DataSet();
                ds1 = new DataSet();

                // Multiple task
                Task t1 = Task.Run(() =>
                {

                    if (sqlcon.State != ConnectionState.Executing)
                    {
                        Console.WriteLine("Task 1 Started..");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                        {
                            da.Fill(ds1);
                        }
                    }

                    //cmd1.ExecuteNonQuery();
                }).ContinueWith((i) =>
                {
                    Console.WriteLine("Error in TAsk 1");

                }, TaskContinuationOptions.OnlyOnFaulted);

                Task t2 = Task.Run(() =>
                {
                    Console.WriteLine("Task 2 Started..");

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd2))
                    {
                        da.Fill(ds2);
                    }

                    //cmd1.ExecuteNonQuery();
                });

                t1.Wait();
                t2.Wait();


                Console.WriteLine(ds1.Tables[0].Rows.Count.ToString());
                Console.WriteLine(ds2.Tables[0].Rows.Count.ToString());

                /// Parent Child Task 
                //              Task<Int32[]> t = Task<Int32[]>.Run(() =>
                //              {
                //                  var results = new Int32[3];
                //                  new Task(() => results[0] = 0,
                //TaskCreationOptions.AttachedToParent).Start();
                //                  new Task(() => results[1] = 1,
                //                  TaskCreationOptions.AttachedToParent).Start();
                //                  new Task(() => results[2] = 2,
                //                  TaskCreationOptions.AttachedToParent).Start();

                //                  return results;
                //              });


                Console.WriteLine(DateTime.Now.ToString());
                Console.Read();
            }
            catch (Exception)
            {
                throw new Exception("Unable to connect..!");

            }

        }
    }
}
