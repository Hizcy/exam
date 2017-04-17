// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Department.cs
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
    public partial class tb_DepartmentBLL : BaseBLL< tb_DepartmentBLL>
    {
        private string key = "DEPARTMENT_LIST_{0}";
        tb_DepartmentDataAccessLayer tb_Departmentdal;
        public tb_DepartmentBLL() 
        {
            tb_Departmentdal = new tb_DepartmentDataAccessLayer();
        }

        public int Insert(tb_DepartmentEntity tb_DepartmentEntity)
        {
            if (HttpContext.Current.Cache[key] != null)
            {
                HttpContext.Current.Cache.Remove(key);
            }
            return tb_Departmentdal.Insert(tb_DepartmentEntity);            
        }

        public void Update(tb_DepartmentEntity tb_DepartmentEntity)
        {
            if (HttpContext.Current.Cache[key] != null)
            {
                HttpContext.Current.Cache.Remove(key);
            }
            tb_Departmentdal.Update(tb_DepartmentEntity);
        }

        public tb_DepartmentEntity GetAdminSingle(int departmentId)
        {
           return tb_Departmentdal.Get_tb_DepartmentEntity(departmentId);
        }

        public IList<tb_DepartmentEntity> Gettb_DepartmentSchoolIdAll()
        {
            IList<tb_DepartmentEntity> tb_DepartmentList = new List<tb_DepartmentEntity>();
            tb_DepartmentList = tb_Departmentdal.Get_tb_DepartmentSchoolIdAll();
            return tb_DepartmentList;
        }
        public IList<tb_DepartmentEntity> Gettb_DepartmentSchoolIdList(int schoolid)
        {
            IList<tb_DepartmentEntity> tb_DepartmentList = new List<tb_DepartmentEntity>();
            tb_DepartmentList = tb_Departmentdal.Get_tb_DepartmentBySchoolId(schoolid);
            return tb_DepartmentList;
        }
        public IList<tb_DepartmentEntity> Gettb_DepartmentParentIdList(int parentid)
        {
            IList<tb_DepartmentEntity> tb_DepartmentList = new List<tb_DepartmentEntity>();
            tb_DepartmentList = tb_Departmentdal.Get_tb_DepartmentByParentID(parentid);
            return tb_DepartmentList;
        }
        public IList<tb_DepartmentEntity> Gettb_DepartmentSchoolIdListTow(int schoolid)
        {
            IList<tb_DepartmentEntity> tb_DepartmentList = new List<tb_DepartmentEntity>();
            tb_DepartmentList = tb_Departmentdal.Get_tb_DepartmentBySchoolIdTow(schoolid);
            return tb_DepartmentList;
        }
        public int Delete_DepartmentByDepartmentId(int departmentId)
        {
            return tb_Departmentdal.Delete_tbDepartmentByDepartmentId(departmentId);
        }
        public int Delete_DepartmentByParentId(int parentId)
        {
            return tb_Departmentdal.Delete_tbDepartmentByParentId(parentId);
        }
        public tb_DepartmentEntity Get_DepartmentEntityBySchoolIdName(int schoolid, string name)
        {
            return tb_Departmentdal.Get_DepartmentBySchoolIdName(schoolid, name);
        }
        public tb_DepartmentEntity Get_DepartmentEntityBySchoold(int schoolid)
        {
            return tb_Departmentdal.Get_DepartmentEntityBySchoolId(schoolid);
        }
        public IList<tb_DepartmentEntity> Get_DepartmentBySchoolIdList(int schoolid)
        {
            IList<tb_DepartmentEntity> tb_DepartmentList = new List<tb_DepartmentEntity>();
            tb_DepartmentList = tb_Departmentdal.Get_DepartmentBySchoolIdList(schoolid);
            return tb_DepartmentList;
        }
        public IList<tb_DepartmentEntity> Gettb_DepartmentParentIdListNowStatus(int parentid)
        {
            IList<tb_DepartmentEntity> tb_DepartmentList = new List<tb_DepartmentEntity>();
            tb_DepartmentList = tb_Departmentdal.Get_tb_DepartmentByParentIdNowSataus(parentid);
            return tb_DepartmentList;
        }
        public DataSet Get_DepartmentDataset(string parentid,int shcoolId)
        {
            return tb_Departmentdal.Get_DepartmentDataSet(parentid,shcoolId);
        }
        public DataSet Get_DepartmentDatasetByDepartmentId(string departmentId, int shcoolId)
        {
            return tb_Departmentdal.Get_DepartmentDataSetByDepartmentId(departmentId, shcoolId);
        }
        public DataSet Get_DepartmentDatasetId(string departmentId, int shcoolId)
        {
            return tb_Departmentdal.Get_DepartmentDataSetId(departmentId, shcoolId);
        }
        public DataSet Get_DepartmentDatasetIdThree(string departmentId, int shcoolId,int parentId)
        {
            return tb_Departmentdal.Get_DepartmentDataSetIdThree(departmentId, shcoolId,parentId);
        }
        public DataSet GetYearClassName(int schoolId, int roleId)
        {
            return tb_Departmentdal.GetYearClassName(schoolId, roleId);
        }
        #region
        public IList<tb_DepartmentEntity> GetDepartmentListByCache(int schoolid)
        {
            key = string.Format(key, schoolid);
            if (HttpContext.Current.Cache[key] != null)
            {
                return HttpContext.Current.Cache[key] as IList<tb_DepartmentEntity>;
            }
            else
            {
                IList<tb_DepartmentEntity> list = Exam.BLL.tb_DepartmentBLL.GetInstance().Gettb_DepartmentSchoolIdList(schoolid);
                if (list == null)
                    return new List<tb_DepartmentEntity>();
                HttpContext.Current.Cache.Insert(key, list, null, DateTime.Now.AddHours(1), TimeSpan.Zero);
                return list;
            }
        }
        public tb_DepartmentEntity GetAdminSingleByCache(int departmentId,int schoolid)
        {
            IList<tb_DepartmentEntity> list = GetDepartmentListByCache(schoolid);
            if (list != null && list.Count > 0)
            {
                return list.FirstOrDefault(c => c.DepartmentId == departmentId);
            }
            return null;
        }
        #endregion
    }
}
