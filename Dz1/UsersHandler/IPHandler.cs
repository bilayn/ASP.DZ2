using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dz1.UsersHandler
{
    public static class IpHandler
    {
        public static string GetCurrentUserIpAddress()
        {
            string ip = "";
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            if (context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (!string.IsNullOrEmpty(context.Request.UserHostAddress))
            {
                ip = context.Request.UserHostAddress;
            }

            return ip;
        }
    }
}