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
            if (Application.Current.Properties["region"] != null)
            {
                staff_region = Application.Current.Properties["region"].ToString();
            }

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
                if (TBName.Tag == null || TBName.Tag.ToString() == "")
                {
                    //sql1 = "select * from "
                    MessageBox.Show(TBName.Text + "  用户不存在请重新输入");
                    TBName.Text = null;
                    TBName.Focus();
                    return;
                }
                else
                {
                    Weight_UserId = TBName.Tag.ToString();
                }
                
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
                    "Weight_UserName,Weight_Size,Weight_Helf,Weight_WorkderId, Id, Weight_Region) " +
                    "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')";
                }

                sql = string.Format(sql, Weight_Time, Weight_ConID, Weight_Num, Weight_Weitgh, Weight_Note, Weight_Last, Weight_Shelf,
                    Weight_UserId, Weight_UserName, Weight_Size, Weight_Helf, staff_name, Id, staff_region);
                int n = DBClass.execUpdate(sql);
                if (n > 0)
                {
                    IsOK = true;
                }
                
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
            sql = "select * from T_Weight as t1 where t1.Weight_WorkderId = '" + staff_name + "' " +
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
            this.TBName.AddItemSource(tlist);
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
                if (IsOK == true)
                {                   
                    TBlastStand.Clear();
                    TBName.Text = null;
                    TBName.Tag = null;
                    TBNote.Clear();
                    TBShelf.Clear();
                    TBSize.Clear();
                    TBtranId.Clear();
                    TBweigh.Clear();

                    TBtranId.Focus();
                    IsOK = false;
                }
                

            }
        }

        private void BTNSave_Click(object sender, RoutedEventArgs e)
        {
            string sql = "";
            sql = "update T_Weight set Weight_Type = 'N' " +
                "where Weight_Type is null " +
                "and Weight_WorkderId = '" + staff_name + "'";
            int n = DBClass.execUpdate(sql);
            if (n > 0)
            {
                MessageBox.Show("保存成功！");
                getTableData();
            }
        }

        private void BTNDelete_Click(object sender, RoutedEventArgs e)
        {
            string sql = "";
            DataSet ds = new DataSet();
            sql = "select * from T_Weight as t1 where t1.Weight_WorkderId = '" + staff_name + "' " +
                "and t1.Weight_Type is null";
            ds = DBClass.execQuery(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
            {
                string str = GetCheckBoxValue(i, 0);
            }
        }

        /// <summary>
        /// 得到CheckBox里的值
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="cellIndex">列索引</param>
        /// <returns>CheckBox里的值</returns>
        private string GetCheckBoxValue(int rowIndex, int cellIndex)
        {
            var obj = VisualTreeHelper.GetChild((ContentPresenter)GetDataGridCell(rowIndex, cellIndex).Content, 0);
            CheckBox chk = null;
            if (obj != null && obj.DependencyObjectType.Name == "CheckBox")
            {
                chk = (CheckBox)obj;
            }
            return chk.IsChecked.ToString();
        }

        /// <summary>
        /// 得到DataGrid的一个单元格
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="cellIndex">列索引</param>
        /// <returns></returns>
        private DataGridCell GetDataGridCell(int rowIndex, int cellIndex)
        {
            DataGridRow row = (DataGridRow)DG1.ItemContainerGenerator.ContainerFromIndex(rowIndex);
            DG1.UpdateLayout();
            row = (DataGridRow)DG1.ItemContainerGenerator.ContainerFromIndex(rowIndex);
            DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(cellIndex);
            DG1.ScrollIntoView(row, DG1.Columns[cellIndex]);
            cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(cellIndex);

            return cell;
        }

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T childContent = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                childContent = v as T;
                if (childContent == null)
                {
                    childContent = GetVisualChild<T>(v);
                }
                if (childContent != null)
                {
                    break;
                }
            }
            return childContent;
        }

    }
}
