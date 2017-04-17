// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Result.cs
// 项目名称：买车网
// 创建时间：2015/8/27
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
    /// 数据层实例化接口类 dbo.tb_Result.
    /// </summary>
    public partial class tb_ResultDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_ResultDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_ResultModel">tb_Result实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_ResultEntity _tb_ResultModel)
		{
			string sqlStr="insert into tb_Result([SchoolId],[UserId],[ExampaperId],[Score],[Point],[Addtime]) values(@SchoolId,@UserId,@ExampaperId,@Score,@Point,@Addtime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@UserId",SqlDbType.Int),
			new SqlParameter("@ExampaperId",SqlDbType.Int),
			new SqlParameter("@Score",SqlDbType.Int),
			new SqlParameter("@Point",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_ResultModel.SchoolId;
			_param[1].Value=_tb_ResultModel.UserId;
			_param[2].Value=_tb_ResultModel.ExampaperId;
			_param[3].Value=_tb_ResultModel.Score;
			_param[4].Value=_tb_ResultModel.Point;
			_param[5].Value=_tb_ResultModel.Addtime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ResultModel">tb_Result实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_ResultEntity _tb_ResultModel)
		{
			string sqlStr="insert into tb_Result([SchoolId],[UserId],[ExampaperId],[Score],[Point],[Addtime]) values(@SchoolId,@UserId,@ExampaperId,@Score,@Point,@Addtime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@UserId",SqlDbType.Int),
			new SqlParameter("@ExampaperId",SqlDbType.Int),
			new SqlParameter("@Score",SqlDbType.Int),
			new SqlParameter("@Point",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_ResultModel.SchoolId;
			_param[1].Value=_tb_ResultModel.UserId;
			_param[2].Value=_tb_ResultModel.ExampaperId;
			_param[3].Value=_tb_ResultModel.Score;
			_param[4].Value=_tb_ResultModel.Point;
			_param[5].Value=_tb_ResultModel.Addtime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Result更新一条记录。
		/// </summary>
		/// <param name="_tb_ResultModel">_tb_ResultModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_ResultEntity _tb_ResultModel)
		{
            string sqlStr="update tb_Result set [SchoolId]=@SchoolId,[UserId]=@UserId,[ExampaperId]=@ExampaperId,[Score]=@Score,[Point]=@Point,[Addtime]=@Addtime where ResultId=@ResultId";
			SqlParameter[] _param={				
				new SqlParameter("@ResultId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@ExampaperId",SqlDbType.Int),
				new SqlParameter("@Score",SqlDbType.Int),
				new SqlParameter("@Point",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_ResultModel.ResultId;
				_param[1].Value=_tb_ResultModel.SchoolId;
				_param[2].Value=_tb_ResultModel.UserId;
				_param[3].Value=_tb_ResultModel.ExampaperId;
				_param[4].Value=_tb_ResultModel.Score;
				_param[5].Value=_tb_ResultModel.Point;
				_param[6].Value=_tb_ResultModel.Addtime;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Result更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ResultModel">_tb_ResultModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_ResultEntity _tb_ResultModel)
		{
            string sqlStr="update tb_Result set [SchoolId]=@SchoolId,[UserId]=@UserId,[ExampaperId]=@ExampaperId,[Score]=@Score,[Point]=@Point,[Addtime]=@Addtime where ResultId=@ResultId";
			SqlParameter[] _param={				
				new SqlParameter("@ResultId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@ExampaperId",SqlDbType.Int),
				new SqlParameter("@Score",SqlDbType.Int),
				new SqlParameter("@Point",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_ResultModel.ResultId;
				_param[1].Value=_tb_ResultModel.SchoolId;
				_param[2].Value=_tb_ResultModel.UserId;
				_param[3].Value=_tb_ResultModel.ExampaperId;
				_param[4].Value=_tb_ResultModel.Score;
				_param[5].Value=_tb_ResultModel.Point;
				_param[6].Value=_tb_ResultModel.Addtime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Result中的一条记录
		/// </summary>
	    /// <param name="ResultId">resultId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ResultId)
		{
			string sqlStr="delete from tb_Result where [ResultId]=@ResultId";
			SqlParameter[] _param={			
			new SqlParameter("@ResultId",SqlDbType.Int),
			
			};			
			_param[0].Value=ResultId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_Result中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ResultId">resultId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ResultId)
		{
			string sqlStr="delete from tb_Result where [ResultId]=@ResultId";
			SqlParameter[] _param={			
			new SqlParameter("@ResultId",SqlDbType.Int),
			
			};			
			_param[0].Value=ResultId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_result 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_result 数据实体</returns>
		public tb_ResultEntity Populate_tb_ResultEntity_FromDr(DataRow row)
		{
			tb_ResultEntity Obj = new tb_ResultEntity();
			if(row!=null)
			{
				Obj.ResultId = (( row["ResultId"])==DBNull.Value)?0:Convert.ToInt32( row["ResultId"]);
				Obj.SchoolId = (( row["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( row["SchoolId"]);
				Obj.UserId = (( row["UserId"])==DBNull.Value)?0:Convert.ToInt32( row["UserId"]);
				Obj.ExampaperId = (( row["ExampaperId"])==DBNull.Value)?0:Convert.ToInt32( row["ExampaperId"]);
				Obj.Score = (( row["Score"])==DBNull.Value)?0:Convert.ToInt32( row["Score"]);
				Obj.Point = (( row["Point"])==DBNull.Value)?0:Convert.ToInt32( row["Point"]);
				Obj.Addtime = (( row["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["Addtime"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_result 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_result 数据实体</returns>
		public tb_ResultEntity Populate_tb_ResultEntity_FromDr(IDataReader dr)
		{
			tb_ResultEntity Obj = new tb_ResultEntity();
			
				Obj.ResultId = (( dr["ResultId"])==DBNull.Value)?0:Convert.ToInt32( dr["ResultId"]);
				Obj.SchoolId = (( dr["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( dr["SchoolId"]);
				Obj.UserId = (( dr["UserId"])==DBNull.Value)?0:Convert.ToInt32( dr["UserId"]);
				Obj.ExampaperId = (( dr["ExampaperId"])==DBNull.Value)?0:Convert.ToInt32( dr["ExampaperId"]);
				Obj.Score = (( dr["Score"])==DBNull.Value)?0:Convert.ToInt32( dr["Score"]);
				Obj.Point = (( dr["Point"])==DBNull.Value)?0:Convert.ToInt32( dr["Point"]);
				Obj.Addtime = (( dr["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Addtime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Result对象
		/// </summary>
		/// <param name="resultId">resultId</param>
		/// <returns>tb_Result对象</returns>
		public tb_ResultEntity Get_tb_ResultEntity (int resultId)
		{
			tb_ResultEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ResultId",SqlDbType.Int)
			};
			_param[0].Value=resultId;
			string sqlStr="select * from tb_Result with(nolock) where ResultId=@ResultId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_ResultEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Result所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_ResultEntity> Get_tb_ResultAll()
		{
			IList< tb_ResultEntity> Obj=new List< tb_ResultEntity>();
			string sqlStr="select * from tb_Result";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_ResultEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="resultId">resultId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Result(int resultId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@resultId",SqlDbType.Int)
                                  };
            _param[0].Value=resultId;
            string sqlStr="select Count(*) from tb_Result where ResultId=@resultId";
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
