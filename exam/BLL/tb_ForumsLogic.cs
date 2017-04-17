// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Forums.cs
// 项目名称：买车网
// 创建时间：2015/12/16
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
    public partial class tb_ForumsBLL : BaseBLL< tb_ForumsBLL>

    {
        tb_ForumsDataAccessLayer tb_Forumsdal;
        public tb_ForumsBLL()
        {
            tb_Forumsdal = new tb_ForumsDataAccessLayer();
        }

        public int Insert(tb_ForumsEntity tb_ForumsEntity)
        {
            return tb_Forumsdal.Insert(tb_ForumsEntity);            
        }

        public void Update(tb_ForumsEntity tb_ForumsEntity)
        {
            tb_Forumsdal.Update(tb_ForumsEntity);
        }

        public tb_ForumsEntity GetAdminSingle(int id)
        {
           return tb_Forumsdal.Get_tb_ForumsEntity(id);
        }

        public IList<tb_ForumsEntity> Gettb_ForumsList()
        {
            IList<tb_ForumsEntity> tb_ForumsList = new List<tb_ForumsEntity>();
            tb_ForumsList=tb_Forumsdal.Get_tb_ForumsAll();
            return tb_ForumsList;
        }
        public IList<tb_ForumsEntity> GetForumsList(int clsid)
        {
            IList<tb_ForumsEntity> tb_ForumList = new List<tb_ForumsEntity>();
            tb_ForumList = tb_Forumsdal.GetForumsList(clsid);
            return tb_ForumList;
        }
        public DataSet Get_tb_forumcls(int clsid)
        {
            return tb_Forumsdal.Getforumclsid(clsid);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="currentindex"></param>
        /// <param name="condition"></param>
        /// <param name="allcount"></param>
        /// <returns></returns>
        public DataSet GetList(int pagesize, int currentindex, string condition, out int allcount)
        {
            return PageData.GetDataByPage("v_Forums", "id", "addtime desc", currentindex, pagesize, "*", condition, out allcount);
        }
    }
}
