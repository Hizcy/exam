// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Exampaper.cs
// 项目名称：买车网
// 创建时间：2015/8/17
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
    public partial class tb_ExampaperBLL : BaseBLL< tb_ExampaperBLL>

    {
        tb_ExampaperDataAccessLayer tb_Exampaperdal;
        public tb_ExampaperBLL()
        {
            tb_Exampaperdal = new tb_ExampaperDataAccessLayer();
        }

        public int Insert(tb_ExampaperEntity tb_ExampaperEntity)
        {
            return tb_Exampaperdal.Insert(tb_ExampaperEntity);            
        }

        public void Update(tb_ExampaperEntity tb_ExampaperEntity)
        {
            tb_Exampaperdal.Update(tb_ExampaperEntity);
        }

        public tb_ExampaperEntity GetAdminSingle(int exampaperId)
        {
           return tb_Exampaperdal.Get_tb_ExampaperEntity(exampaperId);
        }
         
        public IList<tb_ExampaperEntity> Gettb_ExampaperList()
        {
            IList<tb_ExampaperEntity> tb_ExampaperList = new List<tb_ExampaperEntity>();
            tb_ExampaperList=tb_Exampaperdal.Get_tb_ExampaperAll();
            return tb_ExampaperList;
        }
        public int Delete(int exampaperId)
        {
            return tb_Exampaperdal.Delete(exampaperId);
        }
        public DataSet GetList(int pagesize, int currentindex, string condition, out int allcount)
        {
            return PageData.GetDataByPage("v_Exampaper", "ExampaperId", "ExampaperId desc", currentindex, pagesize, "*", condition, out allcount);
        }
        public DataSet GetListByClient(int pagesize, int currentindex, string condition, out int allcount)
        {
            return PageData.GetDataByPage("[v_Exampaper] a inner join [tb_School_QuestionCls] b on a.exampaperclsid=b.QuestionClsId", "a.ExampaperId", "a.ExampaperId desc", currentindex, pagesize, "a.*,b.ismust", condition, out allcount);
        } 
        public IList<tb_ExampaperEntity> Gettb_ExampaperById(int paperId)
        {
            IList<tb_ExampaperEntity> tb_ExampaperList = new List<tb_ExampaperEntity>();
            tb_ExampaperList = tb_Exampaperdal.Get_tbExampaperById(paperId);
            return tb_ExampaperList;
        }
        public IList<tb_ExampaperEntity> Gettb_ExampaperListByExampaperClsId(int exampaperClsId)
        {
            IList<tb_ExampaperEntity> tb_ExampaperList = new List<tb_ExampaperEntity>();
            tb_ExampaperList = tb_Exampaperdal.Get_ExampaperListByExampaperClsId(exampaperClsId);
            return tb_ExampaperList;
        }
        public DataSet Get_ExampaperByParentId(int parentId,int schoolId)
        {
            return tb_Exampaperdal.Get_ExampaperNameByParentid(parentId,schoolId);
        }
        public tb_ExampaperEntity GetexampaperclsId(int exampaperClsId)
        {
            return tb_Exampaperdal.Get_tb_ExampaperclsEntity(exampaperClsId);
        }
        public tb_ExampaperEntity GetexampaperId(int clsid)
        {
            return tb_Exampaperdal.Get_ExampaperEntity(clsid);
        }
    }
}
