// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_ResultExt.cs
// 项目名称：买车网
// 创建时间：2015/8/27
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
    /// 数据层实例化接口类 dbo.tb_ResultExt.
    /// </summary>
    public partial class tb_ResultExtDataAccessLayer 
    {
        public void InsertSelect(List<tb_ResultExtEntity> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into tb_ResultExt (ResultId,QuestionId,Answer,IsRight) ");
            for (int i = 0; i < list.Count;i++ )
            {
                sb.Append("select " + list[i].ResultId + "," + list[i].QuestionId + ",'" + list[i].Answer + "'," + list[i].IsRight + " ");
                if ((i+1) != list.Count)
                {
                    sb.Append(" union ");
                }
            }
            SqlHelper.ExecuteNonQuery(WebConfig.ExamRW, CommandType.Text, sb.ToString());
            
        }
	}
}
