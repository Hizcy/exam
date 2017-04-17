// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Exampaper.cs
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
    /// 数据层实例化接口类 dbo.tb_Exampaper. 
    /// </summary>
    public partial class tb_ExampaperDataAccessLayer 
    {

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
        public IList<Exam.Entity.tb_ExampaperEntity> Get_tbExampaperById(int paperId)
        {
            IList<tb_ExampaperEntity> Obj = new List<tb_ExampaperEntity>();
            SqlParameter[] _param = { new SqlParameter("@PaperId", SqlDbType.Int) };
            _param[0].Value = paperId;
            string sqlStr = "select * from tb_Exampaper with(nolock) where ExampaperId=@ExampaperId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr,_param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_ExampaperEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public IList<Exam.Entity.tb_ExampaperEntity> Get_ExampaperListByExampaperClsId(int exampaperClsId)
        {
            IList<tb_ExampaperEntity> Obj = new List<tb_ExampaperEntity>();
            SqlParameter[] _param = { new SqlParameter("@ExampaperClsId", SqlDbType.Int) };
            _param[0].Value = exampaperClsId;
            string sqlStr = "select * from tb_Exampaper with(nolock) where ExampaperClsId=@ExampaperClsId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_ExampaperEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public DataSet Get_ExampaperExampaperClsId(int exampaperClsId)
        {
            SqlParameter[] _param ={
                                      new SqlParameter("@ExampaperClsId",SqlDbType.Int)
                 };
            _param[0].Value = exampaperClsId;
            string sqlStr = "select * from tb_Exampaper with(nolock) where ExampaperClsId=@ExampaperClsId";
            return SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
        }
        public tb_ExampaperEntity Get_tb_ExampaperClsId(int exampaperClsId)
        {
            tb_ExampaperEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@ExampaperClsId",SqlDbType.Int)
			};
            _param[0].Value = exampaperClsId;
            string sqlStr = "select * from tb_Exampaper with(nolock) where ExampaperClsId=@ExampaperClsId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_ExampaperEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        public DataSet Get_ExampaperNameByParentid(int parentId,int schoolId)
        {
            SqlParameter[] _param = {
                             new SqlParameter("@ParentId", SqlDbType.Int) ,
                             new SqlParameter("@SchoolId",SqlDbType.Int)
                    };
            _param[0].Value = parentId;
            _param[1].Value = schoolId;
          //string sqlStr = "SELECT TOP 1000 [ExampaperId] ,[SchoolId],[ExampaperClsId],[Name] ,[Type] ,[Num] ,[Total] ,[Pass],[Duration],[Status],[Founder],[Addtime],[Updatetime],[ParentId] FROM [exam].[dbo].[v_Exampaper] where parentid=@ParentId";
            string sqlStr = "SELECT * FROM [v_Exampaper] a inner join [tb_School_QuestionCls] b on a.exampaperclsid=b.QuestionClsId where parentid=@ParentId and ismust>-1  and b.schoolid = @SchoolId";
            return SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
        }
        /// <summary>
        /// 根据ID,返回一个tb_Exampaper对象
        /// </summary>
        /// <param name="exampaperId">exampaperId</param>
        /// <returns>tb_Exampaper对象</returns>
        public tb_ExampaperEntity Get_tb_ExampaperclsEntity(int exampaperClsId)
        {
            tb_ExampaperEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@exampaperClsId",SqlDbType.Int)
			};
            _param[0].Value = exampaperClsId;
            string sqlStr = "select * from tb_Exampaper with(nolock) where ExampaperClsId=@exampaperClsId ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_ExampaperEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        /// <summary>
        /// 根据ID,返回一个tb_Exampaper对象
        /// </summary>
        /// <param name="exampaperId">exampaperId</param>
        /// <returns>tb_Exampaper对象</returns>
        public tb_ExampaperEntity Get_ExampaperEntity(int clsid)
        {
            tb_ExampaperEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@clsid",SqlDbType.Int)
			};
            _param[0].Value = clsid;
            string sqlStr = "select * from tb_Exampaper with(nolock) where ExampaperClsId=@clsid ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_ExampaperEntity_FromDr(dr);
                }
            }
            return _obj;
        }
	}
}
