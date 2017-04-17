// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Department.cs
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
    /// 数据层实例化接口类 dbo.tb_Department.
    /// </summary>
    public partial class tb_DepartmentDataAccessLayer 
    {
        public IList<tb_DepartmentEntity> Get_tb_DepartmentBySchoolId(int schoolId)
        {
            IList<tb_DepartmentEntity> Obj = new List<tb_DepartmentEntity>();
            SqlParameter[] _param ={
                                new SqlParameter("@SchoolId",SqlDbType.Int)
             };
            _param[0].Value = schoolId;
            string sqlStr = "select * from tb_Department where schoolid=@SchoolId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_DepartmentEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public IList<tb_DepartmentEntity> Get_tb_DepartmentByParentID(int parentId)
        {
            IList<tb_DepartmentEntity> Obj = new List<tb_DepartmentEntity>();
            SqlParameter[] _param ={
                                new SqlParameter("@ParentId",SqlDbType.Int)
             };
            _param[0].Value = parentId;
            string sqlStr = "select * from tb_Department where parentid=@ParentId and status=1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_DepartmentEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public IList<tb_DepartmentEntity> Get_tb_DepartmentBySchoolIdTow(int schoolId)
        {
            IList<tb_DepartmentEntity> Obj = new List<tb_DepartmentEntity>();
            SqlParameter[] _param ={
                                new SqlParameter("@SchoolId",SqlDbType.Int)
             };
            _param[0].Value = schoolId;
            string sqlStr = "select * from tb_Department where schoolid=@SchoolId and parentid = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_DepartmentEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public int Delete_tbDepartmentByDepartmentId(int departmentid)
        {
            SqlParameter[] _param = { 
                            new SqlParameter("@DepartmentId", SqlDbType.Int) 
                  };
            _param[0].Value = departmentid;
            string sqlStr = "delete from tb_Department where departmentid=@DepartmentId";
            return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
        }
        public int Delete_tbDepartmentByParentId(int parentId)
        {
            SqlParameter[] _param = { 
                            new SqlParameter("@ParentId", SqlDbType.Int) 
                  };
            _param[0].Value = parentId;
            string sqlStr = "delete from tb_Department where parentid=@ParentId";
            return SqlHelper.ExecuteNonQuery(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
        }
        public tb_DepartmentEntity Get_DepartmentBySchoolIdName(int schoolId, string name)
        {
            tb_DepartmentEntity _obj = null;
            SqlParameter[] _param ={
                          new SqlParameter("@SchoolId",SqlDbType.Int),
                          new SqlParameter("@Name",SqlDbType.NVarChar)
                  };
            _param[0].Value = schoolId;
            _param[1].Value = name;
            string sqlStr = "select * from tb_Department with(nolock)  where schoolid =@SchoolId and name=@Name";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_DepartmentEntity_FromDr(dr);   
                }
            }
            return _obj;
        }
        public tb_DepartmentEntity Get_DepartmentEntityBySchoolId(int schoolId)
        {
            tb_DepartmentEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@SchoolId",SqlDbType.Int)
			};
            _param[0].Value = schoolId;
            string sqlStr = "select * from tb_Department with(nolock) where schoolId=@SchoolId and parentid = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                if (dr.Read())
                {
                    _obj = Populate_tb_DepartmentEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        public IList<tb_DepartmentEntity> Get_DepartmentBySchoolIdList(int schoolId)
        {
            IList<tb_DepartmentEntity> Obj = new List<tb_DepartmentEntity>();
            SqlParameter[] _param ={
                                new SqlParameter("@SchoolId",SqlDbType.Int)
             };
            _param[0].Value = schoolId;
            string sqlStr = "select * from tb_Department where schoolid=@SchoolId and parentid != 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_DepartmentEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        //所有数据
        public IList<tb_DepartmentEntity> Get_tb_DepartmentByParentIdNowSataus(int parentId)
        {
            IList<tb_DepartmentEntity> Obj = new List<tb_DepartmentEntity>();
            SqlParameter[] _param ={
                                new SqlParameter("@ParentId",SqlDbType.Int)
             };
            _param[0].Value = parentId;
            string sqlStr = "select * from tb_Department where parentid=@ParentId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_DepartmentEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public DataSet Get_DepartmentDataSet(string parentid,int schoolId)
        {
            SqlParameter[] _param ={
                        
                        new SqlParameter("@SchoolId",SqlDbType.Int),
                    };
            
            _param[0].Value = schoolId;
            string sqlStr = "select *from  v_Department where parentid in(" + parentid + ") and schoolid=@SchoolId";
            DataSet ds = SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
            return ds;
            
        }
        public DataSet Get_DepartmentDataSetByDepartmentId(string DepartmentId, int schoolId)
        {
            SqlParameter[] _param ={
                        
                        new SqlParameter("@SchoolId",SqlDbType.Int),
                    };

            _param[0].Value = schoolId;
            string sqlStr = "select *from  v_Department where DepartmentId in(" + DepartmentId + ") and schoolid=@SchoolId";
            DataSet ds = SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
            return ds;

        }
        public DataSet Get_DepartmentDataSetId(string DepartmentId, int schoolId)
        {
            SqlParameter[] _param ={
                        
                        new SqlParameter("@SchoolId",SqlDbType.Int),
                    };

            _param[0].Value = schoolId;
            string sqlStr = "select distinct parentid,parentname from v_Department where departmentid in (" + DepartmentId + ") and schoolid=@SchoolId";
            DataSet ds = SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
            return ds;

        }
        public DataSet Get_DepartmentDataSetIdThree(string DepartmentId, int schoolId,int parentId)
        {
            SqlParameter[] _param ={
                        
                        new SqlParameter("@SchoolId",SqlDbType.Int),
                        new SqlParameter("@ParebtId",SqlDbType.Int)
                    };

            _param[0].Value = schoolId;
            _param[1].Value = parentId;
            string sqlStr = "select departmentid,name from v_Department where departmentid in (" + DepartmentId + ") and parentid = @ParebtId and  schoolid=@SchoolId";
            DataSet ds = SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
            return ds;

        }
        public DataSet GetYearClassName(int schoolId, int roleid) 
        {
            SqlParameter[] _param ={
                         new SqlParameter("@SchoolId",SqlDbType.Int),
                         new SqlParameter("@RoleId",SqlDbType.Int)
                   };
            _param[0].Value = schoolId;
            _param[1].Value = roleid;
            string sqlStr = "SELECT parentname+[Name] as name,departmentID,parentid FROM [exam].[dbo].[v_Department] where schoolid=@SchoolId and roleid =@RoleId";
            DataSet ds = SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr, _param);
            return ds;
        }

	}
}
