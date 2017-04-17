// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Word.cs
// 项目名称：买车网
// 创建时间：2015/12/24
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
    /// 数据层实例化接口类 dbo.tb_Word.
    /// </summary>
    public partial class tb_WordDataAccessLayer 
    {
        /// <summary>
        /// 状态是 1 的所有数据
        /// </summary>
        /// <returns></returns>
        public IList<tb_WordEntity> GetWordListByStatus()
        {
            IList<tb_WordEntity> Obj = new List<tb_WordEntity>();
            string sqlStr = "select * from tb_Word where status=1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_WordEntity_FromDr(dr));
                }
            }
            return Obj;
        }
	}
}
