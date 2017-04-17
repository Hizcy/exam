// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_User_Department.cs
// 项目名称：买车网
// 创建时间：2015/8/25
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
    /// 数据层实例化接口类 dbo.tb_User_Department.
    /// </summary>
    public partial class tb_User_DepartmentDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_User_DepartmentDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_User_DepartmentModel">tb_User_Department实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_User_DepartmentEntity _tb_User_DepartmentModel)
		{
			string sqlStr="insert into tb_User_Department([SchoolId],[UserId],[DepartmentId]) values(@SchoolId,@UserId,@DepartmentId) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@UserId",SqlDbType.Int),
			new SqlParameter("@DepartmentId",SqlDbType.VarChar)
			};			
			_param[0].Value=_tb_User_DepartmentModel.SchoolId;
			_param[1].Value=_tb_User_DepartmentModel.UserId;
			_param[2].Value=_tb_User_DepartmentModel.DepartmentId;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_User_DepartmentModel">tb_User_Department实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_User_DepartmentEntity _tb_User_DepartmentModel)
		{
			string sqlStr="insert into tb_User_Department([SchoolId],[UserId],[DepartmentId]) values(@SchoolId,@UserId,@DepartmentId) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@UserId",SqlDbType.Int),
			new SqlParameter("@DepartmentId",SqlDbType.VarChar)
			};			
			_param[0].Value=_tb_User_DepartmentModel.SchoolId;
			_param[1].Value=_tb_User_DepartmentModel.UserId;
			_param[2].Value=_tb_User_DepartmentModel.DepartmentId;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_User_Department更新一条记录。
		/// </summary>
		/// <param name="_tb_User_DepartmentModel">_tb_User_DepartmentModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_User_DepartmentEntity _tb_User_DepartmentModel)
		{
            string sqlStr="update tb_User_Department set [SchoolId]=@SchoolId,[UserId]=@UserId,[DepartmentId]=@DepartmentId where RelationId=@RelationId";
			SqlParameter[] _param={				
				new SqlParameter("@RelationId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@DepartmentId",SqlDbType.VarChar)
				};				
				_param[0].Value=_tb_User_DepartmentModel.RelationId;
				_param[1].Value=_tb_User_DepartmentModel.SchoolId;
				_param[2].Value=_tb_User_DepartmentModel.UserId;
				_param[3].Value=_tb_User_DepartmentModel.DepartmentId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_User_Department更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_User_DepartmentModel">_tb_User_DepartmentModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_User_DepartmentEntity _tb_User_DepartmentModel)
		{
            string sqlStr="update tb_User_Department set [SchoolId]=@SchoolId,[UserId]=@UserId,[DepartmentId]=@DepartmentId where RelationId=@RelationId";
			SqlParameter[] _param={				
				new SqlParameter("@RelationId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@DepartmentId",SqlDbType.VarChar)
				};				
				_param[0].Value=_tb_User_DepartmentModel.RelationId;
				_param[1].Value=_tb_User_DepartmentModel.SchoolId;
				_param[2].Value=_tb_User_DepartmentModel.UserId;
				_param[3].Value=_tb_User_DepartmentModel.DepartmentId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_User_Department中的一条记录
		/// </summary>
	    /// <param name="RelationId">relationId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int RelationId)
		{
			string sqlStr="delete from tb_User_Department where [RelationId]=@RelationId";
			SqlParameter[] _param={			
			new SqlParameter("@RelationId",SqlDbType.Int),
			
			};			
			_param[0].Value=RelationId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_User_Department中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="RelationId">relationId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int RelationId)
		{
			string sqlStr="delete from tb_User_Department where [RelationId]=@RelationId";
			SqlParameter[] _param={			
			new SqlParameter("@RelationId",SqlDbType.Int),
			
			};			
			_param[0].Value=RelationId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_user_department 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_user_department 数据实体</returns>
		public tb_User_DepartmentEntity Populate_tb_User_DepartmentEntity_FromDr(DataRow row)
		{
			tb_User_DepartmentEntity Obj = new tb_User_DepartmentEntity();
			if(row!=null)
			{
				Obj.RelationId = (( row["RelationId"])==DBNull.Value)?0:Convert.ToInt32( row["RelationId"]);
				Obj.SchoolId = (( row["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( row["SchoolId"]);
				Obj.UserId = (( row["UserId"])==DBNull.Value)?0:Convert.ToInt32( row["UserId"]);
				Obj.DepartmentId =  row["DepartmentId"].ToString();
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_user_department 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_user_department 数据实体</returns>
		public tb_User_DepartmentEntity Populate_tb_User_DepartmentEntity_FromDr(IDataReader dr)
		{
			tb_User_DepartmentEntity Obj = new tb_User_DepartmentEntity();
			
				Obj.RelationId = (( dr["RelationId"])==DBNull.Value)?0:Convert.ToInt32( dr["RelationId"]);
				Obj.SchoolId = (( dr["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( dr["SchoolId"]);
				Obj.UserId = (( dr["UserId"])==DBNull.Value)?0:Convert.ToInt32( dr["UserId"]);
				Obj.DepartmentId =  dr["DepartmentId"].ToString();
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_User_Department对象
		/// </summary>
		/// <param name="relationId">relationId</param>
		/// <returns>tb_User_Department对象</returns>
		public tb_User_DepartmentEntity Get_tb_User_DepartmentEntity (int relationId)
		{
			tb_User_DepartmentEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@RelationId",SqlDbType.Int)
			};
			_param[0].Value=relationId;
			string sqlStr="select * from tb_User_Department with(nolock) where RelationId=@RelationId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_User_DepartmentEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_User_Department所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_User_DepartmentEntity> Get_tb_User_DepartmentAll()
		{
			IList< tb_User_DepartmentEntity> Obj=new List< tb_User_DepartmentEntity>();
			string sqlStr="select * from tb_User_Department";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_User_DepartmentEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="relationId">relationId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_User_Department(int relationId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@relationId",SqlDbType.Int)
                                  };
            _param[0].Value=relationId;
            string sqlStr="select Count(*) from tb_User_Department where RelationId=@relationId";
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
