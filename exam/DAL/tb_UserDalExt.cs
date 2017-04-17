// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_User.cs
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
    /// 数据层实例化接口类 dbo.tb_User.
    /// </summary>
    public partial class tb_UserDataAccessLayer
    {
        public DataSet GetStatus0List()
        {
            string sqlStr = "select a.*,b.name as schoolname from tb_User a inner join tb_School b on a.SchoolId=b.SchoolId where a.Status=0 and b.Status=1 and a.name='admin'";
            return SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr);
        }
        public tb_UserEntity GetModelByNameAndPwd(string name, string pwd,string domain)
        {
            tb_UserEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@name",SqlDbType.VarChar,50),
            new SqlParameter("@pwd",SqlDbType.VarChar,50),
            new SqlParameter("@domain",SqlDbType.VarChar,50)
			};
            _param[0].Value = name;
            _param[1].Value = pwd;
            _param[2].Value = domain;
            string sqlStr = "select a.* from tb_User a inner join tb_School b on a.SchoolId=b.SchoolId where a.Name=@name and a.Pwd=@pwd and a.Status=1 and b.Status=1 and a.RoleId in (1,2,4,5) and b.domain=@domain";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_UserEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        /// <summary>
        /// 管理端登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public tb_UserEntity loginCheck(string name,string domain)
        {
            tb_UserEntity _obj = null;
            SqlParameter[] _param ={
                    new SqlParameter("@Name",SqlDbType.VarChar),
                    new SqlParameter("@Domain",SqlDbType.VarChar)
             };
            _param[0].Value = name;
            _param[1].Value = domain;
            string sqlStr = "select a.* from tb_User a inner join tb_School b on a.SchoolId=b.SchoolId where a.Name=@Name  and a.Status=1 and b.Status=1 and a.RoleId in (1,2,4,5) and b.domain=@Domain";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_UserEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        /// <summary>
        /// 学生PC端登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public tb_UserEntity GetStudentByNameAndPwd(string name,  string domain)
        {
            tb_UserEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@name",SqlDbType.VarChar,50),
             new SqlParameter("@domain",SqlDbType.VarChar,50)
			};
            _param[0].Value = name;
            _param[1].Value = domain;
            string sqlStr = "select a.* from tb_User a inner join tb_School b on a.SchoolId=b.SchoolId where a.Name=@name and a.Status=1 and b.Status=1 and a.RoleId=3 and b.domain=@domain";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_UserEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        public tb_UserEntity GetStudentByNameAndPwd(string name, string pwd, string domain)
        {
            tb_UserEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@name",SqlDbType.VarChar,50),
            new SqlParameter("@pwd",SqlDbType.VarChar,50),
             new SqlParameter("@domain",SqlDbType.VarChar,50)
			};
            _param[0].Value = name;
            _param[1].Value = pwd;
            _param[2].Value = domain;
            string sqlStr = "select a.* from tb_User a inner join tb_School b on a.SchoolId=b.SchoolId where a.Name=@name and a.Pwd=@pwd and a.Status=1 and b.Status=1 and a.RoleId=3 and b.domain=@domain";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_UserEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        public tb_UserEntity GetModelByNameSchoolId(string name, int schoolid)
        {
            tb_UserEntity _obj = null;
            SqlParameter[] _param ={
			    new SqlParameter("@name",SqlDbType.VarChar,50),
                new SqlParameter("@SchoolId",SqlDbType.Int)
			};
            _param[0].Value = name;
            _param[1].Value = schoolid;
            string sqlStr = "select * from tb_User with(nolock) where Name=@name and schoolid=@SchoolId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_UserEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        public tb_UserEntity GetModel(DataRow row)
        {
            tb_UserEntity Obj = new tb_UserEntity();
            if (row != null)
            {
                if (row["*角色"].ToString() == "学生")
                {
                    Obj.RoleId = 3;
                }
                else if (row["*角色"].ToString() == "教师")
                {
                    Obj.RoleId = 2;
                }
                if (row["年级"].ToString() != "" && row["班级"].ToString() != "")
                {
                    Obj.Description = row["年级"].ToString() + row["班级"].ToString();
                }
                else
                {
                    Obj.Description = "";
                }
                Obj.UserId = 0;
                Obj.SchoolId = 0;
                Obj.DepartmentId = 0;
                Obj.Pwd = row["*密码"].ToString();
                Obj.RealName = row["*姓名"].ToString();
                Obj.Sex = ((row["*性别"].ToString()=="男") ? 1 : 0);
                Obj.Position = row["职位"].ToString();
                Obj.Mail = row["电子邮箱"].ToString();
                Obj.IdentityCard = row["证件号码"].ToString();
                Obj.Phone = row["手机号码"].ToString();
                //Obj.Description = row["备注"].ToString();
                Obj.Status = 1;
                Obj.Addtime = Convert.ToDateTime("1900-1-1");
            }
            else
            {
                return null;
            }
            return Obj;
        }
        public IList<tb_UserEntity> GetNameBySchoolIdRoleId(int schoolId,int roleId)
        {
            IList<tb_UserEntity> Obj = new List<tb_UserEntity>();
            SqlParameter[] _param ={
                                new SqlParameter("@SchoolId",SqlDbType.Int),
                                new SqlParameter("@RoleId",SqlDbType.Int)
                        };
            _param[0].Value = schoolId;
            _param[1].Value = roleId;
            string sqlStr = "select * from tb_User where schoolid=@SchoolId and roleid=@RoleId and status=1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr,_param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_UserEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public int GetClassPeopleNumber(string classname,int schoolId)
        {
            SqlParameter[] _param ={
                        new SqlParameter("@Departmentname",SqlDbType.VarChar),
                        new SqlParameter("@SchoolId",SqlDbType.Int),
                  };
            _param[0].Value = classname;
            _param[1].Value = schoolId;
            string sqlStr = "SELECT count(0) FROM [exam].[dbo].[v_User] where departmentname=@Departmentname and schoolId=@SchoolId";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW, CommandType.Text, sqlStr, _param));
        }
        public int GetTeacherAdminNumber(int schoolId)
        {
            SqlParameter[] _param = {
                        new SqlParameter("@SchoolId",SqlDbType.Int),
                   };
            _param[0].Value = schoolId;
            string sqlStr = "SELECT count(0)  FROM [exam].[dbo].[tb_User] where schoolid=@SchoolId and roleid in(1,2)";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW, CommandType.Text, sqlStr, _param));
        }
        public int UpdateByUserId(string userId)
        {
            string sqlStr = "update [exam].[dbo].[tb_User] set status=0 where userid in(" + userId + ")";
            return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW, CommandType.Text, sqlStr);
        }
        public DataSet GetListUser(string where)
        {
           
            string sqlStr = "select a.name + b.Domain as 用户名,a.realname  as 姓名,(case a.sex when 1 then '男' else '女' end) as 性别, a.mail as 邮箱,a.phone as 手机, a.departmentname as 班级,  a.addtime as 添加时间  from v_User a inner join tb_School b on a.SchoolId=b.SchoolId ";
            if (!string.IsNullOrEmpty(where))
                sqlStr += " where " + where;
            return SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr);
        }
        public IList<tb_UserEntity> GetAgentList()
        {
            IList<tb_UserEntity> Obj = new List<tb_UserEntity>();
            string sqlStr = "SELECT * FROM [exam].[dbo].[tb_User] with(nolock)  where RoleId = 5 and Status = 1 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_UserEntity_FromDr(dr));
                }
            }
            return Obj;
        }
	}
}
