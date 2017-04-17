// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_User.cs
// 项目名称：买车网
// 创建时间：2015/8/10
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Exam.DAL;
using Exam.Entity;
using System.Data;
using System.Linq;
using System.Web;

namespace Exam.BLL
{
    public partial class tb_UserBLL : BaseBLL< tb_UserBLL>

    {
        private string key = "USER_LIST";
        tb_UserDataAccessLayer tb_Userdal;
        public tb_UserBLL()
        {
            tb_Userdal = new tb_UserDataAccessLayer();
        }

        public int Insert(tb_UserEntity tb_UserEntity) 
        {
            //HttpContext.Current.Cache[key] = null;
            return tb_Userdal.Insert(tb_UserEntity);            
        }

        public void Update(tb_UserEntity tb_UserEntity)
        {
            //HttpContext.Current.Cache[key] = null;
            tb_Userdal.Update(tb_UserEntity);
        }

        public tb_UserEntity GetAdminSingle(int userId)
        {
           return tb_Userdal.Get_tb_UserEntity(userId);
        }

        public IList<tb_UserEntity> Gettb_UserList()
        {
            IList<tb_UserEntity> tb_UserList = new List<tb_UserEntity>();
            tb_UserList=tb_Userdal.Get_tb_UserAll();
            return tb_UserList;
        }

        public tb_UserEntity GetModelByNameAndPwd(string name, string pwd,string domain)
        {
            return tb_Userdal.GetModelByNameAndPwd(name, pwd,domain);
        }
        public tb_UserEntity GetStudentByNameAndPwd(string name, string pwd, string domain)
        {
            return tb_Userdal.GetStudentByNameAndPwd(name, pwd,domain);
        }
        public DataSet GetList(int pagesize, int currentindex, string condition, out int allcount)
        {
            return PageData.GetDataByPage("v_Agents", "UserId", "UserId desc", currentindex, pagesize, "*", condition, out allcount);
        }
        public DataSet GetListUser(int pagesize, int currentindex, string condition, out int allcount)
        {
            return PageData.GetDataByPage("v_User", "UserId", "UserId desc", currentindex, pagesize, "*", condition, out allcount);
        }

        public tb_UserEntity GetModel(DataRow dr)
        {
            return tb_Userdal.GetModel(dr);
            
        }
        public tb_UserEntity GetModelByNameSchoolId(string name,int schoolId)
        {
            return tb_Userdal.GetModelByNameSchoolId(name,schoolId);
        }
        public IList<tb_UserEntity> GetNameBySchoolIdRoleId(int schoolId,int roleId)
        {
            IList<tb_UserEntity> tb_UserList = new List<tb_UserEntity>();
            tb_UserList = tb_Userdal.GetNameBySchoolIdRoleId(schoolId,roleId);
            return tb_UserList;
        }
        public int GetPeopleNumber(string className,int schoolId)
        {
            return tb_Userdal.GetClassPeopleNumber(className,schoolId);
        }
        public int GetTeacherAdminNumber(int schoolId)
        {
            return tb_Userdal.GetTeacherAdminNumber(schoolId);
        }
        public DataSet GetStatus0List()
        {
            return tb_Userdal.GetStatus0List();
        }
        public int UpdateByUserId(string userId)
        {
            return tb_Userdal.UpdateByUserId(userId);
        }

        public DataSet GetListUser(string where)
        {
            return tb_Userdal.GetListUser(where);
        }
        public tb_UserEntity loginCheck(string name, string domain)
        {
            return tb_Userdal.loginCheck(name, domain);
        }

        public tb_UserEntity GetStudentByNameAndPwd(string name,  string domain)
        {
            return tb_Userdal.GetStudentByNameAndPwd(name, domain);
        }
        public IList<tb_UserEntity> GetAgentList()
        {
            return tb_Userdal.GetAgentList();
        }
        #region 通过缓存
        //public IList<tb_UserEntity> GetUserListByCache()
        //{
        //    if (HttpContext.Current.Cache[key] != null)
        //    {
        //        return HttpContext.Current.Cache[key] as IList<tb_UserEntity>;
        //    }
        //    else
        //    {
        //        IList<tb_UserEntity> list = Exam.BLL.tb_UserBLL.GetInstance().Gettb_UserList();
        //        if (list == null)
        //            return new List<tb_UserEntity>();
        //        HttpContext.Current.Cache.Insert(key, list, null, DateTime.Now.AddHours(1), TimeSpan.Zero);
        //        return list;
        //    }
        //}
        //public tb_UserEntity GetAdminSingleByCache(int userId)
        //{
        //    IList<tb_UserEntity> list = GetUserListByCache();
        //    return list.FirstOrDefault(c => c.UserId == userId);
        //}
        //public tb_UserEntity GetModelByNameSchoolIdByCache(string name, int schoolId)
        //{
        //    IList<tb_UserEntity> list = GetUserListByCache();
        //    return list.FirstOrDefault(c => c.Name == name && c.SchoolId == schoolId);
        //}
        //public IList<tb_UserEntity> GetNameBySchoolIdRoleIdByCache(int schoolId, int roleId)
        //{
        //    IList<tb_UserEntity> list = GetUserListByCache();
        //    return list.Where(c => c.SchoolId == schoolId && c.RoleId== roleId && c.Status==1).ToList();
        //}
        #endregion
    }
}
