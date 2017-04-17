// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Point_Statistics.cs
// 项目名称：买车网
// 创建时间：2015/8/28
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Exam.DAL;
using Exam.Entity;

namespace Exam.BLL
{
    public partial class tb_Point_StatisticsBLL : BaseBLL< tb_Point_StatisticsBLL>

    {
        tb_Point_StatisticsDataAccessLayer tb_Point_Statisticsdal;
        public tb_Point_StatisticsBLL()
        {
            tb_Point_Statisticsdal = new tb_Point_StatisticsDataAccessLayer();
        }

        public int Insert(tb_Point_StatisticsEntity tb_Point_StatisticsEntity)
        {
            return tb_Point_Statisticsdal.Insert(tb_Point_StatisticsEntity);            
        }

        public void Update(tb_Point_StatisticsEntity tb_Point_StatisticsEntity)
        {
            tb_Point_Statisticsdal.Update(tb_Point_StatisticsEntity);
        }

        public tb_Point_StatisticsEntity GetAdminSingle(int id)
        {
           return tb_Point_Statisticsdal.Get_tb_Point_StatisticsEntity(id);
        }

        public IList<tb_Point_StatisticsEntity> Gettb_Point_StatisticsList()
        {
            IList<tb_Point_StatisticsEntity> tb_Point_StatisticsList = new List<tb_Point_StatisticsEntity>();
            tb_Point_StatisticsList=tb_Point_Statisticsdal.Get_tb_Point_StatisticsAll();
            return tb_Point_StatisticsList;
        }
    }
}
