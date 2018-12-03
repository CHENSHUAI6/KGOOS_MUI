using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Runtime.InteropServices;

namespace KGOOS_MUI.Common
{
    public class BaseClass
    {
        /// <summary>
        /// 获取最大ID
        /// </summary>
        /// <param name="Table">表名</param>
        /// <param name="Id_Name">序号ID字段名</param>
        /// <param name="Num">自然序号：001/0001/00001</param>
        /// <returns></returns>
        public static String getInsertMaxId(String Table, String Id_Name, String Num)
        {
            String sql = "";
            string yyyyMM = "";

            yyyyMM = DateTime.Now.ToString("yyyyMM");
            yyyyMM = yyyyMM + Num;
            sql = "select " + Id_Name + " from " + Table + " where " + Id_Name + " >= " + yyyyMM + " order by " + Id_Name + " desc ";

            DataSet ds = DBClass.execQuery(sql);
            var count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                String max_id = ds.Tables[0].Rows[0][0].ToString();
                var i = Int64.Parse(max_id);
                var ii = i + 1;
                return ii.ToString();
            }
            else
            {
                return yyyyMM;
            }
        }        

        /// <summary>
        /// 把字符串数组转为SQL中in的查询条件
        /// </summary>
        /// <param name="sArray"></param>
        /// <returns></returns>
        public static String getSqlValue(String[] sArray)
        {
            string str = "";
            str = "(''";
            //判断是否输入快递单号
            if (sArray.Length > 0)
            {
                for (int i = 0; i < sArray.Length; i++)
                {
                    if (sArray[i] != "")
                    {
                        str += ",'" + sArray[i].Trim() + "'";
                    }

                }

            }
            str += ")";
            return str;
        }

        /// <summary>
        /// 得到CheckBox里的值
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="cellIndex">列索引</param>
        /// <returns>CheckBox里的值</returns>
        public static string GetCheckBoxValue(int rowIndex, int cellIndex, DataGrid DG1)
        {
            var obj = VisualTreeHelper.GetChild((ContentPresenter)GetDataGridCell(rowIndex, cellIndex, DG1).Content, 0);
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
        public static DataGridCell GetDataGridCell(int rowIndex, int cellIndex, DataGrid DG1)
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


        [DllImport("user32.dll")]
        public static extern int MessageBeep(uint uType);


        public static void playOKSound()
        {
            uint beep = 0x00000000;
            MessageBeep(beep);
        }

        public static void playErrorSound()
        {
            uint beep = 0x00000010;
            MessageBeep(beep);
        }

        /// <summary>
        /// datagrid 中 checkbox 点击事件总写
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="TableData"></param>
        /// <param name="id_name"></param>
        /// <param name="select_name"></param>
        /// <returns></returns>
        public static DataTable TB_CheckBox_Click(object sender, DataTable TableData, string id_name, string select_name)
        {
            CheckBox cb = sender as CheckBox;
            string weight_id = cb.Tag.ToString();
            for (int i = 0; i < TableData.Rows.Count; i++)
            {
                string id = TableData.Rows[i][id_name].ToString();
                if (id.Equals(weight_id))
                {

                    if (bool.Parse(TableData.Rows[i][select_name].ToString()) == true)
                    {
                        TableData.Rows[i][select_name] = false;
                    }
                    else
                    {
                        TableData.Rows[i][select_name] = true;
                    }

                    if (TableData.Rows[i]["is_shipments"].ToString() == "Y")
                    {
                        TableData.Rows[i]["pack_state"] = "已发件";
                    }
                    else if (TableData.Rows[i]["is_shipments"].ToString() == "D")
                    {
                        TableData.Rows[i]["pack_state"] = "已打包";
                    }
                    else
                    {
                        TableData.Rows[i]["pack_state"] = "已申请";
                    }

                    if (bool.Parse(TableData.Rows[i]["paid"].ToString()) == true)
                    {
                        TableData.Rows[i]["pack_state"] = "已付款";
                    }

                    return TableData;
                }
            }
            return TableData;

        }


    }


}
