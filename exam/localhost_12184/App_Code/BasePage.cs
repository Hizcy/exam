using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.OleDb;

/// <summary>
///BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public BasePage()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }


    //private UserIdentity _user;
    ///// <summary>
    ///// 用户身份对象
    ///// </summary>
    protected UserIdentity identity
    {
        get 
        {
            UserIdentity identity = User.Identity as UserIdentity;

            if (identity != null)
                return identity;
            else
                return null;

        }
    }

//    Literal ltlMessage;

    /*protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        //Response.Write(User.Permission("view"));
        //

        //System.Data.DataTable dt = User.BusniessArea;

        //if (!HttpContext.Current.User.Identity.IsAuthenticated)
        //{
        //    Response.Redirect("~/Admin/Login.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.RawUrl));
        //    Response.End();
        //}

        if (!User.CanView)
        {
            //Response.Write(Request.QueryString);
            //Response.Redirect("~/NoRight.aspx");
            //Response.End();
            Server.Transfer("~/NoRight.aspx", false);
        }

        //Control c = this.FinnalControl(this, "ltlMessage");
        //Response.Write(c);
        //Response.Write(this.User.BusniessLocationString);
    }*/

    /*protected override void OnLoad(EventArgs e)
    {
        Control c = this.FinnalControl(this, "ltlMessage");
        if (c != null && c is Literal)
        {
            ltlMessage = c as Literal;
            ltlMessage.Visible = false;
        }


        base.OnLoad(e);

    }*/


    /// <summary>
    /// 提示信息
    /// </summary>
    /// <param name="type">aSuccess|aError|aWarning|aInfo</param>
    /// <param name="title"></param>
    /// <param name="content"></param>
    /*protected void ShowTips(string type, string title, string content)
    {
        //Control c = this.FinnalControl(this, "ltlMessage");
        if (ltlMessage != null)
        {
            string html = "<h4 class='alertP " + type + "'><b>" + title + "</b><span>" + content + "</span></h4>";
            ltlMessage.Visible = true;
            ltlMessage.Text = html;
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "showTips", html);
        }
    }
    protected Control FinnalControl(Control p, string id)
    {
        Control ctrl = null;
        foreach (Control c in p.Controls)
        {
            //Response.Write(c.ID + "\r\n");
            if (c.ID == id)
                return c;
            if (!c.HasControls())
                continue;

            ctrl = FinnalControl(c, id);
        }

        return ctrl;
    }*/
    /// <summary>
    /// 导出Excel
    /// </summary>
    /// <param name="gridView">GridView</param>
    /// <param name="nameTitle">导出名称</param>
    public static void GridViewToExcel(GridView gridView, string strFileName)
    {
        #region <<====数据格式导出====>>

        HttpContext HC = HttpContext.Current;
        HC.Response.Clear();
        HC.Response.Buffer = true;
        HC.Response.ContentEncoding = System.Text.Encoding.UTF8;
        HC.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("GB2312");

        HC.Response.AddHeader("Content-Disposition", "attachment;filename=" + strFileName + ".xls");
        HC.Response.ContentType = "application/ms-excel";
        //HC.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;";

        string strStyle = "<style>td{mso-number-format:\"\\@\";}</style>";

        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        gridView.Visible = true;
        sw.WriteLine(strStyle);


        gridView.RenderControl(htw);
        if (gridView.Rows.Count > 0)
        {
            HC.Response.Write("\ufeff" + sw.ToString());
        }

        HC.Response.Flush();
        HC.Response.End();

        #endregion
    }
    ///// <summary>
    //导出Excel
    /// 这个重写貌似是必须的
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control) { }
    /// <summary>  
    /// 读取Excel文件到DataSet中  
    /// </summary>  
    /// <param name="filePath">文件路径</param>  
    /// <returns></returns>  
    public static DataSet ToDataTable(string filePath)
    {
        string connStr = "";
        string fileType = System.IO.Path.GetExtension(filePath);
        if (string.IsNullOrEmpty(fileType)) return null;

        if (fileType == ".xls")
            connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
        else
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filePath + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
        string sql_F = "Select * FROM [{0}]";

        OleDbConnection conn = null;
        OleDbDataAdapter da = null;
        DataTable dtSheetName = null;

        DataSet ds = new DataSet();
        try
        {
            // 初始化连接，并打开  
            conn = new OleDbConnection(connStr);
            conn.Open();

            // 获取数据源的表定义元数据                         
            string SheetName = "";
            dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            // 初始化适配器  
            da = new OleDbDataAdapter();
            for (int i = 0; i < dtSheetName.Rows.Count; i++)
            {
                SheetName = (string)dtSheetName.Rows[i]["TABLE_NAME"];

                if (SheetName.Contains("$") && !SheetName.Replace("'", "").EndsWith("$"))
                {
                    continue;
                }

                da.SelectCommand = new OleDbCommand(String.Format(sql_F, SheetName), conn);
                DataSet dsItem = new DataSet();
                //da.Fill(dsItem, tblName);
                da.Fill(dsItem);
                ds.Tables.Add(dsItem.Tables[0].Copy());
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("excel,ex:" + ex.Message + "|" + ex.StackTrace);
        }
        finally
        {
            // 关闭连接  
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                da.Dispose();
                conn.Dispose();
            }
        }
        return ds;
    } 
    /// <summary>
    /// SQL防注入方法，对每个查询字符串做检查
    /// </summary>
    /// <param name="strTextIn"></param>
    /// <returns></returns>
    public static string SqlInject(string strTextIn)
    {
        if ((strTextIn != null) && (strTextIn != ""))
        {
            string str = strTextIn.ToLower().Replace(" ", "%20");
            
            if (str.IndexOf("alert") != -1)
            {
                str = str.Replace("alert", " ");
            }
            if (str.IndexOf("%20and%20") != -1)
            {
                str = str.Replace("%20and%20", " ");
            }
            if (str.IndexOf("having") != -1)
            {
                str = str.Replace("having", " ");
            }
            if (str.IndexOf("%20db_name") != -1)
            {
                str = str.Replace("%20db_name", " ");
            }
            if (str.IndexOf("%20or%20") != -1)
            {
                str = str.Replace("%20or%20", " ");
            }
            if (str.IndexOf("net%20user") != -1)
            {
                str = str.Replace("net%20user", " ");
            }
            if (str.IndexOf("'") != -1)
            {
                str = str.Replace("'"," ");
            }
            if (str.IndexOf("/add") != -1)
            {
                str = str.Replace("/add", " ");
            }
            if (str.IndexOf("select%20") != -1)
            {
                str = str.Replace("select%20", " ");
            }
            if (str.IndexOf("insert%20") != -1)
            {
                str = str.Replace("insert%20", " ");
            }
            if (str.IndexOf("delete%20from") != -1)
            {
                str = str.Replace("delete%20from", " ");
            }
            if (str.IndexOf("drop%20") != -1)
            {
                str = str.Replace("drop%20", " ");
            }
            if (str.IndexOf("update%20") != -1)
            {
                str = str.Replace("update%20", " ");
            }
            if (str.IndexOf("truncate%20") != -1)
            {
                str = str.Replace("truncate%20", " ");
            }
            if (str.IndexOf("asc(") != -1)
            {
                str = str.Replace("asc(", " ");
            }
            if (str.IndexOf("mid(") != -1)
            {
                str = str.Replace("mid(", " ");
            }
            if (str.IndexOf("char(") != -1)
            {
                str = str.Replace("char(", " ");
            }
            if (str.IndexOf("count(") != -1)
            {
                str = str.Replace("count(", " ");
            }
            if (str.IndexOf("xp_cmdshell") != -1)
            {
                str = str.Replace("xp_cmdshell", " ");
            }
            if (str.IndexOf("exec%20master") != -1)
            {
                str = str.Replace("exec%20master", " ");
            }
            if (str.IndexOf("net%20localgroup%20administrators") != -1)
            {
                str = str.Replace("net%20localgroup%20administrators", " ");
            }
            return str;
        }
        else
        {
            return string.Empty;
        }
        
    }
}