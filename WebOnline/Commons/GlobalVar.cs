using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebOnline.Commons
{
    public class GlobalVar
    {
        public static int IdUserLogin
        {
            get
            {
                return Protector.Int(HttpContext.Current.Session["ACCOUNT_ID"], -1);
            }
            set
            {
                HttpContext.Current.Session["ACCOUNT_ID"] = value;
            }
        }

        public static string NameUserLogin
        {
            get
            {
                return Protector.String(HttpContext.Current.Session["ACCOUNT_NAME"]);
            }
            set
            {
                HttpContext.Current.Session["ACCOUNT_NAME"] = value;
            }
        }

        public static int Permission
        {
            get
            {
                return Protector.Int(HttpContext.Current.Session["PERMISSION"], 0);
            }
            set
            {
                HttpContext.Current.Session["PERMISSION"] = value;
            }
        }
    }
}