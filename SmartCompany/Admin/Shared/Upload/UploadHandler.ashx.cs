using System.Web;
using System.IO;

namespace SmartCompany.Admin.Shared.Upload
{
    /// <summary>
    /// Summary description for UploadHandler
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            const string UploadFolder = "~/Uploads/";
            //Uploaded File Deletion
            if (context.Request.QueryString.Count > 0)
            {
                string filePath = HttpContext.Current.Server.MapPath(context.Request.QueryString[0].ToString());
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
            //File Upload
            else
            {
                var ext = System.IO.Path.GetExtension(context.Request.Files[0].FileName);
                var fileName = Path.GetFileName(context.Request.Files[0].FileName);

                if (context.Request.Files[0].FileName.LastIndexOf("\\") != -1)
                {
                    fileName = context.Request.Files[0].FileName.Remove(0, context.Request.Files[0].FileName.LastIndexOf("\\")).ToLower();
                }



                fileName = GetUniqueFileName(fileName, HttpContext.Current.Server.MapPath(UploadFolder), ext).ToLower();



                string location = HttpContext.Current.Server.MapPath(UploadFolder) + fileName + ext;
                context.Request.Files[0].SaveAs(location);
                context.Response.Write(fileName + ext);
                context.Response.End();
            }




        }
        // Change the name of upload file
        public static string GetUniqueFileName(string name, string savePath, string ext)
        {

            name = name.Replace(ext, "").Replace(" ", "_");
            name = System.Text.RegularExpressions.Regex.Replace(name, @"[^\w\s]", "");

            var newName = name;
            var i = 0;
            if (System.IO.File.Exists(savePath + newName + ext))
            {

                do
                {
                    i++;
                    newName = name + "_" + i;

                }
                while (System.IO.File.Exists(savePath + newName + ext));

            }

            return newName;


        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}