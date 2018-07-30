using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace CakeWalk.Helper
{
   public class SiteHelper
    {
        /// <summary>
        /// generate saltkey to encrypt data 
        /// </summary>
        /// <param name="length">length</param>
        /// <returns></returns>
        public static string GenerateSalt(int length)
        {
            var rng = new RNGCryptoServiceProvider();
            var buffer = new byte[length];
            rng.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }

        /// <summary>
        /// Encyption of password using salt key
        /// </summary>
        /// <param name="password"></param>
        /// <param name="saltkey"></param>
        /// <param name="passwordFormat"></param>
        /// <returns></returns>
        public static string CreatePasswordHash(string password, string saltKey, string passwordFormat = "SHA1")
        {
            if (String.IsNullOrEmpty(passwordFormat))
                passwordFormat = "SHA1";
            string saltAndPassword = String.Concat(password, saltKey);
            string hashedPassword = sha1Hash1(saltAndPassword).ToUpper();
            //Convert.ToBase64String(Sha1Hash(Encoding.UTF8.GetBytes(saltAndPassword)));


            return hashedPassword;
        }

        public static byte[] Sha1Hash(byte[] data)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return sha1.ComputeHash(data);
            }
        }

        public static string sha1Hash1(string password)
        {
            return string.Join("", SHA1CryptoServiceProvider.Create().ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2"))).ToLower();
        }
        /// <summary>
        /// Get XML Values
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="xpathQuery"></param>
        /// <returns></returns>
        public static string GetXmlValues(string xml, string xpathQuery)
        {
            if (xpathQuery != null)
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(xml);
                XmlNode node = xdoc.SelectSingleNode(xpathQuery);
                if (node == null)
                {
                    node = xdoc.SelectSingleNode(xpathQuery.ToUpper());
                }
                if (node != null)
                {
                    return node.InnerText;
                }
                else
                {
                    return String.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        ///ToCSV 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string ToCsv(DataTable table)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<String> columnNames = table.Columns.OfType<DataColumn>().
                                              Select(column => QuoteValue(column.ColumnName));
            sb.AppendLine(String.Join(",", columnNames));

            IEnumerable<String> fields = null;
            foreach (DataRow row in table.Rows)
            {
                fields = row.ItemArray.Select(field => QuoteValue(field.ToString()));
                sb.AppendLine(String.Join(",", fields));
            }

            return sb.ToString();
        }
        private static string QuoteValue(string value)
        {
            return String.Concat("\"",
            value.Replace("\"", "\"\""), "\"");
        }
    }
}
