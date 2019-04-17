using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace BookRead.Extentions
{
    public static class Extention
    {
        public static bool IsImage( this HttpPostedFileBase file)
        {

            return file.ContentType == "image/png" ||
                   file.ContentType == "image/jpeg" ||
                   file.ContentType == "image/jpg" ||
                   file.ContentType == "image/gif";

        }
        public static string SaveFiles(this HttpPostedFileBase file,string subfolder)
        {
            string fulName=subfolder +"/" + Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
            string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"), fulName);
            file.SaveAs(fullPath);
            return fulName;
        }
        public static bool IsPdf(this HttpPostedFileBase file)
        {
            return file.ContentType == "application/pdf";
        }
    }
}