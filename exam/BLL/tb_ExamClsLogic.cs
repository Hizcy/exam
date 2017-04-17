// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_ExamCls.cs
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
    public partial class tb_ExamClsBLL : BaseBLL< tb_ExamClsBLL>

    {
        tb_ExamClsDataAccessLayer tb_ExamClsdal;
        public tb_ExamClsBLL()
        {
            tb_ExamClsdal = new tb_ExamClsDataAccessLayer();
        }

        public int Insert(tb_ExamClsEntity tb_ExamClsEntity)
        {
            return tb_ExamClsdal.Insert(tb_ExamClsEntity);            
        }

        public void Update(tb_ExamClsEntity tb_ExamClsEntity)
        {
            tb_ExamClsdal.Update(tb_ExamClsEntity);
        }

        public tb_ExamClsEntity GetAdminSingle(int examClsId)
        {
           return tb_ExamClsdal.Get_tb_ExamClsEntity(examClsId);
        }

        public IList<tb_ExamClsEntity> Gettb_ExamClsList()
        {
            IList<tb_ExamClsEntity> tb_ExamClsList = new List<tb_ExamClsEntity>();
            tb_ExamClsList=tb_ExamClsdal.Get_tb_ExamClsAll();
            return tb_ExamClsList;
        }
        public IList<tb_ExamClsEntity> Gettb_ExamClsSchoolIdOne(int schoolId)
        {
            IList<tb_ExamClsEntity> tb_ExamClsList = new List<tb_ExamClsEntity>();
            tb_ExamClsList = tb_ExamClsdal.Get_tb_ExamClsSchoolIdOne(schoolId);
            return tb_ExamClsList;
        }
        public IList<tb_ExamClsEntity> Gettb_ExamClsParentIdTow(int parentId)
        {
            IList<tb_ExamClsEntity> tb_ExamClsList = new List<tb_ExamClsEntity>();
            tb_ExamClsList = tb_ExamClsdal.Get_tb_ExamClsParentIdTow(parentId);
            return tb_ExamClsList;
        }
    }
}
