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
        public IList<tb_LocationEntity> GetProvinceList()
        {

            IList< tb_LocationEntity> Obj=new List< tb_LocationEntity>();
            string sqlStr = "SELECT * FROM tb_Location where LocationParentId=0  and LocationId<700000";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.ExamRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_LocationEntity_FromDr(dr));
				}
			}
			return Obj;
            
        }
        public IList<tb_LocationEntity> GetCityList(int ProvinceId)
        {

            IList<tb_LocationEntity> Obj = new List<tb_LocationEntity>();
            SqlParameter[] _param ={
                new SqlParameter("@ProvinceId",SqlDbType.Int)
            };
            _param[0].Value = ProvinceId;

            string sqlStr = "SELECT * FROM tb_Location where LocationParentId=@ProvinceId and LocationId<>0 and LocationId<700000";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr,_param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_LocationEntity_FromDr(dr));
                }
            }
            return Obj;

        }
        public IList<tb_LocationEntity> GetEurozoneList(int CityId)
        {

            IList<tb_LocationEntity> Obj = new List<tb_LocationEntity>();
            SqlParameter[] _param ={
                new SqlParameter("@CityId",SqlDbType.Int)
            };
            _param[0].Value = CityId;

            string sqlStr = "SELECT * FROM tb_Location where LocationParentId=@CityId and LocationId<>0 and LocationId<700000";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_LocationEntity_FromDr(dr));
                }
            }
            return Obj;

        }
        public DataSet GetLocationByLocationID(int LocationId)
        {
            string sqlStr = "SELECT * FROM [exam].[dbo].[v_Location] with(nolock) where locationid=@LocationId ";
            SqlParameter[] _param = { new SqlParameter("@LocationId", SqlDbType.Int) };
            _param[0].Value = LocationId;
            return SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr,_param);
        }
        public tb_LocationEntity GetLocationByLocationGroupId(int locationGroupId)
        {
            tb_LocationEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@LocationGroupId",SqlDbType.Int)
			};
            _param[0].Value = locationGroupId;
            string sqlStr = "select * from tb_Location with(nolock) where LocationGroupId=@LocationGroupId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_LocationEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        public DataSet GetLocationInfo(int locationId)
        {
            tb_LocationEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@LocationId",SqlDbType.Int)
			};
            _param[0].Value = locationId;
            string sqlStr = "select * from v_Location_t with(nolock) where LocationId=@LocationId";
            return SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
            
        }
        public IList<tb_LocationEntity> GetLocationInfo(string path,int typeId)
        {
            IList<tb_LocationEntity> Obj = new List<tb_LocationEntity>();
            SqlParameter[] _param ={
                //new SqlParameter("@LocationPath",SqlDbType.VarChar),
                new SqlParameter("@TypeId",SqlDbType.Int)
            };
            //_param[0].Value = path;
            _param[0].Value = typeId;
            string sqlStr = "select * from [exam].[dbo].[tb_Location] where [LocationId] in(  select locationid from [exam].[dbo].[tb_Location] where Locationpath like '" + path + "%' ) and [LocationGeographyTypeId]=@TypeId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_LocationEntity_FromDr(dr));
                }
            }
            return Obj;
        }
	}
}
