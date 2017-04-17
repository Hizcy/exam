// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_User.cs
// 项目名称：买车网
// 创建时间：2015/8/29
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
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_UserDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_UserModel">tb_User实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_UserEntity _tb_UserModel)
		{
			string sqlStr="insert into tb_User([SchoolId],[DepartmentId],[Path],[RoleId],[Name],[Pwd],[RealName],[Sex],[Position],[Mail],[IdentityCard],[Phone],[Description],[Status],[Addtime]) values(@SchoolId,@DepartmentId,@Path,@RoleId,@Name,@Pwd,@RealName,@Sex,@Position,@Mail,@IdentityCard,@Phone,@Description,@Status,@Addtime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@DepartmentId",SqlDbType.Int),
			new SqlParameter("@Path",SqlDbType.VarChar),
			new SqlParameter("@RoleId",SqlDbType.Int),
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Pwd",SqlDbType.VarChar),
			new SqlParameter("@RealName",SqlDbType.VarChar),
			new SqlParameter("@Sex",SqlDbType.Int),
			new SqlParameter("@Position",SqlDbType.VarChar),
			new SqlParameter("@Mail",SqlDbType.VarChar),
			new SqlParameter("@IdentityCard",SqlDbType.VarChar),
			new SqlParameter("@Phone",SqlDbType.VarChar),
			new SqlParameter("@Description",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_UserModel.SchoolId;
			_param[1].Value=_tb_UserModel.DepartmentId;
			_param[2].Value=_tb_UserModel.Path;
			_param[3].Value=_tb_UserModel.RoleId;
			_param[4].Value=_tb_UserModel.Name;
			_param[5].Value=_tb_UserModel.Pwd;
			_param[6].Value=_tb_UserModel.RealName;
			_param[7].Value=_tb_UserModel.Sex;
			_param[8].Value=_tb_UserModel.Position;
			_param[9].Value=_tb_UserModel.Mail;
			_param[10].Value=_tb_UserModel.IdentityCard;
			_param[11].Value=_tb_UserModel.Phone;
			_param[12].Value=_tb_UserModel.Description;
			_param[13].Value=_tb_UserModel.Status;
			_param[14].Value=_tb_UserModel.Addtime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_UserModel">tb_User实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_UserEntity _tb_UserModel)
		{
			string sqlStr="insert into tb_User([SchoolId],[DepartmentId],[Path],[RoleId],[Name],[Pwd],[RealName],[Sex],[Position],[Mail],[IdentityCard],[Phone],[Description],[Status],[Addtime]) values(@SchoolId,@DepartmentId,@Path,@RoleId,@Name,@Pwd,@RealName,@Sex,@Position,@Mail,@IdentityCard,@Phone,@Description,@Status,@Addtime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@DepartmentId",SqlDbType.Int),
			new SqlParameter("@Path",SqlDbType.VarChar),
			new SqlParameter("@RoleId",SqlDbType.Int),
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Pwd",SqlDbType.VarChar),
			new SqlParameter("@RealName",SqlDbType.VarChar),
			new SqlParameter("@Sex",SqlDbType.Int),
			new SqlParameter("@Position",SqlDbType.VarChar),
			new SqlParameter("@Mail",SqlDbType.VarChar),
			new SqlParameter("@IdentityCard",SqlDbType.VarChar),
			new SqlParameter("@Phone",SqlDbType.VarChar),
			new SqlParameter("@Description",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_UserModel.SchoolId;
			_param[1].Value=_tb_UserModel.DepartmentId;
			_param[2].Value=_tb_UserModel.Path;
			_param[3].Value=_tb_UserModel.RoleId;
			_param[4].Value=_tb_UserModel.Name;
			_param[5].Value=_tb_UserModel.Pwd;
			_param[6].Value=_tb_UserModel.RealName;
			_param[7].Value=_tb_UserModel.Sex;
			_param[8].Value=_tb_UserModel.Position;
			_param[9].Value=_tb_UserModel.Mail;
			_param[10].Value=_tb_UserModel.IdentityCard;
			_param[11].Value=_tb_UserModel.Phone;
			_param[12].Value=_tb_UserModel.Description;
			_param[13].Value=_tb_UserModel.Status;
			_param[14].Value=_tb_UserModel.Addtime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_User更新一条记录。
		/// </summary>
		/// <param name="_tb_UserModel">_tb_UserModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_UserEntity _tb_UserModel)
		{
            string sqlStr="update tb_User set [SchoolId]=@SchoolId,[DepartmentId]=@DepartmentId,[Path]=@Path,[RoleId]=@RoleId,[Name]=@Name,[Pwd]=@Pwd,[RealName]=@RealName,[Sex]=@Sex,[Position]=@Position,[Mail]=@Mail,[IdentityCard]=@IdentityCard,[Phone]=@Phone,[Description]=@Description,[Status]=@Status,[Addtime]=@Addtime where UserId=@UserId";
			SqlParameter[] _param={				
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@DepartmentId",SqlDbType.Int),
				new SqlParameter("@Path",SqlDbType.VarChar),
				new SqlParameter("@RoleId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Pwd",SqlDbType.VarChar),
				new SqlParameter("@RealName",SqlDbType.VarChar),
				new SqlParameter("@Sex",SqlDbType.Int),
				new SqlParameter("@Position",SqlDbType.VarChar),
				new SqlParameter("@Mail",SqlDbType.VarChar),
				new SqlParameter("@IdentityCard",SqlDbType.VarChar),
				new SqlParameter("@Phone",SqlDbType.VarChar),
				new SqlParameter("@Description",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_UserModel.UserId;
				_param[1].Value=_tb_UserModel.SchoolId;
				_param[2].Value=_tb_UserModel.DepartmentId;
				_param[3].Value=_tb_UserModel.Path;
				_param[4].Value=_tb_UserModel.RoleId;
				_param[5].Value=_tb_UserModel.Name;
				_param[6].Value=_tb_UserModel.Pwd;
				_param[7].Value=_tb_UserModel.RealName;
				_param[8].Value=_tb_UserModel.Sex;
				_param[9].Value=_tb_UserModel.Position;
				_param[10].Value=_tb_UserModel.Mail;
				_param[11].Value=_tb_UserModel.IdentityCard;
				_param[12].Value=_tb_UserModel.Phone;
				_param[13].Value=_tb_UserModel.Description;
				_param[14].Value=_tb_UserModel.Status;
				_param[15].Value=_tb_UserModel.Addtime;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_User更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_UserModel">_tb_UserModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_UserEntity _tb_UserModel)
		{
            string sqlStr="update tb_User set [SchoolId]=@SchoolId,[DepartmentId]=@DepartmentId,[Path]=@Path,[RoleId]=@RoleId,[Name]=@Name,[Pwd]=@Pwd,[RealName]=@RealName,[Sex]=@Sex,[Position]=@Position,[Mail]=@Mail,[IdentityCard]=@IdentityCard,[Phone]=@Phone,[Description]=@Description,[Status]=@Status,[Addtime]=@Addtime where UserId=@UserId";
			SqlParameter[] _param={				
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@DepartmentId",SqlDbType.Int),
				new SqlParameter("@Path",SqlDbType.VarChar),
				new SqlParameter("@RoleId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Pwd",SqlDbType.VarChar),
				new SqlParameter("@RealName",SqlDbType.VarChar),
				new SqlParameter("@Sex",SqlDbType.Int),
				new SqlParameter("@Position",SqlDbType.VarChar),
				new SqlParameter("@Mail",SqlDbType.VarChar),
				new SqlParameter("@IdentityCard",SqlDbType.VarChar),
				new SqlParameter("@Phone",SqlDbType.VarChar),
				new SqlParameter("@Description",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_UserModel.UserId;
				_param[1].Value=_tb_UserModel.SchoolId;
				_param[2].Value=_tb_UserModel.DepartmentId;
				_param[3].Value=_tb_UserModel.Path;
				_param[4].Value=_tb_UserModel.RoleId;
				_param[5].Value=_tb_UserModel.Name;
				_param[6].Value=_tb_UserModel.Pwd;
				_param[7].Value=_tb_UserModel.RealName;
				_param[8].Value=_tb_UserModel.Sex;
				_param[9].Value=_tb_UserModel.Position;
				_param[10].Value=_tb_UserModel.Mail;
				_param[11].Value=_tb_UserModel.IdentityCard;
				_param[12].Value=_tb_UserModel.Phone;
				_param[13].Value=_tb_UserModel.Description;
				_param[14].Value=_tb_UserModel.Status;
				_param[15].Value=_tb_UserModel.Addtime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_User中的一条记录
		/// </summary>
	    /// <param name="UserId">userId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int UserId)
		{
			string sqlStr="delete from tb_User where [UserId]=@UserId";
			SqlParameter[] _param={			
			new SqlParameter("@UserId",SqlDbType.Int),
			
			};			
			_param[0].Value=UserId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_User中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="UserId">userId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int UserId)
		{
			string sqlStr="delete from tb_User where [UserId]=@UserId";
			SqlParameter[] _param={			
			new SqlParameter("@UserId",SqlDbType.Int),
			
			};			
			_param[0].Value=UserId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_user 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_user 数据实体</returns>
		public tb_UserEntity Populate_tb_UserEntity_FromDr(DataRow row)
		{
			tb_UserEntity Obj = new tb_UserEntity();
			if(row!=null)
			{
				Obj.UserId = (( row["UserId"])==DBNull.Value)?0:Convert.ToInt32( row["UserId"]);
				Obj.SchoolId = (( row["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( row["SchoolId"]);
				Obj.DepartmentId = (( row["DepartmentId"])==DBNull.Value)?0:Convert.ToInt32( row["DepartmentId"]);
				Obj.Path =  row["Path"].ToString();
				Obj.RoleId = (( row["RoleId"])==DBNull.Value)?0:Convert.ToInt32( row["RoleId"]);
				Obj.Name =  row["Name"].ToString();
				Obj.Pwd =  row["Pwd"].ToString();
				Obj.RealName =  row["RealName"].ToString();
				Obj.Sex = (( row["Sex"])==DBNull.Value)?0:Convert.ToInt32( row["Sex"]);
				Obj.Position =  row["Position"].ToString();
				Obj.Mail =  row["Mail"].ToString();
				Obj.IdentityCard =  row["IdentityCard"].ToString();
				Obj.Phone =  row["Phone"].ToString();
				Obj.Description =  row["Description"].ToString();
				Obj.Status = (( row["Status"])==DBNull.Value)?0:Convert.ToInt32( row["Status"]);
				Obj.Addtime = (( row["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["Addtime"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_user 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_user 数据实体</returns>
		public tb_UserEntity Populate_tb_UserEntity_FromDr(IDataReader dr)
		{
			tb_UserEntity Obj = new tb_UserEntity();
			
				Obj.UserId = (( dr["UserId"])==DBNull.Value)?0:Convert.ToInt32( dr["UserId"]);
				Obj.SchoolId = (( dr["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( dr["SchoolId"]);
				Obj.DepartmentId = (( dr["DepartmentId"])==DBNull.Value)?0:Convert.ToInt32( dr["DepartmentId"]);
				Obj.Path =  dr["Path"].ToString();
				Obj.RoleId = (( dr["RoleId"])==DBNull.Value)?0:Convert.ToInt32( dr["RoleId"]);
				Obj.Name =  dr["Name"].ToString();
				Obj.Pwd =  dr["Pwd"].ToString();
				Obj.RealName =  dr["RealName"].ToString();
				Obj.Sex = (( dr["Sex"])==DBNull.Value)?0:Convert.ToInt32( dr["Sex"]);
				Obj.Position =  dr["Position"].ToString();
				Obj.Mail =  dr["Mail"].ToString();
				Obj.IdentityCard =  dr["IdentityCard"].ToString();
				Obj.Phone =  dr["Phone"].ToString();
				Obj.Description =  dr["Description"].ToString();
				Obj.Status = (( dr["Status"])==DBNull.Value)?0:Convert.ToInt32( dr["Status"]);
				Obj.Addtime = (( dr["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Addtime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_User对象
		/// </summary>
		/// <param name="userId">userId</param>
		/// <returns>tb_User对象</returns>
		public tb_UserEntity Get_tb_UserEntity (int userId)
		{
			tb_UserEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@UserId",SqlDbType.Int)
			};
			_param[0].Value=userId;
			string sqlStr="select * from tb_User with(nolock) where UserId=@UserId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_UserEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_User所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_UserEntity> Get_tb_UserAll()
		{
			IList< tb_UserEntity> Obj=new List< tb_UserEntity>();
			string sqlStr="select * from tb_User";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_UserEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_User(int userId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@userId",SqlDbType.Int)
                                  };
            _param[0].Value=userId;
            string sqlStr="select Count(*) from tb_User where UserId=@userId";
            int a=Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
            if(a>0)
            {
                return true;
            }
            else
            {
                return false;
            }
		}

        #endregion
		
		#region----------自定义实例化接口函数----------
		#endregion
    }
}
