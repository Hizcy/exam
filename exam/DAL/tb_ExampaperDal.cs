// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Exampaper.cs
// 项目名称：买车网
// 创建时间：2015/8/20
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
    /// 数据层实例化接口类 dbo.tb_Exampaper.
    /// </summary>
    public partial class tb_ExampaperDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_ExampaperDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_ExampaperModel">tb_Exampaper实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_ExampaperEntity _tb_ExampaperModel)
		{
			string sqlStr="insert into tb_Exampaper([SchoolId],[ExampaperClsId],[Name],[Type],[Num],[Total],[Pass],[Duration],[Status],[Founder],[Addtime],[Updatetime]) values(@SchoolId,@ExampaperClsId,@Name,@Type,@Num,@Total,@Pass,@Duration,@Status,@Founder,@Addtime,@Updatetime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@ExampaperClsId",SqlDbType.Int),
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Type",SqlDbType.Int),
			new SqlParameter("@Num",SqlDbType.Int),
			new SqlParameter("@Total",SqlDbType.Int),
			new SqlParameter("@Pass",SqlDbType.Int),
			new SqlParameter("@Duration",SqlDbType.Int),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Founder",SqlDbType.VarChar),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_ExampaperModel.SchoolId;
			_param[1].Value=_tb_ExampaperModel.ExampaperClsId;
			_param[2].Value=_tb_ExampaperModel.Name;
			_param[3].Value=_tb_ExampaperModel.Type;
			_param[4].Value=_tb_ExampaperModel.Num;
			_param[5].Value=_tb_ExampaperModel.Total;
			_param[6].Value=_tb_ExampaperModel.Pass;
			_param[7].Value=_tb_ExampaperModel.Duration;
			_param[8].Value=_tb_ExampaperModel.Status;
			_param[9].Value=_tb_ExampaperModel.Founder;
			_param[10].Value=_tb_ExampaperModel.Addtime;
			_param[11].Value=_tb_ExampaperModel.Updatetime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ExampaperModel">tb_Exampaper实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_ExampaperEntity _tb_ExampaperModel)
		{
			string sqlStr="insert into tb_Exampaper([SchoolId],[ExampaperClsId],[Name],[Type],[Num],[Total],[Pass],[Duration],[Status],[Founder],[Addtime],[Updatetime]) values(@SchoolId,@ExampaperClsId,@Name,@Type,@Num,@Total,@Pass,@Duration,@Status,@Founder,@Addtime,@Updatetime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@ExampaperClsId",SqlDbType.Int),
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Type",SqlDbType.Int),
			new SqlParameter("@Num",SqlDbType.Int),
			new SqlParameter("@Total",SqlDbType.Int),
			new SqlParameter("@Pass",SqlDbType.Int),
			new SqlParameter("@Duration",SqlDbType.Int),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Founder",SqlDbType.VarChar),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_ExampaperModel.SchoolId;
			_param[1].Value=_tb_ExampaperModel.ExampaperClsId;
			_param[2].Value=_tb_ExampaperModel.Name;
			_param[3].Value=_tb_ExampaperModel.Type;
			_param[4].Value=_tb_ExampaperModel.Num;
			_param[5].Value=_tb_ExampaperModel.Total;
			_param[6].Value=_tb_ExampaperModel.Pass;
			_param[7].Value=_tb_ExampaperModel.Duration;
			_param[8].Value=_tb_ExampaperModel.Status;
			_param[9].Value=_tb_ExampaperModel.Founder;
			_param[10].Value=_tb_ExampaperModel.Addtime;
			_param[11].Value=_tb_ExampaperModel.Updatetime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Exampaper更新一条记录。 
		/// </summary>
		/// <param name="_tb_ExampaperModel">_tb_ExampaperModel</param>
		/// <returns>影响的行数</returns> 
		public int Update(tb_ExampaperEntity _tb_ExampaperModel)
		{
            string sqlStr = "update tb_Exampaper set [SchoolId]=@SchoolId,[ExampaperClsId]=@ExampaperClsId,[Name]=@Name,[Type]=@Type,[Num]=@Num,[Total]=@Total,[Pass]=@Pass,[Duration]=@Duration,[Status]=@Status,[Founder]=@Founder,[Addtime]=@Addtime,[Updatetime]=@Updatetime where ExampaperId=@ExampaperId";
			SqlParameter[] _param={				
				new SqlParameter("@ExampaperId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@ExampaperClsId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Type",SqlDbType.Int),
				new SqlParameter("@Num",SqlDbType.Int),
				new SqlParameter("@Total",SqlDbType.Int),
				new SqlParameter("@Pass",SqlDbType.Int),
				new SqlParameter("@Duration",SqlDbType.Int),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Founder",SqlDbType.VarChar),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_ExampaperModel.ExampaperId;
				_param[1].Value=_tb_ExampaperModel.SchoolId;
				_param[2].Value=_tb_ExampaperModel.ExampaperClsId;
				_param[3].Value=_tb_ExampaperModel.Name;
				_param[4].Value=_tb_ExampaperModel.Type;
				_param[5].Value=_tb_ExampaperModel.Num;
				_param[6].Value=_tb_ExampaperModel.Total;
				_param[7].Value=_tb_ExampaperModel.Pass;
				_param[8].Value=_tb_ExampaperModel.Duration;
				_param[9].Value=_tb_ExampaperModel.Status;
				_param[10].Value=_tb_ExampaperModel.Founder;
				_param[11].Value=_tb_ExampaperModel.Addtime;
				_param[12].Value=_tb_ExampaperModel.Updatetime;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Exampaper更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ExampaperModel">_tb_ExampaperModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_ExampaperEntity _tb_ExampaperModel)
		{
            string sqlStr="update tb_Exampaper set [SchoolId]=@SchoolId,[ExampaperClsId]=@ExampaperClsId,[Name]=@Name,[Type]=@Type,[Num]=@Num,[Total]=@Total,[Pass]=@Pass,[Duration]=@Duration,[Status]=@Status,[Founder]=@Founder,[Addtime]=@Addtime,[Updatetime]=@Updatetime where ExampaperId=@ExampaperId";
			SqlParameter[] _param={				
				new SqlParameter("@ExampaperId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@ExampaperClsId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Type",SqlDbType.Int),
				new SqlParameter("@Num",SqlDbType.Int),
				new SqlParameter("@Total",SqlDbType.Int),
				new SqlParameter("@Pass",SqlDbType.Int),
				new SqlParameter("@Duration",SqlDbType.Int),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Founder",SqlDbType.VarChar),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_ExampaperModel.ExampaperId;
				_param[1].Value=_tb_ExampaperModel.SchoolId;
				_param[2].Value=_tb_ExampaperModel.ExampaperClsId;
				_param[3].Value=_tb_ExampaperModel.Name;
				_param[4].Value=_tb_ExampaperModel.Type;
				_param[5].Value=_tb_ExampaperModel.Num;
				_param[6].Value=_tb_ExampaperModel.Total;
				_param[7].Value=_tb_ExampaperModel.Pass;
				_param[8].Value=_tb_ExampaperModel.Duration;
				_param[9].Value=_tb_ExampaperModel.Status;
				_param[10].Value=_tb_ExampaperModel.Founder;
				_param[11].Value=_tb_ExampaperModel.Addtime;
				_param[12].Value=_tb_ExampaperModel.Updatetime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Exampaper中的一条记录
		/// </summary>
	    /// <param name="ExampaperId">exampaperId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ExampaperId)
		{
			string sqlStr="delete from tb_Exampaper where [ExampaperId]=@ExampaperId";
			SqlParameter[] _param={			
			new SqlParameter("@ExampaperId",SqlDbType.Int),
			
			};			
			_param[0].Value=ExampaperId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_Exampaper中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ExampaperId">exampaperId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ExampaperId)
		{
			string sqlStr="delete from tb_Exampaper where [ExampaperId]=@ExampaperId";
			SqlParameter[] _param={			
			new SqlParameter("@ExampaperId",SqlDbType.Int),
			
			};			
			_param[0].Value=ExampaperId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_exampaper 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_exampaper 数据实体</returns>
		public tb_ExampaperEntity Populate_tb_ExampaperEntity_FromDr(DataRow row)
		{
			tb_ExampaperEntity Obj = new tb_ExampaperEntity();
			if(row!=null)
			{
				Obj.ExampaperId = (( row["ExampaperId"])==DBNull.Value)?0:Convert.ToInt32( row["ExampaperId"]);
				Obj.SchoolId = (( row["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( row["SchoolId"]);
				Obj.ExampaperClsId = (( row["ExampaperClsId"])==DBNull.Value)?0:Convert.ToInt32( row["ExampaperClsId"]);
				Obj.Name =  row["Name"].ToString();
				Obj.Type = (( row["Type"])==DBNull.Value)?0:Convert.ToInt32( row["Type"]);
				Obj.Num = (( row["Num"])==DBNull.Value)?0:Convert.ToInt32( row["Num"]);
				Obj.Total = (( row["Total"])==DBNull.Value)?0:Convert.ToInt32( row["Total"]);
				Obj.Pass = (( row["Pass"])==DBNull.Value)?0:Convert.ToInt32( row["Pass"]);
				Obj.Duration = (( row["Duration"])==DBNull.Value)?0:Convert.ToInt32( row["Duration"]);
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
		/// 得到  tb_exampaper 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_exampaper 数据实体</returns>
		public tb_ExampaperEntity Populate_tb_ExampaperEntity_FromDr(IDataReader dr)
		{
			tb_ExampaperEntity Obj = new tb_ExampaperEntity();
			
				Obj.ExampaperId = (( dr["ExampaperId"])==DBNull.Value)?0:Convert.ToInt32( dr["ExampaperId"]);
				Obj.SchoolId = (( dr["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( dr["SchoolId"]);
				Obj.ExampaperClsId = (( dr["ExampaperClsId"])==DBNull.Value)?0:Convert.ToInt32( dr["ExampaperClsId"]);
				Obj.Name =  dr["Name"].ToString();
				Obj.Type = (( dr["Type"])==DBNull.Value)?0:Convert.ToInt32( dr["Type"]);
				Obj.Num = (( dr["Num"])==DBNull.Value)?0:Convert.ToInt32( dr["Num"]);
				Obj.Total = (( dr["Total"])==DBNull.Value)?0:Convert.ToInt32( dr["Total"]);
				Obj.Pass = (( dr["Pass"])==DBNull.Value)?0:Convert.ToInt32( dr["Pass"]);
				Obj.Duration = (( dr["Duration"])==DBNull.Value)?0:Convert.ToInt32( dr["Duration"]);
				Obj.Status = (( dr["Status"])==DBNull.Value)?0:Convert.ToInt32( dr["Status"]);
				Obj.Founder =  dr["Founder"].ToString();
				Obj.Addtime = (( dr["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Addtime"]);
				Obj.Updatetime = (( dr["Updatetime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Updatetime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Exampaper对象
		/// </summary>
		/// <param name="exampaperId">exampaperId</param>
		/// <returns>tb_Exampaper对象</returns>
		public tb_ExampaperEntity Get_tb_ExampaperEntity (int exampaperId)
		{
			tb_ExampaperEntity _obj=null; 
			SqlParameter[] _param={
			new SqlParameter("@ExampaperId",SqlDbType.Int)
			};
			_param[0].Value=exampaperId;
			string sqlStr="select * from tb_Exampaper with(nolock) where ExampaperId=@ExampaperId ";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_ExampaperEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Exampaper所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_ExampaperEntity> Get_tb_ExampaperAll()
		{
			IList< tb_ExampaperEntity> Obj=new List< tb_ExampaperEntity>();
			string sqlStr="select * from tb_Exampaper";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_ExampaperEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="exampaperId">exampaperId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Exampaper(int exampaperId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@exampaperId",SqlDbType.Int)
                                  };
            _param[0].Value=exampaperId;
            string sqlStr="select Count(*) from tb_Exampaper where ExampaperId=@exampaperId";
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
