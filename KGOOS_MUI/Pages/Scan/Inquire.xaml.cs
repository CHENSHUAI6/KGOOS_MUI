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
    /// Interaction logic for Inquire.xaml
    /// </summary>
    public partial class Inquire : UserControl
    {

        private List<WeightModel> _WeightList;
        private string staff_name = "";
        private string staff_region = "";
        public List<WeightModel> WeightList
        {
            get { return _WeightList; }
            set
            {
                _WeightList = value;
            }
        }

        public Inquire()
        {
            InitializeComponent();
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
            TBStartTime.Text = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd HH:mm:ss");
            getAutoCompleteTextBox();
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
        /// 表格获取值
        /// </summary>
        public void getTableData()
        {
            string sql = "";
            DataSet ds = new DataSet();

            string str = TBID.Text;
            string[] sArrayID = Regex.Split(str, "\r\n", RegexOptions.IgnoreCase);
            string starTime = TBStartTime.Text;
            string endTime = TBEndTime.Text;

            
            int num = int.Parse(TBReturnNum.Text);
            

            bool IsExist = false;

            str = BaseClass.getSqlValue(sArrayID);

            sql = "select top " + num + " * from T_Weight as t1 " +
                "join T_Staff as t2 on t2.name_staff = t1.Weight_WorkderId " +
                "join T_Region as t3 on t3.Region_Id = t2.Region_staff " +
                "where t1.Weight_Type is not null " +
                "and t1.Weight_WorkderId = '"+staff_name+"'";

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

            if (TBScan != null && TBScan.Text != "")
            {
                string scan = TBScan.Text;
                sql += " and t1.Weight_WorkderId = '" + scan + "' ";
            }
                        
            string type = TBType.Text;

            
            if (CBID.IsChecked == true)
            {
                sql += "and t1.Weight_ConID in " + str + " ";
            }
            else
            {
                sql += "and t1.Weight_Time between '" + starTime + "' and '" + endTime + "'";
            }
         
            ds = DBClass.execQuery(sql);

            WeightList = new List<WeightModel>();
            
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string Weight_Type = "";
                    SolidColorBrush WeightColor = Brushes.Black;

                    if (ds.Tables[0].Rows[i]["Weight_Type"].ToString() == "N")
                        {
                            Weight_Type = "已到件";
                        }
                    if (double.Parse(ds.Tables[0].Rows[i]["Weight_Helf"].ToString()) > double.Parse(ds.Tables[0].Rows[i]["Weight_Weitgh"].ToString()))
                    {
                        WeightColor = Brushes.Red;
                    }

                    WeightList.Add(new WeightModel()
                    {
                        Checking = false,
                        Id = ds.Tables[0].Rows[i]["Id"].ToString(),
                        Weight_ConID = ds.Tables[0].Rows[i]["Weight_ConID"].ToString(),
                        Weight_Type = Weight_Type,
                        Weight_Last = ds.Tables[0].Rows[i]["Weight_Last"].ToString(),
                        Weight_WorkderId = ds.Tables[0].Rows[i]["Weight_WorkderId"].ToString(),
                        Weight_Time = ds.Tables[0].Rows[i]["Weight_Time"].ToString(),
                        Weight_Helf = ds.Tables[0].Rows[i]["Weight_Helf"].ToString(),
                        Weight_Num = ds.Tables[0].Rows[i]["Weight_Num"].ToString(),
                        Weight_Shelf = ds.Tables[0].Rows[i]["Weight_Shelf"].ToString(),
                        Weight_Note = ds.Tables[0].Rows[i]["Weight_Note"].ToString(),
                        Weight_UserId = ds.Tables[0].Rows[i]["Weight_UserId"].ToString(),
                        Weight_UserName = ds.Tables[0].Rows[i]["Weight_UserName"].ToString(),
                        Weight_Weitgh = ds.Tables[0].Rows[i]["Weight_Weitgh"].ToString(),
                        Weight_Pack = ds.Tables[0].Rows[i]["Weight_Pack"].ToString(),
                        Weight_Region = ds.Tables[0].Rows[i]["Weight_Region"].ToString(),
                        Weight_NoteStaff = ds.Tables[0].Rows[i]["Weight_NoteStaff"].ToString(),
                        Weight_ConTranId = ds.Tables[0].Rows[i]["Weight_ConTranId"].ToString(),
                        Weight_OverLong = ds.Tables[0].Rows[i]["Weight_OverLong"].ToString(),
                        Weight_OverHelf = ds.Tables[0].Rows[i]["Weight_OverHelf"].ToString(),
                        WeightColor = WeightColor
                    });
                }
            }

            str = "";
            for (int i = 0; i < sArrayID.Length; i++ )
            {
                IsExist = false;
                for (int j =0; j < ds.Tables[0].Rows.Count; j++)
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

            this.NoID.Text = str;
            this.DG1.CanUserAddRows = false;
            this.DG1.ItemsSource = WeightList;

            //创建数据源、绑定数据源

            if (!Window.GetWindow(DG1).IsVisible)
            {
                Window.GetWindow(DG1).Show();
            }
            DG1.UpdateLayout();

            for (int i = 0; i < this.DG1.Items.Count; i++)
            {
                DataGridRow row = (DataGridRow)this.DG1.ItemContainerGenerator.ContainerFromIndex(i);

                DataGridCellsPresenter presenter = BaseClass.GetVisualChild<DataGridCellsPresenter>(row);
                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(3);

                string strCell = "";
                TextBlock tbStr = (TextBlock)cell.Content;
                strCell = tbStr.Text.ToString();
                switch (strCell)
                {
                    case "已到件": row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9FF59F"));                       
                        break;
                }
            }
        }
        
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            NoID.Clear();
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

        
    }
}
