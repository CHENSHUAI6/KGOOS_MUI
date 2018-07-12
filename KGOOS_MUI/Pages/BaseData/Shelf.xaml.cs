using KGOOS_MUI.Common;
using KGOOS_MUI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Shelf.xaml
    /// </summary>
    public partial class Shelf : UserControl
    {
        public Shelf()
        {
            InitializeComponent();
            getAutoCompleteTextBox();
            getRegion();
            getType();
        }

        /// <summary>
        /// 表格获取值
        /// </summary>
        /// <param name="type">1-ALL；2-Null；3-有货 </param>
        public void getTable(int type)
        {
            string sql = "";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("num", typeof(string)));
            dt.Columns.Add(new DataColumn("shelf_id", typeof(string)));
            dt.Columns.Add(new DataColumn("shelf_region", typeof(string)));
            dt.Columns.Add(new DataColumn("shelf_type", typeof(string)));
            dt.Columns.Add(new DataColumn("shelf_name", typeof(string)));
            dt.Columns.Add(new DataColumn("shelf_tb_user", typeof(string)));
            dt.Columns.Add(new DataColumn("shelf_stock", typeof(string)));
            dt.Columns.Add(new DataColumn("shelf_note", typeof(string)));
            try
            {
                sql = getSql(type);
                ds = DBClass.execQuery(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["num"] = i + 1;
                        dr["shelf_id"] = ds.Tables[0].Rows[i]["shelf_id"];
                        dr["shelf_region"] = ds.Tables[0].Rows[i]["shelf_region"];
                        dr["shelf_type"] = ds.Tables[0].Rows[i]["shelf_type"];
                        dr["shelf_name"] = ds.Tables[0].Rows[i]["shelf_name"];
                        dr["shelf_tb_user"] = ds.Tables[0].Rows[i]["shelf_tb_user"];
                        dr["shelf_stock"] = "";
                        dr["shelf_note"] = ds.Tables[0].Rows[i]["shelf_note"];
                        dt.Rows.Add(dr);
                    }
                }
                else
                {
                    MessageBox.Show("暂无数据！");
                }
                this.DG1.CanUserAddRows = false;
                this.DG1.ItemsSource = dt.DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        /// <summary>
        /// 获取SQL
        /// </summary>
        /// <param name="type">1-ALL；2-Null；3-有货 </param>
        public string getSql(int type)
        {
            string sql = "";
            string shelf_name = "", shelf_region = "", shelf_type = "",
                   shelf_user_id = "", shelf_tb_user = "", shelf_note = "", shelf_status = "";
            if (type == 1)
            {
                sql = "select * from T_Shelf as t1 " +
                    "where t1.shelf_status = 'N' " +
                    "order by t1.shelf_id desc";
                return sql;
            }
            if (type == 3)
            {
                shelf_status = "Y";
            }
            else if (type == 2)
            {
                shelf_status = "N";
            }

            sql = "select * from T_Shelf as t1 " +
                    "where t1.shelf_status = '" + shelf_status + "' ";

            shelf_region = CB_Region.SelectedIndex.ToString();
            if (shelf_region != "0")
            {
                sql += "and t1.shelf_region = '" + shelf_region + "' ";
            }
            shelf_type = CB_Type.SelectedValue.ToString();
            
            sql += "and t1.shelf_type = '" + shelf_type + "' ";

            if (TB_Shelf.Text.Length > 0)
            {
                shelf_name = TB_Shelf.Text;
                sql += "and t1.shelf_name like '%" + shelf_name + "%' ";
            }

            if (TB_Note.Text.Length > 0)
            {
                shelf_note = TB_Note.Text;
                sql += "and t1.shelf_note LIKE '%" + shelf_note + "%' ";
            }

            if (TBName.Text.Length > 0 && TBName.Tag.ToString().Length > 0)
            {
                shelf_user_id = TBName.Tag.ToString();
                shelf_tb_user = TBName.Text;
                sql += "and t1.shelf_tb_user LIKE '%" + shelf_tb_user + "%' ";
            }

                       
            return sql;
            
        }

        /// <summary>
        /// 写入数据库
        /// </summary>
        public void inputShelf()
        {
            string shelf_id = "", shelf_name = "", shelf_region = "", shelf_type = "",
                           shelf_user_id = "", shelf_tb_user = "", shelf_note = "", shelf_status = "";

            string sql = "";
            DataSet ds = new DataSet();
            SqlConnection conn = DBClass.getConnection();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                shelf_id = BaseClass.getInsertMaxId("T_Shelf", "shelf_id", "0000001");
                shelf_region = CB_Region.SelectedIndex.ToString();
                if (shelf_region == "0")
                {
                    MessageBox.Show("请选择区域！");
                    return;
                }
                shelf_type = CB_Type.SelectedValue.ToString();
                if (TB_Shelf.Text.Length > 0)
                {
                    shelf_name = TB_Shelf.Text;
                }
                else
                {
                    shelf_name = "";
                }

                if (TB_Note.Text.Length > 0)
                {
                    shelf_note = TB_Note.Text;
                }
                else
                {
                    shelf_note = "";
                }

                if (TBName.Text.Length > 0 && TBName.Tag.ToString().Length > 0)
                {
                    shelf_user_id = TBName.Tag.ToString();
                    shelf_tb_user = TBName.Text;
                }
                else
                {
                    shelf_user_id = "";
                    shelf_tb_user = "";
                }

                shelf_status = "N";

                //sql = "insert into T_Shelf " +
                //"(shelf_id, shelf_name, shelf_region, shelf_type, shelf_user_id, " +
                //"shelf_tb_user, shelf_note, shelf_status) " +
                //"values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";

                //sql = string.Format(sql, shelf_id, shelf_name, shelf_region, shelf_type,
                //   shelf_user_id, shelf_tb_user, shelf_note, shelf_status);

                sql = "select shelf_id from T_Shelf as t1 " +
                    "where t1.shelf_name = '" + shelf_name + "' " +
                    "and t1.shelf_type = '" + shelf_type + "' ";

                ds = DBClass.execQuery(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("该货架已存在，请重新输入！");
                    return;
                }

                sql = "insert into T_Shelf " +
                "(shelf_id, shelf_name, shelf_region, shelf_type, shelf_note, shelf_status) " +
                "values ('{0}','{1}','{2}','{3}','{4}','{5}')";

                sql = string.Format(sql, shelf_id, shelf_name, shelf_region, shelf_type,
                    shelf_note, shelf_status);

                int n = DBClass.execUpdate(conn, tran, sql);

                tran.Commit();

                if (n > 0)
                {
                    MessageBox.Show("创建成功！");
                    getTable(1);
                    TB_Shelf.Clear();
                    TB_Note.Clear();
                    TBName.Text = "";
                    TBName.Tag = "";

                }
                else
                {
                    MessageBox.Show("系统繁忙，请重试！");
                }
                
            }
            catch (Exception e1)
            {
                MessageBox.Show("系统错误：" + e1.Message);
            }
        }

        private void DG1_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Btn_Select_Click(object sender, RoutedEventArgs e)
        {
            getTable(3);
        }

        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            inputShelf();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

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
            this.TBName.AddItemSource(tlist);
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
                //if (TBShelf.Text == "")
                //{
                //    this.TBShelf.Focus();
                //}
                //else
                //{
                //    this.TBNote.Focus();
                //}
            }
        }

        /// <summary>
        /// 获取区域
        /// </summary>
        public void getRegion()
        {
            DataSet ds = new DataSet();
            string sql = "";
            string Region_Name = "";
            List<KeyValuePair<string, string>> RegionList = new List<KeyValuePair<string, string>>();
            RegionList.Add(new KeyValuePair<string, string>("0", "请选择区域"));

            sql = "select Region_Name from t_region";

            ds = DBClass.execQuery(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Region_Name = "";
                Region_Name = ds.Tables[0].Rows[i][0].ToString();
                RegionList.Add(new KeyValuePair<string, string>(Region_Name, Region_Name));
            }
            CB_Region.ItemsSource = RegionList;
            CB_Region.SelectedValuePath = "Key";
            CB_Region.DisplayMemberPath = "Value";
            CB_Region.SelectedItem = new KeyValuePair<string, string>("0", "请选择区域");
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        public void getType()
        {
            List<KeyValuePair<string, string>> TypeList = new List<KeyValuePair<string, string>>();
            TypeList.Add(new KeyValuePair<string, string>("小货区", "小货区"));
            TypeList.Add(new KeyValuePair<string, string>("大货区", "大货区"));
            CB_Type.ItemsSource = TypeList;
            CB_Type.SelectedValuePath = "Key";
            CB_Type.DisplayMemberPath = "Value";
            CB_Type.SelectedItem = new KeyValuePair<string, string>("小货区", "小货区");
        }

        private void Btn_Select_Null_Click(object sender, RoutedEventArgs e)
        {
            getTable(2);
        }
        
    }
}
