using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace BookRead.Utilities
{
    public static class Utilite
    {
        public static void RemoveFile(string name  )
        {
            string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"),   name);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}