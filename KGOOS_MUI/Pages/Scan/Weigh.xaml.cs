using KGOOS_MUI.Common;
using KGOOS_MUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace KGOOS_MUI.Pages.Scan
{
    /// <summary>
    /// Interaction logic for Weight.xaml
    /// </summary>
    public partial class Weigh : UserControl
    {       
        private string staff_name = "";
        private string staff_region = "";
        private bool IsOK = false;
        private float Weight_Size = 0;

        public Weigh()
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

            //下拉框赋值
            List<KeyValuePair<string, string>> RegionList = new List<KeyValuePair<string, string>>();
            RegionList.Add(new KeyValuePair<string, string>("默认", "默认"));
            RegionList.Add(new KeyValuePair<string, string>("纸箱", "纸箱"));
            RegionList.Add(new KeyValuePair<string, string>("纸皮", "纸皮"));
            RegionList.Add(new KeyValuePair<string, string>("木架", "木架"));
            RegionList.Add(new KeyValuePair<string, string>("编织袋", "编织袋"));
            RegionList.Add(new KeyValuePair<string, string>("塑料袋", "塑料袋"));
            RegionList.Add(new KeyValuePair<string, string>("长条", "长条"));

            CBType.ItemsSource = RegionList;
            CBType.SelectedValuePath = "Key";
            CBType.DisplayMemberPath = "Value";
            CBType.SelectedItem = new KeyValuePair<string, string>("默认", "默认");
            Weight_Size = 0;

            getTableData();
            getAutoCompleteTextBox();
        }

        /// <summary>
        /// 写入数据库
        /// </summary>
        public void inputDB()
        {
            try
            {
                string sql = "";
                string Weight_Time, Id, Weight_Num, Weight_Note, Weight_Pack, Weight_Shelf,
                    Weight_UserId, Weight_UserName, Weight_Helf, Weight_ConID, Weight_NoteStaff,
                    Weight_OverLong, Weight_OverHelf;
                float Weight_Weitgh = 0;
                
                DataSet ds = new DataSet();

                Weight_Time = TBsacnTime.Value.ToString("yyyy-MM-dd: HH:mm:ss");               

                Id = BaseClass.getInsertMaxId("T_Weight", "Id", "000001");

                if (CBLong.IsChecked == true)
                {
                    Weight_OverLong = "是";
                }
                else
                {
                    Weight_OverLong = "";
                }

                if (CBHelf.IsChecked == true)
                {
                    Weight_OverHelf = "是";
                }
                else
                {
                    Weight_OverHelf = "";
                }

                if (TBtranId.Text.Length >= 5)
                {
                    Weight_ConID = TBtranId.Text;
                }
                else
                {
                    Weight_ConID = "";
                    MessageBox.Show("运单编号不能为空且5位以上。");
                    return;
                }

                if (TBNumber.Text != "")
                {
                    Weight_Num = TBNumber.Text;
                }
                else
                {
                    Weight_Num = "";
                }

                if (TBweigh.Text != "")
                {
                    Weight_Weitgh = float.Parse(TBweigh.Text);
                }
                else
                {
                    Weight_Weitgh = 0;
                }


                if (TBNote.Text != "")
                {
                    Weight_Note = TBNote.Text;
                }
                else
                {
                    Weight_Note = "";
                }


                if (TBShelf.Text != "")
                {
                    Weight_Shelf = TBShelf.Text;
                }
                else
                {
                    Weight_Shelf = "";
                }

                //if (TBSize.Text != "")
                //{
                //    Weight_Size = float.Parse(TBSize.Text);
                //}
                //else
                //{
                //    Weight_Size = 0;
                //}

                if (TBNoteStaff.Text != "")
                {
                    Weight_NoteStaff = TBNoteStaff.Text;
                }
                else
                {
                    Weight_NoteStaff = "";
                }

                Weight_Pack = CBType.SelectedValue.ToString();

                if (Weight_Weitgh > Weight_Size)
                {
                    Weight_Helf = Weight_Weitgh.ToString();
                }
                else
                {
                    Weight_Helf = Weight_Size.ToString();
                }

                if (CBNoZero.IsChecked == true)
                {
                    if (float.Parse(Weight_Helf) == 0)
                    {
                        MessageBox.Show("重量大于零！");
                        return;
                    }
                }

                if (TBName.Tag == null || TBName.Tag.ToString() == "")
                {
                    //MessageBox.Show(TBName.Text + "  用户不存在请重新输入");
                    //TBName.Text = null;
                    //TBName.Focus();
                    //return;
                    Weight_UserId = "";
                }
                else
                {
                    Weight_UserId = TBName.Tag.ToString();
                }
                
                Weight_UserName = TBName.Text;

                sql = "select * from T_Weight as t1 where t1.Weight_ConID = '" + Weight_ConID + "'";
                ds = DBClass.execQuery(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {   
                    sql = "update T_Weight set Weight_Time = '{0}', Weight_Num = '{2}', Weight_Weitgh = '{3}', " +
                        "Weight_Note = '{4}',Weight_Shelf = '{5}',Weight_UserId = '{6}', " +
                        "Weight_UserName = '{7}', Weight_Size = '{8}', Weight_Helf = '{9}', Weight_WorkderId = '{10}', " +
                        "Weight_Region = '{11}', Weight_Pack = '{12}', Weight_NoteStaff = '{13}', " +
                        "Weight_OverLong = '{14}', Weight_OverHelf = '{15}' " +
                        "where Weight_ConID = '{1}'";
                    sql = string.Format(sql, Weight_Time, Weight_ConID, Weight_Num, Weight_Weitgh, Weight_Note, Weight_Shelf,
                    Weight_UserId, Weight_UserName, Weight_Size, Weight_Helf, staff_name, staff_region, Weight_Pack,
                    Weight_NoteStaff, Weight_OverLong, Weight_OverHelf);
                }
                else
                {
                    sql = "insert into T_Weight " +
                    "(Weight_Time,Weight_ConID,Weight_Num,Weight_Weitgh,Weight_Note,Weight_Shelf,Weight_UserId, " +
                    "Weight_UserName,Weight_Size,Weight_Helf,Weight_WorkderId, Id, Weight_Region, Weight_Pack, Weight_NoteStaff, " + 
                    "Weight_OverLong, Weight_OverHelf ) " +
                    "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}', '{14}', '{15}', '{16}')";
                    sql = string.Format(sql, Weight_Time, Weight_ConID, Weight_Num, Weight_Weitgh, Weight_Note, Weight_Shelf,
                    Weight_UserId, Weight_UserName, Weight_Size, Weight_Helf, staff_name, Id, staff_region, Weight_Pack,
                    Weight_NoteStaff, Weight_OverLong, Weight_OverHelf);
                }

                
                int n = DBClass.execUpdate(sql);
                if (n > 0)
                {
                    IsOK = true;
                }
                
            }catch(Exception e)
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
            sql = "select * from T_Weight as t1 where t1.Weight_WorkderId = '" + staff_name + "' " +
                "and t1.Weight_Type is null order by t1.Weight_Time ";
            ds = DBClass.execQuery(sql);
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("IsSelect", typeof(object)));
            dt.Columns.Add(new DataColumn("Weight_Time", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_ConID", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Num", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Weitgh", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Note", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Last", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Shelf", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_UserId", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_UserName", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Size", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Helf", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Pack", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Region", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_NoteStaff", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_OverLong", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_OverHelf", typeof(string)));
            

            if (ds.Tables[0].Rows.Count > 0 )
            {
                //给记录框赋值
                TBNum.Text = ds.Tables[0].Rows.Count.ToString();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                {
                    DataRow dr = dt.NewRow();
                    dr["IsSelect"] = false;
                    dr["Weight_Time"] = ds.Tables[0].Rows[i]["Weight_Time"];
                    dr["Weight_ConID"] = ds.Tables[0].Rows[i]["Weight_ConID"];
                    dr["Weight_Num"] = ds.Tables[0].Rows[i]["Weight_Num"];
                    dr["Weight_Weitgh"] = ds.Tables[0].Rows[i]["Weight_Weitgh"];
                    dr["Weight_Note"] = ds.Tables[0].Rows[i]["Weight_Note"];
                    dr["Weight_Last"] = ds.Tables[0].Rows[i]["Weight_Last"];
                    dr["Weight_Shelf"] = ds.Tables[0].Rows[i]["Weight_Shelf"];
                    dr["Weight_UserId"] = ds.Tables[0].Rows[i]["Weight_UserId"];
                    dr["Weight_UserName"] = ds.Tables[0].Rows[i]["Weight_UserName"];
                    dr["Weight_Size"] = ds.Tables[0].Rows[i]["Weight_Size"];
                    dr["Weight_Helf"] = ds.Tables[0].Rows[i]["Weight_Helf"];
                    dr["Weight_Pack"] = ds.Tables[0].Rows[i]["Weight_Pack"];
                    dr["Weight_Region"] = ds.Tables[0].Rows[i]["Weight_Region"];
                    dr["Weight_NoteStaff"] = ds.Tables[0].Rows[i]["Weight_NoteStaff"];
                    dr["Weight_OverLong"] = ds.Tables[0].Rows[i]["Weight_OverLong"];
                    dr["Weight_OverHelf"] = ds.Tables[0].Rows[i]["Weight_OverHelf"];
                                        
                    dt.Rows.Add(dr);
                }
                
            }
            this.DG1.CanUserAddRows = false;
            this.DG1.ItemsSource = dt.DefaultView;     
        }

        public void getShelf()
        {
            string sql = "";
            string tb_name = "";
            int type = 1; //1：小货区，2：大货区
            string shelf = "";
            DataSet ds = new DataSet();
            try
            {
                if (CBBigShelf.IsChecked == true)
                {
                    type = 2;
                }

                tb_name = TBName.Text;

                sql = "SELECT t1.user_shelf_big, t1.user_shelf_small from T_User as t1 " +
                    "where t1.tb_user = '" + tb_name + "' ";
                ds = DBClass.execQuery(sql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (type == 1)
                    {
                        shelf = ds.Tables[0].Rows[0][1].ToString();
                    }
                    else
                    {
                        shelf = ds.Tables[0].Rows[0][0].ToString();
                    }
                }

                if (shelf.Length > 0)
                {
                    TBShelf.Text = shelf;
                }
                else
                {
                    MessageBoxResult MBR = MessageBox.Show("该用户为新用户，是否为其自动分配一个货架？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information);

                    if (MBR == MessageBoxResult.Yes)
                    {
                        shelf = AutoShelf(type, tb_name);
                        TBShelf.Text = shelf;
                    }
                    else
                    {
                        //执行Cancel的代码
                    }

                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public string AutoShelf(int type, string tb_name)
        {
            string shelf = "";
            string sql = "", sql1 = "";
            DataSet ds = new DataSet();
            SqlConnection conn = DBClass.getConnection();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                sql = "select t1.shelf_name from T_Shelf as t1 " +
                    "where t1.shelf_status != 'Y' ";

                if (type == 1)
                {
                    sql += " and t1.shelf_type = '小货区' ";
                }
                else
                {
                    sql += " and t1.shelf_type = '大货区' ";
                }
                ds = DBClass.execQuery(sql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    shelf = ds.Tables[0].Rows[0][0].ToString();
                    if (type == 1)
                    {
                        sql1 = "update T_User set user_shelf_small = '" + shelf + "' " +
                            "where tb_user = '" + tb_name + "' ";
                    }
                    else
                    {
                        sql1 = "update T_User set user_shelf_big = '" + shelf + "' " +
                            "where tb_user = '" + tb_name + "' ";
                    }
                    int n = DBClass.execUpdate(conn, tran, sql1);
                    sql1 = "";
                    sql1 = "update T_Shelf set shelf_status = 'Y' " +
                        "where shelf_name = '" + shelf + "'";
                    n = DBClass.execUpdate(conn, tran, sql1);
                    tran.Commit();
                }
                else
                {
                    shelf = "";
                    if (type == 1)
                    {
                        MessageBox.Show("小货区-没有未分配的空货架，请创建后再进行操作");
                    }
                    else
                    {
                        MessageBox.Show("大货区-没有未分配的空货架，请创建后再进行操作");
                    }
                    
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);

            }

            return shelf;
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
        /// 运单编号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBtranId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (TBtranId.Text.Length >= 5)
                {
                    if (CBInputTime.IsChecked == false)
                    {
                        TBsacnTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    if (RBimportWeigh.IsChecked == true)
                    {
                        this.TBweigh.Focus();
                    }
                    else
                    {
                        this.TBName.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("运单编号不能为空且5位以上。");
                }

                
            }
        }

        /// <summary>
        /// 重量回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBweigh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.TBName.Focus();
            }
        }

        /// <summary>
        /// 限制输入字符为文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Num_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.]+");
            e.Handled = re.IsMatch(e.Text);
        }

        /// <summary>
        /// 屏蔽中文输入和非法字符粘贴输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Num_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TextChange[] change = new TextChange[e.Changes.Count];
            e.Changes.CopyTo(change, 0);

            int offset = change[0].Offset;
            if (change[0].AddedLength > 0)
            {
                double num = 0;
                if (!Double.TryParse(textBox.Text, out num))
                {
                    textBox.Text = textBox.Text.Remove(offset, change[0].AddedLength);
                    textBox.Select(offset, 0);
                }
            }
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
                getShelf();
                TBShelf.SelectionStart = TBShelf.Text.Length;
                this.TBShelf.Focus();                
            }
        }

        private void CBInputTime_Checked(object sender, RoutedEventArgs e)
        {
            TBsacnTime.Enabled = true;
            MessageBox.Show("手动输入扫描时间已开启");
        }

        private void CBInputTime_Unchecked(object sender, RoutedEventArgs e)
        {
            TBsacnTime.Enabled = false;
            MessageBox.Show("扫描时间为默认获取");
        }


        private void CBNoZero_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("默认重量大于 0 ");
        }

        private void CBNoZero_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("默认重量大于 0 取消");
        }

        /// <summary>
        /// 备注回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                inputDB();
                getTableData();
                if (IsOK == true)
                {
                    TBNumber.Text = "1";
                    if (CBlastName.IsChecked == false)
                    {
                        TBName.Text = null;
                        TBName.Tag = null;
                    }                  
                    TBNote.Clear();
                    TBNoteStaff.Clear();
                    TBShelf.Clear();
                    TBSize.Clear();
                    TBtranId.Clear();
                    TBweigh.Clear();
                    CBHelf.IsChecked = false;
                    CBLong.IsChecked = false;
                    TBtranId.Focus();
                    IsOK = false;
                    Weight_Size = 0;
                }
                

            }
        }

        private void BTNSave_Click(object sender, RoutedEventArgs e)
        {
            string sql = "";
            sql = "select t1.id, t1.Weight_UserName, t1.Web_TBId " + 
                " from t_weight as t1 " + 
                " where t1.Weight_WorkderId = '" + staff_name + "' " +
                " and t1.Weight_Type is null order by t1.Weight_Time ";

            DataSet ds = new DataSet();
            ds = DBClass.execQuery(sql);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            string N_ID = "(''";
            string Y_ID = "(''";

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Weight_tb = dt.Rows[i][1].ToString();
                    string Web_tb = dt.Rows[i][2].ToString();

                    if (Weight_tb.Equals(Web_tb))
                    {
                        Y_ID += ",'" + dt.Rows[i][0].ToString() + "'";
                    }
                    else
                    {
                        N_ID += ",'" + dt.Rows[i][0].ToString() + "'";
                    }
                }
            }

            Y_ID += ")";
            N_ID += ")";
            
            sql = "update T_Weight set Weight_Type = 'N' " +
                "where id in " + N_ID;

            sql += " ; update T_Weight set Weight_Type = 'Y' " +
                "where id in " + Y_ID;
            int n = DBClass.execUpdate(sql);
            if (n > 0)
            {
                MessageBox.Show("保存成功！");
                TBNum.Text = "0";
                getTableData();
            }
        }

        private void BTNDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();
                bool isCheck = false;
                string str = "";

                sql = "select * from T_Weight as t1 where t1.Weight_WorkderId = '" + staff_name + "' " +
                    "and t1.Weight_Type is null order by t1.Weight_Time ";
                ds = DBClass.execQuery(sql);

                str = "(''";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    isCheck = false;
                    isCheck = bool.Parse(BaseClass.GetCheckBoxValue(i, 0, this.DG1));
                    if (isCheck == true)
                    {
                        str += ",'" + ds.Tables[0].Rows[i]["Weight_ConID"].ToString() +"'";
                    }
                }
                str += ")";
                sql = "delete T_Weight where Weight_ConID in " + str;
                int n = DBClass.execUpdate(sql);
                if (n > 0)
                {
                    MessageBox.Show("删除成功！");
                }

                getTableData();
            }
            catch (Exception e1)
            {
                MessageBox.Show("删除失败！" + e1.Message);
            }

        }

        private void TBLength_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TBWidth.Focus();
            }
        }

        private void TBWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TBHeight.Focus();
            }
        }

        private void TBHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {              
                float Size = 0;
                //台湾仓
                if (staff_region == "1")
                {
                    Size = float.Parse(TBLength.Text) * float.Parse(TBWidth.Text) * float.Parse(TBHeight.Text) / 6000;
                    if (TBweigh.Text != "")
                    {
                        Size = (Size + float.Parse(TBweigh.Text)) / 2;
                    }
                    
                }

                //香港仓
                if (staff_region == "2")
                {
                    Size = float.Parse(TBLength.Text) * float.Parse(TBWidth.Text) * float.Parse(TBHeight.Text) / 6000;
                }

                TBSize.Text = Size.ToString();
                TBNote.Text += " 【" + TBLength.Text + "*" + TBWidth.Text + "*" + TBHeight.Text + "=" + Size + "】 ";

                Weight_Size += Size;
                TBNote.Focus();

                //清空数据
                TBWidth.Clear();
                TBLength.Clear();
                TBHeight.Clear();
                TBSize.Clear();
            }
        }

        private void TBNoteStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TBNote.Focus();
            }
        }

        private void TBShelf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TBNote.Focus();
            }
        }

        private void DG1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void CBBigShelf_Checked(object sender, RoutedEventArgs e)
        {
            if (CBBigShelf.IsChecked == true)
            {
                CBSmallShelf.IsChecked = false;
            }
        }

        private void CBSmallShelf_Checked(object sender, RoutedEventArgs e)
        {
            if (CBSmallShelf.IsChecked == true)
            {
                CBBigShelf.IsChecked = false;
            }
        }

        private void BTNAutoShelf_Click(object sender, RoutedEventArgs e)
        {
            string shelf = "", tb_name = "";
            int type = 1;
            if (CBBigShelf.IsChecked == true)
            {
                type = 2;
            }

            tb_name = TBName.Text;
            shelf = AutoShelf(type, tb_name);
            TBShelf.Text = shelf;
        }


        




    

    }
}
