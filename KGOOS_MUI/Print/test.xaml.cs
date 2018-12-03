using FastReport;
using FirstFloor.ModernUI.Windows.Controls;
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

namespace KGOOS_MUI.Print
{
    /// <summary>
    /// Interaction logic for test.xaml
    /// </summary>
    public partial class test : ModernWindow
    {

        FastReport.Preview.PreviewControl prew = new FastReport.Preview.PreviewControl();
        Report report = new Report();

        public test()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();

            DataTable table1 = new DataTable();
            table1.TableName = "print_data"; // 一定要设置表名称
            ds.Tables.Add(table1);

            // 添加表中的列
            table1.Columns.Add("head", typeof(string));
            table1.Columns.Add("name", typeof(string));
            table1.Columns.Add("phone", typeof(string));
            table1.Columns.Add("adress", typeof(string));
            table1.Columns.Add("contran_id", typeof(string));
            table1.Columns.Add("case_num", typeof(string));
            table1.Columns.Add("contran_page", typeof(string));

            table1.Columns.Add("order_id", typeof(string));
            table1.Columns.Add("user_id", typeof(string));
            table1.Columns.Add("user_tb", typeof(string));

            // 任意添加一些数据
            for (int i = 0, maxI = 1; i < maxI; i++)
            {
                DataRow row = table1.NewRow();
                row["head"] = "阿萨德撒多撒大所多" + i.ToString();
                row["name"] = "陈 帅";
                row["phone"] = "18488888888";
                row["adress"] = "阿萨德撒多撒多撒阿萨德撒多撒多撒多奥术大师多撒";
                row["contran_id"] = "1809000001";
                row["case_num"] = i.ToString();
                row["contran_page"] = "180900000100" + i.ToString();

                row["order_id"] = "20180900000100" + i.ToString();
                row["user_id"] = "k1000" + i.ToString();
                row["user_tb"] = "sdasdasdsadasda" + i.ToString();
                table1.Rows.Add(row);
            }

            report = new FastReport.Report();
            report.Preview = prew;//preview1是private FastReport.Preview.PreviewControl preview1;          

            //FDataSet.Tables[0].TableName = "Table1";//数据源名称
            //report.Load(@"C:\主單.frx");
            //发布后地址
            report.Load(@"C:\Program Files\KGOOS\KGOOS\Print_Label\主單.frx");         
            report.RegisterData(ds);
            report.GetDataSource("print_data").Enabled = true;

            report.Prepare();
            report.ShowPrepared();
            //WindowsFormsHost1.Child = prew;

            report.PrintSettings.ShowDialog = false;
            report.Print();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();

            DataTable table1 = new DataTable();
            table1.TableName = "print_data"; // 一定要设置表名称
            ds.Tables.Add(table1);

            // 添加表中的列
            table1.Columns.Add("head", typeof(string));
            table1.Columns.Add("name", typeof(string));
            table1.Columns.Add("phone", typeof(string));
            table1.Columns.Add("adress", typeof(string));
            table1.Columns.Add("contran_id", typeof(string));
            table1.Columns.Add("case_num", typeof(string));
            table1.Columns.Add("contran_page", typeof(string));

            table1.Columns.Add("order_id", typeof(string));
            table1.Columns.Add("user_id", typeof(string));
            table1.Columns.Add("user_tb", typeof(string));

            // 任意添加一些数据
            for (int i = 0, maxI = 10; i < maxI; i++)
            {
                DataRow row = table1.NewRow();
                row["head"] = "阿萨德撒多撒大所多" + i.ToString();
                row["name"] = "陈 帅";
                row["phone"] = "18488888888";
                row["adress"] = "阿萨德撒多撒多撒阿萨德撒多撒多撒多奥术大师多撒";
                row["contran_id"] = "1809000001";
                row["case_num"] = i.ToString();
                row["contran_page"] = "180900000100" + i.ToString();

                row["order_id"] = "20180900000100" + i.ToString();
                row["user_id"] = "k1000" + i.ToString();
                row["user_tb"] = "sdasdasdsadasda" + i.ToString();
                table1.Rows.Add(row);
            }

            report = new FastReport.Report();
            report.Preview = prew;//preview1是private FastReport.Preview.PreviewControl preview1;          

            //FDataSet.Tables[0].TableName = "Table1";//数据源名称
            //report.Load(@"C:\子單.frx");
            //发布后地址
            report.Load(@"C:\Program Files\KGOOS\KGOOS\Print_Label\子單.frx");         
            report.RegisterData(ds);
            report.GetDataSource("print_data").Enabled = true;

            report.Prepare();
            report.ShowPrepared();
            //WindowsFormsHost1.Child = prew;

            report.PrintSettings.ShowDialog = false;
            report.Print();
        }


        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();

            DataTable table1 = new DataTable();
            table1.TableName = "print_data"; // 一定要设置表名称
            ds.Tables.Add(table1);

            DataTable table2 = new DataTable();
            table2.TableName = "print_table"; // 一定要设置表名称
            ds.Tables.Add(table2);

            // 添加表中的列
            table1.Columns.Add("head", typeof(string));
            table1.Columns.Add("name", typeof(string));
            table1.Columns.Add("phone", typeof(string));
            table1.Columns.Add("adress", typeof(string));
            table1.Columns.Add("contran_id", typeof(string));
            table1.Columns.Add("case_num", typeof(string));
            table1.Columns.Add("contran_page", typeof(string));
            table1.Columns.Add("order_id", typeof(string));
            table1.Columns.Add("user_id", typeof(string));
            table1.Columns.Add("user_name", typeof(string));
            table1.Columns.Add("user_tb", typeof(string));
            table1.Columns.Add("company", typeof(string));


            table2.Columns.Add("id", typeof(string));
            table2.Columns.Add("con_id", typeof(string));
            table2.Columns.Add("shelf", typeof(string));
            table2.Columns.Add("helf", typeof(string));

            // 任意添加一些数据           
            for (int i = 0, maxI = 1; i < maxI; i++)
            {
                DataRow row = table1.NewRow();
                row["head"] = "阿萨德撒多撒大所多" + i.ToString();
                row["name"] = "陈 帅";
                row["phone"] = "18488888888";
                row["adress"] = "阿萨德撒多撒多撒阿萨德撒多撒多撒多奥术大师多撒";
                row["contran_id"] = "1809000001";
                row["case_num"] = i.ToString();
                row["contran_page"] = "180900000100" + i.ToString();

                row["order_id"] = "20180900000100" + i.ToString();
                row["user_id"] = "k1000" + i.ToString();
                row["user_name"] = "k1000" + i.ToString();
                row["user_tb"] = "sdasdasdsadasda" + i.ToString();
                row["company"] = "顺丰";
                table1.Rows.Add(row);
            }

            for (int i = 0, maxI = 10; i < maxI; i++)
            {
                DataRow row = table2.NewRow();
                row["id"] = i.ToString();
                row["con_id"] = "31231221" + i.ToString();
                row["shelf"] = "k-312" + i.ToString();
                row["helf"] = "2312.66";                
                table2.Rows.Add(row);
            }

            report = new FastReport.Report();
            report.Preview = prew;//preview1是private FastReport.Preview.PreviewControl preview1;          

            //FDataSet.Tables[0].TableName = "Table1";//数据源名称
            //report.Load(@"C:\集運訂單.frx");
            //发布后地址
            report.Load(@"C:\Program Files\KGOOS\KGOOS\Print_Label\集運訂單.frx");         
            report.RegisterData(ds);
            report.GetDataSource("print_data").Enabled = true;
            report.GetDataSource("print_table").Enabled = true;

            report.Prepare();
            report.ShowPrepared();
            //WindowsFormsHost1.Child = prew;

            report.PrintSettings.ShowDialog = false;
            report.Print();
        }
    }
}
