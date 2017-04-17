// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Location.cs
// 项目名称：买车网
// 创建时间：2015/8/10
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
    /// 数据层实例化接口类 dbo.tb_Location.
    /// </summary>
    public partial class tb_LocationDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_LocationDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_LocationModel">tb_Location实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_LocationEntity _tb_LocationModel)
		{
			string sqlStr="insert into tb_Location([LocationId],[LocationParentId],[LocationGroupId],[LocationName],[LocationRemark],[LocationStatus],[LocationPath],[LocationGeographyTypeId],[LocationBusinessTypeId],[LocationShortName],[LocationSpellName],[OtherParentId]) values(@LocationId,@LocationParentId,@LocationGroupId,@LocationName,@LocationRemark,@LocationStatus,@LocationPath,@LocationGeographyTypeId,@LocationBusinessTypeId,@LocationShortName,@LocationSpellName,@OtherParentId) select @LocationId";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@LocationId",SqlDbType.Int),
			new SqlParameter("@LocationParentId",SqlDbType.Int),
			new SqlParameter("@LocationGroupId",SqlDbType.Int),
			new SqlParameter("@LocationName",SqlDbType.VarChar),
			new SqlParameter("@LocationRemark",SqlDbType.VarChar),
			new SqlParameter("@LocationStatus",SqlDbType.Int),
			new SqlParameter("@LocationPath",SqlDbType.VarChar),
			new SqlParameter("@LocationGeographyTypeId",SqlDbType.Int),
			new SqlParameter("@LocationBusinessTypeId",SqlDbType.Int),
			new SqlParameter("@LocationShortName",SqlDbType.VarChar),
			new SqlParameter("@LocationSpellName",SqlDbType.VarChar),
			new SqlParameter("@OtherParentId",SqlDbType.Int)
			};			
			_param[0].Value=_tb_LocationModel.LocationId;
			_param[1].Value=_tb_LocationModel.LocationParentId;
			_param[2].Value=_tb_LocationModel.LocationGroupId;
			_param[3].Value=_tb_LocationModel.LocationName;
			_param[4].Value=_tb_LocationModel.LocationRemark;
			_param[5].Value=_tb_LocationModel.LocationStatus;
			_param[6].Value=_tb_LocationModel.LocationPath;
			_param[7].Value=_tb_LocationModel.LocationGeographyTypeId;
			_param[8].Value=_tb_LocationModel.LocationBusinessTypeId;
			_param[9].Value=_tb_LocationModel.LocationShortName;
			_param[10].Value=_tb_LocationModel.LocationSpellName;
			_param[11].Value=_tb_LocationModel.OtherParentId;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.ExamRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_LocationModel">tb_Location实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_LocationEntity _tb_LocationModel)
		{
			string sqlStr="insert into tb_Location([LocationId],[LocationParentId],[LocationGroupId],[LocationName],[LocationRemark],[LocationStatus],[LocationPath],[LocationGeographyTypeId],[LocationBusinessTypeId],[LocationShortName],[LocationSpellName],[OtherParentId]) values(@LocationId,@LocationParentId,@LocationGroupId,@LocationName,@LocationRemark,@LocationStatus,@LocationPath,@LocationGeographyTypeId,@LocationBusinessTypeId,@LocationShortName,@LocationSpellName,@OtherParentId) select @LocationId";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@LocationId",SqlDbType.Int),
			new SqlParameter("@LocationParentId",SqlDbType.Int),
			new SqlParameter("@LocationGroupId",SqlDbType.Int),
			new SqlParameter("@LocationName",SqlDbType.VarChar),
			new SqlParameter("@LocationRemark",SqlDbType.VarChar),
			new SqlParameter("@LocationStatus",SqlDbType.Int),
			new SqlParameter("@LocationPath",SqlDbType.VarChar),
			new SqlParameter("@LocationGeographyTypeId",SqlDbType.Int),
			new SqlParameter("@LocationBusinessTypeId",SqlDbType.Int),
			new SqlParameter("@LocationShortName",SqlDbType.VarChar),
			new SqlParameter("@LocationSpellName",SqlDbType.VarChar),
			new SqlParameter("@OtherParentId",SqlDbType.Int)
			};			
			_param[0].Value=_tb_LocationModel.LocationId;
			_param[1].Value=_tb_LocationModel.LocationParentId;
			_param[2].Value=_tb_LocationModel.LocationGroupId;
			_param[3].Value=_tb_LocationModel.LocationName;
			_param[4].Value=_tb_LocationModel.LocationRemark;
			_param[5].Value=_tb_LocationModel.LocationStatus;
			_param[6].Value=_tb_LocationModel.LocationPath;
			_param[7].Value=_tb_LocationModel.LocationGeographyTypeId;
			_param[8].Value=_tb_LocationModel.LocationBusinessTypeId;
			_param[9].Value=_tb_LocationModel.LocationShortName;
			_param[10].Value=_tb_LocationModel.LocationSpellName;
			_param[11].Value=_tb_LocationModel.OtherParentId;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Location更新一条记录。
		/// </summary>
		/// <param name="_tb_LocationModel">_tb_LocationModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_LocationEntity _tb_LocationModel)
		{
            string sqlStr="update tb_Location set [LocationParentId]=@LocationParentId,[LocationGroupId]=@LocationGroupId,[LocationName]=@LocationName,[LocationRemark]=@LocationRemark,[LocationStatus]=@LocationStatus,[LocationPath]=@LocationPath,[LocationGeographyTypeId]=@LocationGeographyTypeId,[LocationBusinessTypeId]=@LocationBusinessTypeId,[LocationShortName]=@LocationShortName,[LocationSpellName]=@LocationSpellName,[OtherParentId]=@OtherParentId where LocationId=@LocationId";
			SqlParameter[] _param={				
				new SqlParameter("@LocationId",SqlDbType.Int),
				new SqlParameter("@LocationParentId",SqlDbType.Int),
				new SqlParameter("@LocationGroupId",SqlDbType.Int),
				new SqlParameter("@LocationName",SqlDbType.VarChar),
				new SqlParameter("@LocationRemark",SqlDbType.VarChar),
				new SqlParameter("@LocationStatus",SqlDbType.Int),
				new SqlParameter("@LocationPath",SqlDbType.VarChar),
				new SqlParameter("@LocationGeographyTypeId",SqlDbType.Int),
				new SqlParameter("@LocationBusinessTypeId",SqlDbType.Int),
				new SqlParameter("@LocationShortName",SqlDbType.VarChar),
				new SqlParameter("@LocationSpellName",SqlDbType.VarChar),
				new SqlParameter("@OtherParentId",SqlDbType.Int)
				};				
				_param[0].Value=_tb_LocationModel.LocationId;
				_param[1].Value=_tb_LocationModel.LocationParentId;
				_param[2].Value=_tb_LocationModel.LocationGroupId;
				_param[3].Value=_tb_LocationModel.LocationName;
				_param[4].Value=_tb_LocationModel.LocationRemark;
				_param[5].Value=_tb_LocationModel.LocationStatus;
				_param[6].Value=_tb_LocationModel.LocationPath;
				_param[7].Value=_tb_LocationModel.LocationGeographyTypeId;
				_param[8].Value=_tb_LocationModel.LocationBusinessTypeId;
				_param[9].Value=_tb_LocationModel.LocationShortName;
				_param[10].Value=_tb_LocationModel.LocationSpellName;
				_param[11].Value=_tb_LocationModel.OtherParentId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Location更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_LocationModel">_tb_LocationModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_LocationEntity _tb_LocationModel)
		{
            string sqlStr="update tb_Location set [LocationParentId]=@LocationParentId,[LocationGroupId]=@LocationGroupId,[LocationName]=@LocationName,[LocationRemark]=@LocationRemark,[LocationStatus]=@LocationStatus,[LocationPath]=@LocationPath,[LocationGeographyTypeId]=@LocationGeographyTypeId,[LocationBusinessTypeId]=@LocationBusinessTypeId,[LocationShortName]=@LocationShortName,[LocationSpellName]=@LocationSpellName,[OtherParentId]=@OtherParentId where LocationId=@LocationId";
			SqlParameter[] _param={				
				new SqlParameter("@LocationId",SqlDbType.Int),
				new SqlParameter("@LocationParentId",SqlDbType.Int),
				new SqlParameter("@LocationGroupId",SqlDbType.Int),
				new SqlParameter("@LocationName",SqlDbType.VarChar),
				new SqlParameter("@LocationRemark",SqlDbType.VarChar),
				new SqlParameter("@LocationStatus",SqlDbType.Int),
				new SqlParameter("@LocationPath",SqlDbType.VarChar),
				new SqlParameter("@LocationGeographyTypeId",SqlDbType.Int),
				new SqlParameter("@LocationBusinessTypeId",SqlDbType.Int),
				new SqlParameter("@LocationShortName",SqlDbType.VarChar),
				new SqlParameter("@LocationSpellName",SqlDbType.VarChar),
				new SqlParameter("@OtherParentId",SqlDbType.Int)
				};				
				_param[0].Value=_tb_LocationModel.LocationId;
				_param[1].Value=_tb_LocationModel.LocationParentId;
				_param[2].Value=_tb_LocationModel.LocationGroupId;
				_param[3].Value=_tb_LocationModel.LocationName;
				_param[4].Value=_tb_LocationModel.LocationRemark;
				_param[5].Value=_tb_LocationModel.LocationStatus;
				_param[6].Value=_tb_LocationModel.LocationPath;
				_param[7].Value=_tb_LocationModel.LocationGeographyTypeId;
				_param[8].Value=_tb_LocationModel.LocationBusinessTypeId;
				_param[9].Value=_tb_LocationModel.LocationShortName;
				_param[10].Value=_tb_LocationModel.LocationSpellName;
				_param[11].Value=_tb_LocationModel.OtherParentId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Location中的一条记录
		/// </summary>
	    /// <param name="LocationId">locationId</param>
		/// <returns>影响的行数</returns>
		public int Delete(int LocationId)
		{
			string sqlStr="delete from tb_Location where [LocationId]=@LocationId";
			SqlParameter[] _param={			
			new SqlParameter("@LocationId",SqlDbType.Int),
			
			};			
			_param[0].Value=LocationId;
			return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_Location中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="LocationId">locationId</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int LocationId)
		{
			string sqlStr="delete from tb_Location where [LocationId]=@LocationId";
			SqlParameter[] _param={			
			new SqlParameter("@LocationId",SqlDbType.Int),
			
			};			
			_param[0].Value=LocationId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_location 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_location 数据实体</returns>
		public tb_LocationEntity Populate_tb_LocationEntity_FromDr(DataRow row)
		{
			tb_LocationEntity Obj = new tb_LocationEntity();
			if(row!=null)
			{
				Obj.LocationId = (( row["LocationId"])==DBNull.Value)?0:Convert.ToInt32( row["LocationId"]);
				Obj.LocationParentId = (( row["LocationParentId"])==DBNull.Value)?0:Convert.ToInt32( row["LocationParentId"]);
				Obj.LocationGroupId = (( row["LocationGroupId"])==DBNull.Value)?0:Convert.ToInt32( row["LocationGroupId"]);
				Obj.LocationName =  row["LocationName"].ToString();
				Obj.LocationRemark =  row["LocationRemark"].ToString();
				Obj.LocationStatus = (( row["LocationStatus"])==DBNull.Value)?0:Convert.ToInt32( row["LocationStatus"]);
				Obj.LocationPath =  row["LocationPath"].ToString();
				Obj.LocationGeographyTypeId = (( row["LocationGeographyTypeId"])==DBNull.Value)?0:Convert.ToInt32( row["LocationGeographyTypeId"]);
				Obj.LocationBusinessTypeId = (( row["LocationBusinessTypeId"])==DBNull.Value)?0:Convert.ToInt32( row["LocationBusinessTypeId"]);
				Obj.LocationShortName =  row["LocationShortName"].ToString();
				Obj.LocationSpellName =  row["LocationSpellName"].ToString();
				Obj.OtherParentId = (( row["OtherParentId"])==DBNull.Value)?0:Convert.ToInt32( row["OtherParentId"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_location 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_location 数据实体</returns>
		public tb_LocationEntity Populate_tb_LocationEntity_FromDr(IDataReader dr)
		{
			tb_LocationEntity Obj = new tb_LocationEntity();
			
				Obj.LocationId = (( dr["LocationId"])==DBNull.Value)?0:Convert.ToInt32( dr["LocationId"]);
				Obj.LocationParentId = (( dr["LocationParentId"])==DBNull.Value)?0:Convert.ToInt32( dr["LocationParentId"]);
				Obj.LocationGroupId = (( dr["LocationGroupId"])==DBNull.Value)?0:Convert.ToInt32( dr["LocationGroupId"]);
				Obj.LocationName =  dr["LocationName"].ToString();
				Obj.LocationRemark =  dr["LocationRemark"].ToString();
				Obj.LocationStatus = (( dr["LocationStatus"])==DBNull.Value)?0:Convert.ToInt32( dr["LocationStatus"]);
				Obj.LocationPath =  dr["LocationPath"].ToString();
				Obj.LocationGeographyTypeId = (( dr["LocationGeographyTypeId"])==DBNull.Value)?0:Convert.ToInt32( dr["LocationGeographyTypeId"]);
				Obj.LocationBusinessTypeId = (( dr["LocationBusinessTypeId"])==DBNull.Value)?0:Convert.ToInt32( dr["LocationBusinessTypeId"]);
				Obj.LocationShortName =  dr["LocationShortName"].ToString();
				Obj.LocationSpellName =  dr["LocationSpellName"].ToString();
				Obj.OtherParentId = (( dr["OtherParentId"])==DBNull.Value)?0:Convert.ToInt32( dr["OtherParentId"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Location对象
		/// </summary>
		/// <param name="locationId">locationId</param>
		/// <returns>tb_Location对象</returns>
		public tb_LocationEntity Get_tb_LocationEntity (int locationId)
		{
			tb_LocationEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@LocationId",SqlDbType.Int)
			};
			_param[0].Value=locationId;
			string sqlStr="select * from tb_Location with(nolock) where LocationId=@LocationId";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_LocationEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Location所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_LocationEntity> Get_tb_LocationAll()
		{
			IList< tb_LocationEntity> Obj=new List< tb_LocationEntity>();
			string sqlStr="select * from tb_Location";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_LocationEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="locationId">locationId</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Location(int locationId)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@locationId",SqlDbType.Int)
                                  };
            _param[0].Value=locationId;
            string sqlStr="select Count(*) from tb_Location where LocationId=@locationId";
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
