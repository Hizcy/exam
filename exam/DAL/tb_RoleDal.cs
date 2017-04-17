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
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_RoleDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_RoleModel">tb_Role实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_RoleEntity _tb_RoleModel)
		{
			string sqlStr="insert into tb_Role([Name],[Permissions],[Status],[Addtime]) values(@Name,@Permissions,@Status,@Addtime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Permissions",SqlDbType.Int),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_RoleModel.Name;
			_param[1].Value=_tb_RoleModel.Permissions;
			_param[2].Value=_tb_RoleModel.Status;
			_param[3].Value=_tb_RoleModel.Addtime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_RoleModel">tb_Role实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_RoleEntity _tb_RoleModel)
		{
			string sqlStr="insert into tb_Role([Name],[Permissions],[Status],[Addtime]) values(@Name,@Permissions,@Status,@Addtime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Permissions",SqlDbType.Int),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_RoleModel.Name;
			_param[1].Value=_tb_RoleModel.Permissions;
			_param[2].Value=_tb_RoleModel.Status;
			_param[3].Value=_tb_RoleModel.Addtime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Role更新一条记录。
		/// </summary>
		/// <param name="_tb_RoleModel">_tb_RoleModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_RoleEntity _tb_RoleModel)
		{
            string sqlStr="update tb_Role set [Name]=@Name,[Permissions]=@Permissions,[Status]=@Status,[Addtime]=@Addtime where RoleId=@RoleId";
			SqlParameter[] _param={				
				new SqlParameter("@RoleId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Permissions",SqlDbType.Int),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_RoleModel.RoleId;
				_param[1].Value=_tb_RoleModel.Name;
				_param[2].Value=_tb_RoleModel.Permissions;
				_param[3].Value=_tb_RoleModel.Status;
				_param[4].Value=_tb_RoleModel.Addtime;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Role更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_RoleModel">_tb_RoleModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_RoleEntity _tb_RoleModel)
		{
            string sqlStr="update tb_Role set [Name]=@Name,[Permissions]=@Permissions,[Status]=@Status,[Addtime]=@Addtime where RoleId=@RoleId";
			SqlParameter[] _param={				
				new SqlParameter("@RoleId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Permissions",SqlDbType.Int),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_RoleModel.RoleId;
				_param[1].Value=_tb_RoleModel.Name;
				_param[2].Value=_tb_RoleModel.Permissions;
				_param[3].Value=_tb_RoleModel.Status;
				_param[4].Value=_tb_RoleModel.Addtime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Role中的一条记录
		/// </summary>
	    /// <param name="RoleId">roleId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int RoleId)
		{
			string sqlStr="delete from tb_Role where [RoleId]=@RoleId";
			SqlParameter[] _param={			
			new SqlParameter("@RoleId",SqlDbType.Int),
			
			};			
			_param[0].Value=RoleId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_Role中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="RoleId">roleId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int RoleId)
		{
			string sqlStr="delete from tb_Role where [RoleId]=@RoleId";
			SqlParameter[] _param={			
			new SqlParameter("@RoleId",SqlDbType.Int),
			
			};			
			_param[0].Value=RoleId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_role 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_role 数据实体</returns>
		public tb_RoleEntity Populate_tb_RoleEntity_FromDr(DataRow row)
		{
			tb_RoleEntity Obj = new tb_RoleEntity();
			if(row!=null)
			{
				Obj.RoleId = (( row["RoleId"])==DBNull.Value)?0:Convert.ToInt32( row["RoleId"]);
				Obj.Name =  row["Name"].ToString();
				Obj.Permissions = (( row["Permissions"])==DBNull.Value)?0:Convert.ToInt32( row["Permissions"]);
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
		/// 得到  tb_role 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_role 数据实体</returns>
		public tb_RoleEntity Populate_tb_RoleEntity_FromDr(IDataReader dr)
		{
			tb_RoleEntity Obj = new tb_RoleEntity();
			
				Obj.RoleId = (( dr["RoleId"])==DBNull.Value)?0:Convert.ToInt32( dr["RoleId"]);
				Obj.Name =  dr["Name"].ToString();
				Obj.Permissions = (( dr["Permissions"])==DBNull.Value)?0:Convert.ToInt32( dr["Permissions"]);
				Obj.Status = (( dr["Status"])==DBNull.Value)?0:Convert.ToInt32( dr["Status"]);
				Obj.Addtime = (( dr["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Addtime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Role对象
		/// </summary>
		/// <param name="roleId">roleId</param>
		/// <returns>tb_Role对象</returns>
		public tb_RoleEntity Get_tb_RoleEntity (int roleId)
		{
			tb_RoleEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@RoleId",SqlDbType.Int)
			};
			_param[0].Value=roleId;
			string sqlStr="select * from tb_Role with(nolock) where RoleId=@RoleId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_RoleEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Role所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_RoleEntity> Get_tb_RoleAll()
		{
			IList< tb_RoleEntity> Obj=new List< tb_RoleEntity>();
			string sqlStr="select * from tb_Role";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_RoleEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="roleId">roleId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Role(int roleId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@roleId",SqlDbType.Int)
                                  };
            _param[0].Value=roleId;
            string sqlStr="select Count(*) from tb_Role where RoleId=@roleId";
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
