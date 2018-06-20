using FirstFloor.ModernUI.Windows.Controls;
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

namespace KGOOS_MUI
{
    //定义委托
    public delegate void ChangeTextHandler(string phone, string name, string adress);


    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class UserAdressWindow : ModernWindow
    {
        private List<UserAdressModel> _UserAdressModel;
        public List<UserAdressModel> UserAddressModel
        {
            get { return _UserAdressModel; }
            set
            {
                _UserAdressModel = value;
            }
        }

        //定义事件
        public event ChangeTextHandler ChangeTextEvent;

        public UserAdressWindow()
        {
            InitializeComponent();
            getUserAdressList();
        }

        public void getUserAdressList()
        {
            string sql = "";
            string userId = "";
            DataSet ds = new DataSet();
            UserAddressModel = new List<UserAdressModel>();

            try
            {
                userId = Application.Current.Properties["userId"].ToString();
                sql = "select * from T_User_Adress as t1 where t1.user_id = '" + userId + "'";
                ds = DBClass.execQuery(sql);
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Phone", typeof(string)));
                dt.Columns.Add(new DataColumn("Name", typeof(string)));
                dt.Columns.Add(new DataColumn("Adress", typeof(string)));
                dt.Columns.Add(new DataColumn("Code", typeof(string)));
                dt.Columns.Add(new DataColumn("Country", typeof(string)));
                dt.Columns.Add(new DataColumn("City", typeof(string)));

                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string phone = "";
                        string adress = "";


                        if (ds.Tables[0].Rows[i]["adress_phone"].ToString().Length > 0)
                        {
                            phone = ds.Tables[0].Rows[i]["adress_phone"].ToString();
                        }
                        else
                        {
                            phone = ds.Tables[0].Rows[i]["adress_tel"].ToString();
                        }
                        adress += ds.Tables[0].Rows[i]["adress_region"].ToString() + " - " + ds.Tables[0].Rows[i]["adress_city"].ToString() + " - " +
                                 ds.Tables[0].Rows[i]["adress_other"].ToString() + " - " + ds.Tables[0].Rows[i]["adress_datail"].ToString();

                        //UserAddressModel.Add(new UserAdressModel()
                        //{

                        //    Phone = phone,
                        //    Name = ds.Tables[0].Rows[i]["adress_name"].ToString(),
                        //    Adress = adress
                        //});
                        

                        DataRow dr = dt.NewRow();
                        dr["Phone"] = phone;
                        dr["Name"] = ds.Tables[0].Rows[i]["adress_name"].ToString();
                        dr["Adress"] = adress;
                        dr["Code"] = "";
                        dr["Country"] = "";
                        dr["City"] = "";
                        
                        dt.Rows.Add(dr);
                    }

                }

                this.DG1.CanUserAddRows = false;
                this.DG1.ItemsSource = dt.DefaultView;

            }
            catch (Exception e)
            {
                MessageBox.Show("系统错误：" + e.Message);
            }
        }
        private void DG1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var a = this.DG1.SelectedItem;
                //MessageBox.Show(a.ToString());
                var b = a as DataRowView;
                string phone = b.Row[0].ToString();
                string name = b.Row[1].ToString();
                string adress = b.Row[2].ToString();
                //string str = phone + "☀" + name + "☀" + adress;
                //引发事件
                if (ChangeTextEvent != null)
                {
                    ChangeTextEvent(phone, name, adress);
                }

                UserAdressWindow uaw = System.Windows.Window.GetWindow(this) as UserAdressWindow;
                uaw.Close();
               
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
