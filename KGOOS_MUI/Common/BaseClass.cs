using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        str += ",'" + sArray[i] + "'";
                    }

                }

            }
            str += ")";
            return str;
        }
    }


}
