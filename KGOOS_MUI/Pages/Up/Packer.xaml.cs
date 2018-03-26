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
                staff_name = "测试人员";
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
        }

        /// <summary>
        /// 获取名称，目的地
        /// </summary>
        public void getCon()
        {
            DataSet ds = new DataSet();
            string sql = "";
            int id = 0;
            string name = "";
            string destination = "";
            List<KeyValuePair<int, string>> RegionList = new List<KeyValuePair<int, string>>();
            RegionList.Add(new KeyValuePair<int, string>(0, "请选择承运商"));
            List<KeyValuePair<int, string>> DestinationList = new List<KeyValuePair<int, string>>();
            DestinationList.Add(new KeyValuePair<int, string>(0, "请选择目的地"));

            sql = "select t1.id, t1.name, t1.destination from T_con_carrier as t1 where t1.region_id = '" + staff_region + "'";
            ds = DBClass.execQuery(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                id = 0;
                name = "";
                id = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                name = ds.Tables[0].Rows[i][1].ToString();
                destination = ds.Tables[0].Rows[i][2].ToString();
                RegionList.Add(new KeyValuePair<int, string>(id, name));
                DestinationList.Add(new KeyValuePair<int, string>(id, destination));
            }

            CBCom.ItemsSource = RegionList;
            CBCom.SelectedValuePath = "Key";
            CBCom.DisplayMemberPath = "Value";
            CBCom.SelectedItem = new KeyValuePair<int, string>(0, "请选择承运商");

            CBDestination.ItemsSource = DestinationList;
            CBDestination.SelectedValuePath = "Key";
            CBDestination.DisplayMemberPath = "Value";
            CBDestination.SelectedItem = new KeyValuePair<int, string>(0, "请选择目的地");
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
        /// 写入数据库
        /// </summary>
        public void inputDB()
        {
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
                pack_con_id = pack_id;

                #region 获取前台数据
                pack_com_carrier = CBCom.SelectedIndex.ToString();
                pack_destination = CBDestination.SelectedIndex.ToString();
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
                    pack_note,pack_shop, pack_more_name, pack_con_id, pack_declare, pack_front_helf, pack_freight,
                    pack_loans, pack_num );

                int n = DBClass.execUpdate(sql);

                if (n > 0)
                {
                    MessageBox.Show("保存成功！");
                }
                

            }
            catch (Exception e)
            {
                MessageBox.Show("操作失败。请重试" + e.Message);
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

            sql = "select t1.tb_user, t1.id_name from T_User as t1";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            float freight = 0;
            freight = Freight.Freight.Count_Freight(20, "20+ceil(w÷9)×9+90");
            TBFreight.Text = freight.ToString();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            inputDB();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
