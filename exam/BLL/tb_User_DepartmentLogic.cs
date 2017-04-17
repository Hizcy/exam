// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_User_Department.cs
// 项目名称：买车网
// 创建时间：2015/8/24
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Exam.DAL;
using Exam.Entity;

namespace Exam.BLL
{
    public partial class tb_User_DepartmentBLL : BaseBLL< tb_User_DepartmentBLL>

    {
        tb_User_DepartmentDataAccessLayer tb_User_Departmentdal;
        public tb_User_DepartmentBLL()
        {
            tb_User_Departmentdal = new tb_User_DepartmentDataAccessLayer();
        }

        public int Insert(tb_User_DepartmentEntity tb_User_DepartmentEntity)
        {
            return tb_User_Departmentdal.Insert(tb_User_DepartmentEntity);            
        }

        public void Update(tb_User_DepartmentEntity tb_User_DepartmentEntity)
        {
            tb_User_Departmentdal.Update(tb_User_DepartmentEntity);
        }

        public tb_User_DepartmentEntity GetAdminSingle(int relationId)
        {
           return tb_User_Departmentdal.Get_tb_User_DepartmentEntity(relationId);
        }

        public IList<tb_User_DepartmentEntity> Gettb_User_DepartmentList()
        {
            IList<tb_User_DepartmentEntity> tb_User_DepartmentList = new List<tb_User_DepartmentEntity>();
            tb_User_DepartmentList=tb_User_Departmentdal.Get_tb_User_DepartmentAll();
            return tb_User_DepartmentList;
        }
        public tb_User_DepartmentEntity GetAdminByUserId(int userId)
        {
            return tb_User_Departmentdal.Get_User_DepartmentEntityByUserId(userId);
        }
        public tb_User_DepartmentEntity GetAdminBySchoolId(int schoolId)
        {
            return tb_User_Departmentdal.Get_User_DepartmentEntityBySchoolId(schoolId);
        }
        public int Delete(int relationId)
        {
            return tb_User_Departmentdal.Delete(relationId);
        }
    }
}
