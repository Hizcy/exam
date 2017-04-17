// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_User_Department.cs
// 项目名称：买车网
// 创建时间：2015/8/24
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
    /// 数据层实例化接口类 dbo.tb_User_Department.
    /// </summary>
    public partial class tb_User_DepartmentDataAccessLayer 
    {
        public tb_User_DepartmentEntity Get_User_DepartmentEntityByUserId(int userId)
        {
            tb_User_DepartmentEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@UserId",SqlDbType.Int)
			};
            _param[0].Value = userId;
            string sqlStr = "select * from tb_User_Department with(nolock) where userId=@UserId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_User_DepartmentEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        public tb_User_DepartmentEntity Get_User_DepartmentEntityBySchoolId(int schoolId)
        {
            tb_User_DepartmentEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@SchoolId",SqlDbType.Int)
			};
            _param[0].Value = schoolId;
            string sqlStr = "select * from v_User with(nolock) where schoolId=@SchoolId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_User_DepartmentEntity_FromDr(dr);
                }
            }
            return _obj;
        }
	}
}
