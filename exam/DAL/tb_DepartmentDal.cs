// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Department.cs
// 项目名称：买车网
// 创建时间：2015/8/11
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
    /// 数据层实例化接口类 dbo.tb_Department.
    /// </summary>
    public partial class tb_DepartmentDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_DepartmentDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_DepartmentModel">tb_Department实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_DepartmentEntity _tb_DepartmentModel)
		{
			string sqlStr="insert into tb_Department([SchoolId],[RoleId],[ParentId],[Name],[Description],[Status],[Addtime],[Updatetime]) values(@SchoolId,@RoleId,@ParentId,@Name,@Description,@Status,@Addtime,@Updatetime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@RoleId",SqlDbType.Int),
			new SqlParameter("@ParentId",SqlDbType.Int),
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Description",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_DepartmentModel.SchoolId;
			_param[1].Value=_tb_DepartmentModel.RoleId;
			_param[2].Value=_tb_DepartmentModel.ParentId;
			_param[3].Value=_tb_DepartmentModel.Name;
			_param[4].Value=_tb_DepartmentModel.Description;
			_param[5].Value=_tb_DepartmentModel.Status;
			_param[6].Value=_tb_DepartmentModel.Addtime;
			_param[7].Value=_tb_DepartmentModel.Updatetime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_DepartmentModel">tb_Department实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_DepartmentEntity _tb_DepartmentModel)
		{
			string sqlStr="insert into tb_Department([SchoolId],[RoleId],[ParentId],[Name],[Description],[Status],[Addtime],[Updatetime]) values(@SchoolId,@RoleId,@ParentId,@Name,@Description,@Status,@Addtime,@Updatetime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@RoleId",SqlDbType.Int),
			new SqlParameter("@ParentId",SqlDbType.Int),
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Description",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_DepartmentModel.SchoolId;
			_param[1].Value=_tb_DepartmentModel.RoleId;
			_param[2].Value=_tb_DepartmentModel.ParentId;
			_param[3].Value=_tb_DepartmentModel.Name;
			_param[4].Value=_tb_DepartmentModel.Description;
			_param[5].Value=_tb_DepartmentModel.Status;
			_param[6].Value=_tb_DepartmentModel.Addtime;
			_param[7].Value=_tb_DepartmentModel.Updatetime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Department更新一条记录。
		/// </summary>
		/// <param name="_tb_DepartmentModel">_tb_DepartmentModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_DepartmentEntity _tb_DepartmentModel)
		{
            string sqlStr="update tb_Department set [SchoolId]=@SchoolId,[RoleId]=@RoleId,[ParentId]=@ParentId,[Name]=@Name,[Description]=@Description,[Status]=@Status,[Addtime]=@Addtime,[Updatetime]=@Updatetime where DepartmentId=@DepartmentId";
			SqlParameter[] _param={				
				new SqlParameter("@DepartmentId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@RoleId",SqlDbType.Int),
				new SqlParameter("@ParentId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Description",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_DepartmentModel.DepartmentId;
				_param[1].Value=_tb_DepartmentModel.SchoolId;
				_param[2].Value=_tb_DepartmentModel.RoleId;
				_param[3].Value=_tb_DepartmentModel.ParentId;
				_param[4].Value=_tb_DepartmentModel.Name;
				_param[5].Value=_tb_DepartmentModel.Description;
				_param[6].Value=_tb_DepartmentModel.Status;
				_param[7].Value=_tb_DepartmentModel.Addtime;
				_param[8].Value=_tb_DepartmentModel.Updatetime;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Department更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_DepartmentModel">_tb_DepartmentModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_DepartmentEntity _tb_DepartmentModel)
		{
            string sqlStr="update tb_Department set [SchoolId]=@SchoolId,[RoleId]=@RoleId,[ParentId]=@ParentId,[Name]=@Name,[Description]=@Description,[Status]=@Status,[Addtime]=@Addtime,[Updatetime]=@Updatetime where DepartmentId=@DepartmentId";
			SqlParameter[] _param={				
				new SqlParameter("@DepartmentId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@RoleId",SqlDbType.Int),
				new SqlParameter("@ParentId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Description",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_DepartmentModel.DepartmentId;
				_param[1].Value=_tb_DepartmentModel.SchoolId;
				_param[2].Value=_tb_DepartmentModel.RoleId;
				_param[3].Value=_tb_DepartmentModel.ParentId;
				_param[4].Value=_tb_DepartmentModel.Name;
				_param[5].Value=_tb_DepartmentModel.Description;
				_param[6].Value=_tb_DepartmentModel.Status;
				_param[7].Value=_tb_DepartmentModel.Addtime;
				_param[8].Value=_tb_DepartmentModel.Updatetime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Department中的一条记录
		/// </summary>
	    /// <param name="DepartmentId">departmentId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int DepartmentId)
		{
			string sqlStr="delete from tb_Department where [DepartmentId]=@DepartmentId";
			SqlParameter[] _param={			
			new SqlParameter("@DepartmentId",SqlDbType.Int),
			
			};			
			_param[0].Value=DepartmentId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_Department中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="DepartmentId">departmentId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int DepartmentId)
		{
			string sqlStr="delete from tb_Department where [DepartmentId]=@DepartmentId";
			SqlParameter[] _param={			
			new SqlParameter("@DepartmentId",SqlDbType.Int),
			
			};			
			_param[0].Value=DepartmentId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_department 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_department 数据实体</returns>
		public tb_DepartmentEntity Populate_tb_DepartmentEntity_FromDr(DataRow row)
		{
			tb_DepartmentEntity Obj = new tb_DepartmentEntity();
			if(row!=null)
			{
				Obj.DepartmentId = (( row["DepartmentId"])==DBNull.Value)?0:Convert.ToInt32( row["DepartmentId"]);
				Obj.SchoolId = (( row["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( row["SchoolId"]);
				Obj.RoleId = (( row["RoleId"])==DBNull.Value)?0:Convert.ToInt32( row["RoleId"]);
				Obj.ParentId = (( row["ParentId"])==DBNull.Value)?0:Convert.ToInt32( row["ParentId"]);
				Obj.Name =  row["Name"].ToString();
				Obj.Description =  row["Description"].ToString();
				Obj.Status = (( row["Status"])==DBNull.Value)?0:Convert.ToInt32( row["Status"]);
				Obj.Addtime = (( row["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["Addtime"]);
				Obj.Updatetime = (( row["Updatetime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["Updatetime"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_department 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_department 数据实体</returns>
		public tb_DepartmentEntity Populate_tb_DepartmentEntity_FromDr(IDataReader dr)
		{
			tb_DepartmentEntity Obj = new tb_DepartmentEntity();
			
				Obj.DepartmentId = (( dr["DepartmentId"])==DBNull.Value)?0:Convert.ToInt32( dr["DepartmentId"]);
				Obj.SchoolId = (( dr["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( dr["SchoolId"]);
				Obj.RoleId = (( dr["RoleId"])==DBNull.Value)?0:Convert.ToInt32( dr["RoleId"]);
				Obj.ParentId = (( dr["ParentId"])==DBNull.Value)?0:Convert.ToInt32( dr["ParentId"]);
				Obj.Name =  dr["Name"].ToString();
				Obj.Description =  dr["Description"].ToString();
				Obj.Status = (( dr["Status"])==DBNull.Value)?0:Convert.ToInt32( dr["Status"]);
				Obj.Addtime = (( dr["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Addtime"]);
				Obj.Updatetime = (( dr["Updatetime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Updatetime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Department对象
		/// </summary>
		/// <param name="departmentId">departmentId</param>
		/// <returns>tb_Department对象</returns>
		public tb_DepartmentEntity Get_tb_DepartmentEntity (int departmentId)
		{
			tb_DepartmentEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@DepartmentId",SqlDbType.Int)
			};
			_param[0].Value=departmentId;
			string sqlStr="select * from tb_Department with(nolock) where DepartmentId=@DepartmentId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_DepartmentEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Department所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_DepartmentEntity> Get_tb_DepartmentSchoolIdAll()
		{
			IList< tb_DepartmentEntity> Obj=new List< tb_DepartmentEntity>();
            string sqlStr = "select * from tb_Department where parentid=0";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_DepartmentEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="departmentId">departmentId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Department(int departmentId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@departmentId",SqlDbType.Int)
                                  };
            _param[0].Value=departmentId;
            string sqlStr="select Count(*) from tb_Department where DepartmentId=@departmentId";
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
