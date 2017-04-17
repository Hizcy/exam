// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_ExampaperExt.cs
// 项目名称：买车网
// 创建时间：2015/8/17
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Exam.DAL;
using Exam.Entity;

namespace Exam.BLL
{
    public partial class tb_ExampaperExtBLL : BaseBLL< tb_ExampaperExtBLL>

    {
        tb_ExampaperExtDataAccessLayer tb_ExampaperExtdal;
        public tb_ExampaperExtBLL()
        {
            tb_ExampaperExtdal = new tb_ExampaperExtDataAccessLayer();
        }

        public int Insert(tb_ExampaperExtEntity tb_ExampaperExtEntity)
        {
            return tb_ExampaperExtdal.Insert(tb_ExampaperExtEntity);            
        }

        public void Update(tb_ExampaperExtEntity tb_ExampaperExtEntity)
        {
            tb_ExampaperExtdal.Update(tb_ExampaperExtEntity);
        }

        public tb_ExampaperExtEntity GetAdminSingle(int extId)
        {
           return tb_ExampaperExtdal.Get_tb_ExampaperExtEntity(extId);
        }

        public IList<tb_ExampaperExtEntity> Gettb_ExampaperExtList()
        {
            IList<tb_ExampaperExtEntity> tb_ExampaperExtList = new List<tb_ExampaperExtEntity>();
            tb_ExampaperExtList=tb_ExampaperExtdal.Get_tb_ExampaperExtAll();
            return tb_ExampaperExtList;
        }
        public IList<tb_ExampaperExtEntity> GetListByExampaperId(int exampaperId)
        {
            IList<tb_ExampaperExtEntity> tb_ExampaperExtList = new List<tb_ExampaperExtEntity>();
            tb_ExampaperExtList = tb_ExampaperExtdal.GetListByExampaperId(exampaperId);
            return tb_ExampaperExtList;
        }
        public int Delete(int exampaperId)
        {
            return tb_ExampaperExtdal.DeleteByExampaperId(exampaperId);
        }
    }
}
