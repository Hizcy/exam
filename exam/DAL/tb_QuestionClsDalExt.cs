// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_QuestionCls.cs
// 项目名称：买车网
// 创建时间：2015/8/10
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
    /// 数据层实例化接口类 dbo.tb_QuestionCls.
    /// </summary>
    public partial class tb_QuestionClsDataAccessLayer 
    {
        public IList<tb_QuestionClsEntity> QuestionClsList()
        {
            IList<tb_QuestionClsEntity> Obj = new List<tb_QuestionClsEntity>();
            
            string sqlStr = "select * from tb_QuestionCls with(nolock) where status=1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_QuestionClsEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public IList<tb_QuestionClsEntity> Get_tb_QuestionClsBySchoolIdOne(int schoolId)
        {
            IList<tb_QuestionClsEntity> Obj = new List<tb_QuestionClsEntity>();
            SqlParameter[] _param ={
                                      new SqlParameter("@SchoolId",SqlDbType.Int)
                 };
            _param[0].Value = schoolId;
            string sqlStr = "select * from tb_QuestionCls with(nolock) where schoolid=@SchoolId and parentid=0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr,_param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_QuestionClsEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public IList<tb_QuestionClsEntity> Get_tb_QuestionClsByParentIdTow(int parentId)
        {
            IList<tb_QuestionClsEntity> Obj = new List<tb_QuestionClsEntity>();
            SqlParameter[] _param ={
                                      new SqlParameter("@ParentId",SqlDbType.Int)
                 };
            _param[0].Value = parentId;
            string sqlStr = "select * from tb_QuestionCls with(nolock) where parentid=@ParentId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_QuestionClsEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public DataSet Get_tb_QuestionClsByParentId(int parentId)
        {
            SqlParameter[] _param ={
                                      new SqlParameter("@ParentId",SqlDbType.Int)
                 };
            _param[0].Value = parentId;
            string sqlStr = "select a.QuestionClsId,b.Name,b.Total,b.Pass from exam.dbo.tb_QuestionCls a,exam.dbo.tb_Exampaper b where a.QuestionClsId=b.ExampaperClsId and a.parentid=@ParentId";
            return SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr,_param);
        }
        
	}
}
