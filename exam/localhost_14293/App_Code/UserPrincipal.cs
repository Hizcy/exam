using System;
using System.Data;
using System.Web;
using System.Security;
using System.Security.Principal;
using Exam.BLL;

/// <summary>
/// UserPrincipal 的摘要说明。
/// </summary>
public class UserPrincipal : IPrincipal
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    public UserPrincipal(UserIdentity user)
    {
        if (user != null && user.IsAuthenticated)
        {
            this._user = user;
        }
        else
        {
            throw new SecurityException("Can't create a principal without a valid user");
            //this._user = new User();
            //this._user.RoleId = 0;
            //this._user.Id = -1;
        }
    }

    private UserIdentity _user;
    /// <summary>
    /// 
    /// </summary>
    public IIdentity Identity
    {
        get { return this._user; }
    }
    
    private string _permissionKey;
    /// <summary>
    /// 权限关键字
    /// </summary>
    public string PermissionKey
    {
        get 
        {
            if (String.IsNullOrEmpty(this._permissionKey))
            {
                string appPath = HttpContext.Current.Request.ApplicationPath;
                if (!appPath.EndsWith("/")) appPath = appPath + "/";

                this._permissionKey = HttpContext.Current.Request.CurrentExecutionFilePath.Replace(appPath, "");
            }

            return this._permissionKey;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public bool IsInRole(string role)
    {
        //return this._user.IsInRole(role);
        return true;
    }
    /// <summary>
    /// 设置权限关键字
    /// </summary>
    /// <param name="key"></param>
    public void SetPermissionKey(string key)
    {
        this._permissionKey = key;
    }


    /// <summary>
    /// 权限值判断
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool Permission(string name)
    {
        bool result = false;
        DataRow[] rows = this._user.GetPermissionTable().Select("Key='" + PermissionKey + "'");
        //this.RoleID = 0;
        if (rows.Length == 0)
        {
            // 未定义的始终返回 True
            if (name.Equals("All", StringComparison.OrdinalIgnoreCase))
                result = false;
            else
                result = true;
        }
        else
        {
            foreach (DataRow row in rows)
            {
                if (row["Action"].ToString().Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    result = Convert.ToBoolean(row["Value"]);
                    break;
                }
            }
        }

        return result;
    }
    /// <summary>
    /// 具有浏览权限
    /// </summary>
    public bool CanView
    {
        get
        {
            bool result = this.Permission("View");
            if (!result && CanAdmin)
                return true;

            return result;
        }
    }
    /// <summary>
    /// 具有管理权限
    /// </summary>
    public bool CanAdmin
    {
        get { return this.Permission("All"); }
    }
    /// <summary>
    /// 具有超级登录权限
    /// </summary>
    public bool CanSuper
    {
        get
        {
            if (HttpContext.Current.Session["SuperAdmin"] == null)
                return false;
            else
            {
                return Convert.ToBoolean(HttpContext.Current.Session["SuperAdmin"]);
            }
        }
    }
}