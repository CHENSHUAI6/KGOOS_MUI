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
    /// Interaction logic for ConTranOld.xaml
    /// </summary>
    public partial class ConTranOld : UserControl
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

        public ConTranOld()
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

            sql = "select top 300 * from T_Order as t1 " +
                "LEFT JOIN T_User_Adress as t2 on t2.id = t1.user_adress_id " +
                "LEFT JOIN T_con_carrier as t3 on t3.id = t1.con_carrier_id " +
                "LEFT JOIN T_Type as t4 on t4.id = t1.fast_type ";

            sql = "(" + sql + ") union all (" + sql + ")";

            ds = DBClass.execQuery(sql);

            PackList = new List<PackModel>();

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    bool paid = false;
                    string pack_state = "", order_put_type = "", con_name = "", destination = "";
                    if (ds.Tables[0].Rows[i]["is_pay"].ToString() == "Y")
                    {
                        paid = true;
                    }
                    if (ds.Tables[0].Rows[i]["is_shipments"].ToString() == "Y")
                    {
                        pack_state = "已发货";
                    }
                    else
                    {
                        pack_state = "已申请";
                    }
                    if (ds.Tables[0].Rows[i]["con_carrier_id"].ToString().Length > 0)
                    {
                        order_put_type = "网页申请";
                        con_name = ds.Tables[0].Rows[i]["name"].ToString();
                        destination = ds.Tables[0].Rows[i]["destination"].ToString();
                    }
                    else
                    {
                        order_put_type = "后台代打包";
                        con_name = ds.Tables[0].Rows[i]["order_con"].ToString();
                        destination = ds.Tables[0].Rows[i]["order_destination"].ToString();
                    }

                    PackList.Add(new PackModel()
                    {
                        //表一
                        paid = paid,
                        informPay = false,
                        processed = false,
                        read = false,
                        pack_state = pack_state,
                        pack_user_id = ds.Tables[0].Rows[i]["user_id"].ToString(),
                        pack_user_name = ds.Tables[0].Rows[i]["user_tb"].ToString(),
                        //表二
                        order_id = ds.Tables[0].Rows[i]["id"].ToString(),
                        order_date = ds.Tables[0].Rows[i]["order_time"].ToString(),
                        order_con_id = ds.Tables[0].Rows[i]["Con_Express_Id"].ToString(),
                        order_con = con_name,
                        order_destrination = destination,
                        order_note = ds.Tables[0].Rows[i]["order_comment"].ToString(),
                        order_put_type = order_put_type,
                        pack_type = ds.Tables[0].Rows[i]["name1"].ToString(),
                    });
                }
            }

            this.DGBasic.CanUserAddRows = false;
            this.DGBasic.ItemsSource = PackList;
            this.DGOrder.CanUserAddRows = false;
            this.DGOrder.ItemsSource = PackList;

            this.DGBasic.FrozenColumnCount = 2;
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

        private void DGBasic_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int a = this.DGBasic.SelectedIndex;
                SetSelectedRow(this.DGOrder, a);


                // 获取要定位之前 ScrollViewer 目前的滚动位置
                //var currentScrollPosition = ScrollViewer.VerticalOffset;
                //var point = new Point(0, currentScrollPosition);

                //// 计算出目标位置并滚动
                //var targetPosition = TargetControl.TransformToVisual(ScrollViewer).Transform(point);
                //ScrollViewer.ScrollToVerticalOffset(targetPosition.Y);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        public static void SetSelectedRow(DataGrid grid, int index)
        {
            DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                grid.UpdateLayout();
                grid.ScrollIntoView(grid.Items[index]);
                row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
            }
            row.IsSelected = true;
        }
    }
}
