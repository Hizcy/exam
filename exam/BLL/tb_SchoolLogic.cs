// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_School.cs
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
using System.Web;
using System.Linq;

namespace Exam.BLL
{
    public partial class tb_SchoolBLL : BaseBLL< tb_SchoolBLL>

    {
        private string key = "SCHOOL_LIST";
        tb_SchoolDataAccessLayer tb_Schooldal;
        public tb_SchoolBLL()
        {
            tb_Schooldal = new tb_SchoolDataAccessLayer();
        }

        public int Insert(tb_SchoolEntity tb_SchoolEntity)
        {
          //  HttpContext.Current.Cache[key] = null;
            return tb_Schooldal.Insert(tb_SchoolEntity);            
        }

        public void Update(tb_SchoolEntity tb_SchoolEntity)
        {
            //  HttpContext.Current.Cache[key] = null;
            if (HttpContext.Current.Cache[key] != null)
            {
                HttpContext.Current.Cache.Remove(key);
            }
            tb_Schooldal.Update(tb_SchoolEntity);
        }

        public tb_SchoolEntity GetAdminSingle(int schoolId)
        {
           return tb_Schooldal.Get_tb_SchoolEntity(schoolId);
        }
        public IList<tb_SchoolEntity> Gettb_SchoolList()
        {
            IList<tb_SchoolEntity> tb_SchoolList = new List<tb_SchoolEntity>();
            tb_SchoolList=tb_Schooldal.Get_tb_SchoolAll();
            return tb_SchoolList;
        }
        public tb_SchoolEntity GetModel(string domain)
        {
            return tb_Schooldal.GetModel(domain);
        }

        public int InsertSchool(string domain, string schoolname, int locationid, string realname, int sex, string phone, string mail, string pwd,int agent,int flag =0)
        {
            return tb_Schooldal.InsertSchool(domain, schoolname, locationid,realname,sex,phone,mail,pwd,agent,flag);
        }
        public DataSet GetList(int pagesize, int currentindex, string condition, out int allcount)
        {
            return PageData.GetDataByPage("v_School", "SchoolId", "SchoolId desc", currentindex, pagesize, "*", condition, out allcount);
        }
        #region
        public IList<tb_SchoolEntity> GetSchoolListByCache()
        {
            
            if (HttpContext.Current.Cache[key] != null)
            {
                return HttpContext.Current.Cache[key] as IList<tb_SchoolEntity>;
            }
            else
            {
                IList<tb_SchoolEntity> list = Exam.BLL.tb_SchoolBLL.GetInstance().Gettb_SchoolList();
                if(list == null)
                    return new List<tb_SchoolEntity>(); 
                HttpContext.Current.Cache.Insert(key,list,null,DateTime.Now.AddHours(1),TimeSpan.Zero);
                return list;
            }
        }
        public tb_SchoolEntity GetAdminSingleByCache(int schoolId)
        {
            IList<tb_SchoolEntity> list = GetSchoolListByCache();
            return list.FirstOrDefault(c => c.SchoolId == schoolId);
        }
        public tb_SchoolEntity GetModelByCache(string domain)
        {
            IList<tb_SchoolEntity> list = GetSchoolListByCache();
            return list.FirstOrDefault(c=>c.Domain==domain);
        }
        #endregion
    }
}
