   using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;

public partial class user_ImportName : System.Web.UI.Page
{
    public int schoolId
    {
        get
        {
            UserIdentity identity = User.Identity as UserIdentity;
            if (identity == null)
            {
                return 0;
            }
            return identity._schoolID;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    public static DataSet ToDataTable(string filePath)
    {
        string connStr = "";
        string fileName = "";
        string fileType = System.IO.Path.GetExtension(fileName);
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            bool flage = false;
            string strName = uploadInput.FileName;
            int i = strName.LastIndexOf(".");//获取。的索引顺序号，在这里。代表图片名字与后缀的间隔
            string kzm = strName.Substring(i);//获取文件扩展名的另一种方法 string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            string path = Request.PhysicalApplicationPath;
            path += @"userinfo\";
            string strPath = path +Guid.NewGuid().ToString()+kzm;
            if (uploadInput.HasFile)
            {
                String[] allowedExtensions = { ".xls", ".xlsx" };
                for (int j = 0; j < allowedExtensions.Length; j++)
                {
                    if (kzm == allowedExtensions[j])
                    {
                        flage = true;
                    }
                }
            }
            if (flage)
            {
                // 判定该路径是否存在 
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                uploadInput.PostedFile.SaveAs(strPath);//将图片存储到服务器上
                DataSet ds = BasePage.ToDataTable(strPath);
                Exam.Entity.tb_DepartmentEntity tmodel=Exam.BLL.tb_DepartmentBLL.GetInstance().Get_DepartmentEntityBySchoold(schoolId);
                if (tmodel != null)
                {

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        //Jnwf.Utils.Log.Logger.Log4Net.Error("importname,ds:y");
                        List<Exam.Entity.tb_UserEntity> list = new List<Exam.Entity.tb_UserEntity>();
                        int schoolidnum = schoolId + 10000;


                        DataSet tds = Exam.BLL.tb_DepartmentBLL.GetInstance().GetYearClassName(schoolId, 3);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            int classid = 0;
                            int parentid = 0;
                            Exam.Entity.tb_UserEntity model = Exam.BLL.tb_UserBLL.GetInstance().GetModel(dr);
                            model.SchoolId = schoolId;
                            if (model != null && model.Pwd != "" && model.RealName != "")
                            {
                                //学生
                                if (model.RoleId == 3)
                                {
                                    string className = model.Description;
                                    if (model.Description != "")
                                    {
                                        //班级总人数
                                        int num = Exam.BLL.tb_UserBLL.GetInstance().GetPeopleNumber(className, schoolId);
                                        //一年级2班
                                        int index = className.IndexOf('级');
                                        //班级名
                                        string classStr = className.Substring(index + 1, className.Length - 2 - index);
                                        if (classStr.Length == 1)
                                        {
                                            classStr = "0" + classStr;//班级序号02
                                        }
                                        //年级名
                                        int tyearname = className.IndexOf('年');
                                        string yearStr = className.Substring(0, tyearname);
                                        string[] str = { "一", "二", "三", "四", "五", "六", "七", "八", "九","十","十一","十二" };
                                        int yearnum = 0;
                                        string yearnum2 = "";
                                        foreach (string year in str)
                                        {
                                            yearnum++;
                                            if (yearnum < 10)
                                            {
                                                if (yearStr.Equals(year))
                                                {
                                                    yearnum2 = "0" + yearnum.ToString();//年级序号01
                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                if (yearStr.Equals(year))
                                                {
                                                    yearnum2 = yearnum.ToString();//年级序号01
                                                    continue;
                                                }
                                            }
                                        }
                                        string numend = "000" + (num + 1).ToString();
                                        numend = numend.Substring(numend.Length - 3, 3);
                                        string name = schoolidnum.ToString() + yearnum2 + classStr + numend;
                                        model.Name = name;//用户名
                                        foreach (DataRow row in tds.Tables[0].Rows)   ///遍历所有的行
                                        {
                                            if (row["name"].ToString().Equals(className))
                                            {
                                                classid = int.Parse(row["DepartmentId"].ToString());
                                                parentid = int.Parse(row["parentid"].ToString());
                                                continue;
                                            }
                                        }
                                        model.DepartmentId = classid;//所属班级id
                                        model.Path = "/" + tmodel.DepartmentId + "/" + parentid + "/" + classid + "/";
                                        model.Addtime = DateTime.Now;
                                        Exam.BLL.tb_UserBLL.GetInstance().Insert(model);
                                    }
                                }
                                //教师管理员
                                else
                                {
                                    int jsnum = Exam.BLL.tb_UserBLL.GetInstance().GetTeacherAdminNumber(schoolId);
                                    string numstr = "0000000" + (jsnum + 1).ToString();
                                    numstr = schoolidnum + numstr.Substring(numstr.Length - 7, 7);
                                    model.DepartmentId = 0;
                                    model.Path = "/" + tmodel.DepartmentId + "/";
                                    model.Name = numstr;
                                    model.Addtime = DateTime.Now;
                                    Exam.BLL.tb_UserBLL.GetInstance().Insert(model);
                                }

                            }
                        }
                        MessageBox.ShowMsg(this, "保存成功！");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("importname,ex:" + ex.Message + "|" + ex.StackTrace);
        }
    }
}

//IList<Exam.Entity.tb_UserEntity> tmodel=Exam.BLL.tb_UserBLL.GetInstance().GetNameBySchoolIdRoleId
////查询user表中的数据
//temp = Exam.BLL.tb_UserBLL.GetInstance().GetModelByNameSchoolId(model.Name, schoolId);
//if (temp != null)
//{
//    b = false;
//    break;
//}
////与excel对比
//temp = list.FirstOrDefault(c => c.Name == model.Name);
//if (temp != null)
//{
//    b = false;
//    break;
//}
//else
//{
//    model.SchoolId = schoolId;
//    model.DepartmentId = int.Parse(hid.Value.ToString());
//    model.Status = 1;
//    model.Addtime = DateTime.Now;
//    model.RoleId = int.Parse(dlljs.SelectedValue);
//    list.Add(model);
//}