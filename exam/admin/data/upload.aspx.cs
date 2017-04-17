using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Configuration;

public partial class Data_upload : System.Web.UI.Page
{
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //WriteLog("upload:进入Page_Load");
        System.Drawing.Image original_image = null;
        Bitmap final_image = null;
        try
        {
            string filepath = ConfigurationManager.AppSettings["htmlpath"] + DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
            string path = Server.MapPath(filepath);

            if (!File.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            HttpPostedFile jpeg_image_upload = Request.Files["Filedata"];
            original_image = System.Drawing.Image.FromStream(jpeg_image_upload.InputStream);

            final_image = (Bitmap)original_image;
            string file = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
            string originalImagePath = path + "/" + file;
            string mthumbnailPath = path + "/m_" + file;
            string sthumbnailPath = path + "/s_" + file;

            final_image.Save(originalImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            
            Thumbnail.MakeThumbnail(originalImagePath, mthumbnailPath, 360, 200, "HW");
            Thumbnail.MakeThumbnail(originalImagePath, sthumbnailPath, 50, 50, "HW");
            
            string web = ConfigurationManager.AppSettings["filepath"] + DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
            Response.Write(web + "/s_" + file + "|" + web + "/m_" + file + "|0");

            

        }
        catch (Exception ex)
        {
            MessageBox.ShowMsg(this.Page, ex.Message);
        }
        finally
        {
            original_image.Dispose();
            final_image.Dispose();

            Response.End();
        }
    }
    private string LOG_ROOT = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "log");
    public const string TIME_FAMATE = "yyyy-MM-dd HH:mm:ss.fff";

    private void WriteLog(string content)
    {
        if (!Directory.Exists(LOG_ROOT))
        {
            Directory.CreateDirectory(LOG_ROOT);
        }

        string Error_Path = Path.Combine(LOG_ROOT, "Error_Log" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
        System.Threading.Monitor.Enter(Error_Path);
        using (StreamWriter sw = new StreamWriter(new FileStream(Error_Path, FileMode.Append), System.Text.Encoding.UTF8))
        {
            content = "[" + DateTime.Now.ToString(TIME_FAMATE) + "]" + content;
            sw.WriteLine(content);
        }
        System.Threading.Monitor.Exit(Error_Path);
    }
}