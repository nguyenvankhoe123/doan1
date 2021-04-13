using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using WebOnline.Models;

namespace WebOnline.Commons
{
    public class FunctionUtils
    {
        public static string ToUnsignString(string input)
        {
            input = input.Trim();
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }
            input = input.Replace(".", "-");
            input = input.Replace(" ", "-");
            input = input.Replace(",", "-");
            input = input.Replace(";", "-");
            input = input.Replace(":", "-");
            input = input.Replace("  ", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            while (str2.Contains("--"))
            {
                str2 = str2.Replace("--", "-").ToLower();
            }
            return str2;
        }
        private static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        public static string MD5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }
        public static string CreateServiceKey(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        public static bool CheckRole(int RoleId, string controlerName)
        {
            string[] leaderController = new string[] { "Dashboard", "ReportGameInfo", "Revenue", "Users", "Payment", "Game", "Server", "StatisticalUsers", "Version", "McoinManager", "Banner", "New", "Partner", "Product", "Setting", "Recruitment", "Contact" };
            string[] monitorController = new string[] { "Dashboard", "ReportGameInfo", "Revenue", "Payment", "StatisticalUsers", "Users", "McoinManager", "Banner", "New", "Partner", "Product", "Setting", "Recruitment", "Contact" };
            string[] mobizController = new string[] { "Banner", "New", "Partner", "Product", "Setting", "Recruitment", "Contact" };

            if (RoleId == 1)
            {
                return true;
            }
            else if (RoleId == 2)
            {
                return leaderController.Where(x => x.Equals(controlerName)).FirstOrDefault() != null ? true : false;
            }
            else if (RoleId == 3)
            {
                return monitorController.Where(x => x.Equals(controlerName)).FirstOrDefault() != null ? true : false;
            }
            else
            {
                return mobizController.Where(x => x.Equals(controlerName)).FirstOrDefault() != null ? true : false;
            }
        }
        private static string GetTimestamp(DateTime value)
        {
            return value.ToString("MM/dd/yyyy HH:mm:ss");
        }
    }
}