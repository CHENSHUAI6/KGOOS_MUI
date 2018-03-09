using KGOOS_MUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace KGOOS_MUI.Pages.Scan
{
    /// <summary>
    /// Interaction logic for Weight.xaml
    /// </summary>
    public partial class Weigh : UserControl
    {
        /// <summary>
        /// 无用，待删除
        /// </summary>
        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public bool IsMember { get; set; }
        }

        public Weigh()
        {
            InitializeComponent();

            //ObservableCollection<Customer> custdata = GetData();

            //Bind the DataGrid to the customer data
            //DG1.DataContext = custdata;
            List<AutoCompleteEntry> tlist = new List<AutoCompleteEntry>();
            tlist.Add(new AutoCompleteEntry("第九人民医院", null));
            tlist.Add(new AutoCompleteEntry("第八人民医院", null));
            tlist.Add(new AutoCompleteEntry("第七人民医院", null));
            tlist.Add(new AutoCompleteEntry("第五人民医院", null));
            this.TBName.AddItemSource(tlist);
            getTableData();
            //colorDG();
        }

        /// <summary>
        /// 无用，待删除
        /// </summary>
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

        /// <summary>
        /// datagrid赋值
        /// </summary>
        public void getTableData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("IsMember", typeof(object)));
            dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dt.Columns.Add(new DataColumn("LastName", typeof(string)));
            for (int i = 0; i < 6; i++)
            {
                DataRow dr = dt.NewRow();
                if (i == 3)
                {
                    dr["IsMember"] = true;
                    dr["FirstName"] = DBNull.Value;
                    dr["LastName"] = DBNull.Value;
                    dt.Rows.Add(dr);
                }
                else
                {
                    dr["IsMember"] = false;
                    dr["FirstName"] = i;
                    dr["LastName"] = "tom" + i.ToString();
                    dt.Rows.Add(dr);
                }
            }
            this.DG1.CanUserAddRows = false;
            this.DG1.ItemsSource = dt.DefaultView;
        }

        /// <summary>
        /// datagrid赋值(无用，待删除)
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<Customer> GetData()
        {
            var customers = new ObservableCollection<Customer>();
            customers.Add(new Customer { FirstName = "Orlando", LastName = "Gee", Email = "122", IsMember = true });
            customers.Add(new Customer { FirstName = "Keith", LastName = "Harris", Email = "dsm", IsMember = true });
            customers.Add(new Customer { FirstName = "Donna", LastName = "Carreras", Email = "works.com", IsMember = false });
            customers.Add(new Customer { FirstName = "Janet", LastName = "Gates", Email = "e-w.com", IsMember = true });
            return customers;
        }

        /// <summary>
        /// 表格默认加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DG1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
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

        /// <summary>
        /// 运单编号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBtranId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (RBimportWeigh.IsChecked == true)
                {
                    this.TBweigh.Focus();
                }
                else
                {
                    this.TBName.Focus();
                }
            }
        }

        /// <summary>
        /// 重量回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBweigh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.TBName.Focus();
            }
        }

        /// <summary>
        /// 限制输入字符为文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Num_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");
            e.Handled = re.IsMatch(e.Text);
        }

        /// <summary>
        /// 屏蔽中文输入和非法字符粘贴输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Num_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TextChange[] change = new TextChange[e.Changes.Count];
            e.Changes.CopyTo(change, 0);

            int offset = change[0].Offset;
            if (change[0].AddedLength > 0)
            {
                double num = 0;
                if (!Double.TryParse(textBox.Text, out num))
                {
                    textBox.Text = textBox.Text.Remove(offset, change[0].AddedLength);
                    textBox.Select(offset, 0);
                }
            }
        }

        /// <summary>
        /// 旺旺名回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.TBNote.Focus();

            }
        }


    }
}
