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

            sql = "select top 300 * from T_Order as t1 " +
                "LEFT JOIN T_User_Adress as t2 on t2.id = t1.user_adress_id " +
                "LEFT JOIN T_con_carrier as t3 on t3.id = t1.con_carrier_id " +
                "LEFT JOIN T_Type as t4 on t4.id = t1.fast_type " + 
                "LEFT JOIN T_con_carrier as t5 " + 
                "on t5.name = t1.order_con and t5.destination = t1.order_destination " ;

            ds = DBClass.execQuery(sql);
                        
            DataTable dt = new DataTable();
            //表一
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

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    bool paid = false;
                    string pack_state = "", order_put_type = "", con_name = "", destination = "";
                    string order_person = "", order_phone = "", order_adress = "";
                    string pack_real_company = "";                 
                    if (ds.Tables[0].Rows[i]["is_shipments"].ToString() == "Y")
                    {
                        pack_state = "已发件";
                    }
                    else
                    {
                        pack_state = "已打包";
                    }
                    if (ds.Tables[0].Rows[i]["is_pay"].ToString() == "Y")
                    {
                        paid = true;
                        pack_state = "已付款";
                    }
                    if (ds.Tables[0].Rows[i]["con_carrier_id"].ToString().Length > 0 )
                    {
                        order_put_type = "网页申请";
                        con_name = ds.Tables[0].Rows[i]["name"].ToString();
                        destination = ds.Tables[0].Rows[i]["destination"].ToString();
                        order_person = ds.Tables[0].Rows[i]["adress_name"].ToString();
                        if (ds.Tables[0].Rows[i]["adress_phone"].ToString().Length > 0)
                        {
                            order_phone = ds.Tables[0].Rows[i]["adress_phone"].ToString();
                        }
                        else
                        {
                            order_phone = ds.Tables[0].Rows[i]["adress_tel"].ToString();
                        }
                        
                        order_adress = ds.Tables[0].Rows[i]["adress_region"].ToString() + "-" +
                                    ds.Tables[0].Rows[i]["adress_city"].ToString() + "-" +
                                    ds.Tables[0].Rows[i]["adress_other"].ToString() + "-" +
                                    ds.Tables[0].Rows[i]["adress_datail"].ToString();
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


                    dt.Rows.Add(dr);
                }
            }

            this.DG1.CanUserAddRows = false;
            //this.DG1.ItemsSource = PackList;
            this.DG1.ItemsSource = dt.DefaultView;
            this.DG1.FrozenColumnCount = 7;

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
            var drv = e.Row.Item as DataRowView;
            switch (drv["pack_state"].ToString())
            {
                case "已发件": e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9FF59F"));
                    break;
                case "已打包": e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1FF83"));
                    break;
                case "已付款": e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF85DB"));
                    break;

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

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            getTableData();
        }

        private void DG1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                affirm_num = 0;
                tb_con_affirm.Clear();

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

                TB_Order_Con_ID.Text = order_con_id;
                TB_Num.Text = order_num;
                TB_Destrination.Text = order_destrination;
                TB_Font_Helf.Text = pack_font_helf;
                TB_Pack_Type.Text = pack_type;
                TB_Font_Freight.Text = pack_font_freight;

                TB_Phone.Text = order_phone;
                TB_Person.Text = order_person;
                TB_Adress.Text = order_adress;
                TB_Oder_Note.Text = order_note;

                getDataByOrderId(order_id, order_con);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
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
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        /// <summary>
        /// 生产打包单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sql = "";
            string ConId = "";
            string pack_person = "", pack_laterHelf = "", pack_laterFeright = "",
                pack_comment = "", pack_time = "", is_pay = "";

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
                if(TB_PackLaterHelf.Text.Length > 0)
                {
                    pack_laterHelf = TB_PackLaterHelf.Text;
                }
                if(TB_PackLaterFeright.Text.Length > 0)
                {
                    pack_laterFeright = TB_PackLaterFeright.Text;
                }
                if (TB_PackComment.Text.Length > 0)
                {
                    pack_comment = TB_PackComment.Text;
                }
                pack_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                sql = "update T_Order set pack_staff = '" + pack_person + "', " +
                    "pack_now_helf = '" + pack_laterHelf + "', " +
                    "pack_now_feright = '" + pack_laterFeright + "', " +
                    "pack_note = '" + pack_comment + "', " +
                    "is_pay = '" + is_pay + "' " +
                    "where Con_Express_Id = '"+ConId+"'";
                int n = DBClass.execUpdate(sql);
                if (n > 0)
                {
                    MessageBox.Show("生成打包单成功！");
                }
                else
                {
                    MessageBox.Show("操作失败，请重试");
                }
                getTableData();
            }catch(Exception e1)
            {
                MessageBox.Show("系统错误，请重试：" + e1.Message);
            }
        }

        
    }
}
