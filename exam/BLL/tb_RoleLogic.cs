// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Role.cs
// 项目名称：买车网
// 创建时间：2015/8/10
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Exam.DAL;
using Exam.Entity;

namespace Exam.BLL
{
    public partial class tb_RoleBLL : BaseBLL< tb_RoleBLL>

    {
        tb_RoleDataAccessLayer tb_Roledal;
        public tb_RoleBLL()
        {
            tb_Roledal = new tb_RoleDataAccessLayer();
        }

        public int Insert(tb_RoleEntity tb_RoleEntity)
        {
            return tb_Roledal.Insert(tb_RoleEntity);            
        }

        public void Update(tb_RoleEntity tb_RoleEntity)
        {
            tb_Roledal.Update(tb_RoleEntity);
        }

        public tb_RoleEntity GetAdminSingle(int roleId)
        {
           return tb_Roledal.Get_tb_RoleEntity(roleId);
        }

        public IList<tb_RoleEntity> Gettb_RoleList()
        {
            IList<tb_RoleEntity> tb_RoleList = new List<tb_RoleEntity>();
            tb_RoleList=tb_Roledal.Get_tb_RoleAll();
            return tb_RoleList;
        }
    }
}
