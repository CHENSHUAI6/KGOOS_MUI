using KGOOS_MUI.Common;
using KGOOS_MUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace KGOOS_MUI.Pages.Scan
{
    /// <summary>
    /// Interaction logic for Weight.xaml
    /// </summary>
    public partial class Weigh : UserControl
    {
        /// <summary>
        /// 无用，待删除
        /// </summary>
        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public bool IsMember { get; set; }
        }
        private string workerId = "";
        public Weigh()
        {
            InitializeComponent();
            initialize();
            //ObservableCollection<Customer> custdata = GetData();

            //Bind the DataGrid to the customer data
            //DG1.DataContext = custdata;

            #region 下拉联想框数据导入（已注掉）
            //List<AutoCompleteEntry> tlist = new List<AutoCompleteEntry>();
            //tlist.Add(new AutoCompleteEntry("第九人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第八人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第七人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第五人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第九人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第八人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第七人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第五人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第九人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第八人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第七人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第五人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第九人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第八人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第七人民医院", null));
            //tlist.Add(new AutoCompleteEntry("第五人民医院", null));
            //this.TBName.AddItemSource(tlist);
            #endregion

            //colorDG();
        }

        /// <summary>
        /// 自定义初始化函数
        /// </summary>
        public void initialize()
        {
            workerId = "chy";
            getTableData();
        }

        /// <summary>
        /// 写入数据库
        /// </summary>
        public void inputDB()
        {
            try
            {
                string sql = "";
                string Weight_Time, Id, Weight_Num, Weight_Weitgh, Weight_Note, Weight_Last, Weight_Shelf,
                    Weight_UserId, Weight_UserName, Weight_Size, Weight_Helf, Weight_ConID;
                DataSet ds = new DataSet();
                if (CBInputTime.IsChecked == true)
                {
                    Weight_Time = TBsacnTime.Value.ToString();
                }
                else
                {
                    Weight_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                Id = BaseClass.getInsertMaxId("T_Weight", "Id", "000001");
                Weight_ConID = TBtranId.Text;
                Weight_Num = "0";
                Weight_Weitgh = TBweigh.Text;
                Weight_Note = TBNote.Text;
                Weight_Last = TBlastStand.Text;
                Weight_Shelf = TBShelf.Text;
                Weight_UserId = TBName.Text;
                Weight_UserName = TBName.Text;
                Weight_Size = TBSize.Text;
                Weight_Helf = "10";
                sql = "select * from T_Weight as t1 where t1.Weight_ConID = '" + Weight_ConID + "'";
                ds = DBClass.execQuery(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sql = "update T_Weight set Weight_Time = '{0}', Weight_Num = '{2}', Weight_Weitgh = '{3}', " +
                        "Weight_Note = '{4}', Weight_Last = '{5}',Weight_Shelf = '{6}',Weight_UserId = '{7}', " +
                        "Weight_UserName = '{8}', Weight_Size = '{9}', Weight_Helf = '{10}', Weight_WorkderId = '{11}' " +
                        "where Weight_ConID = '{1}'";
                }
                else
                {
                    sql = "insert into T_Weight " +
                    "(Weight_Time,Weight_ConID,Weight_Num,Weight_Weitgh,Weight_Note,Weight_Last,Weight_Shelf,Weight_UserId, " +
                    "Weight_UserName,Weight_Size,Weight_Helf,Weight_WorkderId, Id) " +
                    "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')";
                }

                sql = string.Format(sql, Weight_Time, Weight_ConID, Weight_Num, Weight_Weitgh, Weight_Note, Weight_Last, Weight_Shelf,
                    Weight_UserId, Weight_UserName, Weight_Size, Weight_Helf, workerId, Id);
                int n = DBClass.execUpdate(sql);
            }catch(Exception e)
            {
                MessageBox.Show("操作失败。请重试");
            }
            

        }


        /// <summary>
        /// datagrid赋值
        /// </summary>
        public void getTableData()
        {
            string sql = "";
            DataSet ds = new DataSet();
            sql = "select * from T_Weight as t1 where t1.Weight_WorkderId = '" + workerId + "' " +
                "and t1.Weight_Type is null";
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
                    dt.Rows.Add(dr);
                }
                
            }
            this.DG1.CanUserAddRows = false;
            this.DG1.ItemsSource = dt.DefaultView;     
        }

        /// <summary>
        /// 表格默认加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DG1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //e.Row.Header = e.Row.GetIndex() + 1;
            //var drv = e.Row.Item as DataRowView;
            //switch (drv["Id"].ToString())
            //{
            //    case "1": e.Row.Background = new SolidColorBrush(Colors.Green);
            //        break;
            //    case "2": e.Row.Background = new SolidColorBrush(Colors.Yellow);
            //        break;
            //    case "3": e.Row.Background = new SolidColorBrush(Colors.CadetBlue);
            //        break;
            //}
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
                if (RBimportWeigh.IsChecked == true)
                {
                    this.TBweigh.Focus();
                }
                else
                {
                    this.TBName.Focus();
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
            Regex re = new Regex("[^0-9.-]+");
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
                this.TBNote.Focus();

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
            }
        }

        private void BTNSave_Click(object sender, RoutedEventArgs e)
        {
            string sql = "";
            sql = "update T_Weight set Weight_Type = 'N' " +
                "where Weight_Type is null " +
                "and Weight_WorkderId = '" + workerId + "'";
            int n = DBClass.execUpdate(sql);
            if (n > 0)
            {
                MessageBox.Show("保存成功！");
                getTableData();
            }
        }


    }
}
