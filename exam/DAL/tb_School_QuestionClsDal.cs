// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_School_QuestionCls.cs
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
    /// 数据层实例化接口类 dbo.tb_School_QuestionCls.
    /// </summary>
    public partial class tb_School_QuestionClsDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_School_QuestionClsDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_School_QuestionClsModel">tb_School_QuestionCls实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_School_QuestionClsEntity _tb_School_QuestionClsModel)
		{
            string sqlStr = "insert into tb_School_QuestionCls([Score],[SchoolId],[QuestionClsId],[Path],[IsMust]) values(@Score,@SchoolId,@QuestionClsId,@Path,@IsMust) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@Score",SqlDbType.Int),
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@QuestionClsId",SqlDbType.Int),
			new SqlParameter("@Path",SqlDbType.VarChar),
			new SqlParameter("@IsMust",SqlDbType.Int)
			};			
			_param[0].Value=_tb_School_QuestionClsModel.Score;
			_param[1].Value=_tb_School_QuestionClsModel.SchoolId;
			_param[2].Value=_tb_School_QuestionClsModel.QuestionClsId;
			_param[3].Value=_tb_School_QuestionClsModel.Path;
			_param[4].Value=_tb_School_QuestionClsModel.IsMust;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_School_QuestionClsModel">tb_School_QuestionCls实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_School_QuestionClsEntity _tb_School_QuestionClsModel)
		{
			string sqlStr="insert into tb_School_QuestionCls([RelationId],[SchoolId],[QuestionClsId],[Path],[IsMust]) values(@RelationId,@SchoolId,@QuestionClsId,@Path,@IsMust) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@RelationId",SqlDbType.Int),
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@QuestionClsId",SqlDbType.Int),
			new SqlParameter("@Path",SqlDbType.VarChar),
			new SqlParameter("@IsMust",SqlDbType.Int)
			};			
			_param[0].Value=_tb_School_QuestionClsModel.RelationId;
			_param[1].Value=_tb_School_QuestionClsModel.SchoolId;
			_param[2].Value=_tb_School_QuestionClsModel.QuestionClsId;
			_param[3].Value=_tb_School_QuestionClsModel.Path;
			_param[4].Value=_tb_School_QuestionClsModel.IsMust;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_School_QuestionCls更新一条记录。
		/// </summary>
		/// <param name="_tb_School_QuestionClsModel">_tb_School_QuestionClsModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_School_QuestionClsEntity _tb_School_QuestionClsModel)
		{
            string sqlStr="update tb_School_QuestionCls set [SchoolId]=@SchoolId,[QuestionClsId]=@QuestionClsId,[Path]=@Path,[Score]=@Score,[IsMust]=@IsMust where RelationId=@RelationId";
			SqlParameter[] _param={				
				new SqlParameter("@RelationId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@QuestionClsId",SqlDbType.Int),
				new SqlParameter("@Path",SqlDbType.VarChar),
				new SqlParameter("@Score",SqlDbType.Int),
				new SqlParameter("@IsMust",SqlDbType.Int)
				};				
				_param[0].Value=_tb_School_QuestionClsModel.RelationId;
				_param[1].Value=_tb_School_QuestionClsModel.SchoolId;
				_param[2].Value=_tb_School_QuestionClsModel.QuestionClsId;
				_param[3].Value=_tb_School_QuestionClsModel.Path;
				_param[4].Value=_tb_School_QuestionClsModel.Score;
				_param[5].Value=_tb_School_QuestionClsModel.IsMust;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_School_QuestionCls更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_School_QuestionClsModel">_tb_School_QuestionClsModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_School_QuestionClsEntity _tb_School_QuestionClsModel)
		{
            string sqlStr="update tb_School_QuestionCls set [SchoolId]=@SchoolId,[QuestionClsId]=@QuestionClsId,[Path]=@Path,[Score]=@Score,[IsMust]=@IsMust where RelationId=@RelationId";
			SqlParameter[] _param={				
				new SqlParameter("@RelationId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@QuestionClsId",SqlDbType.Int),
				new SqlParameter("@Path",SqlDbType.VarChar),
				new SqlParameter("@Score",SqlDbType.Int),
				new SqlParameter("@IsMust",SqlDbType.Int)
				};				
				_param[0].Value=_tb_School_QuestionClsModel.RelationId;
				_param[1].Value=_tb_School_QuestionClsModel.SchoolId;
				_param[2].Value=_tb_School_QuestionClsModel.QuestionClsId;
				_param[3].Value=_tb_School_QuestionClsModel.Path;
				_param[4].Value=_tb_School_QuestionClsModel.Score;
				_param[5].Value=_tb_School_QuestionClsModel.IsMust;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_School_QuestionCls中的一条记录
		/// </summary>
	    /// <param name="RelationId">relationId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int RelationId)
		{
			string sqlStr="delete from tb_School_QuestionCls where [RelationId]=@RelationId";
			SqlParameter[] _param={			
			new SqlParameter("@RelationId",SqlDbType.Int),
			
			};			
			_param[0].Value=RelationId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_School_QuestionCls中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="RelationId">relationId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int RelationId)
		{
			string sqlStr="delete from tb_School_QuestionCls where [RelationId]=@RelationId";
			SqlParameter[] _param={			
			new SqlParameter("@RelationId",SqlDbType.Int),
			
			};			
			_param[0].Value=RelationId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_school_questioncls 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_school_questioncls 数据实体</returns>
		public tb_School_QuestionClsEntity Populate_tb_School_QuestionClsEntity_FromDr(DataRow row)
		{
			tb_School_QuestionClsEntity Obj = new tb_School_QuestionClsEntity();
			if(row!=null)
			{
				Obj.RelationId = (( row["RelationId"])==DBNull.Value)?0:Convert.ToInt32( row["RelationId"]);
				Obj.SchoolId = (( row["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( row["SchoolId"]);
				Obj.QuestionClsId = (( row["QuestionClsId"])==DBNull.Value)?0:Convert.ToInt32( row["QuestionClsId"]);
				Obj.Path =  row["Path"].ToString();
				Obj.Score = (( row["Score"])==DBNull.Value)?0:Convert.ToInt32( row["Score"]);
				Obj.IsMust = (( row["IsMust"])==DBNull.Value)?0:Convert.ToInt32( row["IsMust"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_school_questioncls 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_school_questioncls 数据实体</returns>
		public tb_School_QuestionClsEntity Populate_tb_School_QuestionClsEntity_FromDr(IDataReader dr)
		{
			tb_School_QuestionClsEntity Obj = new tb_School_QuestionClsEntity();
			
				Obj.RelationId = (( dr["RelationId"])==DBNull.Value)?0:Convert.ToInt32( dr["RelationId"]);
				Obj.SchoolId = (( dr["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( dr["SchoolId"]);
				Obj.QuestionClsId = (( dr["QuestionClsId"])==DBNull.Value)?0:Convert.ToInt32( dr["QuestionClsId"]);
				Obj.Path =  dr["Path"].ToString();
				Obj.Score = (( dr["Score"])==DBNull.Value)?0:Convert.ToInt32( dr["Score"]);
				Obj.IsMust = (( dr["IsMust"])==DBNull.Value)?0:Convert.ToInt32( dr["IsMust"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_School_QuestionCls对象
		/// </summary>
		/// <param name="relationId">relationId</param>
		/// <returns>tb_School_QuestionCls对象</returns>
		public tb_School_QuestionClsEntity Get_tb_School_QuestionClsEntity (int relationId)
		{
			tb_School_QuestionClsEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@RelationId",SqlDbType.Int)
			};
			_param[0].Value=relationId;
			string sqlStr="select * from tb_School_QuestionCls with(nolock) where RelationId=@RelationId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_School_QuestionClsEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_School_QuestionCls所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_School_QuestionClsEntity> Get_tb_School_QuestionClsAll()
		{
			IList< tb_School_QuestionClsEntity> Obj=new List< tb_School_QuestionClsEntity>();
			string sqlStr="select * from tb_School_QuestionCls";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_School_QuestionClsEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="relationId">relationId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_School_QuestionCls(int relationId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@relationId",SqlDbType.Int)
                                  };
            _param[0].Value=relationId;
            string sqlStr="select Count(*) from tb_School_QuestionCls where RelationId=@relationId";
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
