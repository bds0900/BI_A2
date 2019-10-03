using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_2
{
    class ProductInfo
    {
        public int part_total_mod { get; set; }
        public int part_suc_mod { get; set; }
        public float yield_mod { get; set; }
        public int total_suc_painted { get; set; }
        public float yield_point { get; set; }
        public int total_suc_asmbld { get; set; }
        public float yield_asmbl { get; set; }
        public int total_pakgd { get; set; }
        public float total_yield { get; set; }
    }
}
