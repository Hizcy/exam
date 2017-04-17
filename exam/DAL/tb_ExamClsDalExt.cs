// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_ExamCls.cs
// 项目名称：买车网
// 创建时间：2015/8/13
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
    /// 数据层实例化接口类 dbo.tb_ExamCls.
    /// </summary>
    public partial class tb_ExamClsDataAccessLayer 
    {
        public IList<tb_ExamClsEntity> Get_tb_ExamClsSchoolIdOne(int schoolId)
        {
            IList<tb_ExamClsEntity> Obj = new List<tb_ExamClsEntity>();
            SqlParameter[] _param = {
                                new SqlParameter("@SchoolId",SqlDbType.Int)
               };
            _param[0].Value = schoolId;
            string sqlStr = "select * from tb_ExamCls with(nolock) where schoolid=@SchoolId and parentid=0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr,_param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_ExamClsEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public IList<tb_ExamClsEntity> Get_tb_ExamClsParentIdTow(int parentId)
        {
            IList<tb_ExamClsEntity> Obj = new List<tb_ExamClsEntity>();
            SqlParameter[] _param = {
                                new SqlParameter("@ParentId",SqlDbType.Int)
               };
            _param[0].Value = parentId;
            string sqlStr = "select * from tb_ExamCls with(nolock) where parentid=@ParentId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_ExamClsEntity_FromDr(dr));
                }
            }
            return Obj;
        }
	}
}
