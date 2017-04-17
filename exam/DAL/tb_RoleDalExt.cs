// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Role.cs
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
    /// 数据层实例化接口类 dbo.tb_Role.
    /// </summary>
    public partial class tb_RoleDataAccessLayer 
    {
        public tb_RoleEntity Get_RoleEntityByName(string name)
        {
            tb_RoleEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@Name",SqlDbType.NVarChar)
			};
            _param[0].Value = name;
            string sqlStr = "select * from tb_Role with(nolock) where name=@Name";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_RoleEntity_FromDr(dr);
                }
            }
            return _obj;
        }
	}
}
