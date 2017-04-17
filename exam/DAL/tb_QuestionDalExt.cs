// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Question.cs
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
    /// 数据层实例化接口类 dbo.tb_Question.
    /// </summary>
    public partial class tb_QuestionDataAccessLayer 
    {
        public IList<tb_QuestionEntity> GetQuestionList(int schoolid ,int clsid)
        {
            IList<tb_QuestionEntity> Obj = new List<tb_QuestionEntity>();
            SqlParameter[] _param ={
                new SqlParameter("@SchoolId",SqlDbType.Int),
                 new SqlParameter("@QuestionClsId",SqlDbType.Int)
            };
            _param[0].Value = schoolid;
            _param[1].Value = clsid;
            string sqlStr = "SELECT a.* FROM [tb_Question] a inner join tb_QuestionCls b on a.QuestionClsId=b.QuestionClsId where a.schoolid=@SchoolId  and b.parentid=@QuestionClsId and a.status=1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_QuestionEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public IList<tb_QuestionEntity> GetQuestionList(string qids)
        {
            IList<tb_QuestionEntity> Obj = new List<tb_QuestionEntity>();

            string sqlStr = "SELECT * FROM [tb_Question] where status=1 and QuestionId in (" + qids + ")";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_QuestionEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public IList<tb_QuestionEntity> GetQuestionList(int qid)
        {
            IList<tb_QuestionEntity> Obj = new List<tb_QuestionEntity>();
            SqlParameter[] _param ={
                 new SqlParameter("@QuestionClsId",SqlDbType.Int)
            };
            _param[0].Value = qid;

            string sqlStr = "SELECT * FROM [tb_Question] where status=1 and questionClsId=@QuestionClsId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr,_param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_QuestionEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="schoolid"></param>
        /// <param name="questionclsid">书库</param>
        /// <param name="type">单选，多选</param>
        /// <returns></returns>
        public DataSet GetQuestionList(int schoolid ,int clsid,int type)
        {
            //IList<tb_QuestionEntity> Obj = new List<tb_QuestionEntity>();
            SqlParameter[] _param ={
                new SqlParameter("@SchoolId",SqlDbType.Int),
                new SqlParameter("@QuestionClsId",SqlDbType.Int),
                new SqlParameter("@Type",SqlDbType.Int)
            };
            _param[0].Value = schoolid;
            _param[1].Value = clsid;
            _param[2].Value = type;
            string sqlStr = "SELECT ROW_NUMBER() over(order by QuestionId) as rows,* FROM [tb_Question] where schoolid=@SchoolId  and QuestionClsId=@QuestionClsId and type=@Type and status=1";
            DataSet ds = SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
            return ds;
        }
        public DataSet GetDiffCountBySchoolAndCls(int schoolid,int clsid,int type)
        {
            
            SqlParameter[] _param ={
                new SqlParameter("@SchoolId",SqlDbType.Int),
                new SqlParameter("@QuestionClsId",SqlDbType.Int),
                new SqlParameter("@Type",SqlDbType.Int)
            };
            _param[0].Value = schoolid;
            _param[1].Value = clsid;
            _param[2].Value = type;
            string sqlStr = "select Isdifficulty,count(1) as Number from tb_Question with(nolock) where schoolid=@SchoolId and QuestionClsId=@QuestionClsId and type=@Type and Status=1 group by Isdifficulty";

            return SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
            
        }
        //分页
        public static DataSet GetDataByPage(
            string tableName,
            string primaryKey,
            string sortField,
            int currentPage,
            int pageSize,
            string fieldName,
            string condition,
            out int totalCount
            )
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@viewName", SqlDbType.NVarChar),
                new SqlParameter("@keyName", SqlDbType.NVarChar),
                new SqlParameter("@orderString", SqlDbType.NVarChar),
                new SqlParameter("@pageNo", SqlDbType.Int),
                new SqlParameter("@pageSize", SqlDbType.Int),
                new SqlParameter("@fieldName", SqlDbType.NVarChar),
                new SqlParameter("@whereString", SqlDbType.NVarChar),
                new SqlParameter("@recordTotal", SqlDbType.Int)
            };
            paras[0].Value = tableName;
            paras[1].Value = primaryKey;
            paras[2].Value = sortField;
            paras[3].Value = currentPage;
            paras[4].Value = pageSize;
            paras[5].Value = fieldName;
            paras[6].Value = condition;

            paras[7].Direction = ParameterDirection.Output;

            DataSet ds = new DataSet();
            ds = Jnwf.Utils.Data.SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.StoredProcedure, "P_GridViewPager", paras);

            totalCount = Convert.ToInt32(paras[7].Value);

            return ds;
        }
        public IList<tb_QuestionEntity> Get_tb_QuestionBySchoolIdOne(int schoolId)
        {
            IList<tb_QuestionEntity> Obj = new List<tb_QuestionEntity>();
            SqlParameter[] _param = { new SqlParameter("@SchoolId", SqlDbType.Int) };
            _param[0].Value = schoolId;
            string sqlStr = "select * from tb_Question with(nolock) where schoolid=@SchoolId and ParentId=0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr,_param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_QuestionEntity_FromDr(dr));
                }
            }
            return Obj;
        }

        public IList<tb_QuestionEntity> Get_tb_QuestionByParentIdTow(int parentId)
        {
            IList<tb_QuestionEntity> Obj = new List<tb_QuestionEntity>();
            SqlParameter[] _param = { new SqlParameter("@ParentId", SqlDbType.Int) };
            _param[0].Value = parentId;
            string sqlStr = "select * from tb_Question with(nolock) where ParentId=@ParentId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_QuestionEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public int DeleleQuestionByQuestionId(string questionids)
        {
            string sqlStr = "update tb_Question set Status=0 where QuestionId in (" + questionids + ")";

            return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW, CommandType.Text, sqlStr);
        }
        public DataSet GetList(string where)
        {
            string sqlStr = "select name as 试题类型,ParentId ,(case type when 1 then '单选' when 2 then '多选' when 3 then '判断' when 4 then '填空' end) as 试题分类 ,title as 内容,A as A选项,B as B选项,C as C选项,D as D选项,E as E选项,F as F选项, G as G选项,H as H选项,(case answer when '1' then '正确' when '0' then '错误' when 'A' then 'A' when 'B' then 'B' when 'C' then 'C' when 'D' then 'D' when 'E' then 'E' when 'F' then 'F' when 'G' then 'G' when 'H' then 'H'  end) as 正确答案,interpretation as 解析,addtime as 添加时间 from  v_Question    ";
            if (!string.IsNullOrEmpty(where))
                sqlStr += " where " + where;
            return SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr);
        }
	}
}
