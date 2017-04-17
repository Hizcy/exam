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
    /// 数据层实例化接口类 dbo.tb_Forums.
    /// </summary>
    public partial class tb_ForumsDataAccessLayer 
    {
        public IList<tb_ForumsEntity> GetForumsList(int clsid)
        {
            IList<tb_ForumsEntity> Obj = new List<tb_ForumsEntity>();
            SqlParameter[] _param ={
                                      new SqlParameter("@clsid",SqlDbType.Int)
                 };
            _param[0].Value = clsid;
            string sqlStr = "select * from tb_Forums  where BookId=@clsid  order by addtime desc";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_ForumsEntity_FromDr(dr));
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
        public DataSet Getforumclsid(int clsid)
        {
            SqlParameter[] _param ={
                new SqlParameter("@clsid",SqlDbType.Int),
            };
            _param[0].Value = clsid;
            string sqlStr = "SELECT * FROM v_Forums where BookId=@clsid order by addtime desc";
            DataSet ds = SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
            return ds;
        }
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
	}   
}
