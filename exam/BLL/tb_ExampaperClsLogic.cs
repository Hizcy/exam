// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_ExampaperCls.cs
// 项目名称：买车网
// 创建时间：2015/8/13
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Exam.DAL;
using Exam.Entity;

namespace Exam.BLL
{
    public partial class tb_ExampaperClsBLL : BaseBLL< tb_ExampaperClsBLL>

    {
        tb_ExampaperClsDataAccessLayer tb_ExampaperClsdal;
        public tb_ExampaperClsBLL()
        {
            tb_ExampaperClsdal = new tb_ExampaperClsDataAccessLayer();
        }

        public int Insert(tb_ExampaperClsEntity tb_ExampaperClsEntity)
        {
            return tb_ExampaperClsdal.Insert(tb_ExampaperClsEntity);            
        }

        public void Update(tb_ExampaperClsEntity tb_ExampaperClsEntity)
        {
            tb_ExampaperClsdal.Update(tb_ExampaperClsEntity);
        }

        public tb_ExampaperClsEntity GetAdminSingle(int exampaperClsId)
        {
           return tb_ExampaperClsdal.Get_tb_ExampaperClsEntity(exampaperClsId);
        }

        public IList<tb_ExampaperClsEntity> Gettb_ExampaperClsList()
        {
            IList<tb_ExampaperClsEntity> tb_ExampaperClsList = new List<tb_ExampaperClsEntity>();
            tb_ExampaperClsList=tb_ExampaperClsdal.Get_tb_ExampaperClsAll();
            return tb_ExampaperClsList;
        }
        public IList<tb_ExampaperClsEntity> Gettb_ExampaperClsBySchoolIdOne(int schoolId)
        {
            IList<tb_ExampaperClsEntity> tb_ExampaperClsList = new List<tb_ExampaperClsEntity>();
            tb_ExampaperClsList = tb_ExampaperClsdal.Get_tb_ExampaperClsOne(schoolId);
            return tb_ExampaperClsList;
        }
        public IList<tb_ExampaperClsEntity> Gettb_ExampaperClsByParentIdTow(int parentId)
        {
            IList<tb_ExampaperClsEntity> tb_ExampaperClsList = new List<tb_ExampaperClsEntity>();
            tb_ExampaperClsList = tb_ExampaperClsdal.Get_tb_ExampaperClsTow(parentId);
            return tb_ExampaperClsList;
        }

    }
}
