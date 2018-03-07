using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ConTran.xaml
    /// </summary>
    public partial class ConTran : UserControl
    {
        public ConTran()
        {
            InitializeComponent();
        }
        public void colorDG()
        {

            for (int i = 0; i < this.DG1.Items.Count; i++)
            {
                DataRowView drv = DG1.Items[i] as DataRowView;
                DataGridRow row = (DataGridRow)this.DG1.ItemContainerGenerator.ContainerFromIndex(i);
                if (i == 2)
                {
                    row.Background = new SolidColorBrush(Colors.Blue);
                }
            }
        }
        public void getData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("FirstName", typeof(int)));
            dt.Columns.Add(new DataColumn("LastName", typeof(string)));

            for (int i = 0; i < 6; i++)
            {
                DataRow dr = dt.NewRow();
                if (i == 3)
                {
                    dr["FirstName"] = DBNull.Value;
                    dr["LastName"] = DBNull.Value;
                    dt.Rows.Add(dr);
                }
                else
                {
                    dr["FirstName"] = i;
                    dr["LastName"] = "tom" + i.ToString();
                    dt.Rows.Add(dr);
                }
            }

            this.DG1.CanUserAddRows = false;
            this.DG1.ItemsSource = dt.DefaultView;
        }

        //datagrid赋值

        private void DG1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var drv = e.Row.Item as DataRowView;
            switch (drv["FirstName"].ToString())
            {
                case "1": e.Row.Background = new SolidColorBrush(Colors.Green);
                    break;
                case "2": e.Row.Background = new SolidColorBrush(Colors.Yellow);
                    break;
                case "3": e.Row.Background = new SolidColorBrush(Colors.CadetBlue);
                    break;


            }
        }
    }
}
