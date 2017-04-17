// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Ad.cs
// 项目名称：买车网
// 创建时间：2015/12/22
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
    public partial class tb_AdBLL : BaseBLL< tb_AdBLL>

    {
        tb_AdDataAccessLayer tb_Addal;
        public tb_AdBLL()
        {
            tb_Addal = new tb_AdDataAccessLayer();
        }

        public int Insert(tb_AdEntity tb_AdEntity)
        {
            return tb_Addal.Insert(tb_AdEntity);            
        }

        public void Update(tb_AdEntity tb_AdEntity)
        {
            tb_Addal.Update(tb_AdEntity);
        }

        public tb_AdEntity GetAdminSingle(int id)
        {
           return tb_Addal.Get_tb_AdEntity(id);
        }

        public IList<tb_AdEntity> Gettb_AdList()
        {
            IList<tb_AdEntity> tb_AdList = new List<tb_AdEntity>();
            tb_AdList=tb_Addal.Get_tb_AdAll();
            return tb_AdList;
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
            return PageData.GetDataByPage("v_ad", "id", "status desc,addtime desc", currentindex, pagesize, "*", condition, out allcount);
        }
        public IList<tb_AdEntity> Get_tb_adList(int schoolid)
        {
            IList<tb_AdEntity> tb_AdList = new List<tb_AdEntity>();
            tb_AdList = tb_Addal.Get_tb_adAll(schoolid);
            return tb_AdList;
        }
        public IList<tb_AdEntity> GetAd(int schoolid)
        {
            IList<tb_AdEntity> tb_AdList = new List<tb_AdEntity>();
            tb_AdList = tb_Addal.GetAd(schoolid);
            return tb_AdList;
        }
    }
}
