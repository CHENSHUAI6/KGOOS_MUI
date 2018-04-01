using KGOOS_MUI.Common;
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
    /// Interaction logic for FreightCount.xaml
    /// </summary>
    public partial class FreightCount : UserControl
    {
        public FreightCount()
        {
            InitializeComponent();
            initialize();
        }

        /// <summary>
        /// 自定义初始化函数
        /// </summary>
        public void initialize()
        {
            TBEndTime.Text = DateTime.Now.AddYears(2).ToString("yyyy-MM-dd");
            getRegion();
            //getCon();
            //getDestination();
            getPriceType();
        }

        /// <summary>
        /// 获取承运商
        /// </summary>
        public void getCon()
        {
            //DataSet ds = new DataSet();
            //string sql = "";
            //string name = "";
            //List<KeyValuePair<string, string>> RegionList = new List<KeyValuePair<string, string>>();
            //RegionList.Add(new KeyValuePair<string, string>("0", "请选择承运商"));

            //sql = "select t1.name from T_con_carrier as t1 group by t1.name ";

            //ds = DBClass.execQuery(sql);
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    name = "";
            //    name = ds.Tables[0].Rows[i][0].ToString();
            //    RegionList.Add(new KeyValuePair<string, string>(name, name));
            //}
            //CBCom.ItemsSource = RegionList;
            //CBCom.SelectedValuePath = "Key";
            //CBCom.DisplayMemberPath = "Value";
            //CBCom.SelectedItem = new KeyValuePair<string, string>("0", "请选择承运商");
        }

        /// <summary>
        /// 获取目的地
        /// </summary>
        public void getDestination()
        {
            //DataSet ds = new DataSet();
            //string sql = "";
            //string destination = "";
            //List<KeyValuePair<string, string>> RegionList = new List<KeyValuePair<string, string>>();
            //RegionList.Add(new KeyValuePair<string, string>("0", "请选择目的地"));

            //sql = "select destination from T_con_carrier as t1 group by t1.destination ";

            //ds = DBClass.execQuery(sql);
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    destination = "";
            //    destination = ds.Tables[0].Rows[i][0].ToString();
            //    RegionList.Add(new KeyValuePair<string, string>(destination, destination));
            //}
            //CBCom.ItemsSource = RegionList;
            //CBCom.SelectedValuePath = "Key";
            //CBCom.DisplayMemberPath = "Value";
            //CBCom.SelectedItem = new KeyValuePair<string, string>("0", "请选择目的地");
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
            RegionList.Add(new KeyValuePair<string, string>("0", "请选择目的地"));

            sql = "select Region_Name from t_region";

            ds = DBClass.execQuery(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Region_Name = "";
                Region_Name = ds.Tables[0].Rows[i][0].ToString();
                RegionList.Add(new KeyValuePair<string, string>(Region_Name, Region_Name));
            }
            CBRegion.ItemsSource = RegionList;
            CBRegion.SelectedValuePath = "Key";
            CBRegion.DisplayMemberPath = "Value";
            CBRegion.SelectedItem = new KeyValuePair<string, string>("0", "请选择目的地");
        }

        /// <summary>
        /// 费用类型
        /// </summary>
        public void getPriceType()
        {
            List<KeyValuePair<string, string>> PriceTypeList = new List<KeyValuePair<string, string>>();
            PriceTypeList.Add(new KeyValuePair<string, string>("运费", "运费"));
            PriceTypeList.Add(new KeyValuePair<string, string>("其他", "其他"));
            CBPriceType.ItemsSource = PriceTypeList;
            CBPriceType.SelectedValuePath = "Key";
            CBPriceType.DisplayMemberPath = "Value";
            CBPriceType.SelectedItem = new KeyValuePair<string, string>("运费", "运费");
        }

        /// <summary>
        /// 写入T_con_carrier表
        /// </summary>
        public void inputCarrier()
        {
            SqlConnection conn = DBClass.getConnection();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sql = "";
                string id, region_id, destination, name, con_name, start_time, end_time, fin,
                    transport, quote_name, quote_num, quote_note, PriceType, ThingType,
                    AddressType, payAdd;

                id = BaseClass.getInsertMaxId("T_con_carrier", "id", "001");

                #region 获取前台数据
                PriceType = CBPriceType.SelectedIndex.ToString();
                region_id = CBRegion.SelectedIndex.ToString();


                if (TBPayAdd.Text != "")
                {
                    payAdd = TBPayAdd.Text;
                }
                else
                {
                    payAdd = "";
                }

                if (TBRealCon.Text != "")
                {
                    con_name = TBRealCon.Text;
                }
                else
                {
                    con_name = "";
                }

                if (TBRealCon.Text != "")
                {
                    con_name = TBRealCon.Text;
                }
                else
                {
                    con_name = "";
                }


                if (TBName.Text != "")
                {
                    name = TBName.Text;
                }
                else
                {
                    name = "";
                }

                if (TBDestination.Text != "")
                {
                    destination = TBDestination.Text;
                }
                else
                {
                    destination = "";
                }

                if (TBThingType.Text != "")
                {
                    ThingType = TBThingType.Text;
                }
                else
                {
                    ThingType = "";
                }

                if (TBAddressType.Text != "")
                {
                    AddressType = TBAddressType.Text;
                }
                else
                {
                    AddressType = "";
                }

                if (TBStartTime.Text != "")
                {
                    start_time = TBStartTime.Text;
                }
                else
                {
                    start_time = "";
                }

                if (TBFin.Text != "")
                {
                    fin = TBFin.Text;
                }
                else
                {
                    fin = "";
                }

                if (TBTransport.Text != "")
                {
                    transport = TBTransport.Text;
                }
                else
                {
                    transport = "";
                }

                if (TBQuote_num.Text != "")
                {
                    quote_num = TBQuote_num.Text;
                }
                else
                {
                    quote_num = "";
                }

                if (TBEndTime.Text != "")
                {
                    end_time = TBEndTime.Text;
                }
                else
                {
                    end_time = "";
                }

                if (TBQuote_name.Text != "")
                {
                    quote_name = TBQuote_name.Text;
                }
                else
                {
                    quote_name = "";
                }

                if (TBQuote_note.Text != "")
                {
                    quote_note = TBQuote_note.Text;
                }
                else
                {
                    quote_note = "";
                }
                #endregion

                sql = "insert into T_con_carrier " +
                "(id, region_id, destination, name, con_name, start_time, end_time, fin, " +
                "transport, quote_name, quote_num, quote_note, PriceType, ThingType, " +
                "AddressType, payAdd ) " +
                "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}', " +
                "'{11}','{12}','{13}', '{14}', '{15}')";

                sql = string.Format(sql, id, region_id, destination, name, con_name, start_time, end_time, fin,
                    transport, quote_name, quote_num, quote_note, PriceType, ThingType, AddressType, payAdd);

                int n = DBClass.execUpdate(conn, tran, sql);

                tran.Commit();
                if (n > 0)
                {
                    MessageBox.Show("保存成功！");
                    getCarrier();
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("操作失败。请重试" + e.Message);
            }
        }

        /// <summary>
        /// 删除T_con_carrier表
        /// </summary>
        /// <param name="freight_id"></param>
        public void deleteCarrier(string con_id)
        {
            try
            {
                string sql = "";
                sql = "delete T_con_carrier where id = '" + con_id + "'";
                int n = DBClass.execUpdate(sql);

                if (n > 0)
                {
                    MessageBox.Show("删除成功！");
                    getCarrier();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("操作失败。请重试" + e.Message);
            }

        }

        /// <summary>
        /// 写入T_Freight表
        /// </summary>
        public void inputFreight()
        {
            SqlConnection conn = DBClass.getConnection();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sql = "";

                string helf, min_num, char1, max_num, char2, formula, freight_id;

                freight_id = BaseClass.getInsertMaxId("T_Freight", "id", "001");

                var a = this.DG1.SelectedItem;
                var b = a as DataRowView;
                string con_id = b.Row[0].ToString();

                #region 获取前台数据

                if (TBHelf.Text != "")
                {
                    helf = TBHelf.Text;
                }
                else
                {
                    helf = "";
                }

                if (TBFormula.Text != "")
                {
                    formula = TBFormula.Text;
                }
                else
                {
                    formula = "";
                }
                #endregion

                int i = 0;
                if (helf.IndexOf('W') > helf.IndexOf('w'))
                {
                    i = helf.IndexOf('W');
                }
                else
                {
                    i = helf.IndexOf('w');
                }

                min_num = helf.Substring(0, i - 1);
                char1 = helf.Substring(i - 1, 1);
                char2 = helf.Substring(i + 1, 1);
                max_num = helf.Substring(i + 2);

                sql = "insert into T_Freight " +
                "(id, min_num, char1, max_num, char2, formula, carrier_id) " +
                "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";

                sql = string.Format(sql, freight_id, min_num, char1, max_num, char2, formula, con_id);

                int n = DBClass.execUpdate(conn, tran, sql);

                tran.Commit();

                if (n > 0)
                {
                    MessageBox.Show("保存成功！");
                    getFreight(con_id);
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("操作失败。请重试" + e.Message);
            }
        }

        /// <summary>
        /// 更新T_Freight表
        /// </summary>
        /// <param name="freight_id"></param>
        public void updateFreight(string freight_id)
        {
            SqlConnection conn = DBClass.getConnection();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sql = "";

                string helf, min_num, char1, max_num, char2, formula;

                var a = this.DG1.SelectedItem;
                var b = a as DataRowView;
                string con_id = b.Row[0].ToString();

                #region 获取前台数据

                if (TBHelf.Text != "")
                {
                    helf = TBHelf.Text;
                }
                else
                {
                    helf = "";
                }

                if (TBFormula.Text != "")
                {
                    formula = TBFormula.Text;
                }
                else
                {
                    formula = "";
                }
                #endregion

                int i = 0;
                if (helf.IndexOf('W') > helf.IndexOf('w'))
                {
                    i = helf.IndexOf('W');
                }
                else
                {
                    i = helf.IndexOf('w');
                }

                min_num = helf.Substring(0, i - 1);
                char1 = helf.Substring(i - 1, 1);
                char2 = helf.Substring(i + 1, 1);
                max_num = helf.Substring(i + 2);

                sql = "update T_Freight set char1 = '{2}', char2 = '{4}', min_num = '{1}', max_num = '{3}'," +
                    "formula = '{5}' " +
                    "where id = '{0}'";

                sql = string.Format(sql, freight_id, min_num, char1, max_num, char2, formula);

                int n = DBClass.execUpdate(conn, tran, sql);

                tran.Commit();

                if (n > 0)
                {
                    MessageBox.Show("保存成功！");
                    getFreight(con_id);
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("操作失败。请重试" + e.Message);
            }
        }

        /// <summary>
        /// 删除T_Freight表
        /// </summary>
        /// <param name="freight_id"></param>
        public void deleteFreight(string freight_id)
        {
            try
            {
                var a = this.DG1.SelectedItem;
                var b = a as DataRowView;
                string con_id = b.Row[0].ToString();

                string sql = "";
                sql = "delete T_Freight where id = '" + freight_id + "'";
                int n = DBClass.execUpdate(sql);

                if (n > 0)
                {
                    MessageBox.Show("删除成功！");
                    getFreight(con_id);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("操作失败。请重试" + e.Message);
            }

        }

        /// <summary>
        /// 获取T_con_carrier表数据
        /// </summary>
        public void getCarrier()
        {
            string sql = "";
            sql = "select * from T_con_carrier as t1 where 1=1 ";        

            DataSet ds = new DataSet();
            ds = DBClass.execQuery(sql);

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id", typeof(string)));
            dt.Columns.Add(new DataColumn("region_id", typeof(string)));
            dt.Columns.Add(new DataColumn("destination", typeof(string)));
            dt.Columns.Add(new DataColumn("name", typeof(string)));
            dt.Columns.Add(new DataColumn("con_name", typeof(string)));
            dt.Columns.Add(new DataColumn("PriceType", typeof(string)));
            dt.Columns.Add(new DataColumn("AddressType", typeof(string)));
            dt.Columns.Add(new DataColumn("transport", typeof(string)));
            dt.Columns.Add(new DataColumn("ThingType", typeof(string)));
            dt.Columns.Add(new DataColumn("OddType", typeof(string)));
            dt.Columns.Add(new DataColumn("start_time", typeof(string)));
            dt.Columns.Add(new DataColumn("end_time", typeof(string)));
            dt.Columns.Add(new DataColumn("quote_name", typeof(string)));
            dt.Columns.Add(new DataColumn("quote_note", typeof(string)));
            dt.Columns.Add(new DataColumn("fin", typeof(string)));
            dt.Columns.Add(new DataColumn("quote_num", typeof(string)));
            dt.Columns.Add(new DataColumn("payAdd", typeof(string)));

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["id"] = ds.Tables[0].Rows[i]["id"];
                    dr["region_id"] = ds.Tables[0].Rows[i]["region_id"];
                    dr["destination"] = ds.Tables[0].Rows[i]["destination"];
                    dr["name"] = ds.Tables[0].Rows[i]["name"];
                    dr["con_name"] = ds.Tables[0].Rows[i]["con_name"];
                    dr["PriceType"] = ds.Tables[0].Rows[i]["PriceType"];
                    dr["AddressType"] = ds.Tables[0].Rows[i]["AddressType"];
                    dr["transport"] = ds.Tables[0].Rows[i]["transport"];
                    dr["ThingType"] = ds.Tables[0].Rows[i]["ThingType"];
                    dr["OddType"] = ds.Tables[0].Rows[i]["OddType"];
                    dr["start_time"] = ds.Tables[0].Rows[i]["start_time"];
                    dr["end_time"] = ds.Tables[0].Rows[i]["end_time"];
                    dr["quote_name"] = ds.Tables[0].Rows[i]["quote_name"];
                    dr["quote_note"] = ds.Tables[0].Rows[i]["quote_note"];
                    dr["fin"] = ds.Tables[0].Rows[i]["fin"];
                    dr["quote_num"] = ds.Tables[0].Rows[i]["quote_num"];
                    dr["payAdd"] = ds.Tables[0].Rows[i]["payAdd"];
                    dt.Rows.Add(dr);
                }

            }
            this.DG1.CanUserAddRows = false;
            this.DG1.ItemsSource = dt.DefaultView;
        }

        /// <summary>
        /// 获取T_Freight表数据
        /// </summary>
        public void getFreight(string con_id)
        {
            string sql = "";
            sql = "select * from T_Freight as t1 where carrier_id = '" + con_id + "' ";

            DataSet ds = new DataSet();
            ds = DBClass.execQuery(sql);

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id", typeof(string)));
            dt.Columns.Add(new DataColumn("weight", typeof(string)));
            dt.Columns.Add(new DataColumn("formula", typeof(string)));
            dt.Columns.Add(new DataColumn("href", typeof(string)));

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["id"] = ds.Tables[0].Rows[i]["id"];
                    string weight = "";
                    weight = ds.Tables[0].Rows[i]["min_num"].ToString() +
                        ds.Tables[0].Rows[i]["char1"].ToString() +
                        "W" +
                        ds.Tables[0].Rows[i]["char2"].ToString() +
                        ds.Tables[0].Rows[i]["max_num"].ToString();
                    dr["weight"] = weight;
                    dr["formula"] = ds.Tables[0].Rows[i]["formula"];
                    dr["href"] = "?";
                    dt.Rows.Add(dr);
                }

            }
            this.DG2.CanUserAddRows = false;
            this.DG2.ItemsSource = dt.DefaultView;
        }


        #region 录入操作按钮
        private void BtnCeil_Click(object sender, RoutedEventArgs e)
        {
            TBFormula.Text += "ceil(";
            TBFormula.Focus();
            TBFormula.SelectionStart = TBFormula.Text.Length;
        }

        private void BtnFloor_Click(object sender, RoutedEventArgs e)
        {
            TBFormula.Text += "floor(";
            TBFormula.Focus();
            TBFormula.SelectionStart = TBFormula.Text.Length;
        }

        private void BtnRound_Click(object sender, RoutedEventArgs e)
        {
            TBFormula.Text += "round(";
            TBFormula.Focus();
            TBFormula.SelectionStart = TBFormula.Text.Length;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TBHelf.Text += "＜";
            TBHelf.Focus();
            TBHelf.SelectionStart = TBHelf.Text.Length;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TBHelf.Text += "≤";
            TBHelf.Focus();
            TBHelf.SelectionStart = TBHelf.Text.Length;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TBHelf.Text += "＜W≤";
            TBHelf.Focus();
            TBHelf.SelectionStart = TBHelf.Text.Length;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TBFormula.Text += "+";
            TBFormula.Focus();
            TBFormula.SelectionStart = TBFormula.Text.Length;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TBFormula.Text += "-";
            TBFormula.Focus();
            TBFormula.SelectionStart = TBFormula.Text.Length;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            TBFormula.Text += "×";
            TBFormula.Focus();
            TBFormula.SelectionStart = TBFormula.Text.Length;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            TBFormula.Text += "÷";
            TBFormula.Focus();
            TBFormula.SelectionStart = TBFormula.Text.Length;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            TBFormula.Text += "(";
            TBFormula.Focus();
            TBFormula.SelectionStart = TBFormula.Text.Length;
        }

        private void Button_Click_71(object sender, RoutedEventArgs e)
        {
            TBFormula.Text += ")";
            TBFormula.Focus();
            TBFormula.SelectionStart = TBFormula.Text.Length;
        }
        #endregion

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            inputFreight();
        }

        private void TBStartTime_ValueChanged(object sender, EventArgs e)
        {
            TBEndTime.Text = DateTime.Parse(TBStartTime.Text).AddYears(2).ToString("yyyy-MM-dd");
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            inputCarrier();
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            getCarrier();
        }

        private void DG1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var a = this.DG1.SelectedItem;
            var b = a as DataRowView;
            string con_id = b.Row[0].ToString();
            getFreight(con_id);
        }

        private void DG2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var a = this.DG2.SelectedItem;
            var b = a as DataRowView;
            TBHelf.Text = b.Row[1].ToString();
            TBFormula.Text = b.Row[2].ToString();
        }

        /// <summary>
        /// 公式还原，取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            var a = this.DG2.SelectedItem;
            var b = a as DataRowView;
            TBHelf.Text = b.Row[1].ToString();
            TBFormula.Text = b.Row[2].ToString();
        }

        /// <summary>
        /// 公式保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            var a = this.DG2.SelectedItem;
            var b = a as DataRowView;
            string freight_id = "";
            try
            {
                freight_id = b.Row[0].ToString();
                updateFreight(freight_id);
            }
            catch (Exception e1)
            {
                MessageBox.Show("删除失败" + e1.Message);
            }

        }

        /// <summary>
        /// 删除公式按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            var a = this.DG2.SelectedItem;
            var b = a as DataRowView;
            string freight_id = "";
            try
            {
                freight_id = b.Row[0].ToString();
                deleteFreight(freight_id);
            }
            catch (Exception e1)
            {
                MessageBox.Show("删除失败" + e1.Message);
            }


        }

        /// <summary>
        /// 删除承运商按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var a = this.DG1.SelectedItem;
            var b = a as DataRowView;
            string con_id = "";
            try
            {
                con_id = b.Row[0].ToString();
                deleteCarrier(con_id);
            }
            catch (Exception e1)
            {
                MessageBox.Show("删除失败" + e1.Message);
            }
        }




    }
}
