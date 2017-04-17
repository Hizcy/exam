// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Result.cs
// 项目名称：买车网
// 创建时间：2015/8/27
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Exam.DAL;
using Exam.Entity;
using System.Data;

namespace Exam.BLL
{
    public partial class tb_ResultBLL : BaseBLL< tb_ResultBLL>

    {
        tb_ResultDataAccessLayer tb_Resultdal;
        public tb_ResultBLL()
        {
            tb_Resultdal = new tb_ResultDataAccessLayer();
        }

        public int Insert(tb_ResultEntity tb_ResultEntity)
        {
            return tb_Resultdal.Insert(tb_ResultEntity);            
        }

        public void Update(tb_ResultEntity tb_ResultEntity)
        {
            tb_Resultdal.Update(tb_ResultEntity);
        }

        public tb_ResultEntity GetAdminSingle(int resultId)
        {
           return tb_Resultdal.Get_tb_ResultEntity(resultId);
        }

        public IList<tb_ResultEntity> Gettb_ResultList()
        {
            IList<tb_ResultEntity> tb_ResultList = new List<tb_ResultEntity>();
            tb_ResultList=tb_Resultdal.Get_tb_ResultAll();
            return tb_ResultList;
        }
        public IList<tb_ResultEntity> GetListByUserId(int userid)
        {
            IList<tb_ResultEntity> tb_ResultList = new List<tb_ResultEntity>();
            tb_ResultList = tb_Resultdal.GetListByUserId(userid);
            return tb_ResultList;
        }
        public IList<tb_ResultEntity> GetListByUserIdScore(int userid)
        {
            IList<tb_ResultEntity> tb_ResultList = new List<tb_ResultEntity>();
            tb_ResultList = tb_Resultdal.GetListByUserIdScore(userid);
            return tb_ResultList;
        }
        public DataSet GetListByDepartmentId(int departmentid)
        {
            return tb_Resultdal.GetListByDepartmentId(departmentid);
        }
        public IList<tb_ResultEntity> GetListByUserId(string userId)
        {
            IList<tb_ResultEntity> tb_ResultList = new List<tb_ResultEntity>();
            tb_ResultList = tb_Resultdal.GetListByUserId(userId);
            return tb_ResultList;
        }
        public DataSet GetStatListByUserId(int userid)
        {
            return tb_Resultdal.GetStatListByUserId(userid);
        }
   
    }
}
