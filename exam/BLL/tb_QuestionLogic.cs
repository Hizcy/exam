// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Question.cs
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
    public partial class tb_QuestionBLL : BaseBLL< tb_QuestionBLL>

    {
        tb_QuestionDataAccessLayer tb_Questiondal;
        public tb_QuestionBLL()
        {
            tb_Questiondal = new tb_QuestionDataAccessLayer();
        }

        public int Insert(tb_QuestionEntity tb_QuestionEntity)
        {
            return tb_Questiondal.Insert(tb_QuestionEntity);            
        }

        public void Update(tb_QuestionEntity tb_QuestionEntity)
        {
            tb_Questiondal.Update(tb_QuestionEntity);
        }

        public tb_QuestionEntity GetAdminSingle(int questionId)
        {
           return tb_Questiondal.Get_tb_QuestionEntity(questionId);
        }

        public IList<tb_QuestionEntity> Gettb_QuestionList()
        {
            IList<tb_QuestionEntity> tb_QuestionList = new List<tb_QuestionEntity>();
            tb_QuestionList=tb_Questiondal.Get_tb_QuestionAll();
            return tb_QuestionList;
        }
        public DataSet GetDiffCountBySchoolAndCls(int schoolid,int clsid,int type)
        {
           
            return tb_Questiondal.GetDiffCountBySchoolAndCls(schoolid,clsid,type);
            
        }
        public DataSet GetList(int pagesize, int currentindex, string condition, out int allcount)
        {
            return PageData.GetDataByPage("v_Question", "QuestionId", "QuestionId desc", currentindex, pagesize, "*", condition, out allcount);
        }
        public int Delete(int questionId)
        {
            return tb_Questiondal.Delete(questionId);
        }
        public IList<tb_QuestionEntity> Gettb_QuestionBySchoolIdOne(int schoolId)
        {
            IList<tb_QuestionEntity> tb_QuestionList = new List<tb_QuestionEntity>();
            tb_QuestionList = tb_Questiondal.Get_tb_QuestionBySchoolIdOne(schoolId);
            return tb_QuestionList;
        }

        public IList<tb_QuestionEntity> Gettb_QuestionListParentIdTow(int parentId)
        {
            IList<tb_QuestionEntity> tb_QuestionList = new List<tb_QuestionEntity>();
            tb_QuestionList = tb_Questiondal.Get_tb_QuestionByParentIdTow(parentId);
            return tb_QuestionList;
        }
        public IList<tb_QuestionEntity> GetQuestionList(int schoolid, int clsid)
        {
            IList<tb_QuestionEntity> tb_QuestionList = new List<tb_QuestionEntity>();
            tb_QuestionList = tb_Questiondal.GetQuestionList(schoolid,clsid);
            return tb_QuestionList;
        }
        public IList<tb_QuestionEntity> GetQuestionList(string qids)
        {
            IList<tb_QuestionEntity> tb_QuestionList = new List<tb_QuestionEntity>();
            tb_QuestionList = tb_Questiondal.GetQuestionList(qids);
            return tb_QuestionList;
        }

        public IList<tb_QuestionEntity> GetQuestionList(int qid)
        {
            IList<tb_QuestionEntity> tb_QuestionList = new List<tb_QuestionEntity>();
            tb_QuestionList = tb_Questiondal.GetQuestionList(qid);
            return tb_QuestionList;
        }

        public int DeleleQuestionByQuestionId(string questionids)
        {
            return tb_Questiondal.DeleleQuestionByQuestionId(questionids);
        }
        public DataSet GetList(string where)
        {
            return tb_Questiondal.GetList(where);
        }
    }
}
