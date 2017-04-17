// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_QuestionCls.cs
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

namespace Exam.BLL
{
    public partial class tb_QuestionClsBLL : BaseBLL< tb_QuestionClsBLL>

    {
        tb_QuestionClsDataAccessLayer tb_QuestionClsdal;
        public tb_QuestionClsBLL()
        {
            tb_QuestionClsdal = new tb_QuestionClsDataAccessLayer();
        }

        public int Insert(tb_QuestionClsEntity tb_QuestionClsEntity)
        {
            return tb_QuestionClsdal.Insert(tb_QuestionClsEntity);            
        }

        public void Update(tb_QuestionClsEntity tb_QuestionClsEntity)
        {
            tb_QuestionClsdal.Update(tb_QuestionClsEntity);
        }

        public tb_QuestionClsEntity GetAdminSingle(int questionClsId)
        {
           return tb_QuestionClsdal.Get_tb_QuestionClsEntity(questionClsId);
        }

        public IList<tb_QuestionClsEntity> Gettb_QuestionClsList()
        {
            IList<tb_QuestionClsEntity> tb_QuestionClsList = new List<tb_QuestionClsEntity>();
            tb_QuestionClsList=tb_QuestionClsdal.Get_tb_QuestionClsAll();
            return tb_QuestionClsList;
        }
        public IList<tb_QuestionClsEntity> Gettb_QuestionClsListSchoolIdOne(int schoolId)
        {
            IList<tb_QuestionClsEntity> tb_QuestionClsList = new List<tb_QuestionClsEntity>();
            tb_QuestionClsList = tb_QuestionClsdal.Get_tb_QuestionClsBySchoolIdOne(schoolId);
            return tb_QuestionClsList;
        }
        public IList<tb_QuestionClsEntity> Gettb_QuestionClsListParentIdTow(int parentId)
        {
            IList<tb_QuestionClsEntity> tb_QuestionClsList = new List<tb_QuestionClsEntity>();
            tb_QuestionClsList = tb_QuestionClsdal.Get_tb_QuestionClsByParentIdTow(parentId);
            return tb_QuestionClsList;
        }
        public DataSet Gettb_QuestionClsListParentId(int parentId)
        {
            return tb_QuestionClsdal.Get_tb_QuestionClsByParentId(parentId);
        }

        public int Delete(int questionId)
        {
            return tb_QuestionClsdal.Delete(questionId);
        }
        public IList<tb_QuestionClsEntity> QuestionClsList()
        {
            IList<tb_QuestionClsEntity> tb_QuestionClsList = new List<tb_QuestionClsEntity>();
            tb_QuestionClsList = tb_QuestionClsdal.QuestionClsList();
            return tb_QuestionClsList;
        }
    }
}
