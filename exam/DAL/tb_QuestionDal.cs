// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Question.cs
// 项目名称：买车网
// 创建时间：2015/8/14
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
    /// 数据层实例化接口类 dbo.tb_Question.
    /// </summary>
    public partial class tb_QuestionDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_QuestionDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_QuestionModel">tb_Question实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_QuestionEntity _tb_QuestionModel)
		{
			string sqlStr="insert into tb_Question([SchoolId],[QuestionClsId],[Type],[Title],[A],[B],[C],[D],[E],[F],[G],[H],[Answer],[Interpretation],[Isdifficulty],[Status],[Addtime],[Updatetime]) values(@SchoolId,@QuestionClsId,@Type,@Title,@A,@B,@C,@D,@E,@F,@G,@H,@Answer,@Interpretation,@Isdifficulty,@Status,@Addtime,@Updatetime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@QuestionClsId",SqlDbType.Int),
			new SqlParameter("@Type",SqlDbType.Int),
			new SqlParameter("@Title",SqlDbType.VarChar),
			new SqlParameter("@A",SqlDbType.VarChar),
			new SqlParameter("@B",SqlDbType.VarChar),
			new SqlParameter("@C",SqlDbType.VarChar),
			new SqlParameter("@D",SqlDbType.VarChar),
			new SqlParameter("@E",SqlDbType.VarChar),
			new SqlParameter("@F",SqlDbType.VarChar),
			new SqlParameter("@G",SqlDbType.VarChar),
			new SqlParameter("@H",SqlDbType.VarChar),
			new SqlParameter("@Answer",SqlDbType.VarChar),
			new SqlParameter("@Interpretation",SqlDbType.VarChar),
			new SqlParameter("@Isdifficulty",SqlDbType.Int),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_QuestionModel.SchoolId;
			_param[1].Value=_tb_QuestionModel.QuestionClsId;
			_param[2].Value=_tb_QuestionModel.Type;
			_param[3].Value=_tb_QuestionModel.Title;
			_param[4].Value=_tb_QuestionModel.A;
			_param[5].Value=_tb_QuestionModel.B;
			_param[6].Value=_tb_QuestionModel.C;
			_param[7].Value=_tb_QuestionModel.D;
			_param[8].Value=_tb_QuestionModel.E;
			_param[9].Value=_tb_QuestionModel.F;
			_param[10].Value=_tb_QuestionModel.G;
			_param[11].Value=_tb_QuestionModel.H;
			_param[12].Value=_tb_QuestionModel.Answer;
			_param[13].Value=_tb_QuestionModel.Interpretation;
			_param[14].Value=_tb_QuestionModel.Isdifficulty;
			_param[15].Value=_tb_QuestionModel.Status;
			_param[16].Value=_tb_QuestionModel.Addtime;
			_param[17].Value=_tb_QuestionModel.Updatetime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_QuestionModel">tb_Question实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_QuestionEntity _tb_QuestionModel)
		{
			string sqlStr="insert into tb_Question([SchoolId],[QuestionClsId],[Type],[Title],[A],[B],[C],[D],[E],[F],[G],[H],[Answer],[Interpretation],[Isdifficulty],[Status],[Addtime],[Updatetime]) values(@SchoolId,@QuestionClsId,@Type,@Title,@A,@B,@C,@D,@E,@F,@G,@H,@Answer,@Interpretation,@Isdifficulty,@Status,@Addtime,@Updatetime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@QuestionClsId",SqlDbType.Int),
			new SqlParameter("@Type",SqlDbType.Int),
			new SqlParameter("@Title",SqlDbType.VarChar),
			new SqlParameter("@A",SqlDbType.VarChar),
			new SqlParameter("@B",SqlDbType.VarChar),
			new SqlParameter("@C",SqlDbType.VarChar),
			new SqlParameter("@D",SqlDbType.VarChar),
			new SqlParameter("@E",SqlDbType.VarChar),
			new SqlParameter("@F",SqlDbType.VarChar),
			new SqlParameter("@G",SqlDbType.VarChar),
			new SqlParameter("@H",SqlDbType.VarChar),
			new SqlParameter("@Answer",SqlDbType.VarChar),
			new SqlParameter("@Interpretation",SqlDbType.VarChar),
			new SqlParameter("@Isdifficulty",SqlDbType.Int),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_QuestionModel.SchoolId;
			_param[1].Value=_tb_QuestionModel.QuestionClsId;
			_param[2].Value=_tb_QuestionModel.Type;
			_param[3].Value=_tb_QuestionModel.Title;
			_param[4].Value=_tb_QuestionModel.A;
			_param[5].Value=_tb_QuestionModel.B;
			_param[6].Value=_tb_QuestionModel.C;
			_param[7].Value=_tb_QuestionModel.D;
			_param[8].Value=_tb_QuestionModel.E;
			_param[9].Value=_tb_QuestionModel.F;
			_param[10].Value=_tb_QuestionModel.G;
			_param[11].Value=_tb_QuestionModel.H;
			_param[12].Value=_tb_QuestionModel.Answer;
			_param[13].Value=_tb_QuestionModel.Interpretation;
			_param[14].Value=_tb_QuestionModel.Isdifficulty;
			_param[15].Value=_tb_QuestionModel.Status;
			_param[16].Value=_tb_QuestionModel.Addtime;
			_param[17].Value=_tb_QuestionModel.Updatetime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Question更新一条记录。
		/// </summary>
		/// <param name="_tb_QuestionModel">_tb_QuestionModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_QuestionEntity _tb_QuestionModel)
		{
            string sqlStr="update tb_Question set [SchoolId]=@SchoolId,[QuestionClsId]=@QuestionClsId,[Type]=@Type,[Title]=@Title,[A]=@A,[B]=@B,[C]=@C,[D]=@D,[E]=@E,[F]=@F,[G]=@G,[H]=@H,[Answer]=@Answer,[Interpretation]=@Interpretation,[Isdifficulty]=@Isdifficulty,[Status]=@Status,[Addtime]=@Addtime,[Updatetime]=@Updatetime where QuestionId=@QuestionId";
			SqlParameter[] _param={				
				new SqlParameter("@QuestionId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@QuestionClsId",SqlDbType.Int),
				new SqlParameter("@Type",SqlDbType.Int),
				new SqlParameter("@Title",SqlDbType.VarChar),
				new SqlParameter("@A",SqlDbType.VarChar),
				new SqlParameter("@B",SqlDbType.VarChar),
				new SqlParameter("@C",SqlDbType.VarChar),
				new SqlParameter("@D",SqlDbType.VarChar),
				new SqlParameter("@E",SqlDbType.VarChar),
				new SqlParameter("@F",SqlDbType.VarChar),
				new SqlParameter("@G",SqlDbType.VarChar),
				new SqlParameter("@H",SqlDbType.VarChar),
				new SqlParameter("@Answer",SqlDbType.VarChar),
				new SqlParameter("@Interpretation",SqlDbType.VarChar),
				new SqlParameter("@Isdifficulty",SqlDbType.Int),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_QuestionModel.QuestionId;
				_param[1].Value=_tb_QuestionModel.SchoolId;
				_param[2].Value=_tb_QuestionModel.QuestionClsId;
				_param[3].Value=_tb_QuestionModel.Type;
				_param[4].Value=_tb_QuestionModel.Title;
				_param[5].Value=_tb_QuestionModel.A;
				_param[6].Value=_tb_QuestionModel.B;
				_param[7].Value=_tb_QuestionModel.C;
				_param[8].Value=_tb_QuestionModel.D;
				_param[9].Value=_tb_QuestionModel.E;
				_param[10].Value=_tb_QuestionModel.F;
				_param[11].Value=_tb_QuestionModel.G;
				_param[12].Value=_tb_QuestionModel.H;
				_param[13].Value=_tb_QuestionModel.Answer;
				_param[14].Value=_tb_QuestionModel.Interpretation;
				_param[15].Value=_tb_QuestionModel.Isdifficulty;
				_param[16].Value=_tb_QuestionModel.Status;
				_param[17].Value=_tb_QuestionModel.Addtime;
				_param[18].Value=_tb_QuestionModel.Updatetime;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Question更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_QuestionModel">_tb_QuestionModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_QuestionEntity _tb_QuestionModel)
		{
            string sqlStr="update tb_Question set [SchoolId]=@SchoolId,[QuestionClsId]=@QuestionClsId,[Type]=@Type,[Title]=@Title,[A]=@A,[B]=@B,[C]=@C,[D]=@D,[E]=@E,[F]=@F,[G]=@G,[H]=@H,[Answer]=@Answer,[Interpretation]=@Interpretation,[Isdifficulty]=@Isdifficulty,[Status]=@Status,[Addtime]=@Addtime,[Updatetime]=@Updatetime where QuestionId=@QuestionId";
			SqlParameter[] _param={				
				new SqlParameter("@QuestionId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@QuestionClsId",SqlDbType.Int),
				new SqlParameter("@Type",SqlDbType.Int),
				new SqlParameter("@Title",SqlDbType.VarChar),
				new SqlParameter("@A",SqlDbType.VarChar),
				new SqlParameter("@B",SqlDbType.VarChar),
				new SqlParameter("@C",SqlDbType.VarChar),
				new SqlParameter("@D",SqlDbType.VarChar),
				new SqlParameter("@E",SqlDbType.VarChar),
				new SqlParameter("@F",SqlDbType.VarChar),
				new SqlParameter("@G",SqlDbType.VarChar),
				new SqlParameter("@H",SqlDbType.VarChar),
				new SqlParameter("@Answer",SqlDbType.VarChar),
				new SqlParameter("@Interpretation",SqlDbType.VarChar),
				new SqlParameter("@Isdifficulty",SqlDbType.Int),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_QuestionModel.QuestionId;
				_param[1].Value=_tb_QuestionModel.SchoolId;
				_param[2].Value=_tb_QuestionModel.QuestionClsId;
				_param[3].Value=_tb_QuestionModel.Type;
				_param[4].Value=_tb_QuestionModel.Title;
				_param[5].Value=_tb_QuestionModel.A;
				_param[6].Value=_tb_QuestionModel.B;
				_param[7].Value=_tb_QuestionModel.C;
				_param[8].Value=_tb_QuestionModel.D;
				_param[9].Value=_tb_QuestionModel.E;
				_param[10].Value=_tb_QuestionModel.F;
				_param[11].Value=_tb_QuestionModel.G;
				_param[12].Value=_tb_QuestionModel.H;
				_param[13].Value=_tb_QuestionModel.Answer;
				_param[14].Value=_tb_QuestionModel.Interpretation;
				_param[15].Value=_tb_QuestionModel.Isdifficulty;
				_param[16].Value=_tb_QuestionModel.Status;
				_param[17].Value=_tb_QuestionModel.Addtime;
				_param[18].Value=_tb_QuestionModel.Updatetime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Question中的一条记录
		/// </summary>
	    /// <param name="QuestionId">questionId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int QuestionId)
		{
			string sqlStr="delete from tb_Question where [QuestionId]=@QuestionId";
			SqlParameter[] _param={			
			new SqlParameter("@QuestionId",SqlDbType.Int),
			
			};			
			_param[0].Value=QuestionId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_Question中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="QuestionId">questionId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int QuestionId)
		{
			string sqlStr="delete from tb_Question where [QuestionId]=@QuestionId";
			SqlParameter[] _param={			
			new SqlParameter("@QuestionId",SqlDbType.Int),
			
			};			
			_param[0].Value=QuestionId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_question 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_question 数据实体</returns>
		public tb_QuestionEntity Populate_tb_QuestionEntity_FromDr(DataRow row)
		{
			tb_QuestionEntity Obj = new tb_QuestionEntity();
			if(row!=null)
			{
				Obj.QuestionId = (( row["QuestionId"])==DBNull.Value)?0:Convert.ToInt32( row["QuestionId"]);
				Obj.SchoolId = (( row["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( row["SchoolId"]);
				Obj.QuestionClsId = (( row["QuestionClsId"])==DBNull.Value)?0:Convert.ToInt32( row["QuestionClsId"]);
				Obj.Type = (( row["Type"])==DBNull.Value)?0:Convert.ToInt32( row["Type"]);
				Obj.Title =  row["Title"].ToString();
				Obj.A =  row["A"].ToString();
				Obj.B =  row["B"].ToString();
				Obj.C =  row["C"].ToString();
				Obj.D =  row["D"].ToString();
				Obj.E =  row["E"].ToString();
				Obj.F =  row["F"].ToString();
				Obj.G =  row["G"].ToString();
				Obj.H =  row["H"].ToString();
				Obj.Answer =  row["Answer"].ToString();
				Obj.Interpretation =  row["Interpretation"].ToString();
				Obj.Isdifficulty = (( row["Isdifficulty"])==DBNull.Value)?0:Convert.ToInt32( row["Isdifficulty"]);
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
		/// 得到  tb_question 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_question 数据实体</returns>
		public tb_QuestionEntity Populate_tb_QuestionEntity_FromDr(IDataReader dr)
		{
			tb_QuestionEntity Obj = new tb_QuestionEntity();
			
				Obj.QuestionId = (( dr["QuestionId"])==DBNull.Value)?0:Convert.ToInt32( dr["QuestionId"]);
				Obj.SchoolId = (( dr["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( dr["SchoolId"]);
				Obj.QuestionClsId = (( dr["QuestionClsId"])==DBNull.Value)?0:Convert.ToInt32( dr["QuestionClsId"]);
				Obj.Type = (( dr["Type"])==DBNull.Value)?0:Convert.ToInt32( dr["Type"]);
				Obj.Title =  dr["Title"].ToString();
				Obj.A =  dr["A"].ToString();
				Obj.B =  dr["B"].ToString();
				Obj.C =  dr["C"].ToString();
				Obj.D =  dr["D"].ToString();
				Obj.E =  dr["E"].ToString();
				Obj.F =  dr["F"].ToString();
				Obj.G =  dr["G"].ToString();
				Obj.H =  dr["H"].ToString();
				Obj.Answer =  dr["Answer"].ToString();
				Obj.Interpretation =  dr["Interpretation"].ToString();
				Obj.Isdifficulty = (( dr["Isdifficulty"])==DBNull.Value)?0:Convert.ToInt32( dr["Isdifficulty"]);
				Obj.Status = (( dr["Status"])==DBNull.Value)?0:Convert.ToInt32( dr["Status"]);
				Obj.Addtime = (( dr["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Addtime"]);
				Obj.Updatetime = (( dr["Updatetime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Updatetime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Question对象
		/// </summary>
		/// <param name="questionId">questionId</param>
		/// <returns>tb_Question对象</returns>
		public tb_QuestionEntity Get_tb_QuestionEntity (int questionId)
		{
			tb_QuestionEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@QuestionId",SqlDbType.Int)
			};
			_param[0].Value=questionId;
			string sqlStr="select * from tb_Question with(nolock) where QuestionId=@QuestionId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_QuestionEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Question所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_QuestionEntity> Get_tb_QuestionAll()
		{
			IList< tb_QuestionEntity> Obj=new List< tb_QuestionEntity>();
			string sqlStr="select * from tb_Question";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_QuestionEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="questionId">questionId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Question(int questionId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@questionId",SqlDbType.Int)
                                  };
            _param[0].Value=questionId;
            string sqlStr="select Count(*) from tb_Question where QuestionId=@questionId";
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
