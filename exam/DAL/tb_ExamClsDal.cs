// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_ExamCls.cs
// 项目名称：买车网
// 创建时间：2015/8/13
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
    /// 数据层实例化接口类 dbo.tb_ExamCls.
    /// </summary>
    public partial class tb_ExamClsDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_ExamClsDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_ExamClsModel">tb_ExamCls实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_ExamClsEntity _tb_ExamClsModel)
		{
			string sqlStr="insert into tb_ExamCls([SchoolId],[ParentId],[Name],[Description],[Status],[Addtime],[Updatetime]) values(@SchoolId,@ParentId,@Name,@Description,@Status,@Addtime,@Updatetime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@ParentId",SqlDbType.Int),
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Description",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_ExamClsModel.SchoolId;
			_param[1].Value=_tb_ExamClsModel.ParentId;
			_param[2].Value=_tb_ExamClsModel.Name;
			_param[3].Value=_tb_ExamClsModel.Description;
			_param[4].Value=_tb_ExamClsModel.Status;
			_param[5].Value=_tb_ExamClsModel.Addtime;
			_param[6].Value=_tb_ExamClsModel.Updatetime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ExamClsModel">tb_ExamCls实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_ExamClsEntity _tb_ExamClsModel)
		{
			string sqlStr="insert into tb_ExamCls([SchoolId],[ParentId],[Name],[Description],[Status],[Addtime],[Updatetime]) values(@SchoolId,@ParentId,@Name,@Description,@Status,@Addtime,@Updatetime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@SchoolId",SqlDbType.Int),
			new SqlParameter("@ParentId",SqlDbType.Int),
			new SqlParameter("@Name",SqlDbType.VarChar),
			new SqlParameter("@Description",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Addtime",SqlDbType.DateTime),
			new SqlParameter("@Updatetime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_ExamClsModel.SchoolId;
			_param[1].Value=_tb_ExamClsModel.ParentId;
			_param[2].Value=_tb_ExamClsModel.Name;
			_param[3].Value=_tb_ExamClsModel.Description;
			_param[4].Value=_tb_ExamClsModel.Status;
			_param[5].Value=_tb_ExamClsModel.Addtime;
			_param[6].Value=_tb_ExamClsModel.Updatetime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_ExamCls更新一条记录。
		/// </summary>
		/// <param name="_tb_ExamClsModel">_tb_ExamClsModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_ExamClsEntity _tb_ExamClsModel)
		{
            string sqlStr="update tb_ExamCls set [SchoolId]=@SchoolId,[ParentId]=@ParentId,[Name]=@Name,[Description]=@Description,[Status]=@Status,[Addtime]=@Addtime,[Updatetime]=@Updatetime where ExamClsId=@ExamClsId";
			SqlParameter[] _param={				
				new SqlParameter("@ExamClsId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@ParentId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Description",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_ExamClsModel.ExamClsId;
				_param[1].Value=_tb_ExamClsModel.SchoolId;
				_param[2].Value=_tb_ExamClsModel.ParentId;
				_param[3].Value=_tb_ExamClsModel.Name;
				_param[4].Value=_tb_ExamClsModel.Description;
				_param[5].Value=_tb_ExamClsModel.Status;
				_param[6].Value=_tb_ExamClsModel.Addtime;
				_param[7].Value=_tb_ExamClsModel.Updatetime;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_ExamCls更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ExamClsModel">_tb_ExamClsModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_ExamClsEntity _tb_ExamClsModel)
		{
            string sqlStr="update tb_ExamCls set [SchoolId]=@SchoolId,[ParentId]=@ParentId,[Name]=@Name,[Description]=@Description,[Status]=@Status,[Addtime]=@Addtime,[Updatetime]=@Updatetime where ExamClsId=@ExamClsId";
			SqlParameter[] _param={				
				new SqlParameter("@ExamClsId",SqlDbType.Int),
				new SqlParameter("@SchoolId",SqlDbType.Int),
				new SqlParameter("@ParentId",SqlDbType.Int),
				new SqlParameter("@Name",SqlDbType.VarChar),
				new SqlParameter("@Description",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@Addtime",SqlDbType.DateTime),
				new SqlParameter("@Updatetime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_ExamClsModel.ExamClsId;
				_param[1].Value=_tb_ExamClsModel.SchoolId;
				_param[2].Value=_tb_ExamClsModel.ParentId;
				_param[3].Value=_tb_ExamClsModel.Name;
				_param[4].Value=_tb_ExamClsModel.Description;
				_param[5].Value=_tb_ExamClsModel.Status;
				_param[6].Value=_tb_ExamClsModel.Addtime;
				_param[7].Value=_tb_ExamClsModel.Updatetime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_ExamCls中的一条记录
		/// </summary>
	    /// <param name="ExamClsId">examClsId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ExamClsId)
		{
			string sqlStr="delete from tb_ExamCls where [ExamClsId]=@ExamClsId";
			SqlParameter[] _param={			
			new SqlParameter("@ExamClsId",SqlDbType.Int),
			
			};			
			_param[0].Value=ExamClsId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_ExamCls中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ExamClsId">examClsId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ExamClsId)
		{
			string sqlStr="delete from tb_ExamCls where [ExamClsId]=@ExamClsId";
			SqlParameter[] _param={			
			new SqlParameter("@ExamClsId",SqlDbType.Int),
			
			};			
			_param[0].Value=ExamClsId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_examcls 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_examcls 数据实体</returns>
		public tb_ExamClsEntity Populate_tb_ExamClsEntity_FromDr(DataRow row)
		{
			tb_ExamClsEntity Obj = new tb_ExamClsEntity();
			if(row!=null)
			{
				Obj.ExamClsId = (( row["ExamClsId"])==DBNull.Value)?0:Convert.ToInt32( row["ExamClsId"]);
				Obj.SchoolId = (( row["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( row["SchoolId"]);
				Obj.ParentId = (( row["ParentId"])==DBNull.Value)?0:Convert.ToInt32( row["ParentId"]);
				Obj.Name =  row["Name"].ToString();
				Obj.Description =  row["Description"].ToString();
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
		/// 得到  tb_examcls 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_examcls 数据实体</returns>
		public tb_ExamClsEntity Populate_tb_ExamClsEntity_FromDr(IDataReader dr)
		{
			tb_ExamClsEntity Obj = new tb_ExamClsEntity();
			
				Obj.ExamClsId = (( dr["ExamClsId"])==DBNull.Value)?0:Convert.ToInt32( dr["ExamClsId"]);
				Obj.SchoolId = (( dr["SchoolId"])==DBNull.Value)?0:Convert.ToInt32( dr["SchoolId"]);
				Obj.ParentId = (( dr["ParentId"])==DBNull.Value)?0:Convert.ToInt32( dr["ParentId"]);
				Obj.Name =  dr["Name"].ToString();
				Obj.Description =  dr["Description"].ToString();
				Obj.Status = (( dr["Status"])==DBNull.Value)?0:Convert.ToInt32( dr["Status"]);
				Obj.Addtime = (( dr["Addtime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Addtime"]);
				Obj.Updatetime = (( dr["Updatetime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Updatetime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_ExamCls对象
		/// </summary>
		/// <param name="examClsId">examClsId</param>
		/// <returns>tb_ExamCls对象</returns>
		public tb_ExamClsEntity Get_tb_ExamClsEntity (int examClsId)
		{
			tb_ExamClsEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ExamClsId",SqlDbType.Int)
			};
			_param[0].Value=examClsId;
			string sqlStr="select * from tb_ExamCls with(nolock) where ExamClsId=@ExamClsId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_ExamClsEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_ExamCls所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_ExamClsEntity> Get_tb_ExamClsAll()
		{
			IList< tb_ExamClsEntity> Obj=new List< tb_ExamClsEntity>();
			string sqlStr="select * from tb_ExamCls";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_ExamClsEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="examClsId">examClsId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_ExamCls(int examClsId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@examClsId",SqlDbType.Int)
                                  };
            _param[0].Value=examClsId;
            string sqlStr="select Count(*) from tb_ExamCls where ExamClsId=@examClsId";
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
