// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Word.cs
// 项目名称：买车网
// 创建时间：2015/12/24
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Exam.DAL;
using Exam.Entity;

namespace Exam.BLL
{
    public partial class tb_WordBLL : BaseBLL< tb_WordBLL>

    {
        tb_WordDataAccessLayer tb_Worddal;
        public tb_WordBLL()
        {
            tb_Worddal = new tb_WordDataAccessLayer();
        }

        public int Insert(tb_WordEntity tb_WordEntity)
        {
            return tb_Worddal.Insert(tb_WordEntity);            
        }

        public void Update(tb_WordEntity tb_WordEntity)
        {
            tb_Worddal.Update(tb_WordEntity);
        }

        public tb_WordEntity GetAdminSingle(int id)
        {
           return tb_Worddal.Get_tb_WordEntity(id);
        }

        public IList<tb_WordEntity> Gettb_WordList()
        {
            IList<tb_WordEntity> tb_WordList = new List<tb_WordEntity>();
            tb_WordList=tb_Worddal.Get_tb_WordAll();
            return tb_WordList;
        }
        /// <summary>
        /// 状态是一的所有数据
        /// </summary>
        /// <returns></returns>
        public IList<tb_WordEntity> GetWordListByStatus()
        {
            IList<tb_WordEntity> tb_WordList = new List<tb_WordEntity>();
            tb_WordList = tb_Worddal.GetWordListByStatus();
            return tb_WordList;
        }
    }
}
