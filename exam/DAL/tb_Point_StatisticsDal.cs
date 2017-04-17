// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Point_Statistics.cs
// 项目名称：买车网
// 创建时间：2015/8/28
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
    /// 数据层实例化接口类 dbo.tb_Point_Statistics.
    /// </summary>
    public partial class tb_Point_StatisticsDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_Point_StatisticsDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_Point_StatisticsModel">tb_Point_Statistics实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_Point_StatisticsEntity _tb_Point_StatisticsModel)
		{
			string sqlStr="insert into tb_Point_Statistics([SchoolId],[UserId],[Point]) values(@SchoolId,@UserId,@Point) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@UserId",SqlDbType.Int),
			new SqlParameter("@Point",SqlDbType.Int)
			};			
			_param[0].Value=_tb_Point_StatisticsModel.SchoolId;
			_param[1].Value=_tb_Point_StatisticsModel.UserId;
			_param[2].Value=_tb_Point_StatisticsModel.Point;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_Point_StatisticsModel">tb_Point_Statistics实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_Point_StatisticsEntity _tb_Point_StatisticsModel)
		{
			string sqlStr="insert into tb_Point_Statistics([SchoolId],[UserId],[Point]) values(@SchoolId,@UserId,@Point) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@UserId",SqlDbType.Int),
			new SqlParameter("@Point",SqlDbType.Int)
			};			
			_param[0].Value=_tb_Point_StatisticsModel.SchoolId;
			_param[1].Value=_tb_Point_StatisticsModel.UserId;
			_param[2].Value=_tb_Point_StatisticsModel.Point;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Point_Statistics更新一条记录。
		/// </summary>
		/// <param name="_tb_Point_StatisticsModel">_tb_Point_StatisticsModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_Point_StatisticsEntity _tb_Point_StatisticsModel)
		{
            string sqlStr="update tb_Point_Statistics set [SchoolId]=@SchoolId,[UserId]=@UserId,[Point]=@Point where Id=@Id";
			SqlParameter[] _param={				
				new SqlParameter("@Id",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@Point",SqlDbType.Int)
				};				
				_param[0].Value=_tb_Point_StatisticsModel.Id;
				_param[1].Value=_tb_Point_StatisticsModel.SchoolId;
				_param[2].Value=_tb_Point_StatisticsModel.UserId;
				_param[3].Value=_tb_Point_StatisticsModel.Point;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Point_Statistics更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_Point_StatisticsModel">_tb_Point_StatisticsModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_Point_StatisticsEntity _tb_Point_StatisticsModel)
		{
            string sqlStr="update tb_Point_Statistics set [SchoolId]=@SchoolId,[UserId]=@UserId,[Point]=@Point where Id=@Id";
			SqlParameter[] _param={				
				new SqlParameter("@Id",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@Point",SqlDbType.Int)
				};				
				_param[0].Value=_tb_Point_StatisticsModel.Id;
				_param[1].Value=_tb_Point_StatisticsModel.SchoolId;
				_param[2].Value=_tb_Point_StatisticsModel.UserId;
				_param[3].Value=_tb_Point_StatisticsModel.Point;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Point_Statistics中的一条记录
		/// </summary>
	    /// <param name="Id">id</param>
		/// <returns>影响的行数</returns>
		public int Delete(int Id)
		{
			string sqlStr="delete from tb_Point_Statistics where [Id]=@Id";
			SqlParameter[] _param={			
			new SqlParameter("@Id",SqlDbType.Int),
			
			};			
			_param[0].Value=Id;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_Point_Statistics中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="Id">id</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int Id)
		{
			string sqlStr="delete from tb_Point_Statistics where [Id]=@Id";
			SqlParameter[] _param={			
			new SqlParameter("@Id",SqlDbType.Int),
			
			};			
			_param[0].Value=Id;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_point_statistics 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_point_statistics 数据实体</returns>
		public tb_Point_StatisticsEntity Populate_tb_Point_StatisticsEntity_FromDr(DataRow row)
		{
			tb_Point_StatisticsEntity Obj = new tb_Point_StatisticsEntity();
			if(row!=null)
			{
				Obj.Id = (( row["Id"])==DBNull.Value)?0:Convert.ToInt32( row["Id"]);
				Obj.SchoolId = (( row["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( row["SchoolId"]);
				Obj.UserId = (( row["UserId"])==DBNull.Value)?0:Convert.ToInt32( row["UserId"]);
				Obj.Point = (( row["Point"])==DBNull.Value)?0:Convert.ToInt32( row["Point"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_point_statistics 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_point_statistics 数据实体</returns>
		public tb_Point_StatisticsEntity Populate_tb_Point_StatisticsEntity_FromDr(IDataReader dr)
		{
			tb_Point_StatisticsEntity Obj = new tb_Point_StatisticsEntity();
			
				Obj.Id = (( dr["Id"])==DBNull.Value)?0:Convert.ToInt32( dr["Id"]);
				Obj.SchoolId = (( dr["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( dr["SchoolId"]);
				Obj.UserId = (( dr["UserId"])==DBNull.Value)?0:Convert.ToInt32( dr["UserId"]);
				Obj.Point = (( dr["Point"])==DBNull.Value)?0:Convert.ToInt32( dr["Point"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Point_Statistics对象
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>tb_Point_Statistics对象</returns>
		public tb_Point_StatisticsEntity Get_tb_Point_StatisticsEntity (int id)
		{
			tb_Point_StatisticsEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@Id",SqlDbType.Int)
			};
			_param[0].Value=id;
			string sqlStr="select * from tb_Point_Statistics with(nolock) where Id=@Id";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_Point_StatisticsEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Point_Statistics所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_Point_StatisticsEntity> Get_tb_Point_StatisticsAll()
		{
			IList< tb_Point_StatisticsEntity> Obj=new List< tb_Point_StatisticsEntity>();
			string sqlStr="select * from tb_Point_Statistics";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_Point_StatisticsEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Point_Statistics(int id)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@id",SqlDbType.Int)
                                  };
            _param[0].Value=id;
            string sqlStr="select Count(*) from tb_Point_Statistics where Id=@id";
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
