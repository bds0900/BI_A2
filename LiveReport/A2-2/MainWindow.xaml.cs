using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using DevExpress.Xpf.Charts;

namespace A2_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProductInfo pfo = new ProductInfo();
        public MainWindow()
        {
            InitializeComponent();

            //SqlConnection conn = new SqlConnection("A2_2.Properties.Settings.NorthwindConnectionString");
            //conn.Open();
            //String sql = "select CategoryName from Categories";
            //SqlDataAdapter myda = new SqlDataAdapter(sql, conn);

            //DataSet ds = new DataSet();
            //myda.Fill(ds);
            //lbx_product.ItemsSource = ds.Tables[0].DefaultView;

        }

        private void LbxProChange()
        {
            String pro_selected = lbx_product.SelectedItem.ToString();

        }

        private void DrawChart()
        {
            ParetoChart.Series.Clear();
      
        }


        private void Tlt_mod_Loaded(object sender, RoutedEventArgs e)
        {
            pfo.part_total_mod = 100;
            pfo.part_suc_mod = 98;
            pfo.total_pakgd = 89;
            pfo.total_yield = 34;
            pfo.yield_asmbl = 56;
            pfo.yield_mod = 88;
            pfo.yield_point = 45;
            pfo.total_suc_asmbld = 77;
            pfo.total_suc_painted = 87;

            tlt_mod.DataContext = pfo;
            suc_mod.DataContext = pfo;
            yld_mod.DataContext = pfo;
            tlt_suc_pntd.DataContext = pfo;
            suc_asmbd.DataContext = pfo;
            yld_pnt.DataContext = pfo;
            yld_asmb.DataContext = pfo;
            tlt_pakd.DataContext = pfo;
            tlt_yld.DataContext = pfo;
        }

      
    }
}
