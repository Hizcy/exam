// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Result.cs
// 项目名称：买车网
// 创建时间：2015/8/27
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
    /// 数据层实例化接口类 dbo.tb_Result.
    /// </summary>
    public partial class tb_ResultDataAccessLayer 
    {
        public IList<tb_ResultEntity> GetListByUserId(int userid)
        {

            IList<tb_ResultEntity> Obj = new List<tb_ResultEntity>();
            
            SqlParameter[] _param ={
                 new SqlParameter("@userid",SqlDbType.Int) 
            };
            _param[0].Value = userid;
            
            string sqlStr = "select * from tb_Result where userid=@userid and point>0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_ResultEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public IList<tb_ResultEntity> GetListByUserIdScore(int userid)
        {

            IList<tb_ResultEntity> Obj = new List<tb_ResultEntity>();

            SqlParameter[] _param ={
                 new SqlParameter("@userid",SqlDbType.Int) 
            };
            _param[0].Value = userid;
            string sqlStr = "  select UserId,ExampaperId, avg(Score) as 平均分 ,max(Score) as 最高分 ,min(Score) as 最低分 from tb_Result where userid=@userid  group by UserId ,ExampaperId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_ResultEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public DataSet GetListByDepartmentId(int departmentid)
        {
            SqlParameter[] _param ={
                 new SqlParameter("@departmentid",SqlDbType.Int) 
            };
            _param[0].Value = departmentid;
            string sqlStr = "SELECT top 10 A.USERID,A.realname,SUM(B.Score) as score,point,description FROM tb_User a LEFT join tb_result b on a.userid=b.userid where a.departmentid=@departmentid GROUP BY A.USERID,A.realname,point,description";
            return SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
        }
        public IList<tb_ResultEntity> GetListByUserId(string userid)
        {

            IList<tb_ResultEntity> Obj = new List<tb_ResultEntity>();

            SqlParameter[] _param ={
                 new SqlParameter("@UserId",SqlDbType.Int) 
            };
            _param[0].Value = userid;
            string sqlStr = "SELECT * FROM [exam].[dbo].[tb_Result]  where userid in ("+userid+")";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_ResultEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public DataSet GetStatListByUserId(int userid)
        {

            SqlParameter[] _param ={
                 new SqlParameter("@UserId",SqlDbType.Int) 
            };
            _param[0].Value = userid;
            string sqlStr = "select b.*,A.name,c.RealName,c.Position from [tb_Exampaper] a inner join (SELECT UserId,ExampaperId,case when MAX(point)>0 then '通过' else '不通过' end as Point FROM [exam].[dbo].[tb_Result] where UserId=@UserId group by UserId,ExampaperId) b on a.ExampaperId=b.ExampaperId inner join tb_User c on b.UserId=c.UserId";
            DataSet ds = SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
            return ds;
        }
	}
}
