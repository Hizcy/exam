// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Exam.cs
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
    public partial class tb_ExamBLL : BaseBLL< tb_ExamBLL>

    {
        tb_ExamDataAccessLayer tb_Examdal;
        public tb_ExamBLL()
        {
            tb_Examdal = new tb_ExamDataAccessLayer();
        }

        public int Insert(tb_ExamEntity tb_ExamEntity)
        {
            return tb_Examdal.Insert(tb_ExamEntity);            
        }

        public void Update(tb_ExamEntity tb_ExamEntity)
        {
            tb_Examdal.Update(tb_ExamEntity);
        }

        public tb_ExamEntity GetAdminSingle(int examId)
        {
           return tb_Examdal.Get_tb_ExamEntity(examId);
        }

        public IList<tb_ExamEntity> Gettb_ExamList()
        {
            IList<tb_ExamEntity> tb_ExamList = new List<tb_ExamEntity>();
            tb_ExamList=tb_Examdal.Get_tb_ExamAll();
            return tb_ExamList;
        }
        public int Delete(int examId)
        {
            return tb_Examdal.Delete(examId);
        }
        public DataSet GetList(int pagesize, int currentindex, string condition, out int allcount)
        {
            return PageData.GetDataByPage("tb_Exam", "ExamClsId", "ExamClsId desc", currentindex, pagesize, "*", condition, out allcount);
        }
    }
}
