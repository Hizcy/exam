// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Word.cs
// 项目名称：买车网
// 创建时间：2015/12/24
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
    /// 数据层实例化接口类 dbo.tb_Word.
    /// </summary>
    public partial class tb_WordDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_WordDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_WordModel">tb_Word实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_WordEntity _tb_WordModel)
		{
			string sqlStr="insert into tb_Word([RoleId],[UserId],[Word],[Status],[Addtime],[Updatetime]) values(@RoleId,@UserId,@Word,@Status,@Addtime,@Updatetime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@RoleId",SqlDbType.Int),
			new SqlParameter("@UserId",SqlDbType.Int),
			new SqlParameter("@Word",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_WordModel.RoleId;
			_param[1].Value=_tb_WordModel.UserId;
			_param[2].Value=_tb_WordModel.Word;
			_param[3].Value=_tb_WordModel.Status;
			_param[4].Value=_tb_WordModel.Addtime;
			_param[5].Value=_tb_WordModel.Updatetime;
            res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW, CommandType.Text, sqlStr, _param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_WordModel">tb_Word实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_WordEntity _tb_WordModel)
		{
			string sqlStr="insert into tb_Word([RoleId],[UserId],[Word],[Status],[Addtime],[Updatetime]) values(@RoleId,@UserId,@Word,@Status,@Addtime,@Updatetime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@RoleId",SqlDbType.Int),
			new SqlParameter("@UserId",SqlDbType.Int),
			new SqlParameter("@Word",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_WordModel.RoleId;
			_param[1].Value=_tb_WordModel.UserId;
			_param[2].Value=_tb_WordModel.Word;
			_param[3].Value=_tb_WordModel.Status;
			_param[4].Value=_tb_WordModel.Addtime;
			_param[5].Value=_tb_WordModel.Updatetime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Word更新一条记录。
		/// </summary>
		/// <param name="_tb_WordModel">_tb_WordModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_WordEntity _tb_WordModel)
		{
            string sqlStr="update tb_Word set [RoleId]=@RoleId,[UserId]=@UserId,[Word]=@Word,[Status]=@Status,[Addtime]=@Addtime,[Updatetime]=@Updatetime where Id=@Id";
			SqlParameter[] _param={				
				new SqlParameter("@Id",SqlDbType.Int),
				new SqlParameter("@RoleId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@Word",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_WordModel.Id;
				_param[1].Value=_tb_WordModel.RoleId;
				_param[2].Value=_tb_WordModel.UserId;
				_param[3].Value=_tb_WordModel.Word;
				_param[4].Value=_tb_WordModel.Status;
				_param[5].Value=_tb_WordModel.Addtime;
				_param[6].Value=_tb_WordModel.Updatetime;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Word更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_WordModel">_tb_WordModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_WordEntity _tb_WordModel)
		{
            string sqlStr="update tb_Word set [RoleId]=@RoleId,[UserId]=@UserId,[Word]=@Word,[Status]=@Status,[Addtime]=@Addtime,[Updatetime]=@Updatetime where Id=@Id";
			SqlParameter[] _param={				
				new SqlParameter("@Id",SqlDbType.Int),
				new SqlParameter("@RoleId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@Word",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_WordModel.Id;
				_param[1].Value=_tb_WordModel.RoleId;
				_param[2].Value=_tb_WordModel.UserId;
				_param[3].Value=_tb_WordModel.Word;
				_param[4].Value=_tb_WordModel.Status;
				_param[5].Value=_tb_WordModel.Addtime;
				_param[6].Value=_tb_WordModel.Updatetime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Word中的一条记录
		/// </summary>
	    /// <param name="Id">id</param>
		/// <returns>影响的行数</returns>
		public int Delete(int Id)
		{
			string sqlStr="delete from tb_Word where [Id]=@Id";
			SqlParameter[] _param={			
			new SqlParameter("@Id",SqlDbType.Int),
			
			};			
			_param[0].Value=Id;
            return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
		}
		
		/// <summary>
		/// 删除数据表tb_Word中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="Id">id</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int Id)
		{
			string sqlStr="delete from tb_Word where [Id]=@Id";
			SqlParameter[] _param={			
			new SqlParameter("@Id",SqlDbType.Int),
			
			};			
			_param[0].Value=Id;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_word 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_word 数据实体</returns>
		public tb_WordEntity Populate_tb_WordEntity_FromDr(DataRow row)
		{
			tb_WordEntity Obj = new tb_WordEntity();
			if(row!=null)
			{
				Obj.Id = (( row["Id"])==DBNull.Value)?0:Convert.ToInt32( row["Id"]);
				Obj.RoleId = (( row["RoleId"])==DBNull.Value)?0:Convert.ToInt32( row["RoleId"]);
				Obj.UserId = (( row["UserId"])==DBNull.Value)?0:Convert.ToInt32( row["UserId"]);
				Obj.Word =  row["Word"].ToString();
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
		/// 得到  tb_word 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_word 数据实体</returns>
		public tb_WordEntity Populate_tb_WordEntity_FromDr(IDataReader dr)
		{
			tb_WordEntity Obj = new tb_WordEntity();
			
				Obj.Id = (( dr["Id"])==DBNull.Value)?0:Convert.ToInt32( dr["Id"]);
				Obj.RoleId = (( dr["RoleId"])==DBNull.Value)?0:Convert.ToInt32( dr["RoleId"]);
				Obj.UserId = (( dr["UserId"])==DBNull.Value)?0:Convert.ToInt32( dr["UserId"]);
				Obj.Word =  dr["Word"].ToString();
				Obj.Status = (( dr["Status"])==DBNull.Value)?0:Convert.ToInt32( dr["Status"]);
				Obj.Addtime = (( dr["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Addtime"]);
				Obj.Updatetime = (( dr["Updatetime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Updatetime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Word对象
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>tb_Word对象</returns>
		public tb_WordEntity Get_tb_WordEntity (int id)
		{
			tb_WordEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@Id",SqlDbType.Int)
			};
			_param[0].Value=id;
			string sqlStr="select * from tb_Word with(nolock) where Id=@Id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_WordEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Word所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_WordEntity> Get_tb_WordAll()
		{
			IList< tb_WordEntity> Obj=new List< tb_WordEntity>();
			string sqlStr="select * from tb_Word";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_WordEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Word(int id)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@id",SqlDbType.Int)
                                  };
            _param[0].Value=id;
            string sqlStr="select Count(*) from tb_Word where Id=@id";
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
