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
using System.Windows.Threading;

namespace A2_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProductInfo pfo = new ProductInfo();
        private DAL dal = new DAL();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
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
            
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
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
            
            pfo.part_total_mod = dal.GetPartTotalMod();
            pfo.part_suc_mod = dal.GetPartSucMod();
            pfo.total_pakgd = dal.GetTotalPakgd(); 
            pfo.total_yield = dal.GetTotalYield();
            pfo.yield_asmbl = dal.GetYieldAsmbl();
            pfo.yield_mod = dal.GetYieldMod();
            pfo.yield_paint = dal.GetYieldPaint();
            pfo.total_suc_asmbld = dal.GetTotalSucAsmbld();
            pfo.total_suc_painted = dal.GetTotalSucPainted();

            tlt_mod.DataContext = pfo;
            suc_mod.DataContext = pfo;
            yld_mod.DataContext = pfo;
            tlt_suc_pntd.DataContext = pfo;
            tlt_suc_asmbd.DataContext = pfo;
            yld_pnt.DataContext = pfo;
            yld_asmb.DataContext = pfo;
            tlt_pakd.DataContext = pfo;
            tlt_yld.DataContext = pfo;

            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            dal.Update();
            
            tlt_mod.Dispatcher.BeginInvoke(new Action(delegate { tlt_mod.Text = dal.GetPartTotalMod().ToString(); }));
            suc_mod.Dispatcher.BeginInvoke(new Action(delegate { suc_mod.Text = dal.GetPartSucMod().ToString(); }));
            tlt_pakd.Dispatcher.BeginInvoke(new Action(delegate { tlt_pakd.Text = dal.GetTotalPakgd().ToString(); }));
            tlt_yld.Dispatcher.BeginInvoke(new Action(delegate { tlt_yld.Text = dal.GetTotalYield().ToString("P", CultureInfo.InvariantCulture); }));
            yld_asmb.Dispatcher.BeginInvoke(new Action(delegate { yld_asmb.Text = dal.GetYieldAsmbl().ToString("P", CultureInfo.InvariantCulture);  }));
            yld_mod.Dispatcher.BeginInvoke(new Action(delegate { yld_mod.Text = dal.GetYieldMod().ToString("P", CultureInfo.InvariantCulture); }));
            yld_pnt.Dispatcher.BeginInvoke(new Action(delegate { yld_pnt.Text = dal.GetYieldPaint().ToString("P", CultureInfo.InvariantCulture); }));
            tlt_suc_asmbd.Dispatcher.BeginInvoke(new Action(delegate { tlt_suc_asmbd.Text = dal.GetTotalSucAsmbld().ToString(); }));
            tlt_suc_pntd.Dispatcher.BeginInvoke(new Action(delegate { tlt_suc_pntd.Text = dal.GetTotalSucPainted().ToString(); }));
            //Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { this.UpdateLayout(); }));
        }

    }
}
