using FastReport;
using KGOOS_MUI.Common;
using KGOOS_MUI.Model;
using KGOOS_MUI.Pages.Scan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        public int affirm_num = 0;
        public int all_num = 0;
        private string staff_name = "";
        private string staff_region = "";
        private string rb_check_name = "";

        FastReport.Preview.PreviewControl prew = new FastReport.Preview.PreviewControl();
        Report report = new Report();

        //private List<PackModel> _PackList;
        //public List<PackModel> PackList
        //{
        //    get { return _PackList; }
        //    set
        //    {
        //        _PackList = value;
        //    }
        //}

        private DataTable TableData = new DataTable();

        public ConTran()
        {
            InitializeComponent();
            initialize();
        }

        /// <summary>
        /// 自定义初始化函数
        /// </summary>
        public void initialize()
        {
            TBStartTime.Text = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd HH:mm:ss");

            if (Application.Current.Properties["name"] != null)
            {
                staff_name = Application.Current.Properties["name"].ToString();
            }
            else
            {
                staff_name = "chy";
            }
            if (Application.Current.Properties["region"] != null)
            {
                staff_region = Application.Current.Properties["region"].ToString();
            }
            else
            {
                staff_region = "1";
            }
            getCon();
            getAutoCompleteTextBox();
        }

        public string getSql()
        {
            string sql = "";
            string str = TBID.Text;
            string[] sArrayID = Regex.Split(str, "\r\n", RegexOptions.IgnoreCase);
            string starTime = TBStartTime.Text;
            string endTime = TBEndTime.Text;

            string con = "", destination = "";

            str = BaseClass.getSqlValue(sArrayID);

            str = BaseClass.getSqlValue(sArrayID);

            sql = "select top 300 * from T_Order as t1 " +
                "LEFT JOIN T_User_Adress as t2 on t2.id = t1.user_adress_id " +
                "LEFT JOIN T_con_carrier as t3 on t3.id = t1.con_carrier_id " +
                "LEFT JOIN T_Type as t4 on t4.id = t1.fast_type " +
                "LEFT JOIN T_con_carrier as t5 " +
                "on t5.name = t1.order_con and t5.destination = t1.order_destination ";


            sql += " where (t3.Region_Id = '" + staff_region + "' or t1.order_region = '" + staff_region + "') ";

            if (CBID.IsChecked == true)
            {
                sql += "and t1.Con_Express_Id in " + str + " ";
            }
            else
            {
                sql += "and t1.order_time between '" + starTime + "' and '" + endTime + "'";
            }

            con = CBCom.SelectedValue.ToString();
            destination = CBDestination.SelectedValue.ToString();

            if (con != "0")
            {
                sql += " and t3.name = '" + con + "' ";
            }

            if (destination != "0")
            {
                sql += " and t3.destination = '" + destination + "' ";
            }

            if (TBUser_Name != null && TBUser_Name.Text != "")
            {
                string name = TBUser_Name.Text;
                sql += " and t1.user_tb = '" + name + "' ";
            }

            if (RB_Apply.IsChecked == true)
            {
                sql += " and t1.is_shipments is null ";
            }

            if (RB_Pack.IsChecked == true)
            {
                sql += " and t1.is_shipments = 'D' ";
            }

            if (RB_Deliver.IsChecked == true)
            {
                sql += " and t1.is_shipments = 'Y' ";
            }

            //if (TBPlant != null && TBPlant.Text != "")
            //{
            //    string plant = TBPlant.Text;
            //    sql += " and t3.Region_Id = '" + plant + "' ";
            //}

            //if (TBName != null && TBName.Text != "")
            //{
            //    string name = TBName.Text;
            //    sql += " and t1.Weight_UserName = '" + name + "' ";
            //}

            //if (TBlastStand != null && TBlastStand.Text != "")
            //{
            //    string lastStand = TBlastStand.Text;
            //    sql += " and t1.Weight_Last = '" + lastStand + "' ";
            //}

            //string type = TBType.Text;

            sql += " and (t1.order_is_show <> 'N' or t1.order_is_show is null) ";
            


            sql += " order by t1.order_time desc";

            return sql;
        }

        public void getTableData()
        {
            string sql = "";
            DataSet ds = new DataSet();

            sql = getSql();
            ds = DBClass.execQuery(sql);

            DataTable dt = new DataTable();
            //表一

            dt.Columns.Add(new DataColumn("Select", typeof(bool)));
            dt.Columns.Add(new DataColumn("n_num", typeof(string)));
            dt.Columns.Add(new DataColumn("paid", typeof(bool)));
            dt.Columns.Add(new DataColumn("informPay", typeof(bool)));
            dt.Columns.Add(new DataColumn("processed", typeof(bool)));
            dt.Columns.Add(new DataColumn("read", typeof(bool)));
            dt.Columns.Add(new DataColumn("pack_state", typeof(string)));
            dt.Columns.Add(new DataColumn("pack_user_id", typeof(string)));
            dt.Columns.Add(new DataColumn("pack_user_name", typeof(string)));
            //表二
            dt.Columns.Add(new DataColumn("order_id", typeof(string)));
            dt.Columns.Add(new DataColumn("order_date", typeof(string)));
            dt.Columns.Add(new DataColumn("order_con_id", typeof(string)));
            dt.Columns.Add(new DataColumn("order_con", typeof(string)));
            dt.Columns.Add(new DataColumn("order_destrination", typeof(string)));
            dt.Columns.Add(new DataColumn("order_coupon", typeof(string)));
            dt.Columns.Add(new DataColumn("order_support", typeof(string)));
            dt.Columns.Add(new DataColumn("order_tax", typeof(string)));
            dt.Columns.Add(new DataColumn("order_integral", typeof(string)));
            dt.Columns.Add(new DataColumn("order_kb", typeof(string)));
            dt.Columns.Add(new DataColumn("order_note", typeof(string)));
            dt.Columns.Add(new DataColumn("order_put_type", typeof(string)));
            dt.Columns.Add(new DataColumn("pack_type", typeof(string)));

            //表三
            dt.Columns.Add(new DataColumn("order_person", typeof(string)));
            dt.Columns.Add(new DataColumn("order_phone", typeof(string)));
            dt.Columns.Add(new DataColumn("order_adress", typeof(string)));
            dt.Columns.Add(new DataColumn("order_company", typeof(string)));
            dt.Columns.Add(new DataColumn("order_zhou", typeof(string)));

            //表四
            dt.Columns.Add(new DataColumn("order_thing", typeof(string)));
            dt.Columns.Add(new DataColumn("order_money", typeof(string)));
            dt.Columns.Add(new DataColumn("order_china", typeof(string)));
            dt.Columns.Add(new DataColumn("order_idcard", typeof(string)));
            dt.Columns.Add(new DataColumn("order_num", typeof(string)));
            dt.Columns.Add(new DataColumn("order_unit", typeof(string)));

            //表五
            dt.Columns.Add(new DataColumn("pack_staff", typeof(string)));
            dt.Columns.Add(new DataColumn("pack_now_helf", typeof(string)));
            dt.Columns.Add(new DataColumn("pack_note", typeof(string)));
            dt.Columns.Add(new DataColumn("pack_scan", typeof(string)));
            dt.Columns.Add(new DataColumn("pack_time", typeof(string)));
            dt.Columns.Add(new DataColumn("pack_num", typeof(string)));
            dt.Columns.Add(new DataColumn("pack_font_helf", typeof(string)));
            dt.Columns.Add(new DataColumn("pack_font_freight", typeof(string)));
            dt.Columns.Add(new DataColumn("pack_real_company", typeof(string)));

            //表六
            dt.Columns.Add(new DataColumn("pack_now_feright", typeof(string)));
                    //<DataGridTextColumn Header="优惠券号" Binding="{Binding LastName}" />
                    //<DataGridTextColumn Header="预付款"/>
                    //<DataGridTextColumn Header="付款时间"/>
                    //<DataGridTextColumn Header="到付款"/>
                    //<DataGridTextColumn Header="货款"/>

            //其他辅助
            dt.Columns.Add(new DataColumn("is_shipments", typeof(string)));

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    bool paid = false;
                    string pack_state = "", order_put_type = "", con_name = "", destination = "";
                    string order_person = "", order_phone = "", order_adress = "";
                    string pack_real_company = "";
                    string order_coupon = "0", order_support = "0", order_tax = "0",
                    order_integral = "0", order_kb = "0";
                    string pack_now_feright = "";
                    string is_shipments = "";
                    is_shipments = ds.Tables[0].Rows[i]["is_shipments"].ToString();
                    if (is_shipments == "Y")
                    {
                        pack_state = "已发件";
                    }
                    else if (is_shipments == "D")
                    {
                        pack_state = "已打包";
                    }
                    else
                    {
                        pack_state = "已申请";
                    }

                    if (ds.Tables[0].Rows[i]["is_pay"].ToString() == "Y")
                    {
                        paid = true;
                        pack_state = "已付款";
                    }

                    if (is_shipments == "D")
                    {
                        pack_state = "已打包";
                    }

                    if (ds.Tables[0].Rows[i]["con_carrier_id"].ToString().Length > 0)
                    {
                        order_put_type = "网页申请";
                        con_name = ds.Tables[0].Rows[i]["name"].ToString();
                        destination = ds.Tables[0].Rows[i]["destination"].ToString();

                       
                        if (ds.Tables[0].Rows[i]["order_name"].ToString().Length > 0)
                        {
                            order_person = ds.Tables[0].Rows[i]["order_name"].ToString();
                        }
                        else
                        {
                            order_person = ds.Tables[0].Rows[i]["adress_name"].ToString();
                        }
                        
                        if (ds.Tables[0].Rows[i]["order_phone"].ToString().Length > 0)
                        {
                            order_phone = ds.Tables[0].Rows[i]["order_phone"].ToString();
                        }
                        //else if (ds.Tables[0].Rows[i]["adress_phone"].ToString().Length > 0)
                        //{
                        //    order_phone = ds.Tables[0].Rows[i]["adress_phone"].ToString();
                        //}
                        else
                        {
                            order_phone = ds.Tables[0].Rows[i]["adress_phone"].ToString() + 
                                "-" + ds.Tables[0].Rows[i]["adress_tel"].ToString();
                        }

                        if (ds.Tables[0].Rows[i]["order_adress"].ToString().Length > 0)
                        {
                            order_adress = ds.Tables[0].Rows[i]["order_adress"].ToString();
                        }
                        else
                        {
                            order_adress = ds.Tables[0].Rows[i]["adress_region"].ToString() + "-" +
                                    ds.Tables[0].Rows[i]["adress_city"].ToString() + "-" +
                                    ds.Tables[0].Rows[i]["adress_other"].ToString() + "-" +
                                    ds.Tables[0].Rows[i]["adress_datail"].ToString();
                        }                        

                        pack_real_company = ds.Tables[0].Rows[i]["con_name"].ToString();
                    }
                    else
                    {
                        order_put_type = "后台代打包";
                        con_name = ds.Tables[0].Rows[i]["order_con"].ToString();
                        destination = ds.Tables[0].Rows[i]["order_destination"].ToString();
                        order_person = ds.Tables[0].Rows[i]["order_name"].ToString();
                        order_phone = ds.Tables[0].Rows[i]["order_phone"].ToString();
                        order_adress = ds.Tables[0].Rows[i]["order_adress"].ToString();
                        pack_real_company = ds.Tables[0].Rows[i]["con_name1"].ToString();

                    }
                    if (ds.Tables[0].Rows[i]["order_coupon"].ToString().Length > 0)
                    {
                        order_coupon = ds.Tables[0].Rows[i]["order_coupon"].ToString();
                    }
                    if (ds.Tables[0].Rows[i]["order_support"].ToString().Length > 0)
                    {
                        order_support = ds.Tables[0].Rows[i]["order_support"].ToString();
                    }
                    if (ds.Tables[0].Rows[i]["order_tax"].ToString().Length > 0)
                    {
                        order_tax = ds.Tables[0].Rows[i]["order_tax"].ToString();
                    }
                    if (ds.Tables[0].Rows[i]["order_integral"].ToString().Length > 0)
                    {
                        order_integral = ds.Tables[0].Rows[i]["order_integral"].ToString();
                    }
                    if (ds.Tables[0].Rows[i]["order_kb"].ToString().Length > 0)
                    {
                        order_kb = ds.Tables[0].Rows[i]["order_kb"].ToString();
                    }
                    if (ds.Tables[0].Rows[i]["pack_now_feright"].ToString().Length > 0)
                    {
                        pack_now_feright = ds.Tables[0].Rows[i]["pack_now_feright"].ToString();
                    }
                    

                    #region PackList
                    //PackList.Add(new PackModel()
                    //{
                    //    //表一
                    //    paid = paid,
                    //    informPay = false,
                    //    processed = false,
                    //    read = false,
                    //    pack_state = pack_state,
                    //    pack_user_id = ds.Tables[0].Rows[i]["user_id"].ToString(),
                    //    pack_user_name = ds.Tables[0].Rows[i]["user_tb"].ToString(),
                    //    //表二
                    //    order_id = ds.Tables[0].Rows[i]["id"].ToString(),
                    //    order_date = ds.Tables[0].Rows[i]["order_time"].ToString(),
                    //    order_con_id = ds.Tables[0].Rows[i]["Con_Express_Id"].ToString(),
                    //    order_con = con_name,
                    //    order_destrination = destination,
                    //    order_note = ds.Tables[0].Rows[i]["order_comment"].ToString(),
                    //    order_put_type = order_put_type,
                    //    pack_type = ds.Tables[0].Rows[i]["name1"].ToString(),
                    //    //表三
                    //    order_person = order_person,
                    //    order_phone = order_phone,
                    //    order_adress = order_adress,
                    //    order_company = "",
                    //    order_zhou = "",
                    //    //表四
                    //    order_thing = ds.Tables[0].Rows[i]["order_goods"].ToString(),
                    //    order_money = ds.Tables[0].Rows[i]["order_money"].ToString(),
                    //    order_china = "",
                    //    order_idcard = "",
                    //    order_num = ds.Tables[0].Rows[i]["order_num"].ToString(),
                    //    order_unit = "",
                    //    //表五
                    //    pack_staff = ds.Tables[0].Rows[i]["pack_staff"].ToString(),
                    //    pack_now_helf = ds.Tables[0].Rows[i]["pack_now_helf"].ToString(),
                    //    pack_note = ds.Tables[0].Rows[i]["pack_note"].ToString(),
                    //    pack_scan = ds.Tables[0].Rows[i]["pack_scan"].ToString(),
                    //    pack_time = ds.Tables[0].Rows[i]["pack_time"].ToString(),
                    //    pack_num = ds.Tables[0].Rows[i]["pack_num"].ToString(),
                    //    pack_font_helf = ds.Tables[0].Rows[i]["order_helf"].ToString(),
                    //    pack_font_freight = ds.Tables[0].Rows[i]["Freight"].ToString(),
                    //    pack_real_company = pack_real_company,
                    //});
                    #endregion

                    DataRow dr = dt.NewRow();
                    //表一
                    dr["Select"] = false;
                    dr["n_num"] = i + 1;
                    dr["paid"] = paid;
                    dr["informPay"] = false;
                    dr["processed"] = false;
                    dr["read"] = false;
                    dr["pack_state"] = pack_state;
                    dr["pack_user_id"] = ds.Tables[0].Rows[i]["user_id"].ToString();
                    dr["pack_user_name"] = ds.Tables[0].Rows[i]["user_tb"].ToString();
                    //表二
                    dr["order_id"] = ds.Tables[0].Rows[i]["id"].ToString();
                    dr["order_date"] = ds.Tables[0].Rows[i]["order_time"].ToString();
                    dr["order_con_id"] = ds.Tables[0].Rows[i]["Con_Express_Id"].ToString();
                    dr["order_con"] = con_name;
                    dr["order_destrination"] = destination;
                    dr["order_coupon"] = order_coupon;
                    dr["order_support"] = order_support;
                    dr["order_tax"] = order_tax;
                    dr["order_integral"] = order_integral;
                    dr["order_kb"] = order_kb;
                    dr["order_note"] = ds.Tables[0].Rows[i]["order_comment"].ToString();
                    dr["order_put_type"] = order_put_type;
                    dr["pack_type"] = ds.Tables[0].Rows[i]["name1"].ToString();
                    //表三
                    dr["order_person"] = order_person;
                    dr["order_phone"] = order_phone;
                    dr["order_adress"] = order_adress;
                    dr["order_company"] = "";
                    dr["order_zhou"] = "";
                    //表四
                    dr["order_thing"] = ds.Tables[0].Rows[i]["order_goods"].ToString();
                    dr["order_money"] = ds.Tables[0].Rows[i]["order_money"].ToString();
                    dr["order_china"] = "";
                    dr["order_idcard"] = "";
                    dr["order_num"] = ds.Tables[0].Rows[i]["order_num"].ToString();
                    dr["order_unit"] = "";
                    //表五                   
                    dr["pack_staff"] = ds.Tables[0].Rows[i]["pack_staff"].ToString();
                    dr["pack_now_helf"] = ds.Tables[0].Rows[i]["pack_now_helf"].ToString();
                    dr["pack_note"] = ds.Tables[0].Rows[i]["pack_note"].ToString();
                    dr["pack_scan"] = ds.Tables[0].Rows[i]["pack_scan"].ToString();
                    dr["pack_time"] = ds.Tables[0].Rows[i]["pack_time"].ToString();
                    dr["pack_num"] = ds.Tables[0].Rows[i]["pack_num"].ToString();
                    dr["pack_font_helf"] = ds.Tables[0].Rows[i]["order_helf"].ToString();
                    dr["pack_font_freight"] = ds.Tables[0].Rows[i]["Freight"].ToString();
                    dr["pack_real_company"] = pack_real_company;
                    //表六
                    dr["pack_now_feright"] = pack_now_feright;
                    //其他辅助
                    dr["is_shipments"] = is_shipments;
                    dt.Rows.Add(dr);
                }
            }

            TableData = new DataTable();
            TableData = dt;

            ShowDG1();

            ////创建数据源、绑定数据源          
            //if (!Window.GetWindow(DG1).IsVisible)
            //{
            //    Window.GetWindow(DG1).Show();
            //}
            //DG1.UpdateLayout();

            //for (int i = 2; i < this.DG1.Items.Count; i++)
            //{
            //    DataGridRow row = (DataGridRow)this.DG1.ItemContainerGenerator.ContainerFromIndex(i);

            //    DataGridCellsPresenter presenter = BaseClass.GetVisualChild<DataGridCellsPresenter>(row);
            //    DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(4);

            //    string strCell = "";
            //    TextBlock tbStr = (TextBlock)cell.Content;
            //    strCell = tbStr.Text.ToString();

            //    switch (strCell)
            //    {
            //        case "已发件": row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9FF59F"));
            //            break;
            //        case "已打包": row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1FF83"));
            //            break;
            //        case "已付款": row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF85DB"));
            //            break;
            //    }
            //}

        }

        private void DG1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                e.Row.Header = e.Row.GetIndex() + 1;

                if (this.DG1.ItemsSource != null)
                {
                    var drv = e.Row.Item as DataRowView;
                    switch (drv["pack_state"].ToString())
                    {
                        case "已发件": e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9FF59F"));
                            break;
                        case "已打包": e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1FF83"));
                            break;
                        case "已申请": e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A8C2F7"));
                            break;
                        case "已付款": e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF85DB"));
                            break;
                    }
                }
                
            }
            catch (Exception e1) 
            {
                MessageBox.Show("系统错误：" + e1.Message);
            }
            
        }

        private void DGDown_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var drv = e.Row.Item as DataRowView;

            if (bool.Parse(drv["is_Affirm"].ToString()))
            {
                e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9FF59F"));
            }
        }

        public void getDataByOrderId(string order_id, string order_con)
        {
            string sql = "";
            sql = "select * from T_Weight as t1 where t1.Order_id = '" + order_id + "'";

            DataSet ds = new DataSet();
            ds = DBClass.execQuery(sql);

            affirm_num = 0;
            all_num = int.Parse(ds.Tables[0].Rows.Count.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                //表一
                dt.Columns.Add(new DataColumn("id", typeof(string)));
                dt.Columns.Add(new DataColumn("is_Affirm", typeof(bool)));
                dt.Columns.Add(new DataColumn("con_name", typeof(string)));
                dt.Columns.Add(new DataColumn("weight_con", typeof(string)));
                dt.Columns.Add(new DataColumn("num", typeof(string)));
                dt.Columns.Add(new DataColumn("helf", typeof(string)));
                dt.Columns.Add(new DataColumn("type", typeof(string)));
                dt.Columns.Add(new DataColumn("shelf", typeof(string)));
                dt.Columns.Add(new DataColumn("freight", typeof(string)));
                dt.Columns.Add(new DataColumn("comment", typeof(string)));
                dt.Columns.Add(new DataColumn("pack_type", typeof(string)));
                dt.Columns.Add(new DataColumn("weight_person", typeof(string)));
                dt.Columns.Add(new DataColumn("con_id", typeof(string)));
                dt.Columns.Add(new DataColumn("Weight_NoteStaff", typeof(string)));             
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    string pack_type = "";
                    bool is_Affirm = false;
                    if (ds.Tables[0].Rows[i]["Weight_Affirm"].ToString() == "Y")
                    {
                        is_Affirm = true;
                        affirm_num++;
                    }
                    if (ds.Tables[0].Rows[i]["Web_UserId"].ToString().Length > 0)
                    {
                        pack_type = "网站认领";
                    }
                    else
                    {
                        pack_type = "后台认领";
                    }

                    dr["id"] = (i + 1).ToString();
                    dr["is_Affirm"] = is_Affirm;
                    dr["con_name"] = order_con;
                    dr["weight_con"] = ds.Tables[0].Rows[i]["Weight_ConID"].ToString();
                    dr["num"] = ds.Tables[0].Rows[i]["Weight_Num"].ToString();
                    dr["helf"] = ds.Tables[0].Rows[i]["Weight_Helf"].ToString();
                    dr["type"] = "";
                    dr["shelf"] = ds.Tables[0].Rows[i]["Weight_Shelf"].ToString();
                    dr["freight"] = "";
                    dr["comment"] = ds.Tables[0].Rows[i]["Web_Note"].ToString(); ;
                    dr["pack_type"] = pack_type;
                    dr["weight_person"] = ds.Tables[0].Rows[i]["Weight_WorkderId"].ToString();
                    dr["con_id"] = "";
                    dr["Weight_NoteStaff"] = ds.Tables[0].Rows[i]["Weight_NoteStaff"].ToString();                   
                    dt.Rows.Add(dr);
                }

                this.DGDown.CanUserAddRows = false;
                //this.DG1.ItemsSource = PackList;
                this.DGDown.ItemsSource = dt.DefaultView;

                text_num_affirm.Text = affirm_num + @"/" + all_num;
            }
            else
            {
                text_num_affirm.Text = "0/0";
                this.DGDown.ItemsSource = null;
            }
        }     

        private void tb_con_affirm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    string weight_con = "";
                    weight_con = tb_con_affirm.Text;
                    string sql = "";
                    sql = "update T_Weight set Weight_Affirm = 'Y' where Weight_ConID = '" + weight_con + "'";
                    int n = DBClass.execUpdate(sql);
                    if (n > 0)
                    {
                        BaseClass.playOKSound();
                        tb_con_affirm.Clear();
                        var a = this.DG1.SelectedItem;
                        var b = a as DataRowView;
                        string order_id = b.Row["order_id"].ToString();
                        string order_con = b.Row["order_con"].ToString();
                        getDataByOrderId(order_id, order_con);
                    }
                    else
                    {
                        BaseClass.playErrorSound();
                    }

                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("系统错误：" + e1.Message);
            }
        }       

        private void DG1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down || e.Key == Key.Up)
            {
                getDetail();
            }

        }

        /// <summary>
        /// 获取下方表格详细信息
        /// </summary>
        public void getDetail()
        {
            affirm_num = 0;
            tb_con_affirm.Clear();

            if (this.DG1.SelectedItem != null)
            {
                var a = this.DG1.SelectedItem;
                var b = a as DataRowView;
                string order_id = b.Row["order_id"].ToString();
                string order_con_id = b.Row["order_con_id"].ToString();
                string order_num = b.Row["order_num"].ToString();
                string order_destrination = b.Row["order_destrination"].ToString();
                string pack_font_helf = b.Row["pack_font_helf"].ToString();
                string pack_type = b.Row["pack_type"].ToString();
                string pack_font_freight = b.Row["pack_font_freight"].ToString();

                string order_phone = b.Row["order_phone"].ToString();
                string order_person = b.Row["order_person"].ToString();
                string order_adress = b.Row["order_adress"].ToString();
                string order_note = b.Row["order_note"].ToString();

                string order_con = b.Row["order_con"].ToString();

                bool is_pay = bool.Parse(b.Row["paid"].ToString());

                string pack_staff = b.Row["pack_staff"].ToString();
                string pack_now_helf = b.Row["pack_now_helf"].ToString();
                string pack_now_feright = b.Row["pack_now_feright"].ToString();
                string pack_note = b.Row["pack_note"].ToString();
                string pack_num = b.Row["pack_num"].ToString();

                CB_IsPay.IsChecked = is_pay;

                TB_Order_Con_ID.Text = order_con_id;
                TB_Num.Text = order_num;
                TB_Destrination.Text = order_destrination;
                TB_Font_Helf.Text = pack_font_helf;

                //TB_Pack_Type.Text = pack_type;
                TB_Order_Id.Text = order_id;

                TB_Font_Freight.Text = pack_font_freight;

                TB_Phone.Text = order_phone;
                TB_Person.Text = order_person;
                TB_Adress.Text = order_adress;
                TB_Order_Note.Text = order_note;

                TB_PackPerson.Text = pack_staff;
                TB_PackLaterHelf.Text = pack_now_helf;
                TB_PackLaterFeright.Text = pack_now_feright;
                TB_PackComment.Text = pack_note;
                TB_Page_Num.Text = pack_num;

                getDataByOrderId(order_id, order_con);
            }          
        }

        /// <summary>
        /// 获取名称，目的地
        /// </summary>
        public void getCon()
        {
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            string sql1 = "";
            string sql2 = "";
            int id1 = 0;
            int id2 = 0;
            string name = "";
            string destination = "";
            List<KeyValuePair<string, string>> RegionList = new List<KeyValuePair<string, string>>();
            RegionList.Add(new KeyValuePair<string, string>("0", "请选择承运商"));
            List<KeyValuePair<string, string>> DestinationList = new List<KeyValuePair<string, string>>();
            DestinationList.Add(new KeyValuePair<string, string>("0", "请选择目的地"));

            sql1 = "select t1.name from T_con_carrier as t1 where t1.region_id = '" + staff_region + "' " +
                "group by t1.name";

            sql2 = "select t1.destination from T_con_carrier as t1 where t1.region_id = '" + staff_region + "' " +
                "group by t1.destination";

            ds1 = DBClass.execQuery(sql1);
            ds2 = DBClass.execQuery(sql2);

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                name = "";
                name = ds1.Tables[0].Rows[i][0].ToString();
                RegionList.Add(new KeyValuePair<string, string>(name, name));
            }

            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                destination = "";
                destination = ds2.Tables[0].Rows[i][0].ToString();
                DestinationList.Add(new KeyValuePair<string, string>(destination, destination));
            }

            CBCom.ItemsSource = RegionList;
            CBCom.SelectedValuePath = "Key";
            CBCom.DisplayMemberPath = "Value";
            CBCom.SelectedItem = new KeyValuePair<string, string>("0", "请选择承运商");

            CBDestination.ItemsSource = DestinationList;
            CBDestination.SelectedValuePath = "Key";
            CBDestination.DisplayMemberPath = "Value";
            CBDestination.SelectedItem = new KeyValuePair<string, string>("0", "请选择目的地");
        }

        /// <summary>
        /// 下拉联系框赋值
        /// </summary>
        public void getAutoCompleteTextBox()
        {
            string sql = "";
            string strIdName = "";
            DataSet ds = new DataSet();
            List<AutoCompleteEntry> tlist = new List<AutoCompleteEntry>();

            sql = "select t1.id_user, t1.tb_user from T_User as t1";
            ds = DBClass.execQuery(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    strIdName = ds.Tables[0].Rows[i][0] + "   " + ds.Tables[0].Rows[i][1];
                    tlist.Add(new AutoCompleteEntry(strIdName, null));
                }
            }
            this.TBUser_Name.AddItemSource(tlist);
        }

        public void ShowDG1()
        {
            this.DG1.ItemsSource = null;
            this.DG1.CanUserAddRows = false;
            this.DG1.ItemsSource = TableData.DefaultView;
            this.DG1.FrozenColumnCount = 7;
        }

        public void CBSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TableData = BaseClass.TB_CheckBox_Click(sender, TableData, "order_id", "Select");
                ShowDG1();
            }
            catch (Exception e1)
            {

            }
        }

        public void CBPaid_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TableData = BaseClass.TB_CheckBox_Click(sender, TableData, "order_id", "paid");
                this.DG1.ItemsSource = TableData.DefaultView;
                ShowDG1();
            }
            catch (Exception e1)
            {
                MessageBox.Show("系统错误：" + e1.Message);
            }
        }

        public void CBInformPay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TableData = BaseClass.TB_CheckBox_Click(sender, TableData, "order_id", "informPay");
                ShowDG1();
            }
            catch (Exception e1)
            {

            }
        }

        public void CBProcessed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TableData = BaseClass.TB_CheckBox_Click(sender, TableData, "order_id", "processed");
                ShowDG1();
            }
            catch (Exception e1)
            {

            }
        }

        public void CBRead_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TableData = BaseClass.TB_CheckBox_Click(sender, TableData, "order_id", "read");
                ShowDG1();
            }
            catch (Exception e1)
            {

            }
        }

        private void RB_Apply_Click(object sender, RoutedEventArgs e)
        {
            //if (rb_check_name == "RB_Apply")
            //{
            //    RB_Apply.IsChecked = false;
            //    rb_check_name = "";
            //}
            //else
            //{
            //    rb_check_name = "RB_Apply";
            //}
        }

        private void RB_Pack_Click(object sender, RoutedEventArgs e)
        {
            //if (rb_check_name == "RB_Pack")
            //{
            //    RB_Pack.IsChecked = false;
            //    rb_check_name = "";
            //}
            //else
            //{
            //    rb_check_name = "RB_Pack";
            //}
        }


        #region 按钮
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            getTableData();
        }

        /// <summary>
        /// 生成打包单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sql = "", sql1 = "";
            string ConId = "", OrderId = "";
            string pack_person = "", pack_laterHelf = "", pack_laterFeright = "",
                pack_comment = "", pack_time = "", is_pay = "", pack_num = "",
                order_phone = "", order_name = "", order_adress = "", order_note = "";

            SqlConnection conn = DBClass.getConnection();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                ConId = TB_Order_Con_ID.Text;
                OrderId = TB_Order_Id.Text;

                if (CB_IsPay.IsChecked == true)
                {
                    is_pay = "Y";
                }
                if (TB_PackPerson.Text.Length > 0)
                {
                    pack_person = TB_PackPerson.Text;
                }
                if (TB_PackLaterHelf.Text.Length > 0)
                {
                    pack_laterHelf = TB_PackLaterHelf.Text;
                }
                if (TB_PackLaterFeright.Text.Length > 0)
                {
                    pack_laterFeright = TB_PackLaterFeright.Text;
                }
                if (TB_PackComment.Text.Length > 0)
                {
                    pack_comment = TB_PackComment.Text;
                }
                if (TB_Page_Num.Text.Length > 0)
                {
                    pack_num = TB_Page_Num.Text;
                }

                if (TB_Phone.Text.Length > 0)
                {
                    order_phone = TB_Phone.Text;
                }
                if (TB_Person.Text.Length > 0)
                {
                    order_name = TB_Person.Text;
                }
                if (TB_Adress.Text.Length > 0)
                {
                    order_adress = TB_Adress.Text;
                }
                if (TB_Order_Note.Text.Length > 0)
                {
                    order_note = TB_Order_Note.Text;
                }

                pack_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                sql = "update T_Order set pack_staff = '" + pack_person + "', " +
                    "pack_now_helf = '" + pack_laterHelf + "', " +
                    "is_shipments = 'D', " +
                    "pack_now_feright = '" + pack_laterFeright + "', " +
                    "pack_note = '" + pack_comment + "', " +
                    "is_pay = '" + is_pay + "', " +
                    "pack_num = '" + pack_num + "', " +
                    //左边
                    "Con_Express_Id = '" + ConId + "', " +
                    "order_phone = '" + order_phone + "', " +
                    "order_name = '" + order_name + "', " +
                    "order_adress = '" + order_adress + "', " +
                    "order_comment = '" + order_note + "', " +                   
                    "pack_time = '" + pack_time + "' " +
                    "where id = '" + OrderId + "'";

                int n = DBClass.execUpdate(conn, tran, sql);


                sql1 = "update T_Weight set Weight_type = 'D' " +
                    "where Order_id =  '" + OrderId + "'";

                int n1 = DBClass.execUpdate(conn, tran, sql1);

                if (n > 0 && n1 > 0)
                {
                    tran.Commit();
                    MessageBox.Show("生成打包单成功！");
                }
                else
                {
                    MessageBox.Show("操作失败，请重试");
                }
                getTableData();
            }
            catch (Exception e1)
            {
                MessageBox.Show("系统错误，请重试：" + e1.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RB_Apply.IsChecked = false;
            RB_Pack.IsChecked = false;
            RB_Deliver.IsChecked = false;
            RB_Processed.IsChecked = false;
            RB_Paid.IsChecked = false;
            RB_NoPaid.IsChecked = false;
        }

        private void Btn_print_Main_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = this.DG1.SelectedItem;
                var b = a as DataRowView;
                string head = "";
                string name = b.Row["order_person"].ToString();
                string phone = b.Row["order_phone"].ToString();
                string adress = b.Row["order_adress"].ToString();
                string contran_id = b.Row["order_con_id"].ToString();
                string case_num = "";
                string order_id = b.Row["order_id"].ToString();
                string user_id = "";
                string user_tb = "";

                string print_adress = Environment.CurrentDirectory;

                string sql = "";
                sql = "SELECT t1.user_id, t1.user_tb, t2.adress_city, t2.adress_other " +
                    "from T_Order as t1 " +
                    "left JOIN T_User_Adress as t2 on t2.id = t1.user_adress_id " +
                    "where t1.id = '" + order_id + "' ";
                DataSet ds = new DataSet();
                ds = DBClass.execQuery(sql);

                user_id = ds.Tables[0].Rows[0][0].ToString();
                user_tb = ds.Tables[0].Rows[0][1].ToString();
                head = ds.Tables[0].Rows[0][2].ToString() + ds.Tables[0].Rows[0][3].ToString();

                DataSet ds_print = new DataSet();
                DataTable table1 = new DataTable();
                table1.TableName = "print_data"; // 一定要设置表名称
                ds_print.Tables.Add(table1);

                // 添加表中的列
                table1.Columns.Add("head", typeof(string));
                table1.Columns.Add("name", typeof(string));
                table1.Columns.Add("phone", typeof(string));
                table1.Columns.Add("adress", typeof(string));
                table1.Columns.Add("contran_id", typeof(string));
                table1.Columns.Add("case_num", typeof(string));
                table1.Columns.Add("order_id", typeof(string));
                table1.Columns.Add("user_id", typeof(string));
                table1.Columns.Add("user_tb", typeof(string));

                DataRow row = table1.NewRow();
                row["head"] = head;
                row["name"] = name;
                row["phone"] = phone;
                row["adress"] = adress;
                row["contran_id"] = contran_id;
                row["case_num"] = case_num;
                row["order_id"] = order_id;
                row["user_id"] = user_id;
                row["user_tb"] = user_tb;
                table1.Rows.Add(row);

                report = new FastReport.Report();
                report.Preview = prew;//preview1是private FastReport.Preview.PreviewControl preview1;          

                //FDataSet.Tables[0].TableName = "Table1";//数据源名称
                //report.Load(@"C:\主單.frx");
                //发布后地址
                report.Load(print_adress + @"\Print_Label\主單.frx");
                report.RegisterData(ds_print);
                report.GetDataSource("print_data").Enabled = true;

                report.Prepare();
                report.ShowPrepared();
                //WindowsFormsHost1.Child = prew;

                report.PrintSettings.ShowDialog = false;
                report.Print();
            }
            catch (Exception e1)
            {
                MessageBox.Show("系统错误：" + e1.Message);
            }

        }

        private void Btn_print_Page_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = this.DG1.SelectedItem;
                var b = a as DataRowView;
                int s_page_num = 1;

                try
                {
                    s_page_num = int.Parse(TB_Page_Num.Text.ToString());
                }
                catch (Exception e0)
                {
                    MessageBox.Show("请在右下角输入正确打包件数");
                    TB_Page_Num.Focus();
                    return;
                }


                string head = "";
                string name = b.Row["order_person"].ToString();
                string phone = b.Row["order_phone"].ToString();
                string adress = b.Row["order_adress"].ToString();
                string contran_id = b.Row["order_con_id"].ToString();
                string order_id = b.Row["order_id"].ToString();
                string user_id = "";
                string user_tb = "";

                string print_adress = Environment.CurrentDirectory;

                string sql = "";
                sql = "SELECT t1.user_id, t1.user_tb, t2.adress_city, t2.adress_other " +
                    "from T_Order as t1 " +
                    "left JOIN T_User_Adress as t2 on t2.id = t1.user_adress_id " +
                    "where t1.id = '" + order_id + "' ";
                DataSet ds = new DataSet();
                ds = DBClass.execQuery(sql);

                user_id = ds.Tables[0].Rows[0][0].ToString();
                user_tb = ds.Tables[0].Rows[0][1].ToString();
                head = ds.Tables[0].Rows[0][2].ToString() + ds.Tables[0].Rows[0][3].ToString();

                DataSet ds_print = new DataSet();
                DataTable table1 = new DataTable();
                table1.TableName = "print_data"; // 一定要设置表名称
                ds_print.Tables.Add(table1);

                // 添加表中的列
                table1.Columns.Add("head", typeof(string));
                table1.Columns.Add("name", typeof(string));
                table1.Columns.Add("phone", typeof(string));
                table1.Columns.Add("adress", typeof(string));
                table1.Columns.Add("contran_id", typeof(string));
                table1.Columns.Add("case_num", typeof(string));
                table1.Columns.Add("contran_page", typeof(string));
                table1.Columns.Add("order_id", typeof(string));
                table1.Columns.Add("user_id", typeof(string));
                table1.Columns.Add("user_tb", typeof(string));

                for (int i = 2; i <= s_page_num; i++)
                {
                    DataRow row = table1.NewRow();
                    row["head"] = head;
                    row["name"] = name;
                    row["phone"] = phone;
                    row["adress"] = adress;
                    row["contran_id"] = contran_id;
                    row["case_num"] = i.ToString() + "/" + s_page_num.ToString();
                    row["contran_page"] = contran_id + (i - 1).ToString().PadLeft(2, '0');
                    row["order_id"] = order_id;
                    row["user_id"] = user_id;
                    row["user_tb"] = user_tb;
                    table1.Rows.Add(row);
                }


                report = new FastReport.Report();
                report.Preview = prew;//preview1是private FastReport.Preview.PreviewControl preview1;          

                //report.Load(@"C:\主單.frx");
                //发布后地址
                report.Load(print_adress + @"\Print_Label\子單.frx");
                report.RegisterData(ds_print);
                report.GetDataSource("print_data").Enabled = true;

                report.Prepare();
                report.ShowPrepared();
                //WindowsFormsHost1.Child = prew;

                report.PrintSettings.ShowDialog = false;
                report.Print();
                TB_Page_Num.Clear();
            }
            catch (Exception e1)
            {
                MessageBox.Show("系统错误：" + e1.Message);
            }
        }

        private void Btn_print_Con_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = this.DG1.SelectedItem;
                var b = a as DataRowView;

                string head = "";
                string name = b.Row["order_person"].ToString();
                string phone = b.Row["order_phone"].ToString();
                string adress = b.Row["order_adress"].ToString();
                string contran_id = b.Row["order_con_id"].ToString();
                string order_id = b.Row["order_id"].ToString();
                string user_id = "";
                string user_tb = "";
                string user_name = "";
                string company = b.Row["order_company"].ToString();

                string print_adress = Environment.CurrentDirectory;

                string sql = "";
                sql = "SELECT t1.user_id, t1.user_tb, t2.adress_city, t2.adress_other, " +
                    "t3.Weight_ConID, t3.Weight_Shelf, t3.Weight_Helf, t4.id_name " +
                    "from T_Order as t1 " +
                    "left JOIN T_User_Adress as t2 on t2.id = t1.user_adress_id " +
                    "left JOIN T_User as t4 on t4.id_user = t1.user_id " +
                    "INNER JOIN T_Weight as t3 on t3.Order_id = t1.id " +
                    "where t1.id = '" + order_id + "' ";

                DataSet ds = new DataSet();
                ds = DBClass.execQuery(sql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    user_id = ds.Tables[0].Rows[0]["user_id"].ToString();
                    user_tb = ds.Tables[0].Rows[0]["user_tb"].ToString();
                    user_name = ds.Tables[0].Rows[0]["id_name"].ToString();
                    head = ds.Tables[0].Rows[0]["adress_city"].ToString()
                        + ds.Tables[0].Rows[0]["adress_other"].ToString();
                }
                else
                {
                    MessageBox.Show("该数据有误，请联系管理员核对");
                    return;
                }

                DataSet ds_print = new DataSet();

                DataTable table1 = new DataTable();
                table1.TableName = "print_data"; // 一定要设置表名称
                ds_print.Tables.Add(table1);

                DataTable table2 = new DataTable();
                table2.TableName = "print_table"; // 一定要设置表名称
                ds_print.Tables.Add(table2);

                // 添加表中的列
                table1.Columns.Add("head", typeof(string));
                table1.Columns.Add("name", typeof(string));
                table1.Columns.Add("phone", typeof(string));
                table1.Columns.Add("adress", typeof(string));
                table1.Columns.Add("contran_id", typeof(string));
                table1.Columns.Add("case_num", typeof(string));
                table1.Columns.Add("contran_page", typeof(string));
                table1.Columns.Add("order_id", typeof(string));
                table1.Columns.Add("user_id", typeof(string));
                table1.Columns.Add("user_name", typeof(string));
                table1.Columns.Add("user_tb", typeof(string));
                table1.Columns.Add("company", typeof(string));


                table2.Columns.Add("id", typeof(string));
                table2.Columns.Add("con_id", typeof(string));
                table2.Columns.Add("shelf", typeof(string));
                table2.Columns.Add("helf", typeof(string));

                // 任意添加一些数据           
                for (int i = 0, maxI = 1; i < maxI; i++)
                {
                    DataRow row = table1.NewRow();
                    row["head"] = head;
                    row["name"] = name;
                    row["phone"] = phone;
                    row["adress"] = adress;
                    row["contran_id"] = contran_id;
                    row["case_num"] = "";
                    row["contran_page"] = "";

                    row["order_id"] = order_id;
                    row["user_id"] = user_id;
                    row["user_name"] = user_name;
                    row["user_tb"] = user_tb;
                    row["company"] = company;
                    table1.Rows.Add(row);
                }

                for (int i = 0, maxI = ds.Tables[0].Rows.Count; i < maxI; i++)
                {
                    DataRow row1 = table2.NewRow();
                    row1["id"] = i.ToString();
                    row1["con_id"] = ds.Tables[0].Rows[i]["Weight_ConID"].ToString();
                    row1["shelf"] = ds.Tables[0].Rows[i]["Weight_Shelf"].ToString();
                    row1["helf"] = ds.Tables[0].Rows[i]["Weight_Helf"].ToString();
                    table2.Rows.Add(row1);
                }

                report = new FastReport.Report();
                report.Preview = prew;//preview1是private FastReport.Preview.PreviewControl preview1;          

                //FDataSet.Tables[0].TableName = "Table1";//数据源名称
                //report.Load(@"C:\集運訂單.frx");
                //发布后地址
                report.Load(print_adress + @"\Print_Label\集運訂單.frx");
                report.RegisterData(ds_print);
                report.GetDataSource("print_data").Enabled = true;
                report.GetDataSource("print_table").Enabled = true;

                report.Prepare();
                report.ShowPrepared();
                //WindowsFormsHost1.Child = prew;

                report.PrintSettings.ShowDialog = false;
                report.Print();
            }
            catch (Exception e1)
            {
                MessageBox.Show("系统错误：" + e1.Message);
            }
        }       

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string[] str_paid = new string[2];
            string[] str_informPay = new string[2];
            string[] str_processed = new string[2];
            string[] str_read = new string[2];
            string sql = "";
            int n = 0;

            SqlConnection conn = DBClass.getConnection();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                if (this.DG1.ItemsSource == null)
                {
                    MessageBox.Show("请先获取集运清单");
                }
                else
                {
                    str_paid = getCheckList("paid", "order_id");
                    //str_informPay = getCheckList("informPay", "order_id");
                    //str_processed = getCheckList("processed", "order_id");
                    //str_read = getCheckList("read", "order_id");
                    n = updateDatabase(str_paid, "T_Order", "is_pay", "id", conn, tran);
                    
                    //if (n > 0 && n1 > 0)
                    if (n > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("保存成功！");
                        ShowDG1();
                        //Weigh tw = new Weigh();                       
                        //MainWindow mw_new = new MainWindow();
                        //mw_new.ContentSource = new Uri("/Pages/Tran/ConTran.xaml", UriKind.RelativeOrAbsolute);
                        //mw_new.Show();
                        //mw_new.WindowState = WindowState.Maximized;
                        //MainWindow mw = System.Windows.Window.GetWindow(this) as MainWindow;
                        //mw.Close();
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("系统错误: " + e1.Message);
            }
        }
       
        private void BtnSavePack_Click(object sender, RoutedEventArgs e)
        {
            string sql = "";
            string ConId = "";
            string pack_person = "", pack_laterHelf = "", pack_laterFeright = "",
                pack_comment = "", is_pay = "", pack_num = "";

            try
            {
                ConId = TB_Order_Con_ID.Text;

                if (CB_IsPay.IsChecked == true)
                {
                    is_pay = "Y";
                }
                if (TB_PackPerson.Text.Length > 0)
                {
                    pack_person = TB_PackPerson.Text;
                }
                if (TB_PackLaterHelf.Text.Length > 0)
                {
                    pack_laterHelf = TB_PackLaterHelf.Text;
                }
                if (TB_PackLaterFeright.Text.Length > 0)
                {
                    pack_laterFeright = TB_PackLaterFeright.Text;
                }
                if (TB_PackComment.Text.Length > 0)
                {
                    pack_comment = TB_PackComment.Text;
                }
                if (TB_Page_Num.Text.Length > 0)
                {
                    pack_num = TB_Page_Num.Text;
                }

                
                //pack_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                sql = "update T_Order set pack_staff = '" + pack_person + "', " +
                    "pack_now_helf = '" + pack_laterHelf + "', " +
                    "pack_now_feright = '" + pack_laterFeright + "', " +
                    "pack_note = '" + pack_comment + "', " +
                    "is_pay = '" + is_pay + "', " +
                    "pack_num = '" + pack_num + "' " +
                    "where Con_Express_Id = '" + ConId + "'";
                int n = DBClass.execUpdate(sql);
                if (n > 0)
                {
                    MessageBox.Show("打包信息保存成功！");
                }
                else
                {
                    MessageBox.Show("操作失败，请重试");
                }
                getTableData();
            }
            catch (Exception e1)
            {
                MessageBox.Show("系统错误，请重试：" + e1.Message);
            }
        }

        private void BtnDeletePack_Click(object sender, RoutedEventArgs e)
        {
            string sql = "", sql1 = "";
            string OrderId = "";

            SqlConnection conn = DBClass.getConnection();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                OrderId = TB_Order_Id.Text;
                if (CB_IsPay.IsChecked == true)
                {
                    MessageBox.Show("已付款，不能取消");
                    return;
                }
               
                sql = "update T_Order set order_is_show = 'N', " +
                    "pack_note = '取消打包' " +
                    "where id = '" + OrderId + "'";

                int n = DBClass.execUpdate(conn, tran, sql);


                sql1 = "update T_Weight set Order_id = '', " +
                    "Weight_Type = 'Y' " +
                    "where Order_id =  '" + OrderId + "'";

                int n1 = DBClass.execUpdate(conn, tran, sql1);

                if (n > 0 && n1 > 0)
                {
                    tran.Commit();
                    MessageBox.Show("取消打包成功！");
                }
                else
                {
                    MessageBox.Show("操作失败，请重试");
                }
                getTableData();
            }
            catch (Exception e1)
            {
                MessageBox.Show("系统错误，请重试：" + e1.Message);
            }
        }

        private void BtnSaveGoods_Click(object sender, RoutedEventArgs e)
        {
            string sql = "", sql1 = "";
            string ConId = "", OrderId = "";
            string order_phone = "", order_name = "", order_adress = "", order_note = "";

            SqlConnection conn = DBClass.getConnection();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                ConId = TB_Order_Con_ID.Text;
                OrderId = TB_Order_Id.Text;

                if (TB_Phone.Text.Length > 0)
                {
                    order_phone = TB_Phone.Text;
                }
                if (TB_Person.Text.Length > 0)
                {
                    order_name = TB_Person.Text;
                }
                if (TB_Adress.Text.Length > 0)
                {
                    order_adress = TB_Adress.Text;
                }
                if (TB_Order_Note.Text.Length > 0)
                {
                    order_note = TB_Order_Note.Text;
                }

                sql = "update T_Order set " +
                    "Con_Express_Id = '" + ConId + "', " +
                    "order_phone = '" + order_phone + "', " +
                    "order_name = '" + order_name + "', " +
                    "order_adress = '" + order_adress + "', " +
                    "order_comment = '" + order_note + "' " + 
                    "where id = '" + OrderId + "'";

                int n = DBClass.execUpdate(sql);

                if (n > 0)
                {
                    tran.Commit();
                    MessageBox.Show("收货信息保存成功！");
                }
                else
                {
                    MessageBox.Show("操作失败，请重试");
                }
                getTableData();
            }
            catch (Exception e1)
            {
                MessageBox.Show("系统错误，请重试：" + e1.Message);
            }
        }

        #endregion

        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                getDetail();
            }
            catch (Exception e1)
            {
                MessageBox.Show("系统错误：" + e1.Message);
            }
        }

        /// <summary>
        /// str[0]为选中列表，str[1]为未选中列表
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="idName"></param>
        /// <returns></returns>
        public string[] getCheckList(string columnName, string idName)
        {
            string[] str = new string[2];
            bool isCheck = false;

            str[0] = "(''";
            str[1] = "(''";

            int n = 0;
            for (int i = 0; i < TableData.Rows.Count; i++)
            {
                isCheck = false;
                isCheck = bool.Parse(TableData.Rows[i][columnName].ToString());
                if (isCheck == true)
                {
                    n++;
                    str[0] += ",'" + TableData.Rows[i][idName].ToString() + "'";
                }
                else
                {
                    str[1] += ",'" + TableData.Rows[i][idName].ToString() + "'";
                }
            }
            str[0] += ")";
            str[1] += ")";

            return str;
        }

        public int updateDatabase(string[] str, string TableName, string columnName,
            string idName, SqlConnection conn, SqlTransaction tran)
        {
            string sql = "";
            int n = 0;

            sql = "UPDATE " + TableName + " set " + columnName + " = 'Y' " +
                "where " + idName + " in " + str[0] + "";
            n = DBClass.execUpdate(conn, tran, sql);

            sql = "UPDATE " + TableName + " set " + columnName + " = NULL " +
                "where " + idName + " in " + str[1] + "";
            n += DBClass.execUpdate(conn, tran, sql);

            return n;
        }

        


    }
}
