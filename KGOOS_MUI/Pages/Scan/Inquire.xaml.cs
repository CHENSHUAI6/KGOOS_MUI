using KGOOS_MUI.Common;
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
    /// Interaction logic for Inquire.xaml
    /// </summary>
    public partial class Inquire : UserControl
    {
        public Inquire()
        {
            InitializeComponent();
            TBStartTime.Text = DateTime.Now.AddDays(-31).ToString("yyyy-MM-dd HH:mm:ss");
        }
        public void colorDG()
        {

            for (int i = 0; i < this.DG1.Items.Count; i++)
            {
                DataRowView drv = DG1.Items[i] as DataRowView;
                DataGridRow row = (DataGridRow)this.DG1.ItemContainerGenerator.ContainerFromIndex(i);
                if (i == 2)
                {
                    row.Background = new SolidColorBrush(Colors.Blue);
                }
            }
        }
        public void getData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("FirstName", typeof(int)));
            dt.Columns.Add(new DataColumn("LastName", typeof(string)));

            for (int i = 0; i < 6; i++)
            {
                DataRow dr = dt.NewRow();
                if (i == 3)
                {
                    dr["FirstName"] = DBNull.Value;
                    dr["LastName"] = DBNull.Value;
                    dt.Rows.Add(dr);
                }
                else
                {
                    dr["FirstName"] = i;
                    dr["LastName"] = "tom" + i.ToString();
                    dt.Rows.Add(dr);
                }
            }

            this.DG1.CanUserAddRows = false;
            this.DG1.ItemsSource = dt.DefaultView;
        }
        
        private void DG1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //var drv = e.Row.Item as DataRowView;
            //switch (drv["FirstName"].ToString())
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
                "join T_Staff as t2 on t2.id_staff = t1.Weight_WorkderId " +
                "join T_Region as t3 on t3.Region_Id = t2.warehouse_staff " +
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
         
            ds = DBClass.execQuery(sql);
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Checking", typeof(object)));
            dt.Columns.Add(new DataColumn("Id", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_ConID", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Last", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_WorkderId", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Time", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Helf", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Num", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Shelf", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Note", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_UserId", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_UserName", typeof(string)));
            dt.Columns.Add(new DataColumn("Weight_Weitgh", typeof(string)));

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Checking"] = false;
                    dr["Id"] = ds.Tables[0].Rows[i]["Id"];
                    dr["Weight_ConID"] = ds.Tables[0].Rows[i]["Weight_ConID"];
                    dr["Weight_Type"] = ds.Tables[0].Rows[i]["Weight_Type"];
                    dr["Weight_Last"] = ds.Tables[0].Rows[i]["Weight_Last"];
                    dr["Weight_WorkderId"] = ds.Tables[0].Rows[i]["Weight_WorkderId"];
                    dr["Weight_Time"] = ds.Tables[0].Rows[i]["Weight_Time"];
                    dr["Weight_Helf"] = ds.Tables[0].Rows[i]["Weight_Helf"];
                    dr["Weight_Num"] = ds.Tables[0].Rows[i]["Weight_Num"];
                    dr["Weight_Shelf"] = ds.Tables[0].Rows[i]["Weight_Shelf"];
                    dr["Weight_Note"] = ds.Tables[0].Rows[i]["Weight_Note"];
                    dr["Weight_UserId"] = ds.Tables[0].Rows[i]["Weight_UserId"];
                    dr["Weight_UserName"] = ds.Tables[0].Rows[i]["Weight_UserName"];
                    dr["Weight_Weitgh"] = ds.Tables[0].Rows[i]["Weight_Weitgh"];
                    dt.Rows.Add(dr);
                }

            }

            str = "";
            for (int i = 0; i < sArrayID.Length; i++ )
            {
                IsExist = false;
                for (int j =0; j < ds.Tables[0].Rows.Count; j++)
                {
                    if (sArrayID[i].Equals(ds.Tables[0].Rows[j]["Weight_ConID"]))
                    {
                        IsExist = true;
                    }
                }
                if (IsExist == false)
                {
                    str += sArrayID[i] + "\r\n";
                }
            }

            this.NoID.Text = str;
            this.DG1.CanUserAddRows = false;

            this.DG1.ItemsSource = dt.DefaultView;

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
    }
}
