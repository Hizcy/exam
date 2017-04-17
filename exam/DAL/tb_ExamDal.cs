// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Exam.cs
// 项目名称：买车网
// 创建时间：2015/8/17
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
    /// 数据层实例化接口类 dbo.tb_Exam.
    /// </summary>
    public partial class tb_ExamDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_ExamDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_ExamModel">tb_Exam实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_ExamEntity _tb_ExamModel)
		{
			string sqlStr="insert into tb_Exam([SchoolId],[ExamClsId],[ExampaperId],[Name],[Pass],[Duration],[Number],[DepartmentId],[Status],[Founder],[Addtime],[Updatetime]) values(@SchoolId,@ExamClsId,@ExampaperId,@Name,@Pass,@Duration,@Number,@DepartmentId,@Status,@Founder,@Addtime,@Updatetime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@ExamClsId",SqlDbType.Int),
			new SqlParameter("@ExampaperId",SqlDbType.Int),
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Pass",SqlDbType.Int),
			new SqlParameter("@Duration",SqlDbType.Int),
			new SqlParameter("@Number",SqlDbType.Int),
			new SqlParameter("@DepartmentId",SqlDbType.Int),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Founder",SqlDbType.VarChar),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_ExamModel.SchoolId;
			_param[1].Value=_tb_ExamModel.ExamClsId;
			_param[2].Value=_tb_ExamModel.ExampaperId;
			_param[3].Value=_tb_ExamModel.Name;
			_param[4].Value=_tb_ExamModel.Pass;
			_param[5].Value=_tb_ExamModel.Duration;
			_param[6].Value=_tb_ExamModel.Number;
			_param[7].Value=_tb_ExamModel.DepartmentId;
			_param[8].Value=_tb_ExamModel.Status;
			_param[9].Value=_tb_ExamModel.Founder;
			_param[10].Value=_tb_ExamModel.Addtime;
			_param[11].Value=_tb_ExamModel.Updatetime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ExamModel">tb_Exam实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_ExamEntity _tb_ExamModel)
		{
			string sqlStr="insert into tb_Exam([SchoolId],[ExamClsId],[ExampaperId],[Name],[Pass],[Duration],[Number],[DepartmentId],[Status],[Founder],[Addtime],[Updatetime]) values(@SchoolId,@ExamClsId,@ExampaperId,@Name,@Pass,@Duration,@Number,@DepartmentId,@Status,@Founder,@Addtime,@Updatetime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@ExamClsId",SqlDbType.Int),
			new SqlParameter("@ExampaperId",SqlDbType.Int),
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Pass",SqlDbType.Int),
			new SqlParameter("@Duration",SqlDbType.Int),
			new SqlParameter("@Number",SqlDbType.Int),
			new SqlParameter("@DepartmentId",SqlDbType.Int),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Founder",SqlDbType.VarChar),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_ExamModel.SchoolId;
			_param[1].Value=_tb_ExamModel.ExamClsId;
			_param[2].Value=_tb_ExamModel.ExampaperId;
			_param[3].Value=_tb_ExamModel.Name;
			_param[4].Value=_tb_ExamModel.Pass;
			_param[5].Value=_tb_ExamModel.Duration;
			_param[6].Value=_tb_ExamModel.Number;
			_param[7].Value=_tb_ExamModel.DepartmentId;
			_param[8].Value=_tb_ExamModel.Status;
			_param[9].Value=_tb_ExamModel.Founder;
			_param[10].Value=_tb_ExamModel.Addtime;
			_param[11].Value=_tb_ExamModel.Updatetime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Exam更新一条记录。
		/// </summary>
		/// <param name="_tb_ExamModel">_tb_ExamModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_ExamEntity _tb_ExamModel)
		{
            string sqlStr="update tb_Exam set [SchoolId]=@SchoolId,[ExamClsId]=@ExamClsId,[ExampaperId]=@ExampaperId,[Name]=@Name,[Pass]=@Pass,[Duration]=@Duration,[Number]=@Number,[DepartmentId]=@DepartmentId,[Status]=@Status,[Founder]=@Founder,[Addtime]=@Addtime,[Updatetime]=@Updatetime where ExamId=@ExamId";
			SqlParameter[] _param={				
				new SqlParameter("@ExamId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@ExamClsId",SqlDbType.Int),
				new SqlParameter("@ExampaperId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Pass",SqlDbType.Int),
				new SqlParameter("@Duration",SqlDbType.Int),
				new SqlParameter("@Number",SqlDbType.Int),
				new SqlParameter("@DepartmentId",SqlDbType.Int),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Founder",SqlDbType.VarChar),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_ExamModel.ExamId;
				_param[1].Value=_tb_ExamModel.SchoolId;
				_param[2].Value=_tb_ExamModel.ExamClsId;
				_param[3].Value=_tb_ExamModel.ExampaperId;
				_param[4].Value=_tb_ExamModel.Name;
				_param[5].Value=_tb_ExamModel.Pass;
				_param[6].Value=_tb_ExamModel.Duration;
				_param[7].Value=_tb_ExamModel.Number;
				_param[8].Value=_tb_ExamModel.DepartmentId;
				_param[9].Value=_tb_ExamModel.Status;
				_param[10].Value=_tb_ExamModel.Founder;
				_param[11].Value=_tb_ExamModel.Addtime;
				_param[12].Value=_tb_ExamModel.Updatetime;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Exam更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ExamModel">_tb_ExamModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_ExamEntity _tb_ExamModel)
		{
            string sqlStr="update tb_Exam set [SchoolId]=@SchoolId,[ExamClsId]=@ExamClsId,[ExampaperId]=@ExampaperId,[Name]=@Name,[Pass]=@Pass,[Duration]=@Duration,[Number]=@Number,[DepartmentId]=@DepartmentId,[Status]=@Status,[Founder]=@Founder,[Addtime]=@Addtime,[Updatetime]=@Updatetime where ExamId=@ExamId";
			SqlParameter[] _param={				
				new SqlParameter("@ExamId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@ExamClsId",SqlDbType.Int),
				new SqlParameter("@ExampaperId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Pass",SqlDbType.Int),
				new SqlParameter("@Duration",SqlDbType.Int),
				new SqlParameter("@Number",SqlDbType.Int),
				new SqlParameter("@DepartmentId",SqlDbType.Int),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Founder",SqlDbType.VarChar),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_ExamModel.ExamId;
				_param[1].Value=_tb_ExamModel.SchoolId;
				_param[2].Value=_tb_ExamModel.ExamClsId;
				_param[3].Value=_tb_ExamModel.ExampaperId;
				_param[4].Value=_tb_ExamModel.Name;
				_param[5].Value=_tb_ExamModel.Pass;
				_param[6].Value=_tb_ExamModel.Duration;
				_param[7].Value=_tb_ExamModel.Number;
				_param[8].Value=_tb_ExamModel.DepartmentId;
				_param[9].Value=_tb_ExamModel.Status;
				_param[10].Value=_tb_ExamModel.Founder;
				_param[11].Value=_tb_ExamModel.Addtime;
				_param[12].Value=_tb_ExamModel.Updatetime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Exam中的一条记录
		/// </summary>
	    /// <param name="ExamId">examId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ExamId)
		{
			string sqlStr="delete from tb_Exam where [ExamId]=@ExamId";
			SqlParameter[] _param={			
			new SqlParameter("@ExamId",SqlDbType.Int),
			
			};			
			_param[0].Value=ExamId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_Exam中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ExamId">examId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ExamId)
		{
			string sqlStr="delete from tb_Exam where [ExamId]=@ExamId";
			SqlParameter[] _param={			
			new SqlParameter("@ExamId",SqlDbType.Int),
			
			};			
			_param[0].Value=ExamId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_exam 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_exam 数据实体</returns>
		public tb_ExamEntity Populate_tb_ExamEntity_FromDr(DataRow row)
		{
			tb_ExamEntity Obj = new tb_ExamEntity();
			if(row!=null)
			{
				Obj.ExamId = (( row["ExamId"])==DBNull.Value)?0:Convert.ToInt32( row["ExamId"]);
				Obj.SchoolId = (( row["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( row["SchoolId"]);
				Obj.ExamClsId = (( row["ExamClsId"])==DBNull.Value)?0:Convert.ToInt32( row["ExamClsId"]);
				Obj.ExampaperId = (( row["ExampaperId"])==DBNull.Value)?0:Convert.ToInt32( row["ExampaperId"]);
				Obj.Name =  row["Name"].ToString();
				Obj.Pass = (( row["Pass"])==DBNull.Value)?0:Convert.ToInt32( row["Pass"]);
				Obj.Duration = (( row["Duration"])==DBNull.Value)?0:Convert.ToInt32( row["Duration"]);
				Obj.Number = (( row["Number"])==DBNull.Value)?0:Convert.ToInt32( row["Number"]);
				Obj.DepartmentId = (( row["DepartmentId"])==DBNull.Value)?0:Convert.ToInt32( row["DepartmentId"]);
				Obj.Status = (( row["Status"])==DBNull.Value)?0:Convert.ToInt32( row["Status"]);
				Obj.Founder =  row["Founder"].ToString();
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
		/// 得到  tb_exam 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_exam 数据实体</returns>
		public tb_ExamEntity Populate_tb_ExamEntity_FromDr(IDataReader dr)
		{
			tb_ExamEntity Obj = new tb_ExamEntity();
			
				Obj.ExamId = (( dr["ExamId"])==DBNull.Value)?0:Convert.ToInt32( dr["ExamId"]);
				Obj.SchoolId = (( dr["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( dr["SchoolId"]);
				Obj.ExamClsId = (( dr["ExamClsId"])==DBNull.Value)?0:Convert.ToInt32( dr["ExamClsId"]);
				Obj.ExampaperId = (( dr["ExampaperId"])==DBNull.Value)?0:Convert.ToInt32( dr["ExampaperId"]);
				Obj.Name =  dr["Name"].ToString();
				Obj.Pass = (( dr["Pass"])==DBNull.Value)?0:Convert.ToInt32( dr["Pass"]);
				Obj.Duration = (( dr["Duration"])==DBNull.Value)?0:Convert.ToInt32( dr["Duration"]);
				Obj.Number = (( dr["Number"])==DBNull.Value)?0:Convert.ToInt32( dr["Number"]);
				Obj.DepartmentId = (( dr["DepartmentId"])==DBNull.Value)?0:Convert.ToInt32( dr["DepartmentId"]);
				Obj.Status = (( dr["Status"])==DBNull.Value)?0:Convert.ToInt32( dr["Status"]);
				Obj.Founder =  dr["Founder"].ToString();
				Obj.Addtime = (( dr["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Addtime"]);
				Obj.Updatetime = (( dr["Updatetime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Updatetime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Exam对象
		/// </summary>
		/// <param name="examId">examId</param>
		/// <returns>tb_Exam对象</returns>
		public tb_ExamEntity Get_tb_ExamEntity (int examId)
		{
			tb_ExamEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ExamId",SqlDbType.Int)
			};
			_param[0].Value=examId;
			string sqlStr="select * from tb_Exam with(nolock) where ExamId=@ExamId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_ExamEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Exam所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_ExamEntity> Get_tb_ExamAll()
		{
			IList< tb_ExamEntity> Obj=new List< tb_ExamEntity>();
			string sqlStr="select * from tb_Exam";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_ExamEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="examId">examId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Exam(int examId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@examId",SqlDbType.Int)
                                  };
            _param[0].Value=examId;
            string sqlStr="select Count(*) from tb_Exam where ExamId=@examId";
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
