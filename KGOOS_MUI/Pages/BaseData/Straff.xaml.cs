using KGOOS_MUI.Common;
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

namespace KGOOS_MUI.Pages.BaseData
{
    /// <summary>
    /// Interaction logic for Straff.xaml
    /// </summary>
    public partial class Straff : UserControl
    {
        public Straff()
        {
            InitializeComponent();

            getPlant();
        }

        public void getPlant()
        {

            DataSet ds = new DataSet();
            string sql = "";
            int id = 0;
            string name = "";
            List<KeyValuePair<int, string>> RegionList = new List<KeyValuePair<int, string>>();
            RegionList.Add(new KeyValuePair<int, string>(0, "请选择仓库"));

            sql = "select Region_Id, Region_Name from T_Region";
            ds = DBClass.execQuery(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                id = 0;
                name = "";
                id = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                name = ds.Tables[0].Rows[i][1].ToString();
                RegionList.Add(new KeyValuePair<int, string>(id, name));
            }

            Region.ItemsSource = RegionList;
            Region.SelectedValuePath = "Key";
            Region.DisplayMemberPath = "Value";
            Region.SelectedItem = new KeyValuePair<int, string>(0, "请选择仓库");
        }
        /// <summary>
        /// 写入数据库
        /// </summary>
        public void inputDB()
        {
            try
            {
                string sql = "";
                string id_staff, name_staff, pass_staff, role_staff, Region_staff;

                DataSet ds = new DataSet();

                Region_staff = Region.SelectedValue.ToString();
                if (Region_staff.Equals("0"))
                {
                    MessageBox.Show("请选择所在网点");
                    return;     
                }
                //Id = BaseClass.getInsertMaxId("T_Weight", "Id", "000001");

                if (TBid.Text != "")
                {
                    id_staff = TBid.Text;
                }
                else
                {
                    id_staff = "";
                    MessageBox.Show("请输入员工编号");
                    return;                 
                }

                if (TBname.Text != "")
                {
                    name_staff = TBname.Text;
                }
                else
                {
                    name_staff = "";
                    MessageBox.Show("请输入员工姓名");
                    return;  
                }


                if (TBPass.Text != "")
                {
                    pass_staff = TBPass.Text;
                }
                else
                {
                    pass_staff = "";
                    MessageBox.Show("请输入密码");
                    return;  
                }

                sql = "select * from t_staff as t1 where t1.id_staff = '" + id_staff + "'";
                ds = DBClass.execQuery(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sql = "update T_Staff set name_staff = '{1}', pass_staff = '{2}', " +
                        "role_staff = '{3}', region_staff = '{4}' " +
                        "where id_staff = '{0}'";
                }
                else
                {
                    sql = "insert into T_Staff " +
                    "(id_staff, name_staff, pass_staff, role_staff, Region_staff) " +
                    "values ('{0}','{1}','{2}','{3}','{4}')";
                }

                role_staff = "1";

                sql = string.Format(sql, id_staff, name_staff, pass_staff, role_staff, Region_staff);
                int n = DBClass.execUpdate(sql);
                if (n > 0)
                {
                    MessageBox.Show("保存成功！");
                    TBid.Clear();
                    TBname.Clear();
                    TBPass.Clear();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("操作失败。请重试" + e.Message);
            }
        }

        /// <summary>
        /// 删除数据库
        /// </summary>
        public void delDb(string staff_id)
        {
            try
            {
                string sql = "";
                sql = "delete t_staff where id_staff = '" + staff_id + "'";
                int n = DBClass.execUpdate(sql);

                if (n > 0)
                {
                    MessageBox.Show("删除成功！");
                    getTableData();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("操作失败。请重试" + e.Message);
            }
        }

        /// <summary>
        /// datagrid赋值
        /// </summary>
        public void getTableData()
        {
            string sql = "";
            DataSet ds = new DataSet();
            sql = "select * from t_staff as t1 " +
                "join t_region as t2 on t2.Region_Id = t1.Region_staff";
            ds = DBClass.execQuery(sql);
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_staff", typeof(object)));
            dt.Columns.Add(new DataColumn("name_staff", typeof(string)));
            dt.Columns.Add(new DataColumn("pass_staff", typeof(string)));
            dt.Columns.Add(new DataColumn("role_staff", typeof(string)));        
            dt.Columns.Add(new DataColumn("Region_Id", typeof(string)));
            dt.Columns.Add(new DataColumn("Region_Name", typeof(string)));
            

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["id_staff"] = ds.Tables[0].Rows[i]["id_staff"];
                    dr["name_staff"] = ds.Tables[0].Rows[i]["name_staff"];
                    dr["pass_staff"] = ds.Tables[0].Rows[i]["pass_staff"];
                    dr["role_staff"] = ds.Tables[0].Rows[i]["role_staff"];
                    dr["Region_Name"] = ds.Tables[0].Rows[i]["Region_Name"];
                    dr["Region_Id"] = ds.Tables[0].Rows[i]["Region_Id"];
                    dt.Rows.Add(dr);
                }

            }
            this.DG1.CanUserAddRows = false;
            this.DG1.ItemsSource = dt.DefaultView;
        }

        private void DG1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var a = this.DG1.SelectedItem;
                var b = a as DataRowView;
                TBid.Text = b.Row[0].ToString();
                TBname.Text = b.Row[1].ToString();
                TBPass.Text = b.Row[2].ToString();
                int n = int.Parse(b.Row[4].ToString());
                Region.SelectedItem = new KeyValuePair<int, string>(n, b.Row[5].ToString());
            }
            catch (Exception e1)
            {

            }
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            inputDB();
            getTableData();            
        }

        private void Btn_Select_Click(object sender, RoutedEventArgs e)
        {
            getTableData();
        }      

        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            var a = this.DG1.SelectedItem;
            var b = a as DataRowView;
            string staff_id = "";
            try
            {
                staff_id = b.Row[0].ToString();
                delDb(staff_id);
            }
            catch (Exception e1)
            {
                MessageBox.Show("删除失败" + e1.Message);
            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            getTableData();
            TBid.Clear();
            TBname.Clear();
            TBPass.Clear();
            Region.SelectedItem = new KeyValuePair<int, string>(0, "请选择仓库");
        }
    }
}
