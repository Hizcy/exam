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
using System.Collections.Generic;
using System.Text;
using Exam.DAL;
using Exam.Entity;
using System.Data;
using System.Web;
using System.Linq;

namespace Exam.BLL
{
    public partial class tb_LocationBLL : BaseBLL< tb_LocationBLL>

    {
        tb_LocationDataAccessLayer tb_Locationdal;
        public tb_LocationBLL()
        {
            tb_Locationdal = new tb_LocationDataAccessLayer();
        }

        public int Insert(tb_LocationEntity tb_LocationEntity)
        {
            return tb_Locationdal.Insert(tb_LocationEntity);            
        }

        public void Update(tb_LocationEntity tb_LocationEntity)
        {
            tb_Locationdal.Update(tb_LocationEntity);
        }

        public tb_LocationEntity GetAdminSingle(int locationId)
        {
           return tb_Locationdal.Get_tb_LocationEntity(locationId);
        }

        public IList<tb_LocationEntity> Gettb_LocationList()
        {
            IList<tb_LocationEntity> tb_LocationList = new List<tb_LocationEntity>();
            tb_LocationList=tb_Locationdal.Get_tb_LocationAll();
            return tb_LocationList;
        }

        public IList<tb_LocationEntity> GetProvinceList()
        {
            IList<tb_LocationEntity> tb_LocationList = new List<tb_LocationEntity>();
            tb_LocationList = tb_Locationdal.GetProvinceList();
            return tb_LocationList;
        }
        public IList<tb_LocationEntity> GetCityList(int ProvinceId)
        {
            IList<tb_LocationEntity> tb_LocationList = new List<tb_LocationEntity>();
            tb_LocationList = tb_Locationdal.GetCityList(ProvinceId);
            return tb_LocationList;
        }
        public IList<tb_LocationEntity> GetEurozoneList(int CityId)
        {
            IList<tb_LocationEntity> tb_LocationList = new List<tb_LocationEntity>();
            tb_LocationList = tb_Locationdal.GetEurozoneList(CityId);
            return tb_LocationList;
        }
        public DataSet GetLocationIdByLocationId(int licotionId)
        {
            return tb_Locationdal.GetLocationByLocationID(licotionId);
        }
        public tb_LocationEntity GetLocationByLocationGroupId(int locationGroupId)
        {
            return tb_Locationdal.GetLocationByLocationGroupId(locationGroupId);
        }
        public DataSet GetLocationInfo(int locationId)
        {
            return tb_Locationdal.GetLocationInfo(locationId);
        }
        public IList<tb_LocationEntity> GetLocationInfo(string path,int typeId)
        {
            return tb_Locationdal.GetLocationInfo(path, typeId);
        }
        #region 地区缓存
        public IList<Exam.Entity.tb_LocationEntity> GetLocationListByCache()
        {
            string key = "LOCATION_LIST";
            if (HttpContext.Current.Cache[key] != null)
            {
                return HttpContext.Current.Cache[key] as IList<Exam.Entity.tb_LocationEntity>;
            }
            else
            {
                IList<Exam.Entity.tb_LocationEntity> list = Exam.BLL.tb_LocationBLL.GetInstance().Gettb_LocationList();
                if (list == null)
                    return new List<Exam.Entity.tb_LocationEntity>();

                HttpContext.Current.Cache.Insert(key, list, null, DateTime.Now.AddHours(6), TimeSpan.Zero);
                return list;
            }
        }
        public IList<Exam.Entity.tb_LocationEntity> GetProvinceByCache()
        {
            IList<Exam.Entity.tb_LocationEntity> list = GetLocationListByCache();

            return list.Where(c => c.LocationParentId == 0 && c.LocationId < 700000).ToList();
        }
        public IList<Exam.Entity.tb_LocationEntity> GetCityByCache(int cityId)
        {
            IList<Exam.Entity.tb_LocationEntity> list = GetLocationListByCache();

            return list.Where(c => c.LocationParentId == cityId).ToList();
        }
        public IList<Exam.Entity.tb_LocationEntity> GetEurozoneByCache(int eurozone)
        {
            IList<Exam.Entity.tb_LocationEntity> list = GetLocationListByCache();

            return list.Where(c => c.LocationParentId == eurozone).ToList();
        }
        #endregion
    }
}
