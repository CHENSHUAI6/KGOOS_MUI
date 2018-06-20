using KGOOS_MUI.Common;
using KGOOS_MUI.Model;
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
using Freight;
using System.Data.SqlClient;

namespace KGOOS_MUI.Pages.Up
{
    /// <summary>
    /// Interaction logic for Packer.xaml
    /// </summary>
    [System.Runtime.InteropServices.GuidAttribute("79A062BF-0480-4E4E-B4C0-DAB6B28A7224")]
    public partial class Packer : UserControl
    {
        private string staff_name = "";
        private string staff_region = "";

        public Packer()
        {
            InitializeComponent();
            initialize();
        }

        /// <summary>
        /// 自定义初始化函数
        /// </summary>
        public void initialize()
        {
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

            getType();
            getCon();
            getAutoCompleteTextBox();
            getInitial();
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
        /// 获取快件类型
        /// </summary>
        public void getType()
        {
            DataSet ds = new DataSet();
            string sql = "";
            int id = 0;
            string name = "";
            List<KeyValuePair<int, string>> RegionList = new List<KeyValuePair<int, string>>();
            RegionList.Add(new KeyValuePair<int, string>(0, "请选择快件类型"));

            sql = "select t1.id, t1.name from T_Type as t1";
            ds = DBClass.execQuery(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                id = 0;
                name = "";
                id = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                name = ds.Tables[0].Rows[i][1].ToString();
                RegionList.Add(new KeyValuePair<int, string>(id, name));
            }

            CBType.ItemsSource = RegionList;
            CBType.SelectedValuePath = "Key";
            CBType.DisplayMemberPath = "Value";
            CBType.SelectedItem = new KeyValuePair<int, string>(0, "请选择快件类型");
        }

        /// <summary>
        /// 写入数据库--废掉
        /// </summary>
        public void inputDB()
        {
            SqlConnection conn = DBClass.getConnection();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sql = "";
                string pack_id, pack_com_carrier, pack_destination, pack_type, pack_user_id, pack_user_name, pack_phone,
                    pack_name, pack_address, pack_postcode, pack_city, pack_thing, pack_note,
                    pack_shop, pack_more_name, pack_con_id;

                float pack_declare = 0, pack_front_helf = 0, pack_freight = 0, pack_loans = 0;
                int pack_num = 0;
                DataSet ds = new DataSet();

                pack_id = BaseClass.getInsertMaxId("T_Pack", "pack_id", "000001");
                pack_con_id = pack_id.Substring(2);

                #region 获取前台数据
                pack_com_carrier = CBCom.SelectedValue.ToString();
                pack_destination = CBDestination.SelectedValue.ToString();
                pack_type = CBType.SelectedIndex.ToString();

                if (TBUser_Name.Tag == null || TBUser_Name.Tag.ToString() == "")
                {
                    //sql1 = "select * from "
                    MessageBox.Show(TBUser_Name.Text + "  用户不存在请重新输入");
                    TBUser_Name.Text = null;
                    TBUser_Name.Focus();
                    return;
                }
                else
                {
                    pack_user_id = TBUser_Name.Tag.ToString();
                    pack_user_name = TBUser_Name.Text;
                }

                if (TBPhone.Text != "")
                {
                    pack_phone = TBPhone.Text;
                }
                else
                {
                    pack_phone = "";
                }

                if (TBName.Text != "")
                {
                    pack_name = TBName.Text;
                }
                else
                {
                    pack_name = "";
                }


                if (TBAddress.Text != "")
                {
                    pack_address = TBAddress.Text;
                }
                else
                {
                    pack_address = "";
                }


                if (TBpostcode.Text != "")
                {
                    pack_postcode = TBpostcode.Text;
                }
                else
                {
                    pack_postcode = "";
                }

                if (TBCity.Text != "")
                {
                    pack_city = TBCity.Text;
                }
                else
                {
                    pack_city = "";
                }

                if (TBThing.Text != "")
                {
                    pack_thing = TBThing.Text;
                }
                else
                {
                    pack_thing = "";
                }

                if (TBNote.Text != "")
                {
                    pack_note = TBNote.Text;
                }
                else
                {
                    pack_note = "";
                }

                if (TBShop.Text != "")
                {
                    pack_shop = TBShop.Text;
                }
                else
                {
                    pack_shop = "";
                }

                if (TBmore_Name.Text != "")
                {
                    pack_more_name = TBmore_Name.Text;
                }
                else
                {
                    pack_more_name = "";
                }

                if (TBDeclare.Text != "")
                {
                    pack_declare = float.Parse(TBDeclare.Text);
                }
                else
                {
                    pack_declare = 0;
                }

                if (TBFront_helf.Text != "")
                {
                    pack_front_helf = float.Parse(TBFront_helf.Text);
                }
                else
                {
                    pack_front_helf = 0;
                }

                if (TBFreight.Text != "")
                {
                    pack_freight = float.Parse(TBFreight.Text);
                }
                else
                {
                    pack_freight = 0;
                }

                if (TBLoans.Text != "")
                {
                    pack_loans = float.Parse(TBLoans.Text);
                }
                else
                {
                    pack_loans = 0;
                }

                if (TBNum.Text != "")
                {
                    pack_num = int.Parse(TBNum.Text);
                }
                else
                {
                    pack_num = 0;
                }
                #endregion


                sql = "insert into T_Pack " +
                "(pack_id, pack_com_carrier, pack_destination, pack_type, pack_user_id, pack_user_name, pack_phone, " +
                " pack_name, pack_address, pack_postcode, pack_city, pack_thing, pack_note,pack_shop, " +
                "pack_more_name, pack_con_id, pack_declare, pack_front_helf, pack_freight, pack_loans, " +
                "pack_num ) " +
                "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}', " +
                "'{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}')";

                sql = string.Format(sql, pack_id, pack_com_carrier, pack_destination, pack_type, pack_user_id,
                    pack_user_name, pack_phone, pack_name, pack_address, pack_postcode, pack_city, pack_thing,
                    pack_note, pack_shop, pack_more_name, pack_con_id, pack_declare, pack_front_helf, pack_freight,
                    pack_loans, pack_num);

                int n = DBClass.execUpdate(conn, tran, sql);

                if (n > 0)
                {
                    n = 0;
                    inputPackStr(conn, tran);
                    if (n > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("打包成功！");                     
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("操作失败。请重试" + e.Message);
            }
        }

        /// <summary>
        /// 获取初始值
        /// </summary>
        public void getInitial()
        {
            string weightIdList = "";
            string sql = "";
            DataSet ds = new DataSet();
            float helf = 0;

            try
            {
                weightIdList = Application.Current.Properties["weightIdList"].ToString();
                sql = "select Weight_UserId, Weight_UserName, Weight_Helf from t_weight as t2 where t2.Weight_ConId in " + weightIdList;
                ds = DBClass.execQuery(sql);

                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        helf += float.Parse(dt.Rows[i][2].ToString());
                    }
                }

                TBNum.Text = dt.Rows.Count.ToString();
                TBFront_helf.Text = helf.ToString();
                TBUser_Name.Text = dt.Rows[0][1].ToString();
                TBUser_Name.Tag = dt.Rows[0][0].ToString();

                
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            

        }

        /// <summary>
        /// 写入信息
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public void inputPackStr(SqlConnection conn, SqlTransaction tran)
        {
            string weightIdList = "";
            string sql = "";
            string orderId = "", time = "", Con_Express_Id = "";

            string pack_com_carrier, pack_destination, pack_type, pack_user_id, pack_user_name, pack_phone,
                    pack_name, pack_address, pack_postcode, pack_city, pack_thing, pack_note,
                    pack_shop, pack_more_name, pack_con_id;

            float pack_declare = 0, pack_front_helf = 0, pack_freight = 0, pack_loans = 0;
            int pack_num = 0;

            try
            {
                if (Application.Current.Properties["weightIdList"] != null)
                {
                    weightIdList = Application.Current.Properties["weightIdList"].ToString();
                }
                sql = "update t_weight set Weight_Type = 'D', Order_id = '" + orderId + "' " +
                    " where Weight_ConID in " + weightIdList;
                int n = 0; int n1 = 0;

                n = DBClass.execUpdate(conn, tran, sql);

                #region 获取前台数据
                pack_com_carrier = CBCom.SelectedValue.ToString();
                pack_destination = CBDestination.SelectedValue.ToString();
                pack_type = CBType.SelectedIndex.ToString();

                if (TBUser_Name.Tag == null || TBUser_Name.Tag.ToString() == "")
                {
                    //sql1 = "select * from "
                    MessageBox.Show(TBUser_Name.Text + "  用户不存在请重新输入");
                    TBUser_Name.Text = null;
                    TBUser_Name.Focus();
                    return;
                }
                else
                {
                    pack_user_id = TBUser_Name.Tag.ToString();
                    pack_user_name = TBUser_Name.Text;
                }

                if (TBPhone.Text != "")
                {
                    pack_phone = TBPhone.Text;
                }
                else
                {
                    pack_phone = "";
                }

                if (TBName.Text != "")
                {
                    pack_name = TBName.Text;
                }
                else
                {
                    pack_name = "";
                }


                if (TBAddress.Text != "")
                {
                    pack_address = TBAddress.Text;
                }
                else
                {
                    pack_address = "";
                }


                if (TBpostcode.Text != "")
                {
                    pack_postcode = TBpostcode.Text;
                }
                else
                {
                    pack_postcode = "";
                }

                if (TBCity.Text != "")
                {
                    pack_city = TBCity.Text;
                }
                else
                {
                    pack_city = "";
                }

                if (TBThing.Text != "")
                {
                    pack_thing = TBThing.Text;
                }
                else
                {
                    pack_thing = "";
                }

                if (TBNote.Text != "")
                {
                    pack_note = TBNote.Text;
                }
                else
                {
                    pack_note = "";
                }

                if (TBShop.Text != "")
                {
                    pack_shop = TBShop.Text;
                }
                else
                {
                    pack_shop = "";
                }

                if (TBmore_Name.Text != "")
                {
                    pack_more_name = TBmore_Name.Text;
                }
                else
                {
                    pack_more_name = "";
                }

                if (TBDeclare.Text != "")
                {
                    pack_declare = float.Parse(TBDeclare.Text);
                }
                else
                {
                    pack_declare = 0;
                }

                if (TBFront_helf.Text != "")
                {
                    pack_front_helf = float.Parse(TBFront_helf.Text);
                }
                else
                {
                    pack_front_helf = 0;
                }

                if (TBFreight.Text != "")
                {
                    pack_freight = float.Parse(TBFreight.Text);
                }
                else
                {
                    pack_freight = 0;
                }

                if (TBLoans.Text != "")
                {
                    pack_loans = float.Parse(TBLoans.Text);
                }
                else
                {
                    pack_loans = 0;
                }

                if (TBNum.Text != "")
                {
                    pack_num = int.Parse(TBNum.Text);
                }
                else
                {
                    pack_num = 0;
                }
                #endregion


                orderId = BaseClass.getInsertMaxId("T_Order", "id", "000001");
                time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Con_Express_Id = orderId.Substring(2);

                sql = "insert into T_Order " +
                "(id, Con_Express_Id, order_con, order_destination, fast_type, user_id, " +
                "user_tb, order_phone,  order_name, order_adress, order_code, order_city, order_money, order_goods, " +
                "order_num, order_helf, Freight, order_comment, order_loans, order_shop_name, order_many_name, " +
                "order_staff_name, order_region, order_time) " +
                "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}', " +
                "'{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}')";

                sql = string.Format(sql, orderId, Con_Express_Id, pack_com_carrier, pack_destination, pack_type, pack_user_id,
                    pack_user_name, pack_phone, pack_name, pack_address, pack_postcode, pack_city, pack_declare, pack_thing,
                    pack_num, pack_front_helf, pack_freight, pack_note, pack_loans, pack_shop, pack_more_name,
                    staff_name, staff_region, time);

                n1 = DBClass.execUpdate(conn, tran, sql);

                if (n > 0 && n1 > 0)
                {
                    tran.Commit();
                    MessageBox.Show("打包成功！");

                    UpWindow upw = System.Windows.Window.GetWindow(this) as UpWindow;
                    upw.Close();
                }

            }catch(Exception e)
            {

            }
           
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


        /// <summary>
        /// 根据区间锁定公式
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="W"></param>
        /// <returns></returns>
        public string getWeight(DataTable dt, double W)
        {
            string weight = "";
            double min_num = 0.0, max_num = 0.0;
            string char1 = "", char2 = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    min_num = 0.0;
                    max_num = 0.0;
                    char1 = "";
                    char2 = "";

                    min_num = double.Parse(dt.Rows[i]["min_num"].ToString());
                    max_num = double.Parse(dt.Rows[i]["max_num"].ToString());
                    char1 = dt.Rows[i]["char1"].ToString();
                    char2 = dt.Rows[i]["char2"].ToString();

                    if (char1.Equals("＜"))
                    {
                        if (W > min_num)
                        {
                            if (char2.Equals("＜"))
                            {
                                if (W < max_num)
                                {
                                    weight = "";
                                    weight = dt.Rows[i]["formula"].ToString();
                                            
                                    return weight;
                                }
                            }
                            else if (char2.Equals("≤"))
                            {
                                if (W <= max_num)
                                {
                                    weight = "";
                                    weight = dt.Rows[i]["formula"].ToString();
                                    return weight;
                                }
                            }
                        }
                    }
                    else if (char1.Equals("≤"))
                    {
                        if (W >= min_num)
                        {
                            if (char2.Equals("＜"))
                            {
                                if (W < max_num)
                                {
                                    weight = "";
                                    weight = dt.Rows[i]["formula"].ToString();
                                    return weight;
                                }
                            }
                            else if (char2.Equals("≤"))
                            {
                                if (W <= max_num)
                                {
                                    weight = "";
                                    weight = dt.Rows[i]["formula"].ToString();
                                    return weight;
                                }
                            }
                        }
                    }

                }
            }
            return "";
        }

        /// <summary>
        /// 计算运费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            float freight = 0, W = 0;
            string sql = "";
            string pack_com_carrier, pack_destination;
            string weight = "";
            DataSet ds = new DataSet();

            pack_com_carrier = CBCom.SelectedValue.ToString();
            pack_destination = CBDestination.SelectedValue.ToString();

            if (TBFront_helf.Text != "")
            {
                W = float.Parse(TBFront_helf.Text);
            }
            else
            {
                W = 0;
            }

            sql = "select * from T_Freight where carrier_id in ( " +
                "select id from T_con_carrier as t1 where t1.name = '" + pack_com_carrier + "' " +
                "and t1.destination = '" + pack_destination + "' and t1.region_id = '" + staff_region + "') ";
            ds = DBClass.execQuery(sql);

            weight = getWeight(ds.Tables[0], W);

            if (weight == "")
            {
                MessageBox.Show("请配该仓库-目的地-承运商: 该重量区间的公式");
            }
            else
            {
                try 
                {
                    freight = Freight.Freight.Count_Freight(W, weight);
                    TBFreight.Text = freight.ToString();
                }
                catch(Exception e1)
                {
                    MessageBox.Show("该区间公式有误，请联系管理员重新配置。");
                }
                
            }



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            inputDB();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_UserAdress_Click(object sender, RoutedEventArgs e)
        {
            string userId = "";
            try
            {
                if (TBUser_Name.Text != "")
                {
                    try
                    {
                        userId = TBUser_Name.Tag.ToString();

                        Application.Current.Properties["userId"] = userId;
                        UserAdressWindow uaw = new UserAdressWindow();
            
                        //订阅事件
                        uaw.ChangeTextEvent += new ChangeTextHandler(frm_ChangeTextEvent);
                        uaw.ShowDialog();

                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show("该旺旺号未在网页端注册，无法获取收货地址");
                    }

                }
                else
                {
                    MessageBox.Show("请先输入旺旺号");
                }
            }catch(Exception e2)
            {
                MessageBox.Show("系统错误：" + e2.Message);
            }           
        }

        void frm_ChangeTextEvent(string phone, string name, string adress)
        {
            this.TBPhone.Text = phone;
            this.TBName.Text = name;
            this.TBAddress.Text = adress;
        }
    }
}
