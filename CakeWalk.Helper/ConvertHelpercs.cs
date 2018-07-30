using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CakeWalk.Helper
{
   public class ConvertHelpercs
    {

        /// <summary>
        /// To convert into Boolean datatype
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ToBoolean(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            bool iResult = false;
            if (bool.TryParse(Convert.ToString(obj), out iResult))
            {
                return iResult;
            }
            return iResult;
        }

        /// <summary>
        /// To Convert into DateTime datatype
        /// </summary>
        /// <param name="objDT"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object objDT)
        {
            string strDt = Convert.ToString(objDT);
            if (strDt.Length > 0)
            {
                DateTime dtReturn;
                DateTime.TryParse(strDt, out dtReturn);
                if (dtReturn == DateTime.MinValue)
                {
                    return new DateTime();
                }
                return dtReturn;
            }
            return new DateTime();
        }
        /// <summary>
        /// To convert into Decimal datatype
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj)
        {
            if (obj == null)
            {
                return 0M;
            }
            decimal decResult = 0M;
            if (decimal.TryParse(Convert.ToString(obj), out decResult))
            {
                return decResult;
            }
            return decResult;
        }
        /// <summary>
        /// To convert into Int32 datatype
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt32(object obj)
        {
            if (obj != null)
            {
                if (Convert.ToString(obj).Trim().Length == 0)
                {
                    return 0;
                }
                int intResult = 0;
                if (int.TryParse(Convert.ToString(obj), out intResult))
                {
                    return intResult;
                }
            }
            return 0;
        }
        /// <summary>
        /// To Convert into Int64 datatype
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long ToInt64(object obj)
        {
            if (obj != null)
            {
                if (Convert.ToString(obj).Trim().Length == 0)
                {
                    return 0L;
                }
                long intResult = 0L;
                if (long.TryParse(Convert.ToString(obj), out intResult))
                {
                    return intResult;
                }
            }
            return 0L;
        }
        /// <summary>
        /// To convert into String datatype
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            return Convert.ToString(obj);
        }
        /// <summary>
        /// for converting DataTable to List datatype
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IList ConvertDataTabelToIList(DataTable dt)
        {
            IList list = new List<Hashtable>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Hashtable ht = new Hashtable();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ht.Add(dt.Columns[j].ColumnName, "");
                    }

                    for (int n = 0; n < dt.Columns.Count; n++)
                    {
                        ht[dt.Columns[n].ColumnName] = dt.Rows[i][dt.Columns[n].ColumnName];
                    }
                    list.Add(ht);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }
        /// <summary>
        /// Convert Null To String
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ConvertDBNullToString(object obj)
        {
            if (!Convert.IsDBNull(obj))
            {
                return obj.ToString();
            }
            else
            {
                return string.Empty;

            }
        }
    }
}
