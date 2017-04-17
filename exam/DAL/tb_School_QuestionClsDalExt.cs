// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_School_QuestionCls.cs
// 项目名称：买车网
// 创建时间：2015/8/29
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Exam.Entity;
using Jnwf.Utils.Data;


namespace Exam.DAL
{
    /// <summary>
    /// 数据层实例化接口类 dbo.tb_School_QuestionCls.
    /// </summary>
    public partial class tb_School_QuestionClsDataAccessLayer 
    {
        public DataSet Get_School_QuestionClsRelationIdBySchoolId(int schoolId, int parentId)
        {
            SqlParameter[] _param ={
                        new SqlParameter("@SchoolId",SqlDbType.Int),
                        new SqlParameter("@ParentId",SqlDbType.Int)
                   };
            _param[0].Value = schoolId;
            _param[1].Value = parentId;
            string sqlStr = "  SELECT a.*,isnull(b.relationid,0)as relationid,b.score pass,b.Ismust as reads FROM [exam].[dbo].[tb_QuestionCls] a left join [exam].[dbo].[tb_School_QuestionCls] b on a.questionclsid=b.questionclsid and b.schoolid=@SchoolId where a.status=1  and a.parentid=@ParentId order by questionclsid ";
            return SqlHelper.ExecuteDataset(WebConfig.ExamRW, CommandType.Text, sqlStr,_param);
        }
        public tb_School_QuestionClsEntity GetSchoolQuestionClsEntityByQuestionIdSchoolId(int questionId,int schoolid)
        {
            tb_School_QuestionClsEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@QuestionId",SqlDbType.Int),
            new SqlParameter("@SchoolId",SqlDbType.Int)
			};
            _param[0].Value = questionId;
            _param[1].Value = schoolid;
            string sqlStr = "select * from tb_School_QuestionCls with(nolock) where [QuestionClsId]=@QuestionId and schoolid = @SchoolId";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.ExamRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_School_QuestionClsEntity_FromDr(dr);
                }
            }
            return _obj;
        }
	}
}
