using KGOOS_MUI.Common;
using KGOOS_MUI.Model;
using System;
using System.Collections.Generic;
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

namespace KGOOS_MUI.Pages.Tran
{
    /// <summary>
    /// Interaction logic for ConTran.xaml
    /// </summary>
    public partial class ConTran : UserControl
    {
        private List<PackModel> _PackList;
        public List<PackModel> PackList
        {
            get { return _PackList; }
            set
            {
                _PackList = value;
            }
        }

        public ConTran()
        {
            InitializeComponent();
            TBStartTime.Text = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd HH:mm:ss");
        }

        public void getTableData()
        {
            string sql = "";
            DataSet ds = new DataSet();

            string str = TBID.Text;
            string[] sArrayID = Regex.Split(str, "\r\n", RegexOptions.IgnoreCase);
            string starTime = TBStartTime.Text;
            string endTime = TBEndTime.Text;

            str = BaseClass.getSqlValue(sArrayID);

            str = BaseClass.getSqlValue(sArrayID);

            sql = "select top 300 * from T_Pack as t1 ";
            ds = DBClass.execQuery(sql);

            PackList = new List<PackModel>();

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    

                    PackList.Add(new PackModel()
                    {
                        paid = false,
                        informPay = false,
                        processed = false,
                        read = false,
                        pack_state = ds.Tables[0].Rows[i]["pack_state"].ToString(),
                        pack_user_id = ds.Tables[0].Rows[i]["pack_user_id"].ToString(),
                        pack_user_name = ds.Tables[0].Rows[i]["pack_user_name"].ToString(),
                    });
                }
            }

            this.DGBasic.CanUserAddRows = false;
            this.DGBasic.ItemsSource = PackList;


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

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            getTableData();
        }
    }
}
