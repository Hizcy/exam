// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_ExampaperExt.cs
// 项目名称：买车网
// 创建时间：2015/8/19
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
    /// 数据层实例化接口类 dbo.tb_ExampaperExt.
    /// </summary>
    public partial class tb_ExampaperExtDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_ExampaperExtDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_ExampaperExtModel">tb_ExampaperExt实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_ExampaperExtEntity _tb_ExampaperExtModel)
		{
			string sqlStr="insert into tb_ExampaperExt([ExampaperId],[tb_QuestionClsId],[Type],[Title],[Number],[Diff],[Score],[Addtime]) values(@ExampaperId,@tb_QuestionClsId,@Type,@Title,@Number,@Diff,@Score,@Addtime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@ExampaperId",SqlDbType.Int),
			new SqlParameter("@tb_QuestionClsId",SqlDbType.Int),
			new SqlParameter("@Type",SqlDbType.Int),
			new SqlParameter("@Title",SqlDbType.VarChar),
			new SqlParameter("@Number",SqlDbType.Int),
			new SqlParameter("@Diff",SqlDbType.Int),
			new SqlParameter("@Score",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_ExampaperExtModel.ExampaperId;
			_param[1].Value=_tb_ExampaperExtModel.tb_QuestionClsId;
			_param[2].Value=_tb_ExampaperExtModel.Type;
			_param[3].Value=_tb_ExampaperExtModel.Title;
			_param[4].Value=_tb_ExampaperExtModel.Number;
			_param[5].Value=_tb_ExampaperExtModel.Diff;
			_param[6].Value=_tb_ExampaperExtModel.Score;
			_param[7].Value=_tb_ExampaperExtModel.Addtime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ExampaperExtModel">tb_ExampaperExt实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_ExampaperExtEntity _tb_ExampaperExtModel)
		{
			string sqlStr="insert into tb_ExampaperExt([ExampaperId],[tb_QuestionClsId],[Type],[Title],[Number],[Diff],[Score],[Addtime]) values(@ExampaperId,@tb_QuestionClsId,@Type,@Title,@Number,@Diff,@Score,@Addtime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@ExampaperId",SqlDbType.Int),
			new SqlParameter("@tb_QuestionClsId",SqlDbType.Int),
			new SqlParameter("@Type",SqlDbType.Int),
			new SqlParameter("@Title",SqlDbType.VarChar),
			new SqlParameter("@Number",SqlDbType.Int),
			new SqlParameter("@Diff",SqlDbType.Int),
			new SqlParameter("@Score",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_ExampaperExtModel.ExampaperId;
			_param[1].Value=_tb_ExampaperExtModel.tb_QuestionClsId;
			_param[2].Value=_tb_ExampaperExtModel.Type;
			_param[3].Value=_tb_ExampaperExtModel.Title;
			_param[4].Value=_tb_ExampaperExtModel.Number;
			_param[5].Value=_tb_ExampaperExtModel.Diff;
			_param[6].Value=_tb_ExampaperExtModel.Score;
			_param[7].Value=_tb_ExampaperExtModel.Addtime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_ExampaperExt更新一条记录。
		/// </summary>
		/// <param name="_tb_ExampaperExtModel">_tb_ExampaperExtModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_ExampaperExtEntity _tb_ExampaperExtModel)
		{
            string sqlStr="update tb_ExampaperExt set [ExampaperId]=@ExampaperId,[tb_QuestionClsId]=@tb_QuestionClsId,[Type]=@Type,[Title]=@Title,[Number]=@Number,[Diff]=@Diff,[Score]=@Score,[Addtime]=@Addtime where ExtId=@ExtId";
			SqlParameter[] _param={				
				new SqlParameter("@ExtId",SqlDbType.Int),
				new SqlParameter("@ExampaperId",SqlDbType.Int),
				new SqlParameter("@tb_QuestionClsId",SqlDbType.Int),
				new SqlParameter("@Type",SqlDbType.Int),
				new SqlParameter("@Title",SqlDbType.VarChar),
				new SqlParameter("@Number",SqlDbType.Int),
				new SqlParameter("@Diff",SqlDbType.Int),
				new SqlParameter("@Score",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_ExampaperExtModel.ExtId;
				_param[1].Value=_tb_ExampaperExtModel.ExampaperId;
				_param[2].Value=_tb_ExampaperExtModel.tb_QuestionClsId;
				_param[3].Value=_tb_ExampaperExtModel.Type;
				_param[4].Value=_tb_ExampaperExtModel.Title;
				_param[5].Value=_tb_ExampaperExtModel.Number;
				_param[6].Value=_tb_ExampaperExtModel.Diff;
				_param[7].Value=_tb_ExampaperExtModel.Score;
				_param[8].Value=_tb_ExampaperExtModel.Addtime;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_ExampaperExt更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ExampaperExtModel">_tb_ExampaperExtModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_ExampaperExtEntity _tb_ExampaperExtModel)
		{
            string sqlStr="update tb_ExampaperExt set [ExampaperId]=@ExampaperId,[tb_QuestionClsId]=@tb_QuestionClsId,[Type]=@Type,[Title]=@Title,[Number]=@Number,[Diff]=@Diff,[Score]=@Score,[Addtime]=@Addtime where ExtId=@ExtId";
			SqlParameter[] _param={				
				new SqlParameter("@ExtId",SqlDbType.Int),
				new SqlParameter("@ExampaperId",SqlDbType.Int),
				new SqlParameter("@tb_QuestionClsId",SqlDbType.Int),
				new SqlParameter("@Type",SqlDbType.Int),
				new SqlParameter("@Title",SqlDbType.VarChar),
				new SqlParameter("@Number",SqlDbType.Int),
				new SqlParameter("@Diff",SqlDbType.Int),
				new SqlParameter("@Score",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_ExampaperExtModel.ExtId;
				_param[1].Value=_tb_ExampaperExtModel.ExampaperId;
				_param[2].Value=_tb_ExampaperExtModel.tb_QuestionClsId;
				_param[3].Value=_tb_ExampaperExtModel.Type;
				_param[4].Value=_tb_ExampaperExtModel.Title;
				_param[5].Value=_tb_ExampaperExtModel.Number;
				_param[6].Value=_tb_ExampaperExtModel.Diff;
				_param[7].Value=_tb_ExampaperExtModel.Score;
				_param[8].Value=_tb_ExampaperExtModel.Addtime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_ExampaperExt中的一条记录
		/// </summary>
	    /// <param name="ExtId">extId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ExtId)
		{
			string sqlStr="delete from tb_ExampaperExt where [ExtId]=@ExtId";
			SqlParameter[] _param={			
			new SqlParameter("@ExtId",SqlDbType.Int),
			
			};			
			_param[0].Value=ExtId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_ExampaperExt中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ExtId">extId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ExtId)
		{
			string sqlStr="delete from tb_ExampaperExt where [ExtId]=@ExtId";
			SqlParameter[] _param={			
			new SqlParameter("@ExtId",SqlDbType.Int),
			
			};			
			_param[0].Value=ExtId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_exampaperext 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_exampaperext 数据实体</returns>
		public tb_ExampaperExtEntity Populate_tb_ExampaperExtEntity_FromDr(DataRow row)
		{
			tb_ExampaperExtEntity Obj = new tb_ExampaperExtEntity();
			if(row!=null)
			{
				Obj.ExtId = (( row["ExtId"])==DBNull.Value)?0:Convert.ToInt32( row["ExtId"]);
				Obj.ExampaperId = (( row["ExampaperId"])==DBNull.Value)?0:Convert.ToInt32( row["ExampaperId"]);
				Obj.tb_QuestionClsId = (( row["tb_QuestionClsId"])==DBNull.Value)?0:Convert.ToInt32( row["tb_QuestionClsId"]);
				Obj.Type = (( row["Type"])==DBNull.Value)?0:Convert.ToInt32( row["Type"]);
				Obj.Title =  row["Title"].ToString();
				Obj.Number = (( row["Number"])==DBNull.Value)?0:Convert.ToInt32( row["Number"]);
				Obj.Diff = (( row["Diff"])==DBNull.Value)?0:Convert.ToInt32( row["Diff"]);
				Obj.Score = (( row["Score"])==DBNull.Value)?0:Convert.ToInt32( row["Score"]);
				Obj.Addtime = (( row["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["Addtime"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_exampaperext 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_exampaperext 数据实体</returns>
		public tb_ExampaperExtEntity Populate_tb_ExampaperExtEntity_FromDr(IDataReader dr)
		{
			tb_ExampaperExtEntity Obj = new tb_ExampaperExtEntity();
			
				Obj.ExtId = (( dr["ExtId"])==DBNull.Value)?0:Convert.ToInt32( dr["ExtId"]);
				Obj.ExampaperId = (( dr["ExampaperId"])==DBNull.Value)?0:Convert.ToInt32( dr["ExampaperId"]);
				Obj.tb_QuestionClsId = (( dr["tb_QuestionClsId"])==DBNull.Value)?0:Convert.ToInt32( dr["tb_QuestionClsId"]);
				Obj.Type = (( dr["Type"])==DBNull.Value)?0:Convert.ToInt32( dr["Type"]);
				Obj.Title =  dr["Title"].ToString();
				Obj.Number = (( dr["Number"])==DBNull.Value)?0:Convert.ToInt32( dr["Number"]);
				Obj.Diff = (( dr["Diff"])==DBNull.Value)?0:Convert.ToInt32( dr["Diff"]);
				Obj.Score = (( dr["Score"])==DBNull.Value)?0:Convert.ToInt32( dr["Score"]);
				Obj.Addtime = (( dr["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Addtime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_ExampaperExt对象
		/// </summary>
		/// <param name="extId">extId</param>
		/// <returns>tb_ExampaperExt对象</returns>
		public tb_ExampaperExtEntity Get_tb_ExampaperExtEntity (int extId)
		{
			tb_ExampaperExtEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ExtId",SqlDbType.Int)
			};
			_param[0].Value=extId;
			string sqlStr="select * from tb_ExampaperExt with(nolock) where ExtId=@ExtId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_ExampaperExtEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_ExampaperExt所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_ExampaperExtEntity> Get_tb_ExampaperExtAll()
		{
			IList< tb_ExampaperExtEntity> Obj=new List< tb_ExampaperExtEntity>();
			string sqlStr="select * from tb_ExampaperExt";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_ExampaperExtEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="extId">extId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_ExampaperExt(int extId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@extId",SqlDbType.Int)
                                  };
            _param[0].Value=extId;
            string sqlStr="select Count(*) from tb_ExampaperExt where ExtId=@extId";
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
