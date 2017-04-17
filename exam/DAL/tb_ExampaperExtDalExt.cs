// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_ExampaperExt.cs
// 项目名称：买车网
// 创建时间：2015/8/17
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Jnwf.Utils.Data;
using Exam.Entity;


namespace Exam.DAL
{
    /// <summary>
    /// 数据层实例化接口类 dbo.tb_ExampaperExt.
    /// </summary>
    public partial class tb_ExampaperExtDataAccessLayer 
    {
        public IList<tb_ExampaperExtEntity> GetListByExampaperId(int exampaperId)
        {
            IList<tb_ExampaperExtEntity> Obj = new List<tb_ExampaperExtEntity>();
            SqlParameter[] _param = { new SqlParameter("@ExampaperId", SqlDbType.Int) };
            _param[0].Value = exampaperId;
            string sqlStr = "select * from tb_ExampaperExt with(nolock) where exampaperId = @ExampaperId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr,_param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_ExampaperExtEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public int DeleteByExampaperId(int exampaperId)
        {
            string sqlStr = "delete from tb_ExampaperExt where [ExampaperId] =@ExampaperId";
            SqlParameter[] _param ={			
			new SqlParameter("@ExampaperId",SqlDbType.Int)
			
			};
            _param[0].Value = exampaperId;
            return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
        }
    }
}
