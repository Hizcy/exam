
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Exam.DAL
{
    public class PageData
    {
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="tableName">要显示的表或多个表的连接</param>
        /// <param name="fieldName">要显示的字段列表</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="currentPage">要显示那一页的记录</param>
        /// <param name="sortField">排序字段列表或条件</param>
        /// <param name="condition">查询条件,不需where,以And开始</param>
        /// <param name="primaryKey">主表的主键</param>
        /// <param name="recordCount">查询到的记录数</param>
        /// <remarks>
        /// 使用完得关闭IDataReader连接(放在using语句中)
        /// </remarks>
        /// <returns></returns>
        //public static IDataReader GetDataByPage(
        //    string tableName,
        //    string primaryKey,
        //    string sortField,
        //    int currentPage,
        //    int pageSize,
        //    string fieldName,
        //    string condition,

        //    out int totalCount
        //    )
        //{
        //    SqlParameter[] paras = new SqlParameter[]
        //    {
        //        new SqlParameter("@viewName", SqlDbType.NVarChar),
        //        new SqlParameter("@keyName", SqlDbType.NVarChar),
        //        new SqlParameter("@orderString", SqlDbType.NVarChar),
        //        new SqlParameter("@pageNo", SqlDbType.Int),
        //        new SqlParameter("@pageSize", SqlDbType.Int),
        //        new SqlParameter("@fieldName", SqlDbType.NVarChar),
        //        new SqlParameter("@whereString", SqlDbType.NVarChar),
        //        new SqlParameter("@recordTotal", SqlDbType.Int)
        //    };
        //    paras[0].Value = tableName;
        //    paras[1].Value = fieldName;
        //    paras[2].Value = pageSize;
        //    paras[3].Value = currentPage;
        //    paras[4].Value = sortField;
        //    paras[5].Value = condition;
        //    paras[6].Value = primaryKey;
            
        //    paras[7].Direction = ParameterDirection.Output;


        //    SqlDataReader sdr = Jnwf.Utils.Data.SqlHelper.ExecuteReader(WebConfig.AgentsRW, CommandType.StoredProcedure, "P_GridViewPager", paras);

        //    totalCount = Convert.ToInt32(paras[7]);

        //    return sdr;
        //}
        /// <summary>
        /// 新的分页获取数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <param name="pageSize"></param>
        /// <param name="currentPage"></param>
        /// <param name="sortField">排序字段和排序方向,如:SortA DESC；此字段为""时,默认按主键倒序排</param>
        /// <param name="condition"></param>
        /// <param name="primaryKey"></param>
        /// <param name="totalCount">查询到的总记录数</param>  
        /// <returns></returns>
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
