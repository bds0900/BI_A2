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

        //DbSet<SerialState> SerialState = null;

        private float PartTotalMod { get; set; }
        private float PartSucMod { get; set; }
        private float YieldMod { get; set; }
        private float TotalSucPainted { get; set; }
        private float YieldPaint { get; set; }
        private float TotalSucAsmbld { get; set; }
        private float YieldAsmbl { get; set; }
        private float TotalPakgd { get; set; }
        private float TotalYield { get; set; }
        public DAL()
        {
            if (Database.Exists(ConfigurationManager.ConnectionStrings["YoYo"].ConnectionString))
            {
                MessageBox.Show("exist");
                Update();
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
                PartTotalMod = (from st in context.Serial
                                select st).Count();

                PartSucMod = (from st in context.SerialState
                              where st.StateName == "QUEUE_PAINT"
                              select st).Count();
                YieldMod = PartSucMod / PartTotalMod;

                TotalSucPainted = (from st in context.SerialState
                                   where st.StateName == "QUEUE_ASSEMBLY"
                                   select st).Count();
                YieldPaint = TotalSucPainted / PartSucMod;

                TotalSucAsmbld = (from st in context.SerialState
                                  where st.StateName == "PACKAGE"
                                  select st).Count();

                YieldAsmbl = TotalSucAsmbld / TotalSucPainted;

                TotalPakgd = (from st in context.SerialState
                              where st.StateName == "PACKAGE"
                              select st).Count();
                TotalYield = TotalPakgd / PartTotalMod;
            }


        }
        public float GetPartTotalMod()
        {
            return PartTotalMod;
        }
        public float GetPartSucMod()
        {
            return PartSucMod;
        }
        public float GetYieldMod()
        {
            return YieldMod;
        }
        public float GetTotalSucPainted()
        {
            return TotalSucPainted;
        }
        public float GetYieldPaint()
        {
            return YieldPaint;
        }
        public float GetTotalSucAsmbld()
        {
            return TotalSucAsmbld;
        }
        public float GetYieldAsmbl()
        {
            return YieldAsmbl;
        }
        public float GetTotalPakgd()
        {
           
            return TotalPakgd;
        }
        public float GetTotalYield()
        {
            return TotalYield;
        }
    }
}
