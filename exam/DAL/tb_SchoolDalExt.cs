// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_School.cs
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
    /// 数据层实例化接口类 dbo.tb_School.
    /// </summary>
    public partial class tb_SchoolDataAccessLayer 
    {
        public tb_SchoolEntity GetModel(string domain)
        {
            tb_SchoolEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@domain",SqlDbType.VarChar)
			};
            _param[0].Value = domain;
            string sqlStr = "select * from tb_School with(nolock) where domain=@domain and status=1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_SchoolEntity_FromDr(dr);
                }
            }
            return _obj;
        }

        public int InsertSchool(string domain, string schoolname, int locationid, string realname, int sex, string phone, string mail, string pwd, int agent,int flag)
        {
            SqlParameter[] _param ={
			new SqlParameter("@domain",SqlDbType.VarChar),
            new SqlParameter("@schoolname",SqlDbType.VarChar),
            new SqlParameter("@locationid",SqlDbType.Int),
            new SqlParameter("@realname",SqlDbType.VarChar),
            new SqlParameter("@sex",SqlDbType.Int),
            new SqlParameter("@phone",SqlDbType.VarChar),
            new SqlParameter("@mail",SqlDbType.VarChar),
            new SqlParameter("@pwd",SqlDbType.VarChar),
            new SqlParameter("@agent",SqlDbType.Int),
            new SqlParameter("@flag",SqlDbType.Int)
			};

            _param[0].Value = domain;
            _param[1].Value = schoolname;
            _param[2].Value = locationid; 
            _param[3].Value = realname;
            _param[4].Value = sex;
            _param[5].Value = phone;
            _param[6].Value = mail;
            _param[7].Value = pwd;
            _param[8].Value = agent;
            _param[9].Value = flag;
            int res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW, CommandType.StoredProcedure, "P_Register", _param));
            return res;
        }
	}
    
}