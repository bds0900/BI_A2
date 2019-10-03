using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace A2_2
{
    class DAL
    {
        DbSet<SerialState> SerialState = null;
        public DAL()
        {
            if (Database.Exists(ConfigurationManager.ConnectionStrings["YoYo"].ConnectionString))
            {
                MessageBox.Show("exist");
                using (var context = new YoYoDbContext())
                {
                    SerialState = context.SerialState;
                }
            }
            else
            {
                throw new Exception("YoYo is not exist, try agian ");
            }
        }
        public void Update()
        {
            using (var context = new YoYoDbContext())
            {
                SerialState = context.SerialState;
                              
            }

        }
        public int GetPartTotalMod()
        {
            int result = 0;
            using (var context = new YoYoDbContext())
            {
                result = (from st in context.Serial
                          select st).Count();
            }
            return result;
        }
        public int GetPartSucMod()
        {
            int result = 0;
            using (var context = new YoYoDbContext())
            {
                result = (from st in context.SerialState
                          where st.StateName == "QUEUE_PAINT"
                          select st).Count();
            }
            result = (from st in SerialState
                      where st.StateName == "QUEUE_PAINT"
                      select st).Count();
            return result;
        }
        public float GetYieldMod()
        {
            float result = GetPartSucMod() / GetPartTotalMod();

            return result;
        }
        public int GetTotalSucPainted()
        {
            int result = 0;
            using (var context = new YoYoDbContext())
            {
                result = (from st in context.SerialState
                          where st.StateName == "PAINT"
                          select st).Count();
            }
            result = (from st in SerialState
                      where st.StateName == "PAINT"
                      select st).Count();
            return result;
        }
        public float GetYieldPoint()
        {
            float result = GetTotalSucPainted()/ GetPartSucMod();

            return result;
        }
        public int GetTotalSucAsmbld()
        {
            int result = 0;
            using (var context = new YoYoDbContext())
            {
                result = (from st in context.SerialState
                          where st.StateName == "QUEUE_ASSEMBLY"
                          select st).Count();
            }
            result = (from st in SerialState
                      where st.StateName == "QUEUE_ASSEMBLY"
                      select st).Count();
            return result;
        }
        public float GetYieldAsmbl()
        {
            float result = GetTotalSucAsmbld()/ GetTotalSucPainted();
            return result;
        }
        public int GetTotalPakgd()
        {
            int result = 0;
            using (var context = new YoYoDbContext())
            {
                
                result= (from st in context.SerialState
                         where st.StateName == "PACKAGE"
                         select st).Count();
                //var student = query.FirstOrDefault<SerialState>();
            }
            result = (from st in SerialState
                      where st.StateName == "PACKAGE"
                      select st).Count();
            return result;
        }
        public float GetTotalYield()
        {
            float result = GetTotalPakgd()/ GetPartTotalMod();

            return result;
        }
    }
}
