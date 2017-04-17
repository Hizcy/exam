// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_School_QuestionCls.cs
// 项目名称：买车网
// 创建时间：2015/8/29
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
    public partial class tb_School_QuestionClsBLL : BaseBLL< tb_School_QuestionClsBLL>

    {
        tb_School_QuestionClsDataAccessLayer tb_School_QuestionClsdal;
        public tb_School_QuestionClsBLL()
        {
            tb_School_QuestionClsdal = new tb_School_QuestionClsDataAccessLayer();
        }

        public int Insert(tb_School_QuestionClsEntity tb_School_QuestionClsEntity)
        {
            return tb_School_QuestionClsdal.Insert(tb_School_QuestionClsEntity);            
        }

        public void Update(tb_School_QuestionClsEntity tb_School_QuestionClsEntity)
        {
            tb_School_QuestionClsdal.Update(tb_School_QuestionClsEntity);
        }

        public tb_School_QuestionClsEntity GetAdminSingle(int relationId)
        {
           return tb_School_QuestionClsdal.Get_tb_School_QuestionClsEntity(relationId);
        }

        public IList<tb_School_QuestionClsEntity> Gettb_School_QuestionClsList()
        {
            IList<tb_School_QuestionClsEntity> tb_School_QuestionClsList = new List<tb_School_QuestionClsEntity>();
            tb_School_QuestionClsList=tb_School_QuestionClsdal.Get_tb_School_QuestionClsAll();
            return tb_School_QuestionClsList;
        }
        //判断转态
        public DataSet Get_School_QuestionClsRelationIdBySchoolId(int schoolId,int parentId)
        {
            return tb_School_QuestionClsdal.Get_School_QuestionClsRelationIdBySchoolId(schoolId, parentId);
        }
        public int Delete(int relationId)
        {
            return tb_School_QuestionClsdal.Delete(relationId);
        }
        public tb_School_QuestionClsEntity GetSchoolQuestionListByQuestionIdSchoolId(int questionId,int schoolId)
        {
            return tb_School_QuestionClsdal.GetSchoolQuestionClsEntityByQuestionIdSchoolId(questionId, schoolId);
        }
    }
}
