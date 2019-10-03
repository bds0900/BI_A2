using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ReadWrite
{
    class DAL
    {

        public DAL()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["YoYo"].ConnectionString;
            Console.WriteLine(connectionString);
            //check database exist
            if (Database.Exists(ConfigurationManager.ConnectionStrings["YoYo"].ConnectionString))
            {
                Console.WriteLine("exist");
            }
            else
            {
                Console.WriteLine("Data base is note exist, create one");
                // if not exit create
                using (var context = new YoYoDbContext())
                {
                    #region state
                    var states = new List<State>
                    {
                        new State { StateName = "MOLD" },
                        new State { StateName = "QUEUE_INSPECTION_1" },
                        new State { StateName = "INSPECTION_1" },
                        new State { StateName = "INSPECTION_1_SCRAP" },
                        new State { StateName = "QUEUE_PAINT" },
                        new State { StateName = "PAINT" },
                        new State { StateName = "QUEUE_INSPECTION_2" },
                        new State { StateName = "INSPECTION_2" },
                        new State { StateName = "INSPECTION_2_REWORK" },
                        new State { StateName = "INSPECTION_2_SCRAP" },
                        new State { StateName = "QUEUE_ASSEMBLY" },
                        new State { StateName = "ASSEMBLY" },
                        new State { StateName = "QUEUE_INSPECTION_3" },
                        new State { StateName = "INSPECTION_3" },
                        new State { StateName = "INSPECTION_3_REWORK" },
                        new State { StateName = "INSPECTION_3_SCRAP" },
                        new State { StateName = "PACKAGE" },
                    };
                    context.States.AddRange(states);
                    #endregion
                    #region product
                    context.Products.Add(new Product { ProductId = 1, Description = "Original Sleeper" });
                    context.Products.Add(new Product { ProductId = 2, Description = "Black Beauty" });
                    context.Products.Add(new Product { ProductId = 3, Description = "Firecracker" });
                    context.Products.Add(new Product { ProductId = 4, Description = "Lemon Yellow" });
                    context.Products.Add(new Product { ProductId = 5, Description = "Midnight Blue" });
                    context.Products.Add(new Product { ProductId = 6, Description = "Screaming Orange" });
                    context.Products.Add(new Product { ProductId = 7, Description = "Gold glitter" });
                    context.Products.Add(new Product { ProductId = 8, Description = "White Lightening" });
                    #endregion
                    context.SaveChanges();
                }
                Console.WriteLine("Data base is created!");
            }
        }

        public bool CheckDb()
        {

            string connection = ConfigurationManager.ConnectionStrings["YoYo"].ConnectionString;
            string cmdText = "SELECT * FROM master.dbo.sysdatabases WHERE name ='YoYo'";
            bool isExist = false;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        isExist = reader.HasRows;
                    }
                }
                con.Close();
            }
            return isExist;
        }
        public void InsertInto(string message)
        {
            string[] parsed = message.Split(','); ;
            string areaId = parsed[0];
            string serialId = parsed[1];
            string lineId = parsed[2];
            string stateName = parsed[3];
            string reason = parsed[4];
            DateTime date = DateTime.Parse(parsed[5]);
            int productId = Int32.Parse(parsed[6]);

            using (var context = new YoYoDbContext())
            {

                if(!context.Serial.Any(o=>o.SerialId == serialId))
                {
                    context.Serial.Add(new Serial { SerialId = serialId, LineId = lineId, ProductId = productId });
                    if(!context.Lines.Any(o => o.LineId == lineId))
                    {
                        context.Lines.Add(new Line { LineId = lineId, WorkAreaId = areaId });
                        if (!context.WorkAreas.Any(o => o.WorkAreaId == areaId))
                        {
                            context.WorkAreas.Add(new WorkArea { WorkAreaId = areaId });
                        }
                    }
                    context.SerialProduct.Add(new SerialProduct { SerialId = serialId, ProductId = productId });
                }
                context.SerialState.Add(new SerialState { SerialId = serialId, StateName = stateName, Reason = reason, Date = date });
                
                context.SaveChanges();
            }
        }
    }
}
