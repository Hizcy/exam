// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_School.cs
// 项目名称：买车网
// 创建时间：2015/9/7
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
    /// 数据层实例化接口类 dbo.tb_School.
    /// </summary>
    public partial class tb_SchoolDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_SchoolDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_SchoolModel">tb_School实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_SchoolEntity _tb_SchoolModel)
		{
			string sqlStr="insert into tb_School([Name],[Domain],[LocationId],[Agent],[Linkman],[Mail],[Phone],[Tel],[Status],[Addtime],[Updatetime],[Begintime],[Endtime]) values(@Name,@Domain,@LocationId,@Agent,@Linkman,@Mail,@Phone,@Tel,@Status,@Addtime,@Updatetime,@Begintime,@Endtime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Domain",SqlDbType.VarChar),
			new SqlParameter("@LocationId",SqlDbType.Int),
			new SqlParameter("@Agent",SqlDbType.Int),
			new SqlParameter("@Linkman",SqlDbType.VarChar),
			new SqlParameter("@Mail",SqlDbType.VarChar),
			new SqlParameter("@Phone",SqlDbType.VarChar),
			new SqlParameter("@Tel",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime),
			new SqlParameter("@Begintime",SqlDbType.DateTime),
			new SqlParameter("@Endtime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_SchoolModel.Name;
			_param[1].Value=_tb_SchoolModel.Domain;
			_param[2].Value=_tb_SchoolModel.LocationId;
			_param[3].Value=_tb_SchoolModel.Agent;
			_param[4].Value=_tb_SchoolModel.Linkman;
			_param[5].Value=_tb_SchoolModel.Mail;
			_param[6].Value=_tb_SchoolModel.Phone;
			_param[7].Value=_tb_SchoolModel.Tel;
			_param[8].Value=_tb_SchoolModel.Status;
			_param[9].Value=_tb_SchoolModel.Addtime;
			_param[10].Value=_tb_SchoolModel.Updatetime;
			_param[11].Value=_tb_SchoolModel.Begintime;
			_param[12].Value=_tb_SchoolModel.Endtime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_SchoolModel">tb_School实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_SchoolEntity _tb_SchoolModel)
		{
			string sqlStr="insert into tb_School([Name],[Domain],[LocationId],[Agent],[Linkman],[Mail],[Phone],[Tel],[Status],[Addtime],[Updatetime],[Begintime],[Endtime]) values(@Name,@Domain,@LocationId,@Agent,@Linkman,@Mail,@Phone,@Tel,@Status,@Addtime,@Updatetime,@Begintime,@Endtime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Domain",SqlDbType.VarChar),
			new SqlParameter("@LocationId",SqlDbType.Int),
			new SqlParameter("@Agent",SqlDbType.Int),
			new SqlParameter("@Linkman",SqlDbType.VarChar),
			new SqlParameter("@Mail",SqlDbType.VarChar),
			new SqlParameter("@Phone",SqlDbType.VarChar),
			new SqlParameter("@Tel",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime),
			new SqlParameter("@Begintime",SqlDbType.DateTime),
			new SqlParameter("@Endtime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_SchoolModel.Name;
			_param[1].Value=_tb_SchoolModel.Domain;
			_param[2].Value=_tb_SchoolModel.LocationId;
			_param[3].Value=_tb_SchoolModel.Agent;
			_param[4].Value=_tb_SchoolModel.Linkman;
			_param[5].Value=_tb_SchoolModel.Mail;
			_param[6].Value=_tb_SchoolModel.Phone;
			_param[7].Value=_tb_SchoolModel.Tel;
			_param[8].Value=_tb_SchoolModel.Status;
			_param[9].Value=_tb_SchoolModel.Addtime;
			_param[10].Value=_tb_SchoolModel.Updatetime;
			_param[11].Value=_tb_SchoolModel.Begintime;
			_param[12].Value=_tb_SchoolModel.Endtime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_School更新一条记录。
		/// </summary>
		/// <param name="_tb_SchoolModel">_tb_SchoolModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_SchoolEntity _tb_SchoolModel)
		{
            string sqlStr="update tb_School set [Name]=@Name,[Domain]=@Domain,[LocationId]=@LocationId,[Agent]=@Agent,[Linkman]=@Linkman,[Mail]=@Mail,[Phone]=@Phone,[Tel]=@Tel,[Status]=@Status,[Addtime]=@Addtime,[Updatetime]=@Updatetime,[Begintime]=@Begintime,[Endtime]=@Endtime where SchoolId=@SchoolId";
			SqlParameter[] _param={				
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Domain",SqlDbType.VarChar),
				new SqlParameter("@LocationId",SqlDbType.Int),
				new SqlParameter("@Agent",SqlDbType.Int),
				new SqlParameter("@Linkman",SqlDbType.VarChar),
				new SqlParameter("@Mail",SqlDbType.VarChar),
				new SqlParameter("@Phone",SqlDbType.VarChar),
				new SqlParameter("@Tel",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime),
				new SqlParameter("@Begintime",SqlDbType.DateTime),
				new SqlParameter("@Endtime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_SchoolModel.SchoolId;
				_param[1].Value=_tb_SchoolModel.Name;
				_param[2].Value=_tb_SchoolModel.Domain;
				_param[3].Value=_tb_SchoolModel.LocationId;
				_param[4].Value=_tb_SchoolModel.Agent;
				_param[5].Value=_tb_SchoolModel.Linkman;
				_param[6].Value=_tb_SchoolModel.Mail;
				_param[7].Value=_tb_SchoolModel.Phone;
				_param[8].Value=_tb_SchoolModel.Tel;
				_param[9].Value=_tb_SchoolModel.Status;
				_param[10].Value=_tb_SchoolModel.Addtime;
				_param[11].Value=_tb_SchoolModel.Updatetime;
				_param[12].Value=_tb_SchoolModel.Begintime;
				_param[13].Value=_tb_SchoolModel.Endtime;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_School更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_SchoolModel">_tb_SchoolModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_SchoolEntity _tb_SchoolModel)
		{
            string sqlStr="update tb_School set [Name]=@Name,[Domain]=@Domain,[LocationId]=@LocationId,[Agent]=@Agent,[Linkman]=@Linkman,[Mail]=@Mail,[Phone]=@Phone,[Tel]=@Tel,[Status]=@Status,[Addtime]=@Addtime,[Updatetime]=@Updatetime,[Begintime]=@Begintime,[Endtime]=@Endtime where SchoolId=@SchoolId";
			SqlParameter[] _param={				
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Domain",SqlDbType.VarChar),
				new SqlParameter("@LocationId",SqlDbType.Int),
				new SqlParameter("@Agent",SqlDbType.Int),
				new SqlParameter("@Linkman",SqlDbType.VarChar),
				new SqlParameter("@Mail",SqlDbType.VarChar),
				new SqlParameter("@Phone",SqlDbType.VarChar),
				new SqlParameter("@Tel",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime),
				new SqlParameter("@Begintime",SqlDbType.DateTime),
				new SqlParameter("@Endtime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_SchoolModel.SchoolId;
				_param[1].Value=_tb_SchoolModel.Name;
				_param[2].Value=_tb_SchoolModel.Domain;
				_param[3].Value=_tb_SchoolModel.LocationId;
				_param[4].Value=_tb_SchoolModel.Agent;
				_param[5].Value=_tb_SchoolModel.Linkman;
				_param[6].Value=_tb_SchoolModel.Mail;
				_param[7].Value=_tb_SchoolModel.Phone;
				_param[8].Value=_tb_SchoolModel.Tel;
				_param[9].Value=_tb_SchoolModel.Status;
				_param[10].Value=_tb_SchoolModel.Addtime;
				_param[11].Value=_tb_SchoolModel.Updatetime;
				_param[12].Value=_tb_SchoolModel.Begintime;
				_param[13].Value=_tb_SchoolModel.Endtime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_School中的一条记录
		/// </summary>
	    /// <param name="SchoolId">schoolId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int SchoolId)
		{
			string sqlStr="delete from tb_School where [SchoolId]=@SchoolId";
			SqlParameter[] _param={			
			new SqlParameter("@SchoolId",SqlDbType.Int),
			
			};			
			_param[0].Value=SchoolId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_School中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="SchoolId">schoolId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int SchoolId)
		{
			string sqlStr="delete from tb_School where [SchoolId]=@SchoolId";
			SqlParameter[] _param={			
			new SqlParameter("@SchoolId",SqlDbType.Int),
			
			};			
			_param[0].Value=SchoolId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_school 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_school 数据实体</returns>
		public tb_SchoolEntity Populate_tb_SchoolEntity_FromDr(DataRow row)
		{
			tb_SchoolEntity Obj = new tb_SchoolEntity();
			if(row!=null)
			{
				Obj.SchoolId = (( row["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( row["SchoolId"]);
				Obj.Name =  row["Name"].ToString();
				Obj.Domain =  row["Domain"].ToString();
				Obj.LocationId = (( row["LocationId"])==DBNull.Value)?0:Convert.ToInt32( row["LocationId"]);
				Obj.Agent = (( row["Agent"])==DBNull.Value)?0:Convert.ToInt32( row["Agent"]);
				Obj.Linkman =  row["Linkman"].ToString();
				Obj.Mail =  row["Mail"].ToString();
				Obj.Phone =  row["Phone"].ToString();
				Obj.Tel =  row["Tel"].ToString();
				Obj.Status = (( row["Status"])==DBNull.Value)?0:Convert.ToInt32( row["Status"]);
				Obj.Addtime = (( row["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["Addtime"]);
				Obj.Updatetime = (( row["Updatetime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["Updatetime"]);
				Obj.Begintime = (( row["Begintime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["Begintime"]);
				Obj.Endtime = (( row["Endtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["Endtime"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_school 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_school 数据实体</returns>
		public tb_SchoolEntity Populate_tb_SchoolEntity_FromDr(IDataReader dr)
		{
			tb_SchoolEntity Obj = new tb_SchoolEntity();
			
				Obj.SchoolId = (( dr["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( dr["SchoolId"]);
				Obj.Name =  dr["Name"].ToString();
				Obj.Domain =  dr["Domain"].ToString();
				Obj.LocationId = (( dr["LocationId"])==DBNull.Value)?0:Convert.ToInt32( dr["LocationId"]);
				Obj.Agent = (( dr["Agent"])==DBNull.Value)?0:Convert.ToInt32( dr["Agent"]);
				Obj.Linkman =  dr["Linkman"].ToString();
				Obj.Mail =  dr["Mail"].ToString();
				Obj.Phone =  dr["Phone"].ToString();
				Obj.Tel =  dr["Tel"].ToString();
				Obj.Status = (( dr["Status"])==DBNull.Value)?0:Convert.ToInt32( dr["Status"]);
				Obj.Addtime = (( dr["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Addtime"]);
				Obj.Updatetime = (( dr["Updatetime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Updatetime"]);
				Obj.Begintime = (( dr["Begintime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Begintime"]);
				Obj.Endtime = (( dr["Endtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Endtime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_School对象
		/// </summary>
		/// <param name="schoolId">schoolId</param>
		/// <returns>tb_School对象</returns>
		public tb_SchoolEntity Get_tb_SchoolEntity (int schoolId)
		{
			tb_SchoolEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int)
			};
			_param[0].Value=schoolId;
			string sqlStr="select * from tb_School with(nolock) where SchoolId=@SchoolId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_SchoolEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_School所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_SchoolEntity> Get_tb_SchoolAll()
		{
			IList< tb_SchoolEntity> Obj=new List< tb_SchoolEntity>();
			string sqlStr="select * from tb_School";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_SchoolEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="schoolId">schoolId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_School(int schoolId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@schoolId",SqlDbType.Int)
                                  };
            _param[0].Value=schoolId;
            string sqlStr="select Count(*) from tb_School where SchoolId=@schoolId";
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
