// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_ResultExt.cs
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
    /// 数据层实例化接口类 dbo.tb_ResultExt.
    /// </summary>
    public partial class tb_ResultExtDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_ResultExtDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_ResultExtModel">tb_ResultExt实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_ResultExtEntity _tb_ResultExtModel)
		{
			string sqlStr="insert into tb_ResultExt([ResultId],[QuestionId],[Answer],[IsRight]) values(@ResultId,@QuestionId,@Answer,@IsRight) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@ResultId",SqlDbType.Int),
			new SqlParameter("@QuestionId",SqlDbType.Int),
			new SqlParameter("@Answer",SqlDbType.VarChar),
			new SqlParameter("@IsRight",SqlDbType.Int)
			};			
			_param[0].Value=_tb_ResultExtModel.ResultId;
			_param[1].Value=_tb_ResultExtModel.QuestionId;
			_param[2].Value=_tb_ResultExtModel.Answer;
			_param[3].Value=_tb_ResultExtModel.IsRight;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ResultExtModel">tb_ResultExt实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_ResultExtEntity _tb_ResultExtModel)
		{
			string sqlStr="insert into tb_ResultExt([ResultId],[QuestionId],[Answer],[IsRight]) values(@ResultId,@QuestionId,@Answer,@IsRight) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@ResultId",SqlDbType.Int),
			new SqlParameter("@QuestionId",SqlDbType.Int),
			new SqlParameter("@Answer",SqlDbType.VarChar),
			new SqlParameter("@IsRight",SqlDbType.Int)
			};			
			_param[0].Value=_tb_ResultExtModel.ResultId;
			_param[1].Value=_tb_ResultExtModel.QuestionId;
			_param[2].Value=_tb_ResultExtModel.Answer;
			_param[3].Value=_tb_ResultExtModel.IsRight;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_ResultExt更新一条记录。
		/// </summary>
		/// <param name="_tb_ResultExtModel">_tb_ResultExtModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_ResultExtEntity _tb_ResultExtModel)
		{
            string sqlStr="update tb_ResultExt set [ResultId]=@ResultId,[QuestionId]=@QuestionId,[Answer]=@Answer,[IsRight]=@IsRight where ExtId=@ExtId";
			SqlParameter[] _param={				
				new SqlParameter("@ExtId",SqlDbType.Int),
				new SqlParameter("@ResultId",SqlDbType.Int),
				new SqlParameter("@QuestionId",SqlDbType.Int),
				new SqlParameter("@Answer",SqlDbType.VarChar),
				new SqlParameter("@IsRight",SqlDbType.Int)
				};				
				_param[0].Value=_tb_ResultExtModel.ExtId;
				_param[1].Value=_tb_ResultExtModel.ResultId;
				_param[2].Value=_tb_ResultExtModel.QuestionId;
				_param[3].Value=_tb_ResultExtModel.Answer;
				_param[4].Value=_tb_ResultExtModel.IsRight;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_ResultExt更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ResultExtModel">_tb_ResultExtModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_ResultExtEntity _tb_ResultExtModel)
		{
            string sqlStr="update tb_ResultExt set [ResultId]=@ResultId,[QuestionId]=@QuestionId,[Answer]=@Answer,[IsRight]=@IsRight where ExtId=@ExtId";
			SqlParameter[] _param={				
				new SqlParameter("@ExtId",SqlDbType.Int),
				new SqlParameter("@ResultId",SqlDbType.Int),
				new SqlParameter("@QuestionId",SqlDbType.Int),
				new SqlParameter("@Answer",SqlDbType.VarChar),
				new SqlParameter("@IsRight",SqlDbType.Int)
				};				
				_param[0].Value=_tb_ResultExtModel.ExtId;
				_param[1].Value=_tb_ResultExtModel.ResultId;
				_param[2].Value=_tb_ResultExtModel.QuestionId;
				_param[3].Value=_tb_ResultExtModel.Answer;
				_param[4].Value=_tb_ResultExtModel.IsRight;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_ResultExt中的一条记录
		/// </summary>
	    /// <param name="ExtId">extId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ExtId)
		{
			string sqlStr="delete from tb_ResultExt where [ExtId]=@ExtId";
			SqlParameter[] _param={			
			new SqlParameter("@ExtId",SqlDbType.Int),
			
			};			
			_param[0].Value=ExtId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_ResultExt中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ExtId">extId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ExtId)
		{
			string sqlStr="delete from tb_ResultExt where [ExtId]=@ExtId";
			SqlParameter[] _param={			
			new SqlParameter("@ExtId",SqlDbType.Int),
			
			};			
			_param[0].Value=ExtId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_resultext 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_resultext 数据实体</returns>
		public tb_ResultExtEntity Populate_tb_ResultExtEntity_FromDr(DataRow row)
		{
			tb_ResultExtEntity Obj = new tb_ResultExtEntity();
			if(row!=null)
			{
				Obj.ExtId = (( row["ExtId"])==DBNull.Value)?0:Convert.ToInt32( row["ExtId"]);
				Obj.ResultId = (( row["ResultId"])==DBNull.Value)?0:Convert.ToInt32( row["ResultId"]);
				Obj.QuestionId = (( row["QuestionId"])==DBNull.Value)?0:Convert.ToInt32( row["QuestionId"]);
				Obj.Answer =  row["Answer"].ToString();
				Obj.IsRight = (( row["IsRight"])==DBNull.Value)?0:Convert.ToInt32( row["IsRight"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_resultext 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_resultext 数据实体</returns>
		public tb_ResultExtEntity Populate_tb_ResultExtEntity_FromDr(IDataReader dr)
		{
			tb_ResultExtEntity Obj = new tb_ResultExtEntity();
			
				Obj.ExtId = (( dr["ExtId"])==DBNull.Value)?0:Convert.ToInt32( dr["ExtId"]);
				Obj.ResultId = (( dr["ResultId"])==DBNull.Value)?0:Convert.ToInt32( dr["ResultId"]);
				Obj.QuestionId = (( dr["QuestionId"])==DBNull.Value)?0:Convert.ToInt32( dr["QuestionId"]);
				Obj.Answer =  dr["Answer"].ToString();
				Obj.IsRight = (( dr["IsRight"])==DBNull.Value)?0:Convert.ToInt32( dr["IsRight"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_ResultExt对象
		/// </summary>
		/// <param name="extId">extId</param>
		/// <returns>tb_ResultExt对象</returns>
		public tb_ResultExtEntity Get_tb_ResultExtEntity (int extId)
		{
			tb_ResultExtEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ExtId",SqlDbType.Int)
			};
			_param[0].Value=extId;
			string sqlStr="select * from tb_ResultExt with(nolock) where ExtId=@ExtId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_ResultExtEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_ResultExt所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_ResultExtEntity> Get_tb_ResultExtAll()
		{
			IList< tb_ResultExtEntity> Obj=new List< tb_ResultExtEntity>();
			string sqlStr="select * from tb_ResultExt";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_ResultExtEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="extId">extId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_ResultExt(int extId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@extId",SqlDbType.Int)
                                  };
            _param[0].Value=extId;
            string sqlStr="select Count(*) from tb_ResultExt where ExtId=@extId";
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
