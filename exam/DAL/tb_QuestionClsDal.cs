// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_QuestionCls.cs
// 项目名称：买车网
// 创建时间：2015/8/21
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
    /// 数据层实例化接口类 dbo.tb_QuestionCls.
    /// </summary>
    public partial class tb_QuestionClsDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_QuestionClsDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_QuestionClsModel">tb_QuestionCls实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_QuestionClsEntity _tb_QuestionClsModel)
		{
			string sqlStr="insert into tb_QuestionCls([SchoolId],[ParentId],[Name],[Description],[Score],[IsMust],[Status],[Addtime],[Updatetime]) values(@SchoolId,@ParentId,@Name,@Description,@Score,@IsMust,@Status,@Addtime,@Updatetime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@ParentId",SqlDbType.Int),
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Description",SqlDbType.VarChar),
			new SqlParameter("@Score",SqlDbType.Int),
			new SqlParameter("@IsMust",SqlDbType.Int),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_QuestionClsModel.SchoolId;
			_param[1].Value=_tb_QuestionClsModel.ParentId;
			_param[2].Value=_tb_QuestionClsModel.Name;
			_param[3].Value=_tb_QuestionClsModel.Description;
			_param[4].Value=_tb_QuestionClsModel.Score;
			_param[5].Value=_tb_QuestionClsModel.IsMust;
			_param[6].Value=_tb_QuestionClsModel.Status;
			_param[7].Value=_tb_QuestionClsModel.Addtime;
			_param[8].Value=_tb_QuestionClsModel.Updatetime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_QuestionClsModel">tb_QuestionCls实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_QuestionClsEntity _tb_QuestionClsModel)
		{
			string sqlStr="insert into tb_QuestionCls([SchoolId],[ParentId],[Name],[Description],[Score],[IsMust],[Status],[Addtime],[Updatetime]) values(@SchoolId,@ParentId,@Name,@Description,@Score,@IsMust,@Status,@Addtime,@Updatetime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@ParentId",SqlDbType.Int),
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Description",SqlDbType.VarChar),
			new SqlParameter("@Score",SqlDbType.Int),
			new SqlParameter("@IsMust",SqlDbType.Int),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_QuestionClsModel.SchoolId;
			_param[1].Value=_tb_QuestionClsModel.ParentId;
			_param[2].Value=_tb_QuestionClsModel.Name;
			_param[3].Value=_tb_QuestionClsModel.Description;
			_param[4].Value=_tb_QuestionClsModel.Score;
			_param[5].Value=_tb_QuestionClsModel.IsMust;
			_param[6].Value=_tb_QuestionClsModel.Status;
			_param[7].Value=_tb_QuestionClsModel.Addtime;
			_param[8].Value=_tb_QuestionClsModel.Updatetime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_QuestionCls更新一条记录。
		/// </summary>
		/// <param name="_tb_QuestionClsModel">_tb_QuestionClsModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_QuestionClsEntity _tb_QuestionClsModel)
		{
            string sqlStr="update tb_QuestionCls set [SchoolId]=@SchoolId,[ParentId]=@ParentId,[Name]=@Name,[Description]=@Description,[Score]=@Score,[IsMust]=@IsMust,[Status]=@Status,[Addtime]=@Addtime,[Updatetime]=@Updatetime where QuestionClsId=@QuestionClsId";
			SqlParameter[] _param={				
				new SqlParameter("@QuestionClsId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@ParentId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Description",SqlDbType.VarChar),
				new SqlParameter("@Score",SqlDbType.Int),
				new SqlParameter("@IsMust",SqlDbType.Int),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_QuestionClsModel.QuestionClsId;
				_param[1].Value=_tb_QuestionClsModel.SchoolId;
				_param[2].Value=_tb_QuestionClsModel.ParentId;
				_param[3].Value=_tb_QuestionClsModel.Name;
				_param[4].Value=_tb_QuestionClsModel.Description;
				_param[5].Value=_tb_QuestionClsModel.Score;
				_param[6].Value=_tb_QuestionClsModel.IsMust;
				_param[7].Value=_tb_QuestionClsModel.Status;
				_param[8].Value=_tb_QuestionClsModel.Addtime;
				_param[9].Value=_tb_QuestionClsModel.Updatetime;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_QuestionCls更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_QuestionClsModel">_tb_QuestionClsModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_QuestionClsEntity _tb_QuestionClsModel)
		{
            string sqlStr="update tb_QuestionCls set [SchoolId]=@SchoolId,[ParentId]=@ParentId,[Name]=@Name,[Description]=@Description,[Score]=@Score,[IsMust]=@IsMust,[Status]=@Status,[Addtime]=@Addtime,[Updatetime]=@Updatetime where QuestionClsId=@QuestionClsId";
			SqlParameter[] _param={				
				new SqlParameter("@QuestionClsId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@ParentId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Description",SqlDbType.VarChar),
				new SqlParameter("@Score",SqlDbType.Int),
				new SqlParameter("@IsMust",SqlDbType.Int),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_QuestionClsModel.QuestionClsId;
				_param[1].Value=_tb_QuestionClsModel.SchoolId;
				_param[2].Value=_tb_QuestionClsModel.ParentId;
				_param[3].Value=_tb_QuestionClsModel.Name;
				_param[4].Value=_tb_QuestionClsModel.Description;
				_param[5].Value=_tb_QuestionClsModel.Score;
				_param[6].Value=_tb_QuestionClsModel.IsMust;
				_param[7].Value=_tb_QuestionClsModel.Status;
				_param[8].Value=_tb_QuestionClsModel.Addtime;
				_param[9].Value=_tb_QuestionClsModel.Updatetime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_QuestionCls中的一条记录
		/// </summary>
	    /// <param name="QuestionClsId">questionClsId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int QuestionClsId)
		{
			string sqlStr="delete from tb_QuestionCls where [QuestionClsId]=@QuestionClsId";
			SqlParameter[] _param={			
			new SqlParameter("@QuestionClsId",SqlDbType.Int),
			
			};			
			_param[0].Value=QuestionClsId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_QuestionCls中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="QuestionClsId">questionClsId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int QuestionClsId)
		{
			string sqlStr="delete from tb_QuestionCls where [QuestionClsId]=@QuestionClsId";
			SqlParameter[] _param={			
			new SqlParameter("@QuestionClsId",SqlDbType.Int),
			
			};			
			_param[0].Value=QuestionClsId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_questioncls 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_questioncls 数据实体</returns>
		public tb_QuestionClsEntity Populate_tb_QuestionClsEntity_FromDr(DataRow row)
		{
			tb_QuestionClsEntity Obj = new tb_QuestionClsEntity();
			if(row!=null)
			{
				Obj.QuestionClsId = (( row["QuestionClsId"])==DBNull.Value)?0:Convert.ToInt32( row["QuestionClsId"]);
				Obj.SchoolId = (( row["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( row["SchoolId"]);
				Obj.ParentId = (( row["ParentId"])==DBNull.Value)?0:Convert.ToInt32( row["ParentId"]);
				Obj.Name =  row["Name"].ToString();
				Obj.Description =  row["Description"].ToString();
				Obj.Score = (( row["Score"])==DBNull.Value)?0:Convert.ToInt32( row["Score"]);
				Obj.IsMust = (( row["IsMust"])==DBNull.Value)?0:Convert.ToInt32( row["IsMust"]);
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
		/// 得到  tb_questioncls 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_questioncls 数据实体</returns>
		public tb_QuestionClsEntity Populate_tb_QuestionClsEntity_FromDr(IDataReader dr)
		{
			tb_QuestionClsEntity Obj = new tb_QuestionClsEntity();
			
				Obj.QuestionClsId = (( dr["QuestionClsId"])==DBNull.Value)?0:Convert.ToInt32( dr["QuestionClsId"]);
				Obj.SchoolId = (( dr["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( dr["SchoolId"]);
				Obj.ParentId = (( dr["ParentId"])==DBNull.Value)?0:Convert.ToInt32( dr["ParentId"]);
				Obj.Name =  dr["Name"].ToString();
				Obj.Description =  dr["Description"].ToString();
				Obj.Score = (( dr["Score"])==DBNull.Value)?0:Convert.ToInt32( dr["Score"]);
				Obj.IsMust = (( dr["IsMust"])==DBNull.Value)?0:Convert.ToInt32( dr["IsMust"]);
				Obj.Status = (( dr["Status"])==DBNull.Value)?0:Convert.ToInt32( dr["Status"]);
				Obj.Addtime = (( dr["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Addtime"]);
				Obj.Updatetime = (( dr["Updatetime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Updatetime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_QuestionCls对象
		/// </summary>
		/// <param name="questionClsId">questionClsId</param>
		/// <returns>tb_QuestionCls对象</returns>
		public tb_QuestionClsEntity Get_tb_QuestionClsEntity (int questionClsId)
		{
			tb_QuestionClsEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@QuestionClsId",SqlDbType.Int)
			};
			_param[0].Value=questionClsId;
			string sqlStr="select * from tb_QuestionCls with(nolock) where QuestionClsId=@QuestionClsId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_QuestionClsEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_QuestionCls所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_QuestionClsEntity> Get_tb_QuestionClsAll()
		{
			IList< tb_QuestionClsEntity> Obj=new List< tb_QuestionClsEntity>();
			string sqlStr="select * from tb_QuestionCls";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_QuestionClsEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="questionClsId">questionClsId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_QuestionCls(int questionClsId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@questionClsId",SqlDbType.Int)
                                  };
            _param[0].Value=questionClsId;
            string sqlStr="select Count(*) from tb_QuestionCls where QuestionClsId=@questionClsId";
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
