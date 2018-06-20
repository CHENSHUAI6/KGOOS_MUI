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
        private List<WeightModel> _WeightList;
        public List<WeightModel> WeightList
        {
            get { return _WeightList; }
            set
            {
                _WeightList = value;
            }
        }

        public Arrive()
        {
            InitializeComponent();
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
                sql += "and t1.Weight_Time between '" + starTime + "' and '" + endTime + "'";
            }
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
                    else if (ds.Tables[0].Rows[i]["Weight_Type"].ToString() == "D")
                    {
                        Weight_Type = "已打包";
                    }
                    else if (ds.Tables[0].Rows[i]["Weight_Type"].ToString() == "F")
                    {
                        Weight_Type = "已发件";
                    }
                    else
                    {
                        Weight_Type = "已申请";
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
                        WeightColor = WeightColor
                    });
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

            this.NoID.Text = str;
            this.DG1.CanUserAddRows = false;
            this.DG1.ItemsSource = WeightList;

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
            string sql = "";
            DataSet ds = new DataSet();
            bool isCheck = false;
            string str = "";

            try
            {
                sql = getTableSql();
                ds = DBClass.execQuery(sql);

                str = "(''";

                if (this.DG1.ItemsSource == null)
                {
                    MessageBox.Show("请先获取清单再申请打包");
                }
                else
                {
                    int n = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        isCheck = false;
                        isCheck = bool.Parse(BaseClass.GetCheckBoxValue(i, 0, this.DG1));
                        if (isCheck == true)
                        {
                            n++;
                            str += ",'" + ds.Tables[0].Rows[i]["Weight_ConID"].ToString() + "'";
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
                
            }catch (Exception e1)
            {
                MessageBox.Show("系统错误: " + e1.Message);
            }
            
        }
    }
}
