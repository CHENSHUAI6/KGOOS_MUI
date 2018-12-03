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
    /// Interaction logic for Arrive.xaml
    /// </summary>
    public partial class Arrive : UserControl
    {
        //private List<WeightModel> _WeightList;
        //public List<WeightModel> WeightList
        //{
        //    get { return _WeightList; }
        //    set
        //    {
        //        _WeightList = value;
        //    }
        //}

        private int dou_text_cases = 0;
        private double dou_text_helf = 0, dou_text_weight = 0, dou_text_size = 0;

        public DataTable TableData;

        public Arrive()
        {
            InitializeComponent();
            getAutoCompleteTextBox();
            TBStartTime.Text = DateTime.Now.AddDays(-31).ToString("yyyy-MM-dd HH:mm:ss");

        }

        /// <summary>
        /// 表格获取值SQL
        /// </summary>
        public string getTableSql()
        {
            string sql = "";

            string str = TBID.Text;
            string[] sArrayID = Regex.Split(str, "\r\n", RegexOptions.IgnoreCase);
            string starTime = TBStartTime.Text;
            string endTime = TBEndTime.Text;

            int num = int.Parse(TBReturnNum.Text);

            str = BaseClass.getSqlValue(sArrayID);

            sql = "select top " + num + " * from T_Weight as t1 " +
                "join T_Staff as t2 on t2.name_staff = t1.Weight_WorkderId " +
                "join T_Region as t3 on t3.Region_Id = t2.Region_staff " +
                "left join T_Order as t4 on t4.id = t1.Order_id " +
                "where t1.Weight_Type is not null ";

            if (TBPlant != null && TBPlant.Text != "")
            {
                string plant = TBPlant.Text;
                sql += " and t3.Region_Id = '" + plant + "' ";
            }

            if (TBName != null && TBName.Text != "")
            {
                string name = TBName.Text;
                sql += " and t1.Weight_UserName = '" + name + "' ";
            }

            if (TBlastStand != null && TBlastStand.Text != "")
            {
                string lastStand = TBlastStand.Text;
                sql += " and t1.Weight_Last = '" + lastStand + "' ";
            }

            string type = TBType.Text;


            if (CBID.IsChecked == true)
            {
                sql += "and t1.Weight_ConID in " + str + " ";
            }
            else
            {
                sql += "and t1.Weight_Time between '" + starTime + "' and '" + endTime + "' ";
            }


            if (RB_Pack.IsChecked == true)
            {
                sql += " and t1.Weight_Type = 'D' ";
            }
            else if (RB_Arrive.IsChecked == true)
            {
                sql += " and (t1.Weight_Type = 'Y' or t1.Weight_Type = 'N') ";
            }
            else if (RB_Apply.IsChecked == true)
            {
                sql += " and t1.Weight_Type = 'S' ";
            }
            else if (RB_Difference.IsChecked == true)
            {
                sql += " and t1.Web_UserId <> t1.Weight_UserId ";
            }

            sql += " order by t1.Weight_Time desc";
            return sql;
        }

        /// <summary>
        /// 表格获取值
        /// </summary>
        public void getTableData()
        {
            string sql = "";
            DataSet ds = new DataSet();
            bool IsExist = false;
            string str = TBID.Text;
            string[] sArrayID = Regex.Split(str, "\r\n", RegexOptions.IgnoreCase);

            sql = getTableSql();
            ds = DBClass.execQuery(sql);

            //WeightList = new List<WeightModel>();

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Select", typeof(bool)));
            dt.Columns.Add(new DataColumn("n_num", typeof(string)));
            dt.Columns.Add(new DataColumn("Checking", typeof(bool)));
            dt.Columns.Add(new DataColumn("Id", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_ConID", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Last", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_WorkderId", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Time", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Helf", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Size", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_OverLong", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_OverHelf", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Num", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Shelf", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Note", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_UserId", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_UserName", typeof(string)));
            dt.Columns.Add(new DataColumn("Web_TBId", typeof(string)));         
            dt.Columns.Add(new DataColumn("Weight_Weitgh", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Pack", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Region", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_NoteStaff", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_ConTranId", typeof(string)));
            dt.Columns.Add(new DataColumn("order_time", typeof(string)));           
            dt.Columns.Add(new DataColumn("WeightColor", typeof(string)));
            dt.Columns.Add(new DataColumn("TBColor", typeof(string)));
            
            if (ds.Tables[0].Rows.Count > 0)
            {              
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    DataRow dr = dt.NewRow();

                    string Weight_Type = "";
                    SolidColorBrush WeightColor = Brushes.Black;
                    SolidColorBrush TBColor = Brushes.Black;

                    if (ds.Tables[0].Rows[i]["Weight_Type"].ToString() == "N" || ds.Tables[0].Rows[i]["Weight_Type"].ToString() == "Y")
                    {
                        Weight_Type = "已到件";
                    }
                    else if (ds.Tables[0].Rows[i]["Weight_Type"].ToString() == "S")
                    {
                        Weight_Type = "已申请";
                    }
                    else if (ds.Tables[0].Rows[i]["Weight_Type"].ToString() == "D")
                    {
                        Weight_Type = "已打包";
                    }
                    else if (ds.Tables[0].Rows[i]["Weight_Type"].ToString() == "F")
                    {
                        Weight_Type = "已发件";
                    }

                    if (double.Parse(ds.Tables[0].Rows[i]["Weight_Helf"].ToString()) > double.Parse(ds.Tables[0].Rows[i]["Weight_Weitgh"].ToString()))
                    {
                        WeightColor = Brushes.Red;
                    }
                    if (ds.Tables[0].Rows[i]["Weight_UserName"].ToString().Equals(ds.Tables[0].Rows[i]["Web_TBId"].ToString()))
                    {
                        TBColor = Brushes.Black;
                    }
                    else
                    {
                        TBColor = Brushes.Red;
                    }

                    dr["Select"] = false;
                    dr["n_num"] = i + 1;
                    dr["Checking"] = false;
                    dr["Id"] = ds.Tables[0].Rows[i]["Id"].ToString();
                    dr["Weight_ConID"] = ds.Tables[0].Rows[i]["Weight_ConID"].ToString();
                    dr["Weight_Type"] = Weight_Type;
                    dr["Weight_Last"] = ds.Tables[0].Rows[i]["Weight_Last"].ToString();
                    dr["Weight_WorkderId"] = ds.Tables[0].Rows[i]["Weight_WorkderId"].ToString();
                    dr["Weight_Time"] = ds.Tables[0].Rows[i]["Weight_Time"].ToString();
                    dr["Weight_Helf"] = ds.Tables[0].Rows[i]["Weight_Helf"].ToString();
                    dr["Weight_Size"] = ds.Tables[0].Rows[i]["Weight_Size"].ToString();
                    dr["Weight_OverLong"] = ds.Tables[0].Rows[i]["Weight_OverLong"].ToString();
                    dr["Weight_OverHelf"] = ds.Tables[0].Rows[i]["Weight_OverHelf"].ToString();
                    dr["Weight_Num"] = ds.Tables[0].Rows[i]["Weight_Num"].ToString();
                    dr["Weight_Shelf"] = ds.Tables[0].Rows[i]["Weight_Shelf"].ToString();
                    dr["Weight_Note"] = ds.Tables[0].Rows[i]["Weight_Note"].ToString();
                    dr["Weight_UserId"] = ds.Tables[0].Rows[i]["Weight_UserId"].ToString();
                    dr["Weight_UserName"] = ds.Tables[0].Rows[i]["Weight_UserName"].ToString();
                    dr["Web_TBId"] = ds.Tables[0].Rows[i]["Web_TBId"].ToString();
                    dr["Weight_Weitgh"] = ds.Tables[0].Rows[i]["Weight_Weitgh"].ToString();
                    dr["Weight_Pack"] = ds.Tables[0].Rows[i]["Weight_Pack"].ToString();
                    dr["Weight_Region"] = ds.Tables[0].Rows[i]["Weight_Region"].ToString();
                    dr["Weight_NoteStaff"] = ds.Tables[0].Rows[i]["Weight_NoteStaff"].ToString();
                    dr["Weight_ConTranId"] = ds.Tables[0].Rows[i]["Con_Express_Id"].ToString();
                    dr["order_time"] = ds.Tables[0].Rows[i]["order_time"].ToString();                   
                    dr["WeightColor"] = WeightColor;
                    dr["TBColor"] = TBColor;
                    dt.Rows.Add(dr);

                    try
                    {
                        dou_text_cases += int.Parse(ds.Tables[0].Rows[i]["Weight_Num"].ToString());

                    }
                    catch (Exception e1) { }

                    try
                    {
                        dou_text_helf += double.Parse(ds.Tables[0].Rows[i]["Weight_Helf"].ToString());

                    }
                    catch (Exception e1) { }

                    try
                    {
                        dou_text_weight += double.Parse(ds.Tables[0].Rows[i]["Weight_Weitgh"].ToString());

                    }
                    catch (Exception e1) { }

                    try
                    {
                        dou_text_size += double.Parse(ds.Tables[0].Rows[i]["Weight_Size"].ToString());

                    }
                    catch (Exception e1) { }
                   
                    //WeightList.Add(new WeightModel()
                    //{
                    //    Checking = false,
                    //    Id = ds.Tables[0].Rows[i]["Id"].ToString(),
                    //    Weight_ConID = ds.Tables[0].Rows[i]["Weight_ConID"].ToString(),
                    //    Weight_Type = Weight_Type,
                    //    Weight_Last = ds.Tables[0].Rows[i]["Weight_Last"].ToString(),
                    //    Weight_WorkderId = ds.Tables[0].Rows[i]["Weight_WorkderId"].ToString(),
                    //    Weight_Time = ds.Tables[0].Rows[i]["Weight_Time"].ToString(),
                    //    Weight_Helf = ds.Tables[0].Rows[i]["Weight_Helf"].ToString(),
                    //    Weight_Num = ds.Tables[0].Rows[i]["Weight_Num"].ToString(),
                    //    Weight_Shelf = ds.Tables[0].Rows[i]["Weight_Shelf"].ToString(),
                    //    Weight_Note = ds.Tables[0].Rows[i]["Weight_Note"].ToString(),
                    //    Weight_UserId = ds.Tables[0].Rows[i]["Weight_UserId"].ToString(),
                    //    Weight_UserName = ds.Tables[0].Rows[i]["Weight_UserName"].ToString(),
                    //    Weight_Weitgh = ds.Tables[0].Rows[i]["Weight_Weitgh"].ToString(),
                    //    Weight_Pack = ds.Tables[0].Rows[i]["Weight_Pack"].ToString(),
                    //    Weight_Region = ds.Tables[0].Rows[i]["Weight_Region"].ToString(),
                    //    Weight_NoteStaff = ds.Tables[0].Rows[i]["Weight_NoteStaff"].ToString(),
                    //    Weight_ConTranId = ds.Tables[0].Rows[i]["Weight_ConTranId"].ToString(),
                    //    WeightColor = WeightColor
                    //});
                }
            }

            str = "";
            for (int i = 0; i < sArrayID.Length; i++)
            {
                IsExist = false;
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    if (sArrayID[i].Trim().Equals(ds.Tables[0].Rows[j]["Weight_ConID"]))
                    {
                        IsExist = true;
                    }
                }
                if (IsExist == false)
                {
                    str += sArrayID[i].Trim() + "\r\n";
                }
            }

            TableData = new DataTable();
            TableData = dt;

            this.NoID.Text = str;
            this.DG1.CanUserAddRows = false;
            this.DG1.ItemsSource = TableData.DefaultView;

            if (!Window.GetWindow(DG1).IsVisible)
            {
                Window.GetWindow(DG1).Show();
            }
            DG1.UpdateLayout();

            text_record.Text = "记录数:" + TableData.Rows.Count;
            text_cases.Text = "总件数:" + dou_text_cases.ToString();
            text_helf.Text = "总重量:" + dou_text_helf.ToString("0.00");
            text_weight.Text = "总秤重:" + dou_text_weight.ToString("0.00");
            text_size.Text = "总体积重:" + dou_text_size.ToString("0.00");

            //for (int i = 0; i < this.DG1.Items.Count; i++)
            //{
            //    DataGridRow row = (DataGridRow)this.DG1.ItemContainerGenerator.ContainerFromIndex(i);

            //    DataGridCellsPresenter presenter = BaseClass.GetVisualChild<DataGridCellsPresenter>(row);
            //    DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(3);

            //    string strCell = "";
            //    TextBlock tbStr = (TextBlock)cell.Content;
            //    strCell = tbStr.Text.ToString();
            //    switch (strCell)
            //    {
            //        case "已到件": row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9FF59F"));
            //            break;
            //    }
            //}
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            getTableData();
        }

        private void CBID_Checked(object sender, RoutedEventArgs e)
        {
            TBStartTime.Enabled = false;
            TBEndTime.Enabled = false;
        }

        private void CBID_Unchecked(object sender, RoutedEventArgs e)
        {
            TBStartTime.Enabled = true;
            TBEndTime.Enabled = true;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TBID.Clear();
        }

        private void BtnPack_Click(object sender, RoutedEventArgs e)
        {
            bool isCheck = false;
            string str = "";

            try
            {
                str = "(''";

                if (this.DG1.ItemsSource == null)
                {
                    MessageBox.Show("请先获取清单再申请打包");
                }
                else
                {
                    int n = 0;
                    for (int i = 0; i < TableData.Rows.Count; i++)
                    {
                        isCheck = false;
                        isCheck = bool.Parse(TableData.Rows[i]["Select"].ToString());
                        if (isCheck == true)
                        {
                            n++;
                            str += ",'" + TableData.Rows[i]["Weight_ConID"].ToString() + "'";
                        }
                    }
                    str += ")";

                    if (n > 0)
                    {
                        Application.Current.Properties["weightIdList"] = str;

                        UpWindow uw = new UpWindow();
                        uw.ContentSource = new Uri("/Pages/Up/Packer.xaml", UriKind.Relative);
                        uw.Show();
                    }
                    else
                    {
                        MessageBox.Show("请勾选要打包的包裹");
                    }

                }

            }
            catch (Exception e1)
            {
                MessageBox.Show("系统错误: " + e1.Message);
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

        private void DG1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;

            var drv = e.Row.Item as DataRowView;
            switch (drv["Weight_Type"].ToString())
            {
                case "已发件": e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9FF59F"));
                    break;
                case "已打包": e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1FF83"));
                    break;
                case "已到件": e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A8F7E4"));
                    break;
                case "已申请": e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A8C2F7"));
                    break;

            }
        }

        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < TableData.Rows.Count; i++)
            {
                TableData.Rows[i]["Select"] = true;                
            }
            this.DG1.CanUserAddRows = false;
            this.DG1.ItemsSource = TableData.DefaultView;
        }

        private void InvertSelect_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < TableData.Rows.Count; i++)
            {
                if (bool.Parse(TableData.Rows[i]["Select"].ToString()) == true)
                {
                    TableData.Rows[i]["Select"] = false;

                }
                else
                {
                    TableData.Rows[i]["Select"] = true;

                }                
            }
            this.DG1.CanUserAddRows = false;
            this.DG1.ItemsSource = TableData.DefaultView;
        }

        private void CBSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TableData = BaseClass.TB_CheckBox_Click(sender, TableData, "Id", "Select");
                this.DG1.CanUserAddRows = false;
                this.DG1.ItemsSource = TableData.DefaultView;
            }
            catch(Exception e1)
            {

            }
        }

        private void CBCheck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TableData = BaseClass.TB_CheckBox_Click(sender, TableData, "Id", "Checking");
                this.DG1.CanUserAddRows = false;
                this.DG1.ItemsSource = TableData.DefaultView;
            }
            catch (Exception e1)
            {

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RB_Difference.IsChecked = false;
            RB_Pack.IsChecked = false;
            RB_Arrive.IsChecked = false;
            RB_Apply.IsChecked = false;
        }
    }
}
