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
    /// Interaction logic for Coupon.xaml
    /// </summary>
    public partial class Coupon : UserControl
    {
        public Coupon()
        {
            InitializeComponent();
        }

        private void Btn_Select_Click(object sender, RoutedEventArgs e)
        {

            getCoupon();
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            InsertCoupon();
        }

        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            var a = this.DG1.SelectedItem;
            var b = a as DataRowView;
            string id = "";
            try
            {
                id = b.Row[1].ToString();
                DeleteCoupon(id);
            }
            catch (Exception e1)
            {
                MessageBox.Show("删除失败" + e1.Message);
            }
        }

        private void DG1_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        /// <summary>
        /// 获取表格值
        /// </summary>
        public void getCoupon()
        {
            string sql = "";
            try
            {
                sql = "select * from t_coupon as t1 order by coupon_id";
                DataSet ds = new DataSet();
                ds = DBClass.execQuery(sql);
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("num", typeof(string)));
                dt.Columns.Add(new DataColumn("coupon_id", typeof(string)));
                dt.Columns.Add(new DataColumn("coupon_name", typeof(string)));
                dt.Columns.Add(new DataColumn("coupon_num", typeof(string)));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["num"] = i + 1;
                        dr["coupon_id"] = ds.Tables[0].Rows[i]["coupon_id"];
                        dr["coupon_name"] = ds.Tables[0].Rows[i]["coupon_name"];
                        dr["coupon_num"] = ds.Tables[0].Rows[i]["coupon_num"];
                        dt.Rows.Add(dr);
                    }
                }
                this.DG1.CanUserAddRows = false;
                this.DG1.ItemsSource = dt.DefaultView;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        /// <summary>
        /// 新建优惠券
        /// </summary>
        public void InsertCoupon()
        {
            string name = "", num = "";
            string sql = "";
            try
            {
                name = TB_Name.Text;
                num = TB_Money.Text;
                sql = "insert into T_Coupon(coupon_name, coupon_num) " +
                    "values ('" + name + "'," + num + ")";
                int n = DBClass.execUpdate(sql);
                if (n > 0)
                {
                    MessageBox.Show("添加成功！");
                    getCoupon();
                }

            }
            catch(Exception e)
            {
                MessageBox.Show("操作失败，请重试：" + e.Message);
            }
        }

        /// <summary>
        /// 删除优惠券
        /// </summary>
        public void DeleteCoupon(string id)
        {
            string sql = "";
            try
            {
                sql = "delete T_Coupon where coupon_id = '" + id + "'";
                int n = DBClass.execUpdate(sql);

                if (n > 0)
                {
                    MessageBox.Show("删除成功！");
                    getCoupon();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("操作失败。请重试" + e.Message);
            }
        }
    }
}
