// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_ResultExt.cs
// 项目名称：买车网
// 创建时间：2015/8/27
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Exam.DAL;
using Exam.Entity;

namespace Exam.BLL
{
    public partial class tb_ResultExtBLL : BaseBLL< tb_ResultExtBLL>

    {
        tb_ResultExtDataAccessLayer tb_ResultExtdal;
        public tb_ResultExtBLL()
        {
            tb_ResultExtdal = new tb_ResultExtDataAccessLayer();
        }

        public int Insert(tb_ResultExtEntity tb_ResultExtEntity)
        {
            return tb_ResultExtdal.Insert(tb_ResultExtEntity);            
        }

        public void Update(tb_ResultExtEntity tb_ResultExtEntity)
        {
            tb_ResultExtdal.Update(tb_ResultExtEntity);
        }

        public tb_ResultExtEntity GetAdminSingle(int extId)
        {
           return tb_ResultExtdal.Get_tb_ResultExtEntity(extId);
        }

        public IList<tb_ResultExtEntity> Gettb_ResultExtList()
        {
            IList<tb_ResultExtEntity> tb_ResultExtList = new List<tb_ResultExtEntity>();
            tb_ResultExtList=tb_ResultExtdal.Get_tb_ResultExtAll();
            return tb_ResultExtList;
        }

        public void InsertSelect(List<tb_ResultExtEntity> list)
        {
            tb_ResultExtdal.InsertSelect(list);
        }
    }
}
