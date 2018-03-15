using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KGOOS_MUI.Pages.Tran
{
    /// <summary>
    /// Interaction logic for Arrive.xaml
    /// </summary>
    public partial class Arrive : UserControl
    {
        public Arrive()
        {
            InitializeComponent();
        }

        private void DG1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //var drv = e.Row.Item as DataRowView;
            //switch (drv["FirstName"].ToString())
            //{
            //    case "1": e.Row.Background = new SolidColorBrush(Colors.Green);
            //        break;
            //    case "2": e.Row.Background = new SolidColorBrush(Colors.Yellow);
            //        break;
            //    case "3": e.Row.Background = new SolidColorBrush(Colors.CadetBlue);
            //        break;


            //}
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            //getTableData();
        }

        private void CBID_Checked(object sender, RoutedEventArgs e)
        {
            TBStartTime.Enabled = false;
            TBEndTime.Enabled = false;
        }

        private void CBID_Unchecked(object sender, RoutedEventArgs e)
        {
            TBStartTime.Enabled = true;
            TBEndTime.Enabled = true;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TBID.Clear();
        }

        private void BtnPack_Click(object sender, RoutedEventArgs e)
        {
            UpWindow uw = new UpWindow();
            uw.Show();
        }
    }
}
