// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Forums.cs
// 项目名称：买车网
// 创建时间：2015/12/16
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
    /// 数据层实例化接口类 dbo.tb_Forums.
    /// </summary>
    public partial class tb_ForumsDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_ForumsDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_ForumsModel">tb_Forums实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_ForumsEntity _tb_ForumsModel)
		{
			string sqlStr="insert into tb_Forums([UserId],[BookId],[Content],[Status],[Addtime]) values(@UserId,@BookId,@Content,@Status,@Addtime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@UserId",SqlDbType.Int),
			new SqlParameter("@BookId",SqlDbType.Int),
			new SqlParameter("@Content",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_ForumsModel.UserId;
			_param[1].Value=_tb_ForumsModel.BookId;
			_param[2].Value=_tb_ForumsModel.Content;
			_param[3].Value=_tb_ForumsModel.Status;
			_param[4].Value=_tb_ForumsModel.Addtime;
            res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW, CommandType.Text, sqlStr, _param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ForumsModel">tb_Forums实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_ForumsEntity _tb_ForumsModel)
		{
			string sqlStr="insert into tb_Forums([UserId],[BookId],[Content],[Status],[Addtime]) values(@UserId,@BookId,@Content,@Status,@Addtime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@UserId",SqlDbType.Int),
			new SqlParameter("@BookId",SqlDbType.Int),
			new SqlParameter("@Content",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_ForumsModel.UserId;
			_param[1].Value=_tb_ForumsModel.BookId;
			_param[2].Value=_tb_ForumsModel.Content;
			_param[3].Value=_tb_ForumsModel.Status;
			_param[4].Value=_tb_ForumsModel.Addtime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Forums更新一条记录。
		/// </summary>
		/// <param name="_tb_ForumsModel">_tb_ForumsModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_ForumsEntity _tb_ForumsModel)
		{
            string sqlStr="update tb_Forums set [UserId]=@UserId,[BookId]=@BookId,[Content]=@Content,[Status]=@Status,[Addtime]=@Addtime where Id=@Id";
			SqlParameter[] _param={				
				new SqlParameter("@Id",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@BookId",SqlDbType.Int),
				new SqlParameter("@Content",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_ForumsModel.Id;
				_param[1].Value=_tb_ForumsModel.UserId;
				_param[2].Value=_tb_ForumsModel.BookId;
				_param[3].Value=_tb_ForumsModel.Content;
				_param[4].Value=_tb_ForumsModel.Status;
				_param[5].Value=_tb_ForumsModel.Addtime;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Forums更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ForumsModel">_tb_ForumsModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_ForumsEntity _tb_ForumsModel)
		{
            string sqlStr="update tb_Forums set [UserId]=@UserId,[BookId]=@BookId,[Content]=@Content,[Status]=@Status,[Addtime]=@Addtime where Id=@Id";
			SqlParameter[] _param={				
				new SqlParameter("@Id",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@BookId",SqlDbType.Int),
				new SqlParameter("@Content",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_ForumsModel.Id;
				_param[1].Value=_tb_ForumsModel.UserId;
				_param[2].Value=_tb_ForumsModel.BookId;
				_param[3].Value=_tb_ForumsModel.Content;
				_param[4].Value=_tb_ForumsModel.Status;
				_param[5].Value=_tb_ForumsModel.Addtime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Forums中的一条记录
		/// </summary>
	    /// <param name="Id">id</param>
		/// <returns>影响的行数</returns>
		public int Delete(int Id)
		{
			string sqlStr="delete from tb_Forums where [Id]=@Id";
			SqlParameter[] _param={			
			new SqlParameter("@Id",SqlDbType.Int),
			
			};			
			_param[0].Value=Id;
            return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
		}
		
		/// <summary>
		/// 删除数据表tb_Forums中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="Id">id</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int Id)
		{
			string sqlStr="delete from tb_Forums where [Id]=@Id";
			SqlParameter[] _param={			
			new SqlParameter("@Id",SqlDbType.Int),
			
			};			
			_param[0].Value=Id;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_forums 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_forums 数据实体</returns>
		public tb_ForumsEntity Populate_tb_ForumsEntity_FromDr(DataRow row)
		{
			tb_ForumsEntity Obj = new tb_ForumsEntity();
			if(row!=null)
			{
				Obj.Id = (( row["Id"])==DBNull.Value)?0:Convert.ToInt32( row["Id"]);
				Obj.UserId = (( row["UserId"])==DBNull.Value)?0:Convert.ToInt32( row["UserId"]);
				Obj.BookId = (( row["BookId"])==DBNull.Value)?0:Convert.ToInt32( row["BookId"]);
				Obj.Content =  row["Content"].ToString();
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
		/// 得到  tb_forums 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_forums 数据实体</returns>
		public tb_ForumsEntity Populate_tb_ForumsEntity_FromDr(IDataReader dr)
		{
			tb_ForumsEntity Obj = new tb_ForumsEntity();
			
				Obj.Id = (( dr["Id"])==DBNull.Value)?0:Convert.ToInt32( dr["Id"]);
				Obj.UserId = (( dr["UserId"])==DBNull.Value)?0:Convert.ToInt32( dr["UserId"]);
				Obj.BookId = (( dr["BookId"])==DBNull.Value)?0:Convert.ToInt32( dr["BookId"]);
				Obj.Content =  dr["Content"].ToString();
				Obj.Status = (( dr["Status"])==DBNull.Value)?0:Convert.ToInt32( dr["Status"]);
				Obj.Addtime = (( dr["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Addtime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Forums对象
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>tb_Forums对象</returns>
		public tb_ForumsEntity Get_tb_ForumsEntity (int id)
		{
			tb_ForumsEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@Id",SqlDbType.Int)
			};
			_param[0].Value=id;
			string sqlStr="select * from tb_Forums with(nolock) where Id=@Id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_ForumsEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Forums所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_ForumsEntity> Get_tb_ForumsAll()
		{
			IList< tb_ForumsEntity> Obj=new List< tb_ForumsEntity>();
            string sqlStr = "select * from tb_Forums order by addtime desc";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_ForumsEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Forums(int id)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@id",SqlDbType.Int)
                                  };
            _param[0].Value=id;
            string sqlStr="select Count(*) from tb_Forums where Id=@id";
            int a = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW, CommandType.Text, sqlStr, _param));
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
