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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Exam.Entity;
using Jnwf.Utils.Data;


namespace Exam.DAL 
{
    /// <summary>
    /// 数据层实例化接口类 dbo.tb_Ad.
    /// </summary>
    public partial class tb_AdDataAccessLayer 
    {
        /// <summary>
        /// 得到数据表v_Question_Buyer id记录
        /// </summary>
        /// <returns>数据集</returns>
        public IList<tb_AdEntity> Get_tb_adAll(int schoolid)
        {
            IList<tb_AdEntity> Obj = new List<tb_AdEntity>();
            SqlParameter[] _param ={
			new SqlParameter("@SchoolId",SqlDbType.Int)
			};
            _param[0].Value = schoolid;
            string sqlStr = "select  * from v_SchoolIdAd with(nolock) where SchoolId=@SchoolId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_AdEntity_FromDr(dr));
                }
            }
            return Obj;
        }

        public IList<tb_AdEntity> GetAd(int schoolid)
        {
            IList<tb_AdEntity> Obj = new List<tb_AdEntity>();
            SqlParameter[] _param ={
			new SqlParameter("@SchoolId",SqlDbType.Int)
			};
            _param[0].Value = schoolid;

            string sqlStr = "P_GetAd";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.StoredProcedure, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_AdEntity_FromDr(dr));
                }
            }
            return Obj;
        }
	}
}
